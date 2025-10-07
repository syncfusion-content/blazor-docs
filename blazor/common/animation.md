---
layout: post
title: Animation in Blazor components | Syncfusion
description: Learn how to enable or disable animations globally for Syncfusion Blazor components using GlobalOptions.Animation in Program.cs.
platform: Blazor
control: Common
documentation: ug
---

# Animation in Blazor components

This section explains how to enable or disable animations globally for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components. Global animation settings apply app-wide and can override individual component animation settings.

## Enable or disable animation globally

Enable or disable animations for all Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components by setting the [GlobalOptions.Animation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_Animation) property when registering the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SyncfusionBlazor.html#Syncfusion_Blazor_SyncfusionBlazor_AddSyncfusionBlazor_Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Action_Syncfusion_Blazor_GlobalOptions__). Use one of the following modes:

* Enable: Enables the animation for all components, overriding individual component animation settings.
* Disable: Disables the animations for all components, overriding individual component animation settings.
* Default: Animation is enabled or disabled based on component's animation settings.

The following example disables animations globally.

{% tabs %}

{% highlight c# tabtitle="~/Program.cs" hl_lines="3" %}

using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor(options => { options.Animation = GlobalAnimationMode.Disable; });


{% endhighlight %}

{% endtabs %}

N> The [GlobalOptions.Animation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_Animation) property controls script level animations only. It does not affect pure CSS animations defined by CSS classes or properties.
