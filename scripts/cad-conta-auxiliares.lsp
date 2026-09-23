;;; cad-conta-auxiliares.lsp — contingência independente do
;;; `apagarTodosOsTextosDasVeias` (frente 2 do §7.6, rodada 75), fora do plugin.
;;;
;;; Uso pelo harness: o `-Fixture` carrega antes do NETLOAD, e o comando
;;; `(pz-aux:dump)` roda no fim do script — então a MESMA contagem serve para o
;;; antes (sem a ação) e para o depois (com a ação).
;;;
;;;   set POSITRON_XDATA=%TEMP%positron-aux.txt
;;;   powershell -File scripts/cad-zwcad-smoke.ps1 -Fixture scripts/cad-conta-auxiliares.lsp \
;;;     -Comandos "apagarTodosOsTextosDasVeias,(pz-aux:dump)" ...
;;;
;;; Saída:
;;;
;;;   AUXILIAR;<tipo>;<handle>;<texto>;<auxinterlig>;<eletrosul>
;;;   TOTAL;<n>;AUXINTERLIG;<a>;ELETROSUL;<e>
;;;
;;; **A lista de app names vem da tabela APPID do próprio desenho** (a lição da
;;; rodada 70): o `entget` só devolve o grupo -3 dos app names que recebe, e um
;;; app name fora da lista faria a entidade parecer sem XData. A varredura é por
;;; `ssget "_X"` sem filtro de tipo: o `AUXINTERLIG` do desenho real está em
;;; `ATTRIB` (que deriva de `DBText`, como o `AttributeDefinition`), e um filtro
;;; só de `TEXT` contava **0** onde o plugin achou 24.
(defun pz-aux:appids ( / t1 nomes)
  (setq nomes nil)
  (setq t1 (tblnext "APPID" T))
  (while t1
    (setq nomes (cons (cdr (assoc 2 t1)) nomes))
    (setq t1 (tblnext "APPID")))
  nomes)

(setq pz-aux:apps (pz-aux:appids))

(defun pz-aux:escreve (f s) (princ s f))

(defun pz-aux:texto (v)
  (if (null v)
    ""
    (if (= (type v) 'STR) v (vl-princ-to-string v))))

; Devolve a linha da entidade com AUXINTERLIG e/ou ELETROSUL; nil se nao tem nenhum.
(defun pz-aux:linha (e / d x app nome aux elet)
  (setq d (entget e pz-aux:apps))
  (setq aux "" elet "")
  (foreach app (cdr (assoc -3 d))
    (setq nome (car app))
    (if (= nome "AUXINTERLIG")
      (setq aux (strcat "tipo=" (pz-aux:texto (cdr (assoc 1070 (cdr app)))))))
    (if (= nome "ELETROSUL") (setq elet "SIM")))
  (if (and (= aux "") (= elet ""))
    nil
    (strcat "AUXILIAR;" (cdr (assoc 0 d)) ";" (cdr (assoc 5 d)) ";"
            (pz-aux:texto (cdr (assoc 1 d))) ";" aux ";" elet "\n")))

(defun pz-aux:dump ( / caminho f sel i e linha n a el)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-auxiliares.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-auxiliares: falha ao abrir a saida")
    (progn
      (pz-aux:escreve f "AUXILIAR;tipo;handle;texto;auxinterlig;eletrosul\n")
      (setq n 0 a 0 el 0)
      (setq sel (ssget "_X"))
      (if (null sel)
        nil
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq linha (pz-aux:linha e))
            (if linha
              (progn
                (pz-aux:escreve f linha)
                (setq n (1+ n))
                (if (/= (vl-string-search "tipo=" linha) nil) (setq a (1+ a)))
                (if (/= (vl-string-search ";SIM" linha) nil) (setq el (1+ el))))))))
      (pz-aux:escreve f (strcat "TOTAL;" (itoa n) ";AUXINTERLIG;" (itoa a) ";ELETROSUL;" (itoa el) "\n"))
      (close f)
      (princ (strcat "cad-conta-auxiliares: " (itoa n) " auxiliar(es) (AUXINTERLIG " (itoa a)
                     ", ELETROSUL " (itoa el) ") em " caminho)))))

(princ "cad-conta-auxiliares carregado: rode (pz-aux:dump)")
(princ)