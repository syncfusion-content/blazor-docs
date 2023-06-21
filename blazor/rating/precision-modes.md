---
layout: post
title: Precision Modes in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Precision Modes with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Precision Modes in Blazor Rating Component

You can use the [Precision](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Precision) property of the Blazor Rating component to provide ratings with varying levels of precision.

The precision types of Rating are as follows:

* Full: The rating is increased in whole number increments. For example, if the current rating is 2, the next possible ratings are 3, 4, and so on.
* Half: The rating is increased in increments of 0.5 (half). For example, if the current rating is 2.5, the next possible ratings are 3, 3.5, 4, and so on. 
* Quarter: The rating is increased in increments of 0.25 (quarter). For example, if the current rating is 3.75, the next possible ratings are 4, 4.25, 4.5, and so on. 
* Exact: The rating is increased in increments of 0.1. For example, if the current rating is 3.9, the next possible ratings are 4, 4.1, 4.2, and so on.

```cshtml

@using Syncfusion.Blazor.Inputs

<label>Full Precision</label><br/>
<SfRating Value="3" Precision="PrecisionType.Full"></SfRating><br/>

<label>Half Precision</label><br/>
<SfRating Value="2.5" Precision="PrecisionType.Half"></SfRating><br/>

<label>Quarter Precision</label><br/>
<SfRating Value="3.75" Precision="PrecisionType.Quarter"></SfRating><br/>

<label>Exact Precision</label><br/>
<SfRating Value="2.3" Precision="PrecisionType.Exact"></SfRating><br/>

```

![Blazor Rating Component with different Precision Types](./images/blazor-rating-precision-types.png)