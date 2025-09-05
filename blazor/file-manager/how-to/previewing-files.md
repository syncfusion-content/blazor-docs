---
layout: post
title: Previewing Files in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about previewing files in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Previewing files in Blazor File Manager component

In the Blazor File Manager component, you can preview PDF files using the [PDF Viewer](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-app) component, docx files using the [DocumentEditor](https://blazor.syncfusion.com/documentation/document-editor/getting-started/web-app) component, and play videos within the [Dialog](https://blazor.syncfusion.com/documentation/dialog/getting-started-with-web-app) component.

## Previewing PDF and Word File in Dialog

In the Blazor File Manager component, you can view PDF files using the [PDF Viewer](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-app) component and docx files using the DocumentEditor component by setting the proper file path in these components.

The following example demonstrates how to preview PDF and docx files by utilizing the [PDF Viewer](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-app) and [DocumentEditor](https://blazor.syncfusion.com/documentation/document-editor/getting-started/web-app) components within the [Dialog](https://blazor.syncfusion.com/documentation/dialog/getting-started-with-web-app) component.

```cshtml

@using Syncfusion.Blazor.FileManager
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.DocumentEditor

<div class="controlregion">
    <SfFileManager TValue="FileManagerDirectoryContent" ShowThumbnail="true" AllowMultiSelection="false">
        <FileManagerAjaxSettings Url="/api/FileManager/FileOperations"
                                 UploadUrl="/api/FileManager/Upload"
                                 DownloadUrl="/api/FileManager/Download"
                                 GetImageUrl="/api/FileManager/GetImage">
        </FileManagerAjaxSettings>
        <FileManagerEvents TValue="FileManagerDirectoryContent" OnFileOpen="OpenFilePreview"></FileManagerEvents>
    </SfFileManager>

    <SfDialog Width="100%" Height="100%" EnableResize="true" AllowDragging="true" ShowCloseIcon="true" AllowPrerender="true" Visible="@IsDialogVisible">
        <DialogTemplates>
            <Header> @DialogTitle </Header>
            <Content>
                <div style="display:@PdfVisible">
                    <SfPdfViewerServer DocumentPath="@DocumentPath" Height="500px" Width="1060px"></SfPdfViewerServer>
                </div>
                <div style="display:@DocVisible">
                    <SfDocumentEditorContainer @ref="documentEditorContainer" EnableToolbar="true">
                    </SfDocumentEditorContainer>
                </div>
                @DialogContent
            </Content>
        </DialogTemplates>
        <DialogEvents Opened="@DialogOpenedHandler"></DialogEvents>
    </SfDialog>
</div>
@code
{
    private string DocumentPath { get; set; } = string.Empty;
    private bool IsDialogVisible { get; set; } = false;
    private string PdfVisible { get; set; } = "none";
    private string DocVisible { get; set; } = "none";
    private string DialogTitle { get; set; } = "Preview a File";
    private string DialogContent { get; set; } = string.Empty;
    SfDocumentEditorContainer? documentEditorContainer;

    private void OpenFilePreview(FileOpenEventArgs<FileManagerDirectoryContent> args)
    {
        if (!string.IsNullOrEmpty(args.FileDetails.Type))
            this.IsDialogVisible = true;
        else
            this.IsDialogVisible = false;
        if (args.FileDetails.Type == ".pdf")
        {
            DialogTitle = "Preview PDF file : " + args.FileDetails.Name;
            PdfVisible = "block";
            DocVisible = "none";
            DialogContent = string.Empty;
            DocumentPath = "wwwroot\\Files" + args.FileDetails.FilterPath + args.FileDetails.Name;
        }
        else if (args.FileDetails.Type == ".docx")
        {
            DialogTitle = "Preview Word file : " + args.FileDetails.Name;
            DocVisible = "block";
            PdfVisible = "none";
            DialogContent = string.Empty;
            this.OpenDocumentEditor("wwwroot\\Files" + args.FileDetails.FilterPath + args.FileDetails.Name);
        }
        else
        {
            DocumentPath = string.Empty;
            PdfVisible = "none";
            DocVisible = "none";
            DialogTitle = "Preview is unavailable";
            DialogContent = "Preview is unavailable or not handled for this file type (" + args.FileDetails.Type + ")";
        }
    }

    public void OpenDocumentEditor(string filePath)
    {
        if (documentEditorContainer != null)
        {
            using (FileStream fileStream = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                WordDocument document = WordDocument.Load(fileStream, ImportFormatType.Docx);
                string json = JsonSerializer.Serialize(document);
                document.Dispose();
                //To observe the memory go down, null out the reference of document variable.
                document = null;
                //editor = documentEditorContainer.DocumentEditor;
                documentEditorContainer.DocumentEditor.OpenAsync(json);
                //To observe the memory go down, null out the reference of json variable.
                json = null;
            }
        }
    }

    public async void DialogOpenedHandler(OpenEventArgs args)
    {
        if (DocVisible == "block" && documentEditorContainer != null)
            await documentEditorContainer.ResizeAsync();
    }
}

```

N> The fully working sample can be found [here](https://github.com/SyncfusionExamples/Blazor-FileManager-Word-PDF). Also, refer to this [KB](https://www.syncfusion.com/blogs/post/preview-file-blazor-file-manager) to know more about Preview Files in Blazor File Manager.