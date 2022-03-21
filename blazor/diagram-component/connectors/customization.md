---
layout: post
title: Customization in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Customization in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Customization in Blazor Diagram Component

## Decorator

Diagram allows you to customize the connector appearances. The following topics shows how to customize several properties of the connectors.

* Starting and ending points of a connector can be decorated with some customizable shapes like arrows, circles, diamond, or path. The connection end points can be decorated with the [SourceDecorator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_SourceDecorator) and [TargetDecorator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_TargetDecorator) properties of the connector.

* The [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DecoratorSettings.html#Syncfusion_Blazor_Diagram_DecoratorSettings_Shape) property of SourceDecorator allows to define the shape of the source decorator. Similarly, the Shape property of TargetDecorator allows to define the shape of the target decorator.

* To create custom shape for source decorator, use [PathData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DecoratorSettings.html#Syncfusion_Blazor_Diagram_DecoratorSettings_PathData) property. Similarly, to create custom shape for target decorator, use PathData property.

* The following code example illustrates how to create decorators of various shapes.

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
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            Style = new ShapeStyle() { StrokeColor = "#6f409f", StrokeWidth = 1 },
            Type = ConnectorSegmentType.Orthogonal,
            SourceDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Circle,
                Style = new ShapeStyle() { StrokeColor = "#37909A", Fill = "#37909A", StrokeWidth = 1 }
            },
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Custom,
                PathData = "M80.5,12.5 C80.5,19.127417 62.59139,24.5 40.5,24.5 C18.40861,24.5 0.5,19.127417 0.5,12.5 C0.5,5.872583 18.40861,0.5 40.5,0.5 C62.59139,0.5 80.5,5.872583 80.5,12.5 z",
                Style = new ShapeStyle()
                {
                    StrokeColor = "#37909A",
                    Fill = "#37909A",
                    StrokeWidth = 1,
                }
            }
        };
        connectors.Add(Connector);
    }
}
```

### Decorator appearance

* The source decorator’s [StrokeColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeColor), [StrokeWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeWidth), and [StrokeDashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeDashArray) properties are used to customize the color, width, and appearance of the decorator.

* To set the border stroke color, stroke width, and stroke dash array for the target decorator, use StrokeColor, StrokeWidth, and StrokeDashArray.

* To set the size for source and target decorator, use [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DecoratorSettings.html#Syncfusion_Blazor_Diagram_DecoratorSettings_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DecoratorSettings.html#Syncfusion_Blazor_Diagram_DecoratorSettings_Height) properties.

The following code example illustrates how to customize the appearance of the decorator.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        {
            ID = "connector1",
            Style = new ShapeStyle()
            {
                Fill = "#6495ED",
                StrokeColor = "#6495ED",
                StrokeWidth = 1
            },
            SourcePoint = new DiagramPoint()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            Type = ConnectorSegmentType.Orthogonal,
            SourceDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Height = 15,
                Width = 15,
                Style = new ShapeStyle() { StrokeColor = "blue", Fill = "yellow", StrokeWidth = 3 }
            },
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Height = 15,
                Width = 15,
                Style = new ShapeStyle()
                {
                    StrokeColor = "red",
                    Fill = "yellow",
                    StrokeWidth = 3
                }
            }

        };
        connectors.Add(Connector);
    }
}
```

![Blazor Diagram Connector with Decorator](../images/blazor-diagram-decorator.png)

## Padding

Padding is used to leave the space between the Connector's end point and the object to where it is connected.

* The [SourcePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_SourcePadding) property of connector defines space between the source point and the source node of the connector.

* The [TargetPadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_TargetPadding) property of connector defines space between the end point and the target node of the connector.

