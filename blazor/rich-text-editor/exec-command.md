---
layout: post
title: ExecCommand Blazor RichTextEditor Component | Syncfusion
description: Learn here all about ExecCommand in Rich Text Editor in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Execute Command

In Rich Text Editor, the ExecuteCommand method runs the HTML and Markdown commands 
programmatically to manipulate content in the current editable area.

## HTML editor commands

The [ExecuteCommand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ExecuteCommandOption.html) methods 
support following HTML editor commands.


| Commands | Description | Code snippets |
|----------------|---------| -----------|
| Bold | Bold the selected content in the Rich Text Editor. |`await this.RteObj.ExecuteCommandAsync(CommandName.Bold);`|
| Italic | The selected text will be italics. |`await this.RteObj.ExecuteCommandAsync(CommandName.Italic);`|
| Underline | Underline the selected text in the Rich Text Editor. |`await this.RteObj.ExecuteCommandAsync(CommandName.Underline);`|
| StrikeThrough | Apply single line strike through formatting for the selected text. |`await this.RteObj.ExecuteCommandAsync(CommandName.StrikeThrough);`|
| Superscript | Makes the selected text as superscript (higher). |`await this.RteObj.ExecuteCommandAsync(CommandName.Superscript);`|
| Subscript | Makes the selected text as subscript (lower). |`await this.RteObj.ExecuteCommandAsync(CommandName.Subscript);`|
| Uppercase | Change the case of selected text to upper  in the content. |`await this.RteObj.ExecuteCommandAsync(CommandName.Uppercase);`|
| Lowercase | Change the case of selected text to lower in the content. |`await this.RteObj.ExecuteCommandAsync(CommandName.Lowercase);`|
| FontColor | Apply the specified font color for the selected text. |`await this.RteObj.ExecuteCommandAsync(CommandName.FontColor, "Red");`|
| FontName | Apply the specified font name for the selected text. |`await this.RteObj.ExecuteCommandAsync(CommandName.FontName, "Impact");`|
| FontSize | Apply the specified font size for the selected text. |`await this.RteObj.ExecuteCommandAsync(CommandName.FontSize, "10pt");`|
| BackgroundColor | Apply the specified background color the selected text. | `await this.RteObj.ExecuteCommandAsync(CommandName.BackgroundColor, "red");`|
| JustifyCenter | Align the content with center margin. | `await this.RteObj.ExecuteCommandAsync(CommandName.JustifyCenter);`|
| JustifyFull | Align the content with justify margin. |`await this.RteObj.ExecuteCommandAsync(CommandName.JustifyFull);`|
| JustifyLeft | Align the content with left margin. | `await this.RteObj.ExecuteCommandAsync(CommandName.JustifyLeft);`|
| JustifyRight | Align the content with right margin. | `await this.RteObj.ExecuteCommandAsync(CommandName.JustifyRight);`|
| CreateLink | Creates a hyperlink to a text or image to a specific location in the content. |`await this.RteObj.ExecuteCommandAsync(CommandName.CreateLink, new LinkCommandsArgs() { Text = "Links", Url= "http://", Title = "Link"});}` |
| Indent | Allows to increase the indent level of the content. | `await this.RteObj.ExecuteCommandAsync(CommandName.Indent);`|
| InsertHTML | Insert the html content to the current cursor position. |`await this.RteObj.ExecuteCommandAsync(CommandName.InsertHTML,"<div>Syncfusion Rich Text Editor`|
| InsertOrderedList | Create a new list item(numbered). | `await this.RteObj.ExecuteCommandAsync(CommandName.InsertOrderedList);`|
| InsertUnorderedList | Create a new list item(bulleted). |`await this.RteObj.ExecuteCommandAsync(CommandName.InsertUnorderedList);`|
| Outdent | Allows to decrease the indent level of the content. | `await this.RteObj.ExecuteCommandAsync(CommandName.Outdent);`|
| Redo | Allows to redo the actions | `await this.RteObj.ExecuteCommandAsync(CommandName.Redo);`|
| RemoveFormat | Remove all formatting styles (such as bold, italic, underline, color, superscript, subscript, and more) from currently selected text. |`await this.RteObj.ExecuteCommandAsync(CommandName.RemoveFormat);`|
| InsertText | Insert text to the current cursor position. | `await this.RteObj.ExecuteCommandAsync(CommandName.InsertText, "Inserted text");`|
| InsertImage | Insert an image to the current cursor position. | `await this.RteObj.ExecuteCommandAsync(CommandName.InsertImage, new ImageCommandsArgs() { Url = "https://ej2.syncfusion.com/javascript/demos/src/rich-text-editor/images/RTEImage-Feather.png", CssClass = "rte-img" });`|

