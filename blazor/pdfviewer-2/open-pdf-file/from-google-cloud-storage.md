---
layout: post
title: Open PDF files from GCS in Blazor SfPdfViewer Component | Syncfusion
description: Learn here all about how to Open PDF files from Google Cloud Storage in Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Open PDF file from Google Cloud Storage

To load a PDF file from Google Cloud Storage in a SfPdfViewer, you can follow the steps below

**Step 1** Create a Service Account

Open the Google Cloud Console. Navigate to `IAM & Admin` > `Service accounts`. Click `Create Service Account`.` Enter a name, assign roles (e.g., Storage Object Admin), and create a key in JSON format. Download the key file securely. Utilize the downloaded key file in your applications or services for authentication and access to the Google Cloud Storage bucket. For additional details, refer to the [official documentation](https://cloud.google.com/iam/docs/service-accounts-create).

**Step 2:** Create a Simple SfPdfViewer Sample in blazor

Start by following the steps provided in this [link](https://blazor.syncfusion.com/documentation/pdfviewer/getting-started/server-side-application) to create a simple SfPdfViewer sample in blazor. This will give you a basic setup of the SfPdfViewer component.

**Step 3:** Include the following namespaces in the **Index.razor** file.

1. Import the required namespaces at the top of the file:

```csharp
@using Google.Cloud.Storage.V1;
@using Google.Apis.Auth.OAuth2;
@using Syncfusion.Blazor.SfPdfViewer;
```

**Step 4:** Add the below code example to

```csharp

@page "/"

<SfPdfViewer2 DocumentPath="@DocumentPath"
              @ref="@viewer"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code {
    private string DocumentPath { get; set; }
    private SfPdfViewer2 viewer;
    private readonly string keyFilePath = @"path/to/service-account-key.json";
    private readonly string bucketName = "YourBucketName";
    private readonly string fileName = "FileName.pdf";
    private StorageClient _storageClient;

    protected override async Task OnInitializedAsync()
    {
        MemoryStream stream = new MemoryStream();
        // Load the service account credentials from the key file.
        var credentials = GoogleCredential.FromFile(keyFilePath);
        // Create a storage client with Application Default Credentials
        _storageClient = StorageClient.Create(credentials);
        _storageClient.DownloadObject(bucketName, fileName, stream);
        stream.Position = 0;
        DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(stream.ToArray());
    }
}
```

N> Replace **Your Bucket name from Google Cloud Storage** with the actual name of your Google Cloud Storage bucket and **File Name to be Loaded into Syncfusion SfPdfViewer** with the actual file name you want to load from the cloud bucket

N> Replace **path/to/service-account-key.json** with the actual file path to your service account key JSON file. Make sure to provide the correct path and filename.

N> The **Google.Cloud.Storage.V1** NuGet package must be installed in your application to use the previous code example.

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Open%20and%20Save%20from%20GCS)

## See also

* [Processing Large Files Without Increasing Maximum Message Size in SfPdfViewer Component](../how-to/processing-large-files-without-increasing-maximum-message-size)