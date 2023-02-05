---
layout: post
title: Prevent the PDF from scrolling and remove the vertical scrollbar | Syncfusion
description: Learn here all about how to prevent the PDF from scrolling and remove the vertical scrollbar in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Prevent the PDF from scrolling and remove the vertical scrollbar

To prevent the PDF from scrolling and remove the vertical scroll bar in the Syncfusion Blazor PDF Viewer component, you can use CSS to set the `overflow` property of the component container to `hidden`.

By setting the overflow property to hidden, the PDF viewer component will be displayed without a vertical scrollbar and the user will not be able to scroll the content of the PDF.

```html
<style>
    .e-pv-viewer-container {
        overflow: hidden !important;
    }
</style>
```

[View Sample in GitHub]()