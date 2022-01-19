---
layout: post
title: Toolbar Customization in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about toolbar customization in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Toolbar Customization in Blazor PDF Viewer Component

The PDF Viewer comes with a powerful built-in toolbar with the following important options,
* Open PDF file
* Page navigation
* Magnification
* Pan tool
* Text selection tool
* Text search
* Print
* Download
* Undo and redo
* Various annotation tools
* Bookmark panel
* Thumbnail panel

![Blazor PDFViewer with Custom Toolbar](./images/blazor-pdfviewer-custom-toolbar.png)

## Show or hide toolbar

At times, you might need to create your own toolbar. In that case, you need to hide the built-in toolbar. For that customization purpose, the PDF Viewer control provides an option to show or hide the main (top) toolbar either by using the `EnableToolbar` property or `ShowToolbar` method.

The following code snippet explains how to show or hide toolbar using the EnableToolbar property.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer EnableToolbar="false" Width="1060px" Height="500px">
</SfPdfViewerServer>
```

The following code snippet explains how to show or hide toolbar using the ShowToolbar method.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewerServer

<SfButton @onclick="OnClick">Hide Toolbar</SfButton>
<SfPdfViewerServer Width="1060px" Height="500px" @ref="@pdfViewer" DocumentPath="@DocumentPath">
</SfPdfViewerServer>

@code{

   SfPdfViewerServer pdfViewer;
   public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public void OnClick(MouseEventArgs args)
    {
        pdfViewer.ShowToolbar(false);
    }
}
```

## Show or hide navigation toolbar

Navigation toolbar is the side bar, which contains the options to expand and collapse the bookmark panel and page thumbnail panel. This navigation toolbar visibility can be toggled either by using the `EnableNavigationToolbar` property or `ShowNavigationToolbar` method.

The following code snippet explains how to show or hide navigation toolbar using the EnableNavigationToolbar property.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer EnableNavigationToolbar="false" Width="1060px" Height="500px">
</SfPdfViewerServer>
```

The following code snippet explains how to show or hide navigation toolbar using the ShowNavigationToolbar method.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewerServer

<SfButton @onclick="OnClick">Hide Navigation Toolbar</SfButton>
<SfPdfViewerServer EnableNavigationToolbar="true" Width="1060px" Height="500px" @ref="@pdfViewer" DocumentPath="@DocumentPath">
</SfPdfViewerServer>

@code{

    SfPdfViewerServer pdfViewer;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public void OnClick(MouseEventArgs args)
    {
        pdfViewer.ShowNavigationToolbar(false);
    }
}
```

## Show or hide the toolbar item

You can show or hide the toolbar items using the “PdfViewerToolbarSettings” class. The following code snippet explains how to show only the desired options in the toolbar. The resultant PDF Viewer’s toolbar will have these options - Open file, magnification tools, comment tool, and download option.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.PdfViewer

<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" ToolbarSettings="@ToolbarSettings">
</SfPdfViewerServer>

@code{

    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

       public PdfViewerToolbarSettings ToolbarSettings = new PdfViewerToolbarSettings() {
        ToolbarItems = new List<ToolbarItem>()
           {
                ToolbarItem.PageNavigationTool,
                ToolbarItem.MagnificationTool,
                ToolbarItem.CommentTool,
                ToolbarItem.SelectionTool,
                ToolbarItem.PanTool,
                ToolbarItem.UndoRedoTool,
                ToolbarItem.CommentTool,
                ToolbarItem.AnnotationEditTool,
                ToolbarItem.SearchOption,
                ToolbarItem.PrintOption,
                ToolbarItem.DownloadOption
            }
    };
}
```

> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explain core features of PDF Viewer.