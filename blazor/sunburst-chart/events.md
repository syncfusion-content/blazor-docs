---
layout: post
title: Blazor Sunburst Chart Events | Syncfusion®
description: Learn how to subscribe to and customize event callbacks on the Blazor Sunburst Chart using SunburstChartEvents, including drill and rendering hooks.
platform: Blazor
control: Sunburst Chart
documentation: ug
keywords: Blazor Sunburst Chart events, Sunburst Chart events, chart events, drill down, drill up, DrillDownStarting, DrillUpStarting, PointClicking, LegendItemClicking, SunburstChartEvents
---

# Blazor Sunburst Chart Events

Events let you observe and customize the `Blazor Sunburst Chart` at well-defined points during interaction and rendering — from clicks and legend toggling, to data label and segment painting, to navigating between hierarchy levels with drill-down and drill-up. They are useful when you want to intercept a default behavior, perform custom validation, or surface chart interactions in your own UI.

The events of the Blazor Sunburst Chart are configured using the `SunburstChartEvents` child component, placed inside `SfSunburstChart`.

N> **Default behavior:** No event callbacks are subscribed by default. The chart renders and behaves normally until at least one handler is attached to a `SunburstChartEvents` child component. Cancelable events (`Cancel = true`) prevent the default action; the rest are observational.

## DrillDownStarting

The `DrillDownStarting` event is triggered when a user double-clicks a Sunburst segment that has one or more children. Use it to inspect the target segment, perform custom validation, or cancel the drill-down before navigation occurs.

The event fires **after** the chart has confirmed the clicked segment has children and **before** the visual drill-down is applied. The corresponding event arguments are `SunburstDrillEventArgs` (with `EventName = "DrillDownStarting"`).

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 Width="100%" Height="600px">
    <SunburstChartEvents DrillDownStarting="@OnDrillDown" />
    <SunburstDrillSettings Enable="true" />
</SfSunburstChart>

@code {
    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 }
    };

    private void OnDrillDown(SunburstDrillEventArgs args)
    {
        // Here, you can customize your code.

        // Set args.Cancel = true to block the drill-down navigation.
    }
}

```

N> Set `args.Cancel = true` to prevent the drill-down when, for example, the target value is below a threshold set by your application. The handler in the example receives `args.EventName`, `args.Point.Label`, `args.Point.ParentLabel`, `args.Point.RootLabel`, and `args.Point.Value`, which mirror the values in `SunburstDrillPointInfo`.

## DrillUpStarting

The `DrillUpStarting` event is triggered when a user double-clicks the currently focused root segment to navigate back to a higher level in the hierarchy. Use it to perform custom logic before navigation occurs or to cancel the drill-up entirely.

The corresponding event arguments are `SunburstDrillEventArgs` (with `EventName = "DrillUpStarting"`). If neither drill handler is attached, the chart performs the navigation by default.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 Width="100%" Height="600px">
    <SunburstChartEvents DrillDownStarting="@OnDrillDown"
                         DrillUpStarting="@OnDrillUp" />
    <SunburstDrillSettings Enable="true" />
</SfSunburstChart>

@code {
    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 },
        new RegionData { Id = "USA-NewYork-NewYorkCity", ParentId = "USA-NewYork", Label = "New York City", Population = 8336000 },

        new RegionData { Id = "India-Maharashtra-Mumbai", ParentId = "India-Maharashtra", Label = "Mumbai", Population = 12440000 },
        new RegionData { Id = "India-Maharashtra-Pune", ParentId = "India-Maharashtra", Label = "Pune", Population = 3120000 },
        new RegionData { Id = "India-TamilNadu-Chennai", ParentId = "India-TamilNadu", Label = "Chennai", Population = 4646000 },
        new RegionData { Id = "India-Karnataka-Bengaluru", ParentId = "India-Karnataka", Label = "Bengaluru", Population = 8443000 },

        new RegionData { Id = "Germany-Bavaria-Munich", ParentId = "Germany-Bavaria", Label = "Munich", Population = 1488000 },
        new RegionData { Id = "Germany-Bavaria-Nuremberg", ParentId = "Germany-Bavaria", Label = "Nuremberg", Population = 515000 },
        new RegionData { Id = "Germany-Berlin-BerlinCity", ParentId = "Germany-Berlin", Label = "Berlin", Population = 3664000 },
        new RegionData { Id = "Germany-Hamburg-HamburgCity", ParentId = "Germany-Hamburg", Label = "Hamburg", Population = 1899000 }
    };

    private void OnDrillDown(SunburstDrillEventArgs args)
    {
        // Here, you can customize your code.
    }

    private void OnDrillUp(SunburstDrillEventArgs args)
    {
        // Here, you can customize your code.

        // Example: prevent leaving the deepest drilled level.
        // args.Cancel = true;
    }
}

```

