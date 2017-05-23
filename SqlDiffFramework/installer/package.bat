@echo off
set PROGN=SqlDiffFramework
:: includes trailing backslash
set BUILDER="C:\Program Files (x86)\Inno Setup 5\ISCC.exe"
@echo on
%BUILDER% "%PROGN%.iss"
@echo off
set BUILDER=
set PROGN=
pause
