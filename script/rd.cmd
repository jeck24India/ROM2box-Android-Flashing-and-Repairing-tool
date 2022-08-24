rem @echo off
title script by ROMProvider.COM
call "%~dp0params.cmd"

echo # PartNum PartName StartSec NumSecs> "%PartTableFile%"
echo.>> "%PartTableFile%"

setlocal enabledelayedexpansion

set EmmcLogFile=%~dp0emmcdl.log
emmcdl.exe -p %SaharaComPort% -MemoryName %memory% -f %FirehoseFile% -gpt > %EmmcLogFile%

if errorlevel 1 (
  exit /b 1

)


for /f "usebackq delims=" %%L in ("%EmmcLogFile%") do (

  set Line=%%L

  if "!Line:~0,1!" geq "0" (

    if "!Line:~0,1!" leq "9" (

      for /f "tokens=1-12 delims=.: " %%A in ("!Line!") do (

        rem PartNum PartName StartLBA SizeInLBA

        echo %%A %%D %%G %%K>>"%PartTableFile%"

      )

    )

  )

)

del %EmmcLogFile%

echo Partition table saved to %PartTableFile%

copy qcom\parttable.txt qcom\parttable2.txt

set NumParts=0

for /f "usebackq" %%P in (%SelPartsFile%) do (

emmcdl.exe -p %SaharaComPort% -MemoryName %memory% -f %FirehoseFile% -d %%P -o %~dp0/backup/%%P.img

  set /a NumParts = !NumParts! + 1

)
echo %NumParts% partition images created
qcom\make.cmd
exit