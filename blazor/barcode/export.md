---
layout: post
title: Export in Blazor Barcode Component | Syncfusion
description: Checkout and learn here all about Export functionality in Syncfusion Blazor Barcode component and much more.
platform: Blazor
control: Barcode
documentation: ug
---

# Export in Blazor Barcode Component

## Export

Barcode provides support to export its content as an image in the specified image type and downloads it in the browser.

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

### ExportAsBaseImage

Barcode provides support to export as an image in the specified image type and returns it as base64 string.

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

> Format is to specify the type/format of the exported file. You can export Barcode to the following formats:
>* JPG.
>* PNG.