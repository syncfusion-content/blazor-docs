---
layout: post
title: Blazor Grid Data Annotation | Syncfusion
description: Learn how to use Data Annotations in Blazor Data Grid for validation, column metadata, display formatting, enum display values, and CRUD form validation.
platform: Blazor
control: DataGrid
documentation: ug
---

# Data annotation in Blazor Data Grid

Data annotations define validation and display rules for model classes or properties in the [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid). These attributes enforce specific formats and constraints on input values and show clear error messages during editing operations.

When the Data Grid is bound to a model, data annotations automatically map to corresponding [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) settings, enabling built-in validation and metadata display during CRUD operations.

To enable data annotation in the Blazor Data Grid:

1. Add the **System.ComponentModel.DataAnnotations** namespace to the Blazor application.
2. Bind the Data Grid to a model using `TValue` and [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource).
3. Apply annotation attributes to model properties to enforce validation and display rules during CRUD operations.

### Supported data annotation attributes

Data annotation attributes control four key aspects of Data Grid column behavior:

- **Display attributes** manage how column headers and metadata appear in the Data Grid interface
- **Format attributes** define how data values are displayed and formatted in cells and edit dialogs
- **Metadata attributes** control column visibility, editing behavior, and primary key identification
- **Validation attributes** enforce data validation rules and display error messages during data entry

The following tables describe each category:

### Display attributes

Use **Display** attributes to control how column headers, ordering, and metadata appear in the Data Grid interface.

| Attribute Name | Properties | Functionality |
|----------------|------------|---------------|
| Display | Name | Sets the header text for the Data Grid column |
| Display | ShortName | Sets a shorter version of the header text |
| Display | AutoGenerateField | Prevents the column from being auto-generated |
| Display | AutoGenerateFilter | Disables filtering for the column |
| Display | Description | Sets tooltip text shown when hovering the column's ellipsis |
| Display | Order | Defines the display order of the column |

N> When the `Display` attribute's `Name` and the column's `HeaderText` property are both defined, the `HeaderText` value takes precedence and is shown in the column header.

### DisplayFormat attributes

Apply **DisplayFormat** attributes when column values require specific formatting or null-handling behavior.

| Attribute Name | Properties | Functionality |
|----------------|------------|---------------|
| DisplayFormat | FormatString | Sets the display format for column data |
| DisplayFormat | ApplyFormatInEditMode | Applies format during edit mode |
| DisplayFormat | NullDisplayText | Displays custom text when the value is null |
| DisplayFormat | ConvertEmptyStringToNull | Converts empty strings to null in the UI |
| DisplayFormat | HtmlEncode | Enables or disables HTML encoding for display |

### Metadata attributes

Metadata attributes control column visibility, editing capabilities, and key identification in the Data Grid.

| Attribute Name | Properties | Functionality |
|----------------|------------|---------------|
| ScaffoldColumnAttribute | Scaffold | Controls column visibility in the UI |
| ReadOnlyAttribute | IsReadOnly | Marks a model property as read-only at the model level. The Blazor Data Grid honors this attribute by rendering the column as read-only during editing. |
| EditableAttribute | AllowEdit | Prevents editing of the column directly on the `GridColumn`. `EditableAttribute` is the Syncfusion-specific attribute used in the Data Grid sample. |
| Key | Key | Marks the column as the primary key. Pair with `IsPrimaryKey="true"` on the `GridColumn` to enable add, edit, and delete operations. |

N> Both `ReadOnlyAttribute` and `EditableAttribute` prevent editing in the Blazor Data Grid. `ReadOnlyAttribute` is a standard .NET data annotation recognized by validation and binding layers, while `EditableAttribute` is a Syncfusion-specific attribute applied directly on the model property to control the column's edit behavior in the Data Grid.

### Validation attributes

Add validation attributes to enforce rules that display inline validation messages in the Blazor Data Grid during CRUD operations.

N> Validation messages appear only in the add and edit forms. Enable CRUD operations by setting `AllowAdding="true"`, `AllowEditing="true"`, and `AllowDeleting="true"` on `GridEditSettings`. The corresponding toolbar items (`Add`, `Edit`, `Delete`, `Update`, `Cancel`) must also be included in the `Toolbar` property so the edit dialog can render the validation errors.

| Attribute Name | Key Parameters | Functionality |
|----------------|----------------|---------------|
| RequiredAttribute | (none) | Marks a property as required and blocks empty values |
| StringLengthAttribute | MaximumLength, MinimumLength | Sets the maximum (and optional minimum) number of characters allowed |
| RangeAttribute | Minimum, Maximum | Restricts numeric values to a minimum and maximum range |
| RegularExpressionAttribute | Pattern | Validates the value against a regular expression pattern |
| MinLengthAttribute | Length | Sets the minimum number of characters or items required |
| MaxLengthAttribute | Length | Sets the maximum number of characters or items allowed |
| EmailAddressAttribute | (none) | Validates that the value matches an email address format |
| CompareAttribute | OtherProperty | Compares the value with another property on the same model |

### Displaying enum values

The `Display` attribute can be used to show user-friendly labels for enum values, improving readability by replacing raw enum values with descriptive names.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using System.Reflection
@using System.ComponentModel.DataAnnotations

<SfGrid TValue="Order" DataSource="@Orders" Height="315" AllowPaging="true" AllowFiltering="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="115"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="115"></GridColumn>
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
                ShipCity = (new string[] { "Berlin", "Madrid", "Colchester", "Marseille", "Tsawassen" })[Rnd.Next(5)],
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
        // Provides a compact label (ShortName) for the column header.
        [Display(ShortName = "ID")]
        public int OrderID { get; set; }

        // Sets the header text and description for the column.
        [Display(Name = "CustomerID", Description ="List of Customers")]
        // Sets column as required and error message to be displayed when empty.
        [Required(ErrorMessage = "Field should not be empty")]
        // Displays custom text for null values and converts empty strings to null.
        [DisplayFormat(NullDisplayText = "Empty", ConvertEmptyStringToNull = true)]
        public string CustomerID { get; set; }

        // Specifies the data type as Date for formatting and editor selection.
        [DataType(DataType.Date)]
        // Sets the header text for the column.
        [Display(Name = "Order Date")]
        // Sets column as read only.
        [Editable(false)]
        public DateTime? OrderDate { get; set; }

        // Sets the header text and disables filtering for the column.
        [Display(Name = "Freight", AutoGenerateFilter = false)]
        public double? Freight { get; set; }

        // Hides the column from the Data Grid UI.
        [ScaffoldColumn(false)]
        public string ShipCity { get; set; }

        public Status Verified { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

The following image shows how Data Annotations are applied to Data Grid columns in a Blazor application:

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZrRXQDrLszxRyQn?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Data Annotation in Grid](./images/blazor-datagrid-data-annotation.webp)" %}

N> The `EditType` property on each `GridColumn` controls which editor renders during editing (for example, `DataType.Date` maps to a date picker by default). For the full list of available editors and how to map a `DataType` to a specific `EditType`, see [Edit Types in Blazor Data Grid](edit-types).


N> Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour for an overview of available features. Explore the [Blazor Data Grid documentation](https://help.syncfusion.com/blazor/datagrid/getting-started) for more information about data binding and configuration options.