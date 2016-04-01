@echo off
echo "***************************变量设置************************"
set rootdir=E:
set packdir=E:\autobeta
echo "***************************SVN变量*************************"
set isbeta=true
set etc1=true
set codedir=E:\Moba_Code_Beta\Moba_Code_Beta
set bindir=E:\Moba_Svn\bin
set apkdir=E:\Moba_Svn\apk\BETA版本
set artdir=E:\转贴图
set tooldir=E:\手游打包
echo "*********************android渠道变量***********************"
set betadir=E:\Moba_Android_beta
set androidLen=1
set androidIndex=0
set android[0].path=%betadir%
echo "*************关闭其他程序与window资源管理器****************"
:closewin
set/p closewin=为了防止出错,请关闭其他程序与window资源管理器,关闭完成后再按C键继续:
if /i "%closewin%"=="c" (goto initbundle) else (goto closewin)
:initbundle
set/p initbundle=按a生成APK,按c生成更新包,按其它键结束:
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
echo "************************开始打APK包************************"
) else (
echo "************************开始打更新包***********************"
)
%rootdir%
cd %packdir%
echo "***********************SVN更新开始*************************"
if %isbeta% == true (
	call script\svnup.bat
)
echo "************************编译Server*************************"
call script\build.bat
echo "*************************初始资源**************************"
if %isapk%==true (
	call script\apk.bat
	set updatedir=%packdir%\apk
) else (
	call script\update.bat
	set updatedir=%packdir%\modify
)
echo "**************************生成dat**************************"
call script\dat.bat
echo "*************************转图开始**************************"
call script\convert.bat
echo "*************************打包开始**************************"
if %isapk%==true (
call script\package.bat
call script\finish.bat
) else (
call script\finishu.bat
)
echo "*************************打包完成**************************"
pause
