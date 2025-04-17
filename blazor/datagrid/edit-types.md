---
layout: post
title: Edit Types in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Cell Edit Types in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Edit Types in Blazor DataGrid Component

The Syncfusion Blazor DataGrid component offers a variety of edit types, enabling you to customize the editing behavior for different column types. These edit types enhance the editing experience and provide flexibility in managing various data types.

## Default cell edit type editor

The Syncfusion Blazor DataGrid provides pre-built default editors that enhance data editing and input handling within the grid. These default editors simplify the process of defining the editor component for specific columns based on the column's data type. To configure default editors for grid columns, use the [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditType.html) property.

The available default edit types are as follows:

| Component                                                                                      | Edit Type Value      | Description                                                                                                   |
|------------------------------------------------------------------------------------------------|----------------------|---------------------------------------------------------------------------------------------------------------|
| [TextBox](https://blazor.syncfusion.com/documentation/textbox/getting-started-webapp)          | DefaultEdit          | The `DefaultEdit` type renders a TextBox component for string data type columns.                              |
| [NumericTextBox](https://blazor.syncfusion.com/documentation/numeric-textbox/getting-started)  | NumericEdit          | The `NumericEdit` type renders a NumericTextBox component for integer, double, float, and other numeric types.|
| [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) | DropDownEdit         | The `DropDownEdit` type renders a DropDownList component for string data type columns.                        |
| [Checkbox](https://blazor.syncfusion.com/documentation/check-box/getting-started-with-web-app) | BooleanEdit          | The `BooleanEdit` type renders a CheckBox component for boolean data type columns.                            |
| [DatePicker](https://blazor.syncfusion.com/documentation/datepicker/getting-started-with-web-app) | DatePickerEdit       | The `DatePickerEdit` type renders a DatePicker component for date data type columns.                          |
| [DateTimePicker](https://blazor.syncfusion.com/documentation/datetime-picker/getting-started-with-web-app) | DateTimePickerEdit   | The `DateTimePickerEdit` type renders a DateTimePicker component for date-time data type columns.             |

The following example demonstrates how to define the `EditType` for grid columns:

```cs
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" EditType="EditType.DefaultEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Time" EditType="EditType.DateTimePickerEdit" Format="dd/MM/yyyy hh:mm a" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="dd/MM/yyyy" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderData.IsVerified) HeaderText="Verified" DisplayAsCheckBox="true" EditType="EditType.BooleanEdit" Width="120"></GridColumn>
    </GridColumns>
```

> If `EditType` is not defined in the column, it will default to the `DefaultEdit` type (TextBox component).

## Customize TextBox Component of DefaultEdit type

The [StringEditCellParams](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.StringEditCellParams.html) class enables customization of the default TextBox component in the Grid **EditForm** for string data type columns. This feature allows you to modify the TextBox properties and behavior by configuring the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) of the respective GridColumn. Below is a detailed explanation and implementation of this customization.

The table below highlights the key aspects of customizing a TextBox control using the `EditorSettings` property of a GridColumn:

| Component                                                                                      | Edit Type   | Description                                                                                                   | Example Customized Edit Params       |
|------------------------------------------------------------------------------------------------|-------------|---------------------------------------------------------------------------------------------------------------|---------------------------------------|
| [TextBox](https://blazor.syncfusion.com/documentation/textbox/getting-started-webapp)          | DefaultEdit | The `DefaultEdit` type renders a TextBox component for string data type columns. To customize the `TextBox` component, refer to the [TextBox API documentation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html) for detailed information on available properties. | Params: { ShowClearButton: true } |

The following sample code demonstrates the customization applied to the TextBox component of the **CustomerID** Grid column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using BlazorApp1.Data
<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" EditType="EditType.DefaultEdit" EditorSettings="@CustomerEditParams" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public IEditorSettings CustomerEditParams = new StringEditCellParams
        {
            Params = new TextBoxModel() { ShowClearButton = true }
        };
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID; 
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htLfMhCpUkUNGHdd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize NumericTextBox component of NumericEdit type 

The [NumericEditCellParams](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.NumericEditCellParams.html) class allows customization of the NumericTextBox component in the Grid **EditForm** for columns with numeric data types. By configuring the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) property of a GridColumn, you can modify the properties and behavior of the NumericTextBox component.

The table below highlights the key aspects of customizing a NumericTextBox control using the `EditorSettings` property of a GridColumn:

| Component                                                                                      | Edit Type   | Description                                                                                                   | Example Customized Edit Params       |
|------------------------------------------------------------------------------------------------|-------------|---------------------------------------------------------------------------------------------------------------|---------------------------------------|
| [NumericTextBox](https://blazor.syncfusion.com/documentation/numeric-textbox/getting-started)  | NumericEdit | Renders a NumericTextBox component for integer, double, float, short, byte, long, long double, and decimal data type columns. Refer to the [NumericTextBox API documentation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html) for more properties. | Params: { decimals: 2, value: 5 }    |

Below is an example demonstrating how to customize the NumericTextBox component for the **Freight** column in a Syncfusion DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using BlazorApp1.Data
<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" EditType="EditType.NumericEdit" EditorSettings="@NumericEditParams" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" ValidationRules="@(new ValidationRules{ Required=true})" EditType="EditType.DropDownEdit" Width="150">
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public IEditorSettings NumericEditParams = new NumericEditCellParams
    {
        Params = new NumericTextBoxModel<object>() { ShowClearButton = true, ShowSpinButton = false, Decimals=0, Format="N" }
    };
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID; 
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrTCVWpJWVwPDpT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Restrict decimal points in a NumericTextBox while editing a numeric column

By default, the `NumericTextBox` component allows entering decimal values with up to two decimal places when editing a numeric column. However, there may be scenarios where you want to restrict input to whole numbers only, without any decimal points. In such cases, you can use the [ValidateDecimalOnType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_ValidateDecimalOnType) and [Decimals](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_Decimals) properties provided by Syncfusion's `NumericTextBox` component.

The `ValidateDecimalOnType` property controls whether decimal points are allowed during input in the NumericTextBox. By default, it is set to **false**, allowing decimal points to be entered. When set to **true**, decimal points are restricted, and only whole numbers can be entered.

The `Decimals` property specifies the number of decimal places displayed in the NumericTextBox. By default, it is set to 2, meaning two decimal places will be displayed. You can modify this value to customize the decimal places according to your requirements.

In the example below, while editing a row, the NumericTextBox in the **Freight** column restricts input to whole numbers by disabling decimal points.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using BlazorApp1.Data
<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true, Min=1,Max=1000})" EditType="EditType.NumericEdit" EditorSettings="@FreightEditParams" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" ValidationRules="@(new ValidationRules{ Required=true})" EditType="EditType.DropDownEdit" Width="150">
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public IEditorSettings FreightEditParams = new NumericEditCellParams
    {
            Params = new NumericTextBoxModel<object>() { 
                ValidateDecimalOnType= true,
                Decimals= 0,
                Format= "N" ,
                ShowSpinButton=true
            }
    };
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID; 
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLziLMHBZggNEbl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize DropDownList component of DropDownEdit type

The [DropDownEditCellParams](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.DropDownEditCellParams.html) class allows you to customize the DropDownList component in the Grid **EditForm** for columns with string data types. By configuring the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) property of a GridColumn, you can adjust the DropDownList component's properties and behavior to suit your requirements.

The table below outlines the key aspects of customizing a DropDownList control using the `EditorSettings` property of a GridColumn:

| Component                                                                                      | Edit Type     | Description                                                                                                                                              | Example Customized Edit Params     |
|------------------------------------------------------------------------------------------------|---------------|----------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------|
| [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) | DropDownEdit | Renders a DropDownList component for string data type columns. Refer to the [DropDownList API documentation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html) for more customization options. | Params = { Value: 'Germany' }       |

> **Note:** The `DataSource` property in `DropDownListModel` must be of type `IEnumerable<TItem>`. Avoid binding `string[]` or `List<string>` directly to the `DataSource` property.

Below is an example demonstrating how to customize the DropDownList component for the **ShipCity** column in a Syncfusion DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data
<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true, Min=1,Max=1000})" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" ValidationRules="@(new ValidationRules{ Required=true})" EditType="EditType.DropDownEdit" EditorSettings="@DropDownParams" Width="150">
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public IEditorSettings DropDownParams = new DropDownEditCellParams
        {
            Params = new DropDownListModel<object,object>() { ShowClearButton = true, PopupHeight="120" }
        };

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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID; 
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVfMrCdhCGwIKJJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Provide custom data source for DropDownList component

