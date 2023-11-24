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

The Syncfusion Blazor DataGrid component allows you to specify the type of data that a column binds using the [Column.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) property. The `Type` property is used to determine the appropriate [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format), such as [Decimal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnType.html#Syncfusion_Blazor_Grids_ColumnType_Decimal),  [Double](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnType.html#Syncfusion_Blazor_Grids_ColumnType_Double), [Integer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnType.html#Syncfusion_Blazor_Grids_ColumnType_Integer), [Long](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnType.html#Syncfusion_Blazor_Grids_ColumnType_Long), [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnType.html#Syncfusion_Blazor_Grids_ColumnType_None) or [Date](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnType.html#Syncfusion_Blazor_Grids_ColumnType_Date), for displaying the column data. 

DataGrid supports the following column types:

* **String**: Represents a column that binds to string data. This is the default type if the `Type` property is not defined.
* **Decimal**: Represents a column that binds to Decimal data.
* **Double**: Represents a column that binds to Double data.
* **Integer**: Represents a column that binds to Integer data.
* **Long**: Represents a column that binds to Long data.
* **None**: Represents a column that binds to None data.
* **Boolean**: Represents a column that binds to boolean data. It displays checkboxes for boolean values.
* **Date**: Represents a column that binds to date data. It supports formatting options for displaying dates.
* **Datetime**: Represents a column that binds to date and time data. It supports formatting options for displaying date and time values.
* **DateOnly**: Represents a column that binds to [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-7.0) data. It supports formatting options for displaying DateOnly values.

* **TimeOnly**: Represents a column that binds to [TimeOnly](https://learn.microsoft.com/en-us/dotnet/api/system.timeonly?view=net-7.0) data. It supports formatting options for displaying TimeOnly values.

* **Checkbox**: Represents a column that displays checkboxes.

> Blazor DataGrid Component supports `DateOnly` and  `TimeOnly` type in .NET 7 and above version only, even though it introduced in .NET 6 itself due to serialization problem.

Here is an example of how to specify column types in a grid using the types mentioned above.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Type="Syncfusion.Blazor.Grids.ColumnType.Integer" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Type="Syncfusion.Blazor.Grids.ColumnType.String" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Type="Syncfusion.Blazor.Grids.ColumnType.Double" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="130" Type="Syncfusion.Blazor.Grids.ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShippedDate) HeaderText="Shipped Date" Format="dd/MM/yyyy hh:mm" Width="130" Type="Syncfusion.Blazor.Grids.ColumnType.DateTime"></GridColumn>
        <GridColumn Field=@nameof(OrderData.IsVerified) HeaderText="Verified" Width="130" DisplayAsCheckBox="true" Type="Syncfusion.Blazor.Grids.ColumnType.Boolean"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID, string CustomerID, double Freight,DateTime? OrderDate, DateTime? ShippedDate,bool? IsVerified)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.Freight = Freight;  
            this.OrderDate = OrderDate;
            this.ShippedDate = ShippedDate;
            this.IsVerified = IsVerified;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38,new DateTime(1996,7,4),new DateTime(1996,08,07),true));
                    Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07),false));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07),true));
                    Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07),false));
                    Orders.Add(new OrderData(10252, "SUPRD", 51.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07),true));
                    Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07),false));
                    Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07),true));
                    Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07),false));
                    Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07),true));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool? IsVerified { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLUiWZmBWcefthH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

Syncfusion DataGrid supports the following three types of column width:

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
{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="auto"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="30%"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID, string CustomerID, double Freight,DateTime? OrderDate)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.Freight = Freight;  
            this.OrderDate = OrderDate;           
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38,new DateTime(1996,7,4)));
                    Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5)));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6)));
                    Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7)));
                    Orders.Add(new OrderData(10252, "SUPRD", 51.30, new DateTime(1996, 7, 8)));
                    Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9)));
                    Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10)));
                    Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11)));
                    Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12)));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }       
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBUiDgNHtAxxDUg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Column Formatting

