---
layout: post
title:  Custom aggregate in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Custom aggregate in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom aggregate in Blazor DataGrid

The custom aggregate feature in Syncfusion’s Blazor DataGrid allows you to calculate aggregate values using your own aggregate function. This feature can be useful in scenarios where the built-in aggregate functions do not meet your specific requirements. To use the custom aggregate option, follow the steps below:

* Set the **AggregateType** as Custom in **GridAggregateColumn** component.

* Provide your custom aggregate function in the **customAggregate** property.

The custom aggregate function will be invoked differently for total and group aggregations:

**Total Aggregation:** The custom aggregate function will be called with the whole dataset and the current aggregate column object as arguments.

**Group Aggregation:** The custom aggregate function will be called with the current group details and the aggregate column object as arguments.

Here’s an example that demonstrates how to use the custom aggregate feature in the Grid:

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
        int Count = Queryable.Count(Orders.Where(x => x.ShipCountry.Contains("Brazil")).AsQueryable());
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBAsZUjTrNSVYmc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To access the custom aggregate value inside template, use the key as **Custom**

**Show the count of distinct values in aggregate row**

You can calculate the count of distinct values in an aggregate row by using custom aggregate functions. By specifying the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) as **Custom** and providing a custom aggregate function in the `CustomAggregate` property, you can achieve this behavior.

Here’s an example that demonstrates how to show the count of distinct values for the **ShipCountry** column using a custom aggregate:

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

> To display the aggregate value of the current column in another column, you can use the [ColumnName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_ColumnName) property. If the `ColumnName` property is not defined, the field name value will be assigned to the `ColumnName` property.

> You can refer to the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.