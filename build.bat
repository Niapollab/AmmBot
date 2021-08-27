@echo off
chcp 1251 > nul

dotnet publish AmmBot.Service\AmmBot.Service.csproj --output bin -c Release ^
    && move bin\AmmBot.Service.exe bin\AmmBot.exe > nul ^
    && copy install.bat bin\install.bat > nul ^
    && copy uninstall.bat bin\uninstall.bat > nul ^
    && copy start.bat bin\start.bat > nul ^
    && copy stop.bat bin\stop.bat > nul ^
    && del bin\appsettings.Development.json > nul ^
    && del /Q bin\*.pdb > nul