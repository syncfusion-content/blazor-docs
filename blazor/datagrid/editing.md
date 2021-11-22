---
layout: post
title: Editing in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Editing in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Editing in Blazor DataGrid Component

The DataGrid component has options to dynamically insert, delete and update records.

> [Editing](https://blazor.syncfusion.com/documentation/datagrid/editing/) feature requires a primary key column for CRUD operations.

To know about editing feature in Blazor DataGrid component, you can check on this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=jOiZpLexDB0"%}

To define the primary key, set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) to **true** in particular column whose value is unique.

You can start the edit action either by double-clicking the particular row or by selecting the required row and click on the **Edit** button in the toolbar. Similarly, you can add a new record to DataGrid either by clicking on **Add** button in the toolbar or on an external button which is bound to invoke the [AddRecord](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AddRecord) method of the DataGrid, **Save** and **Cancel** while in edit mode is possible using the respective toolbar icon in DataGrid.

Deletion of the record is possible by selecting the required row and click on **Delete** button in the toolbar.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" Height ="315">
   <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

```

The following screenshot represents Editing with Default Mode.
![Editing in Blazor DataGrid](./images/blazor-datagrid-editing.png)

> * Grid uses `Activator.CreateInstance<TValue>()` to generate a new record when an insert operation is invoked, so it must have a parameterless constructor defined for the model class and any referenced complex type classes. To provide custom logic for object creation during editing, you can refer [here](#provide-new-item-or-edited-item-using-events).
> * If [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) is enabled, then it will be considered as a read-only column when editing and adding a record.
> * You can disable editing for a particular column, by specifying
[AllowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowEditing) to **false**.
>* You can disable adding for a particular column, by specifying
[AllowAdding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowAdding) to **false**.
>* You can disable editing of a record on double click, by specifying
[EditSettings.AllowEditOnDblClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_AllowEditOnDblClick) to **false**.

## Toolbar with edit option

The datagrid toolbar has the  following built-in items to execute editing actions.

* Add - Adds a new record.
* Edit - Edits the selected record.
* Update - Updates the edited record.
* Delete - Deletes the selected record.
* Cancel - Cancels the edit state.

You can define this by using the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
   <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120" ></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" ></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following screenshot represents Toolbar with Edit option.
![Blazor DataGrid displays Edit option in Toolbar](./images/blazor-datagrid-editing.png)

## Edit Modes

DataGrid supports the following types of edit modes, they are:

* Normal
* Dialog
* Batch

### Normal

In Normal edit mode, when you start editing the currently selected record is changed to edit state. You can change the cell values and save edited data to the data source. To enable the  Normal edit, set the [EditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) as **Normal**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

The following screenshot represents Editing in Normal Mode.
![Blazor DataGrid with Normal Editing](./images/blazor-datagrid-normal-editing.png)

> Normal edit mode is the default mode of editing.

### Dialog

In dialog edit mode, when you start editing the currently selected row data will be shown on a dialog. You can change the cell values and save edited data to the data source. To enable Dialog edit, set the [EditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) as **Dialog**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}

```

The following screenshot represents Editing in Dialog Mode.
![Blazor DataGrid with Dialog Editing](./images/blazor-datagrid-dialog-editing.png)

### Batch

In batch edit mode, when you double-click on the datagrid cell, then the target cell changed to edit state. You can bulk save (added, changed, and deleted data in the single request) to the data source by click on the toolbar's **Update** button or by externally calling the **EndEdit** method. To enable Batch edit, set the [EditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) as **Batch**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules { Required = true })" Type="ColumnType.Number" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

The following screenshot represents Editing in Batch mode.
![Blazor DataGrid with Batch Editing](./images/blazor-datagrid-batch-editing.png)

## Edit next row or previous row from the current row

You can continue editing the next row or previous row from the current record in batch mode by enabling [EditSettings.AllowNextRowEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_AllowNextRowEdit) to **true**.

Pressing `TAB` from the last cell of the current row allows editing the next row and Pressing `SHIFT + TAB` from the first cell of the current row allows editing the previous row.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules { Required = true })" Type="ColumnType.Number" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

The following GIF represents Editing in Batch mode.
![Editing Next Row in Blazor DataGrid](./images/blazor-datagrid-next-row-edit.gif)

## Cell edit type

The [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) property of the [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) component is used for defining the editor component for any particular column. You can set the [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) based on the data type of the column.

The available default edit types are,

