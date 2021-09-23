---
layout: post
title: Interaction in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about interaction in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Interaction in Blazor Diagram Component

## Selection

Selector provides a visual representation of selected elements. It behaves like a container and allows to update the size, position, and rotation angle of the selected elements through interaction and by using program. Single or multiple elements can be selected at a time.

## Single selection

An element can be selected by clicking that element. During single click, all previously selected items are cleared. The following image shows how the selected elements are visually represented.

![Single Selection in Blazor Diagram](images/selection.gif)

* While selecting the diagram elements, the following events can be used to do your customization.
* When selecting/unselecting the diagram elements, the `SelectionChanged` event gets triggered.

## Selecting a group

When a child element of any group is clicked, its contained group is selected instead of the child element. With consecutive clicks on the selected element, selection is changed from top to bottom in the hierarchy of parent group to its children.

## Multiple selection

Multiple elements can be selected with the following ways:

* Ctrl+Click

During single click, any existing item in the selection list be cleared, and only the item clicked recently is there in the selection list. To avoid clearing the old selected item, Ctrl key must be on hold when clicking.

* Selection rectangle/rubber band selection

Clicking and dragging the diagram area allows to create a rectangular region. The elements that are covered under the rectangular region are selected at the end.

![Multiple Selection in Blazor Diagram](images/multiselect.gif)

## Select/Unselect elements using program

The server-side methods `Select` and `ClearSelection` help to select or clear the selection of the elements at runtime.

Get the current selected items from the `Nodes` and `Connectors` collection of the `SelectionSettings` property of the diagram model.

## Select entire elements in diagram programmatically

The server-side method `SelectAll` used to select all the elements such as nodes/connectors in the diagram. Refer to the following link which shows how to use `SelectAll` method on the diagram.

## Drag

* An object can be dragged by clicking and dragging it. When multiple elements are selected, dragging any one of the selected elements move every selected element.
* When you drag the elements in the diagram, the `PositionChanging` and `PositionChanged` events are triggered and to do customization on those events.

