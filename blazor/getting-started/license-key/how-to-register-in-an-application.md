---
layout: post
title: Getting started with Blazor license key registration | Syncfusion
description: Learn here about how to register Syncfusion blazor license key for blazor application for license validation.
platform: Blazor
component: Common
documentation: ug
---

# Register Syncfusion<sup style="font-size:70%">&reg;</sup> License key in Blazor Application

Syncfusion<sup style="font-size:70%">&reg;</sup> license key should be registered, if your project using Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor packages reference from [nuget.org](https://www.nuget.org/packages?q=syncfusion) or from trial installer. The generated license key is just a string that needs to be registered before any Syncfusion<sup style="font-size:70%">&reg;</sup> control is initiated. The following code is used to register the license.

{% tabs %}
{% highlight c# %}

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}
{% endtabs %}

N> * Place the license key between double quotes.  Also, ensure that Syncfusion.Licensing.dll is referenced in your project where the license key is being registered.
* Syncfusion<sup style="font-size:70%">&reg;</sup> license validation is done offline during application execution and does not require internet access.  Apps registered with a Syncfusion<sup style="font-size:70%">&reg;</sup> license key can be deployed on any system that does not have an internet connection.

I> Syncfusion<sup style="font-size:70%">&reg;</sup> license keys can be validated during the Continuous Integration (CI) processes to ensure proper licensing and prevent licensing errors during deployment. Refer to the [CI License Validation](https://blazor.syncfusion.com/documentation/getting-started/license-key/ci-license-validation) section for detailed instructions on how to implement it.

| Blazor Mode                          | Project(s) to Register License Key      | File(s) to Register License Key         |
|---------------------------------------|-----------------------------------------|-----------------------------------------|
| Blazor Web App (Interactive Auto)      | Server & Client                         | `Server/Program.cs`, `Client/Program.cs`|
| Blazor Web App (Interactive Server)    | Server                                  | `Server/Program.cs`                     |
| Blazor Web App (Interactive WASM)      | Server & Client                         | `Server/Program.cs`, `Client/Program.cs`|
| Blazor Standalone WebAssembly App     | Client                                  | `Program.cs`                            |

## Blazor Web App (Interactive Auto)

Open **~/Program.cs** file in both the server and client projects of a Blazor Web App(Interactive Auto) and register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor license key.
{% tabs %}

{% highlight C# tabtitle="Blazor Web App" hl_lines="1 2" %}

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}

{% endtabs %}

## Blazor Web App (Interactive Server)

* For .NET 8 and .NET 9, open the **~/Program.cs** file and register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key.

{% tabs %}

{% highlight C# tabtitle=".NET 8 & .NET 9 (~/Program.cs)" hl_lines="2 3" %}

var app = builder.Build();
//Register Syncfusion license
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

{% highlight C# tabtitle="Blazor Web App" hl_lines="1 2" %}

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

{% endhighlight %}

{% endtabs %}

## Blazor Standalone WebAssembly App

Open **~/Program.cs** file and register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor license key in the client web app.

{% tabs %}

{% highlight C# tabtitle=".NET 8 & .NET 9 (~/Program.cs)" hl_lines="1 2" %}

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

var builder = WebAssemblyHostBuilder.CreateDefault(args);

....
....

{% endhighlight %}

{% endtabs %}
