---
layout: post
title: Register a Blazor license key in a Razor Class Library | Syncfusion
description: Learn how to register a Syncfusion Blazor license key in a Razor Class Library when using NuGet packages or evaluation builds. Explore to more details.
platform: Blazor
control: Common
documentation: ug
---

# Register a Syncfusion® license key in a Razor Class Library App

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key before any Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component is initialized. Place the key in the Razor Class Library (RCL) project so every consuming app inherits the registration.

{% tabs %}
{% highlight c# %}

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}
{% endtabs %}

N> * Place the license key between double quotes.  Also, ensure that Syncfusion.Licensing.dll is referenced in your project where the license key is being registered.
* Syncfusion<sup style="font-size:70%">&reg;</sup> license validation is done offline during application execution and does not require internet access.  Apps registered with a Syncfusion<sup style="font-size:70%">&reg;</sup> license key can be deployed on any system that does not have an internet connection.

If the RCL references Syncfusion Blazor packages from [nuget.org](https://www.nuget.org/packages?q=syncfusion) or from the trail installer, register the license key in the RCL before packaging or referencing it. The registration pattern mirrors the approach used in Blazor Apps (server or WebAssembly).

For setup guidance, see [Getting started](https://blazor.syncfusion.com/documentation/getting-started/razor-class-library) with Syncfusion Blazor in a Razor Class Library.

## Blazor Web App

Open **~/Program.cs** file and register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor license key in the Blazor web app.

{% tabs %}

{% highlight c# tabtitle="Blazor Web App" hl_lines="1 2" %}

// Register the Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}

{% endtabs %}

## Blazor Server App

After referencing the RCL from a Blazor Server application, register the license key in Program.cs.

* For .NET 8 and .NET 9 apps, open **~/Program.cs** and register the Syncfusion license key.

{% tabs %}

{% highlight c# tabtitle=".NET 8 & .NET 9 (~/Program.cs)" hl_lines="2 3" %}

var app = builder.Build();
// Register the Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

{% endhighlight %}

{% endtabs %}

## Blazor WebAssembly App

After referencing the RCL from a Blazor WebAssembly application, register the license key in Program.cs.

{% tabs %}

{% highlight c# tabtitle="~/Program.cs" hl_lines="1 2" %}

// Register the Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}

{% endtabs %}

N> Refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/razor-class-library) for more information on getting started with RCL in the Blazor Server and Blazor Client WebAssembly application.