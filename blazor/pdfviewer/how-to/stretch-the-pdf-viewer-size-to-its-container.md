---
layout: post
title: Update the PDF Viewer size to its container in PDF Viewer | Syncfusion
description: Learn here all about how to stretch the PDF Viewer size to its container in Syncfusion Blazor PDF Viewer component.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Update PDF Viewer size at run-time in Blazor PDF Viewer Component

You can stretch the PDF Viewer size to its container size while resizing the container at runtime. The following code snippet explains how to update the PDF Viewer size while resizing the Splitter at runtime. In this example, the Syncfusion’s Splitter component is used.

```cshtml
@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Layouts

<!--This splitter layout holds two panes-->
<SfSplitter Height="640px" Width="100%">
    <SplitterEvents Resizing="@onresize"></SplitterEvents>
    <!--Configures one or more panes to construct different layouts-->
    <SplitterPanes>
        <SplitterPane Size="200px">
            <ContentTemplate>
                <div> Left pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Size="200px">
            <ContentTemplate>
                <!--Build the PDF Viewer inside a splitter pane-->
                <SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath">                   
                </SfPdfViewerServer>
            </ContentTemplate>
        </SplitterPane>
    </SplitterPanes>
</SfSplitter>

@code{

    SfPdfViewerServer viewer;
    
    //Sets the document path for initial loading.
    private string DocumentPath { get; set; } = "wwwroot/data/PDF Succinctly.pdf";

    //This method will get invoked when the splitter is resized.
    private void onresize()
    {
        //This method will update the PDF Viewer size when the container size is updated at runtime.
        viewer.UpdateViewerContainerAsync();
    }

}
```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Common/Resize%20the%20PDF%20Viewer%20to%20its%20parent%20element).

N> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.