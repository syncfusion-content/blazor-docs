---
layout: post
title: Data Annotation in Blazor DataGrid | Syncfusion
description: Learn how to use Data Annotations for validation and column metadata in Syncfusion Blazor DataGrid, including enum display and CRUD form validation.
platform: Blazor
control: DataGrid
documentation: ug
---

# Data Annotation in Blazor DataGrid

Data annotations apply validation and display rules to model classes or properties in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, ensuring input values meet defined formats and constraints while providing clear error messages. 

When bound to a model, data annotations automatically map to corresponding [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) behaviors, enabling built-in validation during editing operations.

To enable data annotation-based validation, include the `System.ComponentModel.DataAnnotations` namespace in the Blazor application. Bind the DataGrid to a model using `TValue` and [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) to apply attributes during `CRUD` operations.

The table lists the data annotation attributes supported in the DataGrid:

| Attribute Name | Properties | Functionality |
|---------------|------------|--------------|
| Display | Name | Sets the header text for the DataGrid column |
| Display | ShortName | Sets a shorter version of the header text for the DataGrid column |
| Display | AutoGenerateField | Prevents the column from being auto-generated in the DataGrid |
| Display | AutoGenerateFilter | Specifies whether filtering should be disabled for the column |
| Display | Description | Sets the tooltip text displayed when hovering over the column ellipsis |
| Display | Order | Defines the display order priority of the DataGrid column |
| DisplayFormat | FormatString | Sets the format for displaying data in the column |
| DisplayFormat | ApplyFormatInEditMode | Determines whether the format should be applied during edit mode |
| DisplayFormat | NullDisplayText | Sets the text to be displayed when the value of the property is null |
| DisplayFormat | ConvertEmptyStringToNull | Determines whether empty string values should be converted to null in the user interface |
| DisplayFormat | HtmlEncode | Controls whether HTML encoding is applied when displaying the field |
| ScaffoldColumnAttribute | Scaffold | Sets whether the column is visible in the user interface |
| ReadOnlyAttribute | IsReadOnly | Sets whether the column allows editing |
| Key | Key | Marks a column as the primary key in the DataGrid |
| Validation Attributes:<br><br>1. RequiredAttribute<br>2. StringLengthAttribute<br>3. RangeAttribute<br>4. RegularExpressionAttribute<br>5. MinLengthAttribute<br>6. MaxLengthAttribute<br>7. EmailAddressAttribute<br>8. CompareAttribute<br> | | These validation attributes are used as validation rules in DataGrid CRUD operations |

> DataGrid column properties override data annotation attributes in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. For instance, if both the `Display` attribute’s `Name` and the `HeaderText` property are set for a column, the `HeaderText` value takes precedence and is displayed in the column header.

The sample demonstrates how to use data annotations in the DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using System.Reflection
@using System.ComponentModel.DataAnnotations

<SfGrid TValue="Order" DataSource="@Orders" Height="315" AllowPaging="true" AllowFiltering="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="115"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) EditType="Syncfusion.Blazor.Grids.EditType.DatePickerEdit" Format="d" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130" Type="Syncfusion.Blazor.Grids.ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Format="C2" Width="115"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) Width="110">
            <EditTemplate>
                @{
                    var CurrentOrder = (context as Order);
                    <SfDropDownList Placeholder="Type" ID="Type" @bind-Value="CurrentOrder.Verified" DataSource="@DropDownData" TValue="Status" TItem="Data">
                        <DropDownListFieldSettings Value="Value" Text="Type"></DropDownListFieldSettings>
                    </SfDropDownList>
                }
            </EditTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private List<Order> Orders { get; set; }
    private List<Data> DropDownData { get; } = new();

    protected override void OnInitialized()
    {
        var Rnd = new Random();
        var Values = Enum.GetValues(typeof(Status));

        foreach (Status Item in Values)
        {
            DropDownData.Add(new Data { Type = GetDisplayName(Item), Value = Item });
        }

        Orders = Enumerable.Range(1, 75).Select(x => new Order
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", string.Empty, null })[Rnd.Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
                ShipCity = (new string[] { "Berlin", "Madrid", "Cholchester", "Marseille", "Tsawassen" })[Rnd.Next(5)],
                Verified = (Status)Values.GetValue(Rnd.Next(Values.Length)),
            }).ToList();
    }

    private static string GetDisplayName(Enum EnumValue)
    {
        var DisplayName = EnumValue.GetType()
            .GetMember(EnumValue.ToString())
            .FirstOrDefault()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();

        if (string.IsNullOrEmpty(DisplayName))
        {
            DisplayName = EnumValue.ToString();
        }
        return DisplayName;
    }

    internal enum Status
    {
        [Display(Name = "Yeah")]
        Yes = 0,
        [Display(Name = "Nope")]
        No = 1
    }

    internal sealed class Data
    {
        public string Type { get; set; }
        public Status Value { get; set; }
    }

    internal sealed class Order
    {
        // Sets column as primary key.
        [Key]
        // Sets column as required and error message to be displayed when empty.
        [Required(ErrorMessage = "Order ID should not be empty")]
        // Sets header text to the column.
        [Display(ShortName = "ID")]
        public int OrderID { get; set; }

        [Display(Name = "CustomerID", Description ="List of Customers")]
        // Sets column as required and error message to be displayed when empty.
        [Required(ErrorMessage = "Field should not be empty")]
        [DisplayFormat(NullDisplayText = "Empty", ConvertEmptyStringToNull = true)]
        public string CustomerID { get; set; }

        // Sets data type of column as Date.
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        // Sets column as read only.
        [Editable(false)]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Freight", AutoGenerateFilter = false)]
        public double? Freight { get; set; }

        [ScaffoldColumn(false)]
        public string ShipCity { get; set; }

        public Status Verified { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLIijigsHQsZoWd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The image shows how data annotations are applied to DataGrid columns in a Blazor application:

![Data annotations in DataGrid](./images/blazor-datagrid-data-annotation.png)

> The `Verified` column displays the enum member using the `Display` attribute name, improving readability by showing a user-friendly label instead of the raw enum value.

N> Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour for a broad overview. Explore the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand data presentation and manipulation.