---
layout: post
title: Modal in Blazor SpeedDial Component | Syncfusion
description: Checkout and learn about how to use modal in Blazor SpeedDial component to add overlay to prevent interaction. 
platform: Blazor
control: SpeedDial
documentation: ug
---

# Modal in Blazor SpeedDial Component

You can use the [IsModal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_IsModal) property to set the Speed Dial as modal which adds an overlay to prevent the background interaction.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial IsModal=true Position="FabPosition.BottomRight" OpenIconCss="e-icons e-edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial with IsModal](./images/Blazor-SpeedDial-ModalProperty.png)
