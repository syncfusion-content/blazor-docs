---
layout: post
title: Visualize grid data in chart in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Visualize grid data in chart in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Visualize Grid Data in Chart in Blazor Charts Component

Use the chart's [OnSelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSelectionChanged) event to get the list of selected data from the chart.

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

By using the grid's [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html?&_ga=2.74923985.277089489.1621702797-1228991885.1619258362#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property, chart's selected data can be listed in the grid.

```cshtml

<SfGrid DataSource="@SelectedData2">
    <GridColumns>
        <GridColumn Field=@nameof(SelectionData.x) HeaderText="X Value" TextAlign="TextAlign.Right" Width="50%"></GridColumn>
        <GridColumn Field=@nameof(SelectionData.y) HeaderText="Y value" Width="50%"></GridColumn>
    </GridColumns>
</SfGrid>

```

The complete code snippet is available below.

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

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
