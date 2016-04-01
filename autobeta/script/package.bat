%rootdir%
cd %packdir%
autopack.exe -b xml\build\minCommand.xml xml\bundle.xml
cd %betadir%
call ant clean
call ant release
copy /Y %betadir%\bin\GSOFTGAMEActivity-release.apk %updatedir%\MoBaGame_Min.apk
%rootdir%
cd %packdir%
autopack.exe -b xml\build\norCommand.xml xml\bundle.xml
cd %betadir%
call ant clean
call ant release
copy /Y %betadir%\bin\GSOFTGAMEActivity-release.apk %updatedir%\MoBaGame_Nor.apk
%rootdir%
cd %packdir%
autopack.exe -b xml\build\plsCommand.xml xml\bundle.xml
cd %betadir%
call ant clean
call ant release
copy /Y %betadir%\bin\GSOFTGAMEActivity-release.apk %updatedir%\MoBaGame_Pls.apk
%rootdir%
cd %packdir%
