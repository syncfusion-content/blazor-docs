---
layout: post
title: NodeGroup in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create and update the NodeGroup in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# NodeGroup in Blazor Diagram Component

[NodeGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeGroup.html) is used to cluster multiple nodes and connectors into a single element. It acts like a container for its children (nodes, nodegroups, and connectors). Every change made to the node group also affects the children. Child elements can be edited individually.

## Create NodeGroup

## Add NodeGroup when initializing diagram

A node group can be added to the diagram model through [Nodes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html) collection. To define an object as node group, add the child objects to the [Children](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeGroup.html#Syncfusion_Blazor_Diagram_NodeGroup_Children) collection of the node group. The following code illustrates how to create a node group.

* While creating node group, its child node needs to be declared before the node group declaration.

* Add a node to the existing node group child by using the [Group](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Group) method.

* The nodegroup’s [Ungroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Ungroup) method is used to define whether the node group can be ungrouped or not.

* A node group can be added into a child of another node group.

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
        NodeGroup groupNode = new NodeGroup();
        // Grouping node 1 and node 2 into a single nodegroup.
        groupNode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
        nodes.Add(node3);
        nodes.Add(groupNode);
    }

    public Node createNode(string id, double offsetX, double offsetY, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offsetX,
            OffsetY = offsetY,
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
            // Adding the third node into the existing nodegroup.
            diagram.Group();
        }
    }
}
```

![Grouping in Blazor Diagram](images/blazor-diagram-grouping.png)

The following code illustrates how to ungroup at runtime.

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
        NodeGroup groupNode = new NodeGroup();
        // Grouping node 1 and node 2 into a single nodegroup.
        groupNode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
        nodes.Add(groupNode);
    }

    public Node createNode(string id, double offsetX, double offsetY, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offsetX,
            OffsetY = offsetY,
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
            // Ungroup the selected group into nodes.
            diagram.Ungroup();
        }
    }
}
```

## Add NodeGroup at runtime

A node group can be added at runtime by using Nodes collection of diagram.

The following code illustrates how a node group is added at runtime.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="AddGroup" @onclick="@AddGroup" />
@* Initialize the diagram with NodeCollection *@
<SfDiagramComponent Height="500px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    NodeGroup groupNode = new NodeGroup();

    protected override void OnInitialized()
    {
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        // Grouping node 1 and node 2 into a single node-group.
        groupNode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
    }

    public Node createNode(string id, double offsetX, double offsetY, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offsetX,
            OffsetY = offsetY,
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
        nodes.Add(groupNode);
    }
}
```

* Also, you can add the child to the node group through [AddChild](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_AddChild_Syncfusion_Blazor_Diagram_NodeGroup_Syncfusion_Blazor_Diagram_NodeBase_) method. The following code illustrates how to add child to the existing node group through AddChild method.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="AddChildToGroup" @onclick="@AddChildToGroup" />
@* Initialize the diagram with nodes *@
<SfDiagramComponent @ref="@diagram" Height="500px" Nodes="@nodes"/>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    NodeGroup groupNode = new NodeGroup();

    protected override void OnInitialized()
    {
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        // Grouping node 1 and node 2 into a single node-group.
        groupNode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
        nodes.Add(groupNode);
    }

    public Node createNode(string id, double offsetX, double offsetY, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offsetX,
            OffsetY = offsetY,
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

You can change the position of the node group similar to node. For more information about node positioning, refer to [Positioning](https://blazor.syncfusion.com/documentation/diagram/nodes/positioning).

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="UpdatePosition" @onclick="@UpdatePosition" />
@* Initialize the diagram with NodeCollection *@
<SfDiagramComponent Height="500px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    NodeGroup groupNode = new NodeGroup();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node1 = createNode("node1", 100, 100, "Node1");
        Node node2 = createNode("node2", 300, 100, "Node2");
        // Grouping node 1 and node 2 into a single NodeGroup.
        groupNode.Children = new string[] { "node1", "node2" };
        nodes.Add(node1);
        nodes.Add(node2);
        nodes.Add(groupNode);
    }

    public Node createNode(string id, double offsetX, double offsetY, string content)
    {
        Node node = new Node()
        {
            ID = id,
            OffsetX = offsetX,
            OffsetY = offsetY,
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

## Change the appearance of the node group

You can change the appearance of the node group similar to node. For more information about node appearance, refer to [Appearance](https://blazor.syncfusion.com/documentation/diagram/nodes/customization).

## Interact with the node group

You can edit the node group and its children at runtime. You can interact with the nodegroup as like the node interaction like resize, rotate and drag. For more information about node interaction, refer to [Interaction](https://blazor.syncfusion.com/documentation/diagram/nodes/interaction).

### Selecting a NodeGroup

When a child element of any node group is clicked, its contained node group is selected instead of the child element. With consecutive clicks on the selected element, selection is changed from top to bottom in the hierarchy of parent nodegroup to its children.

## How to flip the GroupNode
The Flip command is used to flip the content and port of the chosen object is mirrored across  in either the horizontal, vertical, or both directions on the diagram page.

**Note:** We can flip the groupnode as well as the selected childnodes.

### How to change the Flip Direction:
The flipdirection is used to flip the node or connector so that it is mirrored across in either horizontal, vertical, or both directions.

| FlipDirection | Description | 
| -------- | -------- |
|Horizontal|It is used to flip the node is mirrored across the horizontal axis.|
|Vertical|	It is used to flip the node is mirrored across the vertical axis.|
|Both|		It is used to flip the node is mirrored across the both horizontal and vertical axis.|
|None|	It is used to disables all the flip behaviour.| 

### How to change the Flip Mode:
The FlipMode is used to control the behaviour of the flip object.
| DiagramFlipMode | Description | 
| -------- | -------- |
|Content|It is used to enable or disable the flip for object’s content..|
|Port|	It is used to enable or disable the flip for object’s port.|
|All|	It is used to enable or disable the flip for both object’s content and port.|
|None|	It is used to disable all the flipmode behaviour.|

**Note:** Flipmode is only applicable for Nodes not for Connectors.

The following code example shows how to change the FlipDirection and FlipMode.
```chtml
@using Syncfusion.Blazor.Diagram
@using ChangeEventArgs = Microsoft.AspNetCore.Components.ChangeEventArgs
<style>    
    #diagram {
        width: 70%;
        float: left;
    }
    #properties {
        width: 15%;
        float: right;
        margin-right:300px;
    }
