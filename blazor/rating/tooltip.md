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

<SfRating Value=3 ShowTooltip=true>
    <TooltipTemplate>
        @{
            if (context == 1)
            {
                <span>Angry</span>
            }
            else if (context == 2)
            {
                <span>Sad</span>
            }
            else if (context == 3)
            {
                <span>Neutral</span>
            }
            else if (context == 4)
            {
                <span>Good</span>
            }
            else
            {
                <span>Happy</span>
            }
        }
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
    .customtooltip .e-tooltip-wrap.e-popup {
        background-color: #2682cb;
        border: 2px solid #5074cd;
    }

    .customtooltip .e-tooltip-wrap .e-arrow-tip-inner.e-tip-bottom {
        color: #2682cb;
    }

    .customtooltip .e-tooltip-wrap .e-arrow-tip-outer.e-tip-bottom {
        border-top: #2682cb;
    }
</style>

```

![Blazor Rating Component with Tooltip Customization](./images/blazor-rating-custom-tooltip.png)