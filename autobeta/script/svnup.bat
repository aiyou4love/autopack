set svnLen=3
set svnIndex=0
set svn[0].path=%codedir%
set svn[1].path=%bindir%
set svn[2].path=%apkdir%
%rootdir%
cd %packdir%
:svnloop
echo "*************************SVN����***************************"
IF %svnIndex% equ %svnLen% goto svnend
set svnCur.path=0
for /F "usebackq delims==. tokens=1-3" %%I in (`set svn[%svnIndex%]`) do (
  set svnCur.%%J=%%K
)
:svnstart
svn up %svnCur.path%
set/p svnstart=����SVN�ɹ���C������,������������SVN:
if /i "%svnstart%"=="c" (goto svnco) else (goto svnstart)
:svnco
set /A svnIndex=%svnIndex% + 1
goto svnloop
:svnend
%rootdir%
cd %packdir%
echo "***********************SVN�������*************************"
