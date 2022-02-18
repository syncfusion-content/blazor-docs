---
layout: post
title: Column Validation in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Column Validation in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Validation

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

## Data annotation

Data Annotation validation attributes are used to validate the fields in the DataGrid. The validation attributes that are supported in the DataGrid are listed below.

| Attribute Name | Functionality |
|-------|---------|
| Validations are,<br><br>1. RequiredAttribute<br>2. StringLengthAttribute<br>3. RangeAttribute<br>4. RegularExpressionAttribute<br>5. MinLengthAttribute<br>6. MaxLengthAttribute<br>7. EmailAddressAttribute<br>8. CompareAttribute<br>9. DataTypeAttribute<br>10.  DataType.Custom<br>11. DataType.Date<br>12. DataType.DateTime<br>13. DataType.EmailAddress<br>14. DataType.ImageUrl<br>15. DataType.Url | The data annotation validation attributes are used as `validation rules` in the DataGrid CRUD operations |

More information on the data annotation can be found in this [documentation](https://blazor.syncfusion.com/documentation/datagrid/data-annotation/) section.

## Custom validation

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

## Custom validator component

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

## Display validation message using in-built tooltip

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

## Disable in-built validator component

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