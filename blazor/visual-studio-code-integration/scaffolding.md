---
layout: post
title: Scaffolding with Blazor scaffolder in VS Code | Syncfusion®
description: Step‑by‑step guide to scaffold with Syncfusion Blazor Scaffolder Extension in Visual Studio Code, simplifying project creation.
platform: Blazor
control: Common
documentation: ug
---

# Syncfusion Blazor Scaffolder

The [Syncfusion® Blazor Scaffolder](https://marketplace.visualstudio.com/items?itemName=SyncfusionInc.Blazor-Scaffolder-VSCode-Extensions) in Visual Studio Code helps you generate Razor pages and controller/service code that interact with your data models. It accelerates common data workflows for controls like controls like [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), [TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid), [Charts](https://www.syncfusion.com/blazor-components/blazor-charts), [Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler), and [Diagram](https://www.syncfusion.com/blazor-components/blazor-diagram-component) by scaffolding CRUD-ready files and UI markup. The Syncfusion® Blazor Scaffolder is available from `v32.2.3` or later.

N> Check that at least one Entity Framework model exists, and the application has been compiled once. If no Entity Framework model exists in your application, refer to this [documentation](https://www.freecodecamp.org/news/how-to-create-an-application-using-blazor-and-entity-framework-core-1c1679d87c7e/) to generate the Entity Framework model. After the model file has been added, check that the required `DbContext` and properties are added. Now, build the application, and try scaffolding. If any changes made in the model properties, rebuild the application once before perform scaffolding.

## Add a scaffolded item

Before starting, confirm the **Syncfusion Blazor Scaffolder Extension** is installed by opening the Extensions view (**Ctrl+Shift+X**) and searching for it under the **Installed** tab. If not installed, follow the steps in the [download and installation](download-and-installation) help topic.

1. In the **Explorer** panel, right-click the project `.csproj` file and choose **Syncfusion Blazor UI Scaffolder**.

    For Blazor Server: right-click the app project `.csproj`.

    ![Scaffolded add-in from server project](images/add_scaffold_serverside.webp)

    For Blazor Hosted: right-click the `{ProjectName}.Server` `.csproj`.

    ![Scaffolded add-in from the hosted project](images/add_scaffold_hosted.webp)

2. The Scaffolder UI launches. Select the target control and click **Next**.

    ![Choose required control](images/control_window.webp)

3. Configure the control and data source.

    Select Data Source Type:

    - Local Data (default): Enter the **Controller/Service name**, **Razor page name**, pick the **Model class**, and choose the **DbContext**.

      ![Choose required Model](images/model_window_local.webp)

    - Remote Data: Enter the **Razor page name**, choose the **Adaptor type**, provide the **URL**, and set the `TValue`.

      - For DataGrid/TreeGrid using the **URL adaptor**, choose between **Localhost URL** (requires a Controller/Service name and model/DbContext) or **API URL** (use a valid API endpoint).

        ![Choose required Model](images/model_window_remote.webp)

      - Example adaptor links in the UI are placeholders for demonstration and do not perform full CRUD operations. To enable real CRUD, supply a valid back-end endpoint that supports the required operations.

4. On the features screen, choose the control features and map data fields as needed, then click **Add**.

    ![Choose required selected control features for the hosted project](images/fetaure_window_hosted_feature.webp)

5. Scaffolding will generate the **Controller/Service** and **Razor** files according to your selections:

    - Local Data: Adds service and Razor files.

      ![Required Controller and Razor files added in the project for the selected control](images/files_for_local_data.webp)

    - Remote Data (Localhost URL): Adds controller and Razor files.

      ![Required Controller and Razor files added in the project for the selected control](images/files_for_remote_data.webp)

    - Remote Data (API adaptor): Adds Razor files integrated with the chosen adaptor.

      ![Required Controller and Razor files added in the project for the selected control](images/files_for_remote_data_adaptor.webp)

6. Add a navigation entry to your app to access the newly created Razor page.

N> If you installed the trial setup or NuGet packages from [nuget.org](https://www.nuget.org), you must register the Syncfusion license key. Refer to the [licensing overview](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for details on generating and registering your license key.  

## See also

- [Overview of Blazor Extension for Visual Studio Code](overview.md)
- [Download and Installation for Visual Studio Code](download-and-installation.md)
- [Create Project Template for Visual Studio Code](create-project.md)
- [Code Snippets for Visual Studio Code](code-snippet.md)
- [Convert Project for Visual Studio Code](convert-project.md)
- [Upgrade Project for Visual Studio Code](upgrade-project.md)
