;; Fixture da rodada 173: exporta a DEFINICAO do formato do desenho (o bloco do
;; caderno, cujo nome traz "PADR") num DWG, para o `CAD` trocar o formato por um
;; de verdade e a cadeia pos-troca recriar os campos das paginas.
;;
;; Roda no load (antes do NETLOAD e do comando). Deixa um rastro com o nome do
;; bloco e o caminho de saida.

(defun pz-fmt:acha-bloco ( / b nome achado)
  (setq b (tblnext "BLOCK" T))
  (while (and b (not achado))
    (setq nome (cdr (assoc 2 b)))
    (if (and nome
             (wcmatch (strcase nome) "*PADR*")
             (not (wcmatch (strcase nome) "*MODEL_SPACE*"))
             (not (wcmatch (strcase nome) "*PAPER_SPACE*")))
      (setq achado nome))
    (setq b (tblnext "BLOCK")))
  achado)

(defun pz-fmt:dump ( / nome caminho f)
  (setq nome (pz-fmt:acha-bloco))
  (setq caminho (strcat (getenv "TEMP") "/formato173.dwg"))
  (setq f (open (strcat (getenv "TEMP") "/formato173.txt") "w"))
  (if f
    (progn
      (write-line (strcat "bloco;" (if nome nome "NENHUM")) f)
      (write-line (strcat "caminho;" caminho) f)
      (close f)))
  (if nome
    (command "_.-WBLOCK" caminho nome)
    (command "_.-WBLOCK" caminho "*"))
  (princ))

(pz-fmt:dump)
(princ)
