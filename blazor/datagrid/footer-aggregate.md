---
layout: post
title:  Footer aggregates in Blazor DataGrid Component | Syncfusion
description: Learn how to configure and display footer aggregates in the Syncfusion Blazor DataGrid using FooterTemplate, AggregateTemplateContext, and formatting options.
platform: Blazor
control: DataGrid
documentation: ug
---

# Footer aggregates in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports calculating and displaying aggregate values in footer cells. Footer aggregates summarize column values across rows and render in the DataGrid footer. Use the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_FooterTemplate) property to render aggregate values in footer cells.

Access aggregate values inside `FooterTemplate` through the implicit template parameter **context**. Cast **context** to [AggregateTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.AggregateTemplateContext.html) to read properties such as **Sum, Average, Min, Max, Count, TrueCount,** and **FalseCount**.

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
        public OrderData(int? OrderID, string CustomerID,double Freight,string ShipName)
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
                int code = 10;
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
                    code += 5;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtByDEqjMQrYOURq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Data source behavior:
> - With local data, footer aggregates are calculated over the entire bound dataset.
> - With remote data and paging, footer aggregates typically reflect only the current page unless the adaptor or server provides total summaries.

## Format aggregate values

To format footer aggregate results in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, use the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Format) property of the aggregate column. The Format string determines how the aggregate value is displayed and supports culture-aware currency, numeric, and date formats.

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
        public OrderData(int? OrderID, string CustomerID,double Freight,string ShipName)
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
                int code = 10;
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
                    code += 5;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtVSZuqDsvUzzuGd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}