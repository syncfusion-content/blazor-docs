---
layout: post
title: Form validation in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Form validation in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Edit Form support

The Rich Text Editor support validation using the [EditForm]( https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-6.0). The user type text content inside the editor is validated with [data annotations]( https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-5.0)  attributes. In the following example, the `FormModel` class has the `Description` property marked required with the `RequiredAttribute` and `MinLengthAttribute` minimum string length validation and error message. The Description property binding to editor `@bind-Value` property and validation work based on user input.

> [View Sample in GitHub.](https://github.com/SyncfusionExamples/rich_text_editor_editform_validation)

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/edit-form.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor form validation ](./images/blazor-richtexteditor-form-validation.png)

## Validation attributes

The Rich Text Editor provides the functionality of character count and its validation. So, you can validate the editor's value on form submission by applying validation attributes and validation messages to the editor.

| Rules | Description |
|----------------|---------|
| Required | Requires value for the Rich Text Editor control.|
| MinLength | Requires the value to be of given minimum characters count.|
| MaxLength | Requires the value to be of given maximum characters count.|

This sample is demonstrated form validation using the `DataAnnotationsValidator`.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/validation-rules.razor %}

{% endhighlight %}
{% endtabs %}

![Char Count Validation in Blazor RichTextEditor](./images/blazor-richtexteditor-char-count-validation.png)


## Custom placement of validation message

The Form Validation error message can be placed from default position to desired custom location.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/custom-placement-validation-message.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor Validation in Custom placement](./images/blazor-richtexteditor-validation-placement.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.