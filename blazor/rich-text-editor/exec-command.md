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
<td><p>Allows you to redo your actions.</p></td>
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

<tr>
<td><p>Undo</p></td>
<td><p>Allows you to undo your actions.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Undo);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Format Block</p></td>
<td><p>Allows you to apply block-level formatting, such as headings (H1–H6) or paragraphs, to the selected text.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.FormatBlock, "H3");
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Heading</p></td>
<td><p>Allows you to directly apply the Heading 1 block style to the selected text.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Heading);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Insert Code Block</p></td>
<td><p>Allows you to insert a preformatted multi-line block by defining the syntax language identifier and its visual dropdown text label.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertCodeBlock, new CodeBlockCommandArgs() { Language = "typescript", Label = "TypeScript" });
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Insert Paragraph</p></td>
<td><p>Allows you to insert a new paragraph block at the current cursor position.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertParagraph);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Insert Horizontal Rule</p></td>
<td><p>Allows you to insert a straight horizontal rule line element to serve as a thematic structural divider between text blocks.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertHorizontalRule);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Insert Br On Return</p></td>
<td><p>Configures the editor to insert a standard HTML line break element when the Enter key is pressed, rather than splitting the current block into a new paragraph.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertBrOnReturn);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Insert Code</p></td>
<td><p>Allows you to apply inline code formatting to the selected text for highlighting variables or short commands.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertCode);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Insert Table</p></td>
<td><p>Allows you to programmatically insert a structured HTML table layout component by declaring the exact row and column constraints.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.InsertTable, new TableCommandArgs() { Row = 3, Columns = 3 });
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Edit Image</p></td>
<td><p>Allows you to programmatically modify an existing image element's properties using specific source URLs, dimensions, and custom CSS classes.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(
    CommandName.EditImage, 
    new ImageCommandsArgs() 
    { 
        Url = "https://cdn.syncfusion.com/ej2/richtexteditor-resources/RTE-Portrait.png", 
        AltText = "Alternative description text", 
        CssClass = "custom-img-style",
        Width = new CommandsWidth() { Width = "300px" },
        Height = new CommandsHeight() { Height = "auto" }
    }
);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Edit Link</p></td>
<td><p>Allows you to programmatically modify a hyperlink element by declaring the destination URL, display text, and title attributes.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(
    CommandName.EditLink, 
    new LinkCommandsArgs() { Url = "https://", Text = "Syncfusion", Title = "Visit Home Page" }
);
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Video</p></td>
<td><p>Allows you to programmatically embed an interactive HTML5 video viewport by assigning specific media source URLs.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(
    CommandName.Video, 
    new VideoCommandsArgs() { Url = "https://cdn.syncfusion.com/ej2/richtexteditor-resources/RTE-Ocean-Waves.mp4", CssClass = "e-rte-video" });
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Audio</p></td>
<td><p>Allows you to programmatically embed an interactive HTML5 audio player tracking path by assigning specific media source URLs.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(
    CommandName.Audio, 
    new AudioCommandsArgs() { Url = "https://cdn.syncfusion.com/ej2/richtexteditor-resources/RTE-Audio.wav", CssClass = "e-rte-audio" });
{% endhighlight %}</td>
</tr>

<tr>
<td><p>Checklist</p></td>
<td><p>Allows you to format the selected text as an interactive checklist.</p></td>
<td>
{% highlight cshtml %}
await this.RteObj.ExecuteCommandAsync(CommandName.Checklist);
{% endhighlight %}</td>
</tr>
</table>

N> Provided support to apply execute commands which do not require direct DOM access.

The following code block demonstrates the usage of the [ExecuteCommand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ExecuteCommandOption.html#constructors) in Rich Text Editor.

{% tabs %}
{% highlight razor %}

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
{% highlight razor %}

{% include_relative code-snippet/markdown-execute-command.razor %}

{% endhighlight %}
{% endtabs %}

![Execute Command in Markdown Blazor RichTextEditor](./images/blazor-richtexteditor-execute-command-markdown.gif)

N> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) example to knows how to render and configure the rich text editor tools.