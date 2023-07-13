---
layout: post
title: Free text annotations in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about free text annotations in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Free text annotations in Blazor SfPdfViewer Component

The SfPdfViewer control provides the options to add, edit and delete the free text annotations.

## Adding a free text annotation to the PDF document

The free text annotations can be added to the PDF document using the annotation toolbar.

* Click the **Edit Annotation** button in the SfPdfViewer toolbar. A toolbar appears below it. 
* Select the **Free Text Annotation** button in the annotation toolbar. It enables the Free Text Annotation mode.
* You can add the text over the pages of the PDF document.

In the pan mode, if the free text annotation mode is entered, the SfPdfViewer control will switch to text select mode.

![Free Text Annotation in Blazor SfPdfViewer](../../pdfviewer/images/blazor-pdfviewer-free-text-annotation.png)

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="OnClick">Free Text</SfButton>
<SfPdfViewer2 @ref="viewer" DocumentPath=@DocumentPath Height="100%" Width="100%" ></SfPdfViewer2>

@code {
    SfPdfViewer2 viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    public async void OnClick(MouseEventArgs args)
    {
        await viewer.SetAnnotationModeAsync(AnnotationType.FreeText);
    }
}

```

## Editing the properties of free text annotation

The font family, font size, font styles, font color, text alignment, fill color, the border stroke color, border thickness, and opacity of the free text annotation can be edited using the Font Family tool, Font Size tool, Font Color tool, Text Align tool, Font Style tool  Edit Color tool, Edit Stroke Color tool, Edit Thickness tool, and Edit Opacity tool in the annotation toolbar.

### Editing font family

The font family of the annotation can be edited by selecting the desired font in the Font Family tool.

![Editing Font Family of Blazor SfPdfViewer Text](../../pdfviewer/images/blazor-pdfviewer-edit-font-family.png)

### Editing font size

The font size of the annotation can be edited by selecting the desired size in the Font Size tool.

![Editing Font Size of Blazor SfPdfViewer Text](../../pdfviewer/images/blazor-pdfviewer-edit-font-size.png)

### Editing font color

The font color of the annotation can be edited using the color palette provided in the Font Color tool.

![Editing Font Color of Blazor SfPdfViewer Text](../../pdfviewer/images/fontcolor.png)

### Editing the text alignment

The text in the annotation can be aligned by selecting the desired styles in the dropdown pop-up in the Text Align tool.

![Editing Free Text Annotation in Blazor SfPdfViewer](../../pdfviewer/images/blazor-pdfviewer-text-alignment.png)

### Editing text styles

The style of the text in the annotation can be edited by selecting the desired styles in the dropdown pop-up in the Font Style tool.

![Editing Font Style in Blazor SfPdfViewer](../../pdfviewer/images/blazor-pdfviewer-edit-font-style.png)

### Editing fill color

The fill color of the annotation can be edited using the color palette provided in the Edit Color tool.

![Editing Fill Color in Blazor SfPdfViewer Text](../../pdfviewer/images/blazor-pdfviewer-text-fill-color.png)

### Editing stroke color

The stroke color of the annotation can be edited using the color palette provided in the Edit Stroke Color tool.

![Editing Stroke Color of Blazor SfPdfViewer Text](../../pdfviewer/images/blazor-pdfviewer-font-stroke.png)

### Editing thickness

The thickness of the border of the annotation can be edited using the range slider provided in the Edit Thickness tool.

![Editing Font Border Thickness of Blazor SfPdfViewer Text](../../pdfviewer/images/blazor-pdfviewer-font-border-thickness.png)

### Editing opacity

The opacity of the annotation can be edited using the range slider provided in the Edit Opacity tool.

![Editing Font Opacity in Blazor SfPdfViewer](../../pdfviewer/images/blazor-pdfviewer-font-opacity.png)

## Setting default properties during control initialization

The properties of the free text annotation can be set before creating the control using FreeTextSettings.

After editing the default values, they will be changed to the selected values.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 @ref="viewer" DocumentPath=@DocumentPath Height="100%" Width="100%" 
FreeTextSettings=@FreeTextSettings></SfPdfViewer2>

@code {
    SfPdfViewer2 viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    
    PdfViewerFreeTextSettings FreeTextSettings = new PdfViewerFreeTextSettings 
    { 
        FillColor = "green", 
        BorderColor = "blue", 
        FontColor = "yellow" 
    };
}

```