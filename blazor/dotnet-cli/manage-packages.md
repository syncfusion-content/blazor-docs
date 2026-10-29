---
layout: post
title: Manage Syncfusion Blazor NuGet Packages using .NET CLI | Syncfusion®
description: Learn here about how to add, update, list, and search Syncfusion® Blazor NuGet packages in an existing project using the Syncfusion® .NET CLI (sf).
platform: Blazor
control: Syncfusion<sup>®</sup> .NET CLI
documentation: UG
---

# Manage packages in an existing project

Package operations change NuGet references only. They do not generate control files.

`<package>` accepts a canonical package alias, a canonical package ID, or an exact unambiguous package display name:

```bash
sf add blazor grid --path ./MyApp
sf update blazor grid --path ./MyApp
```

Existing-project commands accept `-p/--path` with a project file, a project directory, or a supported subdirectory. Without it, the current directory is used. A directory with one Blazor project is selected automatically; when multiple projects are present, interactive mode presents a selector and non-interactive mode requires an explicit project path. `--json` emits one JSON document for script use.

## List packages

To list the available and installed packages:

```bash
sf list blazor packages
sf list blazor installed --path ./MyApp
```

Use `--details` on the list command for package descriptions, release status, registration requirements, documentation links, and whether a generated sample is available.

![Available packages in the Syncfusion .NET CLI](images/cli-list-available-packages.png)

## Search packages

To search the package catalog:

```bash
sf search grid --framework blazor
```

## Package operation options

| Option | Description |
| --- | --- |
| `-p`, `--path` | The project directory, `.csproj` file, or a supported subdirectory |
| `-v`, `--version` | The Syncfusion<sup>®</sup> NuGet package version |
| `--source` | Package source; Syncfusion<sup>®</sup> packages require `https://api.nuget.org/v3/index.json` |
| `--configfile` | The NuGet configuration file to use |
| `--dry-run` | Preview the action without making changes |
| `--force` | Allow supported overwrites |
| `--no-restore` | Skip `dotnet restore` after the action |
| `--json` | Emit one JSON document |

## FAQs

**Does `sf add blazor grid` generate the Grid demo?** No. Package operations change NuGet references only; they do not generate control files. Use `sf new blazor --control grid` during creation, or generate demos from the creation wizard.

## See also

* [Create a Blazor project](/blazor/dotnet-cli/create-project)
* [License activation](/blazor/dotnet-cli/licensing)
* [Install Syncfusion Blazor NuGet packages](https://blazor.syncfusion.com/documentation/installation/install-nuget-packages)
