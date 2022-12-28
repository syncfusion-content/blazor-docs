---
layout: post
title: Precision Modes in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Precision Modes with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Precision Modes in Blazor Rating Component

The Precision type of the Rating which used to component the granularity of the rating, allowing users to provide ratings with varying levels of precision using the [Precision](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Precision) property.

The precision types of Rating are as follows:

* Full
* Half
* Quarter
* Exact

## Full Precision
In Full Precision, the rating value is increased in whole number increments. For example, if the current rating is 3, the next possible ratings are 4, 5, and so on. 

Below example demonstrates the Full precision of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Precision="PrecisionType.Full"></SfRating>

```

![Blazor Rating Component with Full Precision](./images/blazor-rating-full-precision.png)

## Half Precision

In Half Precision, the rating value is increased in increments of 0.5 (half). For example, if the current rating is 3.5, the next possible ratings are 4, 4.5, 5, and so on. 

Below example demonstrates the Half precision of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Precision="PrecisionType.Half"></SfRating>

```

![Blazor Rating Component with Half Precision](./images/blazor-rating-half-precision.png)

## Quarter Precision

In Quarter Precision, the rating value is increased in increments of 0.25 (quarter). For example, if the current rating is 3.75, the next possible ratings are 4, 4.25, 4.5, and so on. 

Below example demonstrates the Quarter precision of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Precision="PrecisionType.Quarter"></SfRating>

```

![Blazor Rating Component with Quarter Precision](./images/blazor-rating-quarter-precision.png)

## Exact Precision

In Exact Precision, the rating value is increased in increments of 0.1. For example, if the current rating is 3.9, the next possible ratings are 4, 4.1, 4.2, and so on. 

Below example demonstrates the Exact precision of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Precision="PrecisionType.Exact"></SfRating>

```

![Blazor Rating Component with Exact Precision](./images/blazor-rating-exact-precision.png)