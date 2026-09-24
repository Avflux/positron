; Fixture da troca de blocos (ver docs/RUNBOOK.md, rodada 135): monta dois blocos com
; atributos, sendo um deles INVISIVEL — o buffer do `LeTodosAtributos` so guarda os
; invisiveis, porque e neles que a troca de bloco carrega o valor de um bloco para o
; outro.
;
;   1. `MODELO_NA_1` com os ATTDEFs `T1` (invisivel) e `T2` (visivel), inserido com
;      os valores `A1` / `B2`;
;   2. `AUXILIAR_A_1` com o ATTDEF `T3` (invisivel), inserido com `C3`.
;
; Esperado no buffer: 2 entradas (T1 e T3), 3 atributos lidos, 2 blocos com atributo.
;
; `(pz-tb:estraga)` e o **avesso da troca** para medir a escrita sem trocar bloco
; nenhum: ele muda o texto do atributo invisivel e o poe visivel. E o que a troca de
; bloco faria com o bloco novo — o buffer tem o valor bom e o comando deve devolve-lo,
; com a visibilidade de volta.
;
; A via do `entmake` do ATTDEF **dentro** do BLOCK nao funciona no ZWCAD (rodada 89):
; aqui cada ATTDEF nasce solto e o bloco e criado com `_.-BLOCK` selecionando ele.
;
; O dump (definido ANTES do desenho) grava um rastro por passo: uma linha do setup que
; estoure nao leva o dump junto (licao da rodada 83).
(setvar "CMDECHO" 0)
(regapp "ZZTeste")

(defun pz-tb:escreve (f s) (princ s f))

(defun pz-tb:marca (s / tf)
  (setq tf (open (strcat (getenv "TEMP") "/positron-tb-trace.txt") "a"))
  (princ (strcat s "\n") tf)
  (close tf))

(defun pz-tb:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-tb:sinn (d)
  (if (assoc 1 d) (cdr (assoc 1 d)) ""))

; O flag 70 do ATTDEF/ATTRIB: o bit 1 e "invisivel".
(defun pz-tb:invisivel (d)
  (= 1 (logand 1 (if (assoc 70 d) (cdr (assoc 70 d)) 0))))

(defun pz-tb:conta ( / caminho f sel i e a d n ent vis)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-troca.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-troca-atributos: falha ao abrir a saida")
    (progn
      (pz-tb:escreve f "ATRIB;handle;bloco;tag;valor;invisivel\n")
      (setq n 0 ent 0 vis 0)
      (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq ent (1+ ent))
            (setq a (entnext e))
            (while (and a (= (cdr (assoc 0 (entget a))) "ATTRIB"))
              (setq n (1+ n))
              (if (pz-tb:invisivel (entget a)) (setq vis (1+ vis)))
              (pz-tb:escreve f (strcat "ATRIB;" (pz-tb:texto (cdr (assoc 5 d))) ";"
                                       (pz-tb:texto (cdr (assoc 2 d))) ";"
                                       (pz-tb:texto (cdr (assoc 2 (entget a)))) ";"
                                       (pz-tb:sinn (entget a)) ";"
                                       (if (pz-tb:invisivel (entget a)) "SIM" "NAO") "\n"))
              (setq a (entnext a))))))
      (pz-tb:escreve f (strcat "TOTAL;insercoes;" (itoa ent) ";atributos;" (itoa n)
                                ";invisiveis;" (itoa vis) "\n"))
      (close f)
      (princ (strcat "cad-fixture-troca-atributos: " (itoa ent) " insercao(oes), "
                     (itoa n) " atributo(s), " (itoa vis) " invisivel(is)")))))

; O avesso da troca: estraga o texto do atributo invisivel e o poe visivel — quem
; devolve o valor e a visibilidade e o `CorrigeAtributos`/`CorrigeAtributosSemMsg`,
; com o buffer lido antes.
(defun pz-tb:estraga ( / sel i e a d)
  (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
  (if sel
    (progn
      (setq i (sslength sel))
      (while (> i 0)
        (setq i (1- i))
        (setq e (ssname sel i))
        (setq a (entnext e))
        (while (and a (= (cdr (assoc 0 (entget a))) "ATTRIB"))
          (setq d (entget a))
          (if (pz-tb:invisivel d)
            (progn
              (setq d (subst (cons 1 "ESTRAGADO") (assoc 1 d) d))
              (setq d (subst (cons 70 0) (assoc 70 d) d))
              (entmod d)))
          (setq a (entnext a))))))
  (princ "cad-fixture-troca-atributos: atributos invisiveis estragados"))

; ── O desenho ──────────────────────────────────────────────────────────────
(defun pz-tb:bloco (nome tags / atds a)
  (setq atds nil)
  (foreach t tags
    (setq a (entmakex (list (quote (0 . "ATTDEF")) (cons 8 "0") (list 10 0.0 0.0 0.0)
                            (cons 40 2.5) (cons 1 t) (cons 2 t) (cons 3 "")
                            (cons 70 (if (= t "T2") 0 1)))))
    (setq atds (cons a atds)))
  (apply (quote command) (append (list "_.-BLOCK" nome (list 0.0 0.0)) atds (list ""))))

(pz-tb:marca "1 ATTDEFs de MODELO_NA_1")
(pz-tb:bloco "MODELO_NA_1" (list "T1" "T2"))
(pz-tb:marca "2 bloco MODELO_NA_1 criado")
(pz-tb:marca "3 ATTDEFs de AUXILIAR_A_1")
(pz-tb:bloco "AUXILIAR_A_1" (list "T3"))
(pz-tb:marca "4 bloco AUXILIAR_A_1 criado")

(command "_.INSERT" "MODELO_NA_1" (list 0.0 0.0) 1.0 1.0 0.0 "A1" "B2")
(pz-tb:marca "5 insert de MODELO_NA_1 feito")
(command "_.INSERT" "AUXILIAR_A_1" (list 30.0 0.0) 1.0 1.0 0.0 "C3")
(pz-tb:marca "6 insert de AUXILIAR_A_1 feito")
(pz-tb:marca "7 fim da fixture")

(princ "fixture da troca de blocos montada: rode (pz-tb:conta)")
(princ)
