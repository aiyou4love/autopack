set dati=1

cd %updatedir%

:datbegin
DEL /F /Q %tooldir%\game_1.dat
DEL /F /Q %tooldir%\game_ios.dat
cd %tooldir%
call 0_delete_all.bat
if %isbeta% == true (
	call 1_copy_all.bat
) else (
	call 1_copy_all_1.bat
)
cd bin
FOR /R %%A IN (.) DO cd %%A && (FOR /F %%B IN ('dir /b /l')  DO rename %%B %%B)
cd %tooldir%
call 5_3_packet_client.bat
cd %tooldir%
if %dati% == 1 (
	goto dattwo
) else (
	if %dati% == 2 (
		goto datthree
	)  else (
		goto datfour
	)
)

:dattwo
xcopy %tooldir%\game_1.dat %updatedir%\ /Y /R
xcopy %tooldir%\game_ios.dat %updatedir%\ /Y /R
set dati=2
DEL /F /Q %bindir%\interface\UserLogin\UserLogin.lua
DEL /F /Q %bindir%\interface\UserLogin\UserLogin.xml
copy %bindir%\interface\UserLogin\UserLogin_mi.lua %bindir%\interface\UserLogin\UserLogin.lua /Y
copy %bindir%\interface\UserLogin\UserLogin_mi.xml %bindir%\interface\UserLogin\UserLogin.xml /Y
goto datbegin
:datthree
copy %tooldir%\game_1.dat %updatedir%\game_1_1.dat /Y
copy %tooldir%\game_ios.dat %updatedir%\game_ios1.dat /Y
set dati=3
DEL /F /Q %bindir%\interface\UserLogin\UserLogin.lua
DEL /F /Q %bindir%\interface\UserLogin\UserLogin.xml
copy %bindir%\interface\UserLogin\UserLogin_ios.lua %bindir%\interface\UserLogin\UserLogin.lua /Y /R
copy %bindir%\interface\UserLogin\UserLogin_ios.xml %bindir%\interface\UserLogin\UserLogin.xml /Y /R
goto datbegin
:datfour
copy %tooldir%\game_1.dat %updatedir%\game_1_2.dat /Y
copy %tooldir%\game_ios.dat %updatedir%\game_ios2.dat /Y
%rootdir%
cd %packdir%
