---
layout: post
title: Clone Group/ Rule in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about Clone Group/ Rule in Syncfusion Blazor QueryBuilder component and much more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Clone Group/ Rule in Blazor QueryBuilder Component

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) functionality extends to cloning both individual rules and entire groups. Utilizing the Clone options will generate an exact duplicate of a rule or group adjacent to the original one. This feature enables users to replicate complex query structures effortlessly. The [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.QueryBuilderShowButtons.html) function offers users the ability to toggle the visibility of these cloning buttons, providing convenient control over the cloning process within the Query Builder interface.

You can `clone` groups and rules by interacting through the user interface and methods.

* Use the [CloneGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_CloneGroup_System_String_System_Int32_) method to clone group.
* Use [CloneRule](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_CloneRule_System_String_System_Int32_) method to clone rule.

```cshtml
@using Syncfusion.Blazor.QueryBuilder
@using Syncfusion.Blazor.Buttons

<SfQueryBuilder TValue="EmployeeDetails" @ref="QuerybuilderObj">
    <QueryBuilderShowButtons RuleDelete="true" GroupDelete="true" GroupInsert="true" CloneGroup="true" CloneRule="true"></QueryBuilderShowButtons>
    <QueryBuilderRule Condition="or" Rules="@Rules"></QueryBuilderRule>
    <QueryBuilderColumns>
        <QueryBuilderColumn Field="EmployeeID" Label="Employee ID" Type="ColumnType.Number"></QueryBuilderColumn>
        <QueryBuilderColumn Field="FirstName" Label="First Name" Type="ColumnType.String"></QueryBuilderColumn>
        <QueryBuilderColumn Field="TitleOfCourtesy" Label="Title Of Courtesy" Type="ColumnType.Boolean"></QueryBuilderColumn>
        <QueryBuilderColumn Field="HireDate" Label="Hire Date" Type="ColumnType.Date" Format="MM/dd/yyyy"></QueryBuilderColumn>
        <QueryBuilderColumn Field="Country" Label="Country" Type="ColumnType.String"></QueryBuilderColumn>
    </QueryBuilderColumns>
</SfQueryBuilder>

<SfButton @onclick="cloneGroup" IsPrimary="true" Content="Clone Group"></SfButton>
<SfButton @onclick="cloneRule" IsPrimary="true" Content="Clone Rule"></SfButton>

@code {
    SfQueryBuilder<EmployeeDetails> QuerybuilderObj;
    List<RuleModel> Rules = new List<RuleModel>()
    {
            new RuleModel { Field="Country", Label="Country", Type="String", Operator="equal", Value = "England" },
            new RuleModel { Field="EmployeeID", Label="EmployeeID", Type="Number", Operator="notequal", Value = 1001 },
            new RuleModel { Condition = "or", Rules = new List<RuleModel>()
            {
                new RuleModel { Field="EmployeeID", Label="EmployeeID", Type="Number", Operator="notequal", Value = 1002 },
            } }
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

    private void cloneGroup()
    {
        QuerybuilderObj.CloneGroup("group1", 2);
    }

    private void cloneRule()
    {
        QuerybuilderObj.CloneRule("group0_rule0", 1);
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

![Clone Group/Rule in Blazor QueryBuilder](./images/clone-group-rule.png)

N> You can also explore our [Blazor Query Builder example](https://blazor.syncfusion.com/demos/query-builder/default-functionalities?theme=bootstrap4) to know how to render and configure the query builder.