---
layout: post
title: Hide Tree Grid Header in Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about hiding Tree Grid Header in Syncfusion Blazor TreeGrid component and more.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Hide Tree Grid Header in Blazor TreeGrid Component

 The Tree Grid header can be hidden by applying the below styles to Tree Grid component.

```html
<style>
    .e-treegrid .e-gridheader .e-columnheader {
        display: none;
    }
</style>
```

N> If you want to hide the header for particular Tree Grid, then apply the above styles to that Tree Grid using the ID (#TreeGrid.e-treegrid .e-gridheader .e-columnheader) property value.

![Hiding Header in Blazor TreeGrid](../images/blazor-treegrid-hide-header.PNG)
