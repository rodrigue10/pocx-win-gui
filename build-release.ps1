param(
    [Parameter(Mandatory=$true)]
    [string]$Version,
    [switch]$BuildOnly,
    [switch]$InstallerOnly
)

$ErrorActionPreference = "Stop"

# Paths
$ScriptRoot = $PSScriptRoot
$MSBuildPaths = @(
    "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe",
    "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe",
    "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
)
$InnoSetupPaths = @(
    "C:\Program Files (x86)\Inno Setup 6\ISCC.exe",
    "C:\Program Files\Inno Setup 6\ISCC.exe"
)
$Solution = Join-Path $ScriptRoot "PoCXWinGUI.slnx"
$VersionInfoFile = Join-Path $ScriptRoot "common\VersionInfo.cs"
$IssFile = Join-Path $ScriptRoot "installer\PoCXFrameworkGUI.iss"

# Find MSBuild
$MSBuild = $null
foreach ($path in $MSBuildPaths) {
    if (Test-Path $path) {
        $MSBuild = $path
        break
    }
}

if (-not $MSBuild) {
    Write-Error "MSBuild not found. Please install Visual Studio with .NET desktop development workload."
    exit 1
}

# Find Inno Setup
$InnoSetup = $null
foreach ($path in $InnoSetupPaths) {
    if (Test-Path $path) {
        $InnoSetup = $path
        break
    }
}

if (-not $InstallerOnly -and -not $BuildOnly) {
    if (-not $InnoSetup) {
        Write-Error "Inno Setup 6 not found. Please install from https://jrsoftware.org/isinfo.php"
        exit 1
    }
}

Write-Host "=== PoCX Framework Windows GUI Build Script ===" -ForegroundColor Cyan
Write-Host "Version: $Version"
Write-Host "MSBuild: $MSBuild"
if ($InnoSetup) {
    Write-Host "Inno Setup: $InnoSetup"
}
Write-Host ""

if (-not $InstallerOnly) {
    # Update version in VersionInfo.cs
    Write-Host "Updating version in VersionInfo.cs..." -ForegroundColor Yellow
    $versionInfoContent = Get-Content $VersionInfoFile -Raw
    $versionInfoContent = $versionInfoContent -replace 'public const string Version = ".*"', "public const string Version = `"$Version`""
    Set-Content -Path $VersionInfoFile -Value $versionInfoContent -NoNewline

    # Update version in .iss file
    Write-Host "Updating version in PoCXFrameworkGUI.iss..." -ForegroundColor Yellow
    $issContent = Get-Content $IssFile -Raw
    $issContent = $issContent -replace '#define MyAppVersion ".*"', "#define MyAppVersion `"$Version`""
    Set-Content -Path $IssFile -Value $issContent -NoNewline

    # Clean solution
    Write-Host "Cleaning solution..." -ForegroundColor Yellow
    & $MSBuild $Solution /t:Clean /p:Configuration=Release /v:minimal
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Clean failed"
        exit 1
    }

    # Build solution
    Write-Host "Building solution..." -ForegroundColor Yellow
    & $MSBuild $Solution /t:Build /p:Configuration=Release /v:minimal /restore
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Build failed"
        exit 1
    }

    Write-Host "Build completed successfully!" -ForegroundColor Green
}

if (-not $BuildOnly) {
    if (-not $InnoSetup) {
        Write-Error "Inno Setup 6 not found. Cannot create installer."
        exit 1
    }

    # Create installer
    Write-Host "Creating installer..." -ForegroundColor Yellow
    & $InnoSetup $IssFile
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Installer creation failed"
        exit 1
    }

    $OutputFile = Join-Path $ScriptRoot "installer\output\PoCXFrameworkGUI-$Version-Setup.exe"
    if (Test-Path $OutputFile) {
        Write-Host ""
        Write-Host "=== Release Complete ===" -ForegroundColor Green
        Write-Host "Installer created: $OutputFile"
        Write-Host "Size: $([math]::Round((Get-Item $OutputFile).Length / 1MB, 2)) MB"
    } else {
        Write-Warning "Installer file not found at expected location"
    }
}

Write-Host ""
Write-Host "Done!" -ForegroundColor Cyan
