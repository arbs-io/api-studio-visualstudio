function Add-NoteProperty {
    param(
        $InputObject,
        $Property,
        $Value,
        [switch]$Force,
        [char]$escapeChar = '#'
    )
    process {
        $path = $Property -split "\."
        $obj = $InputObject
        # loop all but the very last property
        for ($x = 0; $x -lt $path.count -1; $x ++) {
            $propName = $path[$x] -replace $escapeChar, '.'
            if (!($obj | Get-Member -MemberType NoteProperty -Name $propName)) {
                $obj | Add-Member NoteProperty -Name $propName -Value (New-Object PSCustomObject) -Force:$Force.IsPresent
            }
            $obj = $obj.$propName
        }
        $propName = ($path | Select-Object -Last 1) -replace $escapeChar, '.'
        if (!($obj | Get-Member -MemberType NoteProperty -Name $propName)) {
            $obj | Add-Member NoteProperty -Name $propName -Value $Value -Force:$Force.IsPresent
        }
    }
}


dotnet tool install -g OpenVsixSignTool

$vsix = "..\..\dist\api-studio.package.vsix"
$hash = "..\..\api-studio.package-build.json"

OpenVsixSignTool sign --sha1 1b2c3f93680cb70e928e7e2292aa9a1741d0df98 --timestamp http://timestamp.digicert.com -ta sha256 -fd sha256 $vsix

$vsixHash = [PSCustomObject]@{}

Add-NoteProperty -InputObject $vsixHash -Property "signing.vsix" -Value "api-studio.package.vsix"
Add-NoteProperty -InputObject $vsixHash -Property "signing.version" -Value "manual-verification"
Add-NoteProperty -InputObject $vsixHash -Property "signing.timestamp" -Value (Get-Date -Format o | ForEach-Object { $_ -replace ":", "." })
Add-NoteProperty -InputObject $vsixHash -Property "hash.sha1" -Value (Get-FileHash $vsix -Algorithm SHA1).Hash
Add-NoteProperty -InputObject $vsixHash -Property "hash.sha256" -Value (Get-FileHash $vsix -Algorithm SHA256).Hash
Add-NoteProperty -InputObject $vsixHash -Property "hash.sha384" -Value (Get-FileHash $vsix -Algorithm SHA384).Hash
Add-NoteProperty -InputObject $vsixHash -Property "hash.sha512" -Value (Get-FileHash $vsix -Algorithm SHA512).Hash
Add-NoteProperty -InputObject $vsixHash -Property "hash.md5" -Value (Get-FileHash $vsix -Algorithm MD5).Hash
$vsixHash | ConvertTo-Json -depth 100 | Out-File $hash