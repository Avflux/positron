;;; cad-conta-contatos-aux.lsp — contingencia independente do `CorrigeBlocosContatosAux`
;;; (frente 2 do §7.6, rodada 85), fora do plugin.
;;;
;;; Conta, para cada bloco do desenho com o XData `Dispositivo` de tipo `A`, o par
;;; `IndexModelo`/`IndexContato` do XData `Modelo` e os atributos T1/T2/T3 — o antes e o
;;; depois saem do mesmo script (o `-Fixture` carrega antes do NETLOAD e `(pz-ca:conta)`
;;; roda no fim).
;;;
;;;   BLOCO;<handle>;<nome>;<indexModelo>;<indexContato>;<T1>;<T2>;<T3>
;;;   TOTAL;blocos;<n>;comModelo;<m>
(defun pz-ca:escreve (f s) (princ s f))

(defun pz-ca:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

(defun pz-ca:xdata (e app / d r)
  (setq d (entget e (list app)))
  (setq r (car (cdr (assoc -3 d))))
  (if r (mapcar (quote cdr) (cdr r)) nil))

(defun pz-ca:atribs (bloco / e d saida t1 t2 t3 tag val)
  (setq saida (list "" "" "") e (entnext bloco))
  (while (and e (= (cdr (assoc 0 (entget e))) "ATTRIB"))
    (setq d (entget e))
    (setq tag (strcase (pz-ca:texto (cdr (assoc 2 d)))))
    (setq val (pz-ca:texto (cdr (assoc 1 d))))
    (if (= tag "T1") (setq saida (list val (nth 1 saida) (nth 2 saida))))
    (if (= tag "T2") (setq saida (list (nth 0 saida) val (nth 2 saida))))
    (if (= tag "T3") (setq saida (list (nth 0 saida) (nth 1 saida) val)))
    (setq e (entnext e)))
  saida)

(defun pz-ca:conta ( / caminho f sel i e d disp modelo tipo im ic atr n m)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-contatos-aux.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-contatos-aux: falha ao abrir a saida")
    (progn
      (pz-ca:escreve f "BLOCO;handle;nome;indexModelo;indexContato;T1;T2;T3\n")
      (setq n 0 m 0)
      (setq sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq disp (pz-ca:xdata e "Dispositivo"))
            (setq tipo (if disp (pz-ca:texto (nth 0 disp)) ""))
            (if (= (strcase tipo) "A")
              (progn
                (setq n (1+ n))
                ;; O `array[5]`/`array[6]` do `LeXDataQualquerDispositivo` — aqui
                ;; sem o 1001, entao os valores sao (nth 4) e (nth 5).
                (setq im (if disp (pz-ca:texto (nth 4 disp)) ""))
                (setq ic (if disp (pz-ca:texto (nth 5 disp)) ""))
                (if disp (setq m (1+ m)))
                (setq atr (pz-ca:atribs e))
                (pz-ca:escreve f (strcat "BLOCO;" (pz-ca:texto (cdr (assoc 5 d))) ";"
                                         (pz-ca:texto (cdr (assoc 2 d))) ";" im ";" ic ";"
                                         (nth 0 atr) ";" (nth 1 atr) ";" (nth 2 atr) "\n")))))
      (pz-ca:escreve f (strcat "TOTAL;blocos;" (itoa n) ";comModelo;" (itoa m) "\n"))
      (close f)
      (princ (strcat "cad-conta-contatos-aux: " (itoa n) " bloco(s) A")))))))

(princ "contador de contatos auxiliares carregado: rode (pz-ca:conta)")
(princ)