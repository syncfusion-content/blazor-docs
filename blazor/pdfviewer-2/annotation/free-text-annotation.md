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

## Add free text annotation programmatically

The Blazor SfPdfViewer offers the capability to programmatically add the free text annotation within the SfPdfViewer control using the [AddAnnotationAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_AddAnnotationAsync_Syncfusion_Blazor_SfPdfViewer_PdfAnnotation_) method.

Below is an example demonstrating how you can use this method to add free text annotation to a PDF document:

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="@AddFreeTextAnnotationAsync">Add FreeText Annotation</SfButton>
<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/Free_Text_Annotation.pdf";

    public async void AddFreeTextAnnotationAsync(MouseEventArgs args)
    {
        PdfAnnotation annotation = new PdfAnnotation();
        // Set the annotation type of free text
        annotation.Type = AnnotationType.FreeText;
        // Set the PageNumber starts from 0. So, if set 0 it repersent the page 1.
        annotation.PageNumber = 0;

        // Bound of the free text annotation
        annotation.Bound = new Bound();
        annotation.Bound.X = 200;
        annotation.Bound.Y = 150;
        annotation.Bound.Width = 150;
        annotation.Bound.Height = 30;
        // Add free text annotation
        await Viewer.AddAnnotationAsync(annotation);
    }
}

```

This code will add a free text annotation to the first page of the PDF document.

![Programmatically Added Free Text Annotation in Blazor SfPdfViewer](../images/blazor-sfpdfviewer-programmatically-add-freetext-annotation.png)

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Programmatic%20Support/Free%20Text/Add).

## Edit free text annotation programmatically

The Blazor SfPdfViewer offers the capability to programmatically edit the free text annotation within the SfPdfViewer control using the [EditAnnotationAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EditAnnotationAsync_Syncfusion_Blazor_SfPdfViewer_PdfAnnotation_) method.

Below is an example demonstrating how you can utilize this method to edit the free text annotation programmatically:

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="@EditFreeTextAnnotationAsync">Edit FreeText Annotation</SfButton>
<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/Free_Text_Annotation.pdf";

    public async void EditFreeTextAnnotationAsync(MouseEventArgs args)
    {
        // Get annotation collection
        List<PdfAnnotation> annotationCollection = await Viewer.GetAnnotationsAsync();
        // Select the annotation want to edit
        PdfAnnotation annotation = annotationCollection[0];
        // Change the position of the free text annotation
        annotation.Bound.X = 125;
        annotation.Bound.Y = 125;
        // Change the width and height of the free text annotation
        annotation.Bound.Width = 250;
        annotation.Bound.Height = 40;
        // Change the font style of free text annotation like bold, italic, underline strikethrough
        annotation.FontStyle = FontStyle.Bold | FontStyle.Italic;
        // Change the font size of free text annotation
        annotation.FontSize = 20;
        // Change the font color of free text annotation
        annotation.FontColor = "#00008B";
        // Change the font family of free text annotation
        annotation.FontFamily = "Symbol";
        // Change the border width of free text annotation
        annotation.BorderWidth = 3;
        // Change the border color of free text annotation
        annotation.BorderColor = "#000000";
        // Change the text of free text annotation
        annotation.DynamicText = "Modified Free Text";
        // Change the text align of free text annotation
        annotation.TextAlignment = TextAlignment.Center;
        // Change the fill color of free text annotation
        annotation.FillColor = "#FFFF00";
        // Change the Opacity (0 to 1) of free text annotation
        annotation.Opacity = 0.5;
        // Edit the free text annotation
        await Viewer.EditAnnotationAsync(annotation);
    }
}

```

This code snippet will edit the free text annotation programmatically within the SfPdfViewer control.

![Programmatically Edit Free Text Annotation in Blazor SfPdfViewer](../images/blazor-sfpdfviewer-programmatically-edit-freetext-annotation.png)

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Programmatic%20Support/Free%20Text/Edit).

## Custom Font Support for FreeText Annotation

The Blazor SfPdfViewer allows you to load, edit, and save custom fonts in FreeText annotations using the [FallbackFontCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_FallbackFontCollection) and [FontFamilies](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_FontFamilies) properties

### Loading Custom Font Collection in SfPdfViewer
If the custom font is not installed on the system, the FallbackFontCollection property is required to save the FreeText annotation with the custom font.

