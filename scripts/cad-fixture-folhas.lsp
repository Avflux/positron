; Fixture da rodada 182 (o item 2 da correcao do basico — folhas pela paleta: o Inserir das cinco
; colunas do formato, a Nova Pagina pela linha selecionada e o Apagar Paginas).
;
; Com POSITRON_R182_COLUNAS monta no desenho aberto o que o Funcional.dwg real nao tem:
;   - os layers ELET1_COMANDO e ELET2_SINALIZACAO na tabela de layers;
;   - duas LINE na definicao do bloco de formato do desenho (o BlockReference com XData
;     DiagLog/Formato), uma em cada layer ELETn_ — e isso o que o `Pagina.InserirColuna` clona
;     para o layer da pagina escolhida e marca com DiagLog/COLUNAS.
;
; O (pz-folhas:dump) despeja em POSITRON_DUMP: a camada corrente (`CLAYER`), se os layers das
; paginas medidas existem e quantas entidades no ModelSpace tem o XData DiagLog/COLUNAS (com o
; layer e o tipo de cada uma) — leitura independente do plugin (entget e tblsearch).
(setvar "CMDECHO" 0)

(defun pz-folhas:layer (nome)
  (if (not (tblsearch "LAYER" nome))
    (entmake (list '(0 . "LAYER")
                   '(100 . "AcDbSymbolTableRecord")
                   '(100 . "AcDbLayerTableRecord")
                   (cons 2 nome) '(70 . 0) '(62 . 7) '(6 . "CONTINUOUS")))))

; O nome da definicao do bloco de formato (o BlockReference com XData DiagLog/Formato no
; ModelSpace, lido por entget sem depender do plugin).
(defun pz-folhas:nome-formato (/ e d xd bloco)
  (setq e (entnext))
  (while (and e (not bloco))
    (setq d (entget e '("DiagLog")))
    (if (= "INSERT" (cdr (assoc 0 d)))
      (progn
        (setq xd (car (cdr (assoc -3 d))))
        (if (and xd (= "Formato" (cdr (car (cdr xd)))))
          (setq bloco (cdr (assoc 2 d))))))
    (setq e (entnext e)))
  bloco)

; Acrescenta duas LINE a definicao do bloco de formato — sem redefinir o bloco (o ActiveX não
; existe no accoreconsole): no DXF uma entidade nao da pra colocar numa definicao existente sem
; reabrir o BLOCK, entao quando nao ha formato a fixture cria um bloco formato com as duas LINE e
; a referencia marcada; quando ja ha, acrescenta um segundo bloco de formato so se pedido.
; Para funcionar tanto no Funcional.dwg quanto num desenho limpo, a fixture troca o XData Formato
; da referencia antiga para a nossa definicao com as duas colunas.
(defun pz-folhas:montar-colunas (/ e d xd)
  (regapp "DiagLog")
  (pz-folhas:layer "ELET1_COMANDO")
  (pz-folhas:layer "ELET2_SINALIZACAO")

  ; Tira a marca Formato de qualquer INSERT existente para o Encontrar achar o nosso.
  (setq e (entnext))
  (while e
    (setq d (entget e '("DiagLog")))
    (if (and (= "INSERT" (cdr (assoc 0 d))) (assoc -3 d))
      (entmod (append (vl-remove (assoc -3 d) d) (list (list -3 (list "DiagLog"))))))
    (setq e (entnext e)))

  (entmake (list '(0 . "BLOCK") '(2 . "PZ_FORMATO_COLUNAS") '(70 . 0) '(10 0.0 0.0 0.0)))
  (entmake (list '(0 . "LINE") '(8 . "ELET1_COMANDO") '(10 0.0 0.0 0.0) '(11 10.0 0.0 0.0)))
  (entmake (list '(0 . "LINE") '(8 . "ELET1_COMANDO") '(10 0.0 5.0 0.0) '(11 10.0 5.0 0.0)))
  (entmake (list '(0 . "LINE") '(8 . "ELET2_SINALIZACAO") '(10 20.0 0.0 0.0) '(11 30.0 0.0 0.0)))
  (entmake '((0 . "ENDBLK")))

  (entmake (list '(0 . "INSERT") '(100 . "AcDbEntity") '(8 . "0") '(100 . "AcDbBlockReference")
                 '(2 . "PZ_FORMATO_COLUNAS") '(10 0.0 0.0 0.0)
                 (list -3 (list "DiagLog" (cons 1000 "Formato"))))))

(if (getenv "POSITRON_R182_COLUNAS") (pz-folhas:montar-colunas))

(defun pz-folhas:dump (/ arq f e d xd marca tipo)
  (setq arq (getenv "POSITRON_DUMP"))
  (if (and arq (> (strlen arq) 0))
    (progn
      (setq f (open arq "w"))
      (write-line (strcat "CLAYER;" (getvar "CLAYER")) f)
      (foreach p '("1" "2" "2A" "6" "7" "15" "15A" "22" "23")
        (write-line (strcat "LAYER;" p ";" (if (tblsearch "LAYER" p) "existe" "apagado")) f))
      (setq e (entnext))
      (while e
        (setq d (entget e '("DiagLog")))
        (setq xd (car (cdr (assoc -3 d))))
        (if xd
          (progn
            (setq marca (cdr (nth 1 xd)))
            (if (= "COLUNAS" marca)
              (progn
                (setq tipo (cdr (nth 2 xd)))
                (write-line (strcat "COLUNA;" (cdr (assoc 0 d)) ";layer=" (cdr (assoc 8 d)) ";tipo=" tipo) f)))))
        (setq e (entnext e)))
      (close f))))
