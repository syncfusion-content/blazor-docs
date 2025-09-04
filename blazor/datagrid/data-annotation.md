---
layout: post
title: Data Annotation in Blazor DataGrid | Syncfusion
description: Learn how to achieve data validation with data annotations in the Syncfusion® Blazor DataGrid component.
platform: Blazor
control: DataGrid
documentation: ug
---

# Data Annotation in Blazor DataGrid

Data Annotations are used to define validation rules for model classes or properties, ensuring that data entered into an application conforms to the expected format and meets specific criteria. They also enable the display of appropriate error messages to end users.

In the Syncfusion Blazor DataGrid, Data Annotations are leveraged to automatically map these validation rules to the corresponding [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) properties. This integration provides seamless data validation during editing operations within the Grid.

To enable Data Annotations for validation in a Grid, you need to refer the **System.ComponentModel.DataAnnotations** namespace in your Blazor application. Once enabled, the Grid automatically uses the data annotations applied to your model class properties to perform data validation.

The following table lists the data annotation attributes supported in the Grid:

| Attribute Name | Properties | Functionality |
|---------------|------------|--------------|
| Display | Name | Sets the header text for the Grid column |
| Display | ShortName | Sets a shorter version of the header text for the Grid column |
| Display | AutoGenerateField | Prevents the column from being auto-generated in the Grid |
| Display | AutoGenerateFilter | Specifies whether filtering should be disabled for the column |
| Display | Description | Sets the tooltip text displayed when hovering over the column ellipsis |
| Display | Order | Defines the display order priority of the Grid column |
| DisplayFormat | FormatString | Sets the format for displaying data in the column |
| DisplayFormat | ApplyFormatInEditMode | Determines whether the format should be applied during edit mode |
| DisplayFormat | NullDisplayText | Sets the text to be displayed when the value of the property is null |
| DisplayFormat | ConvertEmptyStringToNull | Determines whether empty string values should be converted to null in the user interface |
| DisplayFormat | NeedsHtmlEncode | Sets whether HTML encoding should be disabled for a particular column |
| ScaffoldColumnAttribute | Scaffold | Sets whether the column is visible in the user interface |
| EditableAttribute | ReadOnly | Sets whether the column allows editing |
| Key | Key | Marks a column as the primary key in the Grid |
| Validation Attributes:<br><br>1. RequiredAttribute<br>2. StringLengthAttribute<br>3. RangeAttribute<br>4. RegularExpressionAttribute<br>5. MinLengthAttribute<br>6. MaxLengthAttribute<br>7. EmailAddressAttribute<br>8. CompareAttribute<br> | | These validation attributes are used as `validation rules` in Grid CRUD operations |

> The Syncfusion Blazor DataGrid property takes precedence over data annotation attributes. For example, when both the DisplayName attribute and `HeaderText` are assigned to a field in the Grid model class for a specific column, the `HeaderText` value will be prioritized and displayed in the Grid header.

The following sample code demonstrates how to use data annotations in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using System.Reflection
@using System.ComponentModel.DataAnnotations;

<SfGrid TValue="Order" DataSource="@Orders" Height="315" AllowPaging="true" AllowFiltering="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
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
        public string? CustomerID { get; set; }
        // Sets data type of column as Date.
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        // Sets column as read only.
        [Editable(false)]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "Freight", AutoGenerateFilter = false)]
        public double? Freight { get; set; }
        [ScaffoldColumn(scaffold:false)]
        public string ShipCity { get; set; }
        public Status Verified { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthIZotuimdZMRyd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The following image shows how Data Annotations are applied to Grid columns in a Blazor application:

![Data Annotation in Grid](./images/blazor-datagrid-data-annotation.png)

> The **Verified** column displays the `Enum` member using the `Display` attribute name, enhancing user experience by rendering a human-readable label instead of the raw enum value.

> You can refer to our [Syncfusion Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its features. You can also explore our [Syncfusion Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.
