; Fixture do EDCON/EDCONP (rodada 176): no desenho aberto (o Funcional.dwg do harness, numa
; copia), acha a primeira LWPOLYLINE com CONEXAO tipo 1 e pendura nela textos AUXCONEXAO:
;
;   tipo 4 (cor), 5 (secao), 6 ("cor (secao)")  -> devem ser reescritos pelo EDCON
;   tipo 6 com handle de outra entidade          -> fica (o handle nao casa)
;   tipo 1                                       -> fica (o EDCON so olha 4/5/6)
;
; Uso (o dump roda DEPOIS do EDCON, como linha do script):
;
;   set POSITRON_EDCON_SAIDA=%TEMP%\positron-edcon.txt
;   powershell -File scripts/cad-zwcad-smoke.ps1 -Desenho ...\Funcional.dwg ^
;       -Fixture scripts/cad-fixture-edcon.lsp -Comandos "EDCON A _ALL  4 VM,(pz-edcon:dump)"
;
; Saida: ANTES;<total AUXCONEXAO no desenho>;<por tipo>  e  TEXTO;<rotulo>;<tipo>;<conteudo>
(setvar "CMDECHO" 0)
(regapp "AUXCONEXAO")

(defun pz-edcon:conexao (/ ss i e x achou)
  (setq ss (ssget "_X" '((0 . "LWPOLYLINE") (-3 ("CONEXAO")))) i 0)
  (while (and ss (not achou) (< i (sslength ss)))
    (setq e (ssname ss i)
          x (cdr (cadr (assoc -3 (entget e '("CONEXAO"))))))
    (if (= (cdr (nth 0 x)) 1) (setq achou e))
    (setq i (1+ i)))
  achou)

(defun pz-edcon:texto (rotulo tipo potencial handle / e)
  (command "_.TEXT" (list -1000.0 (* -10.0 tipo)) 2.5 0 rotulo)
  (setq e (entlast))
  (entmod (append (entget e)
    (list (list -3 (list "AUXCONEXAO"
      (cons 1070 tipo) (cons 1071 potencial) (cons 1000 handle) (cons 1000 "") (cons 1000 "")
      (cons 1071 0) (cons 1000 "ana") (cons 1000 "2026-10-15") (cons 1071 1) (cons 1040 0.0)
      (cons 1000 " "))))))
  (setq pz-edcon:textos (cons (cons rotulo e) pz-edcon:textos))
  e)

(defun pz-edcon:antes (/ ss i x tipos)
  (setq ss (ssget "_X" '((0 . "TEXT") (-3 ("AUXCONEXAO")))) i 0)
  (while (and ss (< i (sslength ss)))
    (setq x (cdr (cadr (assoc -3 (entget (ssname ss i) '("AUXCONEXAO")))))
          tipos (cons (cdr (nth 0 x)) tipos)
          i (1+ i)))
  (strcat "ANTES;" (itoa (if ss (sslength ss) 0)) ";" (vl-princ-to-string tipos)))

(setq pz-edcon:textos nil
      pz-edcon:linha-antes (pz-edcon:antes)
      pz-edcon:alvo (pz-edcon:conexao))
(if pz-edcon:alvo
  (progn
    (setq pz-edcon:x (cdr (cadr (assoc -3 (entget pz-edcon:alvo '("CONEXAO")))))
          pz-edcon:potencial (cdr (nth 1 pz-edcon:x))
          pz-edcon:handle (cdr (assoc 5 (entget pz-edcon:alvo))))
    (pz-edcon:texto "COR" 4 pz-edcon:potencial pz-edcon:handle)
    (pz-edcon:texto "SECAO" 5 pz-edcon:potencial pz-edcon:handle)
    (pz-edcon:texto "AMBAS" 6 pz-edcon:potencial pz-edcon:handle)
    (pz-edcon:texto "OUTRO-HANDLE" 6 pz-edcon:potencial "0")
    (pz-edcon:texto "TIPO1" 1 pz-edcon:potencial pz-edcon:handle)))

(defun pz-edcon:dump (/ f par)
  (setq f (open (getenv "POSITRON_EDCON_SAIDA") "w"))
  (write-line pz-edcon:linha-antes f)
  (write-line (strcat "ALVO;" (if pz-edcon:handle pz-edcon:handle "-") ";"
                      (if pz-edcon:potencial (itoa pz-edcon:potencial) "-")) f)
  (foreach par (reverse pz-edcon:textos)
    (write-line (strcat "TEXTO;" (car par) ";" (cdr (assoc 1 (entget (cdr par))))) f))
  (close f)
  (princ))
