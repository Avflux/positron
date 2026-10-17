; Fixture do clsApagar.ApagarDerivados (rodadas 208-210): monta, sobre o Funcional.dwg, os tres
; ramos que a exclusao da pagina "16" leva junto. As paginas "15" ficam como vizinhas.
;
;   interligacao: P1 (layer 16, INTERLIGACAO tipo 2 -> handle de P2); P2 (layer 15, a irma);
;                 R1 (layer 15, rotulo AUXINTERLIG de P2) e R2 (rotulo de outro trecho: fica).
;   contato aux : A1 (layer 16, Dispositivo tipo A) e MO (layer 15, bloco de modelo com
;                 HandleContatoAux = A1 e atributos INSERCAO/INSERCAONA/TAG).
;   mascaras    : M1 (layer 16, a apagada) com as copias M2 e M3 (layer 15, mesmos nomes/painel);
;                 E1/D1 (porta e definicao de M1); M4 (layer 16, sem copias) com E2/D2;
;                 E3 (porta de uma mascara que nao existe: fica).
;
; Uso: -Desenho Funcional.dwg -Fixture este.lsp -Comandos PZ-APD-DUMP,APAGAPAGINA,PZ-APD-DUMP com
; POSITRON_PAGINA=16 e POSITRON_XDATA=<arquivo de saida>.
(setvar "CMDECHO" 0)
(foreach app '("Dispositivo" "Modelo" "INTERLIGACAO" "AUXINTERLIG" "Definicao")
  (regapp app))

(defun pz-apd:handle (e) (cdr (assoc 5 (entget e))))

(defun pz-apd:xdata (e xdata)
  (entmod (append (entget e) (list xdata)))
  e)

