---
layout: post
title: Getting Stared with Blazor DocumentEditor in Server Side | Syncfusion
description: Learn here all about Getting Started with Syncfusion Blazor DocumentEditor in Blazor Server Side App using Visual Studio and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Blazor DocumentEditor Component in Server Side App

This article provides the step-by-step instructions to integrate the Word processor in Blazor server app using [Visual Studio 2019](https://visualstudio.microsoft.com/vs/).

Steps to get started with Word processor component for Blazor:

1. Select **Create a new project** from the Visual Studio dashboard.

    ![new project in blazor](../images/new-project.png)

2. Select **Blazor App** from the template and click the **Next** button.

    ![Blazor app](../images/blazor-template.png)

3. In the project configuration window, click the **Create** button to create a new project with the default project configuration.

    ![asp.net core project configuration](../images/project-configuration.png)

4. Select **Blazor Server App** from the dashboard and click the **Create** button to create a new Blazor Server application. Make sure that **.NET Core** and **ASP.NET Core 3.1** are selected at the top.

    ![select framework](../images/blazor-server-template.png)

5. Install the [Syncfusion.Blazor.WordProcessor](https://www.nuget.org/packages/Syncfusion.Blazor.WordProcessor/) NuGet package to the newly created application by using the **NuGet Package Manager**. Right-click the project and select Manage NuGet Packages.

6. Search **Syncfusion.Blazor.WordProcessor** keyword in the Browse tab and install [Syncfusion.Blazor.WordProcessor](https://www.nuget.org/packages/Syncfusion.Blazor.WordProcessor/) NuGet package in the application.

    ![select nuget](../images/select-nuget.png)

7. Open the **~/_Imports.razor** file and import the `Syncfusion.Blazor.DocumentEditor`.

    ```csharp
    @using Syncfusion.Blazor.DocumentEditor
    ```

8. Add the Syncfusion Word processor component (a.k.a DocumentEditor) to any webpages (razor) in the `Pages` folder. For example, the DocumentEditorContainer component is added to the **~/Pages/Index.razor** page.

    ```csharp
    <SfDocumentEditorContainer EnableToolbar=true></SfDocumentEditorContainer>
    ```

9. Add the SyncfusionBlazor service in `ConfigureServices` method of **Startup.cs** file.

    ```csharp
     public void ConfigureServices(IServiceCollection services) {
         .......
         .......
         services.AddSyncfusionBlazor();
     }
    ```

10. Add the client-side resources through CDN or local npm package in the `<head>` element of the **~/Pages/_Host.cshtml** page.

    ```html
    <head>
        ....
        ....
        <link href="https://cdn.syncfusion.com/blazor/{:version:}/styles/material.css" rel="stylesheet" />
    </head>
    ```

11. Run the application. The Word processor component will be rendered in the web browser.

    ![DocumentEditor Sample](../images/browser-output.png)

12. To load an existing document during control initialization, use the following code example, which opens a Word document. Convert it to SFDT and load in the editor.

    ```csharp
    @using System.IO;
    @using Syncfusion.Blazor.DocumentEditor;

    <SfDocumentEditorContainer @ref="container" EnableToolbar=true>
        <DocumentEditorContainerEvents Created="OnCreated"></DocumentEditorContainerEvents>
    </SfDocumentEditorContainer>

    @code {

        SfDocumentEditorContainer container;

        public void OnCreated(object args)
        {
            string filePath = "wwwroot/data/GettingStarted.docx";
            using (FileStream fileStream = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                WordDocument document = WordDocument.Load(fileStream, ImportFormatType.Docx);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(document);
                document.Dispose();
                //To observe the memory go down, null out the reference of document variable.
                document = null;
                SfDocumentEditor editor = container.DocumentEditor;
                editor.Open(json);
                //To observe the memory go down, null out the reference of json variable.
                json = null;
            }
        }
    }
    ```

> As per the discussion thread [#30064](https://github.com/dotnet/aspnetcore/issues/30064), please null out the reference of streams and other instances when they are no longer required. Using this approach you'll observe the memory go down and become stable.

![DocumentEditor Sample](../images/browser-output-open-document.png)