---
layout: post
title: Events in Blazor Bullet Chart Component | Syncfusion
description: Check out and learn about available events and event handling in Syncfusion Blazor Bullet Chart component.
platform: Blazor
control: Bullet Chart
documentation: ug
---

# Events in Blazor Bullet Chart Component

This section describes the [Blazor Bullet Chart](https://www.syncfusion.com/blazor-components/blazor-bullet-chart) component's events, which are triggered by user actions or chart updates. Events are provided to the Bullet Chart through the [BulletChartEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html) property.

## Loaded

The `Loaded` event is triggered after the Bullet Chart component has loaded.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50">
    <BulletChartEvents Loaded="LoadedHandler"></BulletChartEvents>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };

    public void LoadedHandler(System.EventArgs args)
    {
        // Custom code here.
    }
}

```

## OnPrintComplete

The [OnPrintComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_OnPrintComplete) event is triggered before the rendered Bullet Chart starts printing.

| Argument name | Description |
|--------------|-------------|
| Cancel | Specifies the event cancel status. |

```cshtml

@using Syncfusion.Blazor.Charts

<button @onclick="PrintCall">OnPrint</button>

<SfBulletChart @ref="@BulletChart" DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50">
    <BulletChartEvents OnPrintComplete="PrintCompleteHandler"></BulletChartEvents>
</SfBulletChart>

@code {
    public SfBulletChart<ChartData> BulletChart { get; set; }

    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };

    public async Task PrintCall()
    {
        await BulletChart.PrintAsync();
    }

    public void PrintCompleteHandler(PrintEventArgs args)
    {
        // Custom code here.
    }
}

```

## TooltipRender

The [TooltipRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_TooltipRender) event is triggered before the tooltip is rendered.

| Argument name | Description |
|--------------|-------------|
| Target | Specifies the target bar values. |
| Text | Specifies the content of the tooltip. |
| Value | Specifies the value bar data. |
| Cancel | Specifies the event cancel status. |

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50">
    <BulletChartEvents TooltipRender="TooltipRenderHandler"></BulletChartEvents>
    <BulletChartTooltip TValue="ChartData" Enable="true"></BulletChartTooltip>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };

    public void TooltipRenderHandler(BulletChartTooltipEventArgs args)
    {
        // Custom code here.
    }
}

```

## LegendRender

The [LegendRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_LegendRender) event is triggered before each legend item is rendered.

| Argument name | Description |
|--------------|-------------|
| Fill | Specifies the fill of the legend item. |
| Shape | Specifies the shape of the legend item. |
| Text | Specifies the text of the legend item. |
| Cancel | Specifies the event cancel status. |

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartEvents LegendRender="LegendRenderHandler"></BulletChartEvents>
    <BulletChartLegendSettings Visible="true" Width="15%"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Name="Apple"></BulletChartRange>
        <BulletChartRange End=50 Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End=100 Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 55, TargetValue = 75 },
        new ChartData { FieldValue = 45, TargetValue = 15 },
        new ChartData { FieldValue = 75, TargetValue = 35 }
    };

    public void LegendRenderHandler(BulletChartLegendRenderEventArgs args)
    {
        // Custom code here.
    }
}

```
## PointerClick

The [PointerClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_PointerClick) event is triggered when the mouse or touch pointer is clicked on the target element or feature measure value.

| Argument name | Description |
|--------------|-------------|
| Target | Specifies the target bar values. |
| Value | Specifies the value bar data. |
| CategoryName | Specifies the category name of the selected point. |
| Cancel | Specifies whether the event should continue or be cancelled. |

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartEvents PointerClick="PointClickEvent"></BulletChartEvents>
    <BulletChartLegendSettings Visible="true" Width="15%"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Name="Apple"></BulletChartRange>
        <BulletChartRange End=50 Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End=100 Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 55, TargetValue = 75 },
        new ChartData { FieldValue = 45, TargetValue = 15 },
        new ChartData { FieldValue = 75, TargetValue = 35 }
    };

    public void PointClickEvent(BulletChartPointEventArgs args)
    {
        // Custom code here.
    }
}

```
