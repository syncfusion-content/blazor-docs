---
layout: post
title: Filtering in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about filtering in Syncfusion Blazor QueryBuilder component and much more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Filtering in Blazor QueryBuilder Component

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) allows to create or delete conditions and groups. You can use [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.QueryBuilderShowButtons.html) to enable/disable these buttons.

You can `create` or `delete` conditions by interacting through the user interface and methods.

* Use the [AddRule](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_AddRule_Syncfusion_Blazor_QueryBuilder_RuleModel_System_String_System_Boolean_), and [DeleteRule](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_DeleteRule_System_String_) methods to create/delete conditions.
* Use [AddGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_AddGroup_Syncfusion_Blazor_QueryBuilder_RuleModel_System_String_), and [DeleteGroup](hhttps://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_DeleteGroup_System_String_) methods to create/delete groups.

```cshtml
@using Syncfusion.Blazor.QueryBuilder
@using Syncfusion.Blazor.Buttons

<SfQueryBuilder TValue="EmployeeDetails" @ref="QuerybuilderObj">
    <QueryBuilderShowButtons RuleDelete="true" GroupDelete="true" GroupInsert="true"></QueryBuilderShowButtons>
    <QueryBuilderRule Condition="or" Rules="@Rules"></QueryBuilderRule>
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="TitleOfCourtesy" Label="Title Of Courtesy" Type="ColumnType.Boolean"></QueryBuilderColumn>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date" Format="MM/dd/yyyy"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Country" Label="Country" Type="ColumnType.String"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>

<SfButton @onclick="addRule" IsPrimary="true" Content="Add Rules"></SfButton>
<SfButton @onclick="addGroup" IsPrimary="true" Content="Add Group"></SfButton>
<SfButton @onclick="deleteGroups" IsPrimary="true" Content="Delete Groups"></SfButton>

@code {
    SfQueryBuilder<EmployeeDetails> QuerybuilderObj;
    List<RuleModel> Rules = new List<RuleModel>()
    {
            new RuleModel { Field="Country", Label="Country", Type="String", Operator="equal", Value = "England" },
            new RuleModel { Field="EmployeeID", Label="EmployeeID", Type="Number", Operator="notequal", Value = 1001 }
    };

    RuleModel SampRule = new RuleModel()
    {
        Label = "Employee ID",
        Field = "EmployeeID",
        Type = "Number",
        Operator = "equal",
        Value = 1091
    };

    RuleModel SampGroup = new RuleModel()
    {
        Condition = "or",
        Rules = new List<RuleModel>()
        {
            new RuleModel()
            {
                Label = "Employee ID",
                Field = "EmployeeID",
                Type = "Number",
                Operator = "equal",
                Value = 1091
            }
        }
    };

    public string[] GroupID = new string[] { "group1" };

    private void addRule()
    {
        QuerybuilderObj.AddRule(SampRule, "group0");
    }

    private void addGroup()
    {
        QuerybuilderObj.AddGroup(SampGroup, "group0");
    }

    private void deleteGroups()
    {
        QuerybuilderObj.DeleteGroup("group1");
    }

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

![Filtering in Blazor QueryBuilder](./images/blazor-querybuilder-filtering.png)

N> You can also explore our [Blazor Query Builder example](https://blazor.syncfusion.com/demos/query-builder/default-functionalities?theme=bootstrap5) to know how to render and configure the query builder.