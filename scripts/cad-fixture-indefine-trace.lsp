; Fixture do IndefineUmaPorta (ver docs/RUNBOOK.md, rodada 101): monta o dicionario
; MASCARAS com o modelo 9 e a porta 3, e um bloco de porta (Dispositivo tipo E) apontando
; o modelo 9 e a porta 5 — que NAO esta no dicionario. O comando deve indefinir a porta:
; zerar o indiceDaPorta/handleDaDefinicao/chavePrimaria no XData e limpar os atributos
; (NOME1/PAINEL vazios, T1 com o caracter indefinido, EFC vazio).
(setvar "CMDECHO" 0)
(regapp "Dispositivo")

(defun pz-ip:escreve (f s) (princ s f))

(defun pz-ip:marca (s / tf)
  (setq tf (open (strcat (getenv "TEMP") "/positron-ip-trace.txt") "a"))
  (if tf (progn (princ (strcat s "\n") tf) (close tf))))

(pz-ip:marca "0 load")

(defun pz-ip:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-ip:vals (e / d r)
  (setq d (entget e (list "Dispositivo")))
  (setq r (car (cdr (assoc -3 d))))
  (if r (mapcar (quote cdr) (cdr r)) nil))

(defun pz-ip:atrib (bloco tag / e d achou)
  (setq achou "")
  (setq e (entnext bloco))
  (while (and e (= (cdr (assoc 0 (entget e))) "ATTRIB"))
    (setq d (entget e))
    (if (= (strcase (pz-ip:texto (cdr (assoc 2 d)))) (strcase tag))
      (setq achou (pz-ip:texto (cdr (assoc 1 d)))))
    (setq e (entnext e)))
  achou)

(defun pz-ip:conta ( / caminho f sel i e d v n)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-indefine.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-indefine-porta: falha ao abrir a saida")
    (progn
      (pz-ip:escreve f "PORTA;tipo;indiceModelo;indiceDaPorta;handleDefinicao;NOME1;T1;PAINEL;EFC\n")
      (setq n 0)
      (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq v (pz-ip:vals e))
            (if (and v (= (pz-ip:texto (nth 0 v)) "E"))
              (progn
                (setq n (1+ n))
                (pz-ip:escreve f (strcat "PORTA;" (pz-ip:texto (nth 0 v)) ";"
                                         (pz-ip:texto (nth 4 v)) ";" (pz-ip:texto (nth 5 v)) ";"
                                         (pz-ip:texto (nth 8 v)) ";"
                                         (pz-ip:atrib e "NOME1") ";" (pz-ip:atrib e "T1") ";"
                                         (pz-ip:atrib e "PAINEL") ";" (pz-ip:atrib e "EFC") "\n"))))))
      (pz-ip:escreve f (strcat "TOTAL;portas;" (itoa n) "\n"))
      (close f)
      (princ (strcat "cad-fixture-indefine-porta: " (itoa n) " porta(s)")))))

; ── O desenho ──────────────────────────────────────────────────────────────
; O dicionario MASCARAS: modelo 9 com UMA porta (indice 3).
(defun pz-ip:xrec (valores)
  (entmakex (append (list (quote (0 . "XRECORD")) (quote (100 . "AcDbXrecord")) (quote (280 . 1))) valores)))

(pz-ip:marca "1 antes do mascaras")
(defun pz-ip:mascaras ( / dic)
  (setq dic (entmakex (quote ((0 . "DICTIONARY") (100 . "AcDbDictionary")))))
  (dictadd (namedobjdict) "MASCARAS" dic)
  (dictadd dic "MODELOS2"
    (pz-ip:xrec (list (cons 90 1) (cons 90 9) (cons 1 "M9") (cons 90 1) (cons 90 2) (cons 90 0)
                      (cons 1 "BLOCO") (cons 1 "LAYOUT") (cons 1 "H") (cons 1 "") (cons 1 ""))))
  (dictadd dic "9"
    (pz-ip:xrec (list (cons 90 1)
                      (cons 90 3) (cons 1 "H") (cons 1 "EFC3") (cons 1 "T1X") (cons 1 "B1X")
                      (cons 1 "") (cons 1 "R1") (cons 1 ""))))))

(pz-ip:mascaras)

(pz-ip:marca "2 mascaras ok")

; O bloco da porta: quatro ATTDEFs soltos, o bloco pela `_.-BLOCK` e o INSERT com valores.
(defun pz-ip:attdef (tag valor)
  (entmakex (list (quote (0 . "ATTDEF")) (cons 8 "0") (list 10 0.0 0.0 0.0) (cons 40 2.5)
                  (cons 1 valor) (cons 2 tag) (cons 3 "") (cons 70 0))))

(pz-ip:marca "3 antes dos attdefs")
(setq pz-ip:a1 (pz-ip:attdef "NOME1" "NOME-ANTIGO"))
(setq pz-ip:a2 (pz-ip:attdef "T1" "7"))
(setq pz-ip:a3 (pz-ip:attdef "PAINEL" "PT1"))
(setq pz-ip:a4 (pz-ip:attdef "EFC" "EFC-ANTIGO"))
(pz-ip:marca "4 attdefs ok")
(command "_.-BLOCK" "BTEPORT" (list 0.0 0.0) pz-ip:a1 pz-ip:a2 pz-ip:a3 pz-ip:a4 "")
(pz-ip:marca "5 bloco ok")
(command "_.INSERT" "BTEPORT" (list 10.0 0.0) 1.0 1.0 0.0 "NOME-ANTIGO" "7" "PT1" "EFC-ANTIGO")

; O XData Dispositivo tipo E do INSERT: modelo 9, porta 5 (a que NAO existe no dicionario).
(pz-ip:marca "6 insert ok")
(setq pz-ip:sel (ssget "_X" (list (cons 0 "INSERT"))))
(setq pz-ip:ins (ssname pz-ip:sel 0))
(entmod (append (entget pz-ip:ins)
  (list (list -3
    (list "Dispositivo"
      (cons 1000 "E") (cons 1000 "") (cons 1000 "") (cons 1000 "")
      (cons 1070 9) (cons 1070 5) (cons 1070 0) (cons 1070 0)
      (cons 1000 "") (cons 1000 "1A2B") (cons 1000 "CHAVE")
      (cons 1000 "") (cons 1070 0) (cons 1070 0) (cons 1070 0)
      (cons 1000 "ana") (cons 1000 "2026-09-23")
      (cons 1070 0) (cons 1070 0) (cons 1070 0) (cons 1040 0.0)
      (cons 1000 "") (cons 1000 "") (cons 1071 0) (cons 1000 ""))))))

(pz-ip:marca "7 fim")
(princ "fixture do indefine montada: rode (pz-ip:conta)")
(princ)