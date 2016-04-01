set convertLen=11
set convertIndex=0
set convert[0].path=interscene\texture
set convert[1].path=interscene\fulltexture
set convert[2].path=interscene\HQtexture
set convert[3].path=interscene01\texture
set convert[4].path=chapter001\texture
set convert[5].path=chapter001\texture\terrain
set convert[6].path=chapter002\texture
set convert[7].path=chapter002\texture\terrain
set convert[8].path=chapter003\texture
set convert[9].path=chapter004\texture
set convert[10].path=chapter005\texture
%rootdir%
cd %packdir%
:convertloop
echo "************************转图开始***************************"
IF %convertIndex% equ %convertLen% goto convertend
set convertCur.path=0
for /F "usebackq delims==. tokens=1-3" %%I in (`set convert[%convertIndex%]`) do (
  set convertCur.%%J=%%K
)
:convertstart
if exist %updatedir%\%convertCur.path% (
	cd %updatedir%\%convertCur.path%
	DEL /F /Q %artdir%\texture\*.*
	DEL /F /Q %artdir%\myImage\*.*
	xcopy *.* %artdir%\texture\ /R /Y
	DEL /F /Q *.*
	cd %artdir%
	if %etc1% == true (
		call tex2etc_etc1_alpha.bat
	) else (
		call tex2etc_etc2.bat
	)
	xcopy %artdir%\myImage\*.* %updatedir%\%convertCur.path%\ /R /Y
)
set /A convertIndex=%convertIndex% + 1
goto convertloop
:convertend
%rootdir%
cd %packdir%
echo "************************转图完成***************************"
