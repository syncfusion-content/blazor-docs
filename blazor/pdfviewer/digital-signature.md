---
layout: post
title: Digital Signature appearance in Blazor PDF Viewer | Syncfusion
description: Checkout and learn here all about digital signature appearance in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Digital Signature appearance in Blazor PDF Viewer Component

The PDF Viewer control provides the appearance support for digital signature. If a PDF file that has a digital signature is loaded in the PDF Viewer, the digital signature will show up as an image. Using the 'ShowDigitalSignatureAppearance' API, you may choose whether the digital signature should be seen in the document when loading it into the PDF Viewer or not. By default, it is true. By default, it is true.

![Digital Signature appearance](../pdfviewer/images/blazor-pdfviewer-digital-sign.png)

The following code explains how to disable the ShowDigitalSignatureAppearance in the PDF Viewer.

```cshtml
<SfPdfViewer @ref="viewer"
             ID="pdfviewer"
             ShowDigitalSignatureAppearance="false">
</SfPdfViewer>
```

![Digital Signature without appearance](../pdfviewer/images/blazor-pdfviewer-digital-sign-false.png)
