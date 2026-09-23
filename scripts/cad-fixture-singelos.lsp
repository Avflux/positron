; Fixture do CorrigeCabosSingelos (ver docs/RUNBOOK.md, rodada 81): monta UM trecho
; com o Tag_Cabo e o NomeVeia com o marcador `#` — o par do banco semeado por
; scripts/cad-seed-singelos.py. O comando deve limpar o NomeVeia do XData (e o do
; banco) e recriar o rotulo.
;
; Esperado: "1 trecho(s) com o NomeVeia limpo (1 cabo(s) candidato(s); ...)" e, no
; dump, o trecho com o NomeVeia vazio e o rotulo recriado com o texto CABO-SINGELO.
(setvar "CMDECHO" 0)
(regapp "INTERLIGACAO")
(regapp "AUXINTERLIG")
(command "_.LAYER" "_M" "12" "")

(defun pz-sing:xdata-trecho (tag numVeia nomeVeia painel1 painel2)
  (list -3
    (list "INTERLIGACAO"
      (cons 1070 1) (cons 1000 tag) (cons 1070 numVeia) (cons 1000 nomeVeia)
      (cons 1070 painel1) (cons 1070 0) (cons 1070 painel2) (cons 1070 0)
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1070 0)
      (cons 1070 0) (cons 1000 "ana") (cons 1000 "2026-09-23") (cons 1071 1)
      (cons 1040 0.0) (cons 1000 ""))))

(defun pz-sing:xdata-aux (tipo handle)
  (list -3
    (list "AUXINTERLIG"
      (cons 1070 tipo) (cons 1000 handle) (cons 1000 "")
      (cons 1071 1) (cons 1000 "ana") (cons 1000 "2026-09-23") (cons 1000 ""))))

(defun pz-sing:texto (x y txt xdata / e)
  (command "_.TEXT" (list x y) 2.5 0 txt)
  (setq e (entlast))
  (if xdata (entmod (append (entget e) (list xdata))))
  e)

(command "_.PLINE" (list 0.0 0.0) (list 10.0 0.0) "")
(setq pz-sing:trecho (entlast))
(entmod (append (entget pz-sing:trecho)
                (list (pz-sing:xdata-trecho "CABO-SINGELO" 1 "V#1" 1 2))))
(setq pz-sing:h (cdr (assoc 5 (entget pz-sing:trecho))))
; O rotulo velho (tipo 1) sai e e recriado pela segunda parte do comando.
(pz-sing:texto 5.0 1.0 "V#1" (pz-sing:xdata-aux 1 pz-sing:h))

(defun pz-sing:escreve (f s) (princ s f))

(defun pz-sing:texto-de (v)
  (if (null v) "" (if (= (type v) STR) v (vl-princ-to-string v))))

(defun pz-sing:dump ( / caminho f sel i e d x app nome vals)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-singelos.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-singelos: falha ao abrir a saida")
    (progn
      (pz-sing:escreve f "TRECHO;handle;tag;numVeia;nomeVeia\n")
      (setq sel (ssget "_X"))
      (if (null sel)
        nil
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e (list "INTERLIGACAO" "AUXINTERLIG")))
            (setq x (cdr (assoc -3 d)))
            (foreach app x
              (setq nome (car app))
              (setq vals (cdr app))
              (if (= nome "INTERLIGACAO")
                (pz-sing:escreve f (strcat "TRECHO;" (cdr (assoc 5 d)) ";"
                                           (pz-sing:texto-de (cdr (nth 1 vals))) ";"
                                           (pz-sing:texto-de (cdr (nth 2 vals))) ";"
                                           (pz-sing:texto-de (cdr (nth 3 vals))) "\n")))
              (if (= nome "AUXINTERLIG")
                (pz-sing:escreve f (strcat "ROTULO;" (pz-sing:texto-de (cdr (assoc 1 d))) ";"
                                           (pz-sing:texto-de (cdr (nth 0 vals))) "\n")))))))
      (close f)
      (princ (strcat "cad-fixture-singelos: escrito em " caminho)))))

(princ "fixture de cabos singelos montada")
(princ)