---
layout: post
title: Apply styles to the specific grid when the page has multiple DataGrid Component| Syncfusion
description: Checkout and learn here all about apply styles to the specific grid in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Apply styles to the specific grid when the page has multiple DataGrid Component

To apply specific styles to a particular DataGrid component when a page contains multiple grids, define the **ID** property of the Grid or specify a custom class name for the Grid component. Once the **ID** property or custom class name is assigned to Grid using CSS selectors, the DataGrid component can be identified and styles can be applied to it.

Following a code example to demonstrate how to apply a specific style to a header cell in a particular Grid component.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="grid" DataSource="@GridData" AllowPaging="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Visible="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="false" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
<SfGrid class="custom-grid" @ref="grid" DataSource="@GridData" AllowPaging="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Visible="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="false" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    /*add style to the header cell with grid id  */
    #Grid .e-headercelldiv {
        color: red;
    }

    /*add style to the header cell with a custom class name*/
    .e-grid.custom-grid .e-headercelldiv {
        color: blue;
    }
</style>
@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData> grid { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCountry,double Freight,DateTime OrderDate,DateTime ShippedDate,string ShipCity)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
           this.ShipCountry = ShipCountry;           
           this.Freight = Freight;
           this.OrderDate = OrderDate;     
           this.ShippedDate = ShippedDate;     
           this.ShipCity = ShipCity;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "ALFKI", "France", 33.33,new DateTime(1996,07,07), new DateTime(1996, 08, 07), "Reims"));
                    Orders.Add(new OrderData(10249, "ANANTR", "Germany", 89.76, new DateTime(1996, 07, 12), new DateTime(1996, 08, 08), "Münster"));
                    Orders.Add(new OrderData(10250, "ANTON", "Brazil", 78.67, new DateTime(1996, 07, 13), new DateTime(1996, 08, 09), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251, "BLONP", "Belgium", 55.65, new DateTime(1996, 07, 14), new DateTime(1996, 08, 10), "Lyon"));
                    Orders.Add(new OrderData(10252, "BOLID", "Venezuela",11.09, new DateTime(1996, 07, 15), new DateTime(1996, 08, 11), "Charleroi"));
                    Orders.Add(new OrderData(10253, "BLONP", "Venezuela",98.98, new DateTime(1996, 07, 16), new DateTime(1996, 08, 12), "Lyon"));
                    Orders.Add(new OrderData(10254, "ANTON", "Belgium", 78.75, new DateTime(1996, 07, 17), new DateTime(1996, 08, 13), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10255, "ANANTR", "Germany", 44.07, new DateTime(1996, 07, 18), new DateTime(1996, 08, 14), "Münster"));
                    Orders.Add(new OrderData(10256, "ALFKI", "France", 67.74, new DateTime(1996, 07, 19), new DateTime(1996, 08, 15), "Reims"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }      
        public string ShipCountry { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBqCWNBqXzfsRIR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}