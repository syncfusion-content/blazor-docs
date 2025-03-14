---
layout: post
title: Overview of the Form Designer in SfPdfViewer for Blazor | Syncfusion
description: Learn about the Form Designer feature in SfPdfViewer for Blazor. Discover how to create, edit, and manage interactive form fields within PDF documents.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Form Designer Overview

The Form Designer in SfPdfViewer enables seamless creation, editing, and management of interactive form fields. It supports dynamic module injection, allowing the designer to be added or removed while updating relevant UI elements. Various form fields, including **Text Box**, **Password**, **Radio Button**, **Check Box**, **Dropdown**, **List Box**, **Signature Field** and **Button**, can be added with custom naming, grouping, and data consistency across pages.

Fields retain properties when downloaded or reloaded, even for large documents. Operations like cut, copy, paste, zoom, and resize function smoothly while maintaining data integrity. Additional features include read-only and required field modes, validation, extensive customization, undo/redo, and form submission controls.

## Supported Form Fields

SfPdfViewer supports a range of interactive form fields for structured and dynamic data collection:

> 1. Textbox 
> 2. Password  
> 3. Check Box
> 4. Radio Button
> 5. List Box
> 6. Drop Down
> 7. Signature Field
> 8. Button Field

These fields ensure seamless interaction, customization, and data consistency, enabling the creation of well-structured and user-friendly PDF forms.

## Form Field Management

The SfPdfViewer enables efficient form field management by supporting opening, saving, and printing PDFs while maintaining field integrity.

### Open the PDF Documents with Interactive Form Fields

SfPdfViewer enables smooth loading of PDFs with interactive form fields, preserving their properties and data. This ensures seamless modifications, validations, and data retention, even in large documents. A saved PDF with form fields can be opened using the Open icon in the toolbar. Refer to the GIF below for details.

![Open PDF Document with Exsiting Form Fileds](form-designer-images/Open_PDF_Document_With_Exsiting_Form_Fileds.gif)

### Saving Form Fields

SfPdfViewer saves form fields within the PDF without modifying the original file. Selecting the Download icon preserves all field data and properties for future use. Refer to the GIF below for details.

![Download PDF Document with Form Fileds](form-designer-images/Download_PDF_Document_With_Form_Fileds.gif)

### Printing Form Fields

In SfPdfViewer, form fields can have different visibility modes that control their appearance in the viewer and printed documents.

To control the **Visibility** of form fields in print mode, the **VisibilityMode** enum provides the following options:

#### Available Visibility Modes

| **Mode**                 | **Behavior** |
|--------------------------|-------------|
| **Visible**              | Always visible in both viewer and print. |
| **Hidden**               | Completely hidden in both viewer and print. |
| **VisibleNotPrintable**  | Visible in viewer but excluded from printing. |
| **HiddenPrintable**      | Hidden in viewer but appears in print. |

> Note: The **Visible** mode is the **default** mode for form fields in **SfPdfViewer**.

---

This flexibility ensures precise control over which form fields are displayed or printed as needed. 

#### Example code for the Visibility property

The following code snippet explains how to add a form field that is visible in the viewer but does not appear in print in the SfPdfViewer component.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="AddVisibleNotPrintField">Add Visible Not Printable Textbox</SfButton>

<SfPdfViewer2 @ref="PdfViewerInstance" DocumentPath="wwwroot/data/Form_Fields_with_Visibility_Property.pdf"
                  Height="650px"
                  Width="100%">
    </SfPdfViewer2>
@code { 
    SfPdfViewer2 PdfViewerInstance { get; set; }

    /// <summary>
    /// Adds a form field that appears in the viewer but is excluded from printing.
    /// </summary>
    private async void AddVisibleNotPrintField()
    {
        await PdfViewerInstance.AddFormFieldsAsync(
            [new TextBoxField {
                Name = "VisibleNotPrintable",
                Value = "VisibleNotPrintable",
                Bounds = new Bound { X = 270, Y = 620, Height = 30, Width = 200 },
                PageNumber = 1,
                Visibility = VisibilityMode.VisibleNotPrintable
            }]
        );
    }
}
```

Refer to the GIF below for more details.

![Form Field with VisibleNotPrintable Mode](form-designer-images/Form_Field_with_VisibleNotPrintable_Mode.gif)

[View sample in GitHub]().

### Enable or Disable Form Designer Module in SfPdfViewer

The Form Designer module in **SfPdfViewer** allows users to add and modify form fields within a PDF document.

To enable the Form Designer icon on the toolbar, the FormDesigner module must be injected, and the **EnableFormDesigner** property must be set to `true`.  

If set to `false`, the PDF Viewer remains in **Form Filling Mode only**, and the Form Designer feature is disabled.    

> **Note:** By default, `EnableFormDesigner` is set to `true`.

#### Example code for Injecting Form Designer Module

The following code snippet explains how to inject the FormDesigner module and enable the form designer toolbar in **SfPdfViewer**.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 @ref="PdfViewerInstance" EnableFormDesigner = "true" DocumentPath="wwwroot/data/Form_Designer.pdf"
                  Height="650px"
                  Width="100%">
    </SfPdfViewer2>
@code {
    SfPdfViewer2 PdfViewerInstance { get; set; }
}
```

![Enable Form Designer Module](form-designer-images/Enable_Form_Designer_Module.png)

### Enable or Disable Form Designer 