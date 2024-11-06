---
layout: post
title: Getting Started with Blazor FileManager Component | Syncfusion
description: Checkout and learn about getting started with Blazor FileManager component in Blazor Server Application.
platform: Blazor
control: File Manager
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor FileManager Component

This section briefly explains about how to include [Blazor FileManager](https://www.syncfusion.com/blazor-components/blazor-file-manager) component in your Blazor Server App using Visual Studio.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create a **Blazor Server App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=windows) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion Blazor FileManager and Themes NuGet in the App

To add **Blazor FileManager** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.FileManager](https://www.nuget.org/packages/Syncfusion.Blazor.FileManager) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.FileManager -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.FileManager` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.FileManager

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Server App.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` of the main page as follows:

* For **.NET 6** Blazor Server app, include it in **~/Pages/_Layout.cshtml** file.

* For **.NET 7** Blazor Server app, include it in the **~/Pages/_Host.cshtml** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Blazor FileManager component

Add the Syncfusion Blazor FileManager component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

{% endhighlight %}
{% endtabs %}

## Create Models

Create a new folder named `Models` in the server project. Add the necessary model files to this folder for handling file operations. Download the `PhysicalFileProvider.cs` and `Base` folder from this [repository](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider/tree/master/Models) and place them in the Models folder.

## Create a new folder controller

To initialize a local service, create a new folder name with `Controllers` inside the server part of the project. Then, create a new file `FileManagerController` with extension `.cs` inside the `Controllers` folder.

Make sure your controller `FileManagerController.cs` uses the model classes you've created. Import the model namespace at the top of your controller file

File Manager's base functions are available in the below namespace.
```cshtml
using Syncfusion.EJ2.FileManager.Base;
````
File Manager's operations are available in the below namespace.
````cshtml
using Syncfusion.EJ2.FileManager.PhysicalFileProvider;
````

## Initialize the service in controller

File Manager supports the basic file actions like Read, Delete, Copy, Move, Get Details, Search, Rename, and Create New Folder.

To initialize a local service, create a new folder name with `Controllers` inside the server part of the project. Then, create a new file `FileManagerController` with extension `.cs` inside the `Controllers` folder and add the following code in that file.

{% tabs %}
{% highlight cs tabtitle="Controllers/FileManagerController.cs" %}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
//File Manager's base functions are available in the below namespace.
using Syncfusion.EJ2.FileManager.Base;
//File Manager's operations are available in the below namespace.
using Syncfusion.EJ2.FileManager.PhysicalFileProvider;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace filemanager.Server.Controllers
{
    [Route("api/[controller]")]
    public class FileManagerController : Controller
    {
        public PhysicalFileProvider operation;
        public string basePath;
        string root = "wwwroot\\Files";
        [Obsolete]
        public FileManagerController(IHostingEnvironment hostingEnvironment)
        {
            this.basePath = hostingEnvironment.ContentRootPath;
            this.operation = new PhysicalFileProvider();
            this.operation.RootFolder(this.basePath + "\\" + this.root); // It denotes in which files and folders are available.
        }

        // Processing the File Manager operations.
        [Route("FileOperations")]
        public object FileOperations([FromBody] FileManagerDirectoryContent args)
        {
            switch (args.Action)
            {
                // Add your custom action here.
                case "read":
                    // Path - Current path; ShowHiddenItems - Boolean value to show/hide hidden items.
                    return this.operation.ToCamelCase(this.operation.GetFiles(args.Path, args.ShowHiddenItems));
                case "delete":
                    // Path - Current path where the folder to be deleted; Names - Name of the files to be deleted
                    return this.operation.ToCamelCase(this.operation.Delete(args.Path, args.Names));
                case "copy":
                    //  Path - Path from where the file was copied; TargetPath - Path where the file/folder is to be copied; RenameFiles - Files with same name in the copied location that is confirmed for renaming; TargetData - Data of the copied file
                    return this.operation.ToCamelCase(this.operation.Copy(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "move":
                    // Path - Path from where the file was cut; TargetPath - Path where the file/folder is to be moved; RenameFiles - Files with same name in the moved location that is confirmed for renaming; TargetData - Data of the moved file
                    return this.operation.ToCamelCase(this.operation.Move(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "details":
                    // Path - Current path where details of file/folder is requested; Name - Names of the requested folders
                    return this.operation.ToCamelCase(this.operation.Details(args.Path, args.Names));
                case "create":
                    // Path - Current path where the folder is to be created; Name - Name of the new folder
                    return this.operation.ToCamelCase(this.operation.Create(args.Path, args.Name));
                case "search":
                    // Path - Current path where the search is performed; SearchString - String typed in the searchbox; CaseSensitive - Boolean value which specifies whether the search must be casesensitive
                    return this.operation.ToCamelCase(this.operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                case "rename":
                    // Path - Current path of the renamed file; Name - Old file name; NewName - New file name
                    return this.operation.ToCamelCase(this.operation.Rename(args.Path, args.Name, args.NewName));
            }
            return null;
        }
    }
}

{% endhighlight %}
{% endtabs %}

To configure and map the controller, open the `~/Program.cs` file of the server part of the application. Add the following code to configure the service for the controller and map the controller after `app.UseRouting()`:

```cshtml
builder.Services.AddControllers();
...
app.UseRouting();
app.MapControllers();.
```

This will configure and map the controller in your Blazor App.

## Create Web Server App

Add the Syncfusion Blazor FileManager component in `~/Pages/Index.razor` file.

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="/api/FileManager/FileOperations"
                             UploadUrl="/api/FileManager/Upload"
                             DownloadUrl="/api/FileManager/Download"
                             GetImageUrl="/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

{% endhighlight %}
{% endtabs %}

Add your required files and folders under the `wwwroot\Files` directory.
* In your  project, the `wwwroot` directory is where static files are served from. It is typically found at the root level of your server project.
* Inside the `wwwroot` directory, create a new folder named `Files`. This will be used to store static files like images, documents, or other resources that you want to serve directly.
* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor FileManager component in your default web browser.

![Blazor FileManager Component](images/blazor-filemanager-component.png)

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/FileManager).

## File download support

To perform the download operation, initialize the [DownloadUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html#Syncfusion_Blazor_FileManager_FileManagerAjaxSettings_DownloadUrl) property in a FileManagerAjaxSettings.

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="/api/FileManager/FileOperations"
                                DownloadUrl="/api/FileManager/Download">
    </FileManagerAjaxSettings>
</SfFileManager>

{% endhighlight %}
{% endtabs %}

Initialize the `Download` FileOperation in Controller part with the following code snippet.

{% tabs %}
{% highlight cs tabtitle="Controllers/FileManagerController.cs" %}

namespace filemanager.Server.Controllers
{
    [Route("api/[controller]")]
    public class FileManagerController : Controller
    {
        // Processing the Download operation.
        [Route("Download")]
        public IActionResult Download(string downloadInput)
        {
            //Invoking download operation with the required parameters.
            // path - Current path where the file is downloaded; Names - Files to be downloaded;
            FileManagerDirectoryContent args = JsonConvert.DeserializeObject<FileManagerDirectoryContent>(downloadInput);
            return operation.Download(args.Path, args.Names);
        }
    }
}

{% endhighlight %}
{% endtabs %}

## File upload support

To perform the upload operation, initialize the [UploadUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html#Syncfusion_Blazor_FileManager_FileManagerAjaxSettings_UploadUrl) property in a FileManagerAjaxSettings.

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="/api/FileManager/FileOperations"
                                UploadUrl="/api/FileManager/Upload">
    </FileManagerAjaxSettings>
</SfFileManager>

{% endhighlight %}
{% endtabs %}

Initialize the `Upload` File Operation in Controller part with the following code snippet.

{% tabs %}
{% highlight cs tabtitle="Controllers/FileManagerController.cs" %}

namespace filemanager.Server.Controllers
{
    [Route("api/[controller]")]
    public class FileManagerController : Controller
    {
        // Processing the Upload operation.
        [Route("Upload")]
        public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action)
        {
            //Invoking upload operation with the required parameters.
            // path - Current path where the file is to uploaded; uploadFiles - Files to be uploaded; action - name of the operation(upload)
            FileManagerResponse uploadResponse;
            uploadResponse = operation.Upload(path, uploadFiles, action, null);
            if (uploadResponse.Error != null)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = Convert.ToInt32(uploadResponse.Error.Code);
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = uploadResponse.Error.Message;
            }
            return Content("");
        }
    }
}

{% endhighlight %}
{% endtabs %}

## Image preview support

To perform image preview support in the File Manager component, initialize the [GetImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html#Syncfusion_Blazor_FileManager_FileManagerAjaxSettings_GetImageUrl) property in a FileManagerAjaxSettings.

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="/api/FileManager/FileOperations"
                                GetImageUrl="/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

{% endhighlight %}
{% endtabs %}

Initialize the `GetImage` File Operation in Controller part with the following code snippet.

{% tabs %}
{% highlight cs tabtitle="Controllers/FileManagerController.cs" %}

namespace filemanager.Server.Controllers
{
    [Route("api/[controller]")]
    public class FileManagerController : Controller
    {
        // Processing the GetImage operation.
        [Route("GetImage")]
        public IActionResult GetImage(FileManagerDirectoryContent args)
        {
            //Invoking GetImage operation with the required parameters.
            // path - Current path of the image file; Id - Image file id;
            return this.operation.GetImage(args.Path, args.Id, false, null, null);
        }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor FileManager with Image Preview](images/blazor-filemanager-image-preview.png)

Refer the sample [link](https://www.syncfusion.com/downloads/support/directtrac/general/ze/FileManager1055616812).

## See Also

[Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)

[Getting Started with Syncfusion Blazor for Client-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)

[Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)
