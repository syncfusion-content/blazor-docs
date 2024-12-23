---
layout: post
title: Legends for Blazor Sankey Diagram | Syncfusion
description: Learn how to configure and customize legends in the Blazor Sankey Diagram to enhance data interpretation and user interaction.
platform: Blazor
control: Sankey
documentation: ug
---

# Legends in Blazor Sankey Diagram

## Overview

Legends in a Sankey diagram provide a visual key to interpret the different nodes or links in the diagram. This topic covers how to configure and customize legends in the Blazor Sankey diagram.

## Basic Legend Configuration

Legends in a Sankey diagram provide a visual representation of the categories or elements involved in your data flow, making it easier for users to interpret and analyze the diagram. They help identify nodes, links, or other key elements by associating them with descriptive labels or colors. The `SankeyLegendSettings` in the Sankey diagram allows you to customize the legend's visibility, position, size, and other settings. By enabling and configuring the legend, you can offer users a clear and interactive way to understand the connections and relationships in the data.

Below is an example of how to configure legends for a Sankey diagram. The sample demonstrates how to add and position the legend, adjust its height, and bind data to the Sankey diagram. This configuration can be used to create a well-organized and visually intuitive data visualization.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Sankey;

<SfSankey Nodes="@Nodes" Links="@Links">
    <SankeyLegendSettings 
        Visible="true" 
        Position="SankeyLegendPosition.Bottom" 
        Height="200px">
    </SankeyLegendSettings>
