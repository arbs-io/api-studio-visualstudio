$template_path = "..\src\api-studio.package\ProjectTemplates\azure-function-dotnet6-isolated.zip"


Get-ChildItem .\ -include "bin","obj",".vs","*.user"  -Recurse -Force | `
    foreach ($_) { 
        Write-Host "Cleaning: $($_.fullname)" -ForegroundColor DarkYellow
        remove-item $_.fullname -Force -Recurse 
    }


if (Test-Path $template_path) {
    Write-Host "Removing: $($template_path)" -ForegroundColor DarkMagenta
    Remove-Item $template_path
}

Write-Host "Packing: $($template_path)" -ForegroundColor Green
Compress-Archive -Path .\api-studio.azure-function-dotnet6-isolated\* -DestinationPath $template_path