Column formatting is a powerful feature in Syncfusion DataGrid that allows you to customize the display of data in datagrid columns. You can apply different formatting options to columns based on your requirements, such as displaying numbers with specific formats, formatting dates according to a specific locale, and using templates to format column values.

You can use the [Column.Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) property to specify the format for column values.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID, string CustomerID, double Freight,DateTime? OrderDate)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.Freight = Freight;  
            this.OrderDate = OrderDate;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38,new DateTime(1996,7,4)));
                    Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5)));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6)));
                    Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7)));
                    Orders.Add(new OrderData(10252, "SUPRD", 51.30, new DateTime(1996, 7, 8)));
                    Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9)));
                    Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10)));
                    Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11)));
                    Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12)));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }       
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVKsNgtdDxrKkCw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.RollNo) HeaderText="Roll No" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Mark1) HeaderText="Mark1" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Mark2) HeaderText="Mark2" Format="N" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Average) HeaderText="Average" Format="N2" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Percentage) HeaderText="Percentage of Marks" Format="P" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Fees) HeaderText="Fees" Format="C" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
   private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData( int? RollNo, double? Mark1,double? Mark2,double? Average,double? Percentage,double? Fees)
        {
            this.RollNo=RollNo;
            this.Mark1=Mark1;
            this.Mark2=Mark2;
            this.Average=Average;
            this.Percentage=Percentage;
            this.Fees=Fees;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, 70.0, 60.0,10.67,0.5,400.00));
                    Orders.Add(new OrderData(10249, 71.0, 61.0,10.68,0.95,800.00));
                    Orders.Add(new OrderData(10248, 72.0, 62.0,10.61,0.7,1200.00));
                    Orders.Add(new OrderData(10248, 73.0, 63.0,10.62,0.8,1600.00));
                    Orders.Add(new OrderData(10248, 74.0, 64.0,10.63,0.8,3200.00));
                    Orders.Add(new OrderData(10248, 75.0, 65.0,10.64,0.9,6400.00));
                    Orders.Add(new OrderData(10248, 77.0, 66.0,10.68,0.10,12800.00));
                    Orders.Add(new OrderData(10248, 76.0, 67.0,10.57,0.12,26000.00));
                    Orders.Add(new OrderData(10248, 78.0, 68.0,10.66,0.15,52000.00));                                                                                    
                    code += 5;
                }
            }
            return Orders;
        }
        public int? RollNo { get; set; }
        public double? Mark1 { get; set; }
        public double? Mark2 { get; set; }
        public double? Average { get; set; }
        public double? Percentage { get; set; }
        public double? Fees { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBgCZAsgcTiXKaN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To learn more about number formatting, you can refer to the [Number](https://blazor.syncfusion.com/documentation/datagrid/columns#number-formatting) section.

### Date formatting

Date formatting in datagrid columns allows you to customize how date values are displayed. You can use standard date format strings, such as **"d," "D," "MMM dd, yyyy,"** and more, or create your own custom format strings. To specify the desired date format, you can use the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) property of the DataGrid columns. For example, you can set `Format` as a string like **"yyyy-MM-dd"** for a built-in date format. 

Additionally, you can use custom format strings to format date values, and examples of custom formats and formatted date values are provided in the table below.

Format|Formatted value 
-----|-----
Type="ColumnType.Date" Format="dd/MM/yyyy" | 04/07/1996
Type="ColumnType.Date" Format="dd.MM.yyyy" | 04.07.1996
Type="ColumnType.Date" Format="dMM/dd/yyyy hh:mm tt" | 04/07/1996 12:00 AM
Type="ColumnType.Date" Format="dMM/dd/yyyy hh:mm:ss tt" | 04/07/1996 12:00 AM

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowPaging="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="c2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="dd/MM/yyyy" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Shipped Date" Format="dd/MM/yyyy hh:mm tt" Width="130" Type="ColumnType.DateTime"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID, string CustomerID, double Freight,DateTime? OrderDate)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.Freight = Freight;  
            this.OrderDate = OrderDate;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, 32.38,new DateTime(1996,7,4)));
                    Orders.Add(new OrderData(10249, 11.61, new DateTime(1996, 7, 5)));
                    Orders.Add(new OrderData(10250, 65.83, new DateTime(1996, 7, 6)));
                    Orders.Add(new OrderData(10251, 41.34, new DateTime(1996, 7, 7)));
                    Orders.Add(new OrderData(10252, 51.30, new DateTime(1996, 7, 8)));
                    Orders.Add(new OrderData(10253, 58.17, new DateTime(1996, 7, 9)));
                    Orders.Add(new OrderData(10254, 22.98, new DateTime(1996, 7, 10)));
                    Orders.Add(new OrderData(10255, 148.33, new DateTime(1996, 7, 11)));
                    Orders.Add(new OrderData(10256, 13.97, new DateTime(1996, 7, 12)));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }       
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhAMZKWitcsyBzO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To learn more about date formatting, you can refer to [Date formatting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnType.html#Syncfusion_Blazor_Grids_ColumnType_Date).

## Align the text of content

You can align the text in the content of a Grid column using the [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_TextAlign) property. This property allows you to specify the alignment of the text within the cells of a particular column in the DataGrid. By default, the text is aligned to the left, but you can change the alignment by setting the value of the `TextAlign` property to one of the following options:

*	**Left**: Aligns the text to the left (default).
*	**Center**: Aligns the text to the center.
*	**Right**: Aligns the text to the right.
*	**Justify**: Align the text to the justify.

Here is an example of using the `TextAlign` property to align the text of a DataGrid column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowPaging="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Left" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="130" TextAlign="TextAlign.Justify" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate,string ShipCountry)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.OrderDate = OrderDate;
            this.ShipCountry = ShipCountry;
           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", new DateTime(1996,7,4), "France"));
                    Orders.Add(new OrderData(10249, "TOMSP",  new DateTime(1996, 7, 5), "Germany"));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 7, 6), "Brazil"));
                    Orders.Add(new OrderData(10251, "VINET",  new DateTime(1996, 7, 7), "France"));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 7, 8), "Belgium"));
                    Orders.Add(new OrderData(10253, "HANAR",  new DateTime(1996, 7, 9), "Brazil"));
                    Orders.Add(new OrderData(10254, "CHOPS", new DateTime(1996, 7, 10), "Switzerland"));
                    Orders.Add(new OrderData(10255, "VINET",new DateTime(1996, 7, 11), "Switzerland"));
                    Orders.Add(new OrderData(10256, "HANAR", new DateTime(1996, 7, 12), "Brazil"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? OrderDate { get; set; }
       
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLqMDAssKgmASlG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* The `TextAlign` property only changes the alignment content not the column header. If you want to align both the column header and content, you can use the [HeaderTextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTextAlign) property.

## Render boolean values as checkbox

The DataGrid component allows you to render boolean values as checkboxes in columns. This can be achieved by using the [DisplayAsCheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_DisplayAsCheckBox)  property, which is available in the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn__ctor) component. This property is useful when you have a boolean column in your DataGrid and you want to display the values as checkboxes instead of the default text representation of **true** or **false**.

To enable the rendering of boolean values as checkboxes, you need to set the `DisplayAsCheckBox` property of the `GridColumn` to **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Verified) HeaderText="Verified" TextAlign="TextAlign.Center" DisplayAsCheckBox="true" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID, string CustomerID,double Freight,bool verified)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.Freight = Freight;
            this.Verified = verified;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38,true));
                    Orders.Add(new OrderData(10249, "TOMSP",  11.26,false));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83,true));
                    Orders.Add(new OrderData(10251, "VINET", 41.34,true));
                    Orders.Add(new OrderData(10252, "SUPRD", 51.30,true));
                    Orders.Add(new OrderData(10253, "HANAR", 58.17,true));
                    Orders.Add(new OrderData(10254, "CHOPS", 22.98,false));
                    Orders.Add(new OrderData(10255, "VINET", 148.33,true));
                    Orders.Add(new OrderData(10256, "HANAR", 13.97,true));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public bool Verified { get; set; }       
    }   
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLqWZKWCpWghdlk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* The `DisplayAsCheckBox` property is only applicable to boolean values in DataGrid columns.
> * Need to define [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_EditType) as **EditType.BooleanEdit** to GridColumn to render checkbox while editing a boolean value.
>* When `DisplayAsCheckBox` is set to **true**, the boolean values will be rendered as checkboxes in the DataGrid column, with checked state indicating **true** and unchecked state indicating **false**.