In Syncfusion’s Blazor DataGrid component, you can provide a custom data source for the DropDownList component used in the **EditForm**. This feature allows you to define a specific set of values for the DropDownList, tailoring it to meet your requirements.

To achieve this, use the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) property of the Grid column to specify the custom data source and additional configurations for the DropDownList. Additionally, when setting a new data source, you can define a [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_Query) property to filter or retrieve specific data for the DropDownList.

Below is an example demonstrating how to provide a custom data source for the **ShipCountry** column while editing in the DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data
<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true, Min=1,Max=1000})" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" ValidationRules="@(new ValidationRules{ Required=true})" EditType="EditType.DropDownEdit" EditorSettings="@DropDownParams" Width="150">
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public static List<OrderData> CustomData = new List<OrderData> {
        new OrderData() { ShipCountry= "France" },
        new OrderData() { ShipCountry= "Germany" },
        new OrderData() { ShipCountry= "India" }
    };
    public IEditorSettings DropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomData, Query = new Syncfusion.Blazor.Data.Query() }
    };
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID, TimeOnly? OrderTime)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1, new TimeOnly(9, 30, 0)));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2, new TimeOnly(10, 0, 0)));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", 3, new TimeOnly(14, 15, 0)));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1, new TimeOnly(11, 45, 0)));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2, new TimeOnly(13, 0, 0)));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3, new TimeOnly(16, 30, 0)));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2, new TimeOnly(8, 0, 0)));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", 1, new TimeOnly(10, 30, 0)));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3, new TimeOnly(9, 45, 0)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string? CustomerID { get; set; }
    public string? ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipCountry { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLTWhiHBprRSZPy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Apply Filtering for DropDownList Component

The Syncfusion Blazor DataGrid component supports filtering for the DropDownList within the **EditForm**. This feature enables users to select options from a predefined list and search for specific items using the built-in filtering functionality.

To enable filtering, set the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowFiltering) property to **true** within the [DropDownEditCellParams](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.DropDownEditCellParams.html). This activates the filtering feature in the DropDownList.

