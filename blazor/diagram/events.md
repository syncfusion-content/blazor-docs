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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/CreatedEvent)
## Click Event

The [Click](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Click) event is triggered when a node, connector, or a diagram is clicked. To explore about arguments, refer to the [ClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ClickEventArgs.html)


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

## PropertyChanged Event
The [Property Changed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PropertyChanged) event is triggered when the property changed at run time. To explore about arguments, refer to[PropertyChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PropertyChangedEventArgs.html)

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
     // Notify the property changed event while the change property is at run time.
    private void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```

## CollectionChange Event
* When the node or connector is added or removed from the diagram, the following events are used for customization. It triggers when the node or connector collection is changed.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[CollectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanging)|[CollectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangingEventArgs.html)|Triggers before the node or connector is added or removed from the diagram.|
|[CollectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanged)|[CollectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangedEventArgs.html)|Triggers after the node or connector is added or removed from the diagram|


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
     //  Notify the Collection Changed event while changing the collection of the node or connector at run time.
    private void OnCollectionChanged(CollectionChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```


## MouseEnter Event

The [MouseEnter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseEnter)  event is triggered when the mouse enters a node or connector. To explore about arguments, refer to the [DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html)


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
## MouseLeave Event

The [MouseLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseLeave) event is triggered when the mouse leaves a node or connector. To explore about arguments, refer to the [DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html)


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

## MouseHover Event

The [MouseHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseHover)  event is triggered when the mouse pointer rests on the node or connector. To explore about arguments, refer to the[DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html)


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    MouseHover="OnMouseHover">
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
    private void OnMouseHover(DiagramElementMouseEventArgs args)
    {

    }
}
```
## KeyDown Event

The [KeyDown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_KeyDown) event is triggered when the user presses a key. To explore about arguments, refer to the [KeyEventArgs]https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.KeyEventArgs.html)


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
## KeyUp Event

The [KeyUp](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_KeyUp)event is triggered when a user releases a key. To explore about arguments, refer to the [KeyEventArgs]https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.KeyEventArgs.html)


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

## DragStart Event
* The [DragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DragStart) event is triggered when a symbol is dragged into the diagram from the symbol palette. To explore about arguments, refer to the [DragStartEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DragStartEventArgs.html)

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
     //Notify the drag start event.
    private void DragStart(DragStartEventArgs args)
    {
        //Action to be performed.
    }
}
```

## Dragging Event
* The [Dragging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Dragging) event is triggered when an element drags over another diagram element. To explore about arguments, refer to the [DraggingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DraggingEventArgs.html)



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
     // Notify the dragging event.
    private void Dragging(DraggingEventArgs args)
    {
        //Action to be performed.
    }
}
```
## DragLeave Event
* The [DragLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DragLeave) event is triggered when an element drags over another diagram element. To explore about arguments, refer to the[DragLeaveEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DragLeaveEventArgs.html)



```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    Dragging="DragLeave">
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
     // Notify the DragLeave event.
    private void DragLeave(DragLeaveEventArgs args)
    {
        //Action to be performed.
    }
}
```

## DragDrop Event
* The [DragDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DragDrop) event is triggered when a symbol is dragged and dropped from the symbol palette to the drawing area. To explore about arguments, refer to the [DropEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DropEventArgs.html)


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
     // Notify the DragDrop event.
    private void DragDrop(DropEventArgs args)
    {
        //Action to be performed.
    }
}
```
