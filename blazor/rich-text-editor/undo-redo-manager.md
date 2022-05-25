---
layout: post
title: Undo Redo Manager in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Toolbar in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

## Undo Redo Manager

Undo and redo tools allows to edit the text by disregard or cancel the recently made changes and restore it to previous state. It is a useful tool to restore the performed action which got changed by mistake. By default, upto 30 actions can be undo/redo in the editor.

To undo and redo operations, do one of the following:

* Press the undo/redo button on the toolbar
* Press the Ctrl + Z/Ctrl + Y combination on the keyboard

Customize the undo/redo step count using [`UndoRedoSteps`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_UndoRedoSteps) property. By default, undo/redo actions take `300ms` time interval for storing the action to the undo redo manager. The time interval can be customized by using the [`UndoRedoTimer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_UndoRedoTimer).

{% tabs %}
{% highlight razor tabtitle="~/undo-redo.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor UndoRedoSteps="50" UndoRedoTimer="400">
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
    <p><b> Key features:</b></p>
    <ul>
    <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
    <li><p> Capable of handling markdown editing.</p></li>
    </ul>
</SfRichTextEditor>

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/undo-redo.razor %}

{% endhighlight %}

![Undo Redo Operation in Blazor RichTextEditor](./images/blazor-richtexteditor-undo-redo-operation.png)
