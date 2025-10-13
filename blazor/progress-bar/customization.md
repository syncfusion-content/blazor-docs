---
layout: post
title: Customization in Blazor ProgressBar Component | Syncfusion
description: Check out and learn here all about customization in Syncfusion Blazor ProgressBar component and more.
platform: Blazor
control: Progress Bar
documentation: ug
---

# Customization in Blazor ProgressBar Component

## Segments

Divide a progress bar into multiple segments using the [SegmentCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_SegmentCount) property to visualize progress for sequential tasks. Use [EnableProgressSegments](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_EnableProgressSegments) to divide progress into segments without the track. The [SegmentColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_SegmentColor) property sets the color of each segment.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Circular" Value="100" Height="180" SegmentCount="8" SegmentColor='new string[] { "#00bdaf", "#2f7ecc", "#e9648e", "#fbb78a" }' Minimum="0" Maximum="100" TrackColor="#696969">
</SfProgressBar>

<SfProgressBar Type="ProgressType.Circular" EnableProgressSegments="true" Value="100" Height="180" SegmentColor='new string[] { "#00bdaf", "#2f7ecc", "#e9648e", "#fbb78a" }' SegmentCount="8" Minimum="0" Maximum="100" TrackColor="#696969">
</SfProgressBar>

```

![Blazor ProgressBar with Segments](images/blazor-progressbar-with-segments.png)

## Thickness

Customize the thickness of the track using [TrackThickness](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_TrackThickness), the progress using [ProgressThickness](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_ProgressThickness), and the secondary progress using [SecondaryProgressThickness](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_SecondaryProgressThickness) to achieve different appearances.

```cshtml

 @using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Width="90%" TrackThickness="24" ProgressThickness="24" ShowProgressValue="true" Minimum="0" Maximum="100">
</SfProgressBar>

```

![Blazor ProgressBar with Thickness](images/blazor-progressbar-with-thickness.png)

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar  Type="ProgressType.Linear" Value="80" Minimum="0" Maximum="100" SecondaryProgress="50" SecondaryProgressThickness="30" >
</SfProgressBar>

<SfProgressBar  Type="ProgressType.Circular" Value="80" Minimum="0" Maximum="100" SecondaryProgress="40" SecondaryProgressThickness="20">
</SfProgressBar>

```

![Blazor Secondary ProgressBar with Thickness](images/blazor-progressbar-secondaryprogressbar-thickness.png)

## Radius

Customize the radius of the progress bar using the [Radius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Radius) property, and the progress edges using the [CornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_CornerRadius) property.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Circular" Value="60" Height="160px" Width="160px" EnableRtl="false" TrackColor="#FFD939" Radius="80%" InnerRadius="190%" ProgressColor="white" TrackThickness="80" ProgressThickness="10" CornerRadius="CornerType.Round" Minimum="0" Maximum="100">
</SfProgressBar>

```

![Blazor ProgressBar with Radius](images/blazor-progressbar-with-radius.png)

## Inner Radius

Customize the inner radius of the progress bar using the [InnerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_InnerRadius) property.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Circular" Value="60" Height="160px" Width="160px" EnableRtl="false"
                TrackColor="#FFD939" Radius="80%" InnerRadius="80%" ProgressColor="white" TrackThickness="80" ProgressThickness="10" CornerRadius="CornerType.Round" Minimum="0" Maximum="100">
</SfProgressBar>

```

![Blazor ProgressBar with Inner Radius](images/blazor-progressbar-with-inner-radius.png)

## Progress Color and Track Color

Customize the color of the progress, secondary progress, and track using [ProgressColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_ProgressColor), [SecondaryProgressColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_SecondaryProgressColor), and [TrackColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_TrackColor).

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="50" Height="60" Width="90%" TrackColor="#F8C7D8"
        ShowProgressValue="true" InnerRadius="190%" ProgressColor="#E3165B" TrackThickness="24" CornerRadius="CornerType.Round"
        ProgressThickness="24" Minimum="0" Maximum="100">
</SfProgressBar>

