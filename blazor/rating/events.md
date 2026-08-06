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

> **Prerequisites:** Install the [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor) NuGet package and add `@using Syncfusion.Blazor.Inputs` to your component.

> **Supported versions:** Syncfusion Blazor `Syncfusion.Blazor` (compatible with .NET 6.0, .NET 7.0, .NET 8.0, and .NET 9.0).

| Event | Triggered when | Argument type |
| -- | -- | -- |
| `Created` | Component rendering is completed. | `EventCallback` (no arguments) |
| `ValueChanged` | The rating value changes. | `EventCallback<double>` |
| `OnItemHover` | A rating item is hovered. | `RatingHoverEventArgs` |

## Created

The rating component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Created) event after the component rendering is completed. Use this event for initialization logic that depends on the rendered UI. The handler signature is `Func<object, Task>` or any compatible `Action`/`EventCallback`; it does not receive any arguments.

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

The rating component triggers the [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ValueChanged) event when the rating value changes. The new value is passed as a `double` event argument.

The recommended way to react to value changes is to use two-way binding with `@bind-Value` (which is implemented internally using `ValueChanged`). Use the explicit `ValueChanged` callback when you need side-effect logic in addition to the bound value.

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

The rating component triggers the [OnItemHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_OnItemHover) event when a rating item is hovered. The [RatingHoverEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.RatingHoverEventArgs.html) argument exposes the following members:

| Member | Type | Description |
| -- | -- | -- |
| `Index` | `int` | Zero-based index of the hovered item. |
| `Value` | `double` | Rating value of the hovered item (respects the configured `Precision`). |

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