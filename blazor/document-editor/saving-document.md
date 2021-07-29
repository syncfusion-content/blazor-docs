---
layout: post
title: Saving document in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about Saving document in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Saving document in Blazor DocumentEditor Component

After composing or editing the document, you will need to save the document to the server, database, or local file system.

## Save document to server

You might need to save the document back to the server. The following code example shows how to save the composed document to server.

```cshtml
@using Syncfusion.Blazor.DocumentEditor
@using  System.IO

<button @onclick="OnSave">Save</button>

<SfDocumentEditorContainer @ref="container" EnableToolbar=true></SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    public async void OnSave()
    {
        SfDocumentEditor editor = container.DocumentEditor;
        string base64Data = await editor.SaveAsBlob(FormatType.Docx);
        byte[] data = Convert.FromBase64String(base64Data);
        //To observe the memory go down, null out the reference of base64Data variable.
        base64Data = null;
        //Word document file stream
        Stream stream = new MemoryStream(data);
        //To observe the memory go down, null out the reference of data variable.
        data = null;
        using (var fileStream = new FileStream(@"wwwroot\data\GettingStarted.docx", FileMode.Create, FileAccess.Write))
        {
            //Saving the new file in root path of application
            stream.CopyTo(fileStream);
            fileStream.Close();
        }
        stream.Close();
        //To observe the memory go down, null out the reference of stream variable.
        stream = null;
    }
}

```

## Save document to database

If you have plenty of documents stored in database and you want to save the composed or updated document back to the database, use the following code example.

```cshtml
@using Syncfusion.Blazor.DocumentEditor
@using System.Data.SqlClient

<button @onclick="OnSave">Save</button>

<SfDocumentEditorContainer @ref="container" EnableToolbar="true"></SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    public async void OnSave()
    {
        string documentID = "Getting_Started.docx";
        SfDocumentEditor editor = container.DocumentEditor;
        string base64Data = await editor.SaveAsBlob(FormatType.Docx);
        byte[] data = Convert.FromBase64String(base64Data);
        //To observe the memory go down, null out the reference of base64Data variable.
        base64Data = null;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database.mdf;";
        string queryStmt = "Update DocumentsTable SET Data = @Content where DocumentName = '" + documentID + "'";
        using (SqlConnection con = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(queryStmt, con))
        {
            SqlParameter param = cmd.Parameters.Add("@Content", System.Data.SqlDbType.VarBinary);
            param.Value = data;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //To observe the memory go down, null out the reference of data variable.
            data = null;
        }
    }
}
```

## Download document as a copy

You can also save or download the document in local file system.

```cshtml
@using Syncfusion.Blazor.DocumentEditor

<button @onclick="OnDownload">Download</button>

<SfDocumentEditorContainer @ref="container" EnableToolbar="true"></SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    public void OnDownload()
    {
        SfDocumentEditor editor = container.DocumentEditor;
        editor.Save("sample", FormatType.Docx);
    }
}
``` }
}
```