---
layout: post
title:  Reactive aggregates in Blazor DataGrid Component | Syncfusion
description: Learn how reactive aggregates in the Syncfusion Blazor DataGrid auto-update summary values in the footer, group footer, and group caption during batch editing.
platform: Blazor
control: DataGrid
documentation: ug
---

# Reactive aggregates in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports reactive aggregates that update dynamically as data changes. Aggregate values are recalculated when underlying data is edited, providing real-time updates to footer, group footer, and group caption summaries.

## Auto-update aggregate values in batch editing

When the DataGrid is in batch editing mode, aggregate values in the footer, group footer, and group caption are refreshed each time a cell edit is saved. This ensures that summaries reflect the most recent edits.

The following example demonstrates automatic aggregate value updates in batch editing:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridGroupSettings Columns=@GroupOption></GridGroupSettings>
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
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Coutry" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    private List<string> ToolbarItems = new List<string>() { "Update", "Cancel", "Delete" };
    private string[] GroupOption = (new string[] { "ShipCountry" });
  
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLSNYqjWbvJQVPF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Aggregate values refresh after batch changes are saved (Update). Adding a new record does not update aggregates until the changes are saved.