; Fixture do RecriaTextosCabo (ver docs/RUNBOOK.md, rodada 78): monta um trecho de
; interligacao SEM rotulo valido, um rotulo VELHO (tipo 1) que deve sair, um texto
; comum que fica e duas entidades nao-texto com os app names das variantes
; (AUXINTERLIG/ENEL e ELETROSUL), que a limpeza tambem apaga.
;
; Esperado: "3 rotulo(s) apagado(s) e 1 reinserido(s) de 1 trecho(s)" e, no dump,
; UM rotulo AUXINTERLIG tipo 1 com o texto CABO-1/2 e o trecho com iModeloVeiaFuncao 0.
(setvar "CMDECHO" 0)
(regapp "INTERLIGACAO")
(regapp "AUXINTERLIG")
(regapp "ELETROSUL")
(command "_.LAYER" "_M" "12" "")

; XData do trecho, no layout de 19 valores do `InterligacaoXData`.
(defun pz-rot:xdata-trecho (tag numVeia nomeVeia painel1 painel2)
  (list -3
    (list "INTERLIGACAO"
      (cons 1070 1) (cons 1000 tag) (cons 1070 numVeia) (cons 1000 nomeVeia)
      (cons 1070 painel1) (cons 1070 0) (cons 1070 painel2) (cons 1070 0)
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1070 0)
      (cons 1070 0) (cons 1000 "ana") (cons 1000 "2026-09-23") (cons 1071 1)
      (cons 1040 0.0) (cons 1000 ""))))

; XData do rotulo auxiliar (8 valores).
(defun pz-rot:xdata-aux (tipo handle tHandle)
  (list -3
    (list "AUXINTERLIG"
      (cons 1070 tipo) (cons 1000 handle) (cons 1000 tHandle)
      (cons 1071 1) (cons 1000 "ana") (cons 1000 "2026-09-23") (cons 1000 ""))))

(defun pz-rot:xdata-eletrosul (handle)
  (list -3
    (list "ELETROSUL"
      (cons 1000 "ana") (cons 1000 "2026-09-23") (cons 1000 handle) (cons 1071 1))))

(defun pz-rot:texto (x y txt xdata / e)
  (command "_.TEXT" (list x y) 2.5 0 txt)
  (setq e (entlast))
  (if xdata (entmod (append (entget e) (list xdata))))
  e)

(defun pz-rot:linha (x1 y1 x2 y2 xdata / e)
  (command "_.LINE" (list x1 y1) (list x2 y2) "")
  (setq e (entlast))
  (if xdata (entmod (append (entget e) (list xdata))))
  e)

; O trecho (polilinha com INTERLIGACAO) e o rotulo velho preso a ele.
(command "_.PLINE" (list 0.0 0.0) (list 10.0 0.0) "")
(setq pz-rot:trecho (entlast))
(entmod (append (entget pz-rot:trecho)
                (list (pz-rot:xdata-trecho "CABO-1" 2 "" 1 2))))
(setq pz-rot:h (cdr (assoc 5 (entget pz-rot:trecho))))
; O rotulo velho (tipo 1) sai e e recriado.
(pz-rot:texto 5.0 1.0 "CABO-1/2" (pz-rot:xdata-aux 1 pz-rot:h ""))
; Texto comum: nao tem XData nenhum e fica.
(pz-rot:texto 20.0 5.0 "FICA" nil)
; Nao-texto com AUXINTERLIG (a variante ENEL usa o mesmo app name) sai.
(pz-rot:linha 0.0 20.0 5.0 20.0 (pz-rot:xdata-aux 1 "X1" ""))
; Nao-texto com ELETROSUL sai.
(pz-rot:linha 10.0 20.0 15.0 20.0 (pz-rot:xdata-eletrosul "X2"))

(defun pz-rot:escreve (f s) (princ s f))

(defun pz-rot:texto-de (v)
  (if (null v)
    ""
    (if (= (type v) STR) v (vl-princ-to-string v))))

(defun pz-rot:lista (v) (if (null v) "" (vl-princ-to-string v)))

; Dump: cada entidade com AUXINTERLIG/ELETROSUL e o trecho com o modelo da veia.
(defun pz-rot:dump ( / caminho f sel i e d x app nome tipo aux vals lin)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-rotulos.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-rotulos: falha ao abrir a saida")
    (progn
      (pz-rot:escreve f "AUXILIAR;app;tipo;texto;10;11;rot\n")
      (setq sel (ssget "_X"))
      (if (null sel)
        nil
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e (list "AUXINTERLIG" "ELETROSUL" "INTERLIGACAO")))
            (setq x (cdr (assoc -3 d)))
            (foreach app x
              (setq nome (car app))
              (if (or (= nome "AUXINTERLIG") (= nome "ELETROSUL"))
                (progn
                  (setq vals (cdr app))
                  (setq tipo (pz-rot:texto-de (cdr (assoc 1070 vals))))
                  (pz-rot:escreve f (strcat "AUXILIAR;" nome ";" tipo ";"
                                            (pz-rot:texto-de (cdr (assoc 1 d))) ";"
                                            (pz-rot:lista (cdr (assoc 10 d))) ";"
                                            (pz-rot:lista (cdr (assoc 11 d))) ";"
                                            (pz-rot:texto-de (cdr (assoc 50 d))) "\n"))
                  (setq aux (1+ (if aux aux 0)))))
              (if (= nome "INTERLIGACAO")
                (progn
                  (setq vals (cdr app))
                  (pz-rot:escreve f (strcat "TRECHO;" (pz-rot:texto-de (cdr (assoc 5 d))) ";"
                                            (pz-rot:texto-de (cdr (nth 1 vals))) ";"
                                            (pz-rot:texto-de (cdr (nth 2 vals))) ";"
                                            (pz-rot:texto-de (cdr (nth 12 vals))) "\n"))))))))
      (close f)
      (princ (strcat "cad-fixture-rotulos: escrito em " caminho)))))

(princ "fixture de rotulos de cabo montada")
(princ)