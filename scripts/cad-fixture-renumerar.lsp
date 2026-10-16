; Rodada 186: prova INDEPENDENTE da renumeracao com destino da paleta.
; Roda em COPIA do Funcional.dwg (o harness copia o -Desenho). Le a tabela de LAYERS com
; AutoLISP e escreve no arquivo de POSITRON_PAGINAS_SAIDA: prova que os layers de pagina
; mudaram de nome sem perder o XData Eletron (unidade/alternativo) que carregavam.
(defun pz-pag:digito (c) (and (>= (ascii c) 48) (<= (ascii c) 57)))
(defun pz-pag:letra (c) (and (>= (ascii c) 65) (<= (ascii c) 90)))
(defun pz-pag:soDigitos (texto / n i ok)
  (setq n (strlen texto) i 1 ok (> n 0))
  (while (and ok (<= i n))
    (if (not (pz-pag:digito (substr texto i 1))) (setq ok nil))
    (setq i (1+ i)))
  ok)
(defun pz-pag:ePagina (nome / n ultimo)
  (setq n (strlen nome) ultimo (substr nome n 1))
  (if (pz-pag:letra ultimo)
    (pz-pag:soDigitos (substr nome 1 (1- n)))
    (pz-pag:soDigitos nome)))
(defun pz-pag:xdata (nome / e x)
  (setq e (tblobjname "LAYER" nome) x nil)
  (if e (setq x (cdr (assoc "Eletron" (cdr (assoc -3 (entget e '("Eletron"))))))))
  (if x (vl-princ-to-string x) "ausente"))
(defun pz-pag:dump (/ caminho f tabela nome total)
  (setq caminho (getenv "POSITRON_PAGINAS_SAIDA"))
  (if caminho
    (progn
      (setq f (open caminho "w") tabela (tblnext "LAYER" T) total 0)
      (while tabela
        (setq nome (cdr (assoc 2 tabela)))
        (if (pz-pag:ePagina nome)
          (progn
            (setq total (1+ total))
            (write-line (strcat "PAGINA;" nome ";xdata=" (pz-pag:xdata nome)) f)))
        (setq tabela (tblnext "LAYER")))
      (write-line (strcat "TOTAL;" (itoa total)) f)
      (close f)))
  (princ))
(princ)
