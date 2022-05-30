---
layout: post
title: Form validation in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Form validation in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Form validation in Blazor RichTextEditor Component

This following sample demonstrate how to get the Rich Text Editor validation error message in button click.

## Render the editor in a form

{% tabs %}
{% highlight razor tabtitle="~/edit-form.razor" %}

{% include_relative code-snippet/edit-form.razor %}

{% endhighlight %}
{% endtabs %}

![Form Validation in Blazor RichTextEditor](./images/blazor-richtexteditor-form-validation.png)

## Validation Rules

The Rich Text Editor is a textarea control. The editor also provides the functionality of character count and its validation. So, you can validate the editor's value on form submission by applying Validation Rules and Validation Message to the editor.

| Rules | Description |
|----------------|---------|
| Required | Requires value for the Rich Text Editor control.|
| MinLength | Requires the value to be of given minimum characters count.|
| MaxLength | Requires the value to be of given maximum characters count.|

This sample is demonstrated form validation using the `DataAnnotationsValidator`.

{% tabs %}
{% highlight razor tabtitle="~/validation-rules.razor" %}

{% include_relative code-snippet/validation-rules.razor %}

{% endhighlight %}
{% endtabs %}

![Char Count Validation in Blazor RichTextEditor](./images/blazor-richtexteditor-char-count-validation.png)


## Custom Placement of Validation Message

The Form Validation error message can be placed from default position to desired custom location.

{% tabs %}
{% highlight razor tabtitle="~/custom-placement-validation-message.razor" %}

{% include_relative code-snippet/custom-placement-validation-message.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor Validation in Custom placement](./images/blazor-richtexteditor-validation-placement.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.