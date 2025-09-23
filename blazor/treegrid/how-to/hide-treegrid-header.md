---
layout: post
title: Hide TreeGrid Header in Blazor TreeGrid Component | Syncfusion
description: Learn how to hide the header in the Syncfusion Blazor TreeGrid component using custom styles.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Hide TreeGrid Header in Syncfusion Blazor TreeGrid Component

You can hide the TreeGrid header by applying custom CSS styles to the component. This approach is useful when you want to present a cleaner layout or embed the Tree rid in a minimal UI.

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