## SunburstDrillEventArgs properties

`SunburstDrillEventArgs` is the unified event argument type used by both drill-down and drill-up events. It exposes the following properties:

| Property | Type | Description |
|---|---|---|
| `EventName` | `string` | Returns the literal `"DrillDownStarting"` or `"DrillUpStarting"` so the same handler can distinguish the direction. |
| `Cancel` | `bool` | Set to `true` to prevent the navigation triggered by the click. The default value is `false`. |
| `Point` | `SunburstDrillPointInfo` | Information about the segment the user double-clicked. |

`SunburstDrillPointInfo` exposes the following fields:

| Property | Type | Description |
|---|---|---|
| `Label` | `string` | The label of the segment that triggered the drill. |
| `Value` | `double` | The numeric value of the segment that triggered the drill. |
| `ParentLabel` | `string` | The label of the immediate parent segment of the click target. |
| `RootLabel` | `string` | The label of the top-level root segment that the click target belongs to. |

## PointClicking

The `PointClicking` event is triggered when a user clicks a Sunburst segment. Use it to obtain information about the clicked segment or to inspect the resulting selection state.

The corresponding event arguments are `SunburstPointClickEventArgs`. The `Cancel` property lets you suppress the default click behavior (for example, when `Selection.Enable` is `true`, the default selection update).

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 Width="100%" Height="600px">
    <SunburstChartEvents PointClicking="@OnPointClick" />
</SfSunburstChart>

