---
layout: post
title: Hierarchical Layout in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create hierarchical layout in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Hierarchical Layout in Blazor Diagram Component

The hierarchical tree layout arranges nodes in a tree-like structure, where the nodes in the hierarchical layout may have multiple parents. There is no need to specify the layout root. To arrange the nodes in a hierarchical structure, specify the layout [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_Type) as [HierarchicalTree](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LayoutType.html#Syncfusion_Blazor_Diagram_LayoutType_HierarchicalTree). The following example shows how to arrange the nodes in a hierarchical structure.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" Connectors="@connectors" NodeCreating="@OnNodeCreating" ConnectorCreating="@OnConnectorCreating">
    <Layout Type="LayoutType.HierarchicalTree" @bind-HorizontalSpacing="@HorizontalSpacing" @bind-VerticalSpacing="@VerticalSpacing">
    </Layout>
    <SnapSettings>
        <HorizontalGridLines LineColor="white" LineDashArray="2,2">
        </HorizontalGridLines>
        <VerticalGridLines LineColor="white" LineDashArray="2,2">
        </VerticalGridLines>
    </SnapSettings>
</SfDiagramComponent>

@code 
{
    int left = 40;
    int top = 50;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    int HorizontalSpacing = 40;
    int VerticalSpacing = 40;

    private void OnNodeCreating(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.Height = 40;
        node.Width = 100;
        //Initializing the default node's shape style.
        node.Style = new ShapeStyle() { Fill = "darkcyan", StrokeWidth = 3, StrokeColor = "Black" };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation 
            { 
                Content = node.Annotations[0].Content,
                Style = new TextStyle() { Color = "white", Bold = true }, 
            }
        };
    }

    private void OnConnectorCreating(IDiagramObject connector)
    {
        (connector as Connector).Type = ConnectorSegmentType.Orthogonal;
    }

    protected override void OnInitialized()
    {
        //Initializing node and connectors.
        nodes = new DiagramObjectCollection<Node>()
        {
            new Node() { ID="node1", Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation{Content="Steve-Ceo"} } },
            new Node() { ID="node2", Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation{Content="Kevin-Manager"} } },
            new Node() { ID="node3", Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation{Content="Peter-Manager"} } },
            new Node() { ID="node4", Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation{Content="Jim-CSE"} } },
            new Node() { ID="node5", Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation{Content="Martin-CSE"} } },
            new Node() { ID="node6", Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation{Content="John-Manager"} } },
            new Node() { ID="node7", Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation{Content="Mary-CSE"} } },
        };
        connectors = new DiagramObjectCollection<Connector>()
        {
            new Connector() { ID="connector1", SourceID="node1", TargetID="node2" },
            new Connector() { ID="connector2", SourceID="node1", TargetID="node3" },
            new Connector() { ID="connector3", SourceID="node2", TargetID="node4" },
            new Connector() { ID="connector4", SourceID="node2", TargetID="node5" },
            new Connector() { ID="connector5", SourceID="node3", TargetID="node6" },
            new Connector() { ID="connector6", SourceID="node3", TargetID="node7" },
        };
    }
}

```

![Blazor Hierarchical Diagram](../images/blazor-hierarchical-diagram.png)

## Customizing the properties

### Orientation

You can use [Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_Orientation) property of the Layout to change the orientation at runtime. The following code shows how to change the layout.

```csharp
<SfDiagramComponent Height="600px" Width="500px" >
    <Layout Type="LayoutType.HierarchicalTree" @bind-Orientation="@orientation"></Layout>
</SfDiagramComponent>

// Initializing the orientation value.
LayoutOrientation orientation = LayoutOrientation.TopToBottom;

public void UpdateOrientation()
{
    // Update LayoutOrientation in runtime.
    orientation = LayoutOrientation.BottomToTop;
}
```

### Spacing

You can change the horizontal and vertical spacing for the diagram layout by using the [HorizontalSpacing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_HorizontalSpacing) and [VerticalSpacing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_VerticalSpacing) properties of the layout.

```csharp
<SfDiagramComponent @ref="diagram" Width="900px" Height="800px">
    <Layout Type="LayoutType.HierarchicalTree" @bind-HorizontalSpacing="@HorizontalSpacing" @bind-VerticalSpacing="@VerticalSpacing"/>
</SfDiagramComponent>

// Initializing the Horizontal and Vertical value.
int HorizontalSpacing = 40;
int VerticalSpacing = 50;

// Update the spacing.
public void UpdateSpacing()
{
    Diagram.BeginUpdate();
    HorizontalSpacing += 10;
    VerticalSpacing += 10;
    Diagram.EndUpdate();
}
```

### Margin

You can also change the margin values for the diagram layout by using the [Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_Margin) property.

```csharp
<SfDiagramComponent @ref="diagram" Width="900px" Height="800px" >
  <Layout Type="LayoutType.HierarchicalTree">
     <LayoutMargin Top="@top" Left="@left"></LayoutMargin>
  </Layout>
</SfDiagramComponent>

// Initializing the Margin Top and Left value.
int left = 40;
int top = 50;

// Update the margin values.
public void UpdateMargin()
{
    Diagram.BeginUpdate();
    left += 10;
    top += 10;
    Diagram.EndUpdate();
}
```

## See also

* [How to create a node](../nodes/nodes)

* [How to create a connector](../connectors/connectors)
