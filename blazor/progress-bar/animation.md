---
layout: post
title: Animation in the Blazor Progress Bar component | Syncfusion"
description: Learn here all about the animation of Syncfusion Progress Bar (SfProgressBar) component and more.
platform: Blazor
control: Progress Bar 
documentation: ug
---

# Animation in the Blazor Progress Bar (SfProgressBar)

The progress bar supports animation, which can be enabled by setting the [`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarAnimation.html#Syncfusion_Blazor_ProgressBar_ProgressBarAnimation_Enable) property to **true** in the [`ProgressBarAnimation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarAnimation.html). The speed and the delay during an animation can be controlled using the [`Duration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarAnimation.html#Syncfusion_Blazor_ProgressBar_ProgressBarAnimation_Duration) and the [`Delay`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarAnimation.html#Syncfusion_Blazor_ProgressBar_ProgressBarAnimation_Delay) properties.

```csharp
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="90" Height="60" Width="90%" TrackColor="#FFFFFF"
               ShowProgressValue="true" ProgressColor="#2BB20E" TrackThickness="24" CornerRadius="CornerType.Round"
               ProgressThickness="24" Minimum="0" Maximum="100">
    <ProgressBarAnimation Enable="true" Duration="2000" Delay="0"></ProgressBarAnimation>
</SfProgressBar>
```

![Progress Bar with Animation](images/animation.png)