In the following example, filtering is enabled for the **ShipCountry** column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data
<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true, Min=1,Max=1000})" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" ValidationRules="@(new ValidationRules{ Required=true})" EditType="EditType.DropDownEdit" EditorSettings="@DropDownParams" Width="150">
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }

    public IEditorSettings DropDownParams = new DropDownEditCellParams
        {
            Params = new DropDownListModel<object,object>() { AllowFiltering=true }
        };

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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID; 
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLTsVMdrosEQULA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize CheckBox Component of BooleanEdit Type

The [BooleanEditCellParams](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.BooleanEditCellParams.html) class enables customization of the CheckBox component in the Grid **EditForm** for columns with boolean data types. By configuring the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) property of a GridColumn, you can modify the CheckBox component's properties and behavior to suit your requirements.

The table below highlights the key aspects of customizing a DropDownList control using the `EditorSettings` property of a GridColumn:

| Component  | Edit Type    | Description                                                                                              | Example Customized Edit Params |
|------------|--------------|----------------------------------------------------------------------------------------------------------|---------------------------------|
| [CheckBox](https://blazor.syncfusion.com/documentation/check-box/getting-started-with-web-app) | BooleanEdit  | Renders a CheckBox component for boolean data type columns. Refer to the [CheckBox API documentation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox.html) for more customization options. | Params: { Checked: true }      |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Calendars
@using BlazorApp1.Data
<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="yyyy-MM-dd" Type="ColumnType.DateOnly" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.IsVerified) HeaderText="Verified" EditType="EditType.BooleanEdit" TextAlign="TextAlign.Center" DisplayAsCheckBox="true" Width="120" EditorSettings="@VerifiedEditParams"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public IEditorSettings VerifiedEditParams = new BooleanEditCellParams
    {
        Params = new CheckBoxModel<bool>() { Disabled = true }
    };
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID; 
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrTsLCxTsZNVXjP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize DatePicker Component of DatePickerEdit Type

The [DateEditCellParams](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.DatePickerEditCellParams.html) class enables customization of the DatePicker and DateTimePicker component in the Grid **EditForm** for columns with Date data types. By configuring the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) property of a GridColumn, you can modify the CheckBox component's properties and behavior to suit your requirements.

The table below highlights the key aspects of customizing a DatePicker control using the `EditorSettings` property of a GridColumn:

| Component  | Edit Type    | Description                                                                                              | Example Customized Edit Params |
|------------|--------------|----------------------------------------------------------------------------------------------------------|---------------------------------|
| [DatePicker](https://blazor.syncfusion.com/documentation/datepicker/getting-started-with-web-app) | DatePickerEdit  | The DatePickerEdit type renders a DatePicker component for date data type columns. To customize the DatePicker component, refer to the [DatePicker API documentation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html) for detailed information on available properties. | Params: { Format:’dd.MM.yyyy’ }      |

Below is an example demonstrating how to customize the DatePicker component for the **OrderDate** column in the Syncfusion DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="yyyy-MM-dd" Type="ColumnType.Date" EditorSettings="@DateEditParams" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.IsVerified) HeaderText="Verified" EditType="EditType.BooleanEdit" TextAlign="TextAlign.Center" DisplayAsCheckBox="true" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
    public IEditorSettings DateEditParams { get; set; } = new DateEditCellParams
    {
        Params = new DatePickerModel
        {
            ShowClearButton = false,
            EnableRtl = true,
        }
    };
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID, TimeOnly? OrderTime)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1, new TimeOnly(9, 30, 0)));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2, new TimeOnly(10, 0, 0)));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", 3, new TimeOnly(14, 15, 0)));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1, new TimeOnly(11, 45, 0)));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2, new TimeOnly(13, 0, 0)));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3, new TimeOnly(16, 30, 0)));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2, new TimeOnly(8, 0, 0)));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", 1, new TimeOnly(10, 30, 0)));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3, new TimeOnly(9, 45, 0)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string? CustomerID { get; set; }
    public string? ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipCountry { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
}
{% endhighlight %}
{% endtabs %}

## Customize TimePicker Component of TimePickerEdit Type

The [TimeEditCellParams](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.TimeEditCellParams.html) class enables customization of the DatePicker and DateTimePicker component in the Grid **EditForm** for columns with Date data types. By configuring the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) property of a GridColumn, you can modify the CheckBox component's properties and behavior to suit your requirements.

The table below highlights the key aspects of customizing a TimePicker control using the `EditorSettings` property of a GridColumn:

| Component  | Edit Type    | Description                                                                                              | Example Customized Edit Params |
|------------|--------------|----------------------------------------------------------------------------------------------------------|---------------------------------|
| [TimePicker](https://blazor.syncfusion.com/documentation/timepicker/getting-started-with-web-app) | TimePickerEdit  | The TimePickerEdit type renders a TimePicker component for time data type columns. To customize the TimePicker component, refer to the [TimePicker API documentation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html) for detailed information on available properties. | Params: { Value: new Date() }    |

Below is an example demonstrating how to customize the DatePicker component for the **OrderTime** column in the Syncfusion DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderTime) EditorSettings="@TimeEditParams" EditType="EditType.TimePickerEdit" TextAlign="TextAlign.Right" Type="ColumnType.TimeOnly" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
    public IEditorSettings TimeEditParams = new TimeEditCellParams
        {
            Params = new TimePickerModel<object>() { ShowClearButton= false }
        };
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
namespace BlazorApp1.Data
{
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();

