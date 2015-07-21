@ECHO OFF

..\Tools\NuGet\nuget.exe pack ..\SC.Recaptcha\SC.Recaptcha.csproj -Properties Configuration=Release -OutputDirectory "..\..\NuGet Packages" -Build -Verbose
..\Tools\NuGet\nuget.exe pack ..\SC.Recaptcha.MVC\SC.Recaptcha.MVC.csproj -Properties Configuration=Release -OutputDirectory "..\..\NuGet Packages" -Build -Verbose

SET /p temp="Press any key to continue..."