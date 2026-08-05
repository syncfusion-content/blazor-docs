---
layout: post
title: Code generator for the Blazor extension | Syncfusion®
description: Learn how to add Blazor component markup using the Code Generator in the Blazor extension for Visual Studio. Explore to more details.
platform: Blazor
control: Common
documentation: ug
---

# Add Syncfusion® Blazor component code

This topic explains how to use the Syncfusion® Blazor Code Generator to insert component markup into a Razor file and automatically configure the project with required packages, styles, and namespaces. The Code Generator is a wizard that reads your project's data models and inserts ready-to-use component markup.

## Prerequisites

- Visual Studio 2022 or 2026 with the Syncfusion® Blazor extension installed. See [download and installation](download-and-installation) if it is not installed.
- A Blazor project that builds successfully. Build the project (Ctrl+Shift+B) before running the Code Generator so that its data models appear in the wizard's data-binding list.

## Steps

1. Open your Blazor application in Visual Studio. To create a new Blazor application, use the [Template Studio](template-studio).

2. Open the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Code Generator from a Razor file using one of these options:

    **Option 1 — Editor context menu**

    - Right-click at the insertion point in the Razor file editor and choose **Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Code Generator...**

        ![CodeGeneratorCommand](images/code-generator-command.webp)

    **Option 2 — Visual Studio menu**

    - Place the cursor in the .razor file, then choose **Extensions → Syncfusion → Essential Studio for Blazor → Syncfusion Blazor Code Generator…**

        ![CodeGeneratorMenu](images/code-generator-menu.webp)

3. In the Code Generator wizard, complete the following sub-steps for the selected component:

    1. **Select component**: pick the Syncfusion Blazor component to add (for example, DataGrid, Chart, Scheduler).
    2. **Data binding**: if the component supports data, the wizard lists models and data sources from your project so you can bind quickly.
    3. **Features**: choose the features you need for the component (sorting, filtering, paging, and so on, where applicable).
    4. **Component requirements**: provide any required inputs to complete the generated markup, such as `TValue`, data source URL, or primary-key field.

    ![CodeGeneratorWizard](images/code-generator-mainwizard.webp)

    Click **Insert** to add the generated markup at the cursor location. The Code Generator adds or updates the NuGet package references, required styles, and `using` statements in the active Razor file.

    ![ComponentRenderCode](images/code-generator-componentrendercode.webp)

4. Review the changes in the Visual Studio Output window. Open the Output window via **View → Output**, then select **Syncfusion Blazor Code Generator** from the **Show output from** list. The Code Generator inserts the component markup into the active Razor file and adds or updates NuGet package references, required styles, and `using` statements.

    ![OutputWindow](images/code-generator-outputwindow.webp)

5. If you have installed the trial setup or NuGet packages from nuget.org, register the Syncfusion® license key in your application. Syncfusion® introduced the licensing system in the 2018 Volume 2 (v16.2.0.41) Essential Studio® release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion® license key. Refer to this [blog post](https://www.syncfusion.com/blogs/post/whats-new-in-2018-volume-2) for more information on the licensing changes introduced in Essential Studio®.

## Supported components

The Code Generator supports the major Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components, including DataGrid, Charts, Scheduler, Diagram, TreeGrid, Rich Text Editor, Document Editor, PDF Viewer, and others. The exact list of components in the wizard matches the components available in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package installed in your project.

## See also

- [Template Studio](template-studio)
- [Convert project](convert-project)
- [Scaffolding](scaffolding)