        public OrderData() { }

        public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID, TimeOnly? OrderTime)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipName = ShipName;
            this.Freight = Freight;
            this.OrderDate = OrderDate;
            this.ShippedDate = ShippedDate;
            this.IsVerified = IsVerified;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
            this.EmployeeID = employeeID;
            this.OrderTime = OrderTime;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count == 0)
            {
                Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1, new TimeOnly(9, 30, 0)));
                Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2, new TimeOnly(10, 0, 0)));
                Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", 3, new TimeOnly(14, 15, 0)));
                Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1, new TimeOnly(11, 45, 0)));
                Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2, new TimeOnly(13, 0, 0)));
                Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3, new TimeOnly(16, 30, 0)));
                Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2, new TimeOnly(8, 0, 0)));
                Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", 1, new TimeOnly(10, 30, 0)));
                Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3, new TimeOnly(9, 45, 0)));
            }
            return Orders;
        }

        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public string? ShipName { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool? IsVerified { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipCountry { get; set; }
        public int EmployeeID { get; set; }
        public TimeOnly? OrderTime { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrfWhWRHKMBbbnG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render custom cell editors

The Syncfusion Blazor DataGrid allows you to render custom cell editors for particular columns. This feature is particularly useful when you need to use custom components to edit the data within a Gridcolumn. To achieve this, you can make use of the [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) of the Grid Column component.

N > Before adding edit template to the datagrid, it is recommended to go through the [template](https://blazor.syncfusion.com/documentation/datagrid/templates) section topic to configure the template.

> Custom components inside the `EditTemplate` must be specified with two-way (@bind-Value) binding to reflect the changes in Grid.

### Render textArea in edit form 

The Syncfusion Blazor DataGrid allows you to render a textArea within the Grid's edit form for a specific column. This feature is especially valuable when you need to edit and display multi-line text content, providing an efficient way to manage extensive text data within the Grid's columns.

To render a textArea in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) in the GridColumn. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

> When using a text area, please use **Shift+Enter** to move to the next line. By default, pressing **Enter** will trigger a record update while you are in edit mode.

The following example demonstrates how to render a textArea component in the **ShipAdress** column of the Syncfusion Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using BlazorApp1.Data
<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true, Min=1,Max=1000})" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="OrderDate" Format="dd-MM-yyyy" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true})" EditType="EditType.DatePickerEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipAddress) HeaderText="Ship Address" Width="150">
            <EditTemplate>
                <SfTextArea @bind-Value="@((context as OrderData).ShipAddress)" FloatLabelType="@FloatLabelType.Auto" Placeholder="Enter your address"></SfTextArea>
            </EditTemplate>
            <Template>
                <div style="white-space: pre-wrap;">@((context as OrderData).ShipAddress)</div>
            </Template>
        </GridColumn>
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, string ShipAddress, int employeeID, TimeOnly? OrderTime)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", "12 Rue des Fleurs", 1, new TimeOnly(9, 30, 0)));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", "45 Straße der Nationen", 2, new TimeOnly(10, 0, 0)));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", "89 MG Road", 3, new TimeOnly(14, 15, 0)));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", "23 Rue Victor Hugo", 1, new TimeOnly(11, 45, 0)));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", "78 Rue de l'Industrie", 2, new TimeOnly(13, 0, 0)));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", "5 Bahnhofstrasse", 3, new TimeOnly(16, 30, 0)));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", "12 Rue de Mont Blanc", 2, new TimeOnly(8, 0, 0)));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", "7 Residency Road", 1, new TimeOnly(10, 30, 0)));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", "15 Rue de Rivoli", 3, new TimeOnly(9, 45, 0)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string? ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLTCBinRSrHTcKR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Render AutoComplete component in edit form

The Syncfusion Blazor DataGrid allows you to render a AutoComplete component within the Grid's edit form for a specific column. This feature is especially valuable when you need to provide a dropdown-like auto-suggestion and input assistance for data entry in the Grid’s columns.

To render a AutoComplete in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) in the GridColumn. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

The following example demonstrates how to render an AutoComplete component in the CustomerID column of the Syncfusion Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150">
            <EditTemplate>
                <SfAutoComplete ID="CustomerID" TItem="OrderData" TValue="string" @bind-Value="@((context as OrderData).CustomerID)" DataSource="@Orders">
                    <AutoCompleteFieldSettings Value="CustomerID"></AutoCompleteFieldSettings>
                </SfAutoComplete>
            </EditTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true, Min=1,Max=1000})" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="OrderDate" Format="dd-MM-yyyy" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true})" EditType="EditType.DatePickerEdit" Width="120"></GridColumn>
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, string ShipAddress, int employeeID, TimeOnly? OrderTime)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", "12 Rue des Fleurs", 1, new TimeOnly(9, 30, 0)));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", "45 Straße der Nationen", 2, new TimeOnly(10, 0, 0)));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", "89 MG Road", 3, new TimeOnly(14, 15, 0)));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", "23 Rue Victor Hugo", 1, new TimeOnly(11, 45, 0)));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", "78 Rue de l'Industrie", 2, new TimeOnly(13, 0, 0)));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", "5 Bahnhofstrasse", 3, new TimeOnly(16, 30, 0)));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", "12 Rue de Mont Blanc", 2, new TimeOnly(8, 0, 0)));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", "7 Residency Road", 1, new TimeOnly(10, 30, 0)));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", "15 Rue de Rivoli", 3, new TimeOnly(9, 45, 0)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string? ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
}
{% endhighlight %}
{% endtabs %}

