---
layout: post
title: Syncfusion .NET CLI Overview for Blazor | Syncfusion®
description: Learn to install and use the Syncfusion® .NET CLI (sf) to create Blazor apps with Syncfusion component demos, manage Syncfusion Blazor NuGet packages, and register licenses.
platform: Blazor
control: Syncfusion<sup>®</sup> .NET CLI
documentation: UG
---

# Overview of the Syncfusion<sup>®</sup> .NET CLI

The Syncfusion<sup>®</sup> .NET CLI (`sf`) is a cross-platform command line tool that creates Blazor projects, manages Syncfusion<sup>®</sup> Blazor NuGet packages, and registers licenses from a terminal. After you install the CLI, you can run `sf` with no arguments to open an interactive menu, or run a direct command such as `sf new blazor` for scripted, prompt-free creation.

N> The Syncfusion<sup>®</sup> .NET CLI is currently in preview and is installed with the `--prerelease` flag.

You can use the CLI to perform the following actions:

* Create a Blazor Web App (Server, WebAssembly, or Auto render mode) or a standalone Blazor WebAssembly app, optionally containing generated Syncfusion<sup>®</sup> component demo pages. For details, refer to [Create a Blazor project](/blazor/dotnet-cli/create-project).
* Add, update, list, and search Syncfusion<sup>®</sup> Blazor NuGet packages in an existing project. For details, refer to [Manage packages](/blazor/dotnet-cli/manage-packages).
* Activate Syncfusion<sup>®</sup> licenses for the controls used in a sample, and view installed licenses. For details, refer to [License activation](/blazor/dotnet-cli/licensing).
* Configure an official Syncfusion<sup>®</sup> Model Context Protocol (MCP) server for AI coding clients. For details, refer to [MCP configuration](/blazor/dotnet-cli/configure-mcp).
* Install official Syncfusion<sup>®</sup> component skills for AI agents. For details, refer to [AI skills installation](/blazor/dotnet-cli/install-skills).
* Generate projects for Blazor, .NET MAUI, WPF, WinForms, and WinUI 3.

This documentation covers the Blazor platform.

## Prerequisites

The following software is required before you install and use the CLI:

