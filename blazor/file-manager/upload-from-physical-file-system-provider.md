---
layout: post
title: Upload in Blazor FileManager with Physical service | Syncfusion
description: Checkout and learn here all about upload operation of Syncfusion Blazor FileManager component with physical service and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Upload file from phsyical service provider

To perform a upload operation in Syncfusion Blazor FileManager component from ASP.NET Core physical file system provider, you can follow the steps below

**Step 1:** Create a `SfFileManager` Sample in blazor

Start by following the steps provided in this link to create a simple `SfPdfViewer` sample in blazor. To perform the upload operation, initialize the [UploadUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html#Syncfusion_Blazor_FileManager_FileManagerAjaxSettings_UploadUrl) property in a FileManagerAjaxSettings.

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="/api/FileManager/FileOperations"
                                UploadUrl="/api/FileManager/Upload">
    </FileManagerAjaxSettings>
</SfFileManager>

{% endhighlight %}
{% endtabs %}

**Step 2:** Initialize the physical service in controller

To initialize a local service with upload action, create a new folder name with `Controllers` inside the server part of the project. Then, create a new file with extension `.cs` inside the Controllers folder and add the following code in that file.

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

        // uploads the file(s) into a specified path
        [Route("Upload")]
        public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action)
        {
            try
            {
                FileManagerResponse uploadResponse;
                foreach (var file in uploadFiles)
                {
                    var folders = (file.FileName).Split('/');
                    // checking the folder upload
                    if (folders.Length > 1)
                    {
                        for (var i = 0; i < folders.Length - 1; i++)
                        {
                            string newDirectoryPath = Path.Combine(this.basePath + path, folders[i]);
                            if (Path.GetFullPath(newDirectoryPath) != (Path.GetDirectoryName(newDirectoryPath) + Path.DirectorySeparatorChar + folders[i]))
                            {
                                throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                            }
                            if (!Directory.Exists(newDirectoryPath))
                            {
                                this.operation.ToCamelCase(this.operation.Create(path, folders[i]));
                            }
                            path += folders[i] + "/";
                        }
                    }
                }
                uploadResponse = operation.Upload(path, uploadFiles, action, null);
                if (uploadResponse.Error != null)
                {
                    Response.Clear();
                    Response.ContentType = "application/json; charset=utf-8";
                    Response.StatusCode = Convert.ToInt32(uploadResponse.Error.Code);
                    Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = uploadResponse.Error.Message;
                }
            }
            catch (Exception e)
            {
                ErrorDetails er = new ErrorDetails();
                er.Message = e.Message.ToString();
                er.Code = "417";
                er.Message = "Access denied for Directory-traversal";
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = Convert.ToInt32(er.Code);
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = er.Message;
                return Content("");
            }
            return Content("");
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 3:** Access upload response from model

To access the upload Operation, you need physical model class files that have upload operation methods. So, create `Models` folder in `server` part of the application and include the the `PhysicalFileProvider.cs` and required base class from the [link](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider/tree/master/Models) in the Models folder.

In the following example, the **Upload** operation is handled from physical service.

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

        public virtual FileManagerResponse Upload(string path, IList<IFormFile> uploadFiles, string action, params FileManagerDirectoryContent[] data)
        {
            FileManagerResponse uploadResponse = new FileManagerResponse();
            try
            {
                string validatePath;
                validatePath = Path.Combine(contentRootPath + path);
                if (Path.GetFullPath(validatePath) != GetFilePath(validatePath))
                {
                    throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                }
                AccessPermission PathPermission = GetPathPermission(path);
                if (PathPermission != null && (!PathPermission.Read || !PathPermission.Upload))
                {
                    accessMessage = PathPermission.Message;
                    throw new UnauthorizedAccessException("'" + this.getFileNameFromPath(this.rootName + path) + "' is not accessible. You need permission to perform the upload action.");
                }

                List<string> existFiles = new List<string>();
                foreach (IFormFile file in uploadFiles)
                {
                    if (uploadFiles != null)
                    {
                        var name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim().ToString();
                        string[] folders = name.Split('/');
                        string fileName = folders[folders.Length - 1];
                        var fullName = Path.Combine((this.contentRootPath + path), fileName);
                        if (Path.GetFullPath(fullName) != GetFilePath(fullName) + Path.GetFileName(fullName))
                        {
                            throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                        }
                        if (action == "save")
                        {
                            if (!System.IO.File.Exists(fullName))
                            {
                                using (FileStream fs = System.IO.File.Create(fullName))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();
                                }
                            }
                            else
                            {
                                existFiles.Add(fullName);
                            }
                        }
                        else if (action == "remove")
                        {
                            if (System.IO.File.Exists(fullName))
                            {
                                System.IO.File.Delete(fullName);
                            }
                            else
                            {
                                ErrorDetails er = new ErrorDetails();
                                er.Code = "404";
                                er.Message = "File not found.";
                                uploadResponse.Error = er;
                            }
                        }
                        else if (action == "replace")
                        {
                            if (System.IO.File.Exists(fullName))
                            {
                                System.IO.File.Delete(fullName);
                            }
                            using (FileStream fs = System.IO.File.Create(fullName))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                        else if (action == "keepboth")
                        {
                            string newName = fullName;
                            int index = newName.LastIndexOf(".");
                            if (index >= 0)
                                newName = newName.Substring(0, index);
                            int fileCount = 0;
                            while (System.IO.File.Exists(newName + (fileCount > 0 ? "(" + fileCount.ToString() + ")" + Path.GetExtension(name) : Path.GetExtension(name))))
                            {
                                fileCount++;
                            }
                            newName = newName + (fileCount > 0 ? "(" + fileCount.ToString() + ")" : "") + Path.GetExtension(name);
                            using (FileStream fs = System.IO.File.Create(newName))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                    }
                }
                if (existFiles.Count != 0)
                {
                    ErrorDetails er = new ErrorDetails();
                    er.Code = "400";
                    er.Message = "File already exists.";
                    er.FileExists = existFiles;
                    uploadResponse.Error = er;
                }
                return uploadResponse;
            }
            catch (Exception e)
            {
                ErrorDetails er = new ErrorDetails();

                er.Message = (e.GetType().Name == "UnauthorizedAccessException") ? "'" + this.getFileNameFromPath(path) + "' is not accessible. You need permission to perform the upload action." : e.Message.ToString();
                er.Code = er.Message.Contains("is not accessible. You need permission") ? "401" : "417";
                if ((er.Code == "401") && !string.IsNullOrEmpty(accessMessage)) { er.Message = accessMessage; }
                uploadResponse.Error = er;
                return uploadResponse;
            }
        }
        ...

{% endhighlight %}
{% endtabs %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/FileManager).