@echo off
set PROGN=SqlDiffFramework
:: includes trailing backslash
set OLD_DIR=%~dp0
C:
cd "\Program Files\ISTool"
@echo on
ISTool.exe -compile "%OLD_DIR%%PROGN%.iss"
@echo off
set OLD_DIR=
set PROGN=
pause
