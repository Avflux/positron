; Fixture da exportacao de plaquetas (EPLQ) do recoder: monta o dicionario
; CENG_PLAQUETA com um painel (9) e uma CONEXAO do painel 9, para a EPLQ ler o
; dicionario do proprio desenho e gravar Plaquetas4 (ver docs/RUNBOOK.md).
; Roda com o cadastro de paineis semeado com Indice=9/Nome=PAINEL-9: o nome do
; painel e o que resolve a plaqueta do tipo P.
(setvar "CMDECHO" 0)
(regapp "CONEXAO")
(command "_.LAYER" "_M" "12" "")

(defun pz-xdata-conexao (tipo potencial painel nome secao cor)
  (list -3
    (list "CONEXAO"
      (cons 1070 tipo) (cons 1071 potencial) (cons 1000 "") (cons 1070 painel)
      (cons 1070 0) (cons 1070 0) (cons 1000 nome) (cons 1000 "")
      (cons 1000 "") (cons 1000 secao) (cons 1000 cor) (cons 1000 "")
      (cons 1040 0.0) (cons 1070 0) (cons 1070 0) (cons 1000 "")
      (cons 1000 "") (cons 1071 0) (cons 1071 0) (cons 1000 "ana")
      (cons 1000 "2026-10-09") (cons 1071 0) (cons 1040 0.0) (cons 1000 ""))))

; Um Xrecord de painel: a lista achatada de registros de 7 valores
; (tipo, handle, indexRegua, desc1, desc2, desc3, modelo).
; `entmakex` (nao `entmake`): o `dictadd` precisa do NOME da entidade, e o
; `entmake` devolve a lista de associacao.
(defun pz-xrecord (registros)
  (entmakex
    (append
      (list '(0 . "XRECORD") '(100 . "AcDbXrecord") '(280 . 1))
      (apply 'append
        (mapcar
          '(lambda (r)
             (list (cons 1 (nth 0 r)) (cons 1 (nth 1 r)) (cons 70 (nth 2 r))
                   (cons 1 (nth 3 r)) (cons 1 (nth 4 r)) (cons 1 (nth 5 r))
                   (cons 1 (nth 6 r))))
          registros)))))

; Dicionario CENG_PLAQUETA no NamedObjectsDictionary. A chave do dicionario e o
; numero do painel; cada Xrecord traz TODAS as plaquetas daquele painel.
(defun pz-dicionario-plaquetas ()
  (setq dic (entmakex '((0 . "DICTIONARY") (100 . "AcDbDictionary"))))
  (dictadd (namedobjdict) "CENG_PLAQUETA" dic)
  ; Painel 9 (tem fiacao no desenho): P com descricao e X entram; D sem
  ; dispositivo no desenho e P sem nenhuma descricao saem.
  (dictadd dic "9"
    (pz-xrecord
      (list
        (list "P" "H1"  0 "PLACA DO PAINEL" ""          "" "MOD-P")
        (list "X" "#1"  0 "TEXTO LIVRE"     ""          "" "MOD-X")
        (list "D" "H9"  0 "D"               ""          "" "MOD-D")
        (list "P" "H2"  0 ""                ""          "" "MOD-Z"))))
  ; Painel 77: existe no dicionario mas nao tem fiacao no desenho.
  (dictadd dic "77"
    (pz-xrecord (list (list "X" "#2" 0 "PAINEL 77" "" "" "MOD-77")))))

(pz-dicionario-plaquetas)
(princ "dicionario CENG_PLAQUETA montado")

; Uma CONEXAO do painel 9 - e o que marca o painel como "com fiacao".
(command "_.PLINE" (list 0.0 0.0) (list 10.0 0.0) "")
(entmod (append (entget (entlast)) (list (pz-xdata-conexao 1 5 9 "C1" "2,5" "AZ"))))
(princ "fixture de plaquetas montada")
(princ)
