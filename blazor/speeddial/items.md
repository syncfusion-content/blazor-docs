---
layout: post
title: Items in Blazor SpeedDial Component | Syncfusion
description: Checkout and learn here all about items and how to configure action items in Syncfusion Speed Dial component and much more.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Items in Blazor Speed Dial Component

Add action items to the Blazor SpeedDial using the [SpeedDialItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html) tag directive. Items can display text, icons, or both, and support disabling, tooltips, animation, and templating.

| Fields | Type | Description |
|------|------|-------------|
| [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_Text) | `string` | Defines the text content of the SpeedDialItem. |
| [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_IconCss) | `string` | Defines one or more CSS classes to include an icon or image in a speed dial item. |
| [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_Disabled) | `bool` | Enables or disables the SpeedDialItem. |
| [Id](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_ID) | `string` | Defines a unique value for the SpeedDialItem that can be used to identify the item in event arguments. |
| [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_Title) | `string` | Defines the title of the SpeedDialItem to display a tooltip. |

## Icons in speeddial items

Customize the icon and text of speed dial action items using the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_IconCss) and [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_Text) properties.

### Icon only

Show only an icon in SpeedDial items by setting the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_IconCss) property. To provide additional details, display a tooltip on hover or focus by setting the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_Title) property.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSpeedDial OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
    <SpeedDialItems>
        <SpeedDialItem Title="Cut" IconCss="e-icons e-cut"/>
        <SpeedDialItem Title="Copy" IconCss="e-icons e-copy"/>
        <SpeedDialItem Title="Paste" IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

```

![Blazor SpeedDial with icons](./images/Blazor-SpeedDial-Icon.png)

### Text Only

Show only text in SpeedDial items by setting the [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_Text) property.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem Text="Cut"/>
        <SpeedDialItem Text="Copy"/>
        <SpeedDialItem Text="Paste"/>
    </SpeedDialItems>
</SfSpeedDial>

```

![Blazor SpeedDial with text](./images/Blazor-SpeedDial-Text.png)

### Icon with Text

Show an icon along with text in SpeedDial items by setting both the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_IconCss) and [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_Text) properties.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSpeedDial OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close" Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem Text="Cut" IconCss="e-icons e-cut"/>
        <SpeedDialItem Text="Copy" IconCss="e-icons e-copy"/>
        <SpeedDialItem Text="Paste" IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

```

![Blazor SpeedDial with icon and text](./images/Blazor-SpeedDial-Iconwithtext.png)

### Disabled

Disable SpeedDial items by setting the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_Disabled) property to `true`.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem Text="Cut" Disabled=true/>
        <SpeedDialItem Text="Copy"/>
        <SpeedDialItem Text="Paste"/>
    </SpeedDialItems>
</SfSpeedDial>

```

![Blazor SpeedDial with a disabled item](./images/Blazor-SpeedDial-DisabledItem.png)

## Animation

The Speed Dial items can be animated during the opening and closing of the popup action items. You can customize the animation's `Effect`, `Delay`, and `Duration` by setting [SpeedDialAnimationSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialAnimationSettings.html) tag directive. By default, Speed Dial animates with a `Fade` effect and supports all [SpeedDialAnimationEffect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialAnimationEffect.html) effects.

Below example demonstrates the Speed Dial items with applied Zoom effect.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSpeedDial OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close" Content="Edit">
    <SpeedDialItems>
        <SpeedDialItem Text="Cut" IconCss="e-icons e-cut"/>
        <SpeedDialItem Text="Copy" IconCss="e-icons e-copy"/>
        <SpeedDialItem Text="Paste" IconCss="e-icons e-paste"/>
    </SpeedDialItems>
    <SpeedDialAnimationSettings Effect="SpeedDialAnimationEffect.Zoom"></SpeedDialAnimationSettings>
</SfSpeedDial>

```

![Blazor SpeedDial animation](./images/Blazor-SpeedDial-Animation.png)

## Template

The Speed Dial supports customizing both the action items and the popup container using the [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_ItemTemplate) and [PopupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_PopupTemplate) tag directives. For more details about templates, check the guidance [here](https://blazor.syncfusion.com/documentation/speeddial/getting-started).

## HTML attribute

Blazor Speed Dial items support adding custom HTML attributes via the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SpeedDialItem.html#Syncfusion_Blazor_Buttons_SpeedDialItem_HtmlAttributes) property to customize items. Add them as inline attributes or use the `@attributes` directive.

The following example shows SpeedDial items with HTML attributes.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Content="Edit"> 
    <SpeedDialItems>
        <SpeedDialItem Text="Cut" IconCss="e-icons e-cut" style="color:red;"></SpeedDialItem>
        <SpeedDialItem Text="Copy" IconCss="e-icons e-copy"></SpeedDialItem>
        <SpeedDialItem Text="Paste" IconCss="e-icons e-paste"></SpeedDialItem>
    </SpeedDialItems>
</SfSpeedDial> 

```

![Blazor SpeedDial with HTML attributes](./images/Blazor-SpeedDial-HTML-Attribute.png)