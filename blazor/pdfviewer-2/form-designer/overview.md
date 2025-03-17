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
    // Reference to the SfPdfViewer2 instance
    SfPdfViewer2 PdfViewerInstance { get; set; }

    // Adds a form field that appears in the viewer but is excluded from printing.
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

> Note: By default, `EnableFormDesigner` is set to `true`.

#### Example code for Injecting Form Designer Module

The following code snippet explains how to inject the FormDesigner module and enable the form designer toolbar in **SfPdfViewer**.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;

<!-- SfPdfViewer component with Form Designer enabled -->
<SfPdfViewer2 @ref="PdfViewerInstance" EnableFormDesigner = "true" DocumentPath="wwwroot/data/Form_Designer.pdf"
                  Height="650px"
                  Width="100%">
    </SfPdfViewer2>
@code {
    // Reference to the SfPdfViewer2 instance
    SfPdfViewer2 PdfViewerInstance { get; set; }
}
```

![Enable Form Designer Module](form-designer-images/Enable_Form_Designer_Module.png)

[View sample in GitHub]().

### Enable or Disable Designer Mode in Form Designer

The Designer Mode in **SfPdfViewer** allows users to interact with form field design elements.

When Designer Mode is enabled, users can edit, move, and manipulate form fields within the PDF Viewer. 

If disabled, form fields remain static and can only be filled without modification.

> Note: By default, `IsDesignerMode` is set to `false`, meaning form fields can be filled but not modified.

#### Example for Enable or Disable Designer Mode Dynamically

The following example demonstrates how to Enable Designer Mode using SfButton components.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;
@using Syncfusion.Blazor.Buttons;

<!-- SfPdfViewer component with Designer Mode enabled -->
<SfPdfViewer2 @ref="PdfViewerInstance" 
                IsDesignerMode="true" 
                DocumentPath="wwwroot/data/Form_Designer.pdf"
                Height="650px"
                Width="100%">
</SfPdfViewer2>

@code {
    // Reference to the SfPdfViewer2 instance
    SfPdfViewer2 PdfViewerInstance { get; set; }
}
```

![Enable or Disable Designer Mode](form-designer-images/Enable_Disable_Designer_Mode.gif)

[View sample in GitHub]().

## Export and Import Form Fields Data

The SfPdfViewer control provides support for exporting and importing form field data in multiple formats. 

This functionality allows you to save, transfer, or restore form field values efficiently using the following supported formats:

> 1. XML
> 2. FDF 
> 3. XFDF 
> 4. JSON
> 5. Object-based

The ExportFormFieldsAsync and ImportFormFieldsAsync methods allow you to export the form field data as a stream, which can later be used to import the saved data into another PDF document.

### Types of Form Fields Export and Import

#### Export and Import as XML

Exports form fields data as a XML format and allows importing the same data back into a PDF document.

The following code shows how to export the form fields as an XML data stream and import that data from the stream into the current PDF document via a button click.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="ExportFormFieldData">Export Data</SfButton>
<SfButton OnClick="ImportFormFieldData">Import Data</SfButton>

<SfPdfViewer2 @ref="PdfViewerInstance" DocumentPath="wwwroot/data/Form_Filling_Document_With_Data.pdf"
              Height="650px"
              Width="100%">
</SfPdfViewer2>

