---
layout: post
title: Optimize PDF Scrolling with the OverscanCount | Syncfusion
description: Learn here all about OverscanCount in Blazor application in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Optimize PDF Scrolling with the OverscanCount

The [OverscanCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_OverscanCount) feature in a PDF Viewer allows users to preload a specified number of pages before and after the visible view port when opening a PDF document, thereby enhance the scrolling experience.
 
To utilize this capability in Syncfusion PDF Viewer, adjust the OverscanCount property. By setting this property to a desired number, users can preload pages adjacent to the active page. This ensures quicker access to specific pages without waiting for the entire document to load.

Below is a code snippet illustrating how to implement the OverscanCount:

```cshtml

<SfPdfViewer2 DocumentPath="https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf"
              Height="100%"
              Width="100%" OverscanCount="10">
</SfPdfViewer2>
    
```
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Load%20OverscanCount).
