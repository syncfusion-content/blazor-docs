---
layout: post
title: Events for Blazor Sankey Component | Syncfusion
description: Learn about the events supported by the Blazor Sankey component and how to use them for interactivity and customization.
platform: Blazor
control: Sankey
documentation: ug
---

# Events in Blazor Sankey Component

## Overview

The Syncfusion Blazor Sankey Chart component supports a comprehensive set of events, allowing developers to craft responsive and interactive features. These events are designed to handle user interactions and essential chart lifecycle phases, thereby enhancing the functionality and user experience of your Blazor applications.

## Available Events

The Sankey Chart component includes the following events:

1. **NodeRendering**: Customize nodes before they are drawn on the diagram, allowing for unique visual adjustments based on data or application state.

2. **LegendItemRendering**: This event provides an opportunity to adjust legend items before rendering, enabling enhancements like color changes or text modifications to suit application branding.

3. **LabelRendering**: Modify or format labels before they appear, ensuring they convey pertinent information clearly and comprehensively.

4. **LinkRendering**: Customize the visual aspects of links, such as color or thickness, based on their properties or specific conditions, enhancing the clarity and significance of relationships between nodes.

5. **LegendItemHover**: Respond to user hover actions over legend items, potentially triggering additional UI changes or data displays to improve interactivity.

6. **SizeChanged**: Detect changes to the chart's dimensions, and adapt the layout or other components accordingly to maintain a coherent and visually appealing interface.

7. **TooltipRendering**: Modify the content and style of tooltips for nodes and links to clearly communicate context-specific information and enrich user understanding.

8. **PrintCompleted**: Execute actions following the completion of a print operation, such as updating UI status indicators or logging the event for analytic purposes.

9. **ExportCompleted**: Similar to print operations, this event allows you to trigger follow-up processes when an export operation finishes, including notifications or data processing tasks.

10. **Created**: Run setup operations that should occur after the Sankey chart is fully initialized and rendered, ideal for initializing related components or logging creation events.

11. **NodeClick**: Perform actions driven by user clicks on nodes, which can include updating other UI elements, starting data transactions, or triggering analytics.

12. **NodeEnter**: React to the pointer entering a node region, potentially using it to highlight nodes or display informational overlays dynamically.

13. **NodeLeave**: When the pointer exits a node, utilize this event to execute cleanup operations like removing highlights or hiding additional information.

14. **LinkClick**: Handle user clicks on links, enabling features like detailed data viewing or reshaping interactions in connected components.

15. **LinkEnter**: Implement interactive behaviors when hovering over links, such as emphasizing connections or showing detailed link information.

16. **LinkLeave**: Cleanup actions can be attached to this event when the pointer moves off a link, such as resetting visual styles or removing interactive elements.
## Basic Event Usage

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

- Events are linked to the Sankey component via attributes that correspond with event names.
- Each event delivers distinct event arguments, offering detailed information relevant to the event.
- These events facilitate customizing appearance, enhancing behavior, and executing additional actions based on user interactions.

## Customizing with Events

### LegendItemRendering

This event allows you to adjust the appearance of legend items prior to rendering. You can tailor the visual style, such as colors and labels, to align with the application's design language or thematic consistency. Customization here can enhance visual coherence and aid user interpretation.

### NodeClick

Utilize this event to trigger actions in response to user interactions with nodes, offering opportunities to display detailed information, update related UI components, or log interactions for analytic purposes. This event drives engagement by making visual data exploration more interactive and informative.

### LinkRendering

Adjust the appearance of links for a more customized visualization, based on dynamic conditions such as link weight or status. By modifying visual properties like color or thickness, you can convey additional information through the visual representation of links, aiding user comprehension of complex networks.

### TooltipRendering

Modify both the content and appearance of tooltips to deliver tailored real-time information relevant to the user's context. Tooltips can be adapted to reflect current node or link data, thereby enhancing user interaction and understanding through efficient data presentation.

## Advanced Event Usage

For more complex interactions, multiple events can be combined effectively. Here's an example utilizing several events:

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

    // Nodes and Links initialization (initialization code is omitted for brevity)
}
{% endhighlight %}
{% endtabs %}

## Key Considerations

- Employ events to construct interactive and dynamic Sankey diagrams.
- Leverage multiple events to develop complex user experiences.
- Refresh the UI using `StateHasChanged()` when altering component state within event handlers.
- Be mindful of performance trade-offs when dealing with frequent events, such as hover or mouse movement.
- Utilize the `Created` event for any initial setup tasks post full rendering of the Sankey chart.

By leveraging the robust set of events provided by the Blazor Sankey component, developers can produce rich and interactive visualizations that are both responsive to user actions and enhanced in functionality within Blazor applications.

## See also

* [Nodes](./nodes)
* [Links](./links)
* [Labels](./labels)