</style>
<div id="properties">
    <input type="button" value="HorizontalPort" @onclick="@HorizontalPort" />
    <input type="button" value="HorizontalContent" @onclick="@HorizontalContent" />
    <input type="button" value="HorizontalAll" @onclick="@HorizontalAll" />
    <input type="button" value="HorizontalNone" @onclick="@HorizontalNone" />  
 </div>     
<div id="#diagram">
    <SfDiagramComponent @ref="diagram" Width="1000px" Height="1000px"  Nodes="@NodeCollection" Connectors="@connectors">
        <SnapSettings Constraints="@SnapConstraints.None"></SnapSettings>
    </SfDiagramComponent>
    </div>
@code
{
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    public SfDiagramComponent diagram;
    DiagramObjectCollection<Node> NodeCollection;
      protected override void OnInitialized()
    {
        Node node3 = new Node()
        {
            ID = "node3",
            Width = 100,
            Height = 60,
            OffsetX = 500,
            OffsetY = 300, 
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                {
                    ID="ano3",
                    Content = "node1", 
                    Offset = new DiagramPoint() { X = 0.5, Y = 0.5 } 
                }
            },
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
            },
            Shape= new FlowShape()
            {
                Type=NodeShapes.Flow,
                Shape=NodeFlowShapes.Card                   
            },
            Ports = new DiagramObjectCollection<PointPort>()
            {
               new PointPort()
               {   ID="port3",
                   Style = new ShapeStyle(){ Fill = "gray" },
                   Offset = new DiagramPoint() { X = 0, Y = 0 },
                   Width=14,Height=14,
                   Visibility = PortVisibility.Visible
               }
            },
        };
        Node node4 = new Node()
        {
            ID = "node4",
            Width = 100,
            Height = 60,
            OffsetX = 700,
            OffsetY = 400,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
            },
            Shape= new FlowShape()
            {
                Type=NodeShapes.Flow,
                Shape=NodeFlowShapes.Card                   
            },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    ID="anno4",
                    Content = "node2", 
                    Offset = new DiagramPoint() { X = 0.5, Y = 0.5 } 
                }
            },
            Ports = new DiagramObjectCollection<PointPort>()
            {
               new PointPort()
               {   ID="port4",
                   Style = new ShapeStyle(){ Fill = "gray" },
                   Offset = new DiagramPoint() { X = 0, Y = 0 }, 
                   Width=14,Height=14,
                   Visibility = PortVisibility.Visible
               }
            },
          };
        NodeCollection = new DiagramObjectCollection<Node>() {node3,node4 };
        NodeGroup groupNode = new NodeGroup()
        {
                ID="group",
                Children = new string[] { "node3", "node4" },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                    new ShapeAnnotation 
                    { 
                        ID="anno4",
                        Content = "GroupNode", 
                        Offset = new DiagramPoint() { X = 0.5, Y = 0.5 } 
                    }
                },
            Ports = new DiagramObjectCollection<PointPort>()
            {
               new PointPort()
               {   ID="port4",
                   Style = new ShapeStyle(){ Fill = "gray" },
                   Offset = new DiagramPoint() { X = 0, Y = 0}, 
                    Width=14,Height=14,
                   Visibility = PortVisibility.Visible
               }
            },
        };
        NodeCollection.Add(groupNode);
    }
    
    public void HorizontalPort()
    {     
        if (diagram.SelectionSettings.Nodes.Count > 0)
        {
            for(int i = 0; i < diagram.SelectionSettings.Nodes.Count; i++)
            {
                diagram.SelectionSettings.Nodes[i].FlipMode = DiagramFlipMode.Port;
                if (diagram.SelectionSettings.Nodes[i].Flip.HasFlag(FlipDirection.Horizontal))
                {
                    diagram.SelectionSettings.Nodes[i].Flip &= ~FlipDirection.Horizontal;
                }
                else
                {
                    diagram.SelectionSettings.Nodes[i].Flip |= FlipDirection.Horizontal;
                }               
            }
        }            
    }
    public void HorizontalContent()
    {     
        if (diagram.SelectionSettings.Nodes.Count > 0)
        {
            for(int i = 0; i < diagram.SelectionSettings.Nodes.Count; i++)
            {
                diagram.SelectionSettings.Nodes[i].FlipMode = DiagramFlipMode.Content;
                if (diagram.SelectionSettings.Nodes[i].Flip.HasFlag(FlipDirection.Horizontal))
                {
                    diagram.SelectionSettings.Nodes[i].Flip &= ~FlipDirection.Horizontal;
                }
                else
                {
                    diagram.SelectionSettings.Nodes[i].Flip |= FlipDirection.Horizontal;
                }               
            }
        }            
    }
    public void HorizontalAll()
    {     
        if (diagram.SelectionSettings.Nodes.Count > 0)
        {
            for(int i = 0; i < diagram.SelectionSettings.Nodes.Count; i++)
            {
                diagram.SelectionSettings.Nodes[i].FlipMode = DiagramFlipMode.All;
                if (diagram.SelectionSettings.Nodes[i].Flip.HasFlag(FlipDirection.Horizontal))
                {
                    diagram.SelectionSettings.Nodes[i].Flip &= ~FlipDirection.Horizontal;
                }
                else
                {
                    diagram.SelectionSettings.Nodes[i].Flip |= FlipDirection.Horizontal;
                }              
            }
        }            
    }
    public void HorizontalNone()
    {     
        if (diagram.SelectionSettings.Nodes.Count > 0)
        {
            for(int i = 0; i < diagram.SelectionSettings.Nodes.Count; i++)
            {
                diagram.SelectionSettings.Nodes[i].FlipMode = DiagramFlipMode.None;
                if (diagram.SelectionSettings.Nodes[i].Flip.HasFlag(FlipDirection.Horizontal))
                {
                    diagram.SelectionSettings.Nodes[i].Flip &= ~FlipDirection.Horizontal;
                }
                else
                {
                    diagram.SelectionSettings.Nodes[i].Flip |= FlipDirection.Horizontal;
                }                               
            }
        }       
    }
}
```
Initial rendering:

![Initial Rendering](Images/blazor-diagram-group-node-flip-initial-rendering.png)

| FlipDirection | DiagramFlipMode | Output|
| -------- | -------- |-------- |
|Horizontal|Port|![HorizontalDirection with PortMode](Images/blazor-diagram-group-node-flip-direction-as-horizontal-flip-mode-as-port.png)|
|Horizontal|Content|![HorizontalDirection with ContentMode](Images/blazor-diagram-group-node-flip-direction-as-horizontal-flip-mode-as-content.png)|
|Horizontal|All|![HorizontalDirection with AllMode](Images/blazor-diagram-group-node-flip-direction-as-horizontal-flip-mode-as-all.png)|
|Horizontal|None|![HorizontalDirection with NoneMode](Images/blazor-diagram-group-node-flip-direction-as-horizontal-flip-mode-as-none.png)|

## See Also

* [How to enable/disable the behavior of the node](./constraints)