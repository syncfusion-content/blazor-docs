---
layout: post
title: Fluent UI and Validation with Syncfusion Blazor components
description: Checkout and learn about the documentation for building an accessible Fluent UI registration form using Syncfusion Blazor components in Blazor Server App.
platform: Blazor
component: Common
documentation: ug
---

# Integrating Fluent UI Component and Validation with Blazor Components

This guide demonstrates how to integrate **Fluent UI Component** and validation with **Syncfusion Blazor components** to create a **Registration Form** in a Blazor Server App using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Create a new Blazor App in Visual Studio

A Blazor Server application can be created in Visual Studio by using the following link:

* [Create a Blazor Server Application](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

## Install Required NuGet Packages

### Step 1: Install Syncfusion Packages

Open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install the following packages:

* Syncfusion.Blazor.Inputs
* Syncfusion.Blazor.Buttons
* Syncfusion.Blazor.Popups
* Syncfusion.Blazor.Themes

Alternatively, run the following commands in the Package Manager Console:

```powershell
Install-Package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Buttons -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Popups -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
```

### Step 2: Install Fluent UI Package

Search and install [Microsoft.FluentUI.AspNetCore.Components](https://www.nuget.org/packages/microsoft.FluentUI.AspNetCore.Components).

Alternatively, run the following command in the Package Manager Console:

```powershell
Install-Package Microsoft.FluentUI.AspNetCore.Components -Version 4.14.0
```

## Step-by-Step Code Explanation

### **Step 1:** Create the EditForm Component

The `EditForm` component is a Blazor component that manages form state, validation, and submission. Bind it to the form model using the `Model` property and handle form submission with the `OnValidSubmit` event.

{% tabs %}
{% highlight razor %}

@page "/"

<div class="form-container">
    <h2>Registration Form</h2>

    <EditForm Model="@RegistrationModel" OnValidSubmit="@HandleValidSubmit">
        <!-- Form fields go here -->
    </EditForm>
</div>

@code {
    private RegistrationFormModel RegistrationModel = new();

    private async Task HandleValidSubmit()
    {
        // Handle form submission
    }
    public class RegistrationFormModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool AgreeToTerms { get; set; } = false;
    }
}

{% endhighlight %}
{% endtabs %}

### **Step 2:** Add Validation Components

Form validation ensures that users provide valid data before submission. Add the following validation components:

* **DataAnnotationsValidator** - Automatically validates form fields using C# data annotation attributes such as `[Required]`, `[EmailAddress]`, `[StringLength]`, etc.
* **FluentValidationSummary** - Displaying validation errors in one place helps users quickly identify and fix issues.

```razor
<DataAnnotationsValidator />
<FluentValidationSummary Model="@RegistrationModel.FirstName" />
```

### **Step 3:** Add Form Input Fields

Add text input fields using the Syncfusion `SfTextBox` component to collect user information. The `@bind-Value` directive enables two-way data binding, automatically synchronizing user input with the form model. The `ValidationMessage` component displays validation errors when required fields are empty.

{% tabs %}
{% highlight razor %}

<SfTextBox @bind-Value="@RegistrationModel.FirstName"
            Label="First Name"
            Placeholder="Enter your first name"
            Required="true"
            aria-label="First Name" />
<ValidationMessage For="@(() => RegistrationModel.FirstName)" />

<SfTextBox @bind-Value="@RegistrationModel.Email"
            Label="Email Address"
            Type="InputType.Email"
            Placeholder="your.email@example.com"
            Required="true"
            aria-label="Email Address" />
<ValidationMessage For="@(() => RegistrationModel.Email)" />

<SfTextBox @bind-Value="@RegistrationModel.Password"
            Label="Password"
            Type="InputType.Password"
            Placeholder="Enter a strong password"
            Required="true"
            aria-label="Password" />
<ValidationMessage For="@(() => RegistrationModel.Password)" />

{% endhighlight %}
{% endtabs %}

### **Step 4:** Add Form Action Buttons

Add submit and clear buttons to complete the form. The **Register button** (Submit type) validates all form fields before submission. The **Clear button** resets all fields to empty values using the `ResetForm()` method.

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

## Integrating Fluent UI Validation with Blazor Components

The following code example demonstrates how to integrate Fluent UI component and validation with Syncfusion Blazor components for a complete registration form.

{% tabs %}
{% highlight c# tabtitle="~/Home.razor" %}

@page "/"

@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Microsoft.FluentUI.AspNetCore.Components
@using Syncfusion.Blazor.Popups

<div class="form-container">
    <h2>Registration Form</h2>

    <EditForm Model="@RegistrationModel" OnValidSubmit="@HandleValidSubmit">
        <DataAnnotationsValidator />
        <FluentValidationSummary Model="@RegistrationModel.FirstName" />
        <div class="form-group">
            <label>First Name:</label>
            <SfTextBox @bind-Value="@RegistrationModel.FirstName"
                        Label="First Name"
                        Placeholder="Enter your first name"
                        Required="true"
                        aria-label="First Name" />
            <ValidationMessage For="@(() => RegistrationModel.FirstName)" />
        </div>

        <div class="form-group">
            <label>E-mail Id:</label>
            <SfTextBox @bind-Value="@RegistrationModel.Email"
                        Label="Email Address"
                        Type="InputType.Email"
                        Placeholder="your.email@example.com"
                        Required="true"
                        aria-label="Email Address" />
            <ValidationMessage For="@(() => RegistrationModel.Email)" />
        </div>

        <div class="form-group">
            <label>Password:</label>
            <SfTextBox @bind-Value="@RegistrationModel.Password"
                        Label="Password"
                        Type="InputType.Password"
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
        <SfDialog Target="#target" @ref="DialogObj" Width="300px" Visible="false" ShowCloseIcon="true">
            <DialogTemplates>
                <Header>Status</Header>
                <Content>@DialogContent</Content>
            </DialogTemplates>
            <DialogButtons>
                <DialogButton Content="OK" IsPrimary="true" OnClick="@OnOkClick" />
            </DialogButtons>
        </SfDialog>
    </EditForm>
</div>

@code {
    private RegistrationFormModel RegistrationModel = new();
    private SfDialog DialogObj { get; set; }
    private string DialogContent { get; set; } = "Loading...";
    private void OnOkClick()
    {
        // Place your OK logic here
        RegistrationModel = new();
    }

    private async Task HandleValidSubmit()
    {
        DialogContent = "Form Submitted Successfully!";
        await DialogObj.ShowAsync();
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
        border-radius: 8px;
    }

    .form-group {
        margin-top:20px;
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

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the complete registration form in the default web browser.

