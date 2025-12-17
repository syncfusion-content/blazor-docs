---
layout: post
title: Lane Interaction in Blazor Diagram Component | Syncfusion
description: How to select, resize(with and without selection), and swap the lane, and how to add the child element into the lane.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Lane Interaction in Blazor Diagram Component

The diagram supports interactive lane operations, including selecting, resizing, and swapping lanes, as well as working with child elements inside lanes. 

## How to Select a Lane

A [Lane](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Lane.html) can be selected by clicking (tapping) the header of the lane.

## How to Resize a Lane

* A lane can be resized in the bottom and right direction.
* A lane can be resized by using the resize selector of the lane.
* A lane can be resized by dragging the bottom and right border of the lane without making a selection.
* When a lane is resized, the parent swimlane will automatically adjust its size.
* A lane can resized either by resizing the selector or the tight bounds of the child objects. If a child node moves to the edge of the lane, it can be automatically resized.

The following image shows how to resize the lane.

![Lane Resizing](../Swimlane-images/Lane_Resize.gif)

## How to Swap Lanes

* Lanes can be swapped by dragging a lane over another lane.
* A helper indicator appears to show the insertion position during lane swapping.
The following image shows how to swap lanes.

![Lane Swapping](../Swimlane-images/Lane_Swapping.gif)

## How to Interact with Child Nodes in Lanes

* Resize child nodes within swimlanes.
* You can drag the child nodes within the lane.
* Drag child nodes within the same lane to reposition them.
* Drag and drop the child nodes from a lane to the diagram.
* Drag and drop the child nodes from diagram to the lane.
* Based on the child node interactions, the lane size will be updated.

The following image shows children interaction in lane.

![Lane Children Interaction](../Swimlane-images/Child_Interaction.gif)

## How to restrict nodes from being dragged outside their swimlane

By default, nodes in a swimlane can be moved freely both within and outside the swimlane boundaries. Enabling the **NodeConstraints.AllowDragWithinSwimlane** option on the node’s [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_Constraints) property prevents the node from moving outside the swimlane. When a node is dragged beyond its boundaries, a 'not allowed' cursor appears to indicate the restriction.
 
To enforce this restriction for all child nodes within swimlanes, set the constraint during node initialization in the [NodeCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_NodeCreating) event.
 
The following example demonstrates a node with the text "AllowDrag Within Swimlane" restricted to its swimlane boundaries:

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Swimlanes="@SwimlaneCollections" NodeCreating="@OnNodeCreating" >
    <SnapSettings Constraints="SnapConstraints.None"></SnapSettings>
</SfDiagramComponent>

