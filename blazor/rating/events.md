---
layout: post
title: Events in Rating Component | Syncfusion®
description: Checkout and learn here all about Events with Blazor Rating component in Blazor Server App and Blazor WebAssembly App with examples and much more details.
platform: Blazor
control: Rating
documentation: ug
---

# Events in Rating Component

This section describes the rating events that are triggered when appropriate actions are performed. The following events are available in the rating component.

| Event | Triggered when | Argument type |
| -- | -- | -- |
| [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Created) | Component rendering is completed. | `EventCallback` (no arguments) |
| [`ValueChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ValueChanged) | The rating value changes. | `EventCallback<double>` |
| [`OnItemHover`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_OnItemHover) | A rating item is hovered. | `RatingHoverEventArgs` |

## Created

The rating component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Created) event after the component rendering is completed. Use this event for initialization logic that depends on the rendered UI.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Created="Created"></SfRating>

@code{
    public void Created()
    {
        // Add initialization logic that depends on the rendered UI.
    }
}

```

## ValueChanged

The rating component triggers the [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ValueChanged) event when the rating value changes. The new value is passed as the event argument.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ValueChanged="ValueChanged"></SfRating>

@code{
    public void ValueChanged(double args)
    {
        // Handle the new rating value (args) here.
    }
}

```

## OnItemHover

The rating component triggers the [OnItemHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_OnItemHover) event when a rating item is hovered. The [RatingHoverEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.RatingHoverEventArgs.html) in the event provides details such as the hovered item’s index and value.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating OnItemHover="OnItemHovered"></SfRating>

@code{
    public void OnItemHovered(RatingHoverEventArgs args)
    {
        // Inspect args.Index and args.Value, then perform custom logic.
    }
}

```