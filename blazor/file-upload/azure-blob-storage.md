---
layout: post
title: Azure Blob Storage in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about uploading files to Azure Blob Storage using Syncfusion Blazor File Upload component and more.
platform: Blazor
control: File Upload
documentation: ug
---

# Azure Blob Storage in Blazor File Upload Component

To get started with uploading files to Azure Blob Storage, ensure you have an active Microsoft Azure account with a configured Blob Storage service. The Syncfusion Blazor File Upload component allows you to upload files directly to Azure Blob Storage by configuring the server-side controller to handle Azure operations.

## Installing NuGet Package

Install the `Azure.Storage.Blobs` NuGet package in your Server project to work with Azure Blob Storage:

```bash
dotnet add package Azure.Storage.Blobs
```

## Configuring Azure Connection String

Add the Azure connection string to your `appsettings.json` file in the Server project:

```json
{
  "ConnectionStrings": {
    "AzureConnectionString": "DefaultEndpointsProtocol=https;AccountName=<--accountName-->;AccountKey=<--accountKey-->;EndpointSuffix=core.windows.net"
  }
}
```

N> You can get the **Connection string** from the Access keys section of your Azure Storage account in the Azure portal.

## Server-Side Controller Configuration

Create a new controller named `AzureUploadController.cs` in the `Controllers` folder of your Server project:

```csharp
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureUploadController : ControllerBase
    {
        private readonly string azureConnectionString;
        private const string ContainerName = "upload-container"; // Change this to your container name

        public AzureUploadController(IConfiguration configuration)
        {
            azureConnectionString = configuration.GetConnectionString("AzureConnectionString");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (var file in UploadFiles)
                {
                    if (file.Length > 0)
                    {
                        // Create a BlobContainerClient object to interact with the container
                        var containerClient = new BlobContainerClient(azureConnectionString, ContainerName);

                        // Create the container if it doesn't exist
                        var createResponse = await containerClient.CreateIfNotExistsAsync();

                        // Set public access type to Blob if container was just created
                        if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                        {
                            await containerClient.SetAccessPolicyAsync(PublicAccessType.Blob);
                        }

                        // Get a reference to a blob
                        var blobClient = containerClient.GetBlobClient(file.FileName);

                        // Delete the blob if it exists
                        await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

                        // Upload the file to Azure Blob Storage
                        using (var fileStream = file.OpenReadStream())
                        {
                            await blobClient.UploadAsync(fileStream, new BlobHttpHeaders 
                            { 
                                ContentType = file.ContentType 
                            });
                        }
                    }
                }

                return Ok(new { message = "Files uploaded successfully" });
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.StatusCode = 400;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File upload failed";
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
```

## File Upload Component Configuration

After configuring the server-side controller, map the File Upload component to the controller action by setting the `SaveUrl` in the `UploaderAsyncSettings`:

```cshtml

@*Initializing File Upload with Azure service.*@

@* Replace the hosted port number in the place of "{port}" *@

<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings SaveUrl="http://localhost:{port}/api/AzureUpload/Upload"></UploaderAsyncSettings>
</SfUploader>

```

N> To learn more about file upload operations that can be performed with Azure Blob Storage, refer to this [link](https://github.com/SyncfusionExamples/upload-files-to-azure-using-blazor-file-upload/)

## See Also

* [Asynchronous Upload](./async)
* [Chunk Upload](./chunk-upload)
* [File Upload Events](./async#events)
* [Azure File Manager Provider](../file-manager/azure-cloud-file-system-provider)
* [Blog: Simple Steps to Upload Files to Azure Blob Storage in Blazor App](https://www.syncfusion.com/blogs/post/simple-steps-to-upload-files-to-azure-blob-storage-in-blazor-app)