</SfSankey>
@code {
    public List<SankeyDataNode> Nodes = new List<SankeyDataNode>();
    public List<SankeyDataLink> Links = new List<SankeyDataLink>();
    protected override void OnInitialized()
    {
        Nodes = new List<SankeyDataNode>()
        {
            new SankeyDataNode() { Id = "Solar", Label = new SankeyDataLabel() { Text = "Solar" } },
            new SankeyDataNode() { Id = "Wind", Label = new SankeyDataLabel() { Text = "Wind" } },
            new SankeyDataNode() { Id = "Hydro", Label = new SankeyDataLabel() { Text = "Hydro" } },
            new SankeyDataNode() { Id = "Nuclear", Label = new SankeyDataLabel() { Text = "Nuclear" } },
            new SankeyDataNode() { Id = "Coal", Label = new SankeyDataLabel() { Text = "Coal" } },
            new SankeyDataNode() { Id = "Natural Gas", Label = new SankeyDataLabel() { Text = "Natural Gas" } },
            new SankeyDataNode() { Id = "Oil", Label = new SankeyDataLabel() { Text = "Oil" } },
            new SankeyDataNode() { Id = "Electricity", Label = new SankeyDataLabel() { Text = "Electricity" } },
            new SankeyDataNode() { Id = "Heat", Label = new SankeyDataLabel() { Text = "Heat" } },
            new SankeyDataNode() { Id = "Fuel", Label = new SankeyDataLabel() { Text = "Fuel" } },
            new SankeyDataNode() { Id = "Residential", Label = new SankeyDataLabel() { Text = "Residential" } },
            new SankeyDataNode() { Id = "Commercial", Label = new SankeyDataLabel() { Text = "Commercial" } },
            new SankeyDataNode() { Id = "Industrial", Label = new SankeyDataLabel() { Text = "Industrial" } },
            new SankeyDataNode() { Id = "Transportation", Label = new SankeyDataLabel() { Text = "Transportation" } },
            new SankeyDataNode() { Id = "Energy Services", Label = new SankeyDataLabel() { Text = "Energy Services" } },
            new SankeyDataNode() { Id = "Losses", Label = new SankeyDataLabel() { Text = "Losses" } }
        };

        Links = new List<SankeyDataLink>()
        {
            // Energy Sources to Carriers
            new SankeyDataLink() { SourceId = "Solar", TargetId = "Electricity", Value = 100 },
            new SankeyDataLink() { SourceId = "Wind", TargetId = "Electricity", Value = 120 },
            new SankeyDataLink() { SourceId = "Hydro", TargetId = "Electricity", Value = 80 },
            new SankeyDataLink() { SourceId = "Nuclear", TargetId = "Electricity", Value = 90 },
            new SankeyDataLink() { SourceId = "Coal", TargetId = "Electricity", Value = 200 },
            new SankeyDataLink() { SourceId = "Natural Gas", TargetId = "Electricity", Value = 130 },
            new SankeyDataLink() { SourceId = "Natural Gas", TargetId = "Heat", Value = 80 },
            new SankeyDataLink() { SourceId = "Oil", TargetId = "Fuel", Value = 250 },

            // Energy Carriers to Sectors
            new SankeyDataLink() { SourceId = "Electricity", TargetId = "Residential", Value = 170 },
            new SankeyDataLink() { SourceId = "Electricity", TargetId = "Commercial", Value = 160 },
            new SankeyDataLink() { SourceId = "Electricity", TargetId = "Industrial", Value = 210 },
            new SankeyDataLink() { SourceId = "Heat", TargetId = "Residential", Value = 40 },
            new SankeyDataLink() { SourceId = "Heat", TargetId = "Commercial", Value = 20 },
            new SankeyDataLink() { SourceId = "Heat", TargetId = "Industrial", Value = 20 },
            new SankeyDataLink() { SourceId = "Fuel", TargetId = "Transportation", Value = 200 },
            new SankeyDataLink() { SourceId = "Fuel", TargetId = "Industrial", Value = 50 },

            // Sectors to End Use and Losses
            new SankeyDataLink() { SourceId = "Residential", TargetId = "Energy Services", Value = 180 },
            new SankeyDataLink() { SourceId = "Commercial", TargetId = "Energy Services", Value = 150 },
            new SankeyDataLink() { SourceId = "Industrial", TargetId = "Energy Services", Value = 230 },
            new SankeyDataLink() { SourceId = "Transportation", TargetId = "Energy Services", Value = 150 },
            new SankeyDataLink() { SourceId = "Residential", TargetId = "Losses", Value = 30 },
            new SankeyDataLink() { SourceId = "Commercial", TargetId = "Losses", Value = 30 },
            new SankeyDataLink() { SourceId = "Industrial", TargetId = "Losses", Value = 50 },
            new SankeyDataLink() { SourceId = "Transportation", TargetId = "Losses", Value = 50 }
        };
        base.OnInitialized();
    }
}

{% endhighlight %}
{% endtabs %}


![Blazor Sankey Basic Legend](images/legends/sankey-legends.png)

## Legend Customization and Configuration

The Sankey diagram component offers a robust set of features for legend customization and configuration, allowing users to create visually appealing and informative representations of their data. This comprehensive toolset encompasses a wide range of options, from basic visibility controls to advanced styling capabilities.

Appearance customization extends beyond basic properties, allowing for detailed adjustments to the legend's visual elements. Users can modify the dimensions of legend shapes, customize the padding between shapes and text, and even invert or reverse the order of legend items. The legend can be further enhanced with a title, adding context to the displayed information.

- `Visible`: Determines whether the legend is displayed (default is true).
- `Position`: Sets the position of the legend (Auto, Top, Left, Bottom, Right).
- `Width` and `Height`: Set the dimensions of the legend.
- `Padding`: Sets the padding around the legend collection.
- `ItemPadding`: Sets the padding between legend items.
- `ShapeWidth` and `ShapeHeight`: Set the dimensions of the legend shapes.
- `ShapePadding`: Sets the padding between the legend shape and text.
- `Background`: Sets the background color of the legend area.
- `Opacity`: Sets the opacity of the legend background.
- `EnableHighlight`: Enables highlighting of corresponding elements when hovering over legend items.
- `Title`: Sets a title for the legend.
- `IsInversed`: Inverts the order of the shape and text in legend items.
- `Reverse`: Reverses the order of legend items.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Sankey;