> Provided support to apply execute commands which do not require direct DOM access.

The following code block demonstrates the usage of the ExecuteCommand in Rich Text Editor.

{% tabs %}
{% highlight razor tabtitle="~/html-execute-command.razor" %}

{% include_relative code-snippet/html-execute-command.razor %}

{% endhighlight %}
{% endtabs %}

![Execute Command in Blazor RichTextEditor](./images/blazor-richtexteditor-execute-command.png)

## Markdown editor commands  

The [ExecuteCommand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ExecuteCommandOption.html) methods support following Markdown commands.

| Commands | Description | Code snippets |
|----------------|---------| -----------|
| Bold | Bold the selected content in the Rich Text Editor. |`await this.RteObj.ExecuteCommandAsync(CommandName.Bold);`|
| Italic | The selected text will be italics. |`await this.RteObj.ExecuteCommandAsync(CommandName.Italic);`|
| StrikeThrough | Apply single line strike through formatting for the selected text. |`await this.RteObj.ExecuteCommandAsync(CommandName.StrikeThrough);`|
| Superscript | Makes the selected text as superscript (higher). |`await this.RteObj.ExecuteCommandAsync(CommandName.Superscript);`|
| Subscript | Makes the selected text as subscript (lower). |`await this.RteObj.ExecuteCommandAsync(CommandName.Subscript);`|
| Uppercase | Change the case of selected text to upper  in the content. |`await this.RteObj.ExecuteCommandAsync(CommandName.Uppercase);`|
| Lowercase | Change the case of selected text to lower in the content. |`await this.RteObj.ExecuteCommandAsync(CommandName.Lowercase);`|
| CreateLink | Creates a hyperlink to a text or image to a specific location in the content. |`await this.RteObj.ExecuteCommandAsync(CommandName.CreateLink, new LinkCommandsArgs() { Text = "Links", Url= "http://", Title = "Link"});}` |
| InsertOrderedList | Create a new list item(numbered). | `await this.RteObj.ExecuteCommandAsync(CommandName.InsertOrderedList);`|
| InsertUnorderedList | Create a new list item(bulleted). |`await this.RteObj.ExecuteCommandAsync(CommandName.InsertUnorderedList);`|
| Redo | Allows to redo the actions | `await this.RteObj.ExecuteCommandAsync(CommandName.Redo);`|
| InsertText | Insert text to the current cursor position. | `await this.RteObj.ExecuteCommandAsync(CommandName.InsertText, "Inserted text");`|
| InsertImage | Insert an image to the current cursor position. | `await this.RteObj.ExecuteCommandAsync(CommandName.InsertImage, new ImageCommandsArgs() { Url = "https://ej2.syncfusion.com/javascript/demos/src/rich-text-editor/images/RTEImage-Feather.png", CssClass = "rte-img" });`|

{% tabs %}
{% highlight razor tabtitle="~/markdown-execute-command.razor" %}

{% include_relative code-snippet/markdown-execute-command.razor %}

{% endhighlight %}
{% endtabs %}

![Execute Command in Markdown Blazor RichTextEditor](./images/blazor-richtexteditor-execute-command-markdown.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.