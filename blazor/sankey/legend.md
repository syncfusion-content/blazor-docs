---
layout: post
title: Legends for Blazor Sankey Component | Syncfusion
description: Learn how to configure and customize legends in the Blazor Sankey component to enhance data interpretation and user interaction.
platform: Blazor
control: Sankey
documentation: ug
---

# Legends in Blazor Sankey Component

## Overview

Legends in a Sankey diagram provide a visual key to interpret the different nodes or links in the diagram. This topic covers how to configure and customize legends in the Blazor Sankey component.

## Basic Legend Configuration

Legends can be added to your Sankey diagram using the `SankeyLegendSettings`. Here's an example of how to configure legends in the Sankey component:

```razor
<SfSankey Width="600px" Height="400px" Nodes="@Nodes" Links="@Links" Title="Device Usage" SubTitle="-2023">
    <SankeyLegendSettings 
        Visible="true" 
        Position="SankeyLegendPosition.Bottom" 
        Height="10" 
        Width="10">
        <SankeyLegendMargin Left="10" Right="10" Top="10" Bottom="10"></SankeyLegendMargin>
        <SankeyLegendTextStyle 
            FontSize="10px" 
            FontFamily="Roboto" 
            FontWeight="600" 
            Color="Black" 
            FontStyle="italic">
        </SankeyLegendTextStyle>
        <SankeyLegendTitleStyle 
            FontSize="14px" 
            FontFamily="Roboto" 
            FontWeight="800" 
            Color="Black" 
            FontStyle="italic">
        </SankeyLegendTitleStyle>
    </SankeyLegendSettings>
</SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new List<SankeyDataNode>();
    public List<SankeyDataLink> Links = new List<SankeyDataLink>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        // Initialize Nodes and Links here
    }
}
```

## Key Properties

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

## Customizing Legend Appearance

You can customize the appearance of legends using various properties:

```razor
<SankeyLegendSettings 
    Visible="true" 
    Position="SankeyLegendPosition.Right"
    Width="120"
    Background="#f0f0f0"
    Opacity="0.8"
    BorderColor="#cccccc"
    BorderWidth="1"
    ShapeWidth="15"
    ShapeHeight="15"
    ShapePadding="10"
    ItemPadding="15"
    Padding="12"
    EnableHighlight="true"
    Title="Device Types"
    IsInversed="false"
    Reverse="false">
    <SankeyLegendTextStyle 
        FontSize="12px" 
        FontFamily="Arial" 
        FontWeight="normal" 
        Color="#333333">
    </SankeyLegendTextStyle>
    <SankeyLegendTitleStyle 
        FontSize="14px" 
        FontFamily="Arial" 
        FontWeight="bold" 
        Color="#000000">
    </SankeyLegendTitleStyle>
</SankeyLegendSettings>
```

## Advanced Legend Configuration

### Legend Margins

You can set custom margins for the legend using the `SankeyLegendMargin` class:

```razor
<SankeyLegendSettings>
    <SankeyLegendMargin Left="20" Right="20" Top="10" Bottom="10"></SankeyLegendMargin>
</SankeyLegendSettings>
```

### Legend Text and Title Styles

Customize the text style of legend items and the legend title:

```razor
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
```

## Key Considerations

- Use clear and concise legend items to improve diagram readability.
- Choose an appropriate legend position that doesn't interfere with the main Sankey diagram.
- Customize legend appearance to match your application's design theme.
- Use the `EnableHighlight` property to enhance user interaction.
- Consider using `IsInversed` or `Reverse` properties to optimize legend item ordering for better comprehension.

## Legend Interaction

When `EnableHighlight` is set to true, hovering over a legend item will highlight the corresponding elements in the Sankey diagram. This feature helps users quickly identify specific data flows or node categories.

By effectively configuring and customizing legends in the Blazor Sankey component, you can create more informative and user-friendly diagrams. Legends play a crucial role in helping users interpret complex Sankey diagrams, especially when dealing with multiple categories or data flows.