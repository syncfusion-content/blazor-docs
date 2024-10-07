---
layout: post
title: Check the status of annotations in Blazor SfPdfViewer | Syncfusion
description: Learn here all about how to check the status of annotations or comments in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Check the status of annotations or comments in Blazor SfPdfViewer

The Syncfusion's Blazor SfPdfViewer component allows to check the status of the annotations in the SfPdfViewer using the [Review](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.Review.html) property of the [PdfAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfAnnotation.html) class.

The following code example shows the review status of the annotation.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime JsRuntime;

<SfButton OnClick="reviewStatus">Review Status</SfButton>
<SfPdfViewer2 @ref="pdfviewer"
              CommentPanelVisible="true"
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%"></SfPdfViewer2>

@code{
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    SfPdfViewer2 pdfviewer;    

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
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Comment%20Panel/Retrieve%20the%20comment%20status).

## See also

* [Free text annotations in Blazor SfPdfViewer Component](../annotation/free-text-annotation)

* [Ink Annotation in the Blazor SfPdfViewer component](../annotation/ink-annotation)

* [Stamp annotations in Blazor SfPdfViewer Component](../annotation/stamp-annotation)

* [Comments in Blazor SfPdfViewer Component](../annotation/comments)