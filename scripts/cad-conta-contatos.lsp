;;; cad-conta-contatos.lsp — contingência independente do `CorrigeContatosAux`
;;; (frente 2 do §7.6, rodada 77), fora do plugin.
;;;
;;; O `-Fixture` carrega antes do NETLOAD e `(pz-cc:conta)` roda no fim do script,
;;; então a MESMA contagem serve para o antes (sem a ação) e o depois.
;;;
;;;   set POSITRON_XDATA=%TEMP%positron-contatos.txt
;;;   powershell -File scripts/cad-zwcad-smoke.ps1 -Fixture scripts/cad-conta-contatos.lsp \
;;;     -Comandos "CorrigeContatosAux,(pz-cc:conta)" ...
;;;
;;; Saída:
;;;
;;;   MODELO;<handle>;<bob>;<indexModelo>;<indexContato>;<handleContatoAux>;<outrosApps>
;;;   AUXILIAR;<handle>;<bob>;<indexModelo>;<indexContato>
;;;   TOTAL;modelos;<n>;preenchido;<p>;vazio;<v>;auxiliares;<a>;comOutrosApps;<o>
;;;
;;; A lista de app names vem da tabela **APPID do próprio desenho** (a lição das
;;; rodadas 70 e 75): o `entget` só devolve o grupo -3 dos app names que recebe.
(defun pz-cc:appids ( / t1 nomes)
  (setq nomes nil)
  (setq t1 (tblnext "APPID" T))
  (while t1 (setq nomes (cons (cdr (assoc 2 t1)) nomes)) (setq t1 (tblnext "APPID")))
  nomes)

(setq pz-cc:apps (pz-cc:appids))

(defun pz-cc:escreve (f s) (princ s f))

(defun pz-cc:texto (v)
  (if (null v)
    ""
    (if (= (type v) 'STR) v (vl-princ-to-string v))))

(defun pz-cc:eh-modelo (nome) (or (= nome "Modelo") (= nome "MODELO")))
(defun pz-cc:eh-disp (nome) (or (= nome "Dispositivo") (= nome "DISPOSITIVO")))

; Devolve (tipo linha) ou nil: "MODELO" / "AUXILIAR".
(defun pz-cc:linha (e / d x app nome mod disp outros linha)
  (setq d (entget e pz-cc:apps))
  (setq mod nil disp nil outros 0)
  (foreach app (cdr (assoc -3 d))
    (setq nome (car app))
    (if (pz-cc:eh-modelo nome)
      (setq mod (cdr app))
      (if (pz-cc:eh-disp nome) (setq disp (cdr app)) (setq outros (1+ outros)))))
  (if mod
    (list "MODELO"
          (strcat "MODELO;" (cdr (assoc 5 d))
                  ";" (pz-cc:texto (cdr (nth 0 mod)))
                  ";" (pz-cc:texto (cdr (nth 1 mod)))
                  ";" (pz-cc:texto (cdr (nth 2 mod)))
                  ";" (pz-cc:texto (cdr (nth 3 mod)))
                  ";" (itoa outros)))
    (if (and disp (= (strcase (pz-cc:texto (cdr (nth 0 disp)))) "A"))
      (list "AUXILIAR"
            (strcat "AUXILIAR;" (cdr (assoc 5 d))
                    ";" (pz-cc:texto (cdr (nth 3 disp)))
                    ";" (pz-cc:texto (cdr (nth 4 disp)))
                    ";" (pz-cc:texto (cdr (nth 5 disp)))))
      nil)))

(defun pz-cc:conta ( / caminho f sel i e r modelos preenchido vazio aux comOutros)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-contatos.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-contatos: falha ao abrir a saida")
    (progn
      (pz-cc:escreve f "MODELO;handle;bob;indexModelo;indexContato;handleContatoAux;outrosApps\n")
      (setq modelos 0 preenchido 0 vazio 0 aux 0 comOutros 0)
      (setq sel (ssget "_X"))
      (if (null sel)
        nil
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq r (pz-cc:linha e))
            (if r
              (progn
                (pz-cc:escreve f (strcat (nth 1 r) "\n"))
                (if (= (nth 0 r) "MODELO")
                  (progn
                    (setq modelos (1+ modelos))
                    (if (= (pz-cc:sub (nth 1 r) 5) "")
                      (setq vazio (1+ vazio))
                      (setq preenchido (1+ preenchido)))
                    (if (/= (pz-cc:sub (nth 1 r) 6) "0") (setq comOutros (1+ comOutros))))
                  (setq aux (1+ aux))))))))
      (pz-cc:escreve f (strcat "TOTAL;modelos;" (itoa modelos) ";preenchido;" (itoa preenchido)
                              ";vazio;" (itoa vazio) ";auxiliares;" (itoa aux)
                              ";comOutrosApps;" (itoa comOutros) "\n"))
      (close f)
      (princ (strcat "cad-conta-contatos: " (itoa modelos) " modelo(s) (" (itoa preenchido)
                     " preenchidos, " (itoa vazio) " vazios), " (itoa aux) " auxiliar(es)")))))

;; O campo n de uma linha separada por ";" (n=0 e o rotulo).
(defun pz-cc:sub (linha n / partes pos)
  (setq partes nil)
  (while (/= linha "")
    (setq pos (vl-string-search ";" linha))
    (if pos
      (progn
        (setq partes (cons (substr linha 1 pos) partes))
        (setq linha (substr linha (+ pos 2))))
      (progn
        (setq partes (cons linha partes))
        (setq linha ""))))
  (nth n (reverse partes)))

(princ "cad-conta-contatos carregado: rode (pz-cc:conta)")
(princ)