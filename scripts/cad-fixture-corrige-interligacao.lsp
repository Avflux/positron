; Fixture do comando CorrigeInterligacao: monta oito trechos de interligacao com
; painel errado (ou ja certo) e os dispositivos IMPORTADOS sobre as pontas, para o
; comando redescobrir o painel pelo desenho. Roda com o instrumento independente
; scripts/cad-conta-interligacao.lsp (POSITRON_CONTA) e o dump em POSITRON_DUMP:
;
;   trecho  y    tipo  numVeia  painel1 painel2  ponta 1        ponta 2        esperado
;   A       10   1     -1000    1       2        IMPORTADO 503  IMPORTADO 9    corrige (503, 9)
;   B       20   1     -1000    9       503      IMPORTADO 503  IMPORTADO 9    ja e o par (outra ordem)
;   C       30   2     -1000    0       77       IMPORTADO 9    -              corrige Painel2 = 9
;   D       40   3     -1000    0       77       -              IMPORTADO 9    usa a ponta 2
;   E       50   1     1        1       2        IMPORTADO 503  IMPORTADO 9    cabo definido: nao entra
;   F       60   1     -1000    5       7        -              -              sem dispositivo: pula
;   G       70   1     -1000    5       7        o.c. 99 (9)    o.c. 99 (9)    camada errada: pula
;   H       80   1     -1000    5       7        P (painel 9)   IMPORTADO 9    o P quebra a busca: pula
(setvar "CMDECHO" 0)
(regapp "INTERLIGACAO")
(regapp "IMPORTADO")
(regapp "DISPOSITIVO")
(command "_.LAYER" "_M" "12" "")
(command "_.LAYER" "_M" "99" "")
; o _M deixa a camada corrente: volta para a "12" ANTES de desenhar, senao as
; polylines (que o comando filtra pela propria camada) nasceriam na "99".
(command "_.LAYER" "_S" "12" "")

(defun pz-xdata-interligacao (tipo tag numVeia nomeVeia painel1 painel2)
  (list -3
    (list "INTERLIGACAO"
      (cons 1070 tipo) (cons 1000 tag) (cons 1070 numVeia) (cons 1000 nomeVeia)
      (cons 1070 painel1) (cons 1070 0) (cons 1070 painel2) (cons 1070 0)
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1070 0)
      (cons 1070 0) (cons 1000 "ana") (cons 1000 "2026-10-12") (cons 1071 1)
      (cons 1040 0.0) (cons 1000 ""))))

; O dispositivo IMPORTADO: o array[3] e o tipo importado (B) e o array[9] o painel
; — e o ramo mais curto do verificaDispInterlig (nao exige atributo nem dicionario).
(defun pz-xdata-importado (painel)
  (list -3
    (list "IMPORTADO"
      (cons 1000 "X") (cons 1000 "N1") (cons 1000 "B")
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1000 "")
      (cons 1070 painel))))

; O dispositivo P (modelo): o original PARA a busca daquela ponta nele (o ramo que
; quebra), entao ele e o caso do trecho H.
(defun pz-xdata-dispositivo-p (painel)
  (list -3
    (list "DISPOSITIVO"
      (cons 1000 "P") (cons 1000 "N1") (cons 1000 "N2") (cons 1000 "ALT")
      (cons 1070 0) (cons 1070 0) (cons 1070 0) (cons 1070 painel)
      (cons 1070 0) (cons 1070 0) (cons 1070 0) (cons 1070 0)
      (cons 1070 0) (cons 1070 0))))

(defun pz-bloco (nome layer x y xdata / e)
  (if (not (tblsearch "BLOCK" nome))
    (progn
      (entmake (list (cons 0 "BLOCK") (cons 2 nome) (cons 70 0) (cons 10 (list 0.0 0.0 0.0))))
      (entmake (list (cons 0 "CIRCLE") (cons 8 "0") (cons 10 (list 0.0 0.0 0.0)) (cons 40 0.1)))
      (entmake (list (cons 0 "ENDBLK")))))
  (entmake (list (cons 0 "INSERT") (cons 2 nome) (cons 8 layer) (cons 10 (list x y 0.0))))
  (setq e (entlast))
  (entmod (append (entget e) (list xdata)))
  e)

(defun pz-interligacao (x1 y1 x2 y2 tipo tag numVeia painel1 painel2 / e)
  (command "_.PLINE" (list x1 y1) (list x2 y2) "")
  (setq e (entlast))
  (entmod (append (entget e) (list (pz-xdata-interligacao tipo tag numVeia "" painel1 painel2)))))

(defun pz-importado (layer x y painel)
  (pz-bloco "PZ-IMPORTADO" layer x y (pz-xdata-importado painel)))

; A: par errado nas duas pontas -> corrige para (503, 9).
(pz-interligacao 0.0 10.0 10.0 10.0 1 "" -1000 1 2)
(pz-importado "12" 0.0 10.0 503)
(pz-importado "12" 10.0 10.0 9)
; B: o par certo, na ordem trocada -> nao regrava.
(pz-interligacao 0.0 20.0 10.0 20.0 1 "" -1000 9 503)
(pz-importado "12" 0.0 20.0 503)
(pz-importado "12" 10.0 20.0 9)
; C: tipo 2 com Painel1 zerado -> grava o achado no Painel2.
(pz-interligacao 0.0 30.0 10.0 30.0 2 "" -1000 0 77)
(pz-importado "12" 0.0 30.0 9)
; D: tipo 3 sem dispositivo na ponta 1 -> usa a ponta 2.
(pz-interligacao 0.0 40.0 10.0 40.0 3 "" -1000 0 77)
(pz-importado "12" 10.0 40.0 9)
; E: cabo definido -> fora do comando.
(pz-interligacao 0.0 50.0 10.0 50.0 1 "CABO-OK" 1 1 2)
(pz-importado "12" 0.0 50.0 503)
(pz-importado "12" 10.0 50.0 9)
; F: sem dispositivo nenhum -> pula (o original gravaria 0).
(pz-interligacao 0.0 60.0 10.0 60.0 1 "" -1000 5 7)
; G: dispositivos em outra camada -> o filtro de pagina do original os recusa.
(pz-interligacao 0.0 70.0 10.0 70.0 1 "" -1000 5 7)
(pz-importado "99" 0.0 70.0 9)
(pz-importado "99" 10.0 70.0 9)
; H: um dispositivo P na ponta 1 quebra a busca daquela ponta (o ramo do original).
(pz-interligacao 0.0 80.0 10.0 80.0 1 "" -1000 5 7)
(pz-bloco "PZ-DISPOSITIVO-P" "12" 0.0 80.0 (pz-xdata-dispositivo-p 9))
(pz-importado "12" 10.0 80.0 9)

(if (getenv "POSITRON_CONTA") (load (getenv "POSITRON_CONTA")))
(princ "\nfixture CorrigeInterligacao montada (8 trechos)")
(princ)
