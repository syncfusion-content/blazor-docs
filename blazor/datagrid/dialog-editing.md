---
layout: post
title: Dialog Editing in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Dialog Editing in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Dialog editing in Blazor DataGrid component

Dialog editing is a feature in the Grid component that allows you to edit the data of the currently selected row using a dialog window. With dialog editing, you can easily modify cell values and save the changes back to the data source.This feature is particularly beneficial in scenarios where you need to quickly modify data without navigating to a separate page or view, and it streamlines the process of editing multiple cells.

To enable dialog editing in grid component, you need to set the [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property to **Dialog**. This property determines the editing mode for the grid, and when set to **Dialog**, it enables the dialog editing feature.

Here's an example how to enable dialog editing in the angular grid component:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog" ></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true })" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5 })" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000 })" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBTihBtqxaHFdKg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize the edit dialog

The edit dialog in the Grid component allows you to customize its appearance and behavior based on the type of action being performed, such as editing or adding a record. You can modify properties like header text, showCloseIcon, and height to tailor the edit dialog to your specific requirements.

To customize the edit dialog, you can use [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_HeaderTemplate) and [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_FooterTemplate) of the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) property to customize the appearance of edit dialog.

The following example that demonstrates how to customize the edit dialog.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Dialog="DialogParams" Mode="EditMode.Dialog">
        <HeaderTemplate>
            @{
                var DialogHeader = GetHeader((context as OrderDetails));
                <span>@DialogHeader</span>
            }
        </HeaderTemplate>
        <FooterTemplate>
            <SfButton OnClick="@Save" IsPrimary="true">Submit</SfButton>
            <SfButton OnClick="@Cancel">Discard</SfButton>
        </FooterTemplate>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true })" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5 })" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000 })" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public DialogSettings DialogParams { get; set; } = new DialogSettings { Height= "300px", Width="300px" }; 
    public string GetHeader(OrderDetails value)
    {
        return value.OrderID == 0 
            ? "New Customer" 
            : "Edit Record of " + value.CustomerID;
    }
    public async Task Cancel()
    {
        await Grid.CloseEditAsync();     //Cancel editing action
    }
    public async Task Save()
    {
        await Grid.EndEditAsync();       //Save the edited/added data to Grid
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVIZWXgfDGOMyvy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The Grid add or edit dialog element has the max-height property, which is calculated based on the available window height. So, in the normal window (1920 x 1080), it is possible to set the dialog's height up to 658px.
> * You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.

## Show or hide columns in dialog editing

The show or hide columns in dialog editing feature in the grid allows you to dynamically control the visibility of columns while editing in the dialog edit mode. This feature is useful when you want to display specific columns based on the type of action being performed, such as editing an existing record or adding a new record. To achieve this, you can utilize the following events of the Grid. 

1. [RowCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowCreating): Triggered before an add action is executed in the grid.

2. [RowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowEditing): Triggered before an edit action is executed in the grid.

3. [RowUpdating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDeleting): Triggered before a update action is executed in the grid.

4. [EditCanceling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_EditCanceling): Triggered before a cancel action is executed in the grid.

The `RowCreating` and `RowEditing` events are triggered whenever an action such as adding or editing a record is initiated in the grid. Within the events handler, you can modify the visibility of columns using the [Column.Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Visible) property. This property determines whether a column should be displayed or hidden. 

Additionally, you can reset the column visibility to its initial state using the `Column.Visible` property using `RowUpdating` and `EditCanceling` events of grid.

In the following example, the **CustomerID** column is rendered as a hidden column, and the **ShipCountry** column is rendered as a visible column. In the edit mode, the **CustomerID** column will be changed to a visible state and the **ShipCountry** column will be changed to a hidden state.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog"></GridEditSettings>
    <GridEvents TValue="OrderDetails" EditCanceling="RowCancelingHandler" RowEditing="RowEditingHandler" RowCreating="RowAddingHandler" RowUpdating="RowUpdatingHandler"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Visible="false" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public void RowAddingHandler(RowCreatingEventArgs<OrderDetails> args)
    {
        var columns = Grid.Columns;
        foreach (var column in columns)
        {
            if (column.Field == "CustomerID")
            {
                column.Visible = true; 
            }
        }
    }
    public void RowEditingHandler(RowEditingEventArgs<OrderDetails> args)
    {
        var columns = Grid.Columns;
        foreach (var column in columns)
        {
            if (column.Field == "CustomerID")
            {
                column.Visible = true; 
            }
            else if (column.Field == "ShipCountry")
            {
                column.Visible = false; 
            }
        }
    }
    public void RowUpdatingHandler(RowUpdatingEventArgs<OrderDetails> args)
    {
        var columns = Grid.Columns;
        foreach (var column in columns)
        {
            if (column.Field == "CustomerID")
            {
                column.Visible = false; 
            }
            else if (column.Field == "ShipCountry")
            {
                column.Visible = true; 
            }            
        }
    }
    public void RowCancelingHandler(EditCancelingEventArgs<OrderDetails> args)
    {
        var columns = Grid.Columns;
        foreach (var column in columns)
        {
            if (column.Field == "CustomerID")
            {
                column.Visible = false; 
        }
            else if (column.Field == "ShipCountry")
            {
                column.Visible = true; 
            }
        }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrzWVLAqtMKVgod?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Implement calculated column inside grid dialog editing

You can perform calculations based on the field values available in the grid's dialog edit form and display the results in another field.

In the following sample, the `SfNumericTextBox` component is rendered inside the dialog edit form. We have updated the **Total** column value based on the **Price** and **Quantity** columns using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.NumericTextBoxEvents-1.html#Syncfusion_Blazor_Inputs_NumericTextBoxEvents_1_ValueChange) event of the `SfNumericTextBox` and the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionBegin) event of the Grid.

```cshtml
@using Syncfusion.Blazor.Grids
@using Action = Syncfusion.Blazor.Grids.Action
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="315" Width="900">
    <GridEvents OnActionComplete="OnActionComplete" OnActionBegin="OnActionBegin" TValue="Order"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <Template>
            @{
                var Order = (context as Order);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Price" @ref="PriceRef" @bind-Value="@(Order.Price)" TValue="double" Placeholder="Price" FloatLabelType="FloatLabelType.Always">
                                <NumericTextBoxEvents ValueChange="ValueChange" TValue="double"></NumericTextBoxEvents>
                            </SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Quantity" @ref="QuantityRef" @bind-Value="@(Order.Quantity)" TValue="int?" Placeholder="Quantity" FloatLabelType="FloatLabelType.Always">
                                <NumericTextBoxEvents ValueChange="ValueChange" TValue="int?"></NumericTextBoxEvents>
                            </SfNumericTextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Total" Value="@TotalValue" Enabled="false" TValue="double" Placeholder="Total" FloatLabelType="FloatLabelType.Always"></SfNumericTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Product Name" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.Price) HeaderText="Price" Format="C2" ValidationRules="@(new ValidationRules{ Required=true})" Width="90" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(Order.Quantity) HeaderText="Quantity" ValidationRules="@(new ValidationRules{ Required=true})" Width="90" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(Order.Total) HeaderText="Total" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="90"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    SfNumericTextBox<double> PriceRef;
    SfNumericTextBox<int?> QuantityRef;
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 8).Select(x => new Order()
        {
            CustomerID = (new string[] { "Chai", "Chang", "Aniseed Syrup", "Chef Anton's Cajun Seasoning", "Chef Anton's Gumbo Mix", "Coca-Cola", "Pepsi", "Nescafe" })[new Random().Next(8)],
            Price = 2.1 * x,
            Quantity = x,
            Total = (2.1 * x) * x
        }).ToList();
    }
    public double TotalValue { get; set; }
    public void OnActionComplete(ActionEventArgs<Order> args)
    {
        if (args.RequestType.Equals(Action.Add) || args.RequestType.Equals(Action.BeginEdit))
        {
            // Based on Add or Edit action disable the PreventRender.
            args.PreventRender = false;
        }
    }
    public void OnActionBegin(ActionEventArgs<Order> args)
    {
        if (args.RequestType.Equals(Action.Add) || args.RequestType.Equals(Action.BeginEdit))
        {
            TotalValue = args.Data.Total;
        }
        if (args.RequestType.Equals(Action.Save))
        {
            args.Data.Total = TotalValue;
        }
    }
    public void ValueChange()
    {
        TotalValue = Convert.ToDouble(PriceRef.Value * QuantityRef.Value);
    }

    public class Order
    {
        public string? CustomerID { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }
        public double Total { get; set; }
    }
}

```

N> You can find the fully working sample [here](https://github.com/SyncfusionExamples/blazor-datagrid-calculated-columns-inside-dialog-editing).