dotnet tool install -g OpenVsixSignTool

$vsix = "..\..\dist\api-studio.package.vsix"
$hash = "..\..\dist\api-studio.package.json"

OpenVsixSignTool sign --sha1 1b2c3f93680cb70e928e7e2292aa9a1741d0df98 --timestamp http://timestamp.digicert.com -ta sha256 -fd sha256 $vsix

$vsixHash = New-Object System.Object
$vsixHash | Add-Member -MemberType NoteProperty -Name "SHA1" -Value (Get-FileHash $vsix -Algorithm SHA1).Hash
$vsixHash | Add-Member -MemberType NoteProperty -Name "SHA256" -Value (Get-FileHash $vsix -Algorithm SHA256).Hash
$vsixHash | Add-Member -MemberType NoteProperty -Name "SHA384" -Value (Get-FileHash $vsix -Algorithm SHA384).Hash
$vsixHash | Add-Member -MemberType NoteProperty -Name "SHA512" -Value (Get-FileHash $vsix -Algorithm SHA512).Hash
$vsixHash | Add-Member -MemberType NoteProperty -Name "MD5" -Value (Get-FileHash $vsix -Algorithm MD5).Hash
$vsixHash | ConvertTo-Json -depth 100 | Out-File $hash