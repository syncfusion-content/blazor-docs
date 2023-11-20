---
layout: post
title: Caption template in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Grouping in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Caption template in Blazor DataGrid component

The caption template feature in the Syncfusion Blazor DataGrid allows you to customize and enhance the appearance of group caption row. It provides a flexible way to display additional information about grouped data, such as counts or grouped value, and enables you to incorporate custom content like images, icons, or other HTML elements. This feature empowers you to create visually appealing and informative group captions in the DataGrid component.

To achieve this customization, you can utilize the  [CaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_CaptionTemplate) property. You can type cast the context as [CaptionTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.CaptionTemplateContext.html#properties) to get the data, which represents the currently displayed group, you can incorporate its properties such as `Field` (column's Field name), `HeaderText` (column's Header text), `Key`(grouped value) and `Count` (Count of the grouped records) into the Caption template.

The following example demonstrates how to customize the group header caption in the Grid by utilizing  the `CaptionTemplate` property. It displays the **HeaderText**, **Key** and **Count** of the grouped columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid  DataSource="@GridData" AllowGrouping="true" Height="315px">
    <GridGroupSettings ShowDropArea="false" Columns="@Initial">
        <CaptionTemplate>
            @{
                var data = (context as CaptionTemplateContext);
                <span>@data.HeaderText-@data.Key : @data.Count Items </span>
            }
        </CaptionTemplate>
    </GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>


@code {
    public List<OrderData> GridData { get; set; }
    public string[] Initial = (new string[] { "CustomerID", "ShipCity" });

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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;           
           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
 
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhUWCNmQMWuuKST?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Adding custom text in group caption

The Syncfusion Blazor DataGrid allows you to enhance the group captions by adding custom text, providing a more meaningful and informative representation of the grouped data. By utilizing the [CaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_CaptionTemplate) property, you can add specific text or information to the group caption, offering flexibility in customization.

The following example demonstrates how to add a custom text to the group caption using the `CaptionTemplate` property. You can type cast the context as [CaptionTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.CaptionTemplateContext.html#properties) to get the data used to display the key, count and headerText of the grouped columns along with the custom text.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid  DataSource="@GridData" AllowGrouping="true" Height="315px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="value" Width="120"></GridColumn>
    </GridColumns>
    <GridGroupSettings>
        <CaptionTemplate>
            @{
                var order = (context as CaptionTemplateContext);
                <span>@order.Key -@order.Count Records :@order.HeaderText</span>
            }
        </CaptionTemplate>
    </GridGroupSettings>
</SfGrid>


@code {
    public List<OrderData> GridData { get; set; }
   
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, double? Freight)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.Freight = Freight;           
           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", 3.25));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", 22.98));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", 140.51));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", 65.83));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", 58.17));
                    Orders.Add(new OrderData(10253, "HANAR", "Lyon", 81.91));
                    Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", 3.05));
                    Orders.Add(new OrderData(10255, "RICSU", "Münster", 55.09));
                    Orders.Add(new OrderData(10256, "WELLI", "Reims", 48.29));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public double? Freight { get; set; }

    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhAWsZONigdARCE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render custom component in group caption

The Syncfusion Blazor DataGrid offers the flexibility to render a custom component in the group caption, providing advanced or interactive functionality within the group caption row. This feature allows you to display custom UI elements, like buttons, icons, or dropdowns, and handle user interactions directly within the group caption.

To render custom component in the group caption, you can utilize the [CaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_CaptionTemplate) property. This feature enables you to replace plain text with a custom component in the group caption, enhancing customization and interactivity.

The following example demonstrates how to add a custom component to the group caption using the `CaptionTemplate` property. In the template, the [Chips](https://ej2.syncfusion.com/angular/documentation/chips/getting-started) component is utilized, with the text content set as the group key.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid  DataSource="@GridData" AllowGrouping="true" Height="315px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="value" Width="120"></GridColumn>
    </GridColumns>
   <GridGroupSettings>
        <CaptionTemplate>
            @{
                var data = (context as CaptionTemplateContext);
                var text = data.Key;
                <SfChip>
                    <ChipItems>
                        <ChipItem Text="@text"></ChipItem>
                    </ChipItems>
                </SfChip>
            }
        </CaptionTemplate>
    </GridGroupSettings>
</SfGrid>


@code {
    public List<OrderData> GridData { get; set; }
   
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, double? Freight)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.Freight = Freight;           
           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", 3.25));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", 22.98));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", 140.51));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", 65.83));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", 58.17));
                    Orders.Add(new OrderData(10253, "HANAR", "Lyon", 81.91));
                    Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", 3.05));
                    Orders.Add(new OrderData(10255, "RICSU", "Münster", 55.09));
                    Orders.Add(new OrderData(10256, "WELLI", "Reims", 48.29));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public double? Freight { get; set; }

    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVqCsjEtWGsGdKj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

