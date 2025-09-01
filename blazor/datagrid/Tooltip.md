---
layout: post
title: Tooltip in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Tooltip in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Tooltip in Blazor DataGrid

The Tooltip feature in the Syncfusion Blazor DataGrid allows you to display contextual information when hovering over grid content and header cells. For header cells, the tooltip presents the column header text; for content cells, it shows the corresponding data value. This feature enables quick access to relevant information without interaction.

The Blazor DataGrid supports tooltip for both header and content cells through the `ShowTooltip` property. When enabled, tooltip appear on hover, providing additional context and enhancing the overall user experience.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" ShowTooltip="true" Width="700">
     <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="70"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="90"></GridColumn>
   </GridColumns>
</SfGrid>

@code {
   private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }       
}

{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;
            this.CustomerID = CustomerID;
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
                    Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                    Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                    Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                    Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                    Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                                    
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htrSjFVnKuSghwyK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Display custom tooltip for headers and content

The Syncfusion Blazor DataGrid provides a feature to display custom tooltip for its columns using the `TooltipTemplate` inside the `GridTemplates` component, allowing for flexible and visually enhanced designs.Tooltip customization is supported through the `TooltipTemplateContext` which provides access to the following built-in properties:

  <ul>
      <li><strong>Value</strong> - Shows the content of the hovered cell—either the column name <b>(for headers)</b> or the cell value <b>(for content)</b>.</li>
      <li><strong>RowIndex</strong> - Gives the row number of the hovered cell. Returns <code>-1</code> for header cells.</li>
      <li><strong>ColumnIndex</strong> - Gives the column number of the hovered cell.</li>
      <li><strong>Data</strong> - Provides the full data of the row being hovered. Not available for header cells.</li>
      <li><strong>Column</strong> - Contains details about the column, like field name and formatting.</li>
  </ul>

In this sample, the tooltip template presents a rich and customized tooltip that includes an employee mailID in hyperlink, icons, and additional contextual information, demonstrating tooltip customization within the DataGrid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" Height="330" ShowTooltip="true" Width="700">
    <GridTemplates>
        <TooltipTemplate>
            @{
                var tooltip = context as TooltipTemplateContext;
                var order = tooltip?.RowData as OrdersDetails;
                if (tooltip?.RowIndex == -1)
                {
                    if (tooltip.Value == "Order ID")
                    {
                        <span><strong>@tooltip.Value: </strong>Unique number used to identify each customer order.</span>
                    }

                    else if (tooltip.Value == "Customer ID")
                    {
                        <div>
                            <span><strong>@tooltip.Value: </strong>Displays the name of the customer who placed the order.</span>
                        </div>
                    }
                    else if (tooltip.Value == "Freight")
                    {
                        <span><strong>@tooltip.Value: </strong>Shipping cost for the order. </span>
                    }
                    else
                    {
                        <span><strong>@tooltip.Value: </strong>Name of the city where the order is delivered.</span>
                    }
                }

                else
                {
                    var fieldName = tooltip?.Column?.Field;
                    <div style="font-family: Arial; line-height: 1.6;">
                        @switch (fieldName)
                        {
                            case nameof(order.OrderID):
                                <p style="margin: 2px 0;">@((MarkupString)GetStatusMessage(order.Status, order.OrderDate))</p>
                                break;

                            case nameof(OrdersDetails.CustomerID):
                                <div>
                                    <p style="margin: 2px 0;">
                                        <strong>EmailID: </strong><a href="mailto:@order.Email">@order.Email</a>
                                    </p>
                                </div>
                                break;

                            case nameof(OrdersDetails.Freight):
                                <p style="margin: 4px 0;">
                                    <strong>Expected Delivery: </strong>@order.DeliveryDays
                                </p>
                                break;

                            case nameof(OrdersDetails.ShipCity):
                            <span class="e-icons e-location"></span>
                                <strong>Country: </strong> @order.ShipCountry
                                break;

                            default:
                                <strong>@tooltip?.Column?.Field: </strong> @tooltip.Value
                                break;
                        }
                    </div>
                }
            }
        </TooltipTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer ID" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Freight) Format="C2" Width="80" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-icons.e-location:before {
        position: relative;
        top: 2px; 
    }

