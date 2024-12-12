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
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Sankey;

<SfSankey BackgroundColor="@_backgroundColor" Nodes=@Nodes Links=@Links>
    <SankeyNodeSettings Color="#1c3f60" ></SankeyNodeSettings>
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

In this example, we define multiple links connecting nodes across different categories such as source, energy types, and usage groups.

![Blazor Sankey Link Customization](images/links/sankey-basic-link.png)

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

## Key Considerations

- Use meaningful values for links to accurately represent the flow between nodes.
- Adjust link colors and opacities to enhance visibility and distinguish between different types of flows.
- Consider using the `ColorType` property to create visually appealing color schemes that help users understand the data flow direction.
- Utilize the `HighlightOpacity` and `InactiveOpacity` properties to improve user interaction and focus on specific data flows.

By effectively configuring and customizing links in the Blazor Sankey component, you can create informative and visually appealing flow diagrams that clearly communicate the relationships and quantities in your data. The example provided demonstrates how to create a comprehensive visualization of device usage patterns across different demographic groups, showcasing the power and flexibility of the Sankey diagram.

## See also

* [Nodes](./nodes)
* [Labels](./labels)
* [Legend](./legend)
* [tooltip](./tooltip)