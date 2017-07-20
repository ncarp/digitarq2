set assemblies=System.dll,System.Web.dll,System.Data.dll,System.XML.dll,System.Drawing.dll,System.Management.dll

vbc /target:library /rootnamespace:blong.WebControls /optimize+ /reference:%assemblies% /out:blong.dll *.vb
pause