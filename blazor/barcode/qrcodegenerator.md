---
layout: post
title: QR Code generator in Blazor Barcode Component | Syncfusion
description: Checkout and learn here all about QR Code generator in Syncfusion Blazor Barcode component and more.
platform: Blazor
control: Barcode
documentation: ug
---

# QR Code Generator in Blazor Barcode Component

## QR Code

The [Blazor QR Code](https://www.syncfusion.com/blazor-components/blazor-barcode) is a two-dimensional barcode that is made up of a grid of dark and light dots or blocks that form a square. The data encoded in the barcode can be numeric, alphanumeric, or Shift Japanese Industrial Standards (JIS8) characters. The QR Code uses version from 1 to 40. Version 1 measures 21 modules x 21 modules, Version 2 measures 25 modules x 25 modules, and so on. The number of modules increases in steps of 4 modules per side up to Version 40, which measures 177 modules x 177 modules. Each version has its own capacity. By default, the barcode control automatically sets the version according to the length of the input text. The QR Barcodes are designed for industrial uses and are also commonly used in consumer advertising.

```cshtml
@using Syncfusion.Blazor.BarcodeGenerator

<SfQRCodeGenerator Width="200px" Height="150px" Value="Syncfusion"></SfQRCodeGenerator>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htBqsLMJfZxnCqnf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![QR Code in Blazor Barcode Component](images/blazor-barcode-with-qrcode.png)

## Customizing the Barcode color

A page or printed media containing a barcode often appears colorful in the background and surrounding region with other contents. In such cases, the barcode can also be customized to meet the needs. You can achieve this using [ForeColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.SfQRCodeGenerator.html#Syncfusion_Blazor_BarcodeGenerator_SfQRCodeGenerator_ForeColor) property.

```cshtml
@using Syncfusion.Blazor.BarcodeGenerator

<SfQRCodeGenerator Width="200px" Height="150px" ForeColor="red" Value="Syncfusion"></SfQRCodeGenerator>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBUiVMzfXduXXET?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customizing QR Code Color in Blazor Barcode](images/blazor-barcode-qrcode-color-customization.png)

## Customizing the Barcode dimension

The dimension of the barcode can be changed using the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.SfQRCodeGenerator.html#Syncfusion_Blazor_BarcodeGenerator_SfQRCodeGenerator_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.SfQRCodeGenerator.html#Syncfusion_Blazor_BarcodeGenerator_SfQRCodeGenerator_Width) properties of the barcode generator.

```cshtml
@using Syncfusion.Blazor.BarcodeGenerator

<SfQRCodeGenerator Width="200px" Height="150px"  Value="Syncfusion"></SfQRCodeGenerator>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrqsBCJpjmCuhGI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing the text

In barcode generators, you can customize the barcode text by using the display [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.QRCodeGeneratorDisplayText.html#Syncfusion_Blazor_BarcodeGenerator_QRCodeGeneratorDisplayText_Text) property.

```cshtml
@using Syncfusion.Blazor.BarcodeGenerator

<SfQRCodeGenerator Width="200px" Height="150px" Value="Syncfusion">
    <QRCodeGeneratorDisplayText Text="Text"></QRCodeGeneratorDisplayText>
</SfQRCodeGenerator>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtrKMVCTTXGflLco?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customizing the Text for QR Code in Blazor Barcode](images/blazor-barcode-qrcode-text-customization.png)

## Error Correction Level

The QR Barcode employs error correction to generate a series of error correction codewords which are added to the data code word sequence in order to enable the symbol to withstand damage without data loss. There are four user–selectable levels of error correction, as shown in the table, that offer the capability of recovery from the following amounts of damage. By default, the [Error correction level](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.ErrorCorrectionLevel.html) is Low.

Error Correction Level Table

|Error Correction Level|	Recovery Capacity % (approx.)|
|----------|--------------|
|L	|7|
|M	|15|
|Q	|25|
|H	|30|

```cshtml
<SfQRCodeGenerator Width="200px" Height="200px" ErrorCorrectionLevel="ErrorCorrectionLevel.Low" Value=https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.ErrorCorrectionLevel.html>
    <QRCodeGeneratorDisplayText Visibility="false"></QRCodeGeneratorDisplayText>
</SfQRCodeGenerator>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBKCVCzzDcveinV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## QR code with logo

The QR Code component supports embedding a logo image using the [ImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.QRCodeLogo.html#Syncfusion_Blazor_BarcodeGenerator_QRCodeLogo_ImageUrl) property within the [QRCodeLogo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.QRCodeLogo.html) element. This property is used to set the logo image in the QR barcode. By leveraging these functionalities, users can generate QR codes that seamlessly incorporate custom logos or images, resulting in a visually appealing and branded QR code experience.

The following code example demonstrates how to generate a QR barcode with a logo positioned at the center of it.

```cshtml
@using Syncfusion.Blazor.BarcodeGenerator

<SfQRCodeGenerator Width="200px" Height="150px" Value="https://www.syncfusion.com/blazor-components/blazor-barcode">
    <QRCodeGeneratorDisplayText Visibility="false"></QRCodeGeneratorDisplayText>
    <QRCodeLogo ImageUrl="images/barcode/syncfusion.png"></QRCodeLogo>
</SfQRCodeGenerator>

```

![QR barcode with logo in Blazor Barcode](images/blazor-barcode-qrcode-with-logo.png)

## Event

[OnValidationFailed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.SfQRCodeGenerator.html#Syncfusion_Blazor_BarcodeGenerator_SfQRCodeGenerator_OnValidationFailed) event in the [SfQRCodeGenerator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.SfQRCodeGenerator.html) is used to trigger when the input is an invalid string.

```cshtml
@using Syncfusion.Blazor.BarcodeGenerator

<SfQRCodeGenerator Width="200px" Height="150px" Value="Syncfusion" OnValidationFailed="@OnValidationFailed"></SfQRCodeGenerator>

@code
{
    public void OnValidationFailed(ValidationFailedEventArgs args)
    {
    }
}

```