---
layout: post
title: Blazor Charts Accessibility Customization | Syncfusion®
description: Learn how to configure accessibility in Syncfusion Blazor Charts. Set AccessibilityDescription, AccessibilityRole, and Focusable for screen readers.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Accessibility Customization

The [Blazor Chart](https://www.syncfusion.com/blazor-components/blazor-charts) component displays data graphically. It provides robust customization options for accessibility, allowing you to enhance the user experience for those with disabilities. The following properties summarize the accessibility features supported by the chart component:

* [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_AccessibilityDescription) - Provides a text description for the chart, improving support for screen readers.
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_AccessibilityRole) - Specifies the role of the chart, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Focusable) - Allows the chart to receive focus, making it accessible via keyboard navigation.
* [FocusBorderColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_FocusBorderColor) - Sets the color of the focus border, enhancing visibility when the chart is focused.
* [FocusBorderMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_FocusBorderMargin) - Defines the margin around the focus border.
* [FocusBorderWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_FocusBorderWidth) - Specifies the width of the focus border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statistics in 2024" SubTitle="In Percentage" AccessibilityDescription="@description" AccessibilityRole="@role"
        Focusable="true" FocusBorderColor="@focusColor" FocusBorderMargin="@focusMargin" FocusBorderWidth="@focusThickness">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" Type="ChartSeriesType.Column" DataSource="@StatisticsDetails">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    string description = "Browser Statistics in 2024";
    string role = "img";
    string focusColor = "red";
    double focusMargin = 5;
    double focusThickness = 3;

    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 65.3 },
        new Statistics { Browser = "Safari", Users = 18.3 },
        new Statistics { Browser = "Edge", Users = 5 },
        new Statistics { Browser = "Firefox", Users = 3 },
        new Statistics { Browser = "Samsung Internet", Users = 2.6 },
        new Statistics { Browser = "Opera", Users = 2.4 }
    };
}

```

## Series

The [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) attributes allow you to customize accessibility for each specific chart series. The following properties in [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) can be adjusted for accessibility:
* [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_AccessibilityDescription) - Provides a text description for the series' root element, enhancing support for screen readers.
* [AccessibilityDescriptionFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_AccessibilityDescriptionFormat) - Specifies a format for the accessibility description of each point in the series, allowing dynamic content. The format string can include placeholders such as `${series.name}`, `${point.x}`, `${point.y}`, `${point.high}`, `${point.low}`, `${point.open}`, and `${point.close}`. For example, the format `"${series.name} : ${point.x}"` displays the series name and x-value of the point in the accessibility description. The data point values `high`, `low`, `open`, and `close` apply only to the relevant financial series types.
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_AccessibilityRole) - Specifies the role of the series, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Focusable) - Allows the series to receive focus, making it accessible via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statistics in 2024" SubTitle="In Percentage">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" Type="ChartSeriesType.Column" DataSource="@StatisticsDetails" AccessibilityDescription="Column series with 6 data points" AccessibilityDescriptionFormat="${series.name} : ${point.y}%" AccessibilityRole="img" Focusable="true">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 65.3 },
        new Statistics { Browser = "Safari", Users = 18.3 },
        new Statistics { Browser = "Edge", Users = 5 },
        new Statistics { Browser = "Firefox", Users = 3 },
        new Statistics { Browser = "Samsung Internet", Users = 2.6 },
        new Statistics { Browser = "Opera", Users = 2.4 }
    };
}

```

## Title and subtitle

In the Blazor Chart component, the [ChartTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html) and [ChartSubTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSubTitleStyle.html) attributes allow you to customize the accessibility of the chart's title and subtitle. The following properties in [ChartTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html) and [ChartSubTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSubTitleStyle.html) can be customized for accessibility:
* [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html#Syncfusion_Blazor_Charts_ChartTitleStyle_AccessibilityDescription) - Provides a text description for the chart title, enhancing support for screen readers.
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html#Syncfusion_Blazor_Charts_ChartTitleStyle_AccessibilityRole) - Specifies the role of the chart title, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html#Syncfusion_Blazor_Charts_ChartTitleStyle_Focusable) - Enables or disables keyboard navigation focus for the title.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statistics in 2024" SubTitle="In Percentage">
    <ChartTitleStyle AccessibilityDescription="Chart Title" AccessibilityRole="text" Focusable="true"></ChartTitleStyle>
    <ChartSubTitleStyle Focusable="false"></ChartSubTitleStyle>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" DataSource="@StatisticsDetails">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 65.3 },
        new Statistics { Browser = "Safari", Users = 18.3 },
        new Statistics { Browser = "Edge", Users = 5 },
        new Statistics { Browser = "Firefox", Users = 3 },
        new Statistics { Browser = "Samsung Internet", Users = 2.6 },
        new Statistics { Browser = "Opera", Users = 2.4 }
    };
}

