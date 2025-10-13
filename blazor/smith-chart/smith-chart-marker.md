---
layout: post
title: Marker and Data Labels in Blazor Smith Chart Component | Syncfusion
description: Check out and learn how to configure and customize marker and data labels in Syncfusion Blazor Smith Chart component and more.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Marker and Data Labels in Blazor Smith Chart Component

Markers and data labels provide information about data points in the series. Both are disabled by default in the Smith Chart and can be enabled by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html#Syncfusion_Blazor_Charts_SmithChartSeriesMarker_Visible) property in the marker and data label settings to **true**.

## Marker

By default, markers are not visible. Enable them by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html#Syncfusion_Blazor_Charts_SmithChartSeriesMarker_Visible) property to **true** in [SmithChartSeriesMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html). This adds a marker for each data point in the series. Marker settings can be customized for each series in the Smith Chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'></SmithChartSeriesMarker>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };

    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with Marker](./images/Marker/blazor-smith-chart-marker.png)

### Marker Customization

Customize marker properties for each series using [SmithChartSeriesMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html):

* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html#Syncfusion_Blazor_Charts_SmithChartSeriesMarker_Width) – Sets the marker width.
* [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html#Syncfusion_Blazor_Charts_SmithChartSeriesMarker_Height) – Sets the marker height.
* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html#Syncfusion_Blazor_Charts_SmithChartSeriesMarker_Fill) – Sets the marker fill color.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html#Syncfusion_Blazor_Charts_SmithChartSeriesMarker_Opacity) – Sets the marker opacity.
* [SmithChartSeriesMarkerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarkerBorder.html) – Controls the marker border's width and color.
* [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html#Syncfusion_Blazor_Charts_SmithChartSeriesMarker_Shape) – Changes the marker shape.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'
                                    Height='10'
                                    Width='10'
                                    Fill="#ff99ff"
                                    Opacity='1'
                                    Shape='@Shape.Rectangle'>
                <SmithChartSeriesMarkerBorder Width='2' Color="#cc00cc">
                </SmithChartSeriesMarkerBorder>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };

    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with Custom Marker](./images/Marker/blazor-smith-chart-custom-marker.png)

## Data Labels

Data labels are disabled by default. Enable them by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesDatalabel.html#Syncfusion_Blazor_Charts_SmithChartSeriesDatalabel_Visible) property to **true** in [SmithChartSeriesDatalabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesDatalabel.html). A data label is created for each point in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker>
                <SmithChartSeriesDatalabel Visible='true'></SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };

    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with Data Label](./images/Marker/blazor-smith-chart-data-label.png)

### Data Labels Customization

Customize data labels using the following properties:

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesDatalabel.html#Syncfusion_Blazor_Charts_SmithChartSeriesDatalabel_Fill) – Sets the fill color of the data labels.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesDatalabel.html#Syncfusion_Blazor_Charts_SmithChartSeriesDatalabel_Opacity) – Controls the opacity of the data labels.
* [SmithChartSeriesDataLabelBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesDataLabelBorder.html) – Customizes the border width and color.
* [SmithChartDataLabelTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartDataLabelTextStyle.html) – Customizes font properties for the data label text.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'>
                <SmithChartSeriesDatalabel Visible='true' Fill="#99ffcc" Opacity='1'>
                    <SmithChartDataLabelTextStyle Color="red" Size="15px"></SmithChartDataLabelTextStyle>
                    <SmithChartSeriesDataLabelBorder Color="green" Width='2'>
                    </SmithChartSeriesDataLabelBorder>
                </SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };

    private List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with Custom Data Label](./images/Marker/blazor-smith-chart-custom-data-label.png)

### Smart Labels

Data labels can be placed smartly by setting the [EnableSmartLabels](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_EnableSmartLabels) property to **true** in the Smith Chart series. Connector lines for smart labels can be customized using the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartDataLabelConnectorLine.html#Syncfusion_Blazor_Charts_SmithChartDataLabelConnectorLine_Color) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartDataLabelConnectorLine.html#Syncfusion_Blazor_Charts_SmithChartDataLabelConnectorLine_Width) properties in [SmithChartDataLabelConnectorLine](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartDataLabelConnectorLine.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries EnableSmartLabels="true" Name="Transmission" DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'>
                <SmithChartSeriesDatalabel Visible='true'>
                    <SmithChartDataLabelConnectorLine Color="red" Width="1.5"></SmithChartDataLabelConnectorLine>
                </SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };

    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 }, new SmithChartData { Resistance = 8, Reactance = 6 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 }, new SmithChartData { Resistance = 4.5, Reactance = 2 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 }, new SmithChartData { Resistance = 2.5, Reactance = 1.3 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 }, new SmithChartData { Resistance = 1.5, Reactance = 1 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 }, new SmithChartData { Resistance = 0.5, Reactance = 0.4 },
        new SmithChartData { Resistance = 0.3, Reactance = 0.2 }, new SmithChartData { Resistance = 0, Reactance = 0.15 }
    };
}

```

![Blazor Smith Chart with Smart Data Labels](./images/Marker/blazor-smith-chart-with-smart-data-labels.png)

### Data Label Template

To access aggregate values inside the template, use the implicit named parameter `context`, which can be typecast as [SmithChartPoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartPoint.html) to retrieve values within the template.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'>
                <SmithChartSeriesDatalabel Visible='true'>
                    <Template>
                        @{
                            var data = context as SmithChartPoint;
                        }
                        <div style="background-color: blue">@data.Resistance: @data.Reactance</div>
                    </Template>
                </SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };

    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with Data Label Template](./images/Marker/blazor-smith-chart-data-label-template.png)
