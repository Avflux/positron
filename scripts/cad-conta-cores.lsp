;;; cad-conta-cores.lsp — contingencia independente do `CorrigeCoresDosBlocos` (frente 2
;;; do §7.6, rodada 88), fora do plugin.
;;;
;;; Monta a lista dos nomes de bloco inseridos com QUALQUER XData (a passada 1 do
;;; original), le a cor de cada ATTDEF da definicao e compara com a cor do ATTRIB das
;;; insercoes cujo `Name.ToUpper` entra na lista.
;;;
;;;   COR;handle;nome;tag;corRef;corDef   (so quando difere)
;;;   TOTAL;nomes;<n>;definicoes;<d>;diferencas;<x>
(defun pz-cor:escreve (f s) (princ s f))

(defun pz-cor:texto (v)
  (if (null v) "" (if (= (type v) (quote STR)) v (vl-princ-to-string v))))

; A lista FIXA dos app names que o desenho usa (a `tblnext` sobre o APPID estourava no
; ZWCAD; a licao da rodada 75 e que a lista precisa ser conhecida).
(defun pz-cor:apps ()
  (list "Dispositivo" "Modelo" "MODELO" "CONEXAO" "INTERLIGACAO" "AUXINTERLIG"
        "BORNE" "BORNES" "Fiacao" "MASCARAS" "CONTATOS" "CENG_LAYOUT"
        "Plaqueta" "TextoLP" "ELETROSUL" "DiagLog" "AUXCONEXAO" "Construtor"))

(defun pz-cor:cor (d)
  (if (assoc 62 d) (cdr (assoc 62 d)) 256))

; A cor de um ATTDEF da definicao, pelo tag.
(defun pz-cor:def (nome tag / b e d achou)
  (setq achou nil b (tblobjname "BLOCK" nome))
  (if b
    (progn
      (setq e (entnext b))
      (while (and e (/= (cdr (assoc 0 (entget e))) "ENDBLK"))
        (setq d (entget e))
        (if (and (= (cdr (assoc 0 d)) "ATTDEF")
                 (= (strcase (pz-cor:texto (cdr (assoc 2 d)))) (strcase tag)))
          (setq achou (pz-cor:cor d)))
        (setq e (entnext e)))))
  achou)

(defun pz-cor:conta ( / caminho f apps sel i e d nome nomes difs defs m corDef corRef)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-cores.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-conta-cores: falha ao abrir a saida")
    (progn
      (setq apps (pz-cor:apps))
      (pz-cor:escreve f "COR;handle;nome;tag;corRef;corDef\n")
      (setq nomes nil sel (ssget "_X" (list (cons 0 "INSERT"))))
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq nome (pz-cor:texto (cdr (assoc 2 d))))
            (if (and (cdr (assoc -3 (entget e apps))) (not (member nome nomes)))
              (setq nomes (cons nome nomes)))))
; as definicoes (uma vez por nome)
      (setq defs 0)
      (foreach nome nomes
        (setq b (tblobjname "BLOCK" nome))
        (if b
          (progn
            (setq e (entnext b))
            (while (and e (/= (cdr (assoc 0 (entget e))) "ENDBLK"))
              (if (= (cdr (assoc 0 (entget e))) "ATTDEF") (setq defs (1+ defs)))
              (setq e (entnext e))))))
; as referencias
      (setq difs 0 m 0)
      (if sel
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e))
            (setq nome (pz-cor:texto (cdr (assoc 2 d))))
            (if (member (strcase nome) (mapcar (quote strcase) nomes))
              (progn
                (setq a (entnext e))
                (while (and a (= (cdr (assoc 0 (entget a))) "ATTRIB"))
                  (setq da (entget a))
                  (setq corRef (pz-cor:cor da))
                  (setq corDef (pz-cor:def nome (cdr (assoc 2 da))))
                  (if (and corDef (/= corRef corDef))
                    (progn
                      (setq difs (1+ difs))
                      (pz-cor:escreve f (strcat "COR;" (pz-cor:texto (cdr (assoc 5 d))) ";"
                                                nome ";" (pz-cor:texto (cdr (assoc 2 da))) ";"
                                                (itoa corRef) ";" (itoa corDef) "\n"))))
                  (setq a (entnext a)))))))
      (pz-cor:escreve f (strcat "TOTAL;nomes;" (itoa (length nomes)) ";definicoes;" (itoa defs)
                                ";diferencas;" (itoa difs) "\n"))
      (close f)
      (princ (strcat "cad-conta-cores: " (itoa (length nomes)) " nome(s), " (itoa difs) " diferenca(s)")))))))

(princ "contador de cores carregado: rode (pz-cor:conta)")
(princ)