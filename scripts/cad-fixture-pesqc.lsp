; Fixture do PESQC (frmPesquisaVeiasIndefinidas, rodada 177): o Funcional.dwg nao tem
; veia indefinida, entao monta seis interligacoes com NumVeia -1000 (e uma definida)
; em tres paginas, cobrindo os ramos do carregaTodasAsVeiasIndefinidasDoCaderno:
;
;   - 12, y=100, x=0..50   tipo 1 (5,2)          -> entra (2a da pagina 12, x maior)
;   - 12, y=100, x=-20..0  tipo 1 (1,2)          -> entra (1a da pagina 12, x menor)
;   - 12, y=10             tipo 1 (2,1)          -> entra (3a, y menor)
;   - 12A                  tipo 3 (0,4)          -> entra com o 4 no painel 1
;   - 3                    tipo 2 (0,0) -> B     -> entra com o painel 2 de B nos dois e o handle de B
;   - 3                    tipo 2 (0,2)          -> fica de fora (so o painel 2)
;   - 3                    tipo 1 (1,2) veia 4   -> fica de fora (definida)  [e o B]
;
; Esperado: 5 veias, na ordem 3 / 12 (x=-20) / 12 (x=0) / 12 (y=10) / 12A.
(setvar "CMDECHO" 0)
(regapp "INTERLIGACAO")
(foreach l '("12" "12A" "3") (command "_.LAYER" "_M" l ""))

(defun pz-pesqc:xdata (tipo numVeia painel1 painel2 handle)
  (list -3
    (list "INTERLIGACAO"
      (cons 1070 tipo) (cons 1000 "") (cons 1070 numVeia) (cons 1000 "")
      (cons 1070 painel1) (cons 1070 0) (cons 1070 painel2) (cons 1070 0)
      (cons 1000 handle) (cons 1000 "") (cons 1000 "") (cons 1070 0)
      (cons 1070 0) (cons 1000 "ana") (cons 1000 "2026-10-15") (cons 1071 1)
      (cons 1040 0.0) (cons 1000 ""))))

(defun pz-pesqc:linha (layer x1 y1 x2 y2 tipo numVeia painel1 painel2 handle / e)
  (setvar "CLAYER" layer)
  (command "_.PLINE" (list x1 y1) (list x2 y2) "")
  (setq e (entlast))
  (entmod (append (entget e) (list (pz-pesqc:xdata tipo numVeia painel1 painel2 handle))))
  (cdr (assoc 5 (entget e))))

(setq pz-pesqc:b (pz-pesqc:linha "3" 900000 0 900010 0 1 4 1 2 ""))
(pz-pesqc:linha "12" 900000 100 900050 100 1 -1000 5 2 "")
(pz-pesqc:linha "12" 899980 100 900000 100 1 -1000 1 2 "")
(pz-pesqc:linha "12" 900000 10 900050 10 1 -1000 2 1 "")
(pz-pesqc:linha "12A" 900000 0 900010 0 3 -1000 0 4 "")
(setq pz-pesqc:a (pz-pesqc:linha "3" 900000 50 900010 50 2 -1000 0 0 pz-pesqc:b))
(pz-pesqc:linha "3" 900000 60 900010 60 2 -1000 0 2 "")
(setvar "CLAYER" "0")
(princ (strcat "\nPESQC-FIXTURE;A=" pz-pesqc:a ";B=" pz-pesqc:b))
(princ)
