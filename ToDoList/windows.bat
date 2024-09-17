@echo off
echo Building ToDoList project...
dotnet build ToDoList.generated.sln -f net8.0-windows
if %ERRORLEVEL% equ 0 (
    echo Build succeeded.
    for /f %%i in ('dir /b /s *.csproj ^| findstr /i "ToDoList"') do set PROJECT_FILE=%%i
    if defined PROJECT_FILE (
        echo Running project: %PROJECT_FILE%
        dotnet run --project "%PROJECT_FILE%" --framework net8.0-windows
    ) else (
        echo Could not find a suitable project file to run.
    )
) else (
    echo Build failed.
)
pause