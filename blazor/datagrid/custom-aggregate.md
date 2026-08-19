---
layout: post
title: Blazor Grid Custom Aggregate | Syncfusion
description: Learn how to create custom aggregates in Blazor Data Grid using CustomAggregate callbacks, template context, and custom summary calculations.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom Aggregate in Blazor Data Grid

The custom aggregate feature in the [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) helps calculate summary values with a custom method when built-in aggregate types do not match specific business logic. Set the aggregate type to Custom and define the calculation method in the component.

To use the custom aggregate option:
* Set the `Type` as `AggregateType.Custom` in the `GridAggregateColumn` component.
* Define a custom method in the code-behind that calculates the aggregate value.
* Call the custom method from the template to display the result.

The custom aggregate function is invoked differently based on the context:
- **Total Aggregation:** The function receives the entire dataset and the current aggregate column object.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBnZcNhVMZXlKHt?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

**Calculate the count of distinct values in the aggregate row**

Custom aggregate functions can also calculate distinct counts and other domain-specific summaries. Set the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) as Custom and define a calculation method in the code-behind. The result can be rendered in the footer, group footer, or group caption by calling the custom method from the corresponding template.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDrdZmjhLCNPqmbA?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> To display the aggregate value of the current column in another column, use the [ColumnName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_ColumnName) property. If ColumnName is not defined, the value of Field is used.
>
> Refer to the [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for feature overviews. Explore the [Blazor Data Grid examples](https://blazor.syncfusion.com/demos/datagrid/overview?theme=fluent2) to see data presentation and manipulation in action.