### Render MaskedTextBox component in edit form

The Syncfusion Grid allows you to render a MaskedTextBox component within the Grid's edit form for a specific column. This feature is especially useful when you need to provide masked input fields that require a specific format, such as phone numbers or postal codes.

To render a MaskedTextBox in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) in the GridColumn. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

Here’s an example of how to render a MaskedTextBox component in the CustomerNumber column of the Syncfusion Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerNumber) HeaderText="Customer Number" Width="140">
            <EditTemplate>
                <SfMaskedTextBox Mask='000-000-0000' @bind-Value="@((context as OrderData).CustomerNumber)"></SfMaskedTextBox>
            </EditTemplate>
        </GridColumn>
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

     public OrderData() { }

     public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, string ShipAddress, int employeeID, TimeOnly? OrderTime, string CustomerNumber)
     {
         this.OrderID = OrderID;
         this.CustomerID = CustomerID;
         this.ShipName = ShipName;
         this.Freight = Freight;
         this.OrderDate = OrderDate;
         this.ShippedDate = ShippedDate;
         this.IsVerified = IsVerified;
         this.ShipCity = ShipCity;
         this.ShipCountry = ShipCountry;
         this.ShipAddress = ShipAddress;
         this.EmployeeID = employeeID;
         this.OrderTime = OrderTime;
         this.CustomerNumber = CustomerNumber;
     }

     public static List<OrderData> GetAllRecords()
     {
         if (Orders.Count == 0)
         {
             Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", "12 Rue des Fleurs", 1, new TimeOnly(9, 30, 0), "9755378589"));
             Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", "45 Straße der Nationen", 2, new TimeOnly(10, 0, 0), "9876543210"));
             Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", "89 MG Road", 3, new TimeOnly(14, 15, 0), "9123456789"));
             Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", "23 Rue Victor Hugo", 1, new TimeOnly(11, 45, 0), "9012345678"));
             Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", "78 Rue de l'Industrie", 2, new TimeOnly(13, 0, 0), "8888888888"));
             Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", "5 Bahnhofstrasse", 3, new TimeOnly(16, 30, 0), "7777777777"));
             Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", "12 Rue de Mont Blanc", 2, new TimeOnly(8, 0, 0), "6666666666"));
             Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", "7 Residency Road", 1, new TimeOnly(10, 30, 0), "9999999999"));
             Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", "15 Rue de Rivoli", 3, new TimeOnly(9, 45, 0), "5555555555"));
         }
         return Orders;
     }

     public int OrderID { get; set; }
     public string CustomerID { get; set; }
     public string ShipName { get; set; }
     public double? Freight { get; set; }
     public DateTime? OrderDate { get; set; }
     public DateTime? ShippedDate { get; set; }
     public bool? IsVerified { get; set; }
     public string ShipCity { get; set; }
     public string ShipCountry { get; set; }
     public string ShipAddress { get; set; }
     public int EmployeeID { get; set; }
     public TimeOnly? OrderTime { get; set; }
     public string CustomerNumber { get; set; } 
 }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrfsBiwLfMauJYY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Render DropDownList component in edit form

The Syncfusion Grid allows you to render a DropDownList component within the Grid’s edit form for a specific column. This feature is valuable when you need to provide a convenient way to select options from a predefined list while editing data in the Grid's edit form.

To render a DropDownList in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) in the GridColumn. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

The following example demonstrates how to render a DropDownList component in the **ShipCountry** column of the Syncfusion Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="dd-MM-yyyy" Type="ColumnType.Date" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150">
            <EditTemplate>
                <SfDropDownList ID="ShipCountry" TItem="Country" TValue="string" @bind-Value="@((context as OrderData).ShipCountry)" DataSource="@Countries">
                    <DropDownListFieldSettings Value="CountryName" Text="CountryName"></DropDownListFieldSettings>
                </SfDropDownList>
            </EditTemplate>
        </GridColumn>
         </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public List<Country> Countries { get; set; } = new List<Country>()
    {
        new Country(){ CountryName="France", ID=1},
        new Country(){ CountryName="Germany", ID=2},
        new Country(){ CountryName="India", ID=3},
        new Country(){ CountryName="Switzerland", ID=4},
        new Country(){ CountryName="Belgium", ID=5},
    };
    public class Country
    {
        public string CountryName { get; set; }
        public int ID { get; set; }
    }
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, string ShipAddress, int employeeID, TimeOnly? OrderTime)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", "12 Rue des Fleurs", 1, new TimeOnly(9, 30, 0)));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", "45 Straße der Nationen", 2, new TimeOnly(10, 0, 0)));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", "89 MG Road", 3, new TimeOnly(14, 15, 0)));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", "23 Rue Victor Hugo", 1, new TimeOnly(11, 45, 0)));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", "78 Rue de l'Industrie", 2, new TimeOnly(13, 0, 0)));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", "5 Bahnhofstrasse", 3, new TimeOnly(16, 30, 0)));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", "12 Rue de Mont Blanc", 2, new TimeOnly(8, 0, 0)));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", "7 Residency Road", 1, new TimeOnly(10, 30, 0)));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", "15 Rue de Rivoli", 3, new TimeOnly(9, 45, 0)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string? ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
}
{% endhighlight %}
{% endtabs %}

