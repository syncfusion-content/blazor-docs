---
layout: post
title: Navigation Line in Blazor Maps Component | Syncfusion 
description: Learn about Navigation Line in Blazor Maps component of Syncfusion, and more details.
platform: Blazor
control: Maps
documentation: ug
---

# Navigation Lines

Navigation lines are used to denote the path between the two locations. We can use this feature as flight or train or sea routes.

Following example shows rendering the path between two locations using latitudes and longitudes.

Yon can customize the navigation line color, dashArray, width and angle by modifying their default values in
`MapsNavigationLine`.

Refer the below code snippet to navigate line between two cities in World map.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsNavigationLines>
                <MapsNavigationLine Visible="true"
                                    Color="black"
                                    Angle="90"
                                    Width="2"
                                    DashArray="4"
                                    Latitude="new double[]{ 40.7128, 36.7783 }"
                                    Longitude="new double[]{ -74.0060, -119.4179 }">
                </MapsNavigationLine>
            </MapsNavigationLines>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Maps with navigation lines](./images/NavigationLine/Navigationline.png)

## Enabling arrows

You can enable arrows in the navigation lines using the [`ShowArrow`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html#Syncfusion_Blazor_Maps_MapsArrow_ShowArrow) property in [`MapsArrow`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Maps.MapsArrow.html) tag. You can also customize the following properties in arrow:

* Color - Specifies the color of arrow.
* Offset - Specifies the arrow's offset position.
* Position - Specifies the arrow position to the [`Start`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html#Syncfusion_Blazor_Maps_MapsArrow_Position) or [`End`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsArrow.html#Syncfusion_Blazor_Maps_MapsArrow_Position) of line.
* Size - Specifies the arrow size in pixels.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsNavigationLines>
                <MapsNavigationLine Visible="true"
                                    Color="blue"
                                    Angle="90"
                                    Width="2"
                                    DashArray="4"
                                    Latitude="new double[]{ 40.7128, 36.7783 }"
                                    Longitude="new double[]{ -74.0060, -119.4179 }">
                    @*  To set arrow for navigation line  *@
                    <MapsArrow ShowArrow="true" Color="blue"></MapsArrow>
                </MapsNavigationLine>
            </MapsNavigationLines>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```