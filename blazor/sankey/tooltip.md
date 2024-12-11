---
layout: post
title: Tooltips for Blazor Sankey Component | Syncfusion
description: Learn how to configure and customize tooltips in the Blazor Sankey component to enhance data visualization and user interaction.
platform: Blazor
control: Sankey
documentation: ug
---

# Tooltips in Blazor Sankey Component

## Overview

Tooltips in a Sankey diagram provide additional information about nodes and links when users hover over them. This topic covers how to configure and customize tooltips in the Blazor Sankey component.

## Basic Tooltip Configuration

Tooltips can be added to your Sankey diagram using the `SankeyTooltipSettings`. Here's an example of how to configure tooltips in the Sankey component:

```razor
<SfSankey Width="600px" Height="400px" Nodes="@Nodes" Links="@Links" Title="Device Usage" SubTitle="-2023">
    <SankeyTooltipSettings 
        Enable="true" 
        Fill="blue" 
        Opacity="0.7">
    </SankeyTooltipSettings>
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

- `Enable`: Determines whether tooltips are displayed (default is true).
- `Fill`: Sets the background color of the tooltip.
- `Opacity`: Sets the opacity of the tooltip (0 to 1, default is 0.75).
- `NodeFormat`: Specifies the format for node tooltips.
- `LinkFormat`: Specifies the format for link tooltips.
- `EnableAnimation`: Enables or disables tooltip animation (default is true).
- `Duration`: Sets the duration of the tooltip animation in milliseconds (default is 300).
- `FadeOutDuration`: Sets the fade-out duration for tooltips in milliseconds (default is 1000).

## Customizing Tooltip Appearance

You can customize the appearance of tooltips using various properties:

```razor
<SankeyTooltipSettings 
    Enable="true" 
    Fill="#f0f0f0" 
    Opacity="0.9"
    NodeFormat="Node: $name, Value: $value"
    LinkFormat="From $start.name to $target.name: $value"
    EnableAnimation="true"
    Duration="500"
    FadeOutDuration="1500">
    <SankeyTooltipTextStyle 
        Color="#333333" 
        FontSize="12px" 
        FontFamily="Arial">
    </SankeyTooltipTextStyle>
</SankeyTooltipSettings>
```

## Advanced Tooltip Configuration

### Custom Tooltip Templates

You can create custom tooltip templates for both nodes and links using the `SankeyNodeTemplate` and `SankeyLinkTemplate` properties:

```razor
<SankeyTooltipSettings Enable="true">
    <SankeyNodeTemplate>
        @{
            var data = context as SankeyNodeContext;
            if (data != null)
            {
                <div style="background-color:blue; color:white; padding:5px; border-radius:5px;">
                    <p>@data.Node.Label.Text</p>
                </div>
            }
        }
    </SankeyNodeTemplate>
    <SankeyLinkTemplate>
        @{
            var data = context as SankeyLinkContext;
            if (data != null)
            {
                <div style="background-color:blue; color:white; padding:5px; border-radius:5px;">
                    <p>Value: @data.Link.Value</p>
                </div>
            }
        }
    </SankeyLinkTemplate>
</SankeyTooltipSettings>
```

These templates allow you to completely customize the content and appearance of tooltips for nodes and links.

## Key Considerations

- Use clear and concise tooltip content to improve readability.
- Choose appropriate colors and opacity levels that contrast well with your Sankey diagram.
- Consider using custom templates for more complex tooltip designs or to include additional data.
- Adjust animation settings to ensure smooth transitions without being distracting.
- Use the `NodeFormat` and `LinkFormat` properties for quick customization of tooltip content without needing to create full templates.

## Tooltip Interaction

Tooltips appear when users hover over nodes or links in the Sankey diagram. The `EnableAnimation` property, when set to true, allows for smooth transitions as the tooltip moves between different elements.

## Performance Considerations

While tooltips can greatly enhance the user experience, be mindful of performance, especially when dealing with large Sankey diagrams. Complex custom templates or excessive animations might impact performance on slower devices.

By effectively configuring and customizing tooltips in the Blazor Sankey component, you can create more informative and interactive diagrams. Tooltips play a crucial role in helping users understand detailed information about specific nodes and links without cluttering the main diagram view.