## AutoFit columns

The DataGrid has a feature that allows to automatically adjust column widths based on the maximum content width of each column when you double-click on the resizer symbol located in a specific column header. This feature ensures that all data in the datagrid rows is displayed without wrapping. To use this feature, enable the resizer symbol in the column header by setting the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowResizing) property to true in the datagrid.

### Resizing a column to fit its content using autoFit method

The [AutoFitColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AutoFitColumnsAsync_System_String___) method resizes the column to fit the widest cell's content without wrapping. You can autofit specific columns at initial rendering by invoking the `AutoFitColumnsAsync` method in [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" GridLines="GridLine.Both">
    <GridEvents DataBound="DataboundHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }     
    public void DataboundHandler(object args)
    {
        this.Grid.AutoFitColumnsAsync(new string[] { "ShipAddress", "ShipName" });
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
        public OrderData(int? OrderID, string CustomerID,string ShipName,string ShipAddress, string ShipCity)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.ShipName= ShipName; 
            this.ShipAddress=ShipAddress;
            this.ShipCity=ShipCity;
           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", "59 rue de l Abbaye", "Reims"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", "Luisenstr. 48", "Münster"));
                    Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", "Rua do Paço, 67", "Rio de Janei"));
                    Orders.Add(new OrderData(10251, "VINET", "Victuailles en stock", "2, rue du Commerce", "Lyon"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", "Boulevard Tirou, 255", "Charleroi"));
                    Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", "Rua do Paço, 67", "Rio de Janei"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", "Hauptstr. 31", "Bern"));
                    Orders.Add(new OrderData(10255, "VINET", "Richter Supermarkt", "Starenweg 5", "Genève"));
                    Orders.Add(new OrderData(10256, "HANAR", "Wellington Importadora", "Rua do Mercado, 12", "Resende"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
       
    }
{% endhighlight %}
{% endtabs %}


{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrqWtUWCHFCmyCS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can autofit all the columns by invoking the `AutoFitColumnsAsync` method without specifying column names.

### AutoFit columns with empty space

The Autofit feature is utilized to display columns in a datagrid based on the defined width specified in the columns declaration. If the total width of the columns is less than the width of the grid, this means that white space will be displayed in the grid instead of the columns auto-adjusting to fill the entire grid width.

You can enable this feature by setting the [AutoFit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AutoFit) property set to **true** in `GridColumn` component. This feature ensures that the column width is rendered only as defined in the DataGrid column definition.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315" AllowResizing="true" Width="800">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" MinWidth="100" MaxWidth="200" AutoFit=true TextAlign="TextAlign.Right" Width="200"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" MinWidth="8" Width="150" AutoFit=true></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" MinWidth="10" AutoFit=true Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" MinWidth="8" AutoFit=true Width="180"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" MinWidth="8" Width="150" AutoFit=true></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID, string CustomerID,double Freight,string ShipCity, string ShipCountry)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.Freight = Freight;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims", "France"));
                    Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster","Germany"));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janei","Brazil"));
                    Orders.Add(new OrderData(10251, "VINET", 41.34, "Lyon","France"));
                    Orders.Add(new OrderData(10252, "SUPRD", 51.30, "Charleroi","Belgium"));
                    Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janei","Brazil"));
                    Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern", "Switzerland"));
                    Orders.Add(new OrderData(10255, "VINET",148.53, "Genève", "Switzerland"));
                    Orders.Add(new OrderData(10256, "HANAR", 13.97, "Resende","Brazil"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry{ get; set; }
       
    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLKiNKislriVlUg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> If any one of the column width is undefined, then the particular column will automatically adjust to fill the entire width of the datagrid table, even if you have enabled the `AutoFit` property of the grid.

### Autofit columns when changing column visibility using column chooser

In Syncfusion DataGrid, you can auto-fit columns when the column visibility is changed using the column chooser. This can be achieved by calling the [AutoFitColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AutoFitColumnsAsync)  method in the [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event. By using the **RequestType** property in the event arguments, you can differentiate between different actions, and then call the `AutoFitColumnsAsync` method when the request type is **ColumnState**.

Here's an example code snippet in Blazor that demonstrates how to auto fit columns when changing column visibility using column chooser:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids;
@using BlazorApp1.Data

<SfGrid @ref="Grid" DataSource="@Orders" ShowColumnChooser="true" Toolbar=@ToolbarItems>
    <GridEvents OnActionComplete="OnActionComplete" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) TextAlign="TextAlign.Center" HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipAddress) HeaderText="Ship Address" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Format="d" TextAlign="TextAlign.Right" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }     
    public async Task OnActionComplete(ActionEventArgs<OrderData> Args)
    {
        if (Args.RequestType == Syncfusion.Blazor.Grids.Action.ColumnState)
        {
            await Grid.AutoFitColumnsAsync();
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
        public OrderData(int? OrderID, string CustomerID,string ShipName, string ShipAddress, string ShipCity)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.ShipName = ShipName;
            this.ShipAddress = ShipAddress;           
            this.ShipCity = ShipCity;          
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", "2, rue du Commerce", "Reims"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", "Boulevard Tirou, 255", "Charleroi"));
                    Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", "Rua do Paço, 67", "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251, "VINET", "Victuailles en stock", "Hauptstr. 31", "Bern"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", "Starenweg 5", "Genève"));
                    Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", "Rua do Mercado, 12", "Resende"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", "Carrera 22 con Ave. Carlos Soublette #8-35", "San Cristóbal"));
                    Orders.Add(new OrderData(10255, "VINET", "Richter Supermarkt", "Kirchgasse 6", "Graz"));
                    Orders.Add(new OrderData(10256, "HANAR", "Wellington Importadora", "Sierras de Granada 9993", "México D.F."));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public string ShipAddress { get; set; }       
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtrUWCZmBqLMLrUr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Show or hide columns

