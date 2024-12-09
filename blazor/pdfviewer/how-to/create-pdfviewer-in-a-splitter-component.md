---
layout: post
title: Create PDF Viewer in a Splitter Component in Blazor | Syncfusion
description: Learn here all about how to create PDF Viewer in a Splitter Component in Syncfusion Blazor PDF Viewer component.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Create PDF Viewer in Splitter Component in Blazor PDF Viewer Component

You can use Splitter to render the PDF Viewer while rendering more than one component. The following code snippet explains how to render the PDF Viewer component inside a Splitter pane. In this example, the Syncfusion’s Splitter component is used to render PDF Viewer.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Layouts

<!--This splitter layout holds two panes-->
<SfSplitter Height="640px" Width="100%">    
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
}
```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Common/Render%20the%20PDF%20Viewer%20on%20Splitter).

N> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.