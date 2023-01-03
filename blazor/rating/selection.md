---
layout: post
title: Selection in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Selection with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Selection in Blazor Rating Component

All the items before the selected item is in selected state in a rating component.

Below example demonstrates Selection of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3"></SfRating>

```

![Blazor Rating Component with Selction](./images/blazor-rating-selection.png)

## Selected value
You can get the currently rated value selected by using the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Value) property.

Below example demonstrates the selected value of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating @bind-Value=value></SfRating>
<br/>
Rated Value : @value
@code{
    double value= 3;    
}

```

![Blazor Rating Component with Selected Value](./images/blazor-rating-selected-value.png)

## Minimum value

You can use the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Min) property to set the lowest possible rating.

Below example demonstrates the Min Value of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Min="2"></SfRating>

```

![Blazor Rating Component with Minimum Value](./images/blazor-rating-min.png)

## Single selection

You can select only a single rating item by using the [EnableSingleSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_EnableSingleSelection) property. Only the selected item will be in the selected state, and all other items will be un-selected.

Below example demonstrates the Single Selection of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating EnableSingleSelection=true></SfRating>

```

![Blazor Rating Component with Single Selection](./images/blazor-rating-single-selection.png)

## Show or hide reset button

You can reset the rating value to its default by using the [AllowReset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_AllowReset) property. Value is true then the reset button will be visible to reset the rating value to its default. The default value is `false`.

Below example demonstrates the Show Or Hide Reset Button of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating AllowReset=true></SfRating>

```

![Blazor Rating Component with Reset button](./images/blazor-rating-allow-reset.png)