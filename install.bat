@echo off
chcp 1251 > nul
sc create "VK AMM Bot" start= delayed-auto  binPath= "%~dp0AmmBot.Service.exe" DisplayName= "VK AMM Bot" && sc start "VK AMM Bot"