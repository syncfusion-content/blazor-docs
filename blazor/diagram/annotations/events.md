---
layout: post
title: Annotation Events in Blazor Diagram Component | Syncfusion®
description: Checkout and Learn how to use annotation events in the Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Annotation Events in Blazor Diagram Component

## How to Handle Annotation Selection Change Event

The following events are triggered when selecting or unselecting annotations. Use these events to apply custom behavior during annotation selection.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[SelectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanging)|[SelectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangingEventArgs.html)|Triggers before the annotation selection is changed in the diagram.|
|[SelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanged)|[SelectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangedEventArgs.html)|Triggers when the annotation's selection is changed in the diagram.|

The following code example demonstrates how to handle annotation selection change events:

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes" SelectionChanging="OnSelectionChanging" SelectionChanged="OnSelectionChanged" />

@code
{
    private DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    Content = "Selectable Annotation",
                    Constraints = AnnotationConstraints.Select
                }
            }
        };
        _nodes.Add(node);
    }

    // Event triggered before annotation selection changes
    private void OnSelectionChanging(SelectionChangingEventArgs args)
    {
        // Prevent annotation selection if needed
        // args.Cancel = true;
        Console.WriteLine("Annotation selection changing");
    }

    // Event triggered after annotation selection changes
    private void OnSelectionChanged(SelectionChangedEventArgs args)
    {
        Console.WriteLine("Annotation selection changed");
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/YOUR_SAMPLE_ID?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/SelectionChangeEvent.razor)

## How to Handle Annotation Position Change Event

The following events are triggered when dragging an annotation. Use these events to apply custom behavior during annotation movement.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[PositionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanging)|[PositionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangingEventArgs.html)|Triggers while dragging the annotation in the diagram.|
|[PositionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanged)|[PositionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangedEventArgs.html)|Triggers when the annotation's position is changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes" PositionChanging="OnPositionChanging" PositionChanged="OnPositionChanged" />

@code
{
    private DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    Content = "Draggable Annotation",
                    Constraints = AnnotationConstraints.Select | AnnotationConstraints.Drag
                }
            }
        };
        _nodes.Add(node);
    }

    // Event triggered while dragging the annotation
    private void OnPositionChanging(PositionChangingEventArgs args)
    {
        // Prevent position change if needed
        // args.Cancel = true;
        Console.WriteLine("Annotation position changing");
    }

    // Event triggered after annotation position changes
    private void OnPositionChanged(PositionChangedEventArgs args)
    {
        Console.WriteLine("Annotation position changed");
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/YOUR_SAMPLE_ID?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/PositionChangeEvent.razor)

## How to Handle Annotation Size Change Event

The following events are triggered when resizing an annotation. Use these events to apply custom behavior during annotation resizing.

|Event Name|Arguments|Description|
|------------|------------|-----------------------|
|[SizeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanging)|[SizeChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SizeChangingEventArgs.html)|Triggers before the annotation is resized.|
|[SizeChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanged)|[SizeChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SizeChangedEventArgs.html)|Triggers when the annotation is resized.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes" SizeChanged="OnSizeChanged" SizeChanging="OnSizeChanging"/>

@code
{
    private DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    Content = "Resizable Annotation",
                    Width = 80,
                    Height = 40,
                    Constraints = AnnotationConstraints.Select | AnnotationConstraints.Resize
                }
            }
        };
        _nodes.Add(node);
    }

    // Event triggered before annotation size changes
    private void OnSizeChanging(SizeChangingEventArgs args)
    {
        // Prevent size change if needed
        // args.Cancel = true;
        Console.WriteLine("Annotation size changing");
    }

    // Event triggered after annotation size changes
    private void OnSizeChanged(SizeChangedEventArgs args)
    {
        Console.WriteLine("Annotation size changed");
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/YOUR_SAMPLE_ID?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/SizeChangeEvent.razor)

## How to Handle Annotation Rotation Change Event

The following events are triggered when rotating an annotation. Use these events to apply custom behavior during annotation rotation.

|Event Name|Arguments|Description|
|------------|----------|-------------------------|
|[RotationChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_RotationChanging)|[RotationChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RotationChangingEventArgs.html)|Triggers before the annotation is rotated.|
|[RotationChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_RotationChanged)|[RotationChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RotationChangedEventArgs.html)|Triggers when the annotation is rotated.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes" RotationChanging="OnRotateChanging" RotationChanged="OnRotateChanged" />

@code
{
    // To define node collection.
    private DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6BA5D7", 
                StrokeColor = "white" 
            },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    Content = "Rotatable Annotation",
                    Constraints = AnnotationConstraints.Select | AnnotationConstraints.Rotate
                }
            }
        };
        _nodes.Add(node);
    }

    // Event triggered before annotation rotation changes
    private void OnRotateChanging(RotationChangingEventArgs args)
    {
        // Prevent rotation if needed
        // args.Cancel = true;
        Console.WriteLine("Annotation rotation changing");
    }

    // Event triggered after annotation rotation changes
    private void OnRotateChanged(RotationChangedEventArgs args)
    {
        Console.WriteLine("Annotation rotation changed");
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/YOUR_SAMPLE_ID?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/RotationChangeEvent.razor)

## How to Handle Text Change Event

The following events are triggered when a node's or connector's annotation text is edited in the diagram. Use these events to apply custom behavior during annotation text editing.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[TextChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_TextChanged)|[TextChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextChangeEventArgs.html)|Triggers after a node or connector's annotation text has been changed in the diagram.|
|[TextChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_TextChanging)|[TextChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextChangeEventArgs.html)|An event that is raised when the node and connector's annotation text is changing in the diagram.|

The following code example shows how to register and get notifications from the `TextChanged` and `TextChanging` events.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent TextChanging="@OnLabelTextChanging" Height="600px" TextChanged="@OnTextChanged" Nodes="@_nodes" />

@code
{
    // Defines diagram's nodes collection.
    DiagramObjectCollection<Node> _nodes;
    // Triggered when the node and connector's labels change in the diagram.
    private void OnLabelTextChanging(TextChangeEventArgs args)
    {
        args.Cancel = true;
    }
    // Triggered when annotation editing is complete; provides the old and new text values.
    private void OnTextChanged(TextChangeEventArgs args)
    {
        Console.WriteLine("OldValue", args.OldValue);
        Console.WriteLine("NewValue", args.NewValue);
    }

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation { Content = "Annotation" }
        };
        _nodes.Add(node);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVoijjnBnkUtSTH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/TextChangedEvent.razor)

## See also

* [How to add or remove annotation constraints](../constraints#annotation-constraints)

* [How to customize the annotation](./appearance)

* [How to add an annotation for a Node](./node-annotation)

* [How to add an annotation for a Connector](./connector-annotation)
