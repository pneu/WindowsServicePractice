dotnet tool restore
dotnet pwsh -Command "Start-Process dotnet -ArgumentList 'pwsh','-Command','&{Remove-Service -Name MyHelloService; &sc delete MyHelloService}' -verb RunAs -PassThru"
dotnet pwsh -Command "Get-Service -Name ""MyHelloService"""
