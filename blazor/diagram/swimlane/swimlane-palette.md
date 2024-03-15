---
layout: post
title: Swimlane-Palette in Blazor Diagram Component | Syncfusion
description: Learn here all about Swimlane-Palette support in Syncfusion Blazor Diagram component, its elements and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Swimlane-Palette in Blazor Diagram Component
  Diagram provides support to add lanes and phases to the symbol palette. 

## Add lanes and phases into symbol palette

Swimlane elements such as `Lane`, and `Phase` can be used to visualize the Symbol.

The following code sample shows how to add the lanes and phases to palette.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.SymbolPalette

<div class="control-section">
    <div style="width:20%;">
        <div id="palette-space" class="sb-mobile-palette" style="border: 2px solid #b200ff">
            <SfSymbolPaletteComponent @ref="@symbolpalette" Height="300px" Width="200px"
                                      Palettes="@Palettes" SymbolHeight="60" SymbolWidth="60" SymbolMargin="@SymbolMargin">
            </SfSymbolPaletteComponent>
        </div>
    </div>
</div>

@code
{
    //Reference the symbolpreview.
    DiagramSize SymbolPreview;
    //Define symbol margin.
    SymbolMargin SymbolMargin = new SymbolMargin { Left = 15, Right = 15, Top = 15, Bottom = 15 };

    SfSymbolPaletteComponent symbolpalette;

    //Define palattes collection.
    DiagramObjectCollection<Palette> Palettes = new DiagramObjectCollection<Palette>();

    // Defines palette's swimlane-shape collection.
    DiagramObjectCollection<NodeBase> SwimlaneNodes = new DiagramObjectCollection<NodeBase>();

    protected override void OnInitialized()
    {
        InitPaletteModel();
    }

    private void InitPaletteModel()
    {
        Palettes = new DiagramObjectCollection<Palette>();

        SwimlaneNodes = new DiagramObjectCollection<NodeBase>();

        //create a horizontal lane.
        Lane horizontalLane = new Lane()
            {
                ID = "HorizontalSwimlane",
                Orientation = Orientation.Horizontal,
                Height = 100,
                Width = 150,
                // Style = new TextStyle() { Fill = "orange", StrokeColor = "black" },
                Header = new SwimlaneHeader()
                {
                    Annotation = new ShapeAnnotation() { Content = "Lane Title" },
                    Style = new TextStyle() { Fill = "lightblue", StrokeColor = "black" },
                    Width = 25,
                    Height = 100
                },
            };

        //create a vertical lane.
        Lane verticalLane = new Lane()
            {
                ID = "VerticalSwimlane",
                Orientation = Orientation.Vertical,
                Height = 150,
                Width = 100,
                // Style = new TextStyle() { Fill = "orange", StrokeColor = "black" },
                Header = new SwimlaneHeader()
                {
                    Annotation = new ShapeAnnotation() { Content = "Lane Title" },
                    Style = new TextStyle() { Fill = "lightblue", StrokeColor = "black" },
                    Width = 100,
                    Height = 25
                },
            };

        //create a horizontal phase.
        Phase horizontalPhase = new Phase() { ID = "HorizontalPhase", Orientation = Orientation.Horizontal, Width = 80, Height = 1, Style = new ShapeStyle() { Fill = "#5b9bd5", StrokeColor = "#5b9bd5" } };

        //create a vertical phase.
        Phase verticalPhase = new Phase() { ID = "VerticalPhase", Orientation = Orientation.Vertical, Width = 1, Height = 80, Style = new ShapeStyle() { Fill = "#5b9bd5", StrokeColor = "#5b9bd5" } };

        SwimlaneNodes = new DiagramObjectCollection<NodeBase>()
        {
            horizontalLane,
            verticalLane,
            horizontalPhase,
            verticalPhase
        };

        Palettes = new DiagramObjectCollection<Palette>()
        {
            new Palette(){Symbols =SwimlaneNodes,Title="Swimlane Shapes",ID="SwimlaneShapes" },
        };
      }
}
```

![Swimlane SymbolPalette Shapes](Swimlane-images/Swimlane_SymbolPalette.PNG)

You can download a complete working sample from [GitHub]()


## Interactions

* The drag and drop support for swimlane shapes have been provided.
* When you drag and drop the lane shape, if the diagram already contains swimlane with the same orientation, the lane will be added and stacked inside a swimlane based on the order. Otherwise, it will be added as a new swimlane.
* The phase will only drop on the swimlane shape with the same orientation.
The following image shows how to drag symbol from palette.

![Drag Symbol from Palette](Swimlane-images/Symbol_palette.gif)