* The following code example illustrates how to leave space between the connection end points and source, target nodes.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    //Defines diagram's nodes collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>() 
        {
          new Node() 
          {
                OffsetX = 100,
                OffsetY = 100,
                Height = 50,
                Width = 100,
                ID = "node1",
                Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7" },
                Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
          },
          new Node() 
          {   
                OffsetX = 300,
                OffsetY = 300,
                Height = 50,
                Width = 100,
                ID = "node2",
                Style = new ShapeStyle(){ Fill = "#6BA5D7", StrokeColor = "#6BA5D7" },
                Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
          }
        };
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourceID = "node1",
            TargetID = "node2",
            //Specifies the source and target padding values.
            SourcePadding = 20,
            TargetPadding = 20,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7", StrokeWidth = 1 }
            },
            Style = new ShapeStyle()
            {
                StrokeColor = "#6BA5D7",
                StrokeWidth = 1
            },
            Type = ConnectorSegmentType.Orthogonal
        };
        connectors.Add(Connector);
    }
}
```

![Blazor Diagram Connector with Padding](../images/blazor-diagram-connector-padding.png)

## Bridging

Line bridging creates a bridge for lines to smartly cross over the other lines, at points of intersection. By default, [BridgeDirection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_BridgeDirection) is set to [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Direction.html#Syncfusion_Blazor_Diagram_Direction_Top). Depending upon the direction given bridging direction appears. Bridging can be enabled/disabled either with the [Connector.Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorConstraints.html) or [Diagram.Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramConstraints.html). The following code example illustrates how to enable line bridging.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px"@bind-Constraints="@diagramConstraints" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    DiagramConstraints diagramConstraints = DiagramConstraints.Default | DiagramConstraints.Bridging;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector1 = new Connector()
        {
            ID = "connector1",
            // Bridge space value has been defined.
            BridgeSpace = 20,
            Style = new ShapeStyle()
            {
                Fill = "#6495ED",
                StrokeColor = "#6495ED",
                StrokeWidth = 1
            },
            SourcePoint = new DiagramPoint()
            {
                X = 200 , Y = 200
            },
            TargetPoint = new DiagramPoint()
            {
                X = 400,
                Y = 200
            },
            Type = ConnectorSegmentType.Orthogonal,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow ,
                Style = new ShapeStyle()
                {
                    Fill = "#6495ED",
                    StrokeColor = "#6495ED",
                    StrokeWidth = 1
                }
            }
        };
        connectors.Add(Connector1);
        Connector Connector2 = new Connector()
        {
            ID = "connector2",
            Style = new ShapeStyle()
            {
                Fill = "#6495ED",
                StrokeColor = "#6495ED",
                StrokeWidth = 1
            },
            SourcePoint = new DiagramPoint()
            {
                X = 300,
                Y = 100
            },
            TargetPoint = new DiagramPoint()
            {
                X = 300,
                Y = 300
            },
            Type = ConnectorSegmentType.Orthogonal,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Style = new ShapeStyle()
                {
                    Fill = "#6495ED",
                    StrokeColor = "#6495ED",
                    StrokeWidth = 1
                }
            }
        };
        connectors.Add(Connector2);
    }
}
```

The [BridgeSpace](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_BridgeSpace) property of connectors can be used to define the width for line bridging. By default, the BridgeSpace value is 10px.

Limitation: [BezierSegment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BezierSegment.html) do not support bridging.

![Blazor Diagram Connector with Line Bridge](../images/blazor-diagram-connector-with-bridging.png)

## Corner radius