* [NumericEdit](https://blazor.syncfusion.com/documentation/numeric-textbox/getting-started) component for integers, double, and decimal data types.

* [DefaultEdit](https://blazor.syncfusion.com/documentation/textbox/getting-started) component for string data type.

* [DropDownEdit](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started) component to show all unique values related to that field.

* [BooleanEdit](https://blazor.syncfusion.com/documentation/check-box/getting-started) component for boolean data type.

* [DatePickerEdit](https://blazor.syncfusion.com/documentation/datepicker/getting-started) component for date data type.

* [DateTimePickerEdit](https://blazor.syncfusion.com/documentation/datetime-picker/getting-started) component for date time data type.

## Customizing the default editor controls

You can customize the behavior of the editor component through the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) property of the [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) component.

> We have limited the properties of editor components that can be customized using [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) in Grid default editor components. Kindly find the list of properties that can be customized the below topics.
> If you want to customize other properties, refer to our [EditTemplate](https://blazor.syncfusion.com/documentation/datagrid/editing/#cell-edit-template) documentation to render the custom components in EditForm along with your customization.

### DefaultEdit

`StringEditCellParams` class helps us to customize the default TextBox component in Grid EditForm. The following table describes properties of TextBox control than can be customized using `EditorSettings` of GridColumn editor component.

| Component | Description |
|--------|----------------|
| CssClass | Specifies the CSS class value that is appended to wrapper of Textbox. |
| EnableRtl | Enable or disable rendering component in right to left direction.  |
| ReadOnly | Specifies the boolean value whether the TextBox allows user to change the text.   |
| ShowClearButton | Specifies a Boolean value that indicates whether the clear button is displayed in Textbox.   |
| Multiline | Specifies a boolean value that enable or disable the multiline on the TextBox. The TextBox changes from single line to multiline when enable this multiline mode.   |

The following sample code demonstrates the customization applied to TextBox component set for the DataGrid columns,

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar=@ToolbarItems>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" EditType="EditType.DefaultEdit" EditorSettings="@CustomerEditParams" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Center" EditType="EditType.DropDownEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) HeaderText="Verified" EditType="EditType.BooleanEdit" TextAlign="TextAlign.Center" DisplayAsCheckBox="true" Width="120"></GridColumn>
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

### NumericEdit

`NumericEditCellParams` class helps us to customize the default NumericTextBox component in Grid EditForm. The following table describes properties of NumericTextBox control than can be customized using `EditorSettings` of GridColumn editor component.

| Component | Description |
|--------|----------------|
| CssClass | Gets or Sets the CSS classes to root element of the NumericTextBox which helps to customize the complete UI styles for the NumericTextBox component. |
| Decimals | Specifies the number precision applied to the textbox value when the NumericTextBox is focused.|
| EnableRtl | Enable or disable rendering component in right to left direction.|
| Format | Specifies the number format that indicates the display format for the value of the NumericTextBox |
| PlaceHolder | Gets or sets the string shown as a hint/placeholder when the NumericTextBox is empty. It acts as a label and floats above the NumericTextBox |
| ShowClearButton | Specifies whether to show or hide the clear icon. |
| ShowSpinButton | Specifies whether the up and down spin buttons should be displayed in NumericTextBox. |
| ValidateDecimalOnType | Specifies whether the decimals length should be restricted during typing. |

The following sample code demonstrates the customization applied to NumericTextBox component set for the DataGrid columns,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@OrderData" Toolbar=@ToolbarItems>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" EditorSettings="@FreightEditParams" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Center" EditType="EditType.DropDownEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) HeaderText="Verified" EditType="EditType.BooleanEdit" TextAlign="TextAlign.Center" DisplayAsCheckBox="true" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel" };

    public IEditorSettings FreightEditParams = new NumericEditCellParams
    {
        Params = new NumericTextBoxModel<object>() { ShowClearButton= true, ShowSpinButton = false }
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

### DropDownEdit

`DropDownEditCellParams` class helps us to customize the default DropDownList component in Grid EditForm. The following table describes properties of DropDownList control than can be customized using `EditorSettings` of GridColumn editor component.

| Component | Example |
|--------|----------------|
| Enabled | Specifies a value that indicates whether the component is enabled or not |
| CssClass | Sets CSS classes to the root element of the component that allows customization of appearance.  |
| FilterBarPlaceholder | Accepts the value to be displayed as a watermark text on the filter bar.   |
| AllowFiltering | When allowFiltering is set to true, show the filter bar (search box) of the component. |
| FooterTemplate | Accepts the template design and assigns it to the footer container of the popup list. |
| HeaderTemplate | Accepts the template design and assigns it to the header container of the popup list. |
| PopupHeight | Specifies the height of the popup list |
| PopupWidth | Specifies the width of the popup list. By default, the popup width sets based on the width of the component |
| ReadOnly | When set to true, the user interactions on the component are disabled.   |
| ShowClearButton | Specifies whether to show or hide the clear button. When the clear button is clicked, `Value`, `text`, and `index` properties are reset to null.   |
| ValueTemplate | Accepts the template design and assigns it to the selected list item in the input element of the component.  |
| ActionFailureTemplate | Accepts the template and assigns it to the popup list content of the component when the data fetch request from the remote server fails |
| DataSource | Accepts the list items either through local or remote service and binds it to the component. It can be an array of JSON Objects or an instance of `DataManager`. |

> `IEnumerable<TItem>` is the type of [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_DataSource) property in [DropDownListModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html), so you should not bind `string[]` or `List<string>` type to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_DataSource) property.

The following sample code demonstrates the customization applied to DropDownList component set for the DataGrid columns,

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar=@ToolbarItems>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Center" EditType="EditType.DropDownEdit" EditorSettings="@ShipNameEditParams" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) HeaderText="Verified" EditType="EditType.BooleanEdit" TextAlign="TextAlign.Center" DisplayAsCheckBox="true" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel" };

    public IEditorSettings ShipNameEditParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { AllowFiltering = true, ShowClearButton = true }
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

### BooleanEdit

`BooleanEditCellParams` class helps us to customize the default Checkbox component in Grid EditForm. The following table describes properties of CheckBox control than can be customized using `EditorSettings` of GridColumn editor component.

| Component | Description |
|--------|----------------|
| CssClass | Defines class/multiple classes separated by a space in the CheckBox element. You can add custom styles to the CheckBox by using this property. |
| Label | Defines the caption for the CheckBox, that describes the purpose of the CheckBox.  |
| EnableRtl | Enable or disable rendering component in right to left direction.  |
| LabelPosition | Positions label `Before`/`after` the CheckBox. The possible values are: Before - The label is positioned to left of the CheckBox. After - The label is positioned to right of the CheckBox.   |
| Indeterminate | Specifies a value that indicates whether the CheckBox is in `Indeterminate` state or not. When set to `true`, the CheckBox will be in `indeterminate` state.   |
| Disabled | Specifies a value that indicates whether the CheckBox is `Disabled` or not. When set to `true`, the CheckBox will be in `disabled` state. |

The following sample code demonstrates the customization applied to Checkbox component set for the DataGrid columns,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar=@ToolbarItems>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Center" EditType="EditType.DropDownEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) HeaderText="Verified" EditType="EditType.BooleanEdit" TextAlign="TextAlign.Center" DisplayAsCheckBox="true" Width="120" EditorSettings="@VerifiedEditParams"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel" };

    public IEditorSettings VerifiedEditParams = new BooleanEditCellParams
    {
        Params = new CheckBoxModel<bool>() { Label = "Checked", Disabled = true, LabelPosition = LabelPosition.Before  }
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

### DatePickerEdit

`DateEditCellParams` class helps us to customize the default DatePicker and DateTimePicker component in Grid EditForm. The following table describes properties of DatePicker control than can be customized using `EditorSettings` of GridColumn editor component.

| Component | Example |
|--------|----------------|
| CssClass | Specifies the root CSS class of the DatePicker that allows to customize the appearance by overriding the styles.   |
| EnableRtl | Enable or disable rendering component in right to left direction.    |
| ReadOnly | Specifies the component in readonly state. When the Component is readonly it does not allow user input.     |
| ShowClearButton | Specifies whether to show or hide the clear icon in textbox. |

The following sample code demonstrates the customization applied to DatePicker component set for the DataGrid columns,

```cshtml
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar=@ToolbarItems>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="OrderDate" Format="d" EditType="EditType.DatePickerEdit" EditorSettings="@DateEditParams" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Center" EditType="EditType.DropDownEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) HeaderText="Verified" EditType="EditType.BooleanEdit" TextAlign="TextAlign.Center" DisplayAsCheckBox="true" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel" };

    public IEditorSettings DateEditParams = new DateEditCellParams
    {
        Params = new DatePickerModel() { EnableRtl = true, ShowClearButton = false }
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
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public string ShipName { get; set; }
        public bool Verified { get; set; }
    }
}
```

> Similar way customization can be applied to default DateTimePicker Component using same `DateEditCellParams`

## Cell Edit Template

> Before adding edit template to the datagrid, we strongly recommend you to go through the [template](./templates/#templates) section topic to configure the template.

The cell edit template is used to add a custom component for a particular column. You can use the **EditTemplate** of the [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) component to add the custom component. You can access the parameters passed to the templates using implicit parameter named **context**.

> Custom components inside the EditTemplate must be specified with two-way (**@bind-Value**) binding to reflect the changes in DataGrid.

### Using AutoComplete in EditTemplate

You can able to render SfAutoComplete component in EditTemplate. In the below sample we have rendered  **SfAutoComplete** component in **EditTemplate** for Customer ID column.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Grids

<SfGrid AllowPaging="true" DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150">
            <EditTemplate>
                <SfAutoComplete ID="CustomerID" TItem="Order" TValue="string" @bind-Value="@((context as Order).CustomerID)" DataSource="@Orders">
                    <AutoCompleteFieldSettings Value="CustomerID"></AutoCompleteFieldSettings>
                </SfAutoComplete>
            </EditTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" EditType="EditType.NumericEdit" Format="C2" Width="140" TextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
    </GridColumns>
</SfGrid>


@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

In the following image, **Autocomplete** component is rendered with **EditTemplate** in Customer ID column
![Blazor DataGrid with CellEdit Template](./images/blazor-datagrid-celledit-template.png)

### Using DropDownList in EditTemplate

You can able to render SfDropDownList component in EditTemplate. In the below sample we have rendered  **SfDropDownList** component in **EditTemplate** for ShipCountry column.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150">
            <EditTemplate>
                <SfDropDownList ID="ShipCountry" TItem="Country" TValue="string" @bind-Value="@((context as Order).ShipCountry)" DataSource="@Countries">
                    <DropDownListFieldSettings Value="CountryName" Text="CountryName"></DropDownListFieldSettings>
                </SfDropDownList>
            </EditTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
    public List<Country> Countries { get; set; } = new List<Country>()
    {
        new Country(){ CountryName="Brazil", ID=1},
        new Country(){ CountryName="Argentina", ID=2},
        new Country(){ CountryName="Canada", ID=3}
    };
    public class Country
    {
        public string CountryName { get; set; }
        public int ID { get; set; }
    }
}
```

In the following image, **SfDropDownList** component is rendered with **EditTemplate** in ShipCountry column
![Blazor DataGrid with Editing in Custom DropDownList](./images/blazor-datagrid-editing-in-custom-dropdownlist.png)

### Using TimePicker in EditTemplate

You can able to render SfTimePicker component in EditTemplate. In the below sample we have rendered  **SfTimePicker** component in **EditTemplate** for OrderDate column.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" TextAlign="TextAlign.Right" Width="130" Format="hh:mm tt" DefaultValue="DateTime.Now" Type="ColumnType.DateTime">
            <EditTemplate>
                <SfTimePicker TValue="DateTime?" @bind-Value="@((context as Order).OrderDate)"
                              AllowEdit="true" Format="hh:mm:tt" CssClass="CustomDateCSS" ShowClearButton="true"></SfTimePicker>
            </EditTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150">
        </GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

In the following image, **SfTimePicker** component is rendered with **EditTemplate** in OrderDate column
![Blazor DataGrid with Editing in Custom TimePicker](./images/blazor-datagrid-editing-in-custom-timepicker.png)

### Using MultiSelect Dropdown in EditTemplate

You can able to render SfMultiSelect component in EditTemplate. In the below sample we have rendered  **SfMultiSelect** component in **EditTemplate** for ChosenItems column.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Grids

<SfGrid AllowPaging="true" DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="80"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ChosenItems) HeaderText="Chosen Items" Width="150">
            <EditTemplate>
                <SfMultiSelect ID="ChosenItems" @bind-Value="@((context as Order).ChosenItems)" DataSource="@AvailableChoices" TValue="string[]" TItem="MyChoiceItem">
                    <MultiSelectFieldSettings Value="ChosenItems" Text="ChosenItems"></MultiSelectFieldSettings>
                </SfMultiSelect>
            </EditTemplate>
            <Template>
                @{
                    var d = (context as Order).ChosenItems;
                    <span>@String.Join(",", d)</span>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" EditType="EditType.NumericEdit" Format="C2" Width="90" TextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" Type="ColumnType.Date" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    public List<MyChoiceItem> AvailableChoices { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ChosenItems = new string[] { x + "ItemA" },
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
        AvailableChoices = Enumerable.Range(1, 75).Select(x => new MyChoiceItem()
        {
            Id = x,
            ChosenItems = x + "ItemA"
        }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string[] ChosenItems { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
    public class MyChoiceItem
    {
        public int Id { get; set; }
        public string ChosenItems { get; set; }
    }
}
```

In the following image, **SfMultiSelect** component is rendered with **EditTemplate** in ChosenItems column
![Blazor DataGrid with Editing in Custom MultiSelect](./images/blazor-datagrid-editing-in-custom-multiselect.png)

## Command column

The command column provides an option to add CRUD action buttons in a column. This can be defined by using the `GridCommandColumns` component which needs to be wrapped inside the [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) component.

The available built-in command buttons are:

| Command Button | Actions |
|----------------|---------|
| Edit | Edit the current row.|
| Delete | Delete the current row.|
| Save | Update the edited row.|
| Cancel | Cancel the edited state. |

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Height="315">
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

@code{
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

The following screenshot represents the command column.
![Blazor DataGrid with Command Column](./images/blazor-datagrid-command-column.png)

### Custom command

The custom command buttons can be added in a column by using the [Commands](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Commands) property of the [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) component and the action for the custom buttons can be defined in the [CommandClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CommandClicked) event.

The following sample code demonstrates adding custom command in the **Manage Records** column and the `CommandClicked` event which triggers when the command is clicked,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Height="315">
    <GridEvents CommandClicked="OnCommandClicked" TValue="Order"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn HeaderText="Manage Records" Width="150">
            <GridCommandColumns>
                <GridCommandColumn ButtonOption="@(new CommandButtonOptions() { Content = "Details", CssClass = "e-flat" })"></GridCommandColumn>
            </GridCommandColumns>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }

    public void OnCommandClicked(CommandClickEventArgs<Order> args)
    {
        // Perform required operations here
    }
}
```

The following image represents the custom command added in the **Manage Records** column of the DataGrid component,
![Blazor DataGrid with Custom Command](./images/blazor-datagrid-custom-command.png)

## Column validation

Column validation allows you to validate the edited or added row data and it display errors for invalid fields before saving data. DataGrid uses **Form Validator** library for column validation. You can set validation rules by defining the [ValidationRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ValidationRules).

> Validation in datagrid works based on the Microsoft Blazor EditForm behavior. So once the validation message is shown then it will be again validated only during the form submit or when you focus out from that particular field. Please refer the [Microsoft Validation](https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0#data-annotations-validator-component-and-custom-validation) for further reference.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required= true })" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120" ValidationRules="@(new ValidationRules{ Required= true, MinLength = 3 })"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following screenshot represents the Column Validation in Normal Editing.
![Blazor DataGrid with Validation in Editing](./images/blazor-datagrid-validation-in-editing.png)

### Data Annotation

Data Annotation validation attributes are used to validate the fields in the DataGrid. The validation attributes that are supported in the DataGrid are listed below.

| Attribute Name | Functionality |
|-------|---------|
| Validations are,<br><br>1. RequiredAttribute<br>2. StringLengthAttribute<br>3. RangeAttribute<br>4. RegularExpressionAttribute<br>5. MinLengthAttribute<br>6. MaxLengthAttribute<br>7. EmailAddressAttribute<br>8. CompareAttribute<br>9. DataTypeAttribute<br>10.  DataType.Custom<br>11. DataType.Date<br>12. DataType.DateTime<br>13. DataType.EmailAddress<br>14. DataType.ImageUrl<br>15. DataType.Url | The data annotation validation attributes are used as `validation rules` in the DataGrid CRUD operations |

More information on the data annotation can be found in this [documentation](https://blazor.syncfusion.com/documentation/datagrid/data-annotation/) section.

### Custom Validation

Custom Validation allows the users to customize the validations manually according to the user's criteria.

Custom Validation can be used by overriding the IsValid method inside the class inherits the Validation Attribute. All the validations are done inside the IsValid method.

The following sample code demonstrates custom validations implemented in the fields EmployeeID and Freight.

```cshtml
@using Syncfusion.Blazor.Grids;
@using System.ComponentModel.DataAnnotations;
@using System.Text.RegularExpressions;

<SfGrid DataSource="EmployeeList" AllowPaging="true" Toolbar="toolbar">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(EmployeeDetails.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" > </GridColumn>
        <GridColumn Field="@nameof(EmployeeDetails.CustomerName)" HeaderText="Customer Name" TextAlign="TextAlign.Left"> </GridColumn>
        <GridColumn Field="@nameof(EmployeeDetails.EmployeeID)" HeaderText="Employee ID" TextAlign="TextAlign.Right"> </GridColumn>
        <GridColumn Field="@nameof(EmployeeDetails.Freight)" HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2"> </GridColumn>
        <GridColumn Field="@nameof(EmployeeDetails.ShipCity)" HeaderText="Ship City" TextAlign="TextAlign.Left"> </GridColumn>
        <GridColumn Field="@nameof(EmployeeDetails.ShipName)" HeaderText="Ship Name" TextAlign="TextAlign.Left"> </GridColumn>
    </GridColumns>
</SfGrid>

@code
{
    List<EmployeeDetails> EmployeeList;
    string[] toolbar = new string[] { "Add", "Edit", "Delete", "Update", "Cancel" };
    protected override void OnInitialized()
    {
        base.OnInitialized();
        EmployeeList = Enumerable.Range(1, 20).Select(x => new EmployeeDetails()
        {
            OrderID = 10240 + x,
            CustomerName = new string[] { "VINET", "TOSMP", "HANAR", "VICTE" }[new Random().Next(4)],
            EmployeeID = x,
            Freight = new float[] { 32.28f, 22.90f, 30.99f, 50.52f }[new Random().Next(4)],
            ShipCity = new string[] { "Reims", "Munster", "Rio de Janeir", "Lyon" }[new Random().Next(4)],
            ShipName = new string[] { "Vins et alocools chevalie", "Toms Spezialitaten", "Hanari Carnes", "Supremes delices" }[new Random().Next(4)]
        }).ToList();
    }
    public class EmployeeDetails
    {
        [Required]
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        [CustomValidationEmployeeID]
        public int EmployeeID { get; set; }
        [CustomValidationFreight]
        public float Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
    public class CustomValidationEmployeeID : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int employeeID = Convert.ToInt16(value);
                if (employeeID >= 1)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Employee ID value should be greater than zero");
                }
            }
            else
            {
                return new ValidationResult("Employee ID value is required");
            }
        }
    }
    public class CustomValidationFreight : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                float freight = (float)value;
                if (freight >= 1 && freight <= 10000)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Freight value should between 1 and 10,000");
                }
            }
            else
            {
                return new ValidationResult("Freight value  is required");
            }
        }
    }
}
```

### Custom validator component

Apart from using default validation and custom validation, there are cases where you might want to use your validator component to validate the grid edit form. Such cases can be achieved using the **Validator** property of the **GridEditSettings** component which accepts a validation component and inject it inside the **EditForm** of the grid. Inside the **Validator**, you can access the data using the implicit named parameter context which is of type [ValidatorTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ValidatorTemplateContext.html).

For creating a form validator component you can refer [here](https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0#validator-components).

In the below code example, the following things have been done.

* Created a form validator component named `MyCustomValidator` which accepts [ValidatorTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ValidatorTemplateContext.html) value as parameter.
* Used the `MyCustomValidator` component inside the **Validator** property.
* This validator component will check whether Freight value is in between 0 to 100.
* Displayed the validation error messages using **ValidationMessage** component.

```csharp
[MyCustomValidator.cs]

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using Syncfusion.Blazor.Grids;

    public class MyCustomValidator : ComponentBase
    {
        [Parameter]
        public ValidatorTemplateContext context { get; set; }

        private ValidationMessageStore messageStore;

        [CascadingParameter]
        private EditContext CurrentEditContext { get; set; }

        protected override void OnInitialized()
        {
            messageStore = new ValidationMessageStore(CurrentEditContext);

            CurrentEditContext.OnValidationRequested += ValidateRequested;
            CurrentEditContext.OnFieldChanged += ValidateField;
        }

        protected void HandleValidation(FieldIdentifier identifier)
        {
            if (identifier.FieldName.Equals("Freight"))
            {
                messageStore.Clear(identifier);
                if ((context.Data as OrdersDetails).Freight < 0)
                {
                    messageStore.Add(identifier, "Freight value should be greater than 0");
                }
                else if ((context.Data as OrdersDetails).Freight > 100)
                {
                    messageStore.Add(identifier, "Freight value should be lesser than 100");
                }
                else
                {
                    messageStore.Clear(identifier);
                }
            }
        }

        protected void ValidateField(object editContext, FieldChangedEventArgs fieldChangedEventArgs)
        {
            HandleValidation(fieldChangedEventArgs.FieldIdentifier);
        }

        private void ValidateRequested(object editContext, ValidationRequestedEventArgs validationEventArgs)
        {
            HandleValidation(CurrentEditContext.Field("Field"));
        }

    }
