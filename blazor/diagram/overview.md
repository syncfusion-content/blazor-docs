---
layout: post
title: Overview Panel in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Overview Control in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Overview Panel in Blazor Diagram Component

`SfDiagramOverviewComponent` allows you to see a preview or an overall view of the entire content of a diagram. This helps you to look at the overall picture of a large diagram and also to navigate, pan, or zoom, on a particular position of the page.

## Usage Scenario

When you work on a very large diagram, you may not know the part you are actually working on, or navigation from one part to another might be difficult. One solution for navigation is to zoom out the entire diagram and find where you are. Then, you can zoom in a particular area you want to. This solution is not suitable when you need some frequent navigation.

`SfDiagramOverviewComponent` solves these problems by showing a preview, that is, an overall view of the entire diagram. A rectangle indicates viewport of the diagram. Navigation becomes easy by dragging this rectangle.

## Create overview

The `SourceID` property of `SfDiagramOverviewComponent` should be set with the corresponding diagram ID for the overall view.

The `Width` and `Height` properties of the `SfDiagramOverviewComponent` allow you to define the size of the `SfDiagramOverviewComponent`.

The following code illustrates how to create overview.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.Overview
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="@Diagram" ID="diagram" Width="100%" Height="500px" InteractionController="DiagramInteractions.ZoomPan" ConnectorCreating="@ConnectorCreating" NodeCreating="@NodeCreating">
    <DataSourceSettings ID="Name" ParentID="Category" DataSource="DataSource"></DataSourceSettings>
    <Layout Type="LayoutType.HierarchicalTree" HorizontalSpacing="30" Orientation="LayoutOrientation.TopToBottom" VerticalSpacing="30" HorizontalAlignment="HorizontalAlignment.Auto" VerticalAlignment="VerticalAlignment.Auto" GetLayoutInfo="GetLayoutInfo">
        <LayoutMargin Top="50" Bottom="50" Right="50" Left="50"></LayoutMargin>
    </Layout>            
</SfDiagramComponent>
<SfDiagramOverviewComponent Height="150px" SourceID="diagram"></SfDiagramOverviewComponent>
@code {
SfDiagramComponent Diagram;
private void ConnectorCreating(IDiagramObject connector)
{
    (connector as Connector).Type = ConnectorSegmentType.Orthogonal;
    (connector as Connector).TargetDecorator.Shape = DecoratorShape.None;
    (connector as Connector).Style = new ShapeStyle() { StrokeColor = "#6d6d6d" };
    (connector as Connector).Constraints = 0;
    (connector as Connector).CornerRadius = 5;
}
private TreeInfo GetLayoutInfo(IDiagramObject obj, TreeInfo options)
{
    options.EnableSubTree = true;
    options.Orientation = Orientation.Horizontal;
    return options;
}
private void NodeCreating(IDiagramObject obj)
{
    Node node = obj as Node;
    if (node.Data is System.Text.Json.JsonElement)
    {
        node.Data = System.Text.Json.JsonSerializer.Deserialize<HierarchicalDetails>(node.Data.ToString());
    }
    HierarchicalDetails hierarchicalData = node.Data as HierarchicalDetails;
    node.Style = new ShapeStyle() { Fill = "#659be5", StrokeColor = "none", StrokeWidth = 2, };
    node.BackgroundColor = "#659be5";
    node.Width = 150;
    node.Height = 50;
    node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
    {
        new ShapeAnnotation()
        {
            Content = hierarchicalData.Name,
            Style =new TextStyle(){Color = "white"}
        }
    };
}
 //Create the hierarchical details with needed properties.
public class HierarchicalDetails
{
    public string Name { get; set; }
    public string FillColor { get; set; }
    public string Category { get; set; }
}
//Create the data source with node name and fill color values.
public List<HierarchicalDetails> DataSource = new List<HierarchicalDetails>()
{
    new HierarchicalDetails(){ Name ="Diagram", Category="",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Layout", Category="Diagram",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Tree layout", Category="Layout",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Organizational chart", Category="Layout",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Hierarchical tree", Category="Tree layout",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Radial tree", Category="Tree layout",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Mind map", Category="Hierarchical tree",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Family tree", Category="Hierarchical tree",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Management", Category="Organizational chart",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Human resources", Category="Management",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="University", Category="Management",FillColor="#659be5"},
    new HierarchicalDetails(){ Name ="Business", Category="#Management",FillColor="#659be5"}
};
}
```

## Zoom and Pan

In `SfDiagramOverviewComponent`, the view port of the diagram is highlighted with a red color rectangle. Diagram can be zoomed/panned by interacting with that. You can interact with `SfDiagramOverviewComponent` as follows:

* Resize the rectangle: Zooms in/out the diagram.
* Drag the rectangle: Pans the diagram.
* Click at a position: Navigates to the clicked region.
* Choose a particular region by clicking and dragging: Navigates to the specified region.

The following image shows how the diagram is zoomed/panned with overview.

![Overview Interaction](images/Overview.gif)

## Overview Constraints

The `Constraints` property of the `SfDiagramOverviewComponent` allows you to enable or disable the following behaviors.

* None
* Zoom
* Pan
* DrawFocus
* TapFocus
* Default

| Constraints | Description |
| -------- | -------- |
| None | Disables all the interactions in SfDiagramOverviewComponent.|
| Zoom | Enables the zooming interaction in SfDiagramOverviewComponent. |
| Pan | Enables the panning interaction in SfDiagramOverviewComponent. |
| DrawFocus | Enables to zoom or change the viewport area of the diagram by drawing the new rect in the SfDiagramOverviewComponent. | 
| TapFocus | Enables the panning of the diagram viewport to specific focus point by tap on the SfDiagramOverviewComponent. |
| Default | Enables all the interactions in SfDiagramOverviewComponent. |

The following example shows how to disable zoom constraint from the default overview constraints.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.Overview
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="diagram" Height="600px" Width="90%" ID="diagram" @bind-Nodes="nodes" @bind-Connectors="connectors">
</SfDiagramComponent>
<SfDiagramOverviewComponent Height="150px" SourceID="diagram" Constraints="DiagramOverviewConstraints.Default &~ DiagramOverviewConstraints.Zoom"></SfDiagramOverviewComponent>
@code {
    SfDiagramComponent diagram; DiagramObjectCollection<Node> nodes; DiagramObjectCollection<Connector> connectors;
    protected override void OnInitialized()
    {
        //Initialize the node and connector collections
        nodes = new DiagramObjectCollection<Node>();
        connectors = new DiagramObjectCollection<Connector>();
        Node node1 = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white",
                StrokeWidth = 1
            }
        };
        Node node2 = new Node()
        {
            ID = "node2",
            Height = 100,
            Width = 100,
            OffsetX = 300,
            OffsetY = 100,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white",
                StrokeWidth = 1
            }
        };
        nodes.Add(node1); nodes.Add(node2);
        Connector connector1 = new Connector()
        {
            ID = "connector1",
            SourceID = "node1",
            TargetID = "node2",
            Type = ConnectorSegmentType.Straight,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeWidth = 2
            }
        };
        connectors.Add(connector1);
    }
}
```