---
layout: post
title: Form Support in Blazor TextArea Component | Syncfusion
description: Checkout and learn about the Form support of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: Textarea
documentation: ug
---

# Form Support in Blazor TextArea Component

The TextArea component seamlessly integrates with HTML forms, enabling efficient submission of longer text data. By including TextArea inputs within HTML forms, users can conveniently input multiline text content and submit it as part of form submissions.

This integration enhances the usability of forms, allowing users to provide detailed feedback, enter lengthy descriptions, or input other multiline text data seamlessly.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs
@using System.ComponentModel.DataAnnotations

<EditForm Model="@formModel" OnValidSubmit="HandleValidSubmit">
    <SfTextArea @bind-Value="@formModel.Address" Placeholder="Enter the Address" FloatLabelType="@FloatLabelType.Auto"></SfTextArea>
    <button type="submit">Submit</button>
</EditForm>

@code {
    private FormModel formModel = new FormModel();

    private void HandleValidSubmit()
    {
        // Handle the valid form submission here
    }

    public class FormModel
    {
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Integration with FormValidator component

TextArea component seamlessly integrates with the `FormValidator` component, allowing users to incorporate textarea inputs into form validation processes efficiently.

By integrating TextArea component with the `FormValidator` component, users can enforce validation rules specific to text inputs, such as required fields, minimum and maximum length constraints, pattern matching, and more. This ensures that user-submitted text data meets specified criteria and maintains data integrity.
