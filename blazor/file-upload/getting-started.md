---
layout: post
title: Getting Started with Blazor File Upload Component | Syncfusion
description: Checkout and learn about getting started with Blazor File Upload component in Blazor WebAssembly Application.
platform: Blazor
control: File Upload
documentation: ug
---

# Getting Started with Blazor File Upload Component

This section briefly explains about how to include [Blazor File Upload](https://www.syncfusion.com/blazor-components/blazor-file-upload) component in your Blazor WebAssembly App using Visual Studio, Visual Studio Code and .NET CLI.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to [this guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

To add **Blazor File Upload** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, you can utilize the following package manager command to achieve the same.

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

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

You can create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to [this guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app?tabcontent=visual-studio-code).

Alternatively, you can create a WebAssembly application using the following command in the terminal(<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

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
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor WebAssembly project using .NET CLI

Run the `dotnet new blazorwasm` command to create a new Blazor WebAssembly application in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

This command creates new Blazor WebAssembly app project and places it in a new directory called `BlazorApp` inside your current location. See [Create Blazor app topic](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI command](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) topics for more details.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

Here's an example of how to add **Blazor File Upload** component in the application using the following command in the command prompt (Windows) or terminal (Linux and macOS) to install a [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package. See [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) topics for more details.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Add Import Namespaces

Open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Inputs` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor WebAssembly App.

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

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the `<head>` section of the **~/index.html** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

    //Blazor File Upload Component script reference.
    <!-- <script src="_content/Syncfusion.Blazor.Inputs/scripts/sf-uploader.min.js" type="text/javascript"></script> -->
</head>
```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Blazor File Upload component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Upload component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

<SfUploader></SfUploader>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Upload component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBJXsrOqbMEOurR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor FileUpload Component](./images/blazor-fileupload-component.png)" %}

## Without server-side API endpoint

You can upload the files and files of folders in the Blazor application without specifying the server-side API end point using [AsyncSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html).

### Save and Remove actions

You can get the uploaded files as file stream in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange) event argument. Now, you can write the save handler inside ValueChange event to save the files to desired location. Find the save action code below.

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

### Server-side configuration for saving and returning responses

The following example demonstrates the server-side action for saving files on the server and returning responses in JSON, String, and File formats.

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

The following example demonstrates the client-side action for saving files on the server and returning responses in JSON, String, and File formats.

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

You can allow the specific files alone to upload using the [AllowedExtensions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderModel.html#Syncfusion_Blazor_Inputs_UploaderModel_AllowedExtensions) property. The extension can be represented as collection by comma separators. The uploader component filters the selected or dropped files to match against the specified file types and processes the upload operation. The validation happens when you specify value to inline attribute to accept the original input element.

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
