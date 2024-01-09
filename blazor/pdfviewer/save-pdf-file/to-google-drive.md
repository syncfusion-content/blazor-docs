---
layout: post
title: Save PDF files to Google Drive in PDF Viewer Component | Syncfusion
description: Learn here all about how to save PDF files to Google Drive in Syncfusion Blazor PDF Viewer component and much more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Save PDF file to Google Drive

To save a PDF file to Google Drive, you can follow the steps below

**Step 1** Set up Google Drive API

You must set up a project in the Google Developers Console and enable the Google Drive API. Obtain the necessary credentials to access the API. For more information, view the official [link](https://developers.google.com/drive/api/guides/enable-sdk).

**Step 2:** Create a Simple PDF Viewer Sample in blazor

Start by following the steps provided in this [link](https://blazor.syncfusion.com/documentation/pdfviewer/getting-started/server-side-application) to create a simple PDF viewer sample in blazor. This will give you a basic setup of the PDF viewer component.

**Step 3:** Include the following namespaces in the **Index.razor** file.

1. Import the required namespaces at the top of the file:

```csharp
@using Google.Apis.Drive.v3;
@using Google.Apis.Auth.OAuth2;
@using Google.Apis.Services;
@using Google.Apis.Util.Store;
@using System.Threading.Tasks;
@using Syncfusion.Blazor.PdfViewerServer;
@using Syncfusion.Blazor.Buttons
```

**Step 4:**  Add the below code example to save the downloaded PDF files to `Google drive` file.

```csharp

@page "/"
<SfButton @onclick="OnClick">Save file to google drive</SfButton>
<SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath" Height="500px" Width="1060px"></SfPdfViewerServer>

@code {
    private string DocumentPath { get; set; }
    private SfPdfViewerServer viewer;
    
    private readonly string FolderId = "Your Google Drive Folder ID";
    private readonly string CredentialPath = "Your Path to the OAuth 2.0 Client IDs json file";
    private readonly string ApplicationName = "Your Application name";
    private readonly string FileName = "File Name to be loaded into Syncfusion PDF Viewer";
    private static readonly string[] Scopes = { DriveService.Scope.DriveFile, DriveService.Scope.DriveReadonly };

    public async void OnClick(MouseEventArgs args)
    {
        byte[] data = await viewer.GetDocument();
        string result = Path.GetFileNameWithoutExtension(FileName);
        string fileName = result + "_downloaded.pdf";
        UserCredential credential;

        using (var memStream = new FileStream(CredentialPath, FileMode.Open, FileAccess.Read))
        {
            string credPath = "token.json";
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(memStream).Secrets,
            Scopes,
            "user",
             CancellationToken.None,
            new FileDataStore(credPath, true));
        }

        // Create the Drive API service.
        var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

        var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = fileName,
                Parents = new List<string> { FolderId }
            };

        FilesResource.CreateMediaUpload request;

        using (var stream = new MemoryStream(data))
        {
            request = service.Files.Create(fileMetadata, stream, "application/pdf");
            request.Fields = "id";
            object value = await request.UploadAsync();
        }
    }
}

```

N> Replace **Your Google Drive Folder ID** with your actual Google Drive folder ID, **Your Application name** with your actual application name, **File Name to be Loaded into Syncfusion PDF Viewer** with the actual file name you want to load from the Azure container to the Syncfusion PDF Viewer and **Your Path to the OAuth 2.0 Client IDs JSON file** with the actual path to your OAuth 2.0 Client IDs JSON file

N> The **FolderId** part is the unique identifier for the folder. For example, if your folder URL is: `https://drive.google.com/drive/folders/abc123xyz456`, then the folder ID is `abc123xyz456`.

N> The **Google.Apis.Drive.v3** NuGet package must be installed in your application to use the previous code example.

[View sample in GitHub](https://github.com/SyncfusionExamples/open-save-pdf-documents-in-google-drive)