@code {
    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 },
        new RegionData { Id = "USA-NewYork-NewYorkCity", ParentId = "USA-NewYork", Label = "New York City", Population = 8336000 },

        new RegionData { Id = "India-Maharashtra-Mumbai", ParentId = "India-Maharashtra", Label = "Mumbai", Population = 12440000 },
        new RegionData { Id = "India-Maharashtra-Pune", ParentId = "India-Maharashtra", Label = "Pune", Population = 3120000 },
        new RegionData { Id = "India-TamilNadu-Chennai", ParentId = "India-TamilNadu", Label = "Chennai", Population = 4646000 },
        new RegionData { Id = "India-Karnataka-Bengaluru", ParentId = "India-Karnataka", Label = "Bengaluru", Population = 8443000 },

        new RegionData { Id = "Germany-Bavaria-Munich", ParentId = "Germany-Bavaria", Label = "Munich", Population = 1488000 },
        new RegionData { Id = "Germany-Bavaria-Nuremberg", ParentId = "Germany-Bavaria", Label = "Nuremberg", Population = 515000 },
        new RegionData { Id = "Germany-Berlin-BerlinCity", ParentId = "Germany-Berlin", Label = "Berlin", Population = 3664000 },
        new RegionData { Id = "Germany-Hamburg-HamburgCity", ParentId = "Germany-Hamburg", Label = "Hamburg", Population = 1899000 }
    };

    private void OnPointClick(SunburstPointClickEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## SunburstPointClickEventArgs properties

`SunburstPointClickEventArgs` is supplied to the `PointClicking` callback and exposes the following fields:

| Property | Type | Description |
|---|---|---|
| `EventName` | `string` | Returns the literal `"PointClicking"`. Set by the chart — do not mutate. |
| `Cancel` | `bool` | Set to `true` to suppress the default click behavior (for example, the default selection update when `Selection.Enable` is `true`). The default value is `false`. |
| `Fill` | `string` | The fill color of the clicked segment. Mutate to override the rendered color. |
| `Point` | `SunburstPointInfo` | Information about the clicked segment. Exposes `Label` and `Value`. Set by the chart — do not reassign. |
| `Font` | `SunburstFontModel` | The font style currently applied to the clicked segment. Mutate fields such as `Color`, `FontSize`, or `FontWeight` to override the rendering. |

## LegendItemClicking

The `LegendItemClicking` event is triggered when a user clicks a legend item. Use it to update external UI, log telemetry, or cancel the default visibility toggle that hides the related root-level hierarchy branch.

The corresponding event arguments are `SunburstLegendItemClickEventArgs`.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 Width="100%" Height="600px">
    <SunburstChartEvents LegendItemClicking="@OnLegendClick" />
    <SunburstLegendSettings Visible="true"
                            Position="SunburstLegendPosition.Bottom"
                            ToggleVisibility="true" />
</SfSunburstChart>

@code {
    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 },
        new RegionData { Id = "USA-NewYork-NewYorkCity", ParentId = "USA-NewYork", Label = "New York City", Population = 8336000 },

        new RegionData { Id = "India-Maharashtra-Mumbai", ParentId = "India-Maharashtra", Label = "Mumbai", Population = 12440000 },
        new RegionData { Id = "India-Maharashtra-Pune", ParentId = "India-Maharashtra", Label = "Pune", Population = 3120000 },
        new RegionData { Id = "India-TamilNadu-Chennai", ParentId = "India-TamilNadu", Label = "Chennai", Population = 4646000 },
        new RegionData { Id = "India-Karnataka-Bengaluru", ParentId = "India-Karnataka", Label = "Bengaluru", Population = 8443000 },

        new RegionData { Id = "Germany-Bavaria-Munich", ParentId = "Germany-Bavaria", Label = "Munich", Population = 1488000 },
        new RegionData { Id = "Germany-Bavaria-Nuremberg", ParentId = "Germany-Bavaria", Label = "Nuremberg", Population = 515000 },
        new RegionData { Id = "Germany-Berlin-BerlinCity", ParentId = "Germany-Berlin", Label = "Berlin", Population = 3664000 },
        new RegionData { Id = "Germany-Hamburg-HamburgCity", ParentId = "Germany-Hamburg", Label = "Hamburg", Population = 1899000 }
    };

    private Task OnLegendClick(SunburstLegendItemClickEventArgs args)
    {
        // Here, you can customize your code.

        // Example: prevent the Germany branch from being hidden on click.
        // if (args.Text == "Germany") args.Cancel = true;

        return Task.CompletedTask;
    }
}

```

## SunburstLegendItemClickEventArgs properties

`SunburstLegendItemClickEventArgs` is supplied to the `LegendItemClicking` callback and exposes the following fields:

| Property | Type | Description |
|---|---|---|
| `EventName` | `string` | Returns the literal `"LegendItemClicking"`. Set by the chart — do not mutate. |
| `Cancel` | `bool` | Set to `true` to prevent the default visibility toggle for the legend item's root-level hierarchy branch. The default value is `false`. |
| `LegendIndex` | `int` | The zero-based index of the clicked legend item. Set by the chart. |
| `Text` | `string` | The label text of the clicked legend item. |
| `ShapeColor` | `string` | The marker color of the clicked legend item. |

## LegendItemRendering

The `LegendItemRendering` event fires before each legend item is rendered. Use it to customize the legend text, text color, and marker color. Setting `Cancel` to `true` prevents that legend item from being rendered.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 Width="100%" Height="600px">
    <SunburstChartEvents LegendItemRendering="@OnLegendRendering" />
    <SunburstLegendSettings Visible="true"
                            Position="SunburstLegendPosition.Bottom"
                            ToggleVisibility="false" />
</SfSunburstChart>

@code {
    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 },
        new RegionData { Id = "USA-NewYork-NewYorkCity", ParentId = "USA-NewYork", Label = "New York City", Population = 8336000 },

        new RegionData { Id = "India-Maharashtra-Mumbai", ParentId = "India-Maharashtra", Label = "Mumbai", Population = 12440000 },
        new RegionData { Id = "India-Maharashtra-Pune", ParentId = "India-Maharashtra", Label = "Pune", Population = 3120000 },
        new RegionData { Id = "India-TamilNadu-Chennai", ParentId = "India-TamilNadu", Label = "Chennai", Population = 4646000 },
        new RegionData { Id = "India-Karnataka-Bengaluru", ParentId = "India-Karnataka", Label = "Bengaluru", Population = 8443000 },

        new RegionData { Id = "Germany-Bavaria-Munich", ParentId = "Germany-Bavaria", Label = "Munich", Population = 1488000 },
        new RegionData { Id = "Germany-Bavaria-Nuremberg", ParentId = "Germany-Bavaria", Label = "Nuremberg", Population = 515000 },
        new RegionData { Id = "Germany-Berlin-BerlinCity", ParentId = "Germany-Berlin", Label = "Berlin", Population = 3664000 },
        new RegionData { Id = "Germany-Hamburg-HamburgCity", ParentId = "Germany-Hamburg", Label = "Hamburg", Population = 1899000 }
    };

    private void OnLegendRendering(SunburstLegendRenderEventArgs args)
    {
        if (args.Text == "USA")
        {
            args.Text = "United States";
            args.TextColor = "#1E88E5";
            args.ShapeColor = "#1E88E5";
        }
    }
}

```

