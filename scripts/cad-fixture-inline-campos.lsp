; Rodada 213: prova INDEPENDENTE do AtualizaContTotFl na edicao inline da celula Pagina.
; Roda em COPIA do Funcional.dwg (o harness copia o -Desenho). Com POSITRON_INLINE_MONTAR=1
; monta tres sentinelas DBText com o XData DiagLog/TituloPagina que o AtualizaContTotFl varre:
;   - layer "6", indice 5 (CONT) -> a proxima pagina da "6"; depois do rename 7->7A deve virar "7A";
;   - layer "7", indice 6 (FL)  -> o proprio layer; renomeado, deve virar "7A";
;   - layer "7", indice 7 (TOT) -> a ultima pagina do caderno ("1000"), que nao muda.
; O (pz-inline:dump) despeja em POSITRON_INLINE_SAIDA os campos 5/6/7 de todos os layers de pagina
; (leitura independente do plugin, entget).
(regapp "DiagLog")

(defun pz-inline:campo (layer indice texto)
  (entmakex (list '(0 . "TEXT") (cons 8 layer) '(10 900000.0 0.0 0.0) '(40 . 2.5)
    (cons 1 texto)
    (list -3 (list "DiagLog" '(1000 . "TituloPagina") (cons 1070 indice) (cons 1000 texto)
      '(1070 . 1) '(1000 . "harness") '(1000 . "213") '(1071 . 1) '(1040 . 1.0) '(1000 . " "))))))

(if (= (getenv "POSITRON_INLINE_MONTAR") "1")
  (progn
    (pz-inline:campo "6" 5 "SENTINELA-CONT-213")
    (pz-inline:campo "7" 6 "SENTINELA-FL-213")
    (pz-inline:campo "7" 7 "SENTINELA-TOT-213")))

(defun pz-inline:dump (/ arq f ss i d x indice)
  (setq arq (getenv "POSITRON_INLINE_SAIDA"))
  (if (and arq (> (strlen arq) 0))
    (progn
      (setq f (open arq "w"))
      (foreach p '("6" "7" "7A")
        (write-line (strcat "LAYER;" p ";" (if (tblsearch "LAYER" p) "existe" "ausente")) f))
      (setq ss (ssget "_X" '((0 . "TEXT"))) i 0)
      (while (and ss (< i (sslength ss)))
        (setq d (entget (ssname ss i) '("DiagLog")) i (1+ i)
              x (cdr (assoc "DiagLog" (cdr (assoc -3 d)))))
        (if (and x (= (cdr (car x)) "TituloPagina"))
          (progn
            (setq indice (cdr (cadr x)))
            (if (or (= indice 5) (= indice 6) (= indice 7))
              (write-line (strcat "CAMPO;layer=" (cdr (assoc 8 d)) ";indice=" (itoa indice)
                                 ";texto=" (cdr (assoc 1 d))) f)))))
      (close f)
      (princ))))
(princ)
