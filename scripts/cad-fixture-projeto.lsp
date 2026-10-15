; Fixture da rodada 180 (projeto por desenho): nao monta nada; (pz-proj:dump) grava em
; POSITRON_PROJ_SAIDA o nome do desenho e os XData EletronProj e Eletron do ModelSpace
; (o que o plugin le como projeto ativo), pela API ActiveX (o ModelSpace e um BlockTableRecord).
(vl-load-com)
(setvar "CMDECHO" 0)
(defun pz-proj:xd (app / ms tipos valores)
  (setq ms (vla-get-ModelSpace (vla-get-ActiveDocument (vlax-get-acad-object))))
  (vla-GetXData ms app 'tipos 'valores)
  (if valores
    (mapcar 'vlax-variant-value (vlax-safearray->list valores))))
; Com POSITRON_PROJ_MARCAR, marca o desenho como do Eletron (o app `Eletron` no ModelSpace, o
; tipo "E" do verificaTipoXData) sem o EletronProj: o desenho novo de um projeto ainda sem banco.
(if (getenv "POSITRON_PROJ_MARCAR")
  (progn
    (regapp "Eletron")
    (vla-SetXData (vla-get-ModelSpace (vla-get-ActiveDocument (vlax-get-acad-object)))
      (vlax-make-variant (vlax-safearray-fill (vlax-make-safearray vlax-vbInteger '(0 . 1)) '(1001 1000)))
      (vlax-make-variant (vlax-safearray-fill (vlax-make-safearray vlax-vbVariant '(0 . 1)) '("Eletron" "Marca"))))))

(defun pz-proj:dump (/ f p c)
  (setq f (open (getenv "POSITRON_PROJ_SAIDA") "w"))
  (write-line (strcat "DESENHO;" (getvar "DWGNAME")) f)
  (setq p (pz-proj:xd "EletronProj"))
  (write-line (strcat "ELETRONPROJ;" (if p (vl-princ-to-string p) "(sem)")) f)
  (setq c (pz-proj:xd "Eletron"))
  (write-line (strcat "CONFIG;" (if c (strcat (itoa (length c)) " valor(es)") "(sem)")) f)
  (close f)
  (princ))
(princ)
