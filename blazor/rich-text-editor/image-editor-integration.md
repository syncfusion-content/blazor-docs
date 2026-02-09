---
layout: post
title: Image Editor Integration with Rich Text Editor Component | Syncfusion
description: Checkout and learn how to integrate the Syncfusion Image Editor with Blazor Rich Text Editor to edit images directly within the content.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Image Editor Integration with Rich Text Editor

The Blazor [Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) component can be enhanced with [Image Editor](https://www.syncfusion.com/blazor-components/blazor-image-editor) capabilities to allow users to edit images directly within the editor content. This integration enables inline image editing, such as cropping, applying filters, rotating, and adding annotations without leaving the editor interface.

## Overview

This documentation provides a complete integration of the Syncfusion Image Editor with the Rich Text Editor component. Users can:

- Select or upload an image in the editor content
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

> Before integrating Image Editor with Rich Text Editor, refer to the [Rich Text Editor Getting Started](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started) documentation for initial setup.

## Step 1: Add SignalR Configuration to Program.cs

After following the Rich Text Editor Getting Started guide, add the SignalR configuration to your `Program.cs` file to handle large image data transmission during image editing:

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

In your Blazor project, create a new folder `wwwroot/scripts/` and add a file named `rte-image-editor-interop.js`.

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
<script src="/scripts/rte-imageeditor-interop.js"></script>
</body>
```

> The host page location varies by project type. Refer to the [Rich Text Editor Getting Started](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started) guide for the correct host page file path.

## Step 4: Create the Razor Component

In your Blazor project's `Pages` folder, create a new file: `ImageEditorIntegration.razor`

Copy the complete component implementation from:

{% highlight cshtml %}
{% include_relative code-snippet/image-editor-integration.razor %}
{% endhighlight %}

## How to Use the Integration

1. **Navigate to the component** — Open the page where you created the component (e.g., `/image-editor-integration`)
2. **Select or upload an image** — Select an existing image from the editor content or upload a new image using the Rich Text Editor’s image tool
3. **Select and edit** — Click on the image to select it, then click the "Edit Image" button
4. **Use image tools** — Crop, rotate, filter, annotate, or fine-tune the image as needed
5. **Save changes** — Click "Insert" to replace the original image with the edited version

## See also

* [Image support in Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/image)
* [Rich Text Editor documentation](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started)
* [Image Editor documentation](https://blazor.syncfusion.com/documentation/image-editor/getting-started)
* [Dialog documentation](https://blazor.syncfusion.com/documentation/dialog/getting-started)