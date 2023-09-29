---
layout: post
title: Columns in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Columns in the Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---
# Columns in Blazor DataGrid Component

## Column types

The Syncfusion Blazor DataGrid component allows you to specify the type of data that a column binds using the [Column.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) property. The `Type` property is used to determine the appropriate [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format), such as [Number](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.ColumnType.html#Syncfusion_Blazor_QueryBuilder_ColumnType_Number) or [Date](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.ColumnType.html#Syncfusion_Blazor_QueryBuilder_ColumnType_Date), for displaying the column data. 

DataGrid supports the following column types:

* **String**: Represents a column that binds to string data. This is the default type if the `Type` property is not defined.
* **number**: Represents a column that binds to numeric data. It supports formatting options for displaying numbers.
* **Boolean**: Represents a column that binds to boolean data. It displays checkboxes for boolean values.
* **Date**: Represents a column that binds to date data. It supports formatting options for displaying dates.
* **Datetime**: Represents a column that binds to date and time data. It supports formatting options for displaying date and time values.
* **DateOnly**: Represents a column that binds to [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-7.0) data. It supports formatting options for displaying DateOnly values.

* **TimeOnly**: Represents a column that binds to [TimeOnly](https://learn.microsoft.com/en-us/dotnet/api/system.timeonly?view=net-7.0) data. It supports formatting options for displaying TimeOnly values.

* **Checkbox**: Represents a column that displays checkboxes.

> Blazor DataGrid Component supports `DateOnly` and  `TimeOnly` type in .NET 7 and above version only, even though it introduced in .NET 6 itself due to serialization problem.

Here is an example of how to specify column types in a grid using the types mentioned above.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Type="ColumnType.Number" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Type="ColumnType.String" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Type="ColumnType.Number" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.ShippedDate) HeaderText="Shipped Date" Format="dd/MM/yyyy hh:mm" Width="130" Type="ColumnType.DateTime"></GridColumn>
        <GridColumn Field=@nameof(Order.IsVerified) HeaderText="Verified" Width="130" DisplayAsCheckBox="true" Type="ColumnType.Boolean"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        var random = new Random();
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 10247 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "SUPRD", "CHOPS" })[random.Next(5)],
                Freight = 2.1 * x,
                OrderDate = new DateTime(random.Next(2010, 2023), random.Next(1, 13), random.Next(1, 29)),
                ShippedDate = DateTime.Now.AddDays(-random.Next(1, 10)),
                IsVerified = (new bool[] { true, false })[random.Next(2)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool? IsVerified { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htLKXltppjLrcEOg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* If the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) is not defined, then it will be determined from the first record of the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource).
>* Incase if the first record of the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) is null/blank value for a column then it is necessary to define the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) for that column. This is because the grid uses the column type to determine which filter dialog to display for that column

### Difference between Boolean type and CheckBox type column

* Use the **Boolean** column type when you want to bind boolean values from your datasource and/or edit boolean property values from your type.

* Use the **Checkbox** column type when you want to enable selection/deselection of the whole row.

* When the grid column `Type` is a **Checkbox**, the selection type of the [GridSelectionSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html) will be multiple. This is the default behavior.

* If you have more than one column with the column type as a **Checkbox**, the grid will automatically enable the other column’s checkbox when selecting one column checkbox.

>To learn more about how to render boolean values as checkboxes in a Syncfusion GridColumn, please refer to the [Render boolean values as checkbox](https://blazor.syncfusion.com/documentation/datagrid/columns#render-boolean-values-as-checkbox) section.

## Column Width

To adjust the column width in a Grid, you can use the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width)  property within the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) property of the Grid configuration. This property enables you to define the column width in pixels or as a percentage. You can set the width to a specific value, like **100** for 100 pixels, or as a percentage value, such as **25%** for 25% of the available width.

