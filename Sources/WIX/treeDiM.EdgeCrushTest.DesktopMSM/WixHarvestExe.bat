erase /Q "..\..\TreeDim.EdgeCrushTest.Desktop\bin\Release\*.pdb"
erase /Q ""..\..\TreeDim.EdgeCrushTest.Desktop\bin\Release\*.xml"
"C:\Program Files (x86)\WiX Toolset v3.14\bin\heat.exe" dir "..\..\TreeDim.EdgeCrushTest.Desktop\bin\Release" -dr Bin -cg EdgeCrushTestDesktopGroup -gg -g1 -sf -srd -sreg -var "var.ECTDesktopSourceDir" -o ".\GroupEdgeCrushTestDesktop.wxs"