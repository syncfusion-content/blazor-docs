---
layout: post
title: Labels in Blazor TreeMap Component | Syncfusion
description: Check out and learn here all about Labels in Syncfusion Blazor TreeMap component and much more details.
platform: Blazor
control: TreeMap
documentation: ug
---

# Labels in Blazor TreeMap Component

Data labels identify item or group names in the TreeMap component. Labels are displayed by specifying a data source field in the [LabelPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafItemSettings.html#Syncfusion_Blazor_TreeMap_TreeMapLeafItemSettings_LabelPath) of the [TreeMapLeafItemSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafItemSettings.html).

## Formatting labels

Customize item labels using the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafItemSettings.html#Syncfusion_Blazor_TreeMap_TreeMapLeafItemSettings_LabelFormat) property in [TreeMapLeafItemSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafItemSettings.html).

```cshtml

@using Syncfusion.Blazor.TreeMap

<SfTreeMap WeightValuePath="Count" TValue="Car" DataSource="Cars" RangeColorValuePath="Count">
    <TreeMapLeafItemSettings LabelPath="Name" LabelFormat="${Name}-${Brand}"></TreeMapLeafItemSettings>
</SfTreeMap>

@code {
    public class Car
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
    };

    public List<Car> Cars = new List<Car> {
        new Car { Name = "Mustang", Brand = "Ford", Count = 232 },
        new Car { Name = "EcoSport", Brand = "Ford", Count = 121 },
        new Car { Name = "Swift", Brand = "Maruti", Count = 143 },
        new Car { Name = "Baleno", Brand = "Maruti", Count = 454 },
        new Car { Name = "Vitara Brezza", Brand = "Maruti", Count = 545 },
        new Car { Name = "A3 Cabriolet", Brand = "Audi",Count = 123 },
        new Car { Name = "RS7 Sportback", Brand = "Audi", Count = 523 }
    };
}

```

![Blazor TreeMap with Data Label](images/datalabel/blazor-treemap-data-label.png)

## Label position

Set the label position using the [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafItemSettings.html#Syncfusion_Blazor_TreeMap_TreeMapLeafItemSettings_LabelPosition) property to any of the following locations:

* [BottomCenter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.LabelPosition.html#Syncfusion_Blazor_TreeMap_LabelPosition_BottomCenter)
* [BottomLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.LabelPosition.html#Syncfusion_Blazor_TreeMap_LabelPosition_BottomLeft)
* [BottomRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.LabelPosition.html#Syncfusion_Blazor_TreeMap_LabelPosition_BottomRight)
* [Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.LabelPosition.html#Syncfusion_Blazor_TreeMap_LabelPosition_Center)
* [CenterLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.LabelPosition.html#Syncfusion_Blazor_TreeMap_LabelPosition_CenterLeft)
* [CenterRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.LabelPosition.html#Syncfusion_Blazor_TreeMap_LabelPosition_CenterRight)
* [TopCenter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.LabelPosition.html#Syncfusion_Blazor_TreeMap_LabelPosition_TopCenter)
* [TopLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.LabelPosition.html#Syncfusion_Blazor_TreeMap_LabelPosition_TopLeft)
* [TopRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.LabelPosition.html#Syncfusion_Blazor_TreeMap_LabelPosition_TopRight)

```cshtml

@using Syncfusion.Blazor.TreeMap

<SfTreeMap WeightValuePath="Count" TValue="Car" DataSource="Cars" RangeColorValuePath="Count">
    <TreeMapLeafItemSettings LabelPath="Name" LabelFormat="${Name}-${Brand}" LabelPosition="LabelPosition.Center" Gap="2"></TreeMapLeafItemSettings>
</SfTreeMap>

```

N> See the [Formatting labels](#formatting-labels) section for the definition of the **Cars** data source.

![Blazor TreeMap Label in Custom Position](images/datalabel/blazor-treemap-label-in-custom-position.png)

## Intersect action

When a label's size exceeds the available space, control its behavior using the [InterSectAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafItemSettings.html#Syncfusion_Blazor_TreeMap_TreeMapLeafItemSettings_InterSectAction) property in [TreeMapLeafItemSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafItemSettings.html).

```cshtml

@using Syncfusion.Blazor.TreeMap

<SfTreeMap WeightValuePath="Count" TValue="Car" DataSource="Cars">
    <TreeMapLeafItemSettings LabelPath="Name" LabelFormat="${Name}-${Brand}" InterSectAction="LabelAlignment.WrapByWord">
    </TreeMapLeafItemSettings>
</SfTreeMap>

@code {
    public class Car
    {
        public string Name { get; set; }
        public string Brand { get;set; }
        public int Count { get; set; }
    };

    public List<Car> Cars = new List<Car> {
        new Car { Name = "Mustang", Brand = "Ford Motor Company", Count = 232 },
        new Car { Name = "Lincoln Continental Mark V", Brand = "Ford Motor Company", Count = 50},
        new Car { Name = "EcoSport", Brand = "Ford Motor Company", Count = 121 },
        new Car { Name = "Swift", Brand = "Maruti", Count = 143 },
        new Car { Name = "Baleno", Brand = "Maruti", Count = 454 },
        new Car { Name = "Vitara Brezza", Brand = "Maruti", Count = 545 },
        new Car { Name = "A3 Cabriolet", Brand = "Audi",Count = 123 },
        new Car { Name = "RS7 Sportback", Brand = "Audi", Count = 523 }
    };
}

```

![Blazor TreeMap Label with Intersect Options](images/datalabel/blazor-treemap-label-intersect-action.png)
