---
layout: post
title: Precision Modes in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Precision Modes with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Precision Modes in Blazor Rating Component

You can provide ratings with varying levels of precision using the [Precision](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Precision) property.

The precision types of Rating are as follows:

* Full : The rating value is increased in whole number increments. For example, if the current rating is 3, the next possible ratings are 4, 5, and so on.
* Half : The rating value is increased in increments of 0.5 (half). For example, if the current rating is 3.5, the next possible ratings are 4, 4.5, 5, and so on.
* Quarter : The rating value is increased in increments of 0.25 (quarter). For example, if the current rating is 3.75, the next possible ratings are 4, 4.25, 4.5, and so on. 
* Exact : The rating value is increased in increments of 0.1. For example, if the current rating is 3.9, the next possible ratings are 4, 4.1, 4.2, and so on. 

Below example demonstrates different supported precision types of Rating. 

```cshtml

@using Syncfusion.Blazor.Inputs

<label>Full Precision</label><br/>
<SfRating Value="3" Precision="PrecisionType.Full"></SfRating><br/>
<label>Half Precision</label><br/>
<SfRating Value="2.5" Precision="PrecisionType.Half"></SfRating><br/>
<label>Quarter Precision</label><br/>
<SfRating Value="3.75" Precision="PrecisionType.Quarter"></SfRating><br/>
<label>Exact Precision</label><br/>
<SfRating Value="2.3" Precision="PrecisionType.Exact"></SfRating>

```

![Blazor Rating Component with different Precision Types](./images/blazor-rating-precision-types.png)