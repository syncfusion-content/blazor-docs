---
layout: post
title: Excel Export in Blazor Tree Grid Component | Syncfusion 
description: Learn about Excel Export in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Excel export

The excel export allows exporting Tree Grid data to Excel document. You need to use the
 **ExcelExport** method for exporting. To enable Excel export in the Tree Grid, set the [`AllowExcelExport`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid%601~AllowExcelExport.html) property as true.

{% aspTab template="tree-grid/excel-export/export", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

## To customize excel export

The excel export provides an option to customize mapping of the Tree Grid to excel document.

### Export current page

The excel export provides an option to export the current page into excel. To export current page, define **exportType** to **CurrentPage**.

{% aspTab template="tree-grid/excel-export/currentpage", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

### Export hidden columns

The excel export provides an option to export hidden columns of Tree Grid by defining **includeHiddenColumn** as **true**.

{% aspTab template="tree-grid/excel-export/hiddencolumns", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

### Theme

The excel export provides an option to include theme for exported excel document.

To apply theme in exported Excel, define the **theme** in export properties.

{% aspTab template="tree-grid/excel-export/theme", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

> By default, material theme is applied to exported excel document.

### File name for exported document

You can assign the file name for the exported document by defining **fileName** property in excel export properties.

{% aspTab template="tree-grid/excel-export/filename", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

### To persist collapsed state

You can persist the collapsed state in the exported document by defining **IsCollapsedStatePersist** property as true in **TreeGridExcelExportProperties** parameter of [`ExcelExport`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ExcelExport_Syncfusion_Blazor_Grids_ExcelExportProperties_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method.

{% aspTab template="tree-grid/excel-export/collapsedstate", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

### Limitations

Microsoft Excel permits up to seven nested levels in outlines. So that in the Tree Grid we can able to provide only up to seven nested levels and if it exceeds more than seven levels then the document will be exported without outline option. Please refer the [Microsoft Limitation](https://docs.microsoft.com/en-us/sql/reporting-services/report-builder/exporting-to-microsoft-excel-report-builder-and-ssrs?view=sql-server-2017#ExcelLimitations)
