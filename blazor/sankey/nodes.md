---
layout: post
title: Nodes for Blazor Sankey Diagram | Syncfusion
description: Explore how to define and configure nodes in the Blazor Sankey Diagram to create meaningful and visually appealing flow diagrams.
platform: Blazor
control: Sankey
documentation: ug
---

# Nodes in Blazor Sankey Diagram

## Overview

Nodes are fundamental elements in a Sankey Diagram, representing entities or stages in a process flow. This topic covers how to define, customize, and work with nodes in the Blazor Sankey Diagram.

## Basic Node Configuration

To add nodes to your Sankey Diagram, you need to define a collection of `SankeyDataNode` objects. Each node requires a unique ID and can have additional properties for customization.

- Each node must have a unique `Id` property.
- The `Label` property is of type `SankeyDataLabel` and defines the text displayed for the node.
- Nodes are automatically positioned based on their connections defined in the `Links` collection.

Here's an example of how to configure nodes in the Sankey Diagram:

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Sankey;

<SfSankey BackgroundColor="@_backgroundColor" Nodes=@Nodes Links=@Links>
    <SankeyNodeSettings Color="#1c3f60" Width="10" Padding="20"></SankeyNodeSettings>
    <SankeyLinkSettings Color="#afc1d0" Opacity="0.2"></SankeyLinkSettings>
    <SankeyLabelSettings Color="#FFFFFF" FontWeight="400" ></SankeyLabelSettings>
    <SankeyLegendSettings Visible="false"></SankeyLegendSettings>
</SfSankey>
@code {
    string _backgroundColor = "#0b1320";
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


In this example, we define multiple nodes representing different categories such as source, energy types, and usage groups.

![Blazor Sankey Node Customization](images/nodes/sankey-node-basic.png)

## Customizing Node Appearance

The nodes in a Sankey Diagram represent the primary entities or data points, and their appearance can be tailored to enhance the clarity and style of your visualization. Using the `SankeyNodeSettings` in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Sankey Diagram, you can configure properties like width, alignment, padding, and more to make the diagram visually distinct and avoid overlap between elements.

- **`Width`**: Specifies the width of the nodes. The default value is `20`, but it can be increased or decreased to adjust the visual prominence of nodes in the diagram.
- **`Alignment`**: Determines the alignment of nodes. Options include:
  - **Left**: Aligns nodes to the left edge of the layout.
  - **Top**: Aligns nodes to the top edge of the layout.
  - **Stretch**: Stretches the nodes across the layout to fill available space.
- **`Offset`**: Sets an additional offset for nodes based on their alignment, allowing fine-grained control over node placement.
- **`Padding`**: Defines the spacing around nodes to prevent overlapping with other elements.
- **`Color`**: Lets you customize the fill color of the nodes (not shown in the example but configurable).
- **`Opacity`**: Adjusts the transparency level of the nodes (not shown in the example but configurable).

Below is an example demonstrating the customization of node appearance:

{% tabs %}
{% highlight razor %}

<SankeyNodeSettings 
    Width="30" 
    Alignment="SankeyNodeAlign.Left" 
    Offset="10" 
    Padding="10">
</SankeyNodeSettings>
{% endhighlight %}
{% endtabs %}

## Key Considerations

- Use meaningful IDs and labels for nodes to improve diagram readability.
- Adjust node width, padding, and alignment to create clear and visually appealing Sankey diagrams.
- Consider the relationships between nodes when defining links to accurately represent data flow.
- Utilize the `SankeyLinkSettings` and `SankeyLabelSettings` to further customize the appearance of links and labels in the diagram.

By mastering node configuration in the Blazor Sankey Diagram, you can create rich, informative flow diagrams that effectively communicate complex processes or relationships in your data. The example provided demonstrates how to create a comprehensive visualization of device usage patterns across different demographic groups.

## See also

* [Links](./links)
* [Labels](./labels)
* [Legend](./legend)
* [tooltip](./tooltip)