---
layout: post
title: Moving file in Blazor FileManager with Physical service | Syncfusion
description: Checkout and learn here all about move operation of Syncfusion Blazor FileManager component with physical service and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Move file from phsyical service provider

To perform a move operation in Syncfusion Blazor FileManager component from ASP.NET Core physical file system provider, you can follow the steps below

**Step 1:** Create a `File Manager` Sample in blazor

Start by following the steps provided in this link to create a simple `SfPdfViewer` sample in blazor. To perform the move operation, initialize the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html#Syncfusion_Blazor_FileManager_FileManagerAjaxSettings_Url) property in a FileManagerAjaxSettings.

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="/api/FileManager/FileOperations">
    </FileManagerAjaxSettings>
</SfFileManager>

{% endhighlight %}
{% endtabs %}

**Step 2:** Initialize the physical service in controller

To initialize a local service with move action, create a new folder name with `Controllers` inside the server part of the project. Then, create a new file with extension `.cs` inside the Controllers folder and add the following code in that file.

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
                case "move":
                    // cuts the selected file(s) or folder(s) from a path and then pastes them into a given target path.
                    return this.operation.ToCamelCase(this.operation.Move(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                ...
            }
            return null;
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 3:** Access move response from model

To access the move Operation, you need physical model class files that have move operation methods. So, create `Models` folder in `server` part of the application and include the the `PhysicalFileProvider.cs` and required base class from the [link](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider/tree/master/Models) in the Models folder.

In the following example, the **Move** operation is handled from physical service.

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

        public virtual FileManagerResponse Move(string path, string targetPath, string[] names, string[] renameFiles, FileManagerDirectoryContent targetData, params FileManagerDirectoryContent[] data)
        {
            FileManagerResponse moveResponse = new FileManagerResponse();
            try
            {
                string validatePath;
                validatePath = Path.Combine(contentRootPath + path);
                if (Path.GetFullPath(validatePath) != GetFilePath(validatePath))
                {
                    throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                }
                string result = String.Empty;
                if (renameFiles == null)
                {
                    renameFiles = new string[0];
                }
                string physicalPath = GetPath(path);
                for (int i = 0; i < names.Length; i++)
                {
                    bool IsFile = !IsDirectory(physicalPath, names[i]);
                    AccessPermission permission = GetPermission(physicalPath, names[i], IsFile);
                    if (permission != null && (!permission.Read || !permission.Write))
                    {
                        accessMessage = permission.Message;
                        throw new UnauthorizedAccessException("'" + this.getFileNameFromPath(this.rootName + path + names[i]) + "' is not accessible. You need permission to perform the write action.");
                    }
                }
                AccessPermission PathPermission = GetPathPermission(targetPath);
                if (PathPermission != null && (!PathPermission.Read || !PathPermission.WriteContents))
                {
                    accessMessage = PathPermission.Message;
                    throw new UnauthorizedAccessException("'" + this.getFileNameFromPath(this.rootName + targetPath) + "' is not accessible. You need permission to perform the writeContents action.");
                }

                List<string> existFiles = new List<string>();
                List<string> missingFiles = new List<string>();
                List<FileManagerDirectoryContent> movedFiles = new List<FileManagerDirectoryContent>();
                string tempPath = path;
                for (int i = 0; i < names.Length; i++)
                {
                    string fullName = names[i];
                    int name = names[i].LastIndexOf("/");
                    if (name >= 0)
                    {
                        path = tempPath + names[i].Substring(0, name + 1);
                        names[i] = names[i].Substring(name + 1);
                    }
                    else
                    {
                        path = tempPath;
                    }
                    string itemPath = Path.Combine(contentRootPath + path, names[i]);
                    if (Path.GetFullPath(itemPath) != GetFilePath(itemPath) + Path.GetFileName(itemPath))
                    {
                        throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                    }
                    if (Directory.Exists(itemPath) || File.Exists(itemPath))
                    {
                        if ((File.GetAttributes(itemPath) & FileAttributes.Directory) == FileAttributes.Directory)
                        {
                            string directoryName = names[i];
                            string oldPath = Path.Combine(contentRootPath + path, directoryName);
                            if (Path.GetFullPath(oldPath) != GetFilePath(oldPath) + Path.GetFileName(oldPath))
                            {
                                throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                            }
                            string newPath = Path.Combine(contentRootPath + targetPath, directoryName);
                            if (Path.GetFullPath(newPath) != GetFilePath(newPath) + Path.GetFileName(newPath))
                            {
                                throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                            }
                            bool exist = Directory.Exists(newPath);
                            if (exist)
                            {
                                int index = -1;
                                if (renameFiles.Length > 0)
                                {
                                    index = Array.FindIndex(renameFiles, row => row.Contains(directoryName));
                                }
                                if ((newPath == oldPath) || (index != -1))
                                {
                                    newPath = DirectoryRename(newPath);
                                    result = DirectoryCopy(oldPath, newPath);
                                    if (result != String.Empty) { break; }
                                    bool isExist = Directory.Exists(oldPath);
                                    if (isExist)
                                    {
                                        result = DeleteDirectory(oldPath);
                                        if (result != String.Empty) { break; }
                                    }
                                    FileManagerDirectoryContent detail = GetFileDetails(newPath);
                                    detail.PreviousName = names[i];
                                    movedFiles.Add(detail);
                                }
                                else
                                {
                                    existFiles.Add(fullName);
                                }
                            }
                            else
                            {
                                result = DirectoryCopy(oldPath, newPath);
                                if (result != String.Empty) { break; }
                                bool isExist = Directory.Exists(oldPath);
                                if (isExist)
                                {
                                    result = DeleteDirectory(oldPath);
                                    if (result != String.Empty) { break; }
                                }
                                FileManagerDirectoryContent detail = GetFileDetails(newPath);
                                detail.PreviousName = names[i];
                                movedFiles.Add(detail);
                            }
                        }
                        else
                        {
                            string fileName = names[i];
                            string oldPath = Path.Combine(contentRootPath + path, fileName);
                            if (Path.GetFullPath(oldPath) != GetFilePath(oldPath) + Path.GetFileName(oldPath))
                            {
                                throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                            }
                            string newPath = Path.Combine(contentRootPath + targetPath, fileName);
                            if (Path.GetFullPath(newPath) != GetFilePath(newPath) + Path.GetFileName(newPath))
                            {
                                throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                            }
                            bool fileExist = File.Exists(newPath);
                            try
                            {

                                if (fileExist)
                                {
                                    int index = -1;
                                    if (renameFiles.Length > 0)
                                    {
                                        index = Array.FindIndex(renameFiles, row => row.Contains(fileName));
                                    }
                                    if ((newPath == oldPath) || (index != -1))
                                    {
                                        newPath = FileRename(newPath, fileName);
                                        File.Copy(oldPath, newPath);
                                        bool isExist = File.Exists(oldPath);
                                        if (isExist)
                                        {
                                            File.Delete(oldPath);
                                        }
                                        FileManagerDirectoryContent detail = GetFileDetails(newPath);
                                        detail.PreviousName = names[i];
                                        movedFiles.Add(detail);
                                    }
                                    else
                                    {
                                        existFiles.Add(fullName);
                                    }
                                }
                                else
                                {
                                    File.Copy(oldPath, newPath);
                                    bool isExist = File.Exists(oldPath);
                                    if (isExist)
                                    {
                                        File.Delete(oldPath);
                                    }
                                    FileManagerDirectoryContent detail = GetFileDetails(newPath);
                                    detail.PreviousName = names[i];
                                    movedFiles.Add(detail);
                                }

                            }
                            catch (Exception e)
                            {
                                if (e.GetType().Name == "UnauthorizedAccessException")
                                {
                                    result = newPath;
                                    break;
                                }
                                else
                                {
                                    throw;
                                }
                            }
                        }
                    }
                    else
                    {
                        missingFiles.Add(names[i]);
                    }
                }
                moveResponse.Files = movedFiles;
                if (result != String.Empty)
                {
                    string deniedPath = result.Substring(this.contentRootPath.Length);
                    ErrorDetails er = new ErrorDetails();
                    er.Message = "'" + this.getFileNameFromPath(deniedPath) + "' is not accessible. You need permission to perform this action.";
                    er.Code = "401";
                    moveResponse.Error = er;
                    return moveResponse;
                }
                if (existFiles.Count > 0)
                {
                    ErrorDetails er = new ErrorDetails();
                    er.FileExists = existFiles;
                    er.Code = "400";
                    er.Message = "File Already Exists";
                    moveResponse.Error = er;
                }
                if (missingFiles.Count == 0)
                {
                    return moveResponse;
                }
                else
                {
                    string namelist = missingFiles[0];
                    for (int k = 1; k < missingFiles.Count; k++)
                    {
                        namelist = namelist + ", " + missingFiles[k];
                    }
                    throw new FileNotFoundException(namelist + " not found in given location.");
                }
            }
            catch (Exception e)
            {
                ErrorDetails er = new ErrorDetails
                {
                    Message = e.Message.ToString(),
                    Code = e.Message.ToString().Contains("is not accessible. You need permission") ? "401" : "417",
                    FileExists = moveResponse.Error?.FileExists
                };
                if ((er.Code == "401") && !string.IsNullOrEmpty(accessMessage)) { er.Message = accessMessage; }
                moveResponse.Error = er;
                return moveResponse;
            }
        }
        ...

{% endhighlight %}
{% endtabs %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/FileManager).