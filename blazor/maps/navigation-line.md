---
layout: post
title: Navigation Lines in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about navigation lines in Syncfusion Blazor Maps component and much more.
platform: Blazor
control: Maps
documentation: ug
---

# Navigation Lines in Blazor Maps Component

The navigation lines are used to denote the path between two locations. This feature can be used to draw flight or sea routes. Navigation lines are enabled by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html#Syncfusion_Blazor_Maps_MapsNavigationLine_Visible) property of the [MapsNavigationLine](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html) to **true**.

## Customization

The following properties and classes are available in [MapsNavigationLine](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html) to customize the navigation line of the Maps component.

* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html#Syncfusion_Blazor_Maps_MapsNavigationLine_Color) - To apply the color for navigation lines in Maps.
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html#Syncfusion_Blazor_Maps_MapsNavigationLine_DashArray) - To define the pattern of dashes and gaps that is applied to the outline of the navigation lines.
* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html#Syncfusion_Blazor_Maps_MapsNavigationLine_Width) - To customize the width of the navigation lines.
* [Angle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html#Syncfusion_Blazor_Maps_MapsNavigationLine_Angle) - To customize the angle of the navigation lines.
* [MapsNavigationLineHighlightSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLineHighlightSettings.html) - To customize the highlight settings of the navigation line.
* [MapsNavigationLineSelectionSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLineSelectionSettings.html) - To customize the selection settings of the navigation line.

To navigate the line between two cities on the world map, [Latitude](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html#Syncfusion_Blazor_Maps_MapsNavigationLine_Latitude) and [Longitude](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html#Syncfusion_Blazor_Maps_MapsNavigationLine_Longitude) values are used to indicate the start and end points of navigation lines drawn on Maps.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsNavigationLines>
                <MapsNavigationLine Visible="true" Color="blue" Angle="90" Width="2" DashArray="4"
                                    Latitude="new double[]{ 40.7128, 36.7783 }" Longitude="new double[]{ -74.0060, -119.4179 }">
                </MapsNavigationLine>
            </MapsNavigationLines>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Blazor Maps with Navigation Lines](./images/NavigationLine/blazor-maps-navigation-line.png)

## Enabling the arrows

To enable the arrow in the navigation line, set the [ShowArrow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html#Syncfusion_Blazor_Maps_MapsArrow_ShowArrow) property of [MapsArrow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html) to **true**. The following properties are available in [MapsArrow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html) to customize the arrow of the navigation lines.

* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html#Syncfusion_Blazor_Maps_MapsArrow_Color) - To apply the color for arrow of the navigation line.
* [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html#Syncfusion_Blazor_Maps_MapsArrow_OffSet) - To customize the offset position of the arrow of the navigation line.
* [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html#Syncfusion_Blazor_Maps_MapsArrow_Position) - To customize the position of the arrow in navigation line. The possible values can be [**Start**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.ArrowPosition.html#Syncfusion_Blazor_Maps_ArrowPosition_Start) and [**End**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.ArrowPosition.html#Syncfusion_Blazor_Maps_ArrowPosition_End).
* [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html#Syncfusion_Blazor_Maps_MapsArrow_Size) - To customize the size of the arrow in pixels.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsNavigationLines>
                <MapsNavigationLine Visible="true" Color="blue" Angle="90" Width="2" DashArray="4"
                                    Latitude="new double[]{ 40.7128, 36.7783 }" Longitude="new double[]{ -74.0060, -119.4179 }">
                    @*  To set arrow for navigation line  *@
                    <MapsArrow ShowArrow="true" Color="blue"></MapsArrow>
                </MapsNavigationLine>
            </MapsNavigationLines>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Blazor Maps with Navigation Line Arrow](./images/NavigationLine/blazor-maps-navigation-line-arrow.PNG)