;;; cad-conta-mascaras.lsp — contingência independente do `corrigeDicMascaras`
;;; (frente 2 do §7.6, rodada 76), fora do plugin.
;;;
;;; O `-Fixture` carrega antes do NETLOAD e `(pz-masc:conta)` roda no fim do
;;; script, então a MESMA contagem serve para o antes (sem a ação) e o depois.
;;;
;;;   set POSITRON_XDATA=%TEMP%positron-mascaras.txt
;;;   powershell -File scripts/cad-zwcad-smoke.ps1 -Fixture scripts/cad-conta-mascaras.lsp \
;;;     -Comandos "corrigeDicMascaras,(pz-masc:conta)" ...
;;;
;;; Saída (uma linha por modelo + o total):
;;;
;;;   MODELO;<indice>;<header>;<n portas>;<indices>;<duplicadas>
;;;   TOTAL;modelos;<n>;portas;<p>;duplicadas;<d>;header_zero;<z>
;;;
;;; O registro de um XRECORD sai no `entget` DEPOIS do grupo 280 (medido), então a
;;; contagem usa os valores crus: o primeiro é o `MaxIndice` e cada porta ocupa 8.
;;; Nenhum app name entra aqui (não há `-3`): é o próprio XRECORD do dicionário.
(defun pz-masc:escreve (f s) (princ s f))

(defun pz-masc:texto (v)
  (if (null v)
    ""
    (if (= (type v) 'STR) v (vl-princ-to-string v))))

(defun pz-masc:valores (d)
  (mapcar 'cdr (cdr (member (assoc 280 d) d))))

(defun pz-masc:linha (chave vals / cab i inds vistos dups n)
  (setq cab (nth 0 vals) i 1 inds "" vistos nil dups 0 n 0)
  (while (< i (length vals))
    (setq n (1+ n))
    (setq inds (strcat inds (if (= inds "") "" ",") (pz-masc:texto (nth i vals))))
    (if (member (nth i vals) vistos)
      (setq dups (1+ dups))
      (setq vistos (cons (nth i vals) vistos)))
    (setq i (+ i 8)))
  (list (strcat "MODELO;" chave ";" (pz-masc:texto cab) ";" (itoa n) ";" inds ";" (itoa dups))
        n dups cab))

(defun pz-masc:conta ( / caminho f d item r vals linha total modelos portas dups zeros)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-mascaras.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-mascaras: falha ao abrir a saida")
    (progn
      (pz-masc:escreve f "MODELO;indice;header;portas;indices;duplicadas\n")
      (setq total 0 modelos 0 portas 0 dups 0 zeros 0)
      (setq d (dictsearch (namedobjdict) "MASCARAS"))
      (if (null d)
        (pz-masc:escreve f "SEM MASCARAS\n")
        (foreach item d
          (if (and (= (car item) 3) (/= (cdr item) "MODELOS2"))
            (progn
              (setq r (dictsearch (cdr (assoc -1 d)) (cdr item)))
              (if r
                (progn
                  (setq vals (pz-masc:valores (entget (cdr (assoc -1 r)))))
                  (setq linha (pz-masc:linha (cdr item) vals))
                  (pz-masc:escreve f (strcat (nth 0 linha) "\n"))
                  (setq modelos (1+ modelos))
                  (setq portas (+ portas (nth 1 linha)))
                  (setq dups (+ dups (nth 2 linha)))
                  (if (= (pz-masc:texto (nth 3 linha)) "0") (setq zeros (1+ zeros)))))))))
      (pz-masc:escreve f (strcat "TOTAL;modelos;" (itoa modelos) ";portas;" (itoa portas)
                              ";duplicadas;" (itoa dups) ";header_zero;" (itoa zeros) "\n"))
      (close f)
      (princ (strcat "cad-conta-mascaras: " (itoa modelos) " modelo(s), " (itoa portas)
                     " porta(s), " (itoa dups) " duplicada(s), " (itoa zeros) " com header 0")))))

(princ "cad-conta-mascaras carregado: rode (pz-masc:conta)")
(princ)