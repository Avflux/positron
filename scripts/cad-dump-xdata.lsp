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
;;;     ATT;T1=<texto>
;;;
;;; A linha `ATT;T1=` e o numero **visivel** do bloco — o insumo do
;;; `bt9Discrepantes` (o borne cujo T1 difere do numero da regua/XData).
;;; E o que permite reconstruir a sequencia de bornes de uma regua **fora do
;;; plugin** e conferir a checagem de intervalos (`bt8intervalos`) contra o dado
;;; bruto do desenho. So entram os blocos do ModelSpace — a mesma varredura do
;;; `BornesDoDesenho.Ler`.
;;;
;;; Com `POSITRON_XDATA_PORTAS=1`, ele lista **todos** os dispositivos do desenho
;;; (`DEV;<handle>;tipo=<tipo>;modelo=<n>;porta=<n>`) e, para as portas (tipo `E`),
;;; os atributos uma por linha (`  ATT;<tag>=<texto>`). E o insumo do
;;; `bt14PortasDiscrepantes` (bloco x modelo de mascara) e tambem o que confirma
;;; as `MASCARA;<indice>;<xrecord>` dumadas sempre.
;;;
;;; Com `POSITRON_XDATA_DUPLICADOS=1`, dumpar a **identidade** de cada bloco/texto do
;;; ModelSpace como o `clsBlocos.VerificaDuplicados` a monta (o insumo do
;;; `bt12AMao`), uma linha por item:
;;;
;;;   DUP;<tipo>;<chave>;<handle>
;;;
;;; A identidade da mascara (porta `E`) e do bob (auxiliar `A`) e resolvida pelo
;;; handle referenciado; a chave do borne (`B`) usa o **indice da regua** no lugar
;;; do painel (a regua tem painel unico no dicionario, entao a chave e equivalente).
;;; E o que permite contar os duplicados **fora do plugin** e conferir a regra.
;;;
;;; Com `POSITRON_XDATA_DISPOSITIVOS=1` no ambiente ele duma os dispositivos `P` e
;;; os auxiliares `A` — uma linha por bloco
;;;
;;;   DISP;<handle>;tipo=<P|A>;bloco=<nome>;mid52=<2 chars>;nome=<nome>;painel=<n>;lm1=<n>;lm2=<n>;bob=<handle>;contato=<n>;tipoContato=<1|2|3>
;;;
;;; mais os atributos de cada bloco (`  ATT;<tag>=<texto>`) e os contatos dos
;;; modelos 1..4 do dicionario `CONTATOS`. E o insumo do `bt3Principal` (o `P` sem
;;; LM ou com `?` nos terminais) e do `bt4Auxiliar` (o `A` cujos terminais divergem
;;; do contato do modelo).

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

(defun pz-dump:bornes (f / sel i e d x linha att ad)
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
                (progn
                  (pz-dump:escreve f linha)
                  ;; O atributo T1 (numero visivel) — insumo do `bt9Discrepantes`.
                  (setq att (entnext e))
                  (while (and att (= (cdr (assoc 0 (entget att))) "ATTRIB"))
                    (setq ad (entget att))
                    (if (= (strcase (cdr (assoc 2 ad))) "T1")
                      (pz-dump:escreve f (strcat "  ATT;T1=" (vl-princ-to-string (cdr (assoc 1 ad))) "\n")))
                    (setq att (entnext att))))))))))))

;; As PORTAS inseridas no desenho (blocos `E`), uma linha por porta e uma por
;; atributo — o insumo do `bt14PortasDiscrepantes`, que cruza o modelo (MASCARAS)
;; com o bloco. O XData `Dispositivo` da porta tem o tipo em array[1], o indice do
;; modelo em array[5] e o indice da porta em array[6]; os atributos sao T*/B*/R*
;; (terminal, borne e regua).
(defun pz-dump:portas (f / sel i e d x app vals att ad)
  (setq sel (ssget "_X" '((0 . "INSERT"))))
  (pz-dump:escreve f (strcat "\nPORTAS (INSERT tipo E): "
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
              (setq vals (mapcar 'cdr (cdr app)))
              (pz-dump:escreve f (strcat "DEV;" (cdr (assoc 5 d))
                                         ";tipo=" (vl-princ-to-string (nth 0 vals))
                                         ";modelo=" (vl-princ-to-string (nth 4 vals))
                                         ";porta=" (vl-princ-to-string (nth 5 vals)) "\n"))
              (if (= (strcase (vl-princ-to-string (nth 0 vals))) "E")
                (progn
                  (setq att (entnext e))
                  (while (and att (= (cdr (assoc 0 (entget att))) "ATTRIB"))
                    (setq ad (entget att))
                    (pz-dump:escreve f (strcat "  ATT;" (cdr (assoc 2 ad)) "="
                                               (vl-princ-to-string (cdr (assoc 1 ad))) "\n"))
                    (setq att (entnext att))))))))))))

