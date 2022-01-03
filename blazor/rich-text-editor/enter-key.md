---
layout: post
title: Enter and Shift-Enter Key Tag Customization in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about the enter key and shift + enter key customization feature in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Enter and Shift-Enter Key's Customization in Blazor RichTextEditor

The Rich Text Editor allows to customize the tag that is inserted when pressing the <kbd>enter</kbd> key and <kbd>shift</kbd> + <kbd>enter</kbd> key in the Rich Text Editor.

## Enter key customization

By default, the `<p>` tag is created while pressing the <kbd>enter</kbd> key. The tag created while pressing <kbd>enter</kbd> key can be customized by using the [EnterKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnterKey) property. The possible tags that can be used to customize the <kbd>enter</kbd> key are `<p>`, `<div>`, and `<br>`.

When the <kbd>enter</kbd> key is customized with any of the above possible values, pressing the <kbd>enter</kbd> key in the editor will create a new tag that is configured. Also, when the <kbd>enter</kbd> key is configured, the default value of the Rich Text Editor will change respectively with the configured values when the Rich Text Editor content is empty.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnterKey="EnterKeyTag.DIV">
    <div>In Rich text Editor, the <kbd>enter</kbd> key and <kbd>shift</kbd> + <kbd>enter</kbd> key actions can be customized using the EnterKey and ShiftEnterKey properties.</div>
</SfRichTextEditor>

```

> [Blazor Enter Key Configuration Demo](https://blazor.syncfusion.com/demos/rich-text-editor/enterkeyconfiguration)

## Shift-Enter key customization

By default, the `<br>` tag is created while pressing the <kbd>shift</kbd> + <kbd>enter</kbd> key. <kbd>shift</kbd> + <kbd>enter</kbd> key can be customized by using the [ShiftEnterKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_ShiftEnterKey) property. The possible tags that can be used to customize the <kbd>shift</kbd> + <kbd>enter</kbd> key are `<br>`, `<p>`, and `<div>`.

When the <kbd>shift</kbd> + <kbd>enter</kbd> key is customized with any of the possible values, pressing the <kbd>shift</kbd> + <kbd>enter</kbd> key in the editor will create a new tag that is configured.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor ShiftEnterKey="ShiftEnterKeyTag.DIV">
    <div>In Rich text Editor, the <kbd>enter</kbd> key and <kbd>shift</kbd> + <kbd>enter</kbd> key actions can be customized using the EnterKey and ShiftEnterKey properties.</div>
</SfRichTextEditor>

```

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.