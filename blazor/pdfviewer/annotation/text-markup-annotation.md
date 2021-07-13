# Text Markup annotation

The PDF Viewer control provides the options to add, edit, and delete text markup annotations such as highlight, underline, and strikethrough annotations in the PDF document.

![TextMarkupAnnotation](../../pdfviewer/images/text_markup_annotation.png)

## Adding text markup annotation to the PDF Document

Text Markup annotations can be added to the PDF document using the annotation toolbar and by using context menu.

## Highlight a text

There are two ways to highlight a text in the PDF document.
1. Using the context menu.
    * Select a text in the PDF document and right-click it
    * Select **Highlight** option in the context menu that appears

![HighlightContext](../../pdfviewer/images/highlight_context.png)
2. Using the annotation toolbar.
    * Click the **Edit Annotation** button in the PDF Viewer toolbar.  A toolbar appears below it.
    * Select the **Highlight** button in the annotation toolbar. It enables the highlight mode.
    * Select the text and the highlight annotation will be added.
    * You can also select the text and apply the highlight annotation using the **Highlight** button

![HighlightText](../../pdfviewer/images/highlight_text.png)

In the pan mode, if the highlight mode is entered, the PDF Viewer control will switch to text select mode to enable the text selection for highlighting the text.

Refer to the following code snippet to switch to highlight mode

```csharp
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewer

<SfButton OnClick="OnClick">Click Here</SfButton>
<SfPdfViewerServer DocumentPath="@DocumentPath" @ref="viewer" Width="1060px" Height="500px">
</SfPdfViewerServer>

@code{
    SfPdfViewerServer viewer;

    public void OnClick(MouseEventArgs args)
    {
        viewer.SetAnnotationMode(AnnotationType.Highlight);
    }
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```

## Underline a text

There are two ways to underline a text in the PDF document:
1. Using the context menu.
    * Select a text in the PDF document and right-click it
    * Select **Underline** option in the context menu that appears.

![UnderlineContext](../../pdfviewer/images/underline_context.png)
2. Using the annotation toolbar.
    * Click the **Edit Annotation** button in the PDF Viewer toolbar.  A toolbar appears below it.
    * Select the **Underline** button in the annotation toolbar. It enables the underline mode.
    * Select the text and the underline annotation will be added.
    * You can also select the text and apply the underline annotation using the **Underline** button

![UnderlineText](../../pdfviewer/images/underline_text.png)

In the pan mode, if the underline mode is entered, the PDF Viewer control will switch to text select mode to enable the text selection for underlining the text.

Refer to the following code snippet to switch to underline mode

```csharp
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewer

<SfButton OnClick="OnClick">Click Here</SfButton>
<SfPdfViewerServer DocumentPath="@DocumentPath" @ref="viewer" Width="1060px" Height="500px">
</SfPdfViewerServer>

@code{
    SfPdfViewerServer viewer;

    public void OnClick(MouseEventArgs args)
    {
        viewer.SetAnnotationMode(AnnotationType.Underline);
    }
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```

## Strikethrough a text

There are two ways to strikethrough a text in the PDF document:
1. Using the context menu.
    * Select a text in the PDF document and right-click it
    * Select **strikethrough** option in the context menu that appears.

![StrikeThrough](../../pdfviewer/images/strikethrough_context.png)
2. Using the annotation toolbar.
    * Click the **Edit Annotation** button in the PDF Viewer toolbar.  A toolbar appears below it.
    * Select the **Strikethrough** button in the annotation toolbar. It enables the strikethrough mode.
    * Select the text and the strikethrough annotation will be added.
    * You can also select the text and apply the strikethrough annotation using the **Strikethrough** button

![StrikeThroughText](../../pdfviewer/images/strike_through.png)

In the pan mode, if the strikethrough mode is entered, the PDF Viewer control will switch to text select mode to enable the text selection to strike through the text.

Refer to the following code snippet to switch to strikethrough mode

```csharp
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewer

<SfButton OnClick="OnClick">Click Here</SfButton>
<SfPdfViewerServer DocumentPath="@DocumentPath" @ref="viewer" Width="1060px" Height="500px">
</SfPdfViewerServer>

@code{
    SfPdfViewerServer viewer;

    public void OnClick(MouseEventArgs args)
    {
        viewer.SetAnnotationMode(AnnotationType.Strikethrough);
    }
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```

## Editing the properties of the text markup annotation

The color and the opacity of the text markup annotation can be edited using the Edit Color tool and the Edit Opacity tool in the annotation toolbar.

### Editing color

The color of the annotation can be edited using the color palette provided in the Edit Color tool.

![TextMarkupEditColor](../../pdfviewer/images/textmarkup_editcolor.png)

### Editing opacity

The opacity of the annotation can be edited using the range slider provided in the Edit Opacity tool.

![TextMarkupEditOpacity](../../pdfviewer/images/textmarup_editopacity.png)

## Text markup annotation settings

The properties of the text markup annotation can be set before creating the control using highlightSettings, underlineSettings, and strikethroughSettings.

>After editing the default color and opacity using the Edit color tool and Edit opacity tool, they will be changed to the selected values.

Refer to the following code snippet to set the default annotation settings.

```csharp
@using Syncfusion.Blazor
@using Syncfusion.Blazor.PdfViewerServer
<SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath" HighlightSettings="@HighlightSettings" UnderlineSettings="@UnderlineSettings" StrikethroughSettings="@StrikethroughSettings">
</SfPdfViewerServer>
@code{
    SfPdfViewerServer viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    PdfViewerHighlightSettings HighlightSettings = new PdfViewerHighlightSettings { Color = "green", Opacity = 0.6 };
    PdfViewerUnderlineSettings UnderlineSettings = new PdfViewerUnderlineSettings { Color = "blue", Opacity = 0.6 };
    PdfViewerStrikethroughSettings StrikethroughSettings = new PdfViewerStrikethroughSettings { Color = "orange", Opacity = 0.6 };
}
```