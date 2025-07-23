---
layout: post
title: Hyperlink in the Blazor Spreadsheet component | Syncfusion
description: Checkout and learn how to insert, edit, and remove hyperlink in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Hyperlink in Blazor Spreadsheet component

Hyperlinks in the Blazor Spreadsheet enable interactive navigation within and outside spreadsheets. This feature creates clickable links that connect to external web URLs, specific cells within the current worksheet, or cells in other worksheets.


Enable or disable hyperlink functionality in the Spreadsheet using AllowHyperlink property. The default value for the [AllowHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowHyperLink) property is **true**.

N> When `AllowHyperlink` is set to **false**, the hyperlink options are removed from the interface (ribbon and context menu), but existing hyperlinks will still function.


## Insert hyperlink

Hyperlink make worksheet cells clickable and connected to:
* **Web URLs**: Link to websites like https://www.syncfusion.com
* **Cell references**: Link to another cell in the same sheet, like `A1` or `B5:C10`
* **Sheet references**: Link to cells in other sheets, like `Sheet2!A1`

Adding hyperlinks creates interactive elements that improve navigation and connect data to external sources. Linked cells appear with special formatting (usually underlined and colored text) to indicate they are clickable.


### Insert hyperlink via UI

Hyperlink can be inserted through the Spreadsheet UI using any of the following methods:

**Using the Ribbon**

* Select the cell or range for adding a hyperlink
* Click the **Insert** tab in the Ribbon toolbar
* Click the **Link** option
* Complete the hyperlink information in the dialog
* Click **Insert button** to add hyperlink to the selected cell or range

![Insert tab in the Ribbon toolbar with the Link option highlighted](images/insert-hyperlink-using-ribbon.gif)

**Using the Context Menu**

* Right-click on the selected cell
* Choose **Hyperlink** from the context menu
* Complete the hyperlink information in the dialog
* Click **Insert button** to add hyperlink to the selected cell or range

![Hyperlink dialog box displaying options for inserting a web URL](images/insert-hyperlink-using-contextmenu.gif)

N> Keyboard shortcut `Ctrl + K` can be used to quickly open the insert **Hyperlink** dialog on the active cell without using the UI elements. This shortcut works regardless of whether accessing hyperlink functionality through the ribbon or context menu.


### Insert hyperlink programmatically

Hyperlink can be added programmatically using the [AddHyperlinkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AddHyperlinkAsync_System_String_System_String_System_String_) method. This method allows adding hyperlinks to cells or ranges without using the UI.

The available parameters in the `AddHyperlinkAsync()` method are:

| Parameter | Type | Description |
| -- | -- | -- |
| hyperlink | string | The URL or cell reference destination. Can be a web URL (with or without protocol), a cell reference, or a sheet reference. |
| cellAddress | string | The cell or range where the hyperlink should be added. Can be a single cell or a range of cells. |
| displayText | string (optional) |  The text to display in the cell. If omitted, the hyperlink address is used as display text. For cells with existing values, this parameter will override the existing text. |


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="AddHyperlinkHandler">Add Hyperlink</button>
<SfSpreadsheet @ref="spreadsheetInstance" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet spreadsheetInstance;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task AddHyperlinkHandler()
    {
	    await spreadsheetInstance.AddHyperlinkAsync("https://www.syncfusion.com/blazor-components/blazor-spreadsheet","A2:A5");
    }
}

{% endhighlight %}
{% endtabs %}

**Advanced Usage of AddHyperlinkAsync()**

The [AddHyperlinkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AddHyperlinkAsync_System_String_System_String_System_String_) method is flexible and handles various scenarios beyond basic usage. Below are some special cases and behaviors to be aware of:

{% tabs %}
{% highlight razor%}
// Add a web URL hyperlink to a single cell.
await spreadsheetInstance.AddHyperlinkAsync("https://www.syncfusion.com", "A1", "Syncfusion Website");

// Add a cell reference hyperlink.
await spreadsheetInstance.AddHyperlinkAsync("D10", "B5", "Go to Summary");

// Add a sheet reference hyperlink.
await spreadsheetInstance.AddHyperlinkAsync("Sheet2!B5", "A2", "View Details");

// Add a hyperlink to multiple cells.
await spreadsheetInstance.AddHyperlinkAsync("https://www.syncfusion.com", "A2:A5", "Documentation");

// Web URLs without protocol are automatically prefixed with https://.
await spreadsheetInstance.AddHyperlinkAsync("syncfusion.com", "A1");

// When displayText is omitted, the hyperlink is used as display text.
await spreadsheetInstance.AddHyperlinkAsync("https://www.syncfusion.com", "B1");