The Syncfusion Grid control allows you to show or hide columns dynamically by using property or methods available in the grid. This feature can be useful when you want to customize the visibility of columns in the Grid based on the requirements.

### Using property

You can show or hide columns in the Blazor DataGrid using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Visible) property of each column. By setting the `Visible` property to **true** or **false**, you can control whether the column should be visible or hidden in the datagrid. Here's an example of how to show or hide a column in the Blazor DataGrid using the visible property:

In the below example, the **ShipCity** column is defined with `Visible` property set to **false**, which will hide the column in the rendered grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="false" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
      
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData( int? OrderID, string CustomerID, string ShipCity, DateTime? OrderDate,double? Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.OrderDate = OrderDate;
            this.Freight = Freight;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET","Reims",new DateTime(1996,07,06), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", new DateTime(1996, 07, 06), 11.61));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", new DateTime(1996, 07, 06), 65.83));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", new DateTime(1996, 07, 06),45.78));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", new DateTime(1996, 07, 06),98.6));
                    Orders.Add(new OrderData(10253, "HANAR", "Bern", new DateTime(1996, 07, 06),103.45));
                    Orders.Add(new OrderData(10254, "CHOPS", "Genève", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(10255, "RICSU", "Resende",new DateTime(1996, 07, 06), 112.48));
                    Orders.Add(new OrderData(10256, "WELLI", "San Cristóbal", new DateTime(1996, 07, 06), 33.45));                                                 
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhUMXqWKAAPxnOA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* Hiding a column using the `Visible` property only affects the UI representation of the datagrid. The data for the hidden column will still be available in the underlying data source, and can be accessed or modified programmatically.
>* When a column is hidden, its width is not included in the calculation of the total datagrid width.
>* To hide a column permanently, you can set its Visible property to false in the column definition, or remove the column definition altogether.

### Using methods

You can also show or hide columns in the Blazor DataGrid using the [ShowColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShowColumnsAsync_System_String___System_String_) and [HideColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_HideColumnsAsync_System_String___System_String_) methods of the datagrid component. These methods allow you to show or hide columns based on either the `HeaderText` or the `Field` of the column.

**Based on header text**

You can dynamically show or hide columns in the DataGrid based on the header text by invoking the `ShowColumnsAsync` or `HideColumnsAsync` methods. These methods take an array of column header texts as the first parameter, and the value `HeaderText` as the second parameter to specify that you are showing or hiding columns based on the header text.

Here's an example of how to show or hide a column based on the HeaderText in the Blazor DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfButton OnClick="Show" CssClass="e-primary" Content="Show"></SfButton>
<SfButton OnClick="Hide" CssClass="e-primary" Content="Hide"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Center" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }
    public string[] ColumnItems = new string[] { "Customer ID" };
      
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID,  DateTime? OrderDate,double? Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,06), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 06), 65.83));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 06),45.78));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 06),98.6));
                    Orders.Add(new OrderData(10253, "HANAR", new DateTime(1996, 07, 06),103.45));
                    Orders.Add(new OrderData(10254, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(10255, "RICSU",new DateTime(1996, 07, 06), 112.48));
                    Orders.Add(new OrderData(10256, "WELLI", new DateTime(1996, 07, 06), 33.45));                                                 
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtLKstUiKqvPtChm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Based on field**

You can dynamically show or hide columns in the DataGrid using external buttons based on the field by invoking the `ShowColumnsAsync` or `HideColumnsAsync` methods. These methods take an array of column fields as the first parameter, and the value `Field` as the second parameter to specify that you are showing or hiding columns based on the field.

Here's an example of how to show or hide a column based on the field in the Blazor  DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfButton OnClick="Show" CssClass="e-primary" Content="Show"></SfButton>
<SfButton OnClick="Hide" CssClass="e-primary" Content="Hide"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }
    public string[] ColumnItems = new string[] { "CustomerID" };
      
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID,  DateTime? OrderDate,double? Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,06), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 06), 65.83));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 06),45.78));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 06),98.6));
                    Orders.Add(new OrderData(10253, "HANAR", new DateTime(1996, 07, 06),103.45));
                    Orders.Add(new OrderData(10254, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(10255, "RICSU",new DateTime(1996, 07, 06), 112.48));
                    Orders.Add(new OrderData(10256, "WELLI", new DateTime(1996, 07, 06), 33.45));                                                 
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrqsjUMKTBTIoOw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315" AllowFiltering="true" AllowPaging="true" AllowGrouping="true" AllowReordering="true" AllowSorting="true" AllowResizing="true" Toolbar="@ToolbarItems">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" AllowGrouping="false" AllowResizing="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" AllowSorting="false"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" AllowSorting="false"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150" AllowSorting="false"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" AllowFiltering="false" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {   
    public List<OrderData> Orders { get; set; }
    public List<string> ToolbarItems = new List<string>() { "Search" };      
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData( int? OrderID, string CustomerID,  string ShipCity,string ShipCountry, double? Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;           
            this.Freight = Freight;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "France",    32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Germany", 11.61));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Brazil", 65.83));
                    Orders.Add(new OrderData(10251, "VICTE", "Münster", "Belgium", 45.78));
                    Orders.Add(new OrderData(10252, "SUPRD", "Lyon", "Switzerland"  , 98.6));
                    Orders.Add(new OrderData(10253, "HANAR", "Charleroi", "Switzerland"  ,103.45));
                    Orders.Add(new OrderData(10254, "CHOPS", "Lyon", "Belgium", 103.45));
                    Orders.Add(new OrderData(10255, "RICSU", "Münster", "Brazil", 112.48));
                    Orders.Add(new OrderData(10256, "WELLI", "Rio de Janeiro", "Germany", 33.45));                                                 
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrgCZKCqeQRwTon?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


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

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using BlazorApp1.Data

