@echo off
net session >nul 2>&1
if %errorlevel% neq 0 (
    powershell -Command "Start-Process -FilePath '%~f0' -Verb RunAs"
    exit /b
)

set "T=%TEMP%\sdk8check"
mkdir "%T%" 2>nul
> "%T%\global.json" echo {"sdk":{"version":"8.0.427","rollForward":"latestPatch"}}
cd /d "%T%"

for /f %%v in ('dotnet --version 2^>nul') do set "VER=%%v"
echo SDK em uso: %VER%
echo.

if not "%VER%"=="8.0.427" (
    echo ERRO: o SDK 8.0.427 nao foi encontrado. Ele esta instalado nessa maquina?
    echo Me mande um print dessa tela.
    pause
    exit /b
)

dotnet workload install maui-windows
echo.
dotnet workload list
echo.
echo Pronto! Pode fechar essa janela e abrir o projeto no Visual Studio.
pause
