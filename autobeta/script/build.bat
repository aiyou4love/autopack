%rootdir%
cd %packdir%
:buildserver
devenv %codedir%\MUsrc\moba_phone.sln /Build "Release|Win32"
set/p buildserver=���û�д����밴C������,�д���������������������ٰ��س��������ɽ������:
if /i "%buildserver%"=="c" (goto buildloop) else (goto buildserver)
:buildloop
echo "*************************���뿪ʼ***************************"
IF %androidIndex% equ %androidLen% goto buildend
set androidCur.path=0
for /F "usebackq delims==. tokens=1-3" %%I in (`set android[%androidIndex%]`) do (
  set androidCur.%%J=%%K
)
:androidbuildstart
cd %androidCur.path%
call ndk-build NDK_DEBUG=0
set/p androidbuildstart=���û�д����밴C������,�д���������������������ٰ��س����±���Client:
if /i "%androidbuildstart%"=="c" (goto androidbuildend) else (goto androidbuildstart)
:androidbuildend
set /A androidIndex=%androidIndex% + 1
goto buildloop
:buildend
%rootdir%
cd %packdir%
echo "*************************�������**************************"
