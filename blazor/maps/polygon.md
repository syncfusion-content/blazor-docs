---
layout: post
title: Polygon shape in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about polygon shape in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Polygon shape in Blazor Maps Component

The Maps component allows you to add polygon shape to a geometry map or an online map by using the properties in the [MapsPolygon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsPolygon.html) tag. This section describes how to add polygon shape to the map and customize them.

The polygon shape can be rendered over the map layer by defining the [Points](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsPolygon.html#Syncfusion_Blazor_Maps_MapsPolygon_Points) property in the [MapsPolygon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsPolygon.html) tag in the Maps component. The `Points` property uses a collection of latitude and longitude values to define the polygon shape.

The `MapsPolygon` tag provides the following properties for customizing the polygon shape of the Maps component.

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsPolygon.html#Syncfusion_Blazor_Maps_MapsPolygon_Fill) - It is used to change the color of the polygon shape.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsPolygon.html#Syncfusion_Blazor_Maps_MapsPolygon_Opacity) - It is used to change the opacity of the polygon shape.
* [BorderColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsPolygon.html#Syncfusion_Blazor_Maps_MapsPolygon_BorderColor) - It is used to change the color of the border in the polygon shape.
* [BorderWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsPolygon.html#Syncfusion_Blazor_Maps_MapsPolygon_BorderWidth) - It is used to change the width of the border in the polygon shape.
* [BorderOpacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsPolygon.html#Syncfusion_Blazor_Maps_MapsPolygon_BorderOpacity) - It is used to change the opacity of the border in the polygon shape.

> You can also include **"n"** polygon shapes inside the [MapsPolygons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsPolygons.html) tag.

The following example shows how to customize the polygon shape over the geometry map.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsPolygons>
                <MapsPolygon Points="Points" Fill="red" Opacity="0.7" BorderColor="green" BorderWidth="2" BorderOpacity="0.7"></MapsPolygon>
            </MapsPolygons>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    List<Coordinate> Points = new List<Coordinate>();
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Points.Add(new Coordinate() { Longitude = 34.88539587371454, Latitude = 28.181421087099537 });
        Points.Add(new Coordinate() { Longitude = 37.50029619722466, Latitude = 24.299419888989462 });
        Points.Add(new Coordinate() { Longitude = 39.22241423764024, Latitude = 22.638529461838658 });
        Points.Add(new Coordinate() { Longitude = 38.95650769309776, Latitude = 21.424998160017495 });
        Points.Add(new Coordinate() { Longitude = 40.19963938650778, Latitude = 20.271205391339606 });
        Points.Add(new Coordinate() { Longitude = 41.76547269134551, Latitude = 18.315451049867193 });
        Points.Add(new Coordinate() { Longitude = 42.78452077838921, Latitude = 16.097235052947966 });
        Points.Add(new Coordinate() { Longitude = 43.36984949591576, Latitude = 17.188572054533054 });
        Points.Add(new Coordinate() { Longitude = 44.12558191797012, Latitude = 17.407258102232234 });
        Points.Add(new Coordinate() { Longitude = 46.69027032797584, Latitude = 17.33342243475734 });
        Points.Add(new Coordinate() { Longitude = 47.09312386141585, Latitude = 16.97087769526452 });
        Points.Add(new Coordinate() { Longitude = 48.3417299826302, Latitude = 18.152700711188004 });
        Points.Add(new Coordinate() { Longitude = 49.74762591400318, Latitude = 18.81544363931681 });
        Points.Add(new Coordinate() { Longitude = 52.41428026336621, Latitude = 18.9035706497573 });
        Points.Add(new Coordinate() { Longitude = 55.272683129240335, Latitude = 20.133861012918544 });
        Points.Add(new Coordinate() { Longitude = 55.60121336079203, Latitude = 21.92042703112351 });
        Points.Add(new Coordinate() { Longitude = 55.08204399107967, Latitude = 22.823302662258882 });
        Points.Add(new Coordinate() { Longitude = 52.743894337844154, Latitude = 22.954463486477437 });
        Points.Add(new Coordinate() { Longitude = 51.47035908651375, Latitude = 24.35818837668566 });
        Points.Add(new Coordinate() { Longitude = 51.122553219055874, Latitude = 24.666679732426346 });
        Points.Add(new Coordinate() { Longitude = 51.58731671256831, Latitude = 25.173806925822717 });
        Points.Add(new Coordinate() { Longitude = 51.35950585992913, Latitude = 25.84556484481108 });
        Points.Add(new Coordinate() { Longitude = 51.088770529661275, Latitude = 26.168494193631147 });
        Points.Add(new Coordinate() { Longitude = 50.78527056538036, Latitude = 25.349051242147596 });
        Points.Add(new Coordinate() { Longitude = 50.88330288802666, Latitude = 24.779242606720743 });
        Points.Add(new Coordinate() { Longitude = 50.19702490702369, Latitude = 25.66825106363693 });
        Points.Add(new Coordinate() { Longitude = 50.066461167339924, Latitude = 26.268905608606616 });
        Points.Add(new Coordinate() { Longitude = 49.645896067213215, Latitude = 27.15116474192905 });
        Points.Add(new Coordinate() { Longitude = 48.917371072320805, Latitude = 27.55738830340198 });
        Points.Add(new Coordinate() { Longitude = 48.3984720209192, Latitude = 28.566207269716173 });
        Points.Add(new Coordinate() { Longitude = 47.68851714518985, Latitude = 28.5938991332588 });
        Points.Add(new Coordinate() { Longitude = 47.45059089191449, Latitude = 29.009321449856984 });
        Points.Add(new Coordinate() { Longitude = 44.73549453609391, Latitude = 29.157358362696385 });
        Points.Add(new Coordinate() { Longitude = 41.79487372890989, Latitude = 31.23489959729713 });
        Points.Add(new Coordinate() { Longitude = 40.36977176033773, Latitude = 31.9642352513131 });
        Points.Add(new Coordinate() { Longitude = 39.168270913149826, Latitude = 32.18348471414393 });
        Points.Add(new Coordinate() { Longitude = 37.019253492546454, Latitude = 31.47710220862595 });
        Points.Add(new Coordinate() { Longitude = 37.99644645508337, Latitude = 30.4851028633376 });
        Points.Add(new Coordinate() { Longitude = 37.67756530485232, Latitude = 30.3636358598429 });
        Points.Add(new Coordinate() { Longitude = 37.50181466030105, Latitude = 29.960155516804974 });
        Points.Add(new Coordinate() { Longitude = 36.700288181129594, Latitude = 29.882136586478993 });
        Points.Add(new Coordinate() { Longitude = 36.100009274845206, Latitude = 29.15308642012721 });
        Points.Add(new Coordinate() { Longitude = 34.85774476486728, Latitude = 29.3103032832622 });
        Points.Add(new Coordinate() { Longitude = 34.64498583263142, Latitude = 28.135787235699823 });
        Points.Add(new Coordinate() { Longitude = 34.88539587371454, Latitude = 28.181421087099537 });
    }
}
```
![Blazor Maps with polygon shape](./images/Polygon/blazor-map-polygon-shape-on-maps-layer.png)

## Tooltip for polygon shape

Tooltip is used to display more information about a polygon shape on mouse over or touch end event. This can be enabled by setting the [`Visible`]() property to **true** in the  [`MapsPolygonTooltipSettings`](). Additonally, you need to set the [`TooltipText`]() property in the [`MapsPolygon`](../api/maps/polygonSettingsModel) to show the tooltip text separately for each polygon shape, if you add 'n' numbers of polygon shapes.

### Tooltip customization

The following properties are available in the [`MapsPolygonTooltipSettings`]() to customize the tooltip of the Maps component.

* [`Fill`]() - Applies the color of the tooltip in the polygon shape.
* [`BorderColor`]() - To customize the color of the border of the tooltip in the polygon shape.
* [`BorderWidth`]() - To customize the width of the border of the tooltip in the polygon shape.
* [`BorderOpacity`]() - To customize the opacity of the border of the tooltip in the polygon shape.
* [`FontFamily`]() - To customize the font family of the text in the tooltip of the polygon shape.
* [`FontWeight`]() - TTo customize the font weight of the text in the tooltip of the polygon shape.
* [`FontStyle`]() - To customize the font style of the text in the tooltip of the polygon shape.
* [`FontColor`]() - To customize the font color of the text in the tooltip of the polygon shape.
* [`FontSize`]() - To customize the font size of the text in the tooltip of the polygon shape.
* [`FontOpacity`]() - TTo customize the opacity of the text in the tooltip of the polygon shape.


```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsPolygons>
                <MapsPolygon Points="Points" Fill="red" Opacity="0.7" BorderColor="green" BorderWidth="2" BorderOpacity="0.7">
                <TooltipTemplate> <div style="width:200px;"> Country Name : Saudi Arabia</div> </TooltipTemplate>
                </MapsPolygon>
                <MapsPolygonTooltipSettings Visible="true"></MapsPolygonTooltipSettings>
            </MapsPolygons>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    List<Coordinate> Points = new List<Coordinate>();
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Points.Add(new Coordinate() { Longitude = 34.88539587371454, Latitude = 28.181421087099537 });
        Points.Add(new Coordinate() { Longitude = 37.50029619722466, Latitude = 24.299419888989462 });
        Points.Add(new Coordinate() { Longitude = 39.22241423764024, Latitude = 22.638529461838658 });
        Points.Add(new Coordinate() { Longitude = 38.95650769309776, Latitude = 21.424998160017495 });
        Points.Add(new Coordinate() { Longitude = 40.19963938650778, Latitude = 20.271205391339606 });
        Points.Add(new Coordinate() { Longitude = 41.76547269134551, Latitude = 18.315451049867193 });
        Points.Add(new Coordinate() { Longitude = 42.78452077838921, Latitude = 16.097235052947966 });
        Points.Add(new Coordinate() { Longitude = 43.36984949591576, Latitude = 17.188572054533054 });
        Points.Add(new Coordinate() { Longitude = 44.12558191797012, Latitude = 17.407258102232234 });
        Points.Add(new Coordinate() { Longitude = 46.69027032797584, Latitude = 17.33342243475734 });
        Points.Add(new Coordinate() { Longitude = 47.09312386141585, Latitude = 16.97087769526452 });
        Points.Add(new Coordinate() { Longitude = 48.3417299826302, Latitude = 18.152700711188004 });
        Points.Add(new Coordinate() { Longitude = 49.74762591400318, Latitude = 18.81544363931681 });
        Points.Add(new Coordinate() { Longitude = 52.41428026336621, Latitude = 18.9035706497573 });
        Points.Add(new Coordinate() { Longitude = 55.272683129240335, Latitude = 20.133861012918544 });
        Points.Add(new Coordinate() { Longitude = 55.60121336079203, Latitude = 21.92042703112351 });
        Points.Add(new Coordinate() { Longitude = 55.08204399107967, Latitude = 22.823302662258882 });
        Points.Add(new Coordinate() { Longitude = 52.743894337844154, Latitude = 22.954463486477437 });
        Points.Add(new Coordinate() { Longitude = 51.47035908651375, Latitude = 24.35818837668566 });
        Points.Add(new Coordinate() { Longitude = 51.122553219055874, Latitude = 24.666679732426346 });
        Points.Add(new Coordinate() { Longitude = 51.58731671256831, Latitude = 25.173806925822717 });
        Points.Add(new Coordinate() { Longitude = 51.35950585992913, Latitude = 25.84556484481108 });
        Points.Add(new Coordinate() { Longitude = 51.088770529661275, Latitude = 26.168494193631147 });
        Points.Add(new Coordinate() { Longitude = 50.78527056538036, Latitude = 25.349051242147596 });
        Points.Add(new Coordinate() { Longitude = 50.88330288802666, Latitude = 24.779242606720743 });
        Points.Add(new Coordinate() { Longitude = 50.19702490702369, Latitude = 25.66825106363693 });
        Points.Add(new Coordinate() { Longitude = 50.066461167339924, Latitude = 26.268905608606616 });
        Points.Add(new Coordinate() { Longitude = 49.645896067213215, Latitude = 27.15116474192905 });
        Points.Add(new Coordinate() { Longitude = 48.917371072320805, Latitude = 27.55738830340198 });
        Points.Add(new Coordinate() { Longitude = 48.3984720209192, Latitude = 28.566207269716173 });
        Points.Add(new Coordinate() { Longitude = 47.68851714518985, Latitude = 28.5938991332588 });
        Points.Add(new Coordinate() { Longitude = 47.45059089191449, Latitude = 29.009321449856984 });
        Points.Add(new Coordinate() { Longitude = 44.73549453609391, Latitude = 29.157358362696385 });
        Points.Add(new Coordinate() { Longitude = 41.79487372890989, Latitude = 31.23489959729713 });
        Points.Add(new Coordinate() { Longitude = 40.36977176033773, Latitude = 31.9642352513131 });
        Points.Add(new Coordinate() { Longitude = 39.168270913149826, Latitude = 32.18348471414393 });
        Points.Add(new Coordinate() { Longitude = 37.019253492546454, Latitude = 31.47710220862595 });
        Points.Add(new Coordinate() { Longitude = 37.99644645508337, Latitude = 30.4851028633376 });
        Points.Add(new Coordinate() { Longitude = 37.67756530485232, Latitude = 30.3636358598429 });
        Points.Add(new Coordinate() { Longitude = 37.50181466030105, Latitude = 29.960155516804974 });
        Points.Add(new Coordinate() { Longitude = 36.700288181129594, Latitude = 29.882136586478993 });
        Points.Add(new Coordinate() { Longitude = 36.100009274845206, Latitude = 29.15308642012721 });
        Points.Add(new Coordinate() { Longitude = 34.85774476486728, Latitude = 29.3103032832622 });
        Points.Add(new Coordinate() { Longitude = 34.64498583263142, Latitude = 28.135787235699823 });
        Points.Add(new Coordinate() { Longitude = 34.88539587371454, Latitude = 28.181421087099537 });
    }
}

