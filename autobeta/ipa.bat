@echo off
echo "***************************��������************************"
set rootdir=E:
set packdir=E:\autobeta
set macuser=herman@192.168.10.239
set macpwd=listlist
set isbeta=true
set tooldir=E:\���δ��
set datapk=/Users/herman/Desktop/autobeta/apk
set datup=/Users/herman/Desktop/autobeta/update
echo "*************�ر�����������window��Դ������****************"
:closewin
set/p closewin=Ϊ�˷�ֹ����,��ر�����������window��Դ������,�ر���ɺ��ٰ�C������:
if /i "%closewin%"=="c" (goto initbundle) else (goto closewin)
:initbundle
set/p initbundle=��a����IPA,��c���ɸ��°�,������������:
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
echo "************************��ʼ��IPA��************************"
set updatedir=%packdir%\macosx\apk
) else (
echo "************************��ʼ����°�***********************"
set updatedir=%packdir%\macosx\update
)
echo "****************************��Դ***************************"
if %isapk%==true (
	plink -m %packdir%\cmd\apk.txt %macuser% -pw %macpwd%
) else (
	plink -m %packdir%\cmd\up.txt %macuser% -pw %macpwd%
)
echo "**************************����dat**************************"
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
echo "****************************���***************************"
if %isapk%==true (
	plink -m %packdir%\cmd\fapk.txt %macuser% -pw %macpwd%
) else (
	plink -m %packdir%\cmd\fup.txt %macuser% -pw %macpwd%
)
echo "****************************���***************************"
pause














