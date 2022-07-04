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

| Commands | Description | Code snippets |
|----------------|---------| -----------|
| Bold | Bold the selected content. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Bold); {% endhighlight %}|
| Italic | Apply the italic style for the selected content. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Italic); {% endhighlight %}|
| Underline | Underline the selected content |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Underline);{% endhighlight %}|
| StrikeThrough | Apply single line strike through formatting for the selected content. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.StrikeThrough);{% endhighlight %}|
| Superscript | Makes the selected content as superscript (higher). |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Superscript);{% endhighlight %}|
| Subscript | Makes the selected content as subscript (lower). | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Subscript); {% endhighlight %}|
| Uppercase | Change the selected content into upper case. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Uppercase); {% endhighlight %}|
| Lowercase | Change the selected content into lower case. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Lowercase); {% endhighlight %}|
| FontColor | Apply the specified font color for the selected content. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.FontColor, "Red"); {% endhighlight %}|
| FontName | Apply the specified font name for the selected content. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.FontName, "Impact");{% endhighlight %}|
| FontSize | Apply the specified font size for the selected content. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.FontSize, "10pt");{% endhighlight %}|
| BackgroundColor | Apply the specified background color the selected content. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.BackgroundColor, "red");{% endhighlight %}|
| JustifyCenter | Align the content with center margin. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.JustifyCenter); {% endhighlight %}|
| JustifyFull | Align the content with justify margin. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.JustifyFull); {% endhighlight %}|
| JustifyLeft | Align the content with left margin. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.JustifyLeft); {% endhighlight %}|
| JustifyRight | Align the content with right margin. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.JustifyRight);{% endhighlight %}|
| CreateLink | Creates a hyperlink to a text or image to a specific location in the content. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.CreateLink, new LinkCommandsArgs() { Text = "Links", Url= "http://", Title = "Link"});}{% endhighlight %} |
| Indent | Allows to increase the indent level of the content. | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Indent);{% endhighlight %}|
| InsertHTML | Insert the html content to the current cursor position. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.InsertHTML,"<div>Syncfusion Rich Text Editor</div>");{% endhighlight %}|
| InsertOrderedList | Create a new list item(numbered). | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.InsertOrderedList);{% endhighlight %}|
| InsertUnorderedList | Create a new list item(bulleted). | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.InsertUnorderedList);{% endhighlight %}|
| Outdent | Allows to decrease the indent level of the content. | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Outdent);{% endhighlight %}|
| Redo | Allows to redo the actions | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Redo);{% endhighlight %}|
| RemoveFormat | Remove all formatting styles (such as bold, italic, underline, color, superscript, subscript, and more) from currently selected text. |{% highlight cshtml %}await this.RteObj.ExecuteCommandAsync(CommandName.RemoveFormat);{% endhighlight %}|
| InsertText | Insert text to the current cursor position. | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.InsertText, "Inserted text");{% endhighlight %}|
| InsertImage | Insert an image to the current cursor position. | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.InsertImage, new ImageCommandsArgs() { Url = "https://ej2.syncfusion.com/javascript/demos/src/rich-text-editor/images/RTEImage-Feather.png", CssClass = "rte-img" });{% endhighlight %}|

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

| Commands | Description | Code snippets |
|----------------|---------| -----------|
| Bold | Bold the selected content in markdown mode. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Bold); {% endhighlight %} |
| Italic | Apply the italic style for the selected content in markdown mode. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Italic);{% endhighlight %}|
| StrikeThrough | Apply single line strike through formatting for the selected content in markdown mode. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.StrikeThrough);{% endhighlight %}|
| Superscript | Makes the selected content as superscript (higher) in markdown mode. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Superscript);{% endhighlight %}|
| Subscript | Makes the selected content as subscript (lower) in markdown mode. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Subscript);{% endhighlight %}|
| Uppercase | Change the selected content into upper case in markdown mode. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Uppercase);{% endhighlight %}|
| Lowercase | Change the selected content into lower case in markdown mode. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Lowercase);{% endhighlight %}|
| CreateLink | Creates a hyperlink to a content or image to a specific location in the content in markdown mode. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.CreateLink, new LinkCommandsArgs() { Text = "Links", Url= "http://", Title = "Link"});}{% endhighlight %} |
| InsertOrderedList | Create a new list item(numbered) in markdown mode. | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.InsertOrderedList);{% endhighlight %}|
| InsertUnorderedList | Create a new list item(bulleted) in markdown mode. |{% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.InsertUnorderedList);{% endhighlight %}|
| Redo | Allows to redo the actions | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.Redo);{% endhighlight %}|
| InsertText | Insert text to the current cursor position. | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.InsertText, "Inserted text");{% endhighlight %}|
| InsertImage | Insert an image to the current cursor position in markdowm mode. | {% highlight cshtml %} await this.RteObj.ExecuteCommandAsync(CommandName.InsertImage, new ImageCommandsArgs() { Url = "https://ej2.syncfusion.com/javascript/demos/src/rich-text-editor/images/RTEImage-Feather.png", CssClass = "rte-img" });{% endhighlight %}|

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/markdown-execute-command.razor %}

{% endhighlight %}
{% endtabs %}

![Execute Command in Markdown Blazor RichTextEditor](./images/blazor-richtexteditor-execute-command-markdown.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.