---
layout: post
title: Diagram Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Diagram events in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: DiagramComponent
documentation: ug
---

# Diagram Events in Blazor Diagram Component

## Created Event

The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Created) event is triggered when the Diagram component is rendered.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    Created="OnCreated">
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
    private void OnCreated(object args)
    {

        Diagram.Select(new ObservableCollection<IDiagramObject>() { Diagram.Nodes[0] });
    }
}
```
## Click Event

The [Click](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Click) event is triggered when a node, connector or diagram is clicked.

[ClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ClickEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| ActualObject | Returns the object to be clicked on. It returns null when there is no object present in the clicked position.|
| Count | Returns the number of times the object or diagram has to be clicked.|
| Element | Returns the object if the clicked position has an object or returns the diagram.|
| Button | Returns the mouse button that has to be clicked.|
| Position | Returns the clicked position in the diagram.|


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    Click="OnClick">
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
    private void OnClick(ClickEventArgs args)
    {

    }
}
```

## MouseEnter

The [MouseEnter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseEnter) event is triggered when the mouse enters a node or connector. 

[DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| ActualObject | Returns the the object such as a node or connector when it is dragged from the symbol palette into the diagram.|
| Element | Returns the the helper element from the symbol palette into the diagram while dragging.|
| Targets | Returns the collection of objects over which the selected items are dragged.|


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    MouseEnter="OnMouseEnter">
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
    private void OnMouseEnter(DiagramElementMouseEventArgs args)
    {

    }
}
```

## Property Changed
The [Property Changed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PropertyChanged) event is triggered when the property changed at run time.

[PropertyChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PropertyChangedEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| Element | Returns the object where the property change has occurred.|
| NewValue | Returns the new value of the property that was changed.|
| OldValue | Returns the old value of the property that was changed.|
| PropertyName | Returns the name of the property that has a property change.|

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    PropertyChanged="OnPropertyChanged>
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
     // To notify the property changed event while change property at run time.
    private void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```

## Collection change
* When the node/connector is added or removed from diagram, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[CollectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanging)|[CollectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangingEventArgs.html)|Triggers before the node/connector is adding or removing from the diagram.|
|[CollectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanged)|[CollectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangedEventArgs.html)|Triggers  the node/connector is added or removed from the diagram.|

[CollectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangingEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| Cancel | Returns the value that indicates whether to cancel the change or not.|


[CollectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangedEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| ActionTrigger |Returns current action, like Interactions, Drawing Tools, etc., to be performed in the diagram.. |
| Element | Returns the actual object which is added, removed, or modified. |
| Action | Returns the type of collection change like addition or removal. |

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    CollectionChanged="OnCollectionChanged>
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
     // To notify the Collection Changed event while change collection of node/connector at run time.
    private void OnCollectionChanged(CollectionChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```


## MouseEnter

The [MouseEnter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseEnter) event is triggered when the mouse enters a node or connector. 

[DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| ActualObject | Returns the the object such as a node or connector when it is dragged from the symbol palette into the diagram.|
| Element | Returns the the helper element from the symbol palette into the diagram while dragging.|
| Targets | Returns the collection of objects over which the selected items are dragged.|


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    MouseEnter="OnMouseEnter">
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
    private void OnMouseEnter(DiagramElementMouseEventArgs args)
    {

    }
}
```
## MouseLeave

The [MouseLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseLeave) event is triggered when the mouse leaves a node or connector.

[DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| ActualObject | Returns the the object such as a node or connector when it is dragged from the symbol palette into the diagram.|
| Element | Returns the the helper element from the symbol palette into the diagram while dragging.|
| Targets | Returns the collection of objects over which the selected items are dragged.|


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    MouseLeave="OnMouseLeave">
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
    private void OnMouseLeave(DiagramElementMouseEventArgs args)
    {

    }
}
```

## MouseHover

The [MouseHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseHover) event is triggered when the mouse pointer rests on the node or connector.

[DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| ActualObject | Returns the the object such as a node or connector when it is dragged from the symbol palette into the diagram.|
| Element | Returns the the helper element from the symbol palette into the diagram while dragging.|
| Targets | Returns the collection of objects over which the selected items are dragged.|


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    MouseLeave="OnMouseLeave">
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
    private void OnMouseLeave(DiagramElementMouseEventArgs args)
    {

    }
}
```
## KeyDown

The [KeyDown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_KeyDown) event is triggered when a user presses a key.

[KeyEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.KeyEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| Element | Returns the selected element of the diagram. palette into the diagram.|
| Key | Returns the value of the key action.|
| KeyCode | Returns a number that represents the actual key pressed.|
| KeyModifiers | Returns any modifier keys that were pressed when the flick gesture occurred.|


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                     KeyDown="@OnKeyDown">
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
    private void OnKeyDown(KeyEventArgs args)
    {

    }
}
```
## KeyUp

The [KeyDown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_KeyDown) event is triggered when a user releases a key.

[KeyEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.KeyEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| Element | Returns the selected element of the diagram. palette into the diagram.|
| Key | Returns the value of the key action.|
| KeyCode | Returns a number that represents the actual key pressed.|
| KeyModifiers | Returns any modifier keys that were pressed when the flick gesture occurred.|


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                     KeyUp="@OnKeyUp">
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
    private void OnKeyUp(KeyEventArgs args)
    {

    }
}
```
## Property Changed
The [Property Changed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PropertyChanged) event is triggered when the property changed at run time.

[PropertyChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PropertyChangedEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| Element | Returns the object where the property change has occurred.|
| NewValue | Returns the new value of the property that was changed.|
| OldValue | Returns the old value of the property that was changed.|
| PropertyName | Returns the name of the property that has a property change.|

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    PropertyChanged="OnPropertyChanged>
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
     // To notify the property changed event while change property at run time.
    private void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```

## Collection change
* When the node/connector is added or removed from diagram, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[CollectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanging)|[CollectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangingEventArgs.html)|Triggers before the node/connector is adding or removing from the diagram.|
|[CollectionChanged](https://help.syncfusion.com/cr/blazory/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanged)|[CollectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangedEventArgs.html)|Triggers  the node/connector is added or removed from the diagram.|

[CollectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangingEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| Cancel | Returns the value that indicates whether to cancel the change or not.|


[CollectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangedEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| ActionTrigger |Returns current action, like Interactions, Drawing Tools, etc., to be performed in the diagram.. |
| Element | Returns the actual object which is added, removed, or modified. |
| Action | Returns the type of collection change like addition or removal. |

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    CollectionChanged="OnCollectionChanged>
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100
        };
        nodes.Add(node);
    }
     // To notify the Collection Changed event while change collection of node/connector at run time.
    private void OnCollectionChanged(CollectionChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```

## Drag Start
* The [DragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DragStart) event is triggers when a symbol is dragged into the diagram from the symbol palette.

[DragStartEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DragStartEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| ActionTrigger |Returns current action, like Interactions, Drawing Tools, etc., to be performed in the diagram. |
| Element | Returns the node or connector over which the symbol is dragged. |
| Cancel | Returns the the value that indicates whether to add or remove the symbol from the diagram. |

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    DragStart="DragStart">
</SfDiagramComponent>
<SfSymbolPaletteComponent Height="600px" Palettes="@Palettes" SymbolDragPreviewSize="@SymbolPreview" SymbolHeight="40" GetSymbolInfo="GetSymbolInfo" SymbolWidth="40" >
</SfSymbolPaletteComponent >
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Palette> Palettes = new DiagramObjectCollection<Palette>();
    DiagramObjectCollection<NodeBase> TNodes = new DiagramObjectCollection<NodeBase>();
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    private SymbolInfo GetSymbolInfo(IDiagramObject symbol)
    {
            SymbolInfo SymbolInfo = new SymbolInfo();
            SymbolInfo.Fit = true;
            return SymbolInfo;
          }
    protected override void OnInitialized()
    {
             SymbolPreview = new DiagramSize();
             SymbolPreview.Width = 80;
             SymbolPreview.Height = 80;
             symbolSizeWidth = 50;
             symbolSizeHeight = 50;
             TNodes = new DiagramObjectCollection<NodeBase>();
             Node TNode2 = new Node()
             { 
                 ID = "node1", 
                 Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = FlowShapeType.Decision } 
             };
            TNodes.Add(TNode2);
            Palettes = new DiagramObjectCollection<Palette>()
             {
                new Palette(){Symbols =TNodes,Title="Flow Shapes",ID="Flow Shapes" },
             };
    }
     // To notify the drag start event.
    private void DragStart(DragStartEventArgs args)
    {
        //Action to be performed.
    }
}
```

## Dragging
* The [Dragging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Dragging) event is triggers when an element drags over another diagram element.

[DraggingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DraggingEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| Element |Returns node or connector that is dragged outside the diagram |
| Position | Returns the mouse position of the node/connector. |

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    Dragging="Dragging">
</SfDiagramComponent>
<SfSymbolPaletteComponent Height="600px" Palettes="@Palettes" SymbolDragPreviewSize="@SymbolPreview" SymbolHeight="40" GetSymbolInfo="GetSymbolInfo" SymbolWidth="40" >
</SfSymbolPaletteComponent >
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Palette> Palettes = new DiagramObjectCollection<Palette>();
    DiagramObjectCollection<NodeBase> TNodes = new DiagramObjectCollection<NodeBase>();
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    private SymbolInfo GetSymbolInfo(IDiagramObject symbol)
    {
            SymbolInfo SymbolInfo = new SymbolInfo();
            SymbolInfo.Fit = true;
            return SymbolInfo;
          }
    protected override void OnInitialized()
    {
             SymbolPreview = new DiagramSize();
             SymbolPreview.Width = 80;
             SymbolPreview.Height = 80;
             symbolSizeWidth = 50;
             symbolSizeHeight = 50;
             TNodes = new DiagramObjectCollection<NodeBase>();
             Node TNode2 = new Node()
             { 
                 ID = "node1", 
                 Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = FlowShapeType.Decision } 
             };
            TNodes.Add(TNode2);
            Palettes = new DiagramObjectCollection<Palette>()
             {
                new Palette(){Symbols =TNodes,Title="Flow Shapes",ID="Flow Shapes" },
             };
    }
     // To notify dragging event.
    private void Dragging(DraggingEventArgs args)
    {
        //Action to be performed.
    }
}
```

## DragDrop
* The [DragDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DragDrop) event is triggers when a symbol is dragged and dropped from the symbol palette to the drawing area.

[DropEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DropEventArgs.html)

| Argument Name | Description |
| -------- | -------- |
| Element |Returnsthe node or connector that is being dropped. |
| Target | Returns the object from which the object will be dropped. |
| Cancel | Returns the  value that indicates whether to cancel the drop event or not. |
| Position | Returnsthe position of the object. |

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    DragDrop="DragDrop">
</SfDiagramComponent>
<SfSymbolPaletteComponent Height="600px" Palettes="@Palettes" SymbolDragPreviewSize="@SymbolPreview" SymbolHeight="40" GetSymbolInfo="GetSymbolInfo" SymbolWidth="40" >
</SfSymbolPaletteComponent >
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Palette> Palettes = new DiagramObjectCollection<Palette>();
    DiagramObjectCollection<NodeBase> TNodes = new DiagramObjectCollection<NodeBase>();
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    private SymbolInfo GetSymbolInfo(IDiagramObject symbol)
    {
            SymbolInfo SymbolInfo = new SymbolInfo();
            SymbolInfo.Fit = true;
            return SymbolInfo;
          }
    protected override void OnInitialized()
    {
             SymbolPreview = new DiagramSize();
             SymbolPreview.Width = 80;
             SymbolPreview.Height = 80;
             symbolSizeWidth = 50;
             symbolSizeHeight = 50;
             TNodes = new DiagramObjectCollection<NodeBase>();
             Node TNode2 = new Node()
             { 
                 ID = "node1", 
                 Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = FlowShapeType.Decision } 
             };
            TNodes.Add(TNode2);
            Palettes = new DiagramObjectCollection<Palette>()
             {
                new Palette(){Symbols =TNodes,Title="Flow Shapes",ID="Flow Shapes" },
             };
    }
     // To notify drag drop event.
    private void DragDrop(DropEventArgs args)
    {
        //Action to be performed.
    }
}
```