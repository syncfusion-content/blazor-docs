---
layout: post
title:  Group and caption aggregates in Blazor DataGrid Component | Syncfusion
description: Learn how to configure group footer aggregates and group caption aggregates in the Syncfusion Blazor DataGrid using GroupFooterTemplate and GroupCaptionTemplate with AggregateTemplateContext.
platform: Blazor
control: DataGrid
documentation: ug
---

# Group and caption aggregates in Blazor DataGrid

Group footer and group caption aggregates in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid calculate values based on items in each group and display results in group footer cells and group caption cells. Configure these using the [GroupFooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_GroupFooterTemplate) and [GroupCaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_GroupCaptionTemplate) properties of the [GridAggregateColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn__ctor) component. Aggregate values inside templates can be accessed through AggregateTemplateContext (for example, Sum, Min, Max).

> For group aggregates, ensure grouping is enabled at the grid level with AllowGrouping set to true, and maintain grouped columns by setting [ShowGroupedColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowGroupedColumn) to true.

## Group footer aggregates

Group footer aggregates appear in the footer cells of each group and provide per-group summary values. To display group footer aggregates, define a template with the [GroupFooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_GroupFooterTemplate) property. The template renders the aggregate value for each group’s footer row. Apply the Format property to present currency or date values using culture-aware formatting as needed.

The following example demonstrates group footer aggregates in the DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridGroupSettings Columns=@GroupOptions></GridGroupSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Sum">
                    <GroupFooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </GroupFooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Coutry" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
       
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
    private string[] GroupOptions = (new string[] { "ShipCountry" });

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
        public OrderData(int? OrderID, string CustomerID, string ShipCountry, DateTime OrderDate, double Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.ShipCountry = ShipCountry;
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
                    Orders.Add(new OrderData(10248, "ERNSH", "Austria", new DateTime(1996, 07, 17), 140.51));
                    Orders.Add(new OrderData(10249, "SUPRD", "Belgium", new DateTime(1996, 09, 07), 51.30));
                    Orders.Add(new OrderData(10250, "WELLI", "Brazil", new DateTime(1996, 07, 08), 65.83));
                    Orders.Add(new OrderData(10251, "HANAR", "France", new DateTime(1996, 07, 10), 58.17));
                    Orders.Add(new OrderData(10252, "WELLI", "Germany", new DateTime(1996, 10, 17), 13.97));
                    Orders.Add(new OrderData(10253, "HANAR", "Mexico", new DateTime(1996, 07, 19), 3.05));
                    Orders.Add(new OrderData(10254, "QUEDE", "Switzerland", new DateTime(1996, 07, 04), 32.38));
                    Orders.Add(new OrderData(10255, "RICSU", "Austria", new DateTime(1996, 07, 08), 41.34));
                    Orders.Add(new OrderData(10256, "WELLI", "Belgium", new DateTime(1996, 07, 05), 11.61));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
        public string ShipCountry { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDheZEVxysGhsjjP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Group caption aggregates

Group caption aggregates appear in the caption cells at the top of each group and provide a concise summary. To display group caption aggregates, define a template using the [GroupCaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_GroupCaptionTemplate) property. The template renders the aggregate value in the caption area of each group. Apply the Format property to aggregate values to present culture-aware currency or date results.

The following example demonstrates group caption aggregates in the DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridGroupSettings Columns=@GroupOptions></GridGroupSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Max">
                    <GroupCaptionTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Max: @aggregate.Max</p>
                            </div>
                        }
                    </GroupCaptionTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Coutry" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>


@code {
    public List<OrderData> Orders { get; set; }
    private string[] GroupOptions = (new string[] { "ShipCountry" });

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
        public OrderData(int? OrderID, string CustomerID, string ShipCountry, DateTime OrderDate, double Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
            this.ShipCountry = ShipCountry;
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
                    Orders.Add(new OrderData(10248, "ERNSH", "Austria", new DateTime(1996, 07, 17), 140.51));
                    Orders.Add(new OrderData(10249, "SUPRD", "Belgium", new DateTime(1996, 09, 07), 51.30));
                    Orders.Add(new OrderData(10250, "WELLI", "Brazil", new DateTime(1996, 07, 08), 65.83));
                    Orders.Add(new OrderData(10251, "HANAR", "France", new DateTime(1996, 07, 10), 58.17));
                    Orders.Add(new OrderData(10252, "WELLI", "Germany", new DateTime(1996, 10, 17), 13.97));
                    Orders.Add(new OrderData(10253, "HANAR", "Mexico", new DateTime(1996, 07, 19), 3.05));
                    Orders.Add(new OrderData(10254, "QUEDE", "Switzerland", new DateTime(1996, 07, 04), 32.38));
                    Orders.Add(new OrderData(10255, "RICSU", "Austria", new DateTime(1996, 07, 08), 41.34));
                    Orders.Add(new OrderData(10256, "WELLI", "Belgium", new DateTime(1996, 07, 05), 11.61));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
        public string ShipCountry { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZVyDaVxoilKLoVU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The group total summary in Grid is calculated based on the current page records for each group by default.