Corner radius allows to create connectors with rounded corners. The radius of the rounded corner is set with the [CornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_CornerRadius) property.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px"  Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        {
            ID = "connector1",
            Style = new ShapeStyle()
            {
                Fill = "#6495ED",
                StrokeColor = "#6495ED",
                StrokeWidth = 1
            },
            SourcePoint = new DiagramPoint()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            //Specify the corner radius value.
            CornerRadius = 10,
            Type = ConnectorSegmentType.Orthogonal,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Style = new ShapeStyle()
                {
                    Fill = "#6495ED",
                    StrokeColor = "#6495ED",
                    StrokeWidth = 1
                }
            }
        };
        connectors.Add(Connector);
    }
}
```

![Blazor Diagram Connector with Corner Radius](../images/blazor-diagram-connector-with-corner-radious.png)

## Appearance

* The connector’s [StrokeWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeWidth), [StrokeColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeColor), [StrokeDashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeDashArray), and [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_Opacity) properties are used to customize the appearance of the connector segments.

* The [IsVisible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeBase.html#Syncfusion_Blazor_Diagram_NodeBase_IsVisible) property of the connector indicates whether the connector is visible in the user interface or not.

* Default values for all the [Connectors](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html) can be set by using the [ConnectorCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ConnectorCreating) event callback method. For example, if all connectors have the same type or property then such properties can be moved into ConnectorCreating.

### Segment appearance

The following code example illustrates how to customize the segment appearance.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector1 = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            Style = new ShapeStyle()
            {
                StrokeColor = "red",
                StrokeWidth = 2,
                StrokeDashArray = "2,2"
            },
            Type = ConnectorSegmentType.Orthogonal,
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
        connectors.Add(Connector1);
    }
}
```

### Decorator appearance

* The source decorator’s [StrokeColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeColor), [StrokeWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeWidth) and [StrokeDashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeDashArray) properties are used to customize the color, width, and appearance of the decorator.

* To set the border stroke color, stroke width, and stroke dash array for the target decorator, use StrokeColor, StrokeWidth, and StrokeDashArray.

* To set the size for source and target decorator, use [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DecoratorSettings.html#Syncfusion_Blazor_Diagram_DecoratorSettings_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DecoratorSettings.html#Syncfusion_Blazor_Diagram_DecoratorSettings_Height) properties.

The following code example illustrates how to customize the appearance of the decorator.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        {
            ID = "connector1",
            Style = new ShapeStyle()
            {
                Fill = "#6495ED",
                StrokeColor = "#6495ED",
                StrokeWidth = 1
            },
            SourcePoint = new DiagramPoint()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            Type = ConnectorSegmentType.Orthogonal,
            SourceDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Height = 15,
                Width = 15,
                Style = new ShapeStyle()
                { StrokeColor = "blue", Fill = "yellow", StrokeWidth = 3 }
            },
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Height = 15,
                Width = 15,
                Style = new ShapeStyle()
                {
                    StrokeColor = "red",
                    Fill = "yellow",
                    StrokeWidth = 3
                }
            }
        };
        connectors.Add(Connector);
    }
}
```

![Blazor Diagram Connector with Decorator](../images/blazor-diagram-decorator.png)

## Constraints

* The [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorConstraints.html) property of connector allows to enable/disable certain features of connectors.

* To enable or disable the constraints, refer [Connector Constraints](../constraints).

The following code illustrates how to disable selection.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
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
            TargetPoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            Type = ConnectorSegmentType.Orthogonal,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Style = new ShapeStyle()
                {
                    Fill = "black",
                    StrokeColor = "black",
                    StrokeWidth = 1
                }
            },
            Style = new ShapeStyle()
            {
                StrokeColor = "black",
                StrokeWidth = 1
            },
            //Disable the select constraint.
            Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Select,
        };
        connectors.Add(Connector);
    }
}
```

## Custom properties

* The [AdditionalInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeBase.html#Syncfusion_Blazor_Diagram_NodeBase_AdditionalInfo) property of connector allows you to maintain additional information to the connectors.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Dictionary<string, object> ConnectorInfo = new Dictionary<string, object>();
        ConnectorInfo.Add("connectorInfo", "Central Connector");
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            Type = ConnectorSegmentType.Orthogonal,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
                Style = new ShapeStyle()
                {
                    Fill = "black",
                    StrokeColor = "black",
                    StrokeWidth = 1
                }
            },
            Style = new ShapeStyle()
            {
                StrokeColor = "black",
                StrokeWidth = 1
            },
            //Define the add info value.
            AdditionalInfo = ConnectorInfo
        };
        connectors.Add(Connector);
    }
}
```

## See also

* [How to interact with the connector](./interactions)

* [How to change the segments](./segments)

* [How to get the connector events](./events)
