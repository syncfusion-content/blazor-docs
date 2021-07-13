# Data Matrix generator

## Data Matrix

DataMatrix Barcode is a two dimensional barcode that consists of a grid of dark and light dots or blocks forming square or rectangular symbol. The data encoded in the barcode can either be numbers or alphanumeric. They are widely used in printed media such as labels and letters. You can read it easily with the help of a barcode reader and mobile phones.

```csharp
@using Syncfusion.Blazor.BarcodeGenerator

<SfDataMatrixGenerator Width="200" Height="150"  Value="SYNCFUSION"></SfDataMatrixGenerator>

```

![Data Matrix Generator](images/DataMatrix2.png)

## Customizing the Barcode color

A page or printed media with barcode often appears colorful in the background and surrounding region with other contents. In such cases the barcode can also be customized to suit the needs. You can achieve this by using the [`Forecolor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.SfBarcodeGenerator.html#Syncfusion_Blazor_BarcodeGenerator_SfBarcodeGenerator_ForeColor) property .

```csharp
@using Syncfusion.Blazor.BarcodeGenerator

<SfDataMatrixGenerator Width="200" ForeColor='red' Height="150" Value="SYNCFUSION"></SfDataMatrixGenerator>

```

![Customizing Barcode color in Data Matrix Generator](images/DataMatrix3.png)

## Customizing the Barcode dimension

The dimension of the barcode can be changed using the [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.SfBarcodeGenerator.html#Syncfusion_Blazor_BarcodeGenerator_SfBarcodeGenerator_Height) and [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.SfBarcodeGenerator.html#Syncfusion_Blazor_BarcodeGenerator_SfBarcodeGenerator_Width) property of the barcode generator.

```csharp
@using Syncfusion.Blazor.BarcodeGenerator

<SfDataMatrixGenerator Width="200" Height="150" Value="SYNCFUSION"></SfDataMatrixGenerator>

```

## Customizing the text

In barcode generators you can customize the barcode text by using the display [`Text`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BarcodeGenerator.DataMatrixGeneratorDisplayText.html#Syncfusion_Blazor_BarcodeGenerator_DataMatrixGeneratorDisplayText_Text) property .

```csharp
@using Syncfusion.Blazor.BarcodeGenerator

<SfDataMatrixGenerator Width="200" Height="150" Value="SYNCFUSION">
    <DataMatrixGeneratorDisplayText Text="Text" ></DataMatrixGeneratorDisplayText>
</SfDataMatrixGenerator>

```

![Customizing Text in Data Matrix Generator](images/DataMatrix4.png)

## Event

`OnValidationFailed` event in the `SfDataMatrixGenerator` is used to trigger when the input is an invalid string.

```csharp
@using Syncfusion.Blazor.BarcodeGenerator

<SfDataMatrixGenerator Width="200px" Height="150px" Value="SYNCFUSION" OnValidationFailed="@OnValidationFailed"></SfDataMatrixGenerator>

@code { public void OnValidationFailed(ValidationFailedEventArgs args)
            {
            } }


```