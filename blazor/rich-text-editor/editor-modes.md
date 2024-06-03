---
layout: post
title: Editor Modes in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Editor Modes in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Editor Modes in Blazor RichTextEditor Component

The [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) component is used to create and edit the content and return valid HTML markup or markdown (MD) of the content. It supports the following two editing formations:

* HTML Editor
* Markdown Editor

## HTML editor

Rich Text Editor is a [WYSIWYG Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) component for formatting the word content as HTML. The HTML editing mode is the default mode in Rich Text Editor to format the content through the available toolbar items to return the valid HTML markup. Set the `EditorMode` property to `HTML`.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EditorMode="EditorMode.HTML" >
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
    <p><b> Key features:</b></p>
    <ul>
    <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
    <li><p> Capable of handling markdown editing.</p></li>
    <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
    <li><p> Provides a fully customizable toolbar.</p></li>
    <li><p> Provides HTML view to edit the source directly for developers.</p></li>
    <li><p> Supports third - party library integration.</p></li>
    </ul>
</SfRichTextEditor>

```

![Blazor RichTextEditor with HTML Editor](./images/blazor-richtexteditor-with-html-editor.png)

## Markdown editor

Set the `EditorMode` property to `Markdown` to create or edit the content and apply formatting to view markdown formatted content. The third-party library such as `Marked` or any other library is used to convert markdown into HTML content.

* The Supported Tags are  `h6`,`h5`,`h4`,`h3`,`h2`,`h1`,`blockquote`,`pre`,`p`,`OL`,`UL`.
* The Supported Selection Tags are `Bold`, `Italic`, `StrikeThrough`, `InlineCode`, `SubScript`, `SuperScript`, `UpperCase` and `LowerCase`.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EditorMode="EditorMode.Markdown" >
    ***Overview***The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor used to create and edit the content and return valid HTML markup or markdown (MD) of the content. The editor provides a standard toolbar to format content using its commands. Modular library features to load the necessary functionality on demand. The toolbar contains commands to align the text, insert link, insert image, insert list, undo/redo operation, HTML view, and more.
    ***Key features***
    *Mode*: Provides IFRAME and DIV mode.
    *Module*: Modular library to load the necessary functionality on demand.
    *Toolbar*: Provide a fully customizable toolbar.
    *Editing*: HTML view to edit the source directly for developers.
    *Third-party Integration*: Supports to integrate third-party library.
    *Preview*: Preview the modified content before saving it.
    *Tools*: Handling images, hyperlinks, video, uploads and more.
    *Undo and Redo*: Undo/redo manager.
    *Lists*:Creates bulleted and numbered list
</SfRichTextEditor>

```

![Blazor RichTextEditor with Markdown Editor](./images/blazor-richtexteditor-markdown-editor.png)

For further details on Markdown editing, refer to the [Markdown](./markdown/) section.

N> You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) example to know how to render and configure the rich text editor tools.

## See also

* [How to render the iframe](./iframe)