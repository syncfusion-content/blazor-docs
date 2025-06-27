---
layout: post
title: Open and save in Blazor Spreadsheet Component | Syncfusion
description: Checkout and learn here all about open and save in Syncfusion Blazor Spreadsheet component and more | Syncfusion.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Open and Save in Blazor Spreadsheet component

The **Open** and **Save** options in the Spreadsheet component enable efficient management of Excel files. These functionalities support opening existing Excel files for analysis and modification, as well as saving updates or new files to the system in compatible formats.

## Open
The Spreadsheet component can open an Excel document along with its data, styles, formats, and more. 

### Open an Excel file via the UI
To open an Excel document using the interface, select the `File > Open` option from the ribbon menu.

![UI showing file menu with open option](./images/file-open-feature.png)

![File explorer showing Excel file](./images/select-excel-file.png)

### Open an Excel file from a local path
The Syncfusion Blazor Spreadsheet component enables loading Excel files directly by converting them into byte arrays. This method is particularly effective for dynamically loading Spreadsheet content from a backend service.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<SfSpreadsheet DataSource="DataSourceBytes" >
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }
}

{% endhighlight %}
{% endtabs %}

### Open an Excel file from Base64 string data
Excel files can also be loaded by passing a Base64-encoded representation of the file. This approach is effective for dynamically loading content from a database or API without exposing the file path.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

 <SfSpreadsheet DataSource="DataSourceBytes" >
    <SpreadsheetRibbon></SpreadsheetRibbon>
 </SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }

    protected override void OnInitialized()
    {
        string base64String = "Enter the base64 string data here";
        DataSourceBytes = Convert.FromBase64String(base64String);     
    }
}

{% endhighlight %}
{% endtabs %}

### Supported file formats
The following format is supported for opening:
* MS Excel (.xlsx)
* MS Excel 97-2003 (.xls)

## Save
The Spreadsheet component can save data, styles, formatting, and additional content as an Excel file.

### Save an Excel file using UI
To save the Spreadsheet content through the user interface, select the `File > Save As` option from the ribbon menu.

![UI showing file menu with save option](./images/file-save-feature.png)

![File explorer interface for saving a file](./images/file-save-dialogbox.png)

### Supported file formats
The following format is supported for saving:
* MS Excel (.xlsx)