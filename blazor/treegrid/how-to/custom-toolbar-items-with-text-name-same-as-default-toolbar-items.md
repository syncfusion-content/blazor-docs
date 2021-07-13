---
layout: post
title: How to Custom Toolbar Items With Text Name Same As Default Toolbar Items in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Custom Toolbar Items With Text Name Same As Default Toolbar Items in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Custom toolbar items with text name same as default toolbar items

You can create the Custom toolbar items with text name same as default toolbar items (Add,Edit,Delete,etc.). But while creating them, they will be considered as default toolbar items which will cause some issues while clicking on it. To overcome this behavior, we suggest you to define the **Id** property for custom toolbar items.

This is demonstrated in the below sample code where we have custom toolbar items with text same as **Add** and **Delete** buttons. These toolbar buttons will be enabled only when TreeGridEditSettings is defined in TreeGrid. So custom toolbar will be disabled state considering it as default toolbar item. We have overcome that behaviour by defining the Id property.

{% aspTab template="tree-grid/how-to/custom-toolbar-text", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

Output be like the below.

![`Final output`](../images/custom-toolbar-text.PNG)