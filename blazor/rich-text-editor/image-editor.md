---
layout: post
title: Image Editor Integration with RichTextEditor Component | Syncfusion
description: Checkout and learn how to integrate the Syncfusion Image Editor with Blazor RichTextEditor to edit images directly within the content.
platform: Blazor
control: RichTextEditor
documentation: ug
---
 
# Image Editor Integration with RichTextEditor
 
The Blazor [RichTextEditor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) component can be enhanced with [ImageEditor](https://www.syncfusion.com/blazor-components/blazor-image-editor) capabilities to allow users to edit images directly within the editor content. This integration enables inline image editing, such as cropping, applying filters, rotating, and adding annotations without leaving the editor interface.
 
## Overview
 
This documentation provides a complete integration of the Syncfusion Image Editor with the RichTextEditor component. Users can:
 
- Upload or insert an image directly into the RichTextEditor content
- Select an image within the editor
- Click the "Edit Image" toolbar button to open an image editing dialog
- Edit the image using various tools (crop, zoom, filter, annotate, fine-tune)
- Replace the original image with the edited version
 
## Prerequisites
 
- **Syncfusion.Blazor NuGet package** installed and configured
- **Required namespaces:**
  - `Syncfusion.Blazor.RichTextEditor`
  - `Syncfusion.Blazor.ImageEditor`
  - `Syncfusion.Blazor.Popups`
- **JavaScript interop enabled** — `IJSRuntime` support
- **Host page access** for script references
 
> Before integrating Image Editor with RichTextEditor, refer to the [RichTextEditor Getting Started](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started) documentation for initial setup.
 
## Step 1: Add SignalR Configuration to Program.cs
 
After following the RichTextEditor Getting Started guide, add the SignalR configuration to your `Program.cs` file to handle large image data transmission during image editing:
 
**Add this line to your Program.cs:**
 
```csharp
using Microsoft.AspNetCore.SignalR;
 
builder.Services.Configure<HubOptions>(o => o.MaximumReceiveMessageSize = 1024 * 1024);
```
 
This line should be added after your existing Syncfusion service registration:
 
```csharp
builder.Services.AddSyncfusionBlazor();
builder.Services.Configure<HubOptions>(o => o.MaximumReceiveMessageSize = 1024 * 1024);
```
 
> The `MaximumReceiveMessageSize` configuration allows large image data to be transmitted through SignalR when editing and saving large images. The default value is 32 KB, which may be insufficient for large images.
 
## Step 2: Add the JavaScript Interop File
 
Create the JavaScript interop module to handle file selection and communication between Blazor and the Image Editor.
 
### 2.1 Create the interop file
 
In your Blazor project, create a new folder `wwwroot/scripts/` and add a file named `rte-imageeditor-interop.js`.
 
Copy the complete interop implementation from:
 
{% highlight javascript %}
{% include_relative code-snippet/image-editor-interop.js %}
{% endhighlight %}
 
### 2.2 Verify file placement
 
Ensure the file is located at:
 
```
YourProject/
└── wwwroot/
    └── scripts/
        └── rte-imageeditor-interop.js
```
 
## Step 3: Add Script Reference in Host Page
 
Add the script reference in your host page before the closing `</body>` tag:
 
```html
<body>
    ....
    <script src="/scripts/rte-imageeditor-interop.js"></script>
</body>
```
 
> The host page location varies by project type. Refer to the [RichTextEditor Getting Started](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started) guide for the correct host page file path.
 
## Step 4: Create the Razor Component
 
In your Blazor project's `Pages` folder, create a new file: `ImageEditorIntegration.razor`
 
Copy the complete component implementation from:
 
{% highlight cshtml %}
{% include_relative code-snippet/image-editor-integration.razor %}
{% endhighlight %}
 
## How to Use the Integration
 
1. **Navigate to the component** — Open the page where you created the component (e.g., `/imageeditorintegration`)
2. **Insert an image** — Use the RichTextEditor's image tool to insert an image
3. **Select and edit** — Click on the image to select it, then click the "Edit Image" button
4. **Use image tools** — Crop, rotate, filter, annotate, or fine-tune the image as needed
5. **Save changes** — Click "Insert" to replace the original image with the edited version
 
## See also
 
* [Image support in RichTextEditor](https://blazor.syncfusion.com/documentation/rich-text-editor/image)
* [Rich Text Editor documentation](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started)
* [Image Editor documentation](https://blazor.syncfusion.com/documentation/image-editor/getting-started)
* [Dialog documentation](https://blazor.syncfusion.com/documentation/dialog/getting-started)
Getting Started with Rich Text Editor in Blazor | Syncfusion
Checkout and learn about getting started with the Rich Text Editor in Blazor WebAssembly Application.