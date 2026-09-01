---
layout: post
title: Blazor Chart Wizard Serialization Examples | Syncfusion®
description: Learn how to save and restore Syncfusion Blazor Chart Wizard configuration using SaveChart and LoadChartAsync for JSON-based persistence.
platform: Blazor
control: Chart Wizard
documentation: ug
keywords: chart wizard, blazor, serialization
---

# Blazor Chart Wizard Serialization

The `Chart Wizard` component makes it simple to save and restore your entire Chart Wizard configuration. This is useful for persisting user settings, sharing chart setups, or restoring previous states.

Serialization can be achieved using the following key methods of [`SfChartWizard`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ChartWizard.SfChartWizard.html):

- [`SaveChart()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ChartWizard.SfChartWizard.html#Syncfusion_Blazor_ChartWizard_SfChartWizard_SaveChart) — Serializes the current chart state (including settings, series, axes, titles, and styles) and returns it as a JSON `string`.
- [`LoadChartAsync(string data)`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ChartWizard.SfChartWizard.html#Syncfusion_Blazor_ChartWizard_SfChartWizard_LoadChartAsync_System_String_) — Loads a chart configuration from a JSON string (produced by `SaveChart()`) and applies it to the Chart Wizard instance. Returns a `Task` that completes when the configuration has been applied.

N>
- The serialized JSON captures the full runtime state of the Chart Wizard, including the data-binding configuration. You can store this string in a database, file, or browser storage for later use.
- `LoadChartAsync` resets the Chart Wizard to its default state before applying the values from the JSON.
- Always use the unmodified JSON string produced by `SaveChart()` as input for `LoadChartAsync()`. Passing `null`, an empty string, or malformed JSON throws an exception, so validate the input (for example, with a `try/catch` block) before calling the method.

```cshtml

@using Syncfusion.Blazor.ChartWizard

<div class="control-section">
    <div class="toolbar-container">
        <div>
            <button class="btn btn-primary" @onclick="SaveChart">Save</button>
            <button class="btn btn-primary" @onclick="LoadChart">Load</button>
        </div>
    </div>
    <div class="content-wrapper">
        <SfChartWizard @ref="ChartWizard" Width="100%">
            <ChartSettings DataSource="@Top10Cities" CategoryFields="@categories" SeriesFields="@chartSeries" SeriesType="@chartWizardSeriesType">
            </ChartSettings>
        </SfChartWizard>
    </div>
</div>
<style>
    .toolbar-container {
        width: 100%;
        height: 10%;
        padding-top: 10px;
        padding-bottom: 10px;
    }
</style>

@code {
    private SfChartWizard? ChartWizard;
    private readonly List<string> chartSeries = new() { "Population" };
    private readonly List<string> categories = new() { "City", "Country" };
    private ChartWizardSeriesType chartWizardSeriesType = ChartWizardSeriesType.Bar;
    private string? serializedString;

    public class GlobalCityPopulationItem
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public double? Population { get; set; }
    }

    private readonly List<GlobalCityPopulationItem> Top10Cities = new()
    {
        new() { City = "Tokyo", Country = "Japan", Population = 37.4 },
        new() { City = "Delhi", Country = "India", Population = 31.0 },
        new() { City = "Shanghai", Country = "China", Population = 27.1 },
        new() { City = "Sao Paulo", Country = "Brazil", Population = 22.0 },
        new() { City = "Mexico City", Country = "Mexico", Population = 21.9 },
        new() { City = "Cairo", Country = "Egypt", Population = 20.9 },
        new() { City = "Dhaka", Country = "Bangladesh", Population = 20.3 },
        new() { City = "Beijing", Country = "China", Population = 20.0 },
        new() { City = "Mumbai", Country = "India", Population = 20.0 },
        new() { City = "Osaka", Country = "Japan", Population = 19.2 }
    };

    private void SaveChart()
    {
        if (ChartWizard != null)
        {
            serializedString = ChartWizard.SaveChart();
        }
    }

    private async Task LoadChart()
    {
        if (ChartWizard != null && !string.IsNullOrEmpty(serializedString))
        {
            await ChartWizard.LoadChartAsync(serializedString);
        }
    }
}

```

![Chart Wizard serialization](images/chart-wizard-serialization.webp)


## See Also

- Explore the [Chart Wizard Demo](#) for interactive samples.
- [Working with Data in Blazor Chart Wizard](./working-with-data)
- [Print and Export in Blazor Chart Wizard](./print-export)