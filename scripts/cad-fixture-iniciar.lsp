; Fixture da rodada 181 (o resto do IniciarDWG). Com POSITRON_R181_MONTAR monta o que as duas
; correcoes novas olham, no desenho NOVO (nada disso e criado pelo recoder, e do original que a
; correcao de migracao tira):
;   - duas LINE, uma com XData CONEXAO e outra com INTERLIGACAO (o resto da versao antiga);
;   - tres TEXT com XData AUXCONEXAO: tipo 1 com VerticalMode 1 (o que a correcao alinha) e dois
;     controles que NAO podem ser tocados (tipo 1 com VerticalMode 0 e tipo 4 com VerticalMode 1);
;   - o app Eletron no ModelSpace (o desenho passa a ser do tipo "E", a barra inteira ligada) —
;     pelo ActiveX, que so existe com interface; sem ele o desenho fica tipo V e as correcoes
;     rodam do mesmo jeito (o bloco do lDwgRegen nao depende do tipo).
; Sem POSITRON_R181_MONTAR o arquivo so define o instrumento, para rodar em desenho de verdade.
;
; O (pz-iniciar:dump) despeja em POSITRON_DUMP: o tipo do desenho, o estado do XData CORRECAO (as
; cinco marcas), o estilo Romans, a camada corrente com o numero de layers ligados e o estado de
; cada LINE/TEXT (os apps e o VerticalMode) — a leitura e independente do plugin (entget e
; tblsearch, nao o codigo do recoder).
(setvar "CMDECHO" 0)

; Cada leitura vai por aqui: um erro de leitura nao pode abortar o despejo inteiro (o buffer do
; arquivo fica sem o `close` e o que ja foi escrito se perde).
(defun pz-iniciar:certo (fn / r)
  (setq r (vl-catch-all-apply fn nil))
  (if (vl-catch-all-error-p r) (strcat "(erro: " (vl-catch-all-error-message r) ")") r))

