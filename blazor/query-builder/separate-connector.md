---
layout: post
title: Separate Connector in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about Separate Connector in Syncfusion Blazor QueryBuilder component and much more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Separate Connector in Blazor QueryBuilder Component

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) supports separate connectors between rules or groups within the same parent group. When enabled, each rule (or nested group) can specify its own connector (AND/OR), allowing more precise control over complex logic than using a single group-level connector.

Use the [`EnableIndividualConditions`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_EnableIndividualConditions) property to enable separate connectors. 

```cshtml
@using Syncfusion.Blazor.QueryBuilder

<SfQueryBuilder TValue="EmployeeDetails" @ref="QuerybuilderObj" EnableIndividualConditions="true">
    <QueryBuilderRule Condition="or" Rules="@Rules"></QueryBuilderRule>
    <QueryBuilderColumns>
        <QueryBuilderColumns>
            <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
                <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
                <QueryBuilderColumn Field="LastName" Label="Last Name" Type="ColumnType.String"></QueryBuilderColumn>
                <QueryBuilderColumn Field="IsDeveloper" Label="IsDeveloper" Type="ColumnType.Boolean"></QueryBuilderColumn>
                <QueryBuilderColumn Field="Age" Label="Age" Type="ColumnType.Number"></QueryBuilderColumn>
                <QueryBuilderColumn Field="PrimaryFramework" Label="Primary Framework" Type="ColumnType.String"></QueryBuilderColumn>
                <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date"></QueryBuilderColumn>
                <QueryBuilderColumn Field="Country" Label="Country" Type="ColumnType.String"></QueryBuilderColumn>
        </QueryBuilderColumns>
    </QueryBuilderColumns>
</SfQueryBuilder>

@code {
    SfQueryBuilder<EmployeeDetails> QuerybuilderObj;
    List<RuleModel> Rules = new List<RuleModel>()
    {
        new RuleModel { Label="First Name", Field="FirstName", Type="String", Operator="equal", Value = "Andre", Condition = "and" },
        new RuleModel { Label="Last Name", Field="LastName", Type="String", Operator="in", Value = new string[] { "Davolio", "Buchanan" } },
        new RuleModel { Label="Last Name", Field="LastName", Type="String", Operator="equal", Value = "Davolio", Condition = "or" },
        new RuleModel { Label="Age", Field="Age", Type="Number", Operator="equal", Value = 29, Condition = "and" },
        new RuleModel {
            Condition = "or", Rules = new List<RuleModel>() {
                new RuleModel { Label= "Is Developer", Field = "IsDeveloper", Type = "Boolean", Operator = "equal", Value = true, Condition = "and" },
                new RuleModel { Label= "Primary Framework", Field = "PrimaryFramework", Type = "String", Operator = "equal", Value = "React"}
            }
        }
    };

    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsDeveloper { get; set; }
        public string PrimaryFramework { get; set; }
        public DateTime HireDate { get; set; }
        public string Country { get; set; }
    }
}

```

![EnableIndividualConditions in Blazor Query Builder](./images/separate-connector.png)

N> You can also explore our [Blazor Query Builder example](https://blazor.syncfusion.com/demos/query-builder/default-functionalities?theme=bootstrap4) to know how to render and configure the query builder.