## SunburstLegendRenderEventArgs properties

`SunburstLegendRenderEventArgs` is supplied to the `LegendItemRendering` callback and exposes the following fields:

| Property | Type | Description |
|---|---|---|
| `EventName` | `string` | Returns the literal `"LegendRendering"`. Set by the chart — do not mutate. |
| `Cancel` | `bool` | Set to `true` to prevent the legend item from being rendered. The default value is `false`. |
| `LegendIndex` | `int` | The zero-based index of the legend item being rendered. Set by the chart. |
| `Text` | `string` | The text of the legend item. Mutate to override the rendered label. |
| `TextColor` | `string` | The color of the legend item's text. Mutate to override. |
| `ShapeColor` | `string` | The color of the legend item's marker. Mutate to override. |

## DatalabelRendering

The `DatalabelRendering` event fires before each data label is rendered. Use it to override the rendered text or font style, or cancel the label entirely.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 Width="100%" Height="600px">
    <SunburstChartEvents DatalabelRendering="@OnDataLabel" />
    <SunburstDataLabelSettings Visible="true" />
</SfSunburstChart>

@code {
    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 },
        new RegionData { Id = "USA-NewYork-NewYorkCity", ParentId = "USA-NewYork", Label = "New York City", Population = 8336000 },

        new RegionData { Id = "India-Maharashtra-Mumbai", ParentId = "India-Maharashtra", Label = "Mumbai", Population = 12440000 },
        new RegionData { Id = "India-Maharashtra-Pune", ParentId = "India-Maharashtra", Label = "Pune", Population = 3120000 },
        new RegionData { Id = "India-TamilNadu-Chennai", ParentId = "India-TamilNadu", Label = "Chennai", Population = 4646000 },
        new RegionData { Id = "India-Karnataka-Bengaluru", ParentId = "India-Karnataka", Label = "Bengaluru", Population = 8443000 },

        new RegionData { Id = "Germany-Bavaria-Munich", ParentId = "Germany-Bavaria", Label = "Munich", Population = 1488000 },
        new RegionData { Id = "Germany-Bavaria-Nuremberg", ParentId = "Germany-Bavaria", Label = "Nuremberg", Population = 515000 },
        new RegionData { Id = "Germany-Berlin-BerlinCity", ParentId = "Germany-Berlin", Label = "Berlin", Population = 3664000 },
        new RegionData { Id = "Germany-Hamburg-HamburgCity", ParentId = "Germany-Hamburg", Label = "Hamburg", Population = 1899000 }
    };

    private void OnDataLabel(SunburstLabelRenderEventArgs args)
    {
        if (args.Text == "USA")
        {
            args.Text = "United States";
            args.Font.Color = "#1E88E5";
            args.Font.FontWeight = "Bold";
        }
    }
}

