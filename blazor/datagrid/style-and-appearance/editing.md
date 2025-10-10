---
layout: post
title: Customize editing in Blazor DataGrid | Syncfusion
description: Learn how to style and customize edited and added rows, input fields, the edit dialog header, and command buttons in the Syncfusion Blazor DataGrid using CSS.
platform: Blazor
control: DataGrid
documentation: ug
---

# Editing customization in Syncfusion Blazor DataGrid

The appearance of editing-related elements in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be customized using CSS. Styling options are available for:
- Edited and newly added rows
- Input fields within the edit form
- Edit dialog header
- Command column buttons

N> - Enable editing with [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) and configure [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) to include actions like add, edit, delete, and update.
- Customize dialog headers when [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) is set to `Dialog`.
- Command button icon colors are based on the theme’s icon font. Use browser inspection tools to check class names and glyph codes.
- When using CSS isolation (.razor.css), use the **::deep** selector to reach internal parts of the DataGrid, or place the grid inside a custom wrapper class and apply styles to that wrapper for better control.
- Maintain strong color contrast and clear focus indicators to support accessibility and improve readability.

## Customizing Edited and Added Row Elements

The **.e-editedrow** and **.e-addedrow** classes are used to style the edited and added rows in the Blazor DataGrid. To change its appearance, apply CSS:

```css
.e-grid .e-editedrow table, .e-grid .e-addedrow table {
	    background-color: #62b2eb;
}
```

Style properties such as `background-color` can be modified to visually distinguish rows that are being edited or newly added.

![Blazor DataGrid added row with custom background color](../images/style-and-appearance/edited-added-row-element.png)
![Blazor DataGrid edited row with custom background color](../images/style-and-appearance/edited-added-row-element-2.png)

## Customizing Edited Row Input Elements

The **.e-gridform** and **.e-input** classes are used to style input elements within the edit form of the Blazor DataGrid. To change its appearance, apply CSS:

```css

.e-grid .e-gridform .e-rowcell .e-input-group .e-input {
    font-family: cursive;
    color:rgb(214, 33, 123)
}

```
Style properties such as `font-family` and `color` can be modified to improve the readability and visual appeal of editable fields.

![Blazor DataGrid edited row inputs with custom font and text color](../images/style-and-appearance/edited-row-input-element.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) IsPrimaryKey="true" HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
.e-grid .e-editedrow table, .e-grid .e-addedrow table {
	background-color: #62b2eb;
}
.e-grid .e-gridform .e-rowcell .e-input-group .e-input {
    font-family: cursive;
    color:rgb(214, 33, 123)
}
</style>

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

    public OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Import Export"));
            Orders.Add(new OrderData(10257, "HILAA", "San Cristóbal", "Hila Alimentos"));
            Orders.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Orders.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial"));
            Orders.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Orders.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que delícia"));
            Orders.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htLINOLffsrjCvCt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing the Edit Dialog Header

The **.e-edit-dialog** and **.e-dlg-header-content** classes are used to style the edit dialog header in the Blazor DataGrid when dialog editing is enabled. To change its appearance, apply CSS:

```css

.e-edit-dialog .e-dlg-header-content {
    background-color: #deecf9;
}

```
Style properties such as `background-color` can be modified to visually separate the header from the rest of the dialog content.

![Blazor DataGrid edit dialog header with custom background color](../images/style-and-appearance/edit-dialog-header-element.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.Grids.EditMode.Dialog"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) IsPrimaryKey="true" HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-edit-dialog .e-dlg-header-content {
        background-color: #deecf9;
    }
</style>

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

    public OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Import Export"));
            Orders.Add(new OrderData(10257, "HILAA", "San Cristóbal", "Hila Alimentos"));
            Orders.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Orders.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial"));
            Orders.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Orders.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que delícia"));
            Orders.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBetEhJzsqPbguh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing Command Column Buttons

The **.e-edit**, **.e-delete**, **.e-update**, and **.e-cancel-icon** classes are used to style the command column buttons in the Syncfusion® Blazor DataGrid. These buttons represent actions such as `edit`, `delete`, `update`, and `cancel`. To customize their appearance, apply CSS:

```css

.e-grid .e-delete::before ,.e-grid .e-cancel-icon::before{
    color: #f51717;
}
.e-grid .e-edit::before, .e-grid .e-update::before {
    color: #077005;
}

```
Style properties like `color`, `font-size`, and `font-weight` can be adjusted to differentiate action icons and enhance visibility during interaction.

![Blazor DataGrid command buttons with custom delete and cancel icon colors](../images/style-and-appearance/commandbutton-1.png)
![Blazor DataGrid command buttons with custom edit and save icon colors](../images/style-and-appearance/commandbutton-2.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="100"></GridColumn>
        <GridColumn HeaderText="Manage Records" Width="150">
            <GridCommandColumns>
                <GridCommandColumn Type="CommandButtonType.Edit" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-edit", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Delete" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-delete", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Save" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-update", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Cancel" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-cancel-icon", CssClass = "e-flat" })"></GridCommandColumn>
            </GridCommandColumns>
         </GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-delete::before ,.e-grid .e-cancel-icon::before{
        color: #f51717;
    }
    .e-grid .e-edit::before, .e-grid .e-update::before {
        color: #077005;
    }
</style>

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

    public OrderData(int orderID, string customerID, double freight, string shipCountry)
    {
        OrderID = orderID;
        CustomerID = customerID;
        Freight = freight;
        ShipCountry = shipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "France"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Brazil"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "France"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.30, "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Brazil"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Switzerland"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Switzerland"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Brazil"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "Venezuela"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Austria"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "Mexico"));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Germany"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Brazil"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "USA"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrIjYBTfCdNCmvv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}