<SfButton CssClass="e-primary" OnClick="AddColumns">Add Coluumn</SfButton>
<SfButton CssClass="e-primary" OnClick="DeleteColumns">Delete Column</SfButton>

<SfGrid @ref="Grid" TValue="OrderData" DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Left" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
   private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }     
    public void AddColumns()
    {
        List<GridColumn> NewColumns = new List<GridColumn> { new GridColumn { Field = "EmployeeID", HeaderText = "Employee ID", Width = "120" }, new GridColumn { Field = "OrderDate", HeaderText = "Order Date", Width = "120", Format = "d" } };
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
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID,  string ShipCity, double? Freight,int? EmployeeId,DateTime? OrderDate)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;              
            this.Freight = Freight;
            this.EmployeeID= EmployeeId;
            this.OrderDate = OrderDate;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims",  32.38,1,new DateTime(1996,07,08)));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", 11.61,2, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", 65.83,3,new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10251, "VICTE", "Münster", 45.78,4, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10252, "SUPRD", "Lyon"  , 98.6,5, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10253, "HANAR", "Charleroi", 103.45,6, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10254, "CHOPS", "Lyon", 103.45,7, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10255, "RICSU", "Münster", 112.48,8, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10256, "WELLI", "Rio de Janeiro", 33.45,9, new DateTime(1996, 07, 08)));                                                 
                    code += 5;
                }
            }
            return Orders;
        }


        public int? OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }

        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }

    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBAMjgCAnfXCEpt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### How to refresh columns

