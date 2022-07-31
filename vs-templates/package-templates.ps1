# Clean all compilation items
Get-ChildItem .\ -include "bin","obj",".vs","*.user"  -Recurse -Force | `
    foreach ($_) {
        Write-Host "Cleaning: $($_.fullname)" -ForegroundColor DarkYellow
        remove-item $_.fullname -Force -Recurse
    }

# Build api-studio.codegen.csharp-azurefunction-dotnet6
$template_path = "..\src\api-studio.package\ProjectTemplates\csharp-azurefunction-dotnet6.zip"
if (Test-Path $template_path) {
    Write-Host "Removing: $($template_path)" -ForegroundColor DarkMagenta
    Remove-Item $template_path
}
Write-Host "Packing: $($template_path)" -ForegroundColor Green
Compress-Archive -Path .\api-studio.codegen.csharp-azurefunction-dotnet6\* -DestinationPath $template_path


# Build api-studio.codegen.csharp-azurefunction-dotnet6
$template_path = "..\src\api-studio.package\ProjectTemplates\csharp-minimumapi-dotnet6.zip"
if (Test-Path $template_path) {
    Write-Host "Removing: $($template_path)" -ForegroundColor DarkMagenta
    Remove-Item $template_path
}
Write-Host "Packing: $($template_path)" -ForegroundColor Green
Compress-Archive -Path .\api-studio.codegen.csharp-minimumapi-dotnet6\* -DestinationPath $template_path