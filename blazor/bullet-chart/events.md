---
layout: post
title: Blazor Bullet Chart Events Examples and Reference | Syncfusion®
description: Learn about events in Syncfusion Blazor Bullet Chart such as Loaded, OnLabelRender, LegendRender, and TooltipRender with usage examples.
platform: Blazor
control: Bullet Chart
documentation: ug
---

# Blazor Bullet Chart Events

This section describes the events triggered by the [Blazor Bullet Chart](https://www.syncfusion.com/blazor-components/blazor-bullet-chart) component. The events should be provided to the Bullet Chart through the [BulletChartEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html). The available events are `Loaded`, `OnLabelRender`, `OnPrintComplete`, `TooltipRender`, `LegendRender`, and `PointerClick`.

## Loaded

The `Loaded` event triggers after the Bullet Chart component has been loaded.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50">
    <BulletChartEvents Loaded="LoadedHandler"></BulletChartEvents>
</SfBulletChart>

@code{
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
        // Here, you can customize the code.
    }
}
```

## OnLabelRender

The [OnLabelRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_OnLabelRender) event triggers before a Bullet Chart label is rendered. The [BulletChartLabelRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLabelRenderEventArgs.html) argument provides the label text and position.

| Argument name | Description |
|---------------|-------------|
| Text | Specifies the text of the label. |
| X | Specifies the X position of the label. |
| Y | Specifies the Y position of the label. |

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50">
    <BulletChartEvents OnLabelRender="LabelRenderHandler"></BulletChartEvents>
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };

    public void LabelRenderHandler(BulletChartLabelRenderEventArgs args)
    {
        // Here, you can customize the code.
    }
}
```

## OnPrintComplete

The [OnPrintComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_OnPrintComplete) event triggers before the rendered Bullet Chart starts printing.

|   Argument name    |   Description                                          |
|--------------------| -------------------------------------------------------|
|   Cancel               |   Specifies the event cancel status. |

```cshtml
@using Syncfusion.Blazor.Charts

<button @onclick="PrintCall">OnPrint</button>
<SfBulletChart @ref="@BulletChart" DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50">
    <BulletChartEvents OnPrintComplete="PrintCompleteHandler"></BulletChartEvents>
</SfBulletChart>

@code{
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
        // Here, you can customize the code.
    }
}
```

## TooltipRender

The [TooltipRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_TooltipRender) event triggers before the tooltip rendering. The [BulletChartTooltipEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartTooltipEventArgs.html) argument provides the target, value, text, and cancel status.

|   Argument name    |   Description                                          |
|--------------------| -------------------------------------------------------|
|   Target            |    Specifies the Target Bar values.           |
|   Text     |    Specifies the content of the tooltip.       |
|   Value               |   Specifies the Value Bar data. |
|   Cancel               |   Specifies the event cancel status. |

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50">
    <BulletChartEvents TooltipRender="TooltipRenderHandler"></BulletChartEvents>
    <BulletChartTooltip TValue="ChartData" Enable="true"></BulletChartTooltip>
</SfBulletChart>

@code{
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
        // Here, you can customize the code.
    }
}
```

## LegendRender

The [LegendRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_LegendRender) event triggers before each legend item rendering. The [BulletChartLegendRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendRenderEventArgs.html) argument provides the fill, shape, text, and cancel status.

|   Argument name    |   Description                                          |
|--------------------| -------------------------------------------------------|
|   Fill     |    Specifies the fill of the legend item.      |
|   Shape     |    Specifies the shape of the legend item.      |
|   Text     |    Specifies the text of the legend item.      |
|   Cancel             |   Specifies the event cancel status. |

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

@code{
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
        // Here, you can customize the code.
    }
}

```
## PointerClick

The [PointerClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_PointerClick) event is triggered when the mouse pointer or touch pointer is clicked on the target element or feature measure value. The [BulletChartPointEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartPointEventArgs.html) argument provides the target, value, category name, and cancel status.

|   Argument name    |   Description                                          |
|--------------------| -------------------------------------------------------|
|   Target     |    Specifies the target bar values.
|   Value     |    Specifies the value bar data. 
|   CategoryName     |    Specifies the category name of the selected point.  
|   Cancel             |   Specifies whether the event should continue or be cancelled.|

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" CategoryField="Category" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
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
        public string Category { get; set; }
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { Category = "Apple", FieldValue = 55, TargetValue = 75 },
        new ChartData { Category = "Mango", FieldValue = 45, TargetValue = 15 },
        new ChartData { Category = "Papaya", FieldValue = 75, TargetValue = 35 }
    };
    
    public void PointClickEvent(BulletChartPointEventArgs args)
    {
        // Here, you can customize the code.         
    }
}

```