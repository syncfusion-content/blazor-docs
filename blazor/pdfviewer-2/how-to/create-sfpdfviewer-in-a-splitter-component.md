---
layout: post
title: Create SfPdfViewer in a Splitter Component in Blazor | Syncfusion
description: Learn here all about how to create SfPdfViewer in a Splitter Component in Syncfusion Blazor SfPdfViewer component.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Create SfPdfViewer Component in a Splitter Component in Blazor

You can use Splitter to render the SfPdfViewer while rendering more than one component. The following code snippet explains how to render the SfPdfViewer component inside a Splitter pane. In this example, the Syncfusion’s Splitter component is used to render SfPdfViewer.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Layouts

<!--This splitter layout holds two panes-->
<SfSplitter Height="100%" Width="100%">
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
                <SfPdfViewer2 @ref="@viewer"
                              DocumentPath="@DocumentPath">
                </SfPdfViewer2>

            </ContentTemplate>
        </SplitterPane>

    </SplitterPanes>
</SfSplitter>

@code
{
    SfPdfViewer2 viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Render%20the%20PDF%20Viewer%20on%20Splitter).