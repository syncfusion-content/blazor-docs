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

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Sankey;

<SfSankey Nodes=@Nodes Links=@Links>
    <SankeyNodeSettings Color="#1c3f60" ></SankeyNodeSettings>
    <SankeyLinkSettings Color="#afc1d0" ></SankeyLinkSettings>
    <SankeyLabelSettings Color="#1c3f60" FontWeight="600" FontSize="14px" FontStyle="italic"></SankeyLabelSettings>
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


In this example, we define labels for each node and use `SankeyLabelSettings` to customize their appearance.

![Blazor Sankey Labels](images/labels/sankey-labels.png)

## Key Points

- Labels are defined in the `SankeyDataNode` objects using the `Label` property.
- The `SankeyLabelSettings` component allows global customization of label appearance.
- Labels can display additional information like percentages or values alongside node names.

## Customizing Label Appearance

You can customize the appearance of labels using various properties in `SankeyLabelSettings`:

{% tabs %}
{% highlight razor %}

<SankeyLabelSettings 
    Visible="true" 
    FontSize="12" 
    Color="black" 
    FontFamily="Arial" 
    FontWeight="400" 
    Padding="8">
</SankeyLabelSettings>

{% endhighlight %}
{% endtabs %}


## Label Properties

- `Visible`: Determines whether labels are displayed (default is true).
- `FontSize`: Sets the font size of the label text.
- `Color`: Defines the color of the label text.
- `FontFamily`: Specifies the font family for the label text.
- `FontWeight`: Sets the font weight (e.g., "400" for normal, "700" for bold).
- `Padding`: Sets the padding around the label text (default is 10).

Additional properties inherited from `SankeyBaseTextStyle`:
- `FontStyle`: Sets the font style (e.g., "italic").

## Key Considerations

- Use clear and concise label text to avoid cluttering the diagram.
- Consider using different font sizes or weights to establish a visual hierarchy if needed.
- Ensure sufficient contrast between label color and node color for readability.
- Adjust padding to fine-tune label positioning within nodes.
- Use the `Visible` property to hide labels if the diagram becomes too crowded.

By effectively configuring and customizing labels in the Blazor Sankey component, you can create informative and easy-to-understand flow diagrams. Labels play a crucial role in conveying information about each node, making the overall data visualization more meaningful and accessible to users.

## See also

* [Nodes](./nodes)
* [Links](./links)
* [Legend](./legend)
* [tooltip](./tooltip)