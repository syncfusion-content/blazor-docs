---
layout: post
title: Events in Rating Component | Syncfusion
description: Checkout and learn here all about Events with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Events in Rating Component

This section describes the rating events that will be triggered when appropriate actions are performed. The following events are available in the rating Component.

## Created

The rating Component triggers the `Created` event when the rendering of the rating component is complete. This event can be used to perform custom actions after the rating has been fully rendered.

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

The rating Component triggers the [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ValueChanged) event when the value of the rating is changed. This event can be used to perform custom actions when the value of the rating is changed.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ValueChanged="ValueChanged"></SfRating>

@code{
    public void ValueChanged()
    {
        // Here, you can customize your code.
    }
}

```

## OnItemHover

The rating Component triggers the `OnItemHover` event when the rating item is hovered. This event can be used to perform custom actions when the rating item is hovered.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating OnItemHover="OnItemHovered"></SfRating>

@code{
    public void OnItemHovered()
    {
        // Here, you can customize your code.
    }
}

```