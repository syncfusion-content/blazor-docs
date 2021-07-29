---
layout: post
title: Layers in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Layers in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Layers in Blazor Diagram Component

**Layer** is used to organize related shapes on a diagram control. A layer is a named category of shapes. By assigning shapes to different layers, you can selectively view, remove, and lock different categories of shapes.

In diagram, [`Layers`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramLayer.html) provide a way to change the properties of all shapes that have been assigned to that layer. The following properties can be set.

* Visible
* Lock
* Objects
* AddInfo

## Visible

The layer's [`Visible`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramLayer.html#Syncfusion_Blazor_Diagrams_DiagramLayer_Visible) property is used to control the visibility of the elements assigned to the layer.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

   <SfDiagram Height="600px" Nodes="@NodeCollection" Connectors="@ConnectorCollection" Layers="@Layers">
   </SfDiagram>

@code{
    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>() { };
    public ObservableCollection<DiagramConnector> ConnectorCollection = new ObservableCollection<DiagramConnector>() { };
    public ObservableCollection<DiagramLayer> Layers = new ObservableCollection<DiagramLayer>() { };
    protected override void OnInitialized()
    {
        // A node is created and stored in nodes array.
        DiagramNode node1 = new DiagramNode()
        {
            Id = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation(){ Content = "Default Shape"}
            }
        };
        NodeCollection.Add(node1);

        DiagramNode node2 = new DiagramNode()
        {
            Id = "node2",
            OffsetX = 300,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation(){ Content = "Path Element"}
            },
            Shape = new DiagramShape()
            {
                Type = Syncfusion.Blazor.Diagrams.Shapes.Path,
                Data = "M540.3643,137.9336L546.7973,159.7016L570.3633,159.7296L550.7723,171.9366L558.9053,194.9966L540.3643," +
                "179.4996L521.8223,194.9966L529.9553,171.9366L510.3633,159.7296L533.9313,159.7016L540.3643,137.9336z"
            }
        };
        NodeCollection.Add(node2);
        DiagramConnector connector1 = new DiagramConnector()
        {
            Id = "connector1",
            SourcePoint = new ConnectorSourcePoint() { X = 100, Y = 300 },
            TargetPoint = new ConnectorTargetPoint() { X = 200, Y = 400 },
            Type = Segments.Straight
        };
        ConnectorCollection.Add(connector1);
        string[] objects = new string[] { "node1" };
        // initialize Layers
        Layers.Add(new DiagramLayer() { Id = "Layer1", Visible = true, Objects = objects });
    }
}

```

## Lock

The layer's [`Lock`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramLayer.html#Syncfusion_Blazor_Diagrams_DiagramLayer_Lock) property is used to prevent or allow changes to the elements dimension and position.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

   <SfDiagram Height="600px" Nodes="@NodeCollection" Connectors="@ConnectorCollection" Layers="@Layers">
   </SfDiagram>

@code{
     public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>() { };
    public ObservableCollection<DiagramConnector> ConnectorCollection = new ObservableCollection<DiagramConnector>() { };
    public ObservableCollection<DiagramLayer> Layers = new ObservableCollection<DiagramLayer>() { };
    protected override void OnInitialized()
    {
        // A node is created and stored in nodes array.
        DiagramNode node1 = new DiagramNode()
        {
            Id = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation(){ Content = "Default Shape"}
            }
        };
        NodeCollection.Add(node1);

        DiagramNode node2 = new DiagramNode()
        {
            Id = "node2",
            OffsetX = 300,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation(){ Content = "Path Element"}
            },
            Shape = new DiagramShape()
            {
                Type = Syncfusion.Blazor.Diagrams.Shapes.Path,
                Data = "M540.3643,137.9336L546.7973,159.7016L570.3633,159.7296L550.7723,171.9366L558.9053,194.9966L540.3643," +
                "179.4996L521.8223,194.9966L529.9553,171.9366L510.3633,159.7296L533.9313,159.7016L540.3643,137.9336z"
            }
        };
        NodeCollection.Add(node2);
        DiagramConnector connector1 = new DiagramConnector()
        {
            Id = "connector1",
            SourcePoint = new ConnectorSourcePoint() { X = 100, Y = 300 },
            TargetPoint = new ConnectorTargetPoint() { X = 200, Y = 400 },
            Type = Segments.Straight
        };
        ConnectorCollection.Add(connector1);
        string[] objects = new string[] { "node1" };
        string[] objects1 = new string[] { "node2" };
        Layers.Add(new DiagramLayer() { Id = "Layer1", Visible = true, Objects = objects, Lock = true });
        Layers.Add(new DiagramLayer() { Id = "layer2", Visible = true, Objects = objects1, Lock = false });

    }
}

```

