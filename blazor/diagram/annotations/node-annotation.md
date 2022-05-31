---
layout: post
title: Annotation for Node in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about annotation for node in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# How to position node’s annotation

Diagram allows you to customize the position and appearance of the annotation efficiently. Annotation can be aligned relative to the node boundaries. It has Margin, Offset, Horizontal, and Vertical alignment settings. It is quite tricky when all four alignments are used together but gives more control over alignments properties of the [ShapeAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeAnnotation.html) class. Annotations of a node can be positioned using the following properties of `ShapeAnnotation`.

* Offset
* HorizontalAlignment
* VerticalAlignment
* Margin

## How to change the offset of an annotation

The [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeAnnotation.html#Syncfusion_Blazor_Diagram_ShapeAnnotation_Offset) property of an annotation is used to align the annotations based on fractions. 0 represents top/left corner, 1 represents bottom/right corner, and 0.5 represents half of width/height.

The following code shows the relationship between the shape annotation position and path annotation offset (fraction values).

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
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
                new ShapeAnnotation 
                { 
                    Content = "Offset(0,0)", 
                    // Sets the offset for an annotation's content.
                    Offset = new DiagramPoint() { X = 0, Y = 0 } 
                }
            },
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```

| Offset values | Output |
|---|---|
| (0,0) | ![Blazor Diagram with Annotation in Left Top Position](../images/blazor-diagram-annotation-in-lefttop-position.png) |
| (0,0.5) | ![Blazor Diagram with Annotation in Left Center Position](../images/blazor-diagram-annotation-in-leftcenter-position.png) |
| (0,1) | ![Blazor Diagram with Annotation in Left Bottom Position](../images/blazor-diagram-annotation-in-leftbottom-position.png) |
| (0.5,0) | ![Blazor Diagram with Annotation in Center Top Position](../images/blazor-diagram-annotation-in-centertop-position.png) |
| (0.5,0.5) | ![Blazor Diagram with Annotation in Center Position](../images/blazor-diagram-annotation-in-center-position.png) |
| (0.5,1) | ![Blazor Diagram with Annotation in Center Bottom Position](../images/blazor-diagram-annotation-in-centerbottom-position.png) |
| (1,0) | ![Blazor Diagram with Annotation in Top Right Position](../images/blazor-diagram-annotation-in-topright-position.png) |
| (1,0.5) | ![Blazor Diagram with Annotation in Right Center Position](../images/blazor-diagram-annotation-in-rightcenter-position.png) |
| (1,1) | ![Blazor Diagram with Annotation in Right Bottom Position](../images/blazor-diagram-annotation-in-rightbottom-position.png) |


>* Type of the offset property for node’s shape annotation is [DiagramPoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPoint.html).
>* Type of the offset property for connector’s path annotation is double.

## How to change the alignment of an annotation

The [HorizontalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_HorizontalAlignment) property of annotation is used to set how the annotation is horizontally aligned at the annotation position determined from the fraction values. The [VerticalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_VerticalAlignment) property is used to set how the annotation is vertically aligned at the annotation position.

The following table shows all the possible alignments visually with 'offset (0, 0)'.

| Horizontal Alignment | Vertical Alignment | Output with Offset(0,0) |
| -------- | -------- | -------- |
| Left | Top | ![Blazor Diagram Label in Left Top Position](../images/blazor-diagram-label-in-lefttop-position.png) |
| Center | Top | ![Blazor Diagram Label in Center Top Position](../images/blazor-diagram-label-in-centertop-position.png) |
| Right | Top |  ![Blazor Diagram Label in Right Top Position](../images/blazor-diagram-label-in-righttop-position.png) |
| Left | Center | ![Blazor Diagram Label in Left Center Position](../images/blazor-diagram-label-in-leftcenter-position.png) |
| Center | Center| ![Blazor Diagram Label in Center Center Position](../images/blazor-diagram-label-in-centercenter-position.png) |
| Right | Center | ![Blazor Diagram Label in Right Center Position](../images/blazor-diagram-label-in-rightcenter-position.png) |
| Left | Bottom | ![Blazor Diagram Label in Left Bottom Position](../images/blazor-diagram-label-in-leftbottom-position.png) |
| Center | Bottom | ![Blazor Diagram Label in Center Bottom Position](../images/blazor-diagram-label-in-centerbottom-position.png) |
| Right |Bottom |![Blazor Diagram Label in Right Bottom Position](../images/blazor-diagram-label-in-rightbottom-position.png) |

The following code explains how to align annotations.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Width = 100,
            Height = 100,
            OffsetX = 250,
            OffsetY = 250,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    Content = "Annotation",
                    // Sets the HorizontalAlignment and VerticalAlignment for the content.
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```

>* The value of the `HorizontalAlignment` is [Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.HorizontalAlignment.html#Syncfusion_Blazor_Diagram_HorizontalAlignment_Center) by default.
>* The value of the `VerticalAlignment` is [Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.VerticalAlignment.html#Syncfusion_Blazor_Diagram_VerticalAlignment_Center) by default.
>* Alignment positioned based on the offset value.

## How to change the margin of an annotation

[Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_Margin) is an absolute value used to add some blank space to any one of its four sides. The annotations can be displaced with the margin property. The following code example explains how to align an annotation based on its Offset, HorizontalAlignment, VerticalAlignment, and Margin values.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    Content = "Task1",
                    // Sets the margin for the content.
                    Margin = new Margin() { Top = 10},
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    Offset = new DiagramPoint(){ X = 0.5 ,Y = 1}
                }
            },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```

## How to align the text

The [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html#Syncfusion_Blazor_Diagram_TextStyle_TextAlign) property of annotation allows you to set how the text should be aligned (Left, Right, Center, or Justify) inside the text block. The following code explains how to set TextAlign for an annotation.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    Content = "Text align is set as Left",
                    Style = new TextStyle()
                    { 
                        // Sets the textAlign as left for the content.
                        TextAlign = TextAlign.Left
                    } 
                }
            },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```

## See also

* [How to add annotation for Connector](./connector-annotation)

* [How to add or remove annotation constraints](../constraints/#annotation-constraints)

* [How to customize the annotation](./appearance)
