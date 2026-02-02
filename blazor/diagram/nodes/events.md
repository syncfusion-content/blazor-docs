---
layout: post
title: Events in Syncfusion Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Node Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Events and Constraints in Diagram Component

## Events

The diagram provides a several events support for node that triggers when interacting with the node.

## How to Handle Selection Change Event

* While selecting the diagram elements, the following events can be used to do the customization.
* When selecting or unselecting diagram elements, the following events are triggered.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[SelectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanging)|[SelectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangingEventArgs.html)|Triggers before the selection is changed in the diagram.|
|[SelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanged)|[SelectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangedEventArgs.html)|Triggers when the node's or connector's selection is changed in the diagram.|

The following code example demonstrates how to get the selection change event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@_nodes" 
                    SelectionChanging="OnSelectionChanging"
                    SelectionChanged="OnSelectionChanged" />

@code
{
    // To define node collection.
    private DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            // Appearance of the node
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            }
        };
        // Add node.
        _nodes.Add(node);
    }

    // Event to notify the selection changing event before selecting/unselecting the diagram elements.
    private void OnSelectionChanging(SelectionChangingEventArgs args)
    {
        // Sets true to cancel the selection.
        args.Cancel = true;
    }

    // Event to notify the selection changed event after selecting/unselecting the diagram elements.
    private void OnSelectionChanged(SelectionChangedEventArgs args)
    {
        // Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBSCjjmsOntdxie?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/SelectionChange.razor)

## How to Handle Position Change Event 

* While dragging the node or connector through interaction, the following events can be used to do the customization.
* When dragging a node, the following events are triggered.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[PositionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanging)|[PositionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangingEventArgs.html)|Triggers while dragging the elements in the diagram.|
|[PositionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanged)|[PositionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangedEventArgs.html)|Triggers when the node's or connector's position is changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@_nodes"
                    PositionChanging="OnPositionChanging"
                    PositionChanged="OnPositionChanged" />

@code
{
    // To define node collection.
    private DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
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
            Shape = new Shape() { Type = NodeShapes.Basic}
        };
        // Add node.
        _nodes.Add(node);
    }

    // Event to notify the position changing event while dragging the elements in diagram.
    private void OnPositionChanging(PositionChangingEventArgs args)
    {
        // Sets true to cancel the action.
        args.Cancel = true;
    }

    //Event to notify the position changed event when the node's or connector's position is changed.
    private void OnPositionChanged(PositionChangedEventArgs args)
    {
        // Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rthICtjciuGtobOO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/PositionChange.razor)

## How to Handle Size Change Event 

* While resizing the node during the interaction, the following events can be used to do the customization.
* When resizing a node, the following events are triggered.

|Event Name|Arguments|Description|
|------------|------------|-----------------------|
|[SizeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanging)|[SizeChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SizeChangingEventArgs.html)|Triggers before the node is resized.|
|[SizeChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanged)|[SizeChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SizeChangedEventArgs.html)|Triggers when the node is resized.|
 
```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@_nodes" 
                    SizeChanged="OnSizeChanged" 
                    SizeChanging="OnSizeChanging"/>

@code
{
    // To define node collection.
    private DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
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
        _nodes.Add(node);
    }

    // Event to notify the Size changing event before the diagram elements size is changed.
    private void OnSizeChanging(SizeChangingEventArgs args)
    {
        // Sets true to cancel the resize action
        args.Cancel = true;
    }

    // Event to notify the Size change event after the diagram elements size is changed.
    private void OnSizeChanged(SizeChangedEventArgs args)
    {
        // Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVSCtZGiEcHqVrO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/SizeChange.razor)

## How to Handle Rotate Change Event 

* While rotating the node during the interaction, the following events can be used to do the customization.
* When rotating a node, the following events are triggered.

|Event Name|Arguments|Description|
|------------|----------|-------------------------|
|[RotationChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_RotationChanging)|[RotationChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RotationChangingEventArgs.html)|Triggers before the diagram elements are rotated.|
|[RotationChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_RotationChanged)|[RotationChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RotationChangedEventArgs.html)|Triggers when the diagram elements are rotated.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@_nodes" 
                    RotationChanging="OnRotateChanging"
                    RotationChanged="OnRotateChanged" />

@code
{
    // To define node collection.
    private DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
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
        _nodes.Add(node);
    }

    // Event to notify the rotation changing event before the node is rotated.
    private void OnRotateChanging(RotationChangingEventArgs args)
    {
        // Sets true to cancel the rotation
        args.Cancel = true;
    }

    // Event to notify the rotation changed event after the node is rotated.
    private void OnRotateChanged(RotationChangedEventArgs args)
    {
        // Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZryMjNGMEPDIoUc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/RotationChange.razor)

## How to Use Node Creating Event

* The [NodeCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_NodeCreating)  helps you to define the default properties of the node. The node creation is triggered when the diagram is initialized. In the node creating event, you can customize the node properties.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Nodes="@_nodes" 
                    NodeCreating="OnNodeCreating" />

@code
{
    // Define the node collection.
    private DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        //  A node is created and stored in node collection.
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
        _nodes.Add(node);
    }

    private void OnNodeCreating(IDiagramObject obj)
    { 
        Node node = obj as Node;
        node.Style.Fill = "#357BD2";
        node.Style.StrokeColor = "White";
        node.Style.Opacity = 1;
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVSMZNwsaPGCptX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/NodeCreatingEvent.razor)

## How to Handle Property Changed Event

The [PropertyChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PropertyChanged) event is triggered when a node property of the diagram component is modified at runtime. This event provides details about the changes occurring in the diagram. For event argument details, refer to [PropertyChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PropertyChangedEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="@_diagram" 
                    Width="100%" 
                    Height="700px" 
                    Nodes="_nodes" 
                    PropertyChanged="OnNodePropertyChanged">
</SfDiagramComponent>
@code {
    private SfDiagramComponent diagram;
    private DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            // Initial position and size of the node
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle { Fill = "#6495ED", StrokeColor = "white" }
        };
        _nodes.Add(node);
    }
    // Method to handle Node Property Changed event
    private void OnNodePropertyChanged(PropertyChangedEventArgs args)
    {
        if (args.Element is Node changedNode)
        {
            // Logic to handle the property change for the specific node
            Console.WriteLine($"Node ID: {changedNode.ID} property changed.");
            // Additional logic to handle updates
        }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtroiXXcVZjLxVof?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/PropertyChangedEvent.razor)

## How to Handle Collection Change Events

* The diagram raises events when nodes are added to or removed from the diagram. These events offer opportunities for customization and are invoked whenever the node collection undergoes changes.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[CollectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanging)|[CollectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangingEventArgs.html)|Triggers before the node or connector is added or removed from the diagram.|
|[CollectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanged)|[CollectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangedEventArgs.html)|Triggers after the node or connector is added or removed from the diagram|


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
<SfDiagramComponent @ref="@_diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="_nodes"
                    CollectionChanged="OnCollectionChanged">
</SfDiagramComponent>
@code{
    private SfDiagramComponent _diagram;
    private DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        _nodes.Add(node);
    }
     //  Notify the Collection Changed event while changing the collection of the node at run time.
    private void OnCollectionChanged(CollectionChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNroWDXQBDjHmggk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/CollectionChangeEvent.razor)

## How to Handle the Mouse Enter Event

The [MouseEnter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseEnter) event is triggered when the mouse pointer enters the boundary of a node in the diagram. The event arguments include details about the element being interacted with. For a comprehensive understanding of the event arguments and their properties, refer to the [DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html).


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
<SfDiagramComponent @ref="@_diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="_nodes"
                    MouseEnter="OnMouseEnter">
</SfDiagramComponent>
@code{
    private SfDiagramComponent _diagram;
    private DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        _nodes.Add(node);
    }
    private void OnMouseEnter(DiagramElementMouseEventArgs args)
    {
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrSsDDGVXMoFpjP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/MouseEnterEvent.razor)

## How to Handle the Mouse Leave Event

The [MouseLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseLeave) event is triggered when the mouse pointer exits the boundaries of a node in the diagram. The event arguments include details about the element being left. For a comprehensive understanding of the event arguments and their properties, refer to the [DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html). 


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
<SfDiagramComponent @ref="@_diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="_nodes"
                    MouseLeave="OnMouseLeave">
</SfDiagramComponent>
@code{
    private SfDiagramComponent _diagram;
    private DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        _nodes.Add(node);
    }
    private void OnMouseLeave(DiagramElementMouseEventArgs args)
    {
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtVyCXZcBNhXdpGO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/MouseLeaveEvent.razor)

## How to Handle the Mouse Hover Event

The [MouseHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseHover) event is triggered when the mouse pointer hovers over a node in the diagram. This event provides valuable information about the element being hovered. For detailed information about the event arguments, refer to the [DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html).


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
<SfDiagramComponent @ref="@_diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="_nodes"
                    MouseHover="OnMouseHover">
</SfDiagramComponent>
@code{
    SfDiagramComponent _diagram;
    DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        _nodes.Add(node);
    }
    private void OnMouseHover(DiagramElementMouseEventArgs args)
    {
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBeiXjcLNBzlmCQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Nodes/Events/MouseHoverEvent.razor)


## How to Enable or Disable Node Behaviors Using Constraints

The node [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_Constraints) property enables or disables specific features (for example, select, drag, resize, rotate). For more information about node constraints, refer to the [Node Constraints](https://blazor.syncfusion.com/documentation/diagram/constraints#node-constraints).

## See also

* [How to interact with the node in diagram](./interaction)

* [How to get events when they interact with the connector](../connectors/events)

* [How to get events when they interact with the annotation](../annotations/events)

* [How to identify the clicked diagram elements in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Diagram](https://support.syncfusion.com/kb/article/17226/how-to-identify-the-clicked-diagram-elments-in-syncfusion-blazor-diagram)