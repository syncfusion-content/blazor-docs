<!-- Cascading dropdownlist with grid editing

You can achieve the Cascading DropDownList with grid editing by using the [`EditTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) of the [`GridColumn`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) component.

This is demonstrated in the below sample code where cascading dropdownlist is rendered for the **ShipCountry** and **ShipState** column when editing is enabled in the grid,

{% tabs %}

{% highlight c# %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Newtonsoft.Json

<SfGrid DataSource="@GridData"  AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetail.OrderID) HeaderText="Order ID" TextAlign="@TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetail.OrderDate) HeaderText=" Order Date" Format="d" Type=ColumnType.Date TextAlign="@TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetail.Freight) HeaderText="Freight" Format="C2" AllowEditing="false" TextAlign="@TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetail.ShipCountry) HeaderText="Ship Country" TextAlign="@TextAlign.Right" Width="150">
            <EditTemplate>
                @{
                    var DropDownContext = (context as OrderDetail);
                    <SfDropDownList ID="ShipCountry" Value=@DropDownContext.ShipCountry DataSource="@DropData1">
                        <DropDownListEvents ValueChange="@Change" TValue="string"></DropDownListEvents>
                        <DropDownListFieldSettings Text="ShipCountry" Value="ShipCountry"></DropDownListFieldSettings>
                    </SfDropDownList>
                }
            </EditTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderDetail.ShipCity) HeaderText="Ship City" TextAlign="@TextAlign.Right" Width="150">
            <EditTemplate>
                @{
                    var DropDownContext = (context as OrderDetail);
                    <SfDropDownList ID="ShipCity" @ref="@DefaultDropDown" Value=@DropDownContext.ShipCity DataSource="@DropData2" Enabled="@Enabled" Query="@Query">
                        <DropDownListFieldSettings Text="ShipCity" Value="ShipCity"></DropDownListFieldSettings>
                    </SfDropDownList>
                }
            </EditTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfDropDownList<string> DefaultDropDown;

    public string Query { get; set; } = null;
    public bool Enabled { get; set; } = false;

    List<OrderDetail> GridData = new List<OrderDetail>
    {
        new OrderDetail { OrderID = 1001, Freight = 2.3, OrderDate = new DateTime(1991, 05, 15), ShipCity = "Seattle", ShipName = "White Clover Markets", ShipCountry = "United States" },
        new OrderDetail { OrderID = 1002, Freight = 3.3, OrderDate = new DateTime(1990, 04, 04), ShipCity = "Reims", ShipName = "Vins et alcools Chevalier", ShipCountry = "France" },
        new OrderDetail { OrderID = 1003, Freight = 5.3, OrderDate = new DateTime(1957, 11, 30), ShipCity = "Boise", ShipName = "Save-a-lot Markets", ShipCountry = "United States" },
        new OrderDetail { OrderID = 1004, Freight = 2.3, OrderDate = new DateTime(1992, 07, 14), ShipCity = "Reims", ShipName = "Vins et alcools Chevalier", ShipCountry = "France" },
        new OrderDetail { OrderID = 1005, Freight = 5.3, OrderDate = new DateTime(1927, 01, 20), ShipCity = "Boise", ShipName = "Save-a-lot Markets", ShipCountry = "United States" },
        new OrderDetail { OrderID = 1006, Freight = 9.3, OrderDate = new DateTime(1920, 02, 15), ShipCity = "Lyon", ShipName = "Victuailles en stock", ShipCountry = "France" },
        new OrderDetail { OrderID = 1007, Freight = 6.3, OrderDate = new DateTime(1951, 12, 08), ShipCity = "Albuquerque", ShipName = "Rattlesnake Canyon Grocery", ShipCountry = "United States" },
        new OrderDetail { OrderID = 1008, Freight = 4.3, OrderDate = new DateTime(1930, 10, 22), ShipCity = "Lyon", ShipName = "Victuailles en stock", ShipCountry = "France" },
        new OrderDetail { OrderID = 1009, Freight = 6.3, OrderDate = new DateTime(1953, 02, 18), ShipCity = "Albuquerque", ShipName = "Rattlesnake Canyon Grocery", ShipCountry = "United States" },
        new OrderDetail { OrderID = 1010, Freight = 4.3, OrderDate = new DateTime(1923, 01, 28), ShipCity = "Strasbourg", ShipName = "Blondel et fils", ShipCountry = "France" }
    };

    List<DropDownData1> DropData1 = new List<DropDownData1>
    {
        new DropDownData1() { OrderID = "1", ShipCountry = "United States" },
        new DropDownData1() { OrderID = "2", ShipCountry = "France" }
    };

    List<DropDownData2> DropData2 = new List<DropDownData2>
    {
        new DropDownData2() { OrderID = "1", ShipCity = "Seattle" },
        new DropDownData2() { OrderID = "1", ShipCity = "Albuquerque" },
        new DropDownData2() { OrderID = "1", ShipCity = "Boise" },
        new DropDownData2() { OrderID = "2", ShipCity = "Reims" },
        new DropDownData2() { OrderID = "2", ShipCity = "Lyon" },
        new DropDownData2() { OrderID = "2", ShipCity = "Strasbourg" }
    };

    public class OrderDetail
    {
        public int? OrderID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
    }

    public class DropDownData1
    {
        public string OrderID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }

    public class DropDownData2
    {
        public string OrderID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }

    public void Change(ChangeEventArgs<string> args)
    {
        var argsVal = JsonConvert.DeserializeObject<DropDownData1>(JsonConvert.SerializeObject(args.ItemData));
        this.Enabled = false;
        this.Query = "new ej.data.Query().where('OrderID', 'equal', " + argsVal.OrderID + ")";
        this.Enabled = true;
        this.DefaultDropDown.DataBind();
    }
}

{% endhighlight %}

{% endtabs %} -->