;; Os DISPOSITIVOS do desenho (blocos `P` e `A`), uma linha por bloco e uma por
;; atributo — o insumo do `bt3Principal` (o `P` sem LM ou com terminal indefinido)
;; e do `bt4Auxiliar` (o `A` cujos terminais divergem do contato do modelo).
;;
;; O XData `Dispositivo` sai na ordem "depois do app name" que o C# le como
;; `array[n+1]`: tipo em vals[0], handle do bob em vals[3] (`array[4]`), modelo em
;; vals[4] (`array[5]`), indice do contato em vals[5] (`array[6]`), tipo do contato
;; em vals[6] (`array[7]`), painel em vals[7] (`array[8]`) e os LM em
;; vals[20]/vals[22] (`array[21]`/`array[23]`). `MID52` e o `Mid(bloco, 5, 2)` que
;; o `bt4Auxiliar` compara com o tipo do contato.
(defun pz-dump:dispositivos (f / sel i e d x app vals tipo nome att ad)
  (setq sel (ssget "_X" '((0 . "INSERT"))))
  (pz-dump:escreve f (strcat "\nDISPOSITIVOS (INSERT tipo P/A): "
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
              (setq vals (mapcar 'cdr (cdr app)))
              (setq tipo (strcase (vl-princ-to-string (nth 0 vals))))
              (if (or (= tipo "P") (= tipo "A"))
                (progn
                  (setq nome (cdr (assoc 2 d)))
                  (pz-dump:escreve f
                    (strcat "DISP;" (cdr (assoc 5 d))
                            ";tipo=" tipo
                            ";bloco=" (vl-princ-to-string nome)
                            ";mid52=" (substr nome 5 2)
                            ";nome=" (vl-princ-to-string (nth 1 vals))
                            ";painel=" (vl-princ-to-string (nth 7 vals))
                            ";lm1=" (vl-princ-to-string (nth 20 vals))
                            ";lm2=" (vl-princ-to-string (nth 22 vals))
                            ";bob=" (vl-princ-to-string (nth 3 vals))
                            ";modelo=" (vl-princ-to-string (nth 4 vals))
                            ";contato=" (vl-princ-to-string (nth 5 vals))
                            ";tipoContato=" (vl-princ-to-string (nth 6 vals)) "\n"))
                  (setq att (entnext e))
                  (while (and att (= (cdr (assoc 0 (entget att))) "ATTRIB"))
                    (setq ad (entget att))
                    (pz-dump:escreve f (strcat "  ATT;" (cdr (assoc 2 ad)) "="
                                               (vl-princ-to-string (cdr (assoc 1 ad))) "\n"))
                    (setq att (entnext att))))))))))))

