; Fixture do CorrigeContatosAux (ver docs/RUNBOOK.md, rodada 77): monta dois blocos
; auxiliares (tipo A) e quatro blocos de modelo (XData Modelo), com os tres casos:
;
;   - M1 casa com A1 (bob 1A, modelo 5, contato 2) e estava vazio;
;   - M2 casa com A2 (bob 1A, modelo 5, contato 9) e estava vazio;
;   - M3 nao casa com ninguem (fica vazio, como no original);
;   - M4 casa com A1 e estava com um handle errado (ZZZ).
;
; Esperado: 3 de 4 modelos acertados (2 auxiliares lidos; 1 sem contato casado) e, na
; segunda passada, 0 de 4 - a convergencia. O dump mostra o HandleContatoAux de cada um.
(setvar "CMDECHO" 0)
(regapp "Dispositivo")
(regapp "Modelo")
(command "_.LAYER" "_M" "12" "")

; XData do auxiliar (tipo A) no layout do `LeXDataQualquerDispositivo`: os campos que
; o leitor usa sao o +1 (tipo), +4 (bob), +5 (indexModelo), +6 (indexContato) e +7.
(defun pz-ca:xdata-aux (bob indexModelo indexContato)
  (list -3
    (list "Dispositivo"
      (cons 1000 "A") (cons 1000 "N1") (cons 1000 "N2")
      (cons 1000 bob) (cons 1071 indexModelo) (cons 1071 indexContato)
      (cons 1070 0) (cons 1070 0) (cons 1000 "") (cons 1000 "") (cons 1000 ""))))

; XData do modelo (app name `Modelo`): bob, indexModelo, indexContato e o
; HandleContatoAux que a correcao preenche.
(defun pz-ca:xdata-modelo (bob indexModelo indexContato handleContatoAux)
  (list -3
    (list "Modelo"
      (cons 1000 bob) (cons 1071 indexModelo) (cons 1071 indexContato)
      (cons 1000 handleContatoAux))))

(defun pz-ca:bloco (nome)
  (entmake (list '(0 . "BLOCK") '(100 . "AcDbEntity") '(8 . "0") '(100 . "AcDbBlockBegin")
                 (cons 2 nome) '(70 . 0) (list 10 0.0 0.0 0.0) (cons 3 nome) '(1 . "")))
  (entmake '((0 . "ENDBLK") (100 . "AcDbEntity") (8 . "0") (100 . "AcDbBlockEnd"))))

(defun pz-ca:insert (nome x y xdata / e)
  (setq e (entmakex (list '(0 . "INSERT") '(100 . "AcDbEntity") '(8 . "0")
                          '(100 . "AcDbBlockReference") (cons 2 nome) (list 10 x y 0.0))))
  (entmod (append (entget e) (list xdata)))
  e)

(pz-ca:bloco "PZCONTATO")
; Auxiliares (tipo A).
(pz-ca:insert "PZCONTATO" 0.0 0.0 (pz-ca:xdata-aux "1A" 5 2))
(pz-ca:insert "PZCONTATO" 5.0 0.0 (pz-ca:xdata-aux "1A" 5 9))
; Modelos.
(pz-ca:insert "PZCONTATO" 0.0 5.0 (pz-ca:xdata-modelo "1A" 5 2 ""))
(pz-ca:insert "PZCONTATO" 5.0 5.0 (pz-ca:xdata-modelo "1A" 5 9 ""))
(pz-ca:insert "PZCONTATO" 10.0 5.0 (pz-ca:xdata-modelo "2B" 1 1 ""))
(pz-ca:insert "PZCONTATO" 15.0 5.0 (pz-ca:xdata-modelo "1A" 5 2 "ZZZ"))

(defun pz-ca:escreve (f s) (princ s f))

(defun pz-ca:texto (v)
  (if (null v)
    ""
    (if (= (type v) 'STR) v (vl-princ-to-string v))))

; Uma linha por bloco de modelo: handle, bob, indices e o HandleContatoAux gravado.
(defun pz-ca:dump ( / caminho f sel i e d x app vals linha)
  (setq caminho (getenv "POSITRON_XDATA"))
  (if (or (null caminho) (= caminho ""))
    (setq caminho (strcat (getenv "TEMP") "/positron-contatos.txt")))
  (setq f (open caminho "w"))
  (if (null f)
    (princ "cad-fixture-contatos: falha ao abrir a saida")
    (progn
      (pz-ca:escreve f "MODELO;handle;bob;indexModelo;indexContato;handleContatoAux\n")
      (setq sel (ssget "_X" '((0 . "INSERT"))))
      (if (null sel)
        nil
        (progn
          (setq i (sslength sel))
          (while (> i 0)
            (setq i (1- i))
            (setq e (ssname sel i))
            (setq d (entget e '("Modelo" "MODELO")))
            (setq x (cdr (assoc -3 d)))
            (foreach app x
              (if (or (= (car app) "Modelo") (= (car app) "MODELO"))
                (progn
                  (setq vals (mapcar 'cdr (cdr app)))
                  (pz-ca:escreve f (strcat "MODELO;" (cdr (assoc 5 d))
                                           ";" (pz-ca:texto (nth 0 vals))
                                           ";" (pz-ca:texto (nth 1 vals))
                                           ";" (pz-ca:texto (nth 2 vals))
                                           ";" (pz-ca:texto (nth 3 vals)) "\n"))))))))
      (close f)
      (princ (strcat "cad-fixture-contatos: escrito em " caminho)))))

(princ "fixture de contatos auxiliares montada (2 auxiliares e 4 modelos)")
(princ)