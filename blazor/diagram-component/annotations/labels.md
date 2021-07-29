---
layout: post
title: Annotation in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create and update annotation in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Annotation in Blazor Diagram Component

The `Annotation` is a block of text that can be displayed over a node or connector and it is used to textually represent an object with a string that can be edited at run time. Multiple annotations can be added to a node or connector.

<!-- markdownlint-disable MD033 -->

## Create Annotations

An annotation can be added to a node or connector by defining the annotation object and adding that to the annotation collection of the node or connector. The `Content` property of annotation defines the text to be displayed. The following code explains how to create an annotation.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    //Defines diagram's connector collection
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    //Defines diagram's node collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>() {
                // A annotation is created and stored in Annotations collection of Node.
                 new ShapeAnnotation { Content = "Node" } }
        };
        nodes.Add(node);

        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
          SourcePoint = new Point() { X = 300, Y = 40 },
            TargetPoint = new Point() { X = 400, Y = 160 },
            Type = Segments.Orthogonal,
            Style = new TextShapeStyle() { StrokeColor = "#6495ED" },
            Annotations = new DiagramObjectCollection<PathAnnotation>()
            {
            //A annotation is created and stored in Annotations collection of Connector.
                new PathAnnotation { Content = "Connector" }
            }
        };

        connectors.Add(connector);
    }
}
```

![Annotation](../images/Annotation.png)

>**Note:**
>* `Id` for each annotation should be unique and so it is further used to find the annotation at runtime and do any customization.
>* By default, node’s annotation positioned in center point of the shape.
>* By default, connector’s path annotation positioned center point of its path.

## Add Annotations at runtime

You can add Annotations at runtime to the nodes collection in the Diagram component by using the `Add` method.

The following code explains how to add an annotation to a node at runtime by using `Add` method.

```csharp
@using Syncfusion.Blazor.Diagram

<input value="Addlabel" type="button" @onclick="@AddLabel" name="Addlabel" />
<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    // Reference to diagram
    SfDiagramComponent diagram;
    //Defines diagram's node collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
    //Method to add labels at runtime
    public void AddLabel()
    {
    ShapeAnnotation annotation = new ShapeAnnotation { Content = "Annotation" };
    (diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).Add(annotation);
    }
}
```

Also, the annotations can be added at runtime by using the `AddAsync` method.

The `await` operator suspends evaluation of the enclosing async method until the asynchronous operation represented by its operand completes.

The following code explains how to add an annotation to a node at runtime by using `AddAsync` method.

```csharp
    //Method to add labels at runtime
    public async void AddLabel()
    {
    ShapeAnnotation annotation = new ShapeAnnotation { Content = "Annotation" };
    await(diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).AddAsync(annotation);
    }
```

![Annotation](../images/Annotation_Add.png)

## Remove Annotations

A collection of annotations can be removed from the node by using the `RemoveAt` method. The following code explains how to remove an annotation to a node.

```csharp
@using Syncfusion.Blazor.Diagram

<input value="Removelabel" type="button" @onclick="@RemoveLabel" name="Removelabel" />
<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    //Reference to diagram
    SfDiagramComponent diagram;
    //Defines diagram's node collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
          new ShapeAnnotation {ID="label", Content = "Annotation" },
        };
        nodes.Add(node);
    }
    //Method to remove labels at runtime
    public void RemoveLabel()
    {
      (diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).RemoveAt(0);
    }
}
```

Also, A collection of annotations can be removed from the node by using the `Remove` method.

```csharp
    //Method to remove labels at runtime using Remove method.
    public void RemoveLabel()
    {
         ShapeAnnotation annotation = (diagram.Nodes[0].Annotations[0]) as ShapeAnnotation;
        (diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).Remove(annotation);
    }
```

>**Note:**
>* You can delete multiple annotations from node to pass the collection of annotation objects as argument.
>* The `Add`, `Remove`, and `RemoveAt` methods are applicable for connectors too.

## Update Annotations at runtime

You can get the annotation directly from the node’s annotations collection property and you can change any annotation properties at runtime.

The following code sample shows how the annotation of the node changed at runtime.

```csharp
@using Syncfusion.Blazor.Diagram

<input value="Updatelabel" type="button" @onclick="@UpdateLabel" name="Updatelabel" />
<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    //Reference to diagram
    SfDiagramComponent diagram;

    //Defines diagram's node collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Node" } },
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
    public void UpdateLabel()
    {
        diagram.Nodes[0].Annotations[0].Content = "Updated Annotation";
    }
}
```

## See also

* [`How to add or remove annotation constraints`](../constraints/#annotation-constraints)

* [`How to customize the annotation`](./appearance)