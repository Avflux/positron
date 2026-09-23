;;; cad-conta-bornes-atrib.lsp — contingencia independente do `CorrigePainelET1DosBornes`
;;; (frente 2 do §7.6, rodada 96), fora do plugin.
;;;
;;; Para cada bloco de borne (Dispositivo tipo B), imprime os atributos NOME1/PAINEL/REGUA/T1.
;;;
;;;   BORNE;handle;nome;NOME1;PAINEL;REGUA;T1
;;;   TOTAL;bornes;<n>;comPainel;<p>
(defun pz-ba:escreve (f s) (princ s f))

(defun pz-ba:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-ba:xdata (e / d r)
  (setq d (entget e (list "Dispositivo")))
  (setq r (car (cdr (assoc -3 d))))
  (if r (mapcar (quote cdr) (cdr r)) nil))

(defun pz-ba:atrib (bloco tag / e d achou)
  (setq achou "")
  (setq e (entnext bloco))
  (while (and e (= (cdr (assoc 0 (entget e))) "ATTRIB"))
    (setq d (entget e))
    (if (= (strcase (pz-ba:texto (cdr (assoc 2 d)))) (strcase tag))
      (setq achou (pz-ba:texto (cdr (assoc 1 d)))))
    (setq e (entnext e)))
  achou)

(defun pz-ba:conta ( / caminho f sel i e d disp tipo n comP)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-bornes-atrib.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-bornes-atrib: falha ao abrir a saida")
    (progn
      (pz-ba:escreve f "BORNE;handle;nome;NOME1;PAINEL;REGUA;T1\n")
      (setq n 0 comP 0)
      (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq disp (pz-ba:xdata e))
            (setq tipo (if disp (pz-ba:texto (nth 0 disp)) ""))
            (if (= (strcase tipo) "B")
              (progn
                (setq n (1+ n))
                (if (/= (pz-ba:atrib e "PAINEL") "") (setq comP (1+ comP)))
                (pz-ba:escreve f (strcat "BORNE;" (pz-ba:texto (cdr (assoc 5 d))) ";"
                                         (pz-ba:texto (cdr (assoc 2 d))) ";"
                                         (pz-ba:atrib e "NOME1") ";" (pz-ba:atrib e "PAINEL") ";"
                                         (pz-ba:atrib e "REGUA") ";" (pz-ba:atrib e "T1") "\n")))))
      (pz-ba:escreve f (strcat "TOTAL;bornes;" (itoa n) ";comPainel;" (itoa comP) "\n"))
      (close f)
      (princ (strcat "cad-conta-bornes-atrib: " (itoa n) " borne(s), " (itoa comP) " com PAINEL")))))))

; A contagem roda no LOAD (a linha LISP depois do NETLOAD nao executa no desenho real).
(pz-ba:conta)
(princ)