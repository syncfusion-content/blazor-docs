---
layout: post
title: Form Binding in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about Model ,EditContext and Custom Validation attributes binding with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Data Annotation Attributes

The DataForm component enables users to define the data annotation attributes available from the instance of [System.ComponentModel.DataAnnotations](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-5.0). 

## Display attribute

The [DisplayAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute?view=net-5.0) class is used to specify the display name for a property. The display name is used as the label for the corresponding editor in the DataForm component if label text is not specified for the form item. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[Display(Name = "Name")]
public string Name { get; set; }

{% endhighlight %}
{% endtabs %}

## Required attribute

The [RequiredAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.requiredattribute?view=net-5.0) class is used to specify that a property is required. The DataForm component displays an error message if the property is empty. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[Required(ErrorMessage = "Name is required")]
public string Name { get; set; }

{% endhighlight %}
{% endtabs %}

## Range attribute

The [RangeAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.rangeattribute?view=net-5.0) class is used to specify the numeric range constraints for the value of a property. The DataForm component displays an error message if the property value is not within the specified range. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[Range(0, 100, ErrorMessage = "Age must be between 0 and 100")]
public int Age { get; set; }

{% endhighlight %}
{% endtabs %}

## Regular expression attribute

The [RegularExpressionAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.regularexpressionattribute?view=net-5.0) class is used to specify that a property value must match a specified regular expression. The DataForm component displays an error message if the property value does not match the specified regular expression. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only alphabets")]
public string Name { get; set; }

{% endhighlight %}
{% endtabs %}

## String length Attribute

The [StringLengthAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.stringlengthattribute?view=net-5.0) class is used to specify the minimum and maximum length constraints for the value of a property. The DataForm component displays an error message if the property value is not within the specified length constraints. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

 [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 5 and 10 characters")]
 public string Name { get; set; }

{% endhighlight %}
{% endtabs %}

## Min length Attribute

The [MinLengthAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.minlengthattribute?view=net-5.0) class is used to specify the minimum length constraints for the value of a property. The DataForm component displays an error message if the property value is not within the specified length constraints. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
public string Name { get; set; }

{% endhighlight %}
{% endtabs %}

## Max length Attribute

The [MaxLengthAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.maxlengthattribute?view=net-5.0) class is used to specify the maximum length constraints for the value of a property. The DataForm component displays an error message if the property value is not within the specified length constraints. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[MaxLength(10, ErrorMessage = "Name must be at most 10 characters")]
public string Name { get; set; }

{% endhighlight %}
{% endtabs %}

## Phone attribute

The [PhoneAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.phoneattribute?view=net-5.0) class is used to specify that a property value must match a specified phone number pattern. The DataForm component displays an error message if the property value does not match the specified phone number pattern. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[Phone(ErrorMessage = "Phone number is not valid")]
public string PhoneNumber { get; set; }

{% endhighlight %}
{% endtabs %}

## Email address attribute

The [EmailAddressAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.emailaddressattribute?view=net-5.0) class is used to specify that a property value must match a specified email address pattern. The DataForm component displays an error message if the property value does not match the specified email address pattern. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[EmailAddress(ErrorMessage = "Email address is not valid")]
public string Email { get; set; }

{% endhighlight %}
{% endtabs %}

## Url attribute

The [UrlAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.urlattribute?view=net-5.0) class is used to specify that a property value must match a specified URL pattern. The DataForm component displays an error message if the property value does not match the specified URL pattern. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[Url(ErrorMessage = "URL is not valid")]
public string Url { get; set; }

{% endhighlight %}
{% endtabs %}

## Enum DataType attribute

The [EnumDataTypeAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.enumdatatypeattribute?view=net-5.0) class is used to specify that a property value must be a member of the specified enumeration. The DataForm component displays an error message if the property value is not a member of the specified enumeration. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

 [EnumDataType(typeof(Gender), ErrorMessage = "Please enter a valid gender")]
 public string Gender { get; set; }

{% endhighlight %}
{% endtabs %}

## Compare attribute

The [CompareAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.compareattribute?view=net-5.0) class is used to specify that a property value must match the value of another property in the same class. The DataForm component displays an error message if the property value does not match the value of the other property. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[Compare("Password", ErrorMessage = "Passwords do not match")]
public string ConfirmPassword { get; set; }

{% endhighlight %}
{% endtabs %}

## Editable attribute

The [EditableAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.editableattribute?view=net-5.0) class is used to specify that a property can be edited in the DataForm component. 

{% tabs %}
{% highlight C# tabtitle="C#"  %}

[Editable(false)]
public string ID { get; set; }

{% endhighlight %}
{% endtabs %}

## Custom validation attribute

A [custom validation attribute](https://learn.microsoft.com/en-us/previous-versions/aspnet/cc668224(v=vs.100)#creating-a-custom-validation-attribute) in .NET is a class that inherits from the [ValidationAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute?view=net-8.0&redirectedfrom=MSDN) abstract class and overrides the [IsValid](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute.isvalid?view=net-8.0#system-componentmodel-dataannotations-validationattribute-isvalid(system-object)) method. This method is called when the attribute is applied to a property and the property's value is being validated.

In the `IsValid` method, you can define your custom validation logic. If the validation fails, you return a [ValidationResult](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationresult?view=net-8.0) object with an error message. If the validation passes, you return `ValidationResult.Success`.

{% tabs %}
{% highlight razor tabtitle="Custom Validation Attributes"  %}

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
            <FormItem Field="@nameof(EmployeeModel.Name)" LabelText="Name"></FormItem>
            <FormItem Field="@nameof(EmployeeModel.Email)" LabelText="Email Id"></FormItem>
            <FormItem Field="@nameof(EmployeeModel.Password)" LabelText="Password" EditorType="FormEditorType.Password"> </FormItem>
            <FormItem Field="@nameof(EmployeeModel.ConfirmPassword)" LabelText="Confirm Password" EditorType="FormEditorType.Password"> </FormItem>
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

 In the above example, In the `PasswordValidationAttribute` class, the `IsValid` method checks if the password meets certain criteria (length, contains uppercase letter, contains lowercase letter, contains special character). If it doesn't, it returns a `ValidationResult` with an appropriate error message.In the `EmailValidationAttribute` class, the IsValid method checks if the email is in a valid format. If it's not, it returns a `ValidationResult` with an error message. 

![Blazor DataForm Custom Validation](images/blazor_dataform_customvalidation.png)