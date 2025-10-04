---
layout: post
title: Annotation Events in Blazor Diagram Component | Syncfusion
description: Checkout and Learn how to use annotation events in the Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Annotation Events in Blazor Diagram Component

## How to Handle Text Change Event

* While editing a node's or connector's annotation, the following event can be used to do the customization.
* When a node's or connector's annotation is changed in the diagram, this event is getting triggered. 

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|[TextChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_TextChanged)|[TextChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextChangeEventArgs.html)|Triggers after a node or connector's annotation text has been changed in the diagram.|
|[TextChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_TextChanging)|[TextChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextChangeEventArgs.html)|An event that is raised when the node and connector's annotation text is changing in the diagram.|

The following code example shows how to register and get notifications from the `TextChanged` and `TextChanging` events.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent TextChanging="@OnLabelTextChanging" Height="600px" TextChanged="OnTextChanged" Nodes="@nodes" />

@code
{
    // Defines diagram's nodes collection.
    DiagramObjectCollection<Node> nodes;
    // Triggered when the node and connector's labels change in the diagram.
   private void OnLabelTextChanging(TextChangeEventArgs args)
   {
      args.Cancel = true;
   }
    // Triggered this event when complete the editing for Annotation and update the old text and new text values.
    private void OnTextChanged(TextChangeEventArgs args)
    {
        Console.WriteLine("OldValue", args.OldValue);
        Console.WriteLine("NewValue", args.NewValue);
    }

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
            new ShapeAnnotation { Content = "Annotation" }
        };
        nodes.Add(node);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Events/TextChangedEvent)

## See also

* [How to add or remove annotation constraints](../constraints#annotation-constraints)

* [How to customize the annotation](./appearance)

* [How to add an annotation for a Node](./node-annotation)

* [How to add an annotation for a Connector](./connector-annotation)
