#!/bin/bash

XUNIT_PATH="./packages/xunit.runner.console.2.0.0/tools/xunit.console.x86.exe"  
TESTS_PATH="./**/bin/Debug/*Tests.dll"

xbuild
mono $XUNIT_PATH $TESTS_PATH
