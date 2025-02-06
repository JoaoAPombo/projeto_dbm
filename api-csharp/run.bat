@echo off

:: Pega o diretório onde o script .bat está e navega para esse diretório
cd /d "%~dp0"

:: Executa os comandos para o seu projeto
dotnet restore
dotnet build
dotnet ef migrations add Inicial
dotnet ef database update
dotnet run