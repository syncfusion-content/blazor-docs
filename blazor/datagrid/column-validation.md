---
layout: post
title: Column Validation in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Column Validation in Syncfusion Blazor DataGrid  and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Validation in Blazor DataGrid

Validation is a crucial aspect of data integrity in any application. The Syncfusion Blazor DataGrid provides built-in support for easy and effective data validation. This feature ensures that the data entered or modified adheres to predefined rules, preventing errors and guaranteeing the accuracy of the displayed information.

## Column validation

Column validation allows you to validate edited or newly added row data before saving it. This feature is particularly useful when you need to enforce specific rules or constraints on individual columns to ensure data integrity. By applying validation rules to columns, you can display error messages for invalid fields and prevent the saving of erroneous data. This feature leverages the **Form Validator** library to perform validation. You can define validation rules using the [GridColumn.ValidationRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ValidationRules) property to specify the criteria for validating column values.

> Validation in Grid works based on the Microsoft Blazor EditForm behavior. Once a validation message is shown, it will be validated again only during form submission or when you focus out from that particular field. Refer to the [Microsoft Validation](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-5.0#data-annotations-validator-component-and-custom-validation) documentation for further reference.

The following code example demonstrates how to define a validation rule for a Grid column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true, Min=1})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=3})" Width="120"></GridColumn>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVyjCrhrHDetIYc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Data annotation

Data annotation validation attributes are used to validate fields in the DataGrid. The following validation attributes are supported in the Grid:

| Attribute Name | Functionality |
|---------------|--------------|
| 1. RequiredAttribute<br>2. StringLengthAttribute<br>3. RangeAttribute<br>4. RegularExpressionAttribute<br>5. MinLengthAttribute<br>6. MaxLengthAttribute<br>7. EmailAddressAttribute<br>8. CompareAttribute<br>9. DataTypeAttribute<br>10. DataType.Custom<br>11. DataType.Date<br>12. DataType.DateTime<br>13. DataType.EmailAddress<br>14. DataType.ImageUrl<br>15. DataType.Url | These data annotation validation attributes are used as `validation rules` in DataGrid CRUD operations. |

For more information on data annotation, refer to this [documentation](https://blazor.syncfusion.com/documentation/datagrid/data-annotation) section.

## Custom validation

Custom validation allows users to define their own validation logic based on specific requirements.

To implement custom validation, create a class that inherits from the `ValidationAttribute` class and override the `IsValid` method. All custom validation logic should be placed inside the `IsValid` method.

The following sample code demonstrates how to implement custom validation for the **EmployeeID** and **Freight** fields.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids;

<SfGrid DataSource="OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" ></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name"> </GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
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
    public OrderDetails(int OrderID, string CustomerID, double Freight, string ShipCountry, int EmployeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = EmployeeID;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", 5));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", 6));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", 4));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", 3));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", 4));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", 3));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", 5));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", 9));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", 3));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", 4));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", 1));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", 4));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", 4));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", 4));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", 8));
        }
        return Order;
    }
    [Required]
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    [CustomValidationFreight]
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    [CustomValidationEmployeeID]
    public int EmployeeID { get; set; }
}

