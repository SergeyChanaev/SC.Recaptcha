@ECHO OFF

..\Tools\NuGet\nuget.exe restore ..\SC.Recaptcha.sln

MD Packages

..\Tools\NuGet\nuget.exe pack ..\SC.Recaptcha\SC.Recaptcha.csproj -Properties Configuration=Release -OutputDirectory "Packages" -Build -Verbose
..\Tools\NuGet\nuget.exe pack ..\SC.Recaptcha.MVC\SC.Recaptcha.MVC.csproj -Properties Configuration=Release -OutputDirectory "Packages" -Build -Verbose

SET /p temp="Press any key to continue..."