; O XData do ModelSpace so sai pelo ActiveX: o `entget` do BlockTableRecord nao devolve o grupo
; -3 (medido nesta rodada no Funcional.dwg), e no accoreconsole o ActiveX nem existe (o
; `vlax-get-acad-object` devolve nil e o `vla-GetXData` morre com "bad argument type:"). Por isso
; o despejo do CORRECAO so sai na interface cheia; no accoreconsole quem vale sao as leituras por
; entget (as LINE e os TEXT).
(defun pz-iniciar:xd-ms (app / ms tipos valores)
  (vl-load-com)
  (setq ms (vla-get-ModelSpace (vla-get-ActiveDocument (vlax-get-acad-object))))
  (vla-GetXData ms app 'tipos 'valores)
  (if valores (mapcar 'vlax-variant-value (vlax-safearray->list valores))))

; O tipo do desenho pelas proprias apps do ModelSpace (o verificaTipoXData, lido de fora do plugin).
(defun pz-iniciar:tipo ()
  (cond ((pz-iniciar:xd-ms "Eletron") "E")
        ((pz-iniciar:xd-ms "DiagLog") "D")
        ((pz-iniciar:xd-ms "ArqNet") "A")
        (T "V")))

; O bloco do app na entidade (com o app name na frente), ou nil quando a entidade nao o tem.
; O grupo -3 traz uma LISTA de blocos (`(-3 ((APP (1000 . valor))))`): o bloco do app pedido e o
; primeiro.
(defun pz-iniciar:xd-ent (e app)
  (car (cdr (assoc -3 (entget e (list app))))))

; O estado do app na entidade: sem o grupo -3 (nao tem o app), "marca vazia" (o app name ficou
; sozinho — o estado que o `LimpaXData` do original deixa) ou quantos valores sobraram.
(defun pz-iniciar:estado (e app / bloco)
  (setq bloco (pz-iniciar:xd-ent e app))
  (cond ((null bloco) "sem")
        ((null (cdr bloco)) "marca vazia")
        (T (strcat (itoa (length (cdr bloco))) " valor(es)"))))

; Quantos layers estao ligados (a pagina ativa desliga o resto) — a prova da pagina ativa ao abrir.
(defun pz-iniciar:camadas-ligadas (/ camada cor n)
  (setq n 0)
  (setq camada (tblnext "LAYER" T))
  (while camada
    (setq cor (cdr (assoc 62 camada)))
    (if (not (and cor (< cor 0))) (setq n (1+ n)))
    (setq camada (tblnext "LAYER")))
  n)

; Valores do XData AUXCONEXAO no layout do original (XDataConexao.GravarXDataAuxCircuito): depois
; do app name vem o TIPO (1070), o potencial (1071), o handle (1000) e o enderecamento (1071).
; Sem string vazia: o entmake descarta o valor 1000 "" e o buffer sai torto (medido nesta rodada).
(defun pz-iniciar:aux (tipo)
  (list -3 (list "AUXCONEXAO"
                 (cons 1070 tipo) (cons 1071 0) (cons 1000 "handle")
                 (cons 1000 "a") (cons 1000 "b") (cons 1071 0)
                 (cons 1000 "c") (cons 1000 "d") (cons 1000 "e"))))

(defun pz-iniciar:texto (y vmode tipo rotulo)
  (entmake (list '(0 . "TEXT") '(100 . "AcDbEntity") '(8 . "0") '(100 . "AcDbText")
                 (list 10 0.0 y 0.0) '(40 . 2.5) (cons 1 rotulo) (cons 73 vmode)
                 (list 11 20.0 y 0.0) (pz-iniciar:aux tipo))))

(defun pz-iniciar:montar ()
  (vl-load-com)
  (regapp "Eletron")
  (pz-iniciar:certo (function (lambda ()
    (vla-SetXData (vla-get-ModelSpace (vla-get-ActiveDocument (vlax-get-acad-object)))
      (vlax-make-variant (vlax-safearray-fill (vlax-make-safearray vlax-vbInteger '(0 . 1)) '(1001 1000)))
      (vlax-make-variant (vlax-safearray-fill (vlax-make-safearray vlax-vbVariant '(0 . 1)) '("Eletron" "Marca")))))))

  (regapp "CONEXAO")
  (regapp "INTERLIGACAO")
  (entmake (list '(0 . "LINE") '(100 . "AcDbEntity") '(8 . "0") '(100 . "AcDbLine")
                 '(10 0.0 0.0 0.0) '(11 5.0 0.0 0.0)
                 (list -3 (list "CONEXAO" (cons 1000 "resto da versao antiga") (cons 1070 1)))))
  (entmake (list '(0 . "LINE") '(100 . "AcDbEntity") '(8 . "0") '(100 . "AcDbLine")
                 '(10 0.0 20.0 0.0) '(11 5.0 20.0 0.0)
                 (list -3 (list "INTERLIGACAO" (cons 1000 "resto da versao antiga") (cons 1070 1)))))

  (regapp "AUXCONEXAO")
  (pz-iniciar:texto 40.0 1 1 "circuito tipo 1 vmode 1")
  (pz-iniciar:texto 50.0 0 1 "circuito tipo 1 vmode 0")
  (pz-iniciar:texto 60.0 1 4 "secao tipo 4 vmode 1")
  (princ "\nfixture: 2 Line e 3 TEXT montados (um de cada controle)"))

(if (getenv "POSITRON_R181_MONTAR") (pz-iniciar:montar))

; Uma linha por entidade do espaco corrente.
(defun pz-iniciar:entidades (f / e d xd)
  (setq e (entnext))
  (while e
    (setq d (entget e))
    (if (= "LINE" (cdr (assoc 0 d)))
      (pz-iniciar:linha f e d))
    (if (= "TEXT" (cdr (assoc 0 d)))
      (progn
        (setq xd (pz-iniciar:xd-ent e "AUXCONEXAO"))
        (if xd (pz-iniciar:texto-linha f e d xd))))
    (setq e (entnext e))))

(defun pz-iniciar:linha (f e d / saida)
  (setq saida "")
  (foreach app '("CONEXAO" "INTERLIGACAO")
    (setq saida (strcat saida ";" app "=" (pz-iniciar:estado e app))))
  (write-line (strcat "LINE;" (cdr (assoc 5 d)) saida) f))

; A linha do texto passa pelo `certo`: se a leitura estourar, a mensagem entra no despejo em vez de
; abortar o laco (e o arquivo sem `close` perde o que ja foi escrito).
(defun pz-iniciar:texto-linha (f e d xd)
  (write-line (strcat "TEXT-BRUTO;" (cdr (assoc 5 d)) ";" (vl-princ-to-string xd)) f)
  (write-line (pz-iniciar:certo 'pz-iniciar:texto-resumo) f))

; `d` e `xd` sao do chamador (o escopo do AutoLISP e dinamico).
(defun pz-iniciar:texto-resumo ()
  (strcat "TEXT;" (cdr (assoc 5 d))
          ";tipo=" (vl-princ-to-string (cdr (assoc 1070 (cdr xd))))
          ";vertical=" (vl-princ-to-string (pz-iniciar:vertical d))
          ";texto=" (cdr (assoc 1 d))))

; O modo vertical do texto: o DXF 73, que o CAD omite quando e 0 (o Baseline).
(defun pz-iniciar:vertical (d / v)
  (setq v (cdr (assoc 73 d)))
  (if v v 0))

(defun pz-iniciar:dump (/ f d)
  (setq f (open (getenv "POSITRON_DUMP") "w"))
  (if (null f)
    (princ "\npz-iniciar:dump: nao consegui abrir a saida")
    (progn
      (write-line (strcat "TIPO;" (pz-iniciar:certo 'pz-iniciar:tipo)) f)
      (write-line (strcat "DESENHO;" (getvar "DWGNAME")) f)
      (setq d (pz-iniciar:certo (function (lambda () (pz-iniciar:xd-ms "CORRECAO")))))
      (write-line (strcat "CORRECAO;" (if d (vl-princ-to-string d) "(sem)")) f)
      (write-line (strcat "ROMANS;" (if (tblsearch "STYLE" "Romans") "sim" "nao")) f)
      (write-line (strcat "CAMADAS;corrente=" (getvar "CLAYER")
                          ";ligadas=" (itoa (pz-iniciar:camadas-ligadas))) f)
      (pz-iniciar:entidades f)
      (close f)
      (princ "\npz-iniciar:dump: despejo gravado"))))
(princ)
