---
layout: post
title: Opening A Document in Blazor DocumentEditor Component | Syncfusion 
description: Learn about Opening A Document in Blazor DocumentEditor component of Syncfusion, and more details.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Open documents in Blazor Word processor from various storage location

You might need to open and view Word documents from various location. In this section, you can find the information about how to open Word documents from URL, cloud, database, and local file system and also how to load a document during control initialization.

## Opening a document from URL

If you have your Word document file in the web, you can open it in [`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) using URL. The following code example explains how to open a Word document file from URL.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@using System.IO
@using System.Net
@using Newtonsoft.Json

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    string sfdtString;

    protected override void OnInitialized()
    {
        string fileUrl = "https://www.syncfusion.com/downloads/support/directtrac/general/doc/Getting_Started1018066633.docx";
        WebClient webClient = new WebClient();
        byte[] byteArray = webClient.DownloadData(fileUrl);
        Stream stream = new MemoryStream(byteArray);
        //To observe the memory go down, null out the reference of byteArray variable.
        byteArray = null;
        WordDocument document = WordDocument.Load(stream, ImportFormatType.Docx);
        stream.Dispose();
        //To observe the memory go down, null out the reference of stream variable.
        stream = null;
        sfdtString = JsonConvert.SerializeObject(document);
        document.Dispose();
        //To observe the memory go down, null out the reference of document variable.
        document = null;
    }

    public void OnLoad(object args)
    {
        SfDocumentEditor editor = container.DocumentEditor;
        editor.Open(sfdtString);
        //To observe the memory go down, null out the reference of sfdtString variable.
        sfdtString = null;
    }
}
```

>Note: As per the discussion thread [#30064](https://github.com/dotnet/aspnetcore/issues/30064), please null out the reference of streams and other instances when they are no longer required. Using this approach you'll observe the memory go down and become stable.

## Opening a document from Cloud

You can open the Word documents from Cloud storage.
The following code example shows how to open and load the Word document file stored in Azure Blob Storage.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@using System.IO
@using Microsoft.Azure.Storage
@using Microsoft.Azure.Storage.Blob
@using Newtonsoft.Json

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    string sfdtString;

    protected override void OnInitialized()
    {
        //Connection string of storage account
        string connectionString = "Here Place Your Connection string";
        //Container name
        string containerName = "document";
        //File name to be loaded into Syncfusion Document Editor
        string fileName = "Getting_Started.docx";
        CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
        CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
        MemoryStream memoryStream = new MemoryStream();
        cloudBlockBlob.DownloadToStream(memoryStream);
        WordDocument document = WordDocument.Load(memoryStream, ImportFormatType.Docx);
        memoryStream.Dispose();
        //To observe the memory go down, null out the reference of memoryStream variable.
        memoryStream = null;
        sfdtString = JsonConvert.SerializeObject(document);
        document.Dispose();
        //To observe the memory go down, null out the reference of document variable.
        document = null;
    }
    public void OnLoad(object args)
    {
        SfDocumentEditor editor = container.DocumentEditor;
        editor.Open(sfdtString);
        //To observe the memory go down, null out the reference of sfdtString variable.
        sfdtString = null;
    }
}
```

>Note: The **Microsoft.Azure.Storage.Blob** NuGet package must be installed in your application to use the previous code example.

You can open the Word documents from Azure File Storage using the following code example.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@using System.IO
@using Microsoft.Azure.Storage
@using Microsoft.Azure.Storage.File
@using Newtonsoft.Json

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    string sfdtString;

    protected override void OnInitialized()
    {
        //Connection string of storage account
        string connectionString = "Here Place Your Connection string";
        //Container name
        string shareReference = "document";
        //String directoryReference = "document";
        //File name to be loaded into Syncfusion Document Editor
        string fileReference = "Getting_Started.docx";
        CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
        CloudFileClient fileClient = cloudStorageAccount.CreateCloudFileClient();
        //Get file share
        CloudFileShare cloudFileShare = fileClient.GetShareReference(shareReference);
        if (cloudFileShare.Exists())
        {
            //Get the related directory
            CloudFileDirectory dir = cloudFileShare.GetRootDirectoryReference();
            if (dir.Exists())
            {
                //Get the file reference
                CloudFile file = dir.GetFileReference(fileReference);
                MemoryStream memoryStream = new MemoryStream();
                //Download file to local disk
                file.DownloadToStream(memoryStream);
                WordDocument document = WordDocument.Load(memoryStream, ImportFormatType.Docx);
                memoryStream.Dispose();
                //To observe the memory go down, null out the reference of memoryStream variable.
                memoryStream = null;
                sfdtString = JsonConvert.SerializeObject(document);
                document.Dispose();
                //To observe the memory go down, null out the reference of document variable.
                document = null;
            }
        }
    }
    public void OnLoad(object args)
    {
        if (!String.IsNullOrEmpty(sfdtString))
        {
            SfDocumentEditor editor = container.DocumentEditor;
            editor.Open(sfdtString);
            //To observe the memory go down, null out the reference of sfdtString variable.
            sfdtString = null;
        }
    }
}
```

>Note: The **Microsoft.Azure.Storage.File** NuGet package must be installed in your application to use the previous code example.

## Opening a document from database

The following code example shows how to open the Word document file in viewer from SQL Server database.

```csharp
@using System.IO;
@using Syncfusion.Blazor.DocumentEditor
@using System.Data.SqlClient
@using Newtonsoft.Json

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    public void OnLoad(object args)
    {
        string documentID = "GettingStarted.docx";
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database.mdf;";
        SqlConnection connection = new SqlConnection(connectionString);
        //Searches for the Word document from the database
        string query = "select Data from DocumentsTable where DocumentName = '" + documentID + "'";
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        SqlDataReader read = command.ExecuteReader();
        read.Read();
        //Reads the Word document data as byte array from the database
        byte[] byteArray = (byte[])read["Data"];
        Stream stream = new MemoryStream(byteArray);
        //To observe the memory go down, null out the reference of byteArray variable.
        byteArray = null;
        WordDocument document = WordDocument.Load(stream, ImportFormatType.Docx);
        stream.Dispose();
        //To observe the memory go down, null out the reference of stream variable.
        stream = null;
        string json = JsonConvert.SerializeObject(document);
        document.Dispose();
        //To observe the memory go down, null out the reference of document variable.
        document = null;
        SfDocumentEditor editor = container.DocumentEditor;
        editor.Open(json);
        //To observe the memory go down, null out the reference of json variable.
        json = null;
    }
}

```

>Note: The **System.Data.SqlClient** package must be installed in your application to use the previous code example. You need to modify the connectionString and query variable in the previous code example as per the connection string of your database.

## Opening a document from file system

There is an UI option in built-in toolbar to open the Word documents from local file system. If you want to achieve the same functionality when design your own toolbar, you can use the following code example to load and open the Word documents. In this sample, the Syncfusion’s Uploader control is used for Blazor.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@using Syncfusion.Blazor.Inputs
@using System.IO
@using Newtonsoft.Json

<SfUploader>
    <UploaderEvents OnUploadStart="OnSuccess"></UploaderEvents>
    <UploaderAsyncSettings SaveUrl="https://aspnetmvc.syncfusion.com/services/api/uploadbox/Save" RemoveUrl="https://aspnetmvc.syncfusion.com/services/api/uploadbox/Remove"></UploaderAsyncSettings>
</SfUploader>
<SfDocumentEditorContainer @ref="container" EnableToolbar=false></SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    public void OnSuccess(UploadingEventArgs action)
    {
        string base64 = action.FileData.RawFile.ToString();
        string fileName = action.FileData.Name;
        string data = base64.Split(',')[1];
        byte[] bytes = Convert.FromBase64String(data);
        using (Stream stream = new MemoryStream(bytes))
        {
            WordDocument document = WordDocument.Load(stream, ImportFormatType.Docx);
            string sfdtString = JsonConvert.SerializeObject(document);
            document.Dispose();
            //To observe the memory go down, null out the reference of document variable.
            document = null;
            SfDocumentEditor editor = container.DocumentEditor;
            editor.Open(sfdtString);
            //To observe the memory go down, null out the reference of sfdtString variable.
            sfdtString = null;
        }
        action.Cancel = true;
    }
}

```

## Opening a document on control initialization

The Word document can be opened on control initialization, in this sample, the document is opened when the control is initialized.

```csharp
@using System.IO
@using Syncfusion.Blazor.DocumentEditor
@using Newtonsoft.Json

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    public void OnLoad(object args)
    {
        string filePath = "wwwroot/data/GettingStarted.docx";
        using (FileStream fileStream = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            WordDocument document = WordDocument.Load(fileStream, ImportFormatType.Docx);
            string json = JsonConvert.SerializeObject(document);
            document.Dispose();
            //To observe the memory go down, null out the reference of document variable.
            document = null;
            SfDocumentEditor editor = container.DocumentEditor;
            editor.Open(json);
            //To observe the memory go down, null out the reference of json variable.
            json = null;
        }
    }
}
```

You can also explore our [`Blazor Word Processor`](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.