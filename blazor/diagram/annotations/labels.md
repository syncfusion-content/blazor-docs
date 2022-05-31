---
layout: post
title: Actions of Annotation in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about actions of annotation in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Annotation in Blazor Diagram Component

The [Annotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html) is a block of text that can be displayed over a node or connector and it is used to textually represent an object with a string that can be edited at run time. Multiple annotations can be added to a node or connector.

## Create annotations

An annotation can be added to a node or connector by defining the annotation object and adding that to the annotation collection of the node or connector. The [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_Content) property of annotation defines the text to be displayed. The following code explains how to create an annotation.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" Connectors="@connectors" />

@code
{
    // Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors;

    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

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
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                // Annotation is created and stored in Annotations collection of Node.
                new ShapeAnnotation { Content = "Node" }
            }
        };
        nodes.Add(node);
        connectors = new DiagramObjectCollection<Connector>();
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
        connectors.Add(connector);
    }
}
```

![Blazor Diagram Node with Annotation](../images/blazor-diagram-node-with-annotation.png)

>* [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_ID) for each annotation should be unique and so it is further used to find the annotation at runtime and do any customization.
>* By default, node’s annotation positioned in center point of the shape.
>* By default, connector’s path annotation positioned in center point of its path.

## Add Annotations at runtime

You can add Annotation at runtime to the Annotations collection of the node/connector in the diagram component by using the `Add` method.

The following code explains how to add an annotation to a node at runtime by using `Add` method.

```cshtml
@using Syncfusion.Blazor.Diagram

<input value="Addlabel" type="button" @onclick="@AddLabel" name="Addlabel" />
<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    // Reference to diagram.
    SfDiagramComponent diagram;

    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

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

    // Method to add annotation at runtime.
    public void AddLabel()
    {
        ShapeAnnotation annotation = new ShapeAnnotation { Content = "Annotation" };
        (diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).Add(annotation);
    }
}
```

Also, the annotations can be added at runtime by using the [AddAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramObjectCollection-1.html#Syncfusion_Blazor_Diagram_DiagramObjectCollection_1_AddAsync__0_) method. The `await` operator suspends evaluation of the enclosing async method until the asynchronous operation represented by its operand completes.

The following code explains how to add an annotation to a node at runtime by using the `AddAsync` method.

```csharp
//Method to add annotation at runtime.
public async void AddLabel()
{
    ShapeAnnotation annotation = new ShapeAnnotation { Content = "Annotation" };
    await(diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).AddAsync(annotation);
}
```

![Adding Annotation in Blazor Diagram](../images/blazor-diagram-add-annotation.png)

## Remove annotations

A collection of annotations can be removed from the node by using the `RemoveAt` method. The following code explains how to remove an annotation from a node.

```cshtml
@using Syncfusion.Blazor.Diagram

<input value="Removelabel" type="button" @onclick="@RemoveLabel" name="Removelabel" />

<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes" />

@code
{
    // Reference to diagram.
    SfDiagramComponent diagram;

    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
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
        nodes.Add(node);
    }

    // Method to remove annotation at runtime.
    public void RemoveLabel()
    {
        (diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).RemoveAt(0);
    }
}
```

Also, a collection of annotations can be removed from the node by using the `Remove` method.

```cshtml
    // Method to remove annotation at runtime using Remove method.
    public void RemoveLabel()
    {
        ShapeAnnotation annotation = (diagram.Nodes[0].Annotations[0]) as ShapeAnnotation;
        (diagram.Nodes[0].Annotations as DiagramObjectCollection<ShapeAnnotation>).Remove(annotation);
    }
```

>* You can delete multiple annotations from node to pass the collection of annotation objects as argument.
>* The `Add`, `Remove`, and `RemoveAt` methods are applicable for connectors too.

## Update annotations at runtime

You can get the annotation directly from the node’s annotations collection property and you can change any annotation properties at runtime.

The following code sample shows how the annotation of the node changed at runtime.

```cshtml
@using Syncfusion.Blazor.Diagram

<input value="Updatelabel" type="button" @onclick="@UpdateLabel" name="Updatelabel" />

<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes" />

@code
{
    // Reference to diagram.
    SfDiagramComponent diagram;

    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
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
        nodes.Add(node);
    }

    // Method to update the annotation at runtime.
    public void UpdateLabel()
    {
        diagram.Nodes[0].Annotations[0].Content = "Updated Annotation";
    }
}
```

## See also

* [How to add or remove annotation constraints](../constraints/#annotation-constraints)

* [How to customize the annotation](./appearance)
