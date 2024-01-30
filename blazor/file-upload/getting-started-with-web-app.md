---
layout: post
title: Getting Started for Syncfusion Blazor File Upload Component in Web App
description: Checkout and learn about the documentation for getting started with Blazor File Upload Component in Blazor Web App.
platform: Blazor
component: File Upload
documentation: ug
---

# Getting Started with Blazor File Upload Component in Web App

This section briefly explains about how to include [Blazor File Upload](https://www.syncfusion.com/blazor-components/blazor-file-upload) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

## Install Syncfusion Blazor Inputs and Themes NuGet in the Blazor Web App

To add **Blazor File Upload** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Inputs` namespace.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
```

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Web App. For a app with `WebAssembly` or `Auto (Server and WebAssembly)` interactive render mode, register the Syncfusion Blazor service in both **~/Program.cs** files of your web app.
```cshtml

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

```

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/material.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion Blazor File Upload component

Add the Syncfusion Blazor File Upload component in `.razor` file inside the `Pages` folder. If an interactivity location as `Per page/component` in the web app, define a render mode at top of the component, as follows:

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfUploader></SfUploader>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor File Upload component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrfjsNPVgcxzCGN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor FileUpload Component](./images/blazor-fileupload-component.png)" %}

## Without server-side API endpoint

You can upload the files and files of folders in the Blazor application without specifying the server-side API end point using [AsyncSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html).

### Save and Remove actions

You can get the uploaded files as file stream in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange) event argument. Now, you can write the save handler inside ValueChange event to save the files to desired location. Find the save action code below.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs
<SfUploader AutoUpload="true">
      <UploaderEvents ValueChange="@OnChange"></UploaderEvents>
</SfUploader>
@code {
    private async Task OnChange(UploadChangeEventArgs args)
    {
        try
        {
            foreach (var file in args.Files)
            {
                var path = @"" + file.FileInfo.Name;
                FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
                await file.File.OpenReadStream(long.MaxValue).CopyToAsync(filestream);
                filestream.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor FileUpload displays Updated Files](./images/blazor-fileupload-with-updated-files.png)

While clicking on the remove icon in the file list, you will get the [OnRemove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnRemove) event with removing file name as argument. So, you can write the remove handler inside OnRemove event to remove the particular file from desired location. Find the remove action code below.

{% tabs %}
{% highlight cshtml %}

Private void onRemove(RemovingEventArgs args)
{
    foreach(var removeFile in args.FilesData)
    {
        if (File.Exists(Path.Combine(@"rootPath", removeFile.Name)))
        {
            File.Delete(Path.Combine(@"rootPath", removeFile.Name))
        }
    }
}

{% endhighlight %}
{% endtabs %}

## With server-side API endpoint

The upload process requires save and remove action URL to manage the upload process in the server.

N> * The save action is necessary to handle the upload operation.
<br/> * The remove action is optional, one can handle the removed files from server.

The save action handler upload the files that needs to be specified in the [SaveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_SaveUrl) property.

The save handler receives the submitted files and manages the save process in server. After uploading the files to server location, the color of the selected file name changes to green and the remove icon is changed as bin icon.

The remove action is optional. The remove action handler removes the files that needs to be specified in the [RemoveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_RemoveUrl) property. [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnActionComplete) event triggers after all the selected files have been processed to upload successfully or failed to server.

{% tabs %}
{% highlight cshtml %}

[Route("api/[controller]")]

private IHostingEnvironment hostingEnv;

public SampleDataController(IHostingEnvironment env)
{
    this.hostingEnv = env;
}

[HttpPost("[action]")]
public void Save(IList<IFormFile> UploadFiles)
{
    try
    {
        foreach (var file in UploadFiles)
        {
            var filename = hostingEnv.ContentRootPath + $@"\{file.FileName}";
            if (!System.IO.File.Exists(filename))
            {
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
        }
    }
    catch (Exception e)
    {
        Response.Clear();
        Response.StatusCode = 204;
        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
    }
}

[HttpPost("[action]")]
public void Remove(IList<IFormFile> UploadFiles)
{
    try
    {
        var filename = hostingEnv.ContentRootPath + $@"\{UploadFiles[0].FileName}";
        if (System.IO.File.Exists(filename))
        {
            System.IO.File.Delete(filename);
        }
    }
    catch (Exception e)
    {
        Response.Clear();
        Response.StatusCode = 200;
        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
    }
}

{% endhighlight %}
{% endtabs %}

The [OnFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnFailure) event is triggered when there is a failure in the AJAX request during the uploading or removing of files. It provides a way to handle and respond to any errors or issues that occur during the file upload or removal process.

{% tabs %}
{% highlight razor %}

<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove"></UploaderAsyncSettings>
    <UploaderEvents OnFailure="@OnFailureHandler" OnActionComplete="@OnActionCompleteHandler"></UploaderEvents>
</SfUploader>
@code {
    private void OnFailureHandler(FailureEventArgs args)
    {
        // Here, you can customize your code.
    }
    private void OnActionCompleteHandler(ActionCompleteEventArgs args)
    {
        // Here, you can customize your code.
    }
}

{% endhighlight %}
{% endtabs %}

## Configure allowed file types

You can allow the specific files alone to upload using the [AllowedExtensions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderModel.html#Syncfusion_Blazor_Inputs_UploaderModel_AllowedExtensions) property. The extension can be represented as collection by comma separators. The uploader component filters the selected or dropped files to match against the specified file types and processes the upload operation. The validation happens when you specify value to inline attribute to accept the original input element.

{% tabs %}
{% highlight razor %}

<SfUploader AllowedExtensions=".doc, .docx, .xls, xlsx"></SfUploader>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLfNsDbhTNNJjbi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Allowing Specific Files in Blazor FileUpload](./images/blazor-fileupload-allow-specific-file.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/FileUpload).

## See also

1. [Getting Started with Syncfusion Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
2. [Getting Started with Syncfusion Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)
4. [Getting Started with Syncfusion File Upload in Blazor WebAssembly using Visual Studio](https://blazor.syncfusion.com/documentation/file-upload/how-to/getting-started-with-blazor-webassembly)

