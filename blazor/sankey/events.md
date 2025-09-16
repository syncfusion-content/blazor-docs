---
layout: post
title: Events for Blazor Sankey Component | Syncfusion
description: Learn about the events supported by the Blazor Sankey component and how to use them for interactivity and customization.
platform: Blazor
control: Sankey
documentation: ug
---

# Events in Blazor Sankey Diagram

## Overview

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Sankey Diagram component supports a comprehensive set of events, allowing developers to craft responsive and interactive features. These events are designed to handle user interactions and essential diagram lifecycle phases, thereby enhancing the functionality and user experience of your Blazor applications.

## Events

The Sankey Diagram component includes the following events:

1. **NodeRendering**: This event is fired before nodes are drawn on the diagram, allowing for dynamic customization of node appearance based on data or application state. Use this to apply unique visual adjustments and enhance node representation.

2. **LegendItemRendering**: Fired before legend items are rendered, this event enables modifications such as changing colors or altering text to align with branding needs. It helps ensure the legend matches the application's theme and improves readability.

3. **LabelRendering**: Triggered before labels appear on the diagram, this event allows for modification of label content or formatting. Use it to ensure labels effectively convey essential information in a clear and concise manner.

4. **LinkRendering**: This event fires when links are being rendered, offering opportunities to customize link appearance based on specific properties or conditions. Adjust link visuals to enhance clarity and emphasize relationships between nodes.

5. **LegendItemHover**: Occurs when a user hovers over a legend item, enabling responsive actions such as triggering UI updates or displaying contextual data. Use this to create interactive and informative legend behaviors.

6. **SizeChanged**: Fired when the dimensions of the Sankey Diagram change, this event allows for dynamic layout adjustments. Ensure that connected components and visual elements remain coherent and visually appealing.

7. **TooltipRendering**: Triggered before tooltips for nodes and links are rendered, this event lets you customize tooltip content and style. Leverage it to provide clear, context-specific information that enhances user understanding.

8. **PrintCompleted**: This event fires after a print operation completes, allowing you to update UI indicators or log the event for tracking and analytics. Use it to ensure follow-up actions are seamlessly handled post-print.

9. **ExportCompleted**: Occurs after an export operation finishes, similar to print completion events. Use this event to trigger follow-up tasks like notifications, data processing, or analytics logging.

10. **Created**: Fired after the Sankey Diagram is fully initialized and rendered, this event is useful for initializing related components or logging the creation process for monitoring and debugging purposes.

11. **NodeClick**: This event occurs when a user clicks on a node, enabling actions such as updating UI elements, starting data transactions, or recording analytics. Use it to respond effectively to user interactions with nodes.

12. **NodeEnter**: Triggered when the mouse pointer enters a node region, this event allows for dynamic highlights or displaying additional information. It enhances interactivity and provides immediate feedback to user actions.

13. **NodeLeave**: Occurs when the mouse pointer leaves a node region, supporting cleanup actions like removing highlights or hiding overlays. Use it to maintain a clean and clutter-free user interface.

14. **LinkClick**: Fires when a user clicks on a link within the component. Handle user clicks on links, enabling features like detailed data viewing or reshaping interactions in connected components.

15. **LinkEnter**: This event is triggered when the mouse pointer hovers over a link. Implement interactive behaviors when hovering over links, such as emphasizing connections or showing detailed link information.

16. **LinkLeave**: It occurs when the mouse pointer exits a link. Cleanup actions can be attached to this event when the pointer moves off a link, such as resetting visual styles or removing interactive elements.

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

- Employ events to construct interactive and dynamic Sankey diagrams.
- Leverage multiple events to develop complex user experiences.
- Refresh the UI using `StateHasChanged()` when altering component state within event handlers.
- Be mindful of performance trade-offs when dealing with frequent events, such as hover or mouse movement.
- Utilize the `Created` event for any initial setup tasks post full rendering of the Sankey Diagram.

By leveraging the robust set of events provided by the Blazor Sankey component, developers can produce rich and interactive visualizations that are both responsive to user actions and enhanced in functionality within Blazor applications.

## See also

* [Nodes](./nodes)
* [Links](./links)
* [Labels](./labels)