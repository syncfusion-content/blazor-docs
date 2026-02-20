---
layout: post
title: Fluent Validation with Syncfusion Blazor Components
description: Fluent styled registration form using Syncfusion Blazor components. It includes setup, accessibility, theming, and validation.
platform: Blazor
control: Common
documentation: ug
---

# Fluent UI Validation with Blazor Components

This document explains a Blazor sample that implements a Fluent-styled registration form using Syncfusion Blazor components (`SfDataForm`, `SfTextArea`, `SfCheckBox`, and `SfButton`). It includes setup, annotated code walkthrough, accessibility notes, theming, validation, troubleshooting, and improvements.

## Prerequisites

* .NET SDK: .NET 9 or .NET 10
* Visual Studio 2022 or Visual Studio 2026

## Install NuGet Packages

Ensure the following packages installed in the application.

{% tabs %}

{% highlight C# tabtitle="Package Manager" %}

* Microsoft.FluentUI.AspNetCore.Components
* Syncfusion.Blazor.DataForm
* Syncfusion.Blazor.Inputs
* Syncfusion.Blazor.Buttons
* Syncfusion.Blazor.Themes

{% endhighlight %}

{% endtabs %}

## Integrating Fluent UI with Blazor Forms

This section explains structure and functionality of the Registration Form built using Blazor, Syncfusion components and FluentValidation. This form shows basic user information and validate the input using the validation process.

Refer the following steps to create a Form and validate it.

**Step 1:** Create a form and title

{% tabs %}
{% highlight razor %}

@page "/"

<div class="form-container">
    <h2>Registration Form</h2>

    <EditForm Model="@RegistrationModel" OnValidSubmit="@HandleValidSubmit">
</div>

@code {
    private RegistrationFormModel RegistrationModel = new();

    private void HandleValidSubmit()
    {
        // Handle form submission
        Console.WriteLine("Form submitted successfully!");
    }
}

{% endhighlight %}
{% endtabs %}

* `EditForm` is Blazor's component for creating a forms.
* `Model` links to the data model (RegistrationModel) from form fiels.
* `OnValidSubmit` triggers only when all the validation rules passed.

**Step 2:** Validation components

{% tabs %}
{% highlight razor %}

<DataAnnotationsValidator />
<FluentValidationSummary Model="@RegistrationModel.FirstName" />

{% endhighlight %}
{% endtabs %}

* `DataAnnotationsValidator` is enables Blazor's built-in validation using attributes such as [Required], [EmailAddress], and etc.
* `FluentValidationSummary` is a UI component that shows all validation errors. It is specifically used to validate the Syncfusion Blazor components inside an EditForm and show their FluentValidation error messages to the user.

**Step 3:** Add the Syncfusion Form fields (Input, Buttons components)

{% tabs %}
{% highlight razor %}

<SfTextArea @bind-Value="@RegistrationModel.FirstName"
            Label="First Name"
            Placeholder="Enter your first name"
            Required="true"
            aria-label="First Name" />
<ValidationMessage For="@(() => RegistrationModel.FirstName)" />

{% endhighlight %}
{% endtabs %}

* `@bind-value` links the input to the model.
* `Required="true"` adds the Syncfusion UI validation.
* `ValidationMessage` shows the errors validation for the field.
* Additional FluentValidation message appear in `FluentValidationSummary`.

**Step 4:** Add the Buttons for submit and clear the forms.

{% tabs %}
{% highlight razor %}

<SfButton Type="ButtonType.Submit" Appearance="Appearance.Accent">
    Register
</SfButton>
<SfButton Type="ButtonType.Button" Appearance="Appearance.Neutral" OnClick="@ResetForm">
    Clear
</SfButton>

@code{
    private void ResetForm()
    {
        RegistrationModel = new();
    }
}

{% endhighlight %}
{% endtabs %}

**Step 5:** After understanding the purpose of each section in the form, the complete source code for the registration form is provided below.

{% tabs %}
{% highlight c# tabtitle="~/Home.razor" %}

@page "/"

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Microsoft.FluentUI.AspNetCore.Components

<div class="form-container">
    <h2>Fluent UI Registration Form</h2>

    <EditForm Model="@RegistrationModel" OnValidSubmit="@HandleValidSubmit">
        <DataAnnotationsValidator />
        <FluentValidationSummary Model="@RegistrationModel.FirstName" />
        <div class="form-group">
            <SfTextArea @bind-Value="@RegistrationModel.FirstName"
                        Label="First Name"
                        Placeholder="Enter your first name"
                        Required="true"
                        aria-label="First Name" />
            <ValidationMessage For="@(() => RegistrationModel.FirstName)" />
        </div>

        <div class="form-group">
            <SfTextArea @bind-Value="@RegistrationModel.Email"
                        Label="Email Address"
                        Type="email"
                        Placeholder="your.email@example.com"
                        Required="true"
                        aria-label="Email Address" />
            <ValidationMessage For="@(() => RegistrationModel.Email)" />
        </div>

        <div class="form-group">
            <SfTextArea @bind-Value="@RegistrationModel.Password"
                        Label="Password"
                        Type="password"
                        Placeholder="Enter a strong password"
                        Required="true"
                        aria-label="Password" />
            <ValidationMessage For="@(() => RegistrationModel.Password)" />
        </div>

        <div class="form-group">
            <SfCheckBox @bind-Checked="@RegistrationModel.AgreeToTerms"
                        Label="I agree to the terms and conditions"
                        aria-label="Agree to Terms" />
            <ValidationMessage For="@(() => RegistrationModel.AgreeToTerms)" />
        </div>

        <div class="form-actions">
            <SfButton Type="ButtonType.Submit" Appearance="Appearance.Accent">
                Register
            </SfButton>
            <SfButton Type="ButtonType.Button" Appearance="Appearance.Neutral" OnClick="@ResetForm">
                Clear
            </SfButton>
        </div>
    </EditForm>
</div>

@code {
    private RegistrationFormModel RegistrationModel = new();

    private void HandleValidSubmit()
    {
        // Handle form submission
        Console.WriteLine("Form submitted successfully!");
    }

    private void ResetForm()
    {
        RegistrationModel = new();
    }

    public class RegistrationFormModel
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must agree to the terms")]
        public bool AgreeToTerms { get; set; } = false;
    }
}

<style>
    .form-container {
        max-width: 500px;
        margin: 2rem auto;
        padding: 2rem;
        /* border: 1px solid #e1e4e8; */
        border-radius: 8px;
        /* background-color: #f6f8fa; */
    }

    .form-group {
        margin-bottom: 1.5rem;
    }

    .form-actions {
        display: flex;
        gap: 1rem;
        margin-top: 2rem;
    }
</style>

{% endhighlight %}
{% endtabs %}

