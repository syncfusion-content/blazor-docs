---
layout: post
title:  Blazor Grid Reactive Aggregates | Syncfusion
description: Learn how reactive aggregates in Blazor Data Grid automatically update footer, group footer, and caption summaries during batch editing.
platform: Blazor
control: DataGrid
documentation: ug
---

# Reactive Aggregates in Blazor Data Grid

Reactive aggregates in the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) update automatically after batch cell changes are saved. Summary values refresh in the footer, group footer, and group caption summary areas with each saved change.

## Auto-update aggregate values in batch editing

When DataGrid is in batch editing mode, aggregate values in the footer, group footer, and group caption refresh each time a cell edit is saved. Summary values always reflect the latest saved changes. Deleting a record in batch mode also triggers aggregate recalculation after saving changes.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowDeleting="true" AllowEditing="true" Mode="EditMode.Batch"></GridEditSettings>
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
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Sum" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>TotalSum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjrnDFCvXTPxYTlK?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> Aggregate values refresh after batch changes are saved (Update). Adding a new record does not update aggregates until the changes are saved.