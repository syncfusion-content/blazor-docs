---
layout: post
title: Built-in tools in Blazor Rich Text Editor Component | Syncfusion
description: Checkout and learn here all about built-in tools in Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Overview of Built-in Tools in Blazor Rich Text Editor

To initialize the tools, use the following code. You can change the tool's name as per your requirements. For your reference, here is the `bold` tool initialized.

{% tabs %}
{% highlight razor %}

private List<ToolbarItemModel> Items = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold }
    } 

{% endhighlight %}
{% endtabs %}

The following table lists the tools available in the toolbar.

<table>
<tr>
<td><b>Name</b></td>
<td><b>Icons</b></td>
<td><b>Summary</b></td>
</tr>

<tr>
<td><p>Undo</p></td>
<td><img alt= "Undo in Blazor RichTextEditor" src="../images/undo.png"></td>
<td><p>Allows you to undo the actions.</p></td>
</tr>

<tr>
<td><p>Redo</p></td>
<td><img alt= "Redo in Blazor RichTextEditor" src="../images/redo.png"></td>
<td><p>Allows you to redo the actions.</p></td>
</tr>

<tr>
<td><p>Alignment</p></td>
<td><img alt= "Alignment in Blazor RichTextEditor" src="../images/alignments.png"></td>
<td><p>Aligns the content with the left, center, and right margins.</p></td>
</tr>

<tr>
<td><p>OrderedList</p></td>
<td><img alt= "Ordered list in Blazor RichTextEditor" src="../images/order-list.png"></td>
<td><p>Creates a new list item(numbered).</p></td>
</tr>

<tr>
<td><p>UnorderedList</p></td>
<td><img alt= "Unordered list in Blazor RichTextEditor" src="../images/unorder-list.png"></td>
<td><p>Creates a new list item(bulleted).</p></td>
</tr>

<tr>
<td><p>Indent</p></td>
<td><img alt= "Indent in Blazor RichTextEditor" src="../images/increase-indent.png"></td>
<td><p>Allows you to increase the content's indentation level. </p></td>
</tr>

<tr>
<td><p>Outdent</p></td>
<td><img alt= "Outdent in Blazor RichTextEditor" src="../images/decrease-indent.png"></td>
<td><p>Allows you to decrease the content's indentation level.</p></td>
</tr>

<tr>
<td><p>Hyperlink</p></td>
<td><img alt= "Hyperlink in Blazor RichTextEditor" src="../images/create-link.png"></td>
<td><p>Creates a hyperlink from a text or image to a specific location in the content.</p></td>
</tr>

<tr>
<td><p>Images</p></td>
<td><img alt= "Images in Blazor RichTextEditor" src="../images/insert-image.png"></td>
<td><p>Inserts an image from an online source or local computer.</p></td>
</tr>

<tr>
<td><p>LowerCase</p></td>
<td><img alt= "Lower case in Blazor RichTextEditor" src="../images/lower-case.png"></td>
<td><p>Changes the selected content to lowercase.</p></td>
</tr>

<tr>
<td><p>UpperCase</p></td>
<td><img alt= "Uppercase in Blazor RichTextEditor" src="../images/upper-case.png"></td>
<td><p>Changes the selected content to uppercase.</p></td>
</tr>

<tr>
<td><p>SubScript</p></td>
<td><img alt= "Sub script in Blazor RichTextEditor" src="../images/sub-script.png"></td>
<td><p> Formats the selected text as subscript (lower).</p></td>
</tr>

<tr>
<td><p>SuperScript</p></td>
<td><img alt= "Super script in Blazor RichTextEditor" src="../images/super-script.png"></td>
<td><p> Formats the selected text as superscript (higher).</p></td>
</tr>

<tr>
<td><p>Print</p></td>
<td><img alt= "Print in Blazor RichTextEditor" src="../images/print.png"></td>
<td><p>Allows the editor's content to be printed. </p></td>
</tr>

<tr>
<td><p>FontName</p></td>
<td><img alt= "Font name in Blazor RichTextEditor" src="../images/font-name.png"></td>
<td><p>Defines the fonts that appear in the Rich Text Editor's Font Family DropDownList.</p></td>
</tr>