@code
{
    // Define diagram's swimlane collection
    private DiagramObjectCollection<Swimlane> SwimlaneCollections = new DiagramObjectCollection<Swimlane>();

    protected override void OnInitialized()
    {
        // A swimlane is created and stored in the swimlanes collection
        Swimlane swimlane = new Swimlane()
        {
            Header = new SwimlaneHeader()
            {
                Annotation = new ShapeAnnotation()
                {
                    Content = "SALES PROCESS FLOW CHART"
                },
                Height = 50,
            },
            OffsetX = 400,
            OffsetY = 200,
            Height = 120,
            Width = 450,
            Lanes = new DiagramObjectCollection<Lane>()
            {
                new Lane()
                {
                    Height = 100,
                    Header = new SwimlaneHeader()
                    {
                        Width = 30,
                        Annotation = new ShapeAnnotation(){ Content = "Consumer" }
                    },
                    Children = new DiagramObjectCollection<Node>()
                    {
                        new Node()
                        {
                            Height = 50, 
                            Width = 100, 
                            LaneOffsetX = 100, 
                            LaneOffsetY = 30, 
                            // To enable AllowDragWithinSwimlane to restrict movement outside the swimlane
                            Constraints = NodeConstraints.Default | NodeConstraints.AllowDragWithinSwimlane, 
                            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                            { 
                                new ShapeAnnotation() 
                                { 
                                    Content="AllowDrag Within Swimlane",
                                    Style= new  TextStyle()
                                    {
                                        TextOverflow = TextOverflow.Wrap, TextWrapping = TextWrap.WrapWithOverflow
                                    }
                                } 
                            } 
                        },
                        new Node()
                        {
                            Height = 50, 
                            Width = 50, 
                            LaneOffsetX = 250, 
                            LaneOffsetY = 30
                        },
                    }
                },
            }
        };
        // Add swimlane
        SwimlaneCollections.Add(swimlane);
    }

    private void OnNodeCreating(IDiagramObject obj)
    {
        if (obj is Swimlane swimlane)
        {
            swimlane.Header.Style = new TextStyle()
            {
                Fill = "#5b9bd5",
                StrokeColor = "#5b9bd5"
            };
            foreach (Phase phase in swimlane.Phases)
            {
                phase.Style = new ShapeStyle() { Fill = "#5b9bd5", StrokeColor = "#5b9bd5" };
            }
            foreach (Lane lane in swimlane.Lanes)
            {
                lane.Header.Style = new TextStyle() { Fill = "#5b9bd5", StrokeColor = "#5b9bd5" };
            }
        }
        else if (obj is Node node)
        {
            node.Style = new ShapeStyle()
            {
                Fill = "#5b9bd5",
                StrokeColor = "#5b9bd5"
            };
        }
    }
}

``` 

The following example demonstrates that a constraint can also be enabled or disabled at runtime, for example, via a button click.

```cshtml
@using Syncfusion.Blazor.Diagram

<button onclick="@AllowDrag">AllowDrag</button>
<SfDiagramComponent Height="600px" Swimlanes="@SwimlaneCollections" NodeCreating="@OnNodeCreating" >
    <SnapSettings Constraints="SnapConstraints.None"></SnapSettings>
</SfDiagramComponent>

@code
{
    // Define diagram's swimlane collection
    DiagramObjectCollection<Swimlane> SwimlaneCollections = new DiagramObjectCollection<Swimlane>();

    protected override void OnInitialized()
    {
        // A swimlane is created and stored in the swimlanes collection
        Swimlane swimlane = new Swimlane()
        {
            Header = new SwimlaneHeader()
            {
                Annotation = new ShapeAnnotation()
                {
                    Content = "SALES PROCESS FLOW CHART"
                },
                Height = 50,
            },
            OffsetX = 400,
            OffsetY = 200,
            Height = 120,
            Width = 450,
            Lanes = new DiagramObjectCollection<Lane>()
            {
                new Lane()
                {
                    Height = 100,
                    Header = new SwimlaneHeader()
                    {
                        Width = 30,
                        Annotation = new ShapeAnnotation(){ Content = "Consumer" }
                    },
                    Children = new DiagramObjectCollection<Node>()
                    {
                        new Node()
                        {
                            Height = 50, 
                            Width = 100,
                            LaneOffsetX = 250, 
                            LaneOffsetY = 30
                        },
                    }
                },
            }
        };
        // Add swimlane
        SwimlaneCollections.Add(swimlane);
    }

    public void AllowDrag()
    {
        if (diagramComponent.SelectionSettings.Nodes.Count > 0)
        {
            if (diagramComponent.SelectionSettings.Nodes[0].Constraints.HasFlag(NodeConstraints.AllowDragWithinSwimlane))
            {
                diagramComponent.SelectionSettings.Nodes[0].Constraints &= ~NodeConstraints.AllowDragWithinSwimlane;

            }
            else
            {
                diagramComponent.SelectionSettings.Nodes[0].Constraints |= NodeConstraints.AllowDragWithinSwimlane;
            }
        }
    }
}

``` 

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVeMBiRzuEmRSmS?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" backgroundimage "[Allow Drag Within Swimlane](../Swimlane-images/AllowDragWithinSwimlane.gif)" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Swimlanes/Lane/AllowDragWithinSwimlane/AllowDragWithinSwimlane)
