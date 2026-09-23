; Fixture do CorrigeCoresDosBlocos (ver docs/RUNBOOK.md, rodadas 89/90): monta um bloco
; cujo ATTDEF tem cor 3 e uma insercao cujo ATTRIB foi forcado para a cor 1 — o comando
; deve levar a cor do ATTRIB de volta para 3.
;
; A via do `entmake` do ATTDEF **dentro** do BLOCK nao funciona no ZWCAD (rodada 89):
; aqui o ATTDEF nasce solto no espaco do modelo e o bloco e criado com `_.-BLOCK`
; selecionando ele — a via que funcionou.
;
; O dump (definido ANTES do desenho) imprime a cor da referencia e a da definicao e
; grava um rastro por passo.
(setvar "CMDECHO" 0)
(regapp "ZZTeste")

(defun pz-cf:escreve (f s) (princ s f))

(defun pz-cf:marca (s / tf)
  (setq tf (open (strcat (getenv "TEMP") "/positron-cf-trace.txt") "a"))
  (princ (strcat s "\n") tf)
  (close tf))

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
(pz-cf:marca "1 ATTDEF solto")
(setq pz-cf:atd (entmakex (list (quote (0 . "ATTDEF")) (cons 8 "0") (list 10 0.0 0.0 0.0)
                                (cons 40 2.5) (cons 1 "T1") (cons 2 "T1") (cons 3 "")
                                (cons 62 3) (cons 70 0))))
(pz-cf:marca (strcat "2 ATTDEF feito: " (pz-cf:texto pz-cf:atd)))
; O bloco sai do ATTDEF solto (a via que funciona no ZWCAD).
(command "_.-BLOCK" "BTZX" (list 0.0 0.0) pz-cf:atd "")
(pz-cf:marca "3 bloco BTZX criado")
(command "_.INSERT" "BTZX" (list 10.0 0.0) 1.0 1.0 0.0 "T1x")
(pz-cf:marca "4 insert feito")
(setq pz-cf:sel (ssget "_X" (list (cons 0 "INSERT"))))
(if pz-cf:sel
  (progn
    (setq pz-cf:ins (ssname pz-cf:sel 0))
; Forca a cor do ATTRIB para 1 (o defeito que o comando conserta) e poe XData no INSERT.
    (setq pz-cf:a (entnext pz-cf:ins))
    (if (and pz-cf:a (= (cdr (assoc 0 (entget pz-cf:a))) "ATTRIB"))
      (progn
        (entmod (append (entget pz-cf:a) (list (cons 62 1))))
        (pz-cf:marca "5 ATTRIB forcado para 1")))
    (entmod (append (entget pz-cf:ins) (list (list -3 (list "ZZTeste" (cons 1000 "x"))))))
    (pz-cf:marca "6 XData no INSERT")))
(pz-cf:marca "7 fim da fixture")

(princ "fixture de cores montada: rode (pz-cf:conta)")
(princ)