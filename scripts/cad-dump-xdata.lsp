;;; cad-dump-xdata.lsp — diagnostico de XData dentro do CAD (nao faz parte do plugin).
;;;
;;; Dumpar o XData e os dicionarios do proprio desenho e o unico jeito de separar
;;; "bug da projecao" de "dado da copia do desenho". Foi assim que os blocos do
;;; `Dispositivos4F` (modelo 53 x modelo 6) ficaram provados.
;;;
;;; Uso por script (o harness aceita `-Fixture scripts/cad-dump-xdata.lsp`):
;;;
;;;   (load "C:/.../scripts/cad-dump-xdata.lsp")
;;;
;;; A saida vai para a variavel de ambiente `POSITRON_XDATA` ou, sem ela, para
;;; `<TEMP>\positron-xdata.txt`. Os handles dumados vem de `*positron-dump-handles*`
;;; (padrao: os dois blocos `52-X1`/`52-X2` que divergem no A/B do `Dispositivos4F`).
;;; Antes do load, ajuste a lista se quiser outros handles:
;;;
;;;   (setq *positron-dump-handles* '("4D642" "ABC12"))
;;;   (load "C:/.../scripts/cad-dump-xdata.lsp")

(setq *positron-dump-handles*
  (if (boundp '*positron-dump-handles*) *positron-dump-handles* '("4D642" "4D672")))

(defun pz-dump:escreve (f s) (princ s f))

;; Imprime, por app name, cada valor do XData com o indice **depois do app name**
;; (o indice 0 aqui e o `array[1]` do leitor em C#, que consome o app name como 0).
(defun pz-dump:entidade (h f / e d x app i item)
  (setq e (handent h))
  (if (null e)
    (pz-dump:escreve f (strcat "HANDLE " h ": NAO ENCONTRADO\n"))
    (progn
      (pz-dump:escreve f (strcat "\nHANDLE " h "\n"))
      (setq d (entget e '("DISPOSITIVO" "Dispositivo" "MASCARA" "Mascara")))
      (setq x (cdr (assoc -3 d)))
      (if (null x)
        (pz-dump:escreve f "  sem XData de dispositivo/mascara\n")
        (foreach app x
          (pz-dump:escreve f (strcat "  app=" (vl-princ-to-string (car app)) "\n"))
          (setq i 0)
          (foreach item (cdr app)
            (pz-dump:escreve f (strcat "    idx=" (itoa i) " code=" (itoa (car item))
                                       " val=" (vl-princ-to-string (cdr item)) "\n"))
            (setq i (1+ i))))))))

(defun pz-dump:dicionario (nome sub f / d e r)
  (setq d (dictsearch (namedobjdict) nome))
  (if (null d)
    (pz-dump:escreve f (strcat "\nDIC " nome ": nao existe\n"))
    (progn
      (setq e (cdr (assoc -1 d)))
      (setq r (dictsearch e sub))
      (if (null r)
        (pz-dump:escreve f (strcat "\nDIC " nome "/" sub ": nao existe\n"))
        (pz-dump:escreve f (strcat "\nDIC " nome "/" sub " (Xrecord):\n"
                                   (vl-princ-to-string (entget (cdr (assoc -1 r)))) "\n"))))))

(defun pz-dump:tudo (caminho / f)
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-dump-xdata: falha ao abrir o arquivo de saida")
    (progn
      (foreach h *positron-dump-handles* (pz-dump:entidade h f))
      (pz-dump:dicionario "CONTATOS" "MODELOS2" f)
      (pz-dump:dicionario "MASCARAS" "MODELOS2" f)
      (close f)
      (princ (strcat "cad-dump-xdata: escrito em " caminho)))))

;; Sem `let`: AutoLISP nao tem esse special form (o load falha em silencio e nada e
;; dumado). O caminho usa barra normal, que o AutoCAD aceita no `open`.
(setq pz-dump:saida (getenv "POSITRON_XDATA"))
(if (or (null pz-dump:saida) (= pz-dump:saida ""))
  (setq pz-dump:saida (strcat (getenv "TEMP") "/positron-xdata.txt")))
(pz-dump:tudo pz-dump:saida)
