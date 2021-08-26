@echo off
chcp 1251 > nul

dotnet publish AmmBot.Service\AmmBot.Service.csproj --output bin -c Release --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true -p:IncludeAllContentForSelfExtract=true