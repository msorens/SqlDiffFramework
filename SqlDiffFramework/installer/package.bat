@echo off
set PROGN=SqlDiffFramework
:: includes trailing backslash
set OLD_DIR=%~dp0
C:
cd "C:\Program Files (x86)\Inno Setup 5"
@echo on
ISCC.exe "%OLD_DIR%%PROGN%.iss"
@echo off
set OLD_DIR=
set PROGN=
pause
