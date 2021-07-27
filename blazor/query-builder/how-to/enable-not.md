---
layout: post
title: Show Not Operator in Blazor QueryBuilder Component | Syncfusion
description: Learn here all about Show Not Operator in Syncfusion Blazor QueryBuilder component and more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Show Not Operator in Blazor QueryBuilder Component

The Querybuilder provides `Not` operator along with AND, OR operators to filter records based on more than one condition. You can enable this feature by setting the [`EnableNotCondition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_EnableNotCondition) property to `true`.

> By default `EnableNotCondition` set as false.

```csharp

@using Syncfusion.Blazor.QueryBuilder

<SfQueryBuilder TValue="@EmployeeDetails" EnableNotCondition="true">
    <QueryBuilderRule Condition="or" Not="false" Rules="@Rules"></QueryBuilderRule>
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
        new RuleModel { Field="EmployeeID", Label="EmployeeID", Type="Number", Operator="notequal", Value = 1001 },
        new RuleModel { Condition = "and", Not=true, Rules = new List<RuleModel>(){ new RuleModel() { Field = "FirstName", Label = "First Name", Type = "String", Operator = "contains", Value = "mark" } }}
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

Output will be shown as

![Query Builder Sample](./../images/not.png)