```

![Customizing Blazor ProgressBar and Track Color](images/blazor-progressbar-and-trackbar-with-custom-color.png)

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar  Type="ProgressType.Linear" ProgressColor="#cc0202" Value="50" ProgressThickness="10" TrackThickness="10" Minimum="0" Maximum="100" SecondaryProgress="60"  SecondaryProgressThickness="10" SecondaryProgressColor="#faa7a7" >
</SfProgressBar>

<SfProgressBar  Type=" ProgressType.Circular"  ProgressColor="#cc0202" Value="50" ProgressThickness="10" TrackThickness="10" Minimum="0" Maximum="100" SecondaryProgress="60" SecondaryProgressThickness="10" SecondaryProgressColor= "#faa7a7" >
</SfProgressBar>

```

![Customizing Blazor Secondary ProgressBar Color](images/blazor-progressbar-secondaryprogressbar-color.png)

## Range Colors

Visualize multiple ranges with different colors by mapping colors to specific ranges using [ProgressBarRangeColors](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarRangeColors.html), which holds a collection of [ProgressBarRangeColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarRangeColor.html) types. The [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarRangeColor.html#Syncfusion_Blazor_ProgressBar_ProgressBarRangeColor_Color) property sets the color for a range, while [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarRangeColor.html#Syncfusion_Blazor_ProgressBar_ProgressBarRangeColor_Start) and [End](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarRangeColor.html#Syncfusion_Blazor_ProgressBar_ProgressBarRangeColor_End) define the range. The [IsGradient](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_IsGradient) property applies a gradient effect.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Value="100" IsGradient="true">
    <ProgressBarRangeColors>
        <ProgressBarRangeColor Start="0" End="25" Color="#00bdaf"></ProgressBarRangeColor>
        <ProgressBarRangeColor Start="25" End="50" Color="#2f7ecc"></ProgressBarRangeColor>
        <ProgressBarRangeColor Start="50" End="75" Color="#e9648e"></ProgressBarRangeColor>
        <ProgressBarRangeColor Start="75" End="100" Color="#fbb78a"></ProgressBarRangeColor>
    </ProgressBarRangeColors>
</SfProgressBar>

```

![Changing Range Color in Blazor ProgressBar](images/blazor-progressbar-change-range-color.png)

## RTL

Enable right-to-left (RTL) rendering by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_EnableRtl) property to **true**.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar EnableRtl="true" Value="50" Type="ProgressType.Linear">
</SfProgressBar>

<SfProgressBar EnableRtl="true" Value="80" Type="ProgressType.Circular">
</SfProgressBar>

```

![Right-to-left in Blazor ProgressBar](images/blazor-progressbar-right-to-left.png)

## Progress Bar Visibility

Change the progress bar's visibility using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Visible) property.

```cshtml

@using Syncfusion.Blazor.ProgressBar

 <SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100" Visible="@visible">
    <ProgressBarAnimation  Enable="true"></ProgressBarAnimation>
    <ProgressBarEvents AnimationComplete="@AnimationHandler"></ProgressBarEvents>
</SfProgressBar>

<div>
    <p align="center" style="color:#2e2ef1; font-size: larger ">
        @uploadStatus
    </p>
</div>
    
@code {
    private string uploadStatus { get; set; } = null;
    private bool visible { get; set; } = true;

    public void AnimationHandler(ProgressValueEventArgs args)
    { 
        if (args.Value == 100)
        {
            visible = false;
            uploadStatus = "UPLOAD SUCCESS...";
        }
    }
}

```

![Blazor ProgressBar Visibility](images/progress-bar-visibility.gif)

## Progress Bar Margin

Adjust the spacing between the progress bar and its container using the [ProgressBarMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarMargin.html) property. By default, [Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarMargin.html#Syncfusion_Blazor_ProgressBar_ProgressBarMargin_Left), [Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarMargin.html#Syncfusion_Blazor_ProgressBar_ProgressBarMargin_Right), [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarMargin.html#Syncfusion_Blazor_ProgressBar_ProgressBarMargin_Top), and [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarMargin.html#Syncfusion_Blazor_ProgressBar_ProgressBarMargin_Bottom) margins are set to 10px, ensuring uniform spacing. Modify these values as needed for precise layout customization.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Circular" Height="150px" Width="150px" 
       Value="80" Minimum="0" Maximum="100" TrackThickness="20" ProgressThickness="20">
    <ProgressBarMargin Left="0" Right="0" Bottom="0" Top="0">
    </ProgressBarMargin>
</SfProgressBar>

```

![Margin in Blazor ProgressBar](images/blazor-progressbar-margin.png)
