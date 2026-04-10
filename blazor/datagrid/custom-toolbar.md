---
layout: post
title: Custom Toolbar Items in Blazor DataGrid Component | Syncfusion
description: Learn how to create and use custom toolbar items in the Syncfusion Blazor DataGrid, including templates, icons with text, dropdowns, and export actions.
platform: Blazor
control: DataGrid
documentation: ug
---
# Custom toolbar in Blazor DataGrid

Custom toolbar in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables the creation of a customized toolbar layout and functionality to match specific application requirements. This is achieved by using the [ToolbarTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTemplates.html#Syncfusion_Blazor_Grids_GridTemplates_ToolbarTemplate) property, which provides comprehensive customization options for toolbar layout and styling. Define a custom template for the toolbar and handle toolbar item actions in the **OnClick** event.

The following example demonstrates rendering the custom toolbar `ToolbarTemplate` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" @ref="Grid" AllowGrouping="true">
    <GridTemplates>
        <ToolbarTemplate>
            <SfToolbar>
                <ToolbarEvents Clicked="ToolbarClickHandler"></ToolbarEvents>
                <ToolbarItems>
                    <ToolbarItem Type="@ItemType.Button" PrefixIcon="e-chevron-up icon" Id="collapseall" Text="Collapse All"></ToolbarItem>
                    <ToolbarItem Type="@ItemType.Button" PrefixIcon="e-chevron-down icon" Id="ExpandAll" Text="Expand All"></ToolbarItem>
                </ToolbarItems>
            </SfToolbar>
        </ToolbarTemplate>
    </GridTemplates>
    <GridGroupSettings Columns=@GroupOption></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    private string[] GroupOption = (new string[] { "OrderID" });

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Collapse All")
        {
            this.Grid.CollapseAllGroupAsync();
        }
        if (args.Item.Text == "Expand All")
        {
            this.Grid.ExpandAllGroupAsync();
        }
    }
}
<style>
    .e-collapse::before {
        content: '\e834';
    }
