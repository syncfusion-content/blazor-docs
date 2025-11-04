---
layout: post
title: Events in Blazor SpeedDial Component | Syncfusion
description: Checkout and learn here all about events and how to use them in Syncfusion Speed Dial component and much more.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Events in Blazor SpeedDial Component

This section describes the Speed Dial events that will be triggered when appropriate actions are performed. The following events are available in the Speed Dial Component.

## Item clicked

The speed dial Component triggers the [ItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_ItemClicked) event with [SpeedDialItemEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItemEventArgs.html) argument when an action item is clicked. You can use this event to perform the required action.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial OpenIconCss="e-icons e-edit" ItemClicked="ItemEventClick">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>        
</SfSpeedDial>

@code{
    public void ItemEventClick(SpeedDialItemEventArgs args)
    {
        // Here, you can call your desired action.        
    }
}

{% endhighlight %}
{% endtabs %}

## Created

The speed dial Component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Created) event when SpeedDial Component rendering is completed.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Created="CreatedEvent" OpenIconCss="e-icons e-edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

@code{
    public void CreatedEvent()
    {
        // Here, you can call your desired action.
    }
}

{% endhighlight %}
{% endtabs %}

## Opening

The speed dial Component triggers the [Opening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Opening) event with [SpeedDialBeforeOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialBeforeOpenCloseEventArgs.html) argument before the SpeedDial popup is opened.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Opening="OpeningEvent" OpenIconCss="e-icons e-edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

@code{
    public void OpeningEvent(SpeedDialBeforeOpenCloseEventArgs args)
    {
        // Here, you can call your desired action.
    }
}

{% endhighlight %}
{% endtabs %}

## Opened

The speed dial Component triggers the [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Opened) event with [SpeedDialOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialOpenCloseEventArgs.html) argument when SpeedDial popup is opened.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Opened="OpenedEvent" OpenIconCss="e-icons e-edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

@code{
    public void OpenedEvent(SpeedDialOpenCloseEventArgs args)
    {
        // Here, you can call your desired action.
    }
}

{% endhighlight %}
{% endtabs %}

## Closing

The speed dial Component triggers the [Closing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Closing) event with [SpeedDialBeforeOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialBeforeOpenCloseEventArgs.html) argument before the SpeedDial popup is closed.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Closing="ClosingEvent" OpenIconCss="e-icons e-edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

@code{
    public void ClosingEvent(SpeedDialBeforeOpenCloseEventArgs args)
    {
        // Here, you can call your desired action.
    }
}

{% endhighlight %}
{% endtabs %}

## Closed

The speed dial Component triggers the [Closed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Closed) event with [SpeedDialOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialOpenCloseEventArgs.html) argument when SpeedDial popup is closed.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Closed="ClosedEvent" OpenIconCss="e-icons e-edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

@code{
    public void ClosedEvent(SpeedDialOpenCloseEventArgs args)
    {
        // Here, you can call your desired action.
    }
}

{% endhighlight %}
{% endtabs %}

## Item rendered

The speed dial Component triggers the [ItemRendered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_ItemRendered) event with [SpeedDialItemEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItemEventArgs.html) argument for each `SpeedDialItem` once its rendered.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial ItemRendered="ItemRenderEvent" OpenIconCss="e-icons e-edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

@code{
    public void ItemRenderEvent(SpeedDialItemEventArgs args)
    {
        // Here, you can call your desired action.
    }
}

{% endhighlight %}
{% endtabs %}