// Adding hyperlink to a non-existent sheet reference will not cause error but the link may not work correctly when clicked.
await spreadsheetInstance.AddHyperlinkAsync("NonExistentSheet!A1", "C1", "Invalid Sheet");

// Adding hyperlink to cells with existing values will update the display text.if displayText parameter is provided.
await spreadsheetInstance.AddHyperlinkAsync("https://www.syncfusion.com", "D1", "New Text");

{% endhighlight %}
{% endtabs %}


N> The [AddHyperlinkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AddHyperlinkAsync_System_String_System_String_System_String_) method won't work if the `AllowHyperlink` property is set to **false**.

## Edit hyperlink

Hyperlinks in a spreadsheet can be editable to update the destination or the display text. This includes:

* **Changing the Web URL**: Update the hyperlink to point to a different website or online resource.

* **Editing the Display Text**: Change the text in the cell without affecting the link destination.

* **Updating Cell References**: Modify the hyperlink to point to a different cell in the same sheet (e.g., from A1 to B5).

* **Linking to Another Sheet**: Redirect the hyperlink to a different sheet by modifying the sheet name in the reference (e.g., from Sheet1!A1 to Sheet2!C3).

### Edit hyperlink via UI

Hyperlink can be edited through the Spreadsheet UI using any of the following methods:

**Using the Ribbon**

* Select the cell containing the hyperlink
* Click the **Insert** tab in the Ribbon toolbar
* Click the **Link** option
* Make changes to the hyperlink information in the dialog
* Click **Update** to apply changes

**Using the Context Menu**

* Right-click on the cell containing the hyperlink
* Choose **Edit Hyperlink** from the context menu
* Make changes to the hyperlink information in the dialog
* Click **Update** to apply changes


![Edit hyperlink dialog with options to modify an existing link](images/edit-hyperlink-dialogbox.png)

> The keyboard shortcut `Ctrl + K` quickly opens the Edit Hyperlink dialog without going through menus.

> When editing hyperlinks to other sheets, make sure the target sheet actually exists in your workbook. Links to non-existent sheets will cause errors when clicked.

## Remove hyperlink

Removing hyperlinks disconnects cells from their linked destinations while preserving the display text. This operation removes only the link functionality, not the content itself.

### Remove hyperlink via UI

To remove a hyperlink using the Spreadsheet interface:

**Using the Context Menu**

* Select the cell containing the hyperlink to be removed
* Right-click the cell to display the context menu
* Click **Remove Hyperlink** option from the context menu

![Remove Hyperlink option in the cell context menu](images/remove-hyperlink.png)

N> Select multiple cells with hyperlinks at once (like `A1:D5`) to remove all hyperlinks in a single operation. This saves time when cleaning up many hyperlinks.

### Remove hyperlink programmatically

Hyperlinks can be removed programmatically using the [RemoveHyperlinkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_RemoveHyperlinkAsync_System_String_) method. This method removes hyperlink functionality from specified cells or ranges.

The available parameters in the `RemoveHyperlinkAsync()` method are:

| Parameter | Type | Description |
| -- | -- | -- |
| cellAddress | string | The cell or range from which to remove hyperlinks. |

**Advanced Usage of RemoveHyperlinkAsync()**

{% tabs %}
{% highlight razor%}

// Remove hyperlink from a single cell
await spreadsheetInstance.RemoveHyperlinkAsync("A1");

// Remove hyperlinks from a range of cells
await spreadsheetInstance.RemoveHyperlinkAsync("A1:C5");

// Remove hyperlink from a cell in a specific sheet
await spreadsheetInstance.RemoveHyperlinkAsync("Sheet2!D10");

// Remove hyperlinks from a range in a specific sheet
await spreadsheetInstance.RemoveHyperlinkAsync("Sheet3!A1:A20");

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="RemoveHyperlinkHandler">Remove Hyperlink</button>
<SfSpreadsheet @ref="spreadsheetInstance" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet spreadsheetInstance;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task RemoveHyperlinkHandler()
    {
	    await spreadsheetInstance.RemoveHyperlinkAsync("A2:A5");
    }
}

{% endhighlight %}
{% endtabs %}

N> The [RemoveHyperlinkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_RemoveHyperlinkAsync_System_String_)  is safe for any cell selection. Cells without hyperlinks are simply skipped with no errors.

## Hyperlink Events

The Blazor Spreadsheet provides events that are triggered during hyperlink operations such as [HyperlinkCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.HyperlinkCreatingEventArgs.html), [HyperlinkCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.HyperlinkCreatedEventArgs.html), and [HyperlinkClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.HyperlinkClickEventArgs.html). These events can be used to perform any custom actions before and after hyperlink operations.

