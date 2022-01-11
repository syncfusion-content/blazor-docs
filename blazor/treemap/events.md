---
layout: post
title: Events in Blazor TreeMap Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor TreeMap component and much more details.
platform: Blazor
control: TreeMap
documentation: ug
---

# Events in Blazor TreeMap Component

## Using Events in Blazor TreeMap Component

In the following example, the event [ItemRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapEvents.html#Syncfusion_Blazor_TreeMap_TreeMapEvents_ItemRendering) binds to the TreeMap component, so the event handler ItemRenderer will be called before rendering the item of the TreeMap.

```cshtml
@using Syncfusion.Blazor.TreeMap;
	<SfTreeMap ID="treemap" @ref="Tree" TValue="CarSalesDetails" WeightValuePath="Sales" DataSource="@DataSource">
	    <TreeMapEvents ItemRendering="@ItemRenderer"></TreeMapEvents> 
        <TreeMapLeafItemSettings LabelPath="@LabelPath">
        </TreeMapLeafItemSettings>
        <TreeMapTooltipSettings Visible="true">
        </TreeMapTooltipSettings>
    </SfTreeMap>

@code{
    SfTreeMap<CarSalesDetails> Tree;
    public string LabelPath = "Company";
     public class CarSalesDetails
    {
        public string Continent { get; set; }
        public string Company { get; set; }
        public int Sales { get; set; }
    }

    public List<CarSalesDetails> DataSource = new List<CarSalesDetails> {
        new CarSalesDetails { Continent="China", Company="Volkswagen", Sales=3005994 },
        new CarSalesDetails { Continent="United States", Company="General Motors", Sales=3042775 },
        new CarSalesDetails { Continent="Japan",Company="Toyota", Sales=1527977 },
        new CarSalesDetails { Continent="Germany",Company="Volkswagen", Sales=655977 },
        new CarSalesDetails { Continent="United Kingdom", Company="Ford ", Sales=319442 },
        new CarSalesDetails { Continent="India", Company="Maruti Suzuki", Sales=1443654 },
        new CarSalesDetails { Continent="France", Company="Renault", Sales=408183 },
        new CarSalesDetails { Continent="Brazil", Company="Flat Chrysler", Sales=368842 },
        new CarSalesDetails { Continent="Italy", Company="Flat Chrysler", Sales=386260 },
        new CarSalesDetails { Continent="Canada", Company="Ford", Sales=305086},
      
   };
   void ItemRenderer(ItemRenderingEventArgs args)
   {
           
        // Here you can customize your code
   }
}
```

## Available events

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
|   ImageUrl           |   Specifies the image URL.                                        |
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

Triggers, when clicking on the treemap.

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
|   Cancel             |   Specifies the event cancel status.   |