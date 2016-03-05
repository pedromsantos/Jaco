#!/bin/bash

XUNIT_PATH="./packages/xunit.runner.console.2.0.0/tools/xunit.console.x86.exe"  
TESTS_PATH="./**/bin/Debug/*Tests.dll"
SOURCES_PATH="./**/*.cs"

#mono $HOME/bin/NuGet.exe restore *.sln

fswatch -0 $SOURCES_PATH | xargs -0 -n 1 -I {} mono $XUNIT_PATH $TESTS_PATH
