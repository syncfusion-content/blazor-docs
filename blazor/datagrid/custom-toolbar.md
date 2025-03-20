---
layout: post
title: Custom Toolbar Items in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Custom Toolbar Items in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---
# Custom toolbar in Blazor DataGrid component

Custom toolbar in Syncfusion Blazor Grid allows you to create a distinctive toolbar layout, style, and functionality that aligns with the specific needs of your application, providing a personalized experience within the Grid component.

This can be achieved by utilizing the `Template` property, which offers extensive customization options for the Toolbar. You can define a custom Template for the Toolbar and handle the actions of the ToolbarItems in the **OnClick** event.

The following example demonstrates, how to render the custom Toolbar using `Template`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using BlazorApp1.Data

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

## Render image with text in custom Toolbar

Render an image with text in custom Toolbar in Syncfusion Blazor Grid allows easily render an image along with text in the Toolbar of the DataGrid. This feature enhances the visual presentation of the Grid, providing additional context and improving the overall experience.

To render an image with text in Custom Toolbar, you can utilize the Template in [SfToolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html) in your code.

The following example demonstrates how to render an image in the Toolbar of the grid using `Template`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using BlazorApp1.Data

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
    public void AddButton()
    {
        this.Grid.AddRecordAsync();
    }
    public void DeleteButton()
    {
        this.Grid.DeleteRecordAsync();
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

> You can further customize the styles and layout of the image and text in the Custom Toolbar to suit your specific design requirements.

## Render SfDropDownList in Custom Toolbar

Render SfDropDownList in Custom Toolbar in Syncfusion Blazor Grid enables you to extend the functionality of the Custom Toolbar by incorporating a [DropDownList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html) component, allowing you to perform various actions within the DataGrid based on their selections.

This can be achieved by utilizing the `Template`. The example below demonstrates how to render the **SFDropDownList** component in the Custom Toolbar, where the Toolbar Template includes the its [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ValueChanged) event is bound to the **OnChange** method.

In the **OnChange** method, the text of the selected item is checked to determine the appropriate action. For example, if **Update** is chosen, the [EndEditAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EndEditAsync) method is called to exit the edit mode. If **Edit** is selected, the selected record is passed to the [StartEditAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_StartEditAsync) method to initiate the edit mode dynamically. Similarly, if **Delete** is picked, the selected record is passed to the [DeleteRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DeleteRecordAsync) method to remove it from the grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

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
    public void AddButton()
    {
        this.Grid.AddRecordAsync();
    }
    public void DeleteButton()
    {
        this.Grid.DeleteRecordAsync();
    }
    public void OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, Select> args)
    {
        var selectedRow = this.Grid.GetSelectedRecordsAsync();
        if (args.ItemData.text == "Edit")
        {
            this.Grid.StartEditAsync();
        }
        if (args.ItemData.text == "Delete")
        {
            this.Grid.DeleteRecordAsync();
        }
        if (args.Value == "Update")
        {
            this.Grid.EndEditAsync();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVgWDUiLWIJdsVg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render a component or element using the Toolbar Template

Rendering a component or element using the Toolbar Template in the Syncfusion Blazor Grid allows you to extend the capabilities of the grid Toolbar by incorporating custom components or elements. This provides flexibility to enhance the Toolbar with custom buttons, dropdowns, input fields, icons, or any other desired UI elements. You can bind event handlers or handle interactions within the Template to enable specific actions or behaviors associated with the added components or elements.

To render custom components or elements within the Toolbar, use the `Template` directive. This allows you to include other components, such as a [SfButton](https://help.syncfusion.com/cr/blazor/syncfusion.blazor.buttons.sfbutton.html), and perform specific grid actions based on the button click. For example, when the **ExcelExport** button is clicked, the [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method is called to export the grid to Excel. Similarly, when the **PdfExport** button is clicked, the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method is called to export the grid to PDF format.Likewise, when the Print button is clicked, the [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PrintAsync) method will triggered to print the grid.

The following example demonstrates how to render a **SfButton** component in the Toolbar using `Template` and perform grid action based on the respected button click.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using BlazorApp1.Data

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
    public void ExcelExport()
    {
        this.Grid.ExportToExcelAsync();
    }
    public void PdfExport()
    {
        this.Grid.ExportToPdfAsync();
    }
    public void Print()
    {
        this.Grid.PrintAsync();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLUCtDUyMhZgqEX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}