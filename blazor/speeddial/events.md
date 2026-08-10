---
layout: post
title: Events in Blazor SpeedDial Component | Syncfusion®
description: Checkout and learn here all about events and how to use them in Blazor Speed Dial component and much more.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Events in Blazor SpeedDial Component

This section describes the SpeedDial events that are triggered when appropriate actions are performed. The following events are available in the SpeedDial component.

## Item clicked

The SpeedDial component triggers the [ItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_ItemClicked) event with the [SpeedDialItemEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItemEventArgs.html) argument when an action item is clicked. Use this event to perform the required action.

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
        // Perform the required action using args.Item and args.Event.
    }
}

{% endhighlight %}
{% endtabs %}

## Created

The SpeedDial component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Created) event after the component has completed rendering. Use this event to run initialization logic, logging, or configuration that depends on the rendered instance.

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
        // Run initialization logic after the component is rendered.
    }
}

{% endhighlight %}
{% endtabs %}

## Opening

The SpeedDial component triggers the [Opening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Opening) event with [SpeedDialBeforeOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialBeforeOpenCloseEventArgs.html) before the SpeedDial popup opens. Use this event to prepare data, adjust items, or cancel opening based on conditions by setting the `Cancel` property in the event arguments.

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
        // Cancel the open action based on a condition.
        // args.Cancel = true;
    }
}

{% endhighlight %}
{% endtabs %}

## Opened

The SpeedDial component triggers the [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Opened) event with [SpeedDialOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialOpenCloseEventArgs.html) after the SpeedDial popup is opened. Use this event to run logic that depends on the popup being visible, such as focusing elements or tracking analytics.

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
        // Run logic that depends on the popup being visible.
    }
}

{% endhighlight %}
{% endtabs %}

## Closing

The SpeedDial component triggers the [Closing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Closing) event with [SpeedDialBeforeOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialBeforeOpenCloseEventArgs.html) before the SpeedDial popup closes. Use this event to validate state, save changes, or cancel closing by setting the `Cancel` property in the event arguments.

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
        // Validate state, save changes, or cancel closing.
        // args.Cancel = true;
    }
}

{% endhighlight %}
{% endtabs %}

## Closed

The SpeedDial component triggers the [Closed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Closed) event with [SpeedDialOpenCloseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialOpenCloseEventArgs.html) after the SpeedDial popup is closed. Use this event to perform cleanup or post-close actions.

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
        // Perform cleanup or post-close actions.
    }
}

{% endhighlight %}
{% endtabs %}

## Item rendered

The SpeedDial component triggers the [ItemRendered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_ItemRendered) event with [SpeedDialItemEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItemEventArgs.html) for each `SpeedDialItem` after it is rendered. Use this event to customize item UI or attributes once the DOM is available.

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
        // Customize the rendered item using args.Item.
    }
}

{% endhighlight %}
{% endtabs %}