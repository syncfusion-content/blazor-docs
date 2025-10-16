---
layout: post
title: Getting Started with Blazor File Upload Component | Syncfusion
description: Checkout and learn about getting started with Blazor File Upload component in Blazor WebAssembly Application.
platform: Blazor
control: File Upload
documentation: ug
---

# Getting Started with Blazor File Upload Component in WASM App

This guide explains how to add the [Blazor File Upload](https://www.syncfusion.com/blazor-components/blazor-file-upload) component to a Blazor WebAssembly (WASM) app using Visual Studio, Visual Studio Code, and the .NET CLI. It also outlines optional server API patterns that a WASM app can call for storing files.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* Review the [system requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements) and ensure the required .NET SDK and tooling are installed.

## Create a new Blazor App in Visual Studio

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to [this guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

To use the **Blazor File Upload** component, open NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, use the following Package Manager commands.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are hosted on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete package list and component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* Review the [system requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements) and install the latest .NET SDK.

## Create a new Blazor App in Visual Studio Code

Create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For step-by-step instructions, see [this guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app?tabcontent=visual-studio-code).

Alternatively, create a WebAssembly application using the following command in the terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure the project root directory where your `.csproj` file is located.
* Run the following commands to install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and restore dependencies.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Inputs -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are hosted on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete package list and component details.

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Install the latest [.NET Core SDK](https://dotnet.microsoft.com/en-us/download). If already installed, check the version using the following command in a terminal or command prompt.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor WebAssembly App using .NET CLI

Run the `dotnet new blazorwasm` command to create a new Blazor WebAssembly app in a command prompt (Windows), terminal (macOS), or shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

This command creates a new Blazor WebAssembly app in a directory named `BlazorApp` at the current location. See the [Create Blazor app](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) topics for details.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

Install the **Blazor File Upload** component packages using the .NET CLI. Run the following commands to install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). See [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) for more information.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are hosted on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete package list and component details.

{% endtabcontent %}

{% endtabcontents %}

## Add Import Namespaces

Open **~/_Imports.razor** and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Inputs` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor services in **~/Program.cs** so the components are available to the app.

{% tabs %}
{% highlight C# tabtitle="~/Program.cs" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script are available via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Add the references in the `<head>` section of **~/index.html**.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

    //Blazor File Upload Component script reference.
    <!-- <script src="_content/Syncfusion.Blazor.Inputs/scripts/sf-uploader.min.js" type="text/javascript"></script> -->
</head>
```
N> See the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for ways to reference themes ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). For scripts, see [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references). When using the consolidated Syncfusion script, separate per-component scripts are typically not required.

## Add Blazor File Upload component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Upload component in **~/Pages/Index.razor**.

{% tabs %}
{% highlight razor %}

<SfUploader></SfUploader>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the application. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Upload component renders in the default browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBJXsrOqbMEOurR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor FileUpload Component](./images/blazor-fileupload-component.png)" %}

## Without server-side API endpoint

In a Blazor WebAssembly app, files can be selected and processed on the client without specifying a server-side API endpoint using [AsyncSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html). Client apps cannot write arbitrary files to the device file system. For persistence, use browser storage (such as IndexedDB) or upload to a server API.

### Save and Remove actions

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange) event exposes uploaded files as streams. The example below demonstrates a save handler pattern. In WebAssembly, adapt this logic to save to browser storage or to POST streams to a backend API. Avoid using unbounded stream limits in production.

{% tabs %}
{% highlight cshtml %}

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

When the remove icon is selected in the file list, the [OnRemove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnRemove) event provides the file name to remove. Implement the remove logic appropriate to your storage choice (for example, removing from IndexedDB or calling a backend API). The following sample shows the event signature pattern.

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

Set the [RemoveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_RemoveUrl) property to the server endpoint that deletes files. The [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnActionComplete) event triggers after all selected files are processed (success or failure).

{% tabs %}
{% highlight cshtml %}

[Route("api/[controller]")]
public class SampleDataController : Controller
{
    public string uploads = ".\\Uploaded Files"; // replace with your directory path

    [HttpPost("[action]")]
    public async Task<IActionResult> Save(IFormFile UploadFiles) // Save the uploaded file here
    {
        if (UploadFiles.Length > 0)
        {
            //Create directory if not exists
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var filePath = Path.Combine(uploads, UploadFiles.FileName);
            if (System.IO.File.Exists(filePath))
            {
                //Return conflict status code
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                //Save the uploaded file to server
                await UploadFiles.CopyToAsync(fileStream);
            }
        }
        return Ok();
    }


