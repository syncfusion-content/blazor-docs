---
layout: post
title: NodeGroup in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create and update the NodeGroup in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# NodeGroup in Blazor Diagram Component

NodeGroup is used to cluster multiple nodes and connectors into a single element. It acts like a container for its children (nodes, nodegroups, and connectors). Every change made to the group also affects the children. Child elements can be edited individually.

## Create NodeGroup

## Add NodeGroup when initializing diagram

A nodegroup can be added to the diagram model through `Nodes` collection. To define an object as nodegroup, add the child objects to the `Children` collection of the nodegroup. The following code illustrates how to create a nodegroup.

* While creating nodegroup, its child node needs to be declared before the nodegroup declaration.

* Add a node to the existing nodegroup child by using the `diagram.Group` method.

* The nodegroup’s `diagram.UnGroup` method is used to define whether the nodegroup can be ungrouped or not.

* A nodegroup can be added into a child of another nodegroup.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the diagram with NodeCollection *@
<SfDiagramComponent Height="500px" @ref="diagram" Nodes="@nodes">
    <SnapSettings>
        <HorizontalGridLines LineColor="white" LineDashArray="2,2"></HorizontalGridLines>
        <VerticalGridLines LineColor="white" LineDashArray="2,2"></VerticalGridLines>
    </SnapSettings>
</SfDiagramComponent>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        Node node3 = createNode("node3", 200, 250, "Node3");
        NodeGroup groupnode = new NodeGroup();
        // Grouping node 1 and node 2 into a single nodegroup
        groupnode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
        nodes.Add(node3);
        nodes.Add(groupnode);
    }

    public Node createNode(string id, double offx, double offy, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offx,
            OffsetY = offy,
            Height = 100,
            Width = 100,
            Style = new ShapeStyle() { Fill = "#6495ED" }
        };
        ShapeAnnotation annotation = new ShapeAnnotation
        {
            ID = "annotation1",
            Content = content,
            Style = new TextStyle()
            {
                Color = "white",
                Fill = "transparent",
                StrokeColor = "None"
            },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
    {
            annotation
        };
        return node;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Task.Delay(500);
            diagram.SelectAll();
            // Adding the third node into the existing nodegroup
            diagram.Group();
        }
    }
}
```

![Create Group](images/CreateGroup.png)

The following code illustrates how a ungroup  at runtime.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the diagram with nodes *@
<SfDiagramComponent Height="500px" @ref="diagram" Nodes="@nodes" />

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        NodeGroup groupnode = new NodeGroup();
        // Grouping node 1 and node 2 into a single nodegroup
        groupnode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
        nodes.Add(groupnode);
    }

    public Node createNode(string id, double offx, double offy, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offx,
            OffsetY = offy,
            Height = 100,
            Width = 100,
            Style = new ShapeStyle() { Fill = "#6495ED" }
        };
        ShapeAnnotation annotation = new ShapeAnnotation
        {
            ID = "annotation1",
            Content = content,
            Style = new TextStyle()
            {
                Color = "white",
                Fill = "transparent",
                StrokeColor = "None"
            },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            annotation
        };
        return node;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Task.Delay(500);
            diagram.SelectAll();
            // Ungroup the selected group into nodes
            diagram.UnGroup();
        }
    }
}
```

## Add nodegroup at runtime

A nodegroup  can be added at runtime by using Nodes collection of diagram.

