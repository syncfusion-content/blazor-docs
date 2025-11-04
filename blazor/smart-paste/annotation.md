---
layout: post
title: Annotaions in Blazor Smart Paste Button Component | Syncfusion
description: Checkout and learn here about Annotaions in Syncfusion Blazor Smart Paste Button component and much more.
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# Annotations in Blazor Smart Paste Button Component

## Annotating form fields

By default, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor `Smart Paste Button` analyzes form fields like `<input>`, `<select>`, and `<textarea>` elements, generating descriptions based on their associated `<label>`, `name` attribute, `id` attribute or nearby text content. These descriptions are then sent to the back end AI model to assist in accurately pasting the relevant data. However, for more control, you can override the default behavior by specifying custom descriptions for specific input field using the `data-smartpaste-description` attribute.

```cshtml
@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.SmartComponents
@using Syncfusion.Blazor.Inputs

<SfDataForm ID="MyForm"
            Model="@EventRegistrationModel">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(EventRegistration.Name)" ID="firstname"></FormItem>
        <FormItem Field="@nameof(EventRegistration.DateOfBirth)">
            <Template>
                <label class="e-form-label">Date of Birth</label>
                <SfTextBox HtmlAttributes="DateOfBirth"
                           ID="dateofbirth" />
            </Template>
        </FormItem>
        <FormItem Field="@nameof(EventRegistration.Email)" ID="email"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Phone)" ID="phonenumber"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Address)" ID="address"></FormItem>
    </FormItems>
    <FormButtons>
        <SfSmartPasteButton IsPrimary="true" Content="Smart Paste" IconCss="e-icons e-paste">
        </SfSmartPasteButton>
    </FormButtons>
</SfDataForm>

<br>
<h4 style="text-align:center;">Sample content</h4>
<div>
    Hi, my name is Jane Smith. You can reach me at example@domain.com or call me at +1-555-987-6543. I live at 789 Pine Avenue, Suite 12, Los Angeles, CA 90001. I was born on 15th March 1990.
</div>

@code {
    private EventRegistration EventRegistrationModel = new EventRegistration();

    Dictionary<string, object> DateOfBirth = new Dictionary<string, object>()
    {
        { "data-smartpaste-description", "Date must follow the format: DD-MM-YYYY" }
    };

    public class EventRegistration
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [Display(Name = "Email ID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your mobile number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your DOB.")]
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }
    }
}
```

N> In this example, the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataForm](https://blazor.syncfusion.com/documentation/data-form/getting-started-with-web-app) component is used to manage form input fields. To get started, ensure you have the [Syncfusion.Blazor.DataForm](https://www.nuget.org/packages/Syncfusion.Blazor.DataForm) package installed.

![Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart paste button with annotation](images/smart-paste-annotation.gif)

N> [View Sample in GitHub](https://github.com/syncfusion/smart-ai-samples).

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Paste Button in Blazor Web App](https://blazor.syncfusion.com/documentation/)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Paste Button in Blazor Server App](https://blazor.syncfusion.com/documentation/)
