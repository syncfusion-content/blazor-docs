---
layout: post
title: Getting Started for Syncfusion Blazor File Upload Component in Web App
description: Checkout and learn about the documentation for getting started with Blazor File Upload Component in Blazor Web App.
platform: Blazor
component: File Upload
documentation: ug
---

# Getting Started with Blazor File Upload Component in Web App

This section briefly explains how to include the [Blazor File Upload](https://www.syncfusion.com/blazor-components/blazor-file-upload) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), Visual Studio Code, and .NET CLI.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

*   [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to [this Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) documentation.

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) while creating a Blazor Web Application.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the Blazor Web App

To add the **Blazor File Upload** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App, you need to install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

*   [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

You can create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to [this Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) documentation.

Configure the appropriate interactive render mode and interactivity location when setting up a Blazor Web Application. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands.

{% tabs %}
{% highlight C# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

N> For more information on creating a **Blazor Web App** with various interactive modes and locations, refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App, you need to install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

*   Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
*   Ensure you’re in the project root directory where your `.csproj` file is located.
*   Run the following command to install a [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight C# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Inputs -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Latest version of the [.NET Core SDK](https://dotnet.microsoft.com/en-us/download). If you previously installed the SDK, you can determine the installed version by executing the following command in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

{% tabs %}
{% highlight C# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web project using .NET CLI

Run the following command to create a new Blazor Web App in a command prompt (Windows) or terminal (macOS) or command shell (Linux). For detailed instructions, refer to [this Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=.net-cli) documentation.

Configure the appropriate interactive render mode and interactivity location when setting up a Blazor Web Application. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

For example, in a Blazor Web App with `Auto` interactive render mode, use the following commands:

{% tabs %}
{% highlight C# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp -int Auto
cd BlazorApp
cd BlazorApp.Client

{% endhighlight %}
{% endtabs %}

This command creates a new Blazor Web app project and places it in a new directory called `BlazorApp` inside your current location. See [Create Blazor app topic](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI command](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=linux-macos&view=aspnetcore-8.0) topics for more details.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

Here's an example of how to add the **Blazor File Upload** component in the application using the following command in the command prompt (Windows) or terminal (Linux and macOS) to install a [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package. See [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) topics for more details.

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App, you need to install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

{% tabs %}
{% highlight C# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Inputs --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Add Import Namespaces

Open the **~/_Imports.razor** file from the client project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Inputs` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs

{% endhighlight %}
{% endtabs %}

<h2>Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service</h2>

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If your Blazor Web App uses `WebAssembly` or `Auto` interactive render modes, you must register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** files of the main `server` project and associated `.Client` project.

{% tabs %}
{% highlight C# tabtitle="Server (~/Program.cs)" hl_lines="3 11" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight C# tabtitle="Client (~/Program.cs)" hl_lines="2 5" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

<h2>Add stylesheet and script resources</h2>

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

    <!-- Blazor File Upload Component script reference. -->
    <script src="_content/Syncfusion.Blazor.Inputs/scripts/sf-uploader.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion® Blazor File Upload component

The Syncfusion Blazor File Upload component allows you to seamlessly integrate file upload functionalities into your Blazor applications. It supports various features like asynchronous and synchronous uploads, file type validation, progress tracking, and custom templates. A common use case is enabling users to upload documents, images, or other files to a server, or process them directly within the client-side application.

### Simple Code to render a Usable File Upload Component

The most basic way to render the File Upload component is by adding the `<SfUploader>` tag to your `.razor` page. By default, this component provides a clean interface for users to select files locally.

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | None | --- |

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly`, the render mode is configured in the `App.razor` file by default.

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

*   Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Upload component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBJXsrOqbMEOurR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Use ValueChange Event

The [`ValueChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange) event fires when files are selected or removed from the uploader. This event is crucial for client-side processing of selected files, allowing you to access file details and their content, which is useful for previewing files or handling uploads without a server-side endpoint.

### Code Example

This example demonstrates how to use the [`ValueChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange) event to save uploaded files directly to a local directory when the [`AutoUpload`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AutoUpload) property is set to `true`. This is useful for scenarios where you want to process files immediately after selection without an explicit upload button.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs
@using System.IO

<SfUploader AutoUpload="true">
      <UploaderEvents ValueChange="@OnChange"></UploaderEvents>
</SfUploader>

@code {
    private async Task OnChange(UploadChangeEventArgs args)
    {
        try
        {
            foreach (var fileEntry in args.Files)
            {
                // Define a path where you want to save the file.
                // For a Blazor Server app, this path will be on the server.
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Construct the full file path.
                var filePath = Path.Combine(uploadsFolder, fileEntry.FileInfo.Name);

                // Use a FileStream to write the uploaded file's content to the server.
                await using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // OpenReadStream with long.MaxValue allows reading the entire stream.
                    await fileEntry.File.OpenReadStream(long.MaxValue).CopyToAsync(fileStream);
                }
                Console.WriteLine($"File '{fileEntry.FileInfo.Name}' saved successfully to '{filePath}'");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }
}

{% endhighlight %}
{% endtabs %}

N> When saving files directly in a Blazor Server application using [`ValueChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange) and [`AutoUpload`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AutoUpload), the files are saved on the server where the Blazor Server app is running, not on the client's machine. You need appropriate file system permissions for the server process to write to the specified directory. Also, ensure the target directory (`wwwroot/uploads` in this example) exists or is created programmatically. In a production environment, consider secure storage solutions for uploaded files.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVyZkrqBvaSlvht?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Memory stream

When you need to process uploaded files in memory—perhaps for resizing images, reading content, or sending them to another service without saving them to disk first—using a `MemoryStream` is an efficient approach. This is particularly useful for temporary processing or when dealing with sensitive data that shouldn't persist on the file system.

### Code Example

This example demonstrates how to read the content of an uploaded file into a [MemoryStream Class](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream)`. This allows you to perform in-memory operations on the file, such as converting an image to a Base64 string, without requiring disk I/O.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs
@using System.IO

<SfUploader AutoUpload="true">
      <UploaderEvents ValueChange="@OnValueChangeMemoryStream"></UploaderEvents>
</SfUploader>

@if (!string.IsNullOrEmpty(base64Image))
{
    <h4>Uploaded Image Preview (Base64)</h4>
    <img src="@($"data:image/png;base64,{base64Image}")" style="max-width: 300px; height: auto;" />
}

@code {
    private string base64Image;

    private async Task OnValueChangeMemoryStream(UploadChangeEventArgs args)
    {
        base64Image = string.Empty; // Clear previous image

        foreach (var fileEntry in args.Files)
        {
            if (fileEntry.FileInfo.Type.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
            {
                // Create a MemoryStream to hold the file content.
                using var memoryStream = new MemoryStream();
                
                // Copy the file's content from the upload stream to the MemoryStream.
                await fileEntry.File.OpenReadStream(long.MaxValue).CopyToAsync(memoryStream);
                
                // Convert the MemoryStream content to a byte array.
                byte[] imageBytes = memoryStream.ToArray();
                
                // Convert byte array to Base64 string for display or further processing.
                base64Image = Convert.ToBase64String(imageBytes);
                Console.WriteLine($"Image '{fileEntry.FileInfo.Name}' loaded into MemoryStream and converted to Base64.");
            }
            else
            {
                Console.WriteLine($"File '{fileEntry.FileInfo.Name}' is not an image and won't be processed for Base64 preview.");
                // For non-image files, you could read their content as text or handle differently.
                // Example for text file:
                // memoryStream.Position = 0; // Reset stream position
                // using var reader = new StreamReader(memoryStream);
                // var content = await reader.ReadToEndAsync();
                // Console.WriteLine($"Content of {fileEntry.FileInfo.Name}: {content}");
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

N> When using `MemoryStream` for large files, be mindful of server memory consumption. If you expect very large files, consider processing them in chunks or saving them to temporary storage before processing to avoid out-of-memory exceptions. The `long.MaxValue` in `OpenReadStream` indicates the maximum buffer size. In a Blazor Server app, `Stream` operations occur on the server.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjreNaLUhdwxzvHS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Created Event

The [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Created) event fires after the File Upload component has been rendered and initialized. This event is a good place to perform any initial setup, attach custom event listeners to the component's DOM elements, or apply custom styling that requires the component to be fully rendered.

### Code Example

This example shows how to use the [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Created) event to add a custom message or dynamically change some aspect of the uploader's appearance right after it's created.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents Created="@OnUploaderCreated"></UploaderEvents>
</SfUploader>

<p>@statusMessage</p>

@code {
    private string statusMessage = "Uploader not yet created.";

    private void OnUploaderCreated()
    {
        statusMessage = "Syncfusion File Uploader has been successfully created and initialized!";
        Console.WriteLine(statusMessage);
        // You could also interact with JavaScript to modify DOM here if needed.
        // For example: JSRuntime.InvokeVoidAsync("someJsFunction");
    }
}

{% endhighlight %}
{% endtabs %}

N> The [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Created) event is useful for client-side JavaScript interop if you need to manipulate the DOM elements of the uploader component immediately after it's ready. However, for most Blazor-specific customizations (like custom templates), you should use the built-in Blazor features.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLyNuVUBGtPZrdo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## File Selected Event

The [`FileSelected Event`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_FileSelected)event is triggered when files are chosen from the file explorer dialog, but **before** the [`ValueChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange) event. This event provides an opportunity to perform validations on the selected files (e.g., file size, type, count) and decide whether to proceed with the upload/value change or cancel the selection. It's ideal for immediate client-side feedback or preventative actions.

### Code Example

This example demonstrates how to use the [FileSelected Event](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_FileSelected) event to prevent files larger than a certain size.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs
@using System.Linq

<SfUploader >
    <UploaderEvents FileSelected="@OnFileSelected"></UploaderEvents>
</SfUploader>
<p>@validationMessage</p>

@code {
    private string validationMessage = "";
    private readonly long MaxFileSize = 1024 * 1024; // 1 MB

    private void OnFileSelected(SelectedEventArgs args)
    {
        validationMessage = "";
        foreach (var file in args.FilesData)
        {
            if (file.Size > MaxFileSize)
            {
                validationMessage += $"Error: File '{file.Name}' exceeds {MaxFileSize / (1024 * 1024)} MB limit. ";
                args.Cancel = true; // Prevents this file from being added
            }
        }
        if (!string.IsNullOrEmpty(validationMessage))
        {
            Console.WriteLine(validationMessage);
        }
        else
        {
            Console.WriteLine("Files selected successfully and passed initial validation.");
        }
    }
}

{% endhighlight %}
{% endtabs %}

N> Setting `args.Cancel = true` in the `FileSelected` event will prevent the file (or files if `args.Files` contains multiple) from being added to the uploader's internal file list. This is a client-side validation and should be complemented with server-side validation for robust security and data integrity.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLIZuBUVwEJoJpz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## OnFileListRender

The [`OnFileListRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnFileListRender) event allows you to customize individual file list items before they are rendered in the uploader's UI. This is highly useful for scenarios where you need to display additional information alongside each file, such as a custom preview, metadata, or actions.

### Code Example 

This example demonstrates how to use [`OnFileListRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnFileListRender) 

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs

<SfUploader @ref="fileobj" AutoUpload="false">
    <UploaderEvents OnFileListRender="@OnFileListRenderHandler"></UploaderEvents>
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings>
</SfUploader>

@code {
    SfUploader fileobj;
    private void OnFileListRenderHandler(FileListRenderingEventArgs args)
    {
      
    }
}

{% endhighlight %}
{% endtabs %}


N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/FileUpload).

## See also

1. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
2. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
4. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> File Upload in Blazor WebAssembly using Visual Studio](https://blazor.syncfusion.com/documentation/file-upload/how-to/getting-started-with-blazor-webassembly)
5.  [How to convert images to Base64 string with Blazor File Upload](https://support.syncfusion.com/kb/article/21178/how-to-convert-images-to-base64-string-with-blazor-file-upload)
