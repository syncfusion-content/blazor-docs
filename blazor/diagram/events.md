---
layout: post
title: Events in Blazor Diagram Component | Syncfusion 
description: Checkout and learn here all about the Events in the Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram
documentation: ug
---

# Events in Blazor Diagram Component

## Created

Triggered when the diagram is rendered completely.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents Created="Created"></DiagramEvents>
</SfDiagram>

@code
{
    public void Created()
    {
        //Action to be performed.
    }
}
```

## Clicked

Triggers when a node, connector, or diagram is clicked.

| Argument Name | Description |
| -------- | -------- |
| Element | Returns the object that is clicked or id of the diagram. |
| Position | Returns the object position that is actually clicked. |
| Count |  Returns the number of times clicked. |
| ActualObject | Returns the actual object that is clicked or id of the diagram. |
| Button | Returns the button clicked. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents Clicked="Clicked"></DiagramEvents>
</SfDiagram>

@code
{
    public void Clicked(IBlazorClickEventArgs args)
    {
        //Action to be performed.
    }
}
```

## ContextMenuItemClicked

Triggers when a context menu item is clicked.

| Argument Name | Description |
| -------- | -------- |
| Element | Returns the object that is clicked. |
| Item |  Returns the actual object that is clicked. |
| Name | Returns the name of the object that is clicked. |
| Cancel | Returns whether to cancel the change or not. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents ContextMenuItemClicked="ContextMenuItemClicked"></DiagramEvents>
</SfDiagram>

@code
{
    public void ContextMenuItemClicked(DiagramMenuEventArgs args)
    {
        //Action to be performed.
    }
}
```

## OnContextMenuOpen

Triggers before opening the context menu.

| Argument Name | Description |
| -------- | -------- |
| Cancel | Returns whether to cancel the change or not. |
| Element | Returns the object that is clicked. |
| HiddenItems | Defines the hidden items of the diagram context menu. |
| Items |  Defines the items of the diagram context menu. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents OnContextMenuOpen="OnContextMenuOpen"></DiagramEvents>
</SfDiagram>

@code
{
    public void OnContextMenuOpen(DiagramBeforeMenuOpenEventArgs args)
    {
        //Action to be performed.
    }
}
```

## DataLoaded

Triggers after the diagram is populated from the external data source.

| Argument Name | Description |
| -------- | -------- |
| Diagram | Returns the diagram. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents DataLoaded="DataLoaded"></DiagramEvents>
</SfDiagram>

@code
{
    public void DataLoaded(IDataLoadedEventArgs args)
    {
        //Action to be performed.
    }
}
```

## OnDoubleClick

Triggers when a node, connector, or diagram is clicked.

| Argument Name | Description |
| -------- | -------- |
| Count |  Returns the number of times clicked. |
| Position | Returns the object position that is actually clicked. |
| Element | Returns the object that is clicked or id of the diagram. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents OnDoubleClick="OnDoubleClick"></DiagramEvents>
</SfDiagram>

@code
{
    public void OnDoubleClick(IBlazorDoubleClickEventArgs args)
    {
        //Action to be performed.
    }
}
```

## DragEnter

Triggers when a symbol is dragged into a diagram from the symbol palette.

| Argument Name | Description |
| -------- | -------- |
| Cancel |  Returns whether to add or remove the symbol from the diagram. |
| DiagramId | Returns the id of the diagram. |
| Element | Returns the node or connector that is dragged into a diagram. |
| Source | Returns the node or connector that is to be dragged into a diagram. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents DragEnter="DragEnter"></DiagramEvents>
</SfDiagram>

@code
{
    public void DragEnter(IBlazorDragEnterEventArgs args)
    {
        //Action to be performed.
    }
}
```

## DragLeave

Triggers when a symbol is dragged outside the diagram.

| Argument Name | Description |
| -------- | -------- |
| DiagramId | Returns the id of the diagram. |
| Element | Returns the node or connector that is dragged outside of the diagram. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents DragLeave="DragLeave"></DiagramEvents>
</SfDiagram>

@code
{
    public void DragLeave(IBlazorDragLeaveEventArgs args)
    {
        //Action to be performed.
    }
}
```

## OnDrop

Triggers when a symbol is dragged and dropped from the symbol palette to the drawing area.

| Argument Name | Description |
| -------- | -------- |
| Cancel |  Returns node or connector that is being dropped. |
| Element | Returns the node or connector that is dragged into a diagram. |
| Position | Returns the position of the object. |
| Source | Returns the object from where the element is dragged. |
| Target | Returns the object over which the object will be dropped. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents OnDrop="OnDrop"></DiagramEvents>
</SfDiagram>

@code
{
    public void OnDrop(IBlazorDropEventArgs args)
    {
        //Action to be performed.
    }
}
```

## HistoryChanged

Triggers when a change is reverted or restored(undo/redo).

| Argument Name | Description |
| -------- | -------- |
| Cause | Returns the cause of the event. |
| Change | Returns an array of objects, where each object represents the changes made in the last undo/redo. |
| Source | Returns a collection of objects that are changed in the last undo/redo. |
| Action | Returns the event action. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents HistoryChanged="HistoryChanged"></DiagramEvents>
</SfDiagram>

@code
{
    public void HistoryChanged(IBlazorHistoryChangeArgs args)
    {
        //Action to be performed.
    }
}
```

## MouseEnter

Triggered when the mouse enters a node/connector.

| Argument Name | Description |
| -------- | -------- |
| ActualObject | Returns when the mouse hovers to the target node or connector. |
| Element | Returns a parent node of the target node or connector. |
| Target | Returns the target object over which the selected object is dragged. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents MouseEnter="MouseEnter"></DiagramEvents>
</SfDiagram>

