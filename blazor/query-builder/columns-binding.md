---
layout: post
title: Columns in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about columns in Syncfusion Blazor QueryBuilder component and much more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Columns in Blazor QueryBuilder Component

Column definitions provide the schema used by the Query Builder’s [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_DataSource). They determine how field values are rendered and how users create or delete conditions and groups. The [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.QueryBuilderColumn.html#Syncfusion_Blazor_QueryBuilder_QueryBuilderColumn_Field) property in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_Columns) is required to map data source fields to Query Builder columns.

N> If the column field is not present in the data source, the column renders with empty values.

## Auto generation

[Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_Columns) are automatically generated from the data source when the `Columns` declaration is empty or not provided at initialization. In this case, all fields in the `DataSource` are bound as Query Builder columns.

N> When columns are auto-generated, the column type is inferred from the first record of the data source. 

```cshtml
@using Syncfusion.Blazor.QueryBuilder

<SfQueryBuilder DataSource="@EmployeeData"></SfQueryBuilder>

@code {
    //Local datasource
    public List<EmployeeDetails> EmployeeData = new List<EmployeeDetails>
    {
        new EmployeeDetails{ FirstName = "Martin", EmployeeID = 1001, Country = "England", City = "Manchester", HireDate = new DateTime(2014, 4, 23) },
        new EmployeeDetails{ FirstName = "Benjamin", EmployeeID = 1002, Country = "England", City = "Birmingham", HireDate = new DateTime(2014, 6, 19) },
        new EmployeeDetails{ FirstName = "Stuart", EmployeeID = 1003, Country = "England", City = "London", HireDate = new DateTime(2014, 7, 4) },
        new EmployeeDetails{ FirstName = "Ben", EmployeeID = 1004, Country = "USA", City = "California", HireDate = new DateTime(2014, 8, 15) },
        new EmployeeDetails{ FirstName = "Joseph", EmployeeID = 1005, Country = "Spain", City = "Madrid", HireDate = new DateTime(2014, 8, 29) }
    };

    public class EmployeeDetails
    {
        public string FirstName { get; set; }
        public int EmployeeID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime HireDate { get; set; }
    }
}

```

## Labels

By default, the column label is derived from the column [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.QueryBuilderColumn.html#Syncfusion_Blazor_QueryBuilder_QueryBuilderColumn_Field) value. To override the default, set the [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.QueryBuilderColumn.html#Syncfusion_Blazor_QueryBuilder_QueryBuilderColumn_Label) property to a display-friendly name (for example, a localized string).

N> If both the field and label are not defined for a column, it renders with `empty` text.

## Operators

Define the allowed operators for a column in the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_Columns) collection. Custom operator sets can be configured using the column’s [OperatorsModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.OperatorsModel.html). The following built-in operators and their supported data types are available:

| Operators | Description | Supported Types |
| ------------ | ----------------------- | ------------------ |
| startswith  | Checks whether the value begins with the specified value. | String |
| notstartswith  | Checks whether the value does not begin with the specified prefix. | String |
| endswith  | Checks whether the value ends with the specified value. | String |
| notendswith  | Checks whether the value does not end with the specified value. | String |
| contains | Checks whether the value contains the specified value. | String |
| notcontains | Checks whether the value does not include the specified value. | String |
| equal | Checks whether the value is equal to the specified value. | String, Number, Date, Boolean |
| notequal | Checks for values not equal to the specified value. | String, Number, Date, Boolean |
| greaterthan | Checks whether the value is greater than the specified value. | Date, Number |
| greaterthanorequal | Checks whether a value is greater than or equal to the specified value. | Date, Number |
| lessthan | Checks whether the value is less than the specified value. | Date, Number |
| lessthanorequal | Checks whether the value is less than or equal to the specified value. | Date, Number |
| between | Checks whether the value is between two specific values. | Date, Number |
| notbetween | Checks whether the value is not between two specific values. | Date, Number |
| in | Checks whether the value is one of the specified values. | String, Number |
| notin | Checks whether the value is not one of the specified values. | String, Number |
| isempty | Checks whether the value is empty. | String |
| isnotempty | Checks whether the value is not empty. | String |
| isnull | Checks whether the value is null. | String, Number |
| isnotnull | Checks whether the value is not null. | String, Number |

## Step

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) allows setting step values for number fields. Use the [Step](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.QueryBuilderColumn.html#Syncfusion_Blazor_QueryBuilder_QueryBuilderColumn_Step) property to control the increment/decrement applied by the numeric input.

N> By default, the `Step` value is 1.

```cshtml
@using Syncfusion.Blazor.QueryBuilder

<SfQueryBuilder TValue="EmployeeDetails">
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number" Step="5"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Title" Label="Title" Type="ColumnType.String"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>

@code {
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public bool TitleOfCourtesy { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}

```

N> You can also explore the [Blazor Query Builder example](https://blazor.syncfusion.com/demos/query-builder/default-functionalities?theme=bootstrap5) to learn how to render and configure the Query Builder.

## Format

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) supports formatting of date and number values. Use the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.QueryBuilderColumn.html#Syncfusion_Blazor_QueryBuilder_QueryBuilderColumn_Format) property to apply date and number formats.

N> Standard numeric format specifiers such as `n`, `p`, and `c` can be used in the `Format` property to display number, percentage, and currency inputs respectively. Formatting is culture-aware.

In the following sample, the date field is formatted as `MM-yyyy-dd` and the number field is formatted as currency.

```cshtml
@using Syncfusion.Blazor.QueryBuilder

<SfQueryBuilder TValue="EmployeeDetails">
    <QueryBuilderRule Condition="and" Rules="Rules"></QueryBuilderRule>
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date" Format="MM-yyyy-dd"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Salary" Label="Salary" Type="ColumnType.Number" Format="c2"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>

@code {
    List<RuleModel> Rules = new List<RuleModel>()
    {
        new RuleModel { Field="HireDate", Label="HireDate", Type="Date", Operator="equal", Value = new DateTime(DateTime.Now.Year,DateTime.Now.Month,4) },
        new RuleModel { Field="Salary", Label="Salary",  Type="Number", Operator="greaterthan", Value = 23 }
    };
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public bool TitleOfCourtesy { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Salary { get; set; }
    }
}

```

![Formatting in Blazor QueryBuilder](./images/blazor-querybuilder-format.png)

N> You can also explore our [Blazor Query Builder example](https://blazor.syncfusion.com/demos/query-builder/default-functionalities?theme=bootstrap5) to know how to render and configure the query builder.

## Validations

Validation enables checking of rule inputs and displays errors for invalid fields. To enable validation, set [AllowValidation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_AllowValidation) to `true`. After enabling, fields are validated based on the configured rules and column settings.

N> You can set `Min` and `Max` values for numeric fields using `QueryBuilderColumnValidation`.

```cshtml
@using Syncfusion.Blazor.QueryBuilder

<SfQueryBuilder TValue="EmployeeDetails" AllowValidation="true">
    <QueryBuilderColumnValidation Max="100" Min="0"></QueryBuilderColumnValidation>
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="TitleOfCourtesy" Label="Title of Courtesy" Type="ColumnType.Boolean" Values="Values"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Title" Label="Title" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Country" Label="Country" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="City" Label="City" Type="ColumnType.String"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>

@code {
    private string[] Values = new string[] { "Mr.", "Mrs." };
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public bool TitleOfCourtesy { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}

```

![Validation in Blazor QueryBuilder](./images/blazor-querybuilder-validation.png)