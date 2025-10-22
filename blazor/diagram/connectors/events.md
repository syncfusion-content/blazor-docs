---
layout: post
title: Events in Syncfusion Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Connector Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Events in Diagram Component

## How to Handle Selection Change Event

* While selecting the diagram elements, the following events can be used to do the customization.
* `SelectionChanging` occurs before the selection is committed and can be canceled; `SelectionChanged` occurs after selection is updated and is typically used for UI updates or logging.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[SelectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanging)|[SelectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangingEventArgs.html)|Occurs before the selection has changed in the diagram.|
|[SelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanged)|[SelectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangedEventArgs.html)|Occurs after the selection has changed in the diagram.|

The following code example explains how to get the selection change event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" SelectionChanging="@OnSelectionChanging" SelectionChanged="@OnSelectionChanged"  Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    //Reference the diagram.
    SfDiagramComponent Diagram;
    //Initialize the diagram's connector collection
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
        };
        connectors.Add(Connector);
    }

    // To notify the selection changing event before selecting/unselecting the diagram elements.
    public void OnSelectionChanging(SelectionChangingEventArgs args)
    {
    //Sets true to cancel the selection.
    args.Cancel = true;
    }

    // To notify the selection is changed in the diagram.
    private void OnSelectionChanged(SelectionChangedEventArgs arg)
    {
        //Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhyCDtnzispxatP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/SelectionChangeEvent).

## How to Handle Position Change Event

* While dragging the diagram elements, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[PositionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanging)|[PositionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangingEventArgs.html)|Occurs while dragging the elements in the diagram.|
|[PositionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanged)|[PositionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangedEventArgs.html)|Occurs when the node's or connector's position has changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" PositionChanging="@OnPositionChanging" PositionChanged="@OnPositionChanged" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    //Reference the diagram.
    SfDiagramComponent Diagram;
    //Initialize the diagram's connectors collection
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
        };
        connectors.Add(Connector);
    }

    // To notify the position changing event before dragging the diagram elements.
    public void OnPositionChanging(PositionChangingEventArgs args)
    {
    //Sets true to cancel the dragging.
    args.Cancel = true;
    }

    // To notify the position changed event after dragging the diagram elements.
    private void OnPositionChanged(PositionChangedEventArgs arg)
    {
        //Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZrIWDjdJMBXdkEx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/PositionChangeEvent).

## How to Handle Connection Change Event

* While changing the connection of the connector, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[ConnectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ConnectionChanging)|[ConnectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectionChangingEventArgs.html)|Occurs before the connector’s source or target point is connected or disconnected from the source or target.|
|[ConnectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ConnectionChanged)|[ConnectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectionChangedEventArgs.html)|Occurs when the connector’s source or target point is connected or disconnected from the source or target.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" ConnectionChanging="@OnConnectionChanging" ConnectionChanged="@OnConnectionChange" Height="500px" Connectors="@connectors" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    //Reference the diagram.
    SfDiagramComponent Diagram;
    //Initialize the diagram's connectors collection
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
      //Initialize the diagram's nodes collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

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
          },
        };
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            TargetID = "node1",
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
        };
        connectors.Add(Connector);
    }

    // To notify the connection changing event before the connection change.
    private void OnConnectionChanging(ConnectionChangingEventArgs args)
    {
        //Sets true to cancel the connection change.
        args.Cancel = true;
    }

    // To notify the connection changed event after the connection has changed.
    private void OnConnectionChange(ConnectionChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLSiZXnfsORuETx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/ConnectionChangeEvent)

## How to Handle Source Point Change Event
* While changing the source point of the connector, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[SourcePointChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SourcePointChanging)|[EndPointChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.EndPointChangingEventArgs.html)|Occurs while dragging the connector’s source end in the diagram.|
|[SourcePointChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SourcePointChanged)|[EndPointChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.EndPointChangedEventArgs.html)|Occurs after the connector’s source point has changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" SourcePointChanging="@OnSourcePointChanging" SourcePointChanged="@OnSourcePointChanged" Height="500px" Connectors="@connectors" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    //Reference the diagram.
    SfDiagramComponent Diagram;
    //Initialize the diagram's connectors collection
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    //Initialize the diagram's nodes collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            TargetPoint = new DiagramPoint()
            {
                X = 300,
                Y = 400,
            }
        };
        connectors.Add(Connector);
    }

    //Notify the source point changing event before the source point change.
    private void OnSourcePointChanging(EndPointChangingEventArgs args)
    {
        //Set true to cancel the source point change.
        args.Cancel = true;
    }

    // Notify the source point changed event after the source point has changed.
    private void OnSourcePointChanged(EndPointChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhICZXRfhZiGtIF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/SourcePointChanged)