* **HyperlinkCreating** - The [HyperlinkCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.HyperlinkCreatingEventArgs.html) event is triggered before a hyperlink is created. It provides ways to modify or validate the hyperlink before creation.

* **HyperlinkCreated** - The [HyperlinkCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.HyperlinkCreatedEventArgs.html) event is triggered after a hyperlink has been successfully created. It provides information about the newly added hyperlink.

* **HyperlinkClick** - The [HyperlinkClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.HyperlinkClickEventArgs.html)  event is triggered when a hyperlink is clicked. It enables custom navigation or other actions when hyperlinks are interacted with.

**HyperlinkCreating Event**

The `HyperlinkCreating` event is triggered before a hyperlink is created. This event provides details about the hyperlink and allows for modification or cancellation if required.

**Event Arguments**

The `HyperlinkCreatingEventArgs` includes the following properties:

| Event Arguments | Description |
|----------------|-------------|
| Hyperlink | The URL or cell reference that will be used for the hyperlink. This can be modified to change the destination. |
| CellAddress | The address of the cell where the hyperlink will be added. This can be modified to change the target cell. |
| DisplayText | The text that will be displayed in the cell. This can be modified to customize the visible text. |
| Cancel | Set to true to prevent the hyperlink from being created. Default is false. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<SfSpreadsheet @ref="spreadsheetInstance" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
    <SpreadsheetEvents HyperlinkCreating="OnHyperlinkCreating" ></SpreadsheetEvents>
</SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet spreadsheetInstance;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public void OnHyperlinkCreating(HyperlinkCreatingEventArgs args)
    {
        // Prevent creation of hyperlinks to specific domains
        if (args.Hyperlink?.StartsWith("http://example.com") == true)
        {
            args.Cancel = true;
        }

        // Customize display text if empty
        if (string.IsNullOrEmpty(args.DisplayText))
        {
            args.DisplayText = "Click here";
        }

        // Convert simple domain names to full URLs
        if (args.Hyperlink?.StartsWith("www.") == true)
        {
            args.Hyperlink = "https://" + args.Hyperlink;
        }
    }
}

{% endhighlight %}
{% endtabs %}

**HyperlinkCreated Event**

The `HyperlinkCreated` event is triggered after a hyperlink has been successfully created. It provides information about the newly added hyperlink.

**Event Arguments**

The [HyperlinkCreatedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.HyperlinkCreatedEventArgs.html) includes the following properties:

| Event Arguments | Description |
|----------------|-------------|
| Hyperlink | The URL or cell reference of the created hyperlink (read-only). |
| CellAddress | The address of the cell where the hyperlink was added (read-only). |
| DisplayText | The text displayed in the cell for the hyperlink (read-only). |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<SfSpreadsheet @ref="spreadsheetInstance" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
    <SpreadsheetEvents HyperlinkCreated="OnHyperlinkCreated" ></SpreadsheetEvents>
</SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet spreadsheetInstance;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public void OnHyperlinkCreated(HyperlinkCreatedEventArgs args)
    {
        // Log information about the newly created hyperlink.
        Console.WriteLine($"Hyperlink created at {args.CellAddress} pointing to {args.Hyperlink}");
        Console.WriteLine($"Display text: {args.DisplayText}");
    }
}

{% endhighlight %}
{% endtabs %}

**HyperlinkClick Event**

The `HyperlinkClick` event is triggered when a hyperlink is clicked. It enables custom navigation or other actions when hyperlinks are interacted with.

**Event Arguments**

The [HyperlinkClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.HyperlinkClickEventArgs.html) includes the following properties:

| Event Arguments | Description |
|----------------|-------------|
| Hyperlink | The URL or cell reference of the clicked hyperlink (read-only). |
| CellAddress | The address of the cell containing the clicked hyperlink (read-only). |
| DisplayText | The displayed text of the clicked hyperlink (read-only). |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<SfSpreadsheet @ref="spreadsheetInstance" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
    <SpreadsheetEvents HyperlinkClick="OnHyperlinkClick" ></SpreadsheetEvents>
</SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet spreadsheetInstance;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public void OnHyperlinkClick(HyperlinkClickEventArgs args)
    {
        // Track hyperlink usage.
        Console.WriteLine($"Hyperlink clicked at {args.CellAddress}: {args.Hyperlink}");
        
        // Handle special URLs or sheet references differently.
        if (args.Hyperlink.StartsWith("https://restricted"))
        {
            // Implement custom handling for restricted sites.
            // For example, showing a warning or redirecting elsewhere.
        }
    }
}

{% endhighlight %}
{% endtabs %}