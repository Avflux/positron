; Fixture do corrigeDicMascaras (ver docs/RUNBOOK.md, rodada 76): monta o dicionario
; MASCARAS com UM modelo cujo registro de portas tem os tres defeitos que a
; correcao conserta:
;
;   - porta 3 repetida (o dedup fica com a PRIMEIRA: terminais T3, nao T3BIS);
;   - fora de ordem (3, 1, 3 -> 1, 3);
;   - cabecalho MaxIndice = 0 (o original o recalcula para 3).
;
; Esperado: 1 de 1 modelo normalizado (1 duplicada; 3 lidas) e, na segunda passada,
; 0 de 1 (2 lidas, 0 duplicadas) - a convergencia. O dump mostra o registro depois.
(setvar "CMDECHO" 0)

(defun pz-masc:xrecord (valores)
  (entmakex (append (list '(0 . "XRECORD") '(100 . "AcDbXrecord") '(280 . 1)) valores)))

; Um modelo no MODELOS2: 10 valores por registro a partir do indice 1 (o valor 0 e a
; contagem).
(defun pz-masc:modelo (indice nome)
  (list (cons 90 indice) (cons 1 nome) (cons 90 1) (cons 90 2) (cons 90 0)
        (cons 1 "BLOCO") (cons 1 "LAYOUT") (cons 1 "H") (cons 1 "") (cons 1 "")))

; Uma porta: 8 valores (indice, orientacao, EFC, terminais, bornes, vazio, regua, vazio).
(defun pz-masc:porta (indice orientacao terminais regua)
  (list (cons 90 indice) (cons 1 orientacao) (cons 1 "") (cons 1 terminais)
        (cons 1 "B") (cons 1 "") (cons 1 regua) (cons 1 "")))

(defun pz-masc:dicionario ( / dic)
  (setq dic (entmakex '((0 . "DICTIONARY") (100 . "AcDbDictionary"))))
  (dictadd (namedobjdict) "MASCARAS" dic)
  (dictadd dic "MODELOS2"
    (pz-masc:xrecord (append (list (cons 90 1)) (pz-masc:modelo 900 "M900"))))
  (dictadd dic "900"
    (pz-masc:xrecord
      (append
        (list (cons 90 0))
        (pz-masc:porta 3 "h" "T3" "R3")
        (pz-masc:porta 1 "v" "T1" "R1")
        (pz-masc:porta 3 "x" "T3BIS" "R3BIS")))))

(pz-masc:dicionario)

(defun pz-masc:escreve (f s) (princ s f))

(defun pz-masc:texto (v)
  (if (null v)
    ""
    (if (= (type v) 'STR) v (vl-princ-to-string v))))

; Os valores de um XRECORD saem no `entget` DEPOIS do grupo 280 (verificado no ZWCAD
; 2026): o primeiro e o cabecalho MaxIndice e cada porta ocupa 8 valores.
(defun pz-masc:valores (d)
  (mapcar 'cdr (cdr (member (assoc 280 d) d))))

(defun pz-masc:dump ( / caminho f d item r vals cab i inds terms)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-mascaras.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-mascaras: falha ao abrir a saida")
    (progn
      (pz-masc:escreve f "MODELO;header;portas;terminais\n")
      (setq d (dictsearch (namedobjdict) "MASCARAS"))
      (if (null d)
        (pz-masc:escreve f "SEM MASCARAS\n")
        (foreach item d
          (if (and (= (car item) 3) (/= (cdr item) "MODELOS2"))
            (progn
              (setq r (dictsearch (cdr (assoc -1 d)) (cdr item)))
              (if r
                (progn
                  (setq vals (pz-masc:valores (entget (cdr (assoc -1 r)))))
                  (setq cab (nth 0 vals) i 1 inds "" terms "")
                  (while (< i (length vals))
                    (setq inds (strcat inds (if (= inds "") "" ",") (pz-masc:texto (nth i vals))))
                    (setq terms (strcat terms (if (= terms "") "" ",") (pz-masc:texto (nth (+ i 3) vals))))
                    (setq i (+ i 8)))
                  (pz-masc:escreve f (strcat "MODELO;" (cdr item) ";" (pz-masc:texto cab)
                                            ";" inds ";" terms "\n"))))))))
      (close f)
      (princ (strcat "cad-fixture-mascaras: escrito em " caminho)))))

(princ "fixture de mascaras montada (modelo 900 com porta 3 duplicada e fora de ordem)")
(princ)