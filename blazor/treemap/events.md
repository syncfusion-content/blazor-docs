---
layout: post
title: Events in the Blazor TreeMap component | Syncfusion
description: Learn here all about the Events of Syncfusion TreeMap (SfTreeMap) component and more.
platform: Blazor
control: TreeMap
documentation: ug
---

# Events in the Blazor TreeMap (SfTreeMap)

## ItemHighlighted

Triggers, after highlighting the TreeMap items.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   Cancel             |   Specifies the event cancel status.          |

## ItemRendering

Triggers, before rendering the item of the TreeMap.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   CurrentItem        |   Specifies the current rendering item.   |
|   Text               |   Specifies the text of the current item. |
|   Cancel             |   Specifies the event cancel status.      |

## ItemSelected

Triggers, after selecting the TreeMap item.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Text               |   Specifies the text of the selected item.                |
|   Cancel             |   Specifies the event cancel status.               |

## LegendRendering

Triggers, before rendering the TreeMap legend.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   Cancel             |   Specifies the event cancel status.          |

## LegendItemRendering

Triggers, before rendering each of the legend item.

|   Argument name      |   Description                                                    |
|----------------------| -----------------------------------------------------------------|
|   Fill               |   Specifies the legend shape color.                               |
|   ImageUrl           |   Specifies the image url.                                        |
|   Shape              |   Specifies the legend shape.                     |
|   ShapeBorder              |   Specifies the legend border color and width.                     |
|   Cancel             |   Specifies the event cancel status        .                      |

## Loaded

Triggers, after the TreeMap component has been loaded.

|   Argument name      |   Description                                                    |
|----------------------| -----------------------------------------------------------------|
|   IsResized               |   Specifies whether the component is resized or not.                               |

## Load

Triggers, before rendering the TreeMap. TreeMap will trigger this event first.

## OnPrint

Triggers, before the print operation gets started.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   Cancel             |   Specifies the event cancel status.              |

## OnClick

Description: Triggers, when clicking on the treemap.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   MouseEvent         |   Specifies the pointer mouse event.             |
|   TreeMap            |   Specifies the current treemap instances.        |
|   Name               |   Specifies the name of the event.                 |
|   Cancel             |   Specifies the event cancel status.               |

## OnDoubleClick

Triggers, when double clicking on the treemap.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Cancel             |   Specifies the event cancel status.       |

## DrillCompleted

Triggers, when drilling down functionality gets completed on the TreeMap item.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## OnDrillStart

Triggers, when drilling down functionality gets started on the TreeMap item.

|   Argument name  | Description         |
|----------------------| ----------------------------------------------------------|
|   GroupIndex         |   Specifies the index of the TreeMap item.                 |
|   GroupName          |   Specifies the parent name of the TreeMap item.            |
|   Item               |   Specifies the current drill item.                           |
|   RightClick         |   Return the boolean value whether it is right or not.     |
|   Cancel             |   Specifies the event cancel status.                              |

## OnItemClick

Triggers, when clicking on the TreeMap item.

|   Argument name      |   Description                                 |
|----------------------| ----------------------------------------------|
|   GroupIndex         |   Specifies the index of the TreeMap item       |
|   GroupName          |   Specifies the parent name of the TreeMap item. |
|   Item               |   Specifies the current item on click.             |
|   Text               |   Specifies the text of the current TreeMap item.         |
|   Cancel             |   Specifies the event cancel status.             |

## OnItemMove

Triggers, when mouse moves on the TreeMap item.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## OnRightClick

Triggers, when right-clicked on the TreeMap.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Cancel             |   Specifies the event cancel status.      |

## Resizing

Triggers, when resizing the TreeMap component.

|   Argument name      |   Description                          |
|----------------------| ---------------------------------------|
|   CurrentSize        |   Specifies the size of the TreeMap.           |
|   PreviousSize       |   Specifies the previous size of the TreeMap.  |
|   Cancel             |   Specifies the event cancel status.        |

## TooltipRendering

Triggers, before rendering the TreeMap tooltip.

|   Argument name      |   Description                         |
|----------------------| --------------------------------------|
|   Location           |   Specifies the location of the tooltip.     |
|   Text               |   Specifies the text of the tooltip.         |
|   TextStyle          |   Specifies the text style of the tooltip.   |
|   Data               |   Specifies the TreeMap item data, where the tooltip is to be rendered.       |
|   Cancel             |   Specifies the event cancel status.  |