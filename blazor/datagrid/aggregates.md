---
layout: post
title: Aggregates in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Aggregates in the Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Aggregates in Blazor DataGrid

The Aggregates feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to display aggregate values in the footer, group footer, and group caption of the Grid. With this feature, you can easily perform calculations on specific columns and show summary information.This feature can be configured using the **GridAggregates** component.To represent an aggregate column, you need to specify the minimum required properties, such as [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Field) and [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type).

**Displaying aggregate values**

By default, the aggregate values are displayed in the footer, group, and caption cells of the Grid. However, you can choose to display the aggregate value in any of these cells by using the following properties:

* [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_FooterTemplate): Use this property to display the aggregate value in the footer cell. You can define a custom template to format the aggregate value as per your requirements. 

* [GroupFooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_GroupFooterTemplate): Use this property to display the aggregate value in the group footer cell. Similar to the footerTemplate, you can provide a custom template to format the aggregate value.

* [GroupCaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_GroupCaptionTemplate): Use this property to display the aggregate value in the group caption cell. You can define a custom template to format the aggregate value.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true">
    <GridGroupSettings Columns=@GroupOption></GridGroupSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Sum" Format="C2">
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
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Max" Format="C2">
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
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private string[] GroupOption = (new string[] { "ShipCountry" });
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
        public OrderData(int? OrderID, string CustomerID, string ShipCountry,DateTime OrderDate, double Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCountry= ShipCountry;
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
                    Orders.Add(new OrderData(10248, "ERNSH", "Austria",new DateTime(1996,07,17), 140.51));
                    Orders.Add(new OrderData(10249, "SUPRD", "Belgium",new DateTime(1996,09,07), 51.30));
                    Orders.Add(new OrderData(10250, "WELLI", "Brazil", new DateTime(1996,07,08), 65.83));
                    Orders.Add(new OrderData(10251, "HANAR", "France", new DateTime(1996,07,10), 58.17));
                    Orders.Add(new OrderData(10252, "WELLI", "Germany", new DateTime(1996,10,17), 13.97));
                    Orders.Add(new OrderData(10253, "HANAR", "Mexico", new DateTime(1996,07,19), 3.05));
                    Orders.Add(new OrderData(10254, "QUEDE", "Switzerland", new DateTime(1996,07,04), 32.38));
                    Orders.Add(new OrderData(10255, "RICSU", "Austria", new DateTime(1996,07,08), 41.34));
                    Orders.Add(new OrderData(10256, "WELLI", "Belgium", new DateTime(1996,07,05), 11.61));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }
        public double? Freight { get; set; }
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrACXUDUeyrfGOs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * When using local data, the total summary is calculated based on the entire dataset available in the Grid. The aggregate values will reflect calculations across all the rows in the Grid.
> * When working with remote data, the total summary is calculated based on the current page records. This means that if you have enabled pagination and are displaying data in pages, the aggregate values in the footer will represent calculations only for the visible page.

## Built-in aggregate types

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides several built-in aggregate types that can be specified in the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) property to configure an aggregate column.

The available built-in aggregate types are :

* **Sum:** Calculates the sum of the values in the column.

* **Average:** Calculates the average of the values in the column.
* **Min:** Finds the minimum value in the column.
* **Max:** Finds the maximum value in the column.
* **Count:** Counts the number of values in the column.
* **TrueCount:** Counts the number of true values in the column.
* **FalseCount:** Counts the number of false values in the column.

Here is an example that demonstrates how to use built-in aggregates types in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true">
    <GridGroupSettings Columns=@GroupOption></GridGroupSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.ShippedDate) Type="Syncfusion.Blazor.Grids.AggregateType.Max" Format="d">
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
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.OrderDate) Type="Syncfusion.Blazor.Grids.AggregateType.Min" Format="d">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Min: @aggregate.Min</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.IsVerified) Type="Syncfusion.Blazor.Grids.AggregateType.TrueCount">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>TrueCount: @aggregate.TrueCount</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="Syncfusion.Blazor.Grids.AggregateType.Max" Format="C2">
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
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.IsVerified) HeaderText="Verified" Width="150" Type="ColumnType.Boolean"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>


@code {
    private string[] GroupOption = (new string[] { "ShipCountry" });
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
        public OrderData(int? OrderID, string CustomerID, string ShipCountry,string ShipCity,DateTime OrderDate,DateTime ShippedDate,bool isVerified, double Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCountry= ShipCountry;
            this.ShipCity = ShipCity;
            this.OrderDate = OrderDate;
            this.ShippedDate= ShippedDate;
            this.IsVerified= isVerified;
            this.Freight = Freight;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "ERNSH", "Austria", "Graz", new DateTime(1996,07,17), new DateTime(1996, 08, 17),true, 140.51));
                    Orders.Add(new OrderData(10249, "SUPRD", "Belgium", "Charleroi", new DateTime(1996,09,07), new DateTime(1996, 07, 19) ,false,51.30));
                    Orders.Add(new OrderData(10250, "WELLI", "Brazil", "Rio de Janeiro", new DateTime(1996,07,08), new DateTime(1996, 06, 13), true, 65.83));
                    Orders.Add(new OrderData(10251, "HANAR", "France", "Resende", new DateTime(1996,07,10), new DateTime(1996, 08, 18),false,58.17));
                    Orders.Add(new OrderData(10252, "WELLI", "Germany", "Lyon", new DateTime(1996,10,17), new DateTime(1996, 09, 17), true, 13.97));
                    Orders.Add(new OrderData(10253, "HANAR", "Mexico", "Graz", new DateTime(1996,07,19), new DateTime(1996, 07, 15),false, 3.05));
                    Orders.Add(new OrderData(10254, "QUEDE", "Switzerland", "Resende", new DateTime(1996,07,04), new DateTime(1996, 09, 07), true, 32.38));
                    Orders.Add(new OrderData(10255, "RICSU", "Austria", "Rio de Janeiro", new DateTime(1996,07,08), new DateTime(1996, 10, 08), false, 41.34));
                    Orders.Add(new OrderData(10256, "WELLI", "Belgium", "Graz", new DateTime(1996,07,05), new DateTime(1996, 07, 06),true, 11.61));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public bool IsVerified { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrgCDAjUmunNwOO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Multiple types for a column are supported only when one of the aggregate templates is used.
>  * The aggregate values must be accessed inside the template using their corresponding [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) name.

## See also

* [Handling Aggregates in Custom Adaptor](https://blazor.syncfusion.com/documentation/datagrid/custom-binding#handling-aggregates-in-custom-adaptor)