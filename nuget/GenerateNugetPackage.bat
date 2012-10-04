echo off
%~dp0..\src\.nuget\nuget.exe pack %~dp0..\src\Source\LinkedIn\LinkedIn.csproj.nuspec
echo on
