---
layout: post
title: Blazor Sparkline Charts Localization Examples | Syncfusion®
description: Learn how to localize Syncfusion Blazor Sparkline using LoadCldrData and setCulture, with tooltip format and RTL examples.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Blazor Sparkline Charts Localization

The Blazor Sparkline Charts component uses the `en-US` culture by default. Culture-specific number and currency formatting can be applied by loading the required CLDR data and setting the culture.

## Tooltip Format

The Sparkline Charts tooltip supports localization. The following example shows the tooltip text with currency format based on culture.

```cshtml
@using Microsoft.JSInterop;

<SfSparkline DataSource="@Numbers"
              Type="SparklineType.Line"
              Fill="#b2cfff"
              LineWidth="3"
              UseGroupingSeparator="true"
              Height="200px" Width="350px"
              Format = "c0">
    <SparklineContainerArea>
        <SparklineContainerAreaBorder Color="#033e96" Width="2"></SparklineContainerAreaBorder>
    </SparklineContainerArea>
    <SparklinePadding Left='20' Right='20' Bottom='20' Top='20'></SparklinePadding>
    <SparklineTooltipSettings  Visible='true'></SparklineTooltipSettings>
</SfSparkline>

@code {
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }

    int[] Numbers = { 30000, 60000, 40000, 10000, 30000, 20000, 50000 };

    protected override void OnAfterRender() {
        this.JsRuntime.Ejs().LoadCldrData(new string[]{"ca-gregorian.json",
        "currencies.json","numbers.json","timeZoneNames.json"}).SetCulture("de");
    }
}
```

The `Format` property specifies the currency format, while the `UseGroupingSeparator` property controls whether localized digit-grouping separators are displayed.

If localized values are not displayed, verify that the specified CLDR files are available to the application and that the culture identifier matches the loaded culture data.

## Right-to-left (RTL)

Right-to-left rendering can be enabled by setting the `EnableRtl` property to `true`.

The following example renders the Sparkline Chart in right-to-left mode:


```cshtml

@using Microsoft.JSInterop;

<SfSparkline DataSource="@Numbers"
              Type="SparklineType.Line"
               Height="150px" Width="150px">
</SfSparkline>

@code {
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }

    int[] Numbers = { 0, 6, 4, 1, 3, 2, 5 };

    protected override void OnAfterRender() {
        this.JsRuntime.Ejs().EnableRtl(true);
    }
}

```

## See also

- [Getting started with Blazor Sparkline Charts](https://blazor.syncfusion.com/documentation/sparkline/getting-started)
- [Sparkline Charts appearance](https://blazor.syncfusion.com/documentation/sparkline/appearance)
- [Globalization in Blazor](https://blazor.syncfusion.com/documentation/common/globalization)
- [Localization of Blazor components](https://blazor.syncfusion.com/documentation/common/localization)
