---
layout: post
title: Appearance in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Appearance in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Port appearance and positioning

## How to change the appearance of the port

* The shape of a port can be changed by using the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_Shape) property. To explore the different types of port shapes, refer to Port Shapes. If you need to render a custom shape, then you can set shape to path and define path using the path data property.

* The appearance of the ports can be customized by using the [StrokeColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeColor), [StrokeWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeWidth), and [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_Fill) properties.

* Customize the port size by using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_Height) properties of port.

* The port's [Visibility](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_Visibility) property allows you to define when the port should be visible.

The following code explains how to change the appearance of the port.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes array.
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            // Initialize port collection
            Ports = new DiagramObjectCollection<PointPort>()
            {
                new PointPort()
                {
                    ID = "port1",
                    Offset = new DiagramPoint() { X = 0, Y = 0.5 },
                    Visibility = PortVisibility.Visible,
                    //Set the style for the port.
                    Style = new ShapeStyle()
                    { 
                        Fill = "red", 
                        StrokeColor = "black", 
                        StrokeWidth = 2
                    },
                    Width = 12,
                    Height = 12,
                    // Sets the shape of the port as Circle .
                    Shape = PortShapes.Circle
                }
            },
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Ports/Appearance/Appearance)

![Changing Port Appearance in Blazor Diagram](../images/blazor-diagram-port-appearance.png)

## How to change the visibility of the port

The [Visibility](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_Visibility) of the ports depends upon the properties of Connect, Hidden, Hover, and Visible. By default, [PortVisibility](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortVisibility.html) is set to Hidden.

| Property | Definition |
|---|---|
| Hover | Port is visible when mousehover the DiagramElement. |
| Hidden | Port is not visible for the DiagramElement. |
| Connect | Specifies to visible the port when mousehover the DiagramElement and enable the PortConstraints as InConnect and OutConnect. |
| Visible | Port is always visible for the DiagramElement. |

## Types of port shapes

We have provided some basic built-in [PortShapes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortShapes.html) for the port. Find the shapes as follows.

* Circle
* Custom
* Square
* X

### How to customize the port's shape

 Custom shape support has been provided for port. You can able to add the custom path data instead of build-in shapes. Find the code example that explains how to change the custom shape for port.

 ```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes array.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            // Initialize port collection.
            Ports = new DiagramObjectCollection<PointPort>()
            {
                new PointPort()
                {
                    ID = "port1",
                    Offset = new DiagramPoint() { X = 0.5, Y = 0.5 },
                    Visibility = PortVisibility.Visible,
                    //Set the style for the port.
                    Style = new ShapeStyle() { Fill = "gray", StrokeColor = "black" },
                    Width = 12, 
                    Height = 12,
                    // Sets the shape of the port as Custom .
                    Shape = PortShapes.Custom,
                    // Sets the PathData for port.
                    PathData = "M540.3643,137.9336L546.7973,159.7016L570.3633,159.7296L550.7723,171.9366L558.9053,194.9966L540.3643,179.4996L521.8223,194.9966L529.9553,171.9366L510.3633,159.7296L533.9313,159.7016L540.3643,137.9336z"
                }
            },
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Ports/Appearance/CustomShape)

![Blazor Diagram Port with Custom Shape](../images/blazor-diagram-port-custom-shape.png)

## How to enable or disable certain behavior of the port

The constraints property allows you to enable or disable certain behaviors of ports. For more information about port constraints, refer to [Port Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortConstraints.html). You can verify the [Constraints](https://blazor.syncfusion.com/documentation/diagram/constraints) to learn how to enable or disable the port constraints.

The PortConstraints may have multiple behaviors like listed below:

| Constraints | Usages |
|---|---|
| None |Disables all behaviors of Port. |
| Draw |Enables or disables to draw a connector. |
| InConnect |Enables or disables connecting to the incoming Connector.  |
| OutConnect | Enables or disables connecting the outgoing Connector. |

## How to add additional information for port

The [AdditionalInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_AdditionalInfo) property of the port allows you to maintain additional information for the port.

## See also

* [How to create a node](../nodes/nodes)

* [How to customize the ports](./appearance)

* [How to set the position of the port](./positioning)

* [How to interact with the ports](./interaction)
