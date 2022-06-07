---
layout: post
title: Style and appearance in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Style and Appearance

## Set placeholder

Specifies the placeholder for the Rich Text Editor’s content used when the Rich Text Editor body is empty through the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Placeholder) property.

Use the `e-rte-placeholder` class to define the custom font family, font color, and styles to the placeholder text.

```css

.e-richtexteditor .e-rte-placeholder {
    font-family: monospace;
}

```

The following sample demonstrates the placeholder option in Rich Text Editor.

{% tabs %}
{% highlight razor tabtitle="~/placeholder.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor Placeholder="Type something" />

<style>
    .e-richtexteditor .e-rte-placeholder {
        font-family: monospace;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with Placeholder](./images/blazor-richtexteditor-placeholder.png)

## Code view

Rich Text Editor includes the ability for users to directly edit HTML code via `Source View` in the text area. If you made any modification in Source view directly, the changes will be reflected in the Rich Text Editor's content. So, the users will have more flexibility over the content they have created.

{% tabs %}
{% highlight razor tabtitle="~/code-view.razor" %}

{% include_relative code-snippet/code-view.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with Code View](./images/blazor-richtexteditor-code-view.png)

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Customizing editor content

Use the following CSS to customize the default Rich Text Editor's content properties like font-family, font-size and color.

```css
/* To change font family and font size */
.e-richtexteditor .e-rte-content .e-content,
.e-richtexteditor .e-source-content .e-content {
    font-size: 20px;
    font-family: Segoe ui;
}

/* To change font color and content background */
.e-richtexteditor .e-rte-content,
.e-richtexteditor .e-source-content {
    background: seashell;
    color: blue;
}
```

## Customizing editor toolbar

Use the following CSS to customize the default color in the Rich Text Editor's toolbar icon.

```css
/* To change font color for toolbar icon */
.e-richtexteditor .e-rte-toolbar .e-toolbar-item .e-icons,
.e-richtexteditor .e-rte-toolbar .e-toolbar-item .e-icons:active {
    color: red;
}

/* To change font color for toolbar button */
.e-toolbar .e-tbar-btn,
.e-toolbar .e-tbar-btn:active,
.e-toolbar .e-tbar-btn:hover {
    color: red;
}

/* To change font color for toolbar button in active state*/
.e-richtexteditor .e-rte-toolbar .e-toolbar-item .e-dropdown-btn.e-active .e-icons,
.e-richtexteditor .e-rte-toolbar .e-toolbar-item .e-dropdown-btn.e-active .e-rte-dropdown-btn-text {
    color: red;
}

/* To change font color for expanded toolbar items */
.e-richtexteditor .e-rte-toolbar .e-toolbar-extended .e-toolbar-item .e-tbar-btn .e-icons,
.e-toolbar.e-extended-toolbar .e-toolbar-extended .e-toolbar-item .e-tbar-btn {
    color: red;
}
```
### Refresh editor

While rendering the Rich Text Editor inside the Dialog component, the dialog container and its wrapper elements are styled with display as none, so the editor’s toolbar does not get proper offset width and will render above the edit area container. To resolve this issue, you can call the RefreshUI method of RichTextEditor in the Dialog Opened event.

{% tabs %}
{% highlight razor tabtitle="~/refresh.razor" %}

{% include_relative code-snippet/refresh.razor %}

{% endhighlight %}
{% endtabs %}

## Highlight the specific lines

You can programmatically highlight a portion of the text in the editor, like setting the background color of the text by applying background style to the particular text using RichTextEditor ExecuteCommand method and the `jsinterop` method.

Refer the jsintrob method in `<head>` **wwwroot/jsinterop.js** of file.

{% tabs %}
{% highlight razor tabtitle="~/_jsinterop.js %}

window.RichTextEditor = {
    setBackground: function () {
        var rteInstance = document.getElementById('defaultRTE').blazor__instance;
        rteInstance.formatter.editorManager.nodeSelection.setSelectionText(
            document, rteInstance.inputElement.childNodes[0].childNodes[0], rteInstance.inputElement.childNodes[0].childNodes[0], 9, 20);
        return true;
    }
}

{% endhighlight %}
{% endtabs %}

Refer script in the `<head>` of the **~/Pages/_Host.cshtml** file.

{% tabs %}
{% highlight razor tabtitle="~/-Host.cshtml %}

<head> 
        … 
        … 
        <script src="jsinterop.js"></script> 
</head> 

{% endhighlight %}
{% endtabs %}

Now, add the Syncfusion RichTextEditor component in razor file. Here, the RichTextEditor component is added in the **~/Pages/Index.razor** file under the **~/Pages** folder.

{% tabs %}
{% highlight razor tabtitle="~/Index.Razor %}

<SfButton OnClick="SetBackround">Apply</SfButton>
<SfRichTextEditor ID="defaultRTE" Placeholder="Enter Some Content">
    <RichTextEditorToolbarSettings Items="@Tools" />
</SfRichTextEditor>

@code {
    [Inject]
    IJSRuntime JsRuntime { get; set; }
    private async Task SetBackround()
    {
        await JsRuntime.InvokeAsync<bool>("RichTextEditor.setBackground");
        await this.RteObj.ExecuteCommandAsync(CommandName.BackgroundColor, "yellow");
    }
}

{% endhighlight %}
{% endtabs %}

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.