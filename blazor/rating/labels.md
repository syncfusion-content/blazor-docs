---
layout: post
title: Labels in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Labels with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Labels in Blazor Rating Component

You can use the [ShowLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ShowLabel) property to provide additional information about the current rating value.

The below example demonstrates enabling label in Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" ShowLabel=true></SfRating>

```

![Blazor Rating Component with Label](./images/blazor-rating-label.png)

## LabelPosition
You can place the label on the top, left, up, and down side of the Rating by using the [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_LabelPosition) property.

The label position values of Rating are as follows:

* Top
* Bottom
* Left
* Right

Below example demonstrates different supported label positions of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<label>Left Label Position</label><br/>
<SfRating Value=3 ShowLabel=true LabelPosition="LabelPosition.Left"></SfRating><br/>
<label>Right Label Position</label><br />
<SfRating Value=3 ShowLabel=true></SfRating><br/>
<label>Top Label Position </label><br />
<SfRating Value=3 ShowLabel=true LabelPosition="LabelPosition.Top"></SfRating><br/>
<label>Bottom Label Position</label><br />
<SfRating Value=3 ShowLabel=true LabelPosition="LabelPosition.Bottom"></SfRating><br/>

```

![Blazor Rating Component with different label positions](./images/blazor-rating-label-positions.png)


## LabelTemplate

The Rating supports to customize the content of the label by using [LabelTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_LabelTemplate) tag directive.

Below example demonstrates the label template of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" ShowLabel=true>
    <LabelTemplate>@context Out Of 5</LabelTemplate>
</SfRating>

```

![Blazor Rating Component with Label Template](./images/blazor-rating-label-template.png)