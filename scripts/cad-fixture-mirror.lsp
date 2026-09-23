; Fixture do ApagaBlocosMirror (ver docs/RUNBOOK.md, rodada 94): monta tres insercoes do
; mesmo bloco vazio —
;
;   1. espelhada (escala X = -1) com um XData qualquer  -> o comando APAGA;
;   2. espelhada (escala X = -1) com o app DINTERLIG     -> fica (cabo de aranha);
;   3. normal (escala X = 1) com um XData qualquer       -> fica.
;
; Esperado: "1 bloco(s) espelhado(s) apagado(s) (2 espelhado(s) entre 3 com XData; 1 sao
; cabo de aranha e ficam; 3 bloco(s) lido(s))" e o dump depois com 2 blocos.
;
; As definicoes vem ANTES do desenho e o dump roda no fim (a linha LISP depois do NETLOAD
; funciona no desenho sintetico).
(setvar "CMDECHO" 0)
(regapp "ZZTeste")
(regapp "DINTERLIG")

(defun pz-mr:escreve (f s) (princ s f))

(defun pz-mr:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-mr:conta ( / caminho f sel i e d nome x dint n esp comX)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-mirror.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-mirror: falha ao abrir a saida")
    (progn
      (pz-mr:escreve f "BLOCO;handle;nome;escalaX;temXData;temDinterlig\n")
      (setq n 0 esp 0 comX 0)
      (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq n (1+ n))
            (setq x (if (assoc 41 d) (cdr (assoc 41 d)) 1.0))
            (if (< x 0.0) (setq esp (1+ esp)))
            (setq dint (/= (car (cdr (assoc -3 (entget e (list "DINTERLIG"))))) nil))
            (setq comX (/= (car (cdr (assoc -3 (entget e (list "ZZTeste"))))) nil))
            (pz-mr:escreve f (strcat "BLOCO;" (pz-mr:texto (cdr (assoc 5 d))) ";"
                                     (pz-mr:texto (cdr (assoc 2 d))) ";" (rtos x 2 2) ";"
                                     (if comX "SIM" "NAO") ";" (if dint "SIM" "NAO") "\n")))))
      (pz-mr:escreve f (strcat "TOTAL;blocos;" (itoa n) ";espelhados;" (itoa esp) "\n"))
      (close f)
      (princ (strcat "cad-fixture-mirror: " (itoa n) " bloco(s), " (itoa esp) " espelhado(s)")))))

; ── O desenho ──────────────────────────────────────────────────────────────
(entmake (quote ((0 . "BLOCK") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockBegin")
                  (2 . "BTMIRROR") (70 . 0) (10 0.0 0.0 0.0) (3 . "BTMIRROR") (1 . ""))))
(entmake (quote ((0 . "ENDBLK") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockEnd"))))

(defun pz-mr:ins (x escala xdata / e)
  (entmake (list (quote (0 . "INSERT")) (quote (8 . "0")) (cons 2 "BTMIRROR")
                 (list 10 x 0.0 0.0) (cons 41 escala) (cons 42 1.0) (cons 43 1.0) (cons 50 0.0)))
  (setq e (entlast))
  (if xdata
    (entmod (append (entget e) (list (list -3 (list (car xdata) (cons 1000 (cdr xdata))))))))
  e)

; 1. espelhada com XData qualquer -> apaga
(pz-mr:ins 0.0 -1.0 (cons "ZZTeste" "x"))
; 2. espelhada com DINTERLIG -> fica
(pz-mr:ins 10.0 -1.0 (cons "DINTERLIG" "x"))
; 3. normal com XData qualquer -> fica
(pz-mr:ins 20.0 1.0 (cons "ZZTeste" "x"))

(princ "fixture de mirror montada: rode (pz-mr:conta)")
(princ)