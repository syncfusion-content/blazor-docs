---
layout: post
title: Events in Blazor TreeMap Component | Syncfusion
description: Check out and learn about all available events and event handling in the Syncfusion Blazor TreeMap component.
platform: Blazor
control: TreeMap
documentation: ug
---

# Events in Blazor TreeMap Component

## ItemHighlighted

Triggers after TreeMap items are highlighted.

|   Argument name      |   Description                                 |
|----------------------|-----------------------------------------------|
|   Cancel             |   Specifies the event cancel status.          |

## ItemRendering

Triggers before rendering a TreeMap item.

|   Argument name      |   Description                         |
|----------------------|---------------------------------------|
|   CurrentItem        |   Specifies the current rendering item.   |
|   Text               |   Specifies the text of the current item. |
|   Cancel             |   Specifies the event cancel status.      |

## ItemSelected

Triggers after a TreeMap item is selected.

|   Argument name      |   Description                         |
|----------------------|---------------------------------------|
|   Text               |   Specifies the text of the selected item. |
|   Cancel             |   Specifies the event cancel status. |

## LegendRendering

Triggers before rendering the TreeMap legend.

|   Argument name      |   Description                                 |
|----------------------|-----------------------------------------------|
|   Cancel             |   Specifies the event cancel status.          |

## LegendItemRendering

Triggers before rendering each legend item.

|   Argument name      |   Description                                                    |
|----------------------|------------------------------------------------------------------|
|   Fill               |   Specifies the legend shape color.                              |
|   ImageUrl           |   Specifies the image URL.                                       |
|   Shape              |   Specifies the legend shape.                                    |
|   ShapeBorder        |   Specifies the legend border color and width.                   |
|   Cancel             |   Specifies the event cancel status.                             |

## Loaded

Triggers after the TreeMap component has loaded.

|   Argument name      |   Description                                  |
|----------------------|------------------------------------------------|
|   IsResized          |   Specifies whether the component is resized.  |

## Load

Triggers before the TreeMap renders. This is the first event fired.

## OnPrint

Triggers before a print operation starts.

|   Argument name      |   Description                                 |
|----------------------|-----------------------------------------------|
|   Cancel             |   Specifies the event cancel status.          |

## OnClick

Triggers when the TreeMap is clicked.

|   Argument name      |   Description                                 |
|----------------------|-----------------------------------------------|
|   MouseEvent         |   Specifies the pointer event.          |
|   TreeMap            |   Specifies the current TreeMap instance.    |
|   Name               |   Specifies the event name.            |
|   Cancel             |   Specifies the event cancel status.          |

## OnDoubleClick

Triggers on double-click in the TreeMap.

|   Argument name      |   Description                         |
|----------------------|---------------------------------------|
|   Cancel             |   Specifies the event cancel status.       |

## DrillCompleted

Triggers when drill-down on a TreeMap item is completed.

|   Argument name      |   Description                         |
|----------------------|---------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## OnDrillStart

Triggers when drill-down starts on a TreeMap item.

|   Argument name  | Description         |
|----------------------|-----------------------------------------------------------|
|   GroupIndex         |   Specifies the index of the TreeMap item.                 |
|   GroupName          |   Specifies the parent name of the TreeMap item.            |
|   Item               |   Specifies the current drill item.                           |
|   RightClick         |   Indicates whether the action was initiated by a right-click.     |
|   Cancel             |   Specifies the event cancel status.                              |

## OnItemClick

Triggers when a TreeMap item is clicked.

|   Argument name      |   Description                                 |
|----------------------|-----------------------------------------------|
|   GroupIndex         |   Specifies the index of the TreeMap item.       |
|   GroupName          |   Specifies the parent name of the TreeMap item. |
|   Item               |   Specifies the current item on click.             |
|   Text               |   Specifies the text of the current TreeMap item.         |
|   Cancel             |   Specifies the event cancel status.             |

## OnItemMove

Triggers when the pointer moves over a TreeMap item.

|   Argument name      |   Description                         |
|----------------------|---------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## OnRightClick

Triggers on right-click in the TreeMap.

|   Argument name      |   Description                         |
|----------------------|---------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## Resizing

Triggers when resizing the TreeMap component.

|   Argument name      |   Description                          |
|----------------------|----------------------------------------|
|   CurrentSize        |   Specifies the size of the TreeMap.           |
|   PreviousSize       |   Specifies the previous size of the TreeMap.  |
|   Cancel             |   Specifies the event cancel status.        |

## TooltipRendering

Triggers before rendering the TreeMap tooltip.

|   Argument name      |   Description                         |
|----------------------|---------------------------------------|
|   Location           |   Specifies the location of the tooltip.     |
|   Text               |   Specifies the text of the tooltip.         |
|   TextStyle          |   Specifies the text style of the tooltip.   |
|   Data               |   Specifies the TreeMap item data where the tooltip is rendered.     |
|   Cancel             |   Specifies the event cancel status.   |