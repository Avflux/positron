; Fixture do AtualizaOpcionaisDoCabo (ver docs/RUNBOOK.md, rodada 82): monta um trecho
; com UMA receita de opcionais no rotulo auxiliar tipo 3 (`C#-#N#`) — o texto deve
; virar `CABO-1-V1` — e um rotulo tipo 1, que NAO pode ser tocado.
;
; Esperado: "1 de 1 rotulo(s) com os opcionais atualizados" e, na segunda passada,
; "0 de 1"; o dump mostra os dois rotulos com o texto final.
(setvar "CMDECHO" 0)
(regapp "INTERLIGACAO")
(regapp "AUXINTERLIG")
(command "_.LAYER" "_M" "12" "")

(defun pz-opc:xdata-trecho (tag numVeia nomeVeia)
  (list -3
    (list "INTERLIGACAO"
      (cons 1070 1) (cons 1000 tag) (cons 1070 numVeia) (cons 1000 nomeVeia)
      (cons 1070 1) (cons 1070 0) (cons 1070 2) (cons 1070 0)
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1070 0)
      (cons 1070 0) (cons 1000 "ana") (cons 1000 "2026-09-23") (cons 1071 1)
      (cons 1040 0.0) (cons 1000 ""))))

; Rotulo auxiliar: tipo, handle do trecho, THandle, 1, usuario, data e os OPCIONAIS
; (o indice 7 que o AtualizaOpcionaisDoCabo le).
(defun pz-opc:xdata-aux (tipo handle opcionais)
  (list -3
    (list "AUXINTERLIG"
      (cons 1070 tipo) (cons 1000 handle) (cons 1000 "")
      (cons 1071 1) (cons 1000 "ana") (cons 1000 "2026-09-23") (cons 1000 opcionais))))

(defun pz-opc:texto (x y txt xdata / e)
  (command "_.TEXT" (list x y) 2.5 0 txt)
  (setq e (entlast))
  (if xdata (entmod (append (entget e) (list xdata))))
  e)

(command "_.PLINE" (list 0.0 0.0) (list 10.0 0.0) "")
(setq pz-opc:trecho (entlast))
(entmod (append (entget pz-opc:trecho) (list (pz-opc:xdata-trecho "CABO-1" 2 "V1"))))
(setq pz-opc:h (cdr (assoc 5 (entget pz-opc:trecho))))
; O rotulo tipo 3 com a receita (o texto velho deve ser trocado).
(pz-opc:texto 5.0 1.0 "VELHO" (pz-opc:xdata-aux 3 pz-opc:h "C#-#N#"))
; O rotulo tipo 1: fica como esta.
(pz-opc:texto 20.0 1.0 "NAO-MEXE" (pz-opc:xdata-aux 1 pz-opc:h ""))

(defun pz-opc:escreve (f s) (princ s f))

(defun pz-opc:texto-de (v)
  (if (null v) "" (if (= (type v) STR) v (vl-princ-to-string v))))

(defun pz-opc:dump ( / caminho f sel i e d x app nome vals)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-opcionais.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-opcionais: falha ao abrir a saida")
    (progn
      (pz-opc:escreve f "ROTULO;texto;tipo;opcionais\n")
      (setq sel (ssget "_X" (list (cons 0 "TEXT"))))
      (if (null sel)
        nil
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e (list "AUXINTERLIG")))
            (foreach app (cdr (assoc -3 d))
              (if (= (car app) "AUXINTERLIG")
                (progn
                  (setq vals (cdr app))
                  (pz-opc:escreve f (strcat "ROTULO;" (pz-opc:texto-de (cdr (assoc 1 d))) ";"
                                            (pz-opc:texto-de (cdr (nth 0 vals))) ";"
                                            (pz-opc:texto-de (cdr (nth 6 vals))) "\n"))))))))
      (close f)
      (princ (strcat "cad-fixture-opcionais: escrito em " caminho)))))

(princ "fixture de opcionais montada")
(princ)