; Fixture do CorrigeModelosDeContatos (ver docs/RUNBOOK.md, rodada 86): monta um
; CONTATOS sintetico com UM modelo (53) cujos dois contatos estao FORA da posicao
; (indices 7 e 9) e um bloco auxiliar (Dispositivo tipo A) que aponta o contato 7 —
; o comando deve renumerar o dicionario (7->1, 9->2) e gravar o 1 no XData do bloco.
;
; O dump (definido ANTES do desenho) mostra o tipo e o par IndexModelo/IndexContato.
(setvar "CMDECHO" 0)
(regapp "Dispositivo")

(defun pz-mc:escreve (f s) (princ s f))

(defun pz-mc:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-mc:xdata (e app / d r)
  (setq d (entget e (list app)))
  (setq r (car (cdr (assoc -3 d))))
  (if r (mapcar (quote cdr) (cdr r)) nil))

(defun pz-mc:conta ( / caminho f sel i e d disp n)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-modelos-contatos.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-modelos-contatos: falha ao abrir a saida")
    (progn
      (pz-mc:escreve f "BLOCO;tipo;indexModelo;indexContato\n")
      (setq n 0)
      (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq disp (pz-mc:xdata e "Dispositivo"))
            (if disp
              (progn
                (setq n (1+ n))
                (pz-mc:escreve f (strcat "BLOCO;" (pz-mc:texto (nth 0 disp)) ";"
                                         (pz-mc:texto (nth 4 disp)) ";"
                                         (pz-mc:texto (nth 5 disp)) "\n")))))))
      (pz-mc:escreve f (strcat "TOTAL;blocos;" (itoa n) "\n"))
      (close f)
      (princ (strcat "cad-fixture-modelos-contatos: " (itoa n) " bloco(s)")))))

; ── O desenho ──────────────────────────────────────────────────────────────
; 25 valores depois do app name: tipo, Nome1, Nome2, HandleBob, IndexModelo,
; IndexContato, TipoDoContato, TipoDoComportamento, ... ate a Data (o array do
; `LeXDataQualquerDispositivo`: 5 = IndexModelo, 6 = IndexContato).
(defun pz-mc:disp (tipo indiceModelo indiceContato)
  (list -3
    (list "Dispositivo"
      (cons 1000 tipo) (cons 1000 "") (cons 1000 "") (cons 1000 "1A2B")
      (cons 1070 indiceModelo) (cons 1070 indiceContato)
      (cons 1070 0) (cons 1070 0) (cons 1000 "") (cons 1000 "") (cons 1000 "")
      (cons 1000 "") (cons 1070 0) (cons 1070 0) (cons 1070 0)
      (cons 1000 "ana") (cons 1000 "2026-09-23")
      (cons 1070 0) (cons 1070 0) (cons 1070 0) (cons 1040 0.0)
      (cons 1000 "") (cons 1000 "") (cons 1071 0) (cons 1000 ""))))

(defun pz-mc:xrec (valores)
  (entmakex (append (list (quote (0 . "XRECORD")) (quote (100 . "AcDbXrecord")) (quote (280 . 1)))
                    valores)))

; O modelo 53 (10 valores por registro) e os contatos com indice 7 e 9.
(defun pz-mc:contatos ( / dic)
  (setq dic (entmakex (quote ((0 . "DICTIONARY") (100 . "AcDbDictionary")))))
  (dictadd (namedobjdict) "CONTATOS" dic)
  (dictadd dic "MODELOS2"
    (pz-mc:xrec (list (cons 90 1) (cons 90 53) (cons 1 "M53") (cons 90 1) (cons 90 2) (cons 90 0)
                      (cons 1 "BLOCO") (cons 1 "LAYOUT") (cons 1 "H") (cons 1 "") (cons 1 ""))))
  (dictadd dic "53"
    (pz-mc:xrec (list (cons 90 2)
                      (cons 90 7) (cons 1 "T1A") (cons 1 "T2A") (cons 1 "T3A") (cons 90 1) (cons 1 "CP") (cons 1 "") (cons 1 "")
                      (cons 90 9) (cons 1 "T1B") (cons 1 "T2B") (cons 1 "T3B") (cons 90 2) (cons 1 "CP") (cons 1 "") (cons 1 "")))))

(pz-mc:contatos)

; O bloco (vazio) e o INSERT com o XData Dispositivo tipo A apontando (53, 7).
(entmake (quote ((0 . "BLOCK") (8 . "0") (2 . "BT4XNAY") (70 . 0) (10 0.0 0.0 0.0))))
(entmake (quote ((0 . "ENDBLK") (8 . "0"))))
(entmake (list (quote (0 . "INSERT")) (quote (8 . "0")) (quote (2 . "BT4XNAY"))
               (list 10 0.0 0.0 0.0) (cons 41 1.0) (cons 42 1.0) (cons 43 1.0) (cons 50 0.0)))
(setq pz-mc:bloco (entlast))
(entmod (append (entget pz-mc:bloco) (list (pz-mc:disp "A" 53 7))))

(princ "fixture de modelos de contatos montada: rode (pz-mc:conta)")
(princ)