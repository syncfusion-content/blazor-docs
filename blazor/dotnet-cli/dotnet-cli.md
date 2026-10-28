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

* Create a Blazor Web App (Server, WebAssembly, or Auto render mode) or a standalone Blazor WebAssembly app, optionally containing generated Syncfusion<sup>®</sup> component demo pages.
* Add or update Syncfusion<sup>®</sup> Blazor NuGet package references in an existing project.
* List available and installed packages, and search the package catalog.
* Activate Syncfusion<sup>®</sup> licenses for the controls used in a sample, and view installed licenses.
* Generate projects for Blazor, .NET MAUI, WPF, WinForms, and WinUI 3.

This documentation covers the Blazor platform.

## Prerequisites

The following software is required before you install and use the CLI:

* A [.NET SDK](https://dotnet.microsoft.com/download) that contains the ASP.NET Core Blazor templates. The CLI creates Blazor projects through the installed official `blazor` and `blazorwasm` templates; it does not carry its own copy of those templates.
* Network access to the configured NuGet sources when restore or build is selected.
* A Syncfusion<sup>®</sup> account to activate licenses. Sign in is performed through the browser during license activation. See the [licensing overview](https://help.syncfusion.com/common/essential-studio/licensing/overview) for details.

N> The CLI reads each installed template's help output and offers only the target frameworks the installed template reports. .NET 10 (`net10.0`) is the default when available.

N> Syncfusion<sup>®</sup> packages resolve from the official nuget.org feed, `https://api.nuget.org/v3/index.json`. Package installs resolve the latest stable release and write a concrete version, never `*`. Use `--version` to pin a release.

## Installation

The CLI is published as a .NET global tool with the package ID `Syncfusion.DotNet.CLI`.

1. Open a terminal and run the following command. Add `--prerelease` while only preview versions are available.

    ```bash
    dotnet tool install -g Syncfusion.DotNet.CLI --prerelease
    ```

2. Verify the installation and print the CLI version.

    ```bash
    sf --version
    ```

Run `sf help` for a short command map, or `sf help blazor` for the Blazor command map and package aliases.

![Help output in the Syncfusion .NET CLI](images/cli-help-output.png)

To update the tool to the latest release, run:

```bash
dotnet tool update -g Syncfusion.DotNet.CLI --prerelease
```

To remove the tool, run:

```bash
dotnet tool uninstall -g Syncfusion.DotNet.CLI
```

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
| License management | Activate license | `sf license activate` |
| License management | View installed licenses | `sf license view` |
| License management | Sign in to Syncfusion | `sf login` |
| License management | Sign out | `sf logout` |
| Help and information | View CLI information | `sf info` |
| Help and information | Show help | `sf help` |
| Exit | Exit | `Ctrl+C` |

N> The `<platform>` text is a usage placeholder. Use `blazor` for Blazor.

Use the following keys to navigate the interactive screens:

| Key | Action |
| --- | --- |
| Up / Down | Move through the options |
| Enter | Choose the focused option, or continue |
| Space | Toggle a checkbox in a multi-selection list |
| Escape | Cancel the current question and return to the menu |
| `Ctrl+C` | Exit the interactive session |

Complete direct commands remain usable without opening the menu. `--no-interactive` disables prompts in any command. Run `sf help blazor` to show the Blazor command map and package aliases.

## Available commands

| Command | Purpose |
| --- | --- |
| `sf new blazor` | Create a new Blazor project |
| `sf add blazor <package>` | Add a Syncfusion<sup>®</sup> package to an existing project |
| `sf update blazor <package>` | Update a package in an existing project |
| `sf list blazor packages` | List available packages in the Blazor package catalog |
| `sf list blazor installed` | List installed packages in an existing project |
| `sf search blazor <text>` | Search package aliases, IDs, names, and descriptions |
| `sf login` | Sign in to Syncfusion through the browser |
| `sf logout` | Sign out and clear the local session |
| `sf license activate` | Download the license for the project's packages and register it in the project's startup code |
| `sf license view` | Show the licenses cached for the project (no network call) |
| `sf info` | Show CLI information |
| `sf help blazor` | Show the Blazor command map and package aliases |
| `sf --version` | Show the CLI version |

## Create a Blazor project

You can create a Blazor project through the interactive wizard or a direct command.

### Create a project using the interactive wizard

Run `sf new`, or select **Create a new project** from the main menu. The Blazor creation flow collects these inputs, in this order:

1. **Platform:** Select **Blazor**.

    ![Framework selection in the Syncfusion .NET CLI](images/cli-create-new-project.png)

2. **Application type:** Select **Blazor Web App** or **Blazor WebAssembly App (standalone)**.
3. **Language:** C# is recorded automatically.
4. **Target framework:** Select the .NET version. Only the target frameworks reported by the installed official template are offered; .NET 10 (`net10.0`) is the default when available.
5. **Interactive render mode and interactivity** (Blazor Web App only): Select **Server**, **WebAssembly**, or **Auto** render mode, and **Per page/component** or **Global** interactivity. A standalone WebAssembly app uses WebAssembly rendering automatically and does not prompt for an interactivity location.
6. **Authentication:** Select **None** or **Individual accounts**. The official Blazor Web App Individual Accounts template is supported and requires HTTPS. Standalone WebAssembly Individual authentication requires an external identity-provider authority and client ID, so the CLI rejects that combination instead of generating placeholder credentials.
7. **HTTPS:** Select **Yes** or **No**. HTTPS is fixed to **Yes** when **Individual accounts** is chosen.
8. **Project location and name:** Enter the parent directory and the project name. The project is created in `<location>/<name>`.
9. **Setup:** Select whether to include demo pages. Demo pages are included by default.
10. **Theme:** (Demo pages only) Select one of the Syncfusion component themes described in [Themes](#themes).
11. **Components:** (Demo pages only) Choose one or more Syncfusion component demos from the list. The picker starts with no components selected; use Space to select and Enter to continue after choosing at least one.
12. **Post-create:** Select **Generate only** or **Build project**.
13. **Confirmation:** Review the selected values and confirm to create the project.

N> A complete direct command does not open the wizard. When a name is missing in an interactive terminal, the wizard supplies a default and collects the remaining unspecified inputs. Missing required values in scripts produce an error.

13. Review the configured values and confirm to create the project.

    ![Configured Blazor project values in the Syncfusion .NET CLI](images/cli-configured-blazor-values.png)

N> For WebAssembly and Auto render modes, the CLI places the interactive demo pages, package references, imports, and service registration in the generated `.Client` project. The host project also receives `AddSyncfusionBlazor()` and the Syncfusion import so prerendering works.

N> Demo pages are generated as `<Component>Demo.razor` so they never collide with component type names. Creation is transactional until generation completes; failures roll back the newly created directory.

### Available components

The following component demos can be generated in a new Blazor project:

| Component | Component ID |
| --- | --- |
| AI AssistView | `ai-assistview` |
| Block Editor | `block-editor` |
| Charts | `charts` |
| Diagram | `diagram` |
| Document Editor | `document-editor` |
| File Manager | `file-manager` |
| Gantt Chart | `gantt` |
| Kanban | `kanban` |
| PDF Viewer | `pdf-viewer` |
| Pivot Table | `pivot-table` |
| Query Builder | `query-builder` |
| Scheduler | `scheduler` |
| Spreadsheet | `spreadsheet` |
| Data Grid | `grid` |
| Rich Text Editor | `rich-text-editor` |

N> The generated File Manager demo uses Syncfusion's public physical-file demonstration service. Replace those URLs with an application-owned, authenticated backend before production use. The PDF Viewer demo includes a small PDF as a data URI, avoiding a remote download and cross-origin restrictions. Spreadsheet creates a local budget workbook through XlsIO, and Document Editor starts with a blank editable document.

### Themes

The CLI supports the following Syncfusion component themes:

| Theme | Theme file |
| --- | --- |
| Fluent 2 | `fluent2.css` |
| Bootstrap 5.3 | `bootstrap5.3.css` |
| Bootstrap 5 | `bootstrap5.css` |
| Material 3 | `material3.css` |
| Tailwind 3 | `tailwind3.css` |

These styles theme the Syncfusion components; they do not replace the CSS framework used by Microsoft's application shell.

### Create a project using direct commands

To create a Blazor Web App with the interactive defaults (`web-app`, Server render mode, per-page interactivity, no authentication, HTTPS, Fluent 2 theme, and the Grid demo):

```bash
sf new blazor -n MyApp
```

To create a project with explicit options:

```bash
sf new blazor -n MyApp --render-mode server --control grid charts
```

To create a standalone Blazor WebAssembly app:

```bash
sf new blazor -n ClientApp --app-type webassembly-standalone --control grid
```

To create an official minimal project without Syncfusion packages or demos:

```bash
sf new blazor -n MyApp --control empty
```

Repeat `--control` or list several control IDs to generate multiple demos:

```bash
sf new blazor -n MyApp --control grid --control charts --post-action generate --no-interactive
```

## Run the created project

Run the generated project with the .NET CLI:

```bash
dotnet run --project ./MyApp/MyApp.csproj
```

N> `--post-action generate` runs the official template and writes project files without silently restoring or building. `--post-action build` restores and builds the project during creation.

![Generated Blazor project in the Syncfusion .NET CLI](images/cli-generated-blazor-project.png)

## Manage packages in an existing project

Package operations change NuGet references only. They do not generate control files.

`<package>` accepts a canonical package alias, a canonical package ID, or an exact unambiguous package display name:

```bash
sf add blazor grid --path ./MyApp
sf update blazor grid --path ./MyApp
```

Existing-project commands accept `-p/--path` with a project file, a project directory, or a supported subdirectory. Without it, the current directory is used. A directory with one Blazor project is selected automatically; when multiple projects are present, interactive mode presents a selector and non-interactive mode requires an explicit project path. `--json` emits one JSON document for script use.

To list available packages, list installed packages, and search the catalog:

```bash
sf list blazor packages
sf list blazor installed --path ./MyApp
sf search grid --framework blazor
```

Use `--details` on the list command for package descriptions, release status, registration requirements, documentation links, and whether a generated sample is available.

![Available packages in the Syncfusion .NET CLI](images/cli-list-available-packages.png)

## Activate Syncfusion<sup>®</sup> licenses

The CLI detects the Syncfusion<sup>®</sup> controls used in a project, downloads the matching license keys from your Syncfusion<sup>®</sup> account, and registers the keys in the project's startup code. For example, when a sample is created with the Chart component, the CLI registers the license for `Syncfusion.Blazor.Charts` in `Program.cs` so the build runs without a license warning.

N> Open the Command Prompt or Terminal in the target sample's project directory before running the license activation command. The license operation is project-specific, and the command path must point to the intended sample.

### How license activation works

1. The CLI scans the project at the current directory or at the path you pass through `--path`. It identifies the platform from the project file (`.csproj`) and detects all Syncfusion<sup>®</sup> `PackageReference` entries whose IDs start with `Syncfusion.`.
2. It checks your Syncfusion<sup>®</sup> account for entitlements that cover each detected package. When a paid or trial entitlement is available, the matching license keys are downloaded.
3. The keys are cached in `syncfusion-license.txt` and metadata in `.syncfusion/license-meta.json` inside the project directory.
4. The CLI inserts `SyncfusionLicenseProvider.RegisterLicense(...)` into the platform-specific startup file. For Blazor, the block is added to `Program.cs` before the application builder is created. The block is idempotent, so re-running the command refreshes the keys without duplicating the call.
5. If a control in the project is not covered by a paid entitlement, the CLI prompts you to accept the Syncfusion<sup>®</sup> trial EULA and download a trial key for the missing packages. Pass `--yes` to accept the prompt automatically.

### Activate a license through the interactive menu

1. Open the Command Prompt or Terminal in the target sample's project directory.

    ```bash
    cd D:\CLI\BlazorSample
    ```

2. Run `sf` to open the main menu.

    ```bash
    sf
    ```

3. Under **License management**, select **Activate license**. The CLI focuses the **Activate License** entry and shows the navigation hint at the bottom of the screen.

    ![Activate license option in the Syncfusion .NET CLI](images/cli-activate-license.png)

4. If you are not signed in, the CLI opens your default browser to the Syncfusion<sup>®</sup> sign-in page. Complete sign in with your Syncfusion<sup>®</sup> account.

    ![Syncfusion sign-in page in the browser](images/cli-license-sign-in.png)

5. After sign in, the CLI checks your entitlements, downloads the matching keys for the Syncfusion<sup>®</sup> controls in the sample, and registers the keys in `Program.cs`.

    ![License registered successfully in the Syncfusion .NET CLI](images/cli-license-registered.png)

6. Rebuild the application so the newly registered license is applied. The CLI prints the following reminder at the end of the activation output.

    > Note: Rebuild the application so the newly registered license is applied.

### Activate a license using a direct command

Run the activation command from the sample's project directory:

```bash
sf license activate
```

Pass `--path` to point the CLI at a specific project directory or `.csproj` file:

```bash
sf license activate --path ./MyApp
sf license activate --path ./MyApp/MyApp.csproj
```

Use `--yes` to accept the trial EULA prompt without asking:

```bash
sf license activate --yes
```

Use `--file` to activate from an existing key file. With no value, the CLI reads `./syncfusion-license.txt` from the project directory. With an absolute path, the CLI uses the specified file instead:

```bash
sf license activate --file
sf license activate --file C:\keys\syncfusion-license.txt
```

N> When a license key is supplied through `--file`, the CLI skips sign in and download and registers the keys already in the file. The file path must be absolute.

### View installed licenses

To see the licenses cached for the current project, run:

```bash
sf license view
```

The command reads the cached metadata, lists each product, the license type, the status, and the expiry date, and warns when a Syncfusion<sup>®</sup> package in the project is not covered.

![View installed licenses in the Syncfusion .NET CLI](images/cli-view-installed-license-menu.png)

The cached output reports the registered email, platform, major version, and one row per product.

![Installed license details in the Syncfusion .NET CLI](images/cli-view-installed-license.png)

### License operation notes

* License activation is project-specific. The command path must point to the intended sample, because each project is detected through its `.csproj` and scanned independently.
* The CLI writes `syncfusion-license.txt` and `.syncfusion/license-meta.json` to the project directory.
* The startup file the CLI modifies by platform is `Program.cs` for Blazor, `MauiProgram.cs` for .NET MAUI, `App.xaml.cs` for WPF, `App.xaml.cs` for WinUI, and `Program.cs` (or `Application.xaml.vb` for VB) for WinForms.
* Use `sf logout` to clear the local sign-in session. Use `sf login` to sign in again without running activation.

## Options reference

### Creation options

| Option | Description |
| --- | --- |
| `-n`, `--name` | Project name. Required when prompting is unavailable |
| `-p`, `--path` | Parent directory. Defaults to the current directory |
| `-t`, `--target-framework` | The .NET target framework, such as `net10.0` |
| `--app-type` | `web-app` (default) or `webassembly-standalone` |
| `--render-mode` | `server`, `webassembly`, or `auto` (Web App only) |
| `--interactivity` | `per-page` (default) or `global` (Web App only) |
| `--auth` | `none` (default) or `individual` |
| `--https` | `yes` or `no`. Fixed to `yes` with Individual accounts |
| `--theme` | Syncfusion component theme, such as `fluent2` |
| `--control` | One or more component IDs, or `empty`. Omit to create an empty project |
| `--post-action` | Post-create action: `generate` or `build`. Defaults to `build` for direct commands |
| `--no-interactive` | Disable interactive prompts |
| `--json` | Emit a JSON document instead of table output |

### Package operation options

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

### License options

| Option | Description |
| --- | --- |
| `-p`, `--path` | The project directory or `.csproj`/`.vbproj` to scan for Syncfusion<sup>®</sup> packages. Defaults to the current directory |
| `-y`, `--yes` | Accept the trial EULA prompt automatically during activation |
| `--file` | Activate from an existing key file. With no value, the CLI reads `./syncfusion-license.txt` from the project directory. With an absolute path, the CLI uses the specified file |
| `--json` | Emit one JSON document instead of table output |

### Global options

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

**Does the CLI register a license?** Yes. `sf license activate` scans the project for Syncfusion<sup>®</sup> `PackageReference` entries, downloads the matching license keys from your Syncfusion<sup>®</sup> account, and inserts `SyncfusionLicenseProvider.RegisterLicense(...)` into `Program.cs` (or the platform-specific startup file). The CLI signs you in through the browser the first time, or you can sign in ahead with `sf login`. For background information on Syncfusion<sup>®</sup> licensing, refer to the [licensing overview](https://help.syncfusion.com/common/essential-studio/licensing/overview).

**Does `sf add blazor grid` generate the Grid demo?** No. Package operations change NuGet references only; they do not generate control files. Use `sf new blazor --control grid` during creation, or generate demos from the creation wizard.

**Where does the CLI register the license for Blazor?** In `Program.cs`, before the application builder is created. For .NET MAUI, WPF, WinUI, and WinForms, the CLI targets `MauiProgram.cs`, `App.xaml.cs`, `App.xaml.cs`, and `Program.cs` respectively.

**Can I use my own key file?** Yes. Run `sf license activate --file C:\keys\syncfusion-license.txt` with an absolute path. The CLI reads the keys from the file and registers them in the project's startup code without contacting the license service.

**Which render modes are supported?** Blazor Web App supports Server, WebAssembly, and Auto interactive render modes, with per-page/component or global interactivity. Standalone WebAssembly apps use WebAssembly rendering automatically.

**Which .NET versions are supported?** The available target frameworks come from the installed official `blazor` and `blazorwasm` templates. .NET 10 (`net10.0`) is the default when available.

**Can I overwrite an existing project?** No. Neither `--force` nor confirmation authorizes overwriting an existing destination. Existing destination files or directories are not overwritten or merged, and the CLI does not pick another destination automatically.

**Which platforms does the CLI support?** Blazor, .NET MAUI, WPF, WinForms, and WinUI 3. This documentation covers Blazor.

## See also

* [Syncfusion Blazor components](https://www.syncfusion.com/blazor-components)
* [Get started with Syncfusion Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Install Syncfusion Blazor NuGet packages](https://blazor.syncfusion.com/documentation/installation/install-nuget-packages)
* [Interactive render modes in Blazor](https://blazor.syncfusion.com/documentation/common/interactive-render-mode)
* [Syncfusion<sup>®</sup> licensing overview](https://help.syncfusion.com/common/essential-studio/licensing/overview)