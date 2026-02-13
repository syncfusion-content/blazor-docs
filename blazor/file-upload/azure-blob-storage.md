---
layout: post
title: Azure Blob Storage Integration in Blazor File Upload Component | Syncfusion
description: Learn how to upload files to Azure Blob Storage using the Syncfusion Blazor File Upload component with step-by-step configuration and implementation guidance.
platform: Blazor
control: File Upload
documentation: ug
---

# Azure Blob Storage in Blazor File Upload Component

The Syncfusion Blazor File Upload component enables seamless file uploads directly to Azure Blob Storage by leveraging server-side ASP.NET Core controllers to manage Azure operations. This integration allows developers to store files in Azure Blob Storage without managing local server storage.

## Prerequisites

Before implementing Azure Blob Storage integration, ensure you have:

* An active Microsoft Azure account
* An Azure Storage Account created in the Azure portal
* A Blob Container configured within the Storage Account
* Access keys retrieved from the **Access keys** section of your Storage Account
* The `Azure.Storage.Blobs` NuGet package available in your project

## Installing NuGet Package

Install the `Azure.Storage.Blobs` NuGet package in your Server project to work with Azure Blob Storage:

```bash
dotnet add package Azure.Storage.Blobs
```

## Configuring Azure Connection String

Store your Azure connection string securely in the `appsettings.json` file of your Server project:

```json
{
  "ConnectionStrings": {
    "AzureConnectionString": "DefaultEndpointsProtocol=https;AccountName=<your-account-name>;AccountKey=<your-account-key>;EndpointSuffix=core.windows.net"
  }
}
```

N> Retrieve the **Connection string** from your Azure Storage Account by navigating to **Settings** > **Access keys** in the Azure portal. Never commit connection strings to version control; consider using Azure Key Vault or environment variables for production environments.

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
                        // Create a BlobContainerClient to interact with the Azure Blob Storage container.
                        // The container name should match the configured container in your Azure Storage Account.
                        var container = new BlobContainerClient(azureConnectionString, ContainerName);

                        // Create the container if it doesn't exist with private access.
                        // Using PublicAccessType.None ensures files are not publicly accessible.
                        await container.CreateIfNotExistsAsync(PublicAccessType.None);

                        // Get a reference to the blob using the uploaded file name.
                        var blob = container.GetBlobClient(file.FileName);

                        // Delete the blob if it already exists to avoid version conflicts.
                        await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

                        // Upload the file to Azure Blob Storage with proper content type.
                        using (var fileStream = file.OpenReadStream())
                        {
                            await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                        }
                    }
                }

                return Ok(new { message = "Files uploaded to Azure Blob Storage successfully" });
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.StatusCode = 500;
                var feature = Response.HttpContext.Features.Get<IHttpResponseFeature>();
                if (feature != null)
                {
                    feature.ReasonPhrase = $"File upload failed: {ex.Message}";
                }
                return StatusCode(500, new { error = ex.Message });
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


## See Also

* [Asynchronous Upload](./async)
* [Chunk Upload](./chunk-upload)
* [File Upload Events](./async#events)
* [Azure File Manager Provider](../file-manager/azure-cloud-file-system-provider)
* [Blog: Simple Steps to Upload Files to Azure Blob Storage in Blazor App](https://www.syncfusion.com/blogs/post/simple-steps-to-upload-files-to-azure-blob-storage-in-blazor-app)
