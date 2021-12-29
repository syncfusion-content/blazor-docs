---
layout: post
title: Enter and Shift-Enter Key's Customization in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about the enter key and shift + enter key customization feature in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Enter and Shift-Enter Key's Customization in Blazor RichTextEditor Component

The Rich Text Editor allows to customize the tag that is inserted when pressing the enter key and shift + enter key in the Rich Text Editor.

## Enter key customization

By default, the `<p>` tag will be created while pressing the enter key. The enter key can be customized by using the [EnterKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnterKey) property, where the possible tags that can be used to customize are `<p>`, `<div>`, and `<br>`.

When the enter key is customized with any of the possible values, pressing the enter key in the editor will create a new tag that is configured. Also, when the enter key is configured the default value of the Rich Text Editor will change respectively with the configured values when the Rich Text Editor content is empty.

```csharp

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnterKey="EnterKeyTag.DIV">
    <div>In Rich text Editor, the enter key and shift + enter key actions can be customized using the EnterKey and ShiftEnterKey properties.</div>
</SfRichTextEditor>

```

> You can refer to our [Blazor Enter Key Configuration](https://blazor.syncfusion.com/demos/rich-text-editor/enterkeyconfiguration) feature sample.

## Shift-Enter key customization

By default, the `<br>` tag will be created while pressing the shift + enter key. The shift + enter key can be customized by using the [ShiftEnterKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_ShiftEnterKey) property where the possible tags that can be used to customize are `<br>`, `<p>`, and `<div>`.

When the shift + enter key is customized with any of the possible values, pressing the shift + enter key in the editor will create a new tag that is configured.

```csharp

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor ShiftEnterKey="ShiftEnterKeyTag.DIV">
    <div>In Rich text Editor, the enter key and shift + enter key actions can be customized using the EnterKey and ShiftEnterKey properties.</div>
</SfRichTextEditor>

```

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.