```

## Annotations

The [ChartAnnotations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html) property allows you to add annotations to the chart at a specific region. The following characteristics allow for customization of the annotations' accessibility:
* [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html#Syncfusion_Blazor_Charts_ChartAnnotations_AccessibilityDescription) - Provides a text description for the annotation, enhancing support for screen readers.
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html#Syncfusion_Blazor_Charts_ChartAnnotations_AccessibilityRole) - Specifies the role of the annotation, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html#Syncfusion_Blazor_Charts_ChartAnnotations_Focusable) - Specifies whether annotations are focusable via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statistics in 2024" SubTitle="In Percentage">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartAnnotations AccessibilityDescription="Arrows used to indicate high and low users in browsers" AccessibilityRole="text" Focusable="true">
        <ChartAnnotation X="@(StatisticsDetails[0].Browser)" Y="65.3" CoordinateUnits="Units.Point">
            <ContentTemplate>
                <div><img src="./up-arrow.png" style="width: 41px; height: 41px" alt="Up Arrow" /></div>
            </ContentTemplate>
        </ChartAnnotation>
        <ChartAnnotation X="@(StatisticsDetails[5].Browser)" Y="2.4" CoordinateUnits="Units.Point">
            <ContentTemplate>
                <div><img src="./down-arrow.png" style="width: 41px; height: 41px" alt="Down Arrow" /></div>
            </ContentTemplate>
        </ChartAnnotation>
    </ChartAnnotations>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" DataSource="@StatisticsDetails">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 65.3 },
        new Statistics { Browser = "Safari", Users = 18.3 },
        new Statistics { Browser = "Edge", Users = 5 },
        new Statistics { Browser = "Firefox", Users = 3 },
        new Statistics { Browser = "Samsung Internet", Users = 2.6 },
        new Statistics { Browser = "Opera", Users = 2.4 }
    };
}

```

## Trendline

The [ChartTrendline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html) provides the following properties to customize accessibility for the trendline on the chart:
* [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_AccessibilityDescription) - Provides a text description for the trendline, enhancing support for screen readers.
* [AccessibilityDescriptionFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_AccessibilityDescriptionFormat) - Specifies a format for the accessibility description of the trendline, allowing dynamic content. The format string can include placeholders such as `${series.name}`, `${point.x}`, and `${point.y}`. For example, the format `"${series.name} : ${point.x}"` displays the series name and x-value of the point in the accessibility description.
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_AccessibilityRole) - Specifies the role of the trendline, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Focusable) - Specifies whether trendlines are focusable via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statistics in 2024" SubTitle="In Percentage">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" Type="ChartSeriesType.Line" DataSource="@StatisticsDetails">
            <ChartTrendlines>
                <ChartTrendline Visible="true" AccessibilityDescription="Linear trendline for browser usage" AccessibilityDescriptionFormat="${series.name} : ${point.y}%" AccessibilityRole="img" Focusable="true">
                    <ChartTrendlineMarker Visible="true"></ChartTrendlineMarker>
                </ChartTrendline>
            </ChartTrendlines>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 65.3 },
        new Statistics { Browser = "Safari", Users = 18.3 },
        new Statistics { Browser = "Edge", Users = 5 },
        new Statistics { Browser = "Firefox", Users = 3 },
        new Statistics { Browser = "Samsung Internet", Users = 2.6 },
        new Statistics { Browser = "Opera", Users = 2.4 }
    };
}

```

## Zooming

The [ChartZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html) attributes allow you to adjust the chart's zooming. [ChartZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html) offers the following parameters for accessibility customization:
* [AccessibilityDescriptionFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html#Syncfusion_Blazor_Charts_ChartZoomSettings_AccessibilityDescriptionFormat) - Specifies a format for the accessibility description of the zoom toolkit items, allowing dynamic content. The format string can include the placeholder `{value}` to display the zoom toolkit item name in the accessibility description. For example, the format `"Select the {value} button"` reads as "Select the ZoomIn button" for the ZoomIn item from [ToolbarItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html#Syncfusion_Blazor_Charts_ChartZoomSettings_ToolbarItems).
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html#Syncfusion_Blazor_Charts_ChartZoomSettings_AccessibilityRole) - Specifies the role of the zoom toolkit items, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html#Syncfusion_Blazor_Charts_ChartZoomSettings_Focusable) - Specifies whether zoom toolkit items are focusable via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statistics in 2024" SubTitle="In Percentage">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" Type="ChartSeriesType.Column" DataSource="@StatisticsDetails">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartZoomSettings EnableSelectionZooming="true" EnableMouseWheelZooming="true" EnablePinchZooming="true" AccessibilityDescriptionFormat="Select the {value} button" AccessibilityRole="button" Focusable="true">
    </ChartZoomSettings>
</SfChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 65.3 },
        new Statistics { Browser = "Safari", Users = 18.3 },
        new Statistics { Browser = "Edge", Users = 5 },
        new Statistics { Browser = "Firefox", Users = 3 },
        new Statistics { Browser = "Samsung Internet", Users = 2.6 },
        new Statistics { Browser = "Opera", Users = 2.4 }
    };
}

```

## Legend

The [ChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html) displays information about the series shown in the chart. The following properties in [ChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html) can be used to alter the accessibility of the chart's legend:
* [AccessibilityDescriptionFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_AccessibilityDescriptionFormat) - Specifies a format for the accessibility description of the legend items. The format string can include the placeholder `{value}` to set the accessibility text for the legend item. For example, the format `"Click to toggle the {value} series"` reads as "Click to toggle the Browsers-2024 series" for the legend item with text "Browsers-2024".
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_AccessibilityRole) - Specifies the role of the legend items to screen readers, providing appropriate context.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Focusable) - Specifies whether legend items are focusable via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statistics in 2024" SubTitle="In Percentage">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" DataSource="@StatisticsDetails">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="true" AccessibilityDescriptionFormat="Click to toggle the {value} series" AccessibilityRole="img" Focusable="true">
    </ChartLegendSettings>
</SfChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 65.3 },
        new Statistics { Browser = "Safari", Users = 18.3 },
        new Statistics { Browser = "Edge", Users = 5 },
        new Statistics { Browser = "Firefox", Users = 3 },
        new Statistics { Browser = "Samsung Internet", Users = 2.6 },
        new Statistics { Browser = "Opera", Users = 2.4 }
    };
}

```

Here is a preview sample demonstrating the accessibility customization support for all chart elements:

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhRDHsreiUpbASQ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## See also

* [Accessibility in Blazor Charts](./accessibility.md)
