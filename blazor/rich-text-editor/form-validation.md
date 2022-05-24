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

@using Syncfusion.Blazor.RichTextEditor
@using System.ComponentModel.DataAnnotations;

<div class="control-section">
    <div class="content-container">
        <div id="content" class="box-form" style="margin: 0 auto; max-width:750px; padding:25px">
            <EditForm Model="@Model">
                <DataAnnotationsValidator />
                <SfRichTextEditor ShowCharCount="true" MaxLength="100" Placeholder="Type something..." @bind-Value="@Model.Description" />
                <ValidationMessage For="@(() => Model.Description)" />
                <div class="btn-grp">
                    <button class="samplebtn e-control e-btn" type="reset" data-ripple="true">Reset</button>
                    <button class="samplebtn e-control e-btn" type="submit" data-ripple="true">Submit</button>
                </div>
            </EditForm>
        </div>
    </div>
</div>

<style>
    .box-form {
        webkit-box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 3px 1px -2px rgba(0, 0, 0, 0.12), 0 1px 5px 0 rgba(0, 0, 0, 0.2);
        box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 3px 1px -2px rgba(0, 0, 0, 0.12), 0 1px 5px 0 rgba(0, 0, 0, 0.2);
    }

    .btn-grp {
        text-align: center;
        margin-top: 15px;
    }

    .validation-message {
        color: #f44336;
        font-family: "Roboto", "Segoe UI", "GeezaPro", "DejaVu Serif", "sans-serif", "-apple-system", "BlinkMacSystemFont";
        font-size: 12px;
        font-weight: normal;
    }
</style>

@code{
    private class FormModel
    {
        [Required]
        [MinLength(20, ErrorMessage = "Please enter at least 20 characters.")]
        public string Description { get; set; }
    }
    private FormModel Model = new FormModel();
}

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/edit-form.razor %}

{% endhighlight %}

![Form Validation in Blazor RichTextEditor](./images/blazor-richtexteditor-form-validation.png)

## Validation Rules

The Rich Text Editor is a textarea control. The Rich Text Editor also provides the functionality of character count and its validation. So, you can validate the Rich Text Editor's value on form submission by applying Validation Rules and Validation Message to the Rich Text Editor.

| Rules | Description |
|----------------|---------|
| Required | Requires value for the Rich Text Editor control.|
| MinLength | Requires the value to be of given minimum characters count.|
| MaxLength | Requires the value to be of given maximum characters count.|

This sample is demonstrated form validation using the `DataAnnotationsValidator`.

{% tabs %}
{% highlight razor tabtitle="~/validation-rules.razor" %}

@using Syncfusion.Blazor.RichTextEditor
@using System.ComponentModel.DataAnnotations;

<EditForm Model="@MyForm">
    <DataAnnotationsValidator />
    <p>
        <label for="description">Enter Text</label>
        <SfRichTextEditor ShowCharCount="true" MaxLength="200" Placeholder="Type something" @bind-Value="@MyForm.Description">
        </SfRichTextEditor>
        <ValidationMessage For="@(() => MyForm.Description)"></ValidationMessage>
    </p>
    <button class="e-btn" type="submit">Submit</button>
</EditForm>

@code{
    public class Form
    {
        [Required]
        [MinLength(20, ErrorMessage = "Please enter at least 20 characters.")]
        public string Description { get; set; } = "<div>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</div>";
    }
    private Form MyForm = new Form();
}

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/validation-rules.razor %}

{% endhighlight %}

![Char Count Validation in Blazor RichTextEditor](./images/blazor-richtexteditor-char-count-validation.png)


## Custom Placement of Validation Message

The Form Validation error message can be placed from default position to desired custom location.

{% tabs %}
{% highlight razor tabtitle="~/custom-placement-validation-message.razor" %}

@using Syncfusion.Blazor.RichTextEditor
@using System.ComponentModel.DataAnnotations;

<EditForm Model="@MyForm">
    <p>
        <ValidationMessage For="@(() => MyForm.Description)"></ValidationMessage>
    </p>
    <DataAnnotationsValidator />
    <p>
        <label for="description">Enter Text</label>
        <SfRichTextEditor ShowCharCount="true" MaxLength="200" Placeholder="Type something" @bind-Value="@MyForm.Description">
        </SfRichTextEditor>
    </p>
    <button class="e-btn" type="submit">Submit</button>
</EditForm>

@code{
    public class Form
    {
        [Required(ErrorMessage = "RTE: value is required")]
        [MinLength(15, ErrorMessage = "RTE: Need atleast 15 character length")]
        [MaxLength(100, ErrorMessage = "RTE: Maximum 200 characters only")]
        public string Description { get; set; } = "<div>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</div>";
    }
    private Form MyForm = new Form();
}

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/custom-placement-validation-message.razor %}

{% endhighlight %}

![Blazor RichTextEditor Validation in Custom placement](./images/blazor-richtexteditor-validation-placement.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.