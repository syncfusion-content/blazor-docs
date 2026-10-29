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

Existing-project commands accept `-p/--path` with a project file, a project directory, or a supported subdirectory. Without it, the current directory is used. A directory with one Blazor project is selected automatically; when multiple projects are present, interactive mode presents a selector and **No Interactive** mode requires an explicit project path. `--json` emits one JSON document for script use.

## Install a package by package name

Use the canonical package alias to add a Syncfusion<sup>®</sup> Blazor NuGet package reference to an existing project. For example, to add the Blazor DataGrid package by its alias (`grid`):

{% tabs %}
{% highlight bash tabtitle="Bash" %}

sf add blazor grid --path ./MyApp

{% endhighlight %}
{% endtabs %}

## Install a package using the exact package identifier

Use the canonical package ID or an exact, unambiguous package display name instead of the alias. For example, to add the Blazor DataGrid package by its package ID:

{% tabs %}
{% highlight bash tabtitle="Bash" %}

sf add blazor Syncfusion.Blazor.Grid --path ./MyApp

{% endhighlight %}
{% endtabs %}

## Update a package

To update a package in an existing project, use the same alias, ID, or display name:

{% tabs %}
{% highlight bash tabtitle="Bash" %}

sf update blazor grid --path ./MyApp

{% endhighlight %}
{% endtabs %}

## List all available packages

To list the packages available in the Blazor package catalog:

{% tabs %}
{% highlight bash tabtitle="Bash" %}

sf list blazor packages

{% endhighlight %}
{% endtabs %}

Use `--details` on the list command for package descriptions, release status, registration requirements, documentation links, and whether a generated sample is available.

![Available packages in the Syncfusion .NET CLI](images/cli-list-available-packages.png)

## List installed packages

To list the Syncfusion<sup>®</sup> packages already installed in an existing project:

{% tabs %}
{% highlight bash tabtitle="Bash" %}

sf list blazor installed --path ./MyApp

{% endhighlight %}
{% endtabs %}

## Search packages

To search the package catalog:

{% tabs %}
{% highlight bash tabtitle="Bash" %}

sf search grid --framework blazor

{% endhighlight %}
{% endtabs %}

The search matches package aliases, IDs, names, and descriptions.

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

**Does `sf add blazor grid` generate the Grid demo?**

No. Package operations change NuGet references only; they do not generate control files. Use `sf new blazor --control grid` during creation, or generate demos from the creation wizard.

## See also

* [Create a Blazor project](/blazor/dotnet-cli/create-project)
* [License activation](/blazor/dotnet-cli/licensing)
* [Install Syncfusion Blazor NuGet packages](https://blazor.syncfusion.com/documentation/installation/install-nuget-packages)
