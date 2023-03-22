---
layout: post
title: Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Events in Blazor Diagram Component

## Selection change event

* While selecting the diagram elements, the following events can be used to do the customization.
* When selecting/unselecting the diagram elements, the following events will be triggered to do customization on those events.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[SelectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanging)|[SelectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangingEventArgs.html)|Triggers before the selection is changed in the diagram.|
|[SelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanged)|[SelectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectionChangedEventArgs.html)|Triggers when the selection is changed in the diagram.|

The following code example explains how to get the selection change event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" SelectionChanging="@OnSelectionChanging" SelectionChanged="@OnSelectionChanged"  Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events)

## Position change event

* While dragging the diagram elements, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[PositionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanging)|[PositionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangingEventArgs.html)|Triggers while dragging the elements in the diagram.|
|[PositionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanged)|[PositionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PositionChangedEventArgs.html)|Triggers when the node's/connector's position is changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" PositionChanging="@OnPositionChanging" PositionChanged="@OnPositionChanged" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events)

## Connection change event

* While changing the connection of the connector, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[ConnectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ConnectionChanging)|[ConnectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectionChangingEventArgs.html)|Triggers before the connector’s source or target point is connected or disconnected from the source or target.|
|[ConnectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ConnectionChanged)|[ConnectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectionChangedEventArgs.html)|Triggers when the connector’s source or target point is connected or disconnected from the source or target.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" ConnectionChanging="@OnConnectionChanging" ConnectionChanged="@OnConnectionChange" Height="500px" Connectors="@connectors" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Events)
## Source point change event
* While changing the source point  of the connector, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[SourcePointChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SourcePointChanging)|[EndPointChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.EndPointChangingEventArgs.html)|Triggers while dragging the connector’s source end in the diagram.|
|[SourcePointChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SourcePointChanged)|[EndPointChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.EndPointChangedEventArgs.html)|Triggers when the connector’s source point is changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" SourcePointChanging="@OnSourcePointChanging" SourcePointChanged="@OnSourcePointChanged" Height="500px" Connectors="@connectors" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
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
## Target point change event
* While changing the target point of the connector, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[TargetPointChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_TargetPointChanging)|[EndPointChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.EndPointChangingEventArgs.html)|Triggers while dragging the connector’s target end in the diagram.|
|[TargetPointChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_TargetPointChanged)|[EndPointChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.EndPointChangedEventArgs.html)|Triggers when the connector’s target point is changed|


```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" TargetChanging="@OnTargetChanging" TargetPointChanged="@OnTargetPointChanged" Height="500px" Connectors="@connectors" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
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

    //  Notify the target point changing event before the target point is change.
    private void OnTargetChanging(EndPointChangingEventArgs args)
    {
        //Set true to cancel the target point change
        args.Cancel = true;
    }

    // Notify the target point changed event after the target point has changed.
    private void OnTargetChanged(EndPointChangedEventArgs args)
    {
        //Action to be performed.
    }
}
```

## ConnectorCreating event

* The [ConnectorCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ConnectorCreating)helps to define default properties of the connector. The connector creation is triggered when the diagram is initialized. In the Connector creating event, you can customize the connector properties. 

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
        Connector connector = obj as Connector;
        connector.Style.Fill = "black";
        connector.Style.StrokeColor = "black";
        connector.Style.Opacity = 1;
        connector.TargetDecorator.Style.Fill = "black";
        connector.TargetDecorator.Style.StrokeColor = "black";
    }
```
## Segment collection change event

* The [SegmentCollectionChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SegmentCollectionChange)  triggers when the connector’s segment collection is updated. To explore about arguments, refer to the [SegmentCollectionChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SegmentCollectionChangeEventArgs.html).

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
```

## See also

* [How to customize the connector properties](./customization)

* [How to interact with the connector](./interactions)

* [How to change the segments](./segments)
