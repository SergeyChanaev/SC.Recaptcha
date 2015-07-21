@ECHO OFF

..\Tools\NuGet\nuget.exe push "..\..\NuGet Packages\SC.Recaptcha.1.0.0.0.nupkg"
..\Tools\NuGet\nuget.exe push "..\..\NuGet Packages\SC.Recaptcha.MVC.1.0.0.0.nupkg"

SET /p temp="Press any key to continue..."