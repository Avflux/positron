;;; cad-conta-interligacao.lsp — instrumento independente: dumpar o XData INTERLIGACAO
;;; das polylines do ModelSpace, uma linha por trecho:
;;;
;;;   ILIG;<handle>;<y0>;<tipo>;<numVeia>;<painel1>;<painel2>
;;;
;;; O arquivo sai de POSITRON_DUMP ou, sem ele, <TEMP>/positron-interligacao.txt.
;;; Nao aplica regra nenhuma: e a leitura crua do desenho, para conferir o que o
;;; comando gravou (o mesmo papel dos cad-conta-*.lsp).
(defun pz-ilig-app (e / dados)
  (car (cdr (assoc -3 (entget e (list "INTERLIGACAO"))))))

(defun pz-ilig-campo (app indice)
  (cdr (nth indice app)))

(defun c:pz-conta-ilig ( / arquivo f conjunto i e app tipo numVeia p1 p2 y0)
  (setq arquivo (getenv "POSITRON_DUMP"))
  (if (or (null arquivo) (= arquivo ""))
    (setq arquivo (strcat (getenv "TEMP") "/positron-interligacao.txt")))
  (setq f (open arquivo "w"))
  (if (null f)
    (princ "\npz-conta-ilig: nao consegui abrir a saida")
    (progn
      (setq conjunto (ssget "_X" (list (cons 0 "LWPOLYLINE") (cons 410 "Model"))))
      (if conjunto
        (progn
          (setq i 0)
          (while (< i (sslength conjunto))
            (setq e (ssname conjunto i))
            (setq app (pz-ilig-app e))
            (if app
              (progn
                (setq tipo (pz-ilig-campo app 1))
                (setq numVeia (pz-ilig-campo app 3))
                (setq p1 (pz-ilig-campo app 5))
                (setq p2 (pz-ilig-campo app 7))
                (setq y0 (cadr (cdr (assoc 10 (entget e)))))
                (write-line (strcat "ILIG;" (cdr (assoc 5 (entget e))) ";"
                  (rtos y0 2 0) ";" (itoa tipo) ";" (itoa numVeia) ";"
                  (itoa p1) ";" (itoa p2)) f)))
            (setq i (1+ i)))))
      (close f)
      (princ (strcat "\npz-conta-ilig: "
        (if conjunto (itoa (sslength conjunto)) "0")
        " LWPOLYLINE(s) no ModelSpace; saida em " arquivo))))
  (princ))

(princ "\ncad-conta-interligacao carregado (comando: pz-conta-ilig)")
(princ)
