---
layout: post
title: Straight Segment in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Segments in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

## How to create bezier segment

Bezier segments are used to create curve segments and the curves are configurable either with the control points or with vectors. To create a bezier segment, the Type of the segment is set as [Bezier](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorSegmentType.html#Syncfusion_Blazor_Diagram_ConnectorSegmentType_Bezier) and need to specify type for the connector. The following code example illustrates how to create a default bezier segment.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
     //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 100,
                Y = 100
            },
            Style = new ShapeStyle() { StrokeColor = "#6f409f", StrokeWidth = 1 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            Type = ConnectorSegmentType.Bezier,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Style = new ShapeStyle()
                {
                    Fill = "#6f409f",
                    StrokeColor = "#6f409f",
                    StrokeWidth = 1
                }
            }
        };
        //Add the connector into connectors's collection.
        connectors.Add(Connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Segments/Bezier)

![Connector with Bezier Segment in Blazor Diagram](../../images/blazor-diagram-connector-with-bezier.png)

 [Point1](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSegment.html#Syncfusion_Blazor_Diagram_BezierSegment_Point1) and [Point2](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSegment.html#Syncfusion_Blazor_Diagram_BezierSegment_Point2) properties are used to control the points of the bezier connector, and [vector1](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSegment.html#Syncfusion_Blazor_Diagram_BezierSegment_Vector1) and [Vector2](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSegment.html#Syncfusion_Blazor_Diagram_BezierSegment_Vector2) properties are used to define the length and angle between the source point and target point, respectively. The following code example illustrates how to use these properties in our control.

```cshtml
Connector Connector1 = new Connector()
        {
            ID = "Connector1",
            Type = ConnectorSegmentType.Bezier,
            SourcePoint = new DiagramPoint { X = 500, Y = 200 },
            TargetPoint = new DiagramPoint { X = 600, Y = 300 },
            Segments = new DiagramObjectCollection<ConnectorSegment>
            {
                new BezierSegment() 
                {
                    Type = ConnectorSegmentType.Bezier,
                    //Defines the point1 and point2 for the bezier connector.
                    Point1 = new DiagramPoint { X = 500, Y = 100 },
                    Point2 = new DiagramPoint { X = 600, Y = 200 }
                }
            }
        };
         Connector Connector2 = new Connector()
         {
            ID = "Connector2",
            Type = ConnectorSegmentType.Bezier,
            SourcePoint = new DiagramPoint { X = 200, Y = 100 },
            TargetPoint = new DiagramPoint { X = 300, Y = 200 },
            Segments = new DiagramObjectCollection<ConnectorSegment>
            {
                new BezierSegment()
                {
                    Type = ConnectorSegmentType.Bezier,
                    //Defines the Vector1 and Vector2 for the bezier connector.
                    Vector1 = new Vector(){Distance = 100 ,Angle = 90 },
                    Vector2 = new Vector(){Distance = 45 ,Angle = 45 }
                }
            }
        };
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Segments)


### Bezier Segment Editing

* A segment control point of the Bezier connector is used to change the bezier vectors and points of the connector.

![Editing Bezier Segment in Blazor Diagram](../../images/blazor-diagram-edit-bezier-segment.gif)