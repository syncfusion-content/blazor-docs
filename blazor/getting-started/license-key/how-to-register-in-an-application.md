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

## Blazor Server App

* For .NET 6 and .NET 7 app, open the **~/Program.cs** file and register the Syncfusion license key.

* For .NET 5 and .NET 3.X app, open the **~/Startup.cs** file and register the Syncfusion license key.

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

{% highlight c# tabtitle=".NET 3.X & .NET 5 (~/Startup.cs)" hl_lines="4 5" %}

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // Register Syncfusion license
    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
    });
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
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();

{% endhighlight %}

{% highlight c# tabtitle=".NET 3.X & .NET 5 (~/Program.cs)" hl_lines="3 4" %}

public static async Task Main(string[] args)
{
    //Register Syncfusion license 
    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");

    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

    builder.Services.AddSyncfusionBlazor();
    await builder.Build().RunAsync();
}

{% endhighlight %}

{% endtabs %}