```

## SunburstLabelRenderEventArgs properties

`SunburstLabelRenderEventArgs` is supplied to the `DatalabelRendering` callback and exposes the following fields:

| Property | Type | Description |
|---|---|---|
| `EventName` | `string` | Returns the literal `"DatalabelRendering"`. Set by the chart — do not mutate. |
| `Cancel` | `bool` | Set to `true` to prevent the data label from being rendered. The default value is `false`. |
| `Text` | `string` | The text of the data label. Mutate to override the rendered text. |
| `Font` | `SunburstFontModel` | The font style applied to the data label. Mutate `Color`, `FontSize`, `FontFamily`, `FontWeight`, `FontStyle`, or `Opacity` to override the appearance. |

## SegmentRendering

The `SegmentRendering` event fires before each Sunburst segment is rendered. Use it to override the segment color based on its level or root label, or to skip individual segments.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 Width="100%" Height="600px">
    <SunburstChartEvents SegmentRendering="@OnSegmentRender" />
</SfSunburstChart>

@code {
    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 },
        new RegionData { Id = "USA-NewYork-NewYorkCity", ParentId = "USA-NewYork", Label = "New York City", Population = 8336000 },

        new RegionData { Id = "India-Maharashtra-Mumbai", ParentId = "India-Maharashtra", Label = "Mumbai", Population = 12440000 },
        new RegionData { Id = "India-Maharashtra-Pune", ParentId = "India-Maharashtra", Label = "Pune", Population = 3120000 },
        new RegionData { Id = "India-TamilNadu-Chennai", ParentId = "India-TamilNadu", Label = "Chennai", Population = 4646000 },
        new RegionData { Id = "India-Karnataka-Bengaluru", ParentId = "India-Karnataka", Label = "Bengaluru", Population = 8443000 },

        new RegionData { Id = "Germany-Bavaria-Munich", ParentId = "Germany-Bavaria", Label = "Munich", Population = 1488000 },
        new RegionData { Id = "Germany-Bavaria-Nuremberg", ParentId = "Germany-Bavaria", Label = "Nuremberg", Population = 515000 },
        new RegionData { Id = "Germany-Berlin-BerlinCity", ParentId = "Germany-Berlin", Label = "Berlin", Population = 3664000 },
        new RegionData { Id = "Germany-Hamburg-HamburgCity", ParentId = "Germany-Hamburg", Label = "Hamburg", Population = 1899000 }
    };

    private void OnSegmentRender(SunburstSegmentRenderEventArgs args)
    {
        if (args.LevelIndex == 0)
        {
            args.Color = "#FFA500";
        }
    }
}

```

## SunburstSegmentRenderEventArgs properties

`SunburstSegmentRenderEventArgs` is supplied to the `SegmentRendering` callback and exposes the following fields:

| Property | Type | Description |
|---|---|---|
| `EventName` | `string` | Returns the literal `"SegmentRendering"`. Set by the chart — do not mutate. |
| `Cancel` | `bool` | Set to `true` to prevent the segment from being rendered. The default value is `false`. |
| `Color` | `string` | The fill color of the segment. Mutate to override based on level or root label. |
| `LevelIndex` | `int` | The zero-based index of the level being rendered. The outermost ring is `0`. Set by the chart. |
| `RootLabel` | `string` | The label of the segment's top-level ancestor. Set by the chart. |

## TooltipRendering

The `TooltipRendering` event fires before each tooltip is rendered. Use it to override the tooltip text and appearance, or cancel the tooltip entirely.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 Width="100%" Height="600px">
    <SunburstChartEvents TooltipRendering="@OnTooltipRender" />
    <SunburstTooltipSettings Enable="true" />
</SfSunburstChart>

