---
layout: post
title: Events in Rating Component | Syncfusion
description: Checkout and learn here all about Events with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Events in Rating Component

This section describes the rating events that will be triggered when appropriate actions are performed. The following events are available in the rating component.

## Created

The rating component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Created) event when the rendering of the rating component is completed.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Created="Created"></SfRating>

@code{
    public void Created()
    {
        // Here, you can customize your code.
    }
}

```

## ValueChanged

The rating component triggers the [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ValueChanged) event when the value of the rating is changed. The changed value is passed as the event argument.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ValueChanged="ValueChanged"></SfRating>

@code{
    public void ValueChanged(double args)
    {
        // Here, you can customize your code.
    }
}

```

## OnItemHover

The rating component triggers the [OnItemHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_OnItemHover) event when the rating item is hovered. The [RatingHoverEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.RatingHoverEventArgs.html) passed as an event argument provides the details of the hovered item.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating OnItemHover="OnItemHovered"></SfRating>

@code{
    public void OnItemHovered(RatingHoverEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```