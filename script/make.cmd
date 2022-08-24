@echo off

rem Call ourself to convert from dec to hex from "for /f"

if "%~1" == "-hex" (

  call :DecToHex "%~2"
  exit /b %errorlevel%

)





call "%~dp0params.cmd"
if errorlevel 1 exit /b 1



if not exist "%PartTableFileX%" (

  echo Partition table file "%PartTableFileX%" not found.
  echo Please make it first
  pause
  exit /b 1

)

if not exist "%SelPartsFile%" (

  echo Selected partitions file "%SelPartsFile%" not found
  pause
  exit /b 1

)



echo ^<?xml version="1.0" ?^>>"%xmlFile%"
echo ^<data^>>>"%xmlFile%"



setlocal enabledelayedexpansion



for /f "usebackq tokens=1-4" %%A in ("%PartTableFileX%") do (

  if not "%%A" == "#" (

    for /f "usebackq" %%P in ("%SelPartsFile%") do (

      if "%%P" == "%%B" (

        rem Calculate byte offset in 256-byte units to avoid overflow

        set /a ByteOffset256=%%C * 2

        set /a SizeInKB=%%D / 2

        for /f %%Z in ('call "%~f0" -hex !ByteOffset256!') do set ByteOffset256Hex=%%Z

        echo   ^<program SECTOR_SIZE_IN_BYTES="512" file_sector_offset="0" filename="%%B.img" label="%%B" num_partition_sectors="%%D" physical_partition_number="0" size_in_KB="!SizeInKB!.0" sparse="false" start_byte_hex="0x!ByteOffset256Hex!00L" start_sector="%%C"/^>>>"%xmlFile%"

      )

    )

  )

)

echo ^</data^>>>"%xmlFile%"

echo Raw program script saved to %xmlFile%
copy qcom\rawprogram0.xml qcom\backup
echo ===================Collect Firmware in qcom\backup Folder=============================

exit /b 0





:DecToHex

setlocal enabledelayedexpansion

set DecNum=%~1
set DigTable=0123456789abcdef
set HexRes=

:Loop

set /a DecNumQ=%DecNum% / 16
set /a DecRmd=%DecNum% - %DecNumQ% * 16
set DecNum=%DecNumQ%

set HexDig=!DigTable:~%DecRmd%,1!

set HexRes=%HexDig%%HexRes%

if %DecNum% neq 0 goto Loop

echo %HexRes%

endlocal

exit /b 0
exit
