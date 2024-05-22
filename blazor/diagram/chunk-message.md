---
layout: post
title: Chunk message in the Blazor Diagram Component | Syncfusion
description: Checkout and learn  all about Chunk message in the Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Chunk message in Blazor Diagram Component

The diagram sends large data split into small chunks to the server. Chunk messages enable the measurement of path, image, text, and SVG data without exceeding the maximum size of a single incoming hub message (MaximumReceiveMessageSize of 32KB). By default, the [EnableChunkMessage] property is set to false.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" EnableChunkMessage="true"/>

@code
{
    //Initialize the Nodes Collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        int offsetX = 100; int offsetY = 100; double count = 1;
        for(int i=1; i<=200; i++)
        {
            Node node = new Node()
                {
                    ID = "node" + i,
                    OffsetX = count * offsetX,
                    OffsetY = offsetY,
                    Width = 100,
                    Height = 100,
                    Annotations = new DiagramObjectCollection<ShapeAnnotation>() {
                        new ShapeAnnotation() { Content = "Annotation for the Node" + i.ToString() }
                    }
                };
                count += 1.5;
                if (i % 5 == 0)
                {
                    count = 1;
                    offsetX = 100;
                    offsetY = offsetY + 200;
                }
            nodes.Add(node);
        }
    }
}
```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/)