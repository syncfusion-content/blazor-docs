---
layout: post
title: Chart Print in Blazor Chart Component | Syncfusion 
description: Learn about Chart Print in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

---
title: "Print & Export in Blazor Charts component | Syncfusion"

component: "Charts"

description: "Learn here all about Print & Export of Syncfusion Charts (SfCharts) component and more."
---

# Print & Export in Blazor Charts (SfCharts)

## Print

The [`Print`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Print) method can be used to print a rendered chart directly from the browser. This method accepts an array of elements' ID or a single element. By default, it picks a chart element.

{% aspTab template="chart/getting-started/print", sourceFiles="print.razor" %}

{% endaspTab %}

## Export

Using the [`Export`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Export_Syncfusion_Blazor_Charts_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) method in chart, the rendered chart can be exported to [`JPEG`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_JPEG), [`PNG`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PNG), [`SVG`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_SVG), or [`PDF`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PDF) format. [`Export`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html) Type for format and `FileName` for result are the input parameters for this method.

The optional parameters for this method are,
* `Orientation` - Specifies the portrait or landscape orientation of the page.
* `AllowDownload` - Specifies whether to download or not.

{% aspTab template="chart/getting-started/export", sourceFiles="export.razor" %}

{% endaspTab %}

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)