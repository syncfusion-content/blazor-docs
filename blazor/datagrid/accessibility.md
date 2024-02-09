---
layout: post
title: Accessibility in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Accessibility in Blazor Grid component

The Grid component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

## WAI-ARIA attributes

The Grid component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/grid/) patterns to meet the accessibility. The following ARIA attributes are used in the Grid component:

| Attributes | Purpose |
| --- | --- |
| `role=grid` | To represent the element containing the grid component. |
| `role=row` | To represent the element containing the cells of the row in the grid. |
| `role=rowgroup` | To represent the group of rows in the grid. |
| `role=columnheader` | To represent the cell in a row contains header information for a column in the grid. |
| `role=gridcell` | To represent a cell in the grid component. |
| `role=button` | To represent the element that acts as a button in the grid. |
| `role=search` | To represent the element that acts as a search region in the grid. |
| `role=presentation` | To represent the element to be not available for accessibility concerns. |
| `role=navigation` | To represent the element containing pager elements to navigate from one page to another. |
| `aria-colindex` | Defines the column index of the column with respect to the total number of columns within the grid. |
| `aria-rowindex` | Defines row index of the row with respect to the total number of rows within the grid.  |
| `aria-rowspan` | Defines the number of rows spanned by a cell within the grid.  |
| `aria-colspan` | Defines the number of columns spanned by a cell within the grid. |
| `aria-rowcount` | Defines the total number of rows in the grid.  |
| `aria-colcount` | Defines the total number of columns in the grid. |
| `aria-selected` | Indicates the current "selected" state of the rows and cells in the grid. |
| `aria-expanded` | Indicate if the expand icon in the hierarchy grid or grouped grid or detail grid is expanded or collapsed |
| `aria-sort` | Indicates whether the data in the grid are sorted in ascending or descending order. |
| `aria-busy` | Indicates an element is being modified and that assistive technologies may want to wait until the changes are complete before informing the user about the update. |
| `aria-owns` | Identifies an element in order to define a visual, functional, or contextual relationship between a parent and its child elements. |
| `aria-hidden` | Hides the element from accessibility concerns. |
| `aria-labelledby` | Provides an accessible name for the checkbox labels in excel filter, checkbox filter and column chooser dialog.  |
| `aria-describedby` | Provides an description about the features enabled in the header when the grid header cell is focused. |

## Keyboard interaction

The Grid component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Grid component.

<b>Pager</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Tab</kbd> | <kbd>Tab</kbd> | Focus on the next pager item.
<kbd>Shift + Tab</kbd> | <kbd>Shift + Tab</kbd> | Focus on the previous pager item.
<kbd>Enter / Space</kbd> | <kbd>Enter / Space</kbd> | Select the currently focused page.
<kbd>PageUp / Left Arrow</kbd> | <kbd>Left Arrow</kbd> | Navigate to previous page.
<kbd>PageDown / Right Arrow</kbd> | <kbd>Right Arrow</kbd> | Navigate to next page.
<kbd>Home / Ctrl + Alt + PageUp</kbd> | <kbd>Fn + Left Arrow</kbd> | Navigate to first page.
<kbd>End / Ctrl + Alt + PageDown</kbd> | <kbd>Fn + Right Arrow</kbd> | Navigate to last page.

<b>Focus Elements</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Home</kbd> | <kbd>Fn + Left Arrow</kbd> | Moves the focus to the first cell of the focused row.
<kbd>End</kbd> | <kbd>Fn + Right Arrow</kbd> | Moves the focus to the last cell of the focused row.
<kbd>Ctrl + Home</kbd> | <kbd>Command + Fn + Left Arrow</kbd> | Moves the focus to the first Cell of the first row in the grid.
<kbd>Ctrl + End</kbd> | <kbd>Command +  Fn + Right Arrow</kbd> | Moves the focus to the last Cell of the last row in the grid.
<kbd>Up Arrow</kbd> | <kbd>Up Arrow</kbd> | Moves the cell focus upward from the focused cell.
<kbd>Down Arrow</kbd> | <kbd>Down Arrow</kbd> |  Moves the cell focus downward from the focused cell.
<kbd>Right Arrow</kbd> | <kbd>Right Arrow</kbd> | Moves the cell focus right side from the focused cell.
<kbd>Left Arrow</kbd> | <kbd>Left Arrow</kbd> |  Moves the cell focus left side from the focused cell.
<kbd>Alt + J</kbd> | <kbd>Alt + J</kbd> | Moves the focus to the entire grid.
<kbd>Alt + W</kbd> | <kbd>Alt + W</kbd> | Move the focus to the grid content element.

