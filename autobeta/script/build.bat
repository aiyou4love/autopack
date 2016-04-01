%rootdir%
cd %packdir%
:buildserver
devenv %codedir%\MUsrc\moba_phone.sln /Build "Release|Win32"
set/p buildserver=如果没有错误请按C键继续,有错误请修正错误后按其它键再按回车重新生成解决方案:
if /i "%buildserver%"=="c" (goto buildloop) else (goto buildserver)
:buildloop
echo "*************************编译开始***************************"
IF %androidIndex% equ %androidLen% goto buildend
set androidCur.path=0
for /F "usebackq delims==. tokens=1-3" %%I in (`set android[%androidIndex%]`) do (
  set androidCur.%%J=%%K
)
:androidbuildstart
cd %androidCur.path%
call ndk-build NDK_DEBUG=0
set/p androidbuildstart=如果没有错误请按C键继续,有错误请修正错误后按其它键再按回车重新编译Client:
if /i "%androidbuildstart%"=="c" (goto androidbuildend) else (goto androidbuildstart)
:androidbuildend
set /A androidIndex=%androidIndex% + 1
goto buildloop
:buildend
%rootdir%
cd %packdir%
echo "*************************编译完成**************************"
