; Fixture do NOVAPAGINA (fatia 6): monta tres paginas (os layers 1, 2 e 3), um bloco de
; formato (PZ-FORMATO, nome proprio para nao colidir com o bloco que o desenho real ja tem)
; com atributos na camada -1 (o modelo do criaCamposFormato) e o XData DiagLog "Formato" no
; INSERT. O comando pz-conta-paginas e o instrumento independente: le os layers e os textos
; com o XData do titulo, sem regra nenhuma.
;
; Esperado depois do NOVAPAGINA: o layer 4 criado, CINCO campos copiados (TITULO1PAG,
; TITULO2PAG, PAINEL, FL e CONT - o SECAO fica de fora porque o if/else do criaCamposFormato
; nao o trata, mesmo estando na lista de atributos protegidos) e os TRES titulos que a pagina
; 3 tem nos indices 1, 2 e 4 (o T3 nao tem campo na pagina nova: o formato nao trouxe o
; indice 3).
(setvar "CMDECHO" 0)
(regapp "DiagLog")
(command "_.LAYER" "_M" "1" "")
(command "_.LAYER" "_M" "2" "")
(command "_.LAYER" "_M" "3" "")
(command "_.LAYER" "_M" "-1" "")
(command "_.LAYER" "_M" "0" "")

; O bloco de formato: os ATTDEFs na camada -1 sao o modelo dos campos.
(defun pz-attdef (tag / )
  (entmake (list (cons 0 "ATTDEF") (cons 8 "-1") (cons 10 (list 0.0 0.0 0.0))
    (cons 40 2.5) (cons 1 "") (cons 3 tag) (cons 2 tag) (cons 70 0))))

(if (not (tblsearch "BLOCK" "PZ-FORMATO"))
  (progn
    (entmake (list (cons 0 "BLOCK") (cons 2 "PZ-FORMATO") (cons 70 0) (cons 10 (list 0.0 0.0 0.0))))
    (entmake (list (cons 0 "LINE") (cons 8 "-1") (cons 10 (list 0.0 0.0 0.0)) (cons 11 (list 10.0 0.0 0.0))))
    (pz-attdef "TITULO1PAG")
    (pz-attdef "TITULO2PAG")
    (pz-attdef "PAINEL")
    (pz-attdef "FL")
    (pz-attdef "CONT")
    (pz-attdef "SECAO")
    (entmake (list (cons 0 "ENDBLK")))))

; A marca do XData do formato e "Formato" (o PossuiXDataFormato procura por ela).
(defun pz-xdata-formato ()
  (list -3 (list "DiagLog" (cons 1000 "Formato") (cons 1070 3) (cons 1000 " "))))

; O INSERT do formato com o XData que o PossuiXDataFormato procura.
; O 66=1 diz que os atributos seguem: sem isso o entmake cria o INSERT **sem**
; AttributeReference nenhuma e o criaCamposFormato nao tem de onde copiar.
(defun pz-attrib (tag)
  (entmake (list (cons 0 "ATTRIB") (cons 8 "-1") (cons 10 (list 0.0 0.0 0.0))
    (cons 40 2.5) (cons 1 "") (cons 2 tag) (cons 70 0))))

; O XData entra no proprio entmake: o entmod depois do SEQEND nao pegava o -3 no INSERT.
(entmake (append
  (list (cons 0 "INSERT") (cons 2 "PZ-FORMATO") (cons 8 "0") (cons 66 1)
    (cons 10 (list 0.0 0.0 0.0)))
  (list (pz-xdata-formato))))
(setq pz-formato (entlast))
(pz-attrib "TITULO1PAG")
(pz-attrib "TITULO2PAG")
(pz-attrib "PAINEL")
(pz-attrib "FL")
(pz-attrib "CONT")
(pz-attrib "SECAO")
(entmake (list (cons 0 "SEQEND")))

; Os QUATRO titulos da pagina 3 (o modelo que a pagina nova herda): TEXT na camada 3 com o
; XData do titulo (DiagLog/TituloPagina).
(defun pz-xdata-titulo (indice valor)
  (list -3 (list "DiagLog" (cons 1000 "TituloPagina") (cons 1070 indice) (cons 1000 valor)
    (cons 1070 1) (cons 1000 "ana") (cons 1000 "2026-10-12") (cons 1071 1) (cons 1040 1.0)
    (cons 1000 " "))))

(defun pz-titulo (txt indice / e)
  (command "_.TEXT" (list 20.0 (+ 10.0 indice)) 2.5 0 txt)
  (setq e (entlast))
  (entmod (append (entget e) (list (pz-xdata-titulo indice txt)))))

(command "_.LAYER" "_S" "3" "")
(pz-titulo "T1" 1)
(pz-titulo "T2" 2)
(pz-titulo "T3" 3)
(pz-titulo "T4" 4)
(command "_.LAYER" "_S" "0" "")

; --- o instrumento independente ------------------------------------------------
(defun pz-titulo-do-texto (e / dados app)
  (setq dados (entget e (list "DiagLog")))
  (setq app (car (cdr (assoc -3 dados))))
  (if app (strcat (cdr (nth 1 app)) ";" (itoa (cdr (nth 2 app)))) "sem-xdata"))

(defun c:pz-conta-paginas ( / arquivo f camada conjunto i e dados)
  (setq arquivo (getenv "POSITRON_DUMP"))
  (if (or (null arquivo) (= arquivo ""))
    (setq arquivo (strcat (getenv "TEMP") "/positron-paginas.txt")))
  (setq f (open arquivo "w"))
  (if (null f)
    (princ "\npz-conta-paginas: nao consegui abrir a saida")
    (progn
      (setq camada (tblnext "LAYER" T))
      (while camada
        (write-line (strcat "LAYER;" (cdr (assoc 2 camada))) f)
        (setq camada (tblnext "LAYER")))
      (setq conjunto (ssget "_X" (list (cons 0 "TEXT") (cons 410 "Model"))))
      (if conjunto
        (progn
          (setq i 0)
          (while (< i (sslength conjunto))
            (setq e (ssname conjunto i))
            (setq dados (entget e))
            (write-line (strcat "TEXTO;" (cdr (assoc 8 dados)) ";"
              (cdr (assoc 1 dados)) ";" (pz-titulo-do-texto e)) f)
            (setq i (1+ i)))))
      (close f)
      (princ (strcat "\npz-conta-paginas: saida em " arquivo))))
  (princ))

(princ "\nfixture NOVAPAGINA montada (paginas 1..3 + bloco PZ-FORMATO + titulos na 3)")
(princ)
