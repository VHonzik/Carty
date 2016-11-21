@ECHO Running unit tests...
@ECHO OFF
IF "%UNITY%"=="" (
ECHO UNITY environment variable is not set. Exiting.
EXIT /B 1
)

set TESTRESULTS=%cd%\TestResults

start /WAIT %UNITY%\Unity.exe -batchmode -projectPath %cd%\CartyLibUnitTests -executeMethod UnityTest.Batch.RunIntegrationTests -testscenes=CartyLibTestsCardComponents,CartyLibTestsBoardComponents -targetPlatform=StandaloneWindows -resultsFileDirectory=%TESTRESULTS%

SET ERRNO=%ERRORLEVEL%

IF %ERRNO% EQU 0 (
RD /S /Q %TESTRESULTS%
ECHO All tests passed!
) ELSE (
ECHO Some tests have not passed, generating report to %TESTRESULTS%.
)

EXIT /B %ERRNO%