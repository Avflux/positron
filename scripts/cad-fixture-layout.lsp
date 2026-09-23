; Fixture do REMLAYDUP (ver docs/RUNBOOK.md, rodada 84): monta o dicionario CENG_LAYOUT
; com tres chaves — o painel 3 (no cadastro) com P e C, e o painel 999 (fora dele).
;
;   - P3: A, B, A, C  -> depois A, B  (o duplicado A sai e o ultimo C e descartado)
;   - C3: X, Y        -> depois X     (o ultimo Y e descartado)
;   - P999: M, N      -> intacta      (999 nao esta no cadastro de Paineis)
;
; Esperado: "REMLAYDUP: 2 de 2 chave(s) de layout regravada(s) (6 registro(s) -> 3;
; 480 painel(is) do cadastro)" e, na segunda passada, "0 de 2 ... (3 -> 3)".
(setvar "CMDECHO" 0)

(defun pz-lay:xrec (valores)
  (entmakex (append (list (quote (0 . "XRECORD")) (quote (100 . "AcDbXrecord")) (quote (280 . 1)))
                    valores)))

(defun pz-lay:registro (tag alt x y)
  (list (cons 1 tag) (cons 1 alt) (cons 40 x) (cons 40 y) (cons 1 "")))

(defun pz-lay:dicionario ( / dic)
  (setq dic (entmakex (quote ((0 . "DICTIONARY") (100 . "AcDbDictionary")))))
  (dictadd (namedobjdict) "CENG_LAYOUT" dic)
  (dictadd dic "P3"
    (pz-lay:xrec (append (pz-lay:registro "A" "" 0.0 0.0)
                         (pz-lay:registro "B" "" 1.0 1.0)
                         (pz-lay:registro "A" "" 2.0 2.0)
                         (pz-lay:registro "C" "" 3.0 3.0))))
  (dictadd dic "C3"
    (pz-lay:xrec (append (pz-lay:registro "X" "" 0.0 0.0)
                         (pz-lay:registro "Y" "" 1.0 1.0))))
  (dictadd dic "P999"
    (pz-lay:xrec (append (pz-lay:registro "M" "" 0.0 0.0)
                         (pz-lay:registro "N" "" 1.0 1.0)))))

(pz-lay:dicionario)
; ── O dump da fixture (mesmo formato do cad-conta-layout.lsp) ───────────────
(defun pz-lay:escreve (f s) (princ s f))

(defun pz-lay:texto (v)
  (if (null v)
    ""
    (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-lay:valores (d)
  (mapcar (quote cdr) (cdr (member (assoc 280 d) d))))

(defun pz-lay:conta ( / caminho f dic nome sub vals n tags i total chaves)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-layout.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-layout: falha ao abrir a saida")
    (progn
      (pz-lay:escreve f "CHAVE;nome;registros;tags\n")
      (setq dic (dictsearch (namedobjdict) "CENG_LAYOUT"))
      (setq total 0 chaves 0)
      (if dic
        (foreach item dic
          (if (= (car item) 3)
            (progn
              (setq nome (cdr item))
              (setq sub (dictsearch (cdr (assoc -1 dic)) nome))
              (setq vals (if sub (pz-lay:valores (entget (cdr (assoc -1 sub)))) nil))
              (setq n (if vals (/ (length vals) 5) 0))
              (setq tags "" i 0)
              (while (< i (length vals))
                (setq tags (strcat tags (if (= tags "") "" "|") (pz-lay:texto (nth i vals))))
                (setq i (+ i 5)))
              (setq total (+ total n))
              (setq chaves (1+ chaves))
              (pz-lay:escreve f (strcat "CHAVE;" nome ";" (itoa n) ";" tags "\n"))))))
      (pz-lay:escreve f (strcat "TOTAL;chaves;" (itoa chaves)
                                ";registros;" (itoa total) "\n"))
      (close f)
      (princ (strcat "cad-fixture-layout: escrito em " caminho)))))

(princ "fixture de layout montada: rode (pz-lay:conta)")
(princ)