</style>

@code {
    public List<OrdersDetails> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = new List<OrdersDetails>
        {
            new OrdersDetails { OrderID = 1001, CustomerID = "Nancy", Freight = 80, ProductName = "Laptop", OrderDate = DateTime.Now.AddDays(-1), ShipCity = "Reims", ShipCountry = "France", Status = "Delivered", Location = "France", Email = "nancy@example.com", DeliveryDays = "5-7 days" },
            new OrdersDetails { OrderID = 1002, CustomerID = "Andrew", Freight = 120, ProductName = "Smartphone", OrderDate = DateTime.Now.AddDays(3), ShipCity = "Munster", ShipCountry = "Germany", Status = "Pending", Location = "Germany", Email = "andrew@example.com" , DeliveryDays = "3-4 days"},
            new OrdersDetails { OrderID = 1003, CustomerID = "Janet", Freight = 180, ProductName = "Tablet", OrderDate = DateTime.Now.AddDays(-3), ShipCity = "Charleroi", ShipCountry = "Belgium", Status = "Cancelled", Location = "Belgium", Email = "janet@example.com" , DeliveryDays = "1-2 days"},
            new OrdersDetails { OrderID = 1004, CustomerID = "Margaret", Freight = 60, ProductName = "Monitor", OrderDate = DateTime.Now.AddDays(-4), ShipCity = "Lyon", ShipCountry = "France", Status = "Delivered", Location = "France", Email = "margaret@example.com" , DeliveryDays = "5-7 days"},
            new OrdersDetails { OrderID = 1005, CustomerID = "Steven", Freight = 130, ProductName = "Keyboard", OrderDate = DateTime.Now.AddDays(4), ShipCity = "Delhi", ShipCountry = "India", Status = "Pending", Location = "India", Email = "steven@example.com" , DeliveryDays = "3-4 days"},
            new OrdersDetails { OrderID = 1006, CustomerID = "Michael", Freight = 220, ProductName = "Mouse", OrderDate = DateTime.Now.AddDays(-6), ShipCity = "Tokyo", ShipCountry = "Japan", Status = "Delivered", Location = "Japan", Email = "michael@example.com" , DeliveryDays = "1-2 days" },
            new OrdersDetails { OrderID = 1007, CustomerID = "Robert", Freight = 90, ProductName = "Printer", OrderDate = DateTime.Now.AddDays(-7), ShipCity = "Toronto", ShipCountry = "Canada", Status = "Cancelled", Location = "Canada", Email = "robert@example.com" , DeliveryDays = "5-7 days"},
            new OrdersDetails { OrderID = 1008, CustomerID = "Laura", Freight = 160, ProductName = "Camera", OrderDate = DateTime.Now.AddDays(1), ShipCity = "Sydney", ShipCountry = "Australia", Status = "Pending", Location = "Australia", Email = "laura@example.com", DeliveryDays = "1-2 days" },
            new OrdersDetails { OrderID = 1009, CustomerID = "Anne", Freight = 90, ProductName = "Laptop", OrderDate = DateTime.Now.AddDays(-9), ShipCity = "Reims", ShipCountry = "France", Status = "Delivered", Location = "France", Email = "anne@example.com" ,DeliveryDays = "5-7 days" },
            };
    }
    private string GetStatusMessage(string status, DateTime? orderDate)
    {
        return status switch
        {
            "Cancelled" => "This item has been cancelled and will not be delivered.",
            "Pending" => $"<strong>Expected Delivery Date: </strong> {orderDate?.ToShortDateString()}",
            "Delivered" => $"<strong>Delivered Date: </strong> {orderDate?.ToShortDateString()}",
            _ => "<strong>Status Unknown</strong>"
        };
    }
    public class OrdersDetails
    {
        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double Freight { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipCountry { get; set; }
        public string? Status { get; set; }
        public string? Location { get; set; }
        public string? ProductName { get; set; }
        public string? Email { get; set; }
        public string? DeliveryDays { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDryjujMCPDfWrVi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}