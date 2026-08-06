---
layout: post
title: Tooltip in Blazor Rating Component | Syncfusion®
description: Checkout and learn here all about Tooltip with Blazor Rating component in Blazor Server App and Blazor WebAssembly App with examples and much more details.
platform: Blazor
control: Rating
documentation: ug
---

# Tooltip in Blazor Rating Component

The Blazor Rating component provides tooltip support to display additional information for rating items. Use the [ShowTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ShowTooltip) property to toggle tooltips. The default value is `true`. When `true`, a tooltip is shown for the item under the pointer; when `false`, tooltips are disabled.

> **Prerequisites:** Install the [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor) NuGet package and add `@using Syncfusion.Blazor.Inputs` to your component.

> **Supported versions:** Syncfusion Blazor `Syncfusion.Blazor` (compatible with .NET 6.0, .NET 7.0, .NET 8.0, and .NET 9.0).

> **Mobile behavior:** On touch-only devices, the hover-based tooltip is replaced with a long-press interaction. Set `ShowTooltip="false"` if you want to suppress tooltips entirely on touch devices.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" ShowTooltip=true></SfRating>

```

![Blazor Rating component with tooltip](./images/blazor-rating-tooltip.webp)

## Tooltip template

Use the [TooltipTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_TooltipTemplate) tag directive to define custom content for the tooltip. The current item’s value is passed to the template as `@context` (a `double`), so you can render dynamic content based on the hovered item. Keep tooltip content concise (under ~80 characters) and avoid interactive elements inside the template.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value=4 ShowTooltip=true>
    <TooltipTemplate>
        <b>@((context == 1) ? "Angry" : (context == 2) ? "Sad" : (context == 3) ? "Neutral" : (context == 4) ? "Good" : "Happy")</b>
    </TooltipTemplate>
</SfRating>

```

![Blazor Rating component with tooltip template](./images/blazor-rating-tooltip-template.webp)

## Tooltip customization

Use the `CssClass` property on the Rating component and write styles scoped to that class to customize the tooltip. The class is applied to the component's root element, so you can target the nested tooltip elements without affecting other tooltips on the page.

> For more details on styling options, refer to the [Tooltip styling documentation](https://blazor.syncfusion.com/documentation/tooltip/style). For accessibility, ensure tooltip text is concise, meaningful, and readable; tooltips should supplement visible information rather than replace it.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" CssClass="customtooltip" ShowTooltip=true></SfRating>

<style>

    /* To change the radius of the tooltip corners. */
    .customtooltip .e-tooltip-wrap {
        border-radius: 3px;
    }

    /* To change the size of the tooltip content. */
    .customtooltip .e-tooltip-wrap .e-tip-content {
        font-size: 14px;
    }

    /* To change the border color and width for tooltip. */
    .customtooltip .e-tooltip-wrap.e-popup {
        border: 2px solid #969393;
    }

    /* To change the color for the arrow of the tooltip. */
    .customtooltip .e-tooltip-wrap .e-arrow-tip-inner.e-tip-bottom {
        border-top: 12px solid #969393;
    }

    /* To change the top border color for arrow of the tooltip. */
    .customtooltip .e-tooltip-wrap .e-arrow-tip-outer.e-tip-bottom {
        border-top: 8px solid #969393;
    }

</style>

```

![Blazor Rating component with tooltip customization](./images/blazor-rating-custom-tooltip.webp)

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhxtmMopsEinSxW?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

**Supported CSS variables**

The Rating tooltip exposes the following CSS custom properties that can be overridden within the `customtooltip` scope:

* `--e-tooltip-border-color` - Border color of the tooltip popup.
* `--e-tooltip-bg-color` - Background color of the tooltip.
* `--e-tooltip-color` - Text color of the tooltip content.
