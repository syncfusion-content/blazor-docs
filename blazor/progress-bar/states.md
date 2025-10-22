---
layout: post
title: States in Blazor ProgressBar Component | Syncfusion
description: Check out and learn about the different states in Syncfusion Blazor ProgressBar component and much more details.
platform: Blazor
control: Progress Bar
documentation: ug
---

# States in Blazor ProgressBar Component

The ProgressBar component supports multiple states for visualizing progress.

## Determinate

This is the default state, used when the estimated progress value is known.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
</SfProgressBar>

```

![Blazor Determinate ProgressBar](images/blazor-determinate-progressbar.png)

## Indeterminate

When the progress cannot be estimated, use the indeterminate state by setting the [IsIndeterminate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_IsIndeterminate) property to true. This can be combined with determinate mode to show estimated progress before the actual progress starts.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="20" Height="60" IsIndeterminate="true" Minimum="0" Maximum="100">
</SfProgressBar>

```

![Blazor Indeterminate ProgressBar](images/blazor-indeterminate-progressbar.png)

## Buffer

When the [SecondaryProgress](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_SecondaryProgress) property is set to **true**, the secondary progress indicator becomes visible, and the primary progress depends on it. Both primary and secondary progress are displayed simultaneously.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="40" Height="60" SecondaryProgress="60" Minimum="0" Maximum="100">
</SfProgressBar>

```

![Blazor Buffer ProgressBar](images/blazor-buffer-progressbar.png)

## Active

Enable the animated indicator for estimated progress by setting the [IsActive](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_IsActive) property to **true** in `SfProgressBar` and the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarAnimation.html#Syncfusion_Blazor_ProgressBar_ProgressBarAnimation_Enable) property to **true** in [ProgressBarAnimation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarAnimation.html).

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" IsActive="true" Value="40" Height="60" Minimum="0" Maximum="100">
    <ProgressBarAnimation Enable="true"></ProgressBarAnimation>
</SfProgressBar>

```

![Blazor Active ProgressBar](images/blazor-active-progressbar.png)

## Striped

Enable the striped visual indicator by setting the [IsStriped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_IsStriped) property to **true**.

N>[IsStriped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_IsStriped) property is only applicable for the [Linear](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressType.html#Syncfusion_Blazor_ProgressBar_ProgressType_Linear) [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressType.html) of the `Progress Bar`.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" IsStriped="true" Value="40" Height="60" Minimum="0" Maximum="100">
</SfProgressBar>

```

![Blazor Striped Progress Bar](images/blazor-striped-progressbar.png)
