---
layout: post
title: Data Binding in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Value Binding

This section explains how to bind the [`Value`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) to the Rich Text Editor component that can be achieved in the following way:

* Two-way data binding

## Two-way data binding

The two-way data binding can be achieved by using the `@bind-Value` attribute from code-behind in Rich Text Editor.

{% tabs %}
{% highlight razor tabtitle="~/value-binding.razor" %}

{% include_relative code-snippet/value-binding.razor %}

{% endhighlight %}
{% endtabs %}

## Auto save

The Rich Text Editor saves its content automatically when you focus out the editor, and you can save its content automatically at regular intervals based on the SaveInterval and AutoSaveOnIdle properties while editing.

* If [AutoSaveOnIdle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_AutoSaveOnIdle) is set to true, the content is saved if the editor is idle for the number of milliseconds specified in the SaveInterval property.

* If [AutoSaveOnIdle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_AutoSaveOnIdle) is set to false, the editor saves the content at the regular interval of milliseconds specified in the SaveInterval property.
AutoSaveOnIdle is set to true in this demo, and the SaveInterval is set to 5 seconds.

{% tabs %}
{% highlight razor tabtitle="~/auto-save.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor ID="AutoSave" SaveInterval="saveInterval" AutoSaveOnIdle="true" Placeholder="Start to type a content to save">
    <p>Type or edit the content to be saved automatically in the editor </p>
    <RichTextEditorEvents ValueChange="UpdateStatus" />
</SfRichTextEditor>

@code{
    private int saveInterval { get; set; } = 5000;
    private async Task UpdateStatus(Syncfusion.Blazor.RichTextEditor.ChangeEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}
{% endtabs %}

We can also check whether RichTextEditor's content is changed or not.This can be achieved by using the [`ValueChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_ValueChange) event of the Rich Text Editor to check whether the editor’s value is changed or not.

{% tabs %}
{% highlight razor tabtitle="~/value-change.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor @bind-Value="@Value" @ref="RteObj">
    <RichTextEditorEvents ValueChange="@ValueChangeHandler">
    </RichTextEditorEvents>
</SfRichTextEditor>

@code {
    SfRichTextEditor RteObj;
    private string Value { get; set; } = "<p>Syncfusion RichTextEditor</p>";
    private string PreviousValue { get; set; } = "<p>Syncfusion RichTextEditor</p>";
    public void ValueChangeHandler(object args)
    {
        if (PreviousValue != this.Value)
        {
            //here you can write your code
            this.PreviousValue = this.Value;
        }
    }
}

{% endhighlight %}
{% endtabs %}

# Event

The Rich Text Editor triggers the events based on its actions. The events can be used as an extension point to perform custom operations.

* [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_ValueChange) - Triggers when the editor gets blurred and changes are made to the content.

{% tabs %}
{% highlight razor tabtitle="~/event.razor" %}

{% include_relative code-snippet/event.razor %}

{% endhighlight %}
{% endtabs %}


> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.