1. Grid column width is calculated based on the sum of column widths. For example, a grid container with 4 columns and a width of 800 pixels will have columns with a default width of 200 pixels each.

2. If you specify widths for some columns but not others, the Grid will distribute the available width equally among the columns without explicit widths. For example, if you have 3 columns with widths of 100px, 200px, and no width specified for the third column, the third column will occupy the remaining width after accounting for the first two columns.

3. Columns with percentage widths are responsive and adjust their width based on the size of the grid container. For example, a column with a width of 50% will occupy 50% of the grid width and will adjust proportionally when the grid container is resized to a smaller size.

4. When you manually resize columns in Syncfusion Grid, a minimum width is set to ensure that the content within the cells remains readable. By default, the minimum width is set to 10 pixels if not explicitly specified for a column.

5. If the total width of all columns exceeds the width of the grid container, a horizontal scrollbar will automatically appear to allow horizontal scrolling within the grid.

6. When the columns is hide using the column chooser, the width of the hidden columns is removed from the total grid width, and the remaining columns will be resized to fill the available space.

7. If the parent element has a fixed width, the grid component will inherit that width and occupy the available space. However, if the parent element does not have a fixed width, the grid component will adjust its width dynamically based on the available space.

8. When no width is provided in a column and MinWidth property is defined, if the cumulative width of the column is greater than the grid element width then MinWidth would be used as the column width to avoid it from becoming invisible.
9. When AllowResizing is enabled in the Data Grid, columns whose width is unspecified will be defined as 200px.

**Supported types for column width**

Syncfusion Data
Grid supports the following three types of column width:

**1. Auto**

The column width is automatically calculated based on the content within the column cells. If the content exceeds the width of the column, it will be truncated with an ellipsis (...) at the end. You can set the width for columns as **Auto** in your DataGrid configuration as shown below:

```cshtml
 <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="auto"></GridColumn>
```

**2. Percentage**

The column width is specified as a percentage value relative to the width of the datagrid container. For example, a column width of 25% will occupy 25% of the total datagrid width. You can set the width for columns as **percentage** in your DataGrid configuration as shown below:

```cshtml
 <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="25%"></GridColumn>
```

**3. Pixel**

The column width is specified as an absolute pixel value. For example, a column width of 100px will have a fixed width of 100 pixels regardless of the grid container size. You can set the width for columns as **pixel** in your Grid configuration as shown below:

```cshtml
 <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
  
```

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID"  Width="auto"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="30%"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBqjbjmLhqGOCcx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Column Formatting

Column formatting is a powerful feature in Syncfusion DataGrid that allows you to customize the display of data in datagrid columns. You can apply different formatting options to columns based on your requirements, such as displaying numbers with specific formats, formatting dates according to a specific locale, and using templates to format column values.

You can use the [Column.Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) property to specify the format for column values.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="90"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 10247 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBADYtcKvJdglhC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* The datagrid uses the **Internalization** library to format values based on the specified format and culture.
>* By default, the **number** and **date** values are formatted in **en-US** locale.
>* The available format codes may vary depending on the data type of the column.
>* You can also customize the formatting further by providing a custom function to the `Format` property, instead of a format string.
>* Make sure that the format string is valid and compatible with the data type of the column, to avoid unexpected results.

### Number formatting

Number formatting allows you to customize the display of numeric values in datagrid columns. You can use standard numeric format strings or custom numeric format strings to specify the desired format. The [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) property can be used to specify the number format for numeric columns. For example, you can use the following format strings to format numbers:

Format |Description |Remarks
-----|-----|-----
N | Denotes numeric type. | The numeric format is followed by integer value as N2, N3. etc which denotes the number of precision to be allowed.
C | Denotes currency type. | The currency format is followed by integer value as C2, C3. etc which denotes the number of precision to be allowed.
P | Denotes percentage type | The percentage format expects the input value to be in the range of 0 to 1. For example the cell value **0.2** is formatted as **20%**. The percentage format is followed by integer value as P2, P3. etc which denotes the number of precision to be allowed.

