---
layout: post
title: Hide TreeGrid Header in Blazor TreeGrid Component | Syncfusion
description: Learn how to hide the header in the Syncfusion Blazor TreeGrid component using custom styles and more.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Hide TreeGrid Header in Syncfusion Blazor TreeGrid Component

The TreeGrid header can be hidden by applying custom CSS styles to the component. This approach is useful for presenting a cleaner layout or embedding the TreeGrid within a minimal user interface.

```html
<style>
    .e-treegrid .e-gridheader .e-columnheader {
        display: none;
    }
</style>
```

N> To hide the header for a specific TreeGrid instance, apply the above styles using its unique ID selector. For example:
```css
#TreeGrid.e-treegrid .e-gridheader .e-columnheader {
    display: none;
}
```

![Hiding Header in Blazor TreeGrid](../images/blazor-treegrid-hide-header.PNG)
