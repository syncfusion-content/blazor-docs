---
layout: post
title: Nodes for Blazor Sankey Component | Syncfusion
description: Explore how to define and configure nodes in the Blazor Sankey component to create meaningful and visually appealing flow diagrams.
platform: Blazor
control: Sankey
documentation: ug
---

# Nodes in Blazor Sankey Component

## Overview

Nodes are fundamental elements in a Sankey diagram, representing entities or stages in a process flow. This topic covers how to define, customize, and work with nodes in the Blazor Sankey component.

## Basic Node Configuration

To add nodes to your Sankey diagram, you need to define a collection of `SankeyDataNode` objects. Each node requires a unique ID and can have additional properties for customization.

Here's an example of how to configure nodes in the Sankey component:

```razor
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

```

In this example, we define multiple nodes representing different categories such as source, energy types, and usage groups.

![Blazor Sankey Node Customization](images/nodes/sankey-node-basic.png)

## Key Points

- Each node must have a unique `Id` property.
- The `Label` property is of type `SankeyDataLabel` and defines the text displayed for the node.
- Nodes are automatically positioned based on their connections defined in the `Links` collection.

## Customizing Node Appearance

You can customize the appearance of nodes using the `SankeyNodeSettings`:

```razor
<SankeyNodeSettings Width="30" Alignment="SankeyNodeAlign.Left" Offset="10" Padding="10"></SankeyNodeSettings>
```

## Node Properties

- `Width`: Sets the width of the nodes (default is 20).
- `Alignment`: Determines the alignment of nodes (Left, Top, or Stretch).
- `Offset`: Specifies the offset of nodes based on the alignment.
- `Padding`: Sets the padding around nodes to avoid overlapping.
- `Color`: Defines the color of the nodes (not shown in the example, but available).
- `Opacity`: Sets the opacity level of the nodes (not shown in the example, but available).

## Key Considerations

- Use meaningful IDs and labels for nodes to improve diagram readability.
- Adjust node width, padding, and alignment to create clear and visually appealing Sankey diagrams.
- Consider the relationships between nodes when defining links to accurately represent data flow.
- Utilize the `SankeyLinkSettings` and `SankeyLabelSettings` to further customize the appearance of links and labels in the diagram.

By mastering node configuration in the Blazor Sankey component, you can create rich, informative flow diagrams that effectively communicate complex processes or relationships in your data. The example provided demonstrates how to create a comprehensive visualization of device usage patterns across different demographic groups.

## See also

* [Links](./links)
* [Labels](./labels)
* [Legend](./legend)
* [tooltip](./tooltip)