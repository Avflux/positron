; Rodada 214: prova INDEPENDENTE de que a gravacao da unidade/alternativo CONSERVA o buffer do XData
; Eletron do layer de pagina (o `XDataGeral.AlteraXDataUnidadeAlternativo` troca so as posicoes 2/3).
; Roda em COPIA do Funcional.dwg (o harness copia o -Desenho).
;   - com POSITRON_UNIDADE_MONTAR=1 acrescenta DOIS valores ao XData Eletron do layer "6"
;     (um 1000 "EXTRA-214" e um 1070 214): sao o que o adapter antigo (que recriava os quatro)
;     apagava;
;   - (pz-uni:antes) e (pz-uni:depois) despejam os valores do Eletron dos layers 6/7/7A em
;     POSITRON_UNIDADE_SAIDA e POSITRON_UNIDADE_SAIDA_DEPOIS (leitura independente, entget).
;
; Medido (rodada 214): `(car (assoc -3 d))` NAO e o valor do XData — e a propria chave -3;
; o valor (a lista marcada com o app name) sai de `(cadr (assoc -3 d))`. Com `car` o `append`
; recebia -3 (nao-lista), estourava no load e os defuns seguintes nem eram criados.
(regapp "Eletron")

(defun pz-uni:extra (layer tag / d xd)
  (setq d (entget (tblobjname "LAYER" layer) '("Eletron")))
  (setq xd (cadr (assoc -3 d)))
  (if xd
    (entmod (append (vl-remove (assoc -3 d) d)
                    (list (list -3 (append xd (list (cons 1000 tag) (cons 1070 214)))))))))

(if (= (getenv "POSITRON_UNIDADE_MONTAR") "1")
  (pz-uni:extra "6" "EXTRA-214"))

(defun pz-uni:despeja (arq / f e)
  (if (and arq (> (strlen arq) 0))
    (progn
      (setq f (open arq "w"))
      (foreach p '("6" "7" "7A")
        (setq e (entget (tblobjname "LAYER" p) '("Eletron")))
        (write-line (strcat "LAYER;" p ";eletron="
                            (vl-princ-to-string (cdr (assoc "Eletron" (cdr (assoc -3 e)))))) f))
      (close f))))

(defun pz-uni:antes () (pz-uni:despeja (getenv "POSITRON_UNIDADE_SAIDA")) (princ))
(defun pz-uni:depois () (pz-uni:despeja (getenv "POSITRON_UNIDADE_SAIDA_DEPOIS")) (princ))
(princ)
