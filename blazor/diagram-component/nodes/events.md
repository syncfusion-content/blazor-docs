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

Diagram provides some events support for node that triggers when interacting the node.

## Selection change

* While selecting the diagram elements, the following events can be used to do the customization.
* When selecting or unselecting the diagram elements, the following events are getting triggered. 

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|`SelectionChanging`|`SelectionChangingEventArgs`|Triggers before the selection is changed in the diagram.|
|`SelectionChanged`|`SelectionChangedEventArgs`|Triggers when the node's or connector's selection is changed in the diagram.|

The following code example explains how to get the selection change event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@nodes" 
                    SelectionChanging="OnSelectionChanging"
                    SelectionChanged="OnSelectionChanged" />

@code
{
    // To define node collection
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            // Apperence of the node
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            }
        };
        // Add node
        nodes.Add(node);
    }

    // Event to notify the selection changing event before select/unselect the diagram elements
    public void OnSelectionChanging(SelectionChangingEventArgs args)
    {
        //sets true to cancel the selection.
        args.Cancel = true;
    }

    // Event to notify the selection changed event after select/unselect the diagram elements.
    public void OnSelectionChange(SelectionChangedEventArgs args)
    {
        //Action to be performed
    }
}
```

## Position change

* While dragging the node or connector through interaction, the following events can be used to do the customization.
* When dragging the node, the following events are getting triggered. 

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|`PositionChanging`|`PositionChangedEventArgs`|Triggers while dragging the elements in the diagram.|
|`PositionChanged`|`PositionChangedEventArgs`|Triggers when the node's or connector's position is changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@nodes"
                    PositionChanging="OnPositionChanging"
                    PositionChanged="OnPositionChanged" />

@code
{
    // To define node collection
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            },
            Shape= new Shape() { Type=Shapes.Basic}
        };
        // Add node
        nodes.Add(node);
    }

    // Event to notify the position changing event while dragging the elements in diagram.
    public void OnPositionChanging(PositionChangingEventArgs args)
    {
        //Sets true to cancel the action.
        args.Cancel = true;
    }

    //Event to notify the position changed event when the node's or connector's position is changed.
    public void OnPositionChanged(PositionChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```

## Size change
* While resizing the node during the interaction, the following events can be used to do the customization.
* When resizing the node, the following events are getting triggered. 

|Event Name|Arguments|Description|
|------------|------------|-----------------------|
|`SizeChanging`|`SizeChangingEventArgs`|Triggers before the node is resized.|
|`SizeChanged`|`SizeChangedEventArgs`|Triggers when the node is resized.|
 
```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@nodes" 
                    SizeChanged="OnSizeChanged" 
                    SizeChanging="OnSizeChanging"/>

@code
{
    // To define node collection
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            }
        };
        // Add node
        nodes.Add(node);
    }

    // Event to notify the Size changing event before the digram elements size is changing.
    public void OnSizeChanging(SizeChangingEventArgs args)
    {
        //Sets true to cancel the resize action
        args.Cancel = true;
    }

    // Event to notify the Size change event after the diagram elements size is changed.
    public void OnSizeChanged(SizeChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```

## Rotate change

* While rotating the node during the interaction, the following events can be used to do the customization.
* When rotating the node, the following events are getting triggered. 

|Event Name|Arguments|Description|
|------------|----------|-------------------------|
|`RotateChanging`|`RotationChangingEventArgs`|Triggers before the diagram elements are rotate.|
|`RotationChanged`|`RotationChangedEventArgs` |Triggers when the diagram elements are rotated.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@nodes" 
                    RotationChanging="OnRotateChanging"
                    RotationChanged="OnRotateChanged" />

@code
{
    // To define node collection
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            }
        };
        // Add node
        nodes.Add(node);
    }

    // Event to notify the rotation changing event before the node is rotate.
    public void OnRotateChanging(RotationChangingEventArgs args)
    {
        //Sets true to cancel the rotation
        args.Cancel = true;
    }

    // Event to notify the rotation changed event after the node is rotated.
    public void OnRotateChanged(RotationChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```

## Constraints

The Constraints property of node allows you to enable or disable certain features. For more information about node constraints, refer to the [Node Constraints](../constraints).

## See also

* [How to interact the node in diagram](./interaction)

* [How to get events when they interact the connector](../connectors/events)

* [How to get events when they interact the annotation](../annotations/events)
