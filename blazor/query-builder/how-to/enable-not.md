---
layout: post
title: How to Enable Not in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn about Enable Not in Blazor QueryBuilder component of Syncfusion, and more details.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Not Operator

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