(defun pz-apd:texto (layer x y xdata / e)
  (setq e (entmakex (list '(0 . "TEXT") '(100 . "AcDbEntity") (cons 8 layer)
                          '(100 . "AcDbText") (list 10 x y 0.0) '(40 . 1.0) '(1 . "T")
                          '(100 . "AcDbText"))))
  (if xdata (pz-apd:xdata e xdata))
  e)

(defun pz-apd:polyline (layer x xdata / e)
  (setq e (entmakex (list '(0 . "LWPOLYLINE") '(100 . "AcDbEntity") (cons 8 layer)
                          '(100 . "AcDbPolyline") '(90 . 2) '(70 . 0)
                          (list 10 x 0.0) (list 10 (+ x 5.0) 0.0))))
  (if xdata (pz-apd:xdata e xdata))
  e)

; Bloco com os tres atributos das mascaras e os tres do contato auxiliar.
(defun pz-apd:bloco (nome tags / tag)
  (entmake (list '(0 . "BLOCK") '(100 . "AcDbEntity") '(8 . "0") '(100 . "AcDbBlockBegin")
                 (cons 2 nome) '(70 . 2) (list 10 0.0 0.0 0.0) (cons 3 nome) '(1 . "")))
  (foreach tag tags
    (entmake (list '(0 . "ATTDEF") '(100 . "AcDbEntity") '(8 . "0") '(100 . "AcDbText")
                   (list 10 0.0 0.0 0.0) '(40 . 1.0) '(1 . "") '(100 . "AcDbAttributeDefinition")
                   (cons 3 tag) (cons 2 tag) '(70 . 0))))
  (entmake '((0 . "ENDBLK") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockEnd"))))

; INSERT com atributos (tag . valor) e o XData. Sem atributos, o INSERT sai sem o marcador 66/SEQEND.
(defun pz-apd:insert (nome layer x atributos xdata / e par base)
  (setq base (list '(0 . "INSERT") '(100 . "AcDbEntity") (cons 8 layer)))
  (if atributos (setq base (append base (list '(66 . 1)))))
  (setq base (append base (list '(100 . "AcDbBlockReference") (cons 2 nome) (list 10 x 5.0 0.0))))
  (if atributos
    (entmake base)
    (setq e (entmakex base)))
  (if atributos
    (progn
      (foreach par atributos
        (entmake (list '(0 . "ATTRIB") '(100 . "AcDbEntity") (cons 8 layer) '(100 . "AcDbText")
                       (list 10 x 5.0 0.0) '(40 . 1.0) (cons 1 (cdr par)) '(100 . "AcDbAttribute")
                       (cons 2 (car par)) '(70 . 0))))
      (entmake '((0 . "SEQEND") (100 . "AcDbEntity")))
      (setq e (entlast))))
  (if xdata (pz-apd:xdata e xdata))
  e)

(defun pz-apd:x-interlig (tipo handle)
  (list -3 (list "INTERLIGACAO"
    (cons 1070 tipo) (cons 1000 "CAB") (cons 1070 1) (cons 1000 "V") (cons 1070 1)
    (cons 1070 0) (cons 1070 2) (cons 1070 0) (cons 1000 handle) (cons 1000 "") (cons 1000 "")
    (cons 1070 0) (cons 1070 0) (cons 1000 "u") (cons 1000 "d") (cons 1071 1) (cons 1040 0.0)
    (cons 1000 ""))))

(defun pz-apd:x-rotulo (handle)
  (list -3 (list "AUXINTERLIG"
    (cons 1070 1) (cons 1000 handle) (cons 1000 "") (cons 1071 1) (cons 1000 "u") (cons 1000 "d")
    (cons 1000 ""))))

(defun pz-apd:x-aux ()
  (list -3 (list "Dispositivo"
    (cons 1000 "A") (cons 1000 "N1") (cons 1000 "N2") (cons 1000 "1A") (cons 1071 5)
    (cons 1071 2) (cons 1070 0) (cons 1070 0) (cons 1000 "") (cons 1000 "") (cons 1000 ""))))

(defun pz-apd:x-modelo (handleContatoAux)
  (list -3 (list "Modelo"
    (cons 1000 "1A") (cons 1071 5) (cons 1071 2) (cons 1000 handleContatoAux))))

; Mascara (29 valores do GravarXDataMascara).
(defun pz-apd:x-mascara (n1 n2 lm1 lm2 topo layout)
  (list -3 (list "Dispositivo"
    (cons 1000 "M") (cons 1000 n1) (cons 1000 n2) (cons 1000 "") (cons 1000 "") (cons 1000 "")
    (cons 1040 0.0) (cons 1070 1) (cons 1070 0) (cons 1070 0) (cons 1000 "")
    (cons 1071 7) (cons 1070 0) (cons 1000 "") (cons 1000 "") (cons 1000 topo) (cons 1000 layout)
    (cons 1000 "") (cons 1011 (list 0.0 0.0 0.0)) (cons 1040 0.0) (cons 1071 lm1) (cons 1070 0)
    (cons 1071 lm2) (cons 1000 "u") (cons 1000 "d") (cons 1040 0.0) (cons 1040 0.0)
    (cons 1040 0.0))))

; Porta (18 valores do GravarXDataPorta).
(defun pz-apd:x-porta (handleMascara)
  (list -3 (list "Dispositivo"
    (cons 1000 "E") (cons 1000 "PN1") (cons 1000 "PN2") (cons 1000 handleMascara)
    (cons 1071 3) (cons 1071 4) (cons 1070 0) (cons 1070 0) (cons 1000 "DEF") (cons 1000 "CP")
    (cons 1000 "ALT") (cons 1040 0.0) (cons 1040 0.0) (cons 1071 0) (cons 1071 0)
    (cons 1000 "u") (cons 1000 "d"))))

; Dispositivo principal P (29 valores, o layout do GravarXDataDispPrincipal): nomes, painel, indexModelo e complementar (-1 = sim).
(defun pz-apd:x-disp (n1 n2 alt painel idx compl)
  (list -3 (list "Dispositivo"
    (cons 1000 "P") (cons 1000 n1) (cons 1000 n2) (cons 1000 alt) (cons 1000 "") (cons 1000 "")
    (cons 1040 0.0) (cons 1070 painel) (cons 1070 0) (cons 1070 0) (cons 1000 "")
    (cons 1071 idx) (cons 1070 compl) (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1000 "")
    (cons 1000 "") (cons 1011 (list 0.0 0.0 0.0)) (cons 1040 0.0) (cons 1071 0) (cons 1070 0)
    (cons 1071 0) (cons 1000 "u") (cons 1000 "d") (cons 1040 0.0) (cons 1040 0.0) (cons 1040 0.0))))

(defun pz-apd:x-definicao (handleMascara)
  (list -3 (list "Definicao"
    (cons 1000 handleMascara) (cons 1071 3) (cons 1071 4) (cons 1000 "PORTA"))))

(setq pz-apd:passo 1)
(pz-apd:bloco "PZAPD" '("MODELO" "FABRICANTE" "DESCRICAO" "INSERCAO" "INSERCAONA" "TAG"))

(setq pz-apd:passo 2)
(setq pz-apd:att-vazios '(("MODELO" . "") ("FABRICANTE" . "") ("DESCRICAO" . "")))

; --- interligacao
(setq pz-apd:passo 3)
(setq pz-apd:p2 (pz-apd:polyline "15" 20.0 (pz-apd:x-interlig 1 "0")))
(setq pz-apd:passo 4)
(setq pz-apd:h-p2 (pz-apd:handle pz-apd:p2))
(setq pz-apd:passo 5)
(setq pz-apd:r1 (pz-apd:texto "15" 20.0 1.0 (pz-apd:x-rotulo pz-apd:h-p2)))
(setq pz-apd:passo 6)
(setq pz-apd:r2 (pz-apd:texto "15" 22.0 1.0 (pz-apd:x-rotulo "FFFF")))
(setq pz-apd:passo 7)
(setq pz-apd:p1 (pz-apd:polyline "16" 0.0 (pz-apd:x-interlig 2 pz-apd:h-p2)))

; --- contato auxiliar
(setq pz-apd:passo 8)
(setq pz-apd:a1 (pz-apd:insert "PZAPD" "16" 40.0 nil (pz-apd:x-aux)))
(setq pz-apd:passo 9)
(setq pz-apd:mo (pz-apd:insert "PZAPD" "15" 45.0
  '(("INSERCAO" . "X1") ("INSERCAONA" . "X2") ("TAG" . "keep"))
  (pz-apd:x-modelo (pz-apd:handle pz-apd:a1))))

; --- mascaras
(setq pz-apd:passo 10)
(setq pz-apd:m1 (pz-apd:insert "PZAPD" "16" 60.0
  '(("MODELO" . "MOD1") ("FABRICANTE" . "FAB1") ("DESCRICAO" . "DESC1"))
  (pz-apd:x-mascara "MA" "MB" 11 22 "TOPO" "LAY")))
(setq pz-apd:passo 11)
(setq pz-apd:h-m1 (pz-apd:handle pz-apd:m1))
(setq pz-apd:passo 12)
(setq pz-apd:m2 (pz-apd:insert "PZAPD" "15" 65.0 pz-apd:att-vazios
  (pz-apd:x-mascara "MA" "MB" 0 0 "" "")))
(setq pz-apd:passo 13)
(setq pz-apd:m3 (pz-apd:insert "PZAPD" "15" 70.0
  '(("MODELO" . "m3") ("FABRICANTE" . "f3") ("DESCRICAO" . "d3"))
  (pz-apd:x-mascara "MA" "MB" 33 44 "T3" "L3")))
(setq pz-apd:passo 14)
(setq pz-apd:e1 (pz-apd:insert "PZAPD" "15" 75.0 nil (pz-apd:x-porta pz-apd:h-m1)))
(setq pz-apd:passo 15)
(setq pz-apd:d1 (pz-apd:texto "15" 75.0 2.0 (pz-apd:x-definicao pz-apd:h-m1)))
(setq pz-apd:passo 16)
(setq pz-apd:m4 (pz-apd:insert "PZAPD" "16" 80.0
  '(("MODELO" . "MOD4") ("FABRICANTE" . "FAB4") ("DESCRICAO" . "DESC4"))
  (pz-apd:x-mascara "XA" "XB" 5 6 "T4" "L4")))
(setq pz-apd:passo 17)
(setq pz-apd:h-m4 (pz-apd:handle pz-apd:m4))
(setq pz-apd:passo 18)
(setq pz-apd:e2 (pz-apd:insert "PZAPD" "15" 85.0 nil (pz-apd:x-porta pz-apd:h-m4)))
(setq pz-apd:passo 19)
(setq pz-apd:d2 (pz-apd:texto "15" 85.0 2.0 (pz-apd:x-definicao pz-apd:h-m4)))
(setq pz-apd:passo 20)
(setq pz-apd:e3 (pz-apd:insert "PZAPD" "15" 90.0 nil (pz-apd:x-porta "ZZZ")))

; --- dispositivo principal (rodada 216): ramo P
; promoveComplementar: PP1 (indexModelo 0, layer 16) sai e PC1 (complementar de mesmo nome, layer 15) vira principal.
(setq pz-apd:passo 21)
(setq pz-apd:pp1 (pz-apd:insert "PZAPD" "16" 100.0 nil (pz-apd:x-disp "PN" "PM" "" 1 0 0)))
(setq pz-apd:passo 22)
(setq pz-apd:pc1 (pz-apd:insert "PZAPD" "15" 105.0 nil (pz-apd:x-disp "PN" "PM" "" 1 0 -1)))
; ApagaContatosModeloDispositivo: PP2 (indexModelo 3, layer 16) leva PC2 (complementar, mesmo nome/painel) e
; MD2 (bloco de modelo com o bob PP2); PX2 (complementar de outro nome) fica.
(setq pz-apd:passo 23)
(setq pz-apd:pp2 (pz-apd:insert "PZAPD" "16" 110.0 nil (pz-apd:x-disp "QN" "QM" "" 1 3 0)))
(setq pz-apd:passo 24)
(setq pz-apd:pc2 (pz-apd:insert "PZAPD" "15" 115.0 nil (pz-apd:x-disp "QN" "QM" "" 1 0 -1)))
(setq pz-apd:passo 25)
(setq pz-apd:px2 (pz-apd:insert "PZAPD" "15" 120.0 nil (pz-apd:x-disp "XN" "XM" "" 1 0 -1)))
(setq pz-apd:passo 26)
(setq pz-apd:h-pp2 (pz-apd:handle pz-apd:pp2))
(setq pz-apd:passo 27)
; Modelo com o bob em HandleBob (campo 1) e HandleContatoAux vazio: o x-modelo põe o handle no campo errado para isto.
(setq pz-apd:md2 (pz-apd:insert "PZAPD" "15" 125.0 nil
  (list -3 (list "Modelo" (cons 1000 pz-apd:h-pp2) (cons 1071 5) (cons 1071 2) (cons 1000 "")))))

; --- o dump: uma linha por entidade de teste, com atributos e XData
(defun pz-apd:txt (v)
  (cond ((null v) "")
        ((= (type v) 'STR) v)
        ((listp v) "pt")
        (t (vl-princ-to-string v))))

(setq pz-apd:lista
  (list (cons "P1" pz-apd:p1) (cons "P2" pz-apd:p2) (cons "R1" pz-apd:r1) (cons "R2" pz-apd:r2)
        (cons "A1" pz-apd:a1) (cons "MO" pz-apd:mo) (cons "M1" pz-apd:m1) (cons "M2" pz-apd:m2)
        (cons "M3" pz-apd:m3) (cons "E1" pz-apd:e1) (cons "D1" pz-apd:d1) (cons "M4" pz-apd:m4)
        (cons "E2" pz-apd:e2) (cons "D2" pz-apd:d2) (cons "E3" pz-apd:e3)
        (cons "PP1" pz-apd:pp1) (cons "PC1" pz-apd:pc1) (cons "PP2" pz-apd:pp2) (cons "PC2" pz-apd:pc2)
        (cons "PX2" pz-apd:px2) (cons "MD2" pz-apd:md2)))

(setq pz-apd:fase 0)

; Apagada = o entget falha ou devolve nada (sem ActiveX: o vlax-ename->vla-object do AutoCAD 2020 quebrou aqui, rodada 216).
(defun pz-apd:apagada-p (e / r)
  (setq r (vl-catch-all-apply 'entget (list e)))
  (or (vl-catch-all-error-p r) (null r)))

(defun c:PZ-APD-DUMP ( / caminho f par n e d app v at ad)
  (vl-load-com)
  (setq pz-apd:fase (1+ pz-apd:fase))
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-apagar-derivados.txt")))
  (setq f (open caminho (if (= pz-apd:fase 1) "w" "a")))
  (princ (strcat "=== " (if (= pz-apd:fase 1) "ANTES" "DEPOIS") "
") f)
  (foreach par pz-apd:lista
    (setq n (car par) e (cdr par))
    (if (pz-apd:apagada-p e)
      (princ (strcat n ";APAGADO
") f)
      (progn
        (setq d (entget e '("*")))
        (princ (strcat n ";" (cdr (assoc 5 d)) ";layer=" (cdr (assoc 8 d)) "
") f)
        (if (= (cdr (assoc 0 d)) "INSERT")
          (progn
            (setq at (entnext e))
            (while (and at (= (cdr (assoc 0 (setq ad (entget at)))) "ATTRIB"))
              (princ (strcat "  ATT;" (cdr (assoc 2 ad)) "=" (cdr (assoc 1 ad)) ";vis60=" (itoa (if (assoc 60 ad) (cdr (assoc 60 ad)) 0))
                             ";invisivel=" (if (= 1 (logand 1 (cdr (assoc 70 ad)))) "1" "0") "
") f)
              (setq at (entnext at)))))
        (foreach app (cdr (assoc -3 d))
          (princ (strcat "  XD;" (car app) ";") f)
          (foreach v (cdr app)
            (princ (strcat (pz-apd:txt (cdr v)) "|") f))
          (princ "
" f)))))
  (close f)
  (princ (strcat "PZ-APD-DUMP: " caminho))
  (princ))

(princ "fixture de ApagarDerivados montada (pagina 16 com os tres ramos; vizinhas na 15)")
(princ)

; Tudo num comando so (dump, apaga, dump): depois do APAGAPAGINA o ZWCAD nao executa as linhas
; seguintes do script (o comando do plugin e assincrono em relacao ao /b).
(defun c:PZ-APD-RODA ( / r)
  (c:PZ-APD-DUMP)
  (setq r (vl-catch-all-apply 'vl-cmdf (list "_.APAGAPAGINA")))
  (c:PZ-APD-DUMP)
  (princ))
