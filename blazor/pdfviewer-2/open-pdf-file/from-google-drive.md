---
layout: post
title: Open PDF files from Google Drive in SfPdfViewer Component | Syncfusion
description: Learn here all about how to Open PDF files from Google Drive in Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Open PDF file from Google Drive

To load a PDF file from Google Drive in a SfPdfViewer, you can follow the steps below

**Step 1** Set up Google Drive API

You must set up a project in the Google Developers Console and enable the Google Drive API. Obtain the necessary credentials to access the API. For more information, view the official [link](https://developers.google.com/drive/api/guides/enable-sdk).

**Step 2:** Create a Simple SfPdfViewer Sample in blazor

Start by following the steps provided in this [link](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) to create a simple SfPdfViewer sample in blazor. This will give you a basic setup of the SfPdfViewer component.

**Step 3:** Include the following namespaces in the **Index.razor** file.

1. Import the required namespaces at the top of the file:

```csharp
@using Google.Apis.Drive.v3;
@using Google.Apis.Auth.OAuth2;
@using Google.Apis.Services;
@using Google.Apis.Util.Store;
@using System.Threading.Tasks;
@using Syncfusion.Blazor.SfPdfViewer;
```

**Step 4:** Add the below code example to load a PDF from `Google drive` file.

```csharp
@page "/"

<SfPdfViewer2 DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code {
    private string DocumentPath { get; set; }

    private readonly string FolderId = "Your Google Drive Folder ID";
    private readonly string CredentialPath = "Your Path to the OAuth 2.0 Client IDs json file";
    private readonly string ApplicationName = "Your Application name";
    private readonly string FileName = "File Name to be loaded into Syncfusion SfPdfViewer";

    private static readonly string[] Scopes = { DriveService.Scope.DriveFile, DriveService.Scope.DriveReadonly };

    protected override async Task OnInitializedAsync()
    {
        UserCredential credential;
        using (var stream1 = new FileStream(CredentialPath, FileMode.Open, FileAccess.Read))
        {
            string credPath = "token.json";
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream1).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true));
        }

        var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

        var listRequest = service.Files.List();
        listRequest.Q = $"mimeType='application/pdf' and '{FolderId}' in parents and trashed=false";
        listRequest.Fields = "files(id, name)";
        var files = await listRequest.ExecuteAsync();

        string fileIdToDownload = files.Files
            .FirstOrDefault(file => file.Name == FileName)?.Id;

        if (!string.IsNullOrEmpty(fileIdToDownload))
        {
            var request = service.Files.Get(fileIdToDownload);
            using (var stream = new MemoryStream())
            {
                await request.DownloadAsync(stream);
                stream.Position = 0;
                DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(stream.ToArray());
            }
        }
        else
        {
            Console.WriteLine("File not found in Google Drive.");
        }
    }
}

```

N> Replace **Your Google Drive Folder ID** with your actual Google Drive folder ID, **Your Application name** with your actual application name, **File Name to be Loaded into Syncfusion SfPdfViewer** with the actual file name you want to load from the Azure container to the Syncfusion SfPdfViewer and **Your Path to the OAuth 2.0 Client IDs JSON file** with the actual path to your OAuth 2.0 Client IDs JSON file

N> The **FolderId** part is the unique identifier for the folder. For example, if your folder URL is: `https://drive.google.com/drive/folders/abc123xyz456`, then the folder ID is `abc123xyz456`.

N> The **Google.Apis.Drive.v3** NuGet package must be installed in your application to use the previous code example.

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Open%20and%20Save%20from%20Google%20Drive-SfPdfViewer)

## See also

* [Processing Large Files Without Increasing Maximum Message Size in SfPdfViewer Component](../how-to/processing-large-files-without-increasing-maximum-message-size)