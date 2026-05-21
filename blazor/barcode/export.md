---
layout: post
title: Export in Blazor Barcode Component | Syncfusion
description: Checkout and learn here all about Export functionality in Syncfusion Blazor Barcode component and much more.
platform: Blazor
control: Barcode
documentation: ug
---

# Export in Blazor Barcode Component

Saving and sharing barcode data in a flexible format is an essential requirement for many applications. Exporting a barcode as an image or a Base64 string is a widely adopted approach when working with Barcode, QR Code, and Data Matrix, as it simplifies how barcode content is reused and transmitted. 

The `Export` feature allows you to easily save the generated barcode as an image file. This is useful when you need to download, print, or share the barcode outside the application. With just a single method call, the barcode is converted into a standard image format like JPG or PNG and downloaded directly to the browser, making it simple for end users to access and use.

The `ExportAsBase64` feature is useful when you want to work with barcode data without creating physical image files. Instead of downloading the barcode, it is converted into a Base64 string that can be directly used in your application. This makes it easy to embed the barcode in web pages, send it through APIs, or store it in databases for later use.

## Export

[Blazor Barcode](https://www.syncfusion.com/blazor-components/blazor-barcode) provides support to export its content as an image in the specified image type and downloads it in the browser.

The following code example demonstrates how to export the generated barcode as an image file. 

```cshtml
@using Syncfusion.Blazor.BarcodeGenerator

<input type="button" value="Export" @onclick="@OnExport" />
<SfQRCodeGenerator Width="200px" Height="150px" Value="Syncfusion" @ref="@QRcode" >
    <QRCodeGeneratorDisplayText Text="Text"></QRCodeGeneratorDisplayText>
</SfQRCodeGenerator>
@code{
    SfQRCodeGenerator QRcode;
    private void OnExport() {
        QRcode.Export("fileName", BarcodeExportType.JPG);
    }
}

 ```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVKMVWJJCCNRCqQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### ExportAsBaseImage

Barcode provides support to export as an image in the specified image type and returns it as base64 string.

The following code example illustrates how to export the barcode as a Base64 encoded string.

```cshtml
@using Syncfusion.Blazor.BarcodeGenerator

<input type="button" value="Export" @onclick="@OnExport" />
<SfQRCodeGenerator Width="200px" Height="150px" Value="Syncfusion" @ref="@QRcode">
    <QRCodeGeneratorDisplayText Text="Text"></QRCodeGeneratorDisplayText>
</SfQRCodeGenerator>

@code
{
    SfQRCodeGenerator QRcode;

    private async void OnExport()
    {
        await QRcode.ExportAsBase64Image(BarcodeExportType.JPG);
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBgWLWfTiCgSXzC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Format specifies the image type of the exported file. The following export formats are supported:
<br/>* JPG.
<br/>* PNG.