---
layout: post
title: Saving PDF file in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about saving PDF file in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

N> Syncfusion recommends using [Blazor PDF Viewer (NextGen)](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) Component which provides fast rendering of pages and improved performance. Also, there is no need of external Web service for processing the files and ease out the deployment complexity. It can be used in Blazor Server, WASM and MAUI applications without any changes.

# Saving PDF file in Blazor PDF Viewer Component

After editing the PDF file with various annotation tools, you will need to save the updated PDF to the server, database, or local file system.

## Save PDF file to Server

You might need to save the PDF file back to the server.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons
@using System.IO

<SfButton OnClick="OnClick">Save</SfButton>
<SfPdfViewerServer DocumentPath="@DocumentPath" @ref="viewer" Width="1060px" Height="500px"></SfPdfViewerServer>

@code{  
    SfPdfViewerServer viewer;
    public async void OnClick(MouseEventArgs args)
    {
        byte[] data = await viewer.GetDocument();
        //PDF document file stream
        Stream stream = new MemoryStream(data);
        using (var fileStream = new FileStream(@"wwwroot/Data/PDF_Succinctly_Updated.pdf", FileMode.Create, FileAccess.Write))
        {
            //Saving the new file in root path of application
            stream.CopyTo(fileStream);
            fileStream.Close();
        }
        stream.Close();
    }
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```

## Save PDF file to Database

If you have plenty of PDF files stored in database and you want to save the updated PDF file back to the database, use the following code example.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons
@using System.Data.SqlClient

<SfButton OnClick="OnClick">Save</SfButton>
<SfPdfViewerServer DocumentPath="@DocumentPath" @ref="viewer" Width="1060px" Height="500px">
</SfPdfViewerServer>

@code{
    SfPdfViewerServer viewer;

    public async void OnClick(MouseEventArgs args)
    {
        string DocumentName = "PDF_Succinctly";
        byte[] data = await viewer.GetDocument();
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\database.mdf;";
        string queryStmt = "Update PDFFiles SET Content = @Content where DocumentName = '" + DocumentName + "'";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(queryStmt, con))
            {
                SqlParameter param = cmd.Parameters.Add("@Content", System.Data.SqlDbType.VarBinary);
                param.Value = data;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```

## Download PDF file as a copy

In the built-in toolbar, you have an option to download the updated PDF to the local file system, you can use it to download the PDF file.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewerServer

<SfButton @onclick="OnClick">Download</SfButton>
<SfPdfViewerServer @ref="@viewer" Height="500px" Width="1060px" DocumentPath="@DocumentPath" />

@code{
SfPdfViewerServer viewer;
public void OnClick(MouseEventArgs args)
{
    viewer.Download();
}
public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}
```

N> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap5) to understand how to explain core features of PDF Viewer.