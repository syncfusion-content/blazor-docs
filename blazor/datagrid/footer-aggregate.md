---
layout: post
title: Blazor Grid Footer Aggregates | Syncfusion
description: Learn how to display footer aggregates in Blazor Data Grid using FooterTemplate, AggregateTemplateContext, summary calculations, and custom formatting options.
platform: Blazor
control: DataGrid
documentation: ug
---

# Footer Aggregates in Blazor Data Grid

The [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports calculating and displaying aggregate values in footer cells. Footer aggregates summarize column values across rows and are rendered in the Data Grid footer. Use the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_FooterTemplate) property to render aggregate values in footer cells.

Access aggregate values inside `FooterTemplate` through the implicit template parameter **context**. Cast **context** to [AggregateTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.AggregateTemplateContext.html) to read properties such as **Sum, Average, Min, Max, Count, TrueCount,** and **FalseCount**.

N> **TrueCount** and **FalseCount** properties apply only to boolean fields. These properties count the number of true and false values in the column respectively.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Sum" >
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Max">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Max: @aggregate.Max</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
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
        public OrderData(int? OrderID, string CustomerID, double? Freight, string ShipName)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;                   
            this.Freight = Freight;
            this.ShipName = ShipName;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38, "Vins et alcools Cheval"));
                    Orders.Add(new OrderData(10249, "TOMSP", 51.30, "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE",58.17, "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", 13.97, "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", 3.05, "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS",32.38, "Chop-suey Chinese"));
                    Orders.Add(new OrderData(10255, "RICSU",41.34, "Richter Supermarkt"));
                    Orders.Add(new OrderData(10256, "WELLI",11.61, "Ernst Handel"));
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipName { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBdtmjgrKMuuXxh?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> Data source behavior:
> - With local data, footer aggregates are calculated over the complete bound dataset.
> - With remote data and paging, footer aggregates usually reflect the current page unless the adaptor or server returns total summaries.

## Format aggregate values

To format footer aggregate results, use the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Format) property of the aggregate column. The Format value controls the display of the aggregate output and supports culture-aware numeric and currency formats.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Sum" Format="N0">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Max" Format="N0">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Max: @aggregate.Max</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
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
        public OrderData(int? OrderID, string CustomerID, double? Freight, string ShipName)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;                   
            this.Freight = Freight;
            this.ShipName = ShipName;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38, "Vins et alcools Cheval"));
                    Orders.Add(new OrderData(10249, "TOMSP", 51.30, "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE",58.17, "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", 13.97, "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", 3.05, "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS",32.38, "Chop-suey Chinese"));
                    Orders.Add(new OrderData(10255, "RICSU",41.34, "Richter Supermarkt"));
                    Orders.Add(new OrderData(10256, "WELLI",11.61, "Ernst Handel"));
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipName { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVHNmNgBgVnWONN?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

N> The [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Field) property determines which column is used for aggregate calculation, while the [ColumnName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_ColumnName) property determines which column displays the aggregate result. The aggregate value appears in the footer of the column specified by `ColumnName` rather than in the footer of the source field column.