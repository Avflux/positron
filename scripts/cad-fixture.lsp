; Fixture do E2E do recoder: monta um desenho funcional minimo com XData
; CONEXAO e INTERLIGACAO, para o FIA/INT projetarem de verdade dentro do ZWCAD
; (ver docs/RUNBOOK.md). Roda via `npm run cad:e2e`, sem tela.
(setvar "CMDECHO" 0)
(regapp "CONEXAO")
(regapp "INTERLIGACAO")
(command "_.LAYER" "_M" "12" "")

(defun pz-xdata-conexao (tipo potencial nome secao cor disp1 disp2)
  (list -3
    (list "CONEXAO"
      (cons 1070 tipo) (cons 1071 potencial) (cons 1000 "") (cons 1070 1)
      (cons 1070 0) (cons 1070 0) (cons 1000 nome) (cons 1000 "")
      (cons 1000 "") (cons 1000 secao) (cons 1000 cor) (cons 1000 "")
      (cons 1040 0.0) (cons 1070 disp1) (cons 1070 disp2) (cons 1000 "")
      (cons 1000 "") (cons 1071 0) (cons 1071 0) (cons 1000 "ana")
      (cons 1000 "2026-10-09") (cons 1071 0) (cons 1040 0.0) (cons 1000 ""))))

(defun pz-xdata-interligacao (tipo tag numVeia nomeVeia painel1 painel2)
  (list -3
    (list "INTERLIGACAO"
      (cons 1070 tipo) (cons 1000 tag) (cons 1070 numVeia) (cons 1000 nomeVeia)
      (cons 1070 painel1) (cons 1070 0) (cons 1070 painel2) (cons 1070 0)
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1070 0)
      (cons 1070 0) (cons 1000 "ana") (cons 1000 "2026-10-09") (cons 1071 1)
      (cons 1040 0.0) (cons 1000 ""))))

(defun pz-conexao (x1 y1 x2 y2 tipo potencial nome secao cor disp1 disp2 / e)
  (command "_.PLINE" (list x1 y1) (list x2 y2) "")
  (setq e (entlast))
  (entmod (append (entget e) (list (pz-xdata-conexao tipo potencial nome secao cor disp1 disp2)))))

(defun pz-interligacao (x1 y1 x2 y2 tipo tag numVeia nomeVeia painel1 painel2 / e)
  (command "_.PLINE" (list x1 y1) (list x2 y2) "")
  (setq e (entlast))
  (entmod (append (entget e) (list (pz-xdata-interligacao tipo tag numVeia nomeVeia painel1 painel2)))))

; Duas conexoes (Fiacao + Circuitos4F) e uma interligacao (Interligacao4).
; C1: tipo 1 com Disp1 -> ponto no PRIMEIRO vertice (0,0).
; C2: tipo 1 com Disp2 -> ponto no ULTIMO vertice (10,5).
(pz-conexao 0.0 0.0 10.0 0.0 1 5 "C1" "2,5" "AZ" -1 0)
(pz-conexao 0.0 5.0 10.0 5.0 1 7 "C2" "4" "PT" 0 -1)
(pz-interligacao 0.0 10.0 10.0 10.0 1 "CABO1" 1 "V1" 1 2)
(princ "fixture montada")
(princ)
