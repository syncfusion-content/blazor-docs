---
layout: post
title: Customize placeholder style in Blazor RichTextEditor | Syncfusion
description: Learn here all about how to customize placeholder style in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Customize placeholder style in Blazor RichTextEditor Component

By using `e-rte-placeholder` class, you can customize the placeholder style.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor Placeholder="Type Something" />

<style>
    .e-richtexteditor .e-rte-placeholder {
        /* placeholder style */
        font-family: monospace;
        color: deeppink;
    }
</style>

```

![Customizing Placeholder Style in Blazor RichTextEditor](../images/blazor-richtexteditor-placeholder-style.png)