The following code illustrates how a nodegroup is added at runtime

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="AddGroup" @onclick="@AddGroup" />
@* Initialize the diagram with NodeCollection *@
<SfDiagramComponent Height="500px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    NodeGroup groupnode = new NodeGroup();

    protected override void OnInitialized()
    {
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        // Grouping node 1 and node 2 into a single nodegroup
        groupnode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
    }

    public Node createNode(string id, double offx, double offy, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offx,
            OffsetY = offy,
            Height = 100,
            Width = 100,
            Style = new ShapeStyle() { Fill = "#6495ED" }
        };
        ShapeAnnotation annotation = new ShapeAnnotation()
        {
            ID = "annotation1",
            Content = content,
            Style = new TextStyle()
            {
                Color = "white",
                Fill = "transparent",
                StrokeColor = "None"
            },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            annotation
        };
        return node;
    }

    private void AddGroup()
    {
        nodes.Add(groupnode);
    }
}
```

* Also, you can add the child to the nodegroup through `AddChild` method. The following code illustrates how to add child to the existing nodegroup through AddChild method.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="AddChildToGroup" @onclick="@AddChildToGroup" />
@* Initialize the diagram with nodes *@
<SfDiagramComponent @ref="@diagram" Height="500px" Nodes="@nodes"/>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    NodeGroup groupnode = new NodeGroup();

    protected override void OnInitialized()
    {
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        // Grouping node 1 and node 2 into a single nodegroup
        groupnode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
        nodes.Add(groupnode);
    }

    public Node createNode(string id, double offx, double offy, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offx,
            OffsetY = offy,
            Height = 100,
            Width = 100,
            Style = new ShapeStyle() { Fill = "#6495ED" }
        };
        ShapeAnnotation annotation = new ShapeAnnotation()
        {
            ID = "annotation1",
            Content = content,
            Style = new TextStyle() 
            { 
                Color = "white", 
                Fill = "transparent", 
                StrokeColor = "None" 
            },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            annotation
        };
        return node;
    }

    private async void AddChildToGroup()
    {
        NodeGroup group = diagram.SelectionSettings.Nodes[0] as NodeGroup;
        Node node = new Node()
        {
            ID = "node" + nodes.Count.ToString(),
            OffsetX = 250,
            OffsetY = 250,
            Width = 50,
            Height = 50,
            Style = new ShapeStyle() { Fill = "#6495ED" },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation()
                {
                    Content = "Node" + nodes.Count.ToString(),
                    Style = new TextStyle() 
                    { 
                        Color = "white", 
                        Fill = "transparent", 
                        StrokeColor = "None" 
                    },
                }
            }
        };
        await diagram.AddChild(group as NodeGroup, node);
    }
}
```

## Update position at runtime

You can change the position of the nodegroup similar to node. For more information about node positioning, refer to [Positioning](../nodes/positioning).

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="UpdatePosition" @onclick="@UpdatePosition" />
@* Initialize the diagram with NodeCollection *@
<SfDiagramComponent Height="500px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    NodeGroup groupnode = new NodeGroup();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        // Grouping node 1 and node 2 into a single nodegroup
        groupnode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
        nodes.Add(groupnode);
    }

    public Node createNode(string id, double offx, double offy, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offx,
            OffsetY = offy,
            Height = 100,
            Width = 100,
            Style = new ShapeStyle() { Fill = "#6495ED" }
        };
        ShapeAnnotation annotation = new ShapeAnnotation
        {
            ID = "annotation1",
            Content = content,
            Style = new TextStyle()
            {
                Color = "white",
                Fill = "transparent",
                StrokeColor = "None"
            },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            annotation
        };
        return node;
    }

    private void UpdatePosition()
    {
        nodes[2].OffsetX = 500;
        nodes[2].OffsetY = 200;
    }
}
```

## Appearance

You can change the appearance of the nodegroup similar to node. For more information about node appearance, refer to [Appearance](../nodes/customization).

## Interaction

You can edit the nodegroup and its children at runtime. We able to interact the nodegroup as like the node interaction like resize, rotate and drag. For more information about node interaction, refer to [Interaction](../nodes/interaction).

### Selecting a nodegroup

When a child element of any nodegroup is clicked, its contained nodegroup is selected instead of the child element. With consecutive clicks on the selected element, selection is changed from top to bottom in the hierarchy of parent nodegroup to its children.

## See Also

* [How to enable/disable the behavior of the node](./constraints)