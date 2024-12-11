---
layout: post
title: Events for Blazor Sankey Component | Syncfusion
description: Understand the events supported by the Blazor Sankey component and how to use them.
platform: Blazor
control: Sankey
documentation: ug
---

# Events in Blazor Sankey Component

## Overview

The Syncfusion Blazor Sankey Chart component provides a rich set of events that allow you to respond to various user interactions and chart lifecycle moments. These events enable you to create dynamic and interactive Sankey diagrams, enhancing the user experience of your Blazor applications.

## Available Events

The Sankey Chart component offers the following events:

1. LegendItemRendering
2. LegendItemHover
3. LabelRendering
4. NodeRendering
5. LinkRendering
6. SizeChanged
7. TooltipRendering
8. PrintCompleted
9. ExportCompleted
10. Created
11. NodeClick
12. NodeEnter
13. NodeLeave
14. LinkClick
15. LinkEnter
16. LinkLeave

## Basic Event Usage

Here's an example demonstrating how to use some of the most common events in the Sankey component:

```razor
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
        // Initialize Nodes and Links (omitted for brevity)
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
```

## Key Points

- Events are bound to the Sankey component using attributes that match the event names.
- Each event provides specific event arguments that contain relevant information about the event.
- You can use these events to customize the appearance, behavior, or to perform additional actions based on user interactions.

## Customizing with Events

### LegendItemRendering

Use this event to customize the appearance of legend items before they are rendered.

### NodeClick

Respond to user clicks on nodes, allowing for interactive features or data updates.

### LinkRendering

Customize the appearance of links based on their properties or other conditions.

### TooltipRendering

Modify the content and appearance of tooltips for both nodes and links.

## Advanced Event Usage

You can combine multiple events to create more complex interactions. Here's an example that uses multiple events:

```razor
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
    private string _eventInfo = "Interact with the chart to see event information here.";

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
        _eventInfo = $"Chart resized. New size: {args.CurrentSize.Width}x{args.CurrentSize.Height}";
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

    // Nodes and Links initialization (omitted for brevity)
}
```

## Key Considerations

- Use events to create interactive and dynamic Sankey diagrams.
- Combine multiple events to create complex user experiences.
- Update the UI (using `StateHasChanged()`) when modifying component state in event handlers.
- Consider performance implications when handling frequent events like hover or mouse move.
- Use the `Created` event for any one-time setup operations after the Sankey chart is fully rendered.

By effectively utilizing the events provided by the Blazor Sankey component, you can create rich, interactive visualizations that respond to user actions and provide enhanced functionality in your Blazor applications.