### Render images in the DropDownList editor component using the ItemTemplate

The Syncfusion Blazor DataGrid allows you to render images in the DropDownList editor component. This feature is valuable when you want to display images for each item in the dropdown list of a particular column, enhancing the visual representation of your data.

To render a DropDownList in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) in the GridColumn. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

To display an image in the DropDownList editor component, you can utilize the ItemTemplate property of DropDownList. This property allows you to customize the content of each item in the dropdown list.

The following example demonstrates how to render images in the DropDownList editor component using the ItemTemplate within the EmployeeName column of the Syncfusion Blazor DataGrid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderData.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="120">
            <EditTemplate>
                @if (context is OrderData order)
                {
                    <SfDropDownList TValue="int" TItem="EmployeeData" @bind-Value="order.EmployeeID" DataSource="@Employees" Placeholder="Select Employee">
                        <DropDownListFieldSettings Value="EmployeeID" Text="FirstName"></DropDownListFieldSettings>
                        <DropDownListTemplates TItem="EmployeeData">
                            <ItemTemplate Context="employee">
                                <div style="display: flex; align-items: center;">
                                    <img src="@($"scripts/Images/Employees/{employee.EmployeeID}.png")" alt="Employee" style="width: 50px;" />
                                    <span>@employee.FirstName</span>
                                </div>
                            </ItemTemplate>
                        </DropDownListTemplates>
                    </SfDropDownList>
                }
            </EditTemplate>
        </GridForeignColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
        Employees = EmployeeData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, string ShipAddress, int employeeID, TimeOnly? OrderTime, string CustomerNumber)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
        this.CustomerNumber = CustomerNumber;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", "12 Rue des Fleurs", 1, new TimeOnly(9, 30, 0), "9755378589"));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", "45 Straße der Nationen", 2, new TimeOnly(10, 0, 0), "9876543210"));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", "89 MG Road", 3, new TimeOnly(14, 15, 0), "9123456789"));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", "23 Rue Victor Hugo", 4, new TimeOnly(11, 45, 0), "9012345678"));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", "78 Rue de l'Industrie", 5, new TimeOnly(13, 0, 0), "8888888888"));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", "5 Bahnhofstrasse", 6, new TimeOnly(16, 30, 0), "7777777777"));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", "12 Rue de Mont Blanc", 7, new TimeOnly(8, 0, 0), "6666666666"));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", "7 Residency Road", 8, new TimeOnly(10, 30, 0), "9999999999"));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", "15 Rue de Rivoli", 9, new TimeOnly(9, 45, 0), "5555555555"));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
    public string CustomerNumber { get; set; } 
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeData.cs" %}
public class EmployeeData
{
    public static List<EmployeeData> Employees = new List<EmployeeData>();

    public EmployeeData() { }

    public EmployeeData(
        int EmployeeID, string FirstName, string LastName,
        string Title, string Country, string City,
        DateTime HireDate)
    {
        this.EmployeeID = EmployeeID;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Title = Title;
        this.Country = Country;
        this.City = City;
        this.HireDate = HireDate;
        this.ImageURL = ImageURL;
    }
    public static List<EmployeeData> GetAllRecords()
    {
        if (Employees.Count == 0)
        {
            Employees = new List<EmployeeData>
            {
                new EmployeeData(1, "Nancy", "Davolio", "Sales Representative", "USA", "New York", DateTime.Parse("2012-01-01")),
                new EmployeeData(2, "Andrew", "Fuller", "Vice President, Sales", "UK", "London", DateTime.Parse("2010-03-15")),
                new EmployeeData(3, "Janet", "Leverling", "Sales Manager", "USA", "Seattle", DateTime.Parse("2015-06-23")),
                new EmployeeData(4, "Margaret", "Peacock", "Inside Sales Coordinator", "UAE", "Dubai", DateTime.Parse("2018-09-10")),
                new EmployeeData(5, "Steven", "Buchanan", "Sales Representative", "NED", "Amsterdam", DateTime.Parse("2017-04-17")),
                new EmployeeData(6, "Michael", "Suyama", "Sales Manager", "BER", "Berlin", DateTime.Parse("2013-02-12")),
                new EmployeeData(7, "Anne", "Dodsworth", "Sales Representative", "USA", "Boston", DateTime.Parse("2016-11-05")),
                new EmployeeData(8, "Laura", "Callahan", "Sales Coordinator", "UK", "Manchester", DateTime.Parse("2019-08-19")),
                new EmployeeData(9, "Robert", "King", "Sales Representative", "USA", "Los Angeles", DateTime.Parse("2020-07-21")),
                new EmployeeData(10, "John", "Doe", "Regional Manager", "Canada", "Toronto", DateTime.Parse("2014-05-20"))
            };
        }
        return Employees;
    }

    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public DateTime HireDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

![Render images in the DropDownList editor component using the ItemTemplate](./images/blazor-datagrid-render-image-using-item-template.gif)

### Render Multiple columns in DropDownList component

The Syncfusion Blazor DataGrid allows you to render a DropDownList component within the Grid's edit form for a specific column. This feature is particularly useful when you want to display more detailed information for each item in the dropdown list during editing a specific column.

To render a DropDownList in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) for the Grid column. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

