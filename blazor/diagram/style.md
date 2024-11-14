---
layout: post
title: Style in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Style in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Style in Blazor Diagram Component

## How to customize the connector endpoint handle

To customize the visual appearance of the connector endpoint handle in a diagram, apply the following CSS code:

```cshtml
<style>
    .e-diagram-endpoint-handle {
        fill: red;
        stroke: green;
    }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Connector Endpoint Handle in Blazor Diagram](images/connector-endpoint.png)

## How to customize the connector endpoint handle when it is connected

To enhance the visual appearance of the connector endpoint handle when it is in a connected state, apply the following CSS code:

```cshtml
<style>
    .e-diagram-endpoint-handle.e-connected {
    fill: red;
    stroke: green;
   }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Connector Endpoint Connected in Blazor Diagram](images/Connector-Endpoint-Connected.gif)

## How to customize the connector endpoint handle when it disable

To customize the visual appearance of the connector endpoint handle when it is in a disabled state, apply the following CSS code to your Blazor application:

```cshtml
<style>
   .e-diagram-endpoint-handle.e-disabled {
    fill: red;
    opacity: 1;
    stroke: green;
   }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Connector Endpoint Disable in Blazor Diagram](images/Connector-Endpoint-Disable.png)

## How to customize the bezier connector handle

To customize the appearance of the Bezier connector handle, apply the following CSS code to your Blazor application:

```cshtml
<style>
  .e-diagram-bezier-handle {
    fill: red;
    stroke: green;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Bezier Connector in Blazor Diagram](images/BezierConnector.png)

## How to customize the bezier connector line

To customize the appearance of the Bezier connector line, apply the following CSS code to your Blazor diagram:

```cshtml
<style>
 .e-diagram-bezier-line {
  stroke: red;
}
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Bezier Connector Line in  Blazor Diagram](images/Connector-Bezier-Line.png)

## How to customize the resize handle

To customize the appearance of the resize handle, apply the following CSS code to your Blazor application:

```cshtml
<style>
    .e-diagram-resize-handle {
        fill: white;
        opacity: 1;
        stroke: white;
    }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Resize Handle Blazor Diagram](images/ResizeHandle.png)

## How to customize the selector pivot line

To customize the appearance of the selector pivot line, apply the following CSS properties:

```cshtml
<style>
  .e-diagram-pivot-line {
    stroke: red;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Selector Pivot Line Blazor Diagram](images/SelectorPivotLine.png)

## How to customize the selector border

To customize the appearance of the selector border, apply the following CSS styles:

```cshtml
<style>
 .e-diagram-border {
    stroke: red;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Selector Border Blazor Diagram](images/SelectorBorder.png)

## How to customize the rotate handle

To customize the appearance of the rotation handle, apply the following CSS code to your Blazor diagram:

```cshtml
<style>
.e-diagram-rotate-handle {
    fill: red;
    stroke: green;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Rotate Handle Blazor Diagram](images/RotateHandle.png)

## How to customize the symbol palette while hovering over a symbol

To customize the visual appearance of symbols in the symbol palette during mouse hover interactions, apply the following CSS code to your Blazor Diagram component:

```cshtml
<style>
.e-symbolpalette .e-symbol-hover:hover {
    background: red;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![SymbolPalette Hover in Blazor Diagram](images/SymbolPaletteHover.gif)

## How to customize the symbol palette when symbol is selected

To customize the visual appearance of the symbol palette when a symbol is selected, apply the following CSS code to enhance the user interface:

```cshtml
<style>
.e-symbolpalette .e-symbol-selected {
    background: blue;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![SymbolPalette Selected in Blazor Diagram](images/SymbolPaletteSelect.gif)

## How to customize the ruler

To customize the visual appearance of the ruler properties, apply the following CSS code to your Blazor diagram:

```cshtml
<style>
.e-diagram .e-ruler {
    background-color: red;
    font-size: 13px;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Ruler in Blazor Diagram](images/RulerCustomize.png)

## How to customize the ruler overlap

To customize the visual appearance of the ruler overlap properties, apply the following CSS code to your Blazor diagram component:

```cshtml
<style>
.e-diagram .e-ruler-overlap {
    background-color: red;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Ruler Overlap in Blazor Diagram](images/RulerOverlap.png)

## How to customize the text edit

To customize the appearance of the text edit properties, apply the following CSS code to your Blazor application:

```cshtml
<style>
 .e-diagram .e-diagram-text-edit {
    background: white;
    border-color: red;
    border-style: dashed;
    border-width: 1px;
    box-sizing: content-box;
    color: black;
    min-width: 50px;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Text Edit in Blazor Diagram](images/TextEdit.png)

## How to customize the text edit on selection

To customize the appearance of the text edit control when selected, apply the following CSS properties:

```cshtml
<style>
 .e-diagram-text-edit::selection {
    background: red;
    color: green;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Text Edit on Selection in Blazor Diagram](images/TextEditSelection.png)

## How to customize the highlighter

To customize the appearance of the highlighter, you can use the following CSS code:

```cshtml
<style>
.e-diagram-highlighter {
  stroke:red;
  stroke-width: 7;
}
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Highlighter in Blazor Diagram](images/Highlighter.gif)

## How to customize the diagram background color

To customize the background color of the diagram, apply the following CSS rule:

```cshtml
<style>
  .e-diagram {
      background-color: green;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Diagram Background color in Blazor Diagram](images/Diagram-Background.png)

## How to customize the overview resize handle

To customize the appearance of the overview resize handle, apply the following CSS code to your Blazor application:

```cshtml
<style>
    .overviewresizer
    {
          fill:blue;
    }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Overview Resize Handle in Blazor Diagram](images/OverviewResizer.png)

## How to customize the helper

To customize the appearance of the helper element, apply the following CSS rules:

```cshtml
<style>
   .e-diagram-helper {
      stroke: red;
      stroke-width: 5px;
  }

</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Helper in Blazor Diagram](images/Helper.png)

## How to customize the grid

To customize the visual appearance of the diagram grid, apply the following CSS styles:

```cshtml
<style>
     .e-diagram-thin-grid {
       stroke: red;
   }

</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Thin grid in Blazor Diagram](images/ThinGrid.png)

To customize the appearance of the thick grid lines in your diagram, apply the following CSS code:

```cshtml
<style>
     .e-diagram-thick-grid {
       stroke: red;
   }

</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Thick grid in Blazor Diagram](images/ThickGrid.png)

## How to customize the symbol palette symbols background color

To customize the background color of symbols in the symbol palette, apply the following CSS code:

```cshtml
<style>
     .e-symbol-draggable {
       stroke: red;
   }

</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![SymbolPalette in Blazor Diagram](images/SymbolPaletteSymbolContainer.png)

## How to customize the style of orthogonal segment thumb


To customize the visual appearance of the Orthogonal segment thumb, apply the following CSS code to your stylesheet:


```cshtml
<style>
     .e-diagram-ortho-segment-handle {
       stroke: red;
       stroke-width: 1px;
       fill: green;
   }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Sample/Style/OrthogonalThumbStyle)

![Segment Thumb style in Blazor Diagram](images/OrthogonalThumbStyle.png)

## How to customize the bezier and straight segment thumb 
To customize the visual appearance of Bezier and Straight connector segments, apply the following CSS code:

```cshtml
<style>
  .e-diagram-bezier-segment-handle {
    fill: red;
    stroke: green;
  }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples)

![Segment shape  in Blazor Diagram](images/SegmentStyle.png)





