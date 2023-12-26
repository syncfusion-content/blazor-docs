---
layout: post
title: Importing and Exporting in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about importing and exporting in Syncfusion Blazor QueryBuilder component and more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Importing and Exporting in Blazor QueryBuilder Component

Importing allows to view or edit the predefined conditions which is available in List rules or SQL rules. You can import the conditions as either initial rendering or post rendering.

## Initial rendering

To apply the conditions initially, you can define the condition and rules in **QueryBuilderRule** . Here, the list of rules can be imported by defining the **QueryBuilderRule**.

```cshtml

@using Syncfusion.Blazor.QueryBuilder

<SfQueryBuilder DataSource="@EmployeeData" @ref="QueryBuilderObj">
    <QueryBuilderRule Condition="or" Rules="Rules"></QueryBuilderRule>
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="TitleOfCourtesy" Label="Title Of Courtesy" Type="ColumnType.Boolean"></QueryBuilderColumn>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Country" Label="Country" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="City" Label="City" Type="ColumnType.String"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>

@code {
    SfQueryBuilder<EmployeeDetails> QueryBuilderObj;
    List<RuleModel> Rules = new List<RuleModel>()
    {
            new RuleModel { Field="Country", Label="Country", Type="String", Operator="equal", Value = "England" },
            new RuleModel { Field="EmployeeID", Label="EmployeeID",  Type="Number", Operator="notequal", Value = 1001 }
    };
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

![Blazor QueryBuilder with Data Binding](./images/blazor-querybuilder-binding-data.png)

## Post rendering

### Importing from SQL

You can set the conditions from SQL query through the [SetRulesFromSql](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_SetRules_System_Collections_Generic_List_Syncfusion_Blazor_QueryBuilder_RuleModel__System_String_System_Nullable_System_Boolean__) method.

```cshtml
@using Syncfusion.Blazor.QueryBuilder
@using Syncfusion.Blazor.Buttons

<SfQueryBuilder DataSource="@EmployeeData" @ref="QueryBuilderObj">
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="TitleOfCourtesy" Label="Title Of Courtesy" Type="ColumnType.Boolean"></QueryBuilderColumn>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Country" Label="Country" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="City" Label="City" Type="ColumnType.String"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>
<SfButton CssClass="e-primary" @onclick="setRules">Set Rules</SfButton>

@code {
    SfQueryBuilder<EmployeeDetails> QueryBuilderObj;
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
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public bool TitleOfCourtesy { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }

    private void setRules()
    {
        QueryBuilderObj.SetRulesFromSql("EmployeeID = 1001 AND City LIKE ('Manchester%')");
    }
}
```

![Importing from SQL in Blazor QueryBuilder](./images/blazor-querybuilder-import-from-sql.png)

## Exporting

Exporting allows to save or maintain the created conditions through the [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder). You can export the defined conditions by the following ways.

## Exporting to SQL

The defined conditions can be exported to the SQL query through the [GetSqlFromRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_GetSqlFromRules_Syncfusion_Blazor_QueryBuilder_RuleModel_System_Boolean_) method.

```cshtml
@using Syncfusion.Blazor.QueryBuilder
@using Syncfusion.Blazor.Buttons

<SfQueryBuilder DataSource="@EmployeeDetails" @ref="QueryBuilderObj">
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="TitleOfCourtesy" Label="Title Of Courtesy" Type="ColumnType.Boolean"></QueryBuilderColumn>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Country" Label="Country" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="City" Label="City" Type="ColumnType.String"></QueryBuilderColumn>
    </QueryBuilderColumns>
    <QueryBuilderRule Condition="or" Rules="Rules"></QueryBuilderRule>
</SfQueryBuilder>
<SfButton CssClass="e-primary" @onclick="getSql">Get SQL</SfButton>

@code {
    SfQueryBuilder<Employee> QueryBuilderObj;
    public List<Employee> EmployeeDetails = new List<Employee>
        {
        new Employee{ FirstName = "Martin", EmployeeID = "1001", Country = "England", City = "Manchester", HireDate = "23/04/2014" },
        new Employee{ FirstName = "Benjamin", EmployeeID = "1002", Country = "England", City = "Birmingham", HireDate = "19/06/2014" },
        new Employee{ FirstName = "Stuart", EmployeeID = "1003", Country = "England", City = "London", HireDate = "04/07/2014"},
        new Employee{ FirstName = "Ben", EmployeeID = "1004", Country = "USA", City = "California", HireDate = "15/08/2014" },
        new Employee{ FirstName = "Joseph", EmployeeID = "1005", Country = "Spain", City = "Madrid", HireDate = "29/08/2014" }
    };

    public class Employee {
        public string FirstName { get; set; }
        public string EmployeeID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string HireDate { get; set; }
    }

    public List<RuleModel> Rules = new List<RuleModel>
    {
        new RuleModel { Label="Employee ID", Field = "EmployeeID", Type="Number", Operator = "notequal", Value = 1001},
        new RuleModel { Label="Country", Field = "Country", Type="String", Operator = "equal", Value = "England"}
    };

    private void getSql()
    {
        QueryBuilderObj.GetSqlFromRules(QueryBuilderObj.GetRules());
    }
 }

```

## Importing and Exporting the JSON data

The Syncfusion Blazor [Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) allows you to import and export JSON data, enabling you to load existing conditions and save created conditions. 

### Importing from JSON

The [SetRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_SetRules_System_Collections_Generic_List_Syncfusion_Blazor_QueryBuilder_RuleModel__System_String_System_Nullable_System_Boolean__) function gives you the ability to define conditions from a JSON. You can import rules using this function by providing a list of RuleModel objects as the basis. The JSON text is additionally deserialized to a RuleModel object using the JsonConvert.DeserializeObject method.

### Exporting from JSON

You can seamlessly export the defined conditions from the Syncfusion Blazor Query Builder to a JSON by utilizing the [GetRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_GetRules) method. This method retrieves the configured rules within the Query Builder, offering a convenient way to capture and use the conditions. To complete the process, the JsonConvert.SerializeObject method is employed, enabling the conversion of these rules into a JSON.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.QueryBuilder
@using Newtonsoft.Json

<SfQueryBuilder TValue="EmployeeDetails" @ref="QueryBuilderObj">
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date" Format="yyyy-dd-MM" Operators="dateOpr"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>

<SfButton id="open" CssClass="e-primary" @onclick="Get">Get</SfButton>
<SfButton id="open" CssClass="e-primary" @onclick="Set">Set</SfButton>

@code {
    private SfQueryBuilder<EmployeeDetails> QueryBuilderObj;
    private List<OperatorsModel> dateOpr = new List<OperatorsModel> {
        new OperatorsModel {Text = "Between", Value = "between"},
        new OperatorsModel {Text = "Not Between", Value = "notbetween"}
    };
    private string rule;
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

    private void Get() {
        rule = JsonConvert.SerializeObject(QueryBuilderObj.GetRules());
    }

    private void Set() {
        RuleModel ruleModel = JsonConvert.DeserializeObject<RuleModel>(rule);
        QueryBuilderObj.SetRules(ruleModel.Rules,"and");
    }
}

```

N> You can also explore our [Blazor Query Builder example](https://blazor.syncfusion.com/demos/query-builder/default-functionalities?theme=bootstrap4) to know how to render and configure the query builder.