---
layout: post
title: Annotation for node in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Annotation for node in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram
documentation: ug
---

# Annotation for node in Blazor Diagram Component

Diagram allows you to customize the position and appearance of the annotation efficiently.
Annotation can be aligned relative to the node boundaries. It has Margin, Offset, Horizontal, and Vertical alignment settings. It is quite tricky when all four alignments are used together but gives more control over alignments properties of the [`DiagramNodeAnnotation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html) class.
Annotations of a node can be positioned using the following properties of [`DiagramNodeAnnotation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html).

* [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html#Syncfusion_Blazor_Diagrams_DiagramNodeAnnotation_Offset)
* [`HorizontalAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html#Syncfusion_Blazor_Diagrams_DiagramNodeAnnotation_HorizontalAlignment)
* [`VerticalAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html#Syncfusion_Blazor_Diagrams_DiagramNodeAnnotation_VerticalAlignment)
* [`Margin`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html#Syncfusion_Blazor_Diagrams_DiagramNodeAnnotation_Margin)

## Offset

The [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html#Syncfusion_Blazor_Diagrams_DiagramNodeAnnotation_Offset) property of an annotation is used to align the annotations based on fractions. 0 represents top/left corner, 1 represents bottom/right corner, and 0.5 represents half of width/height.

The following code shows the relationship between the shape annotation position and path annotation offset (fraction values).

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code
{
    //Defines diagram's node collection
    public ObservableCollection<DiagramNode> NodeCollection
    {
        get;
        set;
    }

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>() {
                new DiagramNodeAnnotation() { Content = "Offset(0,0)", Offset = new NodeAnnotationOffset() { X = 0, Y = 0 } }
            },
            OffsetY = 100,
            Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
        };
        NodeCollection.Add(node);
    }
}

```

| Offset values | Output |
|---|---|
| (0,0) | ![Left](../images/Offset0,0.png) |
| (0,0.5) | ![Left](../images/Offset0,5.png) |
| (0,1) | ![Left](../images/Offset0,1.png) |
| (0.5,0) | ![Left](../images/Offset5,0.png) |
| (0.5,0.5) | ![Left](../images/Offset5,5.png) |
| (0.5,1) | ![Left](../images/Offset5,1.png) |
| (1,0) | ![Left](../images/Offset1,0.png) |
| (1,0.5) | ![Left](../images/Offset1,5.png) |
| (1,1) | ![Left](../images/Offset1,1.png) |

>**Note:**
>* Type of the offset property for node’s shape annotation is NodeAnnotationOffset.
>* Type of the offset property for connector’s path annotation is double.

## Horizontal and vertical alignment

* The [`HorizontalAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html#Syncfusion_Blazor_Diagrams_DiagramNodeAnnotation_HorizontalAlignment) property of annotation is used to set how the annotation is horizontally aligned at the annotation position determined from the fraction values.
* The [`VerticalAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html#Syncfusion_Blazor_Diagrams_DiagramNodeAnnotation_VerticalAlignment) property is used to set how the annotation is vertically aligned at the annotation position.

The following table shows all the possible alignments visually with 'offset (0, 0)'.

| Horizontal Alignment | Vertical Alignment | Output with Offset(0,0) |
| -------- | -------- | -------- |
| Left | Top | ![Left Top Label Alignment](../images/Label1.png) |
| Center | Top | ![Center Top Label Alignment](../images/Label2.png) |
| Right | Top |  ![Right Top Label Alignment](../images/Label3.png) |
| Left | Center | ![Left Center Label Alignment](../images/Label4.png) |
| Center | Center| ![Center Center Label Alignment](../images/Label5.png) |
| Right | Center | ![Right Center Label Alignment](../images/Label6.png) |
| Left | Bottom | ![Left Bottom Label Alignment](../images/Label7.png) |
| Center | Bottom | ![Center Bottom Label Alignment](../images/Label8.png) |
| Right |Bottom |![Right Bottom Label Alignment](../images/Label9.png) |

The following code explains how to align annotations.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code
{
    //Defines diagram's node collection
    public ObservableCollection<DiagramNode> NodeCollection { get; set; }

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node1 = new DiagramNode()
        {
            Id = "node1",
            Width = 100,
            Height = 100,
            OffsetX = 250,
            OffsetY = 250,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>() {
                new DiagramNodeAnnotation() { Content = "Annotation", HorizontalAlignment = HorizontalAlignment.Left,VerticalAlignment = VerticalAlignment.Center}
            },

            Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
        };
        NodeCollection.Add(node1);

    }
}

```

>**Note:**
>* The value of the `HorizontalAlignment` is `Center` by default.
>* The value of the `VerticalAlignment` is `Center` by default.
>* Alignment positioned based on the offset value.

## Margin

[`Margin`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNodeAnnotation.html#Syncfusion_Blazor_Diagrams_DiagramNodeAnnotation_Margin) is an absolute value used to add some blank space to any one of its four sides. The annotations can be displaced with the margin property. The following code example explains how to align an annotation based on its Offset, HorizontalAlignment, VerticalAlignment, and Margin values.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code
{
    //Defines diagram's node collection
    public ObservableCollection<DiagramNode> NodeCollection { get; set; }

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node1 = new DiagramNode()
        {
            Id = "node1",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            // Sets the margin for the content
            Annotations = new ObservableCollection<DiagramNodeAnnotation>() {
                new DiagramNodeAnnotation() { Content = "Task1", Margin = new NodeAnnotationMargin(){ Top = 10},
                    HorizontalAlignment = HorizontalAlignment.Center,VerticalAlignment = VerticalAlignment.Top,Offset = new NodeAnnotationOffset(){ X = .5 ,Y = 1} }
            },

            Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
        };
        NodeCollection.Add(node1);

    }
}

```

## Text align

The [`TextAlign`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.AnnotationStyle.html#Syncfusion_Blazor_Diagrams_AnnotationStyle_TextAlign) property of annotation allows you to set how the text should be aligned (Left, Right, Center, or Justify) inside the text block. The following code explains how to set TextAlign for an annotation.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code
{
    //Defines diagram's node collection
    public ObservableCollection<DiagramNode> NodeCollection { get; set; }

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node1 = new DiagramNode()
        {
            Id = "node1",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            // Sets the textAlign as left for the content
            Annotations = new ObservableCollection<DiagramNodeAnnotation>() {
                new DiagramNodeAnnotation() { Content = "Text align is set as Left",Style = new AnnotationStyle(){ TextAlign = TextAlign.Left} }
            },

            Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
        };
        NodeCollection.Add(node1);

    }
}

```

## See also

* [`How to add annotation for Connector`](./connector-annotation)

* [`How to add or remove annotation constraints`](../constraints/#annotation-constraints)

* [`How to customize the annotation`](./appearance)

* [`How to interact the annotation at runtime`](./interaction)