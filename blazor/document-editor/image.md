---
layout: post
title: Images in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about Images in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Images in Blazor DocumentEditor Component

[Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) supports common raster format images like PNG, BMP, JPEG, and GIF. You can insert an image file or online image in the document using the `InsertImage()` method.

```csharp
documentEditor.Editor.InsertImage("<<base64String>>");
```

Image files will be internally converted to base64 string. Whereas, online images are preserved as URL.

## Image resizing

Document editor provides built-in image resizer that can be injected into your application based on the requirements. This allows you to resize the image by dragging the resizing points using mouse or touch interactions. This resizer appears as follows.

![Image Resizing in Blazor DocumentEditor](images/blazor-document-editor-image-resizing.jpeg)

## Changing size

Document editor expose API to get or resize the selected image. Refer to the following sample code.

```csharp
int height = await documentEditor.Selection.ImageFormat.GetHeight();
int width = await documentEditor.Selection.ImageFormat.GetWidth();
documentEditor.Selection.ImageFormat.Resize(width + 10, height + 10);
```

## Text wrapping style

Text wrapping refers to how images fit with surrounding text in a document. Please [refer to this page](../document-editor/text-wrapping-style) for more information about text wrapping styles available in Word documents.

## Positioning the image

DocumentEditor preserves the position properties of the image and displays the image based on position properties. It does not support modifying the position properties. Whereas the image will be automatically moved along with text edited if it is positioned relative to the line or paragraph.

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.