The DropDownList has been provided with several options to customize each list item, group title, selected value, header, and footer element. By default, list items can be rendered as a single column in the DropDownList component. Instead of this, multiple columns can be rendered. This can be achieved by using the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HeaderTemplate) and [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) properties of the DropDownList component.

The following example demonstrates how to render a DropDownList component with multiple columns within in the ShipCountry column. 

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150">
            <EditTemplate>
                @if (context is OrderData order)
                {
                    <SfDropDownList TValue="string" TItem="Country"
                                    @bind-Value="order.ShipCountry" DataSource="@Countries"
                                    Placeholder="Select Country" CssClass="e-multi-column">
                        <DropDownListFieldSettings Value="CountryName" Text="CountryName" />
                        <DropDownListTemplates TItem="Country">
                            <HeaderTemplate>
                                <div>
                                    <span>ID</span>
                                    <span>Country</span>
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate Context="country">
                                <div>
                                    <span>@country.ID</span>
                                    <span>@country.CountryName</span>
                                </div>
                            </ItemTemplate>
                        </DropDownListTemplates>
                    </SfDropDownList>
                }
            </EditTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public List<Country> Countries { get; set; } = new List<Country>()
    {
        new Country(){ CountryName="France", ID=1},
        new Country(){ CountryName="Germany", ID=2},
        new Country(){ CountryName="India", ID=3},
        new Country(){ CountryName="Switzerland", ID=4},
        new Country(){ CountryName="Belgium", ID=5},
    };

    public class Country
    {
        public string CountryName { get; set; }
        public int ID { get; set; }
    }
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, string ShipAddress, int employeeID, TimeOnly? OrderTime)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", "12 Rue des Fleurs", 1, new TimeOnly(9, 30, 0)));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", "45 Straße der Nationen", 2, new TimeOnly(10, 0, 0)));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", "89 MG Road", 3, new TimeOnly(14, 15, 0)));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", "23 Rue Victor Hugo", 1, new TimeOnly(11, 45, 0)));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", "78 Rue de l'Industrie", 2, new TimeOnly(13, 0, 0)));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", "5 Bahnhofstrasse", 3, new TimeOnly(16, 30, 0)));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", "12 Rue de Mont Blanc", 2, new TimeOnly(8, 0, 0)));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", "7 Residency Road", 1, new TimeOnly(10, 30, 0)));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", "15 Rue de Rivoli", 3, new TimeOnly(9, 45, 0)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string? ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhJMLWbrwBsJFQa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To learn more about the available templates in the DropDownList component, check the [documentation](https://blazor.syncfusion.com/documentation/dropdown-list/templates).

### Render ComboBox component in edit form 

The Syncfusion Blazor DataGrid allows you to render a ComboBox component within the Grid's edit form for a specific column. This feature is especially valuable when you need to provide a drop-down selection with auto-suggestions for data entry.

To render a ComboBox in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) in the GridColumn. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

The following example demonstrates how to render a ComboBox component in the **ShipCountry** column of the Syncfusion Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
<GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true, Min=1,Max=1000})" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="OrderDate" Format="dd-MM-yyyy" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true})" EditType="EditType.DatePickerEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150">
            <EditTemplate>
                <SfComboBox ID="ShipCountry" TItem="Country" TValue="string" @bind-Value="@((context as OrderData).ShipCountry)" DataSource="@Countries">
                    <ComboBoxFieldSettings Value="CountryName" Text="CountryName"></ComboBoxFieldSettings>
                </SfComboBox>
            </EditTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
    public List<Country> Countries { get; set; } = new List<Country>()
    {
        new Country(){ CountryName="France", ID=1},
        new Country(){ CountryName="Germany", ID=2},
        new Country(){ CountryName="India", ID=3},
        new Country(){ CountryName="Switzerland", ID=4},
        new Country(){ CountryName="Belgium", ID=5},
    };
    public class Country
    {
        public string CountryName { get; set; }
        public int ID { get; set; }
    }
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, string ShipAddress, int employeeID, TimeOnly? OrderTime)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", "12 Rue des Fleurs", 1, new TimeOnly(9, 30, 0)));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", "45 Straße der Nationen", 2, new TimeOnly(10, 0, 0)));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", "89 MG Road", 3, new TimeOnly(14, 15, 0)));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", "23 Rue Victor Hugo", 1, new TimeOnly(11, 45, 0)));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", "78 Rue de l'Industrie", 2, new TimeOnly(13, 0, 0)));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", "5 Bahnhofstrasse", 3, new TimeOnly(16, 30, 0)));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", "12 Rue de Mont Blanc", 2, new TimeOnly(8, 0, 0)));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", "7 Residency Road", 1, new TimeOnly(10, 30, 0)));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", "15 Rue de Rivoli", 3, new TimeOnly(9, 45, 0)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string? ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVpWVMQfcIDGLDJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Render TimePicker component in edit form