## Objects

The layer's [`Objects`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramLayer.html#Syncfusion_Blazor_Diagrams_DiagramLayer_Objects) property defines the diagram elements to the layer.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

   <SfDiagram Height="600px" Nodes="@NodeCollection" Connectors="@ConnectorCollection" Layers="@Layers">
   </SfDiagram>

@code{
    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>() {};
    public ObservableCollection<DiagramConnector> ConnectorCollection = new ObservableCollection<DiagramConnector>() { };
    public ObservableCollection<DiagramLayer> Layers = new ObservableCollection<DiagramLayer>() { };
    protected override void OnInitialized()
    {
        // A node is created and stored in nodes array.
        DiagramNode node1 = new DiagramNode()
        {
            Id = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation(){ Content = "Default Shape"}
            }
        };
        NodeCollection.Add(node1);

        DiagramNode node2 = new DiagramNode()
        {
            Id = "node2",
            OffsetX = 300,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation(){ Content = "Path Element"}
            },
            Shape = new DiagramShape()
            {
                Type = Syncfusion.Blazor.Diagrams.Shapes.Path,
                Data = "M540.3643,137.9336L546.7973,159.7016L570.3633,159.7296L550.7723,171.9366L558.9053,194.9966L540.3643," +
                "179.4996L521.8223,194.9966L529.9553,171.9366L510.3633,159.7296L533.9313,159.7016L540.3643,137.9336z"
            }
        };
        NodeCollection.Add(node2);
        DiagramConnector connector1 = new DiagramConnector()
        {
            Id = "connector1",
            SourcePoint = new ConnectorSourcePoint() { X = 100, Y = 300 },
            TargetPoint = new ConnectorTargetPoint() { X = 200, Y = 400 },
            Type = Segments.Straight
        };
        ConnectorCollection.Add(connector1);
        string[] objects = new string[] { "node1" ,"node2"};
        string[] objects1 = new string[] { "node2" };
        Layers.Add(new DiagramLayer() { Id = "Layer1", Visible = true, Objects = objects });
        Layers.Add(new DiagramLayer() { Id = "layer2", Visible = true, Objects = objects1});

    }
}
```

## AddInfo

The [`AddInfo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramLayer.html#Syncfusion_Blazor_Diagrams_DiagramLayer_AddInfo) property of layers allow you to maintain additional information to the layers.

The following code illustrates how to add additional information to the layers.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

   <SfDiagram Height="600px" Nodes="@NodeCollection" Connectors="@ConnectorCollection" Layers="@Layers">
   </SfDiagram>

@code{

    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>() { };
    public ObservableCollection<DiagramConnector> ConnectorCollection = new ObservableCollection<DiagramConnector>() { };
    public ObservableCollection<DiagramLayer> Layers = new ObservableCollection<DiagramLayer>() { };
    public class AdditionalInfo
    {
        public string Description { get; set; }
    };
    protected override void OnInitialized()
    {
        // A node is created and stored in nodes array.
        DiagramNode node1 = new DiagramNode()
        {
            Id = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation(){ Content = "Default Shape"}
            }
        };
        NodeCollection.Add(node1);

        DiagramNode node2 = new DiagramNode()
        {
            Id = "node2",
            OffsetX = 300,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation(){ Content = "Path Element"}
            },
            Shape = new DiagramShape()
            {
                Type = Syncfusion.Blazor.Diagrams.Shapes.Path,
                Data = "M540.3643,137.9336L546.7973,159.7016L570.3633,159.7296L550.7723,171.9366L558.9053,194.9966L540.3643," +
                "179.4996L521.8223,194.9966L529.9553,171.9366L510.3633,159.7296L533.9313,159.7016L540.3643,137.9336z"
            }
        };
        NodeCollection.Add(node2);
        DiagramConnector connector1 = new DiagramConnector()
        {
            Id = "connector1",
            SourcePoint = new ConnectorSourcePoint() { X = 100, Y = 300 },
            TargetPoint = new ConnectorTargetPoint() { X = 200, Y = 400 },
            Type = Segments.Straight
        };
        ConnectorCollection.Add(connector1);
        string[] objects = new string[] { "node1" ,"node2"};
        string[] objects1 = new string[] { "node2" };
        Layers.Add(new DiagramLayer() { Id = "Layer1", Visible = true, Objects = objects, AddInfo = new AdditionalInfo() {Description="Layer1" } });
        Layers.Add(new DiagramLayer() { Id = "layer2", Visible = true, Objects = objects1});
    }
}
```

### Add layer at runtime

Layers can be added at runtime by using the [`AddLayer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_AddLayer_Syncfusion_Blazor_Diagrams_DiagramLayer_System_Object_) public method.

