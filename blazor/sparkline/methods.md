---
layout: post
title: Methods in Blazor Sparkline Component | Syncfusion
description: Checkout and learn here all about methods in Syncfusion Blazor Sparkline component and much more details.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Methods in Blazor Sparkline Component

Using the `@ref` property, create an object for the Sparkline component and call the desired method.

## Refresh

The `RefreshAsync` method helps to render the Sparkline component again.

```cshtml
@using Syncfusion.Blazor.Charts

<button @onclick="RefreshCall">Refresh</button>
<SfSparkline @ref="@Sparkline" DataSource="new int[]{ 3, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Area" Height="200px" Width="350px" Fill="#b2cfff" LineWidth="1">
</SfSparkline>

@code
{
    public SfSparkline<int> Sparkline { get; set; }
    public async Task RefreshCall()
    {
        await Sparkline.RefreshAsync();
    }
}
```