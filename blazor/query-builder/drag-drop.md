---
layout: post
title: Drag and Dropin Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about Drag and Drop in Syncfusion Blazor QueryBuilder component and much more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Drag and Dropin Blazor QueryBuilder Component

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) functionality extends to cloning both individual rules and entire groups. Utilizing the Clone options will generate an exact duplicate of a rule or group adjacent to the original one. This feature enables users to replicate complex query structures effortlessly. The [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.QueryBuilderShowButtons.html) function offers users the ability to toggle the visibility of these cloning buttons, providing convenient control over the cloning process within the Query Builder interface.

You can `clone` groups and rules by interacting through the user interface and methods.

* Use the [CloneGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_CloneGroup_System_String_System_Int32_) method to clone group.
* Use [CloneRule](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_CloneRule_System_String_System_Int32_) method to clone rule.

```cshtml
@using Syncfusion.Blazor.QueryBuilder
@using Syncfusion.Blazor.Buttons

<SfQueryBuilder TValue="EmployeeDetails" @ref="QuerybuilderObj">
    <QueryBuilderRule Condition="or" Rules="@Rules"></QueryBuilderRule>
    <QueryBuilderColumns>
        <QueryBuilderColumns>
            <QueryBuilderColumn Field="CustomerID" Label="CustomerID" Type=Syncfusion.Blazor.QueryBuilder.ColumnType.String></QueryBuilderColumn>
            <QueryBuilderColumn Field="EmployeeID" Label="EmployeeID" Type=Syncfusion.Blazor.QueryBuilder.ColumnType.Number></QueryBuilderColumn>
            <QueryBuilderColumn Field="Verified" Label="Verified" Type=Syncfusion.Blazor.QueryBuilder.ColumnType.Boolean></QueryBuilderColumn>
            <QueryBuilderColumn Field="ShipName" Label="ShipName" Type=Syncfusion.Blazor.QueryBuilder.ColumnType.String></QueryBuilderColumn>
            <QueryBuilderColumn Field="OrderDate" Label="OrderDate" Type=Syncfusion.Blazor.QueryBuilder.ColumnType.Date Format="dd/MM/yyyy"></QueryBuilderColumn>
            <QueryBuilderColumn Field="ShipCountry" Label="ShipCountry" Type=Syncfusion.Blazor.QueryBuilder.ColumnType.String></QueryBuilderColumn>
            <QueryBuilderColumn Field="ShipAddress" Label="ShipAddress" Type=Syncfusion.Blazor.QueryBuilder.ColumnType.String></QueryBuilderColumn>
        </QueryBuilderColumns>
    </QueryBuilderColumns>
</SfQueryBuilder>

<SfButton @onclick="DragDrop" IsPrimary="true" Content="Drag and Drop"></SfButton>

@code {
    SfQueryBuilder<EmployeeDetails> QuerybuilderObj;
    List<RuleModel> Rules = new List<RuleModel>()
    {
         new RuleModel { Label="EmployeeID", Field="EmployeeID", Type="Number", Operator="equal", Value = 1001 },
         new RuleModel { Label="CustomerID", Field="CustomerID", Type="String", Operator="equal", Value = "FLKIN" },
         new RuleModel {
            Condition = "or", Rules = new List<RuleModel>() {
                new RuleModel { Label= "OrderDate", Field = "OrderDate", Type = "Date", Operator = "equal", Value = new DateTime(2024, 01, 12) },
                new RuleModel { Label= "ShipCountry", Field = "ShipCountry", Type = "String", Operator = "equal", Value = "USA" }
            }
        }
    };

    private void DragDrop()
    {
        QuerybuilderObj.AllowDragAndDrop = true;
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

![Drag and Drop in Blazor QueryBuilder](./images/drag-drop.png)

N> You can also explore our [Blazor Query Builder example](https://blazor.syncfusion.com/demos/query-builder/default-functionalities?theme=bootstrap4) to know how to render and configure the query builder.