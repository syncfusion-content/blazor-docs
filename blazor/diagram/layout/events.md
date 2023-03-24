---
layout: post
title: Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Events in Blazor Diagram Component

## Data Loaded

* The [DataLoaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DataLoaded) is triggered when the diagram layout is rendered completely.

The following code example explains the data loaded event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" DataLoaded="@DataLoaded" Nodes="@nodes" Connectors="@connectors" NodeCreating="@OnNodeCreating" ConnectorCreating="@OnConnectorCreating">
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
        //Initialize the default node's shape style.
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
    private void DataLoaded(object args)
    {
        //Action to be performed.
    }

    private void OnConnectorCreating(IDiagramObject connector)
    {
        (connector as Connector).Type = ConnectorSegmentType.Orthogonal;
    }

    protected override void OnInitialized()
    {
        //Initialize the node and connectors.
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

