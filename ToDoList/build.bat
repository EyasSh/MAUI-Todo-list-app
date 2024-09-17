@echo off
echo Building and deploying ToDoList project...

REM Build and deploy for Android using specific device
dotnet build ToDoList.generated.sln -t:Run -f net8.0-android /p:DeviceName=RFCWA067YVA

if %ERRORLEVEL% equ 0 (
    echo Build and deployment succeeded.
) else (
    echo Build or deployment failed.
)

pause
