# Upgrade the SDK to a Newer Trading API WSDL

Use this checklist when updating the SDK to a newer eBay Trading API WSDL. Run commands from the repository root in PowerShell. Keep the NuGet package version separate from the Trading API WSDL version.

## Prerequisites

- Visual Studio 2022 with the .NET Framework 4.8 targeting pack.
- Internet access to `https://developer.ebay.com/webservices/latest/ebaysvc.wsdl`.
- A clean or otherwise understood Git worktree. Preserve user changes when updating generated files.

## 1. Download and validate the latest WSDL

Download to a temporary file first so a failed request cannot truncate the checked-in WSDL:

```powershell
$wsdlUrl = 'https://developer.ebay.com/webservices/latest/ebaysvc.wsdl'
$temporaryWsdl = Join-Path $env:TEMP 'ebaysvc-latest.wsdl'
Invoke-WebRequest -Uri $wsdlUrl -OutFile $temporaryWsdl

$wsdlText = Get-Content $temporaryWsdl -Raw
[xml]$wsdlDocument = $wsdlText
if ($wsdlDocument.DocumentElement.LocalName -ne 'definitions') {
    throw 'The downloaded file is not a WSDL definitions document.'
}

$versionMatch = [regex]::Match($wsdlText, '<!--\s*Version\s+(\d+)\s*-->')
if (!$versionMatch.Success) {
    throw 'Could not find the WSDL version comment.'
}
$wsdlVersion = $versionMatch.Groups[1].Value
"Downloaded Trading API WSDL version $wsdlVersion"

Copy-Item $temporaryWsdl 'wsdl\eBaySvc.wsdl' -Force
```

Review the version comment in `wsdl/eBaySvc.wsdl` and the diff before continuing.

## 2. Update the three WSDL-version declarations

Set each declaration to the version found in the WSDL comment:

- `Source/eBay.Service.SDK/AssemblyInfo.cs`: `AssemblyVersion("3.<wsdlVersion>.0.0")`.
- `Source/Helper/AssemblyInfo.cs`: `AssemblyVersion("3.<wsdlVersion>.0.0")`.
- `Source/eBay.Service.SDK/Core/Sdk/ApiContext.cs`: the default `mVersion` string to `"<wsdlVersion>"`.

For example, WSDL version `1487` uses assembly version `3.1487.0.0` and API version `"1487"`. Do not use the NuGet package version for these declarations.

## 3. Regenerate the SOAP proxy

Build the repository's generator with Visual Studio MSBuild. Change `Community` in the path if using another Visual Studio 2022 edition:

```powershell
$msbuild = "$env:ProgramFiles\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
& $msbuild Tools\CodeGen\CodeGen.sln /t:Build /p:Configuration=Release /m
if ($LASTEXITCODE -ne 0) { throw 'Code generator build failed.' }
```

Run the generator against the downloaded local WSDL:

```powershell
$wsdlPath = (Resolve-Path 'wsdl\eBaySvc.wsdl').Path
& Tools\CodeGen\bin\CodeGen.exe `
  -f WebService.cs `
  -m 1 `
  -n eBay.Service.Core.Soap `
  -l cs `
  -p Source\eBay.Service.SDK\Core\Soap `
  -w $wsdlPath
```

The generator overwrites `Source/eBay.Service.SDK/Core/Soap/WebService.cs` and pauses for a key after generation. Confirm it reports success, dismiss the pause, then check the generated date and diff.

## 4. Reconcile API and schema changes

Build errors such as missing request, response, or enum types usually mean the newer WSDL removed or changed an API still used by a wrapper. For each affected API:

1. Confirm the operation or type is absent from the new WSDL; do not infer removal from one compiler error alone.
2. Search the whole repository for its wrapper and types, including SDK helpers, `Source/Helper`, sanity tests, and samples.
3. Update compatible code where possible. If an operation was removed, remove its project compile entry and obsolete wrapper/helper only after accounting for its dependents.
4. Update or remove tests and samples that use the removed API. Do not leave those projects referring to deleted types.

WSDL version 1487 removed several older operations, including `GetCategories`, `GetCategoryFeatures`, VeRO operations, and `GetAdFormatLeads`. This is a historical example, not a list to apply blindly to future WSDLs.

Review generated changes rather than hand-editing `WebService.cs` to restore types missing from the WSDL.

## 5. Set the NuGet release version

Choose the next NuGet package version independently of the WSDL version. Update both:

- `Source/eBay.Service.SDK/eBay.Service.SDK.nuspec`: the metadata `<version>` value and release notes.
- `README.md`: the current version and every Package Manager Console, .NET CLI, Paket, and `PackageReference` example.

Do not change the assembly version to the NuGet version; assembly versions track the Trading API compatibility version as described above.

## 6. Build and test

Build the SDK solution in Release. Disable COM registration because the default Release step requires registry write access:

```powershell
& $msbuild Source\DOTNET.SOAP.sln /t:Build /p:Configuration=Release /p:RegisterForComInterop=false /m
if ($LASTEXITCODE -ne 0) { throw 'SDK solution build failed.' }
```

Confirm the SDK DLLs exist under `Source/eBay.Service.SDK/bin/Release` and the Helper output is under `Source/Helper/bin/Release`. Build the sanity-test and sample projects affected by the API changes as well; the main SDK solution does not compile all of them.

## 7. Pack and verify the NuGet package

Make sure `Source/eBay.Service.SDK/eBay.Service.SDK.nuspec` maps the README and the built SDK DLLs to the package. Download the official NuGet CLI if `nuget.exe` is not installed:

```powershell
$nuget = Join-Path $env:TEMP 'nuget.exe'
if (!(Test-Path $nuget)) {
    Invoke-WebRequest `
      -Uri 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe' `
      -OutFile $nuget
}
```

Pack from the repository root, using the SDK project as the nuspec base path:

```powershell
$outputDirectory = '.\nupkgs\generated-' + (Get-Date -Format 'yyyyMMdd')
New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
& $nuget pack Source\eBay.Service.SDK\eBay.Service.SDK.nuspec `
  -BasePath Source\eBay.Service.SDK `
  -OutputDirectory $outputDirectory
if ($LASTEXITCODE -ne 0) { throw 'NuGet packaging failed.' }
```

Inspect the `.nupkg` with `tar -tf <package-path>`. Confirm it contains the README and both `lib/net48/eBay.Service.dll` and `lib/net48/eBay.Service.SDK.Attribute.dll`; check that its nuspec and embedded README show the same NuGet version. NuGet may warn about the legacy `licenseUrl` metadata or the missing explicit .NET Framework 4.8 dependency group.

## 8. Final review

Run `git diff --check`, inspect `git status` and the complete diff, and confirm the WSDL version, both assembly versions, `ApiContext` default, README version, nuspec version, and package contents agree. Keep generated packages and unrelated local changes out of the commit unless they are intentionally part of the release.