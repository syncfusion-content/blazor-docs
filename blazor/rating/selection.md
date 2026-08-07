---
layout: post
title: Selection in Blazor Rating Component | Syncfusion®
description: Checkout and learn here all about Selection with Blazor Rating component in Blazor Server App and Blazor WebAssembly App with examples and much more details.
platform: Blazor
control: Rating
documentation: ug
---

# Selection in Blazor Rating Component

The Blazor Rating component lets users choose a value using a visual scale. Selection can be changed by clicking or tapping the icons, or programmatically. The key options are the current value, minimum value, single-selection behavior, and an optional reset button.

**Properties overview**

| Property | Type | Default | Description |
| -- | -- | -- | -- |
| `Value` | `double` | `0` | Current rating value. Supports two-way binding. |
| `Min` | `double` | `0` | Lowest selectable value. |
| `EnableSingleSelection` | `bool` | `false` | Visually highlights only the chosen item. |
| `AllowReset` | `bool` | `false` | Displays a reset button that clears the rating to `Min`. |

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3"></SfRating>

```

![Blazor Rating component with selection](./images/blazor-rating-selection.webp)

## Selected value

Use the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Value) property to get or set the currently selected rating. The default value is `0`. The value is a `double` and can be updated with two-way binding or by setting it programmatically. The selected value determines which items are rendered as selected, and the rendered value snaps to the configured `Precision` step and respects `Min` and `ItemsCount`.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating @bind-Value=value></SfRating>
<br/>
Rated Value : @value
@code{
    double value= 3;    
}

```

![Blazor Rating Component with Selected Value](./images/blazor-rating-selected-value.webp)

## Min value

Use the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Min) property to set the lowest selectable rating. The default value is `0`. For example, if `Min` is `2`, selecting a value lower than `2` is not permitted. If the current `Value` is below `Min`, it snaps to the minimum on the next render.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Min="2" Value="2"></SfRating>

```

![Blazor Rating component with a minimum value enforced](./images/blazor-rating-min.webp)

## Single selection

Use the [EnableSingleSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_EnableSingleSelection) property to visually highlight only the chosen item at a time. The default value is `false`. When set to `true`, only the chosen item appears selected while the others appear unselected. The `Value` still reflects the rating value of the selected item, snapped to the configured `Precision` step.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" EnableSingleSelection=true></SfRating>

```

![Blazor Rating component with single-selection](./images/blazor-rating-single-selection.webp)

## Show or hide reset button

Use the [AllowReset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_AllowReset) property to display a reset button. When `AllowReset` is `true`, a reset control appears that resets the rating to the `Min` value. By default, `AllowReset` is `false`.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" AllowReset=true></SfRating>

```

![Blazor Rating component with reset button](./images/blazor-rating-allow-reset.webp)