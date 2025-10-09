---
layout: post
title: Print and Export in Blazor Circular Gauge Component | Syncfusion
description: Check out and learn how to configure and utilize Print and Export feature in the Syncfusion Blazor Circular Gauge component.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Print and Export in Blazor Circular Gauge Component

## Print

Enable printing by setting the [AllowPrint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AllowPrint) property to **true**. The rendered circular gauge can be printed directly from the browser by calling the [Print](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Print_System_Object_) method. Access the Circular Gauge instance using `@ref="Gauge"`.

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
            <CircularGaugePointer></CircularGaugePointer>
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

Enable image export by setting the [AllowImageExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AllowImageExport) property to **true**. The rendered circular gauge can be exported as an image using the [Export](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Export_Syncfusion_Blazor_CircularGauge_ExportType_System_String_System_Object_System_Nullable_System_Boolean__) method. The method requires the image type and file name. Supported image formats:

* JPEG
* PNG
* SVG

```cshtml

@using Syncfusion.Blazor.CircularGauge

<button @onclick="ExportGauge">Export</button>
<SfCircularGauge @ref="Gauge" AllowImageExport="true">
   <CircularGaugeAxes>
      <CircularGaugeAxis>
        <CircularGaugeAxisMajorTicks Height="10" Width="3"
                                     Position="Position.Inside">
        </CircularGaugeAxisMajorTicks>
        <CircularGaugeAxisMinorTicks Height="5" Width="2"
                                     Position="Position.Inside">
        </CircularGaugeAxisMinorTicks>
        <CircularGaugePointers>
            <CircularGaugePointer></CircularGaugePointer>
        </CircularGaugePointers>
      </CircularGaugeAxis>
    </CircularGaugeAxes>
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

Enable PDF export by setting the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AllowPdfExport) property to **true**. The rendered circular gauge can be exported to PDF using the [Export](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Export_Syncfusion_Blazor_CircularGauge_ExportType_System_String_System_Object_System_Nullable_System_Boolean__) method. The method accepts the file type, file name, and an optional orientation parameter (0 for portrait, 1 for landscape).

```cshtml

@using Syncfusion.Blazor.CircularGauge

<button @onclick="ExportGauge">Export</button>
<SfCircularGauge @ref="Gauge" AllowPdfExport="true">
  <CircularGaugeAxes>
      <CircularGaugeAxis>
        <CircularGaugeAxisMajorTicks Height="10" Width="3"
                                     Position="Position.Inside">
        </CircularGaugeAxisMajorTicks>
        <CircularGaugeAxisMinorTicks Height="5" Width="2"
                                     Position="Position.Inside">
        </CircularGaugeAxisMinorTicks>
        <CircularGaugePointers>
            <CircularGaugePointer></CircularGaugePointer>
        </CircularGaugePointers>
      </CircularGaugeAxis>
    </CircularGaugeAxes>
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