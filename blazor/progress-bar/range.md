---
layout: post
title: Blazor ProgressBar Range Examples | Syncfusion®
description: Learn how to set the range in Syncfusion Blazor ProgressBar using Minimum and Maximum properties with code samples.
platform: Blazor
control: ProgressBar
documentation: ug
---

# Blazor ProgressBar Range

The range represents the entire span of the Progress Bar and it can be defined using the [Minimum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Minimum) and the [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Maximum) properties.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
</SfProgressBar>
```

![Blazor ProgressBar with Range](images/blazor-determinate-progressbar.webp)