public class CustomValidationEmployeeID : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            int EmployeeIdValue = Convert.ToInt32(value);
            if (EmployeeIdValue >= 1)
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
            double FreightValue = Convert.ToDouble(value);
            if (FreightValue >= 1 && FreightValue <= 10000)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Freight value should be between 1 and 10,000");
            }
        }
        else
        {
            return new ValidationResult("Freight value is required");
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrojMBhUyZJfcXd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Validate complex column using data annotation attribute

You can validate complex data binding columns by using the [ValidateComplexType](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-5.0#data-annotations-validator-component-and-custom-validation) attribute from data annotations.

In the following sample, the `ValidateComplexType` attribute is applied to the `EmployeeName` class to enable validation of its properties. A custom validation message is displayed in the "First Name" column by using the `RequiredAttribute` with a custom error message.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@EmployeeData" Height="315" AllowSorting=true Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="EmployeeID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="EmpDetails.FirstName" HeaderText="First Name" Width="150"></GridColumn>
        <GridColumn Field="EmpDetails.LastName" HeaderText="Last Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Title) HeaderText="Title" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<EmployeeDetails> EmployeeData { get; set; }
    protected override void OnInitialized()
    {
        EmployeeData = EmployeeDetails.GetAllRecords();
    } 
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}
using System.ComponentModel.DataAnnotations;

public class EmployeeDetails
{
    public static List<EmployeeDetails> Employees = new List<EmployeeDetails>();
    public EmployeeDetails(int employeeID, string firstName, string lastName, string title)
    {
        EmployeeID = employeeID;
        EmpDetails = new EmployeeInfo
        {
            FirstName = firstName,
            LastName = lastName
        };
        Title = title;
    }
    public static List<EmployeeDetails> GetAllRecords()
    {
        if (Employees.Count == 0)
        {
            Employees.Add(new EmployeeDetails(1, "Nancy", "Davolio", "Sales Representative"));
            Employees.Add(new EmployeeDetails(2, "Andrew", "Fuller", "Vice President, Sales"));
            Employees.Add(new EmployeeDetails(3, "Janet", "Leverling", "Sales Representative"));
            Employees.Add(new EmployeeDetails(4, "Margaret", "Peacock", "Sales Representative"));
            Employees.Add(new EmployeeDetails(5, "Steven", "Buchanan", "Sales Manager"));
            Employees.Add(new EmployeeDetails(6, "Michael", "Suyama", "Sales Representative"));
            Employees.Add(new EmployeeDetails(7, "Robert", "King", "Sales Representative"));
            Employees.Add(new EmployeeDetails(8, "Laura", "Callahan", "Inside Sales Coordinator"));
            Employees.Add(new EmployeeDetails(9, "Anne", "Dodsworth", "Sales Representative"));
        }
        return Employees;
    }
    [Required]
    public int EmployeeID { get; set; }
    [ValidateComplexType]
    public EmployeeInfo EmpDetails { get; set; }
    public string Title { get; set; }
}
public class EmployeeInfo
{
    [Required(ErrorMessage = "First name should not be empty")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
{% endhighlight %}
{% endtabs %}

> Ensure to include the package **Microsoft.AspNetCore.Components.DataAnnotations.Validation** for complex type validation using the following reference: 
`<PackageReference Include="Microsoft.AspNetCore.Components.DataAnnotations.Validation" Version="3.2.0-rc1.20223.4" />`

![Validate Complex Column Using Data Annotation Attribute in Blazor DataGrid.](images/blazor-datagrid-validate-complex-column-using-data-annotation-attribute.gif)

## Custom validator component

In addition to using the default and custom validation options, there may be scenarios where you want to implement your own validator component to validate the Grid edit form. This can be accomplished by using the **Validator** property of the **GridEditSettings** component, which accepts a validation component and injects it inside the **EditForm** of the Grid. Within the **Validator**, you can access the data using the implicit parameter `context`, which is of type [ValidatorTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ValidatorTemplateContext.html).

For guidance on creating a form validator component, refer to the [official documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms-and-input-components?view=aspnetcore-5.0#validator-components).

In the following code example:

* A form validator component named `MyCustomValidator` is created, which accepts a [ValidatorTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ValidatorTemplateContext.html) value as a parameter.
* The `MyCustomValidator` component is used inside the **Validator** property.
* This validator component checks whether the Freight value is between 0 and 100.
* Validation error messages are displayed using the **ValidationMessage** component.

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
        HandleValidation(CurrentEditContext.Field("Freight"));
    }
}
```

```csharp
[Index.razor]

<SfGrid TValue="OrdersDetails" DataSource="GridData" Toolbar="@(new List<string>() { "Add", "Edit", "Update", "Cancel" })">
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

![Blazor DataGrid with Custom Validator in Editing.](images/blazor-datagrid-custom-validator-in-editing.png)

## Display validation message using in-built tooltip

In the above code example, the **ValidationMessage** component is used. However, this approach may not be suitable when using Inline editing or Batch editing modes. In such cases, you can use the built-in validation tooltip to display error messages by calling the `ValidatorTemplateContext.ShowValidationMessage(fieldName, isValid, message)` method.

The `HandleValidation` method of the `MyCustomValidator` component can be updated as shown below.

```c#
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

![Blazor DataGrid with Custom Validator in Editing.](images/blazor-datagrid-custom-validator.png)

## Disable in-built validator component

The **Validator** property can also be used to disable the built-in validator component used by the Syncfusion Blazor DataGrid. By default, the Grid uses two validator components: **DataAnnotationsValidator** and an internal validator that handles the [ValidationRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ValidationRules) property for edit form validation. If you want to use only the **DataAnnotationsValidator** component, you can achieve this by using the following code.

```c#
<SfGrid TValue="OrdersDetails" DataSource="GridData" Toolbar="@(new List<string>() { "Add", "Edit", "Update", "Cancel" })">
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

## Display validation message in dialog template

Use form validation to display a validation message for a field that is not defined as a column in the Syncfusion Blazor DataGrid.

You can use the **Validator** property to show a validation message for a field in the dialog template, even if that field is not present in the Grid columns. In the following example, the validation message for **ShipAddress** is displayed in the dialog template, even though the **ShipAddress** field is not defined as a Grid column.

> Validation messages for fields not defined in the Grid columns will appear as a validation summary at the top of the dialog edit form.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs
@using System.ComponentModel.DataAnnotations

<SfGrid DataSource="@OrderData" Toolbar="@(new string[] {"Add", "Edit" ,"Delete","Update","Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <Validator>
            <DataAnnotationsValidator></DataAnnotationsValidator>
        </Validator>
        <Template>
            @{
                var Order = (context as OrderDetails);
                <div>
                    <ValidationMessage For="() => Order.OrderID" />
                    <ValidationMessage For="() => Order.CustomerID" />
                    <ValidationMessage For="() => Order.Freight" />
                    <ValidationMessage For="() => Order.OrderDate" />
                    <ValidationMessage For="() => Order.ShipCountry" />
                    <ValidationMessage For="() => Order.ShipCity" />
                    <ValidationMessage For="() => Order.ShipAddress" />
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="@((Order.OrderID == 0) ? true : false)" FloatLabelType="FloatLabelType.Always" Placeholder="Order ID"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfTextBox ID="CustomerID" @bind-Value="@(Order.CustomerID)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Customer Name">
                            </SfTextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double" FloatLabelType="FloatLabelType.Always" Placeholder="Freight"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)" FloatLabelType="FloatLabelType.Always" Placeholder="Order Date">
                            </SfDatePicker>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCountry" TItem="Country" @bind-Value="@(Order.ShipCountry)" TValue="string" DataSource="@CountryName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Country">
                                <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCity" TItem="City" @bind-Value="@(Order.ShipCity)" TValue="string" DataSource="@CityName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship City">
                                <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <SfTextBox ID="ShipAddress" Multiline="true" @bind-Value="@(Order.ShipAddress)" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Address"></SfTextBox>
                        </div>
                    </div>                    
                </div>
            }
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" HeaderTextAlign="TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" Width="140" TextAlign="TextAlign.Right" HeaderTextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public class City
    {
        public string ShipCity { get; set; }
    }
    List<City> CityName = new List<City>
    {
        new City() { ShipCity= "Reims" },
        new City() { ShipCity= "Münster" },
        new City() { ShipCity = "Rio de Janeiro" },
        new City() { ShipCity = "Lyon" },
        new City() { ShipCity = "Charleroi" },
        new City() { ShipCity = "Genève" },
        new City() { ShipCity = "Resende" },
        new City() { ShipCity = "San Cristóbal" },
        new City() { ShipCity = "Graz" },
        new City() { ShipCity = "México D.F." },
        new City() { ShipCity = "Köln" },
        new City() { ShipCity = "Albuquerque" },
    };
    public class Country
    {
        public string ShipCountry { get; set; }
    }
    List<Country> CountryName = new List<Country>
    {
        new Country() { ShipCountry= "France"},
        new Country() { ShipCountry= "Brazil"},
        new Country() { ShipCountry= "Germany"},
        new Country() { ShipCountry= "Belgium"},
        new Country() { ShipCountry= "Austria"},
        new Country() { ShipCountry= "Switzerland"},
        new Country() { ShipCountry= "Venezuela"},
        new Country() { ShipCountry= "Mexico"},
        new Country() { ShipCountry= "USA"},
    };
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int orderID, string customerId, double freight, string shipCountry, string shipName, string shipCity, string shipAddress, DateTime orderDate)
    {
        OrderID = orderID;
        CustomerID = customerId;
        Freight = freight;
        ShipCountry = shipCountry;
        ShipName = shipName;
        ShipCity = shipCity;
        ShipAddress = shipAddress;
        OrderDate = orderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", "Vins et alcools Chevalier", "Reims", "59 rue de l Abbaye", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", "Toms Spezialitäten", "Münster", "Luisenstr. 48", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", "Hanari Carnes", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", "Victuailles en stock", "Lyon", "2, rue du Commerce", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", "Suprêmes délices", "Charleroi", "Boulevard Tirou, 255", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", "Hanari Carnes", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", "Chop-suey Chinese", "Bern", "Hauptstr. 31", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", "Richter Supermarkt", "Genève", "Starenweg 5", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", "Wellington Importadora", "Resende", "Rua do Mercado, 12", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", "HILARION-Abastos", "San Cristóbal", "Carrera 22 con Ave. Carlos Soublette #8-35", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", "Ernst Handel", "Graz", "Kirchgasse 6", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", "Centro comercial Moctezuma", "México D.F.", "Sierras de Granada 9993", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", "Ottilies Käseladen", "Köln", "Mehrheimerstr. 369", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", "Que Delícia", "Rio de Janeiro", "Rua da Panificadora, 12", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", "Rattlesnake Canyon Grocery", "Albuquerque", "2817 Milton Dr.", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    [Range(1, int.MaxValue, ErrorMessage = "Order ID must be greater than 0")]
    public int OrderID { get; set; }
    [StringLength(5, MinimumLength = 3, ErrorMessage = "CustomerID must be between 3 and 5 characters long.")]
    public string CustomerID { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Freight must be a positive value")]
    public double Freight { get; set; }
    [Required]
    public string ShipCountry { get; set; }
    [Required]
    public string ShipName { get; set; }
    [Required]
    public string ShipCity { get; set; }
    [Required]
    public string ShipAddress { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBoZChqfqyraNHa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can find the fully working sample [here](https://github.com/SyncfusionExamples/blazor-datagrid-display-validation-message-in-dialog-template). 