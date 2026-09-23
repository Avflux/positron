; Fixture das correcoes de um campo (ver docs/RUNBOOK.md, rodada 72): monta um
; desenho com o app name LEGADO ("DISPOSITIVO", sem o "Dispositivo") e um borne
; com `Visivel = -1` e `lm = 0`, mais o dicionario REGUAS/MODELOS2 com o lm da
; regua. Serve para exercitar os dois caminhos de ESCRITA que o desenho real nao
; exercita: o `CorrigeDisp` (renomear o app name legado) e o `CorrigeBornes`
; (visibilidade -1 -> 0 e resolucao do lm).
(setvar "CMDECHO" 0)
(regapp "DISPOSITIVO")
(command "_.LAYER" "_M" "12" "")

; XData do borne no layout de 18 valores do original; o app name e o legado.
(defun pz-xdata-borne (visivel lm)
  (list -3
    (list "DISPOSITIVO"
      (cons 1000 "B") (cons 1000 "") (cons 1000 "") (cons 1000 "")
      (cons 1000 "1") (cons 1000 "")
      (cons 1040 1.0) (cons 1071 39)
      (cons 1000 "") (cons 1000 (itoa lm)) (cons 1000 "H")
      (cons 1040 0.0) (cons 1040 0.0)
      (cons 1071 0) (cons 1071 visivel)
      (cons 1000 "ana") (cons 1000 "2026-09-23"))))

; Bloco vazio + INSERT: o borne e o INSERT (e dele que o leitor tira handle e XData).
(defun pz-bloco-bare ()
  (entmake '((0 . "BLOCK") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockBegin")
             (2 . "PZBORNE") (70 . 0) (10 0.0 0.0 0.0) (3 . "PZBORNE") (1 . "")))
  (entmake '((0 . "ENDBLK") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockEnd")))
  (entmake '((0 . "INSERT") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockReference")
             (2 . "PZBORNE") (10 5.0 5.0 0.0)))
  (entlast))

; Xrecord do MODELOS2: cabecalho (maior indice) + um registro de 10 valores com
; +6 = lm do tipo 0 e +7 = lm do tipo 1 (o `BuscaLMdaRegua` do original).
(defun pz-xrecord-regua (indice nome painel lm0 lm1)
  (entmakex
    (append
      (list '(0 . "XRECORD") '(100 . "AcDbXrecord") '(280 . 1))
      (list (cons 90 indice))
      (list (cons 90 indice) (cons 1 nome) (cons 1 "") (cons 90 painel)
            (cons 90 0) (cons 90 0) (cons 90 lm0) (cons 90 lm1) (cons 90 0) (cons 1 "")))))

(defun pz-dicionario-reguas (/ dic)
  (setq dic (entmakex '((0 . "DICTIONARY") (100 . "AcDbDictionary"))))
  (dictadd (namedobjdict) "REGUAS" dic)
  (dictadd dic "MODELOS2" (pz-xrecord-regua 39 "R39" 9 45 46)))

(pz-dicionario-reguas)
(setq pz-b (pz-bloco-bare))
(entmod (append (entget pz-b) (list (pz-xdata-borne -1 0))))
(princ "fixture de correcoes montada (borne com Visivel=-1 e app name legado)")
(princ)