@code { 
    // Reference to the SfPdfViewer2 instance
    SfPdfViewer2 PdfViewerInstance { get; set; }

    // Stream to store exported XML form field data
    Stream XMLStream = new MemoryStream();

    // List to store form field information
    List<FormFieldInfo> FormFields = new List<FormFieldInfo>();

    // Exports form field data from the PDF viewer to an XML stream
    private async Task ExportFormFieldData()
    {
        if (PdfViewerInstance != null)
        {
            // Retrieve form field information from the PDF viewer
            FormFields = await PdfViewerInstance.GetFormFieldsAsync();
            if (FormFields != null && FormFields.Count > 0)
            {
                // Export data to XML format
                XMLStream = await PdfViewerInstance.ExportFormFieldsAsync(FormFieldDataFormat.Xml); 
            }
        }
    }

    // Imports form field data from the XML stream into the PDF viewer
    private async Task ImportFormFieldData()
    {
        if (PdfViewerInstance != null && XMLStream != null)
        {
            // Import XML data into the viewer
            await PdfViewerInstance.ImportFormFieldsAsync(XMLStream, FormFieldDataFormat.Xml); 
        }
    }
}
```

![Export and Import XML Format](form-designer-images/Export_Import_XML_Format.gif)

[View sample in GitHub]().

#### Export and Import as FDF

Exports form field data in Forms Data Format (FDF) and allows importing the same data back into a PDF document.

The code demonstrates how to exporting form fields as FDF at a stream and importing the data back into the current PDF document through a button click.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="ExportFormFieldData">Export Data</SfButton>
<SfButton OnClick="ImportFormFieldData">Import Data</SfButton>

<SfPdfViewer2 @ref="PdfViewerInstance" DocumentPath="wwwroot/data/Form_Filling_Document_With_Data.pdf"
              Height="650px"
              Width="100%">
</SfPdfViewer2>

@code { 
    // Reference to the SfPdfViewer2 instance
    SfPdfViewer2 PdfViewerInstance { get; set; }

    // Stream to store exported form field data in FDF format
    Stream FDFStream = new MemoryStream();

    // List to store form field information
    List<FormFieldInfo> FormFields = new List<FormFieldInfo>();

    // Exports form field data from the PDF viewer in FDF format
    private async void ExportFormFieldData()
    {
        // Retrieve form field information from the PDF viewer
        FormFields = await PdfViewerInstance.GetFormFieldsAsync(); 
        if (FormFields != null && FormFields.Count > 0)
        {
            // Export form fields as FDF data
            FDFStream = await PdfViewerInstance.ExportFormFieldsAsync(FormFieldDataFormat.Fdf); 
        }
    }

    // Imports form field data from FDF format into the PDF viewer
    private async void ImportFormFieldData()
    {
        if (FDFStream != null)
        {
            // Import FDF data into the viewer
            await PdfViewerInstance.ImportFormFieldsAsync(FDFStream, FormFieldDataFormat.Fdf); 
        }
    }
}
```

![Export and Import FDF Format](form-designer-images/Export_Import_FDF_Format.gif)

[View sample in GitHub]().

#### Export and Import as XFDF

Similar to FDF, but in XML-based format, XFDF ensures structured data handling for form fields.

The following code shows how to export the form fields as an XFDF data stream and import that data from the stream into the current PDF document via a button click.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="ExportFormFieldData">Export Data</SfButton>
<SfButton OnClick="ImportFormFieldData">Import Data</SfButton>

<SfPdfViewer2 @ref="PdfViewerInstance" DocumentPath="wwwroot/data/Form_Filling_Document_With_Data.pdf"
              Height="650px"
              Width="100%">
</SfPdfViewer2>

@code { 
    // Reference to the SfPdfViewer2 instance
    SfPdfViewer2 PdfViewerInstance { get; set; }

    // Stream to store exported XFDF form field data
    Stream XFDFStream = new MemoryStream();

    // List to store form field information
    List<FormFieldInfo> FormFields = new List<FormFieldInfo>();

    // Exports form field data from the PDF viewer to an XFDF stream
    private async void ExportFormFieldData()
    {
        // Retrieve form field information from the PDF viewer
        FormFields = await PdfViewerInstance.GetFormFieldsAsync(); 
        if (FormFields != null && FormFields.Count > 0)
        {
            // Export data to XFDF format 
            XFDFStream = await PdfViewerInstance.ExportFormFieldsAsync(FormFieldDataFormat.Xfdf); 
        }
    }
    // Imports form field data from the XFDF stream into the PDF viewer
    private async void ImportFormFieldData()
    {
        if (XFDFStream != null)
        {
            // Import XFDF data into the viewer
            await PdfViewerInstance.ImportFormFieldsAsync(XFDFStream, FormFieldDataFormat.Xfdf); 
        }
    }
}
```

![Export and Import XFDF Format](form-designer-images/Export_Import_XFDF_Format.gif)

[View sample in GitHub]().

#### Export and Import as JSON

Exports form field data in JSON format, which can be easily read and imported back into the PDF Viewer.

The code demonstrates how to exporting form fields as JSON at a stream and importing the data back into the current PDF document through a button click.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="ExportFormFieldData">Export Data</SfButton>
<SfButton OnClick="ImportFormFieldData">Import Data</SfButton>

<SfPdfViewer2 @ref="PdfViewerInstance" DocumentPath="wwwroot/data/Form_Filling_Document_With_Data.pdf"
              Height="650px"
              Width="100%">
</SfPdfViewer2>

@code { 
    // Reference to the SfPdfViewer2 instance
    SfPdfViewer2 PdfViewerInstance { get; set; }

    // Stream to store exported form field data in JSON format
    Stream JSONStream = new MemoryStream();

    // List to store form field information
    List<FormFieldInfo> FormFields = new List<FormFieldInfo>();

    // Exports form field data from the PDF viewer in JSON format
    private async void ExportFormFieldData()
    {
        // Retrieve form field information from the PDF viewer
        FormFields = await PdfViewerInstance.GetFormFieldsAsync(); 
        if (FormFields != null && FormFields.Count > 0)
        {
            // Export form fields as JSON data
            JSONStream = await PdfViewerInstance.ExportFormFieldsAsync(FormFieldDataFormat.Json); 
        }
    }

    // Imports form field data from JSON format into the PDF viewer
    private async void ImportFormFieldData()
    {
        if (JSONStream != null)
        {
            // Import JSON data into the viewer
            await PdfViewerInstance.ImportFormFieldsAsync(JSONStream, FormFieldDataFormat.Json); 
        }
    }
}
```

