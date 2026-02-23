---
layout: post
title: Fluent UI Validation in Syncfusion Blazor components
description: Checkout and learn about the documentation for building an accessible Fluent UI styled registration form using Syncfusion Blazor components in Blazor Server App.
platform: Blazor
component: Common
documentation: ug
---

# Fluent UI Validation with Blazor Components

This section briefly explains how to include a **Fluent UI Registration Form** using Syncfusion Blazor components in a Blazor Server App using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor Server App** by using the **Blazor Web App** template in Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor Server App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) documentation.

Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) when creating a Blazor Server App.

## Install NuGet packages in the App

Open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install [Microsoft.FluentUI.AspNetCore.Components](https://www.nuget.org/packages/microsoft.FluentUI.AspNetCore.Components), [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/), [Syncfusion.Blazor.Buttons](https://www.nuget.org/packages/Syncfusion.Blazor.Buttons/), and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

Alternatively, run the following commands in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.FluentUI.AspNetCore.Components -Version 4.14.0
Install-Package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Buttons -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet packages list with component details.

## Add Import Namespaces

Open the **~/_Imports.razor** file and import the following namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Microsoft.FluentUI.AspNetCore.Components

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of the Blazor Server App.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in Blazor application.

## Add Form Component

Add the Form component in the **~/Components/Pages/Home.razor** file. If the interactivity location is set to `Per page/component`, define a render mode at the top of the page.

N> If an Interactivity Location is set to `Global` and the **Render Mode** is set to `Server`, the render mode is configured in the `App.razor` file by default.

```razor
@* desired render mode define here *@
@rendermode InteractiveServer
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

### **Step 2:** Add Validation

Form validation ensures that users provide valid data before submission. Syncfusion and Fluent UI offer built-in validation components:

* **DataAnnotationsValidator** - Automatically validates form fields using C# data annotation attributes such as `[Required]`, `[EmailAddress]`, `[StringLength]`, etc.
* **FluentValidationSummary** - Displaying validation errors in one place helps users quickly identify and fix issues.

```razor
<DataAnnotationsValidator />
<FluentValidationSummary Model="@RegistrationModel.FirstName" />
```

### **Step 3:** Add Form Input Fields

Add text input fields using the Syncfusion `SfTextArea` component to collect user information. The `@bind-Value` directive enables two-way data binding, automatically synchronizing user input with the form model. The `ValidationMessage` component displays validation errors when required fields are empty.

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

The following code example demonstrates how to integrate Fluent UI validation with Syncfusion Blazor components for a complete registration form.

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
        border-radius: 8px;
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

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the complete registration form in the default web browser.

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-integrations-common).
