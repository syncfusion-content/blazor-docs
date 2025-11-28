---
layout: post
title: Register a Syncfusion Blazor license key | Syncfusion
description: Learn here about how to register a Syncfusion Blazor license key in your application when using NuGet packages or evaluation builds. Explore to more details.
platform: Blazor
control: Common
documentation: ug
---

# Register a Syncfusion® license key in a Blazor application

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key before any Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component is initialized when referencing packages from [NuGet.org](https://www.nuget.org/packages?q=syncfusion) or using the trail installer. The license key is a string that must be registered at application startup.

{% tabs %}
{% highlight c# %}

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}
{% endtabs %}

N> * Place the license key between double quotes.  Also, ensure that Syncfusion.Licensing.dll is referenced in your project where the license key is being registered.
* Syncfusion<sup style="font-size:70%">&reg;</sup> license validation is done offline during application execution and does not require internet access. Apps registered with a Syncfusion<sup style="font-size:70%">&reg;</sup> license key can be deployed on any system that does not have an internet connection.

I> Syncfusion<sup style="font-size:70%">&reg;</sup> license keys can be validated during the Continuous Integration (CI) processes to ensure proper licensing and prevent licensing errors during deployment. Refer to the [CI License Validation](https://blazor.syncfusion.com/documentation/getting-started/license-key/ci-license-validation) section for detailed instructions on how to implement it.

Use the following table to determine where to register the license key based on the Blazor hosting model.

| Blazor mode                          | Projects to register the license key     | Files to register the license key        |
|--------------------------------------|------------------------------------------|------------------------------------------|
| Blazor Web App (Interactive Auto)    | Server and client                        | `Server/Program.cs`, `Client/Program.cs` |
| Blazor Web App (Interactive Server)  | Server                                   | `Server/Program.cs`                      |
| Blazor Web App (Interactive WASM)    | Server and client                        | `Server/Program.cs`, `Client/Program.cs` |
| Blazor Standalone WebAssembly app    | Client                                   | `Program.cs`                             |

## Blazor Web App (Interactive Auto)

Open **~/Program.cs** file in both the server and client projects of a Blazor Web App(Interactive Auto) and register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor license key.
{% tabs %}

{% highlight c# tabtitle="Blazor Web App" hl_lines="1 2" %}

// Register the Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}

{% endtabs %}

## Blazor Web App (Interactive Server)

* For .NET 8, .NET 9 and .NET 10, open the **~/Program.cs** file and register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key.

{% tabs %}

{% highlight c# tabtitle=".NET 10, .NET 9 & .NET 8 (~/Program.cs)" hl_lines="2 3" %}

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

## Blazor Web App (Interactive WebAssembly)

Open **~/Program.cs** file in both the server and client projects of a Blazor Web App(Interactive WebAssembly) and register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor license key.
{% tabs %}

{% highlight c# tabtitle="Blazor Web App" hl_lines="1 2" %}

// Register the Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}

{% endtabs %}

## Blazor Standalone WebAssembly App

Open **~/Program.cs** file and register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor license key in the client web app.

{% tabs %}

{% highlight c# tabtitle=".NET 10, .NET 9 & .NET 8 (~/Program.cs)" hl_lines="1 2" %}

// Register the Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

var builder = WebAssemblyHostBuilder.CreateDefault(args);

....
....

{% endhighlight %}

{% endtabs %}
