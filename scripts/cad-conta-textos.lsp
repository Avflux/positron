;;; cad-conta-textos.lsp — contingência independente do `ApagarTextosEmBranco`
;;; e do `apagaXDataTerceiros` (frente 2 do §7.6), fora do plugin.
;;;
;;; Uso pelo harness (o `-Fixture` carrega antes do NETLOAD, então o desenho
;;; ainda está intacto):
;;;
;;;   set POSITRON_TEXTOS=%TEMP%\positron-textos.txt
;;;   powershell -File scripts/cad-zwcad-smoke.ps1 -Fixture scripts/cad-conta-textos.lsp ...
;;;
;;; Saída:
;;;
;;;   TEXTOS;<total>    + TEXTO;<handle>;<apps>;<conteudo>
;;;   ATTDEFS;<total>   + ATTDEF;<handle>;<apps>;<tag>;<conteudo>
;;;   TERCEIROS;<total> + TERCEIRO;<handle>
;;;
;;; `apps` é a lista de app names de XData da entidade, separada por vírgula (a
;;; lista que o `entget` pede; os app names do Positron e os de terceiros mais
;;; comuns). Com ela dá para reconstruir em Python a regra do original — apaga o
;;; texto **em branco e sem XData** — e conferir o número do plugin.
;;;
;;; **Por que ATTDEF entra:** o `ApagarTextosEmBranco` do original casta para
;;; `DBText`, e no .NET do CAD o `AttributeDefinition` deriva de `DBText` — o
;;; `ssget` do LISP separa `TEXT` de `ATTDEF`, mas o plugin lê os dois. É o que
;;; explica a diferença entre o total do `ssget` e o do contador do plugin.
;;;
;;; `vl-princ-to-string` escapa quebra de linha (sai `\n` literal), então o
;;; conteúdo não parte a linha.

;; A lista de app names vem da **tabela APPID do próprio desenho**, não de uma
;; lista fixa: o `entget` só devolve o grupo -3 dos app names que ele recebe, e um
;; app name fora da lista faria o texto parecer "sem XData" — que é justamente a
;; condição que o `ApagarTextosEmBranco` usa para apagar. Lista fixa dá falso
;; positivo (foi medido: 41 "apagáveis" contra os 14 do plugin).
(defun pz-ct:appids ( / t1 nomes)
  (setq nomes nil)
  (setq t1 (tblnext "APPID" T))
  (while t1
    (setq nomes (cons (cdr (assoc 2 t1)) nomes))
    (setq t1 (tblnext "APPID")))
  nomes)

(setq pz-ct:apps (pz-ct:appids))

(defun pz-ct:escreve (f s) (princ s f))

(defun pz-ct:nomes (e / d nomes)
  (setq d (entget e pz-ct:apps))
  (setq nomes "")
  (foreach app (cdr (assoc -3 d))
    (setq nomes (strcat nomes (if (= nomes "") "" ",") (vl-princ-to-string (car app)))))
  nomes)

(defun pz-ct:dump (f tipo sels / i e d)
  (if sels
    (progn
      (setq i (sslength sels))
      (while (> i 0)
        (setq i (1- i))
        (setq e (ssname sels i))
        (setq d (entget e))
        (pz-ct:escreve f
          (strcat tipo ";" (cdr (assoc 5 d)) ";" (pz-ct:nomes e) ";"
                  (vl-princ-to-string (cdr (assoc 1 d))) "\n"))))))

(setq pz-ct:saida (getenv "POSITRON_TEXTOS"))
(if (or (null pz-ct:saida) (= pz-ct:saida ""))
  (setq pz-ct:saida (strcat (getenv "TEMP") "/positron-textos.txt")))

(setq pz-ct:f (open pz-ct:saida "w"))
(setq pz-ct:textos (ssget "_X" '((0 . "TEXT"))))
(setq pz-ct:attdefs (ssget "_X" '((0 . "ATTDEF"))))
(setq pz-ct:terceiros (ssget "_X" '((-3 ("AEC_XDATA_BOUND_SPACE")))))

(pz-ct:escreve pz-ct:f (strcat "TEXTOS;" (itoa (if (null pz-ct:textos) 0 (sslength pz-ct:textos))) "\n"))
(pz-ct:dump pz-ct:f "TEXTO" pz-ct:textos)
(pz-ct:escreve pz-ct:f (strcat "ATTDEFS;" (itoa (if (null pz-ct:attdefs) 0 (sslength pz-ct:attdefs))) "\n"))
(pz-ct:dump pz-ct:f "ATTDEF" pz-ct:attdefs)
(pz-ct:escreve pz-ct:f (strcat "TERCEIROS;" (itoa (if (null pz-ct:terceiros) 0 (sslength pz-ct:terceiros))) "\n"))
(if pz-ct:terceiros
  (progn
    (setq pz-ct:j (sslength pz-ct:terceiros))
    (while (> pz-ct:j 0)
      (setq pz-ct:j (1- pz-ct:j))
      (pz-ct:escreve pz-ct:f
        (strcat "TERCEIRO;" (cdr (assoc 5 (entget (ssname pz-ct:terceiros pz-ct:j)))) "\n")))))
(close pz-ct:f)
(princ "cad-conta-textos: ok")
