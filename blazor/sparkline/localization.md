---
layout: post
title: Localization in Blazor Sparkline Charts Component | Syncfusion 
description: Learn about Localization in Blazor Sparkline Charts component of Syncfusion, and more details.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Localization

The Sparkline Charts component supports localization. The default culture for localization is `en-US`. Change the culture using the `LoadCldrData` and the `setCulture` method.

## Tooltip format

The Sparkline Charts tooltip supports localization. The following code sample shows the tooltip text with currency format based on culture.

```cshtml
<SfSparkline DataSource="@Numbers"
              Type="SparklineType.Line"
              Fill="#b2cfff"
              LineWidth="3"
              UseGroupingSeparator= "true"
              Height="200px" Width="350px"
              Format = "c0">
                <SparklineContainerArea>
                    <SparklineContainerAreaBorder Color="#033e96" Width="2"></SparklineContainerAreaBorder>
                </SparklineContainerArea>
                <SparklinePadding Left='20' Right='20' Bottom='20' Top='20'></SparklinePadding>
                <SparklineTooltipSettings  Visible='true'></SparklineTooltipSettings>
</SfSparkline>

@code {
    int[] Numbers={30000, 60000, 40000, 10000, 30000, 20000, 50000};
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }

    protected override void OnAfterRender() {
        this.JsRuntime.Ejs().LoadCldrData(new string[]{"ca-gregorian.json",
        "currencies.json","numbers.json","timeZoneNames.json"}).SetCulture("de");
    }
}
```

![Sparkline Charts with localization](./images/localization/Localization.png)

## Rtl

If the `EnableRtl` property is set to true, then the Sparkline Charts will be rendered from right-to-left direction.

The following example shows the Sparkline Charts render from "Right-to-left".

@using Microsoft.JSInterop;

```cshtml
<SfSparkline DataSource="@Numbers"
              Type="SparklineType.Line"
               Height="150px" Width="150px">
</SfSparkline>

@code {
    int[] Numbers={0, 6, 4, 1, 3, 2, 5};
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }

    protected override void OnAfterRender() {
        this.JsRuntime.Ejs().EnableRtl(true);
    }
}
```

![Sparkline Charts with Rtl](./images/localization/Rtl.png)