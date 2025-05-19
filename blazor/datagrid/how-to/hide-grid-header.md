---
layout: post
title: Hide DataGrid Header in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Hide DataGrid Header in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Hide DataGrid Header in Blazor DataGrid

In the Syncfusion Blazor DataGrid, the header row (which displays the column titles) can be hidden using simple CSS styles.

Apply the following CSS to your application. This will completely hide the column headers of every Grid on the page:

```html
<style>
    .e-grid .e-gridheader .e-columnheader{
        display: none;
    }
</style>
```

N> If you want to hide the header for particular Grid, then you can apply the above styles to that Grid using the ID (#Grid.e-grid .e-gridheader .e-columnheader) property value.