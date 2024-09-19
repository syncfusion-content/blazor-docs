---
layout: post
title: Add and Delete Annotation Collection in a PDF Viewer | Syncfusion
description: Learn here all about add and delete multiple annotations at once in Blazor application in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Add and Delete multiple annotations at once in a PDF Viewer

The PDF Viewer provides support to add and delete multiple annotations at once. we can programmatically create a collection of annotations, such as lines or shapes, and apply them to the document in one go using [AddAnnotationsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_AddAnnotationsAsync_System_Collections_Generic_List_Syncfusion_Blazor_SfPdfViewer_PdfAnnotation__). Similarly, the viewer allows you to retrieve and remove all annotations from the document efficiently using [DeleteAnnotationsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_DeleteAnnotationsAsync_System_Collections_Generic_List_Syncfusion_Blazor_SfPdfViewer_PdfAnnotation__). This capability is particularly useful for bulk annotation management within a Blazor application.


The following code demonstrates how to add multiple annotations at once to PDF Viewer.

```cshtml

<SfButton OnClick="AddAnnotations">AddAnnotations</SfButton>
<SfPdfViewer2 @ref="Viewer" 
              DocumentPath="https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf"
              Height="100%"
              Width="100%">
</SfPdfViewer2>
 

@code {
    SfPdfViewer2 Viewer;
    
    public async void AddAnnotations() 
    {
        List < PdfAnnotation > annotations = new List < PdfAnnotation > ();

        PdfAnnotation annotation1 = new PdfAnnotation();
        annotation1.Type = AnnotationType.Line;
        annotation1.VertexPoints = new List <VertexPoint>() 
        {
            new VertexPoint() 
            {
                X = 200,
                Y = 230
            },
            new VertexPoint() 
            {
                X = 350,
                Y = 230
            }
        };
        annotation1.PageNumber = 0;
        annotations.Add(annotation1);

        PdfAnnotation annotation2 = new PdfAnnotation();
        annotation2.Type = AnnotationType.Circle;
        annotation2.Bound = new Bound() 
        {
            X = 200,
            Y = 300,
            Width = 90,
            Height = 90
        };
        annotation2.PageNumber = 0;
        annotations.Add(annotation2);

        // Add multiple annotations at once
        await Viewer.AddAnnotationsAsync(annotations);
    }
}
    
```

The following code demonstrates how to delete multiple annotations at once in PDF Viewer.

```cshtml

<SfButton OnClick="DeleteAnnotations">DeleteAnnotations</SfButton>
<SfPdfViewer2 @ref="Viewer" 
              DocumentPath="https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code {
    SfPdfViewer2 Viewer;
    
    public async void DeleteAnnotations()
    {
        List<PdfAnnotation> annotationCollection = await Viewer.GetAnnotationsAsync();
        // Delete multiple annotations at once
        await Viewer.DeleteAnnotationsAsync(annotationCollection);
    }
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Add%20and%20Delete%20Annotations).
