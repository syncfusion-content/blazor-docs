---
layout: post
title: Lock Group/ Rule in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about Lock Group/ Rule in Syncfusion Blazor QueryBuilder component and much more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Lock Group/ Rule in Blazor QueryBuilder Component

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) supports locking individual rules or entire groups. When a rule is locked, its field, operator, and value editors are disabled and cannot be changed. Locking a group disables all editors and actions within that group. Locked items still participate in evaluation; only editing is restricted. The visibility of lock buttons in the UI can be configured through the [`ShowButtons`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.QueryBuilderShowButtons.html) configuration.

Locking can be done through the user interface or programmatically.

* Use the [LockGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_LockGroup_System_String_System_Boolean_) method to lock group.
* Use [LockRule](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_LockRule_System_String_System_Boolean_) method to lock rule.

```cshtml
@using Syncfusion.Blazor.QueryBuilder
@using Syncfusion.Blazor.Buttons

<SfQueryBuilder TValue="EmployeeDetails" @ref="QuerybuilderObj">
    <QueryBuilderShowButtons RuleDelete="true" GroupDelete="true" GroupInsert="true" LockGroup="true" LockRule="true"></QueryBuilderShowButtons>
    <QueryBuilderRule Condition="or" Rules="@Rules"></QueryBuilderRule>
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="TitleOfCourtesy" Label="Title Of Courtesy" Type="ColumnType.Boolean"></QueryBuilderColumn>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date" Format="MM/dd/yyyy"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Country" Label="Country" Type="ColumnType.String"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>

<SfButton @onclick="lockGroup" IsPrimary="true" Content="Lock Group"></SfButton>
<SfButton @onclick="lockRule" IsPrimary="true" Content="Lock Rule"></SfButton>

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

    private void lockGroup()
    {
        QuerybuilderObj.LockGroup("group0");
    }

    private void lockRule()
    {
        QuerybuilderObj.LockRule("group0_rule0");
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

![Lock Group/Rule in Blazor Query Builder](./images/lock-group-rule.png)

N> You can also explore our [Blazor Query Builder example](https://blazor.syncfusion.com/demos/query-builder/default-functionalities?theme=bootstrap4) to know how to render and configure the query builder.