setlocal

for %%v in (2.0, 3.5, 4.0, 12.0) do (
  for /f "usebackq tokens=2* delims= " %%c in (`reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild\ToolsVersions\%%v" /v MSBuildToolsPath`) do (
      set msBuildExe=%%dMSBuild.exe
  )
)

fsmonitor -s -p +*.cs "%msBuildExe%" Jaco.sln

endlocal