@code {
    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 },
        new RegionData { Id = "USA-NewYork-NewYorkCity", ParentId = "USA-NewYork", Label = "New York City", Population = 8336000 },

        new RegionData { Id = "India-Maharashtra-Mumbai", ParentId = "India-Maharashtra", Label = "Mumbai", Population = 12440000 },
        new RegionData { Id = "India-Maharashtra-Pune", ParentId = "India-Maharashtra", Label = "Pune", Population = 3120000 },
        new RegionData { Id = "India-TamilNadu-Chennai", ParentId = "India-TamilNadu", Label = "Chennai", Population = 4646000 },
        new RegionData { Id = "India-Karnataka-Bengaluru", ParentId = "India-Karnataka", Label = "Bengaluru", Population = 8443000 },

        new RegionData { Id = "Germany-Bavaria-Munich", ParentId = "Germany-Bavaria", Label = "Munich", Population = 1488000 },
        new RegionData { Id = "Germany-Bavaria-Nuremberg", ParentId = "Germany-Bavaria", Label = "Nuremberg", Population = 515000 },
        new RegionData { Id = "Germany-Berlin-BerlinCity", ParentId = "Germany-Berlin", Label = "Berlin", Population = 3664000 },
        new RegionData { Id = "Germany-Hamburg-HamburgCity", ParentId = "Germany-Hamburg", Label = "Hamburg", Population = 1899000 }
    };

    private void OnTooltipRender(SunburstTooltipRenderEventArgs args)
    {
        args.HeaderText = "Region";
        args.Text = $"{args.Point.Label}: {args.Point.Value:N0}";
        args.Fill = "#424242";
        args.Opacity = 1;
    }
}

```

## SunburstTooltipRenderEventArgs properties

`SunburstTooltipRenderEventArgs` is supplied to the `TooltipRendering` callback and exposes the following fields:

| Property | Type | Description |
|---|---|---|
| `EventName` | `string` | Returns the literal `"TooltipRendering"`. Set by the chart — do not mutate. |
| `Cancel` | `bool` | Set to `true` to prevent the tooltip from being displayed. The default value is `false`. |
| `Text` | `string` | The body text of the tooltip. Mutate to override. |
| `HeaderText` | `string` | The header text of the tooltip. Mutate to override. |
| `Fill` | `string` | The background fill color of the tooltip. Mutate to override. The default value is `"#000000"`. |
| `Opacity` | `double` | The opacity of the tooltip, between `0` and `1`. The default value is `0.75`. |
| `Font` | `SunburstFontModel` | The font style applied to the tooltip body text. Mutate fields to override. |
| `HeaderFont` | `SunburstFontModel` | The font style applied to the tooltip header line. Mutate fields to override. |
| `HeaderLineColor` | `string` | The color of the separator line drawn between the header and body when `SunburstTooltipSettings.ShowHeaderLine` is true. The default value is `string.Empty`. |
| `Point` | `SunburstPointInfo` | Information about the data point under the cursor. Exposes `Label` and `Value`. Set by the chart — do not reassign. |

## Loaded

The `Loaded` event fires once after the Sunburst chart has been initialized and rendered. It is the right place to run post-load configuration or toast the user that the chart is ready.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 Width="100%" Height="600px">
    <SunburstChartEvents Loaded="@OnLoaded" />
</SfSunburstChart>

@code {
    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 },
        new RegionData { Id = "USA-NewYork-NewYorkCity", ParentId = "USA-NewYork", Label = "New York City", Population = 8336000 },

        new RegionData { Id = "India-Maharashtra-Mumbai", ParentId = "India-Maharashtra", Label = "Mumbai", Population = 12440000 },
        new RegionData { Id = "India-Maharashtra-Pune", ParentId = "India-Maharashtra", Label = "Pune", Population = 3120000 },
        new RegionData { Id = "India-TamilNadu-Chennai", ParentId = "India-TamilNadu", Label = "Chennai", Population = 4646000 },
        new RegionData { Id = "India-Karnataka-Bengaluru", ParentId = "India-Karnataka", Label = "Bengaluru", Population = 8443000 },

        new RegionData { Id = "Germany-Bavaria-Munich", ParentId = "Germany-Bavaria", Label = "Munich", Population = 1488000 },
        new RegionData { Id = "Germany-Bavaria-Nuremberg", ParentId = "Germany-Bavaria", Label = "Nuremberg", Population = 515000 },
        new RegionData { Id = "Germany-Berlin-BerlinCity", ParentId = "Germany-Berlin", Label = "Berlin", Population = 3664000 },
        new RegionData { Id = "Germany-Hamburg-HamburgCity", ParentId = "Germany-Hamburg", Label = "Hamburg", Population = 1899000 }
    };

    private void OnLoaded(SunburstLoadedEventArgs args)
    {
        // Post-load logic.
    }
}

```

