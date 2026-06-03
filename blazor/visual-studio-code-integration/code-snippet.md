---
layout: post
title: Code snippets for Blazor Extension in VS code | Syncfusion®
description: Learn how to use the code snippet feature in the Syncfusion Blazor extension for Visual Studio Code to quickly insert Blazor component markup and common scenarios.
platform: Blazor
control: Common
documentation: ug
---

# Add Syncfusion Blazor Components Using Code Snippets

The [Syncfusion Blazor](https://www.syncfusion.com/blazor-components) extension for Visual Studio Code speeds up component insertion by providing ready-to-use Razor markup and placeholders for common features.

## Quick start

1. Open your Blazor project in Visual Studio Code and the target Razor file.
2. Position the cursor where you want the component markup inserted.
3. Type the `sf` prefix using the convention:

    ```
    sf<Syncfusion component name>-<feature>
    ```
    For example, type `sfgrid-grouping` to insert a DataGrid with grouping enabled.
4. Choose the snippet from the suggestions and press Enter or Tab. The component markup is inserted with editable placeholders.

    ![Animated demo showing insertion of a Syncfusion Blazor code snippet](images/codesnippet.webp)

5. Use Tab to navigate placeholders and fill required values. Inline comments in the snippet highlight required fields.

    ![Snippet comments highlighting required placeholders](images/comment.webp)

6. Each snippet includes a help link at the top so you can quickly access the relevant documentation for the inserted component or feature.

    ![Help link shown at the top of the inserted snippet](images/help.webp)

## After inserting a snippet — project configuration checklist

The snippet only adds Razor markup. To render Syncfusion components correctly, ensure the project is configured as follows:

- Add the required Syncfusion NuGet package(s). Individual packages are recommended — refer to [Benefits of using individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages#benefits-of-using-individual-nuget-packages) for details.

    ![NuGet Package](images/nuget-snippet.webp)

- Import Syncfusion namespaces in `~/_Imports.razor`.

    ![Namespace](images/namespace-snippet.webp)

- Include a Syncfusion [theme](https://blazor.syncfusion.com/documentation/appearance/themes) stylesheet in the page head: 
    - `~/Components/App.razor` — (Blazor Web App)
    - `~/Pages/_Host.cshtml` — (Blazor Server)
    - `~/wwwroot/index.html` — (Blazor WebAssembly)

    ![Themes](images/themes-snippet.webp)

- Register the Syncfusion Blazor service in the appropriate `Program.cs` files. For interactive Web App render modes `WebAssembly` or `Auto`, register in both `Program.cs` files when applicable.

    ![Registration of the Syncfusion Blazor service](images/configuration-snippet.webp)

N> If you installed the trial setup or NuGet packages from [nuget.org](https://www.nuget.org), you must register the Syncfusion license key. Refer to the [licensing overview](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for details on generating and registering your license key. 

## See also

- [Overview of Blazor Extension for Visual Studio Code](overview.md)
- [Download and Installation](download-and-installation.md)
- [Create Project Template](create-project.md)
- [Convert Project](convert-project.md)
- [Upgrade Project](upgrade-project.md)
- [Scaffolding](scaffolding.md)