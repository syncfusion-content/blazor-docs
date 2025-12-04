---
layout: post
title: Styles in Blazor SpeedDial Component | Syncfusion
description: Checkout and learn here all about styles and icons in Syncfusion Speed Dial component and much more.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Styles in Blazor SpeedDial Component

This section describes the different ways to style the SpeedDial component and configure its icons, text, states, and appearance.

## SpeedDial button

Customize the icon and text of the Blazor SpeedDial component using the [OpenIconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_OpenIconCss), [CloseIconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_CloseIconCss), and [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Content) properties. Icon classes (e-icons) are provided by the selected theme.

### SpeedDial with Icon

Use the [OpenIconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_OpenIconCss) and [CloseIconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_CloseIconCss) properties to show icons in the speed dial button. To provide additional context, show a tooltip on hover by setting the `title` attribute.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial with Icon](./images/Blazor-SpeedDial-IconOnly.png)

### SpeedDial with Text

Show text only in the SpeedDial button by setting the [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Content) property without specifying icon properties.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial with Text](./images/Blazor-SpeedDial-TextOnly.png)

### SpeedDial with Icon and Text

Show both an icon and text in the Blazor SpeedDial button by setting the [OpenIconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_OpenIconCss), [CloseIconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_CloseIconCss), and [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Content) properties together.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Content="Edit" OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial with Icon and Text](./images/Blazor-SpeedDial-IconText.png)

## Disabled

Enable or disable the Speed Dial component using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Disabled) property. When disabled, the floating action button and its interactions are unavailable.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Disabled=true Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial with Disabled](./images/Blazor-SpeedDial-Disabled.png)

## CssClass

Apply predefined visual styles using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_CssClass) property. Assign one of the following CSS classes to change the appearance.

| CssClass | Description |
| -------- | -------- |
| e-primary | Used to represent a primary action. |
| e-outline | Used to render the button with an outline appearance. |
| e-info | Used to represent an informative action. |
| e-success | Used to represent a positive action. |
| e-warning | Used to represent an action with caution. |
| e-danger | Used to represent a negative action. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial CssClass="e-warning" Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial with CssClass](./images/Blazor-SpeedDial-Cssclass.png)

## Visible

Control the visibility of the Speed Dial component using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Visible) property. Set it to false to render the component in a hidden state.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Visible=false Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

{% endhighlight %}
{% endtabs %}

## Tooltip

Show a tooltip on hover to provide additional details by setting the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_Title) property for speed dial items. Tooltips are especially useful when using icon-only items.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem Title="Cut" IconCss="e-icons e-cut"/>
        <SpeedDialItem Title="Copy" IconCss="e-icons e-copy"/>
        <SpeedDialItem Title="Paste" IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

{% endhighlight %}
{% endtabs %}

## Opens on hover

Use the [OpensOnHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_OpensOnHover) property to open action items on hover. By default, action items open on click.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial OpensOnHover=true Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial with OpensOnHover](./images/Blazor-SpeedDial-OpensOnHover.png)

## Customized icon

Use the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_CssClass) property to customize the appearance of the SZpeedDial component in its default state. Below example below demonstrates the `cssClass` property usage in speedDial.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons
<div id="target" style="min-height:200px; position:relative; width:300px; border:1px solid;">
<SfSpeedDial Target="#target" OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close" CssClass="custom-css">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>
</div>
<style>  
    .custom-css .e-btn-icon {
        color: black;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial With CustomIcon Close](./images/Blazor-SpeedDial-CustomIcon-Close.png)

![Blazor SpeedDial With CustomIcon Open](./images/Blazor-SpeedDial-CustomIcon-Open.png)