## SunburstLoadedEventArgs properties

`SunburstLoadedEventArgs` is supplied to the `Loaded` callback and exposes the following field:

| Property | Type | Description |
|---|---|---|
| `EventName` | `string` | Returns the literal `"Loaded"`. Read-only. |

## PrintCompleted and exporting hooks

The Blazor Sunburst Chart exposes synchronous `Action` callbacks for the print and export workflows initiated by `PrintAsync` and `ExportAsync`. They are not `EventCallback` instances because they are invoked by internal orchestration rather than by a user gesture.

* `PrintCompleted` (`Action`) – Fires after the chart's print workflow finishes.
* `Exporting` (`Action<ChartExportEventArgs>`) – Fires before an export is performed. Use `Cancel = true` to skip the export, or override `Width`, `Height`, or the in-progress `Workbook` for visual / data exports.
* `ExportCompleted` (`Action<ExportEventArgs>`) – Fires after the export completes. Receives the resulting `DataUrl` when `ExportAsync` was called with `allowDownload = false`.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSunburstChart TItem="RegionData"
                 Title="Population by Region"
                 DataSource="@Regions"
                 IdMemberPath="@nameof(RegionData.Id)"
                 ParentIdMemberPath="@nameof(RegionData.ParentId)"
                 LabelMemberPath="@nameof(RegionData.Label)"
                 ValueMemberPath="@nameof(RegionData.Population)"
                 @ref="Sunburst"
                 Width="100%" Height="600px">
    <SunburstChartEvents Exporting="@OnExporting"
                         ExportCompleted="@OnExportCompleted" />
</SfSunburstChart>

<button @onclick="ExportChart">Export PNG</button>

@code {
    private SfSunburstChart<RegionData>? Sunburst;

    public class RegionData
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Label { get; set; } = string.Empty;
        public double Population { get; set; }
    }

    public List<RegionData> Regions = new List<RegionData>
    {
        new RegionData { Id = "USA", ParentId = null, Label = "USA" },
        new RegionData { Id = "India", ParentId = null, Label = "India" },
        new RegionData { Id = "Germany", ParentId = null, Label = "Germany" },

        new RegionData { Id = "USA-California", ParentId = "USA", Label = "California" },
        new RegionData { Id = "USA-Texas", ParentId = "USA", Label = "Texas" },
        new RegionData { Id = "USA-NewYork", ParentId = "USA", Label = "New York" },

        new RegionData { Id = "India-Maharashtra", ParentId = "India", Label = "Maharashtra" },
        new RegionData { Id = "India-TamilNadu", ParentId = "India", Label = "Tamil Nadu" },
        new RegionData { Id = "India-Karnataka", ParentId = "India", Label = "Karnataka" },

        new RegionData { Id = "Germany-Bavaria", ParentId = "Germany", Label = "Bavaria" },
        new RegionData { Id = "Germany-Berlin", ParentId = "Germany", Label = "Berlin" },
        new RegionData { Id = "Germany-Hamburg", ParentId = "Germany", Label = "Hamburg" },

        new RegionData { Id = "USA-California-LosAngeles", ParentId = "USA-California", Label = "Los Angeles", Population = 3898000 },
        new RegionData { Id = "USA-California-SanDiego", ParentId = "USA-California", Label = "San Diego", Population = 1381000 },
        new RegionData { Id = "USA-Texas-Houston", ParentId = "USA-Texas", Label = "Houston", Population = 2304000 },
        new RegionData { Id = "USA-Texas-Dallas", ParentId = "USA-Texas", Label = "Dallas", Population = 1304000 },
        new RegionData { Id = "USA-NewYork-NewYorkCity", ParentId = "USA-NewYork", Label = "New York City", Population = 8336000 },

        new RegionData { Id = "India-Maharashtra-Mumbai", ParentId = "India-Maharashtra", Label = "Mumbai", Population = 12440000 },
        new RegionData { Id = "India-Maharashtra-Pune", ParentId = "India-Maharashtra", Label = "Pune", Population = 3120000 },
        new RegionData { Id = "India-TamilNadu-Chennai", ParentId = "India-TamilNadu", Label = "Chennai", Population = 4646000 },
        new RegionData { Id = "India-Karnataka-Bengaluru", ParentId = "India-Karnataka", Label = "Bengaluru", Population = 8443000 },

        new RegionData { Id = "Germany-Bavaria-Munich", ParentId = "Germany-Bavaria", Label = "Munich", Population = 1488000 },
        new RegionData { Id = "Germany-Bavaria-Nuremberg", ParentId = "Germany-Bavaria", Label = "Nuremberg", Population = 515000 },
        new RegionData { Id = "Germany-Berlin-BerlinCity", ParentId = "Germany-Berlin", Label = "Berlin", Population = 3664000 },
        new RegionData { Id = "Germany-Hamburg-HamburgCity", ParentId = "Germany-Hamburg", Label = "Hamburg", Population = 1899000 }
    };

    private async Task ExportChart()
    {
        // Export as PNG without triggering a browser download; the result is
        // delivered to OnExportCompleted through the Data URL on the event args.
        await Sunburst!.ExportAsync(ExportType.PNG, "sunburst", null, false);
    }

    private void OnExporting(ChartExportEventArgs args)
    {
        // Adjust the captured canvas dimensions before the export runs.
        args.Width = 1024;
        args.Height = 768;
    }

    private void OnExportCompleted(ExportEventArgs args)
    {
        // args.DataUrl contains the exported image as a data URL when allowDownload is false.
    }
}

