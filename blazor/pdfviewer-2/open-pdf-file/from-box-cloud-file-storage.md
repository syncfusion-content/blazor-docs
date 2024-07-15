---
layout: post
title: Open PDF files from Box storage SfPdfViewer Component | Syncfusion
description: Learn here all about how to Open PDF files from Box cloud file storage in Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Open PDF file from Box cloud file storage

To load a PDF file from Box cloud file storage in a SfPdfViewer, you can follow the steps below

**Step 1** Set up a Box developer account and create a Box application

To access Box storage programmatically, you'll need a developer account with Box. Go to the [Box Developer Console](https://developer.box.com/), sign in or create a new account, and then create a new Box application. This application will provide you with the necessary credentials Client ID and Client Secret to authenticate and access Box APIs. Before accessing files, you need to authenticate your application to access your Box account. Box API supports `OAuth 2.0 authentication` for this purpose.

**Step 2:** Create a Simple SfPdfViewer Sample in blazor

Start by following the steps provided in this [link](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) to create a simple SfPdfViewer sample in blazor. This will give you a basic setup of the SfPdfViewer component.

**Step 3:** Include the following namespaces in the **Index.razor** file.

1. Import the required namespaces at the top of the file:

```csharp
@using Box.V2;
@using Box.V2.Auth;
@using Box.V2.Config;
@using Box.V2.Models;
@using Syncfusion.Blazor.SfPdfViewer;
```

**Step 4:** Add the below code example to load a PDF from `Box cloud storage` 

```csharp

@page "/"

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
    private readonly string fileName = "File Name to be loaded into Syncfusion SfPdfViewer";

    protected override async Task OnInitializedAsync()
    {
        // Initialize the Box API client with your authentication credentials
        var auth = new OAuthSession(accessToken, "YOUR_REFRESH_TOKEN", 3600, "bearer");
        var config = new BoxConfigBuilder(clientID, clientSecret, new Uri("http://boxsdk")).Build();
        var client = new BoxClient(config, auth);

        // Download the file from Box storage
        var items = await client.FoldersManager.GetFolderItemsAsync(folderID, 1000, autoPaginate: true);
        var files = items.Entries.Where(i => i.Type == "file");

        // Filter the files based on the objectName
        var matchingFile = files.FirstOrDefault(file => file.Name == fileName);

        if (matchingFile != null)
        {
            // Fetch the file from Box storage by its ID
            using (var fileStream = await client.FilesManager.DownloadAsync(matchingFile.Id).ConfigureAwait(false))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(stream).ConfigureAwait(false);

                    // Reset the position to the beginning of the stream
                    stream.Position = 0;
                    DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(stream.ToArray());
                }
            }
        }
        else
        {
            // Handle case where the file is not found
            Console.WriteLine("File not found in the specified folder.");
        }
    }
}
```

N> replace **Your_Box_Storage_Access_Token** with your actual box access token, and **Your_Folder_ID** with the ID of the folder in your box storage where you want to perform specific operations. Remember to use your valid box API credentials, as **Your_Box_Storage_ClientID** and **Your_Box_Storage_ClientSecret"** are placeholders for your application's API key and secret.

N> The **Box.V2.Core** NuGet package must be installed in your application to use the previous code example.

N> Replace `PDF_Succinctly.pdf` with the actual document name that you want to load from Box cloud file storage. Make sure to pass the document name from the box folder to the [documentPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_DocumentPath) property of the SfPdfViewer component

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Open%20and%20Save%20from%20box%20cloud%20storage-SfPdfViewer)

## See also

* [Processing Large Files Without Increasing Maximum Message Size in SfPdfViewer Component](../how-to/processing-large-files-without-increasing-maximum-message-size)