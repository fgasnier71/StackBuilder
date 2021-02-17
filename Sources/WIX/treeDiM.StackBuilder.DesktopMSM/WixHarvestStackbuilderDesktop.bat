del "..\..\TreeDim.StackBuilder.Desktop\bin\Release\*.pdb"
del "..\..\TreeDim.StackBuilder.Desktop\bin\Release\*.xml"
rmdir  "..\..\TreeDim.StackBuilder.Desktop\bin\Release\ar" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\arm" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\arm64" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\ja-JP" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\pt-BR" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\zh-TW" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\zh-CN" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\th" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\da" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\sk" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\ReportTemplates" /s /q
rmdir "..\..\TreeDim.StackBuilder.Desktop\bin\Release\app.publish" /s /q
"C:\Program Files (x86)\WiX Toolset v3.14\bin\heat.exe" dir "..\..\TreeDim.StackBuilder.Desktop\bin\Release" -dr Bin -cg StackBuilderDesktopGroup -gg -g1 -sf -srd -sreg -var "var.StackBuilderDesktopSourceDir" -o ".\GroupStackBuilderDesktop.wxs"