; Fixture do LimpaTextosLPCopiados (ver docs/RUNBOOK.md, rodada 83): uma conexao tipo 1
; (que define o topo do desenho em y=10) e quatro textos — dois MText e dois TEXT —
; com e sem o XData TextoLP, acima e abaixo do topo.
;
; AS DEFINICOES VEM ANTES do desenho: se alguma linha do setup estourar, o dump ainda
; existe e o arquivo sai (licao das rodadas 77/81/83).
;
; Esperado: "2 de 3 texto(s) com XData TextoLP limpo(s) (topo do desenho 10)": o MText
; abaixo sai, o MText acima FICA (a regra do original), o TEXT acima sai e o TEXT sem o
; XData nao e tocado. O dump mostra os quatro com o tamanho do XData TextoLP (1 = so a
; marca, ou seja limpo).
(setvar "CMDECHO" 0)
(regapp "CONEXAO")
(regapp "TextoLP")
(command "_.LAYER" "_M" "12" "")

(defun pz-lp:escreve (f s) (princ s f))

(defun pz-lp:texto-de (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-lp:conexao (x1 y1 x2 y2 / e)
  (command "_.PLINE" (list x1 y1) (list x2 y2) "")
  (setq e (entlast))
  (entmod (append (entget e)
    (list (list -3
      (list "CONEXAO"
        (cons 1070 1) (cons 1071 5) (cons 1000 "") (cons 1070 1)
        (cons 1070 0) (cons 1070 0) (cons 1000 "C1") (cons 1000 "")
        (cons 1000 "") (cons 1000 "2,5") (cons 1000 "AZ") (cons 1000 "")
        (cons 1040 0.0) (cons 1070 -1) (cons 1070 0) (cons 1000 "")
        (cons 1000 "") (cons 1071 0) (cons 1071 0) (cons 1000 "ana")
        (cons 1000 "2026-09-23") (cons 1071 0) (cons 1040 0.0) (cons 1000 "")))))))

(defun pz-lp:mtexto (x y txt)
  (entmakex (list (cons 0 "MTEXT") (cons 100 "AcDbEntity") (cons 8 "0")
                  (cons 100 "AcDbMText") (list 10 x y 0.0) (cons 40 2.5) (cons 1 txt))))

(defun pz-lp:texto (x y txt)
  (command "_.TEXT" (list x y) 2.5 0 txt)
  (entlast))

(defun pz-lp:marca (e)
  (if e (entmod (append (entget e) (list (list -3 (list "TextoLP" (cons 1000 "LP")))))))
  e)

(defun pz-lp:dump ( / caminho f sel i e d app vals)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-textolp.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-textolp: falha ao abrir a saida")
    (progn
      (pz-lp:escreve f "TEXTO;tipo;y;textolp\n")
      (setq sel (ssget "_X" (list (cons 0 "MTEXT,TEXT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e (list "TextoLP")))
            (setq vals "")
            (foreach app (cdr (assoc -3 d))
              (if (= (car app) "TextoLP")
                (setq vals (itoa (length (cdr app))))))
            (pz-lp:escreve f (strcat "TEXTO;" (pz-lp:texto-de (cdr (assoc 0 d))) ";"
                                     (pz-lp:texto-de (cdr (assoc 10 d))) ";" vals "\n")))))
      (close f)
      (princ (strcat "cad-fixture-textolp: escrito em " caminho)))))

; ── O desenho ──────────────────────────────────────────────────────────────
; O topo: a conexao tipo 1 vai de y=0 a y=10.
(pz-lp:conexao 0.0 0.0 10.0 10.0)
; MText abaixo do topo: sai.
(pz-lp:marca (pz-lp:mtexto 0.0 5.0 "M-ABAIXO"))
; MText acima do topo: FICA.
(pz-lp:marca (pz-lp:mtexto 0.0 20.0 "M-ACIMA"))
; TEXT acima do topo: sai (o DBText nao olha o Y).
(pz-lp:marca (pz-lp:texto 0.0 30.0 "T-ACIMA"))
; TEXT sem o XData: nao e tocado.
(pz-lp:texto 0.0 40.0 "T-SEM-XDATA")

(princ "fixture de textos LP montada")
(princ)