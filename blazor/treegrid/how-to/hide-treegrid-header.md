---
layout: post
title: Blazor TreeGrid Hide Header | Syncfusion
description: Learn how to hide the header in Blazor TreeGrid to simplify layouts, customize grid appearance, and improve user experience.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Hide Header in Blazor TreeGrid

 The Tree Grid header can be hidden by applying the below styles to Tree Grid component.

```html
<style>
    .e-treegrid .e-gridheader .e-columnheader {
        display: none;
    }
</style>
```

N> If you want to hide the header for particular Tree Grid, then apply the above styles to that Tree Grid using the ID (#TreeGrid.e-treegrid .e-gridheader .e-columnheader) property value.

![Hiding Header in Blazor TreeGrid](../images/blazor-treegrid-hide-header.webp)
