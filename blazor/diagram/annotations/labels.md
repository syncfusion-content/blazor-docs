---
layout: post
title: Annotation in Blazor Diagram Component | Syncfusion
description: Checkout and Learn how to create, add, remove, and update annotation for nodes and connectors in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Annotation in Blazor Diagram Component

The [Annotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html) is a block of text that can be displayed over a node or connector and it is used to textually represent an object with a string that can be edited at run time. Multiple annotations can be added to a single node or connector.

## How to Create an Annotation

An annotation can be added to a node or connector by defining the annotation object and adding it to the `Annotation` collection of the parent object. The [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_Content) property of the annotation defines the text to be displayed. 


To create and add annotations to nodes and connectors using the Blazor Diagram, refer to the following video:

{% youtube "youtube:https://www.youtube.com/watch?v=f7Jnl5hSy7I" %}

The following code example demonstrates how to create an annotation for a node and a connector.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes" Connectors="@_connectors" />

@code
{
    // Defines diagram's connector collection.
    DiagramObjectCollection<Connector> _connectors;

    // Defines diagram's node collection.
    DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                // Annotation is created and stored in Annotations collection of Node.
                new ShapeAnnotation { Content = "Node" }
            }
        };
        _nodes.Add(node);
        _connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            SourcePoint = new DiagramPoint() { X = 300, Y = 40 },
            TargetPoint = new DiagramPoint() { X = 400, Y = 160 },
            Type = ConnectorSegmentType.Orthogonal,
            Style = new TextStyle() { StrokeColor = "#6495ED" },
            Annotations = new DiagramObjectCollection<PathAnnotation>()
            {
                // Annotation is created and stored in Annotations collection of Connector.
                new PathAnnotation { Content = "Connector" }
            }
        };
        _connectors.Add(connector);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjroijNRrQAsIOIt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/CreateAnnotation.razor)

![Blazor Diagram Node with Annotation](../images/blazor-diagram-node-with-annotation.png)

N>* Each annotation's [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_ID) should be unique. It can be used to find and customize the annotation at runtime.
<br/>* By default, a node's annotation is positioned at the center of the shape.
<br/>* By default, a connector’s path annotation positioned at the center of its path.
>**Note:** Do not use underscores(_) for annotation's id.

## How to Add an Annotation at Runtime

An annotation can be added to the `Annotations` collection of a node or connector at runtime by using the `Add` method.

The following code explains how to add an annotation to a node at runtime by using `Add` method.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Addlabel" OnClick="@AddLabel" />
<SfDiagramComponent Height="600px" @ref="@_diagram" Nodes="@_nodes">
</SfDiagramComponent>

@code
{
    // Reference to diagram.
    SfDiagramComponent _diagram;

    // Defines diagram's node collection.
    DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        _nodes.Add(node);
    }

    // Method to add annotation at runtime.
    public void AddLabel()
    {
        ShapeAnnotation annotation = new ShapeAnnotation { Content = "Annotation" };
        (_diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).Add(annotation);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLIMjtxrwUyoCqW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/AddAnnotationAtRunTime.razor)

Also, the annotations can be added at runtime by using the [AddAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramObjectCollection-1.html#Syncfusion_Blazor_Diagram_DiagramObjectCollection_1_AddAsync__0_) method. The `await` operator suspends the evaluation of the enclosing async method until the asynchronous operation represented by its operand completes.

The following code explains how to add an annotation to a node at runtime by using the `AddAsync` method.

```csharp
//Method to add annotation at runtime.
public async void AddLabelAsync()
{
    ShapeAnnotation _annotation = new ShapeAnnotation { Content = "Annotation" };
    await (_diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).AddAsync(_annotation);
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/AddAsync.razor)

![Adding Annotation in Blazor Diagram](../images/blazor-diagram-add-annotation.png)

## How to Remove an Annotation at Runtime

An annotation can be removed from a node or connector's `Annotations` collection by using the `RemoveAt` method. The following code explains how to remove an annotation from a node.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons


<SfButton Content="Removelabel" OnClick="@RemoveLabel" />

<SfDiagramComponent Height="600px" @ref="@_diagram" Nodes="@_nodes" />

@code
{
    // Reference to diagram.
    SfDiagramComponent _diagram;

    // Defines diagram's node collection.
    DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation {ID = "label", Content = "Annotation" },
        };
        _nodes.Add(node);
    }

    // Method to remove annotation at runtime.
    public void RemoveLabel()
    {
        (_diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).RemoveAt(0);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjByiXZHBwzKleyR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/RemoveAnnotationUsingRemoveAt.razor)

Also, The `Remove` method can also be used to remove a specific annotation object.

```cshtml
    // Method to remove annotation at runtime using Remove method.
    public void RemoveLabel()
    {
        ShapeAnnotation _annotation = (diagram.Nodes[0].Annotations[0]) as ShapeAnnotation;
        (diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).Remove(_annotation);
    }
```

N>* You can delete multiple annotations from a node to pass the collection of annotation objects as argument.
<br/>* The `Add`, `AddAsync`, `Remove`, and `RemoveAt` methods are applicable for connectors too.

## How to Update an Annotation at Runtime

An annotation can be updated at runtime by retrieving it from the node or connector's Annotations collection and modifying its properties.

The following code sample shows how to change the content of a node's annotation at runtime.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons


<SfButton Content="Updatelabel" OnClick="@UpdateLabel" />

<SfDiagramComponent Height="600px" @ref="@_diagram" Nodes="@_nodes" />

@code
{
    // Reference to diagram.
    SfDiagramComponent _diagram;

    // Defines diagram's node collection.
    DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>() 
            { 
                new ShapeAnnotation { Content = "Node" } 
            },
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        _nodes.Add(node);
    }

    // Method to update the annotation at runtime.
    public void UpdateLabel()
    {
        _diagram.Nodes[0].Annotations[0].Content = "Updated Annotation";
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBIitZxBcSXRxWo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Annotations/UpdateAnnotation.razor)

## See also

* [How to add or remove annotation constraints](../constraints#annotation-constraints)

* [How to customize the annotation](./appearance)

* [How to animate connectors using annotation template in angular diagram](https://support.syncfusion.com/kb/article/20265/how-to-animate-connectors-using-annotation template-in-angular-diagram )

* [How to dynamically create and connect diagram nodes with annotations via ports in syncfusion<sup style="font-size:70%">&reg;</sup> blazor diagram](https://support.syncfusion.com/kb/article/19001/how-to-dynamically-create-and-connect-diagram-nodes-with-annotations-via-ports-in-syncfusion-blazor-diagram) 
* [How to Prevent text Overflow and display excess Content on hover in a diagram](https://support.syncfusion.com/kb/article/18726/how-to-prevent-text-overflow-and-display-excess-content-on-hover-in-a-diagram)

* [How to generate a hierarchical layout with annotations at runtime](https://support.syncfusion.com/kb/article/17884/how-to-generate-a-hierarchical-layout-with-annotation-at-runtime)