You can use the [RefreshColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RefreshColumnsAsync) method of the Syncfusion DataGrid to refresh the columns in the datagrid. This method can be used when you need to update the datagrid columns dynamically based on user actions or data changes.

```csharp
this.Grid.RefreshColumnsAsync();
```
## Responsive columns

The Syncfusion Blazor DataGrid provides a built-in feature to toggle the visibility of columns based on Media Queries  using the [HideAtMedia](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HideAtMedia) Column property. The `HideAtMedia` accepts valid [Media Queries](http://cssmediaqueries.com/what-are-css-media-queries.html). 

In this example, we have a DataGrid that displays data with three columns: **Order ID, Customer ID, and Freight**. We have set the `HideAtMedia` property of the **OrderID** column to (min-width: 700px) which means that this column will be hidden when the browser screen width is less than or equal to 700px.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" HideAtMedia="(min-width: 700px)" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" HideAtMedia="(max-width: 500px)" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" HideAtMedia="(min-width: 500px)" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
   private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
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
        public OrderData( int? OrderID, string CustomerID,   double? Freight,DateTime? OrderDate)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;                 
            this.Freight = Freight;           
            this.OrderDate = OrderDate;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET",  32.38,new DateTime(1996,07,08)));
                    Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83,new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10251, "VICTE", 45.78, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10252, "SUPRD"  , 98.6, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10253, "HANAR", 103.45, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10254, "CHOPS", 103.45, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10255, "RICSU", 112.48, new DateTime(1996, 07, 08)));
                    Orders.Add(new OrderData(10256, "WELLI", 33.45, new DateTime(1996, 07, 08)));                                                 
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }   
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVgCXgigHQmVtsp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See also

* [How to create a Custom Grid Column component](https://support.syncfusion.com/kb/article/11220/blazor-grid-how-to-create-a-custom-grid-column-component)

> You can refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.
