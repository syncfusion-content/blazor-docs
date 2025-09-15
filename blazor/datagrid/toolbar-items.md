---
layout: post
title: Toolbar Items in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Toolbar Items in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Toolbar items in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers a flexible toolbar that enables the addition of custom Toolbar Items or modification of existing ones. This customizable toolbar is positioned above the Grid, providing a convenient way to access various actions and functionalities.

## Built-in Toolbar item

Built-in toolbar items in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid involves utilizing pre-defined actions to perform standard operations within the Grid.

These items can be added by defining the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property as a collection of built-in items. Each item is rendered as a button with an icon and text. The following table lists the built-in Toolbar Items and their respective actions:

| Built-in Toolbar Items | Actions |
|------------------------|---------|
| Add | Adds a new row to the Grid.|
| Edit | Enables editing mode for the selected row in the Grid.|
| Update | Saves the changes made during the editing mode.|
| Delete | Deletes the selected record from the Grid.|
| Cancel | Discards the changes made during the editing mode.|
| Search | Displays a search box to filter the Grid records.|
| Print | Print the Grid content.|
| ColumnChooser | Choose the column’s visibility. |
| PdfExport | Exports the Grid data to a PDF file.|
| ExcelExport | Exports the Grid data to an Excel file.|
| CsvExport | Exports the Grid data to a CSV file.|

The following example demonstrates how to enable built-in Toolbar items such as **Print** and **Search** in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" @ref="Grid"  Toolbar=@ToolbarItems>
   <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public string[] ToolbarItems = new string[] { "Search", "Print" };
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrAMXrYLyKJdugz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Show only icons in built-in Toolbar Items

Showing only icons in the built-in Toolbar Items of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid involves customizing the appearance of the toolbar to display icons without text.