```

```csharp
[Index.razor]

<SfGrid TValue="OrdersDetails" DataSource="GridData"
        Toolbar="@(new List<string>() { "Add", "Edit", "Update", "Cancel" })">
        <GridEditSettings AllowAdding="true" AllowEditing="true" Mode="EditMode.Dialog">
            <Validator>
                @{
                    ValidatorTemplateContext txt = context as ValidatorTemplateContext;
                }
                <MyCustomValidator context="@txt"></MyCustomValidator>

                <ValidationMessage For="@(() => (txt.Data as OrdersDetails).Freight)"></ValidationMessage>

            </Validator>
        </GridEditSettings>
        <GridColumns>
            <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true"></GridColumn>
            <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
@code{

    private List<OrdersDetails> GridData;

    protected override void OnInitialized()
    {
        Random r = new Random();
        GridData = Enumerable.Range(1, 10).Select(x => new OrdersDetails()
        {
            OrderID = x,
            Freight = 32.45 * x
        }).ToList();
    }
}
```

The output will be as follows.

![Blazor DataGrid with Custom Validator in Editing](./images/blazor-datagrid-custom-validator-in-editing.png)

#### Display validation message using in-built tooltip

In the above code example, you can see that **ValidationMessage** component is used, this might be not suitable when using Inline editing or batch editing. In such cases, you can use the in-built validation tooltip to show those error messages by using `ValidatorTemplateContext.ShowValidationMessage(fieldName, IsValid, Message)` method.

Now the HandleValidation method of the MyCustomValidator component would be changed like below.

```csharp

        protected void HandleValidation(FieldIdentifier identifier)
        {
            if (identifier.FieldName.Equals("Freight"))
            {
                messageStore.Clear(identifier);
                if ((context.Data as OrdersDetails).Freight < 0)
                {
                    messageStore.Add(identifier, "Freight value should be greater than 0");
                    context.ShowValidationMessage("Freight", false, "Freight value should be greater than 0");
                }
                else if ((context.Data as OrdersDetails).Freight > 100)
                {
                    messageStore.Add(identifier, "Freight value should be lesser than 100");
                    context.ShowValidationMessage("Freight", false, "Freight value should be lesser than 100");
                }
                else
                {
                    messageStore.Clear(identifier);
                    context.ShowValidationMessage("Freight", true, null);
                }
            }
        }

