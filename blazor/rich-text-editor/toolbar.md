---
layout: post
title: Toolbar in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Toolbar in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Toolbar in Blazor RichTextEditor Component

The Rich Text Editor toolbar contains a collection of tools such as bold, Italic, and text alignment buttons that are used to format the content. However, in most integrations, you can customize the toolbar configurations easily to suit your needs. The Rich Text Editor allows to configure different types of toolbar using [`RichTextEditorToolbarSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html) - `Type` property. The types of toolbar are:

1. Expand
2. MultiRow

![Toolbar](./images/blazor-richtexteditor-toolbar-types.png)

## Expand Toolbar

The default mode of [`RichTextEditorToolbarSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_Type) - `Type` as [`Expand`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ToolbarType.html#Syncfusion_Blazor_RichTextEditor_ToolbarType_Expand) to hide the overflowing items in the next row. By clicking the expand arrow, view the overflowing toolbar items.

{% tabs %}
{% highlight razor tabtitle="~/expand-toolbar.razor" %}

@using Syncfusion.Blazor.RichTextEditor 

<SfRichTextEditor> 
    <RichTextEditorToolbarSettings Items="@Tools" Type="ToolbarType.Expand" />
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p> 
</SfRichTextEditor> 

@code{ 
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>() 
    { 
        new ToolbarItemModel() { Command = ToolbarCommand.Bold }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Italic }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Underline }, 
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor }, 
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Formats }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.OrderedList }, 
        new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Outdent }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Indent }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Image }, 
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Undo }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Redo } 
    }; 
}

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/expand-toolbar.razor %}

{% endhighlight %}

![Blazor RichTextEditor with Expand Toolbar](./images/blazor-richtexteditor-expand-toolbar.png)

## Multi-row Toolbar

Set the [`RichTextEditorToolbarSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_Type) - `Type` as [`MultiRow`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ToolbarType.html#Syncfusion_Blazor_RichTextEditor_ToolbarType_MultiRow) to display the toolbar items in a row-wise format. All toolbar items are visible always.

{% tabs %}
{% highlight razor tabtitle="~/multirow-toolbar.razor" %}

@using Syncfusion.Blazor.RichTextEditor 

<SfRichTextEditor> 
    <RichTextEditorToolbarSettings Items="@Tools" Type="ToolbarType.MultiRow" />
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p> 
</SfRichTextEditor> 

@code{ 
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>() 
    { 
        new ToolbarItemModel() { Command = ToolbarCommand.Bold }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Italic }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Underline }, 
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor }, 
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Formats }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.OrderedList }, 
        new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Outdent }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Indent }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Image }, 
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Undo }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Redo } 
    }; 
}

{% endhighlight %}
{% endtabs %}


{% highlight cshtml %}

{% include_relative code-snippet/multirow-toolbar.razor %}

{% endhighlight %}

![Blazor RichTextEditor with MultiRow Toolbar](./images/blazor-richtexteditor-multirow-toolbar.png)

## Floating Toolbar

By default, toolbar is float at the top of the Rich Text Editor on scrolling. It can be customized by specifying the offset of the floating toolbar from documents top position using `FloatingToolbarOffset`.

Enable or disable the floating toolbar using [`EnableFloating`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_EnableFloating) of the [`RichTextEditorToolbarSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html) property.

{% tabs %}
{% highlight razor tabtitle="~/floating-toolbar.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor Height="800px">
    <RichTextEditorToolbarSettings EnableFloating="true" Items="@Tools" />
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
</SfRichTextEditor>

@code{
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Italic }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Underline }, 
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor }, 
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Formats }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.OrderedList }, 
        new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Outdent }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Indent }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Image }, 
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Undo }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Redo } 
    };
}

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/floating-toolbar.razor %}

{% endhighlight %}

## Build-in Tools

The following table lists the tools available in the toolbar.