The layer's [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramLayer.html#Syncfusion_Blazor_Diagrams_DiagramLayer_Id) property defines the ID of the layer, and its further used to find the layer at runtime and do any customization.

The following code illustrates how to add a layer.

```cshtml
@using Syncfusion.Blazor.Diagrams
 <input type="button" value="Addlayer" @onclick="@addLayer" />
<SfDiagram Height="600px" @ref="@diagram">
</SfDiagram>

@code{
    SfDiagram diagram;
    DiagramLayer layer = new DiagramLayer()
    {
        Id = "newlayer",
        Visible = true,
        Lock = false,
        Objects = new string[] { },
        ZIndex = -1,
        AddInfo = { }
    };
    List<DiagramConnector> connectors = new List<DiagramConnector>() {
        new DiagramConnector()
        {
            Id = "connector2",
            SourcePoint = new ConnectorSourcePoint() { X = 200, Y = 100 },
            TargetPoint = new ConnectorTargetPoint() { X = 500, Y = 100 },
            Type = Segments.Straight
        }
    };
    // add the layers to the existing diagram layer collection
    public void addLayer()
    {
        diagram.AddLayer(layer, connectors);
    }
}
```

### Remove layer at runtime

Layers can be removed at runtime by using the [`RemoveLayer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_RemoveLayer_System_String_) public method.

The following code illustrates how to remove a layer.

```csharp
    SfDiagram diagram;

    // remove the diagram layers
    diagram.RemoveLayer("Layer1");

```

### MoveObjects

Objects of the layers can be moved by using the [`MoveObjects`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_MoveObjects_System_Collections_Generic_List_System_String__System_String_) public method.

The following code illustrates how to move objects from one layer to another layer from the diagram.

```csharp
  SfDiagram diagram;
  // move the objects of diagram layers
  string[] objects = new string[] { "node2" };
  diagram.MoveObjects(objects,"Layer1");  
```

### BringLayerForward

Layers can be moved forward at runtime by using the [`BringLayerForward`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_BringLayerForward_System_String_) public method.

The following code illustrates how to bring forward to layer.

```csharp
    SfDiagram diagram;

    // move the layer forward
    diagram.BringLayerForward("Layer1");
```

### SendLayerBackward

Layers can be moved backward at runtime by using the [`SendLayerBackward`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_SendLayerBackward_System_String_) public method.

The following code illustrates how to send backward to layer.

```csharp
    SfDiagram diagram;
    // move the layer backward
    diagram.SendLayerBackward("Layer1");

```

### CloneLayer

Layers can be cloned with its object by using the [`CloneLayer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_CloneLayer_System_String_) public method.

The following code illustrates how to bring forward to layer.

```csharp
    SfDiagram diagram;
    // clone a layer with its objec
    diagram.CloneLayer("Layer1");
```

### GetActiveLayer

To get the active layers back in diagram, use the [`GetActiveLayer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_GetActiveLayer) public method.

The following code illustrates how to bring forward to layer.

```csharp
    SfDiagram diagram;
    // gets the active layer back
    diagram.GetActiveLayer();
```

### SetActiveLayer

Set the active layer by using the [`SetActiveLayer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_SetActiveLayer_System_String_) public method.

The following code illustrates how to bring forward to layer.

```csharp
    SfDiagram diagram;

    // set the active layer
    //@param layerName defines the name of the layer which is to be active layer
    diagram.SetActiveLayer("Layer1");
```