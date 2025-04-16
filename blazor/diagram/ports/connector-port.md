---
layout: post
title: Connector Ports in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about connector ports in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

## Create connector port

Creating connector ports is similar to creating node ports. To define connector ports, you need to create a collection of `PathPort` and assign it to the connector’s `Ports` property.

The following code example demonstrates how to create a connector port:

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    //Define diagram's connector collection
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        // A connector is created and stored in connectors collection.
        connectors = new DiagramObjectCollection<Connector>();

        // Create connector
        Connector connector = new Connector()
        {
            ID = "connector",
            SourcePoint = new DiagramPoint() { X = 400, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 550, Y = 350 },
            Type = ConnectorSegmentType.Orthogonal,
            Ports = new DiagramObjectCollection<PathPort>()
            {
                new PathPort()
                {
                    ID = "port",
                    Visibility = PortVisibility.Visible,
                    Shape = PortShapes.Square,
                    Style = new ShapeStyle(){ Fill = "gray", StrokeColor = "black" },
                }
            }
        };
        connectors.Add(connector);
    }
}
```
## Port PathPosition

The `PathPosition` property allows you to place a connector port along the path of a connector. It accepts a value between 0 and 1, where:

* 0 represents the starting point of the connector.
* 1 represents the endpoint of the connector.

You can set any value between 0 and 1 to position the port at a specific location along the connector's path.

>**Note:** The default value of PathPosition is 0.5, which places the port at the midpoint of the connector.

The following code example demonstrates how to set the PathPosition for a connector port:

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    //Define diagram's connector collection
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        // A connector is created and stored in connectors collection.
        connectors = new DiagramObjectCollection<Connector>();

        // Create connector
        Connector connector = new Connector()
        {
            ID = "connector",
            SourcePoint = new DiagramPoint() { X = 400, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 550, Y = 350 },
            Type = ConnectorSegmentType.Orthogonal,
            Ports = new DiagramObjectCollection<PathPort>()
            {
                new PathPort()
                {
                    ID = "port",
                    Visibility = PortVisibility.Visible,
                    Shape = PortShapes.Square,
                    PathPosition = 0,
                    Style = new ShapeStyle(){ Fill = "gray", StrokeColor = "black" },
                }
            }
        };
        connectors.Add(connector);
    }
}
```

## Connector port connection

Connector ports are used to establish connections between connectors. To create such a connection, set the `SourcePortID` or `TargetPortID` property to the ID of the corresponding port on the connector.

The following code example demonstrates how to connect one connector to a port on another connector: