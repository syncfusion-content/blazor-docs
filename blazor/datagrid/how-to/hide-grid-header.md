---
layout: post
title: How to Hide Grid Header in Blazor DataGrid Component | Syncfusion
description: Checkout and learn about Hide Grid Header in Blazor DataGrid component of Syncfusion, and more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Hide DataGrid header

You can hide the DataGrid header by applying the below styles to DataGrid component.

```html
<style>
    .e-grid .e-gridheader .e-columnheader{
        display: none;
    }
</style>
```

> if you want to hide the header for particular DataGrid, then you can apply the above styles to that DataGrid using the ID (#Grid.e-grid .e-gridheader .e-columnheader) property value.