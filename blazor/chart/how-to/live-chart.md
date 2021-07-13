<!-- markdownlint-disable MD036 -->

# Live Data Update

You can update a chart with live data by using the Timer.

To update live data in a chart, follow the given steps:

**Step 1**:

 Render the series using Collection.

```razor
    <SfChart @ref="liveChart" Title="CPU Usage">
        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime">
        </ChartPrimaryXAxis>

        <ChartSeriesCollection>
            <ChartSeries Type="ChartSeriesType.Line"  DataSource="@DataPoints"
                         XName="@nameof(ChartDataPoint.Time)" YName="@nameof(ChartDataPoint.CPU_Usage)">
            </ChartSeries>
        </ChartSeriesCollection>
    </SfChart>
  ```

**Step 2**:

Update the data to series at a specified interval using timer.

 ```razor
    protected override void OnInitialized()
    {
        // Starting live update in the chart.
        timer = new Timer(500);
        timer.Elapsed += AddData;
        timer.AutoReset = true;
        timer.Enabled = true;
    }
    private void AddData(Object source, ElapsedEventArgs e)
    {
        dataLength++;
        DataPoints.RemoveAt(0);
        DataPoints.Add(new ChartDataPoint
        {
            Time = DateTime.Now.AddSeconds(dataLength + 10),
            CPU_Usage = randomNum.Next(30, 80)
        });

    }
 ```

{% aspTab template="chart/how-to/add-remove", sourceFiles="live-chart.razor" %}

{% endaspTab %}

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.