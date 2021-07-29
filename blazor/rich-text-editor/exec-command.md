---
layout: post
title: ExecCommand Blazor RichTextEditor Component | Syncfusion
description: Learn here all about ExecCommand in Rich Text Editor in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# ExecCommand in Rich Text Editor in Blazor RichTextEditor Component

In Rich Text Editor, the ExecuteCommand is used to perform commands for the modification of content in editable area.
The `ExecuteCommand` will perform the following commands.

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
| RemoveFormat | remove all formatting styles (such as bold, italic, underline, color, superscript, subscript, and more) from currently selected text. |`await this.RteObj.ExecuteCommandAsync(CommandName.RemoveFormat);`|
| InsertText | Insert text to the current cursor position. | `await this.RteObj.ExecuteCommandAsync(CommandName.InsertText, "Inserted text");`|
| InsertImage | Insert an image to the current cursor position. | `await this.RteObj.ExecuteCommandAsync(CommandName.InsertImage, new ImageCommandsArgs() { Url = "https://ej2.syncfusion.com/javascript/demos/src/rich-text-editor/images/RTEImage-Feather.png", CssClass = "rte-img" });`|

> Provided support to apply execute commands which do not require direct DOM access.

The following code block demonstrates the usage of the ExecuteCommand in Rich Text Editor.

```csharp

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor @ref="@RteObj">
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
    <p><b> Key features:</b></p>
    <ul>
        <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
        <li><p> Capable of handling markdown editing.</p></li>
        <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
        <li><p> Provides a fully customizable toolbar.</p></li>
        <li><p> Provides HTML view to edit the source directly for developers.</p></li>
        <li><p> Supports third - party library integration.</p></li>
    </ul>
</SfRichTextEditor>
<SfButton Content="Bold" @onclick="@OnBoldCommand" />
<SfButton Content="InsertHTML" @onclick="@OnInsertHtmlCommand" />

@code {
    SfRichTextEditor RteObj;

    private async Task OnBoldCommand()
    {
        await this.RteObj.ExecuteCommandAsync(CommandName.Bold);
    }

    private async Task OnInsertHtmlCommand()
    {
        await this.RteObj.ExecuteCommandAsync(CommandName.InsertHTML, "<div>Syncfusion Rich Text Editor component</div>");
    }
}

```

The output will be as follows.

![Execute Command](./images/exec-command.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.