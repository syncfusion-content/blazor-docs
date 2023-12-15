---
layout: post
title: Dynamic Points in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the Dynamic Points in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Dynamic Data Points in Blazor Charts Component

Dynamic point is the ability to add or remove points dynamically from the existing data source by clicking with mouse within the chart area. To create a Blazor chart dynamic points follow the below procedure.

**Step 1**

Binding the method in [ChartMouseClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_ChartMouseClick) event, so that we can add or remove data points by clicking inside the chart area.

``` cshtml
<ChartEvents ChartMouseClick="MouseClick"></ChartEvents>
```

**Step 2**

Create a method `MouseClick` to fetch the X axis and Y axis data of the currently clicked location from the [ChartMouseClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_ChartMouseClick) event arguments. A method `IsSamePoint` is created to check whether the point get from [ChartMouseClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_ChartMouseClick) is already exist in the data source, if the point is already exit means, we remove that point from the data source from its index using `RemoveAt` method or the points are added to the data source using `AddToDataSource` method.

```cshtml

public void MouseClick(ChartMouseEventArgs args)
{
    if (args.AxisData.Count > 0)
    {
        if (args.AxisData.TryGetValue("PrimaryXAxis", out object xValue) && args.AxisData.TryGetValue("PrimaryYAxis", out object yValue))
        {
            xPoint = Math.Round(Convert.ToDouble(xValue, null));
            yPoint = Math.Round(Convert.ToDouble(yValue, null));
            bool isSamePoint;
            if (MouseClickPoints.Count >= 1)
            {
                index = -1;
                isSamePoint = IsSamePoint();
                if (isSamePoint && MouseClickPoints.Count >= 1)
                {
                    MouseClickPoints.RemoveAt(index);
                }
                else if (!isSamePoint)
                {
                    AddToDataSource(xPoint, yPoint);
                }
            }
            else
            {
                AddToDataSource(xPoint, yPoint);
            }
            StateHasChanged();
        }
    }
}

public bool IsSamePoint()
{
    foreach (PointData item in MouseClickPoints)
    {
        index = index + 1;
        if (item.X == Convert.ToDouble(xPoint, null) && item.Y == Convert.ToDouble(yPoint, null))
        {
            return true;
        }
    }
    return false;
}

public void AddToDataSource(object xValue, object yValue)
{
    MouseClickPoints.Add(new PointData() { X = Convert.ToDouble(xValue, null), Y = Convert.ToDouble(yValue, null) });
}

``` 

**Action**

The below razor page illustrates a chart that allows users to add new data and update existing data source by clicking in the chart area. Additionally, clicking on an existing point will remove that data from the existing data source.

``` cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts
@inject NavigationManager NavigationManager

<div class="control-section" align='center'>
    <SfChart @ref="Chart" Width="@Width" Height="450px" Theme="@Theme">
        <ChartEvents ChartMouseClick="MouseClick"></ChartEvents>
        <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>
        <ChartPrimaryXAxis @ref="XAxis" ValueType="Syncfusion.Blazor.Charts.ValueType.Double" RangePadding="ChartRangePadding.Additional" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
            <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
        </ChartPrimaryXAxis>
        <ChartPrimaryYAxis>
            <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
            <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        </ChartPrimaryYAxis>
        <ChartTooltipSettings Enable="true" Format="${point.x} : <b>${point.y} </b>"></ChartTooltipSettings>
        <ChartSeriesCollection>
            <ChartSeries DataSource="@MouseClickPoints" XName="X" YName="Y" Opacity="1" Width="2" Type="ChartSeriesType.Line">
                <ChartMarker Visible="true" Height="10" Width="10" />
            </ChartSeries>
        </ChartSeriesCollection>
    </SfChart>
</div>
@code {
#nullable enable
    SfChart? Chart;
    ChartPrimaryXAxis? XAxis;
    private Theme Theme { get; set; }
    public string Width { get; set; } = "90%";
    object xPoint, yPoint;
    int index;
     
    public void MouseClick(ChartMouseEventArgs args)
    {
        if (args.AxisData.Count > 0)
        {
            if (args.AxisData.TryGetValue("PrimaryXAxis", out object xValue) && args.AxisData.TryGetValue("PrimaryYAxis", out object yValue))
            {
                xPoint = Math.Round(Convert.ToDouble(xValue, null));
                yPoint = Math.Round(Convert.ToDouble(yValue, null));
                bool isSamePoint;
                if (MouseClickPoints.Count >= 1)
                {
                    index = -1;
                    isSamePoint = IsSamePoint();
                    if (isSamePoint && MouseClickPoints.Count >= 1)
                    {
                        MouseClickPoints.RemoveAt(index);
                    }
                    else if (!isSamePoint)
                    {
                        AddToDataSource(xPoint, yPoint);
                    }
                }
                else
                {
                    AddToDataSource(xPoint, yPoint);
                }
                StateHasChanged();
            }
        }
    }
    public bool IsSamePoint()
    {
        foreach (PointData item in MouseClickPoints)
        {
            index = index + 1;
            if (item.X == Convert.ToDouble(xPoint, null) && item.Y == Convert.ToDouble(yPoint, null))
            {
                return true;
            }
        }
        return false;
    }
    public void AddToDataSource(object xValue, object yValue)
    {
        MouseClickPoints.Add(new PointData() { X = Convert.ToDouble(xValue, null), Y = Convert.ToDouble(yValue, null) });
    }
    public class PointData
    {
        public Nullable<double> X { get; set; }
        public Nullable<double> Y { get; set; }
    }
    public List<PointData> MouseClickPoints = new List<PointData>
    {
        new PointData { X= 12, Y= 19 },
        new PointData { X= 26, Y= 25 },
        new PointData { X= 45, Y= 15 },
        new PointData { X= 78, Y= 24 },
        new PointData { X= 90, Y= 35 }
    };
}

```

![Dynamic Points](../images/dynamic-points.gif)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Tooltip](./tool-tip)
* [Legend](./legend)
* [Marker](./data-markers)