<b>Selection</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Up Arrow</kbd> | <kbd>Up Arrow</kbd> | Moves up a row/cell selection from the selected row/cell.
<kbd>Down Arrow</kbd> | <kbd>Down Arrow</kbd> | Moves down a row/cell selection from the selected row/cell.
<kbd>Right Arrow</kbd> | <kbd>Right Arrow</kbd> | Moves to the right cell selection from the selected cell.
<kbd>Left Arrow</kbd> | <kbd>Left Arrow</kbd> | Moves to the left cell selection from the selected cell.
<kbd>Shift + Up Arrow</kbd> | <kbd>Shift + Up Arrow</kbd> | Extends the row/cell selection upwards from the selected row/cell.
<kbd>Shift + Down Arrow</kbd> | <kbd>Shift + Down Arrow</kbd> | Extends the row/cell selection downwards from the selected row/cell.
<kbd>Shift + Right Arrow</kbd> | <kbd>Shift + Right Arrow</kbd> | Extends the cell selection to the right side from the selected cell.
<kbd>Shift + Left Arrow</kbd> | <kbd>Shift + Left Arrow</kbd> | Extends the cell selection to the left side from the selected cell.
<kbd>Enter</kbd> | <kbd>Enter</kbd> | Moves the row/cell selection downward from the selected cell/row.
<kbd>Shift + Enter</kbd> | <kbd>Shift + Enter</kbd> | Moves the row/cell selection upward.
<kbd>Esc</kbd> | <kbd>Esc</kbd> | Deselects all the selected row/cells.
<kbd>Ctrl + A</kbd> | <kbd>Ctrl + A</kbd> | Select all the row/cells in the current page.

<b>Grouping</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Ctrl + Up Arrow</kbd> | <kbd>Command + Up Arrow</kbd> | Collapses all the visible groups.
<kbd>Ctrl + Down Arrow</kbd> | <kbd>Command + Down Arrow</kbd> | Expands all the visible groups.
<kbd>Ctrl + Space</kbd> | <kbd>Ctrl + Space</kbd> | Performs grouping when focused on a header element.
<kbd>Enter</kbd> | <kbd>Enter</kbd> | If the current cell is an expand/collapse cell then expands/collapses the current group/detailrow/childgrid.

<b>Print</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Ctrl + P</kbd> | <kbd>Command + P</kbd>| Prints the Grid.

<b>Clipboard</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Ctrl + C</kbd> | <kbd>Command + C</kbd> | Copies selected rows or cells data into the clipboard.
<kbd>Ctrl + Shift + H</kbd> | <kbd>Ctrl + Shift + H</kbd> | Copies selected rows or cells data with header into clipboard

<b>Editing</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>F2</kbd> | <kbd>F2</kbd> | Starts editing of selected row if Mode is Normal/Dialog or Starts editing of selected cell if Mode is Batch.
<kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves the current form it the Mode is Normal or Dialog / Saves the current cell and starts editing the next row cell if Mode is Batch.
<kbd>Insert</kbd> | <kbd>Ctrl + Command + Enter<kbd> | Creates a new add form depending on the NewRowPosition.
<kbd>Delete</kbd> | <kbd>Delete</kbd> | Deletes the current selected record.
<kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigates to the next editable cell if the Mode is Normal or Dialog / Saves the current cell and starts editing the next cell is Mode is Batch.
<kbd>Shift + Tab</kbd> | <kbd>Shift + Tab</kbd> | Navigates to the previous editable cell if the Mode is Normal or Dialog / Saves the current cell and starts editing the previous cell is Mode is Batch.
<kbd>Shift + Enter</kbd> | <kbd>Shift + Enter</kbd> | Saves the current cell and starts editing the previous row cell if Mode is Batch.

