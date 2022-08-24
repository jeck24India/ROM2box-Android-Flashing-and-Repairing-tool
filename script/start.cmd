rem @echo off
title by ROMProvider.COM
call "%~dp0params.cmd"
if errorlevel 1 exit /b 1



if not exist "%FirehoseFile%" (

  echo Firehose file "%FirehoseFile%" not found
  exit /b 1

)



echo # PartNum PartName StartSec NumSecs> "%PartTableFile%"
echo.>> "%PartTableFile%"

setlocal enabledelayedexpansion

set EmmcLogFile=%~dp0emmcdl.log

emmcdl.exe -p %SaharaComPort% -MemoryName %memory% -f %FirehoseFile% -gpt > %EmmcLogFile%


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
call replacer.bat qcom\parttable.txt "1" ""
call replacer.bat qcom\parttable.txt "2" ""
call replacer.bat qcom\parttable.txt "3" ""
call replacer.bat qcom\parttable.txt "4" ""
call replacer.bat qcom\parttable.txt "5" ""
call replacer.bat qcom\parttable.txt "6" ""
call replacer.bat qcom\parttable.txt "7" ""
call replacer.bat qcom\parttable.txt "8" ""
call replacer.bat qcom\parttable.txt "9" ""
call replacer.bat qcom\parttable.txt "0" ""
call replacer.bat qcom\parttable.txt "#" ""
call replacer.bat qcom\parttable.txt "PartNum" ""
call replacer.bat qcom\parttable.txt "PartName" ""
call replacer.bat qcom\parttable.txt "StartLBA" ""
call replacer.bat qcom\parttable.txt "SizeInLBA" ""
call replacer.bat qcom\parttable.txt "StartSec" ""
call replacer.bat qcom\parttable.txt "NumSecss" ""
call replacer.bat qcom\parttable.txt "NumSecs" ""

setlocal enabledelayedexpansion



set NumParts=0

for /f "usebackq" %%P in (%SelPartsFile%) do (

emmcdl.exe -p %SaharaComPort% -MemoryName %memory% -f %FirehoseFile% -d %%P -o %~dp0/backup/%%P.img

  set /a NumParts = !NumParts! + 1

)

echo %NumParts% partition images created

qcom\make.cmd
exit