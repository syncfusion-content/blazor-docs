---
layout: post
title: Blazor Charts Localization Examples | Syncfusion®
description: Learn how to localize Syncfusion Blazor Charts. Configure the localization framework and culture settings for labels, tooltips, and legends.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Localization

The [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) component supports localization, which enables you to adapt UI elements such as labels, tooltips, legends, and other text-based content to different languages and cultures. Localization is an essential feature for building globally accessible applications because it lets users interact with charts in their preferred language and regional settings.

Localization in Syncfusion Blazor components is handled through the common [Syncfusion Blazor localization framework](https://blazor.syncfusion.com/documentation/common/localization). By configuring localization, you can display translated text for chart elements and ensure consistent formatting based on cultural preferences such as date formats, number formats, and currency symbols.

When localization is applied, the chart component automatically adapts to the selected culture. For example, date values displayed on the axis follow the regional format, and numeric values are shown with the appropriate separators and symbols. Decimal separators may vary between cultures (for example, `.` vs `,`), and date formats differ significantly (for example, `MM/dd/yyyy` vs `dd/MM/yyyy`); proper localization handles these variations seamlessly.

## Localize chart elements

N> The following steps summarize chart-specific localization. For complete setup, including resource file creation and culture registration, refer to the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic.

### 1. Register the localization services

In `Program.cs`, add Syncfusion localization to the service collection and configure the supported cultures.

```csharp
// filepath: Program.cs
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSyncfusionBlazor();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var supportedCultures = new[] { "en-US", "fr-FR", "de-DE", "ja-JP" };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
});
```

### 2. Add the localization middleware

```csharp
// filepath: Program.cs
// ...existing code...
var app = builder.Build();

app.UseRequestLocalization();
// ...existing code...
```

### 3. Create a resource file for chart strings

Add a `.resx` file under `Resources/` named `Syncfusion.Blazor.Charts.{culture}.resx` (for example, `Syncfusion.Blazor.Charts.fr-FR.resx`) and provide translated values for each chart string.

N> **Troubleshooting:** If translated text does not appear, verify that the `ResourcesPath` matches the folder containing your `.resx` files, that the resource file is named exactly `Syncfusion.Blazor.Charts.{culture}.resx`, and that the request culture is being applied (check `app.UseRequestLocalization()` is called before `app.UseRouting()`).

## Right-to-Left (RTL) rendering

The chart supports right-to-left rendering for languages such as Arabic and Hebrew. Enable RTL by setting the chart's `EnableRtl` property to `true` and configuring the host page with a right-to-left text direction (set the document's direction to RTL, e.g., `<html dir="rtl" lang="ar">`).

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart Title="مبيعات المنطقة" EnableRtl="true">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartPrimaryYAxis />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesData" XName="Region" YName="Amount" Type="ChartSeriesType.Column" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Region { get; set; }
        public double Amount { get; set; }
    }

    public List<SalesInfo> SalesData = new()
    {
        new SalesInfo { Region = "شمال", Amount = 45 },
        new SalesInfo { Region = "جنوب", Amount = 32 },
        new SalesInfo { Region = "شرق", Amount = 28 },
        new SalesInfo { Region = "غرب", Amount = 51 }
    };
}
```

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2) to learn about the available chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

By following these practices, you can build scalable and user-friendly applications that effectively communicate data across diverse audiences.

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)
* [Marker](./data-markers)