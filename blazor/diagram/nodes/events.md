---
layout: post
title: Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Events and Constraints in Blazor Diagram Component

## Events

Diagram provides some events support for node that triggers when interacting with the node.

## Selection change event

* While selecting the diagram elements, the following events can be used to do the customization.
* When selecting or unselecting the diagram elements, the following events are getting triggered. 

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[SelectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanging)|[SelectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangingEventArgs.html)|Triggers before the selection is changed in the diagram.|
|[SelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanged)|[SelectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangedEventArgs.html)|Triggers when the node's or connector's selection is changed in the diagram.|

The following code example explains how to get the selection change event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@nodes" 
                    SelectionChanging="OnSelectionChanging"
                    SelectionChanged="OnSelectionChanged" />

@code
{
    // To define node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            // Apperence of the node
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            }
        };
        // Add node.
        nodes.Add(node);
    }

    // Event to notify the selection changing event before selecting/unselecting the diagram elements.
    public void OnSelectionChanging(SelectionChangingEventArgs args)
    {
        // Sets true to cancel the selection.
        args.Cancel = true;
    }

    // Event to notify the selection changed event after selecting/unselecting the diagram elements.
    public void OnSelectionChanged(SelectionChangedEventArgs args)
    {
        // Action to be performed.
    }
}
```

## Position change event

* While dragging the node or connector through interaction, the following events can be used to do the customization.
* When dragging the node, the following events are getting triggered. 

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[PositionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanging)|[PositionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangingEventArgs.html)|Triggers while dragging the elements in the diagram.|
|[PositionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanged)|[PositionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangedEventArgs.html)|Triggers when the node's or connector's position is changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@nodes"
                    PositionChanging="OnPositionChanging"
                    PositionChanged="OnPositionChanged" />

@code
{
    // To define node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            },
            Shape = new Shape() { Type = Shapes.Basic}
        };
        // Add node.
        nodes.Add(node);
    }

    // Event to notify the position changing event while dragging the elements in diagram.
    public void OnPositionChanging(PositionChangingEventArgs args)
    {
        // Sets true to cancel the action.
        args.Cancel = true;
    }

    //Event to notify the position changed event when the node's or connector's position is changed.
    public void OnPositionChanged(PositionChangedEventArgs args)
    {
        // Action to be performed.
    }
}
```

## Size change event

* While resizing the node during the interaction, the following events can be used to do the customization.
* When resizing the node, the following events are getting triggered. 

|Event Name|Arguments|Description|
|------------|------------|-----------------------|
|[SizeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanging)|[SizeChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SizeChangingEventArgs.html)|Triggers before the node is resized.|
|[SizeChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanged)|[SizeChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SizeChangedEventArgs.html)|Triggers when the node is resized.|
 
```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@nodes" 
                    SizeChanged="OnSizeChanged" 
                    SizeChanging="OnSizeChanging"/>

@code
{
    // To define node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            }
        };
        // Add node.
        nodes.Add(node);
    }

    // Event to notify the Size changing event before the diagram elements size is changed.
    public void OnSizeChanging(SizeChangingEventArgs args)
    {
        // Sets true to cancel the resize action
        args.Cancel = true;
    }

    // Event to notify the Size change event after the diagram elements size is changed.
    public void OnSizeChanged(SizeChangedEventArgs args)
    {
        // Action to be performed.
    }
}
```

## Rotate change event

* While rotating the node during the interaction, the following events can be used to do the customization.
* When rotating the node, the following events are getting triggered. 

|Event Name|Arguments|Description|
|------------|----------|-------------------------|
|[RotationChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_RotationChanging)|[RotationChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RotationChangingEventArgs.html)|Triggers before the diagram elements are rotated.|
|[RotationChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_RotationChanged)|[RotationChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RotationChangedEventArgs.html)|Triggers when the diagram elements are rotated.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@nodes" 
                    RotationChanging="OnRotateChanging"
                    RotationChanged="OnRotateChanged" />

@code
{
    // To define node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            }
        };
        // Add node.
        nodes.Add(node);
    }

    // Event to notify the rotation changing event before the node is rotated.
    public void OnRotateChanging(RotationChangingEventArgs args)
    {
        // Sets true to cancel the rotation
        args.Cancel = true;
    }

    // Event to notify the rotation changed event after the node is rotated.
    public void OnRotateChanged(RotationChangedEventArgs args)
    {
        // Action to be performed.
    }
}
```

## How to enable or disable certain behaviors of the node

The Constraints property of node allows you to enable or disable certain features. For more information about node constraints, refer to the [Node Constraints](../constraints).

## See also

* [How to interact with the node in diagram](./interaction)

* [How to get events when they interact with the connector](../connectors/events)

* [How to get events when they interact with the annotation](../annotations/events)
