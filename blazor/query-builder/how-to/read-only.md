---
layout: post
title: Readonly in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about Readonly in Syncfusion Blazor QueryBuilder component and much more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Read-only in Blazor QueryBuilder component

The Readonly property disables user interactions in the QueryBuilder, preventing actions such as adding or removing groups and rules, and editing fields, operators, and values. Set the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_Readonly) property to `true`.

```cshtml

@using Syncfusion.Blazor.QueryBuilder

<SfQueryBuilder TValue="@EmployeeDetails" Readonly="true">
    <QueryBuilderRule Condition="or" Rules="@Rules"></QueryBuilderRule>
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Country" Label="Country" Type="ColumnType.String"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>

@code {
    List<RuleModel> Rules = new List<RuleModel>()
    {
        new RuleModel { Field="EmployeeID", Label="EmployeeID", Type="Number", Operator="notequal", Value = 1001 }
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

![Readonly mode in Blazor QueryBuilder](./../images/blazor-querybuilder-readonly.png)