@code
{
    public void MouseEnter(IBlazorMouseEventArgs args)
    {
        //Action to be performed.
    }
}
```

## MouseLeave

Triggered when the mouse leaves node/connector.

| Argument Name | Description |
| -------- | -------- |
| ActualObject | Returns when the mouse hovers to the target node or connector. |
| Element | Returns a parent node of the target node or connector. |
| Target | Returns the target object over which the selected object is dragged. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents MouseLeave="MouseLeave"></DiagramEvents>
</SfDiagram>

@code
{
    public void MouseLeave(IBlazorMouseEventArgs args)
    {
        //Action to be performed.
    }
}
```

## OnPositionChange

Triggers while dragging the elements in a diagram.

| Argument Name | Description |
| -------- | -------- |
| Source | Returns the node or connector that is being dragged. |
| State | Returns the state of drag event (Starting, dragging, and completed). |
| NewValue | Returns the current node or connector that is being dragged. |
| OldValue | Returns the previous node or connector that is dragged. |
| Target | Returns the target node or connector that is dragged. |
| TargetPosition | Returns the offset of the selected items. |
| AllowDrop | Returns whether the object that can be dropped over the element. |
| Cancel | Returns whether to cancel the change or not. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents OnPositionChange="OnPositionChange"></DiagramEvents>
</SfDiagram>

@code
{
    public void OnPositionChange(IBlazorDraggingEventArgs args)
    {
        //Action to be performed.
    }
}
```

## PropertyChanged

Triggers once the node or connector property changed.

| Argument Name | Description |
| -------- | -------- |
| Element | Returns the selected element. |
| Cause | Returns the action is nudged or not. |
| NewValue | Returns the new value of the property that is being changed. |
| OldValue | Returns the old value of the node property that is being changed. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents PropertyChanged="PropertyChanged"></DiagramEvents>
</SfDiagram>

@code
{
    public void PropertyChanged(IBlazorPropertyChangeEventArgs args)
    {
        //Action to be performed.
    }
}
```

## OnRotateChange

Triggers when the diagram elements are rotated.

| Argument Name | Description |
| -------- | -------- |
| Source | Returns the node that is selected for rotation. |
| State | Returns the state of an event. |
| NewValue | Returns the current rotation angle. |
| OldValue | Returns the previous rotation angle. |
| Cancel | Returns whether to cancel the change or not. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents OnRotateChange="OnRotateChange"></DiagramEvents>
</SfDiagram>

@code
{
    public void OnRotateChange(IRotationEventArgs args)
    {
        //Action to be performed.
    }
}
```

## SelectionChanged

Triggers when the selection is changed in the diagram.

| Argument Name | Description |
| -------- | -------- |
| Cause | Returns the actual cause of the event. |
| State | Returns the state of an event. |
| NewValue | Returns the collection of nodes and connectors that have to be added to the selection list. |
| OldValue | Returns the collection of nodes and connectors that have to be removed from the selection list. |
| Type | Returns whether the item is added or removed from the selection list. |
| Cancel | Returns whether or not to cancel the selection change event or not. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents SelectionChanged="SelectionChanged"></DiagramEvents>
</SfDiagram>

@code
{
    public void SelectionChanged(IBlazorSelectionChangeEventArgs args)
    {
        //Action to be performed.
    }
}
```

## OnSizeChange

Triggers when a node is resized.

| Argument Name | Description |
| -------- | -------- |
| Source | Returns the node that is selected for resizing. |
| State | Returns the state of an event. |
| NewValue | Returns the new width, height, offsetX, and offsetY values of the element that is being resized. |
| OldValue | Returns the previous width, height, offsetX, and offsetY values of the element that is being resized. |
| Cancel | Returns whether or not to cancel the size change event or not. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents OnSizeChange="OnSizeChange"></DiagramEvents>
</SfDiagram>

@code
{
    public void OnSizeChange(ISizeChangeEventArgs args)
    {
        //Action to be performed.
    }
}
```

## TextEdited

Triggers when editor got focus at the time of node’s label or text node editing.

| Argument Name | Description |
| -------- | -------- |
| Element | Returns a node or connector in which annotation is being edited. |
| Annotation | Returns an annotation which that is being edited. |
| NewValue | Returns the new text value of the element that is being changed. |
| OldValue | Returns the old text value of the element. |
| Cancel | Returns whether or not to cancel the event or not. |

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Width="1000px" Height="600px">
    <DiagramEvents TextEdited="TextEdited"></DiagramEvents>
</SfDiagram>

@code
{
    public void TextEdited(IBlazorTextEditEventArgs args)
    {
        //Action to be performed.
    }
}
```

## Native events

The Diagram control provides event support, which triggers while interacting with the diagram. Also, Syncfusion provides native event support in Blazor for the following events

| Event Name | Event Type |
| -------- | -------- |
| onfocus | FocusEventArgs |
| onclick | MouseEventArgs |
| onmousemove | MouseEventArgs |
| onmouseover | MouseEventArgs |
| onmouseout | MouseEventArgs |
| onmousedown | MouseEventArgs |
| onmouseup | MouseEventArgs |
| ondblclick | MouseEventArgs |
| onkeydown | KeyboardEventArgs |
| onkeyup | KeyboardEventArgs |
| ondrop | DragEventArgs |

The native events can be defined as mentioned below. For example, the onmousedown event in diagram.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram @onmousedown="@OnMouseDown" Height="600px"/>

@code
{
    public void OnMouseDown(MouseEventArgs args)
    {
        //Action to be performed.
    }
}
```
