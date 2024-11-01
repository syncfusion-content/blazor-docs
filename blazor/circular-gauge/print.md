---
layout: post
title: Print and Export in Blazor Circular Gauge Component | Syncfusion
description: Checkout and learn here all about Print and Export in Syncfusion Blazor Circular Gauge component and more.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Print and Export in Blazor Circular Gauge Component

## Print

To use the print functionality, you should set the [AllowPrint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AllowPrint) property to **true**. The rendered circular gauge can be printed directly from the browser by calling the method [print](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Print_System_Object_). You can get the Circular Gauge component object using `@ref="Gauge"`

```cshtml
@using Syncfusion.Blazor.CircularGauge

<button @onclick="PrintGauge">Print</button>
<SfCircularGauge @ref="Gauge" AllowPrint="true">
   <CircularGaugeAxes>
      <CircularGaugeAxis>
        <CircularGaugeAxisMajorTicks Height="10" Width="3"
                                     Position="Position.Inside">
        </CircularGaugeAxisMajorTicks>
        <CircularGaugeAxisMinorTicks Height="5" Width="2"
                                     Position="Position.Inside">
        </CircularGaugeAxisMinorTicks>
        <CircularGaugePointers>
            <CircularGaugePointer Value="40"></CircularGaugePointer>
        </CircularGaugePointers>
      </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>

@code {
    SfCircularGauge Gauge;
    void PrintGauge()
    {
        this.Gauge.Print();
    }
}
```

![Printing in Blazor Circular Gauge](./images/blazor-circulargauge-printing.png)

## Export

### Image export

To use the image export functionality, you should set the [AllowImageExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AllowImageExport) property to **true**. The rendered circular gauge can be exported as an image using the [export](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Export_Syncfusion_Blazor_CircularGauge_ExportType_System_String_System_Object_System_Nullable_System_Boolean__) method. The method requires two parameters: image type and file name. The circular gauge can be exported as an image in the following formats.

* JPEG
* PNG
* SVG

```cshtml
@using Syncfusion.Blazor.CircularGauge

<button @onclick="ExportGauge">Export</button>
<SfCircularGauge @ref="Gauge" AllowImageExport="true">
</SfCircularGauge>

@code {
    SfCircularGauge Gauge;
    void ExportGauge()
    {
        this.Gauge.Export(ExportType.PNG, "CircularGauge");
    }
}
```

![Exporting in Blazor Circular Gauge](./images/blazor-circulargauge-exporting.png)

### PDF export

To use the PDF export functionality, you should set the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AllowPdfExport) property to **true**. The rendered circular gauge can be exported as PDF using the [export](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Export_Syncfusion_Blazor_CircularGauge_ExportType_System_String_System_Object_System_Nullable_System_Boolean__) method. The [export](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Export_Syncfusion_Blazor_CircularGauge_ExportType_System_String_System_Object_System_Nullable_System_Boolean__) method requires three parameters: file type, file name and orientation of the PDF document. The orientation setting is optional and "0" indicates portrait and "1" indicates landscape.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<button @onclick="ExportGauge">Export</button>
<SfCircularGauge @ref="Gauge" AllowPdfExport="true">
</SfCircularGauge>

@code {
    SfCircularGauge Gauge;
    void ExportGauge()
    {
        this.Gauge.Export(ExportType.PDF, "CircularGauge", 0);
    }
}
```

![PDF Export in Blazor Circular Gauge](./images/blazor-circulargauge-exporting.png)
