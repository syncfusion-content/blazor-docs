<!-- markdownlint-disable MD036 -->

# Chart selected data in grid

By using the chart’s `OnSelectionChanged` event, you can get the current data.

```razor

 <ChartEvents OnSelectionChanged="@ShowSelectedData"></ChartEvents>

  public void ShowSelectedData(IDragCompleteEventArgs Args)
    {
        object data = Args.SelectedDataValues;
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

By using the grid’s 'DataSource' property, you can update the  chart’s datasource to grid current page records and visualize the chart selected data in grid.

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

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.