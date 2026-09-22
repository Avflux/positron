; Fixture da acao INDCABO (IndefineCabosNaoExistentes) do recoder: monta duas
; interligacoes, uma com cabo que ESTA no catalogo e outra com cabo FANTASMA, mais
; um rotulo auxiliar (AUXINTERLIG tipo 1) preso a ponta. Roda com o catalogo
; semeado com CABO-OK (ver docs/RUNBOOK.md); sem ele a acao nao faz nada.
(setvar "CMDECHO" 0)
(regapp "INTERLIGACAO")
(regapp "AUXINTERLIG")
(command "_.LAYER" "_M" "12" "")

(defun pz-xdata-interligacao (tipo tag numVeia nomeVeia painel1 painel2)
  (list -3
    (list "INTERLIGACAO"
      (cons 1070 tipo) (cons 1000 tag) (cons 1070 numVeia) (cons 1000 nomeVeia)
      (cons 1070 painel1) (cons 1070 0) (cons 1070 painel2) (cons 1070 0)
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1070 0)
      (cons 1070 0) (cons 1000 "ana") (cons 1000 "2026-10-09") (cons 1071 1)
      (cons 1040 0.0) (cons 1000 ""))))

(defun pz-xdata-aux (tipo handle thandle)
  (list -3
    (list "AUXINTERLIG"
      (cons 1070 tipo) (cons 1000 handle) (cons 1000 thandle)
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1000 ""))))

(defun pz-interligacao (x1 y1 x2 y2 tipo tag numVeia nomeVeia painel1 painel2 / e)
  (command "_.PLINE" (list x1 y1) (list x2 y2) "")
  (setq e (entlast))
  (entmod (append (entget e) (list (pz-xdata-interligacao tipo tag numVeia nomeVeia painel1 painel2)))))

(defun pz-rotulo (x y txt tipo handle thandle / e)
  (command "_.TEXT" (list x y) 2.5 0 txt)
  (setq e (entlast))
  (entmod (append (entget e) (list (pz-xdata-aux tipo handle thandle)))))

; CABO-OK existe no catalogo semeado -> fica intacto.
(pz-interligacao 0.0 10.0 10.0 10.0 1 "CABO-OK" 1 "V1" 1 2)
; CABO-FANTASMA nao existe -> a INDCABO limpa o cabo e a veia.
(pz-interligacao 0.0 20.0 10.0 20.0 1 "CABO-FANTASMA" 2 "V2" 1 2)
; Rotulo auxiliar do cabo (tipo 1) -> vira o caracter de terminal indefinido.
(pz-rotulo 0.0 25.0 "CABO-FANTASMA" 1 "H1" "H2")
(princ "fixture INDCABO montada")
(princ)