```

The output will be as follows.

![Blazor DataGrid with Custom Validator in Editing](./images/blazor-datagrid-custom-validator.png)

#### Disable in-built validator component

**Validator** property can also be used to disable the in-built validator component used by the grid. For instance, by default, the grid uses two validator components, **DataAnnotationValidator** and an internal [ValidationRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ValidationRules) property handling validator, for handling edit form validation. If you are willing to use only the **DataAnnotationValidator** component, then it could be simply achieved by using the below code.

```cshtml
<SfGrid TValue="OrdersDetails" DataSource="GridData"
        Toolbar="@(new List<string>() { "Add", "Edit", "Update", "Cancel" })">
        <GridEditSettings AllowAdding="true" AllowEditing="true" Mode="EditMode.Dialog">
            <Validator>
               <DataAnnotationsValidator></DataAnnotationsValidator>
            </Validator>
        </GridEditSettings>
        <GridColumns>
            <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true"></GridColumn>
            <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
@code{

    private List<OrdersDetails> GridData;

    protected override void OnInitialized()
    {
        Random r = new Random();
        GridData = Enumerable.Range(1, 10).Select(x => new OrdersDetails()
        {
            OrderID = x,
            Freight = 32.45 * x
        }).ToList();
    }
}
```

## Provide new item or edited item using events

Grid uses `Activator.CreateInstance<TValue>()` to create or clone new record instance during add and edit operations, so it is must to have parameterless constructor defined for the model class.

There are cases where custom logic is required for creating new object or new object instance cannot be created using  `Activator.CreateInstance<TValue>()`. In such cases you can provide model object instance manually using events.

### Normal or Dialog editing

You can use OnActionBegin event to provide new object instance during editing operation. The new object should be assigned to the `OnActionBegin<TValue>.Data` property.

In the following example:

* A model class with no parameter-less constructor is bound with the grid.
* Enabled inline editing feature in grid.
* `OnActionBegin` event callback is assigned in which `Data` property is assigned with custom object for both add and edit operation.

```csharp

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowEditing="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
    <GridEvents TValue="Order" OnActionBegin="ActionBegin"></GridEvents>
</SfGrid>

