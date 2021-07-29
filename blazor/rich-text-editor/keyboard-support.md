---
layout: post
title: Keyboard support in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Keyboard support in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Keyboard support in Blazor RichTextEditor Component

The editor has full keyboard accessibility that includes shortcuts to open and other actions with toolbar items, drop-down lists, and dialogs.

## HTML formation shortcut key

You can use the following key shortcuts when the Rich Text Editor renders with `HTML` editMode.

| Actions | Keyboard shortcuts |
|----------------|---------|
| Toolbar focus | <kbd>`alt`</kbd> + <kbd>`f10`</kbd> |
| Insert link | <kbd>`ctrl`</kbd> + <kbd>`k`</kbd> |
| Insert image | <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`i`</kbd> |
| Insert table | <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`e`</kbd> |
| Undo | <kbd>`ctrl`</kbd> + <kbd>`z`</kbd> |
| Redo | <kbd>`ctrl`</kbd> + <kbd>`y`</kbd> |
| Copy | <kbd>`ctrl`</kbd> + <kbd>`c`</kbd> |
| Cut | <kbd>`ctrl`</kbd> + <kbd>`x`</kbd> |
| Paste| <kbd>`ctrl`</kbd> + <kbd>`v`</kbd> |
| Bold| <kbd>`ctrl`</kbd> + <kbd>`b`</kbd> |
| Italic| <kbd>`ctrl`</kbd> + <kbd>`i`</kbd> |
| Underline| <kbd>`ctrl`</kbd> + <kbd>`u`</kbd> |
| Strikethrough| <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`s`</kbd> |
| Uppercase| <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`u`</kbd> |
| Lowercase| <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`l`</kbd> |
| Superscript| <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`=`</kbd> |
| Subscript| <kbd>`ctrl`</kbd> + <kbd>`=`</kbd> |
| Indents| <kbd>`ctrl`</kbd> + <kbd>`]`</kbd> |
| Outdents| <kbd>`ctrl`</kbd> + <kbd>`[`</kbd> |
| HTML source | <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`h`</kbd> |
| Fullscreen| <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`f`</kbd> |
| Justify center| <kbd>`ctrl`</kbd> + <kbd>`e`</kbd> |
| Justify full | <kbd>`ctrl`</kbd> + <kbd>`j`</kbd> |
| Justify left | <kbd>`ctrl`</kbd> + <kbd>`l`</kbd> |
| Justify right | <kbd>`ctrl`</kbd> + <kbd>`r`</kbd> |
| Clear format | <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`r`</kbd> |
| Ordered list | <kbd>`ctrl`</kbd> + <kbd>`shift`</kbd> + <kbd>`o`</kbd> |
| Unordered list | <kbd>`ctrl`</kbd> + <kbd>`alt`</kbd> + <kbd>`o`</kbd> |

## Markdown formation shortcut key

You can use the following key shortcuts when the Rich Text Editor renders with `Markdown` editMode.

| Actions | Keyboard shortcuts |
|----------------|---------|
| Toolbar focus| <kbd>alt</kbd> + <kbd>f10</kbd> |
| Insert link| <kbd>ctrl</kbd> + <kbd>k</kbd> |
| Insert image| <kbd>ctrl</kbd> + <kbd>shift</kbd> + <kbd>i</kbd> |
| Insert table| <kbd>ctrl</kbd> + <kbd>shift</kbd> + <kbd>e</kbd> |
| Undo| <kbd>ctrl</kbd> + <kbd>z</kbd> |
| Redo| <kbd>ctrl</kbd> + <kbd>y</kbd> |
| Copy| <kbd>ctrl</kbd> + <kbd>c</kbd> |
| Cut| <kbd>ctrl</kbd> + <kbd>x</kbd> |
| Paste| <kbd>ctrl</kbd> + <kbd>v</kbd> |
| Bold| <kbd>ctrl</kbd> + <kbd>b</kbd> |
| Italic| <kbd>ctrl</kbd> + <kbd>i</kbd> |
| Strikethrough| <kbd>ctrl</kbd> + <kbd>shift</kbd> + <kbd>s</kbd> |
| Uppercase| <kbd>ctrl</kbd> + <kbd>shift</kbd> + <kbd>u</kbd> |
| Lowercase| <kbd>ctrl</kbd> + <kbd>shift</kbd> + <kbd>l</kbd> |
| Superscript| <kbd>ctrl</kbd> + <kbd>shift</kbd> + <kbd>=</kbd> |
| Subscript| <kbd>ctrl</kbd> + <kbd>=</kbd> |
| Fullscreen| <kbd>ctrl</kbd> + <kbd>shift</kbd> + <kbd>f</kbd> |
| Ordered list| <kbd>ctrl</kbd> + <kbd>shift</kbd> + <kbd>o</kbd> |
| Unordered list| <kbd>ctrl</kbd> + <kbd>alt</kbd> + <kbd>o</kbd> |

```csharp

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EditorMode="EditorMode.Markdown">
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
    <p><b> Key features:</b></p>
    <ul>
    <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
    <li><p> Capable of handling markdown editing.</p></li>
    <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
    <li><p> Provides a fully customizable toolbar.</p></li><li><p> Provides HTML view to edit the source directly for developers.</p></li>
    <li><p> Supports third - party library integration.</p></li>
    <li><p> Allows preview of modified content before saving it.</p></li>
    </ul>
</SfRichTextEditor>

```

The output will be as follows.

![Keyconfig](./images/markdown-key.png)

## Custom key config

Customize the key config for the keyboard interaction of Rich Text Editor, using the `KeyConfigure` property.

In the following code block, customize the bold and italic, toolbar actions with `ctrl+1`, `ctrl+2` respectively.

```csharp

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor KeyConfigure="@KeyConfig">
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
    <p><b> Key features:</b></p>
    <ul>
    <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
    <li><p> Capable of handling markdown editing.</p></li>
    <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
    <li><p> Provides a fully customizable toolbar.</p></li>
    <li><p> Provides HTML view to edit the source directly for developers.</p></li>
    <li><p> Supports third - party library integration.</p></li>
    <li><p> Allows preview of modified content before saving it.</p></li>
    </ul>
</SfRichTextEditor>

@code {
    private ShortcutKeys KeyConfig = new ShortcutKeys()
    {
        Bold = "ctrl+1",
        Italic = "ctrl+2"
    };
}

```

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.

## See Also

* [Globalization](./globalization/)
* [Accessibility](./accessibility/)