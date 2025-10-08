---
layout: post
title: Range in Blazor ProgressBar Component | Syncfusion
description: Check out and learn how to configure range values in the Syncfusion Blazor ProgressBar for precise progress visualization.
platform: Blazor
control: Progress Bar
documentation: ug
---

# Range in Blazor ProgressBar Component

The range defines the entire span of the Progress Bar and is set using the [Minimum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Minimum) and [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Maximum) properties.

```cshtml

@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
</SfProgressBar>

```

![Blazor ProgressBar with Range](images/blazor-determinate-progressbar.png)
