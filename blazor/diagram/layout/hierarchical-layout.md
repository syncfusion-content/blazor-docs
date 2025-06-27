---
layout: post
title: Hierarchical Layout in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create hierarchical layout in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Hierarchical Layout in Blazor Diagram Component

The hierarchical tree layout arranges nodes in a tree-like structure, where the nodes in the hierarchical layout may have multiple parents. There is no need to specify the layout root. To arrange the nodes in a hierarchical structure, specify the layout [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_Type) as [HierarchicalTree](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LayoutType.html#Syncfusion_Blazor_Diagram_LayoutType_HierarchicalTree). The following example shows how to arrange the nodes in a hierarchical structure.

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
       node.Annotations[0].Style = new TextStyle() { Color = "white", Bold = true };
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Layout/HeirarchicalLayout)

![Blazor Hierarchical Diagram](../images/blazor-hierarchical-diagram.png)


You can create a hierarchical layout with DataSource. The following code demonstrates how to render a Hierarchical layout using DataSource.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" Connectors="@connectors" NodeCreating="@OnNodeCreating" ConnectorCreating="@OnConnectorCreating">
  <DataSourceSettings ID="Id" ParentID="Manager" DataSource="DataSource"> </DataSourceSettings>
    <Layout Type="LayoutType.HierarchicalTree" HorizontalSpacing="@HorizontalSpacing" VerticalSpacing="@VerticalSpacing" >
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
    }

    private void OnConnectorCreating(IDiagramObject connector)
    {
        (connector as Connector).Type = ConnectorSegmentType.Orthogonal;
    }

    public class HierarchicalDetails
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Manager { get; set; }
        public string ChartType { get; set; }
        public string Color { get; set; }
    }
    public List<HierarchicalDetails> DataSource = new List<HierarchicalDetails>()
    {
        new HierarchicalDetails()   { Id= "parent", Role= "Board", Color= "#71AF17" },
        new HierarchicalDetails()   { Id= "1", Role= "General Manager", Manager= "parent", ChartType= "right", Color= "#71AF17" },
        new HierarchicalDetails()   { Id= "11", Role= "Assistant Manager", Manager= "1", Color= "#71AF17" },
        new HierarchicalDetails()   { Id= "2", Role= "Human Resource Manager", Manager= "1", ChartType= "right", Color= "#1859B7" },
        new HierarchicalDetails()   { Id= "3", Role= "Trainers", Manager= "2", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "4", Role= "Recruiting Team", Manager= "2", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "5", Role= "Finance Asst. Manager", Manager= "2", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "6", Role= "Design Manager", Manager= "1",ChartType= "right", Color= "#1859B7" },
        new HierarchicalDetails()   { Id= "7", Role= "Design Supervisor", Manager= "6", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "8", Role= "Development Supervisor", Manager= "6", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "9", Role= "Drafting Supervisor", Manager= "6", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "10", Role= "Operation Manager", Manager= "1", ChartType= "right", Color= "#1859B7" },
        new HierarchicalDetails()   { Id= "11", Role= "Statistic Department", Manager= "10", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "12", Role= "Logistic Department", Manager= "10", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "16", Role= "Marketing Manager", Manager= "1", ChartType= "right", Color= "#1859B7" },
        new HierarchicalDetails()   { Id= "17", Role= "Oversea sales Manager", Manager= "16", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "18", Role= "Petroleum Manager", Manager= "16", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "20", Role= "Service Dept. Manager", Manager= "16", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "21", Role= "Quality Department", Manager= "16", Color= "#2E95D8" }
    };
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Layout/HierarchicalTreeWithDataSource)

>**Note:** In the DataSourceSettings, the type of the ID and ParentID properties is string. The provided DataSource should have a parent-child relationship. It is necessary for at least one node to have an empty ParentID.

## Customizing the Properties

### How to Change Orientation 

You can use the [Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_Orientation) property of the Layout to change the orientation at runtime. The following code shows how to change the layout.

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

### How to Update Spacing Between Nodes

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
    Diagram.EndUpdateAsync();
}
```

### How to Update Margin

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
    Diagram.EndUpdateAsync();
}
```

## See also

* [How to create a node](../nodes/nodes)

* [How to create a connector](../connectors/connectors)

* [How to Generate a Hierarchical Layout with Annotation at Runtime](https://support.syncfusion.com/kb/article/17884/how-to-generate-a-hierarchical-layout-with-annotation-at-runtime)