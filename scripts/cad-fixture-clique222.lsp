; Rodada 222: o desenho da prova do clique fisico na paleta.
; Roda na COPIA do Funcional.dwg que o harness abre (o original nunca e tocado), antes do NETLOAD
; e do `pzFolhas`. POSITRON_C222_MODO escolhe o que montar:
;
;   atalhos — o Xrecord CENG_ELET/Atalhos com as SEIS strings DXF 1 do `Dicionario.gravaAtalhos`
;             (Dicionario.cs:99-207): "2", "6", "999" (pagina inexistente, o clique limpa),
;             "" (slot livre para a captura do btSalva) e "QUINTO"/"SEXTO" nas duas posicoes que
;             NAO tem rotulo na tela (`lb1..lb4` so). O clique fisico em qualquer um dos quatro
;             rotulos grava os seis de volta: os dois ultimos tem de sobreviver.
;
;   titulo4 — o TITULO 4 no formato e no desenho: um DBText no layer da pagina "7" com o XData
;             DiagLog/TituloPagina de indice 4 (o `gravarXDataTitulo`, 10 valores) e um ATRIBUTO
;             TITULO4PAG no layer "-1" da referencia do formato — a coluna do editor so aparece
;             quando o atributo esta no formato (`Pagina.buscaTitulosExistentes`, `Pagina.cs:2502`).
;             O atributo entra pelo ActiveX (`vla-AddAttribute`), que so existe com interface.
;
; (c222:dump) escreve em POSITRON_C222_SAIDA, por AutoLISP puro (nenhum acesso ao plugin):
; "ATALHOS;<total>", "ATALHO;<indice>;<valor>" (indice de 1 a 6), "PAGINA;<nome>" por layer de
; pagina, "TITULO4;<layer>;<texto>" e "TOTAL;<paginas>".
(setvar "CMDECHO" 0)

