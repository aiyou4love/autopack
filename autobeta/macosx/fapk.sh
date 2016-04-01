#!/bin/sh
mono autotool/autopack.exe -b xml/build/betaCommand.xml xml/bundle.xml
mono autotool/autopack.exe -b xml/build/inhouseCommand.xml xml/bundle.xml
security unlock-keychain -p listlist
betadir=Desktop/MobaBeta/beta/Moba_Phone_Game/Moba_Phone_Code
inhousedir=Desktop/MobaBeta/inhouse/Moba_Phone_Game/Moba_Phone_Code
betasign="iPhone Distribution: Shanghai Gsoft Information Technology Co., Ltd. (PY2ALEBEQ8)"
inhousesign="iPhone Distribution: Shanghai Gsoft Information Technology CO., Ltd."
cd
cd $betadir/Ios_Client
xcodebuild -project Moba_Game.xcodeproj -sdk iphoneos -scheme "Moba_Game" -configuration "Release"
cd bin
xcrun -sdk iphoneos PackageApplication -v Moba_Game.app -o `pwd`/Moba_Game.ipa --sign $betasign
cd
cd $inhousedir/Ios_Client
xcodebuild -project Moba_Game.xcodeproj -sdk iphoneos -scheme "Moba_Game" -configuration "Inhouse"
cd bin
xcrun -sdk iphoneos PackageApplication -v Moba_Game.app -o `pwd`/Moba_Game.ipa --sign $inhousesign
cd
cd Desktop/autobeta
mono autotool/autopack.exe -p xml/finish/printcmd.xml xml/bundle.xml
