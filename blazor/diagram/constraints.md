---
layout: post
title: Constraints in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Constraints in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram
documentation: ug
---

> Syncfusion recommends using [Blazor Diagram Component](https://blazor.syncfusion.com/documentation/diagram-component/getting-started) which provides better performance than this diagram control. Blazor Diagram Component will be actively developed in the future.

# Constraints in Blazor Diagram Component

Constraints are used to enable or disable certain behaviors of the diagram, nodes, and connectors. Constraints are provided as flagged enumerations, so that multiple behaviors can be enabled or disabled using the Bitwise operators `(&, |, ~, <<, etc.)`.

To know more about Bitwise operators, refer to the [Bitwise Operations](#bitwise-operations).

## Diagram constraints

Diagram constraints allow you to enable or disable the following behaviors:

* Page editing
* Bridging
* Zoom and pan
* Undo or redo
* Tooltip

The following list of diagram constraints are used to Enables or Disables certain features of the diagram.

| Constraints | Description |
| -------- | -------- |
|None|Disable all diagram functionalities|
|Bridging|Enables or Disable Bridging support for connector in diagram|
|Undo/redo|Enables or Disable the Undo/Redo support for the diagram|
|Tooltip|Enables or Disable Tooltip support support for the diagram|
|UserInteraction|Enables or Disable user interaction support for the diagram|
|ApiUpdate|Enables or Disable update API support for the diagram|
|PageEditable|Enables or Disable Page Editable support for the diagram|
|Zoom|Enables or Disable Zoom support for the diagram|
|PanX|Enables or Disable Paning X coordinate support for the diagram|
|PanY|Enables or Disable Paning Y coordinate support for the diagram|
|Pan|Enables or Disable panning both X and Y coordinates support for the diagram|
|ZoomTextEdit|Enables or Disables zooming the text box while editing the text|
|LineRouting|Enables or Disable the line routing for the diagram|
|Virtualization|Enables or Disable Virtualization support the diagram|
|Default|Enables or Disable all constraints in diagram|

The following example shows how to disable page editing using the diagram constraints.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize the diagram with constraints *@
<SfDiagram Height="600px" Nodes="@NodeCollection" Constraints="@DiagramConstraints">
</SfDiagram>

@code{
    //sets the Diagram constraints...
    DiagramConstraints DiagramConstraints = DiagramConstraints.Default & ~DiagramConstraints.PageEditable;

    //Initialize the Nodes Collection.
    ObservableCollection<DiagramNode> NodeCollection;

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Id = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        NodeCollection.Add(node);
    }
}
```

The following another code example shows how the virtualization can be enabled for the diagram.

```csharp
//enabled the Virtualization functionality for the diagram
Diagram.Constraints = DiagramConstraints.Default | DiagramConstraints.Virtualization;
```

For more information about diagram constraints, refer to the [DiagramConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramConstraints.html).

> By default, the following constraints are enabled in the diagram,
>* UndoRedo
>* UserInteraction
>* ApiUpdate
>* PageEditable
>* Zoom
>* Pan

The diagram constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](#bitwise-operations) in the diagram.

## Node constraints

Node constraints allows you to enable or disable the following behaviors of node. They are as follows:

* Selection
* Deletion
* Drag
* Resize
* Rotate
* Connect
* Shadow
* Tooltip

The following list of node constraints are used to Enables or Disables certain features of node.

| Constraints | Description |
| -------- | -------- |
|None|Disable all node Constraints|
|Select|Enables or Disables node to be selected|
|Drag|Enables or Disables node to be Dragged|
|Rotate|Enables or Disables node to be rotating|
|Shadow|Enables or disables node to display shadow|
|PointerEvents|Enables or disables node to provide pointer option|
|Delete|Enables or Disables node to be deleting|
|InConnect|Enables or disables node to provide in connect option|
|OutConnect|Enables or disables node to provide out connect option|
|Individual|Enables node to provide individual resize option|
|Expandable|Enables node to provide Expandable option|
|AllowDrop|Enables node to provide allow to drop option|
|Inherit|Enables node to inherit the interaction option from the parent object|
|ResizeNorthEast|Enable or disable to Resizing NorthEast side of the node|
|ResizeEast|Enable or disable to Resizing East side of the node|
|ResizeSouthEast|Enable or disable to Resizing SouthEast side of the node|
|ResizeSouth|Enable or disable to Resizing South side of the node|
|ResizeSouthWest|Enable or disable to Resizing SouthWest side of the node|
|ResizeWest|Enable or disable to Resizing West side of the node|
|ResizeNorthWest|Enable or disable to Resizing NorthWest side of the node|
|ResizeNorth|Enable or disable to Resizing North side of the node|
|Resize|Enables or Disables to Resizing of the node|
|AspectRatio|Enables the Aspect ratio of the node|
|Tooltip|Enables or disables tool tip for the Nodes|
|InheritTooltip|Enables or disables inherit tool tip option from the parent object|
|ReadOnly|Enables the  ReadOnly support for annotation in node|
|HideThumbs|Enable to hide all resize thumbs for the node|
|AllowMovingOutsideLane|Enables or disables child in parent for the swimLane node|
|Default|Enables all default constraints for the node|

The following example shows how to disable rotation using the node constraints.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize the diagram with NodeCollection *@
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code{
    ObservableCollection<DiagramNode> NodeCollection;

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Id = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
            //sets the NodeConstraints constraints...
            Constraints = NodeConstraints.Default & ~NodeConstraints.Rotate
        };
        NodeCollection.Add(node);
    }
}
```

The following another code example shows how the tooltip can be enabled for the node.

```csharp
//enabled the tooltip constraints for the node
node.Constraints = NodeConstraints.Default | NodeConstraints.Tooltip;
```

For more information about node constraints, refer to the [NodeConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.NodeConstraints.html).

>**Note** : By default, the following constraints are enabled for the node,
>* Select
>* Drag
>* Resize
>* Rotate
>* Delete
>* InConnect
>* OutConnect
>* Expandable
>* InheritTooltip

> The node constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](#bitwise-operations).

## Connector constraints

Connector constraints allow you to enable or disable certain behaviors of connectors.

* Selection
* Deletion
* Drag
* Segment editing
* Tooltip
* Bridging

The following list of connector constraints are used to Enables or Disables certain features of connectors.

| Constraints | Description |
| -------- | -------- |
|None|Disable all connector Constraints|
|Select|Enables or Disables node to be selected|
|Delete|Enables or Disables node to be deleting|
|Drag|Enables or Disables node to be Dragged|
|DragSourceEnd|Enables connectors source end to be selected|
|DragTargetEnd|Enables connectors target end to be selected|
|DragSegmentThumb|Enables control point and end point of every segment in a connector for editing|
|AllowDrop|Enables allow drop support to the connector|
|Bridging|Enables bridging to the connector|
|BridgeObstacle|Enables or Disables Bridge Obstacles with overlapping of connectors|
|InheritBridging|Enables to inherit bridging option from the parent object|
|PointerEvents|Enables to set the pointer events|
|Tooltip|Enables or disables tool tip for the connectors|
|InheritTooltip|Enables or disables to inheriting tool tip option from the parent object|
|Interaction|Enables or disables Interaction for the connector|
|ReadOnly|Enables or disables readonly for the connector|
|LineRouting|Enables or disables routing to the connector|
|InheritLineRouting|Enables or disables to inheriting routing option from the parent|
|Default|Enables all constraints for the connector|

The following code shows how to disable selection by using the connector constraints.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize the diagram with ConnectorCollection *@
<SfDiagram Height="600px" Connectors="@ConnectorCollection">
</SfDiagram>

@code{
    ObservableCollection<DiagramConnector> ConnectorCollection;

    protected override void OnInitialized()
    {
        ConnectorCollection = new ObservableCollection<DiagramConnector>();
        DiagramConnector connector = new DiagramConnector()
        {
            Id = "connector1",
            Type = Segments.Straight,
            SourcePoint = new ConnectorSourcePoint() { X = 100, Y = 100 },
            TargetPoint = new ConnectorTargetPoint() { X = 200, Y = 200 },
            //sets the ConnectorConstraints...
            Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Select
        };
        ConnectorCollection.Add(connector);
    }
}
```

The following another code example shows how the tooltip can be enabled for the connector.

```csharp
//enabled the tooltip constraints for the connector
connector.Constraints = ConnectorConstraints.Default | ConnectorConstraints.Tooltip;
```

For more information about connector constraints, refer to the [ConnectorConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.ConnectorConstraints.html).

>By default, the following constraints are enabled for the connector,
>* Select
>* Drag
>* DragSourceEnd
>* DragTargetEnd
>* Delete
>* BridgeObstacle
>* InheritBridging
>* PointerEvents
>* InheritTooltip
>* InheritLineRouting

**Note** : The connector constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](#bitwise-operations).

## Port constraints

You can enable or disable certain behaviors of port. They are as follows:

* Connect
* ConnectOnDrag

The following list of port constraints are used to Enables or Disables certain features of ports.

| Constraints | Description |
| -------- | -------- |
|None|Disable all port Constraints|
|Drag|Enables or disables to drag the port|
|Draw|Enables to create the connection when mouse hover on the port|
|InConnect|Enables or disables to only connect the target end of connector|
|OutConnect|Enables or disables to only connect the source end of connector|
|Default|Enables all constraints for the port|

The following code shows how to disable creating connections with a port.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize the diagram with NodeCollection *@
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code{
    ObservableCollection<DiagramNode> NodeCollection;

    protected override void OnInitialized()
    {
        //Initialize the NodeCollection.
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Id = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        node.Ports = new ObservableCollection<DiagramPort>()
        {
            new DiagramPort()
            {
                Id="port1",
                Offset=new NodePortOffset(){X=0,Y=0.5},
                Shape=PortShapes.Circle,
                Visibility=PortVisibility.Visible,
                //sets the PortConstraints...
                Constraints=PortConstraints.None
            }
        };
        NodeCollection.Add(node);
    }
}
```

The following another code example shows to modify the port constraints to accept target connection alone.

```csharp
//Enable to create target connection alone.
port.Constraints = PortConstraints.InConnect;
```

For more information about port constraints, refer to the [PortConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.PortConstraints.html).

> By default, the following constraints are enabled for the port,
>* InConnect
>* OutConnect

**Note** : The port constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](#bitwise-operations).

## Annotation constraints

You can enable or disable read-only mode for the annotations by using the annotation constraints.

The following list of annotation constraints are used to Enables or Disables certain features of annotations.

| Constraints | Description |
| -------- | -------- |
|ReadOnly|Enables or Disables the ReadOnly Constraints|
|InheritReadOnly|Enables or Disables to inherit the ReadOnly option from the parent object|
|Select|Enables or Disable select support for the annotation|
|Drag|Enables or Disable drag support for the annotation|
|Resize|Enables or Disable resize support for the annotation|
|Rotate|Enables or Disable rotate support for the annotation|
|Interaction|Enables or Disable annotation to inherit the interaction option|
|None|Disables all constraints for the annotation|

The following code shows how to enable read-only mode for the annotations.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize the diagram with NodeCollection *@
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code{
    ObservableCollection<DiagramNode> NodeCollection;

    protected override void OnInitialized()
    {
        //Initialize the NodeCollection.
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Id = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        node.Annotations = new ObservableCollection<DiagramNodeAnnotation>()
        {
            new DiagramNodeAnnotation()
            {
                Id="annotation1",
                Content="Annotation Text Wrapping",
                //sets the Constraints for Annotation...
                Constraints=AnnotationConstraints.ReadOnly,
                Style=new AnnotationStyle(){Color="#000000", Fill="transparent",
                FontFamily="TimesNewRoman", FontSize=12, Bold=true, Italic=true},
            }
        };
        NodeCollection.Add(node);
    }
}
```

The following another code example shows how to enable the selection and dragging functionality for the annotation.

```csharp
//Enable select and drag constraints for the annotation.
annotation.Constraints = AnnotationConstraints.Select | AnnotationConstraints.Drag;
```

For more details about annotation constraints, refer to the [AnnotationConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.AnnotationConstraints.html).

> The annotation constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](#bitwise-operations).

## Selector constraints

Selector visually represents the selected elements with certain editable thumbs. The visibility of the thumbs can be controlled with selector constraints. The part of selector is categorized as follows:

* Resizer
* Rotator
* User handles

The following list of selector constraints are used to Enables or Disables certain features of selected items.

| Constraints | Description |
| -------- | -------- |
|None|Hides all the selector elements|
|ConnectorSourceThumb|Shows or hides the source thumb of the connector|
|ConnectorTargetThumb|Shows or hides the target thumb of the connector|
|ResizeSouthEast|Shows or hides the bottom right resize handle of the selector|
|ResizeSouthWest|Shows or hides the bottom left resize handle of the selector|
|ResizeNorthEast|Shows or hides the top right resize handle of the selector|
|ResizeNorthWest|Shows or hides the top left resize handle of the selector|
|ResizeEast|Shows or hides the middle right resize handle of the selector|
|ResizeWest|Shows or hides the middle left resize handle of the selector|
|ResizeSouth|Shows or hides the bottom center resize handle of the selector|
|ResizeNorth|Shows or hides the top center resize handle of the selector|
|Rotate|Shows or hides the rotate handle of the selector|
|UserHandle|Shows or hides the user handles of the selector|
|ToolTip|Shows or hides the default tooltip of selected items|
|ResizeAll|Shows or hides all resize handles of the selector|
|All|Shows all handles of the selector|

The following code shows how to hide rotator.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection" SelectedItems="@selectedItems">
</SfDiagram>

@code{
    ObservableCollection<DiagramNode> NodeCollection;

    DiagramSelectedItems selectedItems = new DiagramSelectedItems() { Constraints = SelectorConstraints.All & ~SelectorConstraints.Rotate };

    protected override void OnInitialized()
    {
        //Initialize the NodeCollection.
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Id = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        NodeCollection.Add(node);
    }
}
```

The following another code example shows how to enable the userhandle functionality for the selected item.

```csharp
//Enable userhandle constraint for the selected item.
selectedItems.Constraints = SelectorConstraints.All | SelectorConstraints.UserHandle;
```

For more information about selector constraints, refer to the [SelectorConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SelectorConstraints.html).

> By default, the following constraints are enabled for the selected items,
>* ResizeAll
>* UserHandle
>* Rotate
>* ToolTip

**Note** : The port constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](#bitwise-operations).

## Snap constraints

Snap constraints control the visibility of gridlines and enable or disable snapping. Snap constraints allow to set the following behaviors.

* Show only horizontal or vertical gridlines.
* Show both horizontal and vertical gridlines.
* Snap to either horizontal or vertical gridlines.
* Snap to both horizontal and vertical gridlines.

The following list of snapping constraints are used to Enables or Disables certain features of snapping.

| Constraints | Description |
| -------- | -------- |
|None|Disable to snapping the nodes/connectors in diagram|
|ShowHorizontalLines|Displays only the horizontal gridlines in diagram|
|ShowVerticalLines|Displays only the Vertical gridlines in diagram|
|ShowLines|Display both Horizontal and Vertical gridlines|
|SnapToHorizontalLines|Enables the object to snap only with horizontal gridlines|
|SnapToVerticalLines|Enables the object to snap only with Vertical gridlines|
|SnapToLines|Enables the object to snap with both horizontal and Vertical gridlines|
|SnapToObject|Enables the object to snap with the other objects in the diagram|
|All|Shows gridlines and enables snapping|

The following code shows how to show only horizontal gridlines.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    @* Initialize the snapsettings with constraints *@
    <DiagramSnapSettings Constraints="SnapConstraints.ShowHorizontalLines"></DiagramSnapSettings>
</SfDiagram>

@code{
    ObservableCollection<DiagramNode> NodeCollection;
    protected override void OnInitialized()
    {
        //Initialize the NodeCollection.
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Id = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        NodeCollection.Add(node);
    }
}
```

For more information about snap constraints, refer to the [SnapConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SnapConstraints.html).

> By default, the following constraints are enabled for the snap functionality in the diagram,
>* ShowLines
>* SnapToLines

**Note** : The snap constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](#bitwise-operations).

## Boundary constraints

Boundary constraints defines a boundary for the diagram inside that the interaction should be done. Boundary constraints allow to set the following behaviors.

* Infinite boundary
* Diagram sized boundary
* Page sized boundary

The following list of constraints are used to Enables or Disables certain features of boundary interactions of the diagram.

| Constraints | Description |
| -------- | -------- |
|Infinity|Allow the interactions to take place at the infinite height and width|
|Diagram|Allow the interactions to take place around the diagram height and width|
|Page|Allow the interactions to take place around the page height and width|

The following code shows how to limit the interaction done inside a diagram within a page.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    @* Initialize the pagesettings with boundary constraints *@
    <DiagramPageSettings Width="600" Height="500" BoundaryConstraints="BoundaryConstraints.Page"></DiagramPageSettings>
</SfDiagram>

@code{
    ObservableCollection<DiagramNode> NodeCollection;

    protected override void OnInitialized()
    {
        //Initialize the NodeCollection.
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Id = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
        };
        NodeCollection.Add(node);
    }
}
```

For more information about selector constraints, refer to the [BoundaryConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.BoundaryConstraints.html).

> By default, the following boundary constraints are enabled for the snap functionality in the diagram,
>* Diagram

**Note** : The boundary constraints are provided as flagged enumerations, so that multiple behaviors can be added or removed from the default constraints using the [Bitwise Operations](#bitwise-operations).

## Inherit behaviors

Some of the behaviors can be defined through both the specific object (node or connector) and diagram. When the behaviors are contradictorily defined through both, the actual behavior is set through inherit options.

The following code example shows how to inherit the line bridging behavior from the diagram model.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize the diagram with constraints *@
<SfDiagram Height="600px" Connectors="@ConnectorCollection" Constraints="@DiagramConstraints">
</SfDiagram>

@code{
    //Sets the diagram constraints
    public DiagramConstraints DiagramConstraints = DiagramConstraints.Default | DiagramConstraints.Bridging;

    ObservableCollection<DiagramConnector> ConnectorCollection;

    protected override void OnInitialized()
    {
        ConnectorCollection = new ObservableCollection<DiagramConnector>();

        DiagramConnector connector = new DiagramConnector()
        {
            Id = "connector1",
            SourcePoint = new ConnectorSourcePoint() { X = 100, Y = 100 },
            TargetPoint = new ConnectorTargetPoint() { X = 200, Y = 200 },
            //sets the ConnectorConstraints...
            Constraints = ConnectorConstraints.Default | ConnectorConstraints.InheritBridging
        };
        DiagramConnector connector1 = new DiagramConnector()
        {
            Id = "connector2",
            SourcePoint = new ConnectorSourcePoint() { X = 200, Y = 100 },
            TargetPoint = new ConnectorTargetPoint() { X = 100, Y = 200 },
        };
        ConnectorCollection.Add(connector);
        ConnectorCollection.Add(connector1);
    }
}
```

## Bitwise operations

Bitwise operations are used to manipulate the flagged enumerations `enum`. In this section, Bitwise operations are shown by using the node constraints. The same is applicable when working with node constraints, connector constraints, or port constraints.

## Add operation

You can add or enable multiple values at a time by using the Bitwise `|` (OR) operator.

The following code shows to add line routing constraints into the default diagram constraints to enable line routing functionality into the diagram.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Constraints="@DiagramConstraint">
</SfDiagram>

@code{
//To adding line routing constraint with default contraints.
DiagramConstraints DiagramConstraint = DiagramConstraints.Default | DiagramConstraints.LineRouting;
}
```

## Remove Operation

You can remove or disable values by using the Bitwise ‘&~’ (XOR) operator.

The following code shows to remove zoom and pan constraints from the default constraints to disable zoom and panning functionality in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Constraints="@DiagramConstraint">
</SfDiagram>

@code{
//To removing zoom and panning constraints from the default contraints
//It has disabled zoom and panning funcationality for the diagram.
DiagramConstraints DiagramConstraint = DiagramConstraints.Default &~ (DiagramConstraints.Zoom | DiagramConstraints.Pan);
}
```

## Check operation

You can check any value by using the Bitwise ‘&’ (AND) operator.

```csharp
if ((node.constraints & (NodeConstraints.Rotate)) == (NodeConstraints.Rotate));
```

In the previous example, check whether the rotate constraints are enabled in a node. When node constraints have rotated constraints, the expression returns a rotate constraint.