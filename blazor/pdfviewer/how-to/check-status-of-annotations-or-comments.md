---
layout: post
title: Check the status of annotations in Blazor PDF Viewer | Syncfusion
description: Learn here all about how to check the status of annotations or comments in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Check the status of annotations in Blazor PDF Viewer Component

The Syncfusion's Blazor PDF Viewer component allows to check the status of the annotations in the PDF viewer using the [Review](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PdfViewer.Review.html) property of the [PdfAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PdfViewer.PdfAnnotation.html) class.

The following code example shows the review status of the annotation.

```cshtml
@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime JsRuntime;

<SfButton OnClick="reviewStatus">Review Status</SfButton>
<SfPdfViewerServer @ref="pdfviewer" CommentPanelVisible="true" DocumentPath="@DocumentPath" Height="500px" Width="1060px" ></SfPdfViewerServer>

@code{
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    SfPdfViewerServer pdfviewer;    

    //Prints the comment status of the PDF document in console.
    public async void reviewStatus()
    {
        //Gets the annotation collection.
        List<PdfAnnotation> annotationCollection = await pdfviewer.GetAnnotationsAsync();
        for (var x = 0; x < annotationCollection.Count; x++)
        {
            PdfAnnotation annotation = annotationCollection[x];
            //Gets the review status details of the comment.
            Review review = annotation.Review;
            var reviewState = review.State;
            var reviewStateModel = review.StateModel;
            await this.JsRuntime.InvokeVoidAsync("console.log",reviewState.ToString());
        }
    }
}
```
N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Annotations/Comment%20Panel/Retrieve%20the%20comment%20status).