## How to Handle Target Point Change Event
* While changing the target point of the connector, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[TargetPointChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_TargetPointChanging)|[EndPointChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.EndPointChangingEventArgs.html)|Occurs while dragging the connector’s target end in the diagram.|
|[TargetPointChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_TargetPointChanged)|[EndPointChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.EndPointChangedEventArgs.html)|Occurs after the connector’s target point has changed|


```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" TargetPointChanging="@OnTargetPointChanging" TargetPointChanged="@OnTargetPointChanged" Height="500px" Connectors="@connectors" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    //Reference the diagram.
    SfDiagramComponent Diagram;
    //Initialize the diagram's connectors collection
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    //Initialize the diagram's nodes collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
            {
                ID = "connector1",
                SourcePoint = new DiagramPoint()
                {
                    X = 200,
                    Y = 200
                },
                TargetPoint = new DiagramPoint()
                {
                    X = 300,
                    Y = 400,
                }
            };
        connectors.Add(Connector);
    }


    // Notify the target point changed event before the target point has changed.
    private void OnTargetPointChanging(EndPointChangingEventArgs args)
    {
        //Action to be performed.
    }
    // Notify the target point changed event after the target point has changed.
    private void OnTargetPointChanged(EndPointChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVSiXtHpVXnCpui?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/TargetPointChanged)

## How to Handle Connector Creating Event

* Use this event to set default properties when connectors are created. The event is raised as connectors are initialized, allowing customization of connector appearance and behavior.
* The [ConnectorCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ConnectorCreating) event helps to define default properties of the connector.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Connectors="@connectors" 
                    ConnectorCreating="OnConnectorCreating" />

@code
{
    // Define the connector collection.
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        //A connector is created and stored in the connectors collection.
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            TargetPoint = new DiagramPoint()
            {
                X = 300,
                Y = 400,
            }
        };
        connectors.Add(Connector);
    }

    public void OnConnectorCreating(IDiagramObject args)
    { 
        Connector connector = args as Connector;
        connector.Style.Fill = "black";
        connector.Style.StrokeColor = "black";
        connector.Style.Opacity = 1;
        connector.TargetDecorator.Style.Fill = "black";
        connector.TargetDecorator.Style.StrokeColor = "black";
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrIWXjdfViroMCT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/ConnectorCreating)

## How to Handle Segment Collection Change Event

* The [SegmentCollectionChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SegmentCollectionChange) event triggers when the connector’s segment collection is updated. To explore about arguments, refer to the [SegmentCollectionChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SegmentCollectionChangeEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" 
                    Connectors="@connectors" 
                    SegmentCollectionChange="SegmentCollectionChange" />

@code
{
    // Define the connector collection.
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        //A connector is created and stored in the connectors collection.
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            TargetPoint = new DiagramPoint()
            {
                X = 300,
                Y = 400,
            }
        };
        connectors.Add(Connector);
    }

    public void SegmentCollectionChange(SegmentCollectionChangeEventArgs args)
    { 
       
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBSMZXHTrpgeJhU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/SegmentCollectionChangeEvent)

## How to Handle Collection Change Events

* The following events are raised when elements are added to or removed from the diagram. `CollectionChanging` occurs before the update (cancellable), and `CollectionChanged` occurs after the update.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[CollectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanging)|[CollectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangingEventArgs.html)|Occurs before a element is added or removed from the diagram.|
|[CollectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanged)|[CollectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangedEventArgs.html)|Occurs after a element is added or removed from the diagram|


```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Connectors="@connectors"
                    CollectionChanged="OnCollectionChanged">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
          Connector Connector = new Connector()
        {
            ID = "connector1",
            // Set the source and target point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            // Type of the connector segments.
            Type = ConnectorSegmentType.Straight
        };
        connectors.Add(Connector);
    }
     //  Notify the Collection Changed event while changing the collection of the connector at run time.
    private void OnCollectionChanged(CollectionChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVoCDNnpVAEjlgO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/CollectionChangeEvent)