<SfSankey Nodes="@Nodes" Links="@Links">
    <SankeyLegendSettings 
    Visible="true" 
    Position="SankeyLegendPosition.Bottom"
    Width="100%"
    Height="200px"
    Background="#f0f0f0"
    Opacity="0.8"
    BorderColor="#cccccc"
    BorderWidth="1"
    ShapeWidth="15"
    ShapeHeight="15"
    EnableHighlight="true"
    Title="Energy Flow"
    IsInversed="false"
    Reverse="false">
    <SankeyLegendMargin Left="20" Right="20" Top="20" Bottom="20"></SankeyLegendMargin>
</SankeyLegendSettings>
</SfSankey>
@code {
    public List<SankeyDataNode> Nodes = new List<SankeyDataNode>();
    public List<SankeyDataLink> Links = new List<SankeyDataLink>();
    protected override void OnInitialized()
    {
        Nodes = new List<SankeyDataNode>()
        {
            new SankeyDataNode() { Id = "Solar", Label = new SankeyDataLabel() { Text = "Solar" } },
            new SankeyDataNode() { Id = "Wind", Label = new SankeyDataLabel() { Text = "Wind" } },
            new SankeyDataNode() { Id = "Hydro", Label = new SankeyDataLabel() { Text = "Hydro" } },
            new SankeyDataNode() { Id = "Nuclear", Label = new SankeyDataLabel() { Text = "Nuclear" } },
            new SankeyDataNode() { Id = "Coal", Label = new SankeyDataLabel() { Text = "Coal" } },
            new SankeyDataNode() { Id = "Natural Gas", Label = new SankeyDataLabel() { Text = "Natural Gas" } },
            new SankeyDataNode() { Id = "Oil", Label = new SankeyDataLabel() { Text = "Oil" } },
            new SankeyDataNode() { Id = "Electricity", Label = new SankeyDataLabel() { Text = "Electricity" } },
            new SankeyDataNode() { Id = "Heat", Label = new SankeyDataLabel() { Text = "Heat" } },
            new SankeyDataNode() { Id = "Fuel", Label = new SankeyDataLabel() { Text = "Fuel" } },
            new SankeyDataNode() { Id = "Residential", Label = new SankeyDataLabel() { Text = "Residential" } },
            new SankeyDataNode() { Id = "Commercial", Label = new SankeyDataLabel() { Text = "Commercial" } },
            new SankeyDataNode() { Id = "Industrial", Label = new SankeyDataLabel() { Text = "Industrial" } },
            new SankeyDataNode() { Id = "Transportation", Label = new SankeyDataLabel() { Text = "Transportation" } },
            new SankeyDataNode() { Id = "Energy Services", Label = new SankeyDataLabel() { Text = "Energy Services" } },
            new SankeyDataNode() { Id = "Losses", Label = new SankeyDataLabel() { Text = "Losses" } }
        };

        Links = new List<SankeyDataLink>()
        {
            // Energy Sources to Carriers
            new SankeyDataLink() { SourceId = "Solar", TargetId = "Electricity", Value = 100 },
            new SankeyDataLink() { SourceId = "Wind", TargetId = "Electricity", Value = 120 },
            new SankeyDataLink() { SourceId = "Hydro", TargetId = "Electricity", Value = 80 },
            new SankeyDataLink() { SourceId = "Nuclear", TargetId = "Electricity", Value = 90 },
            new SankeyDataLink() { SourceId = "Coal", TargetId = "Electricity", Value = 200 },
            new SankeyDataLink() { SourceId = "Natural Gas", TargetId = "Electricity", Value = 130 },
            new SankeyDataLink() { SourceId = "Natural Gas", TargetId = "Heat", Value = 80 },
            new SankeyDataLink() { SourceId = "Oil", TargetId = "Fuel", Value = 250 },

            // Energy Carriers to Sectors
            new SankeyDataLink() { SourceId = "Electricity", TargetId = "Residential", Value = 170 },
            new SankeyDataLink() { SourceId = "Electricity", TargetId = "Commercial", Value = 160 },
            new SankeyDataLink() { SourceId = "Electricity", TargetId = "Industrial", Value = 210 },
            new SankeyDataLink() { SourceId = "Heat", TargetId = "Residential", Value = 40 },
            new SankeyDataLink() { SourceId = "Heat", TargetId = "Commercial", Value = 20 },
            new SankeyDataLink() { SourceId = "Heat", TargetId = "Industrial", Value = 20 },
            new SankeyDataLink() { SourceId = "Fuel", TargetId = "Transportation", Value = 200 },
            new SankeyDataLink() { SourceId = "Fuel", TargetId = "Industrial", Value = 50 },

            // Sectors to End Use and Losses
            new SankeyDataLink() { SourceId = "Residential", TargetId = "Energy Services", Value = 180 },
            new SankeyDataLink() { SourceId = "Commercial", TargetId = "Energy Services", Value = 150 },
            new SankeyDataLink() { SourceId = "Industrial", TargetId = "Energy Services", Value = 230 },
            new SankeyDataLink() { SourceId = "Transportation", TargetId = "Energy Services", Value = 150 },
            new SankeyDataLink() { SourceId = "Residential", TargetId = "Losses", Value = 30 },
            new SankeyDataLink() { SourceId = "Commercial", TargetId = "Losses", Value = 30 },
            new SankeyDataLink() { SourceId = "Industrial", TargetId = "Losses", Value = 50 },
            new SankeyDataLink() { SourceId = "Transportation", TargetId = "Losses", Value = 50 }
        };
        base.OnInitialized();
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor Sankey Customized Legend](images/legends/sankey-legend-customization.png)

### Legend Text and Title Styles

The Sankey diagram provides advanced customization options for legend text and title styles through the `SankeyLegendTextStyle` and `SankeyLegendTitleStyle` APIs, enabling developers to configure properties such as font size, family, weight, color, and style. These APIs offer flexibility to align the legend's typography with the overall design aesthetic of the visualization, ensuring the legends complement the data representation and enhance the user experience. This level of control allows for seamless integration of legends into a wide range of visualization styles, from simple and clean to highly customized designs, as demonstrated in the following code snippet:

{% tabs %}
{% highlight razor %}

<SankeyLegendSettings>
    <SankeyLegendTextStyle 
        FontSize="11px" 
        FontFamily="Segoe UI" 
        FontWeight="500" 
        Color="#666666" 
        FontStyle="normal">
    </SankeyLegendTextStyle>
    <SankeyLegendTitleStyle 
        FontSize="13px" 
        FontFamily="Segoe UI" 
        FontWeight="600" 
        Color="#333333" 
        FontStyle="normal">
    </SankeyLegendTitleStyle>
</SankeyLegendSettings>

{% endhighlight %}
{% endtabs %}

## Key Considerations

- Use clear and concise legend items to improve diagram readability.
- Choose an appropriate legend position that doesn't interfere with the main Sankey diagram.
- Customize legend appearance to match your application's design theme.
- Use the `EnableHighlight` property to enhance user interaction.
- Consider using `IsInversed` or `Reverse` properties to optimize legend item ordering for better comprehension.

## Legend Interaction

When `EnableHighlight` is set to true, hovering over a legend item will highlight the corresponding elements in the Sankey diagram. This feature helps users quickly identify specific data flows or node categories.

By effectively configuring and customizing legends in the Blazor Sankey diagram, you can create more informative and user-friendly diagrams. Legends play a crucial role in helping users interpret complex Sankey diagrams, especially when dealing with multiple categories or data flows.

## See also

* [Nodes](./nodes)
* [Links](./links)
* [Labels](./labels)