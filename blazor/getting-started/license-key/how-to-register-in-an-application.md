---
layout: post
title: Overview of Syncfusion license registration - Syncfusion
description: Learn here about how to register Syncfusion blazor license key for blazor application for license validation.
platform: Blazor
component: Common
documentation: ug
---

# Register Syncfusion License key in Blazor Application

Syncfusion license key should be registered, if your project using Syncfusion Blazor packages reference from [nuget.org](https://www.nuget.org/packages?q=syncfusion) or from trial installer. The generated license key is just a string that needs to be registered before any Syncfusion control is initiated. The following code is used to register the license.

{% tabs %}
{% highlight c# %}

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}
{% endtabs %}

N> * Place the license key between double quotes.  Also, ensure that Syncfusion.Licensing.dll is referenced in your project where the license key is being registered.
* Syncfusion license validation is done offline during application execution and does not require internet access.  Apps registered with a Syncfusion license key can be deployed on any system that does not have an internet connection.

I> Syncfusion license keys can be validated during the Continuous Integration (CI) processes to ensure proper licensing and prevent licensing errors during deployment. Refer to the [CI License Validation] (https://blazor.syncfusion.com/documentation/getting-started/license-key/ci-license-validation) section for detailed instructions on how to implement it.

## Blazor Web App

Open **~/Program.cs** file and register the Syncfusion Blazor license key in the Blazor web app.

{% tabs %}

{% highlight C# tabtitle="Blazor Web App" hl_lines="1 2" %}

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}

{% endtabs %}

## Blazor Server App

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

Open **~/Program.cs** file and register the Syncfusion Blazor license key in the client web app.

{% tabs %}

{% highlight C# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="1 2" %}

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

var builder = WebAssemblyHostBuilder.CreateDefault(args);

....
....

{% endhighlight %}

{% endtabs %}
