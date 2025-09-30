---
layout: post
title: ExecuteCommand in Blazor Rich Text Editor Component | Syncfusion
description: Learn here all about ExecuteCommand in Rich Text Editor in Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Execute Command Programmatically

In the Rich Text Editor, the [ExecuteCommand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ExecuteCommandOption.html) method runs HTML and Markdown commands programmatically to manipulate content in the current editable area.

## HTML editor commands

The [ExecuteCommand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ExecuteCommandOption.html#constructors) method supports the following HTML editor commands.

<table>
<tr>
<td><b>Commands</b></td>
<td><b>Description</b></td>
<td><b>Code snippets</b></td>
</tr>

<tr>
<td><p>Bold</p></td>
<td><p>Applies bold formatting to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Bold); 
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Italic</p></td>
<td><p>Applies italic formatting to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Italic);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Underline</p></td>
<td><p>Underlines the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Underline);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>StrikeThrough</p></td>
<td><p>Applies single-line strikethrough formatting to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.StrikeThrough);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Superscript</p></td>
<td><p>Applies superscript (higher) formatting to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Superscript);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Subscript</p></td>
<td><p>Applies subscript (lower) formatting to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Subscript);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Uppercase</p></td>
<td><p>Changes the selected content to uppercase.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Uppercase);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Lowercase</p></td>
<td><p>Changes the selected content to lowercase.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Lowercase);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>FontColor</p></td>
<td><p>Applies the specified font color to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.FontColor, "Red");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>FontName</p></td>
<td><p>Applies the specified font family to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.FontName, "Impact");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>FontSize</p></td>
<td><p>Applies the specified font size to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.FontSize, "10pt");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>BackgroundColor</p></td>
<td><p>Applies the specified background color to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.BackgroundColor, "red");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>JustifyCenter</p></td>
<td><p>Align the content with the centre margin.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.JustifyCenter);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>JustifyFull</p></td>
<td><p>Align the content with justify margin.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.JustifyFull);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>JustifyLeft</p></td>
<td><p>Align the content with the left margin.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.JustifyLeft);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>JustifyRight</p></td>
<td><p>Align the content with the margin on the right.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.JustifyRight);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>CreateLink</p></td>
<td><p>Creates a hyperlink from a text or image to a specific location in the content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.CreateLink, new LinkCommandsArgs() { Text = "Links", Url= "http://", Title = "Link"});
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Indent</p></td>
<td><p>Increases the indentation level of the content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Indent);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertHTML</p></td>
<td><p>Inserts the specified HTML at the current cursor position.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertHTML,"<div>Syncfusion Rich Text Editor</div>");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertOrderedList</p></td>
<td><p>Creates a new numbered list item.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertOrderedList);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertUnorderedList</p></td>
<td><p>Creates a new bulleted list item.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertUnorderedList);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>NumberFormatList</p></td>
<td><p>Creates an ordered list with customizable numbering styles. See the available formats <a href="https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorNumberFormatList.html">here</a>.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.NumberFormatList, "Decimal");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>BulletFormatList</p></td>
<td><p>Creates an unordered list with customizable bullet styles. See the available formats <a href="https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorBulletFormatList.html">here</a>.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.BulletFormatList, "Disc");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Outdent</p></td>
<td><p>Decreases the indentation level of the content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Outdent);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Redo</p></td>
<td><p>Allows you to redo your actions. </p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Redo);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>RemoveFormat</p></td>
<td><p>Remove all formatting styles (such as bold, italic, underline, color, superscript, subscript, and more) from the currently selected text.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.RemoveFormat);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertText</p></td>
<td><p>Inserts text at the current cursor position.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertText, "Inserted text");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertImage</p></td>
<td><p>Inserts an image at the current cursor position.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertImage, new ImageCommandsArgs() { Url = "https://ej2.syncfusion.com/javascript/demos/src/rich-text-editor/images/RTEImage-Feather.png", CssClass = "rte-img" });
{% endhighlight %}</td>
</tr>
</table>

N> Provided support to apply execute commands which do not require direct DOM access.

The following code block demonstrates the usage of the [ExecuteCommand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ExecuteCommandOption.html#constructors) in Rich Text Editor.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/html-execute-command.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor execute command](./images/blazor-richtexteditor-execute-command.gif)

## Markdown editor commands  

The [ExecuteCommand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ExecuteCommandOption.html#constructors) methods support following markdown commands.

<table>
<tr>
<td><b>Commands</b></td>
<td><b>Description</b></td>
<td><b>Code snippets</b></td>
</tr>

<tr>
<td><p>Bold</p></td>
<td><p>Make the selected content bold.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Bold); 
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Italic</p></td>
<td><p>Apply the italic style to the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Italic);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>StrikeThrough</p></td>
<td><p>Apply single-line strikethrough formatting for the selected content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.StrikeThrough);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Superscript</p></td>
<td><p>Makes the selected content as superscript (higher).</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Superscript);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Subscript</p></td>
<td><p>Makes the selected content as subscript (lower).</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Subscript);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Uppercase</p></td>
<td><p>Change the selected content to upper case.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Uppercase);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Lowercase</p></td>
<td><p>Change the selected content to lower case.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Lowercase);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>CreateLink</p></td>
<td><p>Creates a hyperlink from a text or image to a specific location in the content.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.CreateLink, new LinkCommandsArgs() { Text = "Links", Url= "http://", Title = "Link"});
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertOrderedList</p></td>
<td><p>Create a new list item(numbered).</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertOrderedList);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertUnorderedList</p></td>
<td><p>Create a new list item(bulleted).</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertUnorderedList);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Redo</p></td>
<td><p>Allows you to redo your actions. </p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Redo);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertText</p></td>
<td><p>Text will be inserted at the current cursor position.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertText, "Inserted text");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertImage</p></td>
<td><p>Insert an image to the current cursor position.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertImage, new ImageCommandsArgs() { Url = "https://ej2.syncfusion.com/javascript/demos/src/rich-text-editor/images/RTEImage-Feather.png", CssClass = "rte-img" });
{% endhighlight %}</td>
</tr>
</table>

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-execute-command.razor %}

{% endhighlight %}
{% endtabs %}

![Execute Command in Markdown Blazor RichTextEditor](./images/blazor-richtexteditor-execute-command-markdown.gif)

N> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) example to knows how to render and configure the rich text editor tools.