# Clean all compilation items
Get-ChildItem .\ -include "bin","obj",".vs","*.user"  -Recurse -Force | `
    foreach ($_) {
        Write-Host "Cleaning: $($_.fullname)" -ForegroundColor DarkYellow
        remove-item $_.fullname -Force -Recurse
    }

# Build csharp-azurefunction-dotnet6
$template_path = "..\src\api-studio.package\ProjectTemplates\csharp-azurefunction-dotnet6.zip"
if (Test-Path $template_path) {
    Write-Host "Removing: $($template_path)" -ForegroundColor DarkMagenta
    Remove-Item $template_path
}
Write-Host "Packing: $($template_path)" -ForegroundColor Green
Compress-Archive -Path .\csharp-azurefunction-dotnet6\* -DestinationPath $template_path


# Build csharp-azurefunction-dotnet6
$template_path = "..\src\api-studio.package\ProjectTemplates\csharp-minimalapi-dotnet6.zip"
if (Test-Path $template_path) {
    Write-Host "Removing: $($template_path)" -ForegroundColor DarkMagenta
    Remove-Item $template_path
}
Write-Host "Packing: $($template_path)" -ForegroundColor Green
Compress-Archive -Path .\csharp-minimalapi-dotnet6\* -DestinationPath $template_path