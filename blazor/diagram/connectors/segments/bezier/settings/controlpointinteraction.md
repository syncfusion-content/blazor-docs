---
layout: post
title: Bezier Segments Interaction in Blazor Diagram | Syncfusion
description: Checkout and learn here all about Bezier Segments in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Bezier Segments Interaction in Blazor Diagram

## How to Interact with the Bezier Segments Efficiently

When interacting with multiple bezier segments, maintain their control points at the same distance and angle by using the [BezierConnectorSettings.Smoothness](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierConnectorSettings.html#Syncfusion_Blazor_Diagram_BezierConnectorSettings_Smoothness) property of the Connector class.

| BezierSmoothness value | Description | Output |
|-------- | -------- | -------- |
| [SymmetricDistance](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSmoothness.html#Syncfusion_Blazor_Diagram_BezierSmoothness_SymmetricDistance)| Both control points of adjacent segments will be at the same distance when one of them is editing. | ![SymmetricDistance](../../../../images/SymmetricDistance.png) |
| [SymmetricAngle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSmoothness.html#Syncfusion_Blazor_Diagram_BezierSmoothness_Both) | Both control points of adjacent segments will be at the same angle when one of them is editing. | ![SymmetricAngle](../../../../images/SymmetricAngle.gif) |
| [SymmetricAngle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSmoothness.html#Syncfusion_Blazor_Diagram_BezierSmoothness_) | Both control points of adjacent segments will be at the same angle when one of them is editing. | ![SymmetricAngle](../../../../images/SymmetricAngle.gif) |
| [Both](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSmoothness.html#Syncfusion_Blazor_Diagram_BezierSmoothness_Both) | Both control points of adjacent segments will be at the same angle and same distance when one of them is editing. | ![Symmetric](../../../../images/SmoothnessBoth.png) |
| [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSmoothness.html#Syncfusion_Blazor_Diagram_BezierSmoothness_None) | Segment’s control points interact independently from each other. | ![SymmetricNone](../../../../images/SymmetricNone.gif)


## How to Show or Hide Bezier Segment's Control Points

By using the [BezierConnectorSettings.ControlPointsVisibility](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierConnectorSettings.html#Syncfusion_Blazor_Diagram_BezierConnectorSettings_ControlPointsVisibility) property of the Connector class, you can enable or disable the visibility of the bezier segment's control points.

| ControlPointsVisibility value | Description | Output |
|-------- | -------- | -------- |
| [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ControlPointsVisibility.html#Syncfusion_Blazor_Diagram_ControlPointsVisibility_None) | Hides all control points of the bezier connector. | ![None](../../../../images/ControlpointsvisibilityNone.png) |
| [Source](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ControlPointsVisibility.html#Syncfusion_Blazor_Diagram_ControlPointsVisibility_Source) | Shows control points of the source segment and hides all other control points in a bezier connector. | ![Source](../../../../images/ControlpointsvisibilitySource.png) |
| [Target](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ControlPointsVisibility.html#Syncfusion_Blazor_Diagram_ControlPointsVisibility_Target) | Shows control points of the target segment and hides all other control points in a bezier connector. | ![Target](../../../../images/ControlpointsvisibilityTarget.png) |
| [Intermediate ](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ControlPointsVisibility.html#Syncfusion_Blazor_Diagram_ControlPointsVisibility_Intermediate)| Shows control points of the intermediate segments and hides all other control points in a bezier connector. | ![Intermediate](../../../../images/ControlpointsvisibilityIntermediate.png) |
| [All](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ControlPointsVisibility.html#Syncfusion_Blazor_Diagram_ControlPointsVisibility_All) | Shows all the control points of the bezier connector, including the source, target, and intermediate segments' control points. | ![All](../../../../images/ControlpointsvisibilityAll.png) |

```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors"></SfDiagramComponent>
@code {
    //Define the diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Connector connector1 = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint() { X = 700, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 1000, Y = 400 },
            Segments = new DiagramObjectCollection<ConnectorSegment>()
            {
                new BezierSegment(){Type = ConnectorSegmentType.Bezier, Point = new DiagramPoint(){X = 750, Y = 250}},
                new BezierSegment(){Type = ConnectorSegmentType.Bezier, Point = new DiagramPoint(){X = 900, Y = 350}}
            },
            Type = ConnectorSegmentType.Bezier,
            BezierConnectorSettings = new BezierConnectorSettings() 
            {
                //Define the visibility of the control points. 
                ControlPointsVisibility = ControlPointsVisibility.Intermediate 
            },
        };
        connectors.Add(connector1);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Segments).
