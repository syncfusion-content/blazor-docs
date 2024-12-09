---
layout: post
title: Constraints in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Constraints in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Constraints in Blazor Diagram Component

Constraints are used to enable or disable certain behaviors of the diagram, nodes, and connectors. Constraints are provided as flagged enumerations, so that multiple behaviors can be enabled or disabled using the Bitwise operators `(&, |, ~, <<, etc.)`.

To know more about Bitwise operators, refer to the [Bitwise Operations](constraints#bitwise-operations).

## Diagram constraints

[DiagramConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramConstraints.html#Syncfusion_Blazor_Diagram_DiagramConstraints) allow you to enable or disable the following behaviors. 

* PageEditable
* Bridging
* Zoom
* UndoRedo
* UserInteraction
* Tooltip

| Constraints | Description |
| -------- | -------- |
|None|Disable all diagram functionalities.|
|Bridging|Enables or disables Bridging support for connector in diagram.|
|Undo/redo|Enables or disables the Undo/Redo support for the diagram.|
|UserInteraction|Enables or disables user interaction support for the diagram.|
|ApiUpdate|Enables or disables update API support for the diagram.|
|PageEditable|Enables or disables Page Editable support for the diagram.|
|Zoom|Enables or disables Zoom support for the diagram.|
|PanX|Enables or disables Panning X coordinate support for the diagram.|
|PanY|Enables or disables Panning Y coordinate support for the diagram.|
|Pan|Enables or disables panning both X and Y coordinates support for the diagram.|
|ZoomTextEdit|Enables or disables zooming the text box while editing the text.|
|Tooltip|Enables or disables the tooltip for the diagram elements(Nodes and connectors).|
|Routing|Determines if automatic line routing is enabled or disabled for connectors. When enabled, lines are automatically routed to avoid overlapping with nodes and other obstacles.|
|Default|Enables or disables all constraints in diagram.|

The following example shows how to disable PageEditable constraint from default diagram constraints.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the diagram with constraints *@
<SfDiagramComponent Height="600px" Nodes="@nodes" 
Constraints="@DiagramConstraints" />

@code
{
    //Sets the Diagram constraints.
    DiagramConstraints DiagramConstraints = DiagramConstraints.Default & ~DiagramConstraints.PageEditable;
    //Initialize the Nodes Collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        nodes.Add(node);
    }
}
```

The following example shows how to add Bridging constraint to the default constraints of diagram.

```csharp
DiagramConstraints DiagramConstraints = DiagramConstraints.Default | DiagramConstraints.Bridging;
```

The diagram constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](constraints#bitwise-operations) in the diagram.

```csharp
//Removing multiple constraints from default.
DiagramConstraints DiagramConstraints = DiagramConstraints.Default & ~(DiagramConstraints.PageEditable|DiagramConstraints.Zoom);
```

For more information about diagram constraints, refer to the [Diagram constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramConstraints.html).

N> By default, the following constraints are enabled in the diagram,
<br/>* ApiUpdate
<br/>* PanX
<br/>* PanY
<br/>* Pan
<br/>* ZoomTextEdit
<br/>* Default
<br/>* None
<br/>* Tooltip

## Node constraints

The [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_Constraints) property of the Node allows you to enable or disable the following behaviors. 

* Select
* Drag
* Resize
* Rotate
* Delete
* InConnect
* OutConnect
* Tooltip

| Constraints | Description |
| -------- | -------- |
|None|Disable all node Constraints|
|Select|Enables or disables the node to be selected.|
|Drag|Enables or disables the node to be dragged.|
|Rotate|Enables or disables the node to be rotated.|
|Shadow|Enables or disables the node to display shadow.|
|PointerEvents|Enables or disables the node to provide pointer option.|
|Delete|Enables or disables node to be deleted.|
|InConnect|Enables or disables node to provide in connect option.|
|OutConnect|Enables or disables node to provide out connect option.|
|AllowDrop|Enables node to provide allow to drop option.|
|ResizeNorthEast|Enable or disable to resize NorthEast side of the node.|
|ResizeEast|Enable or disable to resize East side of the node.|
|ResizeSouthEast|Enable or disable to resize SouthEast side of the node.|
|ResizeSouth|Enable or disable to resize South side of the node.|
|ResizeSouthWest|Enable or disable to resize SouthWest side of the node.|
|ResizeWest|Enable or disable to resize West side of the node.|
|ResizeNorthWest|Enable or disable to resize NorthWest side of the node.|
|ResizeNorth|Enable or disable to resize North side of the node.|
|AspectRatio|Enables the Aspect ratio of the node.|
|ReadOnly|Enables the ReadOnly support for annotation in the node.|
|HideThumbs|Enable to hide all resize thumbs for the node.|
|Tooltip|Enables or disables tooltip for the Nodes.|
|InheritTooltip|Enables or disables inherit tooltip option from the parent object.|
|Resize|Enables or Disables the expansion or compression of a node.|
|Inherit|Enables the node to inherit the interaction option from the parent object.|
|Default|Enables all default constraints for the node.|

The following example shows how to disable rotate constraint from the default node constraints.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the diagram with NodeCollection *@
<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "White" },
            //Sets the NodeConstraints constraints.
            Constraints = NodeConstraints.Default & ~NodeConstraints.Rotate
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Constraints/NodeConstraints)

![Node Constraints in Blazor Diagram](images/blazor-diagram-node-constraints.png)

The following example shows how to add Shadow constraint to the default constraints of node.

```csharp
NodeConstraints NodeConstraints = NodeConstraints.Default | NodeConstraints.Shadow;
```

The node constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](constraints#bitwise-operations).

```csharp
 //Removing multiple constraints from default.
NodeConstraints NodeConstraints = NodeConstraints.Default & ~ (NodeConstraints.Select | NodeConstraints.Drag);
```
The following code example shows how the tooltip can be enabled for the node.

```csharp
//Enabled the tooltip constraints for the node.
node.Constraints = NodeConstraints.Default | NodeConstraints.Tooltip;
```

For more information about node constraints, refer to the [NodeConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeConstraints.html).

N>By default, the following constraints are enabled for the node,
<br/>* Shadow
<br/>* PointerEvents
<br/>* AllowDrop
<br/>* ResizeNorthEast
<br/>* ResizeEast
<br/>* ResizeSouthEast
<br/>* ResizeSouth
<br/>* ResizeSouthWest
<br/>* ResizeWest
<br/>* ResizeNorthWest
<br/>* ResizeNorth
<br/>* AspectRatio
<br/>* ReadOnly
<br/>* HideThumbs
<br/>* Inherit
<br/>* Default

## Connector constraints

The [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_Constraints) property of the Connector allows you to enable or disable the following behaviors of connectors. 

* Select
* Drag
* DragSourceEnd
* DragTargetEnd
* Delete
* InheritBridging
* PointerEvents
* Tooltip

| Constraints | Description |
| -------- | -------- |
|None|Disable all connector Constraints.|
|Select|Enables or disables connector to be selected.|
|Delete|Enables or disables connector to be deleted.|
|Drag|Enables or disables connector to be dragged.|
|DragSourceEnd|Enables connectors source end to be selected.|
|DragTargetEnd|Enables connectors target end to be selected.|
|DragSegmentThumb|Enables control point and end point of every segment in a connector for editing.|
|Interaction|Enables or disables Interaction for the connector.|
|AllowDrop|Enables allow drop support to the connector.|
|Bridging|Enables bridging to the connector.|
|InheritBridging|Enables to inherit bridging option from the parent object.|
|PointerEvents|Enables to set the pointer events.|
|ConnectToNearByNode|Enables to connect to the nearest node.|
|ConnectToNearByPort|Enables to connect to the nearest port.|
|Tooltip|Enables or disables tooltip for the connectors.|
|InheritTooltip|Enables or disables inherit tooltip option from the parent object
|ConnectToNearByElement|Enables to connect to the nearest elements.|
|Routing|Determines if routing is enabled or disabled for the connector.|
|InheritRouting|Specifies whether the connector should inherit the routing value from the parent object.|
|InheritSegmentThumbShape|Indicates if the connector should inherit the segment thumb shape from the parent object.|
|ReadOnly|Enables or disables readonly for the connector.|
|Default|Enables all constraints for the connector.|

The following code shows how to disable select constraint from the default constraints of connector.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the diagram with connectors *@
<SfDiagramComponent Height="600px" Connectors="@connectors" />

@code
{
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            ID = "connector1",
            Type = ConnectorSegmentType.Straight,
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            //Sets the ConnectorConstraints.
            Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Select
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Constraints/ConnectorConstraints)

The following example shows how to add Bridging constraint to the default constraints of a connector.

```csharp
ConnectorConstraints ConnectorConstraints = ConnectorConstraints.Default | ConnectorConstraints.Bridging;
```

The connector constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](constraints#bitwise-operations).

```csharp
//Removing multiple constraints from default.
ConnectorConstraints ConnectorConstraints = ConnectorConstraints.Default & ~ (ConnectorConstraints.Select | ConnectorConstraints.Drag);
```

The following code example shows how the tooltip can be enabled for the connector.

```csharp
//Enabled the tooltip constraints for the connector.
connector.Constraints = ConnectorConstraints.Default | ConnectorConstraints.Tooltip;
```

For more information about connector constraints, refer to the [ConnectorConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorConstraints.html).

N>By default, the following constraints are enabled for the connector,
<br/>* DragSegmentThumb
<br/>* Interaction
<br/>* AllowDrop
<br/>* Bridging
<br/>* InheritBridging
<br/>* ConnectToNearByNode
<br/>* ConnectToNearByPort
<br/>* ConnectToNearByElement
<br/>* ReadOnly
<br/>* Default

## Port constraints

The [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_Constraints) property of the Port allows you to enable or disable the following behaviors of port. 

* InConnect
* OutConnect

| Constraints | Description |
| -------- | -------- |
|None|Disable all port Constraints.|
|Draw|Enables to create the connection when mouse hover on the port.|
|InConnect|Enables or disables to connect only the target end of connector.|
|OutConnect|Enables or disables to connect only the source end of connector.|
|Default|Enables all constraints for the port.|

The following code shows how to disable creating connections with a port.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the diagram with NodeCollection *@
<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        // Initialize the NodeCollection.
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        node.Ports = new DiagramObjectCollection<PointPort>()
        {
            new PointPort()
            {
                ID="port1",
                Offset=new DiagramPoint(){X=0,Y=0.5},
                Shape=PortShapes.Circle,
                Visibility=PortVisibility.Visible,
                // Sets the PortConstraints.
                Constraints=PortConstraints.None
            }
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Constraints/PortConstraints)

The following code example shows how to modify the port constraints to accept target connection alone.

```csharp
//Enable to create target connection alone.
port.Constraints = PortConstraints.InConnect;
```

The port constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](constraints#bitwise-operations).

```csharp
//Enable to create target connection alone.
port.Constraints = PortConstraints.Default | PortConstraints.Draw;
```

For more information about port constraints, refer to the [PortConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortConstraints.html).

N> By default, the following constraints are enabled for the port,
<br/>* Draw
<br/>* Default

## Annotation constraints

The [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_Constraints) property of the Annotations allows you to enable or disable read-only mode for the annotations by using the annotation constraints.

| Constraints | Description |
| -------- | -------- |
|ReadOnly|Enables or disables the ReadOnly Constraints,|
|InheritReadOnly|Enables or disables to inherit the ReadOnly option from the parent object.|
|None|Disables all constraints for the annotation.|

The following code shows how to enable read-only mode for the annotations.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the diagram with NodeCollection *@
<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        //Initialize the NodeCollection.
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation()
            {
                ID="annotation1",
                Content="Annotation Text Wrapping",
                // Sets the Constraints for Annotation.
                Constraints=AnnotationConstraints.ReadOnly,
                Style= new TextStyle()
                {
                    Color="#000000",
                    Fill="Transparent",
                    FontFamily="TimesNewRoman",
                    FontSize=12,
                    Bold=true,
                    Italic=true
                },
            }
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Constraints/AnnotationConstraints)

For more details about annotation constraints, refer to the [AnnotationConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AnnotationConstraints.html).

## Selector constraints

Selector visually represents the selected elements with certain editable thumbs. The visibility of the thumbs can be controlled with selector constraints. The part of selector is categorized as follows:

* ResizeAll
* UserHandle
* Rotate
* Tooltip

| Constraints | Description |
| -------- | -------- |
|None|Hides all the selector elements.|
|ConnectorSourceThumb|Shows or hides the source thumb of the connector.|
|ConnectorTargetThumb|Shows or hides the target thumb of the connector.|
|ResizeSouthEast|Shows or hides the bottom right resize handle of the selector.|
|ResizeSouthWest|Shows or hides the bottom left resize handle of the selector.|
|ResizeNorthEast|Shows or hides the top right resize handle of the selector.|
|ResizeNorthWest|Shows or hides the top left resize handle of the selector.|
|ResizeEast|Shows or hides the middle right resize handle of the selector.|
|ResizeWest|Shows or hides the middle left resize handle of the selector.|
|ResizeSouth|Shows or hides the bottom center resize handle of the selector.|
|ResizeNorth|Shows or hides the top center resize handle of the selector.|
|Rotate|Shows or hides the rotate handle of the selector.|
|UserHandle|Shows or hides the user handles of the selector.|
|Tooltip| Shows or hides the tooltip for the drag, resize, and rotate operation of nodes and connectors. |
|ResizeAll|Shows or hides all resize handles of the selector.|
|All|Shows all handles of the selector.|

The following code shows how to hide rotator.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" SelectionSettings="@selectionSettings"/>

@code
{
    DiagramObjectCollection<Node> nodes;
    public DiagramSelectionSettings selectionSettings = new DiagramSelectionSettings() 
    { 
        Constraints = SelectorConstraints.All & ~SelectorConstraints.Rotate 
    };

    protected override void OnInitialized()
    {
        //Initialize the NodeCollection.
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Constraints/SelectorConstraints)

![Selector Constraints in Blazor Diagram](images/blazor-diagram-node-constraints.png)

The following code illustrates how to show or hide the tooltip for the drag, resize and rotate operation of the nodes.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Popups
<p>Selector Constraints</p>
 <input type="checkbox" value="Tooltip" @onchange="@constraintschange"checked="@check5" />Tooltip
<SfDiagramComponent Width="1000px" Height="500px" Nodes="@nodes" />
@code
{
    DiagramObjectCollection<Node> nodes;
    bool selector=true;
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
     private void constraintschange(object value)
    {
        var obj = value as ChangeEventArgs;

        if ((bool)obj.Value)
        {
             selection.Constraints |= SelectorConstraints.Tooltip;
              selector = true;
        }
        else
        {
              selection.Constraints &= ~SelectorConstraints.Tooltip;
              selector = false;
        }

    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Constraints)

|![ToolTip During hover the node with selectorconstraints](images/blazor-diagram-selectorconstraintsnode.gif) | 

N> Element should be in a selected state, then only Rotator, UserHandle and Resizer thumbs will be visible.

The following code example shows how to disable the userhandle functionality for the selected item.

```csharp
//Enable userhandle constraint for the selected item.
selectedItems.Constraints = SelectorConstraints.All &~ SelectorConstraints.UserHandle;
```

For more information about selector constraints, refer to the [SelectorConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectorConstraints.html).

N> By default, the following constraints are enabled for the selected items,
<br/>* ConnectorSourceThumb
<br/>* ConnectorTargetThumb
<br/>* ResizeSouthEast
<br/>* ResizeSouthWest
<br/>* ResizeEast
<br/>* ResizeWest
<br/>* ResizeSouth
<br/>* ResizeNorth
<br/>* All
<br/>* Tooltip

## Snap constraints

The [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html#Syncfusion_Blazor_Diagram_SnapSettings_Constraints) property of the SnapConstraints control the visibility of gridlines and enable or disable snapping. Snap constraints allow to set the following behaviors.

* Show only horizontal or vertical gridlines.
* Show both horizontal and vertical gridlines.
* Snap to either horizontal or vertical gridlines.
* Snap to both horizontal and vertical gridlines.

The following list of snapping constraints are used to enable or disable certain features of snapping.

| Constraints | Description |
| -------- | -------- |
|None|Disable snapping the nodes/connectors in diagram.|
|ShowHorizontalLines|Displays only the horizontal gridlines in diagram.|
|ShowVerticalLines|Displays only the Vertical gridlines in diagram.|
|ShowLines|Display both Horizontal and Vertical gridlines.|
|SnapToHorizontalLines|Enables the object to snap only with horizontal gridlines.|
|SnapToVerticalLines|Enables the object to snap only with Vertical gridlines.|
|SnapToLines|Enables the object to snap with both horizontal and Vertical gridlines.|
|SnapToObject|Enables the object to snap with the other objects in the diagram.|
|All|Shows gridlines and enables snapping.|

The following code shows how to show only horizontal gridlines.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
    @* Initialize the snapsettings with constraints *@
    <SnapSettings Constraints="SnapConstraints.ShowHorizontalLines" />
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        //Initialize the NodeCollection.
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Constraints/SnapConstraints)

The snap constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](constraints#bitwise-operations).

```csharp
snapconstraints = SnapConstraints.ShowHorizontalLines | SnapConstraints.ShowVerticalLines | SnapConstraints.ShowLines;
```

For more information about snap constraints, refer to the [SnapConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapConstraints.html).

N> By default, the following constraints are enabled for the snap functionality in the diagram,
<br/>* ShowLines
<br/>* ShowVerticalLines
<br/>* ShowHorizontalLines
<br/>* SnapToHorizontalLines
<br/>* SnapToObject
<br/>* All

## Boundary constraints

Boundary constraints defines a boundary for the diagram inside that the interaction should be done. Boundary constraints allow to set the following behaviors.

* Infinity
* Diagram
* Page

The following list of constraints are used to enable or disable certain features of boundary interactions of the diagram.

| Constraints | Description |
| -------- | -------- |
|Infinity|Allow the interactions to take place at the infinite height and width.|
|Diagram|Allow the interactions to take place around the diagram height and width.|
|Page|Allow the interactions to take place around the page height and width.|

The following code shows how to limit the interaction done inside a diagram within a page.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
    @* Initialize the pagesettings with boundary constraints *@
    <PageSettings Width="600" Height="500" BoundaryConstraints="BoundaryConstraints.Page"/>
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        //Initialize the NodeCollection.
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Constraints/BoundaryConstraints)

For more information about selector constraints, refer to the [BoundaryConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BoundaryConstraints.html).

N> By default, the following boundary constraints are enabled for the snap functionality in the diagram,
<br/>* Diagram

## Inherit behaviors

Some of the behaviors can be defined through both the specific object (node or connector) and diagram. When the behaviors are contradictorily defined through both, the actual behavior is set through inherit options.

The following code example shows how to inherit the line bridging behavior from the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the diagram with constraints *@
<SfDiagramComponent Height="600px"
                    Connectors="@connectors"
                    Constraints="@diagramConstraints">
</SfDiagramComponent>

@code
{
    //Sets the diagram constraints.
    DiagramConstraints diagramConstraints = DiagramConstraints.Default | DiagramConstraints.Bridging;
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            //Sets the ConnectorConstraints.
            Constraints = ConnectorConstraints.Default | ConnectorConstraints.InheritBridging
        };
        Connector connector1 = new Connector()
        {
            ID = "connector2",
            SourcePoint = new DiagramPoint() { X = 200, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 100, Y = 200 },
        };
        connectors.Add(connector);
        connectors.Add(connector1);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Constraints/InheritBehaviors)

## Bitwise operations

Bitwise operations are used to manipulate the flagged enumerations `enum`. In this section, Bitwise operations are shown by using the node constraints. The same is applicable when working with node constraints, connector constraints, or port constraints.

### Add operation

You can add or enable multiple values at a time by using the Bitwise `|` (OR) operator.

The following code shows how to add bridging constraints into the default diagram constraints to enable bridging functionality in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Constraints="@diagramConstraint"/>

@code
{
    //To add line routing constraint with default contraints.
    DiagramConstraints diagramConstraint = DiagramConstraints.Default | DiagramConstraints.Bridging;
}
```

### Remove operation

You can remove or disable values by using the Bitwise ‘&~’ (XOR) operator.

The following code shows to remove zoom and pan constraints from the default constraints to disable zoom and panning functionality in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Constraints="@diagramConstraint"/>

@code
{
    //To remove zoom and panning constraints from the default constraints.
    //It has disabled zoom and panning functionality for the diagram.
    DiagramConstraints diagramConstraint = DiagramConstraints.Default &~ (DiagramConstraints.Zoom | DiagramConstraints.Pan);
}
```

### Check operation

You can check any value by using the Bitwise ‘&’ (AND) operator.

```csharp
if ((node.constraints & (NodeConstraints.Rotate)) == (NodeConstraints.Rotate));
```

In the previous example, check whether the rotate constraints are enabled in a node. When node constraints have rotated constraints, the expression returns a rotate constraint.
