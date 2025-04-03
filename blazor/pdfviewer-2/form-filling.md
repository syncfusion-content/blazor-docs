---
layout: post
title: Form filling in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about form filling in Syncfusion Blazor SfPdfViewer component and much more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Form filling in Blazor SfPdfViewer Component

SfPdfViewer component allows to display the form fields available in the PDF document. By using this, you can edit and download the form fields.

The form fields displayed in the SfPdfViewer are:

* Text box
* Password box
* Combo box
* Check box
* Radio Button
* Signature Field
* List box

![Form Filling in Blazor SfPdfViewer](../pdfviewer/images/blazor-pdfviewer-form-filling.png)

## Disabling form fields

The SfPdfViewer control provides an option to disable the form fields feature. The code snippet for disabling the feature is as follows.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%"
              Width="100%"
              DocumentPath="@DocumentPath"
              EnableFormFields=false />

@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/FormFillingDocument.pdf";
}

```

## How to draw handwritten signature in the signature field

Signature can be added to the Signature field by using the following steps:

* Click the Signature Field in the PDF document. The signature panel will appear.

![Signature Field in Blazor SfPdfViewer](../pdfviewer/images/blazor-pdfviewer-signature-field.png)

* Draw the signature in the signature panel.

![Displaying Signature Panel in Blazor SfPdfViewer](../pdfviewer/images/blazor-pdfviewer-signature-panel.png)

* Click the **CREATE** button, the drawn signature will be added in the signature field.

![Displaying Signature in Blazor SfPdfViewer](../pdfviewer/images/blazor-pdfviewer-signature.png)

## Delete the signature inside the signature field

You can also delete the signature in the signature field by using Delete Option in the annotation toolbar.

![Deleting Signature in Blazor SfPdfViewer](../pdfviewer/images/blazor-pdfviewer-delete-signature.png)

## Export and import form fields

The SfPdfViewer control supports exporting and importing the form field data in the following formats using the `ImportFormFieldsAsync` and `ExportFormFieldsAsync` methods.

* XML
* FDF
* XFDF
* JSON

> N The form field data will be exported as stream, and that data from the stream will be imported into the current PDF document.

### Export and import as XML

The following code shows how to export the form fields as an XML data stream and import that data from the stream into the current PDF document via a button click.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@ExportAsStream">Export XML</SfButton>
<SfButton OnClick="@ImportFromStream">Import XML</SfButton>

<SfPdfViewer2 @ref=Viewer
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%" />

@code 
{
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/FormFillingDocument.pdf";
    Stream stream;

    // Event triggers on Export XML button click.
    public async void ExportAsStream()
    {
        // Export the form field data to an XML format stream.
        stream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Xml);
    }

    // Event triggers on Import XML button click.
    public async void ImportFromStream()
    {
        // Import the form field data from the XML format stream into the current PDF document.
        await Viewer.ImportFormFieldsAsync(stream, FormFieldDataFormat.Xml);
    }
}

```

### Export and import as FDF

The following code shows how to export the form fields as an FDF data stream and import that data from the stream into the current PDF document via a button click.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@ExportAsStream">Export FDF</SfButton>
<SfButton OnClick="@ImportFromStream">Import FDF</SfButton>

<SfPdfViewer2 @ref=Viewer
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%" />

@code
{
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/FormFillingDocument.pdf";
    Stream stream;

    // Event triggers on Export FDF button click.
    public async void ExportAsStream()
    {
        // Export the form field data to an FDF format stream.
        stream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Fdf);
    }

    // Event triggers on Import FDF button click.
    public async void ImportFromStream()
    {
        // Import the form field data from the FDF format stream into the current PDF document.
        await Viewer.ImportFormFieldsAsync(stream, FormFieldDataFormat.Fdf);
    }
}

```

###  Export and import as XFDF

The following code shows how to export the form fields as an XFDF data stream and import that data from the stream into the current PDF document via a button click.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="@ExportAsStream">Export XFDF</SfButton>
<SfButton OnClick="@ImportFromStream">Import XFDF</SfButton>

<SfPdfViewer2 @ref=Viewer
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%" />

@code
{
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/FormFillingDocument.pdf";
    Stream stream;

    // Event triggers on Export XFDF button click.
    public async void ExportAsStream()
    {
        // Export the form field data to an XFDF format stream.
        stream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Xfdf);
    }

    // Event triggers on Import XFDF button click.
    public async void ImportFromStream()
    {
        // Import the form field data from the XFDF format stream into the current PDF document.
        await Viewer.ImportFormFieldsAsync(stream, FormFieldDataFormat.Xfdf);
    }
}

```

### Export and import as JSON

The following code shows how to export the form fields as a JSON data stream and import that data from the stream into the current PDF document via a button click.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="@ExportAsStream">Export JSON</SfButton>
<SfButton OnClick="@ImportFromStream">Import JSON</SfButton>

<SfPdfViewer2 @ref=Viewer
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%" />

@code
{
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/FormFillingDocument.pdf";
    Stream stream;

    // Event triggers on Export JSON button click.
    public async void ExportAsStream()
    {
        // Export the form field data to an JSON format stream.
        stream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Json);
    }

    // Event triggers on Import JSON button click.
    public async void ImportFromStream()
    {
        // Import the form field data from the JSON format stream into the current PDF document.
        await Viewer.ImportFormFieldsAsync(stream, FormFieldDataFormat.Json);
    }
}


```

### Export form fields as Json file

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="@OnExportFormFieldsClick">Export JSON</SfButton>

<SfPdfViewer2 Height="100%"
              Width="100%"
              DocumentPath="@DocumentPath"
              @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/FormFillingDocument.pdf";

    // Event triggers on Export JSON button click.
    public async void OnExportFormFieldsClick(MouseEventArgs args)
    {
        // Exports to a JSON file in the existing document name.
        await Viewer.ExportFormFieldsAsync("");
    }
}

```

### Export and import as object

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer;

<SfButton OnClick="@OnExportFormFieldsClick">Export Data</SfButton>
<SfButton OnClick="@OnImportFormFieldsClick">Import Data</SfButton>

<SfPdfViewer2 @ref="@Viewer"
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code
{
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/FormFillingDocument.pdf";
    Dictionary<string, string> dictionary;

    // Event triggers on Export Data button click.
    public async void OnExportFormFieldsClick(MouseEventArgs args)
    {
        // Export the form field data to a dictionary.
        dictionary = await Viewer.ExportFormFieldsAsObjectAsync();
    }

    // Event triggers on Import Data button click.
    public async void OnImportFormFieldsClick(MouseEventArgs args)
    {
        // Import the form field data from the dictionary into the current PDF document.
        await Viewer.ImportFormFieldsAsync(dictionary);
    }
}

```

## See also

* [Handwritten Signature in Blazor SfPdfViewer Component](./hand-written-signature)