* A [.NET SDK](https://dotnet.microsoft.com/download) that contains the ASP.NET Core Blazor templates. The CLI creates Blazor projects through the installed official `blazor` and `blazorwasm` templates; it does not carry its own copy of those templates.
* Network access to the configured NuGet sources when restore or build is selected.
* A Syncfusion<sup>®</sup> account to activate licenses. Sign in is performed through the browser during license activation. See the [licensing overview](https://help.syncfusion.com/common/essential-studio/licensing/overview) for details.

N> The CLI reads each installed template's help output and offers only the target frameworks the installed template reports. .NET 10 (`net10.0`) is the default when available.

N> Syncfusion<sup>®</sup> packages resolve from the official nuget.org feed, `https://api.nuget.org/v3/index.json`. Package installs resolve the latest stable release and write a concrete version, never `*`. Use `--version` to pin a release.

## Installation and setup

The CLI is published as a .NET global tool with the package ID `Syncfusion.DotNet.CLI`.

1. Open a terminal and run the following command. Add `--prerelease` while only preview versions are available.

    {% tabs %}
    {% highlight bash tabtitle="Bash" %}

    dotnet tool install -g Syncfusion.DotNet.CLI --prerelease

    {% endhighlight %}
    {% endtabs %}

2. Verify the installation and print the CLI version.

    {% tabs %}
    {% highlight bash tabtitle="Bash" %}

    sf --version

    {% endhighlight %}
    {% endtabs %}

3. Add the global tools directory to the `PATH` environment variable if the `sf` command is not found after installation. The .NET global tools are installed in `%USERPROFILE%\.dotnet\tools` (Windows) or `~/.dotnet/tools` (Linux/macOS), and this directory must be on the `PATH`.

    | Environment variable | Value |
    | --- | --- |
    | `PATH` | `%USERPROFILE%\.dotnet\tools` |

4. Run `sf help` for a short command map, or `sf help blazor` for the Blazor command map and package aliases.

![Help output in the Syncfusion .NET CLI](images/cli-help-output.png)

To update the tool to the latest release, run:

{% tabs %}
{% highlight bash tabtitle="Bash" %}

dotnet tool update -g Syncfusion.DotNet.CLI --prerelease

{% endhighlight %}
{% endtabs %}

To remove the tool, run:

{% tabs %}
{% highlight bash tabtitle="Bash" %}

dotnet tool uninstall -g Syncfusion.DotNet.CLI

{% endhighlight %}
{% endtabs %}

## Initialize the CLI

Run `sf` in an interactive terminal to open the main menu. The menu shows the current CLI version and groups the available operations.

![Syncfusion .NET CLI main menu](images/cli-main-menu.png)

| Group | Operation | Command reference |
| --- | --- | --- |
| Project creation | Create a new project | `sf new` |
| Package management | Add a package to an existing project | `sf add` |
| Package management | Update a package in an existing project | `sf update` |
| Discovery | List available packages | `sf list <platform> packages` |
| Discovery | List installed packages in an existing project | `sf list <platform> installed` |
| Discovery | Search for packages | `sf search` |
| AI & Skills | Setup Model Context Protocol (MCP) | `sf mcp init` |
| AI & Skills | Add component skills to AI Agent | `sf skills install` |
| License management | Activate license | `sf license activate` |
| License management | View installed licenses | `sf license view` |
| License management | Sign in to Syncfusion | `sf login` |
| License management | Sign out | `sf logout` |
| Help and information | View CLI information | `sf info` |
| Help and information | Show help | `sf help` |
| Help and information | Exit the interactive session | `Ctrl+C` |

N> The `<platform>` text is a usage placeholder. Use `blazor` for Blazor.

Complete direct commands remain usable without opening the menu. `--no-interactive` disables prompts in any command. Run `sf help blazor` to show the Blazor command map and package aliases.

## Available commands

| Command | Purpose | For details, refer to |
| --- | --- | --- |
| `sf new blazor` | Create a new Blazor project | [Create a Blazor project](/blazor/dotnet-cli/create-project) |
| `sf add blazor <package>` | Add a Syncfusion<sup>®</sup> package to an existing project | [Manage packages](/blazor/dotnet-cli/manage-packages) |
| `sf update blazor <package>` | Update a package in an existing project | [Manage packages](/blazor/dotnet-cli/manage-packages) |
| `sf list blazor packages` | List available packages in the Blazor package catalog | [Manage packages](/blazor/dotnet-cli/manage-packages) |
| `sf list blazor installed` | List installed packages in an existing project | [Manage packages](/blazor/dotnet-cli/manage-packages) |
| `sf search blazor <text>` | Search package aliases, IDs, names, and descriptions | [Manage packages](/blazor/dotnet-cli/manage-packages) |
| `sf mcp init blazor` | Configure a project-local Syncfusion<sup>®</sup> MCP client | [MCP configuration](/blazor/dotnet-cli/configure-mcp) |
| `sf skills install blazor` | Install Syncfusion<sup>®</sup> component skills for AI agents | [AI skills installation](/blazor/dotnet-cli/install-skills) |
| `sf login` | Sign in to Syncfusion through the browser | [License activation](/blazor/dotnet-cli/licensing) |
| `sf logout` | Sign out and clear the local session | [License activation](/blazor/dotnet-cli/licensing) |
| `sf license activate` | Download the license for the project's packages and register it in the project's startup code | [License activation](/blazor/dotnet-cli/licensing) |
| `sf license view` | Show the licenses cached for the project (no network call) | [License activation](/blazor/dotnet-cli/licensing) |
| `sf info` | Show CLI information | |
| `sf help blazor` | Show the Blazor command map and package aliases | |
| `sf --version` | Show the CLI version | |

## Global options

| Option | Description |
| --- | --- |
| `-h`, `--help` | Show command help |
| `--version` | Show the CLI version |
| `--interactive` | Allow prompts when running in an interactive terminal |
| `--no-interactive` | Disable prompts |
| `--json` | Emit machine-readable output |
| `--verbose` | Write diagnostics to stderr |
| `--no-color` | Disable colored output |

## FAQs

**Which platforms does the CLI support?**

Blazor, .NET MAUI, WPF, WinForms, and WinUI 3. This documentation covers Blazor.

## See also

* [Syncfusion Blazor components](https://www.syncfusion.com/blazor-components)
* [Get started with Syncfusion Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Install Syncfusion Blazor NuGet packages](https://blazor.syncfusion.com/documentation/installation/install-nuget-packages)
* [Syncfusion<sup>®</sup> licensing overview](https://help.syncfusion.com/common/essential-studio/licensing/overview)
