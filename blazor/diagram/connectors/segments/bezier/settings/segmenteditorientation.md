---
layout: post
title: Bezier Segments in Blazor Diagram Component | Syncfusion
description:  Check out and learn about Bezier Segments in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Bezier Segments in Blazor Diagram Component

## How to Edit Bezier Segments Using Bezier Connector Settings

The intermediate point of two adjacent bezier segments can be edited interactively using the [BezierConnectorSettings.SegmentEditOrientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierConnectorSettings.html#Syncfusion_Blazor_Diagram_BezierConnectorSettings_SegmentEditOrientation) property of the Connector class.

| SegmentEditOrientation value | Description | Output |
|-------- | -------- | -------- |
| [Bidirectional](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSegmentEditOrientation.html#Syncfusion_Blazor_Diagram_BezierSegmentEditOrientation_Bidirectional) | Allows the intermediate points to be dragged in either vertical or horizontal directions. | ![Bidirectional](../../../../images/Bidirectional.gif) |
| [Freeform](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSegmentEditOrientation.html#Syncfusion_Blazor_Diagram_BezierSegmentEditOrientation_FreeForm) | Allows the intermediate points to be dragged in any direction. | ![Freeform](../../../../images/Freeform.gif) |

The following code illustrates how to interact with Bezier efficiently by using the [BezierConnectorSettings.Smoothness](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierConnectorSettings.html#Syncfusion_Blazor_Diagram_BezierConnectorSettings_Smoothness) and [BezierConnectorSettings.SegmentEditOrientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierConnectorSettings.html#Syncfusion_Blazor_Diagram_BezierConnectorSettings_SegmentEditOrientation) properties of the Connector class.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Nodes="@nodes" Connectors="@connectors"></SfDiagramComponent>

@code {
    //Define the diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    //Define the diagram's node collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes.Add(
            new Node()
                {
                    ID = "node1",
                    OffsetX = 300,
                    OffsetY = 100,
                    Width = 100,
                    Height = 100,
                    Ports = new DiagramObjectCollection<PointPort>()
                    {
                    new PointPort()
                    {
                        ID="Port1",
                        Visibility = PortVisibility.Visible,
                        Offset = new DiagramPoint() { X = 1, Y = 0.5 },
                    },
                    }
                });
        nodes.Add(new Node()
            {
                ID = "node2",
                OffsetX = 300,
                OffsetY = 350,
                Width = 100,
                Height = 100,
                Ports = new DiagramObjectCollection<PointPort>()
                {
                    new PointPort()
                    {
                        ID="Port1",
                        Visibility = PortVisibility.Visible,
                        Offset = new DiagramPoint() { X = 0, Y = 0.5 },
                    },
                }
            });
        Connector connector1 = new Connector()
            {
                ID = "connector1",
                SourceID = "node1",
                TargetID = "node2",
                SourcePortID = "Port1",
                TargetPortID = "Port1",
                Type = ConnectorSegmentType.Bezier,
                BezierConnectorSettings = new BezierConnectorSettings() 
                { 
                    //Define the smoothness for a bezier connector.
                    Smoothness = BezierSmoothness.SymmetricAngle,
                    //Define the orientation of the segment editing controls.
                    SegmentEditOrientation = BezierSegmentEditOrientation.FreeForm
                },
                Constraints = ConnectorConstraints.Default | ConnectorConstraints.DragSegmentThumb
            };
        connectors.Add(connector1);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Segments).

