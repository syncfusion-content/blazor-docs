---
layout: post
title: How to Retrieve the Content in Blazor Markdown Editor | Syncfusion
description: Checkout and learn about how to retrieve the formatted content in Blazor Markdown Editor component of Syncfusion, and more details.
platform: Blazor
control: MarkdownEditor
documentation: ug
---

# Retrieve the formatted content in the Blazor Markdown Editor

To retrieve the contents of the Markdown editor, use the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) property of the Rich Text Editor.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.RichTextEditor
@using Syncfusion.Blazor.Popups

<SfButton @onclick="@GetValue">Get Value</SfButton>

<br />
<SfDialog @ref="DialogObj" @bind-Visible="@Visibility" Content="@Content" Header="@Header" Target="#target" Height="200px" Width="400px" ShowCloseIcon="true">
    <DialogButtons>
        <DialogButton Content="Ok" IsPrimary="true" OnClick="@DlgButtonClick" />
    </DialogButtons>
</SfDialog>

<SfRichTextEditor @ref="RteObj" Value="@RteValue" EditorMode="EditorMode.Markdown"/>

@code {
    SfRichTextEditor RteObj;
    SfDialog DialogObj;
    private string Content;
    private bool Visibility = false;
    private string Header = "Markdown Editor Value";
    private string RteValue = @" In Rich Text Editor, you click the toolbar buttons to format the words and the changes are visible immediately. In contrast, Markdown requires syntax to indicate formatting. When you format the word in Markdown format, you need to add Markdown syntax to the word to indicate which words and phrases should look different from each other. Rich Text Editor supports markdown editing when the editorMode set as **markdown** and using both *keyboard interaction* and *toolbar action*, you can apply the formatting to text. You can add your own custom formatting syntax for the Markdown formation, [sample link](https://blazor.syncfusion.com/demos/markdown-editor/overview). The third-party library <b>Marked</b> is used in this sample to convert markdown into HTML content.";
    private async Task GetValue()
    {
        this.Content = this.RteValue;
        await this.DialogObj.ShowAsync();
    }
    private async Task DlgButtonClick(object arg)
    {
    await this.DialogObj.HideAsync();
    }
}

{% endhighlight %}
{% endtabs %}
