---
layout: post
title: How to Get Selected Data in Blazor Charts | Syncfusion®
description: Learn how to get selected data in Blazor Charts using Syncfusion. Use the OnSelectionChanged event to read SelectedDataValues into your model.
platform: Blazor
control: Charts
documentation: ug
---

# How to Get Selected Data in Blazor Charts

This example demonstrates how to capture the data points selected by the user in a Syncfusion® Blazor Chart and display them in a Syncfusion® DataGrid. It is supported in Blazor Server, Blazor WebAssembly, and Blazor Hybrid (MAUI) applications using Syncfusion® Blazor Charts v20.x or later.

The [`OnSelectionChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSelectionChanged) event is triggered after the user completes a selection operation. The event handler receives a `SelectionCompleteEventArgs` object, whose `SelectedDataValues` property contains the selected data points in JSON format. When multiple series are present, deserializing this property returns a `List<List<SelectionData>>`, where each inner list represents the selected points for a series in the order the series are declared.

```cshtml

<ChartEvents OnSelectionChanged="@ShowSelectedData"></ChartEvents>

public void ShowSelectedData(IDragCompleteEventArgs args)
{
    object data = args.SelectedDataValues;
    List<List<SelectionData>> data1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<SelectionData>>>(data.ToString());
    this.SelectedData = new List<SelectionData>();
    this.SelectedData2 = new List<SelectionData>();
    for (int i = 0; i < data1[0].Count; i++)
    {
        this.SelectedData.Add(new SelectionData { x = data1[0][i].x, y = data1[0][i].y });
    }
    for (int i = 0; i < data1[1].Count; i++)
    {
        this.SelectedData2.Add(new SelectionData { x = data1[1][i].x, y = data1[1][i].y });
    }
    this.StateHasChanged();
}
```

The selected points can be bound to a Grid using its [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) property:

```cshtml

<SfGrid DataSource="@SelectedData2">
    <GridColumns>
        <GridColumn Field=@nameof(SelectionData.x) HeaderText="X Value" TextAlign="TextAlign.Right" Width="50%"></GridColumn>
        <GridColumn Field=@nameof(SelectionData.y) HeaderText="Y value" Width="50%"></GridColumn>
    </GridColumns>
</SfGrid>

```

The complete code snippet is available below. `SelectionMode.DragXY` enables rectangle drag selection on both axes; the chart exposes selected points per series through `args.SelectedDataValues`.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Grids
@using System.Collections.ObjectModel

<div class="row">
    <div class="col-md-8">
        <SfChart Title="Profit Comparison of A and B" SelectionMode="Syncfusion.Blazor.Charts.SelectionMode.DragXY">
            <ChartEvents OnSelectionChanged="@ShowSelectedData"></ChartEvents>
            <ChartPrimaryXAxis Minimum="1970" Maximum="2016">
                <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
            </ChartPrimaryXAxis>
            <ChartPrimaryYAxis Minimum="0" Maximum="100" Interval="25" Title="Sales" LabelFormat="{value}%">
                <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
            </ChartPrimaryYAxis>
            <ChartSeriesCollection>
                <ChartSeries DataSource="@dataSource" Name="Product A" XName="x" Opacity="1" YName="y1" Type="ChartSeriesType.Scatter">
                    <ChartMarker Height="10" Width="10" Shape="ChartShape.Triangle"></ChartMarker>
                </ChartSeries>
                <ChartSeries DataSource="@dataSource" Name="Product B" XName="x" Opacity="1" YName="y2" Type="ChartSeriesType.Scatter">
                    <ChartMarker Height="10" Width="10" Shape="ChartShape.Pentagon"></ChartMarker>
                </ChartSeries>
            </ChartSeriesCollection>
            <ChartArea>
                <ChartAreaBorder Width="0"></ChartAreaBorder>
            </ChartArea>
            <ChartLegendSettings Visible="true" ToggleVisibility="false"></ChartLegendSettings>
        </SfChart>
    </div>
    <div class="col-md-2">
        Series 1
        <SfGrid DataSource="@SelectedData">
            <GridColumns>
                <GridColumn Field=@nameof(SelectionData.x) HeaderText="X Value" TextAlign="TextAlign.Right" Width="50%"></GridColumn>
                <GridColumn Field=@nameof(SelectionData.y) HeaderText="Y value" Width="50%"></GridColumn>
            </GridColumns>
        </SfGrid>
    </div>
    <div class="col-md-2">
        Series 2
        <SfGrid DataSource="@SelectedData2">
            <GridColumns>
                <GridColumn Field=@nameof(SelectionData.x) HeaderText="X Value" TextAlign="TextAlign.Right" Width="50%"></GridColumn>
                <GridColumn Field=@nameof(SelectionData.y) HeaderText="Y value" Width="50%"></GridColumn>
            </GridColumns>
        </SfGrid>
    </div>
</div>
@code{
    public class RangeSelectionData
    {
        public double x { get; set; }
        public double y1 { get; set; }
        public double y2 { get; set; }
    }
    public class SelectionData
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    private Random rnd = new Random();
    public List<RangeSelectionData> dataSource = new List<RangeSelectionData>();
    public ObservableCollection<SelectionData> SelectedData = new ObservableCollection<SelectionData>();
    public ObservableCollection<SelectionData> SelectedData2 = new ObservableCollection<SelectionData>();

    protected override void OnInitialized()
    {
        for (int i = 0; i < 48; i++)
        {
            dataSource.Add(new RangeSelectionData { x = 1971 + i, y1 = rnd.Next(10, 100), y2 = rnd.Next(10, 100) });
        }
    }
    public void ShowSelectedData(SelectionCompleteEventArgs Args)
    {
        object data = Args.SelectedDataValues;
        List<List<SelectionData>> data1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<SelectionData>>>(data.ToString());
        this.SelectedData = new ObservableCollection<SelectionData>();
        this.SelectedData2 = new ObservableCollection<SelectionData>();
        for (int i = 0; i < data1[0].Count; i++)
        {
            this.SelectedData.Add(new SelectionData { x = data1[0][i].x, y = data1[0][i].y });
        }
        for (int i = 0; i < data1[1].Count; i++)
        {
            this.SelectedData2.Add(new SelectionData { x = data1[1][i].x, y = data1[1][i].y });
        }
    }
}

```

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
