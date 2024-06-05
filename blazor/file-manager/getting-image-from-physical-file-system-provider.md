---
layout: post
title: Get image in Blazor FileManager with Physical service | Syncfusion
description: Checkout and learn here all about get image operation of Syncfusion Blazor FileManager component with physical service and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Getting Images from phsyical service provider

To perform a get image operation in Syncfusion Blazor FileManager component from ASP.NET Core physical file system provider, you can follow the steps below

**Step 1:** Create a `SfFileManager` Sample in blazor

Start by following the steps provided in this link to create a simple `SfPdfViewer` sample in blazor. To perform the get image operation, initialize the [GetImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html#Syncfusion_Blazor_FileManager_FileManagerAjaxSettings_GetImageUrl) property in a FileManagerAjaxSettings.

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="/api/FileManager/FileOperations"
                                GetImageUrl="/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

{% endhighlight %}
{% endtabs %}

**Step 2:** Initialize the physical service in controller

To initialize a local service with get image action, create a new folder name with `Controllers` inside the server part of the project. Then, create a new file with extension `.cs` inside the Controllers folder and add the following code in that file.

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
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace filemanager.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        public PhysicalFileProvider operation;
        public string basePath;
        string root = "wwwroot\\Files";
        [Obsolete]
        public SampleDataController(IHostingEnvironment hostingEnvironment)
        {
            this.basePath = hostingEnvironment.ContentRootPath;
            this.operation = new PhysicalFileProvider();
            this.operation.RootFolder(this.basePath + "\\" + this.root); // It denotes in which files and folders are available.
        }

        // gets the image(s) from the given path
        [Route("GetImage")]
        public IActionResult GetImage(FileManagerDirectoryContent args)
        {
            return this.operation.GetImage(args.Path, args.Id,false,null, null);
        } 
    }
}

{% endhighlight %}
{% endtabs %}

**Step 3:** Access get image response from model

To access the get image Operation, you need physical model class files that have get image operation methods. So, create `Models` folder in `server` part of the application and include the the `PhysicalFileProvider.cs` and required base class from the [link](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider/tree/master/Models) in the Models folder.

In the following example, the **GetImage** operation is handled from physical service.

{% tabs %}
{% highlight cs tabtitle="Models/PhysicalFileProvider.cs" %}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using Syncfusion.EJ2.FileManager.Base;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;


namespace Syncfusion.EJ2.FileManager.PhysicalFileProvider
{
    public class PhysicalFileProvider 
    {
        protected string contentRootPath;
        protected string[] allowedExtension = new string[] { "*" };
        AccessDetails AccessDetails = new AccessDetails();
        private string rootName = string.Empty;
        protected string hostPath;
        protected string hostName;
        private string accessMessage = string.Empty;

        public PhysicalFileProvider()
        {
        }

        public void RootFolder(string name)
        {
            this.contentRootPath = name;
            this.hostName = new Uri(contentRootPath).Host;
            if (!string.IsNullOrEmpty(this.hostName))
            {
                this.hostPath = Path.DirectorySeparatorChar + this.hostName + Path.DirectorySeparatorChar + contentRootPath.Substring((contentRootPath.ToLower().IndexOf(this.hostName) + this.hostName.Length + 1));
            }
        }

        public virtual FileStreamResult GetImage(string path, string id, bool allowCompress, ImageSize size, params FileManagerDirectoryContent[] data)
        {
            try
            {
                AccessPermission PathPermission = GetFilePermission(path);
                if (PathPermission != null && !PathPermission.Read)
                    return null;
                String fullPath = (contentRootPath + path);
                if (Path.GetFullPath(fullPath) != GetFilePath(fullPath) + this.getFileNameFromPath(fullPath))
                {
                    throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                }

                FileStream fileStreamInput = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                FileStreamResult fileStreamResult = new FileStreamResult(fileStreamInput, "APPLICATION/octet-stream");
                return fileStreamResult;
            }
            catch (Exception)
            {
                return null;
            }
        }
        ...

{% endhighlight %}
{% endtabs %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/FileManager).