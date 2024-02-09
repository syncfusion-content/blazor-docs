---
layout: post
title: Animation in Blazor Components | Syncfusion
description: Checkout and learn here all about enable or disable animation globally for Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Animation in Blazor Components

This section provides information about the animation process and how to enable/disable it globally for Syncfusion Blazor Components.

## Enable or disable animation globally

You can enable or disable animation for all Syncfusion Blazor Component's globally by setting [GlobalOptions.Animation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_Animation) property while registering the [Syncfusion Blazor service](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SyncfusionBlazor.html#Syncfusion_Blazor_SyncfusionBlazor_AddSyncfusionBlazor_Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Action_Syncfusion_Blazor_GlobalOptions__), with one of below options,

* Enable - Enables the animation for all components regardless of individual component's animation settings.
* Disable - Disables the animation for all components regardless of individual component's animation settings.
* Default - Animation is enabled or disabled based on component's animation settings.

In the below code example animation is disabled.

{% tabs %}

{% highlight c# tabtitle="~/Program.cs" hl_lines="3" %}

using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor(options => { options.Animation = GlobalAnimationMode.Disable; });


{% endhighlight %}

{% endtabs %}

N> [GlobalOptions.Animation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_Animation) property controls script level animations only and it is not applicable for direct CSS level animations (Animation defined from CSSs classes/properties).