<tr>
<td><p>FontSize</p></td>
<td><img alt= "Font size in Blazor RichTextEditor" src="../images/font-size.png"></td>
<td><p>Defines the font sizes that appear under the Font Size DropDownList from the Rich Text Editor's toolbar.</p></td>
</tr>

<tr>
<td><p>FontColor</p></td>
<td><img alt= "Font color in Blazor RichTextEditor" src="../images/font-color.png"></td>
<td><p>Specifies an array of colors that can be used in the color popup for the font color.</p></td>
</tr>

<tr>
<td><p>BackgroundColor</p></td>
<td><img alt= "Background color in Blazor RichTextEditor" src="../images/background-color.png"></td>
<td><p>Specifies an array of colors that can be used in the color popup for the background color.</p></td>
</tr>

<tr>
<td><p>Format</p></td>
<td><img alt= "Format in Blazor RichTextEditor" src="../images/formats.png"></td>
<td><p>An Object with the options that will appear in the Paragraph Format dropdown from the toolbar.</p></td>
</tr>

<tr>
<td><p>Blockquote</p></td>
<td><img alt= "Blockquote in Blazor RichTextEditor" src="../images/blockquote.png"></td>
<td><p>Blockquotes visually highlight important text within an editor, emphasizing key information or quotations.</p></td>
</tr>

<tr>
<td><p>StrikeThrough</p></td>
<td><img alt= "Strike through in Blazor RichTextEditor" src="../images/strikethrough.png"></td>
<td><p>Applies double line strike through formatting for the selected text.</p></td>
</tr>

<tr>
<td><p>ClearFormat</p></td>
<td><img alt= "Clear format in Blazor RichTextEditor" src="../images/clear-format.png"></td>
<td><p>The clear format tool is useful for removing all formatting styles from currently selected text, such as bold, italic, underline, color, superscript, subscript, and more. As a result, all the text formatting will be cleared and returned to its default styles.</p></td>
</tr>

<tr>
<td><p>FullScreen</p></td>
<td><img alt= "Full screen in Blazor RichTextEditor" src="../images/maximize.png"></td>
<td><p>Stretches the editor to the maximum width and height of the browser window.</p></td>
</tr>

<tr>
<td><p>SourceCode</p></td>
<td><img alt= "Source code in Blazor RichTextEditor" src="../images/code-view.png"></td>
<td><p>Allows users to toggle between design view and HTML source view. Changes made in source view are synchronized with the design view.</p></td>
</tr>

<tr>
<td><p>NumberFormatList</p></td>
<td><img alt= "Number format list in Blazor RichTextEditor" src="../images/number-format.png"></td>
<td><p>Allows to create list items with various list style types(numbered). </p></td>
</tr>

<tr>
<td><p>BulletFormatList</p></td>
<td><img alt= "Bullet format list in Blazor RichTextEditor" src="../images/bullet-format.png"></td>
<td><p>Allows to create list items with various list style types(bulleted).</p></td>
</tr>

<tr>
<td><p>HorizontalLine</p></td>
<td><img alt= "Horizontal Line in Blazor RichTextEditor" src="../images/horizontal-icon.png"></td>
<td><p>Horizontal lines visually separate sections of content in the editor, enhancing readability and layout clarity.</p></td>
</tr>
</table>

Users can customize the order of toolbar tools to suit your application's requirements. If you are not specifying any tools order, the editor will create the toolbar with default items.

## How to remove built-in tool from toolbar

Remove the built-in tools from the toolbar by using the [RichTextEditorToolbarSettings.Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_Items) property.

{% tabs %}
{% highlight razor %}

<SfRichTextEditor>
    <RichTextEditorToolbarSettings Items="@Tools" />
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
</SfRichTextEditor>

@code {
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.FontName },
        new ToolbarItemModel() { Command = ToolbarCommand.FontSize },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable },
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo }
    };
}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor removed default toolbar items](../images/blazor-richtexteditor-removed-default-toolbar-items.png)