    [HttpPost("[action]")]
    public void Remove(string UploadFiles) // Delete the uploaded file here
    {
        if(UploadFiles != null)
        {
            var filePath = Path.Combine(uploads, UploadFiles);
            if (System.IO.File.Exists(filePath))
            {
                //Delete the file from server
                System.IO.File.Delete(filePath);
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

The [OnFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnFailure) event is raised when an AJAX request fails during upload or removal. Use it to surface and handle server-side errors in the UI.

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

### Server-side configuration for saving and returning responses

The following sample demonstrates a server action that saves files and returns responses in JSON, string, and file formats. In production, validate file type and size, sanitize file names, use unique file naming, and write to a dedicated uploads directory.

{% tabs %}
{% highlight cshtml %}

[Route("api/[controller]")]

private IHostingEnvironment hostingEnv;

public SampleDataController(IHostingEnvironment env)
{
    this.hostingEnv = env;
}

[HttpPost("[action]")]
public IActionResult Save()
{
    // for JSON Data
    try
    {
        // Process uploaded files
        var responseData = new
        {
            Success = true,
            Message = "Files uploaded successfully",
            // Additional data can be added here
        };

        return Ok(responseData);
    }
    catch (Exception e)
    {
        var errorResponse = new
        {
            Success = false,
            Message = "File upload failed: " + e.Message
        };

        return BadRequest(errorResponse);
    }

    // for String Data
    try
    {
        // Process string data
        var data = "success";
        // Return the string data
        return Content(data);
    }
    catch (Exception)
    {
        var data = "failed";
        return Content(data);
    }

    // for File Data
    try
    {
        // Example: Retrieve file path for stream.txt
        var filePath = "stream.txt"; // Example file path
        
        var fullPath = Path.GetFullPath(filePath);

        // Return the file
        return PhysicalFile(fullPath, "text/plain");
    }
    catch (Exception e)
    {
        return Content("Failed to retrieve file response: " + e.Message, "text/plain");
    }

}

{% endhighlight %}
{% endtabs %}

### Client-side configuration for saving and returning responses

The following sample shows how to handle success responses on the client and interpret JSON/string/file responses from the server. Adapt the logic to your API contract.

{% tabs %}
{% highlight cshtml %}

@using Syncfusion.Blazor.Inputs
@using System.Text.Json


<SfUploader>
    <UploaderAsyncSettings SaveUrl="/api/Uploader/Save"></UploaderAsyncSettings>
    <UploaderEvents Success="@OnSuccessHandler"></UploaderEvents>
</SfUploader>

@code {

    private void OnSuccessHandler(SuccessEventArgs args)
    {
        if (args.Response is not null) // Check if the event argument is not null
        {
           var responseText = args.Response.ResponseText;
           if (!string.IsNullOrWhiteSpace(responseText))
           {    
                // for JSON and File Datas
                using var jsonDoc = JsonDocument.Parse(responseText);
                var jsonResponse = jsonDoc.RootElement;

                if (jsonResponse.TryGetProperty("success", out var successProp))
                {
                    var isSuccess = successProp.GetBoolean();

                    if (isSuccess)
                    {
                        // File upload success
                        var message = jsonResponse.TryGetProperty("message", out var messageProp) ? messageProp.GetString() : "File uploaded successfully";

                        // Additional processing as needed
                    }
                }


                // for string Data
                var message = responseText;
                // Additional processing as needed
           }
        }
    }

}

{% endhighlight %}
{% endtabs %}

## Configure allowed file types

Restrict uploads to specific file types using the [AllowedExtensions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderModel.html#Syncfusion_Blazor_Inputs_UploaderModel_AllowedExtensions) property. Provide extensions as a comma-separated list, typically with a leading dot for each extension. The Uploader filters selected or dropped files to match the specified types and then processes the upload operation. For client-side filtering, ensure the accept attribute of the underlying input reflects the same extensions.

{% tabs %}
{% highlight razor %}

<SfUploader AllowedExtensions=".doc, docx, .xls, xlsx"></SfUploader>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhzDsrOqbKVNviI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Allowing Specific Files in Blazor FileUpload](./images/blazor-fileupload-allow-specific-file.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/FileUpload).

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Server-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> File Upload in Blazor WebAssembly using Visual Studio](https://blazor.syncfusion.com/documentation/file-upload/how-to/getting-started-with-blazor-webassembly)