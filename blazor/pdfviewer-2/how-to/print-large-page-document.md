---
layout: post
title: Print large page document in SfPdfViewer | Syncfusion
description: Learn how to efficiently print large page documents using the SfPdfViewer with optimized memory usage and custom toolbar actions
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Print large page documents in SfPdfViewer component in Blazor

This guide demonstrates how to implement a custom printing solution for large PDF documents in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SfPdfViewer component.

### Implement Print Handler
Add a custom print toolbar item to the primary toolbar of the SfPdfViewer, and implement a click handler to handle its functionality. The handler retrieves the byte array of the loaded PDF document and invokes a JavaScript function to print the PDF on the client-side.

```cshtml
private async Task ClickAction(ClickEventArgs Item)
{
    if (Item.Item.Id == "print" && Viewer != null)
    {
        //get the byte array of loaded PDF
        byte[] bytes = await Viewer.GetDocumentAsync();

        //send the byte array to client
        await JSRuntime.InvokeVoidAsync("printPDF", bytes);
    }
}

```

### Add JavaScript Function
Add a `printPDF` function to your JavaScript file that converts the byte array into a Blob object and generates a Blob URL for the loaded PDF. The Blob URL is then used to open the PDF in a new tab or trigger the print dialog.

```javascript
// Convert the byte array to a Blob object
const blob = new Blob([byteArray], { type: 'application/pdf' });
// Generate a Blob URL for the loaded PDF
const blobUrl = URL.createObjectURL(blob);
```
The Blob URL is opened in a new browser window or tab, and the native window.print() function is called to execute the print operation.

```javascript
// Open the Blob URL in a new window or tab
const printWindow = window.open(blobUrl, '_blank');
// open the print window of browser
const tryPrint = () => {
    printWindow.focus();
    printWindow.print();
};
```

>N> Ensure that users have pop-ups enabled for your site in their browser settings, as this solution opens the PDF in a new window or tab for printing.
![Allow pop-up for large page print window](../../pdfviewer-2/images/allow-popup-largepage-print.png)

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Print/Print%20Large%20page%20document).

## See also

* [Primary Toolbar Customization in SfPdfViewer](../toolbar-customization)