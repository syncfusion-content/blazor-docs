---
layout: post
title: Globalization in Blazor Sparkline Component | Syncfusion
description: Check out and learn about globalization support in the Syncfusion Blazor Sparkline component for better adaptability.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Globalization in Blazor Sparkline Component

Globalization is the process of designing and developing a component to work in different cultures or locations. In the Sparkline component, the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_Format) property is used to globalize number, date, and time values. The following example shows the tooltip globalized to currency format in the Deutsch culture.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new double[]{ 300.00, 600.00, 400.21, 100.20, 300.70, 200.04, 500.00 }" Height="200px" Width="350px" Format="C">
    <SparklineTooltipSettings TValue="double" Visible="true"></SparklineTooltipSettings>
</SfSparkline>

```

N> Refer to the [localization documentation for Blazor Server](https://blazor.syncfusion.com/documentation/common/localization#enable-localization-in-blazor-server-application) and [Blazor WebAssembly](https://blazor.syncfusion.com/documentation/common/localization#enable-localization-in-blazor-webassembly-application) for configuration details.

On successful configuration, the Sparkline will be rendered as shown below.

![Localization in Blazor Sparkline Chart](./images/localization/blazor-sparkline-localization.png)
