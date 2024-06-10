---
layout: post
title: Rename files in Blazor FileManager with Physical service | Syncfusion
description: Checkout and learn here all about rename operation of Syncfusion Blazor FileManager component with physical service and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Rename file from phsyical service provider

To perform a rename operation in Syncfusion Blazor FileManager component from ASP.NET Core physical file system provider, you can follow the steps below

**Step 1:** Create a `File Manager` Sample in blazor

Start by following the steps provided in this link to create a simple `SfPdfViewer` sample in blazor. To perform the rename operation, initialize the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html#Syncfusion_Blazor_FileManager_FileManagerAjaxSettings_Url) property in a FileManagerAjaxSettings.

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="/api/FileManager/FileOperations">
    </FileManagerAjaxSettings>
</SfFileManager>

{% endhighlight %}
{% endtabs %}

**Step 2:** Initialize the physical service in controller

To initialize a local service with rename action, create a new folder name with `Controllers` inside the server part of the project. Then, create a new file with extension `.cs` inside the Controllers folder and add the following code in that file.

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
                ...
                case "rename":
                    // renames a file or folder.
                    return this.operation.ToCamelCase(this.operation.Rename(args.Path, args.Name, args.NewName, false, args.ShowFileExtension, args.Data));
                ...
            }
            return null;
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 3:** Access rename response from model

To access the rename Operation, you need physical model class files that have rename operation methods. So, create `Models` folder in `server` part of the application and include the the `PhysicalFileProvider.cs` and required base class from the [link](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider/tree/master/Models) in the Models folder.

In the following example, the **Rename** operation is handled from physical service.

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

        public virtual FileManagerResponse Rename(string path, string name, string newName, bool replace = false, bool showFileExtension = true, params FileManagerDirectoryContent[] data)
        {
            FileManagerResponse renameResponse = new FileManagerResponse();
            try
            {
                string validatePath;
                validatePath = Path.Combine(contentRootPath + path);
                if (Path.GetFullPath(validatePath) != GetFilePath(validatePath))
                {
                    throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                }
                string physicalPath = GetPath(path);
                if (!showFileExtension)
                {
                    name = name + data[0].Type;
                    newName = newName + data[0].Type;
                }
                bool IsFile = !IsDirectory(physicalPath, name);
                AccessPermission permission = GetPermission(physicalPath, name, IsFile);
                if (permission != null && (!permission.Read || !permission.Write))
                {
                    accessMessage = permission.Message;
                    throw new UnauthorizedAccessException();
                }

                string tempPath = (contentRootPath + path);
                string oldPath = Path.Combine(tempPath, name);
                if (Path.GetFullPath(oldPath) != GetFilePath(oldPath) + Path.GetFileName(oldPath))
                {
                    throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                }
                string newPath = Path.Combine(tempPath, newName);
                if (Path.GetFullPath(newPath) != GetFilePath(newPath) + Path.GetFileName(newPath))
                {
                    throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                }
                FileAttributes attr = File.GetAttributes(oldPath);

                FileInfo info = new FileInfo(oldPath);
                bool isFile = (File.GetAttributes(oldPath) & FileAttributes.Directory) != FileAttributes.Directory;
                if (isFile)
                {
                    if (File.Exists(newPath) && !oldPath.Equals(newPath, StringComparison.OrdinalIgnoreCase))
                    {
                        FileInfo exist = new FileInfo(newPath);
                        ErrorDetails er = new ErrorDetails();
                        er.Code = "400";
                        er.Message = "Cannot rename " + exist.Name.ToString() + " to " + newName + ": destination already exists.";
                        renameResponse.Error = er;
                        return renameResponse;
                    }
                    info.MoveTo(newPath);
                }
                else
                {
                    bool directoryExist = Directory.Exists(newPath);
                    if (directoryExist && !oldPath.Equals(newPath, StringComparison.OrdinalIgnoreCase))
                    {
                        DirectoryInfo exist = new DirectoryInfo(newPath);
                        ErrorDetails er = new ErrorDetails();
                        er.Code = "400";
                        er.Message = "Cannot rename " + exist.Name.ToString() + " to " + newName + ": destination already exists.";
                        renameResponse.Error = er;

                        return renameResponse;
                    }
                    else if (oldPath.Equals(newPath, StringComparison.OrdinalIgnoreCase))
                    {
                        tempPath = Path.Combine(tempPath + "Syncfusion_TempFolder");
                        Directory.Move(oldPath, tempPath);
                        Directory.Move(tempPath, newPath);
                    }
                    else
                    {
                        Directory.Move(oldPath, newPath);
                    }
                }
                FileManagerDirectoryContent[] addedData = new[]{
                        GetFileDetails(newPath)
                    };
                renameResponse.Files = addedData;
                return renameResponse;
            }
            catch (Exception e)
            {
                ErrorDetails er = new ErrorDetails();
                er.Message = (e.GetType().Name == "UnauthorizedAccessException") ? "'" + this.getFileNameFromPath(this.rootName + path + name) + "' is not accessible. You need permission to perform the write action." : e.Message.ToString();
                er.Code = er.Message.Contains("is not accessible. You need permission") ? "401" : "417";
                if ((er.Code == "401") && !string.IsNullOrEmpty(accessMessage)) { er.Message = accessMessage; }
                renameResponse.Error = er;
                return renameResponse;
            }
        }
        ...

{% endhighlight %}
{% endtabs %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/FileManager).