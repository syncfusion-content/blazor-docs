---
layout: post
title: Visualize grid data in chart in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Visualize grid data in chart in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Visualize grid data in chart in Blazor Charts Component

Use the chart's [`OnSelectionChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSelectionChanged) event to get the list of selected data from the chart.

```razor

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

By using the grid's [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html?&_ga=2.74923985.277089489.1621702797-1228991885.1619258362#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property, chart's selected data can be listed in the grid.

```razor

<SfGrid DataSource="@SelectedData2">
    <GridColumns>
        <GridColumn Field=@nameof(SelectionData.x) HeaderText="X Value" TextAlign="TextAlign.Right" Width="50%"></GridColumn>
        <GridColumn Field=@nameof(SelectionData.y) HeaderText="Y value" Width="50%"></GridColumn>
    </GridColumns>
</SfGrid>

```

{% aspTab template="chart/how-to/selected-griddata", sourceFiles="selected-griddata.razor" %}

{% endaspTab %}

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart Example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.