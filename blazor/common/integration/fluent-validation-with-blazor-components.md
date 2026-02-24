---
layout: post
title: Building an Accessible Registration Form with Syncfusion and Fluent UI Components
description: Learn how to build an accessible registration form using Syncfusion Blazor components with Fluent UI's ValidationSummary in a Blazor Server App.
platform: Blazor
component: Common
documentation: ug
---

# Integrating Fluent UI ValidationSummary with Syncfusion Blazor Components

This guide demonstrates how to integrate **Syncfusion Blazor components** with **Fluent UI's ValidationSummary** component to create an accessible **Registration Form** in a Blazor Server App using [Visual Studio](https://visualstudio.microsoft.com/vs/). You'll learn form validation best practices, accessibility standards, and proper component integration.

## Create a new Blazor App in Visual Studio

A Blazor Server application can be created in Visual Studio by using the following link:

* [Create a Blazor Server Application](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

## Install Required NuGet Packages

### Step 1: Install Syncfusion Packages

Open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install the following packages:

* Syncfusion.Blazor.Inputs
* Syncfusion.Blazor.Buttons
* Syncfusion.Blazor.Popups

Alternatively, run the following commands in the Package Manager Console:

```powershell
Install-Package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Buttons -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Popups -Version {{ site.releaseversion }}
```

### Step 2: Install Fluent UI Package

Search and install [Microsoft.FluentUI.AspNetCore.Components](https://www.nuget.org/packages/microsoft.FluentUI.AspNetCore.Components).

Alternatively, run the following command in the Package Manager Console:

```powershell
Install-Package Microsoft.FluentUI.AspNetCore.Components -Version {{ site.releaseversion }}
```

## Configure Project Settings

### Step 1: Register Services in Program.cs

Add the following services to the `Program.cs` file to enable Syncfusion and Fluent UI components:

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 4 12 13" %}

....
....
using Microsoft.FluentUI.AspNetCore.Components;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
....
....

builder.Services.AddSyncfusionBlazor();
builder.Services.AddFluentUIComponents();

....

{% endhighlight %}
{% endtabs %}

### Step 2: Configure _Imports.razor

Open the **~/_Imports.razor** file and import the following namespaces.

```razor
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups
@using Microsoft.FluentUI.AspNetCore.Components
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

Form validation ensures that users provide valid data before submission. Add the following validation components to the `EditForm`:

* **DataAnnotationsValidator** - Automatically validates form fields using C# data annotation attributes such as `[Required]`, `[EmailAddress]`, `[StringLength]`, etc.
* **FluentValidationSummary** - Displays validation errors in one place, helping users quickly identify and fix issues. Bind it to the entire form model.

```razor
<EditForm Model="@RegistrationModel" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <FluentValidationSummary Model="@RegistrationModel" />
    <!-- Form fields go here -->
</EditForm>
```

### **Step 3:** Add Form Input Fields

Add input fields using the Syncfusion `SfTextBox` component to collect user information. The `@bind-Value` directive enables two-way data binding, automatically synchronizing user input with the form model. The `Label` property creates accessible labels, and the `ValidationMessage` component displays validation errors below each field.

{% tabs %}
{% highlight razor %}

<div class="form-group">
    <SfTextBox @bind-Value="@RegistrationModel.FirstName"
                Label="First Name"
                Placeholder="Enter your first name"
                Required="true"
                aria-label="First Name" />
    <ValidationMessage For="@(() => RegistrationModel.FirstName)" />
</div>

<div class="form-group">
    <SfTextBox @bind-Value="@RegistrationModel.Email"
                Label="Email Address"
                Type="InputType.Email"
                Placeholder="your.email@example.com"
                Required="true"
                aria-label="Email Address" />
    <ValidationMessage For="@(() => RegistrationModel.Email)" />
</div>

<div class="form-group">
    <SfTextBox @bind-Value="@RegistrationModel.Password"
                Label="Password"
                Type="InputType.Password"
                Placeholder="Enter a strong password"
                Required="true"
                aria-label="Password" />
    <ValidationMessage For="@(() => RegistrationModel.Password)" />
</div>

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

## Complete Example: Integrating Fluent UI ValidationSummary with Syncfusion Blazor Components

The following code example demonstrates how to integrate Fluent UI's ValidationSummary with Syncfusion Blazor components to create a complete, accessible registration form.

{% tabs %}
{% highlight c# tabtitle="~/Home.razor" %}

@page "/"

<div class="form-container">
    <h2>Registration Form</h2>

    <EditForm Model="@RegistrationModel" OnValidSubmit="@HandleValidSubmit">
        <!-- Validates the form model and displays any errors -->
        <DataAnnotationsValidator />
        <FluentValidationSummary Model="@RegistrationModel" />

        <!-- First Name Field -->
        <div class="form-group">
            <SfTextBox @bind-Value="@RegistrationModel.FirstName"
                        Label="First Name"
                        Placeholder="Enter your first name"
                        Required="true"
                        aria-label="First Name" />
            <ValidationMessage For="@(() => RegistrationModel.FirstName)" />
        </div>

        <!-- Email Field -->
        <div class="form-group">
            <SfTextBox @bind-Value="@RegistrationModel.Email"
                        Label="Email Address"
                        Type="InputType.Email"
                        Placeholder="your.email@example.com"
                        Required="true"
                        aria-label="Email Address" />
            <ValidationMessage For="@(() => RegistrationModel.Email)" />
        </div>

        <!-- Password Field -->
        <div class="form-group">
            <SfTextBox @bind-Value="@RegistrationModel.Password"
                        Label="Password"
                        Type="InputType.Password"
                        Placeholder="Enter a strong password (min. 8 characters)"
                        Required="true"
                        aria-label="Password" />
            <ValidationMessage For="@(() => RegistrationModel.Password)" />
        </div>

        <!-- Terms Agreement Checkbox -->
        <div class="form-group">
            <SfCheckBox @bind-Checked="@RegistrationModel.AgreeToTerms"
                        Label="I agree to the terms and conditions"
                        aria-label="Agree to Terms and Conditions" />
            <ValidationMessage For="@(() => RegistrationModel.AgreeToTerms)" />
        </div>

        <!-- Form Action Buttons -->
        <div class="form-actions">
            <SfButton Type="ButtonType.Submit" Appearance="Appearance.Accent">
                Register
            </SfButton>
            <SfButton Type="ButtonType.Button" Appearance="Appearance.Neutral" OnClick="@ResetForm">
                Clear
            </SfButton>
        </div>

        <!-- Status Dialog -->
        <SfDialog @ref="DialogObj" Width="300px" Visible="false" ShowCloseIcon="true">
            <DialogTemplates>
                <Header>Form Submission Status</Header>
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
    private string DialogContent { get; set; } = string.Empty;

    /// <summary>
    /// Handles successful form submission after all validations pass.
    /// </summary>
    private async Task HandleValidSubmit()
    {
        try
        {
            DialogContent = "Form submitted successfully! Your registration has been processed.";
        }
        catch (Exception ex)
        {
            DialogContent = $"An error occurred: {ex.Message}";
        }
        
        await DialogObj.ShowAsync();
    }

    /// <summary>
    /// Closes the dialog and resets the form model.
    /// </summary>
    private void OnOkClick()
    {
        RegistrationModel = new();
    }

    /// <summary>
    /// Resets all form fields to empty values.
    /// </summary>
    private void ResetForm()
    {
        RegistrationModel = new();
    }

    /// <summary>
    /// Data model for the registration form with validation attributes.
    /// </summary>
    public class RegistrationFormModel
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must agree to the terms and conditions to proceed")]
        public bool AgreeToTerms { get; set; } = false;
    }
}

<style>
    .form-container {
        max-width: 500px;
        margin: 2rem auto;
        padding: 2rem;
        border-radius: 8px;
        box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
    }

    h2 {
        text-align: center;
        margin-bottom: 1.5rem;
        color: #333;
    }

    .form-group {
        margin-bottom: 1.5rem;
    }

    .form-group:focus-within {
        outline: 2px solid transparent;
    }

    .form-actions {
        display: flex;
        gap: 1rem;
        margin-top: 2rem;
        justify-content: center;
    }

    .form-actions ::deep button {
        min-width: 100px;
    }
</style>

{% endhighlight %}
{% endtabs %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the complete registration form in the default web browser.
