---
layout: post
title: Open and save in Blazor Spreadsheet Component | Syncfusion
description: Checkout and learn here all about open and save in Syncfusion Blazor Spreadsheet component and more | Syncfusion.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Open and save in Blazor Spreadsheet component

The open and save features in our spreadsheet component enable users to efficiently manage their Excel files. These functionalities allow you to open existing excel files for analysis and modification, as well as save updates or new files to your system in compatible formats.

## Open an excel file from UI
The Spreadsheet component opens an Excel document with its data, style, format, and more. 

### User interface:
In user interface you can open an Excel document by clicking `File > Open` menu item in ribbon.

![the user interface option for opening Excel files](./images/file-open-feature.png)

![the user interface for selecting Excel file from file explorer](./images/select-excel-file.png)

### Open an excel file from local path

The Syncfusion Blazor Spreadsheet component allows you to load Excel files directly by converting the file into a byte array. This approach is useful when you want to load spreadsheet content dynamically from a backend.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

<SfSpreadsheet DataSource="DataSourceBytes" >
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }
    protected void Task OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }
}

{% endhighlight %}
{% endtabs %}

### Open an excel file from Base64 string data

You can also load files by passing a Base64-encoded Excel file. This is useful when you want to load files dynamically from a database or API without exposing the file path.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

 <SfSpreadsheet DataSource="DataSourceBytes" >
    <SpreadsheetRibbon></SpreadsheetRibbon>
 </SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }
    protected override void OnInitialized()
    {
        string base64String = "Enter your base64 string here";
        DataSourceBytes = Convert.FromBase64String(base64String);     
    }
}

{% endhighlight %}
{% endtabs %}

### Supported file formats
The following list of Excel file formats are supported in Spreadsheet:
* MS Excel (.xlsx)
* MS Excel 97-2003 (.xls)

## Save an excel file using UI
The Spreadsheet component saves its data, style, format, and more as Excel file document.

### User interface:
In user interface, you can save Spreadsheet data as Excel document by clicking `File > Save As` menu item in ribbon.

![The user interface option for saving Excel files](./images/file-save-feature.png)

![The user interface for entering a file name and saving it](./images/file-save-dialogbox.png)

### Supported file formats
* MS Excel (.xlsx)