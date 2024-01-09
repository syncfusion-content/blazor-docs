---
layout: post
title: Save PDF files to Box cloud storage in  PDF Viewer Component | Syncfusion
description: Learn here all about how to save PDF files to Box cloud file storage in Syncfusion Blazor PDF Viewer component and much more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Save PDF file to Box cloud file storage

To save a PDF file to Box cloud file storage, you can follow the steps below


**Step 1** Set up a Box developer account and create a Box application

To access Box storage programmatically, you'll need a developer account with Box. Go to the [Box Developer Console](https://developer.box.com/), sign in or create a new account, and then create a new Box application. This application will provide you with the necessary credentials Client ID and Client Secret to authenticate and access Box APIs. Before accessing files, you need to authenticate your application to access your Box account. Box API supports `OAuth 2.0 authentication` for this purpose.

**Step 2:** Create a Simple PDF Viewer Sample in blazor

Start by following the steps provided in this [link](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) to create a simple PDF viewer sample in blazor. This will give you a basic setup of the PDF viewer component.

**Step 3:** Include the following namespaces in the **Index.razor** file.

1. Import the required namespaces at the top of the file:

```csharp
@using Box.V2;
@using Box.V2.Auth;
@using Box.V2.Config;
@using Box.V2.Models;
@using Syncfusion.Blazor.SfPdfViewer;
@using Syncfusion.Blazor.Buttons
```

**Step 4:** Add the below code example to save pdf to `Box cloud storage` 

```csharp

@page "/"
<SfButton @onclick="OnClick">Save file to Box storage</SfButton>
<SfPdfViewer2 DocumentPath="@DocumentPath"
              @ref="viewer"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code {
    private SfPdfViewer2 viewer;
    private string DocumentPath { get; set; }
    private readonly string accessToken = "Your Box Storage Access Token";
    private readonly string folderID = "Your Folder ID";
    private readonly string clientID = "Your Box Storage ClientID";
    private readonly string clientSecret = "Your Box Storage ClientSecret";
    private readonly string fileName = "File Name to be loaded into Syncfusion PDF Viewer";

    public async void OnClick(MouseEventArgs args)
    {
        byte[] data = await viewer.GetDocumentAsync();
        string result = Path.GetFileNameWithoutExtension(fileName);
        string FileName = result + "_downloaded.pdf";
        // Initialize the Box API client with your authentication credentials
        var auth = new OAuthSession(accessToken, "YOUR_REFRESH_TOKEN", 3600, "bearer");
        var config = new BoxConfigBuilder(clientID, clientSecret, new Uri("http://boxsdk")).Build();
        var client = new BoxClient(config, auth);

        var fileRequest = new BoxFileRequest
            {
                Name = FileName,
                Parent = new BoxFolderRequest { Id = folderID },
            };

        using (var stream = new MemoryStream(data))
        {
            var boxFile = await client.FilesManager.UploadAsync(fileRequest, stream);
        }

    }
}

```

N> replace **Your_Box_Storage_Access_Token** with your actual box access token, and **Your_Folder_ID** with the ID of the folder in your box storage where you want to perform specific operations. Remember to use your valid box API credentials, as **Your_Box_Storage_ClientID** and **Your_Box_Storage_ClientSecret"** are placeholders for your application's API key and secret.

N> The **Box.V2.Core** NuGet package must be installed in your application to use the previous code example.

N> Replace `PDF_Succinctly.pdf` with the actual document name that you want to load from Box cloud file storage. Make sure to pass the document name from the box folder to the `documentPath` property of the PDF viewer component

[View sample in GitHub](https://github.com/SyncfusionExamples/open-save-pdf-documents-in-box-cloud-file-storage)