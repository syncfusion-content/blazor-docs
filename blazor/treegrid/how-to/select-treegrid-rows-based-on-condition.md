---
layout: post
title: How to Select Treegrid Rows Based On Condition in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Select Treegrid Rows Based On Condition in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Select Tree Grid rows based on certain condition

You can select specific rows in the Tree Grid based on some conditions by using the [`SelectRows`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SelectRows_System_Double___) method in the [`DataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_DataBound) event of the Tree Grid component.

This is demonstrated in the below sample code where the index value of Tree Grid rows with **Duration** column value greater than 6 are stored in the [`RowDataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowDataBound) event and then selected in the [`DataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_DataBound) event,

{% aspTab template="tree-grid/how-to/select-row", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

Output be like the below.

![`Final output`](../images/select-row.PNG)