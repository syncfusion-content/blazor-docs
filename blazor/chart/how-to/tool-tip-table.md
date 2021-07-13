<!-- markdownlint-disable MD036 -->

# Create a table in tooltip

You can show the tooltip as table by using [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Template) property in [`ChartTooltipSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html).

To access the aggregate values inside the Template, you can use the implicit named parameter context. You can type cast the context as [`ChartTooltipInfo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipInfo.html) to get aggregate values inside template

```razor
            <ChartTooltipSettings Enable="true">
                <Template>
                    @{
                        var data = context as ChartTooltipInfo;
                        <table>
                            <tr><td>Point Value: </td><td>@data.X : @data.Y</td></tr>
                            <tr><td><div id="chart_cloud"><img src="https://ej2.syncfusion.com/demos/src/chart/images/cloud.png" style="width: 41px; height: 41px" /></div></td></tr>
                        </table>
                    }
                </Template>
            </ChartTooltipSettings>

```

{% aspTab template="chart/how-to/tooltip", sourceFiles="tooltip.razor" %}

{% endaspTab %}

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.