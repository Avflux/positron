; Rodada 221: o desenho da mMensagem 27 — o "Não há espaço suficiente!" da renumeração com
; destino da paleta (o `C8Op1CM1YgS`, `uscPaginas.cs:2247-2390`). A recusa sai quando as páginas
; **selecionadas** não cabem nem no espaço numérico nem no alfanumérico antes da próxima página
; NÃO selecionada (o limite `p` do original).
;
; A rodada 186 deixou a medição pendente com a premissa "precisa de 27 linhas selecionadas e o
; Funcional.dwg tem 16 páginas". A premissa é FALSA: o alfanumérico (`calculaEspacoAlfaNumerico`)
; conta 27 nomes POR NÚMERO (a página seca + A..Z), então o limite é uma **letra vizinha**, não a
; 27ª página. Duas rotas, por POSITRON_MSG27_MODO:
;
;   letra  — cria o layer "5A". Com o destino "5" e as páginas 6 e 7 selecionadas o limite é a
;            própria "5A" (5,65): o espaço numérico dá 1 (o `5`: floor(5,65) - 5 + 1) e o
;            alfanumérico também 1 (de 64='A'-1 a 65='A'), então DUAS selecionadas já não cabem.
;            Precisa de 2 páginas — é a rota medida na cópia do Funcional (16 páginas).
;
;   trinta — cria os layers das páginas 1..31 que faltam na cópia do Funcional, MENOS a "3" (o
;            destino livre: se ela existisse, a recusa seria a mMensagem 25, "já existe"). Com o
;            destino "3", a "4" como limite e 27 selecionadas, o ramo alfanumérico aplica (3,
;            3A..3Z); com 28, recusa. É a forma literal da premissa da rodada 186 (fronteira 27/28).
;
; Roda no load (antes do NETLOAD e do comando), na CÓPIA do desenho que o harness abre.
;
; (pz27:dump) escreve POSITRON_PAGINAS_SAIDA com uma linha por layer de página —
; "PAGINA;<nome>;xdata=<...>" e "TOTAL;<n>" — lido da tabela de LAYERS por AutoLISP puro (nenhum
; acesso ao plugin): é a prova independente do que a renumeração fez. Chamada no load para
; POSITRON_PAGINAS_SAIDA_ANTES, quando definida (o estado que a fixture montou).
(setvar "CMDECHO" 0)

(defun pz27:layer (nome)
  (if (not (tblsearch "LAYER" nome))
    (entmake (list '(0 . "LAYER")
                   '(100 . "AcDbSymbolTableRecord")
                   '(100 . "AcDbLayerTableRecord")
                   (cons 2 nome) '(70 . 0) '(62 . 7) '(6 . "CONTINUOUS")))))

(defun pz27:digito (c) (and (>= (ascii c) 48) (<= (ascii c) 57)))
(defun pz27:letra (c) (and (>= (ascii c) 65) (<= (ascii c) 90)))
(defun pz27:soDigitos (texto / n i ok)
  (setq n (strlen texto) i 1 ok (> n 0))
  (while (and ok (<= i n))
    (if (not (pz27:digito (substr texto i 1))) (setq ok nil))
    (setq i (1+ i)))
  ok)
; O nome é página? Mesma regra do `LayerValido` do reverso: número maior que ZERO (o layer "0"
; não conta), ou número seguido de dígito/letra MAIÚSCULA.
(defun pz27:ePagina (nome / n ultimo numero)
  (setq n (strlen nome) ultimo (substr nome n 1) numero nil)
  (if (pz27:letra ultimo)
    (if (pz27:soDigitos (substr nome 1 (1- n)))
      (setq numero (atoi (substr nome 1 (1- n)))))
    (if (pz27:soDigitos nome) (setq numero (atoi nome))))
  (and numero (> numero 0)))
(defun pz27:xdata (nome / e x)
  (setq e (tblobjname "LAYER" nome) x nil)
  (if e (setq x (cdr (assoc "Eletron" (cdr (assoc -3 (entget e '("Eletron"))))))))
  (if x (vl-princ-to-string x) "ausente"))

(defun pz27:dump-para (caminho / f tabela nome total)
  (if caminho
    (progn
      (setq f (open caminho "w") tabela (tblnext "LAYER" T) total 0)
      (if f
        (progn
          (while tabela
            (setq nome (cdr (assoc 2 tabela)))
            (if (pz27:ePagina nome)
              (progn
                (setq total (1+ total))
                (write-line (strcat "PAGINA;" nome ";xdata=" (pz27:xdata nome)) f)))
            (setq tabela (tblnext "LAYER")))
          (write-line (strcat "TOTAL;" (itoa total)) f)
          (close f)))))
  (princ))

(defun pz27:dump () (pz27:dump-para (getenv "POSITRON_PAGINAS_SAIDA")))

(defun pz27:montar (modo / i)
  (cond
    ((= modo "LETRA") (pz27:layer "5A"))
    ((= modo "TRINTA")
     (setq i 1)
     (while (<= i 31)
       ; A "3" fica de fora: é o destino da movimentação, que o original exige livre.
       (if (/= i 3) (pz27:layer (itoa i)))
       (setq i (1+ i))))))

(setq pz27:modo (strcase (if (getenv "POSITRON_MSG27_MODO") (getenv "POSITRON_MSG27_MODO") "")))
(pz27:montar pz27:modo)
(if (= pz27:modo "LETRA")
  (princ (strcat "\nFixtures 221: modo LETRA (layer 5A garantido)."))
  (if (= pz27:modo "TRINTA")
    (princ (strcat "\nFixtures 221: modo TRINTA (layers 1..31, sem a 3, garantidos)."))
    (princ (strcat "\nFixtures 221: sem POSITRON_MSG27_MODO - so o dump."))))

(pz27:dump-para (getenv "POSITRON_PAGINAS_SAIDA_ANTES"))
(princ)
