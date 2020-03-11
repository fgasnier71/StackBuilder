del "..\..\TreeDim.StackBuilder.Desktop\bin\Release\*.pdb"
del "..\..\TreeDim.StackBuilder.Desktop\bin\Release\*.xml"
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\ReportTemplates" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\app.publish" /s /q
"C:\Program Files (x86)\WiX Toolset v3.14\bin\heat.exe" dir "..\..\TreeDim.StackBuilder.Desktop\bin\Release" -dr Bin -cg StackBuilderDesktopGroup -gg -g1 -sf -srd -sreg -var "var.StackBuilderDesktopSourceDir" -o ".\GroupStackBuilderDesktop.wxs"