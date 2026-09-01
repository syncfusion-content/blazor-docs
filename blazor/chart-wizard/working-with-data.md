---
layout: post
title: Blazor Chart Wizard Working with Data Examples | Syncfusion®
description: Learn how to configure data sources, category fields, series fields, and chart types in Syncfusion Blazor Chart Wizard using ChartSettings.
platform: Blazor
control: Chart Wizard
documentation: ug
keywords: chart wizard, blazor, chart
---

# Blazor Chart Wizard Working with Data

The primary configuration for the Chart Wizard is provided through [`ChartSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ChartWizard.ChartSettings.html). Key properties:

- `DataSource` (`IEnumerable<object>`) — Supplies the collection of data objects for the chart. Each object should have fields referenced by `CategoryFields` and `SeriesFields`.
- `CategoryFields` (`IEnumerable<string>`) — Specifies one or more field names from your data objects to use as category (x-axis) values. Example: `new List<string>{ "Country" }` or `new[] { "Month" }`.
- `SeriesFields` (`IEnumerable<string>`) — Lists one or more numeric field names to render as chart series. Use multiple names for multi-series charts (for example, `new[]{ "Gold", "Silver", "Bronze" }`).
- `SeriesType` ([`ChartWizardSeriesType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ChartWizard.ChartWizardSeriesType.html)) — Selects the chart type for rendering series. Supported values include `Bar`, `Column`, `Line`, `Area`, and `Pie`.

## Configuring Fields

- **Single-category, single-series chart**

```cshtml
<ChartSettings DataSource="@SalesData"
               CategoryFields="@(new[]{ "Month" })"
               SeriesFields="@(new[]{ "Sales" })"
               SeriesType="ChartWizardSeriesType.Column" />
```


- **Multi-series chart**

```cshtml
<ChartSettings DataSource="@OlympicsData"
               CategoryFields="@(new[]{ "Country" })"
               SeriesFields="@(new[]{ "Gold", "Silver", "Bronze" })"
               SeriesType="ChartWizardSeriesType.Bar" />
```


N>
- The order of `SeriesFields` determines the default series ordering.
- `CategoryFields` can include multiple fields for nested or grouped categories; the Chart Wizard combines them in the order provided.

## List Binding

Any `IEnumerable` collection can be assigned to the `DataSource` property of `ChartSettings`.

```cshtml

@using Syncfusion.Blazor.ChartWizard
@using Syncfusion.Blazor

<div class="control-section">
    <SfChartWizard Width="90%" Theme="Theme.Material3" PropertyPanelExpanded="true">
        <ChartSettings DataSource="@OlympicsDataSource"
                       CategoryFields="@categories"
                       SeriesFields="@chartSeries"
                       SeriesType="ChartWizardSeriesType.Bar">
        </ChartSettings>
    </SfChartWizard>
</div>

@code {
    private readonly List<string> chartSeries = new() { "Gold", "Silver", "Bronze" };
    private readonly List<string> categories = new() { "Country" };

    private readonly List<OlympicsData> OlympicsDataSource = new()
    {
        new OlympicsData { Country = "USA", CountryCode = "USA", Gold = 40, Silver = 44, Bronze = 42 },
        new OlympicsData { Country = "China", CountryCode = "CHN", Gold = 40, Silver = 27, Bronze = 24 },
        new OlympicsData { Country = "Great Britain", CountryCode = "GBR", Gold = 14, Silver = 22, Bronze = 29 },
        new OlympicsData { Country = "France", CountryCode = "FRA", Gold = 16, Silver = 26, Bronze = 22 },
        new OlympicsData { Country = "Australia", CountryCode = "AUS", Gold = 18, Silver = 19, Bronze = 16 },
        new OlympicsData { Country = "Japan", CountryCode = "JPN", Gold = 20, Silver = 12, Bronze = 13 },
        new OlympicsData { Country = "Italy", CountryCode = "ITA", Gold = 12, Silver = 13, Bronze = 15 },
        new OlympicsData { Country = "Netherlands", CountryCode = "NLD", Gold = 15, Silver = 7,  Bronze = 12 },
        new OlympicsData { Country = "Germany", CountryCode = "DEU", Gold = 12, Silver = 13, Bronze = 8  },
        new OlympicsData { Country = "South Korea", CountryCode = "KOR", Gold = 13, Silver = 9,  Bronze = 10 }
    };

    public class OlympicsData
    {
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Bronze { get; set; }
    }
}

```


![Chart Wizard working with data - list binding](images/chart-wizard-working-with-data-list.webp)

## ObservableCollection

An [`ObservableCollection`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1) is a dynamic data collection that raises [`INotifyCollectionChanged`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged) notifications when items are added, removed, moved, or when the collection is cleared. When such a collection is bound to `DataSource`, the Chart Wizard refreshes automatically to reflect the changes.

```cshtml

@using Syncfusion.Blazor.ChartWizard
@using System.Collections.ObjectModel

<div class="control-section">
    <button class="btn btn-primary" @onclick="AddData">Add Data</button>
    <SfChartWizard>
        <ChartSettings DataSource="@OlympicsDataSource"
                       CategoryFields="@categories"
                       SeriesFields="@chartSeries"
                       SeriesType="ChartWizardSeriesType.Bar" />
    </SfChartWizard>
</div>

@code {
    private readonly List<string> chartSeries = new() { "Gold", "Silver", "Bronze" };
    private readonly List<string> categories = new() { "CountryCode" };
    private ObservableCollection<OlympicsData> OlympicsDataSource = new();

    public class OlympicsData
    {
        public string? CountryCode { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }

        public static ObservableCollection<OlympicsData> GetData()
        {
            return new ObservableCollection<OlympicsData>
            {
                new OlympicsData { CountryCode = "GBR", Gold = 27, Silver = 23, Bronze = 17 },
                new OlympicsData { CountryCode = "CHN", Gold = 26, Silver = 18, Bronze = 26 },
                new OlympicsData { CountryCode = "AUS", Gold = 8, Silver = 11, Bronze = 10 },
                new OlympicsData { CountryCode = "RUS", Gold = 19, Silver = 18, Bronze = 19 }
            };
        }
    }

    protected override void OnInitialized()
    {
        OlympicsDataSource = OlympicsData.GetData();
    }

    private void AddData()
    {
        OlympicsDataSource.Add(new OlympicsData { CountryCode = "USA", Gold = 39, Silver = 41, Bronze = 33 });
    }
}

```

![Chart Wizard working with data - observable data binding](images/chart-wizard-working-with-data-observable.webp)


## See Also

- Explore the [Chart Wizard Demo](#) for interactive samples.
- [Serialization in Blazor Chart Wizard](./serialization)
- [Print and Export in Blazor Chart Wizard](./print-export)
