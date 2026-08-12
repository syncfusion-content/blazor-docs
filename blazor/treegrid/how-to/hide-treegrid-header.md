---
layout: post
title: Blazor TreeGrid Hide Header | Syncfusion
description: Learn how to hide the header in Blazor TreeGrid to simplify layouts, customize grid appearance, and improve user experience.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Hide Header in Blazor TreeGrid

 The TreeGrid header can be hidden by applying the below styles to TreeGrid component.

```html
<style>
    .e-treegrid .e-gridheader .e-columnheader {
        display: none;
    }
</style>
```

N> To hide the header for a particular TreeGrid, apply the above styles to that TreeGrid using the ID selector (#TreeGrid.e-treegrid .e-gridheader .e-columnheader).

![Hiding Header in Blazor TreeGrid](../images/blazor-treegrid-hide-header.webp)
