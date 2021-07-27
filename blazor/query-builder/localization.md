---
layout: post
title: Localization in Blazor QueryBuilder Component | Syncfusion
description: Learn here all about Localization in Syncfusion Blazor QueryBuilder component and more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Localization in Blazor QueryBuilder Component

The `Localization` library allows you to localize default text content of the Query Builder. The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) has static text that can be changed to other cultures (Arabic, Deutsch, French, etc.). In the following sample the text is changed to `German` culture.

We have used Resource file (.resx) to translate the static text of the querybuilder.

> Use `Resource` file to translate the static text of the Querybuilder. The Resource file is an XML file which contains the strings(key and value pairs) that you want to translate into different language. You can also refer [`Localization`](https://blazor.syncfusion.com/documentation/common/localization/#how-to-enable-localization-in-blazor-application) link to know more about how to configure and use localization in the Blazor Server and Web Assembly project for Syncfusion Blazor components.

The following list of properties and its values are used in the Query Builder.

| Locale key | en-US (default) |
| ------------ | ----------------------- |
| QueryBuilder_AddGroup  | Add Group |
| QueryBuilder_AddCondition  | Add Condition |
| QueryBuilder_DeleteRule | Remove this condition |
| QueryBuilder_DeleteGroup | Delete group |
| QueryBuilder_Edit | EDIT |
| QueryBuilder_SelectField | Select a field |
| QueryBuilder_SelectOperator | Select operator |
| QueryBuilder_StartsWith | Starts With|
| QueryBuilder_EndsWith | Ends With |
| QueryBuilder_Contains | Contains |
| QueryBuilder_Equal | Equal |
| QueryBuilder_NotEqual | Not Equal |
| QueryBuilder_LessThan | Less Than |
| QueryBuilder_LessThanOrEqual | Less Than Or Equal |
| QueryBuilder_GreaterThan | Greater Than |
| QueryBuilder_GreaterThanOrEqual | Greater Than Or Equal |
| QueryBuilder_Between | Between |
| QueryBuilder_NotBetween | Not Between|
| QueryBuilder_In | In |
| QueryBuilder_NotIn | Not In |
| QueryBuilder_Remove | REMOVE |
| QueryBuilder_ValidationMessage | This field is required |
| QueryBuilder_SummaryViewTitle | Summary View |
| QueryBuilder_OtherFields | Other Fields |
| QueryBuilder_AND | AND |
| QueryBuilder_OR | OR |
| QueryBuilder_SelectValue | Enter Value |
| QueryBuilder_IsEmpty | Is Empty |
| QueryBuilder_IsNotEmpty | Is Not Empty |
| QueryBuilder_IsNull | Is Null |
| QueryBuilder_IsNotNull | Is Not Null |

```csharp

@using Syncfusion.Blazor.QueryBuilder

<SfQueryBuilder TValue="EmployeeDetails">
    <QueryBuilderRule Condition="and" Rules="@Rules"></QueryBuilderRule>
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
    List<RuleModel> Rules = new List<RuleModel>()
    {
        new RuleModel { Field="EmployeeID", Label="Employee ID", Type="Number", Operator="equal", Value = 2345 }
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

Output will be shown as

![Query Builder Sample](./images/qb-locale.png)
> You can also explore our [Blazor Query Builder example](https://blazor.syncfusion.com/demos/query-builder/default-functionalities?theme=bootstrap4) to knows how to render and configure the query builder.