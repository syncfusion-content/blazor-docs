---
layout: post
title: Group in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create and update the group in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Group in Blazor Diagram Component

Group is used to cluster multiple nodes and connectors into a single element. It acts like a container for its children (nodes, groups, and connectors). Every change made to the group also affects the children. Child elements can be edited individually.

## Create group

## Add group when initializing diagram

A group can be added to the diagram model through `Nodes` collection. To define an object as group, add the child objects to the `Children` collection of the group. The following code illustrates how to create a group node.

* While creating group, its child node needs to be declared before the group declaration.

* Add a node to the existing group child by using the `diagram.Group` method.

* The group’s `diagram.UnGroup` method is used to define whether the group can be ungrouped or not.

* A group can be added into a child of another group.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the diagram with nodes *@
 <SfDiagramComponent Height="500px" @ref="diagram" Nodes="@nodes">
 </SfDiagramComponent>

@code{
SfDiagramComponent diagram;
DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
protected override void OnInitialized()
{
    Node node1 = createNode("node1", 100, 100, "Node1");
    Node node2 = createNode("node2", 300, 100, "Node2");
    Node node3 = createNode("node3", 200, 250, "Node3");
    Group groupnode = new Group();
    // Grouping node 1 and node 2 into a single group
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
        ID="annotation1",
        Content = content,
        Style=new TextShapeStyle(){Color="white", Fill="transparent",StrokeColor="None"},
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
        // Adding the third node into the existing group
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
<SfDiagramComponent Height="500px" @ref="diagram" Nodes="@nodes">
</SfDiagramComponent>

@code{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");

        Group groupnode = new Group();
        // Grouping node 1 and node 2 into a single group
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
            Style = new TextShapeStyle() { Color = "white", Fill = "transparent", StrokeColor = "None" },
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

## Add group at runtime

A group node can be added at runtime by using Nodes collection of diagram.

The following code illustrates how a group node is added at runtime

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="AddGroup" @onclick="@AddGroup" />
@* Initialize the diagram with nodes *@
<SfDiagramComponent Height="500px" Nodes="@nodes">
</SfDiagramComponent>

@code{

DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
Group groupnode = new Group();
protected override void OnInitialized()
{
    Node node1 = createNode("node1", 100, 100, "Node1");
    Node node2 = createNode("node2", 300, 100, "Node2");
    // Grouping node 1 and node 2 into a single group
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
        ID="annotation1",
        Content = content,
        Style=new TextShapeStyle(){Color="white", Fill="transparent",StrokeColor="None"},
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

* Also, you can add the child to the group through `AddChild` method. The following code illustrates how to add child to the existing group through AddChild method.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="AddChildToGroup" @onclick="@AddChildToGroup" />
@* Initialize the diagram with nodes *@
<SfDiagramComponent @ref="@diagram" Height="500px" Nodes="@nodes">
</SfDiagramComponent>

@code{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    Group groupnode = new Group();
    protected override void OnInitialized()
    {
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        // Grouping node 1 and node 2 into a single group
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
            Style = new TextShapeStyle() { Color = "white", Fill = "transparent", StrokeColor = "None" },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
{
        annotation
    };
        return node;
    }
    private async void AddChildToGroup()
    {
        Group group = diagram.SelectedItems.Nodes[0] as Group;
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
                            Style = new TextShapeStyle() { Color = "white", Fill = "transparent", StrokeColor = "None" },
                        }
                    }
        };
        await diagram.AddChild(group as Group, node);
    }
}
```

## Update position at runtime

You can change the position of the group similar to node. For more information about node positioning, refer to [Positioning](../nodes/positioning).

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="UpdatePosition" @onclick="@UpdatePosition" />
@* Initialize the diagram with nodes *@
<SfDiagramComponent Height="500px" Nodes="@nodes">
</SfDiagramComponent>

@code{

    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    Group groupnode = new Group();
    SfDiagramComponent Diagram;
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        // Grouping node 1 and node 2 into a single group
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
            Style = new TextShapeStyle() { Color = "white", Fill = "transparent", StrokeColor = "None" },
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

You can change the appearance of the group similar to node. For more information about node appearance, refer to [Appearance](../nodes/customization).

## Interaction

You can edit the group and its children at runtime. We able to interact the group as like the node interaction like resize, rotate and drag. For more information about node interaction, refer to [Interaction](../nodes/interaction).

### Selecting a group

When a child element of any group is clicked, its contained group is selected instead of the child element. With consecutive clicks on the selected element, selection is changed from top to bottom in the hierarchy of parent Group to its children.

## See Also

* [How to enable/disable the behavior of the node](./constraints)