```

![Blazor Maps with tooltip for polygon shape](./images/Polygon/blazor-map-polygon-shape-tooltip.png)

### Tooltip template

The HTML element can be rendered in the tooltip of the Maps using the [`TooltipTemplate`]() property of the [`MapsPolygon`](../api/maps/polygonSettingsModel).  If you add 'n' numbers of polygon shapes, you may add the `TooltipTemplate` property to each polygon group, which will display the tooltip data for the associated polygon shape.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsPolygons>
                <MapsPolygon Points="Points" Fill="red" Opacity="0.7" BorderColor="green" BorderWidth="2" BorderOpacity="0.7"></MapsPolygon>
            </MapsPolygons>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    List<Coordinate> Points = new List<Coordinate>();
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Points.Add(new Coordinate() { Longitude = 34.88539587371454, Latitude = 28.181421087099537 });
        Points.Add(new Coordinate() { Longitude = 37.50029619722466, Latitude = 24.299419888989462 });
        Points.Add(new Coordinate() { Longitude = 39.22241423764024, Latitude = 22.638529461838658 });
        Points.Add(new Coordinate() { Longitude = 38.95650769309776, Latitude = 21.424998160017495 });
        Points.Add(new Coordinate() { Longitude = 40.19963938650778, Latitude = 20.271205391339606 });
        Points.Add(new Coordinate() { Longitude = 41.76547269134551, Latitude = 18.315451049867193 });
        Points.Add(new Coordinate() { Longitude = 42.78452077838921, Latitude = 16.097235052947966 });
        Points.Add(new Coordinate() { Longitude = 43.36984949591576, Latitude = 17.188572054533054 });
        Points.Add(new Coordinate() { Longitude = 44.12558191797012, Latitude = 17.407258102232234 });
        Points.Add(new Coordinate() { Longitude = 46.69027032797584, Latitude = 17.33342243475734 });
        Points.Add(new Coordinate() { Longitude = 47.09312386141585, Latitude = 16.97087769526452 });
        Points.Add(new Coordinate() { Longitude = 48.3417299826302, Latitude = 18.152700711188004 });
        Points.Add(new Coordinate() { Longitude = 49.74762591400318, Latitude = 18.81544363931681 });
        Points.Add(new Coordinate() { Longitude = 52.41428026336621, Latitude = 18.9035706497573 });
        Points.Add(new Coordinate() { Longitude = 55.272683129240335, Latitude = 20.133861012918544 });
        Points.Add(new Coordinate() { Longitude = 55.60121336079203, Latitude = 21.92042703112351 });
        Points.Add(new Coordinate() { Longitude = 55.08204399107967, Latitude = 22.823302662258882 });
        Points.Add(new Coordinate() { Longitude = 52.743894337844154, Latitude = 22.954463486477437 });
        Points.Add(new Coordinate() { Longitude = 51.47035908651375, Latitude = 24.35818837668566 });
        Points.Add(new Coordinate() { Longitude = 51.122553219055874, Latitude = 24.666679732426346 });
        Points.Add(new Coordinate() { Longitude = 51.58731671256831, Latitude = 25.173806925822717 });
        Points.Add(new Coordinate() { Longitude = 51.35950585992913, Latitude = 25.84556484481108 });
        Points.Add(new Coordinate() { Longitude = 51.088770529661275, Latitude = 26.168494193631147 });
        Points.Add(new Coordinate() { Longitude = 50.78527056538036, Latitude = 25.349051242147596 });
        Points.Add(new Coordinate() { Longitude = 50.88330288802666, Latitude = 24.779242606720743 });
        Points.Add(new Coordinate() { Longitude = 50.19702490702369, Latitude = 25.66825106363693 });
        Points.Add(new Coordinate() { Longitude = 50.066461167339924, Latitude = 26.268905608606616 });
        Points.Add(new Coordinate() { Longitude = 49.645896067213215, Latitude = 27.15116474192905 });
        Points.Add(new Coordinate() { Longitude = 48.917371072320805, Latitude = 27.55738830340198 });
        Points.Add(new Coordinate() { Longitude = 48.3984720209192, Latitude = 28.566207269716173 });
        Points.Add(new Coordinate() { Longitude = 47.68851714518985, Latitude = 28.5938991332588 });
        Points.Add(new Coordinate() { Longitude = 47.45059089191449, Latitude = 29.009321449856984 });
        Points.Add(new Coordinate() { Longitude = 44.73549453609391, Latitude = 29.157358362696385 });
        Points.Add(new Coordinate() { Longitude = 41.79487372890989, Latitude = 31.23489959729713 });
        Points.Add(new Coordinate() { Longitude = 40.36977176033773, Latitude = 31.9642352513131 });
        Points.Add(new Coordinate() { Longitude = 39.168270913149826, Latitude = 32.18348471414393 });
        Points.Add(new Coordinate() { Longitude = 37.019253492546454, Latitude = 31.47710220862595 });
        Points.Add(new Coordinate() { Longitude = 37.99644645508337, Latitude = 30.4851028633376 });
        Points.Add(new Coordinate() { Longitude = 37.67756530485232, Latitude = 30.3636358598429 });
        Points.Add(new Coordinate() { Longitude = 37.50181466030105, Latitude = 29.960155516804974 });
        Points.Add(new Coordinate() { Longitude = 36.700288181129594, Latitude = 29.882136586478993 });
        Points.Add(new Coordinate() { Longitude = 36.100009274845206, Latitude = 29.15308642012721 });
        Points.Add(new Coordinate() { Longitude = 34.85774476486728, Latitude = 29.3103032832622 });
        Points.Add(new Coordinate() { Longitude = 34.64498583263142, Latitude = 28.135787235699823 });
        Points.Add(new Coordinate() { Longitude = 34.88539587371454, Latitude = 28.181421087099537 });
    }
}

```

![Blazor Maps with tooltip template for polygon shape](./images/Polygon/blazor-map-polygon-shape-tooltip-template.png)