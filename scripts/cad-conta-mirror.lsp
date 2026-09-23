;;; cad-conta-mirror.lsp — contingencia independente do `ApagaBlocosMirror` (frente 2 do
;;; §7.6, rodada 93), fora do plugin.
;;;
;;; Conta os INSERTs: quantos tem escala X negativa (espelhados), quantos tem algum XData e
;;; quantos tem o app DINTERLIG (cabo de aranha).
;;;
;;;   TOTAL;blocos;<n>;espelhados;<e>;comXData;<x>;comDinterlig;<d>;espelhadosComXDataSemDinterlig;<a>
(defun pz-mr:escreve (f s) (princ s f))

(defun pz-mr:apps ( / l n)
  (setq l nil)
  (foreach n (list "DINTERLIG" "Dispositivo" "Modelo" "CONEXAO" "INTERLIGACAO" "AUXINTERLIG"
                   "BORNE" "Mascara" "MASCARAS" "CONTATOS" "CENG_LAYOUT" "Plaqueta")
    (if (tblsearch "APPID" n) (setq l (cons n l))))
  l)

(defun pz-mr:conta ( / caminho f apps sel i e d x esc comX dint alvo n)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-mirror.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-mirror: falha ao abrir a saida")
    (progn
      (setq apps (pz-mr:apps))
      (setq n 0 esc 0 comX 0 dint 0 alvo 0)
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
            (if (< x 0.0) (setq esc (1+ esc)))
            (setq comX (/= (cdr (assoc -3 (entget e apps))) nil))
            (if comX (setq comX (1+ 0)))
            (setq dint (/= (car (cdr (assoc -3 (entget e (list "DINTERLIG"))))) nil))
            (if comX (setq comX (if (= comX 0) 1 comX)))
            (if dint (setq dint (1+ 0)))
            (if (and (< x 0.0) (cdr (assoc -3 (entget e apps))) (/= (car (cdr (assoc -3 (entget e (list "DINTERLIG"))))) nil))
              (setq alvo (1+ alvo)))
            (setq i i))))
      (pz-mr:escreve f (strcat "TOTAL;blocos;" (itoa n) ";espelhados;" (itoa esc)
                                ";comDinterlig;" (itoa dint) "\n"))
      (close f)
      (princ (strcat "cad-conta-mirror: " (itoa n) " bloco(s), " (itoa esc) " espelhado(s)")))))

; A contagem roda no LOAD (a linha LISP depois do NETLOAD nao executa no desenho real).
(pz-mr:conta)
(princ)