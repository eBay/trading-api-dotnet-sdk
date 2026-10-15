# Trading API .NET SDK: Agent Guide

## Project overview

This repository is the eBay Trading API (SOAP) SDK for .NET, published to NuGet as `eBay.Service.SDK`. It targets .NET Framework 4.8 and uses old-style `.csproj` files that list every source file explicitly. The SOAP proxy is generated from the Trading API WSDL; the rest of the SDK wraps it with per-API call classes.

## Repository map

| Path | Purpose |
| --- | --- |
| `wsdl/eBaySvc.wsdl` | Checked-in Trading API WSDL (source of truth for generation). |
| `Source/eBay.Service.SDK/` | Main SDK (`eBay.Service.dll`). `Call/` holds per-API wrappers, `Core/Sdk/ApiContext.cs` holds the default API version, and `Core/Soap/WebService.cs` is generated. |
| `Source/eBay.Service.SDK.Attribute/` | Attribute library (`eBay.Service.SDK.Attribute.dll`). |
| `Source/Helper/` | Helper library used by samples. |
| `Source/SanityTest/` | Sanity/unit tests (`UnitTests.sln`, not part of `DOTNET.SOAP.sln`). |
| `Tools/CodeGen/` | Command-line proxy generator (`CodeGen.sln`). |
| `Tools/Generator/` | Visual Studio custom-tool generator. |
| `Samples/C#`, `Samples/VB.NET` | Sample apps with their own solutions. |
| `docs/Release Notes/` | Release notes. |

## Editing rules

- Never hand-edit `Source/eBay.Service.SDK/Core/Soap/WebService.cs`; regenerate it from the WSDL.
- Because `.csproj` files list `Compile Include` entries, adding or deleting a source file also requires a project file edit.
- Two version schemes exist and must stay independent: the Trading API WSDL version (assembly versions and `ApiContext` default) and the NuGet package version (nuspec and `README.md`).
- Do not commit build output (`bin/`, `obj/`) or generated `.nupkg` files unless intentionally part of a release.

## Platform support

Commands below are PowerShell 7 (`pwsh`), which runs on Windows, macOS, and Linux. Use forward slashes in repository paths and run from the repository root.

| Steps | Needs Windows? |
| --- | --- |
| 1 (download WSDL), 2 (versions), 4 (reconcile), 5 (NuGet version), 8 (review) | No. These are file and text operations. |
| 3 (regenerate proxy), 6 (build), 7 (pack) | Yes. They depend on Visual Studio MSBuild and .NET Framework 4.8 assemblies such as `System.Web.Services` and `System.Windows.Forms`. Mono or `dotnet build` is not verified for this repository. |

On macOS or Linux, do the portable steps and leave the Windows-only steps to a Windows machine or CI runner; do not substitute unverified tooling.

# Upgrade the SDK to a Newer Trading API WSDL

Use this checklist when updating the SDK to a newer eBay Trading API WSDL. Keep the NuGet package version separate from the Trading API WSDL version.

## Prerequisites

- PowerShell 7 or later (`pwsh`).
- For steps 3, 6, and 7: Windows with Visual Studio 2022 and the .NET Framework 4.8 targeting pack.
- Internet access to `https://developer.ebay.com/webservices/latest/ebaysvc.wsdl`.
- A clean or otherwise understood Git worktree. Preserve user changes when updating generated files.

## 1. Download and validate the latest WSDL

Download to a temporary file first so a failed request cannot truncate the checked-in WSDL:

```powershell
$wsdlUrl = 'https://developer.ebay.com/webservices/latest/ebaysvc.wsdl'
$temporaryWsdl = Join-Path ([System.IO.Path]::GetTempPath()) 'ebaysvc-latest.wsdl'
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

Copy-Item $temporaryWsdl 'wsdl/eBaySvc.wsdl' -Force