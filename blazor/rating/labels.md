---
layout: post
title: Labels in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Labels with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Labels in Blazor Rating Component

The Labels of the Rating which used to display the current value of a rating. Using the [ShowLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ShowLabel) property.

Below example demonstrates Default Label of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ShowLabel=true></SfRating>

```

![Blazor Rating Component with Label](./images/blazor-rating-label.png)

## Label Position
You can place the label on the top, left, up, and down side of the Rating by setting [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_LabelPosition) property.

The label position values of Rating are as follows:

* Top
* Bottom
* Left
* Right

Below example demonstrates different supported label positions of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<div class="rating-control">
    <div class="rating-content">
        <label>Top Label Position</label><br/>
        <SfRating ShowLabel=true LabelPosition="LabelPosition.Top"></SfRating>
    </div>
    <div class="rating-content">
        <label>Bottom Label Position</label><br />
        <SfRating ShowLabel=true LabelPosition="LabelPosition.Bottom"></SfRating>
    </div>
    <div class="rating-content">
        <label>Left Label Position</label><br />
        <SfRating ShowLabel=true LabelPosition="LabelPosition.Left"></SfRating>
    </div>
    <div class="rating-content">
        <label>Right Label Position</label><br />
        <SfRating ShowLabel=true LabelPosition="LabelPosition.Right"></SfRating>
    </div>
</div>

<style>
    .rating-control {
        display: grid;
        grid-template-columns: auto auto;
        grid-gap: 10px;
    }

    .rating-control > div {
        text-align: center;
        padding: 10px 0;
    }
</style>

```

![Blazor Rating Component with different label positions](./images/blazor-rating-label-positions.png)


## Label Template

The Rating supports to customize the content of the label by setting [LabelTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_LabelTemplate) tag directive.

Below example demonstrates the label template of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ShowLabel=true>
    <LabelTemplate>@context Out Of 5</LabelTemplate>
</SfRating>

```

![Blazor Rating Component with Label Template](./images/blazor-rating-label-template.png)