---
layout: post
title: Events for Blazor Sankey Component | Syncfusion
description: Learn about the events supported by the Syncfusion Blazor Sankey component and how to use them for interactivity and customization.
platform: Blazor
control: Sankey
documentation: ug
---

# Events in Blazor Sankey Diagram

## Overview

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Sankey Diagram component provides a comprehensive set of events to handle user interactions and key lifecycle moments. These events enable responsive behaviors, targeted customization, and coordinated updates across application features.

## Events

The Sankey Diagram component includes the following events:

1. **NodeRendering**: Fires before nodes are drawn, enabling dynamic customization of node appearance based on data or state. Apply visual adjustments to emphasize categories or thresholds.

2. **LegendItemRendering**: Fires before legend items render, allowing changes to text and colors for branding and readability. Align legend content with application themes.

3. **LabelRendering**: Triggers before labels appear, supporting modification of label text or formatting. Ensure labels convey essential information clearly.

4. **LinkRendering**: Fires during link rendering, allowing conditional styling based on link properties. Modify colors or stroke styles to highlight relationships.

5. **LegendItemHover**: Occurs when hovering over a legend item, enabling contextual UI responses or highlighting. Use to reinforce legend-to-visual mapping.

6. **SizeChanged**: Fires when the component size changes, enabling layout recalculations or responsive adjustments.

7. **TooltipRendering**: Triggers before tooltips render for nodes and links, allowing customization of content and style. Event arguments may reference either a node or a link.

8. **PrintCompleted**: Fires after printing completes, allowing status updates, logging, or follow-up actions.

9. **ExportCompleted**: Occurs after export completes, useful for notifications, analytics, or post-processing.

10. **Created**: Fires after the Sankey Diagram is initialized and rendered, suitable for one-time setup of related components.

11. **NodeClick**: Occurs on node click, enabling UI updates, navigation, or analytics triggers.

12. **NodeEnter**: Triggers when the pointer enters a node region, supporting highlight or context display behaviors.

13. **NodeLeave**: Occurs when the pointer leaves a node, enabling cleanup such as removing highlights or overlays.

14. **LinkClick**: Fires on link click, enabling drill-downs, detail views, or coordinated interactions.

15. **LinkEnter**: Triggers on link hover, supporting emphasis and display of additional link details.

16. **LinkLeave**: Occurs when the pointer exits a link, enabling visual reset or cleanup.

Below is an example demonstrating how to implement some of the key events in the Sankey component:

{% tabs %}
{% highlight razor %}

<SfSankey Width="600px" Height="400px"
           Nodes="@Nodes"
           Links="@Links"
           LegendItemRendering="OnLegendItemRendering"
           NodeClick="OnNodeClick"
           LinkRendering="OnLinkRendering"
           TooltipRendering="OnTooltipRendering">
</SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new List<SankeyDataNode>();
    public List<SankeyDataLink> Links = new List<SankeyDataLink>();

    protected override void OnInitialized()
    {
        // Initialize Nodes and Links (initialization code is omitted for brevity)
    }

    private void OnLegendItemRendering(SankeyLegendRenderEventArgs args)
    {
        args.Text = $"Custom: {args.Text}";
        args.Fill = "#FF69B4"; // Change color to pink
    }

    private void OnNodeClick(SankeyNodeEventArgs args)
    {
        Console.WriteLine($"Node clicked: {args.Node.Id}");
    }

    private void OnLinkRendering(SankeyLinkRenderEventArgs args)
    {
        if (args.Link.Value > 40)
        {
            args.Fill = "green";
        }
        else if (args.Link.Value > 20)
        {
            args.Fill = "orange";
        }
        else
        {
            args.Fill = "red";
        }
    }

    private void OnTooltipRendering(SankeyTooltipRenderEventArgs args)
    {
        if (args.Node != null)
        {
            args.Text = $"Node: {args.Node.Id} (Custom)";
        }
        else if (args.Link != null)
        {
            var value = args.Link.Value;
            string strength = value > 40 ? "Strong" : (value > 20 ? "Medium" : "Weak");
            args.Text = $"Link: {args.Link.SourceId} to {args.Link.TargetId}, Strength: {strength}";
        }
    }
}

{% endhighlight %}
{% endtabs %}

## Key Points

- Events are attached to the Sankey component using attributes that map to event names.
- Each event provides specific event arguments with details relevant to the trigger context.
- Events enable appearance customization, behavioral enhancements, and coordinated actions based on interactions.

## Customizing with Events

### LegendItemRendering

Adjust legend item appearance prior to rendering. Modify colors and labels to match design guidelines and improve readability.

### NodeClick

Trigger application logic on node interaction, such as updating related UI, revealing details, or recording telemetry.

### LinkRendering

Customize link visuals based on data-driven conditions. Use color or stroke changes to convey weight, status, or categories.

### TooltipRendering

Tailor tooltip content and styling for nodes and links to deliver concise, context-specific information at hover or focus.

## Advanced Event Usage

For complex interactions, combine multiple events effectively. Here's an example utilizing several events:

{% tabs %}
{% highlight razor %}

<SfSankey Width="600px" Height="400px"
           Nodes="@Nodes"
           Links="@Links"
           NodeClick="OnNodeClick"
           LinkEnter="OnLinkEnter"
           LinkLeave="OnLinkLeave"
           SizeChanged="OnSizeChanged"
           PrintCompleted="OnPrintCompleted"
           ExportCompleted="OnExportCompleted">
</SfSankey>

<div>
    <h3>Event Info:</h3>
    <p>@_eventInfo</p>
</div>

@code {
    private string _eventInfo = "Interact with the diagram to see event information here.";

    // Event handlers
    private void OnNodeClick(SankeyNodeEventArgs args)
    {
        _eventInfo = $"Node clicked: {args.Node.Id}";
        StateHasChanged();
    }

    private void OnLinkEnter(SankeyLinkEventArgs args)
    {
        _eventInfo = $"Mouse entered link: {args.Link.SourceId} -> {args.Link.TargetId}, Value: {args.Link.Value}";
        StateHasChanged();
    }

    private void OnLinkLeave(SankeyLinkEventArgs args)
    {
        _eventInfo = $"Mouse left link: {args.Link.SourceId} -> {args.Link.TargetId}";
        StateHasChanged();
    }

    private void OnSizeChanged(SankeySizeChangedEventArgs args)
    {
        _eventInfo = $"Diagram resized. New size: {args.CurrentSize.Width}x{args.CurrentSize.Height}";
        StateHasChanged();
    }

    private void OnPrintCompleted()
    {
        _eventInfo = "Print operation completed.";
        StateHasChanged();
    }

    private void OnExportCompleted(SankeyExportedEventArgs args)
    {
        _eventInfo = $"Export operation completed. IsBase64: {args.Base64} or DataUrl: {args.DataUrl}";
        StateHasChanged();
    }

    // Nodes and Links initialization (initialization code is omitted for brevity)
}

{% endhighlight %}
{% endtabs %}

## Key Considerations

- Use events to build interactive and responsive Sankey diagrams.
- Combine events to orchestrate complex user experiences.
- Invoke `StateHasChanged()` when updating component state in event handlers.
- Consider performance for high-frequency events such as hover.
- Use the `Created` event for initial setup tasks after the diagram is fully rendered.

By leveraging the events provided by the Blazor Sankey component, applications can deliver interactive visualizations that respond to input and support advanced customization.

## See also

* [Nodes](./nodes)
* [Links](./links)
* [Labels](./labels)