; ---------- o Xrecord dos atalhos ----------
(defun c222:dicionario-ceng (/ raiz dic)
  (setq raiz (namedobjdict))
  (setq dic (dictsearch raiz "CENG_ELET"))
  (if dic
    (cdr (assoc -1 dic))
    (dictadd raiz "CENG_ELET"
      (entmakex '((0 . "DICTIONARY") (100 . "AcDbDictionary") (281 . 1))))))

(defun c222:gravar-atalhos (valores / dic x)
  (setq dic (c222:dicionario-ceng))
  (if (dictsearch dic "Atalhos") (dictremove dic "Atalhos"))
  (setq x (entmakex (append '((0 . "XRECORD") (100 . "AcDbXrecord") (280 . 1))
                            (mapcar '(lambda (v) (cons 1 v)) valores))))
  (dictadd dic "Atalhos" x))

(defun c222:ler-atalhos (/ d x)
  (setq d (dictsearch (namedobjdict) "CENG_ELET"))
  (if d (setq d (dictsearch (cdr (assoc -1 d)) "Atalhos")))
  (if d
    (mapcar 'cdr (vl-remove-if-not '(lambda (par) (= 1 (car par))) (entget (cdr (assoc -1 d)))))))

; ---------- o titulo 4 ----------
(regapp "DiagLog")
(defun c222:titulo4 (layer indice texto)
  (entmakex (list '(0 . "TEXT") (cons 8 layer) '(10 900000.0 0.0 0.0) '(40 . 2.5)
    (cons 1 texto)
    (list -3 (list "DiagLog" '(1000 . "TituloPagina") (cons 1070 indice) (cons 1000 texto)
      '(1070 . 1) '(1000 . "harness") '(1000 . "222") '(1071 . 1) '(1040 . 1.0) '(1000 . " "))))))

; O nome da definicao do bloco de formato (o INSERT com XData DiagLog/Formato no ModelSpace,
; lido por entget sem depender do plugin — o mesmo criterio da rodada 182).
(defun c222:formato (/ e d xd bloco)
  (setq e (entnext))
  (while (and e (not bloco))
    (setq d (entget e '("DiagLog")))
    (if (= "INSERT" (cdr (assoc 0 d)))
      (progn
        (setq xd (car (cdr (assoc -3 d))))
        (if (and xd (= "Formato" (cdr (car (cdr xd)))))
          (setq bloco e))))
    (setq e (entnext e)))
  bloco)

(defun c222:atributo-titulo4 (/ bloco vla att r)
  (vl-load-com)
  (setq bloco (c222:formato))
  (if (not bloco)
    "sem bloco de formato"
    (progn
      (setq r (vl-catch-all-apply
        (function (lambda ()
          (setq vla (vlax-ename->vla-object bloco))
          (setq att (vla-AddAttribute vla 2.5 0 "Titulo 4" '(0.0 0.0 0.0) "TITULO4PAG" "TITULO 4"))
          (vla-put-Layer att "-1")
          (vla-put-TextString att "TITULO 4")
          "atributo TITULO4PAG (layer -1) criado"))))
      (if (vl-catch-all-error-p r)
        (strcat "vla-AddAttribute falhou: " (vl-catch-all-error-message r))
        r))))

; A prova da carga da fixture vai para um arquivo ao lado do despejo: o comando da interface
; nao tem stdout que o harness leia.
(defun c222:aviso (texto / f)
  (setq f (open (strcat (getenv "POSITRON_C222_SAIDA") ".carga") "w"))
  (if f (progn (write-line texto f) (close f))))

; ---------- o documento tipo D (desenho NOVO) ----------
; O `verificaTipoXData` le as apps do ModelSpace: com o DiagLog e sem o Eletron o desenho e "D".
; Num desenho novo nao ha o que remover — o `vla-SetXData` poe o DiagLog (ActiveX, so com
; interface: a rodada 181 mediu que no accoreconsole ele nao existe).
(defun c222:layer (nome)
  (if (not (tblsearch "LAYER" nome))
    (entmake (list '(0 . "LAYER")
                   '(100 . "AcDbSymbolTableRecord")
                   '(100 . "AcDbLayerTableRecord")
                   (cons 2 nome) '(70 . 0) '(62 . 7) '(6 . "CONTINUOUS")))))

(defun c222:virar-d (/ ms r)
  (vl-load-com)
  (setq r (vl-catch-all-apply
    (function (lambda ()
      (setq ms (vla-get-ModelSpace (vla-get-ActiveDocument (vlax-get-acad-object))))
      (vla-SetXData ms
        (vlax-make-variant (vlax-safearray-fill (vlax-make-safearray vlax-vbInteger '(0 . 1)) '(1001 1000)))
        (vlax-make-variant (vlax-safearray-fill (vlax-make-safearray vlax-vbVariant '(0 . 1)) '("DiagLog" "Marca"))))
      "DiagLog no ModelSpace"))))
  (if (vl-catch-all-error-p r)
    (strcat "vla-SetXData falhou: " (vl-catch-all-error-message r))
    r))

; ---------- as paginas (a mesma leitura independente da rodada 221) ----------
(defun c222:digito (c) (and (>= (ascii c) 48) (<= (ascii c) 57)))
(defun c222:letra (c) (and (>= (ascii c) 65) (<= (ascii c) 90)))
(defun c222:soDigitos (texto / n i ok)
  (setq n (strlen texto) i 1 ok (> n 0))
  (while (and ok (<= i n))
    (if (not (c222:digito (substr texto i 1))) (setq ok nil))
    (setq i (1+ i)))
  ok)
(defun c222:ePagina (nome / n ultimo numero)
  (setq n (strlen nome) ultimo (substr nome n 1) numero nil)
  (if (c222:letra ultimo)
    (if (c222:soDigitos (substr nome 1 (1- n)))
      (setq numero (atoi (substr nome 1 (1- n)))))
    (if (c222:soDigitos nome) (setq numero (atoi nome))))
  (and numero (> numero 0)))

; ---------- o despejo ----------
(defun c222:dump (/ caminho f tabela nome total atalhos ss i d x indice texto bloco e)
  (setq caminho (getenv "POSITRON_C222_SAIDA"))
  (if (and caminho (> (strlen caminho) 0))
    (progn
      (setq f (open caminho "w") total 0)
      (setq atalhos (c222:ler-atalhos))
      (if atalhos
        (progn
          (write-line (strcat "ATALHOS;" (itoa (length atalhos))) f)
          (setq i 1)
          (foreach valor atalhos
            (write-line (strcat "ATALHO;" (itoa i) ";" valor) f)
            (setq i (1+ i))))
        (write-line "ATALHOS;0" f))
      (setq tabela (tblnext "LAYER" T))
      (while tabela
        (setq nome (cdr (assoc 2 tabela)))
        (if (c222:ePagina nome)
          (progn
            (setq total (1+ total))
            (write-line (strcat "PAGINA;" nome) f)))
        (setq tabela (tblnext "LAYER")))
      ; Os atributos da referencia do formato (a coluna do editor sai deles).
      (setq bloco (c222:formato))
      (if bloco
        (progn
          (setq e (entnext bloco))
          (while (and e (/= "SEQEND" (cdr (assoc 0 (entget e)))))
            (setq d (entget e))
            (if (= "ATTRIB" (cdr (assoc 0 d)))
              (write-line (strcat "ATRIBUTO;" (cdr (assoc 8 d)) ";" (cdr (assoc 2 d))) f))
            (setq e (entnext e)))))
      (setq ss (ssget "_X" '((0 . "TEXT"))) i 0)
      (while (and ss (< i (sslength ss)))
        (setq d (entget (ssname ss i) '("DiagLog"))
              x (cdr (assoc "DiagLog" (cdr (assoc -3 d))))
              i (1+ i))
        (if (and x (= (cdr (car x)) "TituloPagina"))
          (progn
            (setq indice (cdr (cadr x)) texto (cdr (assoc 1 d)))
            (if (= indice 4)
              (write-line (strcat "TITULO4;" (cdr (assoc 8 d)) ";" texto) f)))))
      (write-line (strcat "TOTAL;" (itoa total)) f)
      (close f)))
  (princ))

; ---------- a montagem ----------
(setq c222:modo (strcase (if (getenv "POSITRON_C222_MODO") (getenv "POSITRON_C222_MODO") "")))
(cond
  ((= c222:modo "ATALHOS")
   (c222:gravar-atalhos '("2" "6" "999" "" "QUINTO" "SEXTO"))
   (princ "\nFixtures 222: Xrecord CENG_ELET/Atalhos com seis valores (2, 6, 999, vazio, QUINTO, SEXTO)."))
  ((= c222:modo "TIPO-D")
   (c222:layer "1") (c222:layer "2") (c222:layer "3") (c222:layer "10")
   (c222:aviso (strcat "modo TIPO-D: 4 layers de pagina; " (c222:virar-d)))
   (princ "\nFixtures 222: desenho novo com 4 paginas e o DiagLog no ModelSpace (tipo D)."))
  ((= c222:modo "TITULO4")
   (c222:titulo4 "7" 4 "TITULO 4 DA PROVA 222")
   (c222:aviso "modo TITULO4: DBText de indice 4 no layer 7")
   (princ "\nFixtures 222: titulo 4 no layer \"7\" (o atributo do formato vem do harness)."))
  (T (princ (strcat "\nFixtures 222: modo \"" c222:modo "\" — so o despejo."))))
(princ)
