---
layout: post
title: Hide DataGrid Header in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Hide DataGrid Header in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Hide DataGrid Header in Blazor DataGrid Component

You can hide the DataGrid header by applying the following styles to the DataGrid component.

```html
<style>
    .e-grid .e-gridheader .e-columnheader{
        display: none;
    }
</style>
```

N> If you want to hide the header for particular DataGrid, then you can apply the above styles to that DataGrid using the ID (#Grid.e-grid .e-gridheader .e-columnheader) property value.