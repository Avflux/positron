;;; cad-conta-portas.lsp — contingencia independente do `corrigePortas` (frente 2 do
;;; §7.6, rodada 87), fora do plugin.
;;;
;;; Para cada bloco de porta (Dispositivo tipo E), imprime o par
;;; `indiceDoModelo`/`indiceDaPorta` do XData e os atributos EFC/T/B/R com a
;;; invisibilidade (grupo 60) das reguas.
;;;
;;;   PORTA;handle;nome;indexModelo;indexDaPorta;EFC;T1;T2;B1;B2;R1;R1invisivel
;;;   TOTAL;blocos;<n>;comDispositivo;<m>
(defun pz-pt:escreve (f s) (princ s f))

(defun pz-pt:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-pt:xdata (e app / d r)
  (setq d (entget e (list app)))
  (setq r (car (cdr (assoc -3 d))))
  (if r (mapcar (quote cdr) (cdr r)) nil))

(defun pz-pt:atrib (bloco tag / e d achou)
  (setq achou "")
  (setq e (entnext bloco))
  (while (and e (= (cdr (assoc 0 (entget e))) "ATTRIB"))
    (setq d (entget e))
    (if (= (strcase (pz-pt:texto (cdr (assoc 2 d)))) (strcase tag))
      (setq achou (pz-pt:texto (cdr (assoc 1 d)))))
    (setq e (entnext e)))
  achou)

; A invisibilidade da regua (grupo 60): 1 = invisivel.
(defun pz-pt:invisivel (bloco tag / e d achou)
  (setq achou "")
  (setq e (entnext bloco))
  (while (and e (= (cdr (assoc 0 (entget e))) "ATTRIB"))
    (setq d (entget e))
    (if (= (strcase (pz-pt:texto (cdr (assoc 2 d)))) (strcase tag))
      (setq achou (itoa (if (assoc 60 d) (cdr (assoc 60 d)) 0))))
    (setq e (entnext e)))
  achou)

(defun pz-pt:conta ( / caminho f sel i e d disp tipo im ip n m)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-portas.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-portas: falha ao abrir a saida")
    (progn
      (pz-pt:escreve f "PORTA;handle;nome;indexModelo;indexDaPorta;EFC;T1;T2;B1;B2;R1;R1invisivel\n")
      (setq n 0 m 0)
      (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq disp (pz-pt:xdata e "Dispositivo"))
            (setq tipo (if disp (pz-pt:texto (nth 0 disp)) ""))
            (if (= (strcase tipo) "E")
              (progn
                (setq n (1+ n))
                (setq im (if disp (pz-pt:texto (nth 4 disp)) ""))
                (setq ip (if disp (pz-pt:texto (nth 5 disp)) ""))
                (if disp (setq m (1+ m)))
                (pz-pt:escreve f (strcat "PORTA;" (pz-pt:texto (cdr (assoc 5 d))) ";"
                                         (pz-pt:texto (cdr (assoc 2 d))) ";" im ";" ip ";"
                                         (pz-pt:atrib e "EFC") ";"
                                         (pz-pt:atrib e "T1") ";" (pz-pt:atrib e "T2") ";"
                                         (pz-pt:atrib e "B1") ";" (pz-pt:atrib e "B2") ";"
                                         (pz-pt:atrib e "R1") ";" (pz-pt:invisivel e "R1") "\n")))))
      (pz-pt:escreve f (strcat "TOTAL;blocos;" (itoa n) ";comDispositivo;" (itoa m) "\n"))
      (close f)
      (princ (strcat "cad-conta-portas: " (itoa n) " porta(s)")))))))

(princ "contador de portas carregado: rode (pz-pt:conta)")
(princ)