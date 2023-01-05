---
layout: post
title: Tooltip in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Tooltip with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Tooltip in Blazor Rating Component

The Blazor Rating component supports tooltips to provide more information about the rating by using the [ShowTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ShowTooltip) property.

Below example demonstrates Tooltip of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ShowTooltip=true></SfRating>

```

![Blazor Rating Component with Tooltip](./images/blazor-rating-tooltip.png)

## TooltipTemplate

The Rating tooltips can be customized using the [TooltipTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_TooltipTemplate) tag directive to provide more expressive content rather than the item’s numerical values.

Below example demonstrates the tooltip template of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value=4 ShowTooltip=true>
    <TooltipTemplate>
        <b>@((context == 1)?"Angry":(context == 2)?"Sad":(context == 3)?"Neutral":(context == 4)?"Good":"Happy")</b>
    </TooltipTemplate>
</SfRating>

```

![Blazor Rating Component with Tooltip Template](./images/blazor-rating-tooltip-template.png)

## Tooltip customization

The Rating Tooltip can be customized by using the CssClass property, which accepts custom CSS class names that defines the specific user-defined styles and themes to be applied on the Tooltip element.

N> You can also explore more about [Tooltip Customization](https://blazor.syncfusion.com/documentation/tooltip/style) that shows how to customize styles and appearance of tooltip.

Below example demonstrates the tooltip customization of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating CssClass="customtooltip" ShowTooltip=true></SfRating>

<style>

    /*To change the radius of the tooltip corners.*/
    .customtooltip .e-tooltip-wrap {
        border-radius: 3px;
    }

    /*To change the size of the tooltip content.*/
    .customtooltip .e-tooltip-wrap .e-tip-content {
        font-size:14px;
    }

    /*To change the border color and width for tooltip.*/
    .customtooltip .e-tooltip-wrap.e-popup {
        border: 2px solid #969393;
    }

    /*To change the color for arrow of the tooltip.*/
    .customtooltip .e-tooltip-wrap .e-arrow-tip-inner.e-tip-bottom {
        border: 12px solid #9693
    }

    /*To change the top border color for arrow of the tooltip.*/
    .customtooltip .e-tooltip-wrap .e-arrow-tip-outer.e-tip-bottom {
        border-top: 12.5px solid #969393;
    }

</style>

```

![Blazor Rating Component with Tooltip Customization](./images/blazor-rating-custom-tooltip.png)