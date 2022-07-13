---
layout: post
title: ExecCommand Blazor RichTextEditor Component | Syncfusion
description: Learn here all about ExecCommand in Rich Text Editor in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Execute Command Programmatically

In Rich Text Editor, the [ExecuteCommand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ExecuteCommandOption.html) method runs the HTML and Markdown commands 
programmatically to manipulate content in the current editable area.

## HTML editor commands

The `ExecuteCommand` methods support following HTML editor commands.

<table>
<tr>
<td><b>Commands</b></td>
<td><b>Description</b></td>
<td><b>Code snippets</b></td>
</tr>

<tr>
<td><p>Bold</p></td>
<td><p>Bold the selected content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Bold); 
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Italic</p></td>
<td><p>Apply the italic style for the selected content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Italic);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Underline</p></td>
<td><p>Underline the selected content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Underline);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>StrikeThrough</p></td>
<td><p>Apply single line strike through formatting for the selected content.</p></td>
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
<td><p>Change the selected content into upper case.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Uppercase);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Lowercase</p></td>
<td><p>Change the selected content into lower case.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Lowercase);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>FontColor</p></td>
<td><p>Apply the specified font color for the selected content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.FontColor, "Red");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>FontName</p></td>
<td><p>Apply the specified font name for the selected content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.FontName, "Impact");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>FontSize</p></td>
<td><p>Apply the specified font size for the selected content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.FontSize, "10pt");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>BackgroundColor</p></td>
<td><p>Apply the specified background color the selected content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.BackgroundColor, "red");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>JustifyCenter</p></td>
<td><p>Align the content with center margin.</p></td>
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
<td><p>Align the content with left margin. </p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.JustifyLeft);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>JustifyRight</p></td>
<td><p>Align the content with right margin. </p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.JustifyRight);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>CreateLink</p></td>
<td><p>Creates a hyperlink to a text or image to a specific location in the content. </p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.CreateLink, new LinkCommandsArgs() { Text = "Links", Url= "http://", Title = "Link"});
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Indent</p></td>
<td><p>Allows to increase the indent level of the content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Indent);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertHTML</p></td>
<td><p>Insert the html content to the current cursor position.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.InsertHTML,"<div>Syncfusion Rich Text Editor</div>");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertOrderedList</p></td>
<td><p> Create a new list item(numbered).</p></td>
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
<td><p>Outdent</p></td>
<td><p>Allows to decrease the indent level of the content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Outdent);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Redo</p></td>
<td><p>Allows to redo the actions</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Redo);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>RemoveFormat</p></td>
<td><p>Remove all formatting styles (such as bold, italic, underline, color, superscript, subscript, and more) from currently selected text.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.RemoveFormat);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertText</p></td>
<td><p>Insert text to the current cursor position.</p></td>
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


> Provided support to apply execute commands which do not require direct DOM access.

The following code block demonstrates the usage of the `ExecuteCommand` in Rich Text Editor.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/html-execute-command.razor %}

{% endhighlight %}
{% endtabs %}

![Execute Command in Blazor RichTextEditor](./images/blazor-richtexteditor-execute-command.png)

## Markdown editor commands  

The `ExecuteCommand` methods support following Markdown commands.

<table>
<tr>
<td><b>Commands</b></td>
<td><b>Description</b></td>
<td><b>Code snippets</b></td>
</tr>

<tr>
<td><p>Bold</p></td>
<td><p>Bold the selected content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Bold); 
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Italic</p></td>
<td><p>Apply the italic style for the selected content.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Italic);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>StrikeThrough</p></td>
<td><p>Apply single line strike through formatting for the selected content.</p></td>
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
<td><p>Change the selected content into upper case.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Uppercase);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Lowercase</p></td>
<td><p>Change the selected content into lower case.</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Lowercase);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>CreateLink</p></td>
<td><p>Creates a hyperlink to a text or image to a specific location in the content. </p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.CreateLink, new LinkCommandsArgs() { Text = "Links", Url= "http://", Title = "Link"});
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertOrderedList</p></td>
<td><p> Create a new list item(numbered).</p></td>
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
<td><p>Allows to redo the actions</p></td>
<td>
{% highlight cshtml %} 
await this.RteObj.ExecuteCommandAsync(CommandName.Redo);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>InsertText</p></td>
<td><p>Insert text to the current cursor position.</p></td>
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
{% highlight razor %}

{% include_relative code-snippet/markdown-execute-command.razor %}

{% endhighlight %}
{% endtabs %}

![Execute Command in Markdown Blazor RichTextEditor](./images/blazor-richtexteditor-execute-command-markdown.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.