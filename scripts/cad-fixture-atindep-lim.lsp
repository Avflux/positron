; Fixture do ramo do desenho do `Edita Material Selecionado` do ATINDEP (ver
; docs/RUNBOOK.md, rodada 152): monta o que o desenho do projeto NAO exercita.
;
;   1. `ZQLIM` — um dispositivo `P` com os ATTDEFs `NOME1`, `MODELO`, `PAINEL` e
;      `FABRICANTE` (o desenho real tem 31 dispositivos com o `MODELO` e NENHUM
;      com `PAINEL`/`FABRICANTE`: as duas escritas ficariam como "tag fora do
;      bloco" o tempo todo), inserido com os quatro valores preenchidos e o
;      XData `Dispositivo` do layout de 29 valores do `GravarXDataDispPrincipal`,
;      painel 503 e `iLM1` = 0 (o zero faz a gravacao do XData acontecer);
;   2. `(pz-lim:estraga "5A3E" "MODELO DO REAL")` — o **avesso** do `MODELO`
;      limpo: poe um texto no `MODELO` de um dispositivo real (a copia do
;      `Funcional.dwg`, a linha 55 do painel 503, o `bTL`), que o comando tem de
;      **limpar**. Sem o estrago o efeito nao aparece: nesta copia os 31
;      `MODELO` estao vazios.
;
; O dump de XData entra por `POSITRON_DUMP_LSP` (o caminho de
; `scripts/cad-dump-xdata.lsp`): o `load` dele dumparia o "antes" e o comando
; `pz-dump`, de dentro dele, o "depois" — e por isso que a fixture nao tem dump
; proprio. Ver o cabecalho daquele arquivo.
;
; O que o comando grava (o mesmo para o dispositivo real):
;
;   iLM1  <- o material escolhido na tela (o que o guarda do `iLM1` decide)
;   MODELO <- "" (limpo)     PAINEL <- "PNL-GGE" (o nome do painel 503)
;   FABRICANTE <- "SIEMENS"  (o fabricante do material 461)
;
; A linha da `ListaMateriais` que aponta para o bloco **nao** nasce aqui (a
; fixture nao fala banco): ela e inserida na copia do banco com o handle que o
; dump mostra.
;
; Ferramenta (rodada 152): o caminho do bloco + INSERT tem de ser o **de
; `command`** (`_.-BLOCK` selecionando ATTDEFs soltos, como a fixture da troca
; de atributos da rodada 135) — por `entmake` o bloco nasce mas o `INSERT` nao
; aceita os atributos, e a montagem com o `100` da subclasse + o `66` faz o
; `entmakex` devolver nil. O `_.INSERT` **nao** pode ir dentro de um
; `vl-catch-all-apply`: assim o CAD cancela o comando ("Function cancelled").
(setvar "CMDECHO" 0)
(regapp "Dispositivo")

(defun pz-lim:marca (s / tf)
  (setq tf (open (strcat (getenv "TEMP") "/positron-lim-trace.txt") "a"))
  (princ (strcat s "\n") tf)
  (close tf))

;; O XData do dispositivo no layout de 29 valores do `GravarXDataDispPrincipal`
;; (`clsDispositivo`/`XDataDispositivosMaster`): os pares sao os `vals` do dump
;; (0 = tipo "P" ... 7 = painel ... 20 = iLM1 ... 27 = visibilidade).
(defun pz-lim:xdata (nome painel lm1)
  (list -3
    (list "Dispositivo"
      (cons 1000 "P") (cons 1000 nome) (cons 1000 "") (cons 1000 "")
      (cons 1000 "") (cons 1000 "") (cons 1040 0.0) (cons 1070 painel)
      (cons 1070 0) (cons 1070 0) (cons 1000 "") (cons 1071 0) (cons 1070 0)
      (cons 1000 "") (cons 1000 "") (cons 1000 "") (cons 1000 "LAYOUT") (cons 1000 "")
      (cons 1011 (list 0.0 0.0 0.0)) (cons 1040 0.0)
      (cons 1071 lm1) (cons 1070 0) (cons 1071 0)
      (cons 1000 "fixture") (cons 1000 "2026-10-13")
      (cons 1040 0.0) (cons 1040 1.0) (cons 1040 0.0))))

;; Bloco com os ATTDEFs dos quatro tags (a tecnica da rodada 89: cada ATTDEF
;; nasce solto e o bloco e criado com o `_.-BLOCK` selecionando ele).
(defun pz-lim:bloco (nome tags / atds a tag)
  (setq atds nil)
  (foreach tag tags
    (setq a (entmakex (list '(0 . "ATTDEF") '(8 . "0") (list 10 0.0 0.0 0.0)
                            (cons 40 2.5) (cons 1 tag) (cons 2 tag) (cons 3 "") (cons 70 0))))
    (if (null a) (pz-lim:marca (strcat "ATTDEF " tag " devolveu nil")) nil)
    ; `append` e nao `cons`: e a ordem desta lista que decide a ordem dos ATTDEFs
    ; na definicao do bloco e, com ela, a ordem dos valores no `_.INSERT`.
    (setq atds (append atds (list a))))
  (apply 'command (append (list "_.-BLOCK" nome (list 0.0 0.0)) atds (list ""))))

(defun pz-lim:dispositivo (nome painel lm1 x y valores / e par)
  (command "_.INSERT" nome (list x y) 1.0 1.0 0.0
           (nth 0 valores) (nth 1 valores) (nth 2 valores) (nth 3 valores))
  (setq e (entlast))
  (if (= (cdr (assoc 0 (entget e))) "INSERT")
    nil
    (pz-lim:marca "  o INSERT nao e o entlast"))
  (entmod (append (entget e) (list (pz-lim:xdata nome painel lm1))))
  e)

;; O avesso do `MODELO` limpo: uma linha de texto no atributo do bloco do handle.
(defun pz-lim:estraga (handle valor / e att d achou)
  (setq e (if (null handle) nil (handent handle)))
  (if (null e)
    (pz-lim:marca (strcat "o handle " handle " nao esta no desenho"))
    (progn
      (setq achou nil)
      (setq att (entnext e))
      (while (and att (= (cdr (assoc 0 (entget att))) "ATTRIB"))
        (setq d (entget att))
        (if (= (strcase (cdr (assoc 2 d))) "MODELO")
          (progn
            (entmod (subst (cons 1 valor) (assoc 1 d) d))
            (setq achou T)))
        (setq att (entnext att)))
      (pz-lim:marca (strcat "MODELO do bloco " handle
                            (if achou " estragado" " NAO existe no bloco"))))))

; ── O desenho ──────────────────────────────────────────────────────────────
(pz-lim:bloco "ZQLIM" (list "NOME1" "MODELO" "PAINEL" "FABRICANTE"))
(pz-lim:dispositivo "ZQLIM" 503 0 0.0 0.0
  (list "PZ1" "MODELO ANTIGO" "PAINEL ANTIGO" "FABRICANTE ANTIGO"))
(pz-lim:marca "dispositivo ZQLIM inserido")

; O dispositivo real da linha 55 do painel 503 (`bTL`, handle 5A3E, material
; 463): o MODELO dele e estragado para a limpeza ser visivel no dump.
(pz-lim:estraga "5A3E" "MODELO DO REAL")

(setq pz-lim:dump (getenv "POSITRON_DUMP_LSP"))
(if (and pz-lim:dump (/= pz-lim:dump ""))
  (load pz-lim:dump)
  nil)

(princ "fixture do ATINDEP/lim montada: ZQLIM (4 atributos + XData) e o MODELO do real 5A3E estragado")
(princ)
