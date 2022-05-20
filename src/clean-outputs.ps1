#   Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process

Get-ChildItem .\ -include "bin","obj",".vs","*.user"  -Recurse -Force | `
    foreach ($_) { 
        Write-Host "Cleaning: $($_.fullname)" -ForegroundColor DarkYellow
        remove-item $_.fullname -Force -Recurse 
    }


