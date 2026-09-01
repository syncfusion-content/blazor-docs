---
layout: post
title: Blazor Sparkline Charts Methods Examples | Syncfusion®
description: Learn about available methods in Syncfusion Blazor Sparkline, including how to use RefreshAsync with @ref to update the chart.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Blazor Sparkline Charts Methods

The `@ref` directive attribute can be used to obtain a reference to the Sparkline component and call its methods.

## Refresh

The `RefreshAsync` method re-renders the Sparkline component programmatically. It returns a `Task` that represents the asynchronous refresh operation.

> The `@ref` component reference is available only after the component is rendered. Ensure that the reference is not null before calling component methods.

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