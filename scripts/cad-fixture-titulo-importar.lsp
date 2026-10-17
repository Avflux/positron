; Rodada 215: prova da IMPORTACAO do Excel ativo (o `clsTextos.ImportaTitulos`).
;
; A grade do `frmEditaTitulos` le o titulo do **TextString** do DBText da pagina
; (`TitulosDaPaginaDoDesenho.LerGrade` -> `Pagina.capturaTitulos`), e o indice vem do XData
; `DiagLog`/`TituloPagina` (posicao 3 do XData). Esta fixture troca o TextString do titulo de
; indice 1 da pagina "6" **antes** do plugin carregar: a grade fica com um valor DIFERENTE do
; que a aba do Excel recebeu na exportacao anterior, e a importacao tem de achar exatamente
; essa diferenca (e so ela). O XData fica intocado, entao o indice continua valido.
;
; Uso: `-Fixture scripts\cad-fixture-titulo-importar.lsp` numa sessao com
; `POSITRON_TITULOS_EXCEL=importar`, depois de uma sessao `=exportar` (a aba com os titulos do
; desenho) com o mesmo Excel aberto. O que a fixture le/escreve vai para POSITRON_TITULO_DUMP.
(defun pz-tit:log (s / f)
  (if (setq f (getenv "POSITRON_TITULO_DUMP"))
    (progn
      (setq f (open f "a"))
      (write-line s f)
      (close f)))
  (princ))

;; Os valores do XData `DiagLog` do texto, na ordem (0 = marca, 1 = indice, 2 = valor...).
(defun pz-tit:valores (e / d app vals)
  (setq d (entget e '("DiagLog")))
  (setq vals nil)
  (foreach app (cdr (assoc -3 d))
    (if (= (car app) "DiagLog")
      (setq vals (mapcar 'cdr (cdr app)))))
  vals)

(defun pz-tit:altera (layer indice novo / ss i e d vals)
  (setq ss (ssget "_X" (list '(0 . "TEXT") (cons 8 layer))))
  (pz-tit:log (strcat "TEXTOS no layer " layer ": " (itoa (if ss (sslength ss) 0))))
  (setq i 0)
  (while (and ss (< i (sslength ss)))
    (setq e (ssname ss i))
    (setq i (1+ i))
    (setq vals (pz-tit:valores e))
    (if vals
      (pz-tit:log (strcat "  indice=" (vl-princ-to-string (nth 1 vals))
                          " valor=" (vl-princ-to-string (nth 2 vals))
                          " texto=" (vl-princ-to-string (cdr (assoc 1 (entget e)))))))
    (if (and vals (= (nth 0 vals) "TituloPagina") (= (nth 1 vals) indice))
      (progn
        (setq d (entget e '("DiagLog")))
        (entmod (subst (cons 1 novo) (assoc 1 d) d))
        (pz-tit:log (strcat "  TROCADO indice " (itoa indice) " -> " novo)))))
  (princ))

(pz-tit:altera "6" 1 "TITULO1-MEDIDO-215")
(pz-tit:log "fixture 215 aplicada")
(princ)
