;;; cad-conta-derivacoes.lsp — contingencia independente do `Limpahandle` (frente 2 do
;;; §7.6, rodada 92), fora do plugin.
;;;
;;; Para cada polilinha com XData CONEXAO tipo 3 (derivacao), imprime o handle guardado.
;;;
;;;   DERIVACAO;handlePolilinha;tipo;handle;nome;potencial
;;;   TOTAL;conexoes;<n>;derivacoes;<d>;comHandle;<h>
(defun pz-dv:escreve (f s) (princ s f))

(defun pz-dv:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-dv:vals (e / d r)
  (setq d (entget e (list "CONEXAO")))
  (setq r (car (cdr (assoc -3 d))))
  (if r (mapcar (quote cdr) (cdr r)) nil))

(defun pz-dv:conta ( / caminho f sel i e d v tipo handle nome pot n deriv comH)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-derivacoes.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-derivacoes: falha ao abrir a saida")
    (progn
      (pz-dv:escreve f "DERIVACAO;handlePolilinha;tipo;handle;nome;potencial\n")
      (setq n 0 deriv 0 comH 0)
      (setq sel (ssget "_X" (list (cons 0 "LWPOLYLINE,POLYLINE"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq v (pz-dv:vals e))
            (if v
              (progn
                (setq n (1+ n))
                (setq tipo (pz-dv:texto (nth 0 v)))
                (if (= tipo "3")
                  (progn
                    (setq deriv (1+ deriv))
                    (setq handle (pz-dv:texto (nth 2 v)))
                    (setq nome (pz-dv:texto (nth 5 v)))
                    (setq pot (pz-dv:texto (nth 1 v)))
                    (if (/= handle "") (setq comH (1+ comH)))
                    (pz-dv:escreve f (strcat "DERIVACAO;" (pz-dv:texto (cdr (assoc 5 (entget e)))) ";"
                                             tipo ";" handle ";" nome ";" pot "\n")))))))
      (pz-dv:escreve f (strcat "TOTAL;conexoes;" (itoa n) ";derivacoes;" (itoa deriv)
                                ";comHandle;" (itoa comH) "\n"))
      (close f)
      (princ (strcat "cad-conta-derivacoes: " (itoa deriv) " derivacao(oes), " (itoa comH) " com handle")))))))

; A contagem roda no LOAD: no desenho real a linha de comando LISP depois do NETLOAD nao
; executa (rodadas 90/91), entao o "antes" sai daqui e o "depois" vem do proprio comando.
(pz-dv:conta)
(princ "contador de derivacoes carregado e rodado")
(princ)