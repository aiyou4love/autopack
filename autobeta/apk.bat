@echo off
echo "***************************��������************************"
set rootdir=E:
set packdir=E:\autobeta
echo "***************************SVN����*************************"
set isbeta=true
set etc1=true
set codedir=E:\Moba_Code_Beta\Moba_Code_Beta
set bindir=E:\Moba_Svn\bin
set apkdir=E:\Moba_Svn\apk\BETA�汾
set artdir=E:\ת��ͼ
set tooldir=E:\���δ��
echo "*********************android��������***********************"
set betadir=E:\Moba_Android_beta
set androidLen=1
set androidIndex=0
set android[0].path=%betadir%
echo "*************�ر�����������window��Դ������****************"
:closewin
set/p closewin=Ϊ�˷�ֹ����,��ر�����������window��Դ������,�ر���ɺ��ٰ�C������:
if /i "%closewin%"=="c" (goto initbundle) else (goto closewin)
:initbundle
set/p initbundle=��a����APK,��c���ɸ��°�,������������:
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
echo "************************��ʼ��APK��************************"
) else (
echo "************************��ʼ����°�***********************"
)
%rootdir%
cd %packdir%
echo "***********************SVN���¿�ʼ*************************"
if %isbeta% == true (
	call script\svnup.bat
)
echo "************************����Server*************************"
call script\build.bat
echo "*************************��ʼ��Դ**************************"
if %isapk%==true (
	call script\apk.bat
	set updatedir=%packdir%\apk
) else (
	call script\update.bat
	set updatedir=%packdir%\modify
)
echo "**************************����dat**************************"
call script\dat.bat
echo "*************************תͼ��ʼ**************************"
call script\convert.bat
echo "*************************�����ʼ**************************"
if %isapk%==true (
call script\package.bat
call script\finish.bat
) else (
call script\finishu.bat
)
echo "*************************������**************************"
pause
