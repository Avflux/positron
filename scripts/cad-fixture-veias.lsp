; Fixture do apagarTodosOsTextosDasVeias (ver docs/RUNBOOK.md, rodada 75): monta os
; QUATRO ramos da regra do original num desenho so -
;
;   - DBText com AUXINTERLIG tipo 1  -> apaga (o rotulo da veia);
;   - DBText com AUXINTERLIG tipo 2  -> fica (o rotulo da ponta);
;   - LWPOLYLINE com ELETROSUL       -> apaga (o primeiro ramo nao olha o tipo);
;   - DBText com ELETROSUL           -> apaga;
;   - LWPOLYLINE com AUXINTERLIG t.1 -> fica (o ramo do AUXINTERLIG so olha texto);
;   - DBText sem XData nenhum        -> fica.
;
; Esperado: 3 de 6 apagados (3 com AUXINTERLIG e 2 com ELETROSUL) e, na segunda
; passada, 0 de 3 - a convergencia. O dump (pz-veias:dump) mostra o que sobrou.
(setvar "CMDECHO" 0)
(regapp "AUXINTERLIG")
(regapp "ELETROSUL")
(command "_.LAYER" "_M" "12" "")

; XData do rotulo auxiliar no layout do `GravarXDataAuxInterligacao`: tipo, handle,
; THandle e quatro campos vazios.
(defun pz-veias:xdata-aux (tipo handle thandle)
  (list -3
    (list "AUXINTERLIG"
      (cons 1070 tipo) (cons 1000 handle) (cons 1000 thandle)
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1000 ""))))

; XData da variante Eletrosul, no layout do `GravarXDataAuxInterligacaoEletrosul`.
(defun pz-veias:xdata-eletrosul (handle)
  (list -3
    (list "ELETROSUL"
      (cons 1000 "ana") (cons 1000 "2026-09-23") (cons 1000 handle) (cons 1071 1))))

(defun pz-veias:texto (x y txt xdata / e)
  (command "_.TEXT" (list x y) 2.5 0 txt)
  (setq e (entlast))
  (if xdata (entmod (append (entget e) (list xdata))))
  e)

(defun pz-veias:linha (x y xdata / e)
  (command "_.PLINE" (list x y) (list (+ x 5.0) y) "")
  (setq e (entlast))
  (if xdata (entmod (append (entget e) (list xdata))))
  e)

(pz-veias:texto 0.0 0.0 "VEIA-1" (pz-veias:xdata-aux 1 "H1" ""))
(pz-veias:texto 0.0 5.0 "PONTA-2" (pz-veias:xdata-aux 2 "H2" "T2"))
(pz-veias:linha 0.0 10.0 (pz-veias:xdata-eletrosul "H3"))
(pz-veias:texto 0.0 15.0 "ELETRO-4" (pz-veias:xdata-eletrosul "H4"))
(pz-veias:linha 20.0 10.0 (pz-veias:xdata-aux 1 "H5" ""))
(pz-veias:texto 0.0 20.0 "SEM-XDATA" nil)

(defun pz-veias:escreve (f s) (princ s f))

(defun pz-veias:texto-de (v)
  (if (null v)
    ""
    (if (= (type v) 'STR) v (vl-princ-to-string v))))

; Uma linha por entidade que sobrou: tipo, texto e os dois app names (com o tipo
; do AUXINTERLIG) - a conferencia FORA do plugin do que a acao apagou.
(defun pz-veias:dump-entidade (d / x app nome aux elet)
  (setq aux "" elet "")
  (setq x (cdr (assoc -3 d)))
  (foreach app x
    (setq nome (car app))
    (if (= nome "AUXINTERLIG")
      (setq aux (strcat "tipo=" (pz-veias:texto-de (cdr (assoc 1070 (cdr app)))))))
    (if (= nome "ELETROSUL") (setq elet "SIM")))
  (strcat "ENTIDADE;" (cdr (assoc 0 d)) ";" (pz-veias:texto-de (cdr (assoc 1 d)))
          ";" aux ";" elet "\n"))

(defun pz-veias:dump ( / caminho f sel i e d)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-veias.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-veias: falha ao abrir a saida")
    (progn
      (pz-veias:escreve f "ENTIDADE;tipo;texto;auxinterlig;eletrosul\n")
      (setq sel (ssget "_X" '((0 . "TEXT,MTEXT,LWPOLYLINE"))))
      (if (null sel)
        nil
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e '("AUXINTERLIG" "ELETROSUL")))
            (pz-veias:escreve f (pz-veias:dump-entidade d)))))
      (close f)
      (princ (strcat "cad-fixture-veias: entidades escritas em " caminho)))))

(princ "fixture das veias montada (6 entidades: 3 apagaveis)")
(princ)