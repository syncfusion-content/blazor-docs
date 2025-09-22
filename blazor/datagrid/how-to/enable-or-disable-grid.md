---
layout: post
title: Enable or Disable the Blazor DataGrid | Syncfusion
description: Learn how to enable or disable the entire Syncfusion Blazor DataGrid component to control user interaction with it.
platform: Blazor
control: DataGrid
documentation: ug
---

# Enable or disable Blazor DataGrid and its actions

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be dynamically enabled or disabled by toggling a button. This is useful to restrict user interaction with the Grid during certain application states or processes. The approach below disables interaction at the UI level by applying a CSS class to a wrapper and setting an attribute for styling or accessibility.

To implement this:

* Define a CSS class on the wrapper (`.grid-wrapper.disabled`) to visually and functionally disable the Grid.

```css
.grid-wrapper.disabled {
    opacity: 0.5;
    pointer-events: none;
    touch-action: none;
    cursor: not-allowed;
}
```
* Bind a boolean flag (`isGridDisabled`) to update the wrapper class and an attribute (for example, `aria-disabled`) on the Grid or wrapper.
* Use a button to toggle the flag and control the Grid state.

The following example demonstrates how to enable or disable the Grid and its actions using a button:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-flat" OnClick="ToggleGrid">
    @(isGridDisabled ? "Enable Grid" : "Disable Grid")
</SfButton>

<div class="@(isGridDisabled ? "grid-wrapper disabled" : "grid-wrapper")">
    <SfGrid DataSource="@Orders" @attributes="@GridAttributes" AllowPaging="true" Height="273px" Toolbar="@Toolbar">
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
    .grid-wrapper.disabled {
        opacity: 0.5;
        pointer-events: none;
        touch-action: none;
        cursor: not-allowed;
    }
</style>

@code {
    private bool isGridDisabled = false;
    private Dictionary<string, object> GridAttributes { get; set; } = new();
    public List<OrderDetails> Orders { get; set; }
    private List<string> Toolbar = new() { "Add", "Edit", "Delete", "Update", "Cancel" };

    protected override void OnInitialized()
    {
        GridAttributes.Add("aria-disabled", "false");
        Orders = OrderDetails.GetAllRecords();
    }

    private void ToggleGrid()
    {
        isGridDisabled = !isGridDisabled;
        GridAttributes["aria-disabled"] = isGridDisabled ? "true" : "false";
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjheZIiyqvGbDYvc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}