</style>
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerID, string ShipCity, string ShipName)
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
                for (int? i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(1, "Nancy", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(2, "Andrew", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(3, "Steven", "Rio de Janeiro","Hanari Carnes"));
                    Orders.Add(new OrderData(4, "Margaret", "Bern", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(5, "Janet", "Genève", "Richter Supermarkt"));
                    Orders.Add(new OrderData(6, "Andrew", "Genève", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(7, "Nancy", "Rio de Janeiro", "Suprêmes délices"));
                    Orders.Add(new OrderData(8, "Margaret", "Bern", "Victuailles en stock"));
                    Orders.Add(new OrderData(9, "Janet", "Lyon", "Hanari Carnes"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBUsZBuSRVoiYtS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render image with text in custom toolbar

Rendering an image with text in custom toolbar in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables easy display of an image along with text in the toolbar of the DataGrid. This feature enhances visual presentation, provides additional context, and improves the overall experience.

To render an image with text in the custom toolbar, use the `Template` in [SfToolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" @ref="Grid">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <div class="image">
                        <img class="image" src="@($"image/addimage.png")" />
                        <SfButton id="AddButton" OnClick="AddButton">Add</SfButton>
                        <img class="image" src="@($"image/deleteimage.png")" />
                        <SfButton id="DeleteButton" OnClick="DeleteButton">Delete</SfButton>
                    </div>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public async Task AddButton()
    {
        await this.Grid.AddRecordAsync();
    }
    public async Task DeleteButton()
    {
        await this.Grid.DeleteRecordAsync();
    }
}
<style>
    .image {
        height: 50px;
    }
</style>
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double Freight)
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
                for (int? i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(1, "Nancy", new DateTime(1993, 09, 15), 98));
                    Orders.Add(new OrderData(2, "Andrew", new DateTime(1997, 06, 01), 46));
                    Orders.Add(new OrderData(3, "Steven", new DateTime(2000, 04, 04), 56));
                    Orders.Add(new OrderData(4, "Margaret", new DateTime(1895, 11, 11), 74));
                    Orders.Add(new OrderData(5, "Janet", new DateTime(2001, 08, 04), 83));
                    Orders.Add(new OrderData(6, "Andrew", new DateTime(2022, 04, 09), 51));
                    Orders.Add(new OrderData(7, "Nancy", new DateTime(2023, 06, 06), 23));
                    Orders.Add(new OrderData(8, "Margaret", new DateTime(2011, 12, 30), 87));
                    Orders.Add(new OrderData(9, "Janet", new DateTime(2012, 07, 07), 34));
                    code += 5;
                }
            }
            return Orders;
        }
        
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

> The styles and layout of the image and text in the custom toolbar can be further customized to meet specific design requirements. For better accessibility, include alt text on images.

## Render DropDownList in custom toolbar

Rendering a DropDownList in custom toolbar in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid extends toolbar functionality by incorporating an [SfDropDownList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html) and allowing actions based on user selection.

This is achieved by using the `Template` property. The example below shows how to render the `SfDropDownList` in the custom toolbar, where the toolbar template binds the [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ValueChanged) event to the **OnChange** method.

In the **OnChange** method, the selected item text determines the action. For example, if **Update** is chosen, the [EndEditAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EndEditAsync) method exits edit mode. If **Edit** is selected, the selected record is passed to [StartEditAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_StartEditAsync) to start editing dynamically. Similarly, if **Delete** is chosen, the selected record is passed to [DeleteRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DeleteRecordAsync) to remove it from the DataGrid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" @ref="Grid">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>    
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <label>Change the value: </label>
                    <SfDropDownList @ref="Dropdown" TValue="string" TItem="Select" DataSource=@LocalData Width="200">
                        <DropDownListFieldSettings Text="text" Value="text"> </DropDownListFieldSettings>
                        <DropDownListEvents TValue="string" TItem="Select" ValueChange="OnChange"> </DropDownListEvents>
                    </SfDropDownList>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    SfDropDownList<string, Select> Dropdown;
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    public class Select
    {
        public string text { get; set; }
    }
    List<Select> LocalData = new List<Select>
    {
        new Select() { text = "Edit"},
        new Select() { text = "Delete"},
        new Select() { text = "Update"},
    };
    
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public async Task AddButton()
    {
        await this.Grid.AddRecordAsync();
    }
    public async Task DeleteButton()
    {
        await this.Grid.DeleteRecordAsync();
    }
    public async Task OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, Select> args)
    {
        var selectedRow = this.Grid.GetSelectedRecordsAsync();
        if (args.ItemData.text == "Edit")
        {
            await this.Grid.StartEditAsync();
        }
        if (args.ItemData.text == "Delete")
        {
            await this.Grid.DeleteRecordAsync();
        }
        if (args.Value == "Update")
        {
            await this.Grid.EndEditAsync();
        }
        this.Dropdown.Placeholder = args.ItemData.text;
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
        public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double Freight)
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
                for (int? i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(1, "Nancy", new DateTime(1993, 09, 15), 98));
                    Orders.Add(new OrderData(2, "Andrew", new DateTime(1997, 06, 01), 46));
                    Orders.Add(new OrderData(3, "Steven", new DateTime(2000, 04, 04), 56));
                    Orders.Add(new OrderData(4, "Margaret", new DateTime(1895, 11, 11), 74));
                    Orders.Add(new OrderData(5, "Janet", new DateTime(2001, 08, 04), 83));
                    Orders.Add(new OrderData(6, "Andrew", new DateTime(2022, 04, 09), 51));
                    Orders.Add(new OrderData(7, "Nancy", new DateTime(2023, 06, 06), 23));
                    Orders.Add(new OrderData(8, "Margaret", new DateTime(2011, 12, 30), 87));
                    Orders.Add(new OrderData(9, "Janet", new DateTime(2012, 07, 07), 34));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrSMjjihtPwLWfl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render SfAutoComplete in custom toolbar

Rendering the [SfAutoComplete](https://blazor.syncfusion.com/documentation/autocomplete/getting-started-with-web-app) in the custom toolbar of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enhances usability by enabling dynamic search based on user input.

This is implemented by using the `Template` property of the [Toolbar](https://blazor.syncfusion.com/documentation/toolbar/getting-started-webapp). The example below renders the `SfAutoComplete` within the custom toolbar. The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_ValueChange) event of `SfAutoComplete` is bound to the **OnSearch** method, which searches the DataGrid based on the selected input.

In the **OnSearch** method, the selected value from `SfAutoComplete` is used as the search keyword. The DataGrid’s [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchAsync_System_String_) method filters records that match the keyword across all searchable columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders" AllowPaging="true" @ref="Grid">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEvents TValue="Order"></GridEvents>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <SfAutoComplete Placeholder="Search Customer Name" TItem="CustomerDetails" TValue="string" DataSource="@Customers">
                        <AutoCompleteEvents ValueChange="OnSearch" TValue="string" TItem="CustomerDetails"></AutoCompleteEvents>
                        <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
                    </SfAutoComplete>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="ShipCountry" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class CustomerDetails
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    List<CustomerDetails> Customers = new List<CustomerDetails>
    {
        new CustomerDetails() { Name = "VINET", Id = 1 },
        new CustomerDetails() { Name = "TOMSP", Id = 2 },
        new CustomerDetails() { Name = "HANAR", Id = 3 },
        new CustomerDetails() { Name = "VICTE", Id = 4 },
        new CustomerDetails() { Name = "SUPRD", Id = 5 }
    };
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Order.GetAllRecords();
    }

    public async Task OnSearch(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string,CustomerDetails> args)
    {
        await this.Grid.SearchAsync(args.Value);
    }
}

{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

 public class Order
 {
     public static List<Order> Orders = new List<Order>();

     public Order(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
     {
         this.OrderID = orderID;
         this.CustomerID = customerID;
         this.Freight = freight;
         this.ShipCity = shipCity;
         this.ShipName = shipName;
         this.ShipCountry = shipCountry;
     }

     public static List<Order> GetAllRecords()
     {
         if (Orders.Count == 0)
         {
             Orders.Add(new Order(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
             Orders.Add(new Order(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
             Orders.Add(new Order(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
             Orders.Add(new Order(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
             Orders.Add(new Order(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
             Orders.Add(new Order(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
             Orders.Add(new Order(10254, "VICTE", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
             Orders.Add(new Order(10255, "TOMSP", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
             Orders.Add(new Order(10256, "HANAR", 13.97, "Resende", "Wellington Import Export", "Brazil"));
             Orders.Add(new Order(10257, "VINET", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            
         }

         return Orders;
     }

     public int OrderID { get; set; }
     public string CustomerID { get; set; }
     public double Freight { get; set; }
     public string ShipCity { get; set; }
     public string ShipName { get; set; }
     public string ShipCountry { get; set; }
 }

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BthoNTLFzGxGrdMg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render an element or control using the Toolbar Template

Rendering an element by using the toolbar template in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid extends the toolbar with custom UI like buttons, dropdowns, input fields, icons, or other controls. Event handlers can be bound within the template to enable actions for the added elements.

To render custom UI within the toolbar, use the `Template` directive. For example, include an [SfButton](https://help.syncfusion.com/cr/blazor/syncfusion.blazor.buttons.sfbutton.html) and perform specific DataGrid actions based on button clicks. When the **ExcelExport** button is clicked, [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) exports the DataGrid to Excel. When the **PdfExport** button is clicked, [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) exports the DataGrid to PDF. Likewise, when the **Print** button is clicked, [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PrintAsync) is triggered to print the DataGrid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfGrid DataSource="@Orders" AllowPaging="true" AllowExcelExport="true" AllowPdfExport="true" Height="200" @ref="Grid">
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <div>
                        <SfButton id="addButton" OnClick="ExcelExport">Excel Export</SfButton>
                        <SfButton id="addButton" OnClick="PdfExport">Pdf Export</SfButton>
                        <SfButton id="addButton" OnClick="Print">Print</SfButton>
                    </div>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
  
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public async Task ExcelExport()
    {
        await this.Grid.ExportToExcelAsync();
    }
    public async Task PdfExport()
    {
        await this.Grid.ExportToPdfAsync();
    }
    public async Task Print()
    {
        await this.Grid.PrintAsync();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity,string ShipName)
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
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Cheval"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
                    Orders.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Importado"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVysZtiBWCpVQjw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}