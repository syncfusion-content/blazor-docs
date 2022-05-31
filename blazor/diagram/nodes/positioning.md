---
layout: post
title: Positioning in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Positioning in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Positioning a node in Blazor Diagram Component

## Arrange the nodes

* Position of a node is controlled by using the [OffsetX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_OffsetX) and [OffsetY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_OffsetY) properties. By default, these offset properties represent the distance between the origin of the diagram’s page and node’s center point.

* You may expect this offset values to represent the distance between page origin and node’s top-left corner instead of center. The Pivot property helps to solve this problem. Default value of node’s [Pivot](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_Pivot) point is (0.5, 0.5) that means center of the node.

* The size of the node can be controlled by using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_Height) properties.

The following table shows how pivot relates offset values with node boundaries.

| Pivot | Offset |
|-------- | -------- |
| (0.5,0.5)| OffsetX and OffsetY values are considered as the node’s center point. |
| (0,0) | OffsetX and OffsetY values are considered as the top-left corner of the node. |
| (1,1) | OffsetX and OffsetY values are considered as the bottom-right corner of the node. |

The following code shows how to change the Pivot value.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes" />

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes array.
        Node node = new Node()
        {
            ID = "node",
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
            // Pivot of the node.
            Pivot = new DiagramPoint() { X = 0, Y = 0 }
        };
        nodes.Add(node);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            //OnAfterRenderAsync will be triggered after the component rendered.
            await Task.Delay(200);
            diagram.Select(new ObservableCollection<IDiagramObject>() { diagram.Nodes[0] });
        }
    }
}
```

![Arranging Node Position in Blazor Diagram](../images/blazor-diagram-node-position.png)

Rotation of a node is controlled by using the [RotationAngle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_RotationAngle) property. The following code shows how to change the RotationAngle value.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes" />

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes array.
        Node node = new Node()
        {
            ID = "node",
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
            // RotationAngle of the node.
            RotationAngle = 90
        };
        nodes.Add(node);
    }
}
```

![Changing Node Rotation Angle in Blazor Diagram](../images/blazor-diagram-node-rotation-angle.png)

## How to set minimum size and maximum size for the node

The [MinWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_MinWidth) and [MinHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_MinHeight) properties of node allows you to control the minimum size of the node while resizing. Similarly, the [MaxWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_MaxWidth) and [MaxHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_MaxHeight) properties of node allows you to control the maximum size of the node while resizing. The below gif explains how minimum and maximum size is controlled.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes" />

@code
 {
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes array.
        Node node = new Node()
        {
            ID = "node",
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            //Minimum Size of the node.
            MinHeight = 50,
            MinWidth = 50,
            //Maximum Size of the node.
            MaxHeight = 200,
            MaxWidth = 200,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            },
        };
        nodes.Add(node);
    }
}
```

![Displaying Maximum and Minimum Size of Blazor Diagram Node](../images/blazor-diagram-show-max-min-size-node.gif)

## See also

* [How to customize the node](./appearance)

* [How to get events when they interact with the node](./events)
