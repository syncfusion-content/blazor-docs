---
layout: post
title: Types of Validation in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about different types of validation that can be used in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Validation in DataForm component

DataForm provides the capability to utilize both standard and custom validators that are compatible with the [EditForm](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform?view=aspnetcore-7.0) component. Such as [DataAnnotationsValidator](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.dataannotationsvalidator?view=aspnetcore-7.0) , [ObjectGraphDataAnnotationsValidator ](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-8.0#nested-models-collection-types-and-complex-types) etc...We can specify the required validators inside `FormValidator` RenderFragment of the DataForm component , The following examples illustrate the procedures for setting up the component with various validators.

## Data annotation validation

`DataAnnotationsValidator` in DataForm component validates the fields based on the attributes bounded to the model properties. 

{% tabs %}
{% highlight razor tabtitle="DataAnnotationsValidator"  %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs

<SfDataForm ID="MyForm"
            Model="@SignUpModel"
            Width="50%"
            ButtonsAlignment="FormButtonsAlignment.Right">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
        <ValidationSummary></ValidationSummary>
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(SignUpModel.FirstName)" LabelText="First Name"></FormItem>
        <FormItem Field="@nameof(SignUpModel.LastName)" LabelText="Last Name"> </FormItem>
        <FormItem Field="@nameof(SignUpModel.Email)" LabelText="Email Id"> </FormItem>
        <FormItem Field="@nameof(SignUpModel.Password)" LabelText="Password" EditorType="FormEditorType.Password"> </FormItem>
        <FormItem Field="@nameof(SignUpModel.ConfirmPassword)" LabelText="Confirm Password" EditorType="FormEditorType.Password"> </FormItem>
        <FormItem Field="@nameof(SignUpModel.Accept)" LabelText="Agree to the terms and conditions"> </FormItem>
    </FormItems>

    <FormButtons>
        <SfButton>SignUp</SfButton>
    </FormButtons>

</SfDataForm>


@code {

    public class SignUpDetails
    {

        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter the email id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to agree to the Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree to the Terms and Conditions")]
        public bool Accept { get; set; }
    }

    private SignUpDetails SignUpModel = new SignUpDetails();
}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm DataAnnotationsValidator](images/blazor_dataform_dataannotationsvalidator.png)

## Validation Message Display

Within the DataForm component, we have the option to showcase validation messages in two distinct styles: inline or via a tooltip. When applying inline display, the validation messages remain statically visible whenever validation occurs. On the other hand, tooltip display reveals validation messages to users upon request. Additionally, there is functionality to hide the validation messages as desired by using [ValidationDisplayMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_ValidationDisplayMode) . The classifications of the respective property are outline below 

| FormValidationDisplay | Snapshot |
| ------------ | ----------------------- |
|[FormValidationDisplay.Inline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormValidationDisplay.html#Syncfusion_Blazor_DataForm_FormValidationDisplay_Inline)|![DataForm FormValidationDisplay.Inline](images/blazor_dataform_validation_display_inline.png)|
|[FormValidationDisplay.Tooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormValidationDisplay.html#Syncfusion_Blazor_DataForm_FormValidationDisplay_Tooltip)|![DataForm FormValidationDisplay.Tooltip](images/blazor_dataform_validation_display_tooltip.png)|
|[FormValidationDisplay.None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormValidationDisplay.html#Syncfusion_Blazor_DataForm_FormValidationDisplay_None)|![DataForm FormValidationDisplay.None](images/blazor_dataform_validation_display_none.png)|

The below example demonstrate , how to configure validation message presentation with DataForm component

{% tabs %}
{% highlight razor tabtitle="Validation Message Display"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Width="50%"
            Model="@RegistrationDetailsModel"
            ValidationDisplayMode="FormValidationDisplay.Tooltip">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    public class RegistrationDetails
    {

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }
    }

    private RegistrationDetails RegistrationDetailsModel = new RegistrationDetails();
}

{% endhighlight %}
{% endtabs %}

## Complex model validation 

The `ObjectGraphDataAnnotationsValidator` within the DataForm component ensures the validation of the entire object graph of the bound model, including both collection and complex-type properties.In the below example  `ValidateComplexType` attribute is used  to validate the properties declared in the nested classes such as `ChildModel` and `GrandChildModel`.

{% tabs %}
{% highlight razor tabtitle="ObjectGraphDataAnnotationsValidator"  %}

@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.DataForm

<h3>Complex type validation</h3>

<div class="mt-4" style="margin: 0 auto;">
    <SfDataForm Model="@MyModel" Width="50%">
        <FormValidator>
            <ObjectGraphDataAnnotationsValidator></ObjectGraphDataAnnotationsValidator>
        </FormValidator> 
        <FormItems>
            <FormItem Field="@nameof(MyModel.Name)"  LabelText="Name"></FormItem>
            <FormItem Field="@nameof(MyModel.Child.GrandChild.Email)" LabelText="Email" Placeholder="someone@example.com"> </FormItem>
            <FormItem Field="@nameof(MyModel.Child.GrandChild.Password)" EditorType="FormEditorType.Password"  LabelText="Password"></FormItem>
            <FormItem Field="@nameof(MyModel.Child.GrandChild.ConfirmPassword)" EditorType="FormEditorType.Password" LabelText="Confirm Password"></FormItem>
        </FormItems>
    </SfDataForm>
</div>
@code {
    UserDetails MyModel { get; set; } = new UserDetails();

    abstract class Credential
    {
       
        [Required(ErrorMessage = "Enter Password here")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Confirm Password here")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter Email here")]
        public string Email { get; set; }
    }

    class GrandChildModel : Credential
    {
    }

    class ChildModel : Credential
    {
        [ValidateComplexType]
        public GrandChildModel GrandChild { get; set; }

        public ChildModel()
        {
            GrandChild = new GrandChildModel();
        }
    }

    class UserDetails : Credential
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter FirstName here")]
        public string Name { get; set; }

        [ValidateComplexType]
        public ChildModel Child { get; set; }

        public UserDetails()
        {
            Child = new ChildModel();
        }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm ObjectGraphDataAnnotationsValidator](images/blazor_dataform_complextypevalidation.png)

## Fluent validation 

`FluentValidator` is a custom validator that validates beyond standard validation attributes. It allows for checking if field values conform to the credit card format, match a specific value, exceed or fall below a given value, or are equivalent to the value of another field within the same model.

{% tabs %}
{% highlight razor tabtitle="FluentValidator.razor"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Microsoft.AspNetCore.Components.Forms
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Calendars;
@using FluentValidation
@using Blazored.FluentValidation

<SfDataForm ID="MyForm"
            Model="@PaymentDetailsModel"
            Width="50%">
    <FormValidator>
        <FluentValidationValidator Validator="PaymentDetailsValidation" />
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(PaymentDetailsModel.Name)" LabelText="Full Name on Card"></FormItem>
        <FormItem Field="@nameof(PaymentDetailsModel.CardNumber)" LabelText="Card Number"></FormItem>
        <FormItem Field="@nameof(PaymentDetailsModel.ExpirationDate)" LabelText="Expiration Date">
            <Template>
                <label class="e-form-label">Expiration Date</label>
                <SfDatePicker EnableMask="true" Format="MM/yy" @bind-Value="@PaymentDetailsModel.ExpirationDate">
                </SfDatePicker>
            </Template>
        </FormItem>
        <FormItem Field="@nameof(PaymentDetailsModel.CVV)">
            <Template>
                <label class="e-form-label">CVV/CVC</label>
                <SfMaskedTextBox Mask="000" PromptChar="@PromptCharacter" @bind-Value="@PaymentDetailsModel.CVV"></SfMaskedTextBox>
            </Template>
        </FormItem>
        <FormItem Field="@nameof(PaymentDetailsModel.BillingAddress)" LabelText="Billing Address" EditorType="FormEditorType.TextArea">
        </FormItem>
        <FormItem Field="@nameof(PaymentDetailsModel.Accept)" EditorType="FormEditorType.Switch" LabelText="I agree to the terms and conditions"></FormItem>
    </FormItems>

    <FormButtons>
        <SfButton>Pay</SfButton>
    </FormButtons>

</SfDataForm>

@code {

    char PromptCharacter { get; set; } = ' ';

    public class PaymentDetails
    {

        [Required(ErrorMessage = "Enter Name on the card")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Billing Address")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "Enter Card number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Enter Count here")]
        public DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessage = "Enter CVV/CVC")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "You need to agree to the Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree to the Terms and Conditions")]
        public bool Accept { get; set; }
    }

    private PaymentDetails PaymentDetailsModel = new PaymentDetails();

    PaymentDetailsValidator PaymentDetailsValidation = new PaymentDetailsValidator();
}

{% endhighlight %}

{% highlight razor tabtitle="PaymentDetailsValidator.cs"  %}

public class PaymentDetailsValidator : AbstractValidator<PaymentDetails>
{
    public PaymentDetailsValidator()
    {
        RuleFor(customer => customer.Name).NotEmpty().MinimumLength(3).WithMessage("Name should greater than 3 characters ").MaximumLength(50).WithMessage("Name should not contains more than 50 characters");
        RuleFor(customer => customer.CardNumber).NotEmpty().WithMessage("Please enter credit card number").CreditCard().WithMessage("Entered number is not a valid credit card number.");
        RuleFor(customer => customer.ExpirationDate).NotEmpty().WithMessage("Please enter expiration date");
        RuleFor(customer => customer.CVV).NotEmpty().Length(3);
        RuleFor(customer => customer.BillingAddress).NotEmpty().WithMessage("Please specify a billing address");
        RuleFor(customer => customer.Accept).Equal(true).WithMessage("You must accept the terms and conditions to proceed further");
    }
}
{% endhighlight %}

{% endtabs %}

![Blazor DataForm ObjectGraphDataAnnotationsValidator](images/blazor_dataform_fluentvalidation.png)

## See also

* Custom Validation

    * [Custom Validation attributes](./form-binding.md)