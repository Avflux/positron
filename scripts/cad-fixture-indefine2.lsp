; Fixture do IndefineUmaPorta (ver docs/RUNBOOK.md, rodada 102): o dicionario MASCARAS com o
; modelo 9 e a porta 3, e um bloco de porta (Dispositivo tipo E) apontando o modelo 9 e a
; porta 5 — que NAO existe. O comando deve indefinir a porta.
;
; Versao enxuta: sem funcoes auxiliares, so `v` e `vz` (duas globais com os valores crus).
(setvar "CMDECHO" 0)
(regapp "Dispositivo")

(defun pz-ip2:escreve (f s) (princ s f))

(defun pz-ip2:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

; ── O dicionario ───────────────────────────────────────────────────────────
(defun pz-ip2:dict ( / dic)
  (setq dic (entmakex (quote ((0 . "DICTIONARY") (100 . "AcDbDictionary")))))
  (dictadd (namedobjdict) "MASCARAS" dic)
  (dictadd dic "MODELOS2"
    (entmakex (append (quote ((0 . "XRECORD") (100 . "AcDbXrecord") (280 . 1)))
              (list (cons 90 1) (cons 90 9) (cons 1 "M9") (cons 90 1) (cons 90 2) (cons 90 0)
                    (cons 1 "BLOCO") (cons 1 "LAYOUT") (cons 1 "H") (cons 1 "") (cons 1 "")))))
  (dictadd dic "9"
    (entmakex (append (quote ((0 . "XRECORD") (100 . "AcDbXrecord") (280 . 1)))
              (list (cons 90 1) (cons 90 3) (cons 1 "H") (cons 1 "EFC3") (cons 1 "T1X")
                    (cons 1 "B1X") (cons 1 "") (cons 1 "R1") (cons 1 ""))))))

pz-ip2:dict-placeholder
(defun pz-ip2:attdef (tag valor)
  (entmakex (list (quote (0 . "ATTDEF")) (cons 8 "0") (list 10 0.0 0.0 0.0) (cons 40 2.5)
                  (cons 1 valor) (cons 2 tag) (cons 3 "") (cons 70 0))))

(defun pz-ip2:dump ( / caminho f sel i e d v n)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-indefine.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-indefine: falha ao abrir a saida")
    (progn
      (pz-ip2:escreve f "PORTA;tipo;indiceModelo;indiceDaPorta;NOME1;T1;PAINEL;EFC\n")
      (setq n 0)
      (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e (list "Dispositivo")))
            (setq v (mapcar (quote cdr) (cdr (car (cdr (assoc -3 d))))))
            (if (and v (= (pz-ip2:texto (nth 0 v)) "E"))
              (progn
                (setq n (1+ n))
                (setq vz nil)
                (setq b (entnext e))
                (while (and b (= (cdr (assoc 0 (entget b))) "ATTRIB"))
                  (setq vz (cons (cons (strcase (pz-ip2:texto (cdr (assoc 2 (entget b)))))
                                       (pz-ip2:texto (cdr (assoc 1 (entget b))))) vz))
                  (setq b (entnext b)))
                (pz-ip2:escreve f (strcat "PORTA;E;" (pz-ip2:texto (nth 4 v)) ";"
                                         (pz-ip2:texto (nth 5 v)) ";"
                                         (pz-ip2:texto (cdr (assoc "NOME1" vz))) ";"
                                         (pz-ip2:texto (cdr (assoc "T1" vz))) ";"
                                         (pz-ip2:texto (cdr (assoc "PAINEL" vz))) ";"
                                         (pz-ip2:texto (cdr (assoc "EFC" vz))) "\n"))))))
      (pz-ip2:escreve f (strcat "TOTAL;portas;" (itoa n) "\n"))
      (close f)
      (princ "cad-fixture-indefine: ok"))))

; ── O desenho (depois das definicoes) ─────────────────────────────────────
(pz-ip2:dict)
(setq pz-ip2:bloco nil)
(pz-ip2:attdef "NOME1" "NOME-ANTIGO")
(pz-ip2:attdef "T1" "7")
(pz-ip2:attdef "PAINEL" "PT1")
(pz-ip2:attdef "EFC" "EFC-ANTIGO")

; ── Fim (o dump roda no load) ─────────────────────────────────────────────
(pz-ip2:dump)
(princ)