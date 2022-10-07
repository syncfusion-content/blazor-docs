---
layout: post
title: Tooltip in Blazor Diagram Component | Syncfusion
description: Checkout and learn all about the Tooltip support in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Tooltip in Blazor Diagram Component

In a Graphical User Interface (GUI), a tooltip is a message that is displayed when the mouse is hovered over an element. The diagram provides tooltip support when dragging, resizing or rotating a node, and when the mouse hovers any diagram element.

## Default tooltip

By default, the diagram displays a tooltip that provides information about the size, position, and angle when dragging, resizing, and rotating diagram elements. The following images illustrate how the diagram displays the node information during an interaction.

| Drag | Resize | Rotate |
|------|--------|--------|
|![ToolTip During Drag](images/Drag.png) | ![ToolTip During Resize](images/Resize.png) | ![ToolTip During Rotate](images/Rotate.png) |

## Tooltip for a specific nodes/connectors

The diagram provides support to show tooltip when the mouse hovers over any node/connector.The tooltip can be customized for each node and connector.

The following code example illustrates how to customize the tooltip for nodes.

```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent Width="1000px" Height="500px" Nodes="@nodes" />
@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
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
            Tooltip = new DiagramTooltip(){Content="NodeTooltip"},
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        nodes.Add(node);
    }
}
```
|![ToolTip During hover the node](images/blazor-diagram-nodetooltip.png) | 

