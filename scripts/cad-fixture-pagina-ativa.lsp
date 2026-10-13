; Fixture do ATIVAPAGINA/PASSO (fatia 5, a pagina ativa): monta as paginas 1..3, a capa "1"
; com um texto proprio, o layer -1 (a camada de trabalho do produto) e texto em cada pagina,
; para a ativacao ter o que desligar. O pz-conta-camadas e o instrumento independente: le
; estado de cada layer (nome, LIGADO/desligado pela cor 62 negativa, corrente) e os textos
; por camada, de um arquivo por passo (o c:pz-conta-camadas <sufixo>).
(setvar "CMDECHO" 0)
(command "_.LAYER" "_M" "1" "")
(command "_.LAYER" "_M" "2" "")
(command "_.LAYER" "_M" "3" "")
(command "_.LAYER" "_M" "-1" "")
(command "_.LAYER" "_M" "0" "")
(defun pz-texto (txt camada)
  (command "_.TEXT" (list 10.0 10.0) 2.5 0 txt)
  (setq e (entlast))
  (command "_.CHPROP" e "" "_LA" camada ""))
(command "_.LAYER" "_S" "1" "") (pz-texto "capa" "1")
(command "_.LAYER" "_S" "2" "") (pz-texto "folha 2" "2")
(command "_.LAYER" "_S" "3" "") (pz-texto "folha 3" "3")
(command "_.LAYER" "_S" "-1" "") (pz-texto "trabalho" "-1")
(command "_.LAYER" "_S" "3" "")
(defun pz-conta-camadas (sufixo / arquivo f camada corrente n e dados conjunto i)
  (setq arquivo (strcat (getenv "POSITRON_DUMP") sufixo))
  (setq f (open arquivo "w"))
  (if (null f)
    (princ "\npz-conta-camadas: nao consegui abrir a saida")
    (progn
      (setq corrente (getvar "CLAYER"))
      (write-line (strcat "CORRENTE;" corrente) f)
      (setq camada (tblnext "LAYER" T))
      (while camada
        (setq n (cdr (assoc 2 camada)))
        (setq cor (cdr (assoc 62 camada)))
        (write-line (strcat "LAYER;" n ";" (if (and cor (< cor 0)) "DESLIGADO" "LIGADO")) f)
        (setq camada (tblnext "LAYER")))
      (setq conjunto (ssget "_X" (list (cons 0 "TEXT") (cons 410 "Model"))))
      (if conjunto
        (progn
          (setq i 0)
          (while (< i (sslength conjunto))
            (setq e (ssname conjunto i))
            (setq dados (entget e))
            (write-line (strcat "TEXTO;" (cdr (assoc 8 dados)) ";" (cdr (assoc 1 dados))) f)
            (setq i (1+ i)))))
      (close f)
      (princ (strcat "\npz-conta-camadas: saida em " arquivo))))
  (princ))
(princ "\nfixture PAGINA-ATIVA montada (paginas 1..3 + capa 1 + trabalho em -1)")
(princ)