## Adding/Removing nuget packages

You can install nuget packages by clicking the packages section in the nuget asset manager. Search for the necessary nuget package and install based on the available versions. The selected package also install its necessary dependency packages. So there is no need for installing the dependency packages.

N>Blazor playground is a WASM application, so it can only install client-side packages. Server-side packages are cannot be installed.

For example, Click the package section in the nuget asset manager. Search for Syncfusion.Blazor.Grid and install the package based on available version. Here, the grid component is added to Index.razor.

```csharp

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Grids
<SfGrid DataSource="@OrderData" Toolbar=@ToolbarItems>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" EditType="EditType.DefaultEdit" EditorSettings="@CustomerEditParams" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" EditType="EditType.DropDownEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) HeaderText="Verified" EditType="EditType.BooleanEdit" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" DisplayAsCheckBox="true" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code{
    public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel" };
    public IEditorSettings CustomerEditParams = new StringEditCellParams
    {
        Params = new TextBoxModel() { EnableRtl = true, ShowClearButton = false, Multiline = true }
    };
    List<Order> OrderData = new List<Order>
{
        new Order() { OrderID = 10248, CustomerID = "VINET", Freight = 32.38, ShipName = "Vins et alcools Chevalier", Verified = true },
        new Order() { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61, ShipName = "Toms Spezialitäten", Verified = false },
        new Order() { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83, ShipName = "Hanari Carnes", Verified = true },
        new Order() { OrderID = 10251, CustomerID = "VICTE", Freight = 41.34, ShipName = "Victuailles en stock", Verified = false },
        new Order() { OrderID = 10252, CustomerID = "SUPRD", Freight = 51.3, ShipName = "Suprêmes délices", Verified = false },
        new Order() { OrderID = 10253, CustomerID = "HANAR", Freight = 58.17, ShipName = "Hanari Carnes", Verified = false },
        new Order() { OrderID = 10254, CustomerID = "CHOPS", Freight = 22.98, ShipName = "Chop-suey Chinese", Verified = true },
        new Order() { OrderID = 10255, CustomerID = "RICSU", Freight = 148.33, ShipName = "Richter Supermarket", Verified = true },
        new Order() { OrderID = 10256, CustomerID = "WELLI", Freight = 13.97, ShipName = "Wellington Importadora", Verified = false },
        new Order() { OrderID = 10257, CustomerID = "HILAA", Freight = 81.91, ShipName = "HILARION-Abastos", Verified = true }
    };
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public bool Verified { get; set; }
    }
}
```

![Adding Nuget Packages](images/Nuget_Packages.png)

You can also downgrade or upgrade the installed package by searching the same package name. Also, provided the option to delete the installed packages.

![Upgrading Nuget Packages](images/Upgrade.png)


## Adding Multiple nuget packages

You can also install multiple nuget packages. After installation, you can start using the added packages in your code. 

For example, 

N>To avoid compatibility issues, make sure that all Syncfusion Blazor packages are installed in the same version.