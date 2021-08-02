---
layout: post
title: Hide Tree Grid Header in Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about Hide Tree Grid Header in Syncfusion Blazor TreeGrid component and more.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Hide Tree Grid Header in Blazor TreeGrid Component

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