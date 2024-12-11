---
layout: post
title: Prevent the PDF from scrolling | Syncfusion
description: Learn here all about Create PDF Viewer in a popup window in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Prevent the PDF from scrolling and remove the vertical scrollbar

<<<<<<< HEAD
To prevent a PDF from scrolling and remove the vertical scroll bar in the Syncfusion&reg; Blazor PDF Viewer component, use CSS to set the `overflow` property of the component container to `hidden`.
=======
To prevent a PDF from scrolling and remove the vertical scroll bar in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer component, use CSS to set the `overflow` property of the component container to `hidden`.
>>>>>>> remotes/origin/hotfix/hotfix-v27.2.2

By setting the overflow property to hidden, the PDF viewer component will be displayed without a vertical scrollbar, and the user will not be able to scroll the content of a PDF.

```html
<style>
    .e-pv-viewer-container {
        overflow: hidden !important;
    }
</style>
```

[View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/BLAZ-28848-preventScroll/Common/Prevent%20the%20PDF%20from%20scrolling)