The following example code demonstrates the formatting of data for **Mark 1** and **Mark 2** using the **'N'** format, **Percentage of Marks** using the **'P'** format, and **Fees** using the **'C'** format.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.RollNo) HeaderText="Roll No"  Width="90"></GridColumn>
        <GridColumn Field=@nameof(Order.Mark1) HeaderText="Mark1"  Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.Mark2) HeaderText="Mark2" Format="N" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.Average) HeaderText="Average" Format="N2" Width="90"></GridColumn>
        <GridColumn Field=@nameof(Order.Percentage) HeaderText="Percentage of Marks" Format="P" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Fees) HeaderText="Fees" Format="C" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 20).Select(x => new Order()
            {
                RollNo = 1000 + x,
                Mark1 = 70.0 + x,
                Mark2 = 60.0 +x,
                Average = (70.0 + x + 60.0 + x) / 2.0,
                Percentage = ((70.0 + x + 60.0 + x) / 200.0),
                Fees = 400.00*x
           
            }).ToList();
    }

    public class Order
    {
        public int? RollNo { get; set; }
        public double? Mark1 { get; set; }
        public double? Mark2 { get; set; }
        public double? Average  { get; set; }
        public double? Percentage  { get; set; }
        public double? Fees { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjBUNlXmAtxmIcAD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To learn more about number formatting, you can refer to the [Number](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.ColumnType.html#Syncfusion_Blazor_QueryBuilder_ColumnType_Number) section.

### Date formatting

Date formatting in datagrid columns allows you to customize how date values are displayed. You can use standard date format strings, such as **"d," "D," "MMM dd, yyyy,"** and more, or create your own custom format strings. To specify the desired date format, you can use the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) property of the DataGrid columns. For example, you can set `Format` as a string like **"yyyy-MM-dd"** for a built-in date format. 

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Height="315">
    <GridColumns>

        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="c2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="dd/MM/yyyy" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Shipped Date" Format="dd/MM/yyyy hh:mm tt" Width="130" Type="ColumnType.DateTime"></GridColumn>

    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 10247 + x,
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
         
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLqZuDGKYkQtgRk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To learn more about date formatting, you can refer to [Date formatting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.ColumnType.html#Syncfusion_Blazor_QueryBuilder_ColumnType_Date).

## Align the text of content

You can align the text in the content of a Grid column using the [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_TextAlign) property. This property allows you to specify the alignment of the text within the cells of a particular column in the DataGrid. By default, the text is aligned to the left, but you can change the alignment by setting the value of the `TextAlign` property to one of the following options:

*	**Left**: Aligns the text to the left (default).
*	**Center**: Aligns the text to the center.
*	**Right**: Aligns the text to the right.
*	**Justify**: Align the text to the justify.

Here is an example of using the `TextAlign` property to align the text of a DataGrid column:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid  DataSource="@Orders" AllowPaging="true"  Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Left"  Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="130" TextAlign="TextAlign.Justify"  Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<Order> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }

    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhKjlNGUojBmUPG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* The `TextAlign` property only changes the alignment content not the column header. If you want to align both the column header and content, you can use the [HeaderTextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTextAlign) property.

## Render boolean values as checkbox

The DataGrid component allows you to render boolean values as checkboxes in columns. This can be achieved by using the [DisplayAsCheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_DisplayAsCheckBox)  property, which is available in the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn__ctor) component. This property is useful when you have a boolean column in your DataGrid and you want to display the values as checkboxes instead of the default text representation of **true** or **false**.

To enable the rendering of boolean values as checkboxes, you need to set the `DisplayAsCheckBox` property of the `GridColumn` to **true**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) HeaderText="Verified" TextAlign="TextAlign.Center" DisplayAsCheckBox="true" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    List<Order> OrderData = new List<Order>
    {
        new Order() { OrderID = 10248, CustomerID = "VINET", Freight = 32.38, Verified = true },
        new Order() { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61, Verified = false },
        new Order() { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83, Verified = true },
        new Order() { OrderID = 10251, CustomerID = "VICTE", Freight = 41.34, Verified = false },
        new Order() { OrderID = 10252, CustomerID = "SUPRD", Freight = 51.3,  Verified = false },
        new Order() { OrderID = 10253, CustomerID = "HANAR", Freight = 58.17, Verified = false },
        new Order() { OrderID = 10254, CustomerID = "CHOPS", Freight = 22.98, Verified = true },
        new Order() { OrderID = 10255, CustomerID = "RICSU", Freight = 148.33,Verified = true },
        new Order() { OrderID = 10256, CustomerID = "WELLI", Freight = 13.97, Verified = false },
        new Order() { OrderID = 10257, CustomerID = "HILAA", Freight = 81.91, Verified = true }
    };
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public bool Verified { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhKDutbrMNqKYBV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* The `DisplayAsCheckBox` property is only applicable to boolean values in DataGrid columns.
> * Need to define [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_EditType) as **EditType.BooleanEdit** to GridColumn to render checkbox while editing a boolean value.
>* When `DisplayAsCheckBox` is set to **true**, the boolean values will be rendered as checkboxes in the DataGrid column, with checked state indicating **true** and unchecked state indicating **false**.

## AutoFit columns

The DataGrid has a feature that allows to automatically adjust column widths based on the maximum content width of each column when you double-click on the resizer symbol located in a specific column header. This feature ensures that all data in the datagrid rows is displayed without wrapping. To use this feature, enable the resizer symbol in the column header by setting the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowResizing) property to true in the datagrid.

### Resizing a column to fit its content using autoFit method

The [AutoFitColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AutoFitColumnsAsync_System_String___) method resizes the column to fit the widest cell's content without wrapping. You can autofit specific columns at initial rendering by invoking the `AutoFitColumnsAsync` method in [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" GridLines="GridLine.Both">
    <GridEvents DataBound="DataboundHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcools Chevalier", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)],
                ShipAddress = (new string[] { "59 rue de l Abbaye", "Luisenstr. 48", "Rua do Paço, 67", "2, rue du Commerce", "Boulevard Tirou, 255" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeir", "Lyon", "Charleroi" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
      
    }

    public void DataboundHandler(object args)
    {
        this.Grid.AutoFitColumnsAsync(new string[] { "ShipAddress", "ShipName" });
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrgNEjFLoRSOpNL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can autofit all the columns by invoking the `AutoFitColumnsAsync` method without specifying column names.

### AutoFit columns with empty space

The Autofit feature is utilized to display columns in a datagrid based on the defined width specified in the columns declaration. If the total width of the columns is less than the width of the grid, this means that white space will be displayed in the grid instead of the columns auto-adjusting to fill the entire grid width.

You can enable this feature by setting the [AutoFit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AutoFit) property set to **true** in `GridColumn` component. This feature ensures that the column width is rendered only as defined in the DataGrid column definition.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowResizing="true" Width="800">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" MinWidth="100" MaxWidth="200" AutoFit=true TextAlign="TextAlign.Right" Width="200"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" MinWidth="8" Width="150" AutoFit=true></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" MinWidth="10" AutoFit=true Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" MinWidth="8" AutoFit=true Width="180"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" MinWidth="8" Width="150" AutoFit=true></GridColumn>

    </GridColumns>
</SfGrid>

@code {

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipCountry = (new string[] { "Brazil", "Switzerland", "Belgium", "France", "Germany" })[new Random().Next(5)],
                Freight = 2.1 * x,
             }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtVKDOZvqVGRPiOF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> If any one of the column width is undefined, then the particular column will automatically adjust to fill the entire width of the datagrid table, even if you have enabled the `AutoFit` property of the grid .

### Autofit columns when changing column visibility using column chooser

In Syncfusion DataGrid, you can auto-fit columns when the column visibility is changed using the column chooser. This can be achieved by calling the [AutoFitColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AutoFitColumnsAsync)  method in the [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event. By using the **RequestType** property in the event arguments, you can differentiate between different actions, and then call the `AutoFitColumnsAsync` method when the request type is **ColumnState**.

Here's an example code snippet in Blazor that demonstrates how to auto fit columns when changing column visibility using column chooser:

```cshtml
@using Syncfusion.Blazor.Grids;

<SfGrid @ref="Grid" DataSource="@Employees" ShowColumnChooser="true" Toolbar=@ToolbarItems>
    <GridEvents OnActionComplete="Complete" TValue="EmployeeData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.OrderID) TextAlign="TextAlign.Center" HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.CustomerID) HeaderText="Customer ID" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.ShipName) HeaderText="Ship Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.ShipAddress) HeaderText="Ship Address" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.ShipCity) HeaderText="Ship City" Format="d" TextAlign="TextAlign.Right" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
    SfGrid<EmployeeData> Grid { get; set; }
    public List<EmployeeData> Employees { get; set; }

    public async Task Complete(ActionEventArgs<EmployeeData> Args)
    {
        if (Args.RequestType == Syncfusion.Blazor.Grids.Action.ColumnState)
        {
            await Task.Delay(200);
            await Grid.AutoFitColumnsAsync();
        }
    }

    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
            {
                OrderID = x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcools Chevalier", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)],
                ShipAddress = (new string[] { "	59 rue de l Abbaye", "Luisenstr. 48", "Rua do Paço, 67","2, rue du Commerce",
                                    "	Boulevard Tirou, 255" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)]
            }).ToList();
    }

    public class EmployeeData
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhgjutlAcMBSghb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Show or hide columns

The Syncfusion Grid control allows you to show or hide columns dynamically by using property or methods available in the grid. This feature can be useful when you want to customize the visibility of columns in the Grid based on the requirements.

### Using property

You can show or hide columns in the Blazor DataGrid using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Visible) property of each column. By setting the `Visible` property to **true** or **false**, you can control whether the column should be visible or hidden in the datagrid. Here's an example of how to show or hide a column in the Blazor DataGrid using the visible property:

In the below example, the **ShipCity** column is defined with `Visible` property set to **false**, which will hide the column in the rendered grid.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Visible="false" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBqNYipiHlGiNfy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* Hiding a column using the `Visible` property only affects the UI representation of the datagrid. The data for the hidden column will still be available in the underlying data source, and can be accessed or modified programmatically.
>* When a column is hidden, its width is not included in the calculation of the total datagrid width.
>* To hide a column permanently, you can set its Visible property to false in the column definition, or remove the column definition altogether.

### Using methods

You can also show or hide columns in the Blazor DataGrid using the [ShowColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShowColumnsAsync_System_String___System_String_) and [HideColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_HideColumnsAsync_System_String___System_String_) methods of the datagrid component. These methods allow you to show or hide columns based on either the `HeaderText` or the `Field` of the column.

**Based on header text**

You can dynamically show or hide columns in the DataGrid based on the header text by invoking the `ShowColumnsAsync` or `HideColumnsAsync` methods. These methods take an array of column header texts as the first parameter, and the value `HeaderText` as the second parameter to specify that you are showing or hiding columns based on the header text.

Here's an example of how to show or hide a column based on the HeaderText in the Blazor DataGrid:


```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="Show" CssClass="e-primary" Content="Show"></SfButton>
<SfButton OnClick="Hide" CssClass="e-primary" Content="Hide"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Center" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public string[] ColumnItems = new string[] { "Customer ID" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 10250 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "SUPRD", "CHOPS" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void Show()
    {
        // Show columns by its header text
        this.DefaultGrid.ShowColumnsAsync(ColumnItems, "HeaderText");
    }

    public void Hide()
    {
        // Hide columns by its header text
        this.DefaultGrid.HideColumnsAsync(ColumnItems, "HeaderText");
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDrKXuWzMHVcbltj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Based on field**

You can dynamically show or hide columns in the DataGrid using external buttons based on the field by invoking the `ShowColumnsAsync` or `HideColumnsAsync` methods. These methods take an array of column fields as the first parameter, and the value `Field` as the second parameter to specify that you are showing or hiding columns based on the field.

Here's an example of how to show or hide a column based on the field in the Blazor  DataGrid:


```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="Show" CssClass="e-primary" Content="Show"></SfButton>
<SfButton OnClick="Hide" CssClass="e-primary" Content="Hide"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public string[] ColumnItems = new string[] { "CustomerID" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "SUPRD", "CHOPS" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void Show()
    {
        // Show columns by field
        this.DefaultGrid.ShowColumnsAsync(ColumnItems, "Field");
    }


    public void Hide()
    {
        // Hide columns by field
        this.DefaultGrid.HideColumnsAsync(ColumnItems, "Field");
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhgjYMfWcyPioge?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Controlling Grid actions

You can control various actions such as filtering, grouping, sorting, resizing, reordering, editing, and searching for specific columns in the Syncfusion Blazor DataGrid using the following properties:

* [AllowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowEditing): Enables or disables editing for a column.
* [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowFiltering): Enables or disables filtering for a column.
* [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowGrouping): Enables or disables grouping for a column.
* [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSorting): Enables or disables sorting for a column.
* [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering): Enables or disables reordering for a column.
* [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowResizing): Enables or disables resizing for a column
* [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching): Enables or disables searching for a column

Here is an example code that demonstrates how to control datagrid actions for specific columns:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowFiltering="true" AllowPaging="true" AllowGrouping="true" AllowReordering="true" AllowSorting="true" AllowResizing="true" Toolbar="@Tool">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" AllowGrouping="false" AllowResizing="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150" AllowSorting="false"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150" AllowSorting="false"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150" AllowSorting="false"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" AllowFiltering="false" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public List<string> Tool = new List<string>() { "Search" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 10247 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipCountry = (new string[] { "France", "Germany", "Brazil", "Belgium", "Switzerland" })[new Random().Next(5)],
                Freight = 2.1 * x,
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLUjkszslstYuzX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Customize column styles

Customizing the datagrid column styles allows you to modify the appearance of columns in the DataGrid control to meet your design requirements. You can customize the font, background color, and other styles of the columns. To customize the columns styles in the datagrid, you can use grid event, css, property or method support.

For more information check on this [documentation](https://blazor.syncfusion.com/documentation/datagrid/cell#customize-cell-styles).


## Manipulating columns

The Syncfusion DataGrid for Blazor provides powerful features for manipulating columns in a datagrid. This section explains how to access columns and add/remove columns using Syncfusion DataGrid properties, methods, and events.

### Accessing Columns

To access columns in the Syncfusion DataGrid, you can use the following methods in the datagrid.

* **[GetColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnsAsync_System_Nullable_System_Boolean__)**:

This method returns the array of columns defined in the datagrid.

```csharp
var Columns = this.Grid.GetColumnsAsync().Result;
```

* **[GetColumnByFieldAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByFieldAsync_System_String_)**:

This method returns the column object that matches the specified field name.

```csharp
var Column = this.Grid.GetColumnByFieldAsync("ProductName").Result;
```

* **[GetColumnByUidAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByUidAsync_System_String_)**:

This method returns the column object that matches the specified UID.

```csharp
 var Column = this.Grid.GetColumnByUidAsync();
```

* **[GetVisibleColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetVisibleColumnsAsync)**:

This method returns the list of visible columns.

```csharp
var VisibleColumns = this.Grid.GetVisibleColumnsAsync().Result;
```

* **[GetForeignKeyColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetForeignKeyColumnsAsync)**:

This method returns the list of foreignkey columns.

```csharp
var ForeignKeyColumns = this.Grid.GetForeignKeyColumnsAsync.Result;
```

* **[GetColumnFieldNamesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnFieldNamesAsync)**

This method returns an list of field names of all the columns in the DataGrid.

```csharp
 var FieldNames = this.Grid.GetColumnFieldNamesAsync().Result;
```

> For a complete list of column methods and properties, refer to this [section](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).


### Adding/Removing Columns

The DataGrid component allows you to dynamically add or remove columns to and from the datagrid using the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) property, which can be accessed through the instance of the DataGrid.

To add a new column to the DataGrid, you can directly **Add** the new column object to the columns property.To remove a column from the DataGrid, you can use the **RemoveAt** method. This method allows you to remove a specific column from the columns list of the DataGrid. In the below provided code snippet, the column removed is the last column in the list. If you want to remove a specific list of columns by its index.

Here's an example of how you can add and remove a column from the datagrid:

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-primary" OnClick="AddColumns">Add Coluumn</SfButton>
<SfButton CssClass="e-primary" OnClick="DeleteColumns">Delete Column</SfButton>

<SfGrid @ref="Grid" TValue="Order" DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Left" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    SfGrid<Order>? Grid { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                EmployeeID = x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "CHOPS" })[new Random().Next(5)],
                Freight = 2.1 * x,
                ShipCity = (new string[] { "Seattle", "Tacoma", "Redmond", "Kirkland", "London" })[new Random().Next(5)],
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
    }

    public void AddColumns()
    {
        List<GridColumn> NewColumns = new List<GridColumn> { new GridColumn { Field = "EmployeeID", HeaderText = "Employee ID", Width = "120" },new GridColumn { Field = "OrderDate", HeaderText = "Order Date", Width = "120" , Format="d" } };
        foreach (GridColumn column in NewColumns)
        {
            Grid.Columns.Add(column);
        }
        Grid.RefreshColumnsAsync();
    }

    public void DeleteColumns()
    {
        var ColumnsCount = Grid.Columns.Count();
        if (ColumnsCount > 0)
            Grid.Columns?.RemoveAt(ColumnsCount - 1);
        Grid.RefreshColumnsAsync();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrgXOCfVznXKWnw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### How to refresh columns

You can use the [RefreshColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RefreshColumnsAsync) method of the Syncfusion DataGrid to refresh the columns in the datagrid. This method can be used when you need to update the datagrid columns dynamically based on user actions or data changes.

```csharp
this.Grid.RefreshColumnsAsync();
```
## Responsive columns

The Syncfusion Blazor DataGrid provides a built-in feature to toggle the visibility of columns based on Media Queries  using the [HideAtMedia](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HideAtMedia) Column property. The `HideAtMedia` accepts valid [Media Queries](http://cssmediaqueries.com/what-are-css-media-queries.html). 

In this example, we have a DataGrid that displays data with three columns: **Order ID, Customer ID, and Freight**. We have set the `HideAtMedia` property of the **OrderID** column to (min-width: 700px) which means that this column will be hidden when the browser screen width is less than or equal to 700px.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" HideAtMedia="(min-width: 700px)" TextAlign="TextAlign.Center" Width="120"></GridColumn> 
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" HideAtMedia="(max-width: 500px)" Width="150" TextAlign="TextAlign.Center"></GridColumn> 
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Center" Width="130"></GridColumn> 
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" HideAtMedia="(min-width: 500px)" TextAlign="TextAlign.Center" Width="120"></GridColumn> 
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhAjkMzrysJSudC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See also

* [How to create a Custom Grid Column component](https://support.syncfusion.com/kb/article/11220/blazor-grid-how-to-create-a-custom-grid-column-component)

> You can refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.
