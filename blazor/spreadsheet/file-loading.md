---
layout: post
title: Getting Started with Blazor Spreadsheet Component | Syncfusion
description: Checkout and learn about getting started with Blazor Spreadsheet component in Blazor WebAssembly Application.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# File Loading approaches in Blazor Spreadsheet

File loading is a fundamental technique that empowers the Syncfusion Blazor Spreadsheet to integrate file data into its interface, enabling the creation of dynamic and interactive Spreadsheet. This feature is particularly valuable when working with large datasets or when data needs to be fetched remotely.

It supports two kinds of file loading approaches:

* File path
* Base64 String

## Loading File From a Local Path

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
        string filePath = "//file path";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }
}

{% endhighlight %}
{% endtabs %}

## Loading File Using a Base64 String

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
        string base64String = "//base64String";
        DataSourceBytes = Convert.FromBase64String(base64String);     
    }
}

{% endhighlight %}
{% endtabs %}