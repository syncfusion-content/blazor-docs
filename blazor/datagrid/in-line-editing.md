---
layout: post
title: Inline Editing in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Inline Editing in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Inline editing in Blazor DataGrid

The Syncfusion Blazor DataGrid provides a powerful in-line editing feature that allows you to edit the cell values of a row directly within the Grid. This feature is especially useful when you want to quickly modify data without the need for a separate edit form. In normal edit mode, the selected record is switched to an editable state, allowing you to modify the cell values and save the changes to the data source.

To enable in-line editing in the Grid, set the [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property of the Grid's configuration to **Normal**. This property determines the editing mode of the Grid.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhTWVWxfiLoTefJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Normal edit mode is default mode of editing.
> * When enabling editing, it is necessary to set the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property value to **true** for the unique column.

## Automatically update a specific column based on another column edited value

You can automatically update the value of a column based on the edited value of another column using the Cell Edit Template feature. This is useful when you want to dynamically calculate and update a column's value in real time based on changes made to another related column.

You can update a column value based on another column’s edited value in normal mode by using the [RowUpdating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowUpdating) and [RowEdited](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowEdited) events, along with the [EditTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditTemplate) property of the Grid.

In the following example, the **TotalCost** column value is updated based on changes to the **UnitPrice** and **UnitsInStock** columns during normal editing.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs

<SfGrid @ref="Grid" DataSource="@ProductData" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="273">
    <GridEvents TValue="ProductDetails" RowEdited="EditHandler" RowUpdating="UpdateHandler"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(ProductDetails.ProductID)" HeaderText="Product ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" ValidationRules="@(new ValidationRules { Required = true })" Width="100"></GridColumn>
        <GridColumn Field="@nameof(ProductDetails.ProductName)" HeaderText="Product Name" ValidationRules="@(new ValidationRules { Required = true })" Width="120">
        </GridColumn>
        <GridColumn Field="@nameof(ProductDetails.UnitPrice)" HeaderText="Unit Price" Width="150" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules { Required = true, Min = 1 })" Format="C2">
            <EditTemplate>
                @{
                    var Data = context as ProductDetails;
                    <SfNumericTextBox @ref="UnitPriceReference" TValue="double" @bind-Value="@Data.UnitPrice" Min="1">
                        <NumericTextBoxEvents TValue="double" ValueChange="@ValueChangeHandler"></NumericTextBoxEvents>
                    </SfNumericTextBox>
                }
            </EditTemplate>
        </GridColumn>
        <GridColumn Field="@nameof(ProductDetails.UnitsInStock)" HeaderText="Units In Stock" Width="150" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules { Required = true, Min = 1 })">
            <EditTemplate>
                @{
                    var Data = context as ProductDetails;
                    <SfNumericTextBox @ref="UnitsInStockReference" TValue="double" @bind-Value="@Data.UnitsInStock" Min="1">
                        <NumericTextBoxEvents TValue="double" ValueChange="ValueChangeHandler"></NumericTextBoxEvents>
                    </SfNumericTextBox>
                }
            </EditTemplate>
        </GridColumn>
        <GridColumn Field="@nameof(ProductDetails.TotalCost)" HeaderText="Total Cost" Width="150" AllowEditing="false" Format="C2" TextAlign="TextAlign.Right">
            <EditTemplate>
                @{
                    <SfNumericTextBox TValue="double" Value="@TotalValue" Enabled="false">
                    </SfNumericTextBox>
                }
            </EditTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<ProductDetails> Grid;
    SfNumericTextBox<double> UnitPriceReference;
    SfNumericTextBox<double> UnitsInStockReference;
    public double TotalValue { get; set; }
    public List<ProductDetails> ProductData { get; set; }
    protected override void OnInitialized()
    {
        ProductData = ProductDetails.GetAllRecords();
    }
    public async Task UpdateHandler(RowUpdatingEventArgs<ProductDetails> args)
    {        
        args.Data.TotalCost = TotalValue;
    }
    public async Task EditHandler(RowEditedEventArgs<ProductDetails> args)
    {     
        TotalValue = args.Data.TotalCost;
    }
    private void ValueChangeHandler()
    {
        TotalValue = Convert.ToDouble(UnitPriceReference.Value * UnitsInStockReference.Value);
        Grid.PreventRender(false);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrJMhsGhTuTRXHB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Cancel edit based on condition

The Syncfusion Blazor DataGrid provides the ability to cancel edit operations for a particular row or cell based on specific conditions. This feature allows you to control whether editing should be allowed or prevented for certain rows or cells in the Grid.

To cancel an edit operation based on a specific condition, you can handle the following Grid events. These events are triggered when a CRUD (Create, Read, Update, and Delete) operation is performed in the Grid:

1. [RowCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowCreating): Triggered before an add action is executed in the Grid.

2. [RowDeleting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDeleting): Triggered before a delete action is executed in the Grid.

3. [RowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowEditing): Triggered before an edit action is executed in the Grid.

By applying your desired condition, you can cancel the edit, delete, or add operation by setting the `args.Cancel` property to **true**.

In the demo below, CRUD operations are prevented based on the **Role** column value. If the Role column is **Admin**, then edit and delete actions are prevented for that row.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-outline" Content="@Content" OnClick="ToggleGridAddability" style="margin-bottom:5px"></SfButton>
<SfGrid DataSource="@EmployeeData" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridEvents TValue="EmployeeDetails" RowEditing="RowEditingHandler" RowCreating="RowAddingHandler" RowDeleting="RowDeletingHandler"></GridEvents>
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
    public void RowAddingHandler(RowCreatingEventArgs<EmployeeDetails> args)
    {
        if (!IsAddable)
        {
            args.Cancel = true; 
        }
    }
    public void RowEditingHandler(RowEditingEventArgs<EmployeeDetails> args)
    {
        if (args.Data.Role == "Admin") 
        {
            args.Cancel = true;
        }
    }
    public void RowDeletingHandler(RowDeletingEventArgs<EmployeeDetails> args)
    {
        if (args.Datas[0].Role == "Admin")
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBfWhsbiluKzXeX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Perform CRUD action programmatically

Performing CRUD actions programmatically means creating, reading, updating, and deleting data in a system or application using code instead of manual user interaction.

* To add a new record to the Grid, use the [AddRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AddRecordAsync__0_System_Nullable_System_Int32__) method. You can pass the **data** parameter to add a new record, and the **index** parameter to add a record at a specific position. If you call this method without any parameters, it will create an empty row in the Grid. If an index is not specified, the new record will be displayed at the zeroth index.

* To change the selected row to the edit state, use the [StartEditAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_StartEditAsync) method. Before invoking this method, you must select a row in the Grid.

* To update the row data in the Grid’s data source, use the [UpdateRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UpdateRowAsync_System_Int32__0_) method. Pass the **index** of the row to be updated along with the updated **data**.

* To update a particular cell in a row, use the [SetCellValueAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetCellValueAsync_System_Object_System_String_System_Object_) method. Pass the primary key value, field name, and new value for the cell. Changes made using this method are only reflected visually in the Grid UI and are not persisted in the underlying data source. This method is commonly used for unbound columns, such as auto-calculated or formula columns, where values are derived from other data within the Grid or external calculations.

* To remove a selected row from the Grid, use the [DeleteRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DeleteRecordAsync) method. For both edit and delete operations, you must select a row first.

> These methods can be used in both normal and dialog editing modes.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom:5px">
    <SfButton CssClass="e-outline" Content="Add" OnClick="GridAddAction"></SfButton>
    <SfButton CssClass="e-outline" Content="Edit" OnClick="GridEditAction"></SfButton>
    <SfButton CssClass="e-outline" Content="Delete" OnClick="GridDeleteAction"></SfButton>
    <SfButton CssClass="e-outline" Content="Update Row" OnClick="UpdateRowAction"></SfButton>
    <SfButton CssClass="e-outline" Content="Update Cell" OnClick="UpdateCellAction"></SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public async Task GridAddAction()
    {
        var newRecord = new OrderDetails(
            new Random().Next(100000),
            GenerateCustomerId(),
            GenerateShipCity(),
            GenerateShipName()
        );
        await Grid.AddRecordAsync(newRecord);
    }
    public async Task GridEditAction()
    {
        await Grid.StartEditAsync();
    }
    public async Task GridDeleteAction()
    {
        await Grid.DeleteRecordAsync();
    }
    public async Task UpdateRowAction()
    {
        var UpdatedData = new OrderDetails(10248, "RTER", "America", "Hanari");
        await Grid.UpdateRowAsync(0, UpdatedData);
    }
    public async Task UpdateCellAction()
    {
        var firstRecord = Grid.CurrentViewData.FirstOrDefault();
        if (firstRecord != null)
        {
            if (firstRecord is OrderDetails record)
            {
                await Grid.SetCellValueAsync(record.OrderID, "CustomerID", "Value Changed");
            }            
        }        
    }
    private string GenerateCustomerId()
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var random = new Random();
        return new string(Enumerable.Repeat(characters, 5).Select(s => s[random.Next(s.Length)]).ToArray());
    }
    private string GenerateShipCity()
    {
        var cities = new[] { "London", "Paris", "New York", "Tokyo", "Berlin" };
        return cities[new Random().Next(cities.Length)];
    }
    private string GenerateShipName()
    {
        var names = new[] { "Que Delícia", "Bueno Foods", "Island Trading", "Laughing Bacchus Winecellars" };
        return names[new Random().Next(names.Length)];
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora"));
            Order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            Order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            Order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            Order.Add(new OrderDetails(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            Order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBTWrWOgendnpyr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Show confirmation dialog while deleting

Displaying a confirmation dialog adds an extra layer of safety when deleting a record from the Syncfusion Blazor DataGrid. This dialog prompts the user for confirmation before proceeding with the deletion, helping to prevent accidental or unintended deletions. The deletion will only proceed if the user confirms the action. The Grid provides a built-in confirmation dialog for this purpose.

To enable the confirmation dialog for delete operations in the Grid, set the [ShowDeleteConfirmDialog](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_ShowDeleteConfirmDialog) property of the `GridEditSettings` configuration to **true**. By default, this property is set to **false**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom:5px">
    <label> Enable or Disable show delete confirmation dialog:</label>
    <SfSwitch ValueChange="Change" TChecked="bool" style="margin-top:5px"></SfSwitch>
</div>
<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal" ShowDeleteConfirmDialog="@DeleteConfirmDialog"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public bool DeleteConfirmDialog { get; set; } = false;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBfiLsFpKplAfEA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The `ShowDeleteConfirmDialog` property supports all type of edit modes.

## Display default value for columns while adding

This feature is useful when you want to pre-fill certain column values with default values to streamline the data entry process. The Grid allows you to set default values for columns when adding a new record.

To set a default value for a specific column in the Grid, use the [DefaultValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_DefaultValue) property of the `GridColumns` configuration. When a new row is added, the Grid will automatically populate the specified default value in the corresponding column.

Here's an example of how to set a default value for a column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal" ></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" DefaultValue="@CustomerValue" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" DefaultValue="@FreightValue" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" DefaultValue="@CountryValue" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public string CustomerValue { get; set; } = "HANAR";
    public double FreightValue { get; set; } = 1.0;
    public string CountryValue { get; set; } = "France";
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVJCLsuBDjebSEM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Delete multiple rows

The delete multiple rows feature in the Syncfusion Blazor DataGrid allows you to easily remove several rows at once. This is useful when you need to delete multiple records simultaneously. There are two ways to implement this feature: using the built-in toolbar delete option or by calling a method.

**Using the built-in toolbar delete option**

The Syncfusion Blazor DataGrid provides a user-friendly interface for performing actions such as deleting rows through the built-in toolbar. To enable deleting multiple rows using the toolbar, configure the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property and set the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) property to **Multiple** to allow multiple row selection.

To delete multiple selected records, first select the desired rows in the Grid by highlighting or checking their checkboxes. Then, click the delete icon in the toolbar. This will remove the selected records from the Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowSelection="true" Toolbar="@(new List<string>() { "Delete" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLpiBMkLcuVmJPN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can also delete the selected records using the **Delete** keyboard shortcut.

**Using method**

You can delete multiple rows programmatically by using the [DeleteRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DeleteRecordAsync) method. This method allows you to delete records with the given options. If the **fieldName** (the field name of the primary key column) and **data** parameters are not provided, the Grid will delete the selected records.

```ts
Grid.DeleteRecordAsync();
```

> * The `GridSelectionSettings.Type` property must be set to **Multiple** to enable multiple row selection.
> * To prevent accidental or undesired deletions, it is recommended to enable the `ShowDeleteConfirmDialog` property in the `GridEditSettings` configuration.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-outline" Content="Delete Multiple" OnClick="GridDeleteAction" style="margin-bottom:5px"></SfButton>
<SfGrid DataSource="@OrderData" AllowSelection="true" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private async Task GridDeleteAction()
    {
        await Grid.DeleteRecordAsync();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLStsZBUpReRDUm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Adding a new row at the bottom of the Blazor DataGrid

The Syncfusion Blazor DataGrid allows you to add a new row at the bottom, enabling you to insert a new record at the end of the existing data set. This feature is especially useful when you want to conveniently add new records without scrolling up or manually repositioning the newly added row.

By default, when adding a new row, the Grid inserts it at the top. However, you can change this behavior by setting the [NewRowPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_NewRowPosition) property of the `GridEditSettings` configuration to **Bottom**. This property determines where the new row will be inserted.

Here's an example of how to enable adding new rows at the bottom of the Grid:

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
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.Grids.EditMode.Normal" NewRowPosition="@RowPosition"></GridEditSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZhTCBWEJgzWWmwI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The `NewRowPosition` property is supported for **Normal** and **Batch** editing modes.

## Saving a new row at a particular index

By default, when a new row is added to the Syncfusion Blazor DataGrid, it is inserted and saved at the top of the Grid’s data source. However, certain use cases may require saving the newly added row at a different position. For example, at the end of the current page or a custom index based on business logic.

To achieve this customization, the `args.Index` property can be set during the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event of the Grid. This allows the developer to define the exact position where the new row should be saved in the underlying data source.

The following sample code demonstrates changing the save index of the new row that gets added in the Grid. Using `ActionBegin` event, `args.Index` property can be used to set the custom index for the saved new row. This allows the users to define the exact position where the new row should be saved in the underlying data source. 

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Action = Syncfusion.Blazor.Grids.Action

<SfGrid @ref="GridInstance" AllowPaging="true" DataSource="@Orders" Toolbar="@(new List<string>() { "Add","Edit","Delete","Update","Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" NewRowPosition="NewRowPosition.Bottom"></GridEditSettings>
    <GridEvents OnActionBegin="OnActionBegin" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Order> GridInstance { get; set; }
    public List<Order> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[new Random().Next(5)]
        }).ToList();
    }
    public void OnActionBegin(ActionEventArgs<Order> args)
    {
        if (args.RequestType.Equals(Action.Save) && args.Action == "Add")
        {
            //Here you can set the custom index for the saved new row. Below calculation save the new row as last row of current page.
            args.Index = (GridInstance.PageSettings.CurrentPage * GridInstance.PageSettings.PageSize) - 1;
        }
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDByNfVYAhjTFmxS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Show add new row always in Blazor DataGrid

The Syncfusion Blazor DataGrid simplifies the addition of new records by consistently presenting a blank "add new row" form within the Grid. To enable this feature, set the [ShowAddNewRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_ShowAddNewRow) property within the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) configuration to **true**. This allows for continuous addition of new records. You can display the add new row at either the top or bottom of the Grid content, depending on the [NewRowPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_NewRowPosition) property of `GridEditSettings`. By default, the add new row is displayed at the top of the Grid content.

The following sample demonstrates how to add a new record continuously using the `ShowAddNewRow` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.Grids.EditMode.Normal" NewRowPosition="Syncfusion.Blazor.Grids.NewRowPosition.Top" ShowAddNewRow="true"></GridEditSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLfiLskTTrNxaux?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
> To save newly added records, you can either press the **Enter** key or click the **Update** button on the toolbar after filling in the new add form.

### Limitations

* This feature is supported only in Inline/Normal editing mode and is not compatible with other edit modes.
* The new blank add row form will always be displayed at the top, even if you set the new row position to bottom for Grids with Virtual Scrolling or Infinite Scrolling enabled.
* This feature is not compatible with the column virtualization feature.

## Enable editing in single click

Enabling single-click editing in the Syncfusion Blazor DataGrid's **Normal** editing mode is a valuable feature that allows you to make a row editable with just one click. This can be achieved by using the [StartEditAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_StartEditAsync) and [EndEditAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EndEditAsync) methods.

To implement this feature, bind the [OnRecordClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnRecordClick) event of the Grid. Within the event handler, call the `StartEditAsync` method to begin editing the clicked row and the `EndEditAsync` method to save or cancel editing for a previously edited row. This ensures that editing mode is triggered when a specific record in the Grid is clicked.

The following sample demonstrates how to enable editing with a single click using the `OnRecordClick` event:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal" ></GridEditSettings>
    <GridEvents OnRecordClick="RecordClickHandler" TValue="OrderDetails"></GridEvents>
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
    private int? CurrentRowIndex { get; set; } = null;
    public async Task RecordClickHandler(Syncfusion.Blazor.Grids.RecordClickEventArgs<OrderDetails> args)
    {
        if (Grid.IsEdit && CurrentRowIndex != args.RowIndex)
        {
            // End editing for the previously edited row.
            await Grid.EndEditAsync();
        }
        // Update the currently selected row index
        CurrentRowIndex = args.RowIndex;
        await Grid.SelectRowAsync(args.RowIndex);
        // Start editing the clicked row.
        await Grid.StartEditAsync();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtryNWXVhqPKVwhQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable editing for a particular row

In the Syncfusion Blazor DataGrid, you can prevent editing of specific rows based on certain conditions. This feature is useful when you want to restrict editing for certain rows, such as those containing read-only data, calculated values, or protected information. It helps maintain data integrity and ensures that only authorized changes can be made in the Grid.

To disable editing for a particular row, use the [RowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowEditing) event of the Grid. You can set the **args.Cancel** property to **true** within this event to prevent editing for that row.

In the demo below, rows with the value **France** in the **ShipCountry** column are prevented from being edited.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal" ></GridEditSettings>
    <GridEvents TValue="OrderDetails" RowEditing="RowEditingHandler"></GridEvents>
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
    public void RowEditingHandler(RowEditingEventArgs<OrderDetails> args)
    {
        if (args.Data.ShipCountry == "France") 
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLotiNrUuudyXpE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Provide new item or edited item using events

The Syncfusion Blazor DataGrid uses `Activator.CreateInstance<TValue>()` to create or clone a new record instance during add and edit operations, so the model class and any referenced complex type classes must have parameterless constructors defined.

However, there are cases where custom logic is required to create a new object, or a new object instance cannot be created using `Activator.CreateInstance<TValue>()`. In such cases, you can manually provide the model object instance using events.

You can use the [RowCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowCreating) and [OnBeginEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnBeginEdit) events to provide a new object instance during creation and editing operations. The new object should be assigned to the `RowCreating<TValue>.Data` and `OnBeginEdit<TValue>.RowData` properties.

In the following example:

* A model class without a parameterless constructor is bound to the Grid.
* Inline editing is enabled in the Grid.
* The `RowCreating` event is used to assign default values for new rows.
* The `OnBeginEdit` event is used to clone the current row's data when editing an existing item.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridEvents OnBeginEdit="OnBeginEdit" RowCreating="RowCreating" TValue="OrderDetails"></GridEvents>
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
    private int LatestOrderID { get; set; } = 101;
    public void RowCreating(RowCreatingEventArgs<OrderDetails> args)
    {
        args.Data.OrderID = LatestOrderID; 
        args.Data.CustomerID = "HANAR"; 
        args.Data.Freight = 5;
        args.Data.ShipCountry = "Brazil";
        LatestOrderID += 1;
    }
    public void OnBeginEdit(BeginEditArgs<OrderDetails> args)
    {
        args.RowData = new OrderDetails(args.RowData.OrderID, args.RowData.CustomerID, args.RowData.Freight, args.RowData.ShipCountry);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthINCtgBmWlAIwy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Supported events for inline and dialog editing

Inline and dialog editing in the Syncfusion Blazor DataGrid provide flexible ways to modify records, catering to various user needs. This section outlines the key events triggered during the editing operations, including adding, editing, updating, deleting, and canceling, to help you effectively implement and customize the Grid’s behavior for enhanced user interaction.

**Sequence of events**

* **Adding a new record**

| Event | Description |
|-------|-------------|
| [RowCreating](https://blazor.syncfusion.com/documentation/datagrid/events#rowcreating) | Triggers before a new row is added to the Grid. This event is useful for initializing default values or conditionally preventing the add operation. |
| [RowCreated](https://blazor.syncfusion.com/documentation/datagrid/events#rowcreated) | Triggers after a new row is added to the Grid. |

* **Editing a record**

| Event | Description |
|-------|-------------|
| [OnRowEditStart](https://blazor.syncfusion.com/documentation/datagrid/events#onroweditstart) | Triggers before a row enters edit mode. Enables control over data cloning behavior and can be used to prepare the row for editing. |
| [OnBeginEdit](https://blazor.syncfusion.com/documentation/datagrid/events#onbeginedit) | Triggers before a row enters edit mode in the UI, such as on double-click or pressing F2. This event is useful for conditional editing logic. |
| [RowEditing](https://blazor.syncfusion.com/documentation/datagrid/events#rowediting) | Triggers before the edit action is performed. This event is useful for validation or dynamic configuration of the editing interface. |
| [RowEdited](https://blazor.syncfusion.com/documentation/datagrid/events#rowedited) | Triggers after the edit action is completed. |

* **Saving (Updating) a record**

| Event | Description |
|-------|-------------|
| [RowUpdating](https://blazor.syncfusion.com/documentation/datagrid/events#rowupdating) | Triggers before the edited or newly added data is saved. Used for validating or modifying data before it is committed to the data source. |
| [RowUpdated](https://blazor.syncfusion.com/documentation/datagrid/events#rowupdated) | Triggers after the edited or newly added data is saved to the data source. |

* **Deleting a record**

| Event | Description |
|-------|-------------|
| [RowDeleting](https://blazor.syncfusion.com/documentation/datagrid/events#rowdeleting) | Triggers before a row is deleted from the Grid. This event is used to confirm deletion or cancel the operation based on custom logic. |
| [RowDeleted](https://blazor.syncfusion.com/documentation/datagrid/events#rowdeleted) | Triggers after a row is deleted from the Grid. |

* **Canceling an edit operation**

| Event | Description |
|-------|-------------|
| [EditCanceling](https://blazor.syncfusion.com/documentation/datagrid/events#editcanceling) | Triggers before the cancellation of an edit operation. This event is useful for confirmation prompts or rollback logic before discarding changes. |
| [EditCanceled](https://blazor.syncfusion.com/documentation/datagrid/events#editcanceled) | Triggers after the cancellation of an edit operation. |

> The same events are also applicable when using **Dialog** editing mode.