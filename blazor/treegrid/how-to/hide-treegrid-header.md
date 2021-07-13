---
layout: post
title: How to Hide Treegrid Header in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Hide Treegrid Header in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Hide Tree Grid header

You can hide the Tree Grid header by applying the below styles to Tree Grid component.

```html
<style>
    .e-treegrid .e-gridheader .e-columnheader {
        display: none;
    }
</style>
```

> if you want to hide the header for particular Tree Grid, then you can apply the above styles to that Tree Grid using the ID (#TreeGrid.e-treegrid .e-gridheader .e-columnheader) property value.

Output be like the below.

![`Final output`](../images/hide-header.PNG)