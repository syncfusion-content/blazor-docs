---
layout: post
title: Accessibility Customization in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Accessibility Customization in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Accessibility Customization in Blazor Chart Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Chart component is structured to visualize data in a graphical manner. It provides robust customization options for accessibility, allowing you to enhance the user experience for those with disabilities. The main attributes of the Blazor Chart component's accessibility customization are briefly explained in this section.

The chart component has a number of characteristics that enable accessibility features to be customized, including:
*  [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_AccessibilityDescription) - Provides a text description for the chart, improving support for screen readers.
*  [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_AccessibilityRole) - Specifies the role of the chart, helping screen readers to identify the element appropriately.
*  [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Focusable) - Allows the chart to receive focus, making it accessible via keyboard navigation.
*  [FocusBorderColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_FocusBorderColor) - Sets the color of the focus border, enhancing visibility when the chart is focused.
*  [FocusBorderMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_FocusBorderMargin) - Defines the margin around the focus border.
*  [FocusBorderWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_FocusBorderWidth) - Specifies the width of the focus border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statics in 2024" SubTitle="-In Percentage" AccessibilityDescription=@description AccessibilityRole=@role
        Focusable="true" FocusBorderColor="@focusColor" FocusBorderMargin="5" FocusBorderWidth="@focusThickness">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" DataSource="@StatisticsDetails">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    string description = "Browser Statics in 2024";
    string role = "graphics";
    string focusColor = "red";
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

The [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) attributes allow for customization of the accessibility for each specific chart series. [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) has characteristics that can be adjusted for accessibility, such as:
* [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_AccessibilityDescription) - Provides a text description for the series' root element, enhancing support for screen readers.
* [AccessibilityDescriptionFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_AccessibilityDescriptionFormat) - Specifies a format for the accessibility description of each point in the series, allowing dynamic content. The format string can include the placeholders such as ${series.name}, ${point.x}, ${point.y}, ${point.high}, etc. For example, the format "${series.name} : ${point.x}" displays the series name and x-value of the point in the accessibility description. Data point's values like `high`, `low`, `open`, and `close` are applicable based on the series types.
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_AccessibilityRole) - Specifies the role of the series, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Focusable) - Allows the series to receive focus, making it accessible via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statics in 2024" SubTitle="-In Percentage">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" DataSource="@StatisticsDetails" AccessibilityDescription="Line series with 6 data points" AccessibilityDescriptionFormat="${series.name} : ${point.y}%" AccessibilityRole="img" Focusable="true">
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

In blazor chart component, the [ChartTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html) and [ChartSubTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSubTitleStyle.html) attributes allow you to customize the accessibility of the chart's title and subtitle.The following properties in [ChartTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html) and [ChartSubTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSubTitleStyle.html) can be customized for accessibility:
* [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html#Syncfusion_Blazor_Charts_ChartTitleStyle_AccessibilityDescription) - Provides a text description for the chart title, enhancing support for screen readers.
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html#Syncfusion_Blazor_Charts_ChartTitleStyle_AccessibilityRole) - Specifies the role of the chart title, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html#Syncfusion_Blazor_Charts_ChartTitleStyle_Focusable) - Enables or disables the keyboard navigation focus for title.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statics in 2024" SubTitle="-In Percentage">
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

The [ChartAnnotations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html) property allows to add annotations to the chart at specific region. The characteristics, which include the following, allow for customization of the annotations' accessibility: 
* [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html#Syncfusion_Blazor_Charts_ChartAnnotations_AccessibilityDescription) - Provides a text description for the annotation, enhancing support for screen readers.
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html#Syncfusion_Blazor_Charts_ChartAnnotations_AccessibilityRole) - Specifies the role of the annotation, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html#Syncfusion_Blazor_Charts_ChartAnnotations_Focusable) - Specifies whether annotations are focusable via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statics in 2024" SubTitle="-In Percentage">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartAnnotations AccessibilityDescription="Arrows Used to Indicate High and Low Users in Browsers" AccessibilityRole="text" Focusable="true">
        <ChartAnnotation X="StatisticsDetails[0].Browser" Y="65.3" CoordinateUnits="Units.Point">
            <ContentTemplate>
                <div><img src="./up-arrow.png" style="width: 41px; height: 41px" alt="Up Arrow" /></div>
            </ContentTemplate>
        </ChartAnnotation>
        <ChartAnnotation X="StatisticsDetails[5].Browser" Y="2.4" CoordinateUnits="Units.Point">
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

Customizable properties within the [ChartTrendline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html) allow you to control the accessibility of the trendline on the chart, including:
* [AccessibilityDescription](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_AccessibilityDescription) - Provides a text description for the trendline, enhancing support for screen readers.
* [AccessibilityDescriptionFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_AccessibilityDescriptionFormat) - Specifies a format for the accessibility description of the trendline, allowing dynamic content. For example, the format "${series.name} : ${point.x}" displays the series name and x-value of the point in the accessibility description.
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_AccessibilityRole) - Specifies the role of the trendline, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Focusable) - Specifies whether trendlines are focusable via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statics in 2024" SubTitle="-In Percentage">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" DataSource="@StatisticsDetails">
            <ChartTrendlines>
                <ChartTrendline Visible="true" AccessibilityDescriptionFormat="${point.x} : ${point.y}%" AccessibilityRole="img"  Focusable="true">
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

The [ChartZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html) attributes allow you to adjust the chart's zooming capability. [ChartZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html) offers the following parameters for accessibility customization:
* [AccessibilityDescriptionFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html#Syncfusion_Blazor_Charts_ChartZoomSettings_AccessibilityDescriptionFormat) - Specifies a format for the accessibility description of the zoom toolkit items, allowing dynamic content. The format string can include placeholders such as {value} to display zoom toolkit item name in the accessibility description. For example, the format "Selected the ${value} option" will read as "Selected the ZoomIn option" for the ZoomIn item from [ToolbarItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html#Syncfusion_Blazor_Charts_ChartZoomSettings_ToolbarItems).
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html#Syncfusion_Blazor_Charts_ChartZoomSettings_AccessibilityRole) - Specifies the role of the zoom toolkit items, helping screen readers to identify the element appropriately.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartZoomSettings.html#Syncfusion_Blazor_Charts_ChartZoomSettings_Focusable) - Specifies whether zoom toolkit items are focusable via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statics in 2024" SubTitle="-In Percentage">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Browsers-2024" XName="Browser" YName="Users" DataSource="@StatisticsDetails">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartZoomSettings EnableSelectionZooming="true" AccessibilityDescriptionFormat="Select the {value} button" AccessibilityRole="button" Focusable="true">
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

The [ChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html) provides the information on the series shown in the chart. The following properties in [ChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html) can be used to alter the accessibility of the chart's legend:
* [AccessibilityDescriptionFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_AccessibilityDescriptionFormat) - Specifies a format for the accessibility description of the legend items. The format string can include placeholders such as {value} to set the accessibility text for the legend item. For example, the format "Selected the ${value} legend" will read as "Selected the Product A legend" for the legend item with text "Product A".
* [AccessibilityRole](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_AccessibilityRole) - Specifies the role of the legend items to screen readers, providing appropriate context.
* [Focusable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Focusable) - Specifies whether legend items are focusable via keyboard navigation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Browser Statics in 2024" SubTitle="-In Percentage">
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhfXnWhVHFlrqSz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 
