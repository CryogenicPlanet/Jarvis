
FOR /F "tokens=* delims="  %%i IN (alarm_time.txt) DO @echo %%i
pause>nul
echo hi
