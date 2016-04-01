@echo off
echo "***************************变量设置************************"
set rootdir=E:
set packdir=E:\autobeta
set macuser=herman@192.168.10.239
set macpwd=listlist
set isbeta=true
set tooldir=E:\手游打包
set datapk=/Users/herman/Desktop/autobeta/apk
set datup=/Users/herman/Desktop/autobeta/update
echo "*************关闭其他程序与window资源管理器****************"
:closewin
set/p closewin=为了防止出错,请关闭其他程序与window资源管理器,关闭完成后再按C键继续:
if /i "%closewin%"=="c" (goto initbundle) else (goto closewin)
:initbundle
set/p initbundle=按a生成IPA,按c生成更新包,按其它键结束:
if /i "%initbundle%"=="a" (
	set isapk=true
) else (
	if "%initbundle%"=="c" (
		set isapk=false
	) else (
		goto initbundle
	)
)
if %isapk%==true (
echo "************************开始打IPA包************************"
set updatedir=%packdir%\macosx\apk
) else (
echo "************************开始打更新包***********************"
set updatedir=%packdir%\macosx\update
)
echo "****************************资源***************************"
if %isapk%==true (
	plink -m %packdir%\cmd\apk.txt %macuser% -pw %macpwd%
) else (
	plink -m %packdir%\cmd\up.txt %macuser% -pw %macpwd%
)
echo "**************************生成dat**************************"
call script\dat.bat
if %isapk%==true (
	pscp -pw %macpwd% %updatedir%\game_ios.dat %macuser%:%datapk%
	pscp -pw %macpwd% %updatedir%\game_ios1.dat %macuser%:%datapk%
	pscp -pw %macpwd% %updatedir%\game_ios2.dat %macuser%:%datapk%
) else (
	pscp -pw %macpwd% %updatedir%\game_ios.dat %macuser%:%datup%
	pscp -pw %macpwd% %updatedir%\game_ios1.dat %macuser%:%datup%
	pscp -pw %macpwd% %updatedir%\game_ios2.dat %macuser%:%datup%
)
echo "****************************打包***************************"
if %isapk%==true (
	plink -m %packdir%\cmd\fapk.txt %macuser% -pw %macpwd%
) else (
	plink -m %packdir%\cmd\fup.txt %macuser% -pw %macpwd%
)
echo "****************************完成***************************"
pause














