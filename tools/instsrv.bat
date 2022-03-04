@echo off
setlocal
set root=%~dp0..
dotnet tool restore
dotnet pwsh -Command "Start-Process dotnet -ArgumentList 'pwsh','-Command','&{New-Service -Name MyHelloService -BinaryPathName %root%/bin/Debug/net5.0/HelloService.exe}' -verb RunAs -PassThru"
dotnet pwsh -Command "Get-Service -Name ""MyHelloService"""

