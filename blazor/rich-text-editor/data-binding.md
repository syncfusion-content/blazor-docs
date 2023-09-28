---
layout: post
title: Data Binding in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Value Binding in Blazor RichTextEditor

You can bind the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) to the editor component, by using the `@bind-Value` attribute and it supports string type. If component value has been changed, it will affect all the places where you bind the variable for the **bind-Value** attribute.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/value-binding.razor %}

{% endhighlight %}
{% endtabs %}

## Auto save

The Rich Text Editor saves its content automatically when you focus out the editor, and you can save its content automatically at regular intervals based on the [SaveInterval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_SaveInterval) and [AutoSaveOnIdle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_AutoSaveOnIdle) properties while editing.

* If `AutoSaveOnIdle` is set to true, the content is saved if the editor is idle for the number of milliseconds specified in the `SaveInterval` property.

* If `AutoSaveOnIdle` is set to false, the editor saves the content at the regular interval of milliseconds specified in the `SaveInterval` property.

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

You can get the RichTextEditor's edited content by using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_ValueChange) event.

When the user changes the content, the `ValueChange` event is invoked on every [SaveInterval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_SaveInterval) time or when the editor loses focus.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/event.razor %}

{% endhighlight %}
{% endtabs %}

N> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.