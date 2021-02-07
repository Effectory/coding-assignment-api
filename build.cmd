@ECHO OFF
REM ****************************************************************************
REM Copyright 2021 Effectory - https://www.effectory.com
REM ****************************************************************************

if "%1" == "" goto no_config 
if "%1" NEQ "" goto set_config 

:set_config
SET Configuration=%1
GOTO build

:no_config
SET Configuration=Release
GOTO build

:build
dotnet build -c %Configuration% ./EffectoryQuestionnaire.sln
GOTO test

:test

echo ---------------------------
echo Running NETCOREAPP2.0 Tests
echo ---------------------------

dotnet test ./tests/Effectory.Questionnaire.Tests/Effectory.Questionnaire.Tests.csproj || exit /b 1