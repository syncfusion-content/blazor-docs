---
layout: post
title: Shapes in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about the Shapes in the Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram
documentation: ug
---

N> Syncfusion recommends using [Blazor Diagram Component](https://blazor.syncfusion.com/documentation/diagram/getting-started) which provides better performance than this diagram control. Blazor Diagram Component will be actively developed in the future.

# Shapes in Blazor Diagram Component

Diagram provides support to add different kind of nodes. They are as follows:

* Text node
* Image node
* HTML node
* Path node
* Basic shapes
* Flow shapes

<!-- markdownlint-disable MD033 -->
<!-- markdownlint-disable MD010 -->

## Text

Texts can be added to the diagram as [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNode.html#Syncfusion_Blazor_Diagrams_DiagramNode_Shape) nodes. The shape property of the node allows you to set the type of node and for text nodes, it should be set as **text**. In addition, define the content object that is used to define the text to be added and style is used to customize the appearance of that text. The following code illustrates how to create a text node.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code{
    //Initialize node collection with node.
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
     {
        //Creates a text node.
        new DiagramNode()
        {
            Id="node1",
            // Size of the node.
            Height=100,
            Width=100,
            // Position of the node.
            OffsetX=100,
            OffsetY=100,
            //Sets type of the shape as text.
            Shape=new DiagramShape(){Type=Shapes.Text,Content="Text Node"}
        }
     };
}
```

![Text node](images/Textnode.png)

## Image

Diagram allows to add images as [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNode.html#Syncfusion_Blazor_Diagrams_DiagramNode_Shape) nodes. The shape property of node allows you to set the type of node and for image nodes, it should be set as **image**. In addition, the source property of shape enables you to set the image source.

The following code illustrates how an image node is created.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection" />

@code{
    //Initialize node collection with node.
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
    {
        //Creates a image node.
        new DiagramNode()
        {
            Id="node1",
            //Size of the node.
            Height=100,
            Width=100,
            //Position of the node.
            OffsetX=100,
            OffsetY=100,
            //Sets type of the shape as image.
            Shape=new DiagramShape(){Type=Shapes.Image,Source="/diagram/images/syncfusion.png"}
        }
    };
}
```

![Image node](images/Imagenode.png)

**Base64 Encoded Image Into The Image Node:**

The following code illustrates how to add Base64 image into image node.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection"/>

@code{
    //Initialize node collection with node.
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
    {
         //Creates a image node.
         new DiagramNode()
         {
             Id="node1",
             //Size of the node.
             Height=100,
             Width=100,
             //Position of the node.
             OffsetX=100,
             OffsetY=100,
             //Sets type of the shape as image.
             Shape=new DiagramShape(){Type=Shapes.Image,Source="data:image/gif;base64,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"}
         }
    };
}
```

![Image node](images/base64.jpg)

N> Deploy your HTML file in the web application and export the diagram (image node) or else the image node will not be exported in the Chrome and Firefox due to security issues. Refer to the following link.

Link 1: [https://stackoverflow.com/questions/4761711/local-image-in-canvas-in-chrome](https://stackoverflow.com/questions/4761711/local-image-in-canvas-in-chrome)

## Image alignment

Stretch and align the image content anywhere but within the node boundary.

The scale property of the node allows to stretch the image as you desired (either to maintain proportion or to stretch). By default, the [Scale](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramShape.html#Syncfusion_Blazor_Diagrams_DiagramShape_Scale) property of the node is set as meet. The following code illustrates how to scale or stretch the content of the image node.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection" />

@code{
    //Initialize node collection with node.
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
    {
        //Creates a image node.
        new DiagramNode()
        {
            Id="node1",
            //Size of the node.
            Height=100,
            Width=100,
            //Position of the node.
            OffsetX=100,
            OffsetY=100,
            //Sets type of the shape as image.
            Shape=new DiagramShape(){Type=Shapes.Image,Source="/diagram/images/syncfusion.png",Scale=Stretch.Meet, Align = ImageAlignment.XMinYMin}
        }
    };
}
```

The following table illustrates all the possible scale options for the image node.

| Values | Images |
|-------- | -------- |
| None | ![None Alignment](images/Image1.png) |
| Meet |![Meet Alignment](images/Image2.png) |
| Slice |![Slice Alignment](images/Image3.png) |
| Stretch |![Stretch Alignment](images/Image4.png) |

## HTML

Html elements can be embedded in the diagram through `Html` type node. The shape property of node allows you to set the type of node and to create a HTML node it should be set as `HTML`. The following code illustrates how an Html node is created.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Add a Namespace for a Syncfusion control used in Diagram HTML node *@
@using Syncfusion.Blazor.Inputs

@* Initialize Diagram with node template *@
<SfDiagram ModelType="@model" Height="600px" Nodes="@NodeCollection">
    <DiagramTemplates>
        <NodeTemplate>
            @{
                <SfTextBox Placeholder="My text"></SfTextBox>
            }
        </NodeTemplate>
    </DiagramTemplates>
</SfDiagram>

@code{
    public Type model = typeof(Node);
    public class Node
    {
        public string Id { get; set; }
        public double Width { get; set; }
    }

    //Initialize node collection with node.
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
    {
        //Creates an HTML node
        new DiagramNode()
        {
            Id="node1",
            //Size of the node.
            Height=100,
            Width=100,
            //Position of the node.
            OffsetX=400,
            OffsetY=100,
            //Sets the type of the shape as HTML.
            Shape=new DiagramShape()
            {
                Type=Shapes.HTML,
            }
        }
    };
}
```

![HTML node](images/Htmlnode.png)

N> HTML node cannot be exported to image format, like JPEG, PNG and BMP. It is by design, while exporting the diagram is drawn in a canvas. Further, this canvas is exported into image formats. Currently, drawing in a canvas equivalent from all possible HTML is not feasible. Hence, this limitation.

## Basic shapes

* The [Basic](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNode.html#Syncfusion_Blazor_Diagrams_DiagramNode_Shape) shapes are common shapes that are used to represent the geometrical information visually. To create basic shapes, the type of the shape should be set as **basic**. Its shape property can be set with any one of the built-in shapes.

* To render a rounded rectangle, you need to set the type as basic and shape as rectangle. Set the [CornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramShape.html#Syncfusion_Blazor_Diagrams_DiagramShape_CornerRadius) property to specify the radius of rounded rectangle.

The following code example illustrates how to create a basic shape.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection" />

@code{
    //Initialize node collection with node.
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
    {
        //Creates a basic shape node.
        new DiagramNode()
        {
            Id="node1",
            //Size of the node.
            Height=100,
            Width=100,
            //Position of the node.
            OffsetX=100,
            OffsetY=100,
            //Sets the type of the shape as basic.
            Shape=new DiagramShape(){Type=Shapes.Basic,BasicShape=BasicShapes.Rectangle}
        }
    };
}
```

N> By default, the `Shape` property of the node is set as **basic**.

Default property for shape is Rectangle.

N> When the `Shape` is not set for a basic shape, it is considered as a **rectangle**.

The list of basic shapes are as follows.

![BasicShapes](images/Basic.png)

## Path

The [Path](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNode.html#Syncfusion_Blazor_Diagrams_DiagramNode_Shape) node is a commonly used basic shape that allows visually to represent the geometrical information. To create a path node, specify the shape as **path**. The path property of node allows you to define the path to be drawn. The following code illustrates how a path node is created.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection" />

@code{
    //Initialize node collection with node.
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
    {
        // Creates a path node.
        new DiagramNode()
        {
            Id="node1",
            //Size of the node.
            Height=100,
            Width=100,
            //Position of the node.
            OffsetX=100,
            OffsetY=100,
            //Sets the type of the shape as path.
            Shape=new DiagramShape()
            {
                Type=Shapes.Path,
                Data="M35.2441,25 L22.7161,49.9937 L22.7161,0.00657536 L35.2441,25 z M22.7167,25 L-0.00131226,25 M35.2441,49.6337 L35.2441,0.368951 M35.2441,25 L49.9981,25"
            }
        }
    };
}
```

## Flow Shapes

The [Flow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramNode.html#Syncfusion_Blazor_Diagrams_DiagramNode_Shape) shapes are used to represent the process flow. It is used for analyzing, designing and managing for documentation process. To create a flow shape, specify the shape type as **flow**. Flow shapes and by default, it is considered as **process**. The following code example illustrates how to create a flow shape.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection" />

@code{
    //Initialize node collection with node.
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
    {
        //Creates a flow shape node.
        new DiagramNode()
        {
            Id="node1",
            //Size of the node.
            Height=100,
            Width=100,
            //Position of the node.
            OffsetX=100,
            OffsetY=100,
            //Sets the type of the shape as flow.
            Shape=new DiagramShape()
            {
                Type=Shapes.Flow,
                FlowShape=FlowShapes.DirectData
            }
        }
    };
}
```

The list of flow shapes are as follows.

![FlowShapes](images/FlowShapes.png)