<b>Filtering</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Alt + Down arrow</kbd> | <kbd>Alt + Down arrow</kbd> | Opens the filter menu(excel, menu and checkbox filter) when its header element is in focused state.

<b>Column Menu</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Alt + Down arrow</kbd> | <kbd>Alt + Down arrow</kbd> | Opens column menu when its header element is in focused state.

<b>Reordering</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Ctrl + left arrow or right arrow</kbd> | <kbd>Command  + left arrow or right arrow</kbd> | Reorders the focused header column to the left or right side.

<b>Sorting</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs sorting(ascending/descending) on a column when its header element is in focused state.
<kbd>Ctrl + Enter</kbd> | <kbd>Command + Enter</kbd> | Performs multi-sorting on a column when its header element is in focused state.
<kbd>Shift + Enter</kbd> | <kbd>Shift + Enter</kbd> | Clears sorting for the focused header column.

<br>

> * The <kbd>Command</kbd> and <kbd>Control</kbd> keys on Mac devices can be interchanged. When this switch occurs, use the <kbd>Command</kbd> key in place of the <kbd>Control</kbd> key and the <kbd>Control</kbd> key in place of the <kbd>Command</kbd> key for the above listed key interactions with Mac devices. For example, after switching the keys to group the columns when the header element is focused use <kbd>Command + Space</kbd> and for expanding the visible groups use <kbd>Ctrl + Down Arrow</kbd>.

### Custom shortcut keys to perform grid actions

The Syncfusion Blazor Grid component enables you to enhance the usablity of keyboard shortcuts for various grid actions and navigation. In addition to the built-in keyboard navigation capabilities, you can implement custom keyboard shortcuts to execute specific actions.

To achieve this, you can utilize the `onkeydown` event of the grid. This event is triggered for every key press, allowing you to customize the behavior based on the pressed key.

The following example demonstrates how to perform grid actions using shortcut keys through the `onkeydown` event. Within the event, define the following custom shortcuts to perform various grid actions:

* Pressing N adds a new record.
* Pressing Ctrl + S save a record by invoking endEdit.
* Pressing Ctrl + D deletes a record.
* Pressing Ctrl + A selects all rows.
* Pressing Ctrl + G groups the grid by a specified column.

You can add more custom shortcuts and actions as needed to enhance the functionality of your Syncfusion Blazor Grid component.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" @ref="Grid" AllowGrouping="true" @onkeydown="Keydown" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" Height="267px">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData> Grid;

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
      public async Task Keydown(KeyboardEventArgs args)
    {
        string key = args.Key.ToLower();

        switch (key)
        {
            case "n":

                await Grid.AddRecordAsync();
                break;
            case "s":
                if (args.CtrlKey)
                {
                    await Grid.EndEditAsync();
                }
                break;
            case "d":
                if (args.CtrlKey)
                {
                    await Grid.DeleteRecordAsync();
                }
                break;
            case "a":
                if (args.CtrlKey)
                {
                    await Grid.SelectRowsByRangeAsync(0);
                }
                break;
            case "g":
                if (args.CtrlKey)
                {
                    await Grid.GroupColumnAsync("CustomerID");
                }
                break;
            default:
               
                break;
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();

        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerID, string ShipCountry)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCountry = ShipCountry;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Australia"));
                    Orders.Add(new OrderData(10249, "TOMSP", "United States"));
                    Orders.Add(new OrderData(10250, "HANAR", "Switzerland"));
                    Orders.Add(new OrderData(10251, "VICTE", "Germany"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Brazil"));
                    Orders.Add(new OrderData(10253, "HANAR", "Germany"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Australia"));
                    Orders.Add(new OrderData(10255, "RICSU", "Denmark"));
                    Orders.Add(new OrderData(10256, "WELLI", "United States"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBpNBDEAcdTJNTv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Ensuring accessibility

The Grid component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the Grid component is shown in the following sample. Open the [sample](https://blazorplayground.syncfusion.com/embed/BZVJNrDOzLFrMLUn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5) in a new window to evaluate the accessibility of the Grid component with accessibility tools.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVJNrDOzLFrMLUn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

