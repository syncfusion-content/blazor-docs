---
layout: post
title: Labels for Blazor Sankey Component | Syncfusion
description: Learn how to configure and customize labels in the Blazor Sankey component to enhance data visualization.
platform: Blazor
control: Sankey
documentation: ug
---

# Labels in Blazor Sankey Component

## Overview

Labels in a Sankey diagram provide textual information for nodes, enhancing the readability and understanding of the diagram. This topic covers how to configure and customize labels in the Blazor Sankey component.

## Basic Label Configuration

Labels are defined as part of the node configuration and can be further customized using the `SankeyLabelSettings`. Here's an example of how to configure labels in the Sankey component:

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
        // ... Links initialization ...
    }
}
```

In this example, we define labels for each node and use `SankeyLabelSettings` to customize their appearance.

## Key Points

- Labels are defined in the `SankeyDataNode` objects using the `Label` property.
- The `SankeyLabelSettings` component allows global customization of label appearance.
- Labels can display additional information like percentages or values alongside node names.

## Customizing Label Appearance

You can customize the appearance of labels using various properties in `SankeyLabelSettings`:

```razor
<SankeyLabelSettings 
    Visible="true" 
    FontSize="12" 
    Color="black" 
    FontFamily="Arial" 
    FontWeight="400" 
    Padding="8">
</SankeyLabelSettings>
```

## Label Properties

- `Visible`: Determines whether labels are displayed (default is true).
- `FontSize`: Sets the font size of the label text.
- `Color`: Defines the color of the label text.
- `FontFamily`: Specifies the font family for the label text.
- `FontWeight`: Sets the font weight (e.g., "400" for normal, "700" for bold).
- `Padding`: Sets the padding around the label text (default is 10).

Additional properties inherited from `SankeyBaseTextStyle`:
- `FontStyle`: Sets the font style (e.g., "italic").

## Advanced Label Configuration

The example demonstrates labels with additional information:

1. Gender labels include percentages: "Female (58%)", "Male (42%)"
2. Device type labels show usage percentages: "Tablet (12%)", "Mobile (40%)", "Desktop (48%)"
3. Age group labels display ranges and percentages: "< 18 years (8%)", "18-26 years (35%)", etc.

This configuration provides a rich set of information directly in the labels, enhancing the diagram's readability.

## Key Considerations

- Use clear and concise label text to avoid cluttering the diagram.
- Consider using different font sizes or weights to establish a visual hierarchy if needed.
- Ensure sufficient contrast between label color and node color for readability.
- Adjust padding to fine-tune label positioning within nodes.
- Use the `Visible` property to hide labels if the diagram becomes too crowded.

By effectively configuring and customizing labels in the Blazor Sankey component, you can create informative and easy-to-understand flow diagrams. Labels play a crucial role in conveying information about each node, making the overall data visualization more meaningful and accessible to users.