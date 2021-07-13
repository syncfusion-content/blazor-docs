---
layout: post
title: How to Calculate Column Value Based On Other Columns in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Calculate Column Value Based On Other Columns in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Calculate column value based on other column values

You can calculate the values for a Tree Grid column based on other column values by using the **context** parameter in the [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Template) property of the [`TreeGridColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html) component. Inside the [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Template), you can access the column values using the implicit named parameter **context** and then calculate the values for the new column as required.

This is demonstrated in the below sample code where the value for **Resources** column is calculated based on the values of **Duration** and **Progress** columns,

{% aspTab template="tree-grid/how-to/calculate-value", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following image represents the output of the above sample code,
![Column rendered based on other columns](../images/treegrid-columns-calculated.png)