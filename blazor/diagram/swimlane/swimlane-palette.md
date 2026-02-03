---
layout: post
title: Swimlane-Palette in Blazor Diagram Component | Syncfusion
description: Learn here all about Swimlane-Palette support in Syncfusion Blazor Diagram component, its elements and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Swimlane-Palette in Blazor Diagram Component
Diagram supports adding lanes and phases to the symbol palette. 

## How to Add Lanes and Phases to the Symbol Palette

Swimlane elements such as [Lane](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Lane.html) and [Phase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Phase.html) can be used to visualize the symbols.

The following code shows how to add lanes and phases to a palette.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.SymbolPalette

<div class="control-section">
    <div style="width:200px; height: 300px;">
        <div id="palette-space" class="sb-mobile-palette" style="border: 2px solid #b200ff">
            <SfSymbolPaletteComponent @ref="_symbolPalette" Height="300px" Width="200px"
                                      Palettes="@_palettes" SymbolHeight="60" SymbolWidth="60" SymbolMargin="@_symbolMargin">
            </SfSymbolPaletteComponent>
        </div>
    </div>
</div>

<AddNodeToPalette />

@code
{
    // Reference the symbol preview
    private DiagramSize _symbolPreview;
    // Define symbol margin
    private SymbolMargin _symbolMargin = new SymbolMargin { Left = 15, Right = 15, Top = 15, Bottom = 15 };
    private SfSymbolPaletteComponent _symbolPalette;
    // Define palettes collection
    private DiagramObjectCollection<Palette> _palettes = new DiagramObjectCollection<Palette>();
    // Defines palette's swimlane-shape collection
    private DiagramObjectCollection<NodeBase> _swimlaneNodes = new DiagramObjectCollection<NodeBase>();

    protected override void OnInitialized()
    {
        InitPaletteModel();
    }

    private void InitPaletteModel()
    {
        _palettes = new DiagramObjectCollection<Palette>();

        _swimlaneNodes = new DiagramObjectCollection<NodeBase>();
        //horizontal lane
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

        //vertical lane
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

        //horizontal phase
        Phase horizontalPhase = new Phase() { ID = "HorizontalPhase", Orientation = Orientation.Horizontal, Width = 80, Height = 1, Style = new ShapeStyle() { Fill = "#5b9bd5", StrokeColor = "#5b9bd5" } };

        //vertical phase
        Phase verticalPhase = new Phase() { ID = "VerticalPhase", Orientation = Orientation.Vertical, Width = 1, Height = 80, Style = new ShapeStyle() { Fill = "#5b9bd5", StrokeColor = "#5b9bd5" } };

        _swimlaneNodes = new DiagramObjectCollection<NodeBase>()
        {
            horizontalLane,
            verticalLane,
            horizontalPhase,
            verticalPhase
        };

        _palettes = new DiagramObjectCollection<Palette>()
        {
            new Palette() { Symbols = _swimlaneNodes, Title = "Swimlane Shapes", ID = "SwimlaneShapes" },
        };
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVeWZXcKcyuCrTl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Swimlanes/SwimlanePalette/SwimlanePalette.razor)

![Swimlane SymbolPalette Shapes](Swimlane-images/Swimlane_SymbolPalette.PNG)

## How to Drag and Drop Swimlane Shapes from the Symbol Palette

* Drag-and-drop is supported for swimlane symbols.
* When a lane symbol is dropped, if the diagram already contains a swimlane with the same orientation, the lane is added and stacked inside the swimlane based on order. Otherwise, a new swimlane is created.
* A phase will only drop on a swimlane shape with the same orientation.

The following image shows dragging a symbol from the palette.

![Drag Symbol from Palette](Swimlane-images/Symbol_palette.gif)
