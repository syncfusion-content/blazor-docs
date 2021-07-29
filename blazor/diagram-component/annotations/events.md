---
layout: post
title: Events in Blazor Diagram Component | Syncfusion
description: Learn here all about Events in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram
documentation: ug
---

# Events in Blazor Diagram Component

## Text edit

The TextEdit event will notify the annotation content changes after editing. The `TextEditEventArgs` interface is used to get event arguments.

The following code example shows how to register and get the notification from the TextEdit event.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" TextEdit="textedit"  Nodes="@NodeCollection">
</SfDiagramComponent>

@code
{
   //Defines diagram's nodes collection
    DiagramObjectCollection<Node> NodeCollection = new DiagramObjectCollection<Node>();

   //Triggered this event when complete the editing for Annotation and update the old text and new text values.
   private void textedit(TextEditEventArgs args)
    {
        Console.WriteLine("Oldvalue", args.OldValue);
        Console.WriteLine("NewValue", args.NewValue);
    }
    protected override void OnInitialized()
    {
        NodeCollection = new DiagramObjectCollection<Node>();
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
            new ShapeAnnotation {Content = "Annotation" }
        };
        NodeCollection.Add(node);
    }
}

```

## Key down

The keydown event occurs when a keyboard key is pressed down and updated the respective keyboard key pressed.

## Key up

The keyup event occurs when a keyboard key is released and updated the respective keyboard key pressed.

The following code example shows how to register and get the notification from the onkeydown and onkeyup events.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" KeyDown ="@OnKeyDown" KeyUp="@OnKeyUp" Nodes="@NodeCollection" >
</SfDiagramComponent>

@code
{
    //Defines diagram's nodes collection
   DiagramObjectCollection<Node> NodeCollection = new DiagramObjectCollection<Node>();

   //Occurs when  click the annotation and enter the character in key down state
    private void OnKeyDown(KeyEventArgs args)
    {

    }
    //Occurs when click the annotation and enter the character in key release state
    private void OnKeyUp(KeyEventArgs args)
    {

    }
    protected override void OnInitialized()
    {
        NodeCollection = new DiagramObjectCollection<Node>();
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
            new ShapeAnnotation {Content = "Annotation" }
        };
        NodeCollection.Add(node);
    }
}}

```

## See also

* [`How to add or remove annotation constraints`](../constraints/#annotation-constraints)

* [`How to customize the annotation`](./appearance)

* [`How to add annotation for Node`](./node-annotation)

* [`How to add annotation for Connector`](./connector-annotation)
