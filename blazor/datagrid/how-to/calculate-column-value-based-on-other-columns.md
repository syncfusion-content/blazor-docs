---
layout: post
title: Calculate column value based on other columns in DataGrid | Syncfusion
description: Learn here all about Calculate column value based on other columns in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Calculate Column Value Based on Other Columns in Blazor DataGrid

In the Syncfusion Blazor DataGrid, calculated column values can be displayed by using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property of a [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html). This allows combining or processing values from other columns in each row. The **context** parameter inside the template provides access to the current row data, which can be used to perform custom calculations like addition, subtraction, or any other logic.

In the provided example, a **FinalCost** column is not bound to a direct data field but is instead calculated by adding values from the **ManfCost** and **LabCost** columns for each row. The template reads the context, performs the addition, and displays the result inside a div.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type=ColumnType.Date TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ManfCost) HeaderText="Manufacturing Cost" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.LabCost) HeaderText="Labor Cost" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.FinalCost) HeaderText="Final price" Format="C2" TextAlign="TextAlign.Center" Width="120">
            <Template>
                @{
                    var value = (context as Order);
                    var finalAmount = value.ManfCost + value.LabCost;
                    <div>$@finalAmount</div>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 25).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ManfCost = 10 * x,
            LabCost = 3 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ManfCost { get; set; }
        public int? LabCost { get; set; }
        public double? FinalCost { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVoNfKNztPbnpjL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}