@code {

    List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order(1000 + x)
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI",
                "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x,
            OrderDate = (new DateTime[] { new DateTime(2019, 01, 01), new DateTime(2019, 01, 02) })[new Random().Next(2)]
        }).ToList();
    }

    public void ActionBegin(ActionEventArgs<Order> arg)
    {
        //Handles add operation
        if (arg.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Add))
        {
            arg.Data = new Order(0) { CustomerID = "Customer ID" };
        }

        //Handles edit operation. During edit operation, original object will be cloned.
        if (arg.RequestType.Equals(Syncfusion.Blazor.Grids.Action.BeginEdit))
        {
            arg.Data = new Order(arg.RowData.OrderID)
            {
                CustomerID = arg.RowData.CustomerID,
                Freight = arg.RowData.Freight,
                OrderDate = arg.RowData.OrderDate
            };
        }
    }

    // This class does not contain any parameter-less constructor, hence this cannot be instantiated using Activator.CreateInstance.
    public class Order
    {
        public Order(int? orderid) => OrderID = orderid;

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

```

### Batch editing

You can use `OnBatchAdd` and `OnCellEdit` event to provide new object instance during add and cell edit operation respectively.

For add operation assign new object to the `OnBatchAdd.DefaultData` property. For cell edit, assign cloned object in the `OnCellEdit.Data` property.

In the following example:

* A model class with no parameter-less constructor is bound with grid.
* Enabled batch editing feature in grid.
* `OnBatchAdd` event callback is assigned in which `DefaultData` property is assigned with custom object for add operation.
* `OnCellEdit` event callback is assigned in which the `Data` property is assigned with a custom object for handling edit operation.

```csharp

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Update", "Cancel" })">
    <GridEditSettings AllowEditing="true" AllowAdding="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
    <GridEvents TValue="Order" OnBatchAdd="BeforeAdd" OnCellEdit="CellEdit"></GridEvents>
</SfGrid>

@code {

    List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order(1000 + x)
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI",
                "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x,
            OrderDate = (new DateTime[] { new DateTime(2019, 01, 01), new DateTime(2019, 01, 02) })[new Random().Next(2)]
        }).ToList();
    }

    public void BeforeAdd(BeforeBatchAddArgs<Order> arg)
    {
        arg.DefaultData = new Order(0) { CustomerID = "Customer ID" };
    }

    public void CellEdit(CellEditArgs<Order> arg)
    {
        //Return args.Data if its not null so previously edited data will not be lost.
        arg.Data = arg.Data ?? new Order(arg.RowData.OrderID)
        {
            CustomerID = arg.RowData.CustomerID,
            Freight = arg.RowData.Freight,
            OrderDate = arg.RowData.OrderDate
        };
    }

    // This class does not contain any parameter-less constructor, hence this cannot be instantiated using Activator.CreateInstance.
    public class Order
    {
        public Order(int orderid) => OrderID = orderid;
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

```

## Entity Framework

This section uses and follows the code explained in the [Entity Framework data binding](./data-binding/#entity-framework) section hence we recommend you to refer Entity framework data binding section before continuing  this section.

### Handle CRUD in data access layer class

Now add methods **AddOrder**, **UpdateOrder**, **DeleteOrder** in the **"OrderDataAccessLayer.cs"** to handle the insert, update and remove operations respectively.**CRUD** record details are bound to the **Order** parameter. Please refer the following code.

```csharp
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFGrid.Shared.Models;

namespace EFGrid.Shared.DataAccess
{
    public class OrderDataAccessLayer
    {
        OrderContext db = new OrderContext();
        public DbSet<Order> GetAllOrders()
        {
            try
            {
                return db.Orders;
            }
            catch
            {
                throw;
            }
        }
        public void AddOrder(Order Order)
        {
            try
            {
                db.Orders.Add(Order);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateOrder(Order Order)
        {
            try
            {
                db.Entry(Order).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteOrder(int id)
        {
            try
            {
                Order ord = db.Orders.Find(id);
                db.Orders.Remove(ord);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
```

### Enable CRUD in Web API

Now you have to create a new **Post**, **Put**, **Delete** method in the Web API controller which will perform the CRUD operations and returns the appropriate resultant data. The **'SfDataManager'** will make requests to this action based on route name.

```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using EFGrid.Shared.DataAccess;
using EFGrid.Shared.Models;

namespace WebApplication1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        OrderDataAccessLayer db = new OrderDataAccessLayer();
        [HttpGet]
        public object Get()
        {

            IQueryable<Order> data = db.GetAllOrders().AsQueryable();
            var count = data.Count();
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$inlinecount"))
            {
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
                return new { Items = data.Skip(skip).Take(top), Count = count };
            }
            else
            {
                return data;
            }
        }
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public void Post([FromBody]Order Order)
        {

            Random rand = new Random();
            db.AddOrder(Order);

        }
        [HttpPut]
        public object Put([FromBody]Order Order)
        {
            db.UpdateOrder(Order);
            return Order;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteOrder(id);
        }
    }
}
```

### Configure the datagrid to perform CRUD operations

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <SfDataManager Url="api/Default" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Normal"></GridEditSettings>
        <GridColumns>
            <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" IsIdentity="true" TextAlign="@Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
            <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="90"></GridColumn>
            <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="90"></GridColumn>
        </GridColumns>
</SfGrid>

@code{
    public class Order {
        public int? OrderID { get; set; }
        public string  CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

>You can find the fully working sample [here](https://github.com/ej2gridsamples/Blazor/blob/master/EntityFramework.zip).

## Perform CRUD operation using Grid Events

IQueryable data can be bound directly to Grid component from database without using Data Adaptors. IQueryable data bound to Grid component using DataSource property of SfGrid. While binding the Data to Grid component using **DataSource** property, CRUD actions needs to be handled using Grid Action Events (i.e.) using **OnActionBegin** and **OnActionComplete** events of Grid.

### Create an interface layer to the Database

Create an interface with CRUD methods like below based on your model class.

```csharp
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Models
{
    interface ILibraryService
    {
        IQueryable<Book> GetBooks();
        void InsertBook(Book employee);
        void UpdateBook(long id, Book employee);
        Book SingleBook(long id);
        void DeleteBook(long id);
    }
}
```

### Create an intermediate service using the interface

By inheriting the interface, create a new service to retrieve the data from database and perform CRUD operation. Refer the below demonstration.

```csharp
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryManagement.Models
{
    public class LibraryService : ILibraryService
    {
        private LibraryContext _context;
        public LibraryService(LibraryContext context)
        {
            _context = context;
        }

        public void DeleteBook(long id)
        {
            try
            {
                Book ord = _context.Books.Find(id);
                _context.Books.Remove(ord);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<Book> GetBooks()
        {
            try
            {
                return _context.Books.AsQueryable();
            }
            catch
            {
                throw;
            }
        }

        public void InsertBook(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateBook(long id, Book book)
        {
            try
            {
                var local = _context.Set<Book>().Local.FirstOrDefault(entry => entry.Id.Equals(book.Id));
                // check if local is not null
                if (local != null)
                {
                    // detach
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Entry(book).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
```

### Configure the DataGrid component to perform CRUD actions using Grid events

Since data is bound to Grid using DataSource property, perform CRUD actions will be reflected at Grid component level only. To reflect the changes in database, we need to handle the changes in Grid action events.

**OnActionBegin** – This event will be triggered when the action gets initiated. So, while inserting/updating a record, **RequestType Save** will be sent in the event arguments to save the changes in the database. Similarly, while deleting a record, RequestType as Delete will be initiated to perform actions externally.  Since for both Update and Insert action, RequestType will be Save, we can differentiate them by using the **Args.Action** property, which will indicate the current action.
**OnActionComplete** – It will be triggered when certain actions are completed. Here, we can refresh the Grid component with an updated datasource to reflect the changes.

```cshtml
@using LibraryManagement.Models
@inject ILibraryService LibraryService

<SfGrid DataSource="@LibraryBooks" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" TValue="Book">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridEvents OnActionBegin="ActionBeginHandler" OnActionComplete="ActionCompleteHandler" TValue="Book"></GridEvents>
    <GridColumns>
        <GridColumn Field="@nameof(Book.Id)" IsPrimaryKey="true" IsIdentity="true" Visible="false"></GridColumn>
        <GridColumn Field="@nameof(Book.Name)" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Book.Author)" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Book.Quantity)" Width="90" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="@nameof(Book.Price)" Width="90" Format="C2" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="@nameof(Book.Available)" DisplayAsCheckBox="true" Width="70"></GridColumn>
    </GridColumns>
</SfGrid>

@code
{
    public IQueryable<Book> LibraryBooks { get; set; }
    protected override void OnInitialized()
    {
        LibraryBooks = LibraryService.GetBooks();
    }
    public void ActionBeginHandler(ActionEventArgs<Book> Args)
    {
        if (Args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
        {
            if (Args.Action == "Add")
            {
                LibraryService.InsertBook(Args.Data);
            }
            else
            {
                LibraryService.UpdateBook(Args.Data.Id, Args.Data);
            }
        }
        if (Args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Delete))
        {
            LibraryService.DeleteBook(Args.Data.Id);
        }
    }
    public void ActionCompleteHandler(ActionEventArgs<Book> Args)
    {
        if (Args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
        {
            LibraryBooks = LibraryService.GetBooks(); //to fetch the updated data from db to Grid
        }
    }
}
```

> Please find the sample from this [Github](https://github.com/SyncfusionExamples/blazor-server-datagrid-efcore-crud/) location.

## Performing CRUD operations programmatically

You can perform CRUD operations like **Add** , **Update** , **Delete** by using the [AddRecord](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AddRecord) , [UpdateRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UpdateRow_System_Double__0_) , [DeleteRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DeleteRow_System_Object_)  methods.

* **AddRecord** - Add a new record into the datagrid
* **UpdateRow** - Update a existing record in a datagrid.
* **DeleteRow** - Delete a selected row in the datagrid

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="Add"> Add </SfButton>
<SfButton @onclick="Update"> Update - 1001 </SfButton>
<SfButton @onclick="Delete"> Delete the selected row </SfButton>

<SfGrid DataSource="@Orders" AllowPaging="true" @ref="Grid" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required = true })" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required = true })" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    SfGrid<Order> Grid;

    public async Task Add()
    {
        Order adddata = new Order()
        {
            OrderID = 1000,
            CustomerID = "MJDGX",
            ShipCountry = "LONDON",
            Freight = 3.01
        };
        await this.Grid.AddRecord(adddata);
    }

    public async Task Update()
    {
        Order data = new Order() { OrderID = 1001, CustomerID = "ABCDE", ShipCountry = "LONDON", Freight = 2.91 };
        await this.Grid.UpdateRow(1, data);
    }

    public async Task Delete()
    {
        await this.Grid.DeleteRecord();
    }

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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

The following GIF represents the datagrid with Add, Update, Delete items,
![CRUD operations in Blazor DataGrid Editing](./images/blazor-datagrid-editing-in-crud-operation.gif)

## Custom external form editing

You can perform the edit operation of Datagrid in a Custom external form. The edit operation can be done by [RowSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowSelected) property.

```csharp

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<div class="row">
    <div class="col-md-6">
        <div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <label for="orderedit">OrderID</label>
                    <input class="form-control" @bind="@(SelectedProduct.OrderID)" type="number" disabled />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <label for="customeredit">CustomerID</label>
                    <SfTextBox ID="CustomerID" @bind-Value="@(SelectedProduct.CustomerID)"></SfTextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <label for="freightedit">Frieght</label>
                    <SfNumericTextBox ID="Freight" TValue="double?" @bind-Value="@SelectedProduct.Freight"></SfNumericTextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <label for="countryedit">ShipCountry</label>
                    <SfDropDownList ID="ShipCountry" @bind-Value="@SelectedProduct.ShipCountry" TItem="Country" TValue="string" DataSource="@Dropdown">
                        <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                    </SfDropDownList>
                </div>
            </div>
        </div>
        <SfButton @onclick="Save">Save</SfButton>
    </div>
    <div class="col-md-6">
        <SfGrid DataSource="@Orders" AllowPaging="true" @ref="Grid" Height=315>
            <GridEditSettings AllowEditing="true"></GridEditSettings>
            <GridEvents RowSelected="RowSelectHandler" TValue="Order"></GridEvents>
            <GridColumns>
                <GridColumn Field=@nameof(Order.OrderID) HeaderText="OrderID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.CustomerID) HeaderText="CustomerID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="ShipCountry" TextAlign="TextAlign.Right" Width="120"></GridColumn>
            </GridColumns>
        </SfGrid>
    </div>
</div>

@code{
    public List<Order> Orders { get; set; }
    SfGrid<Order> Grid;
    public Order SelectedProduct = new Order();
    public class Country
    {
        public string ShipCountry { get; set; }
    }
    List<Country> Dropdown = new List<Country>
{
          new Country() { ShipCountry= "USA" },
          new Country() { ShipCountry= "UK" },
          new Country() { ShipCountry= "RUSSIA" },
          new Country() { ShipCountry= "INDIA" },
          new Country() { ShipCountry= "CHINA" },
    };

    async Task Save()
    {
        await this.Grid.UpdateRow(1, SelectedProduct);
    }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[new Random().Next(5)]
        }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }

    public void RowSelectHandler(RowSelectEventArgs<Order> args)
    {
        SelectedProduct = args.Data;
    }

}

```

The following GIF represent the datagrid with Custom External form editing,
![Blazor DataGrid with Custom External Form Editing](./images/blazor-datagrid-custom-form-editing.gif)

## Dialog template

> Before adding dialog template to the datagrid, we strongly recommend you to go through the [Template](./templates/#templates) section topic to configure the template.

To know about customizing the  **Dialog Template** in Blazor DataGrid Component, you can check this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=Cfj476xT2ao"%}

The dialog template editing provides an option to customize the default behavior of dialog editing. Using the dialog template, you can render your editors by defining the [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component's [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property as **Dialog** and wrapping the HTML elements inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) property of [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html).

> Custom components inside the Dialog Template must be specified with two-way (**@bind-Value**) binding to reflect the changes in DataGrid.

In some cases, you would need to add new field editors in the dialog which are not present in the column model. In that case, the dialog template will help you to customize the default edit dialog.

The following sample code demonstrates DataGrid enabled with dialog template editing,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@GridData" Toolbar="@(new string[] {"Add", "Edit" ,"Delete","Update","Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="@EditMode.Dialog">
        <Template>
            @{
                var Order = (context as OrdersDetails);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Order ID</label>
                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="@((Order.OrderID == null) ? true : false)"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Customer Name</label>
                            <SfAutoComplete ID="customerID" TItem="OrdersDetails" @bind-Value="@(Order.CustomerID)" TValue="string" DataSource="@GridData">
                                <AutoCompleteFieldSettings Value="CustomerID"></AutoCompleteFieldSettings>
                            </SfAutoComplete>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Freight</label>
                            <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double?"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Order Date</label>
                            <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)"></SfDatePicker>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Ship Country</label>
                            <SfDropDownList ID="ShipCountry" @bind-Value="@(Order.ShipCountry)" TItem="OrdersDetails" TValue="string" DataSource="@GridData">
                                <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Ship City</label>
                            <SfDropDownList ID="ShipCity" @bind-Value="@(Order.ShipCity)" TItem="OrdersDetails" TValue="string" DataSource="@GridData">
                                <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <label class="e-float-text e-label-top">Ship Address</label>
                            <SfTextBox ID="ShipAddress" @bind-Value="@(Order.ShipAddress)"></SfTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<OrdersDetails> GridData = new List<OrdersDetails>
{
        new OrdersDetails() { OrderID = 10248, CustomerID = "VINET", Freight = 32.38, ShipCity = "Berlin", OrderDate = DateTime.Now.AddDays(-2), ShipName = "Vins et alcools Chevalier", ShipCountry = "Denmark", ShipAddress = "Kirchgasse 6" },
        new OrdersDetails() { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-5), ShipName = "Toms Spezialitäten", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
        new OrdersDetails() { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83, ShipCity = "Cholchester", OrderDate = DateTime.Now.AddDays(-12), ShipName = "Hanari Carnes", ShipCountry = "Germany", ShipAddress = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo" },
        new OrdersDetails() { OrderID = 10251, CustomerID = "VICTE", Freight = 41.34, ShipCity = "Marseille", OrderDate = DateTime.Now.AddDays(-18), ShipName = "Victuailles en stock", ShipCountry = "Austria", ShipAddress = "Magazinweg 7" },
        new OrdersDetails() { OrderID = 10252, CustomerID = "SUPRD", Freight = 51.3, ShipCity = "Tsawassen", OrderDate = DateTime.Now.AddDays(-22), ShipName = "Suprêmes délices", ShipCountry = "Switzerland", ShipAddress = "1029 - 12th Ave. S." },
        new OrdersDetails() { OrderID = 10253, CustomerID = "HANAR", Freight = 58.17, ShipCity = "Tsawassen", OrderDate = DateTime.Now.AddDays(-26), ShipName = "Hanari Carnes", ShipCountry = "Switzerland", ShipAddress = "1029 - 12th Ave. S." },
        new OrdersDetails() { OrderID = 10254, CustomerID = "CHOPS", Freight = 22.98, ShipCity = "Berlin", OrderDate = DateTime.Now.AddDays(-34), ShipName = "Chop-suey Chinese", ShipCountry = "Denmark", ShipAddress = "Kirchgasse 6" },
        new OrdersDetails() { OrderID = 10255, CustomerID = "RICSU", Freight = 148.33, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-39), ShipName = "Richter Supermarket", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
        new OrdersDetails() { OrderID = 10256, CustomerID = "WELLI", Freight = 13.97, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-43), ShipName = "Wellington Importadora", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
        new OrdersDetails() { OrderID = 10257, CustomerID = "HILAA", Freight = 81.91, ShipCity = "Cholchester", OrderDate = DateTime.Now.AddDays(-48), ShipName = "HILARION-Abastos", ShipCountry = "Germany", ShipAddress = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo" }
    };

    public class OrdersDetails
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
    }
}

<style>
    .form-group.col-md-6 {
        width: 200px;
    }

    label.e-float-text {
        position: relative;
        padding-left: 0;
        top: 10%;
    }
</style>
```

> In the above sample code, the textbox rendered for **OrderID** column inside the dialog template is disabled using its `Enabled` property to prevent editing of the primary key column.

The following image represents the dialog template that is displayed on double-clicking a DataGrid cell,
![Blazor DataGrid with Dialog Edit Template](./images/blazor-datagrid-dialog-edit-template.png)

### Disable components in dialog template

It is possible to disable particular components rendered inside the dialog template using the data source value. This can be achieved by utilizing the `Enabled` property of the components which specifies whether the component is enabled or disabled.

This is demonstrated in the below sample code where if the `RequestType` argument value of the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionBegin) event is **BeginEdit** then the `Enabled` property of the **OrderID** Textbox is set to false.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@GridData" Toolbar="@(new string[] {"Add", "Edit" ,"Delete","Update","Cancel" })">
    <GridEvents OnActionBegin="ActionBeginHandler" TValue="OrdersDetails"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="@EditMode.Dialog">
        <Template>
            @{
                var Order = (context as OrdersDetails);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Order ID</label>
                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="@Enabled"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Customer Name</label>
                            <SfAutoComplete ID="CustomerID" TItem="OrdersDetails" @bind-Value="@(Order.CustomerID)" TValue="string" DataSource="@GridData">
                                <AutoCompleteFieldSettings Value="CustomerID"></AutoCompleteFieldSettings>
                            </SfAutoComplete>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Freight</label>
                            <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Order Date</label>
                            <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)"></SfDatePicker>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Ship Country</label>
                            <SfDropDownList ID="ShipCountry" @bind-Value="@(Order.ShipCountry)" TItem="OrdersDetails" TValue="string" DataSource="@GridData">
                                <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Ship City</label>
                            <SfDropDownList ID="ShipCity" @bind-Value="@(Order.ShipCity)" TItem="OrdersDetails" TValue="string" DataSource="@GridData">
                                <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <label class="e-float-text e-label-top">Ship Address</label>
                            <SfTextBox ID="ShipAddress" @bind-Value="@(Order.ShipAddress)"></SfTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public bool Enabled = true;

    public List<OrdersDetails> GridData = new List<OrdersDetails>
{
        new OrdersDetails() { OrderID = 10248, CustomerID = "VINET", Freight = 32.38, ShipCity = "Berlin", OrderDate = DateTime.Now.AddDays(-2), ShipName = "Vins et alcools Chevalier", ShipCountry = "Denmark", ShipAddress = "Kirchgasse 6" },
        new OrdersDetails() { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-5), ShipName = "Toms Spezialitäten", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
        new OrdersDetails() { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83, ShipCity = "Cholchester", OrderDate = DateTime.Now.AddDays(-12), ShipName = "Hanari Carnes", ShipCountry = "Germany", ShipAddress = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo" },
        new OrdersDetails() { OrderID = 10251, CustomerID = "VICTE", Freight = 41.34, ShipCity = "Marseille", OrderDate = DateTime.Now.AddDays(-18), ShipName = "Victuailles en stock", ShipCountry = "Austria", ShipAddress = "Magazinweg 7" },
        new OrdersDetails() { OrderID = 10252, CustomerID = "SUPRD", Freight = 51.3, ShipCity = "Tsawassen", OrderDate = DateTime.Now.AddDays(-22), ShipName = "Suprêmes délices", ShipCountry = "Switzerland", ShipAddress = "1029 - 12th Ave. S." },
        new OrdersDetails() { OrderID = 10253, CustomerID = "HANAR", Freight = 58.17, ShipCity = "Tsawassen", OrderDate = DateTime.Now.AddDays(-26), ShipName = "Hanari Carnes", ShipCountry = "Switzerland", ShipAddress = "1029 - 12th Ave. S." },
        new OrdersDetails() { OrderID = 10254, CustomerID = "CHOPS", Freight = 22.98, ShipCity = "Berlin", OrderDate = DateTime.Now.AddDays(-34), ShipName = "Chop-suey Chinese", ShipCountry = "Denmark", ShipAddress = "Kirchgasse 6" },
        new OrdersDetails() { OrderID = 10255, CustomerID = "RICSU", Freight = 148.33, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-39), ShipName = "Richter Supermarket", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
        new OrdersDetails() { OrderID = 10256, CustomerID = "WELLI", Freight = 13.97, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-43), ShipName = "Wellington Importadora", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
        new OrdersDetails() { OrderID = 10257, CustomerID = "HILAA", Freight = 81.91, ShipCity = "Cholchester", OrderDate = DateTime.Now.AddDays(-48), ShipName = "HILARION-Abastos", ShipCountry = "Germany", ShipAddress = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo" }
    };

    public class OrdersDetails
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
    }

    public void ActionBeginHandler(ActionEventArgs<OrdersDetails> args)
    {
        if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit)
        {
            // The Textbox component is disabled using its Enabled property
            this.Enabled = false;
        }
        else
        {
            this.Enabled = true;
        }
    }
}

<style>
    .form-group.col-md-6 {
        width: 200px;
    }

    label.e-float-text {
        position: relative;
        padding-left: 0;
        top: 10%;
    }
</style>
```

The following image represents the dialog template of the DataGrid component with disabled components,
![Blazor DataGrid displays Disable components](./images/blazor-datagrid-disable-component.png)

### Set focus to editor

By default, the first input element in the dialog will be focused while opening it. If the first input element is in the a disabled or hidden state, you can set focus to the required input element in the corresponding components **Created** or **DataBound** event.

This is demonstrated in the below sample code where the first input element is in disabled state. So the  **CustomerID** Autocomplete component is focused by invoking its [FocusIn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FocusIn) method in the AutoComplete's [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_DataBound) event.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@GridData" Toolbar="@(new string[] {"Add", "Edit" ,"Delete","Update","Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="@EditMode.Dialog">
        <Template>
            @{
                var Order = (context as OrdersDetails);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Order ID</label>
                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="@((Order.OrderID == null) ? true : false)"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Customer Name</label>
                            <SfAutoComplete ID="customerID" TItem="OrdersDetails" @bind-Value="@(Order.CustomerID)" TValue="string" DataSource="@GridData">
                                <AutoCompleteFieldSettings Value="CustomerID"></AutoCompleteFieldSettings>
                                <AutoCompleteEvents TValue="string" TItem="OrdersDetails" DataBound="FocusAutoComplete"></AutoCompleteEvents>
                            </SfAutoComplete>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Freight</label>
                            <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double?"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Order Date</label>
                            <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)"></SfDatePicker>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Ship Country</label>
                            <SfDropDownList ID="ShipCountry" @bind-Value="@(Order.ShipCountry)" TItem="OrdersDetails" TValue="string" DataSource="@GridData">
                                <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Ship City</label>
                            <SfDropDownList ID="ShipCity" @bind-Value="@(Order.ShipCity)" TItem="OrdersDetails" TValue="string" DataSource="@GridData">
                                <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <label class="e-float-text e-label-top">Ship Address</label>
                            <SfTextBox ID="ShipAddress" @bind-Value="@(Order.ShipAddress)"></SfTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfAutoComplete<string, OrdersDetails> AutoComplete { get; set; }
    public List<OrdersDetails> GridData = new List<OrdersDetails>
    {
    new OrdersDetails() { OrderID = 10248, CustomerID = "VINET", Freight = 32.38, ShipCity = "Berlin", OrderDate = DateTime.Now.AddDays(-2), ShipName = "Vins et alcools Chevalier", ShipCountry = "Denmark", ShipAddress = "Kirchgasse 6" },
    new OrdersDetails() { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-5), ShipName = "Toms Spezialitäten", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
    new OrdersDetails() { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83, ShipCity = "Cholchester", OrderDate = DateTime.Now.AddDays(-12), ShipName = "Hanari Carnes", ShipCountry = "Germany", ShipAddress = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo" },
    new OrdersDetails() { OrderID = 10251, CustomerID = "VICTE", Freight = 41.34, ShipCity = "Marseille", OrderDate = DateTime.Now.AddDays(-18), ShipName = "Victuailles en stock", ShipCountry = "Austria", ShipAddress = "Magazinweg 7" },
    new OrdersDetails() { OrderID = 10252, CustomerID = "SUPRD", Freight = 51.3, ShipCity = "Tsawassen", OrderDate = DateTime.Now.AddDays(-22), ShipName = "Suprêmes délices", ShipCountry = "Switzerland", ShipAddress = "1029 - 12th Ave. S." },
    new OrdersDetails() { OrderID = 10253, CustomerID = "HANAR", Freight = 58.17, ShipCity = "Tsawassen", OrderDate = DateTime.Now.AddDays(-26), ShipName = "Hanari Carnes", ShipCountry = "Switzerland", ShipAddress = "1029 - 12th Ave. S." },
    new OrdersDetails() { OrderID = 10254, CustomerID = "CHOPS", Freight = 22.98, ShipCity = "Berlin", OrderDate = DateTime.Now.AddDays(-34), ShipName = "Chop-suey Chinese", ShipCountry = "Denmark", ShipAddress = "Kirchgasse 6" },
    new OrdersDetails() { OrderID = 10255, CustomerID = "RICSU", Freight = 148.33, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-39), ShipName = "Richter Supermarket", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
    new OrdersDetails() { OrderID = 10256, CustomerID = "WELLI", Freight = 13.97, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-43), ShipName = "Wellington Importadora", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
    new OrdersDetails() { OrderID = 10257, CustomerID = "HILAA", Freight = 81.91, ShipCity = "Cholchester", OrderDate = DateTime.Now.AddDays(-48), ShipName = "HILARION-Abastos", ShipCountry = "Germany", ShipAddress = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo" }
};

    public class OrdersDetails
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
    }
    private async Task FocusAutoComplete() {
        await this.AutoComplete.FocusIn();
    }
}

<style>
    .form-group.col-md-6 {
        width: 200px;
    }

    label.e-float-text {
        position: relative;
        padding-left: 0;
        top: 10%;
    }
</style>
```

The following image represents the AutoComplete component in focused state inside the dialog template of the DataGrid component,
![Blazor DataGrid displays Dynamic Focus of Components](./images/blazor-datagrid-dynamic-focus-component.png)

## Inline Template

> Before adding an Inline template to the DataGrid, we strongly recommend you to go through the [Template](./templates/#templates) section topic to configure the template.

The Inline template editing provides an option to customize the default behavior of Inline editing. Using the Inline template, you can render your editors by defining the [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component's [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property as **Normal** and wrapping the HTML elements inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) property of [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html).

> Custom components inside the Inline Template must be specified with two-way (**@bind-Value**) binding to reflect the changes in DataGrid.

In some cases, you would need to add new field editors in the Inline editing which are not present in the column model. In that case, the Inline template editing will help you to customize the default editing.

The following sample code demonstrates DataGrid enabled with Inline template editing,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@GridData" Toolbar="@(new string[] {"Add", "Edit" ,"Delete","Update","Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="@EditMode.Normal">
        <Template>
            @{
                var Order = (context as OrdersDetails);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Order ID</label>
                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" ShowSpinButton="false" Enabled="@((Order.OrderID == null)? true: false)"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Customer Name</label>
                            <SfAutoComplete ID="CustomerID" TItem="OrdersDetails" FloatLabelType="FloatLabelType.Auto" @bind-Value="@(Order.CustomerID)" TValue="string" DataSource="@GridData">
                                <AutoCompleteFieldSettings Value="CustomerID"></AutoCompleteFieldSettings>
                            </SfAutoComplete>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Freight</label>
                            <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double?"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Order Date</label>
                            <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)"></SfDatePicker>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Ship Country</label>
                            <SfDropDownList ID="ShipCountry" TItem="OrdersDetails" @bind-Value="@(Order.ShipCountry)" TValue="string" DataSource="@GridData">
                                <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Ship City</label>
                            <SfDropDownList ID="ShipCity" TItem="OrdersDetails" @bind-Value="@(Order.ShipCity)" TValue="string" DataSource="@GridData">
                                <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <label class="e-float-text e-label-top">Ship Address</label>
                            <SfTextBox ID="ShipAddress" @bind-Value="@(Order.ShipAddress)"></SfTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<OrdersDetails> GridData = new List<OrdersDetails>
{
        new OrdersDetails() { OrderID = 10248, CustomerID = "VINET", Freight = 32.38, ShipCity = "Berlin", OrderDate = DateTime.Now.AddDays(-2), ShipName = "Vins et alcools Chevalier", ShipCountry = "Denmark", ShipAddress = "Kirchgasse 6" },
        new OrdersDetails() { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-5), ShipName = "Toms Spezialitäten", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
        new OrdersDetails() { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83, ShipCity = "Cholchester", OrderDate = DateTime.Now.AddDays(-12), ShipName = "Hanari Carnes", ShipCountry = "Germany", ShipAddress = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo" },
        new OrdersDetails() { OrderID = 10251, CustomerID = "VICTE", Freight = 41.34, ShipCity = "Marseille", OrderDate = DateTime.Now.AddDays(-18), ShipName = "Victuailles en stock", ShipCountry = "Austria", ShipAddress = "Magazinweg 7" },
        new OrdersDetails() { OrderID = 10252, CustomerID = "SUPRD", Freight = 51.3, ShipCity = "Tsawassen", OrderDate = DateTime.Now.AddDays(-22), ShipName = "Suprêmes délices", ShipCountry = "Switzerland", ShipAddress = "1029 - 12th Ave. S." },
        new OrdersDetails() { OrderID = 10253, CustomerID = "HANAR", Freight = 58.17, ShipCity = "Tsawassen", OrderDate = DateTime.Now.AddDays(-26), ShipName = "Hanari Carnes", ShipCountry = "Switzerland", ShipAddress = "1029 - 12th Ave. S." },
        new OrdersDetails() { OrderID = 10254, CustomerID = "CHOPS", Freight = 22.98, ShipCity = "Berlin", OrderDate = DateTime.Now.AddDays(-34), ShipName = "Chop-suey Chinese", ShipCountry = "Denmark", ShipAddress = "Kirchgasse 6" },
        new OrdersDetails() { OrderID = 10255, CustomerID = "RICSU", Freight = 148.33, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-39), ShipName = "Richter Supermarket", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
        new OrdersDetails() { OrderID = 10256, CustomerID = "WELLI", Freight = 13.97, ShipCity = "Madrid", OrderDate = DateTime.Now.AddDays(-43), ShipName = "Wellington Importadora", ShipCountry = "Brazil", ShipAddress = "Avda. Azteca 123" },
        new OrdersDetails() { OrderID = 10257, CustomerID = "HILAA", Freight = 81.91, ShipCity = "Cholchester", OrderDate = DateTime.Now.AddDays(-48), ShipName = "HILARION-Abastos", ShipCountry = "Germany", ShipAddress = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo" }
    };
    public class OrdersDetails
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
    }
}

<style>
    .form-group.col-md-6 {
        width: 200px;
    }

    label.e-float-text {
        position: relative;
        padding-left: 0;
        top: 10%;
    }
</style>
```

> In the above sample code, the textbox rendered for **OrderID** column inside the Inline editing template is disabled using its `Enabled` property to prevent editing of the primary key column.

## Adding a new row at the bottom of the datagrid

By default, a new row will be added at the top of the datagrid. You can change it by setting [NewRowPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_NewRowPosition) property of the [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component as **Bottom**.

The following sample code demonstrates changing the position of the new row that gets added in the DataGrid component,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" NewRowPosition="NewRowPosition.Bottom"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following image represents the new row added at the bottom of the DataGrid,
![Adding New Row at Bottom Position of Blazor DataGrid](./images/blazor-datagrid-add-new-row.png)

>* In Batch mode while in edit mode, you can add a new row at bottom using the TAB key when you are on the last cell of the last row.

## Confirmation messages

It is possible to display confirmation dialog's on performing deletion or batch operations on the DataGrid records.

### Delete confirmation

The delete confirms dialog can be shown on deleting a record by setting the [ShowDeleteConfirmDialog](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_ShowDeleteConfirmDialog) property of the [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component as **true**.

The following sample code demonstrates enabling delete confirmation dialog in the DataGrid component,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" ShowDeleteConfirmDialog="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following GIF represents the delete confirmation dialog displayed while deleting a record in DataGrid,
![Blazor DataGrid displays Delete Confirmation Dialog](./images/blazor-datagrid-delete-confirm-dialog.gif)

> The [ShowDeleteConfirmDialog](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_ShowDeleteConfirmDialog) supports all type of edit modes.

### Batch confirmation

The confirmation dialog can be enabled for all the batch operations by setting the [ShowConfirmDialog](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_ShowConfirmDialog) property of the [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component as **true**.

The following sample code demonstrates enabling confirmation dialog for batch operations in the DataGrid component,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowPaging="true" AllowSorting="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" ShowConfirmDialog="true" ShowDeleteConfirmDialog="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following GIF represents the confirmation dialog displayed while performing batch operations in DataGrid,
![Blazor DataGrid displays Update Confirmation Dialog](./images/blazor-datagrid-update-confirm-dialog.gif)

> Enabling [ShowConfirmDialog](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_ShowConfirmDialog) requires the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property value of the [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component to be **Batch**.
> If [ShowConfirmDialog](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_ShowConfirmDialog) is set to false, then confirmation dialog will not be displayed on batch editing.

## Default column values on adding new record

The datagrid provides an option to set the default value for the columns when adding a new record in it. To set a default value for a particular column you need to define it in the [DefaultValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_DefaultValue) property of the [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) component.

The following sample code demonstrates setting default value as **ANTON** to the **CustomerID** column,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120" DefaultValue="@("ANTON")"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following image represents the default value displayed in the **CustomerID** column while adding a new record in DataGrid,
![Adding New Record in Default Column Value of Blazor DataGrid](./images/blazor-datagrid-default-column-value.png)

## Disable editing for particular column

You can disable editing for particular columns by setting value as **false** to the [AllowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowEditing) property of the [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) component.

The following sample code demonstrates editing disabled for the **CustomerID** column,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120" AllowEditing="false"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

> Similarly [AllowAdding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowAdding) property at the column level helps us to disable the particular column from inserting value to it.

The following screenshot represents the editing disabled for the **CustomerID** column in DataGrid,
![Disable Editing for Specific Column in Blazor DataGrid](./images/blazor-datagrid-disable-editing.png)

## Troubleshoot: Editing works only for first row

The Editing functionalities can be performed based upon the primary key value of the selected row. If **PrimaryKey** is not defined in the datagrid, then edit or delete action take places in the first row.

## Event trace while editing

While editing operation is getting executed the following events will be notified,

* OnActionBegin
* OnActionComplete

In both these events the type of editing operation is returned in the **RequestType** parameter of the event arguments. In addition to this, the event arguments also return the edited row data.

The **RequestType** values for the editing operations are listed in the below table,

| RequestType | OnActionBegin | OnActionComplete |
|----------|---------------|---------------|
| BeginEdit | Before editing operation begins | After editing operation is completed |
| Add | Before add operation begins | After add operation is completed |
| Delete | Before delete operation begins | After delete operation is completed |
| Save | Before save operation begins | After save operation is completed |
| Cancel | Before cancel operation begins | After cancel operation is completed |

The following sample code demonstrates the different **RequestType** parameters returned while performing editing operations in the OnActionBegin and OnActionComplete event,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridEvents OnActionBegin="ActionBegin" OnActionComplete="ActionComplete" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void ActionBegin(ActionEventArgs<Order> args)
    {
        if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit)
        {
            // Triggers before editing operation starts
        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Add)
        {
            // Triggers before add operation starts
        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Cancel)
        {
            // Triggers before cancel operation starts
        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
        {
            // Triggers before save operation starts
        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
        {
            // Triggers before delete operation starts
        }
    }

    public void ActionComplete(ActionEventArgs<Order> args)
    {
        if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit)
        {
            // Triggers once editing operation completes
        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Add)
        {
            // Triggers once add operation completes
        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Cancel)
        {
            // Triggers once cancel operation completes
        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
        {
            // Triggers once save operation completes
        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
        {
            // Triggers once delete operation completes
        }
    }
}
```

## Customize the edit dialog

You can use [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_HeaderTemplate) and [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_FooterTemplate) of the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component to customize the appearance of edit dialog.

In the below example we have changed the dialog's header text and footer button content for editing and adding records.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <HeaderTemplate>
            @{
                var text = GetHeader((context as Order));
                <span>@text</span>
            }
        </HeaderTemplate>
        <FooterTemplate>
            <SfButton OnClick="@Save" IsPrimary="true">@ButtonText</SfButton>
            <SfButton OnClick="@Cancel">Cancel</SfButton>
        </FooterTemplate>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules { Required = true })" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules { Required = true })" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Order> Grid { get; set; }
    public List<Order> Orders { get; set; }
    public string Header { get; set; }
    public string ButtonText { get; set; }
    public string GetHeader(Order Value)
    {
        if (Value.OrderID == null)
        {
            ButtonText = "Insert";
            return "Insert New Order";
        }
        else
        {
            ButtonText = "Save Changes";
            return "Edit Record Details of " + Value.OrderID.ToString();
        }
    }
    public async Task Cancel()
    {
        await Grid.CloseEdit();     //Cancel editing action
    }
    public async Task Save()
    {
        await Grid.EndEdit();       //Save the edited/added data to Grid
    }
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.

## Perform CRUD operation for complex object using EditTemplate

Before performing CRUD operations with complex Objects, we recommend you to go through the [Complex DataBinding](https://blazor.syncfusion.com/documentation/datagrid/columns/#complex-data-binding) documentation.

To customize the default Grid EditForm TextBox component, we will use [EditTemplate](https://blazor.syncfusion.com/documentation/datagrid/editing/#cell-edit-template) to customize the Grid EditForm.

You can edit the complex objects using EditTemplate inside the GridColumn component by defining two-way (**@bind-Value**) binding to reflect the changes in DataGrid.

For focus and Column Validation to work properly, you have to define the **ID** property EditTemplate components with a value similar to GridColumn Field property value.

> Also ensure to define **ID** property for the complex column as (`___`) replacing the (`.`) operator in the Field value.

The following sample code demonstrates the CRUD operation for complex objects with EditTemplate.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@Employees" Height="315" Toolbar="@(new List<string>() { "Add", "Edit" ,"Delete","Update","Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.CustomerID) HeaderText="CustomerID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="Data.EmployeeID" HeaderText="EmployeeID" ValidationRules="@(new ValidationRules{ Required=true, Number=true, Range = new double[]{1, 2000}})" Width="130">
            <EditTemplate>
                @{
                    <SfNumericTextBox ID="Data___EmployeeID" @bind-Value="@((context as EmployeeData).Data.EmployeeID)"></SfNumericTextBox>

                }
            </EditTemplate>
        </GridColumn>
        <GridColumn Field="Data.FirstName" HeaderText="First Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="150">
            <EditTemplate>
                @{
                    <SfDropDownList ID="Data___FirstName" @bind-Value="@((context as EmployeeData).Data.FirstName)" TItem="EmployeeData" TValue="string" DataSource="@Employees">
                        <DropDownListFieldSettings Value="Data.FirstName" Text="Data.FirstName"></DropDownListFieldSettings>
                        </SfDropDownList>
                        }
                </EditTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
        {
            CustomerID = x,
            Data = new EmployeeName()
            {
                FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
                EmployeeID = 1000 + x
            },
            Title = (new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager",
                                      "Inside Sales Coordinator" })[new Random().Next(4)],
        }).ToList();
    }

    public class EmployeeData
    {
        public int? CustomerID { get; set; }
        public EmployeeName Data { get; set; }
        public string Title { get; set; }
    }

    public class EmployeeName
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
    }
}
```