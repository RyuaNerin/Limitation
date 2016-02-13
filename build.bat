@echo off

set MSBUILD="%ProgramFiles(x86)%\MSBuild\12.0\Bin\MSBuild.exe"
if not exist %MSBUILD% set MSBUILD="%ProgramFiles%\MSBuild\12.0\Bin\MSBuild.exe"
if not exist %MSBUILD% set MSBUILD="%ProgramFiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe"
if not exist %MSBUILD% set MSBUILD="%ProgramFiles%\MSBuild\14.0\Bin\MSBuild.exe"
if not exist %MSBUILD% echo Error: Could not find MSBuild.exe. && goto :eof


SET CDIR=%cd%\Limitation\bin\Confused\
SET RDIR=%cd%\Limitation\bin\Release\

del /F /S /Q "Limitation\bin\Release"
del /F /S /Q "Limitation\bin\Confused"

%MSBUILD% "%cd%\Limitation\Limitation.csproj" /p:Configuration=Release

echo ^<project outputDir="%CDIR%" baseDir="%RDIR%" xmlns="http://confuser.codeplex.com"^> >  "%RDIR%ConfuserEx.crproj"
echo ^<rule pattern="true" inherit="false"^> >> "%RDIR%ConfuserEx.crproj"
echo ^<protection id="resources"/^> >> "%RDIR%ConfuserEx.crproj"
echo ^</rule^> >> "%RDIR%ConfuserEx.crproj"
echo ^<module path="Limitation.exe" snKey="%cd%\Limitation\Uncommit\Limitation.snk" /^> >> "%RDIR%ConfuserEx.crproj"
echo ^</project^> >> "%RDIR%ConfuserEx.crproj"

"%cd%\ConfuserEx\Confuser.CLI.exe" -n "%RDIR%confuserex.crproj"
