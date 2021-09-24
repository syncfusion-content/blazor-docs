---
layout: post
title: Interaction in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Interaction in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Node Interaction in Blazor Diagram Component

Diagram provides the support to select, drag, resize, or rotate the node interactively.

## Select

A node can be select at runtime by using the [Select](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Select_System_Collections_ObjectModel_ObservableCollection_Syncfusion_Blazor_Diagram_IDiagramObject__System_Nullable_System_Boolean__) method and clear the selection in the diagram by using the [ClearSelection](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ClearSelection). The following code explains how to select and clear selection in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<input type="button" value="Select" @onclick="OnSelect">
<input type="button" value="UnSelect" @onclick="@UnSelect" />
<SfDiagramComponent @ref="@diagram" Height="600px" Nodes="@nodes" />

@code
{
    // reference of the diagram
    SfDiagramComponent diagram;
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
            }
        };
        // Add node
        nodes.Add(node);
    }

    public void OnSelect()
    {
        // Select the node
        diagram.Select(new ObservableCollection<IDiagramObject> { diagram.Nodes[0] });
    }

    public void UnSelect()
    {
        // clear selection in the diagram
        diagram.ClearSelection();
    }
}
```

And also the selection enable during the interaction.

* An element can be selected by clicking that element.
* When you select the elements in the diagram, the [SelectionChanging](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanging) and [SelectionChanged](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanged) event gets triggered and to do customization in those events.

![Select](../images/node-select.png)

## Drag

A node can be drag at runtime by using the [Drag](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Drag_Syncfusion_Blazor_Diagram_IDiagramObject_System_Double_System_Double_) method. The following code explains how to drag the node by using the drag method.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Drag" @onclick="OnDrag">
<SfDiagramComponent @ref="@Diagram" Height="600px" Nodes="@nodes" />

@code
{
    // reference of the diagram
    SfDiagramComponent Diagram;
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
            }
        };
        // Add node
        nodes.Add(node);
    }

    public void OnDrag()
    {
        // Drag the node
        Diagram.Drag(Diagram.Nodes[0], 10, 10);
    }
}
```

And also the drag the node during the interaction.

* An object can be dragged by clicking and dragging it. When multiple elements are selected, dragging any one of the selected elements move all the selected elements.
* When you drag the elements in the diagram, the [PositionChanging](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanging) and [PositionChanged](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanged) event gets triggered and to do customization in this event.

![Drag](../images/drag.gif)

## Resize

A node can be resize at runtime by using the [Scale](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Scale_Syncfusion_Blazor_Diagram_IDiagramObject_System_Double_System_Double_Syncfusion_Blazor_Diagram_DiagramPoint_) method. The following code explains how to resize the node by using the scale method.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Resize" @onclick="OnResize">
<SfDiagramComponent @ref="@diagram" Height="600px" Nodes="@nodes" />

@code
{
    // reference of the diagram
    SfDiagramComponent diagram;
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
            }
        };
        // Add node
        nodes.Add(node);
    }

    public void OnResize()
    {
        // Resize the node
        diagram.Scale(diagram.Nodes[0], 0.5, 0.5, new DiagramPoint() { X = 0, Y = 0 });
    }
}
```

And also you can resize the node during interaction.

* Selector is surrounded by eight thumbs. When dragging these thumbs, the selected items can be resized.
* When one corner of the selector is dragged, the opposite corner will be in a static position.
* When a node is resized, the [SizeChanging](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanging) and [SizeChanged](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanged) event gets triggered.

![Resize](../images/resize.gif)

## Rotate

A node can be rotate at runtime by using the [Rotate](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Rotate_Syncfusion_Blazor_Diagram_IDiagramObject_System_Double_Syncfusion_Blazor_Diagram_DiagramPoint_) method. The following code explains how to rotate the node by using the rotate method.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Rotate" @onclick="OnRotate">
<SfDiagramComponent @ref="@diagram" Height="600px" Nodes="@nodes" />

@code
{
    // reference of the diagram
    SfDiagramComponent diagram;
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
            }
        };
        // Add node
        nodes.Add(node);
    }

    public void OnRotate()
    {
        // Rotate the node
        diagram.Rotate(diagram.Nodes[0], diagram.Nodes[0].RotationAngle + 10);
    }
}
```

And also the rotate the node during the interaction.

* A rotate handler is placed above the selector. Clicking and dragging the handler in a circular direction lead to rotate the node.
* The node is rotated with reference to the static pivot point.
* Pivot thumb (thumb at the middle of the node) appears when rotating the node to represent the static point.
* When a node is rotated, the [RotationChanging](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_RotationChanging) and [RotationChanged](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_RotationChanged) events getting triggered.

![Rotate](../images/rotate.gif)

For more information about node interaction, refer to [Node Interaction](../interaction).

## See also

* [How to get events while the interact the node](./events)

* [How to positioning the node](./positioning)

* [How to customize the node](./appearance)

* [How to interact the annotation in diagram](../annotations/interaction)

* [How to interact the port in diagram](../ports/interaction)

* [How to interact the connector in diagram](../connectors/interactions)