The following example demonstrates how to load custom font collections, such as Arial Black and Courier New, as TTF files in SfPdfViewer.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 @ref="pdfViewer" Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents Created="@Created"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private SfPdfViewer2? pdfViewer;
    private string DocumentPath { get; set; } = "wwwroot/PDF/Arial Black.pdf";

    public void Created()
    {
        // Use FallbackFontCollection to save the custom font
        // Maps the font family name to its corresponding TTF file as a memory stream  
        pdfViewer.FallbackFontCollection.Add("Arial", new MemoryStream(System.IO.File.ReadAllBytes("wwwroot/Fonts/ARIAL.ttf")));
        pdfViewer.FallbackFontCollection.Add("Arial Black", new MemoryStream(System.IO.File.ReadAllBytes("wwwroot/Fonts/ARIBLK.ttf")));
        pdfViewer.FallbackFontCollection.Add("Courier New", new MemoryStream(System.IO.File.ReadAllBytes("wwwroot/Fonts/COUR.ttf")));
    }
}
```
### Adding Custom Font Families to the Annotation Toolbar Dropdown
The FontFamilies property is used to add custom font families to the Font Family dropdown in the annotation toolbar.

The following example demonstrates how to add custom font families as a string array to the Font Family dropdown in the annotation toolbar:

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 @ref="pdfViewer" Height="100%" Width="100%" DocumentPath="@DocumentPath" FontFamilies="@FontFamilies">
</SfPdfViewer2>

@code {
    private SfPdfViewer2? pdfViewer;
    
    // Use the FontFamilies property to add custom font families to the Font Family dropdown in the annotation toolbar
    internal string[] FontFamilies { get; set; } = { "Helvetica", "Courier", "Symbol", "Times New Roman", "Arial Black", "Courier New", "Arial" };
    private string DocumentPath { get; set; } = "wwwroot/PDF/Arial Black.pdf";
}
```

![FontFamilies Property in Blazor SfPdfViewer](../images/FontFamilies_API_SfPdfViewer.png)


The following example demonstrates how to load, edit, and save custom fonts in FreeText annotations

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 @ref="pdfViewer" Height="100%" Width="100%" DocumentPath="@DocumentPath" FontFamilies="@FontFamilies">
    <PdfViewerEvents Created="@Created"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private SfPdfViewer2? pdfViewer;

    // Use the FontFamilies property to add custom font families to the annotation toolbar dropdown
    internal string[] FontFamilies { get; set; } = { "Helvetica", "Courier", "Symbol", "Times New Roman", "Arial Black", "Courier New", "Arial" };

    private string DocumentPath { get; set; } = "wwwroot/PDF/Arial Black.pdf";

    public void Created()
    {
        // Use FallbackFontCollection to save the custom font
        // Maps the font family name to its corresponding TTF file as a memory stream  
        pdfViewer.FallbackFontCollection.Add("Arial", new MemoryStream(System.IO.File.ReadAllBytes("wwwroot/Fonts/ARIAL.ttf")));
        pdfViewer.FallbackFontCollection.Add("Arial Black", new MemoryStream(System.IO.File.ReadAllBytes("wwwroot/Fonts/ARIBLK.ttf")));
        pdfViewer.FallbackFontCollection.Add("Courier New", new MemoryStream(System.IO.File.ReadAllBytes("wwwroot/Fonts/COUR.ttf")));
    }
}
```

![Custom Font Support for FreeText annotation in Blazor SfPdfViewer](../images/customFont_support_freeText.png)

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/FreeText/Custom%20Font%20Support%20For%20FreeText%20Annotation).

To ensure proper and seamless execution when using Google API fonts in the PDF Viewer component, it's essential to load these fonts into the sample application as well. This is particularly important because FreeText annotations are rendered directly onto the canvas, making it mandatory to have the fonts available in the sample for accurate rendering.

The following example illustrates how to load custom fonts in FreeText annotations using fonts from Google Fonts or other external sources.

```cshtml
<script>
    window.addEventListener('DOMContentLoaded', () => {
        var fontFamily = ["Allura, Tangerine, Sacramento, Inspiration"];
        for (var fontIndex=0; fontIndex<fontFamily.length; fontIndex++)
        {
            document.fonts.load(`16px ${fontFamily[fontIndex]}`).then(() => {
                console.log(`Font "${fontFamily[fontIndex]}" loaded successfully.`);
            }).catch(err => {
                console.error(`Failed to load font "${font}":`, err);
            });
        }
    });
</script>
```

>**Note:** If external fonts are not properly loaded in the environment, it may lead to slight inconsistencies when importing and rendering free text annotations using those custom fonts. This issue typically occurs only with fonts that are referenced externally, such as those loaded from web-based sources.

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/FreeText/Load%20Custom%20Font%20From%20External%20Links).

## See also

* [How to delete the annotation programmatically](./text-markup-annotation#delete-annotation-programmatically)
* [How to Load the Font Collection in SfPdfViewer](../how-to/load-font-collection)