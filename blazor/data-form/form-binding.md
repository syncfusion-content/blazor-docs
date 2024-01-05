---
layout: post
title: Form Binding in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about Model ,EditContext and Custom Validation attributes binding with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Form Binding with Blazor DataForm Component

This segment provides a concise overview of the concepts involved in associating a [Model](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform.model?view=aspnetcore-7.0#microsoft-aspnetcore-components-forms-editform-model) or [EditContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform.editcontext?view=aspnetcore-7.0#microsoft-aspnetcore-components-forms-editform-editcontext) with a Data Form.

## Model binding 

The following example illustrates how the `Model` is bound to the DataForm component using the user-defined `EventRegistration` model class.

{% tabs %}
{% highlight razor tabtitle="Model"  %}

@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm" Width="50%"
            Model="@EventRegistrationModel">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>
    <FormButtons>
        <SfButton typeof="submit">Register</SfButton>
    </FormButtons>
</SfDataForm>
@code {
    private EventRegistration EventRegistrationModel = new EventRegistration()
        {
            FirstName = "Andrew",
            LastName = "Jack"
        };

    public class EventRegistration
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email-ID.")]
        [Display(Name = "Email ID")]
        public string Email { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Model Binding](images/blazor_dataform_formbinding.png)

## EditContext binding 

The following example illustrates how the `EditContext` is bound to the DataForm component using the user-defined `EventRegistration` model class.

{% tabs %}
{% highlight razor tabtitle="EditContext"  %}

@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm" Width="50%"
            EditContext="@RegistrationEditContext">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>
    <FormButtons>
        <SfButton typeof="submit">Register</SfButton>
    </FormButtons>
</SfDataForm>

@code {
    EditContext RegistrationEditContext { get; set; }

    protected override void OnInitialized()
    {
        RegistrationEditContext = new EditContext(EventRegistrationModel);
        base.OnInitialized();
    }

    private EventRegistration EventRegistrationModel = new EventRegistration()
    {
        FirstName = "Andrew",
        LastName = "Jack"
    };

    public class EventRegistration
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email-ID.")]
        [Display(Name = "Email ID")]
        public string Email { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

