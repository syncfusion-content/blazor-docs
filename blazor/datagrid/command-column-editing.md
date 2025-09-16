---
layout: post
title: Command Column Editing in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Command Column Editing in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Command column editing in Blazor DataGrid

The command column editing feature allows you to add CRUD (Create, Read, Update and Delete) action buttons in a column for performing operations on individual rows. This feature is commonly used when you want to enable inline editing, deletion, or saving of row changes directly within the Grid.

To enable command column editing, use the [GridColumn.Commands](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Commands) property. By defining this property, you can specify the command buttons to display in the command column, such as Edit, Delete, Save, and Cancel.

The available built-in command buttons are:

| Command Button | Action                      |
|---------------|-----------------------------|
| Edit          | Edit the current row.       |
| Delete        | Delete the current row.     |
| Save          | Update the edited row.      |
| Cancel        | Cancel the edit operation.  |

Here's an example that demonstrates how to add CRUD action buttons in a column using the `GridCommandColumns` property:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
        <GridColumn HeaderText="Manage Records" Width="150">
            <GridCommandColumns>
                <GridCommandColumn Type="CommandButtonType.Edit" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-edit", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Delete" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-delete", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Save" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-update", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Cancel" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-cancel-icon", CssClass = "e-flat" })"></GridCommandColumn>
            </GridCommandColumns>
         </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;    
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVyZWBVCmUhlVYq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom command column

The custom command column feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to add custom command buttons in a column to perform specific actions on individual rows. This feature is particularly useful when you need to provide customized functionality for editing, deleting, or performing any other operation on a row.

To add custom command buttons in a column, you can utilize the [GridColumn.Commands](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Commands) property. Furthermore, you can define the actions associated with these custom buttons using the [CommandClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CommandClicked) event.

Here's an example that demonstrates how to add custom command buttons using the `GridCommandColumns` property and customize the button click behavior to display Grid details in a dialog using the `CommandClicked` event:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Popups

<SfGrid DataSource="@OrderData">
    <GridEvents TValue="OrderDetails" CommandClicked="CommandClickedHandler"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
        <GridColumn HeaderText="Commands" Width="150">
            <GridCommandColumns>
                <GridCommandColumn ButtonOption="@(new CommandButtonOptions() { Content = "Details", CssClass = "e-flat" })"></GridCommandColumn>
            </GridCommandColumns>
        </GridColumn>
    </GridColumns>
</SfGrid>
<SfDialog @ref="Dialog" Visible="false" Width="50%" ShowCloseIcon="true" Header="@DialogHeader">
    <DialogTemplates>
        <Content>
            @if (selectedRecord != null)
            {
                <p><b>ShipName:</b> @selectedRecord.ShipName</p>
                <p><b>ShipPostalCode:</b> @selectedRecord.ShipPostalCode</p>
                <p><b>ShipAddress:</b> @selectedRecord.ShipAddress</p>
            }
        </Content>
    </DialogTemplates>
</SfDialog>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private SfDialog Dialog;
    private string DialogHeader;
    private OrderDetails selectedRecord;
    private void CommandClickedHandler(CommandClickEventArgs<OrderDetails> args)
    {
        selectedRecord = args.RowData; 
        DialogHeader="Row Information of " + selectedRecord.OrderID; 
        Dialog.ShowAsync();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry, string ShipName, string ShipPostalCode, string ShipAddress)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipName = ShipName;
        this.ShipPostalCode = ShipPostalCode;
        this.ShipAddress = ShipAddress;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", "Vins et alcools Chevalier", "51100", "59 rue de l Abbaye"));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", "Toms Spezialitäten", "44087", "Luisenstr. 48"));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", "Hanari Carnes", "05454-876", "Rua do Paço, 67"));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", "Victuailles en stock", "69004", "2, rue du Commerce"));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", "Suprêmes délices", "B-6000", "Boulevard Tirou, 255"));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", "Hanari Carnes", "05454-876", "Rua do Paço, 67"));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", "Chop-suey Chinese", "3012", "Hauptstr. 31"));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", "Richter Supermarkt", "1204", "Starenweg 5"));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", "Wellington Importadora", "08737-363", "Rua do Mercado, 12"));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", "HILARION-Abastos", "5022", "Carrera 22 con Ave. Carlos Soublette #8-35"));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", "Ernst Handel", "8010", "Kirchgasse 6"));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", "Centro comercial Moctezuma", "05022", "Sierras de Granada 9993"));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", "Ottilies Käseladen", "50739", "Mehrheimerstr. 369"));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", "Que Delícia", "02389-673", "Rua da Panificadora, 12"));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", "Rattlesnake Canyon Grocery", "87110", "2817 Milton Dr."));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipName { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipAddress { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htVoDiBhCEmvtthU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid does not support adding a new record using the command column. This is because the command column and its buttons are rendered only after a record is created. As a result, the Grid supports only edit, delete, cancel, and update options in the command column.

## Hide the command column button in a specific record

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, command columns are used to perform CRUD operations on records, such as editing or deleting. Sometimes, you may want to hide the command buttons for specific records based on certain conditions. This can be done by using the [`RowDataBound`](https://blazor.syncfusion.com/documentation/datagrid/events#rowdatabound) event, which is triggered every time a row is created or updated in the Grid.

This is demonstrated in the following steps where the `RowDataBound` event is triggered when a record is created. Based on the record details, you can add a specific class name to that row and hide the command buttons using CSS styles.

* Use the `RowDataBound` event of the Grid to access each row's data at the time of rendering.
* Inside the event, check the value of the **Verified** column for the current record.
* Based on the value of the **Verified** column, if Verified is **false**, only the **Edit** button will be shown; otherwise **Delete** button will be shown.
* In order to hide buttons (**display: none** style to the buttons), CSS class is applied to the row inside the `RowDataBound` event based on the record condition using `addClass` method, and corresponding CSS rules are defined to hide the respective command buttons.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Height="315">
    <GridEvents RowDataBound="RowBound" TValue="Order"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn HeaderText="Manage Records" Width="150">
            <GridCommandColumns>
                <GridCommandColumn Type="CommandButtonType.Edit" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-edit", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Delete" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-delete", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Save" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-update", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Cancel" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-cancel-icon", CssClass = "e-flat" })"></GridCommandColumn>
            </GridCommandColumns>
        </GridColumn>
    </GridColumns>
</SfGrid>
<style>
    /*to remove the edit button alone*/
    .e-removeEditcommand .e-unboundcell .e-unboundcelldiv button.e-Editbutton {
        display: none;
    }
    /*to remove the delete button alone*/
    .e-removeDeletecommand .e-unboundcell .e-unboundcelldiv button.e-Deletebutton {
        display: none;
    }
</style>
@code{
    public List<Order> Orders { get; set; }
    public void RowBound(RowDataBoundEventArgs<Order> Args)
    {
        if (Args.Data.Verified)
        {
            Args.Row.AddClass(new string[] { "e-removeEditcommand" });
        }
        else
        {
            Args.Row.AddClass(new string[] { "e-removeDeletecommand" });
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            Verified = (new bool[] { true, false })[new Random().Next(2)],
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[new Random().Next(5)]
        }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public bool Verified { get; set; }
        public string ShipCountry { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLetprbTsENCfsy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
