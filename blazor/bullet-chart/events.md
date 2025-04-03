---
layout: post
title: Events in Blazor Bullet Chart Component | Syncfusion
description: Checkout and learn here all about available Events in Syncfusion Blazor Bullet Chart component and much more.
platform: Blazor
control: Bullet Chart 
documentation: ug
---

# Events in Blazor Bullet Chart Component

This section describes about the [Blazor Bullet](https://www.syncfusion.com/blazor-components/blazor-bullet-chart) Chart component's events that will be triggered when appropriate actions are performed. The events should be provided to the Bullet Chart through the [BulletChartEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html).

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

The [TooltipRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_TooltipRender) event triggers before the tooltip rendering.

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

The [LegendRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_LegendRender) event triggers before each legend item rendering.

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

The [PointerClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartEvents.html#Syncfusion_Blazor_Charts_BulletChartEvents_PointerClick) event is triggered when the mouse pointer or touch pointer is clicked on the target element or on the feature measure value.

|   Argument name    |   Description                                          |
|--------------------| -------------------------------------------------------|
|   Target     |    Specifies the target bar values.
|   Value     |    Specifies the value bar data. 
|   CategoryName     |    Specifies the category name of the selected point.  
|   Cancel             |   Specifies whether the event should continue or be cancelled.|

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
        // Here, you can customize the code.         
    }
}

```