; Positron — carregador opcional, para quem prefere digitar ELET em vez de NETLOAD.
;
; COMO USAR: ponha este arquivo (e a Positron.Plugin.ZWCAD.dll) numa pasta que esteja no
; caminho de suporte do ZWCAD (por exemplo a pasta Support do perfil), ou carregue este .lsp
; com APPLOAD. Depois, digitar ELET carrega a DLL pelo NOME (sem procurar o caminho) e abre a
; paleta de folhas.
;
; Preferindo nao digitar nada: use o autoload do .bundle (PackageContents.xml ao lado), que
; carrega a DLL na abertura do ZWCAD.
(defun c:ELET ( / dll)
  (setq dll (findfile "Positron.Plugin.ZWCAD.dll"))
  (if dll
    (progn
      (command "_.NETLOAD" dll)
      (command "_.FOLHAS"))
    (princ "\nPositron: a DLL nao esta no caminho de suporte - rode NETLOAD uma vez apontando o arquivo."))
  (princ))

(princ "\nPositron: digite ELET para carregar o plugin (ou use o autoload do .bundle).")
(princ)
