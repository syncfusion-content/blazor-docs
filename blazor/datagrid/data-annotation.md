---
layout: post
title: Data Annotation in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Data Annotation in Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Data Annotation in Blazor DataGrid Component

Data Annotations helps us to define rules to the model classes or properties to perform data validation and display suitable messages to end users.

The Data Annotation can be enabled by referencing the **System.ComponentModel.DataAnnotations** namespace which maps the data annotations to the corresponding DataGrid Column property.

The list of data annotation attributes that are supported in DataGrid component are provided below,

| Attribute Name | Properties | Functionality |
|-------|---------|---------|
| Display | Name	| Sets the header text for the grid column
| Display |	ShortName |	Sets a shorter version of the header text for the grid column
| Display |	AutoGenerateField | Prevents the column from being auto-generated in the grid.
| Display |	AutoGenerateFilter | Sets whether filtering should be disabled for a particular column.
| Display |	Description | Sets the tooltip text displayed when hovering over the ellipsis of the column.
| Display |	Order |	Sets the priority order of the Grid Column
| DisplayFormat | FormatString | Sets the format for displaying data in the column.
| DisplayFormat	| ApplyFormatInEditMode | Determines whether the column format should be applied in edit mode
| DisplayFormat	| NullDisplayText | Sets the text to be displayed when the value of the property is null
| DisplayFormat	| ConvertEmptyStringToNull | Determines whether empty string values should be converted to null in the user interface
| DisplayFormat | NeedsHtmlEncode | Sets whether HTML encoding should be disabled for a particular column.
| ScaffoldColumnAttribute | Scaffold | Sets whether the column is visible in the user interface
| EditableAttribute | ReadOnly | Sets whether the column allows editing |
| Key | Key | This attribute is used to mark a column as the primary key in the data grid |
| Validations are,<br><br>1. RequiredAttribute<br>2. StringLengthAttribute<br>3. RangeAttribute<br>4. RegularExpressionAttribute<br>5. MinLengthAttribute<br>6. MaxLengthAttribute<br>7. EmailAddressAttribute<br>8. CompareAttribute<br>| | The data annotation validation attributes are used as `validation rules` in the DataGrid CRUD operations|

N> The DataGrid Property takes precedence over Data Annotation. For example, when both the DisplayName Attribute and HeaderText are assigned to a Field in the DataGrid Model class for a specific column, the value of the HeaderText property will be prioritized and displayed in the DataGrid header.

The following sample code demonstrates data annotations implemented in the DataGrid component,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using System.Reflection
@using System.ComponentModel.DataAnnotations;

<SfGrid TValue="Order" DataSource="@Orders" Height="315" Width="500" AllowPaging="true" AllowFiltering="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) TextAlign="TextAlign.Right" Width="115"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="115"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) Width="110">
            <EditTemplate>
                @{
                    var Order = (context as Order);
                    <SfDropDownList Placeholder="Type" ID="Type" @bind-Value="@((context as Order).Verified)" DataSource="@DropDownData" TValue="Status" TItem="Data">
                        <DropDownListEvents TItem="Data" TValue="Status"></DropDownListEvents>
                        <DropDownListFieldSettings Value="Value" Text="Type"></DropDownListFieldSettings>
                    </SfDropDownList>
                }
            </EditTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public List<Data> DropDownData = new List<Data>();

    protected override void OnInitialized()
    {
        Random rnd = new Random();
        var values = Enum.GetValues(typeof(Status));
        foreach (Status item in Enum.GetValues(typeof(Status)))
        {
            DropDownData.Add(new Data { Type = GetDisplayName(item), Value = item });
        }
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", string.Empty, null })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
                ShipCity = (new string[] { "Berlin", "Madrid", "Cholchester", "Marseille", "Tsawassen" })[new Random().Next(5)],
                Verified = (Status)(values.GetValue(rnd.Next(values.Length))),
            }).ToList();
    }

    public static string GetDisplayName(Enum enumValue)
    {
        string displayName;
        displayName = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();
        if (String.IsNullOrEmpty(displayName))
        {
            displayName = enumValue.ToString();
        }
        return displayName;
    }
    public enum Status
    {
        [Display(Name = "Yeah")]
        Yes = 0,
        [Display(Name = "Nope")]
        No = 1
    }
    public class Data
    {
        public string Type { get; set; }
        public Status Value { get; set; }
    }

    public class Order
    {
        // Sets column as primary key
        [Key]
        // Sets column as required and error message to be displayed when empty
        [Required(ErrorMessage = "Order ID  should not be empty")]
        // Sets header text to the column
        [Display(ShortName = "ID")]
        public int? OrderID { get; set; }
        [Display(Name = "CustomerID", Description ="List of Customers")]
        // Sets column as required and error message to be displayed when empty
        [Required(ErrorMessage = "Field should not be empty")]
        [DisplayFormat(NullDisplayText = "Empty", ConvertEmptyStringToNull = true)]
        public string? CustomerID { get; set; }
        // Sets data type of column as Date
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        // Sets column as read only
        [Editable(false)]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "Freight", AutoGenerateFilter = false)]
        public double? Freight { get; set; }
        [ScaffoldColumn(scaffold:false)]
        public string ShipCity { get; set; }
        public Status Verified { get; set; }
    }
}
```

The following image represents data annotations enabled in the DataGrid columns,
![Data Annotation in Blazor DataGrid](./images/blazor-datagrid-data-annotation.png)

> Displaying Enum Class Display attribute name in the "Verified" Column, this implementation aims to improve user experience by presenting human-readable text in the grid for Enum values associated with the "Verified" column

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.