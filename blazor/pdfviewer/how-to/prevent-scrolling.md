---
Layout: Post
Title: Prevent the PDF from scrolling | Syncfusion
Description: Learn how to prevent a PDF from scrolling, remove the vertical scrollbar in the Syncfusion Blazor PDF Viewer component, and more.
Platform: Blazor
Control: PDF Viewer
Documentation: ug
--- 

# Prevent the PDF from scrolling and remove the vertical scrollbar

To prevent a PDF from scrolling and remove the vertical scroll bar in the Syncfusion Blazor PDF Viewer component, use CSS to set the `overflow` property of the component container to` hidden`.

By setting the overflow property to hidden, the PDF viewer component will be displayed without a vertical scrollbar, and the user will not be able to scroll the content of a PDF.

```html
<style>
    .e-pv-viewer-container {
        overflow: hidden !important;
    }
</style>
```

[View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/BLAZ-28848-preventScroll/Common/Prevent%20the%20PDF%20from%20scrolling)