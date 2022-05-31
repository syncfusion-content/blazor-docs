---
layout: post
title: Organizational chart in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create organization chart in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Organizational Chart in Blazor Diagram Component

An organizational chart is a diagram that displays the structure of an organization and relationships. To create an organizational chart, the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_Type) of layout should be set as an [OrganizationalChart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LayoutType.html#Syncfusion_Blazor_Diagram_LayoutType_OrganizationalChart). The following code example illustrates how to create an organizational chart.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@NodeCollection" Connectors="@connectors" NodeCreating="@OnNodeCreating" ConnectorCreating="@OnConnectorCreating">
    <Layout Type="LayoutType.OrganizationalChart" @bind-HorizontalSpacing="@HorizontalSpacing" @bind-VerticalSpacing="@VerticalSpacing">
    </Layout>
</SfDiagramComponent>

@code 
{
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    //Defines diagram's node collection.
    DiagramObjectCollection<Node> NodeCollection = new DiagramObjectCollection<Node>();

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
            new ShapeAnnotation { Style = new TextStyle() { Color = "white", Bold = true },Content = node.Annotations[0].Content }
        };
    }

    private void OnConnectorCreating(IDiagramObject connector)
    {
        (connector as Connector).Type = ConnectorSegmentType.Orthogonal;
    }

    protected override void OnInitialized()
    {
        NodeCollection = new DiagramObjectCollection<Node>()
        {
            new Node() { ID = "node1",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Project Management" } } },
            new Node() { ID = "node2",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "R&D Team" } } },
            new Node() { ID = "node3",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Philosophy" } } },
            new Node() { ID = "node4",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Organization" } } },
            new Node() { ID = "node5",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Technology" } } },
            new Node() { ID = "node6",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Funding" } } },
            new Node() { ID = "node7",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Resource-Allocation" } } },
            new Node() { ID = "node8",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Targeting" } } },
            new Node() { ID = "node9",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Evaluation" } } },
            new Node() { ID = "node10",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "HR-Team" } } },
            new Node() { ID = "node11",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Recruiment" } } },
            new Node() { ID = "node12",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Employee-Relation" } } },
            new Node() { ID = "node13",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Production & Sales Team" } } },
            new Node() { ID = "node14",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Design" } } },
            new Node() { ID = "node15",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Operation" } } },
            new Node() { ID = "node16",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Support" } } },
            new Node() { ID = "node17",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Quality Assurance" } } },
            new Node() { ID = "node18",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Customer Interaction" } } },
            new Node() { ID = "node19",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Support and Maintenance" } } },
            new Node() { ID = "node20",Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Task Coordination" } } }
        };        
        connectors = new DiagramObjectCollection<Connector>()
        {
            new Connector() { ID = "connector1", SourceID = "node1", TargetID = "node2" },
            new Connector() { ID = "connector2", SourceID = "node1", TargetID = "node10" },
            new Connector() { ID = "connector3", SourceID = "node1", TargetID = "node13" },
            new Connector() { ID = "connector4", SourceID = "node2", TargetID = "node3" },
            new Connector() { ID = "connector5", SourceID = "node2", TargetID = "node4" },
            new Connector() { ID = "connector6", SourceID = "node2", TargetID = "node5" },
            new Connector() { ID = "connector7", SourceID = "node2", TargetID = "node6" },
            new Connector() { ID = "connector8", SourceID = "node2", TargetID = "node7" },
            new Connector() { ID = "connector9", SourceID = "node2", TargetID = "node8" },
            new Connector() { ID = "connector10", SourceID = "node2", TargetID = "node9" },
            new Connector() { ID = "connector11", SourceID = "node2", TargetID = "node11" },
            new Connector() { ID = "connector12", SourceID = "node10", TargetID = "node12" },
            new Connector() { ID = "connector13", SourceID = "node10", TargetID = "node14" },
            new Connector() { ID = "connector14", SourceID = "node13", TargetID = "node15" },
            new Connector() { ID = "connector15", SourceID = "node13", TargetID = "node16" },
            new Connector() { ID = "connector16", SourceID = "node13", TargetID = "node17" },
            new Connector() { ID = "connector17", SourceID = "node13", TargetID = "node18" },
            new Connector() { ID = "connector18", SourceID = "node13", TargetID = "node19" },
            new Connector() { ID = "connector19", SourceID = "node13", TargetID = "node20" }
        };
    }
}
```

![Blazor Organization Chart Diagram](../images/blazor-organization-chart.png)

Organizational chart layout starts parsing from root and iterate through all its child elements. The [GetLayoutInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_GetLayoutInfo) event callback method provides necessary information about a node’s children and the way to arrange them(direction, orientation, offsets, etc.). The arrangements can be customized by overriding this function as explained.

**GetLayoutInfo** set chart orientations, chart types, and offset to be left between parent and child nodes. The GetLayoutInfo event callback method is called to configure every subtree of the organizational chart. It takes the following arguments.

1. **IDiagramObject**: Parent node to that options are to be customized.
2. **TreeInfo**: Object to set the customizable properties.
3. **TreeInfo**: Returns an object value to be customized.

## Customize layout

Orientation, spacings, and position of the layout can be customized with a set of properties.

To explore layout properties, refer to `Layout Properties`.

### How to update the Layout bounds

Diagram provides support to align the layout within any custom rectangular area. For more information about bounds, refer to [Bounds](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_Bounds).

### How to align Layout 

The layout can be aligned anywhere over the layout bounds/viewport using the [HorizontalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_HorizontalAlignment) and [VerticalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_VerticalAlignment) properties of the layout.

The following code illustrates how to align the layout at the top-left of the layout bounds.

```csharp
<SfDiagramComponent @ref="diagram" Width="900px" Height="800px">
    <Layout Type="LayoutType.OrganizationalChart" @bind-HorizontalSpacing="@HorizontalSpacing" @bind-VerticalSpacing="@VerticalSpacing" @bind-VerticalAlignment="@verticalAlignment"></Layout>
</SfDiagramComponent>

int HorizontalSpacing = 40;
int VerticalSpacing = 40;
VerticalAlignment verticalAlignment = VerticalAlignment.Bottom;
```

The following table illustrates the different chart orientations and chart types.

|Orientation|Type|Description|Example|
| -------- | ----------- | ------------- |------|
|Horizontal|Left|Arranges the child nodes horizontally at the left side of the parent.|![Blazor Organization Chart Diagram ChildNode in Horizontal Left Position](../images/blazor-diagram-childnode-at-horizontal-left-side.png)|
||Right|Arranges the child nodes horizontally at the right side of the parent.|![Blazor Organization Chart Diagram ChildNode in Horizontal Left Position](../images/blazor-diagram-childnode-at-horizontal-right-side.png)|
||Center|Arranges the children like standard tree layout orientation.|![Blazor Organization Chart Diagram ChildNode in Horizontal Center Position](../images/blazor-diagram-childnode-at-horizontal-center-side.png)|
||Balanced|Arranges the leaf level child nodes in multiple rows.|![Blazor Organization Chart Diagram ChildNode in Horizontal Balance Position](../images/blazor-diagram-childnode-at-horizontal-both-side.png)|
|Vertical|Left|Arranges the children vertically at the left side of the parent.|![Blazor Organization Chart Diagram ChildNode in Vertical Left Position](../images/blazor-diagram-childnode-at-vertical-left-side.png)|
||Right|Arranges the children vertically at the right side of the parent.|![Blazor Organization Chart Diagram ChildNode in Vertical Right Position](../images/blazor-diagram-childnode-at-vertical-right-side.png)|
||Alternate|Arranges the children vertically at both left and right sides of the parent.|![Blazor Organization Chart Diagram ChildNode in Vertical Alternate Position](../images/blazor-diagram-childnode-at-vertical-both-side.png)|

The following code example illustrates how to set the vertical right arrangement to the leaf level trees.

```csharp
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" NodeCreating="@OnNodeCreating" ConnectorCreating="@OnConnectorCreating">
    <DataSourceSettings ID="Id" ParentID="Team" DataSource="@DataSource"></DataSourceSettings>
    <SnapSettings>
        <HorizontalGridLines LineColor="white" LineDashArray="2,2">
        </HorizontalGridLines>
        <VerticalGridLines LineColor="white" LineDashArray="2,2">
        </VerticalGridLines>
    </SnapSettings>
    <Layout Type="LayoutType.OrganizationalChart" @bind-HorizontalSpacing="@HorizontalSpacing" @bind-VerticalSpacing="@VerticalSpacing" GetLayoutInfo="GetLayoutInfo">
    </Layout>
</SfDiagramComponent>

@code
{
    //Initializing layout.
    int HorizontalSpacing = 40;
    int VerticalSpacing = 50;

    //To configure every subtree of the organizational chart.
    private TreeInfo GetLayoutInfo(IDiagramObject obj, TreeInfo options)
    {
        options.AlignmentType = SubTreeAlignmentType.Right;
        options.Orientation = Orientation.Vertical;
        return options;
    }

    //Creates node with some default values.
    private void OnNodeCreating(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.Height = 50;
        node.Width = 150;
        node.Style = new ShapeStyle() { Fill = "#6495ED", StrokeWidth = 1, StrokeColor = "Black" };
    }

    //Creates connectors with some default values.
    private void OnConnectorCreating(IDiagramObject connector)
    {
        Connector connectors = connector as Connector;
        connectors.Type = ConnectorSegmentType.Orthogonal;
        connectors.Style = new TextStyle() { StrokeColor = "#6495ED", StrokeWidth = 1 };
        connectors.TargetDecorator = new DecoratorSettings
        {
            Shape = DecoratorShape.None,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED", }
        };
    }

    public class OrgChartDataModel
    {
        public string Id { get; set; }
        public string Team { get; set; }
        public string Role { get; set; }
    }
    public object DataSource = new List<object>()
    {
        new OrgChartDataModel() { Id= "1", Role= "General Manager" },
        new OrgChartDataModel() { Id= "2", Role= "Human Resource Manager", Team= "1" },
        new OrgChartDataModel() { Id= "3", Role= "Design Manager", Team= "1" },
        new OrgChartDataModel() { Id= "4", Role= "Operation Manager", Team= "1" },
        new OrgChartDataModel() { Id= "5", Role= "Marketing Manager", Team= "1" }
    };
}
```

![Blazor Organization Diagram ChildNode in Vertical Right](../images/blazor-diagram-childnode-at-vertical-right.png)

### How to update the Layout spacing

Layout provides support to add space horizontally and vertically between the nodes. The [HorizontalSpacing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_HorizontalSpacing) and [VerticalSpacing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_VerticalSpacing) properties of the layout allow you to set the space between the nodes horizontally and vertically.

### How to update the Layout margin

Layout provides support to add some blank space between the layout bounds/viewport and the layout. The [Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_Margin) property of the layout allows you to set the blank space.

```csharp
//Initialize the organizational chart layout with Margin.
<SfDiagramComponent @ref="diagram" Width="900px" Height="800px" >
  <Layout Type="LayoutType.HierarchicalTree">
     <LayoutMargin Top="@top" Left="@left"></LayoutMargin>
  </Layout>
</SfDiagramComponent>
@code
{
    //Initializing the Margin Top and Left value.
    int left = 40;
    int top = 50;
}
```

### How to change orientation

Diagram provides support to customize the `Orientation` of layout. You can set the desired orientation using `LayoutOrientation`.

The following code illustrates how to arrange the nodes in a BottomToTop orientation.

```csharp
//Initialize the layout with layout orientation as BottomToTop in page.
<SfDiagramComponent Height="600px" Width="500px" >
    <Layout Type="LayoutType.HierarchicalTree" @bind-Orientation="@orientation"></Layout>
</SfDiagramComponent>
@code
{
    //Initializing the orientation value.
    LayoutOrientation orientation = LayoutOrientation.TopToBottom;
}
```

### Fixed node

Layout provides support to arrange the nodes with reference to the position of a fixed node and set it to the [FixedNode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_FixedNode) of the layout property. This is helpful when you try to expand/collapse a node. It might be expected that the position of the double-clicked node should not be changed.

```csharp
//Initialize the organizational chart layout with FixedNode.
<SfDiagramComponent Height="600px" Width="500px" >
    <Layout Type="LayoutType.OrganizationalChart" FixedNode="Node1" @bind-HorizontalSpacing="@HorizontalSpacing" @bind-VerticalSpacing="@VerticalSpacing" @bind-Orientation="@orientation"></Layout>
</SfDiagramComponent>
@code
{
    //Initializing the orientation value.
    LayoutOrientation orientation = LayoutOrientation.TopToBottom;
    //Initializing the Horizontal and Vertical value.
    int HorizontalSpacing = 40;
    int VerticalSpacing = 50;
}

```

## How to refresh the layout

Diagram allows to refresh the layout at runtime by using the [DoLayout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DoLayout) method. Use the following code example to refresh the layout.

```csharp
//Update the layout at runtime.
diagram.DoLayout();

//Here, diagram is instance of SfDiagramComponent.
```

## See also

* [How to create a node](../nodes/nodes)

* [How to create a connector](../connectors/connectors)
