---
layout: post
title: Exporting in Blazor Tree Grid Component | Syncfusion 
description: Learn about Exporting in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# PDF Export

PDF export allows exporting Tree Grid data to PDF document. You need to use the
 **PdfExport** method for exporting. To enable PDF export in the Tree Grid, set the [`AllowPdfExport`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Grids.EjsGrid~AllowPdfExport.html) as true.

{% aspTab template="tree-grid/pdf-export/export", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

## To customize PDF export

PDF export provides an option to customize mapping of Tree Grid to exported PDF document.

### File name for exported document

You can assign the file name for the exported document by defining **fileName** property in **PdfExportProperties**.

{% aspTab template="tree-grid/pdf-export/filename", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

### How to change page orientation

Page orientation can be changed Landscape(Default Portrait) for the exported document using the export properties.

{% aspTab template="tree-grid/pdf-export/orientation", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

### How to change page size

Page size can be customized for the exported document using the export properties.

Supported page sizes are:

* Letter
* Note
* Legal
* A0
* A1
* A2
* A3
* A5
* A6
* A7
* A8
* A9
* B0
* B1
* B2
* B3
* B4
* B5
* Archa
* Archb
* Archc
* Archd
* Arche
* Flsa
* HalfLetter
* Letter11x17
* Ledger

{% aspTab template="tree-grid/pdf-export/pagesize", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

### Export current page

PDF export provides an option to export the current page into PDF. To export current page, define the **exportType** to **CurrentPage**.

{% aspTab template="tree-grid/pdf-export/currentpage", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

### Export hidden columns

PDF export provides an option to export hidden columns of Tree Grid by defining the **includeHiddenColumn** as **true**.

{% aspTab template="tree-grid/pdf-export/hiddencolumns", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

### Theme

PDF export provides an option to include theme for exported PDF document.

To apply theme in exported PDF, define the **theme** in export properties.

{% aspTab template="tree-grid/pdf-export/theme", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

> By default, material theme is applied to exported PDF document.
