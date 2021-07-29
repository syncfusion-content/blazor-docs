---
layout: post
title: Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Events in Blazor Diagram Component

## Selection change

The [`SelectionChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramEvents.html#Syncfusion_Blazor_Diagrams_DiagramEvents_SelectionChanged) event is triggered when select or unselect the node or connector. The [`IBlazorSelectionChangeEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IBlazorSelectionChangeEventArgs.html) interface is used to get selection change event arguments.

The following code example explains how to get the selection change event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Connectors="@ConnectorCollection">
    <DiagramEvents SelectionChanged="@SelectionChanged"></DiagramEvents>
</SfDiagram>
@code
{
    //Defines diagram's connector collection
    public ObservableCollection<DiagramConnector> ConnectorCollection = new ObservableCollection<DiagramConnector>();

    protected override void OnInitialized()
    {
        DiagramConnector diagramConnector = new DiagramConnector()
        {
            Id = "Connector1",
            SourcePoint = new ConnectorSourcePoint() { X = 100, Y = 100 },
            TargetPoint = new ConnectorTargetPoint() { X = 200, Y = 200 },
            TargetDecorator = new ConnectorTargetDecorator()
            {
                Shape = DecoratorShapes.Arrow,
                Style = new DecoratorShapeStyle() { Fill = "#6f409f", StrokeColor = "#6f409f", StrokeWidth = 1 }
            },
            Style = new ConnectorShapeStyle() { StrokeColor = "#6f409f", StrokeWidth = 1 },
            Type = Segments.Orthogonal
        };
        ConnectorCollection.Add(diagramConnector);
    }
    // SelectionChange event for diagram
    public void SelectionChanged(IBlazorSelectionChangeEventArgs args)
    {
        Console.WriteLine(args.NewValue.Connectors[0].Id);
    }
}
```

## Position change

The [`OnPositionChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramEvents.html#Syncfusion_Blazor_Diagrams_DiagramEvents_OnPositionChange) events is triggered when drag the node or connector in interaction. The [`IBlazorDraggingEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IBlazorDraggingEventArgs.html) interface is used to get position change event arguments.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Connectors="@ConnectorCollection">
    <DiagramEvents OnPositionChange="@OnPositionChange"></DiagramEvents>
</SfDiagram>
@code
{
    //Defines diagram's connector collection
    public ObservableCollection<DiagramConnector> ConnectorCollection = new ObservableCollection<DiagramConnector>();

    protected override void OnInitialized()
    {
        DiagramConnector diagramConnector = new DiagramConnector()
        {
            Id = "Connector1",
            SourcePoint = new ConnectorSourcePoint() { X = 100, Y = 100 },
            TargetPoint = new ConnectorTargetPoint() { X = 200, Y = 200 },
            TargetDecorator = new ConnectorTargetDecorator()
            {
                Shape = DecoratorShapes.Arrow,
                Style = new DecoratorShapeStyle() { Fill = "#6f409f", StrokeColor = "#6f409f", StrokeWidth = 1 }
            },
            Style = new ConnectorShapeStyle() { StrokeColor = "#6f409f", StrokeWidth = 1 },
            Type = Segments.Orthogonal
        };
        ConnectorCollection.Add(diagramConnector);
    }
    // Position change event for diagram
    public void OnPositionChange(IBlazorDraggingEventArgs args)
    {
        Console.WriteLine(args.NewValue.Connectors[0].Id);
    }
}
```

## Connection change

The [`OnConnectionChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramEvents.html#Syncfusion_Blazor_Diagrams_DiagramEvents_OnConnectionChange) event will notify when the connection is changed. The [`IBlazorConnectionChangeEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IBlazorConnectionChangeEventArgs.html) interface is used to get event arguments.

```csharp

@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Connectors="@ConnectorCollection" Constraints="@diagramConstraints">
  <DiagramEvents OnConnectionChange="@OnConnectionChange"></DiagramEvents>
</SfDiagram>

@code
{
    //Defines diagram's connector collection
    public ObservableCollection<DiagramConnector> ConnectorCollection = new ObservableCollection<DiagramConnector>();

    //Defines diagram's constraints values.
    public DiagramConstraints diagramConstraints = DiagramConstraints.Default;
    private void OnConnectionChange(IBlazorConnectionChangeEventArgs args)
    {
        Console.WriteLine("Oldvalue", args.OldValue);
        Console.WriteLine("NewValue", args.NewValue);
    }
    protected override void OnInitialized()
    {
        DiagramConnector diagramConnector = new DiagramConnector()
        {
            SourcePoint = new ConnectorSourcePoint() { X = 100, Y = 100 },
            TargetPoint = new ConnectorTargetPoint() { X = 200, Y = 200 },
            TargetDecorator = new ConnectorTargetDecorator()
            {
                Shape = DecoratorShapes.Arrow,
                Style = new DecoratorShapeStyle() { Fill = "#6f409f", StrokeColor = "#6f409f", StrokeWidth = 1 }
            },
            Style = new ConnectorShapeStyle() { StrokeColor = "#6f409f", StrokeWidth = 1 },
            Type = Segments.Straight,
        };
        //Add the connector into connectors's collection.
        ConnectorCollection.Add(diagramConnector);
    }
}

```

## See also

* [`How to customize the connector properties`](./customization)

* [`How to interact the connector`](./interactions)

* [`How to change the segments`](./segments)