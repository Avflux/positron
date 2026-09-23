; Fixture do CorrigeCoresDosBlocos (ver docs/RUNBOOK.md, rodada 89): monta um bloco
; cujo ATTDEF tem cor 3 e uma insercao com XData cujo ATTRIB esta em BYLAYER (256) —
; o comando deve levar a cor do ATTRIB para 3.
;
; O dump (definido ANTES do desenho) imprime a cor da referencia e a da definicao.
(setvar "CMDECHO" 0)
(regapp "ZZTeste")

(defun pz-cf:escreve (f s) (princ s f))

(defun pz-cf:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-cf:cor (d)
  (if (assoc 62 d) (cdr (assoc 62 d)) 256))

; A cor de um ATTDEF da definicao, pelo tag.
(defun pz-cf:def (nome tag / b e d achou)
  (setq achou nil b (tblobjname "BLOCK" nome))
  (if b
    (progn
      (setq e (entnext b))
      (while (and e (/= (cdr (assoc 0 (entget e))) "ENDBLK"))
        (setq d (entget e))
        (if (and (= (cdr (assoc 0 d)) "ATTDEF")
                 (= (strcase (pz-cf:texto (cdr (assoc 2 d)))) (strcase tag)))
          (setq achou (pz-cf:cor d)))
        (setq e (entnext e)))))
  achou)

(defun pz-cf:conta ( / caminho f sel i e a d nome corRef corDef difs refs)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-cores.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-cores: falha ao abrir a saida")
    (progn
      (pz-cf:escreve f "COR;handle;nome;tag;corRef;corDef\n")
      (setq difs 0 refs 0)
      (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq nome (pz-cf:texto (cdr (assoc 2 d))))
            (setq a (entnext e))
            (while (and a (= (cdr (assoc 0 (entget a))) "ATTRIB"))
              (setq refs (1+ refs))
              (setq corRef (pz-cf:cor (entget a)))
              (setq corDef (pz-cf:def nome (cdr (assoc 2 (entget a)))))
              (if (and corDef (/= corRef corDef)) (setq difs (1+ difs)))
              (pz-cf:escreve f (strcat "COR;" (pz-cf:texto (cdr (assoc 5 d))) ";" nome ";"
                                       (pz-cf:texto (cdr (assoc 2 (entget a)))) ";"
                                       (itoa corRef) ";" (itoa (if corDef corDef -1)) "\n"))
              (setq a (entnext a))))))
      (pz-cf:escreve f (strcat "TOTAL;referencias;" (itoa refs) ";diferencas;" (itoa difs)
                                ";insercoes;" (itoa (if sel (sslength sel) 0)) "\n"))
      (close f)
      (princ (strcat "cad-fixture-cores: " (itoa refs) " referencia(s), " (itoa difs) " diferenca(s)")))))

; ── O desenho ──────────────────────────────────────────────────────────────
(entmake (quote ((0 . "BLOCK") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockBegin")
                  (2 . "BTZX") (70 . 0) (10 0.0 0.0 0.0) (3 . "BTZX") (1 . ""))))
(entmake (quote ((0 . "ATTDEF") (100 . "AcDbEntity") (8 . "0") (62 . 3)
                  (100 . "AcDbText") (10 0.0 0.0 0.0) (40 2.5) (1 "T1") (50 . 0.0)
                  (100 . "AcDbAttributeDefinition") (3 . "") (2 . "T1") (70 . 0))))
(entmake (quote ((0 . "ENDBLK") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockEnd"))))
; O INSERT com um ATTRIB e o SEQEND, tudo por entmake (deterministico): o `66 . 1`
; marca a insercao como tendo atributos.
(entmake (list (quote (0 . "INSERT")) (quote (8 . "0")) (cons 2 "BTZX") (list 10 0.0 0.0 0.0) (cons 66 1)))
(setq pz-cf:ins (entlast))
(entmake (list (quote (0 . "ATTRIB")) (quote (100 . "AcDbEntity")) (quote (8 . "0"))
               (quote (100 . "AcDbText")) (list 10 0.0 0.0 0.0) (cons 40 2.5) (cons 1 "T1x")
               (quote (100 . "AcDbAttribute")) (cons 2 "T1") (cons 70 0)))
(entmake (quote ((0 . "SEQEND") (8 . "0"))))
; O INSERT precisa de ALGUM XData (a passada 1 do original).
(entmod (append (entget pz-cf:ins) (list (list -3 (list "ZZTeste" (cons 1000 "x"))))))

(princ "fixture de cores montada: rode (pz-cf:conta)")
(princ)