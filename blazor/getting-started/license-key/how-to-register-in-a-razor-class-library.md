---
layout: post
title: Overview of Syncfusion license registration - Syncfusion
description: Learn here about how to register Syncfusion blazor license key for syncfusion Blazor application with license validation.
platform: Blazor
component: Common
documentation: ug
---

# Register Syncfusion License Key in a Razor Class Library Application

The generated license key is just a string that might be registered before any Syncfusion control is initiated. The following code is used to register the license.

{% tabs %}
{% highlight c# %}

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}
{% endtabs %}

N> * Place the license key between double quotes.  Also, ensure that Syncfusion.Licensing.dll is referenced in your project where the license key is being registered.
* Syncfusion license validation is done offline during application execution and does not require internet access.  Apps registered with a Syncfusion license key can be deployed on any system that does not have an internet connection.

If your Razor Class Library (RCL) project uses Syncfusion Blazor packages from [nuget.org](https://www.nuget.org/packages?q=syncfusion) or the trial installer, you must register your license key. We need to register the license key in RCL project similar to how we do for the Blazor project based on your application type (Server application / Client WebAssembly application).

Refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/razor-class-library) for more information on getting started with the Syncfusion Blazor components in the RCL project.

## Blazor Web App

Open **~/Program.cs** file and register the Syncfusion Blazor license key in the Blazor web app.

{% tabs %}

{% highlight C# tabtitle="Blazor Web App" hl_lines="1 2" %}

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}

{% endtabs %}

## Blazor Server App

After configuring the RCL project with your Blazor Server application, register the license key in the Program.cs file.

* For .NET 6 and .NET 7 app, open the **~/Program.cs** file and register the Syncfusion license key.

{% tabs %}

{% highlight C# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="2 3" %}

var app = builder.Build();
//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

{% endhighlight %}

{% endtabs %}

## Blazor WebAssembly App

After configuring the RCL project with your Blazor Client WebAssembly application, register the license key in the Program.cs file.

{% tabs %}

{% highlight c# tabtitle="~/Program.cs" hl_lines="3 4" %}

    // Register Syncfusion license
    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}

{% endtabs %}

N> Refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/razor-class-library) for more information on getting started with RCL in the Blazor Server and Blazor Client WebAssembly application.