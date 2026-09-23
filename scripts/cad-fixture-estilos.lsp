; Fixture do CorrigeStyle (ver docs/RUNBOOK.md, rodada 73): monta o caso de
; ESCRITA que o desenho real NAO exercita — os 5 estilos de la estao com fonte e
; escala 1.
;
;   - `PZSEMFONTE`: estilo com o `FileName` vazio (grupo 3) e a escala/altura
;     fora do padrao. O `CorrigeStyle` copia fonte, escala (1.0) e altura (0.0)
;     da referencia e **regrava o arquivo da fonte**: o original só copia o
;     descritor `Font`, e no ZWCAD isso nao persiste o `FileName` (medido), entao
;     o recoder tambem grava o arquivo — sem isso o defeito nao sai e a segunda
;     passada reportaria o mesmo.
;
; O caso `XScale == 0` NAO da para montar por `entmake`: o ZWCAD normaliza o
; fator de largura 0 para 1 (a fixture tenta `PZZEROESCALA` e o dump mostra 1.0).
; Esse ramo fica coberto pela regra pura (`CorrecaoEstiloTextoTests`).
(setvar "CMDECHO" 0)

(defun pz-estilos:escreve (f s) (princ s f))

(defun pz-estilos:texto (v)
  (if (null v)
    ""
    (if (= (type v) 'STR) v (vl-princ-to-string v))))

; Dump dos estilos para `POSITRON_XDATA` (ou TEMP). Roda como comando
; — `(pz-estilos:dump)` — depois do `CorrigeStyle`, para conferir fora do plugin
; o que ficou gravado em cada campo (o FileName e o XScale/TextSize do grupo 3/41/40).
(defun pz-estilos:dump ( / caminho f t1)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-estilos.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-estilos: falha ao abrir a saida")
    (progn
      (pz-estilos:escreve f "ESTILOS\n")
      (setq t1 (tblnext "STYLE" T))
      (while t1
        (pz-estilos:escreve f (strcat "ESTILO;" (pz-estilos:texto (cdr (assoc 2 t1)))
                                   ";" (pz-estilos:texto (cdr (assoc 3 t1)))
                                   ";" (pz-estilos:texto (cdr (assoc 41 t1)))
                                   ";" (pz-estilos:texto (cdr (assoc 40 t1))) "\n"))
        (setq t1 (tblnext "STYLE")))
      (close f)
      (princ (strcat "cad-fixture-estilos: estilos escritos em " caminho)))))

; STYLE: nome (2), altura fixa (40), fator de largura (41), arquivo de fonte (3)
; e big font (4). Estilo nao tem XData, entao nao ha o que carimbar.
(defun pz-estilo (nome arquivo escala altura)
  (entmake
    (list '(0 . "STYLE")
          '(100 . "AcDbSymbolTableRecord")
          '(100 . "AcDbTextStyleTableRecord")
          (cons 2 nome)
          '(70 . 0)
          (cons 40 altura)
          (cons 41 escala)
          '(50 . 0.0)
          '(71 . 0)
          '(42 . 2.5)
          (cons 3 arquivo)
          '(4 . ""))))

(pz-estilo "PZSEMFONTE" "" 2.0 1.5)

(princ "fixture de estilos montada (estilo sem fonte, escala 2.0 e altura 1.5)")
(princ)
