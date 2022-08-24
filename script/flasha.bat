title Fastboot Flasher by ROMProvider.COM
fastboot.exe getvar all 2>stdoutput.txt
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc 1 /f "tdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc -1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc -1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc -1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc -1 /f "stdoutput.txt" /o -
call jrepl.bat "^" "" /k 0 /exc -1 /f "stdoutput.txt" /o -

Set "fIn=stdoutput.txt"
If Not Exist "%fIn%" Exit /B
Copy /Y "%fIn%" "%fIn%.bak">Nul 2>&1 || Exit /B
Find /V /I "size"<"%fIn%.bak">"%fIn%"
::Del "%fIn%.bak"
call replacer.bat stdoutput.txt "(ext4)" ""
call replacer.bat stdoutput.txt "(bootloader)" ""
call replacer.bat stdoutput.txt "partition-type:" ""
call replacer.bat stdoutput.txt ":" ""
call a.bat "()" "orange" "bin\stdoutput.txt" >"newfile.txt"
call replacer.bat newfile.txt "orange " ""

call "%~dp0dir.cmd"
set SelPartsFile=%~dp0newfile.txt
setlocal enabledelayedexpansion



set NumParts=0

for /f "usebackq" %%P in ("%SelPartsFile%") do (

fastboot.exe flash %%P %dir%%%P.img
  
  
  set /a NumParts = !NumParts! + 1

)

echo %NumParts% partition images Processed
fastboot.exe erase userdata
fastboot.exe erase metadata
exit