| Name | Icons | Summary | Initialization &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  |
|----------------|---------|---------|------------------------------------------|
| Undo |![Undo icon](./images/undo.png) | Allows to undo the actions.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Undo } <br> }; |
| Redo | ![Redo icon](./images/redo.png) | Allows to redo the actions.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Redo } <br> }; |
| Alignment | ![Alignment icon](./images/alignments.png) | Aligns the content with left, center, and right margin.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Alignments } <br> }; |
| OrderedList | ![OrderedList icon](./images/order-list.png) | Creates a new list item(numbered). |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.OrderedList } <br> }; |
| UnorderedList | ![UnorderedList icon](./images/unorder-list.png) | Creates a new list item(bulleted). |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList } <br> }; |
| Indent | ![Indent icon](./images/increase-indent.png) | Allows to increase the indent level of the content.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Indent } <br> };|
| Outdent | ![Outdent icon](./images/decrease-indent.png) | Allows to decrease the indent level of the content.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Outdent } <br> };|
| Hyperlink | ![Hyperlink icon](./images/create-link.png) | Creates a hyperlink to a text or image to a specific location in the content.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.CreateLink } <br> };|
| Images | ![Images icon](./images/insert-image.png) | Inserts an image from an online source or local computer. |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Image } <br> }; |
| LowerCase | ![LowerCase icon](./images/lower-case.png) | Changes the case of selected text to lower in the content. |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.LowerCase } <br> }; |
| UpperCase | ![UpperCase icon](./images/upper-case.png) | Changes the case of selected text to upper  in the content.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.UpperCase } <br> }; |
| SubScript | ![SubScript icon](./images/sub-script.png) | Makes the selected text as subscript (lower).|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.SubScript } <br> }; |
| SuperScript | ![SuperScript icon](./images/super-script.png) | Makes the selected text as superscript (higher).|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.SuperScript } <br> }; |
| Print | ![Print icon](./images/print.png) | Allows to print the editor content. |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Print } <br> }; |
| FontName | ![FontName icon](./images/font-name.png) | Defines the fonts that appear under the Font Family DropDownList from the Rich Text Editor's toolbar. |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.FontName } <br> };|
| FontSize | ![FontSize icon](./images/font-size.png) | Defines the font sizes that appear under the Font Size DropDownList from the Rich Text Editor's toolbar.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.FontSize } <br> };|
| FontColor | ![FontColor icon](./images/font-color.png) | Specifies an array of colors can be used in the colors popup for font color.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.FontColor } <br> }; |
| BackgroundColor | ![BackgroundColor icon](./images/background-color.png) | Specifies an array of colors can be used in the colors popup for background color.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor } <br> }; |
| Format | ![Format icon](./images/formats.png) | An Object with the options that will appear in the Paragraph Format dropdown from the toolbar. |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Formats } <br> }; |
| StrikeThrough | ![StrikeThrough icon](./images/strikethrough.png) | Applies double line strike through formatting for the selected text. |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough } <br> }; |
| ClearFormat | ![ClearFormat icon](./images/clear-format.png) | The clear format tool is useful to remove all formatting styles (such as bold, italic, underline, color, superscript, subscript, and more) from currently selected text. As a result, all the text formatting will be cleared and return to its default formatting styles.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.ClearFormat } <br> }; |
| FullScreen | ![FullScreen icon](./images/maximize.png) | Stretches the editor to the maximum width and height of the browser window.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.FullScreen } <br> }; |
| SourceCode | ![SourceCode icon](./images/code-view.png)  | Rich Text Editor includes the ability for users to directly edit HTML code via "Source View". If you made any modification in Source view directly, synchronize with Design view.|public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.SourceCode } <br> }; |
| NumberFormatList | ![NumberFormatList icon](./images/number-format.png) | Allows to create list items with various list style types(numbered). |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.NumberFormatList } <br> }; |
| BulletFormatList | ![BulletFormatList icon](./images/bullet-format.png) | Allows to create list items with various list style types(bulleted). |public List&lt;ToolbarItemModel&gt; Items = new List&lt;ToolbarItemModel&gt;() {<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.BulletFormatList } <br> }; |

By default, tools will be arranged in the following order.

> new List&lt;ToolbarItemModel&gt;()<br>{<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Bold },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Italic },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Underline },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Separator },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Formats },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Alignments },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.OrderedList },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Separator },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Image },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Separator },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Undo },<br>&nbsp;&nbsp;&nbsp;&nbsp;new ToolbarItemModel() { Command = ToolbarCommand.Redo }<br>};

The tools order can be customized as your application requirement. If you are not specifying any tools order, the editor will create the toolbar with default items.

## Custom Tool

The Rich Text Editor allows to configure your own tools to its toolbar using [`RichTextEditorCustomToolbarItems`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorCustomToolbarItems.html) tag directive with in a [`RichTextEditorToolbarSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html). The tools can be plain text, icon, HTML template. You can also define the order and group where the tool should be included.

This sample shows how to add your own tools to toolbar of the Rich Text Editor. The `Ω` command is added to insert special characters in the editor.

Refer to the following code snippet for custom tool with tooltip text which will be included in `Items` field of [`RichTextEditorToolbarSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html) property.

{% tabs %}
{% highlight razor tabtitle="~/custom-toolbar.razor" %}

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorToolbarSettings Items="@Tools">
        <RichTextEditorCustomToolbarItems>
            <RichTextEditorCustomToolbarItem Name="Symbol">
                <Template>
                    <SfButton @onclick="ClickHandler">Ω</SfButton>
                </Template>
            </RichTextEditorCustomToolbarItem>
        </RichTextEditorCustomToolbarItems>
    </RichTextEditorToolbarSettings>
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
</SfRichTextEditor>

@code {
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Name = "Symbol", TooltipText = "Insert Symbol" },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.FullScreen }
    };
    private void ClickHandler()
    {
        //Perform your action here
    }
}

{% endhighlight %}
{% endtabs %}

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.

## See Also

* [How to render the toolbar in inline mode](./inline-mode/)