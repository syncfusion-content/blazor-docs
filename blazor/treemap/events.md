---
layout: post
title: Blazor TreeMap Events | Syncfusion®
description: Learn how to handle Blazor TreeMap events including Load, Loaded, Resizing, ItemRendering, ItemSelected, drill-down actions, clicks, and tooltip customization.
platform: Blazor
control: TreeMap
documentation: ug
---

# Blazor TreeMap Events

The Blazor TreeMap component raises events during its lifecycle, item interaction, drill-down, legend rendering, and tooltip rendering. This topic lists the available events, their trigger conditions, and the arguments each event provides.

## Load

Triggers before rendering the TreeMap. This is the first event raised by the component.

## Loaded

Triggers after the TreeMap component has been loaded.

|   Argument name      |   Description                                                    |
|----------------------| -----------------------------------------------------------------|
|   IsResized               |   Specifies whether the component is resized or not.                               |

## Resizing

Triggers when resizing the TreeMap component.

|   Argument name      |   Description                          |
|----------------------| ---------------------------------------|
|   CurrentSize        |   Specifies the current size of the TreeMap.           |
|   PreviousSize       |   Specifies the previous size of the TreeMap.  |
|   Cancel             |   Specifies the event cancel status.        |

## ItemRendering

Triggers before rendering an item of the TreeMap.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   CurrentItem        |   Specifies the current rendering item.   |
|   Text               |   Specifies the text of the current item. |
|   Cancel             |   Specifies the event cancel status.      |

## ItemHighlighted

Triggers after highlighting the TreeMap items.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   Cancel             |   Specifies the event cancel status.          |

## ItemSelected

Triggers after selecting the TreeMap item.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Text               |   Specifies the text of the selected item.    |
|   Cancel             |   Specifies the event cancel status.           |

## OnClick

Triggers when clicking on the TreeMap.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   MouseEvent         |   Specifies the pointer mouse event.             |
|   TreeMap            |   Specifies the current TreeMap instance.        |
|   Name               |   Specifies the name of the event.                 |
|   Cancel             |   Specifies the event cancel status.               |

## OnDoubleClick

Triggers when double-clicking on the TreeMap.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## OnItemClick

Triggers when clicking on a TreeMap item.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   GroupIndex         |   Specifies the index of the TreeMap item.       |
|   GroupName          |   Specifies the parent name of the TreeMap item. |
|   Item               |   Specifies the current item on click.             |
|   Text               |   Specifies the text of the current TreeMap item.         |
|   Cancel             |   Specifies the event cancel status.             |

## OnItemMove

Triggers when the mouse moves on a TreeMap item.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## OnRightClick

Triggers when performing a right-click on the TreeMap.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## OnDrillStart

Triggers before the drill-down operation starts on a TreeMap item.

|   Argument name  |   Description                                                     |
|----------------------| ------------------------------------------------------------------|
|   GroupIndex         |   Specifies the index of the TreeMap item.                 |
|   GroupName          |   Specifies the parent name of the TreeMap item.            |
|   Item               |   Specifies the current drill item.                           |
|   RightClick         |   Specifies a boolean value indicating whether the click is a right-click.     |
|   Cancel             |   Specifies the event cancel status.                              |

## DrillCompleted

Triggers after the drill-down operation completes on a TreeMap item.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## LegendItemRendering

Triggers before rendering each legend item.

|   Argument name      |   Description                                                    |
|----------------------| -----------------------------------------------------------------|
|   Fill               |   Specifies the legend shape color.                               |
|   ImageUrl           |   Specifies the image URL.                                        |
|   Shape              |   Specifies the legend shape.                     |
|   ShapeBorder        |   Specifies the legend border color and width.                     |
|   Cancel             |   Specifies the event cancel status.                      |

## LegendRendering

Triggers before rendering the TreeMap legend.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   Cancel             |   Specifies the event cancel status.          |

## TooltipRendering

Triggers before rendering the TreeMap tooltip.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Location           |   Specifies the location of the tooltip.     |
|   Text               |   Specifies the text of the tooltip.         |
|   TextStyle          |   Specifies the text style of the tooltip.   |
|   Data               |   Specifies the TreeMap item data, where the tooltip is to be rendered.       |
|   Cancel             |   Specifies the event cancel status.   |

## OnPrint

Triggers before the print operation starts.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   Cancel             |   Specifies the event cancel status.              |


N> The exact event-argument type for each event is available in the [Syncfusion.Blazor.TreeMap API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.html). Use the matching `EventArgs` type in the handler signature.

## See also

* [Selection and highlight](selection-and-highlight.md)
* [Tooltip](tooltip.md)
* [Drill-down](drill-down.md)
* [Print and export](print-and-export.md)