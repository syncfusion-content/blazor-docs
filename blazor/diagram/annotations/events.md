---
layout: post
title: Events in Blazor Diagram Component | Syncfusion 
description: Checkout and learn here all about Events in the Blazor Diagram component of Syncfusion and much more.
platform: Blazor
control: Diagram
documentation: ug
---

# Events in Blazor Diagram Component

## Text edit

The TextEdit event will notify the annotation content changes after editing. The [IBlazorTextEditEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IBlazorTextEditEventArgs.html) interface is used to get event arguments.

> A new blazor diagram component which provides better performance than the existing diagram control in Blazor WebAssembly App. It is available in preview mode.Refer the [Link](https://blazor.syncfusion.com/documentation/diagram-component/annotations/events)


The following code example shows how to register and get the notification from the TextEdit event.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    <DiagramEvents TextEdited="@TextEdited"></DiagramEvents>
</SfDiagram>

@code
{
    //Defines diagram's nodes collection
    public ObservableCollection<DiagramNode> NodeCollection { get; set; }

    //Triggered this event when complete the editing for Annotation and update the old text and new text values.
    private void TextEdited(IBlazorTextEditEventArgs args)
    {
        Console.WriteLine("Oldvalue", args.OldValue);
        Console.WriteLine("NewValue", args.NewValue);
    }
    
    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new NodeShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white"
            },
        };
        node.Annotations = new ObservableCollection<DiagramNodeAnnotation>()
        {
            new DiagramNodeAnnotation() {Content = "Annotation" }
        };
        NodeCollection.Add(node);
    }
}
```

## Double click

The DoubleClick event will notify the annotation start editing. The [IDoubleClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IBlazorDoubleClickEventArgs.html) interface is used to get the position actually clicked and clicked object.

The following code example shows how to register and get the notification from the [OnDoubleClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IBlazorDoubleClickEventArgs.html) event.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    <DiagramEvents OnDoubleClick="@OnDoubleClick" />
</SfDiagram>

@code
{
    //Defines diagram's nodes collection
    public ObservableCollection<DiagramNode> NodeCollection
    { get; set; }

    //Triggered this event when double click on the Annotation and update the position and source for clicked item.
    private void OnDoubleClick(IBlazorDoubleClickEventArgs args)
    {
        Console.WriteLine("Position", args.Position);
        Console.WriteLine("Source", args.Source);
    }

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new NodeShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white"
            },
        };
        node.Annotations = new ObservableCollection<DiagramNodeAnnotation>()
        {
            new DiagramNodeAnnotation() {Content = "Annotation" }
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
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    <DiagramEvents OnKeyDown="@OnKeyDown" OnKeyUp="@OnKeyUp"></DiagramEvents>
</SfDiagram>

@code
{
    //Defines diagram's nodes collection
    public ObservableCollection<DiagramNode> NodeCollection
    { get; set; }

    //Occurs when  click the annotation and enter the character in key down state
    private void OnKeyDown(IKeyEventArgs args)
    {

    }

    //Occurs when click the annotation and enter the character in key release state
    private void OnKeyUp(IKeyEventArgs args)
    {

    }

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new NodeShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white"
            },
        };
        node.Annotations = new ObservableCollection<DiagramNodeAnnotation>()
        {
            new DiagramNodeAnnotation() {Content = "Annotation" }
        };
        NodeCollection.Add(node);
    }
}
```

## See also

* [How to add or remove annotation constraints](../constraints/#annotation-constraints)

* [How to customize the annotation](./appearance)

* [How to interact the annotation at runtime](./interaction)

* [How to add annotation for Node](./node-annotation)

* [How to add annotation for Connector](./connector-annotation)
