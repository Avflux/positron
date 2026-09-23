;;; cad-conta-layout.lsp — contingencia independente do `REMLAYDUP` (frente 2 do
;;; §7.6, rodada 84), fora do plugin.
;;;
;;; O `-Fixture` carrega antes do NETLOAD e `(pz-lay:conta)` roda no fim do script,
;;; entao a MESMA contagem serve para o antes (sem a acao) e o depois.
;;;
;;; Saida (uma linha por chave + o total):
;;;
;;;   CHAVE;<nome>;<n registros>;<tags separadas por |>,
;;;   TOTAL;chaves;<n>;registros;<r>
;;;
;;; O registro de um XRECORD sai no `entget` DEPOIS do grupo 280 (medido na rodada 76),
;;; e cada posicao do CENG_LAYOUT ocupa 5 valores (tag, alternativo, X, Y, vazio).
(defun pz-lay:escreve (f s) (princ s f))

(defun pz-lay:texto (v)
  (if (null v)
    ""
    (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-lay:valores (d)
  (mapcar (quote cdr) (cdr (member (assoc 280 d) d))))

(defun pz-lay:conta ( / caminho f dic nome sub vals n tags i total chaves)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-layout.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-layout: falha ao abrir a saida")
    (progn
      (pz-lay:escreve f "CHAVE;nome;registros;tags\n")
      (setq dic (dictsearch (namedobjdict) "CENG_LAYOUT"))
      (setq total 0 chaves 0)
      (if dic
        (foreach item dic
          (if (= (car item) 3)
            (progn
              (setq nome (cdr item))
              (setq sub (dictsearch (cdr (assoc -1 dic)) nome))
              (setq vals (if sub (pz-lay:valores (entget (cdr (assoc -1 sub)))) nil))
              (setq n (if vals (/ (length vals) 5) 0))
              (setq tags "" i 0)
              (while (< i (length vals))
                (setq tags (strcat tags (if (= tags "") "" "|") (pz-lay:texto (nth i vals))))
                (setq i (+ i 5)))
              (setq total (+ total n))
              (setq chaves (1+ chaves))
              (pz-lay:escreve f (strcat "CHAVE;" nome ";" (itoa n) ";" tags "\n"))))))
      (pz-lay:escreve f (strcat "TOTAL;chaves;" (itoa chaves)
                                ";registros;" (itoa total) "\n"))
      (close f)
      (princ (strcat "cad-conta-layout: escrito em " caminho)))))

(princ "contador de layout carregado: rode (pz-lay:conta)")
(princ)