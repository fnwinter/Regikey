!include x64.nsh

; The name of the installer
Name "RegikeyInstaller"

; The file to write
OutFile "regikey_install.exe"

; The default installation directory
InstallDir $PROGRAMFILES\Regikey

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages
Page directory
Page instfiles

;--------------------------------

; The stuff to install
Section "Install" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  CreateDirectory "$SMPROGRAMS\Regikey"
  createShortCut "$SMPROGRAMS\Regikey\Regikey.lnk" "$INSTDIR\REGIKEY.exe"
  createShortCut "$SMPROGRAMS\Regikey\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
  ShellLink::SetRunAsAdministrator "$SMPROGRAMS\Regikey\Regikey.lnk"

  ${If} ${RunningX64}
	# 64 bit code
	File REGIKEY_x64.exe
	Rename $INSTDIR\REGIKEY_x64.exe $INSTDIR\REGIKEY.exe
  ${Else}
	# 32 bit code
	File REGIKEY_x86.exe
	Rename $INSTDIR\REGIKEY_x86.exe $INSTDIR\REGIKEY.exe
  ${EndIf}  

  # define uninstaller name
  WriteUninstaller $INSTDIR\uninstaller.exe

SectionEnd ; end the section

Section "Uninstall"

Delete $INSTDIR\uninstaller.exe
Delete $INSTDIR\REGIKEY.exe
Delete "$SMPROGRAMS\Regikey\Regikey.lnk"
Delete "$SMPROGRAMS\Regikey\Uninstall.lnk"

RMDir "$SMPROGRAMS\Regikey"
RMDir $INSTDIR

SectionEnd