---
layout: post
title: Enable Ripple support in Blazor components | Syncfusion
description: Learn how to enable Ripple Effect support globally or per component for Syncfusion Blazor components in Blazor Web App, Blazor WASM standalone, and Blazor Server App.
platform: Blazor
control: Common
documentation: ug
---

# Enable Ripple Support in Syncfusion® Blazor Components

Enable Ripple support can be enabled for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components by setting the `EnableRippleEffect` property to `true`. This renders supported Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components to display a ripple effect.

## Enable Ripple Effect Globally

To enable the ripple effect for all Syncfusion<sup style="font-size:70%">&reg;</sup> components by setting the [EnableRippleeffect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRippleEffect) global option to `true` when adding Syncfusion Blazor via `AddSyncfusionBlazor()`.

### Blazor Web App

For **.NET 8, .NET 9 and .NET 10** Blazor Web Apps using any render mode (Server, WebAssembly, or Auto), set the [EnableRippleEffect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRippleEffect) property to `true` using the `AddSyncfusionBlazor` service method in the `~/Program.cs` file.

{% tabs %}

{% highlight c# tabtitle="~/Program.cs" hl_lines="3" %}

using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor(options => { options.EnableRippleEffect = true; });


{% endhighlight %}

{% endtabs %}

### Blazor WebAssembly Standalone App

For Blazor WebAssembly Standalone apps, set the [EnableRippleEffect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRippleEffect) property to `true` using the `AddSyncfusionBlazor` service method in the `~/Program.cs` file.

{% tabs %}

{% highlight c# tabtitle=".NET 10, .NET 9 & .NET 8 (~/Program.cs)" %}

using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

....
builder.Services.AddSyncfusionBlazor(options => { options.EnableRippleEffect = true; });
await builder.Build().RunAsync();
....

{% endhighlight %}

{% endtabs %}

The above configuration enables ripple effect globally for all Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

For example, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Tab component will display with a ripple animation effect:

![Blazor components rendered with ripple effect](images/EnableRipple.gif)

