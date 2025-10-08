---
layout: post
title:  Custom aggregate in Blazor DataGrid Component | Syncfusion
description: Learn how to create and display custom aggregates in Syncfusion Blazor DataGrid using CustomAggregate callback and template context.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom aggregate in Blazor DataGrid

The custom aggregate feature in the Syncfusion Blazor DataGrid enables calculating summary values with a user-defined function when built-in aggregate types do not meet specific requirements. Configure a custom aggregate by setting the aggregate type and providing a delegate that computes the value.

To use the custom aggregate option:
* Set the `AggregateType` as Custom in the `GridAggregateColumn` component.
* Provide a custom aggregate function using the `CustomAggregate` property on the GridAggregateColumn.

The custom aggregate function is invoked differently based on the context:
- **Total Aggregation:** The function receives the entire dataset and the current aggregate column object.
- **Group Aggregation:** The function receives the current group details and the aggregate column object.

Here’s an example that demonstrates how to use the custom aggregate feature in the DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true">
   <GridAggregates>
    <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.ShipCountry) Type="AggregateType.Custom" >
                    <FooterTemplate>
                        @{
                            <div>
                                <p>Brazil Count: @CustomAggregateFunction()</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>    
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
  
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    private int CustomAggregateFunction()
    {
        return Orders.Count(x => x.ShipCountry.Contains("Brazil"));
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
        public OrderData(int? OrderID, string CustomerID, string ShipCountry, double Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
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
                    Orders.Add(new OrderData(10248, "ERNSH", "Austria",140.51));
                    Orders.Add(new OrderData(10249, "SUPRD", "Belgium",51.30));
                    Orders.Add(new OrderData(10250, "WELLI", "Brazil",65.83));
                    Orders.Add(new OrderData(10251, "HANAR", "France",58.17));
                    Orders.Add(new OrderData(10252, "WELLI", "Germany",13.97));
                    Orders.Add(new OrderData(10253, "HANAR", "Mexico",3.05));
                    Orders.Add(new OrderData(10254, "QUEDE", "Switzerland",32.38));
                    Orders.Add(new OrderData(10255, "RICSU", "Austria",41.34));
                    Orders.Add(new OrderData(10256, "WELLI", "Belgium",11.61));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCountry { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVIXkVRertPQOeX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To access a custom aggregate value inside a template, use the `Custom` key (AggregateTemplateContext.Custom).

**Show the count of distinct values in aggregate row**

Custom aggregate functions can also compute distinct counts or other domain-specific summaries. Specify the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) as Custom and provide a function via the [CustomAggregate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_CustomAggregate) property. The result can be rendered in the footer, group footer, or group caption by using the corresponding template and accessing AggregateTemplateContext.Custom.

Here’s an example that shows the count of distinct values for the ShipCountry column using a custom aggregate:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true">
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.ShipCountry) Type="AggregateType.Custom">
                    <FooterTemplate>
                        @{

                            <div>
                                <p>Distinct Count: @CustomAggregateFunction()</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
  
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    private int CustomAggregateFunction()
    {
        int Count = Orders.Where(item => item.ShipCountry != null).Select(item => item.ShipCountry).Distinct().Count();
        return Count;
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
        public OrderData(int? OrderID, string CustomerID, string ShipCountry, double Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;   
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
                    Orders.Add(new OrderData(10248, "ERNSH", "Austria", 140.51));
                    Orders.Add(new OrderData(10249, "SUPRD", "Belgium", 51.30));
                    Orders.Add(new OrderData(10250, "WELLI", "Brazil", 65.83));
                    Orders.Add(new OrderData(10251, "HANAR", "France", 58.17));
                    Orders.Add(new OrderData(10252, "WELLI", "Germany", 13.97));
                    Orders.Add(new OrderData(10253, "HANAR", "Mexico", 3.05));
                    Orders.Add(new OrderData(10254, "QUEDE", "Switzerland", 32.38));
                    Orders.Add(new OrderData(10255, "RICSU", "Austria", 41.34));
                    Orders.Add(new OrderData(10256, "WELLI", "Belgium", 11.61));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCountry { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVUDvBkVInESEoB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To display the aggregate value of the current column in another column, use the [ColumnName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_ColumnName) property. If ColumnName is not defined, the value of Field is used.
>
> Refer to the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for feature overviews. Explore the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid examples](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to see data presentation and manipulation in action.