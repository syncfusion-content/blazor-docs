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

The Speed Dial component raises the [ItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_ItemClicked) event with [SpeedDialItemEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItemEventArgs.html) argument when an action item is clicked. You can use this event to perform the required action.

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

The Speed Dial component raises the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Created) event after the component has completed rendering. Use this event to run initialization logic, logging, or configuration that depends on the rendered instance.

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

The Speed Dial component raises the [Opening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Opening) event with [SpeedDialBeforeOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialBeforeOpenCloseEventArgs.html) before the Speed Dial popup opens. Use this event to prepare data, adjust items, or cancel opening based on conditions by setting the Cancel property in the event arguments.

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

The Speed Dial component raises the [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Opened) event with [SpeedDialOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialOpenCloseEventArgs.html) after the Speed Dial popup is opened. Use this event to run logic that depends on the popup being visible, such as focusing elements or tracking analytics.

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

The Speed Dial component raises the [Closing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Closing) event with [SpeedDialBeforeOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialBeforeOpenCloseEventArgs.html) before the Speed Dial popup closes. Use this event to validate state, save changes, or cancel closing by setting the Cancel property in the event arguments.

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

The Speed Dial component raises the [Closed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Closed) event with [SpeedDialOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialOpenCloseEventArgs.html) after the Speed Dial popup is closed. Use this event to perform cleanup or post-close actions.

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

The Speed Dial component raises the [ItemRendered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_ItemRendered) event with [SpeedDialItemEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItemEventArgs.html) for each SpeedDialItem after it is rendered. Use this event to customize item UI or attributes once the DOM is available.

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