## How to Handle the Mouse Enter Event

The [MouseEnter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_MouseEnter) event is raised when the mouse pointer enters the boundary of a connector in the diagram and provides valuable information about the element being interacted with. For a comprehensive understanding of the event arguments and their properties, refer to the [DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html).


```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Connectors="@connectors"
                    MouseEnter="OnMouseEnter">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
          Connector Connector = new Connector()
        {
            ID = "connector1",
            // Set the source and target point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            // Type of the connector segments.
            Type = ConnectorSegmentType.Straight
        };
        connectors.Add(Connector);
    }
    private void OnMouseEnter(DiagramElementMouseEventArgs args)
    {
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtVoCjXHTrIsWtog?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/MouseEnterEvent)

## How to Handle the Mouse Leave Event

The [MouseLeave](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/MouseLeaveEvent) event is raised when the mouse pointer exits the boundaries of a connector in the diagram and provides valuable information about the element being left. For a comprehensive understanding of the event arguments and their properties, refer to the [DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html). 


```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Connectors="@connectors"
                    MouseLeave="OnMouseLeave">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
          Connector Connector = new Connector()
        {
            ID = "connector1",
            // Set the source and target point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            // Type of the connector segments.
            Type = ConnectorSegmentType.Straight
        };
        connectors.Add(Connector);
    }
    private void OnMouseLeave(DiagramElementMouseEventArgs args)
    {
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhSWNXnJLoppsUR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/MouseLeaveEvent).

## How to Handle the Mouse Hover Event

The [MouseHover](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/MouseHoverEvent) event is raised when the mouse pointer hovers over a connector in the diagram and provides valuable information about the element being hovered. For detailed information about the event arguments, refer to the [DiagramElementMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramElementMouseEventArgs.html).


```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="@Diagram"
                    Width="100%"
                    Height="700px"
                    Connectors="@connectors"
                    MouseHover="OnMouseHover">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
         Connector Connector = new Connector()
        {
            ID = "connector1",
            // Set the source and target point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            // Type of the connector segments.
            Type = ConnectorSegmentType.Straight
        };
        connectors.Add(Connector);
    }
    private void OnMouseHover(DiagramElementMouseEventArgs args)
    {
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDroiZXnJhdsQvix?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/MouseHoverEvent).

## How to Handle Property Changed Event

The [Property Changed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PropertyChanged) event is raised when connector's property of the diagram component is modified at runtime. This event provides valuable information about the changes occurring in the diagram. For a detailed understanding of the event arguments, refer to the [PropertyChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PropertyChangedEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="@diagram" 
                    Width="100%" 
                    Height="700px" 
                    Connectors="@connectors"
                    PropertyChanged="OnNodePropertyChanged">
</SfDiagramComponent>
@code {
    SfDiagramComponent diagram;
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
          Connector Connector = new Connector()
        {
            ID = "connector1",
            // Set the source and target point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            // Type of the connector segments.
            Type = ConnectorSegmentType.Straight
        };
        connectors.Add(Connector);
    }
    // Method to handle Property Changed event
    private void OnNodePropertyChanged(PropertyChangedEventArgs args)
    {
        if (args.Element is Connector changedNode)
        {
            // Logic to handle the property change for the specific connector
            Console.WriteLine($"Node ID: {changedNode.ID} property changed.");
            // Additional logic to handle updates
        }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrIsNNxfhRxEZXL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events/PropertyChangedEvent)


## See also

* [How to customize the connector properties](./customization)

* [How to interact with the connector](./interactions)

* [How to change the segments](./segments)

* [How to Connect Visio While Dropping Node in Existing Blazor Diagram](https://support.syncfusion.com/kb/article/11181/how-to-connect-visio-while-dropping-node-in-existing-blazor-diagram)