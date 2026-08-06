---
layout: post
title: Methods in Blazor Sparkline Charts | Syncfusion®
description: Call the Blazor Sparkline Charts methods such as RefreshAsync on an SfSparkline reference obtained via @ref to programmatically re-render the chart.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Methods in Blazor Sparkline Charts

The `@ref` property can be used to create an object reference for the Sparkline component and call its methods.

## Refresh

The `RefreshAsync` method re-renders the Sparkline component.

```cshtml

@using Syncfusion.Blazor.Charts

<button @onclick="RefreshCall">Refresh</button>
<SfSparkline @ref="@Sparkline" DataSource="new int[]{ 3, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Area" Height="200px" Width="350px" Fill="#b2cfff" LineWidth="1">
</SfSparkline>

@code {
    public SfSparkline<int> Sparkline { get; set; }

    public async Task RefreshCall()
    {
        await Sparkline.RefreshAsync();
    }
}

```