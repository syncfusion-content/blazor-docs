---
layout: post
title: Update the Viewer size to its container in SfPdfViewer | Syncfusion
description: Learn here all about how to stretch the SfPdfViewer size to its container in Syncfusion Blazor SfPdfViewer component.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Update the viewer size at run-time in Blazor SfPdfViewer Component

You can stretch the SfPdfViewer size to its container size while resizing the container at runtime. The following code snippet explains how to update the SfPdfViewer size while resizing the Splitter at runtime. In this example, the Syncfusion’s Splitter component is used.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Layouts

<!--This splitter layout holds two panes-->
<SfSplitter Height="100%" Width="100%">
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

                <!--Build the SfPdfViewer inside a splitter pane-->
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

    //Sets the document path for initial loading.
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    //This method will get invoked when the splitter is resized.
    private async void onresize()
    {
        //This method will update the SfPdfViewer size when the container size is updated at runtime.
        await viewer.UpdateViewerContainerAsync();
    }
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Resize%20the%20PDF%20Viewer%20to%20its%20parent%20element).