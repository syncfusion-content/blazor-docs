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
<SfSankey Width="600px" Height="400px" Nodes="@Nodes" Links="@Links" Title="Device Usage" SubTitle="-2023">
    <SankeyNodeSettings Width="30" Alignment="SankeyNodeAlign.Left" Offset="10" Padding="10"></SankeyNodeSettings>
    <SankeyLinkSettings Color="blue" ColorType="SankeyColorType.Source" HighlightOpacity="1" InactiveOpacity="0.3" Opacity="0.7"></SankeyLinkSettings>
    <SankeyLabelSettings Visible="true" FontSize="12" Color="black" FontFamily="Arial" FontWeight="400" Padding="8"></SankeyLabelSettings>
</SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new List<SankeyDataNode>();
    public List<SankeyDataLink> Links = new List<SankeyDataLink>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Nodes = new List<SankeyDataNode>()
        {
            new SankeyDataNode() { Id = "Female", Label = new SankeyDataLabel() { Text = "Female (58%)" } },
            new SankeyDataNode() { Id = "Male", Label = new SankeyDataLabel() { Text = "Male (42%)" } },
            new SankeyDataNode() { Id = "Tablet", Label = new SankeyDataLabel() { Text = "Tablet (12%)" } },
            new SankeyDataNode() { Id = "Mobile", Label = new SankeyDataLabel() { Text = "Mobile (40%)" } },
            new SankeyDataNode() { Id = "Desktop", Label = new SankeyDataLabel() { Text = "Desktop (48%)" } },
            new SankeyDataNode() { Id = "< 18", Label = new SankeyDataLabel() { Text = "< 18 years (8%)" } },
            new SankeyDataNode() { Id = "18-26", Label = new SankeyDataLabel() { Text = "18-26 years (35%)" } },
            new SankeyDataNode() { Id = "27-40", Label = new SankeyDataLabel() { Text = "27-40 years (38%)" } },
            new SankeyDataNode() { Id = "> 40", Label = new SankeyDataLabel() { Text = "> 40 years (19%)" } }
        };
        Links = new List<SankeyDataLink>()
        {
            new SankeyDataLink() { SourceId = "Female", TargetId = "Tablet", Value = 12 },
            new SankeyDataLink() { SourceId = "Female", TargetId = "Mobile", Value = 14 },
            new SankeyDataLink() { SourceId = "Female", TargetId = "Desktop", Value = 32 },
            new SankeyDataLink() { SourceId = "Male", TargetId = "Mobile", Value = 26 },
            new SankeyDataLink() { SourceId = "Male", TargetId = "Desktop", Value = 16 },
            new SankeyDataLink() { SourceId = "Tablet", TargetId = "< 18", Value = 4 },
            new SankeyDataLink() { SourceId = "Tablet", TargetId = "> 40", Value = 8 },
            new SankeyDataLink() { SourceId = "Mobile", TargetId = "< 18", Value = 4 },
            new SankeyDataLink() { SourceId = "Mobile", TargetId = "18-26", Value = 24 },
            new SankeyDataLink() { SourceId = "Mobile", TargetId = "27-40", Value = 10 },
            new SankeyDataLink() { SourceId = "Mobile", TargetId = "> 40", Value = 2 },
            new SankeyDataLink() { SourceId = "Desktop", TargetId = "18-26", Value = 11 },
            new SankeyDataLink() { SourceId = "Desktop", TargetId = "27-40", Value = 28 },
            new SankeyDataLink() { SourceId = "Desktop", TargetId = "> 40", Value = 9 }
        };
    }
}
```

In this example, we define multiple nodes representing different categories such as gender, device types, and age groups.

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

## Advanced Configuration

The example demonstrates a complex Sankey diagram with multiple levels:

1. Gender (Female, Male)
2. Device Types (Tablet, Mobile, Desktop)
3. Age Groups (< 18, 18-26, 27-40, > 40)

This multi-level configuration allows for a detailed representation of data flow, showing how different user groups interact with various device types across age ranges.

## Key Considerations

- Use meaningful IDs and labels for nodes to improve diagram readability.
- Adjust node width, padding, and alignment to create clear and visually appealing Sankey diagrams.
- Consider the relationships between nodes when defining links to accurately represent data flow.
- Utilize the `SankeyLinkSettings` and `SankeyLabelSettings` to further customize the appearance of links and labels in the diagram.

By mastering node configuration in the Blazor Sankey component, you can create rich, informative flow diagrams that effectively communicate complex processes or relationships in your data. The example provided demonstrates how to create a comprehensive visualization of device usage patterns across different demographic groups.