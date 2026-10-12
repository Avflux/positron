; Positron - carregador opcional, para quem prefere digitar ELET em vez de NETLOAD.
;
; COMO USAR: ponha este arquivo e a DLL da plataforma (Positron.Plugin.ZWCAD.dll ou
; Positron.Plugin.AutoCAD.dll) numa pasta do caminho de suporte do CAD, ou carregue este .lsp com
; APPLOAD. Depois, digitar ELET carrega a DLL pelo NOME (sem procurar o caminho) e abre a paleta
; de folhas.
;
; Preferindo nao digitar nada: use o autoload do .bundle (PackageContents.xml ao lado) - o
; scripts/instala-bundle.ps1 instala nos dois CADs. Nao use os dois ao mesmo tempo: aqui o c:ELET
; e um comando LISP e, carregado, ele fica na frente do ELET do plugin.
(defun c:ELET ( / dll)
  (setq dll (findfile "Positron.Plugin.ZWCAD.dll"))
  (if (null dll) (setq dll (findfile "Positron.Plugin.AutoCAD.dll")))
  (if dll
    (progn
      (command "_.NETLOAD" dll)
      (command "_.FOLHAS"))
    (princ "\nPositron: a DLL nao esta no caminho de suporte - rode NETLOAD uma vez apontando o arquivo."))
  (princ))

(princ "\nPositron: digite ELET para carregar o plugin (ou use o autoload do .bundle).")
(princ)
