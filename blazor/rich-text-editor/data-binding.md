---
layout: post
title: Data Binding in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Value Binding in Blazor Rich Text Editor

The Blazor Rich Text Editor supports two-way data binding to its [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) property using the `@bind-Value` attribute. The `Value` property accepts a `string` and represents the HTML content of the editor.

- When the editor content is modified, the bound variable is updated based on the configured save behavior (such as idle timeout, interval, or focus loss).
- When the bound variable is updated programmatically, the editor content reflects the latest value immediately.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/value-binding.razor %}

{% endhighlight %}
{% endtabs %}

## Auto-save

The Rich Text Editor can automatically save its content based on the configuration of the [SaveInterval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_SaveInterval) and [AutoSaveOnIdle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_AutoSaveOnIdle) properties. By default, the content is saved when the editor loses focus.

- When `AutoSaveOnIdle` is set to `true`, the editor saves the content only after the user stops typing. If no activity occurs for the duration specified by the `SaveInterval`, the content is saved automatically.

- When `AutoSaveOnIdle` is set to `false`, the editor saves the content at regular time intervals defined by the `SaveInterval`, regardless of whether the user is actively typing or idle.

> **Important:**
> - With `AutoSaveOnIdle = true`, `SaveInterval` acts as an *idle timeout*.
> - With `AutoSaveOnIdle = false`, `SaveInterval` acts as a *fixed recurring interval*.

The following example demonstrates how to use the `ValueChange` event to receive a notification whenever the editor content is saved, based on the configured auto-save behavior.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor ID="AutoSave" SaveInterval="SaveInterval" AutoSaveOnIdle="true" Value="@Value">
    <p>Type or edit the content to be saved automatically in the editor </p>
    <RichTextEditorEvents ValueChange="UpdateStatus" />
</SfRichTextEditor>

@code{
    private string Value { get; set; } = "<p>Start to type a content to save</p>";
    private int SaveInterval { get; set; } = 5000;
    private void UpdateStatus(Syncfusion.Blazor.RichTextEditor.ChangeEventArgs args)
    {
        // Place the codes here, which save the Rich Text Editor value into database.
        this.Value = args.Value;
    }
}

{% endhighlight %}
{% endtabs %}


## Get editor content

You can retrieve the editor's content using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_ValueChange) event. 

This event is triggered in the following scenarios:

- When the editor loses focus  
- When auto-save occurs based on the configured settings:
  - After the idle duration when `AutoSaveOnIdle = true`
  - At regular intervals defined by the [`SaveInterval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_SaveInterval) property when `AutoSaveOnIdle = false`

This allows you to capture and process the latest editor content whenever a save action is triggered.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/event.razor %}

{% endhighlight %}
{% endtabs %}

N> To explore the Rich Text Editor's features, visit the [feature tour page](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor). You can also refer to the [Blazor Rich Text Editor demo](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) to learn how to render and configure the component and its tools.