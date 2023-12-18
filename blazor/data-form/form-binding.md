---
layout: post
title: Form Binding in Blazor DataForm Component | Syncfusion
description: Checkout and learn about form binding with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Form Binding with Blazor DataForm Component

This segment provides a concise overview of the concepts involved in associating a [Model](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform.model?view=aspnetcore-7.0#microsoft-aspnetcore-components-forms-editform-model) or [EditContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform.editcontext?view=aspnetcore-7.0#microsoft-aspnetcore-components-forms-editform-editcontext) with a Data Form. Additionally, it covers how to apply the attributes of properties that are defined within the model class.

## Model and EditContext binding 

The following example illustrates how the `Model` or `EditContext` are bound to the DataForm component using the user-defined `EventRegistration` model class.

{% tabs %}
{% highlight razor tabtitle="Model" hl_lines="3 10" %}

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
{% highlight razor tabtitle="Model" hl_lines="3 10" %}

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

![Blazor DataForm Model Binding](images/blazor_dataform_formbinding.png)

## Data Annotation Attributes

The DataForm component enables users to define the data annotation attributes available from the instance of [System.ComponentModel.DataAnnotations](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-5.0). For instance:

`[Display(Name = "Custom field name")]` - This attribute is used to set a custom name for the field, which will be shown as its label.

`[Editable(false)]` - When this attribute is used, it renders the associated field uneditable, thus preventing users from changing its content.

`[EmailAddress]` - This attribute checks to ensure that the value entered in the field conforms to a valid email address format.

For guidance on how to use some of these attributes in DataForm component, see the example provided below.

{% tabs %}
{% highlight razor tabtitle="Attributes" hl_lines="3 10" %}

@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

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
            RegistrationId = 1001,
            FirstName = "Andrew",
            LastName = "Jack"
        };

    public class EventRegistration
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Registration Id")]
        [Editable(false)]
        public int RegistrationId { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email-ID.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email ID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        public string PhoneNumber { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

![Blazor DataForm Model Binding](images/blazor_dataform_attributes.png)

### Custom Validation

Custom validation attributes can also be applied to model properties to execute necessary checks. In the following example, we've implemented validations for the `Email` and `Password` fields, specifically to particular scenario. 

{% tabs %}
{% highlight razor tabtitle="Custom Validation Attributes" hl_lines="3 10" %}

@using System;
@using System.ComponentModel.DataAnnotations;
@using Syncfusion.Blazor.DataForm;
@using System.Text.RegularExpressions;

<SfDataForm ID="MyForm"
            Model="@EmployeeModel"
            Width="50%">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormGroup LabelText="Sign Up Details">
            <FormItem Field="@nameof(EmployeeModel.Name)" LabelText="FirstName"></FormItem>
            <FormItem Field="@nameof(EmployeeModel.Email)" LabelText="Email Id"></FormItem>
            <FormItem Field="@nameof(EmployeeModel.Password)" LabelText="Password"> </FormItem>
            <FormItem Field="@nameof(EmployeeModel.ConfirmPassword)" LabelText="Confirm Password"> </FormItem>
        </FormGroup>
    </FormItems>
</SfDataForm>


@code {
    private EmployeeDetails EmployeeModel = new EmployeeDetails();

    public class EmployeeDetails
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [PasswordValidation(ErrorMessage = "This field should not be Empty")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm Password must match Password")]
        public string? ConfirmPassword { get; set; }

        [Required]
        [EmailValidation(ErrorMessage = "This field should not be Empty")]
        public string? Email { get; set; }
    }

    public class PasswordValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = value as string;

            if (fieldValue.Length < 10)
            {
                return new ValidationResult("Password should have at least 10 characters", new[] { validationContext.MemberName });
            }

            if (!Regex.IsMatch(fieldValue, @"[A-Z]"))
            {
                return new ValidationResult("Password should contain at least one uppercase letter", new[] { validationContext.MemberName });
            }

            if (!Regex.IsMatch(fieldValue, @"[a-z]"))
            {
                return new ValidationResult("Password should contain at least one lowercase letter", new[] { validationContext.MemberName });
            }

            if (!Regex.IsMatch(fieldValue, @"[@#$%^&+=]"))
            {
                return new ValidationResult("Password should contain at least one special character", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }

    public class EmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value as string;

            if (!IsValidEmail(email))
            {
                return new ValidationResult("Email address is not valid..", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$");
        }
    }
}
{% endhighlight %}
{% endtabs %}

![Blazor DataForm Custom Validation](images/blazor_dataform_customvalidation.png)