For more information about dragging , refer [Node Drag](https://blazor.syncfusion.com/documentation/diagram-component/nodes/interaction/#drag)

## Resize

* Selector is surrounded by eight thumbs. When dragging these thumbs, selected items can be resized.
* When one corner of the selector is dragged, opposite corner is in a static position.
* When a node is resized, the `SizeChanging` and `SizeChanged` events are gets triggered.

For more information about resizing , refer [Node Resize](https://blazor.syncfusion.com/documentation/diagram-component/nodes/interaction/#resize)

>Note:  While dragging and resizing, the objects are snapped towards the nearest objects to make better alignments. For better alignments, refer to [Snapping](https://blazor.syncfusion.com/documentation/diagram-component/grid-lines#snapping).

## Rotate

* A rotate handler is placed above the selector. Clicking and dragging the handler in a circular direction lead to rotate the node.
* The node is rotated with reference to the static pivot point.
* Pivot thumb (thumb at the middle of the node) appears while rotating the node to represent the static point.

For more information about resizing , refer [Node Rotate](https://blazor.syncfusion.com/documentation/diagram-component/nodes/interaction/#rotate)

## Connection editing

* Each segment of a selected connector is editable with some specific handles/thumbs.

## End point handles

Source and target points of the selected connectors are represented with two handles. Clicking and dragging those handles help you to adjust the source and target points.

For more information , refer [End Point Dragging](https://blazor.syncfusion.com/documentation/diagram-component/connectors/interactions/#end-point-dragging)

* If you drag the connector end points, then the following events can be used to do your customization.
* When you connect connector with ports/node or disconnect from it, the `ConnectionChanging` and `ConnectionChanged` events are gets triggered.

## Straight segment editing

* End point of each straight segment is represented by a thumb that enables to edit the segment.
* Any number of new segments can be inserted into a straight line by clicking, when Shift and Ctrl keys are pressed (Ctrl+Shift+Click).
* Straight segments can be removed by clicking the segment end point, when Ctrl and Shift keys are pressed (Ctrl+Shift+Click).

For more information about straight segment editing , refer [Straight Segment Editing](https://blazor.syncfusion.com/documentation/diagram-component/connectors/interactions/#straight-segment-editing)

## Orthogonal segment editing

* Orthogonal thumbs allow you to adjust the length of adjacent segments by clicking and dragging it.
* When necessary, some segments are added or removed automatically, when dragging the segment. This is to maintain proper routing of orthogonality between segments.

For more information about orthogonal segment editing , refer [Orthogonal Segment Editing](https://blazor.syncfusion.com/documentation/diagram-component/connectors/interactions/#orthogonal-segment-editing)

## User handles

* User handles are used to add some frequently used commands around the selector. To create user handles, define and add them to the `UserHandles` collection of the `SelectedItems` property.
* The name property of user handle is used to define the name of the user handle and its further used to find the user handle at runtime and do any customization.

## Alignment

User handles can be aligned relative to the node boundaries. It has `Margin`, `Offset`, `Side`, `HorizontalAlignment`, and `VerticalAlignment` settings. It is quite tricky when all four alignments are used together but gives more control over alignment.

## Offset

The `Offset` property of `UserHandles` is used to align the user handle based on fractions. 0 represents top/left corner, 1 represents bottom/right corner, and 0.5 represents half of width/height.

## Side

The `Side` property of `UserHandles` is used to align the user handle by using the `Top`, `Bottom`, `Left`, and `Right` options.

## Horizontal and vertical alignments

The `HorizontalAlignment` property of `UserHandles` is used to set how the user handle is horizontally aligned at the position based on the `Offset`. The `VerticalAlignment` property is used to set how user handle is vertically aligned at the position.

## Margin

Margin is an absolute value used to add some blank space in any one of its four sides. The `UserHandles` can be displaced with the `Margin` property.

## Notification for the mouse button clicked

The diagram component notifies the mouse button clicked. For example, whenever the right mouse button is clicked, the clicked button is notified as right. The mouse click is notified with,

| Notification | Description |
|----------------|--------------|
| Left | When the left mouse button is clicked, left is notified  |
| Middle | When the mouse wheel is clicked, middle is notified |
| Right | When the right mouse button is clicked, right is notified |

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" Click='@OnClick' />

@code
{
    public DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes array.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            // Add node
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeDashArray = "5,5", StrokeColor = "red", StrokeWidth = 2 },
        };
        nodes.Add(node);
    }

    private void OnClick(ClickEventArgs args)
    {
        Console.WriteLine("Button", args.Button);
    }
}
```

## Appearance

The appearance of the user handle can be customized by using the `Size`, `BorderColor`, `BackgroundColor`, `Visible`, `PathData`, and `PathColor` properties of the `UserHandles`.

## Zoom pan

* When a large diagram is loaded, only certain portion of the diagram is visible. The remaining portions are clipped. Clipped portions can be explored by scrolling the scrollbars or panning the diagram.
* Diagram can be zoomed in or out by using Ctrl + mouse wheel.

![Zoom Pan in Blazor Diagram](images/zoompan.gif)

## Keyboard

Diagram provides support to interact with the elements with key gestures. By default, some in-built commands are bound with a relevant set of key combinations.

The following table illustrates those commands with the associated key values.

| Shortcut Key | Command | Description|
|--------------|---------|------------|
| Ctrl + A | `SelectAll` | Select all nodes/connectors in the diagram.|
| Ctrl + C | Copy | Copy the diagram selected elements.|
| Ctrl + V | Paste | Pastes the copied elements.|
| Ctrl + X | Cut | Cuts the selected elements.|
| Ctrl + Z | Undo | Reverses the last editing action performed on the diagram.|
| Ctrl + Y | Redo | Restores the last editing action when no other actions have occurred since the last undo on the diagram.|
| Delete | Delete | Deletes the selected elements.|
| Ctrl/Shift + Click on object |  | Multiple selection (Selector binds all selected nodes/connectors).|
| Up Arrow | Nudge(“up”) | `NudgeUp`: Moves the selected elements towards up by one pixel.|
| Down Arrow | Nudge(“down”) | `NudgeDown`: Moves the selected elements towards down by one pixel.|
| Left Arrow | Nudge(“left”) | `NudgeLeft`: Moves the selected elements towards left by one pixel.|
| Right Arrow | Nudge(“right”) | `NudgeRight`: Moves the selected elements towards right by one pixel.|
| Ctrl + MouseWheel | Zoom | Zoom (Zoom in/Zoom out the diagram).|
| F2 | `StartTextEdit` | Starts to edit the label of selected element.|
| Esc | `EndTextEdit` | Sets the label mode as view and stops editing.|

## See Also

* [How to control the diagram history](./undo-redo)