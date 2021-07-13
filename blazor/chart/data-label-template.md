---
layout: post
title: Data Label Template in Blazor Chart Component | Syncfusion 
description: Learn about Data Label Template in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# DataLabel Template

You can bind text and interior information for a point from datasource other than x and y value.

To access the aggregate values inside the [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Template), you can use the implicit named parameter context. You can type cast the context as IChartTemplate to get aggregate values inside template.

You can also change this implicit parameter name using Context attribute.

For example, you can access the data label template using context as follows.

```razor
        <ChartDataLabel Visible="true">
                    <Template>
                        @{
                             var data = context as ChartDataPointInfo;
                            <table>
                                <tr><td align="center"> @data.Y</td></tr>
                            </table>
                        }
                    </Template>
         </ChartDataLabel>
  
```

{% aspTab template="chart/data-label-template", sourceFiles="data-label-template.razor" %}

{% endaspTab %}

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.