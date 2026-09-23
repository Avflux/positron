; Fixture do SobeLm (ver docs/RUNBOOK.md, rodada 74): monta os DOIS caminhos de
; leitura do lm da regua e o caminho de ESCRITA que o desenho real nao exercita
; (la os 119 BorneSemLm nao tem definicao em nenhuma das duas fontes):
;
;   - MODELOS2: a regua 39 define +6 = 496 (lm do tipo 0) - o campo que o
;     BuscaLMdaRegua do original le;
;   - CENG_BORNES: a regua 44 tem o campo do MODELOS2 zerado e um borne de
;     reserva com lm = 497 no dicionario (o desvio medido do recoder);
;   - o borne que ja tem lm (10) nao entra: so o zerado sobe.
;
; Esperado: "SobeLm: 3 de 4 borne(s) ganharam o lm da regua (3 com lm zerado;
; 0 sem definicao para o tipo na regua)." e, na segunda passada, "os 4 borne(s)
; do desenho ja tem lm." O dump mostra 496/497/497/10 (independente do plugin).
(setvar "CMDECHO" 0)
(regapp "Dispositivo")

; XData do borne no layout de 18 valores do original (app name Dispositivo/B).
(defun pz-lm:xdata-borne (regua tipo lm)
  (list -3
    (list "Dispositivo"
      (cons 1000 "B") (cons 1000 "") (cons 1000 "") (cons 1000 "")
      (cons 1000 "41") (cons 1000 "")
      (cons 1040 41.0) (cons 1071 regua)
      (cons 1000 "") (cons 1000 (itoa lm)) (cons 1000 "H")
      (cons 1040 0.0) (cons 1040 0.0)
      (cons 1071 tipo) (cons 1071 1)
      (cons 1000 "ana") (cons 1000 "2026-09-23"))))

; Bloco vazio + INSERT: o borne e o INSERT (e dele que o leitor tira handle e XData).
(defun pz-lm:bloco (nome)
  (entmake (list '(0 . "BLOCK") '(100 . "AcDbEntity") '(8 . "0") '(100 . "AcDbBlockBegin")
                 (cons 2 nome) '(70 . 0) (list 10 0.0 0.0 0.0) (cons 3 nome) '(1 . "")))
  (entmake '((0 . "ENDBLK") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockEnd"))))

(defun pz-lm:borne (nome x y regua tipo lm / e)
  (setq e (entmakex (list '(0 . "INSERT") '(100 . "AcDbEntity") '(8 . "0")
                          '(100 . "AcDbBlockReference") (cons 2 nome) (list 10 x y 0.0))))
  (entmod (append (entget e) (list (pz-lm:xdata-borne regua tipo lm))))
  e)

; Registro de 10 valores do MODELOS2: +0 indice, +1 nome, +2 alternativo,
; +3 painel, +6 = lm do tipo 0 e +7 = lm do tipo 1 (o BuscaLMdaRegua do original).
(defun pz-lm:regua-valores (indice nome painel lm0 lm1)
  (list (cons 90 indice) (cons 1 nome) (cons 1 "") (cons 90 painel)
        (cons 90 0) (cons 90 0) (cons 90 lm0) (cons 90 lm1) (cons 90 0) (cons 1 "")))

(defun pz-lm:dicionario-reguas (/ dic)
  (setq dic (entmakex '((0 . "DICTIONARY") (100 . "AcDbDictionary"))))
  (dictadd (namedobjdict) "REGUAS" dic)
  (dictadd dic "MODELOS2"
    (entmakex
      (append
        (list '(0 . "XRECORD") '(100 . "AcDbXrecord") '(280 . 1))
        (list (cons 90 44))
        (pz-lm:regua-valores 39 "R39" 9 496 0)
        (pz-lm:regua-valores 44 "R44" 10 0 0)))))

; Registro de 10 valores do CENG_BORNES: +1 numero, +3 ordem, +4 tipo,
; +5 lm, +6 reserva.
(defun pz-lm:reserva-valores (numero ordem tipo lm)
  (list (cons 90 44) (cons 1 numero) (cons 1 "") (cons 90 ordem)
        (cons 90 tipo) (cons 90 lm) (cons 290 1) (cons 1 "") (cons 1 "") (cons 1 "")))

(defun pz-lm:dicionario-bornes (/ dic)
  (setq dic (entmakex '((0 . "DICTIONARY") (100 . "AcDbDictionary"))))
  (dictadd (namedobjdict) "CENG_BORNES" dic)
  (dictadd dic "44"
    (entmakex
      (append
        (list '(0 . "XRECORD") '(100 . "AcDbXrecord") '(280 . 1))
        (pz-lm:reserva-valores "41" 41 0 497)))))

(pz-lm:dicionario-reguas)
(pz-lm:dicionario-bornes)
(pz-lm:bloco "PZBORNE")
(pz-lm:borne "PZBORNE" 5.0 5.0 39 0 0)
(pz-lm:borne "PZBORNE" 10.0 5.0 44 0 0)
(pz-lm:borne "PZBORNE" 15.0 5.0 44 0 0)
(pz-lm:borne "PZBORNE" 20.0 5.0 39 0 10)

(defun pz-lm:escreve (f s) (princ s f))

(defun pz-lm:texto (v)
  (if (null v)
    ""
    (if (= (type v) 'STR) v (vl-princ-to-string v))))

; Dump do que ficou gravado. Roda como comando - (pz-lm:dump) - depois do
; SobeLm, para conferir FORA do plugin o lm/tipo/regua de cada borne (o
; vals[9] e o vals[13] do mesmo layout que o cad-dump-xdata.lsp usa).
(defun pz-lm:dump ( / caminho f sel i e d x app vals)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-lm.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-lm: falha ao abrir a saida")
    (progn
      (pz-lm:escreve f "BORNE;handle;lm;tipo;regua\n")
      (setq sel (ssget "_X" '((0 . "INSERT"))))
      (if (null sel)
        nil
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e '("Dispositivo")))
            (setq x (cdr (assoc -3 d)))
            (foreach app x
              (if (= (car app) "Dispositivo")
                (progn
                  (setq vals (mapcar 'cdr (cdr app)))
                  (pz-lm:escreve f (strcat "BORNE;" (cdr (assoc 5 d))
                                           ";" (pz-lm:texto (nth 9 vals))
                                           ";" (pz-lm:texto (nth 13 vals))
                                           ";" (pz-lm:texto (nth 7 vals)) "\n"))))))))
      (close f)
      (princ (strcat "cad-fixture-lm: bornes escritos em " caminho)))))

(princ "fixture do SobeLm montada (2 reguas: MODELOS2 e CENG_BORNES; 4 bornes, 1 com lm)")
(princ)
