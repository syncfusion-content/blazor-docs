---
layout: post
title: Form Support in Blazor TextArea Component | Syncfusion
description: Checkout and learn about the Form support of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: TextArea
documentation: ug
---

# Form Support in Blazor TextArea Component

The TextArea component integrates with HTML forms and Blazor’s EditForm to capture and submit multiline text efficiently. Common scenarios include collecting detailed feedback, descriptions, and other long-form inputs as part of a form submission. For a Working example, see the TextArea forms and validation demo for a working example: TextArea forms and validation demo.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs
@using System.ComponentModel.DataAnnotations

<EditForm Model="@formModel" OnValidSubmit="HandleValidSubmit" OnInvalidSubmit="@HandleInvalidSubmit">
    <SfTextArea @bind-Value="@formModel.Address" Placeholder="Enter the Address" FloatLabelType="@FloatLabelType.Auto"></SfTextArea>
    <button type="submit">Submit</button>
</EditForm>

@code {
    private FormModel formModel = new FormModel();

    private void HandleValidSubmit()
    {
        // Handle the valid form submission here
    }

    private void HandleInvalidSubmit()
    {
        // Handle the invalid form submission here
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

By integrating The TextArea component with the `FormValidator` component, users can enforce validation rules specific to text inputs, such as required fields, minimum and maximum length constraints, pattern matching, and more. This ensures that user-submitted text data meets specified criteria and maintains data integrity.