---
layout: post
title: How to Change Data Source Dynamically in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Change Data Source Dynamically in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Change Tree Grid data source dynamically

You can change the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_DataSource) of the Tree Grid component dynamically through an external button.

This is demonstrated in the below sample code where the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_DataSource) is dynamically modified using the bounded property,

{% aspTab template="tree-grid/how-to/change-data", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following GIF represents Tree Grid data source modified dynamically on button click,
![`Update datasource dynamically`](../images/change-datasource.gif)