```

## SunburstChartEvents events

The following tables list the events exposed by the `SunburstChartEvents` component, the event arguments they receive, and the default `EventName` value.

### Interaction events

| Event | EventArgs | EventName | Cancelable |
|---|---|---|---|
| `Loaded` | `SunburstLoadedEventArgs` | `Loaded` | No |
| `PointClicking` | `SunburstPointClickEventArgs` | `PointClicking` | Yes |
| `LegendItemClicking` | `SunburstLegendItemClickEventArgs` | `LegendItemClicking` | Yes |
| `DrillDownStarting` | `SunburstDrillEventArgs` | `DrillDownStarting` | Yes |
| `DrillUpStarting` | `SunburstDrillEventArgs` | `DrillUpStarting` | Yes |
| `PrintCompleted` | `Action` (no args) | n/a | No |

### Rendering events

| Event | EventArgs | EventName | Cancelable |
|---|---|---|---|
| `LegendItemRendering` | `SunburstLegendRenderEventArgs` | `LegendRendering` | Yes |
| `DatalabelRendering` | `SunburstLabelRenderEventArgs` | `DatalabelRendering` | Yes |
| `SegmentRendering` | `SunburstSegmentRenderEventArgs` | `SegmentRendering` | Yes |
| `TooltipRendering` | `SunburstTooltipRenderEventArgs` | `TooltipRendering` | Yes |

### Export hooks

| Event | EventArgs | Cancelable |
|---|---|---|
| `Exporting` | `ChartExportEventArgs` | Yes (`Cancel`) |
| `ExportCompleted` | `ExportEventArgs` | No |

N> `Action` callbacks (`LegendItemRendering`, `DatalabelRendering`, `SegmentRendering`, `TooltipRendering`, `Exporting`, `ExportCompleted`, `PrintCompleted`) are invoked synchronously by the chart. `EventCallback` callbacks (`Loaded`, `PointClicking`, `LegendItemClicking`, `DrillDownStarting`, `DrillUpStarting`) support Blazor's asynchronous dispatch and can be used with `async` / `await`.

## See also

* [Tooltip](./tooltip)
* [Selection](./selection)
* [Highlight](./highlight)
* [Data Label](./data-label)
* [Legend](./legend)
