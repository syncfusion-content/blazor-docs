---
layout: post
title: Events in Rating Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Rating component and much more.
platform: Blazor
control: Rating
documentation: ug
---

# Events in Rating Component

This section explains the available events in Rating Component.

## Created

Event triggers after the creation of Rating.

Below example shows the Created event of the Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Created="Created"></SfRating>

@code{
    public void Created()
    {
        // Your required action here
    }
}

```

## ValueChanged

The [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ValueChanged) event triggers when the rating item value is changed. 

Below example shows the ValueChanged event of the Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ValueChanged="ValueChanged"></SfRating>

@code{
    public void ValueChanged()
    {
        // Your required action here
    }
}

```

## OnItemHover

Event triggers when the rating item is hovered. 

Below example shows the OnItemHover event of the Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating OnItemHover="OnItemHovered"></SfRating>

@code{
    public void OnItemHovered()
    {
        // Your required action here
    }
}

```

