echo off
call "C:\Program Files (x86)\Microsoft Visual Studio 11.0\VC\vcvarsall.bat"
msbuild %~dp0..\src\Source\LinkedIn\LinkedIn.csproj
%~dp0..\src\.nuget\nuget.exe pack %~dp0..\src\Source\LinkedIn\LinkedIn.csproj.nuspec
echo on
