del "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\*.pdb"
del "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\*.xml"
del "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\*dll.config"
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\ReportTemplates" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\app.publish" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\de" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\es" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\ja" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\nl" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\pt" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\pl" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\ru" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\sl" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\sv" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\tr" /s /q
rmdir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release\zh" /s /q
"C:\Program Files (x86)\WiX Toolset v3.14\bin\heat.exe" dir "..\..\TechnologyBSA.ALCE.Desktop\bin\Release" -dr Bin -cg ALCEDesktopGroup -gg -g1 -sf -srd -sreg -var "var.ALCEDesktopSourceDir" -o ".\GroupALCEDesktop.wxs"