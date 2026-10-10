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
;;;
;;; Com `POSITRON_XDATA_BORNES=1` no ambiente, alem dos handles e dos dicionarios
;;; ele duma **todos** os blocos de borne do desenho, um por linha:
;;;
;;;   BORNE;<handle>;<tipo>;<numero>;<complemento>;<ordem>;<indexRegua>;<layer>
;;;
;;; E o que permite reconstruir a sequencia de bornes de uma regua **fora do
;;; plugin** e conferir a checagem de intervalos (`bt8intervalos`) contra o dado
;;; bruto do desenho. So entram os blocos do ModelSpace — a mesma varredura do
;;; `BornesDoDesenho.Ler`.

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

;; As PORTAS de cada modelo de mascara (MASCARAS/<indice>), um registro por linha,
;; no layout de 8 valores do leitor (indice da porta, orientacao, EFC, terminais,
;; bornes, +5 nao usado, regua, +7 nao usado). E o insumo da regua da mascara
;; (`bt13ReguaMascara`): o campo Regua do registro indice+6.
(defun pz-dump:modelos-mascara (f / d item r)
  (setq d (dictsearch (namedobjdict) "MASCARAS"))
  (if (null d)
    (pz-dump:escreve f "\nMASCARAS: nao existe\n")
    (foreach item d
      (if (= (car item) 3)
        (progn
          (setq r (dictsearch (cdr (assoc -1 d)) (cdr item)))
          (pz-dump:escreve f
            (strcat "\nMASCARA;" (cdr item) ";"
                    (if (null r) "NAO EXISTE"
                        (vl-princ-to-string (entget (cdr (assoc -1 r)))))
                    "\n")))))))

;; Um bloco de borne por linha. O XData e lido pelo app name `Dispositivo` (o
;; legado `DISPOSITIVO` tambem vale) e os valores saem na ordem do layout do
;; `BorneXData`: tipo, Numero, NumeroComplem, Ordem, IndiceRegua — o mesmo indice
;; "depois do app name" que o `pz-dump:entidade` usa.
(defun pz-dump:linha-borne (e d app / vals)
  (setq vals (mapcar 'cdr (cdr app)))
  (if (= (strcase (vl-princ-to-string (nth 0 vals))) "B")
    (strcat "BORNE;" (cdr (assoc 5 d))
            ";" (vl-princ-to-string (nth 0 vals))
            ";" (vl-princ-to-string (nth 4 vals))
            ";" (vl-princ-to-string (nth 5 vals))
            ";" (vl-princ-to-string (nth 6 vals))
            ";" (vl-princ-to-string (nth 7 vals))
            ";" (vl-princ-to-string (cdr (assoc 8 d))) "\n")
    nil))

(defun pz-dump:bornes (f / sel i e d x linha)
  (setq sel (ssget "_X" '((0 . "INSERT"))))
  (pz-dump:escreve f (strcat "\nBORNES (INSERT com XData Dispositivo): "
                             (itoa (if (null sel) 0 (sslength sel))) " bloco(s)\n"))
  (if (null sel)
    nil
    (progn
      (setq i (sslength sel))
      (while (> i 0)
        (setq i (1- i))
        (setq e (ssname sel i))
        (setq d (entget e '("Dispositivo" "DISPOSITIVO")))
        (setq x (cdr (assoc -3 d)))
        (foreach app x
          (if (or (= (car app) "Dispositivo") (= (car app) "DISPOSITIVO"))
            (progn
              (setq linha (pz-dump:linha-borne e d app))
              (if (null linha)
                nil
                (pz-dump:escreve f linha)))))))))

(defun pz-dump:tudo (caminho / f)
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-dump-xdata: falha ao abrir o arquivo de saida")
    (progn
      (foreach h *positron-dump-handles* (pz-dump:entidade h f))
      (pz-dump:dicionario "CONTATOS" "MODELOS2" f)
      (pz-dump:dicionario "MASCARAS" "MODELOS2" f)
      (pz-dump:modelos-mascara f)
      ;; Reguas: e o dicionario que diz de que painel e cada regua — o que
      ;; explica por que a checagem de intervalos ignora uma regua.
      (pz-dump:dicionario "REGUAS" "MODELOS2" f)
      (if (= (getenv "POSITRON_XDATA_BORNES") "1")
        (pz-dump:bornes f)
        nil)
      (close f)
      (princ (strcat "cad-dump-xdata: escrito em " caminho)))))

;; Sem `let`: AutoLISP nao tem esse special form (o load falha em silencio e nada e
;; dumado). O caminho usa barra normal, que o AutoCAD aceita no `open`.
(setq pz-dump:saida (getenv "POSITRON_XDATA"))
(if (or (null pz-dump:saida) (= pz-dump:saida ""))
  (setq pz-dump:saida (strcat (getenv "TEMP") "/positron-xdata.txt")))
(pz-dump:tudo pz-dump:saida)