The Syncfusion Blazor DataGrid allows you to render a TimePicker component within the Grid’s edit form for a specific column. This feature is especially valuable when you need to provide a time input, such as appointment times, event schedules, or any other time-related data for editing in the Grid.

To render a TimePicker in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) in the GridColumn. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

The following example demonstrates how to render a TimePicker component in the **OrderDate** column of the Syncfusion Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="hh:mm tt" DefaultValue="DateTime.Now" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.DateTime">
            <EditTemplate>
                <SfTimePicker TValue="DateTime?" @bind-Value="@((context as OrderData).OrderDate)"></SfTimePicker>
            </EditTemplate>
        </GridColumn>
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, string ShipAddress, int employeeID, TimeOnly? OrderTime, string CustomerNumber)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
        this.CustomerNumber = CustomerNumber;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4, 9, 30, 0), new DateTime(1996, 08, 07), true, "Reims", "France", "12 Rue des Fleurs", 1, new TimeOnly(9, 30, 0), "9755378589"));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5, 10, 0, 0), new DateTime(1996, 08, 07), false, "Münster", "Germany", "45 Straße der Nationen", 2, new TimeOnly(10, 0, 0), "9876543210"));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6, 14, 15, 0), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", "89 MG Road", 3, new TimeOnly(14, 15, 0), "9123456789"));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7, 11, 45, 0), new DateTime(1996, 08, 07), false, "Lyon", "France", "23 Rue Victor Hugo", 4, new TimeOnly(11, 45, 0), "9012345678"));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8, 13, 0, 0), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", "78 Rue de l'Industrie", 5, new TimeOnly(13, 0, 0), "8888888888"));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9, 16, 30, 0), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", "5 Bahnhofstrasse", 6, new TimeOnly(16, 30, 0), "7777777777"));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10, 8, 0, 0), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", "12 Rue de Mont Blanc", 7, new TimeOnly(8, 0, 0), "6666666666"));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11, 10, 30, 0), new DateTime(1996, 08, 07), false, "Resende", "India", "7 Residency Road", 8, new TimeOnly(10, 30, 0), "9999999999"));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12, 9, 45, 0), new DateTime(1996, 08, 07), true, "Paris", "France", "15 Rue de Rivoli", 9, new TimeOnly(9, 45, 0), "5555555555"));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
    public string CustomerNumber { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLJiLsFKiBkUUQg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Render MultiSelect component in edit form

The Syncfusion Blazor DataGrid allows you to render a MultiSelect component within the Grid’s edit form, enabling you to select multiple values from a dropdown list when editing a specific column. This feature is particularly useful when you need to handle situations where multiple selections are required for a column.

To render a TimePicker in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) in the GridColumn. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

The following example demonstrates how to render a MultiSelect component in the ShipCity column of the Syncfusion Grid:

### Render RichTextEditor component in edit form

The Syncfusion Grid allows you to render the RichTextEditor component within the edit form. This feature is valuable when you need to format and style text content using various formatting options such as bold, italic, underline, bullet lists, numbered lists, and more during editing a specific column.

To render a RichTextEditor in the edit form, you need to define an [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) in the GridColumn. The `EditTemplate` property specifies the cell edit template that used as an editor for a particular column. It can accept either a template string or an HTML element ID.

Additionally, you need set the [AllowTextWrap]() property of the corresponding grid column to **true**. By enabling this property, the rich text editor component will automatically adjust its width and wrap the text content to fit within the boundaries of the column.

The following example demonstrates how to render a RichTextEditor component in the ShipAddress column of the Syncfusion Grid. 

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.RichTextEditor
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@Syncfusion.Blazor.Grids.EditMode.Normal"></GridEditSettings>
    <GridColumns>
    <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID"   Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="100" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipAddress) HeaderText="Ship Address" Width="150" DisableHtmlEncode=false>
            <EditTemplate>
                <SfRichTextEditor ID="ShipAddress" @bind-value="@((context as OrderData).ShipAddress)" />
            </EditTemplate>
        </GridColumn> 
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

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, string ShipAddress, int employeeID, TimeOnly? OrderTime)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.EmployeeID = employeeID;
        this.OrderTime = OrderTime;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", "12 Rue des Fleurs", 1, new TimeOnly(9, 30, 0)));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", "45 Straße der Nationen", 2, new TimeOnly(10, 0, 0)));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "India", "89 MG Road", 3, new TimeOnly(14, 15, 0)));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", "23 Rue Victor Hugo", 1, new TimeOnly(11, 45, 0)));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", "78 Rue de l'Industrie", 2, new TimeOnly(13, 0, 0)));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", "5 Bahnhofstrasse", 3, new TimeOnly(16, 30, 0)));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", "12 Rue de Mont Blanc", 2, new TimeOnly(8, 0, 0)));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "India", "7 Residency Road", 1, new TimeOnly(10, 30, 0)));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", "15 Rue de Rivoli", 3, new TimeOnly(9, 45, 0)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string? ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public int EmployeeID { get; set; }
    public TimeOnly? OrderTime { get; set; }
}
{% endhighlight %}
{% endtabs %}