To display only icons in the built-in Toolbar Items of the Grid, you can use CSS to hide the text portion of the buttons using the following CSS style.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="200" Toolbar=@ToolbarItems>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
   <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public string[] ToolbarItems = new string[] { "Add", "Edit","Delete","Update","Cancel" };
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}
<style>
    .e-grid .e-toolbar .e-tbar-btn-text,
    .e-grid .e-toolbar .e-toolbar-items .e-toolbar-item .e-tbar-btn-text {
        display: none;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjLAsNrYBydmAXyF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Customize the built-in toolbar items

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to customize the built-in toolbar items to meet your specific requirements. This can include adding, removing, or modifying toolbar items, as well as handling custom actions when toolbar buttons are clicked.

To customize the built-in toolbar items, you can use the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event of the Grid.

The following example demonstrate how to customize the toolbar by disabling and canceling the **Add** button functionlity and showing a custom message when the **Add** button of toolbar is clicked:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<p style="color:red;" id="message">@message</p>

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit","Delete", "Cancel", "Update" })" Height="348">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    private string message;

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_add") 
        {
            args.Cancel = true;
            var newRecord = new OrderData(10247, "TOMSP", "Hanari Carnes", "Lyon");
            await Grid.AddRecordAsync(newRecord);
            message = "The default adding action is canceled, and a new record is added using the addRecord method.";
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public string ShipCity { get; set; }

    public OrderData(int orderID, string customerID, string shipName, string shipCity)
    {
        OrderID = orderID;
        CustomerID = customerID;
        ShipName = shipName;
        ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        return new List<OrderData>
        {
            new OrderData(10248, "ALFKI", "Maria Anders", "Berlin"),
            new OrderData(10249, "ANATR", "Ana Trujillo", "Mexico City"),
            new OrderData(10250, "ANTON", "Antonio Moreno", "Madrid"),
            new OrderData(10251, "BERGS", "Christina Berglund", "Luleå"),
            new OrderData(10252, "BLAUS", "Hanna Moos", "Mannheim"),
            new OrderData(10253, "BLONP", "Frédérique Citeaux", "Strasbourg"),
            new OrderData(10254, "BOLID", "Martín Sommer", "Madrid"),
            new OrderData(10255, "BONAP", "Laurence Lebihan", "Marseille"),
            new OrderData(10256, "BOTTM", "Elizabeth Lincoln", "London"),
            new OrderData(10257, "BSBEV", "Victoria Ashworth", "London"),
            new OrderData(10258, "CACTU", "Patricio Simpson", "Buenos Aires"),
            new OrderData(10259, "CENTC", "Francisco Chang", "Mexico D.F.")
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVINzCcAGRIvWxA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 

## Custom Toolbar Items

Adding custom Toolbar Items to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid involves incorporating personalized functionality into the Toolbar.

Custom Toolbar Items can be added to the Grid by defining the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property as a collection of [ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel__ctor) objects. These objects define the custom items and their corresponding actions. The actions for the customized toolbar items are defined in the [OnToolbarClick](https://blazor.syncfusion.com/documentation/datagrid/events#ontoolbarclick) event.

By default, custom Toolbar Items are positioned on the **left** side of the Toolbar. However, you can change the position by using the [Align](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel_Align) property of the `ItemModel`. The following example demonstrates how to apply the `Align` property with the value **Right** for the **Collapse All** Toolbar Item:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid DataSource="@Orders" @ref="Grid" AllowGrouping="true" Height="200" Toolbar=@Toolbaritems>
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridGroupSettings Columns=@GroupColumn></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    private List<ItemModel> Toolbaritems = new List<ItemModel>();
    public List<OrderData> Orders { get; set; }
    private string[] GroupColumn = (new string[] { "CustomerID" });

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
        Toolbaritems.Add(new ItemModel() { Text = "Expand all", TooltipText = "Expand all", PrefixIcon = "e-expand" });
        Toolbaritems.Add(new ItemModel() { Text = "Collapse all", TooltipText = "Collapse all", PrefixIcon = "e-collapse-2", Align = (Syncfusion.Blazor.Navigations.ItemAlign.Right) });
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Expand all")
        {
            await this.Grid.GroupExpandAll();
        }
        if (args.Item.Text == "Collapse all")
        {
            await this.Grid.GroupCollapseAll();
        }
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


{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVqiNBEKnOsnFxm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Both built-in and custom items in Toolbar

Built-in and custom items in a Toolbar within the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the flexibility to create a customized toolbar with a combination of standard actions and custom actions.

To use both types of toolbar items, you can define the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property of the Grid as an array that includes both built-in and custom items. The built-in items are specified as strings, while the custom items are defined as objects with properties such as [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Text), [PrefixIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_PrefixIcon), and [Id](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Id) within the toolbar.

The following example demonstrates, how to use both built-in and custom toolbar items in the Grid. The built-in toolbar items includes **Add**, **Edit**, **Delete**, **Update**, and **Cancel**, while the custom toolbar item is **Click**:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<div style="margin-left:280px"><p style="color:red;" id="message">@message</p></div>

<SfGrid DataSource="@Orders" @ref="Grid" Height="200" Toolbar=@Toolbaritems>
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public string message;
    private List<Object> Toolbaritems = new List<Object>() { "Add", "Delete", "Edit", "Update", "Cancel", new ItemModel() { Text = "Click", TooltipText = "Click", PrefixIcon = "e-click", Id = "Click" } };
    public List<OrderData> Orders { get; set; }
   

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Click")
        {
            message = "Custom Toolbar Clicked";
            //You can customize your code here.
        }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBKCXBEUwAbaVmT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom Toolbar Items in a specific position

Customizing the position of a custom toolbar within the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid involves modifying the default placement of the custom Toolbar Items. This enables you to precisely control the positioning of each custom Toolbar item according to your specific requirements and desired layout within the Grid.

By default, custom Toolbar Items in Grid are aligned on the left side of the toolbar. However, you have the ability to modify the position of the custom toolbar items by utilizing the [Align](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel_Align) property of the  [ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel__ctor).

In the following sample, the **Collapse All** Toolbar item is positioned on the **Right**, the **Expand All** Toolbar item is positioned on the **Left**, and the **Search** Toolbar item is positioned at the **Center**:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid @ref="Grid" DataSource="@Orders" AllowGrouping="true" Toolbar="@Toolbaritems" Height="315">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridGroupSettings Columns=@GroupOption></GridGroupSettings>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.EmployeeID) HeaderText="Employee ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules { Required = true })" Type="ColumnType.Number" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.FirstName) HeaderText="First Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Country) HeaderText="Country" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderData.PostalCode) HeaderText="PostalCode" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    private List<Object> Toolbaritems = new List<Object>() { "Search", new ItemModel() { Text = "Expand all", TooltipText = "Expand all", PrefixIcon = "e-expand", Align = (Syncfusion.Blazor.Navigations.ItemAlign.Left) }, new ItemModel() { Text = "Collapse all", TooltipText = "Collapse all", PrefixIcon = "e-collapse", Align = (Syncfusion.Blazor.Navigations.ItemAlign.Right) } };
    private string[] GroupOption = (new string[] { "FirstName" });

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Expand all")
        {
            await this.Grid.GroupExpandAll();
        }
        if (args.Item.Text == "Collapse all")
        {
            await this.Grid.GroupCollapseAll();
        }
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
        public OrderData(int? EmployeeId,string FirstName,string Country,string PostalCode)
        {
           this.EmployeeID = EmployeeId;
           this.FirstName = FirstName;
           this.Country = Country;
           this.PostalCode = PostalCode;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int? i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(1, "Nancy", "USA", "98122"));
                    Orders.Add(new OrderData(2, "Andrew", "UK", "98401"));
                    Orders.Add(new OrderData(3, "Steven", "USA", "98033"));
                    Orders.Add(new OrderData(4, "Margaret", "UK", "SW1 8JR"));
                    Orders.Add(new OrderData(5, "Janet", "USA", "EC2 7JR"));
                    Orders.Add(new OrderData(6, "Andrew", "UK", "98122"));
                    Orders.Add(new OrderData(7, "Nancy", "USA", "98401"));
                    Orders.Add(new OrderData(8, "Margaret", "UK", "98033"));
                    Orders.Add(new OrderData(9, "Janet", "USA", "98033"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhKMNXKhRPOCyLS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize the text name of custom Toolbar Items with same as default Toolbar Items

When creating custom toolbar items in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using the same text as default toolbar items (such as "Add", "Edit", or "Delete"), the Grid treats them as default items. This may result in unexpected behavior—such as the toolbar buttons becoming disabled during certain Grid states.

To avoid this behavior and ensure proper functionality:

* Assign a unique **Id** to each custom toolbar item to distinguish them from default toolbar items.
* Use the `Text`, `PrefixIcon`, and `TooltipText` properties of the [ItemModel]([ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel__ctor)) to define the button appearance.
* Handle actions using the `OnToolbarClick` event based on the Id or Text.

This is demonstrated in the following sample code where there are custom toolbar items with text same as Add and Delete buttons. These toolbar buttons will be enabled only when `GridEditSettings` is defined in Grid. So custom toolbar will be disabled state considering it as default toolbar item.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Toolbar="@ToolbarItems" Height="250">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) IsPrimaryKey="true" HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    private List<ItemModel> ToolbarItems = new List<ItemModel>() {
        new ItemModel() { Text = "Add", PrefixIcon = "e-add", Id = "Grid_add" },
        new ItemModel() { Text = "Edit", PrefixIcon = "e-edit", Id = "Grid_edit" },
        new ItemModel() { Text = "Delete", PrefixIcon = "e-delete", Id = "Grid_delete" },
        new ItemModel() { Text = "Update", PrefixIcon = "e-update", Id = "Grid_update" },
        new ItemModel() { Text = "Cancel", PrefixIcon = "e-cancel", Id = "Grid_cancel" }
    };

    protected override void OnInitialized()
    {
        var random = new Random();
        var customerIds = new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" };
        Orders = Enumerable.Range(1, 25).Select(x => new OrderData
        {
            OrderID = 1000 + x,
            CustomerID = customerIds[random.Next(customerIds.Length)],
            OrderDate = DateTime.Now.AddDays(-x),
            Freight = Math.Round(random.NextDouble() * 100, 2),
        }).ToList();
    }

    public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Add")
        {
            Grid.AddRecord();
        }
        if (args.Item.Text == "Edit")
        {
            Grid.StartEdit();
        }
        if (args.Item.Text == "Delete")
        {
            Grid.DeleteRecord();
        }
        if (args.Item.Text == "Update")
        {
            Grid.EndEdit();
        }
        if (args.Item.Text == "Cancel")
        {
            Grid.CloseEdit();
        }
    }

    public class OrderData
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDheXeVNVHTgrfqL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing the toolbar items tooltip text

You can customize the toolbar items tooltip text by adding toolbar items externally by setting [ItemModel.TooltipText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel__ctor) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" Toolbar=@ToolbarItems>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) IsPrimaryKey="true" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;

    public List<OrderData> Orders { get; set; }
    private List<object> ToolbarItems = new List<object>() {
        new ItemModel() { Text = "Excel",TooltipText="Export to Excel", PrefixIcon = "e-excelexport", Id = "Grid_excelexport"}, //Here Grid is SfGrid ID.
        new ItemModel(){ Text = "Pdf",TooltipText="Export to PDF", PrefixIcon= "e-pdfexport", Id="Grid_pdfexport"},
        new ItemModel(){ Text = "CSV",TooltipText="Export to CSV", PrefixIcon= "e-csvexport", Id="Grid_csvexport"},
    };

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
                    Orders.Add(new OrderData(1, "Nancy",new DateTime(1993,09,15) ,98));
                    Orders.Add(new OrderData(2, "Andrew",new DateTime(1997,06,01) , 46));
                    Orders.Add(new OrderData(3, "Steven", new DateTime(2000,04,04),56));
                    Orders.Add(new OrderData(4, "Margaret", new DateTime(1895,11,11),74));
                    Orders.Add(new OrderData(5, "Janet",new DateTime(2001,08,04),83));
                    Orders.Add(new OrderData(6, "Andrew", new DateTime(2022,04,09),51));
                    Orders.Add(new OrderData(7, "Nancy", new DateTime(2023,06,06),23));
                    Orders.Add(new OrderData(8, "Margaret", new DateTime(2011,12,30),87));
                    Orders.Add(new OrderData(9, "Janet", new DateTime(2012,07,07),34));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVACXLuoSzCcoOM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}