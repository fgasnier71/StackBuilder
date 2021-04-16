del "..\..\Test\treeDiM.StackBuilder.WCFService.Test\bin\Release\*.pdb"
del "..\..\Test\treeDiM.StackBuilder.WCFService.Test\bin\Release\*.xml"
rmdir "..\..\Test\treeDiM.StackBuilder.WCFService.Test\bin\Release\app.publish" /s /q
rmdir "..\..\Test\treeDiM.StackBuilder.WCFService.Test\bin\Debug" /s /q
rmdir "..\..\Test\treeDiM.StackBuilder.WCFService.Test\obj" /s /q
"C:\Program Files (x86)\WiX Toolset v3.14\bin\heat.exe" dir "..\..\Test\treeDiM.StackBuilder.WCFService.Test" -dr Bin -cg WCFServiceTestGroup -gg -g1 -sf -srd -sreg -var "var.WCFServiceTestSourceDir" -o ".\GroupWCFServiceTest.wxs"