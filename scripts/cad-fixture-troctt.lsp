; Fixture do TROCTT (frmEditaTitulosTextos, rodada 179). Acha a pagina P do primeiro titulo 1..4
; preenchido (TEXT com XData DiagLog/TituloPagina) e uma pagina Q de outro, e cria em P:
;
;   A  TEXT  "PZ-ABC"                   -> troca (texto solto)
;   B  TEXT  "PZ-ABC" com XData Eletron -> fica (LerXDataVazio)
;   C  MTEXT "PZ-ABC"                   -> troca (multitexto)
;   D  TEXT  "pz-abc"                   -> fica (o Replace diferencia maiusculas)
;   E  TEXT  "PZ-ABC" na pagina Q       -> fica (pagina nao selecionada)
;
; (pz-troctt:dump) grava em POSITRON_TROCTT_SAIDA: P, Q, os titulos de P e os cinco textos.
(setvar "CMDECHO" 0)
(regapp "Eletron")

(defun pz-troctt:titulo (e / x)
  (setq x (cdr (assoc "DiagLog" (cdr (assoc -3 (entget e '("DiagLog")))))))
  (if (and x (= (strcase (cdr (car x))) "TITULOPAGINA")) (cdr (cadr x))))

(setq pz-troctt:p nil pz-troctt:q nil pz-troctt:titulos nil
      ss (ssget "_X" '((0 . "TEXT"))) i 0)
(while (and ss (< i (sslength ss)))
  (setq e (ssname ss i) i (1+ i))
  (setq n (pz-troctt:titulo e))
  (if (and n (< 0 n 5) (/= (vl-string-trim " " (cdr (assoc 1 (entget e)))) ""))
    (progn
      (setq lay (cdr (assoc 8 (entget e))))
      (cond ((null pz-troctt:p) (setq pz-troctt:p lay))
            ((and (null pz-troctt:q) (/= lay pz-troctt:p)) (setq pz-troctt:q lay))))))

(defun pz-troctt:texto (lay txt y / e)
  (entmakex (list '(0 . "TEXT") (cons 8 lay) (list 10 950000.0 y 0.0) '(40 . 2.5) (cons 1 txt))))

(setq pz-troctt:a (pz-troctt:texto pz-troctt:p "PZ-ABC" 0.0))
(setq pz-troctt:b (pz-troctt:texto pz-troctt:p "PZ-ABC" 10.0))
(entmod (append (entget pz-troctt:b) '((-3 ("Eletron" (1000 . "PZ"))))))
(setq pz-troctt:c (entmakex (list '(0 . "MTEXT") '(100 . "AcDbEntity") (cons 8 pz-troctt:p) '(100 . "AcDbMText")
                                  (list 10 950000.0 20.0 0.0) '(40 . 2.5) '(1 . "PZ-ABC"))))
(setq pz-troctt:d (pz-troctt:texto pz-troctt:p "pz-abc" 30.0))
(setq pz-troctt:e (pz-troctt:texto pz-troctt:q "PZ-ABC" 40.0))
(princ (strcat "\nPZ-TROCTT;P=" pz-troctt:p ";Q=" pz-troctt:q))

(defun pz-troctt:dump (/ f ss i e n)
  (setq f (open (getenv "POSITRON_TROCTT_SAIDA") "w"))
  (write-line (strcat "PAGINAS;" pz-troctt:p ";" pz-troctt:q) f)
  (setq ss (ssget "_X" (list '(0 . "TEXT") (cons 8 pz-troctt:p))) i 0)
  (while (and ss (< i (sslength ss)))
    (setq e (ssname ss i) i (1+ i) n (pz-troctt:titulo e))
    (if n (write-line (strcat "TITULO;" (itoa n) ";" (cdr (assoc 1 (entget e)))) f)))
  (foreach par (list (cons "A" pz-troctt:a) (cons "B" pz-troctt:b) (cons "C" pz-troctt:c)
                     (cons "D" pz-troctt:d) (cons "E" pz-troctt:e))
    (write-line (strcat "TEXTO;" (car par) ";" (cdr (assoc 1 (entget (cdr par))))) f))
  (close f)
  (princ))
(princ)
