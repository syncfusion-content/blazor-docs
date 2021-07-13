---
layout: post
title: How to Customize Column Styles in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Customize Column Styles in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Customize Column Styles

You can customise the appearance of the header and content of a particular column using the [`CustomAttributes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_CustomAttributes) property.

To customize the Tree Grid column, follow the given steps:

**Step 1**:

Create a CSS class with custom style to override the default style for rowcell and headercell.

```css
.e-attr{
        background: #5DADE2;
        font-family: "Bell MT";
        color: red;
        font-size: 5px;
    }
```

**Step 2**:

Add the custom CSS class to the specified column by using the [`CustomAttributes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_CustomAttributes) property.

{% aspTab template="tree-grid/how-to/column-styles", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

Output be like the below.

![`Final output`](../images/changecolumnstyle.PNG)