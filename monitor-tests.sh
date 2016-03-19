#!/bin/bash

XUNIT_PATH="./packages/xunit.runner.console.2.0.0/tools/xunit.console.x86.exe"  
TESTS_PATH="./**/bin/Debug/*Tests.dll"
SOURCES_PATH="./**/*.cs"

fsmonitor -p '+*.cs' mono $XUNIT_PATH $TESTS_PATH