;; A identidade do `clsBlocos.VerificaDuplicados`: `painel_nome1_nome2_alternativo`.
;; `Nothing` vira vazio (como `Conversions.ToString`), nao o literal "nil".
(defun pz-dump:texto (v)
  (if (null v)
    ""
    (if (= (type v) 'STR) v (vl-princ-to-string v))))

(defun pz-dump:identidade-ref (h / e d x vals achou)
  (setq e (if (null h) nil (handent h)))
  (if (null e)
    "0___"
    (progn
      (setq d (entget e '("Dispositivo" "DISPOSITIVO")))
      (setq vals nil)
      (foreach app (cdr (assoc -3 d))
        (if (and (null vals)
                 (or (= (car app) "Dispositivo") (= (car app) "DISPOSITIVO")))
          (setq vals (mapcar 'cdr (cdr app)))))
      (if (null vals)
        "0___"
        (strcat (pz-dump:texto (nth 7 vals)) "_"
                (pz-dump:texto (nth 1 vals)) "_"
                (pz-dump:texto (nth 2 vals)) "_"
                (pz-dump:texto (nth 3 vals)))))))

(defun pz-dump:duplicados (f / sel i e d x app vals tipo k)
  (setq sel (ssget "_X" '((0 . "INSERT,TEXT"))))
  (pz-dump:escreve f (strcat "\nDUPLICADOS (blocos e textos): "
                             (itoa (if (null sel) 0 (sslength sel))) " item(ns)\n"))
  (if (null sel)
    nil
    (progn
      (setq i (sslength sel))
      (while (> i 0)
        (setq i (1- i))
        (setq e (ssname sel i))
        (setq d (entget e))
        (if (= (cdr (assoc 0 d)) "INSERT")
          (progn
            (setq d (entget e '("Dispositivo" "DISPOSITIVO")))
            (foreach app (cdr (assoc -3 d))
              (if (or (= (car app) "Dispositivo") (= (car app) "DISPOSITIVO"))
                (progn
                  (setq vals (mapcar 'cdr (cdr app)))
                  (setq tipo (strcase (pz-dump:texto (nth 0 vals))))
                  (if (or (= tipo "M") (= tipo "P"))
                    (pz-dump:escreve f (strcat "DUP;" tipo ";"
                      (pz-dump:texto (nth 7 vals)) "_" (pz-dump:texto (nth 1 vals)) "_"
                      (pz-dump:texto (nth 2 vals)) "_" (pz-dump:texto (nth 3 vals))
                      ";" (cdr (assoc 5 d))
                      ";" (pz-dump:texto (nth 12 vals)) "\n"))
                    (if (= tipo "E")
                      (pz-dump:escreve f (strcat "DUP;E;" (pz-dump:identidade-ref (nth 3 vals))
                        "_" (pz-dump:texto (nth 5 vals)) ";" (cdr (assoc 5 d)) "\n"))
                      (if (= tipo "A")
                        (pz-dump:escreve f (strcat "DUP;A;" (pz-dump:identidade-ref (nth 3 vals))
                          "_" (pz-dump:texto (nth 5 vals)) ";" (cdr (assoc 5 d)) "\n"))
                        (if (= tipo "B")
                          (pz-dump:escreve f (strcat "DUP;B;" (pz-dump:texto (nth 7 vals)) "_"
                            (pz-dump:texto (nth 4 vals)) ";" (cdr (assoc 5 d)) "\n"))
                          nil))))))))          (progn
            (setq d (entget e '("Definicao" "DEFINICAO")))
            (foreach app (cdr (assoc -3 d))
              ;; O app name e o `(car app)`; os valores (apos o 1001) sao
              ;; handleDaMascara, indiceDoModelo e indiceDaPorta.
              (if (= (strcase (pz-dump:texto (car app))) "DEFINICAO")
                (progn
                  (setq vals (mapcar 'cdr (cdr app)))
                  (pz-dump:escreve f (strcat "DUP;D;" (pz-dump:texto (nth 0 vals)) "_"
                    (pz-dump:texto (nth 1 vals)) "_" (pz-dump:texto (nth 2 vals))
                    ";" (cdr (assoc 5 d)) "\n")))))))))) ) 

;; O dicionario CENG_PLAQUETA: uma entrada por **painel**, com o Xrecord das
;; plaquetas daquele painel — o insumo do `EPLQ` (registros de 7 valores:
;; tipo, handle, indexRegua, desc1, desc2, desc3, modelo). E o que permite ver se
;; o desenho tem plaqueta e conferir, fora do plugin, o nome que cada uma resolve.
(defun pz-dump:plaquetas (f / d item r)
  (setq d (dictsearch (namedobjdict) "CENG_PLAQUETA"))
  (if (null d)
    (pz-dump:escreve f "\nCENG_PLAQUETA: nao existe\n")
    (foreach item d
      (if (= (car item) 3)
        (progn
          (setq r (dictsearch (cdr (assoc -1 d)) (cdr item)))
          (pz-dump:escreve f
            (strcat "\nPLAQUETA;" (cdr item) ";"
                    (if (null r) "NAO EXISTE"
                        (vl-princ-to-string (entget (cdr (assoc -1 r)))))
                    "\n")))))))

;; O dicionario CONTATOS: cada entrada e os contatos auxiliares de UM modelo — o
;; `sTerminaisMod` do `bt4Auxiliar` sai daqui (registros de 8 valores, campos
;; +1..+3 = T1..T3 e +4 = tipo). Duma **todas** as entradas, porque os modelos que
;; os auxiliares referenciam nao sao 1..N contiguos.
(defun pz-dump:contatos (f / d item r)
  (setq d (dictsearch (namedobjdict) "CONTATOS"))
  (if (null d)
    (pz-dump:escreve f "\nCONTATOS: nao existe\n")
    (foreach item d
      (if (= (car item) 3)
        (progn
          (setq r (dictsearch (cdr (assoc -1 d)) (cdr item)))
          (pz-dump:escreve f
            (strcat "\nCONTATOS/" (cdr item) ";"
                    (if (null r) "NAO EXISTE"
                        (vl-princ-to-string (entget (cdr (assoc -1 r)))))
                    "\n")))))))

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
      (pz-dump:plaquetas f)
      (if (= (getenv "POSITRON_XDATA_BORNES") "1")
        (pz-dump:bornes f)
        nil)
      (if (= (getenv "POSITRON_XDATA_PORTAS") "1")
        (pz-dump:portas f)
        nil)
      (if (= (getenv "POSITRON_XDATA_DISPOSITIVOS") "1")
        (progn
          (pz-dump:dispositivos f)
          ;; Todos os contatos auxiliares dos modelos do dicionario.
          (pz-dump:contatos f))
        nil)
      (if (= (getenv "POSITRON_XDATA_DUPLICADOS") "1")
        (pz-dump:duplicados f)
        nil)
      (close f)
      (princ (strcat "cad-dump-xdata: escrito em " caminho)))))

;; Sem `let`: AutoLISP nao tem esse special form (o load falha em silencio e nada e
;; dumado). O caminho usa barra normal, que o AutoCAD aceita no `open`.
(setq pz-dump:saida (getenv "POSITRON_XDATA"))
(if (or (null pz-dump:saida) (= pz-dump:saida ""))
  (setq pz-dump:saida (strcat (getenv "TEMP") "/positron-xdata.txt")))
(pz-dump:tudo pz-dump:saida)
