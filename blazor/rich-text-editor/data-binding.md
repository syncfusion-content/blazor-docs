---
layout: post
title: Data Binding in Blazor RichTextEditor | Syncfusion
description: Learn how to implement data binding in the Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Value Binding in Blazor RichTextEditor

The Blazor Rich Text Editor supports two-way data binding to its [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) property using the `@bind-Value` attribute. The `Value` property accepts a `string` type. When the editor's content is modified, the bound variable is automatically updated. Likewise, any changes to the variable will be reflected in the editor's content.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/value-binding.razor %}

{% endhighlight %}
{% endtabs %}

## Auto-save

The Rich Text Editor can automatically save its content based on the configuration of the [SaveInterval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_SaveInterval) and [AutoSaveOnIdle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_AutoSaveOnIdle) properties. By default, the content is saved when the editor loses focus.

* When `AutoSaveOnIdle` is `true`, the content is saved if the editor remains idle for the duration specified in the `SaveInterval` property (in milliseconds).

* When `AutoSaveOnIdle` is `false`, the content is saved at the regular interval defined by the `SaveInterval` property.

The following example demonstrates how to use the `ValueChange` event to get a notification when the content is saved.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor ID="AutoSave" SaveInterval="saveInterval" AutoSaveOnIdle="true" Value="@Value">
    <p>Type or edit the content to be saved automatically in the editor </p>
    <RichTextEditorEvents ValueChange="UpdateStatus" />
</SfRichTextEditor>

@code{
    private string Value { get; set; } = "<p>Start to type a content to save </p>";
    private int saveInterval { get; set; } = 5000;
    private void UpdateStatus(Syncfusion.Blazor.RichTextEditor.ChangeEventArgs args)
    {
        // Place the codes here, which save the Rich Text Editor value into database.
        this.Value = args.Value;
    }
}

{% endhighlight %}
{% endtabs %}


## Get editor content

You can retrieve the editor's content using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_ValueChange) event. This event is triggered either when the editor loses focus or at the specified [SaveInterval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_SaveInterval), allowing you to capture the latest content.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/event.razor %}

{% endhighlight %}
{% endtabs %}

N> To explore the Rich Text Editor's features, visit the [feature tour page](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor). You can also refer to the [Blazor Rich Text Editor demo](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) to learn how to render and configure the component and its tools.