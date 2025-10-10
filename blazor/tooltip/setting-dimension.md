---
layout: post
title: Setting Dimension in Blazor Tooltip Component | Syncfusion
description: Checkout and learn here all about setting dimension in Syncfusion Blazor Tooltip component and more.
platform: Blazor
control: Tooltip
documentation: ug
---

# Setting Dimension in Blazor Tooltip Component

## Height and width

Configure the outer dimensions of the tooltip using the [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_Width) and [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_Height) properties. The default for both properties is `auto`. These properties accept values in pixels (for example, "200px") as strings or numbers. Choose values that maintain readability across different screen sizes.

```cshtml
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfTooltip ID="Tooltip" Height="50px" Width="200px" Target="#btn" Content="@Content">
    <SfButton ID="btn" Content="Show Tooltip"></SfButton>
</SfTooltip>

@code
{
    string Content="Lets go green & Save Earth !!";
}
```

![Blazor Tooltip with Dimension](images/blazor-tooltip-dimension.gif)

### Scroll mode

When a specific pixel value is set for [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_Height) and the tooltip content exceeds that height, vertical scrolling is automatically enabled within the tooltip container.

```cshtml
@using Syncfusion.Blazor.Popups

<SfTooltip ID="tooltip" Height="60px" Width="200px" IsSticky="true" Target="#target" Content="@Content">
    <div id='container'>
        <p>
            A green home is a type of house designed to be
            <a id="target">
                <u>environmentally friendly</u>
            </a> and sustainable. And also focuses on the efficient use of "energy, water, and building materials." As green homes
            have become more prevalent we have also seen the emergence of green affordable housing.
        </p>
    </div>
</SfTooltip>

@code
{
    string Content = "<div><b>Environmentally friendly</b> or environment-friendly, (also referred to as eco-friendly, nature-friendly, and green) are marketing and sustainability terms referring to goods and services, laws, guidelines and policies that inflict reduced, minimal, or no harm upon ecosystems or the environment.</div>";
}
```

![Blazor Tooltip showing vertical scrolling when content overflows fixed height](images/blazor-tooltip-scrolling.gif)

N> Sticky mode is not required for scrolling but can help demonstrate overflow behavior. To enable sticky mode, set the [`IsSticky`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_IsSticky) property to `true`.