---
layout: post
title: Batch Editing in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Batch Editing in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Batch editing in Blazor DataGrid

Batch editing is a powerful feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid that allows you to edit multiple cells simultaneously. It provides a convenient way to make changes to several cells and save them in a single request to the data source. This feature is particularly useful when working with large datasets or when you need to update multiple cells at once.

In batch edit mode, when you double-click a Grid cell, the target cell becomes editable. You can perform bulk updates of added, changed, and deleted data by either clicking the toolbar's **Update** button or by externally invoking the [ApplyBatchChangesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ApplyBatchChangesAsync_Syncfusion_Blazor_Grids_BatchChanges__0__) method.

To enable batch editing mode, set the [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property to **Batch**. This property determines the editing mode of the Grid and allows you to activate the batch editing feature.

Here's an example of how to enable batch editing in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVINMWGKEkClhfx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Automatically update the column based on another column edited value

You can automatically update the value of a column based on the edited value of another column in batch mode. This feature is useful when you want to dynamically calculate and update a column's value in real time based on changes made in another related column.

To implement this feature, define a calculated column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. By leveraging events and methods such as [CellSaved](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellSaved) and [UpdateCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UpdateCellAsync_System_Int32_System_String_System_Object_), you can efficiently update the column value whenever another column's value is edited.

Additionally, for batch editing, you can manage the add operation using a boolean variable along with the [OnBatchAdd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnBatchAdd) and [OnBatchSave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnBatchSave) events. These events ensure that calculations and updates are applied even when new rows are added during batch editing.

In the following example, the **TotalCost** column value is updated based on changes to the **UnitPrice** and **UnitsInStock** columns during batch editing.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@ProductData" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEvents CellSaved="CellSavedHandler" OnBatchAdd="BatchAddHandler" OnBatchSave="BatchSaveHandler" TValue="ProductDetails"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(ProductDetails.ProductID)" HeaderText="Product ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" ValidationRules="@(new ValidationRules { Required = true })" Width="100"></GridColumn>
        <GridColumn Field="@nameof(ProductDetails.ProductName)" HeaderText="Product Name" ValidationRules="@(new ValidationRules { Required = true })" Width="120">
        </GridColumn>
        <GridColumn Field="@nameof(ProductDetails.UnitPrice)" HeaderText="Unit Price" Width="150" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules { Required = true, Min = 1 })" Format="C2"></GridColumn>
        <GridColumn Field="@nameof(ProductDetails.UnitsInStock)" HeaderText="Units In Stock" Width="150" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules { Required = true, Min = 1 })"></GridColumn>
        <GridColumn Field="@nameof(ProductDetails.TotalCost)" HeaderText="Total Cost" Width="150" AllowEditing="false" AllowAdding="false" Format="C2" TextAlign="TextAlign.Right">
            <Template>
                @{
                    var Order = (context as ProductDetails);
                    Order.TotalCost = Order.UnitPrice * Order.UnitsInStock;
                    <span>@Order.TotalCost</span>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<ProductDetails> Grid;
    bool IsAdd { get; set; }
    public List<ProductDetails> ProductData { get; set; }
    protected override void OnInitialized()
    {
        ProductData = ProductDetails.GetAllRecords();
    }
    public async Task CellSavedHandler(CellSavedArgs<ProductDetails> args)
    {
        var index = await Grid.GetRowIndexByPrimaryKeyAsync(args.RowData.ProductID);
        if (args.ColumnName == "UnitPrice")
        {
            if (IsAdd)
            {
                args.RowData.UnitPrice = (double)args.Value;
                await Grid.UpdateCellAsync(index, "TotalCost", Convert.ToInt32(args.Value) * 1);
            }
            await Grid.UpdateCellAsync(index, "TotalCost", Convert.ToInt32(args.Value) * args.RowData.UnitPrice);
        }
        else if (args.ColumnName == "UnitsInStock")
        {
            if (IsAdd)
            {
                args.RowData.UnitsInStock = (double)args.Value;
                await Grid.UpdateCellAsync(index, "TotalCost", Convert.ToDouble(args.Value) * 1);
            }
            await Grid.UpdateCellAsync(index, "TotalCost", Convert.ToDouble(args.Value) * args.RowData.UnitsInStock);
        }
    }
    public void BatchAddHandler(BeforeBatchAddArgs<ProductDetails> args)
    {
        IsAdd = true;
    }
    public void BatchSaveHandler(BeforeBatchSaveArgs<ProductDetails> args)
    {
        IsAdd = false;
    }
}
{% endhighlight %}
{% highlight c# tabtitle="ProductDetails.cs" %}
public class ProductDetails
{
    public static List<ProductDetails> Products = new List<ProductDetails>();
    public ProductDetails(int productID, string productName, double unitPrice, double unitsInStock, double totalCost)
    {
        this.ProductID = productID;
        this.ProductName = productName;
        this.UnitPrice = unitPrice;
        this.UnitsInStock = unitsInStock;
        this.TotalCost = totalCost;
    }
    public static List<ProductDetails> GetAllRecords()
    {
        if (Products.Count == 0)
        {
            Products.Add(new ProductDetails(1, "Chai", 18.0, 39, 702));
            Products.Add(new ProductDetails(2, "Chang", 19.0, 17, 323));
            Products.Add(new ProductDetails(3, "Aniseed Syrup", 10.0, 13, 130));
            Products.Add(new ProductDetails(4, "Chef Anton's Cajun Seasoning", 22.0, 53, 1166));
            Products.Add(new ProductDetails(5, "Chef Anton's Gumbo Mix", 21.35, 0, 0));
            Products.Add(new ProductDetails(6, "Chef Anton's Gumbo", 23.35, 0, 0));
            Products.Add(new ProductDetails(7, "Chef Anton's Mix", 25.35, 0, 0));
            Products.Add(new ProductDetails(8, "Chef Gumbo Mix", 27.39, 0, 0));
        }
        return Products;
    }
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public double UnitPrice { get; set; }
    public double UnitsInStock { get; set; }
    public double TotalCost { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjrejMhCfPQMlvUW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Cancel edit based on condition

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to cancel CRUD operations (Edit, Add, and Delete) for specific rows or cells in batch edit mode based on custom conditions. This feature gives you control over whether editing should be permitted or prevented for certain rows or cells in the Grid.

To cancel the edit action, handle the [OnCellEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnCellEdit) event. This event is triggered when a cell enters edit mode. In the event handler, add a condition to determine if the edit operation should be allowed. If the condition is met, set the `args.Cancel` property to **true** to cancel the edit operation.

To cancel the add action, handle the [OnBatchAdd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnBatchAdd) event. This event is triggered before a new record is added to the batch changes. In the event handler, add a condition to determine if the add operation should proceed. If the condition is met, set the `args.Cancel` property to **true** to cancel the add operation.

To cancel the delete action, handle the [OnBatchDelete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnBatchDelete) event. This event is triggered before a record is deleted from the batch changes. In the event handler, add a condition to control whether the delete operation should take place. If the condition is met, set the `args.Cancel` property to **true** to cancel the delete operation.

In the example below, CRUD operations are prevented based on the **Role** column value. If the Role column is **Admin**, edit and delete actions are prevented for that row.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-outline" Content="@Content" OnClick="ToggleGridAddability" style="margin-bottom:5px"></SfButton>
<SfGrid DataSource="@EmployeeData" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="315">
    <GridEvents TValue="EmployeeDetails" OnCellEdit="CellEditHandler" OnBatchAdd="BatchAddHandler" OnBatchDelete="BatchDeleteHandler"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeName) HeaderText="Employee Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Role) HeaderText="Role" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeCountry) HeaderText="Employee Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private string Content => IsAddable ? "Grid is Addable" : "Grid is Not Addable";
    private bool IsAddable = true;
    public List<EmployeeDetails> EmployeeData { get; set; }    
    protected override void OnInitialized()
    {
        EmployeeData = EmployeeDetails.GetAllRecords();
    }
    public void BatchAddHandler(BeforeBatchAddArgs<EmployeeDetails> args)
    {
        if (!IsAddable)
        {
            args.Cancel = true; 
        }
    }
    public void CellEditHandler(CellEditArgs<EmployeeDetails> args)
    {
        if (args.Data.Role == "Admin") 
        {
            args.Cancel = true;
        }
    }
    public void BatchDeleteHandler(BeforeBatchDeleteArgs<EmployeeDetails> args)
    {
        if (args.RowData.Role == "Admin")
        {
            args.Cancel = true;
        }
    }
    public void ToggleGridAddability()
    {
        IsAddable = !IsAddable;
    }
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}
public class EmployeeDetails
{
    public static List<EmployeeDetails> Employees = new List<EmployeeDetails>();
    public EmployeeDetails(int employeeID, string employeeName, string role, string employeeCountry)
    {
        this.EmployeeID = employeeID;
        this.EmployeeName = employeeName;
        this.Role = role;
        this.EmployeeCountry = employeeCountry;
    }
    public static List<EmployeeDetails> GetAllRecords()
    {
        if (Employees.Count == 0)
        {
            Employees.Add(new EmployeeDetails(1, "Davolio", "Admin", "France"));
            Employees.Add(new EmployeeDetails(2, "Buchanan", "Employee", "Germany"));
            Employees.Add(new EmployeeDetails(3, "Fuller", "Admin", "Brazil"));
            Employees.Add(new EmployeeDetails(4, "Leverling", "Manager", "France"));
            Employees.Add(new EmployeeDetails(5, "Peacock", "Manager", "Belgium"));
            Employees.Add(new EmployeeDetails(6, "Janet", "Admin", "Brazil"));
            Employees.Add(new EmployeeDetails(7, "Suyama", "Employee", "Switzerland"));
            Employees.Add(new EmployeeDetails(8, "Robert", "Admin", "Switzerland"));
            Employees.Add(new EmployeeDetails(9, "Andrew", "Employee", "Brazil"));
            Employees.Add(new EmployeeDetails(14, "Michael", "Admin", "Venezuela"));
            Employees.Add(new EmployeeDetails(11, "Ana Trujillo", "Manager", "Austria"));
            Employees.Add(new EmployeeDetails(10, "Antonio Moreno", "Manager", "Mexico"));
            Employees.Add(new EmployeeDetails(12, "VICTE", "Admin", "Germany"));
            Employees.Add(new EmployeeDetails(13, "Christina Berglund", "Manager", "Brazil"));
            Employees.Add(new EmployeeDetails(15, "Hanna Moos", "Employee", "USA"));
        }
        return Employees;
    }
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public string Role { get; set; }
    public string EmployeeCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBytMVNBCJUWjzh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Adding a new row at the bottom of the Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to add a new row at the bottom of the Grid, enabling you to insert a new record at the end of the existing data set. This feature is particularly useful when you want to conveniently add new records without scrolling up or manually repositioning the newly added row. To achieve this, use the [NewRowPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_NewRowPosition) property in the `GridEditSettings` configuration and set it to **Bottom**.

>* If you set `NewRowPosition` to **Bottom**, you can use the **TAB** key to easily move between cells or rows in edit mode. As you enter data in each cell and press **TAB**, the Grid will automatically create new rows below the current row, allowing you to conveniently add data for multiple rows without leaving edit mode.
>* If you set `NewRowPosition` to **Top**, the Grid will display a blank row form at the top by default, allowing you to enter data for the new record. However, when the data is saved or updated, it will be inserted at the bottom of the Grid, ensuring the new record appears at the end of the existing data set.
>* If the paging feature is enabled, updating the row will automatically move it to the last page based on the page size. This behavior applies to both local and remote data binding.
>* If scrolling is enabled, you can use the **TAB** key to add a new row, even if the new row is added beyond the currently visible area of the Grid.
>* The `NewRowPosition` property is supported for both **Normal** and **Batch** editing modes.

Here's an example that demonstrates how to enable adding new rows at the bottom of the Grid using the `NewRowPosition` property:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="margin-bottom:5px">
    <label> Select new row position: </label>
    <SfDropDownList TValue="NewRowPosition" TItem="DropDownOrder" DataSource="@DropDownValue" Width="100px">
        <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
        <DropDownListEvents ValueChange="OnChange" TValue="NewRowPosition" TItem="DropDownOrder"></DropDownListEvents>
    </SfDropDownList>
</div>
<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch" NewRowPosition="@RowPosition"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public NewRowPosition RowPosition { get; set; } = NewRowPosition.Top;  
    public class DropDownOrder
    {
        public string Text { get; set; }
        public NewRowPosition Value { get; set; }
    }    
    public void OnChange(ChangeEventArgs<NewRowPosition, DropDownOrder> Args)
    {
        RowPosition = Args.Value;
    }
    List<DropDownOrder> DropDownValue = new List<DropDownOrder>
    {
        new DropDownOrder() { Text = "Top", Value = NewRowPosition.Top },
        new DropDownOrder() { Text = "Bottom", Value = NewRowPosition.Bottom},
    };
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, double Freight, string ShipCountry, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public DateTime OrderDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhetirZBAiQraCy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Confirmation dialog

Displaying a confirmation dialog provides an extra layer of safety when performing actions such as saving a record or canceling changes in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. This dialog prompts users for confirmation before proceeding, helping to prevent accidental or undesired changes. The Grid includes a built-in confirmation dialog that can be used to confirm save, cancel, and other actions.

To enable the confirmation dialog, set the [ShowConfirmDialog](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_ShowConfirmDialog) property of the `GridEditSettings` configuration to **true**. The default value is **true**.

> * `GridEditSettings.ShowConfirmDialog` requires the [`GridEditSettings.Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) to be **Batch**.
> * If `GridEditSettings.ShowConfirmDialog` is set to **false**, the confirmation dialog will not appear in batch editing.
> * When performing update or delete operations, a separate delete confirmation dialog is shown when clicking the delete button or pressing the delete key.

The following example demonstrates how to enable or disable the confirmation dialog using the `ShowConfirmDialog` property:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom:5px">
    <label> Enable or Disable show confirmation dialog:</label>
    <SfSwitch ValueChange="toggleShowConfirmDialog" TChecked="bool" Checked="@CheckedValue" style="margin-top:5px"></SfSwitch>
</div>
<div style="margin-bottom:5px">
    <label> Enable or Disable show delete confirmation dialog:</label>
    <SfSwitch ValueChange="toggleShowDeleteConfirmDialog" TChecked="bool" style="margin-top:5px"></SfSwitch>
</div>
<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch" ShowDeleteConfirmDialog="@DeleteConfirmDialog" ShowConfirmDialog="@ConfirmDialog"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public bool CheckedValue { get; set; } = true;
    public bool ConfirmDialog { get; set; } = true;
    public bool DeleteConfirmDialog { get; set; } = false;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private void toggleShowConfirmDialog(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        CheckedValue = args.Checked;
        ConfirmDialog = CheckedValue;
    }
    private void toggleShowDeleteConfirmDialog(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        DeleteConfirmDialog = args.Checked;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtretsBNBSFKelXV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to make editing in single click and arrow keys

You can enable editing with a single click and navigate between cells or rows using arrow keys, without needing to double-click or use the mouse for navigation. By default, in batch mode, the **TAB** key allows you to move to the next cell or row, and the **Enter** key moves to the next cell in the row. However, you can customize this behavior to start editing with a single click or by using arrow keys.

To enable editing with a single click, handle the [CellSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellSelected) event of the Grid. In the event handler, call the [EditCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EditCellAsync_System_Int32_System_String_) method to make the selected cell editable.

> Ensure that the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property of [GridSelectionSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html) is set to **Both**.

The following example demonstrates how to enable single-click editing and arrow key navigation using the `CellSelected` event together with the `EditCellAsync` method:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" AllowSelection="true">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch" ></GridEditSettings>
    <GridSelectionSettings Mode="SelectionMode.Both"></GridSelectionSettings>
    <GridEvents CellSelected="CellSelectHandler" TValue="OrderDetails"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
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
    public async Task CellSelectHandler(CellSelectEventArgs<OrderDetails> args)
    {
        //get selected cell index
        var CellIndexes = await Grid.GetSelectedRowCellIndexesAsync();
        //get the row and cell index
        var CurrentEditRowIndex = CellIndexes[0].Item1;
        var CurrentEditCellIndex = (int)CellIndexes[0].Item2;
        //get the available fields
        var Fields = await Grid.GetColumnFieldNamesAsync();
        // edit the selected cell using the cell index and column name
        await Grid.EditCellAsync(CurrentEditRowIndex, Fields[CurrentEditCellIndex]);
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, double Freight, string ShipCountry, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public DateTime OrderDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVoXsBNzpRlVgXw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable editing for a particular cell

You can prevent editing of specific cells based on certain conditions in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. This feature is useful when you want to restrict editing for certain cells, such as read-only data, calculated values, or protected information. It helps maintain data integrity and ensures that only authorized changes can be made in the Grid.

To disable editing for a particular cell in batch mode, use the [OnCellEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnCellEdit) event of the Grid. In the event handler, set the **args.Cancel** property to **true** to prevent editing for that cell.

Here's an example demonstrating how you can disable editing for cells containing the value **France** using the `OnCellEdit` event:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" >
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch" ></GridEditSettings>
    <GridEvents TValue="OrderDetails" OnCellEdit="CellEditHandler"></GridEvents>
        <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public void CellEditHandler(CellEditArgs<OrderDetails> args)
    {
        if (args.Data.ShipCountry == "France" && args.Column.Field == "ShipCountry")
        {
            args.Cancel = true;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBoZshVWCZLddwb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Save or update the changes immediately

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides a convenient way to save or update changes immediately in batch mode without the need for a separate Save button. This feature is particularly useful when you want to allow you to edit data efficiently without having to manually trigger a save action. You can achieve this by utilizing the [CellSaved](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellSaved) event and the [EndEditAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EndEditAsync) method.

By default, when you use the `EndEditAsync` method to save or update data, a confirmation dialog is displayed. This dialog prompts for confirmation before proceeding with the save or cancel action, helping to prevent accidental or undesired changes.

The `CellSaved` event is triggered when a cell is saved in the Grid. It provides a way to perform custom logic when a cell is saved or updated.

> * To avoid the confirmation dialog when using the `EndEditAsync` method, you can set [GridEditSettings.ShowConfirmDialog](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_ShowConfirmDialog) to **false**. However, note that to use this property, the [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) must be set to **Batch**. This combination allows you to save or update changes immediately without the need for a confirmation dialog.

Here's an example that demonstrates how to achieve immediate saving or updating of changes using the `CellSaved` event and the `EndEditAsync` method:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" >
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch" ShowConfirmDialog="false"></GridEditSettings>
    <GridEvents TValue="OrderDetails" CellSaved="CellSavedHandler"></GridEvents>
        <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
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
    public void CellSavedHandler(CellSavedArgs<OrderDetails> args)
    {
        Grid.EndEditAsync();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVItChDTJgJazlr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Edit next row or previous row from the current row

In batch mode, you can seamlessly edit the next or previous row directly from the current row by enabling the [GridEditSettings.AllowNextRowEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_AllowNextRowEdit) property and setting it to **true**. This feature enhances the user experience by streamlining row-to-row editing in an efficient and intuitive manner.

* **Navigate to the Next Row**: Press the `TAB` key from the last cell of the current row to move to and begin editing the first cell of the next row.
* **Navigate to the Previous Row**: Press `SHIFT + TAB` from the first cell of the current row to move to and begin editing the last cell of the previous row.

The following example demonstrates how to enable or disable the `GridEditSettings.AllowNextRowEdit` property:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom:5px">
    <label> Enable or Disable AllowNextRowEdit Property:</label>
    <SfSwitch ValueChange="ValueChange" TChecked="bool" style="margin-top:5px"></SfSwitch>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch" AllowNextRowEdit="@NextRowEditValue"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public bool NextRowEditValue { get; set; } = false;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private void ValueChange(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        NextRowEditValue = args.Checked;
        Grid.PreventRender(false);
    }
}
{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, double Freight, string ShipCountry, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public DateTime OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVeZshWVcvQDOWF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Provide new item or edited item using events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid uses `Activator.CreateInstance<TValue>()` to create or clone new record instances during add and edit operations. Therefore, the model class and any referenced complex type classes must have parameterless constructors defined.

However, there are scenarios where custom logic is required to create a new object, or a new object instance cannot be created using `Activator.CreateInstance<TValue>()`. In such cases, you can manually provide the model object instance using events.

You can use the [OnBatchAdd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnBatchAdd) and [OnCellEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnCellEdit) events to provide a new object instance during add and cell edit operations, respectively.

For the add operation, assign the new object to the [OnBatchAdd.DefaultData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.BeforeBatchAddArgs-1.html#Syncfusion_Blazor_Grids_BeforeBatchAddArgs_1_DefaultData) property. For cell editing, assign the cloned object to the [OnCellEdit.Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.CellEditArgs-1.html#Syncfusion_Blazor_Grids_CellEditArgs_1_Data) property.

In the following example:

* A model class without a parameterless constructor is bound to the Grid.
* Batch editing is enabled in the Grid.
* The `OnBatchAdd` event callback assigns a custom object to the `DefaultData` property for the add operation.
* The `OnCellEdit` event callback assigns a custom object to the `Data` property for the edit operation.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })">
    <GridEvents TValue="OrderDetails" OnBatchAdd="BeforeAdd" OnCellEdit="CellEdit"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private int LatestOrderID { get; set; } = 101;
    public void BeforeAdd(BeforeBatchAddArgs<OrderDetails> args)
    {
        args.DefaultData = new OrderDetails(LatestOrderID, "HANAR", 33, "Brazil", new DateTime(1999, 8, 7));
        LatestOrderID += 1;
    }
    public void CellEdit(CellEditArgs<OrderDetails> args)
    {
        //Return args.Data if it is not null, so previously edited data will not be lost.
        args.Data = args.Data ?? new OrderDetails(args.RowData.OrderID, args.RowData.CustomerID, args.RowData.Freight, args.RowData.ShipCountry, args.RowData.OrderDate);
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, double Freight, string ShipCountry, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public DateTime OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhojCBWKkZwhwWp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to perform bulk changes using a method

To perform bulk changes—including adding, editing, and deleting records—you can use the [ApplyBatchChangesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ApplyBatchChangesAsync_Syncfusion_Blazor_Grids_BatchChanges__0__) method. This method streamlines the process of updating new, edited, and deleted records within the current page of the Grid, allowing you to efficiently apply all changes at once.

When you make edits or add new records, these changes are visually highlighted in green within the current view. This visual cue allows you to easily identify modified records and choose whether to save or cancel the changes, enabling seamless and efficient management of bulk modifications.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom:5px"><SfButton OnClick="BulkDataUpdate">Apply Batch Changes</SfButton></div>
<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
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
    private void BulkDataUpdate()
    {
        var BatchChanges = new BatchChanges<OrderDetails>()
        {
            AddedRecords = new List<OrderDetails>() { new OrderDetails(101, "HANAR", 33, "Brazil", new DateTime(1999, 8, 7)), 
            new OrderDetails(102, "RATTC", 78, "USA", new DateTime(1996, 7, 14)) },
            DeletedRecords = new List<OrderDetails>() { new OrderDetails(10250, "HANAR", 65.83, "Brazil", new DateTime(1996, 7, 8)) },
            ChangedRecords = new List<OrderDetails>() { new OrderDetails(10248, "CENTC", 52, "Germany", new DateTime(1996, 9, 9)) }
        };
        Grid.ApplyBatchChangesAsync(BatchChanges);
    }
}
{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, double Freight, string ShipCountry, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public DateTime OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrStoqXKmIboOTG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Supported events for batch editing

Batch editing in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers a powerful way to edit multiple records simultaneously. Understanding the sequence and purpose of events triggered during this process enables users to customize or extend the data Grid's functionality. This section outlines the key events associated with batch editing, providing essential information to harness the full potential of this feature.

| Event | Description |
|-------|-------------|
| [OnBatchAdd](https://blazor.syncfusion.com/documentation/datagrid/events#onbatchadd) | Triggers before new records are added to the UI when the user clicks the add toolbar item or presses the insert key. |
| [OnBatchSave](https://blazor.syncfusion.com/documentation/datagrid/events#onbatchsave) | Triggers before batch changes (added, edited, deleted data) are saved to the data source. A confirmation popup is displayed when the Update button is clicked. |
| [OnBatchDelete](https://blazor.syncfusion.com/documentation/datagrid/events#onbatchdelete) | Triggers before records are deleted in the Grid. If no rows are selected, a popup prompts the user to select rows for deletion. |
| [OnCellEdit](https://blazor.syncfusion.com/documentation/datagrid/events#oncelledit) | Triggers before a cell enters edit mode in the UI, such as on double-click or pressing F2. |
| [OnCellSave](https://blazor.syncfusion.com/documentation/datagrid/events#oncellsave) | Triggers before cell changes are updated in the UI, such as on pressing Enter key or navigating to another cell. |
| [CellSaved](https://blazor.syncfusion.com/documentation/datagrid/events#cellsaved) | Triggers after cell changes are updated in the UI and the edited values are highlighted in the Grid. |