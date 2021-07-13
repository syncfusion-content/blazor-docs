---
layout: post
title: How to Render Treegrid Inside Tab With Specific Height in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Render Treegrid Inside Tab With Specific Height in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Render Tree Grid inside the Tab with specific height

By default, Tree Grid will occupy the entire space of the parent element when Tree Grid [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Height) and [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Width) property is defined as 100%. But if you render the similar Tree Grid inside the Tab control, it will consider the entire page and render the Tree Grid without horizontal scroller.

{% aspTab template="tree-grid/how-to/treegrid-inside-tab", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

Output be like the below.

![`Final output`](../images/treegrid-in-tab.PNG)