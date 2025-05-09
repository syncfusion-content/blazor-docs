---
layout: post
title: Enable or Disable the Blazor DataGrid | Syncfusion
description: Learn here all about how to enable or disable the entire Syncfusion Blazor DataGrid and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Enable disable Grid and its actions in Blazor DataGrid

You can enable/disable the Syncfusion Blazor DataGrid and its actions by applying/removing corresponding CSS styles.

To enable/disable the Grid and its actions, follow the given steps:

**Step 1**: Create CSS class with custom style to override the default style of Grid.

```css
    .disablegrid {
        pointer-events: none;
        opacity: 0.4;
    }
    .wrapper {
        cursor: not-allowed;
    }

```

**Step 2**: Add/Remove the CSS class to the Grid in the click event handler of Button.

```cshtml
     private void ToggleGrid()
    {
        if (GridWrapperClass.Contains("disablegrid"))
        {
            GridWrapperClass = "";
        }
        else
        {
            GridWrapperClass = "wrapper disablegrid";
        }
    }
```

In the below demo, the button click will enable/disable the Grid and its actions.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-flat" @onclick="ToggleGrid">Enable/Disable Grid</SfButton>

<div id="GridParent" class="@GridWrapperClass">
    <SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Height="273px"
            Toolbar="@Toolbar">
        <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
        <GridColumns>
            <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" IsPrimaryKey="true" Width="100"></GridColumn>
            <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
            <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" EditType="EditType.NumericEdit" Width="120" Format="C2"></GridColumn>
            <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country"  EditType="EditType.DropDownEdit" Width="150"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

<style>
    .disablegrid {
        opacity: 0.5;
        pointer-events: none;
        cursor: not-allowed;
    }

    .wrapper {
        background-color: #f3f3f3;
        padding: 10px;
        border-radius: 6px;
    }
</style>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; }
    private List<string> Toolbar = new() { "Add", "Edit", "Delete", "Update", "Cancel" };
    private string GridWrapperClass = "";
    protected override void OnInitialized()
    {
         Orders = OrderDetails.GetAllRecords();
    }
    private void ToggleGrid()
    {
        if (GridWrapperClass.Contains("disablegrid"))
        {
            GridWrapperClass = "";
        }
        else
        {
            GridWrapperClass = "wrapper disablegrid";
        }
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();

    public OrderDetails(int orderId, string customerId, string shipCity, string shipName,double freight, DateTime orderDate, string shipCountry)
    {
        this.OrderID = orderId;
        this.CustomerID = customerId;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.Freight = freight;
        this.OrderDate = orderDate;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier", 32.38, new DateTime(2024, 1, 5), "France"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten", 11.61, new DateTime(2024, 1, 7), "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", 65.83, new DateTime(2024, 1, 10), "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock", 41.34, new DateTime(2024, 1, 12), "France"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices", 51.30, new DateTime(2024, 1, 14), "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", 58.17, new DateTime(2024, 1, 16), "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese", 22.98, new DateTime(2024, 1, 18), "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt", 148.33, new DateTime(2024, 1, 20), "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora", 13.97, new DateTime(2024, 1, 22), "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos", 81.91, new DateTime(2024, 1, 24), "Venezuela"));
        }
        return order;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLSZTBAfLsZcZfE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}