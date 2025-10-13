---
layout: post
title: Data Labels in Blazor 3D Chart Component | Syncfusion
description: Check out and learn how to configure and customize the Data Labels in Syncfusion Blazor 3D Chart component.
platform: Blazor
control: 3D Chart
documentation: ug
---

# Data Labels in Blazor 3D Chart Component

Data labels display information about each data point in the chart. Enable the `Visible` property in `Chart3DDataLabel` to add data labels to a chart series. By default, labels are arranged smartly to avoid overlap.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Olympic Medals" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="Chart3DSeriesType.Column">
            <Chart3DDataLabel Visible="true"></Chart3DDataLabel>
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
    {
		new Chart3DData{ Country = "USA", Gold = 50, Silver = 70 },
		new Chart3DData{ Country = "China", Gold = 40, Silver = 60 },
		new Chart3DData{ Country = "Japan", Gold = 70, Silver = 60 },
		new Chart3DData{ Country = "Australia", Gold = 60, Silver = 56 },
		new Chart3DData{ Country = "France", Gold = 50, Silver = 45 },
		new Chart3DData{ Country = "Germany", Gold = 40, Silver = 30 },
		new Chart3DData{ Country = "Italy", Gold = 40, Silver = 35 },
		new Chart3DData{ Country = "Sweden", Gold = 30, Silver = 25 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBzZdWrfVZpBXMM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor 3D Chart with Data Label](images/data-label/blazor-chart-data-label.png)

## Position

The `Position` property places the label at the `Top`, `Middle`, or `Bottom` of the data point.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Olympic Medals" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="Chart3DSeriesType.Column">
            <Chart3DDataLabel Visible="true" Position="Syncfusion.Blazor.Chart3D.Chart3DDataLabelPosition.Middle"></Chart3DDataLabel>
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
    {
		new Chart3DData{ Country = "USA", Gold = 50, Silver = 70 },
		new Chart3DData{ Country = "China", Gold = 40, Silver = 60 },
		new Chart3DData{ Country = "Japan", Gold = 70, Silver = 60 },
		new Chart3DData{ Country = "Australia", Gold = 60, Silver = 56 },
		new Chart3DData{ Country = "France", Gold = 50, Silver = 45 },
		new Chart3DData{ Country = "Germany", Gold = 40, Silver = 30 },
		new Chart3DData{ Country = "Italy", Gold = 40, Silver = 35 },
		new Chart3DData{ Country = "Sweden", Gold = 30, Silver = 25 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLJtxCBfBjQyAbW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Changing Label Position in Blazor 3D Chart](images/data-label/blazor-chart-label-position.png)

## Template

Label content can be formatted using a template. Placeholders such as `${point.x}` and `${point.y}` display the corresponding data values. Set the template using the `Chart3DDataLabelTemplate` property.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@SalesReports" XName="X" YName="Y">
                <Chart3DDataLabel Visible="true" NameField="Text">
                    <Chart3DDataLabelTemplate>
                        @{
                            var data = context as Chart3DDataPointInfo;
                        }
                        <table>
                            <tr>
                                <td align="center" style="background-color: #C1272D; font-size: 14px; color: #E7C554; font-weight: bold; padding: 5px"> @data.PointText :</td>
                                <td align="center" style="background-color: #C1272D; font-size: 14px; color: whitesmoke; font-weight: bold; padding: 5px"> @data.Y</td>
                            </tr>
                        </table>
                    </Chart3DDataLabelTemplate>
                </Chart3DDataLabel>
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> SalesReports = new List<Data>
	{
       new Data{ X= "Jan", Y= 3, Text= "January" },
       new Data{ X= "Feb", Y= 3.5, Text= "February" },
       new Data{ X= "Mar", Y= 7, Text= "March" },
       new Data{ X= "Apr", Y= 13.5, Text= "April" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBJNRWBJVChojGx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor 3D Chart Label with Template](images/data-label/blazor-chart-datalabel-template.png)

## Text mapping

Text from the data source can be mapped to the label using the `NameField` property.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="Chart3DSeriesType.Column">
            <Chart3DDataLabel Visible="true" NameField="Text"></Chart3DDataLabel>
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data> 
	{
	   new Data{ X = "Jan", Y = 3, Text = "January" },
	   new Data{ X = "Feb", Y = 3.5, Text = "February" },
	   new Data{ X = "Mar", Y = 7, Text = "March" },
	   new Data{ X = "Apr", Y = 13.5, Text = "April" }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVJNxsrfBWdyERK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor 3D Chart Label with Text Mapping](images/data-label/blazor-chart-label-with-text-mapping.png)

## Format

Data labels can be formatted using the `Format` property. Global formatting options such as 'N1', 'P1', and 'C1' are supported.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="Chart3DSeriesType.Column">
            <Chart3DDataLabel Visible="true" Format="N1"></Chart3DDataLabel>
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data> 
	{
	   new Data{ X = "Jan", Y = 3, Text = "January" },
	   new Data{ X = "Feb", Y = 3.5, Text = "February" },
	   new Data{ X = "Mar", Y = 7, Text = "March" },
	   new Data{ X = "Apr", Y = 13.5, Text = "April" }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrJNnWhzrCaQgqM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor 3D Chart Label with Format](images/data-label/blazor-chart-label-with-format.png)

The table below shows the results of applying various commonly used label formats to numeric data.

<!-- markdownlint-disable MD033 -->

<table>
  <tr>
    <th>Value</th>
    <th>Format</th>
    <th>Resultant Value</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>1000</td>
    <td>n1</td>
    <td>1000.0</td>
    <td>The number is rounded to 1 decimal place.</td>
  </tr>
  <tr>
    <td>1000</td>
    <td>n2</td>
    <td>1000.00</td>
    <td>The number is rounded to 2 decimal places.</td>
  </tr>
   <tr>
    <td>1000</td>
    <td>n3</td>
    <td>1000.000</td>
    <td>The number is rounded to 3 decimal place.</td>
  </tr>
  <tr>
    <td>0.01</td>
    <td>p1</td>
    <td>1.0%</td>
    <td>The number is converted to percentage with 1 decimal place.</td>
  </tr>
  <tr>
    <td>0.01</td>
    <td>p2</td>
    <td>1.00%</td>
    <td>The number is converted to percentage with 2 decimal place.</td>
  </tr>
   <tr>
    <td>0.01</td>
    <td>p3</td>
    <td>1.000%</td>
    <td>The number is converted to percentage with 3 decimal place.</td>
  </tr>
  <tr>
    <td>1000</td>
    <td>c1</td>
    <td>$1000.0</td>
    <td>The currency symbol is appended to number and number is rounded to 1 decimal place.</td>
  </tr>
   <tr>
    <td>1000</td>
    <td>c2</td>
    <td>$1000.00</td>
    <td>The currency symbol is appended to number and number is rounded to 2 decimal place.</td>
  </tr>
</table>

## Margin

The `Margin` property creates space around the data label element.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="Chart3DSeriesType.Column">
            <Chart3DDataLabel Visible="true">
                <Chart3DDataLabelBorder Color="red" Width="1"></Chart3DDataLabelBorder>
                <Chart3DDataLabelMargin Bottom="5" Left="5" Right="5" Top="5"></Chart3DDataLabelMargin>
            </Chart3DDataLabel>
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data> 
	{
	   new Data{ X = "Jan", Y = 3, Text = "January" },
	   new Data{ X = "Feb", Y = 3.5, Text = "February" },
	   new Data{ X = "Mar", Y = 7, Text = "March" },
	   new Data{ X = "Apr", Y = 13.5, Text = "April" }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLpNHihJhLAjJdx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor 3D Chart Label with Margin](images/data-label/blazor-chart-label-with-margin.png)

## Customization

The `Fill` and `Chart3DDataLabelBorder` properties customize the stroke and border of the data label.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="Chart3DSeriesType.Column">
            <Chart3DDataLabel Visible="true" Fill="#AB6E15">
                    <Chart3DDataLabelBorder Width="2" Color="red"></Chart3DDataLabelBorder> 
            </Chart3DDataLabel>
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data> 
	{
	   new Data{ X = "Jan", Y = 3, Text = "January" },
	   new Data{ X = "Feb", Y = 3.5, Text = "February" },
	   new Data{ X = "Mar", Y = 7, Text = "March" },
	   new Data{ X = "Apr", Y = 13.5, Text = "April" }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrJXnCrfBBywLmC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor 3D Chart with Custom Label](images/data-label/blazor-chart-custom-label.png)

## Customizing specific label

A specific label can be customized using the `TextRender` event, which allows changing the label text for a data point.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Olympic Medals" DataLabelRendering="TextRender" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Opacity="1" YName="Gold" Type="Chart3DSeriesType.Column">
            <Chart3DDataLabel Visible="true"></Chart3DDataLabel>
        </Chart3DSeries>         
    </Chart3DSeriesCollection>

    <Chart3DLegendSettings Visible="true" />
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<Chart3DData> MedalDetails = new List<Chart3DData>
	{
		new Chart3DData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new Chart3DData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new Chart3DData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new Chart3DData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new Chart3DData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new Chart3DData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new Chart3DData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new Chart3DData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
	};

    public void TextRender(Chart3DTextRenderEventArgs args)
    {
        if (args.Point.Index == 2)
        {
            args.Text = "Label";
        }
        else
        {
            args.Cancel = true;
        }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVzNxihTVLOVTJZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor 3D Chart with Custom Speci Label](images/data-label/blazor-chart-custom-specific-label.png)
