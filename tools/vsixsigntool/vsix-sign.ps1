dotnet tool install -g OpenVsixSignTool
OpenVsixSignTool sign --sha1 1b2c3f93680cb70e928e7e2292aa9a1741d0df98 --timestamp http://timestamp.digicert.com -ta sha256 -fd sha256 "..\..\dist\api-studio.package.vsix"