![Export and Import JSON Format](form-designer-images/Export_Import_JSON_Format.gif)

[View sample in GitHub]().

#### Export and Import as an Object

The Form fields can be exported and imported as an object, which is useful for in-memory processing and quick data manipulation.

The following code shows how to export the form fields as an XFDF data stream and import that data from the stream into the current PDF document via a button click.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="ExportFormFieldData">Export Data</SfButton>
<SfButton OnClick="ImportFormFieldData">Import Data</SfButton>

<SfPdfViewer2 @ref="PdfViewerInstance" DocumentPath="wwwroot/data/Form_Filling_Document_With_Data.pdf"
              Height="650px"
              Width="100%">
</SfPdfViewer2>

@code { 
    // Reference to the SfPdfViewer2 instance
    SfPdfViewer2 PdfViewerInstance { get; set; }

    // Dictionary to store exported form field data as key-value pairs
    Dictionary<string, string> FormFieldsObject = new Dictionary<string, string>();

    // List to store form field information
    List<FormFieldInfo> FormFields = new List<FormFieldInfo>();

    // Exports form field data from the PDF viewer as an object (key-value pairs)
    private async void ExportFormFieldData()
    {
        // Retrieve form field information
        FormFields = await PdfViewerInstance.GetFormFieldsAsync();
        if (FormFields != null && FormFields.Count > 0)
        {
            // Export form fields as an object
            FormFieldsObject = await PdfViewerInstance.ExportFormFieldsAsObjectAsync();
        }
    }

    // Imports form field data from an object into the PDF viewer
    private async void ImportFormFieldData()
    {
        if (FormFieldsObject != null)
        {
            // Import object data into the viewer
            await PdfViewerInstance.ImportFormFieldsAsync(FormFieldsObject);
        }
    }
}
```

![Export and Import Object Format](form-designer-images/Export_Import_Object_Format.gif)

[View sample in GitHub]().

#### Export Form Fields as a JSON File

This method allows exporting the form field data and saving it as a JSON file, which can be stored or shared for future use.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="ExportFormFieldData">Export Data</SfButton>

<SfPdfViewer2 @ref="PdfViewerInstance" DocumentPath="wwwroot/data/Form_Filling_Document_With_Data.pdf"
              Height="650px"
              Width="100%">
</SfPdfViewer2>

@code {
    // Reference to the SfPdfViewer2 instance
    SfPdfViewer2 PdfViewerInstance { get; set; }

    // Exports form field data from the PDF viewer into a JSON file
    private async void ExportFormFieldData()
    {
        // Exports form fields and saves them as a JSON file
        await PdfViewerInstance.ExportFormFieldsAsync(""); 
    }
}
```

![Export and Import JSON File](form-designer-images/Export_JSON_File.gif)

[View sample in GitHub]().

Additionally, the component provides a built-in Submit button that allows exporting form field data as a JSON file directly from the PDF document. The following sections demonstrate different ways to export and import form field data.

Refer to the GIF below for details.

![Export and Import Object Format](form-designer-images/Export_Submit_JSON.gif)