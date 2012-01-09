param ([string]$solutionDir, [string]$projectPath)

if((Test-Path "$solutionDir\nugetPacks") -eq $false) {
    Write-Host "nugetPacks folder does not exists. Creating one..."
    mkdir "$solutionDir\nugetPacks"
}

sal __Nuget "$solutionDir\tools\NuGet.exe"
__Nuget pack $projectPath -OutputDirectory "$solutionDir\nugetPacks"