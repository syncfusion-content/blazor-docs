---
layout: post
title: Selection in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Selection in Syncfusion Blazor Rating component and much more.
platform: Blazor
control: Rating
documentation: ug
---

# Selection in Blazor Rating Component

All the items till the current value is selected.

Below example demonstrates Selection of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ShowLabel=true></SfRating>

```

![Blazor Rating Component with Selction](./images/blazor-rating-label.png)

## Selected Value
You can place the label on the top, left, up, and down side of the Rating by setting [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_LabelPosition) property. The default value is `Right`.

Below example demonstrates the selected value of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ShowLabel=true LabelPosition="LabelPosition.Right"></SfRating>

```

![Blazor Rating Component with Selected Value](./images/blazor-rating-label.png)

## Min Value

You can customize the minimum possible rating value by setting [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Min) property. If you want to allow users to provide ratings from 2, you can set the Min property to 2.

Below example demonstrates the Min Value of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Min="2"></SfRating>

```

![Blazor Rating Component with Label Template](./images/blazor-rating-min.png)

## Single Selection

You can select only a single rating item by setting [EnableSingleSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_EnableSingleSelection) property. Only the selected item will be in the selected state, and all other items will be un-selected.

Below example demonstrates the Single Selection of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating EnableSingleSelection=true></SfRating>

```

![Blazor Rating Component with Single Selection](./images/blazor-rating-single-selection.png)

## Show Or Hide Reset Button

You can reset the rating value to its default by setting [AllowReset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_AllowReset) property. Value is true then the reset button will be visible to reset the rating value to its default. The default value is `false`.

Below example demonstrates the Show Or Hide Reset Button of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating AllowReset=true></SfRating>

```

![Blazor Rating Component with Label Template](./images/blazor-rating-allow-reset.png)