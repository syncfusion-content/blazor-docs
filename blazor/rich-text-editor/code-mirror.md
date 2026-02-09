---
layout: post
title: Code Mirror in Blazor RichTextEditor Component | Syncfusion
description: Learn how to integrate CodeMirror with the Syncfusion Blazor Rich Text Editor to enable advanced code editing, syntax highlighting, and formatting.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Code Mirror Integration in Blazor Rich Text Editor Component

The Syncfusion Blazor Rich Text Editor includes a built‑in HTML source editor through the view-source option, enabling users to view and modify the underlying markup. To enhance this source editing experience, the Code Mirror plugin can be integrated with the editor.

This guide explains how to integrate Code Mirror with the Syncfusion Blazor RichTextEditor to provide a seamless workflow that combines visual WYSIWYG editing with a rich, syntax‑highlighted HTML source editor.

## Prerequisites

Before proceeding, ensure you have completed the basic Rich Text Editor setup as outlined in the Getting Started guide. This includes configuring the Blazor project, installing the required packages, importing the necessary CSS files, injecting the modules, and adding the basic editor markup.

Refer to the guide here: [Getting Started with Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app).

## Key features

- Replace the Rich Text Editor source textarea with a Code Mirror Editor View.  
- Preserve editor undo/redo by inserting source changes via the Rich Text Editor APIs.

## Step 1: Set up the Code Mirror 

Install the required code mirror packages using the following command:

```bash
npm install codemirror
```

## Step 2: Add the JavaScript Interop File
 
Create the JavaScript interop module to handle communication between Blazor and Code Mirror.
 
### 2.1 Set up the Code Mirror interop file
 
In your Blazor project, create a new folder named `wwwroot/scripts/` and add a file called `code-mirror.js` to include the code shown below,

{% tabs %}
{% highlight javascript %}

{% include_relative code-snippet/code-mirror.js %}

{% endhighlight %}
{% endtabs %}
 
### 2.2 Verify file placement
 
Ensure the file is located at:
 
```
YourProject/
└── wwwroot/
    └── scripts/
        └── code-mirror.js
```

## Step 3: Add Script Reference in Host Page

Add the script references in your host page before the closing `</body>` tag:
 
```html
<body>
    ...
     <!-- CodeMirror core CSS -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.65.2/codemirror.min.css" rel="stylesheet" />

    <!-- CodeMirror theme (Monokai) -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.65.2/theme/monokai.min.css" rel="stylesheet" />

    <!-- CodeMirror core JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.65.2/codemirror.min.js"></script>

    <!-- CodeMirror language modes -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.65.2/mode/css/css.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.65.2/mode/xml/xml.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.65.2/mode/htmlmixed/htmlmixed.min.js"></script>
    <!--Interop file-->
    <script src="/scripts/code-mirror.js"></script>
    ...
</body>
```

> The host page location varies by project type. Refer to the [RichTextEditor Getting Started](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started) guide for the correct host page file path.
>
> **Note:** The Code Mirror CDN script must be loaded before the custom interop file to ensure proper functionality.

## Step 4: Create the Razor Component

Create a new Razor component file named **`RichTextEditorWithCodeMirror.razor`** in your **Pages** directory:

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/code-mirror.razor %}

{% endhighlight %}
{% endtabs %}

## How to Use the Integration

Once Code Mirror is integrated with the Rich Text Editor, you can begin using the enhanced source‑editing experience immediately:

- Switch to Source Mode
  Click the `Source Code` toolbar option in the Rich Text Editor to open the Code Mirror interface.

- Edit HTML with Syntax Highlighting
  The embedded Code Mirror editor provides syntax highlighting, line numbers, and theme support.

- Return to WYSIWYG Mode
  When switching back to Preview or Normal mode, Code Mirror content is synchronized with the editor's main view.

## See also

* [Rich Text Editor documentation](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started)
* [Rich Text Editor events](https://blazor.syncfusion.com/documentation/rich-text-editor/events)
* [Code Mirror Developer Documentation](https://codemirror.net/)