The following code example illustrates how to customize the tooltip for connectors.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<SfDiagramComponent Width="1000px" Height="500px" Connectors="connector" />
@code
{
    DiagramObjectCollection<Connector> connector;

    protected override void OnInitialized()
    {
        connector = new DiagramObjectCollection<Connector>();
        Connector connectors = new Connector()
        {
            ID = "Connector1",
            SourcePoint = new DiagramPoint() { X = 500, Y = 500 },
            TargetPoint = new DiagramPoint() { X = 600, Y = 400 },
            Tooltip = new DiagramTooltip(){Content="ConnectorTooltip"},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
        connector.Add(connectors);
    }
}
```
|![ToolTip During hover the node](images/blazor-diagram-connectortooltip.png) | 

## How to set tooltip position for nodes/connectors

Tooltips can be attached to 12 static locations around the target. On initializing the Tooltip, set the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramTooltip.html#Syncfusion_Blazor_Diagram_DiagramTooltip_Position) property with any one of the following values:

* `TopLeft`
* `TopCenter`
* `TopRight`
* `BottomLeft`
* `BottomCenter`
* `BottomRight`
* `LeftTop`
* `LeftCenter`
* `LeftBottom`
* `RightTop`
* `RightCenter`
* `RightBottom`

> By default, Tooltip is placed at the `BottomRight` of the target element.

The following code example is used to set tooltip position for nodes.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Node Position" @onclick="PositionChange" />
<SfDiagramComponent Width="1000px" Height="500px" Nodes="@nodes" />
@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
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
            Tooltip = new DiagramTooltip(){Content="NodeTooltip",Position=Position.TopCenter},
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        nodes.Add(node);
    }
    //Change position at run time
    private void PositionChange()
    {
        nodes[0].Tooltip.Position = Position.RightCenter;
    }
}
```

The following code example is used to set tooltip position for connectors.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Connector Position" @onclick="PositionChange" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="connector" />
@code
{
    DiagramObjectCollection<Connector> connector;

    protected override void OnInitialized()
    {
        connector = new DiagramObjectCollection<Connector>();
        Connector connectors = new Connector()
        {
            ID = "Connector1",
            SourcePoint = new DiagramPoint() { X = 500, Y = 500 },
            TargetPoint = new DiagramPoint() { X = 600, Y = 400 },
            Tooltip = new DiagramTooltip(){Content="ConnectorTooltip",Position=Position.TopCenter},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
        connector.Add(connectors);
    }
     //Change position at run time
    private void PositionChange()
    {
        connector[0].Tooltip.Position = Position.RightCenter;
    }
}
```

## How to set tooltip content for nodes/connectors

A text or a piece of information assigned to the Tooltip’s [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramTooltip.html#Syncfusion_Blazor_Diagram_DiagramTooltip_Content) property will be displayed as the main content of the Tooltip for nodes/connectors.

The following code example is used to set tooltip content for nodes.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Node Content" @onclick="ContentChange" />
<SfDiagramComponent Width="1000px" Height="500px" Nodes="@nodes" />
@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
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
            Tooltip = new DiagramTooltip(){Content="NodeTooltip"},
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        nodes.Add(node);
    }
    //Change Content at run time
    private void ContentChange()
    {
        nodes[0].Tooltip.Content = "UpdateTooltipContent";
    }
}
```

The following code example is used to set tooltip content for connectors.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Connector Content" @onclick="ContentChange" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="connector" />
@code
{
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connector;

    protected override void OnInitialized()
    {
        connector = new DiagramObjectCollection<Connector>();
        Connector connectors = new Connector()
        {
            ID = "Connector1",
            SourcePoint = new DiagramPoint() { X = 500, Y = 500 },
            TargetPoint = new DiagramPoint() { X = 600, Y = 400 },
            Tooltip = new DiagramTooltip(){Content="ConnectorTooltip"},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
        connector.Add(connectors);
    }
    //Change Content at run time
    private void ContentChange()
    {
        connector[0].Tooltip.Content = "UpdateTooltipContent";
    }
}
```

## How to shows/hides the tip pointer for tooltip

[ShowTipPointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramTooltip.html#Syncfusion_Blazor_Diagram_DiagramTooltip_ShowTipPointer) property value is true, if the tip pointer is visible; otherwise, false.

The following code example is used to set tooltip tip pointer for nodes.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Node TipPointer" @onclick="TipPointerChange" />
<SfDiagramComponent Width="1000px" Height="500px" Nodes="@nodes" />
@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
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
            Tooltip = new DiagramTooltip(){Content="NodeTooltip",ShowTipPointer=true},
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        nodes.Add(node);
    }
    //Change TipPointer at run time
    private void TipPointerChange()
    {
        nodes[0].Tooltip.ShowTipPointer = false;
    }
}
```
The following code example is used to set tooltip tip pointer for connectors.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Connector TipPointer" @onclick="TipPointerChange" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="connector" />
@code
{
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connector;

    protected override void OnInitialized()
    {
        connector = new DiagramObjectCollection<Connector>();
        Connector connectors = new Connector()
        {
            ID = "Connector1",
            SourcePoint = new DiagramPoint() { X = 500, Y = 500 },
            TargetPoint = new DiagramPoint() { X = 600, Y = 400 },
            Tooltip = new DiagramTooltip(){Content="ConnectorTooltip",ShowTipPointer=true},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
        connector.Add(connectors);
    }
    //Change TipPointer at run time
    private void TipPointerChange()
    {
        connector[0].Tooltip.ShowTipPointer = false;
    }
}
```

## Tooltip template content

To customize the tooltip content or to create your own visualized element on the tooltip, [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramTooltip.html#Syncfusion_Blazor_Diagram_DiagramTooltip_Template) can be used.

The following code example illustrates how to add formatted template content to the tooltip for nodes.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Node Template" @onclick="TemplateChange" />
<SfDiagramComponent Width="1000px" Height="500px" Nodes="@nodes" />
@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
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
            Tooltip = new DiagramTooltip(){Content="NodeTooltip",Template=getContent()},
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        nodes.Add(node);
    }
    private string getContent()
    {
        string content = "<div><p>Product Name : Diagram</p><p>Element: Node</p><p>Content: Node Tooltip <p></p></div>";
        return content;
    }
    //Change Template at run time
    private void TemplateChange()
    {
        nodes[0].Tooltip.Template = "<p>TemplateUpdate</p>";
    }
}
```

The following code example illustrates how to add formatted template content to the tooltip for connectors.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Connector Template" @onclick="TemplateChange" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="connector" />
@code
{
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connector;

    protected override void OnInitialized()
    {
        connector = new DiagramObjectCollection<Connector>();
        Connector connectors = new Connector()
        {
            ID = "Connector1",
            SourcePoint = new DiagramPoint() { X = 500, Y = 500 },
            TargetPoint = new DiagramPoint() { X = 600, Y = 400 },
            Tooltip = new DiagramTooltip(){Content="ConnectorTooltip",Template=getContent()},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
        connector.Add(connectors);
    }
   private string getContent()
    {
        string content = "<div><p>Product Name : Diagram</p><p>Element: Connector</p><p>Content: Connector Tooltip <p></p></div>";
        return content;
    }
    //Change Template at run time
    private void TemplateChange()
    {
        connector[0].Tooltip.Template = "<p>TemplateUpdate</p>";
    }
}
```

## Tooltip animation

To animate the tooltip, a set of specific animation effects are available, and it can be controlled by using the animation property. The [Animation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramTooltip.html#Syncfusion_Blazor_Diagram_DiagramTooltip_AnimationSettings) property also allows you to set delay, duration, and various other effects of your choice.

The following code example illustrates how to set animation to the tooltip for nodes.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Node Animation" @onclick="AnimationChange" />
<SfDiagramComponent Width="1000px" Height="500px" Nodes="@nodes" />
@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
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
            Tooltip = new DiagramTooltip(){Content="NodeTooltip",AnimationSettings = new AnimationModel()
            {
               Open = new TooltipAnimationSettings(){Effect = Effect.None},
                Close = new TooltipAnimationSettings(){Effect = Effect.None}
            }},
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        nodes.Add(node);
    }
    //Change Animation at run time
    private void AnimationChange()
    {
        nodes[0].Tooltip.AnimationSettings = new AnimationModel()
            {
                Open = new TooltipAnimationSettings() { Effect = Effect.FadeZoomIn, Duration = 100 },
                Close = new TooltipAnimationSettings() { Effect = Effect.FadeZoomOut, Duration = 50 }
            };
    }
}
```

The following code example illustrates how to set animation to the tooltip for connectors.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Connector Animation" @onclick="AnimationChange" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="connector" />
@code
{
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connector;

    protected override void OnInitialized()
    {
        connector = new DiagramObjectCollection<Connector>();
        Connector connectors = new Connector()
        {
            ID = "Connector1",
            SourcePoint = new DiagramPoint() { X = 500, Y = 500 },
            TargetPoint = new DiagramPoint() { X = 600, Y = 400 },
            Tooltip = new DiagramTooltip(){Content="ConnectorTooltip",AnimationSettings = new AnimationModel()
            {
               Open = new TooltipAnimationSettings(){Effect = Effect.None},
                Close = new TooltipAnimationSettings(){Effect = Effect.None}
            }},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
        connector.Add(connectors);
    }
    //Change Animation at run time
    private void AnimationChange()
    {
        connector[0].Tooltip.AnimationSettings = new AnimationModel()
            {
                Open = new TooltipAnimationSettings() { Effect = Effect.ZoomIn, Duration = 500 },
                Close = new TooltipAnimationSettings() { Effect = Effect.ZoomOut, Duration = 500 }
            };
    }
}
```

## Tooltip Open Mode

The mode on which the Tooltip is to be opened on a page, i.e., on hovering, focusing, or clicking on the target elements can be decided. On initializing the Tooltip, set the [OpensOn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramTooltip.html#Syncfusion_Blazor_Diagram_DiagramTooltip_OpensOn) property with any one of the following values:

* `Auto`
* `Hover`
* `Custom`
* `Click`


> By default, Tooltip is open mode is `Auto`.

The following code example illustrates how to set open mode to the tooltip for nodes.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Show CustomTooltip" @onclick="show" />
<input type="button" value="Hide CustomTooltip" @onclick="hide" />
<SfDiagramComponent @ref="@diagram" Width="1000px" Height="500px" Nodes="@nodes" />
@code
{
    DiagramObjectCollection<Node> nodes;
    SfDiagramComponent diagram;
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            },
            Tooltip = new DiagramTooltip(){Content="Auto",OpensOn="Auto",Position=Position.BottomCenter},
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        Node node1 = new Node()
        {
            ID = "node2",
            OffsetX = 250,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            },
            Tooltip = new DiagramTooltip(){Content="Hover",OpensOn="Hover"},
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        Node node2 = new Node()
        {
            ID = "node3",
            OffsetX = 400,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            },
            Tooltip = new DiagramTooltip(){Content="Custom",OpensOn="Custom"},
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        Node node3 = new Node()
        {
            ID = "node4",
            OffsetX = 550,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            },
            Tooltip = new DiagramTooltip() { Content = "Click", OpensOn = "Click" },
            Constraints = NodeConstraints.Default|NodeConstraints.Tooltip,
        };
        nodes.Add(node);
        nodes.Add(node1);
        nodes.Add(node2);
        nodes.Add(node3);
    }
   
    private  void show()
    {
        diagram.ShowTooltip(diagram.Nodes[2] as NodeBase);
    }
    private  void hide()
    {
       diagram.HideTooltip(diagram.Nodes[2] as NodeBase);
    }
}
```
|![ToolTip During hover the node with open mode](images/blazor-diagram-openmodenodetooltip.gif) | 

The following code example illustrates how to set open mode to the tooltip for connectors.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<input type="button" value="Show CustomTooltip" @onclick="show" />
<input type="button" value="Hide CustomTooltip" @onclick="hide" />
<SfDiagramComponent @ref="@diagram" Width="1000px" Height="500px" Connectors="connector" />
@code
{
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connector;
    SfDiagramComponent diagram;
    protected override void OnInitialized()
    {
        connector = new DiagramObjectCollection<Connector>();
        Connector connectors = new Connector()
        {
            ID = "Connector1",
            SourcePoint = new DiagramPoint() { X = 100, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 100 },
            Tooltip = new DiagramTooltip(){Content="Auto",OpensOn="Auto"},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
         Connector connectors1 = new Connector()
        {
            ID = "Connector2",
            SourcePoint = new DiagramPoint() { X = 300, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 400, Y = 100 },
            Tooltip = new DiagramTooltip(){Content="Hover",OpensOn="Hover"},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
          Connector connectors2 = new Connector()
        {
            ID = "Connector3",
            SourcePoint = new DiagramPoint() { X = 500, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 600, Y = 100 },
            Tooltip = new DiagramTooltip(){Content="Custom",OpensOn="Custom"},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
          Connector connectors3 = new Connector()
        {
            ID = "Connector4",
            SourcePoint = new DiagramPoint() { X = 700, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 800, Y = 100 },
            Tooltip = new DiagramTooltip(){Content="Click",OpensOn="Click"},
            Constraints =  ConnectorConstraints.Default|ConnectorConstraints.Tooltip ,
        };
        connector.Add(connectors);
        connector.Add(connectors1);
        connector.Add(connectors2);
        connector.Add(connectors3);
    }
    
    private  void show()
    {
        diagram.ShowTooltip(diagram.Connectors[2] as NodeBase);
    }
    private void hide()
    {
       diagram.HideTooltip(diagram.Connectors[2] as NodeBase);
    }
}
```

