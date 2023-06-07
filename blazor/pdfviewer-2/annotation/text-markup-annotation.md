---
layout: post
title: Text markup annotations in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about text markup annotations in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Text markup annotations in Blazor SfPdfViewer Component

The SfPdfViewer control provides the options to add, edit, and delete text markup annotations such as highlight, underline, and strikethrough annotations in the PDF document.

![Blazor SfPdfViewer with Text Markup Annotation](../../pdfviewer/images/blazor-pdfviewer-text-markup-annotation.png)

## Adding text markup annotation to the PDF Document

Text Markup annotations can be added to the PDF document using the annotation toolbar and by using context menu.

## Highlight a text

There are two ways to highlight a text in the PDF document.

**Using the context menu.**

* Select a text in the PDF document and right-click it.

* Select **Highlight** option in the context menu that appears

![Highlighting Context in Blazor SfPdfViewer](../../pdfviewer/images/blazor-pdfviewer-highlight-context.png)

**Using the annotation toolbar.**

* Click the **Edit Annotation** button in the SfPdfViewer toolbar. A toolbar appears below it.

* Select the **Highlight** button in the annotation toolbar. It enables the highlight mode.

* Select the text and the highlight annotation will be added.

* You can also select the text and apply the highlight annotation using the **Highlight** button.

![Highlighting Text in Blazor SfPdfViewer](../../pdfviewer/images/blazor-pdfviewer-highlight-text.png)

In the pan mode, if the highlight mode is entered, the SfPdfViewer control will switch to text select mode to enable the text selection for highlighting the text.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnClick">Highlight</SfButton>
<SfPdfViewer2 DocumentPath="@DocumentPath" @ref="viewer" Width="100%" Height="100%">
</SfPdfViewer2>

@code {
    SfPdfViewer2 viewer;

    public void OnClick(MouseEventArgs args)
    {
        viewer.SetAnnotationMode(AnnotationType.Highlight);
    }
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

## Underline a text

There are two ways to underline a text in the PDF document.

**Using the context menu.**

* Select a text in the PDF document and right-click it.

* Select **Underline** option in the context menu that appears.

![Displaying Underline in Blazor SfPdfViewer ContextMenu](../../pdfviewer/images/blazor-pdfviewer-underline-context-menu.png)

**Using the annotation toolbar.**

* Click the **Edit Annotation** button in the SfPdfViewer toolbar. A toolbar appears below it.

* Select the **Underline** button in the annotation toolbar. It enables the underline mode.

* Select the text and the underline annotation will be added.

* You can also select the text and apply the underline annotation using the **Underline** button.

![Blazor SfPdfViewer with Underline Text](../../pdfviewer/images/blazor-pdfviewer-underline-text.png)

In the pan mode, if the underline mode is entered, the SfPdfViewer control will switch to text select mode to enable the text selection for underlining the text.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnClick">Underline</SfButton>
<SfPdfViewer2 DocumentPath="@DocumentPath" @ref="viewer" Width="100%" Height="100%">
</SfPdfViewer2>

@code {
    SfPdfViewer2 viewer;

    public void OnClick(MouseEventArgs args)
    {
        viewer.SetAnnotationMode(AnnotationType.Underline);
    }
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

## Strikethrough a text

There are two ways to strikethrough a text in the PDF document:

Using the context menu.

* Select a text in the PDF document and right-click it.

* Select **strikethrough** option in the context menu that appears.

![Displaying Strike Through in Blazor SfPdfViewer ContextMenu](../../pdfviewer/images/blazor-pdfviewer-strike-through-in-contextmenu.png)

**Using the annotation toolbar.**

* Click the **Edit Annotation** button in the SfPdfViewer toolbar. A toolbar appears below it.

* Select the **Strikethrough** button in the annotation toolbar. It enables the strikethrough mode.

* Select the text and the strikethrough annotation will be added.

* You can also select the text and apply the strikethrough annotation using the **Strikethrough** button.

![Blazor PDFViewer with StrikeThrough Text](../../pdfviewer/images/blazor-pdfviewer-strike-through-text.png)

In the pan mode, if the strikethrough mode is entered, the SfPdfViewer control will switch to text select mode to enable the text selection to strike through the text.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnClick">Strikethrough</SfButton>
<SfPdfViewer2 DocumentPath="@DocumentPath" @ref="viewer" Width="100%" Height="100%">
</SfPdfViewer2>

@code {
    
    SfPdfViewer2 viewer;

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

![Editing Text Color in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-editing-text-color.png)

### Editing opacity

The opacity of the annotation can be edited using the range slider provided in the Edit Opacity tool.

![Editing Text Opacity in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-edit-text-opacity.png)

## Text markup annotation settings

The properties of the text markup annotation can be set before creating the control using highlightSettings, underlineSettings, and strikethroughSettings.

N> After editing the default color and opacity using the Edit color tool and Edit opacity tool, they will be changed to the selected values.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 @ref="@viewer" DocumentPath="@DocumentPath" HighlightSettings="@HighlightSettings" UnderlineSettings="@UnderlineSettings" 
    StrikethroughSettings="@StrikethroughSettings" Height="100%" Width="100%"></SfPdfViewer2>

@code {
    SfPdfViewer2 viewer;

    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    PdfViewerHighlightSettings HighlightSettings = new PdfViewerHighlightSettings { Color = "green", Opacity = 0.6 };

    PdfViewerUnderlineSettings UnderlineSettings = new PdfViewerUnderlineSettings { Color = "blue", Opacity = 0.6 };

    PdfViewerStrikethroughSettings StrikethroughSettings = new PdfViewerStrikethroughSettings { Color = "orange", Opacity = 0.6 };
}

```