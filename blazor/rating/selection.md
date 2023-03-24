---
layout: post
title: Selection in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Selection with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Selection in Blazor Rating Component

The Blazor Rating component allows users to rate something using a visual scale, and the selection state can be changed by the user clicking or tapping on the stars in the rating scale or through code. The Rating component has a minimum value and a reset button, and provides customization options for the selected rating value and selection behavior.


```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3"></SfRating>

```

![Blazor Rating Component with Selction](./images/blazor-rating-selection.png)

## Selected value

You can use the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Value) property of the Blazor Rating component to determine the currently selected rating value and update it using two-way binding or by setting the value programmatically. The current rating value can also be used to identify the selected items.

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

## Min value

You can use the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Min) property of the Blazor Rating component to set the minimum possible rating value the user can select. If you set the `Min` property to 2, then you will not be able to select a rating lower than 2.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Min="2"></SfRating>

```

![Blazor Rating Component with Minimum Value](./images/blazor-rating-min.png)

## Single selection

You can use the [EnableSingleSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_EnableSingleSelection) property of the Blazor Rating component to select only one item at a time. When the `EnableSingleSelection` property is set to `true`, only the selected item will be considered to be in the selected state, while all other items will be unselected.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" EnableSingleSelection=true></SfRating>

```

![Blazor Rating Component with Single Selection](./images/blazor-rating-single-selection.png)

## Show or hide reset button

You can reset the rating value to its default by using the [AllowReset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_AllowReset) property of the Blazor Rating component. When the `AllowReset` property is set to `true`, a reset button will be shown that allows the user to reset the rating value to its default.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" AllowReset=true></SfRating>

```

![Blazor Rating Component with Reset button](./images/blazor-rating-allow-reset.png)