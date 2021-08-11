---
layout: post
title: MindMap Layout in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create the MindMap layout in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Mind map Layout in Blazor Diagram Component

A mind map is a diagram that displays the nodes as a spider diagram organizes information around a central concept. To create mind map, the `Type` of layout should be set as `MindMap`. The following code example illustrates how to create a mind map layout.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent Height="600px" NodeDefaults="@NodeDefaults" ConnectorDefaults="@ConnectorDefaults">
    <DataSourceSettings Id="Id" ParentId="ParentId" DataSource="@DataSource"></DataSourceSettings>
    <Layout Type="LayoutType.MindMap">
        <LayoutMargin Top="20" Left="20"></LayoutMargin>
    </Layout>
</SfDiagramComponent>

@code {

    private void NodeDefaults(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.Height = 25;
        node.Width = 25;
        node.BackgroundColor = "#6BA5D7";
        node.Style = new ShapeStyle() { Fill = "#6495ED", StrokeWidth = 1, StrokeColor = "white" };
        node.Shape = new BasicShape() { Type = Shapes.Basic }; ;
    }

    private void ConnectorDefaults(IDiagramObject connector)
    {
        Connector connectors = connector as Connector;
        connectors.Type = Segments.Bezier;
        connectors.Style = new TextShapeStyle() { StrokeColor = "#6495ED", StrokeWidth = 2 };
        connectors.TargetDecorator = new Decorator
        {
            Shape = DecoratorShapes.None,
        };
    }

    public class MindMapDetails
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string ParentId { get; set; }
        public string Branch { get; set; }
        public string Fill { get; set; }
    }

    public object DataSource = new List<object>()
{
    new MindMapDetails() { Id= "1",Label="Creativity", ParentId ="", Branch = "Root"},
    new MindMapDetails() { Id= "2",  Label="Brainstorming", ParentId ="1", Branch = "Right" },
    new MindMapDetails() { Id= "3",  Label="Complementing", ParentId ="1", Branch = "Left" },
    new MindMapDetails() { Id= "4",  Label="Sessions", ParentId ="2", Branch = "subRight" },
    new MindMapDetails() { Id= "5",  Label="Complementing", ParentId ="2", Branch = "subRight" },
    new MindMapDetails() { Id= "6", Label= "Local", ParentId ="3", Branch = "subRight"  },
    new MindMapDetails() { Id= "7", Label= "Remote", ParentId ="3", Branch = "subRight"  },
    new MindMapDetails() { Id= "8", Label= "Individual", ParentId ="3", Branch = "subRight" },
    new MindMapDetails() { Id= "9", Label= "Teams", ParentId ="3", Branch = "subRight" },
    new MindMapDetails() { Id= "10", Label= "Ideas", ParentId ="5", Branch = "subRight" },
    new MindMapDetails() { Id= "11", Label= "Engagement", ParentId ="5", Branch = "subRight" },
    };
}
```

![Mind Map](../images/mind_map.png)

You can also decide the branch for mind map using GetBranch method. The following code demonstrates how to set all branches on the right side for mind map layout using GetBranch method.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" NodeDefaults="@NodeDefaults" ConnectorDefaults="@ConnectorDefaults">
    <DataSourceSettings Id="Id" ParentId="ParentId" DataSource="@DataSource"></DataSourceSettings>
    <Layout Type="LayoutType.MindMap" GetBranch="@GetBranch">
        <LayoutMargin Top="20" Left="20"></LayoutMargin>
    </Layout>
</SfDiagramComponent>

@code {

    private BranchTypes GetBranch(IDiagramObject obj)
    {
        if ((obj as Node).ID == "1")
        {
            return BranchTypes.Root;
        }
        return BranchTypes.Right;
    }

    private void NodeDefaults(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.Height = 100;
        node.Width = 100;
        node.BackgroundColor = "#6BA5D7";
        node.Style = new ShapeStyle() { Fill = "#6495ED", StrokeWidth = 1, StrokeColor = "white" };
        node.Shape = new BasicShape() { Type = Shapes.Basic };
        MindMapDetails mindmapData = node.Data as MindMapDetails;
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation()
            {
                Content = mindmapData.Label
            }
        };
    }

    private void ConnectorDefaults(IDiagramObject connector)
    {
        Connector connectors = connector as Connector;
        connectors.Type = Segments.Bezier;
        connectors.Style = new TextShapeStyle() { StrokeColor = "#6495ED", StrokeWidth = 2 };
        connectors.TargetDecorator = new Decorator
        {
            Shape = DecoratorShapes.None,
        };
    }

    public class MindMapDetails
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string ParentId { get; set; }
        public string Branch { get; set; }
        public string Fill { get; set; }
    }

    public object DataSource = new List<object>()
    {
    new MindMapDetails() { Id= "1",Label="Creativity", ParentId =""},
    new MindMapDetails() { Id= "2",  Label="Brainstorming", ParentId ="1"},
    new MindMapDetails() { Id= "3",  Label="Complementing", ParentId ="1"},
    new MindMapDetails() { Id= "4",  Label="Sessions", ParentId ="2"},
    new MindMapDetails() { Id= "5",  Label="Complementing", ParentId ="2"},
    new MindMapDetails() { Id= "6", Label= "Local", ParentId ="3"},
    new MindMapDetails() { Id= "7", Label= "Remote", ParentId ="3"},
    new MindMapDetails() { Id= "8", Label= "Individual", ParentId ="3"},
    new MindMapDetails() { Id= "9", Label= "Teams", ParentId ="3"},
    new MindMapDetails() { Id= "10", Label= "Ideas", ParentId ="5"},
    new MindMapDetails() { Id= "11", Label= "Engagement", ParentId ="5"},
    };
}
```

![Mindmap](images/Mindmapgetbranch.png)

## See also

* [How to create a node](../nodes/nodes)

* [How to create a connector](../connectors/connectors)
