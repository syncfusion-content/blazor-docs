---
layout: post
title: Print and export in the Blazor Range Selector component | Syncfusion
description: Learn here all about print and export of the Syncfusion Blazor Range Selector (SfRangeNavigator) component and more.
platform: Blazor
control: Range Selector
documentation: ug
---

# Print and export in the Blazor Range Selector (SfRangeNavigator)

## Print

The rendered Range Selector can be printed directly from the browser by calling the public method [`Print`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Print).

{% aspTab template="range-navigator/print/print", sourceFiles="print.razor" %}

{% endaspTab %}

## Export

The rendered Range Selector can be exported to **JPEG**, **PNG**, **SVG**, or **PDF** format by using the [`Export`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Export_Syncfusion_Blazor_Charts_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) method in the Range Selector. This method contains the following parameters:

* **Type** - To specify the export type. The component can be exported to **JPEG**, **PNG**, **SVG**, or **PDF** format.
* **File name** - To specify the file name to export.
* **Orientation** - To specify the orientation type. This is applicable only for PDF export type. It is an optional parameter.

{% aspTab template="range-navigator/print/export", sourceFiles="export.razor" %}

{% endaspTab %}