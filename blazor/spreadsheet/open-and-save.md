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
Loading Excel files into the Spreadsheet component preserves data, styles, formats, and other elements. Multiple methods exist for opening files, including user interface interactions and programmatic approaches.

### Open an Excel file via UI
To open an Excel document using the interface, select the `File > Open` option from the ribbon menu. A file explorer dialog appears, allowing selection of the desired Excel file for loading into the Spreadsheet component.

![UI showing file menu with open option](./images/file-open-feature.png)

![File explorer showing Excel file](./images/select-excel-file.png)

### Open an Excel file from a local path
Excel files can be loaded programmatically by converting them into byte arrays. This approach suits scenarios where files are retrieved from a backend service.

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
Excel files encoded as Base64 strings can be loaded into the Spreadsheet component. This method is suitable for scenarios involving data retrieval from databases or APIs.

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
The Spreadsheet component supports the following file formats for opening:
* MS Excel (.xlsx)
* MS Excel 97-2003 (.xls)

## Save
The Spreadsheet component enables saving of data, styles, formatting, and additional content as an Excel file. This functionality ensures that modifications are preserved in a compatible format.

### Save an Excel file using UI
To save the Spreadsheet content through the user interface, select the `File > Save As` option from the ribbon menu.

![UI showing file menu with save option](./images/file-save-feature.png)

![File explorer interface for saving a file](./images/file-save-dialogbox.png)

### Supported file formats
The Spreadsheet component supports saving files in the MS Excel (.xlsx) format.

### Protection with save operations
Integration of sheet or workbook protection with save operations ensures data security. Protection settings restrict unauthorized modifications while preserving the configured settings in the saved Excel file.

N> To know more about protection, refer [here](https://blazor.syncfusion.com/documentation/spreadsheet/protection#protect-sheet).