---
layout: post
title: Links for Blazor Sankey Component | Syncfusion
description: Learn how to define and configure links in the Blazor Sankey component to represent connections between nodes.
platform: Blazor
control: Sankey
documentation: ug
---

# Links in Blazor Sankey Component

## Overview

Links in a Sankey diagram represent the connections and flow between nodes. They visually depict the relationships and quantities transferred between different entities or stages in a process. This topic covers how to define, customize, and work with links in the Blazor Sankey component.

## Basic Link Configuration

To add links to your Sankey diagram, you need to define a collection of `SankeyDataLink` objects. Each link requires a source node, a target node, and a value representing the flow quantity.

Here's an example of how to configure links in the Sankey component:

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

In this example, we define multiple links connecting nodes across different categories such as gender, device types, and age groups.

## Key Points

- Each link must have a `SourceId` and `TargetId` corresponding to existing node IDs.
- The `Value` property determines the thickness of the link and represents the quantity flowing between nodes.
- Links are automatically rendered based on the node positions and specified values.

## Customizing Link Appearance

You can customize the appearance of links using the `SankeyLinkSettings`:

```razor
<SankeyLinkSettings Color="blue" ColorType="SankeyColorType.Source" HighlightOpacity="1" InactiveOpacity="0.3" Opacity="0.7"></SankeyLinkSettings>
```

## Link Properties

- `Color`: Sets the color of the links. Can be specified in hex or rgba format.
- `ColorType`: Determines how the color is applied to the links. Options are:
  - `SankeyColorType.Source`: Color based on the source node.
  - `SankeyColorType.Target`: Color based on the target node.
  - `SankeyColorType.Blend`: A blend of source and target node colors.
- `Opacity`: Sets the opacity of the links (0.0 to 1.0, default is 0.8).
- `HighlightOpacity`: Sets the opacity of links when hovered over (0.0 to 1.0, default is 0.8).
- `InactiveOpacity`: Sets the opacity of inactive links (0.0 to 1.0, default is 0.2).

## Advanced Link Configuration

The example demonstrates a complex Sankey diagram with multiple levels of links:

1. From gender (Female, Male) to device types (Tablet, Mobile, Desktop)
2. From device types to age groups (< 18, 18-26, 27-40, > 40)

This multi-level configuration allows for a detailed representation of data flow, showing how different user groups interact with various device types across age ranges.

## Key Considerations

- Use meaningful values for links to accurately represent the flow between nodes.
- Adjust link colors and opacities to enhance visibility and distinguish between different types of flows.
- Consider using the `ColorType` property to create visually appealing color schemes that help users understand the data flow direction.
- Utilize the `HighlightOpacity` and `InactiveOpacity` properties to improve user interaction and focus on specific data flows.

By effectively configuring and customizing links in the Blazor Sankey component, you can create informative and visually appealing flow diagrams that clearly communicate the relationships and quantities in your data. The example provided demonstrates how to create a comprehensive visualization of device usage patterns across different demographic groups, showcasing the power and flexibility of the Sankey diagram.