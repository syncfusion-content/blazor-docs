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

The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Created) event is triggered when the Diagram component is rendered. You can perform any action in the created event such as selecting any object in the diagram.

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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/ClickEvent)

## PropertyChanged Event
The [Property Changed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PropertyChanged) event is triggered when the property changed at run time. To explore about arguments, refer to [PropertyChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PropertyChangedEventArgs.html)

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    PropertyChanged="OnPropertyChanged">
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/PropertyChangedEvent)

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
                    CollectionChanged="OnCollectionChanged">
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/CollectionChangeEvent)

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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/MouseEnterEvent)

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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/MouseLeaveEvent)

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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/MouseHoverEvent)

## KeyDown Event

The [KeyDown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_KeyDown) event is triggered when the user presses a key. To explore about arguments, refer to the [KeyEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.KeyEventArgs.html)


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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/KeyDownEvent)

## KeyUp Event

The [KeyUp](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_KeyUp)event is triggered when a user releases a key. To explore about arguments, refer to the [KeyEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.KeyEventArgs.html)


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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/KeyUpEvent)

## DragStart Event
* The [DragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DragStart) event is triggered when a symbol is dragged into the diagram from the symbol palette. To explore about arguments, refer to the [DragStartEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DragStartEventArgs.html)

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.SymbolPalette
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    DragStart="DragStart">
</SfDiagramComponent>
<SfSymbolPaletteComponent @ref="PaletteInstance" Height="600px" Palettes="@Palettes"  SymbolHeight="40" GetSymbolInfo="GetSymbolInfo" SymbolWidth="40" >
</SfSymbolPaletteComponent >
@code{
    SfDiagramComponent Diagram;
    SfSymbolPaletteComponent PaletteInstance;
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
             TNodes = new DiagramObjectCollection<NodeBase>();
             Node TNode2 = new Node()
             { 
                 ID = "node1", 
                 Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = NodeFlowShapes.Decision } 
             };
            TNodes.Add(TNode2);
            Palettes = new DiagramObjectCollection<Palette>()
             {
                new Palette(){Symbols =TNodes,Title="Flow Shapes",ID="Flow Shapes" },
             };
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        PaletteInstance.Targets = new DiagramObjectCollection<SfDiagramComponent>() { };
        PaletteInstance.Targets.Add(Diagram);
    }
     //Notify the drag start event.
    private void DragStart(DragStartEventArgs args)
    {
        //Action to be performed.
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/DragStartEvent)


## Dragging Event
* The [Dragging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Dragging) event is triggered when an element drags over another diagram element. To explore about arguments, refer to the [DraggingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DraggingEventArgs.html)



```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.SymbolPalette
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    Dragging="Dragging">
</SfDiagramComponent>
<SfSymbolPaletteComponent Height="600px" Palettes="@Palettes"  SymbolHeight="40" GetSymbolInfo="GetSymbolInfo" SymbolWidth="40" >
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
             TNodes = new DiagramObjectCollection<NodeBase>();
             Node TNode2 = new Node()
             { 
                 ID = "node1", 
                 Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = NodeFlowShapes.Decision } 
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/DraggingEvent)

## DragLeave Event
* The [DragLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DragLeave) event is triggered when an element drags over another diagram element. To explore about arguments, refer to the[DragLeaveEventArgs](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/DragLeaveEvent)



```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
@using Syncfusion.Blazor.Diagram.SymbolPalette

<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Nodes="nodes"
                    DragLeave="DragLeave">
</SfDiagramComponent>
<SfSymbolPaletteComponent Height="600px" Palettes="@Palettes" SymbolDragPreviewSize="@SymbolPreview" SymbolHeight="40" GetSymbolInfo="GetSymbolInfo" SymbolWidth="40" >
</SfSymbolPaletteComponent >
@code{
    SfDiagramComponent Diagram;
    DiagramSize SymbolPreview;
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
             TNodes = new DiagramObjectCollection<NodeBase>();
             Node TNode2 = new Node()
             { 
                 ID = "node1", 
                 Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = NodeFlowShapes.Decision} 
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events)

## DragDrop Event
* The [DragDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DragDrop) event is triggered when a symbol is dragged and dropped from the symbol palette to the drawing area. To explore about arguments, refer to the [DropEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DropEventArgs.html)


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
@using Syncfusion.Blazor.Diagram.SymbolPalette

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
    DiagramSize SymbolPreview;
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
             TNodes = new DiagramObjectCollection<NodeBase>();
             Node TNode2 = new Node()
             { 
                 ID = "node1", 
                 Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = NodeFlowShapes.Decision } 
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/DragDrop)

## OnAutoScrollChange Event
The [OnAutoScrollChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_OnAutoScrollChange)  event is triggered with [AutoScrollChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AutoScrollChangeEventArgs.html) argument when changes are detected to the scroll position, extent, or viewport size as a result of auto-scrolling for diagram elements.

The [AutoScrollChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AutoScrollChangeEventArgs.html) include the following options:
* [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AutoScrollChangeEventArgs.html#Syncfusion_Blazor_Diagram_AutoScrollChangeEventArgs_Cancel) - Auto-scrolling can be stopped by setting to true to this property.
* [Item](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AutoScrollChangeEventArgs.html#Syncfusion_Blazor_Diagram_AutoScrollChangeEventArgs_Item) -  Represents a diagram element that is currently being auto-scrolled.
* [Delay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AutoScrollChangeEventArgs.html#Syncfusion_Blazor_Diagram_AutoScrollChangeEventArgs_Delay) - The amount of time to wait from applying the auto scroll to the diagram element before beginning to perform the auto scroll can be controlled by setting TimeSpan value to this property.


```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent Height="400px" Width="400px" Nodes="@nodes" Connectors="@connectors" OnAutoScrollChange="AutoScrollChange">
    @* Sets the ScrollSettings for the diagram *@
    <ScrollSettings EnableAutoScroll=true AutoScrollPadding="@autoScrollBorder" @bind-ScrollLimit="@ScrollLimit">
    </ScrollSettings>
</SfDiagramComponent>
@code
{
    ScrollLimitMode ScrollLimit { get; set; } = ScrollLimitMode.Infinity;
    DiagramObjectCollection<Node> nodes;
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    DiagramMargin autoScrollBorder = new DiagramMargin() { Left = 30, Right = 30, Top = 30, Bottom = 30 };
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in the nodes collection.
        Node node = new Node()
            {
                ID = "node1",
                // Position of the node.
                OffsetX = 250,
                OffsetY = 250,
                // Size of the node.
                Width = 100,
                Height = 100,
                Style = new ShapeStyle()
                {
                    Fill = "#6495ED",
                    StrokeColor = "white"
                }
            };
        // Add node.
        nodes.Add(node);
        Connector Connector = new Connector()
            {
                ID = "connector1",
                // Set the source and target point of the connector.
                SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
                TargetPoint = new DiagramPoint() { X = 100, Y = 200 },
                // Type of the connector segments.
                Type = ConnectorSegmentType.Straight,
                Style = new ShapeStyle()
                {
                    StrokeColor = "#6495ED",
                    StrokeWidth = 1
                },
            };
        connectors.Add(Connector);
    }
    private void AutoScrollChange(AutoScrollChangeEventArgs args)
    {
        args.Cancel = false;
        args.Delay = new TimeSpan(0, 0, 0, 1, 0);
    }
}
```

![Speed Limit control in autoScroll support for node](images/SpeedLimitNodeConnector.gif) 

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Events/OnAutoScrollChange)