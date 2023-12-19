---
layout: post
title: Shapefile in Blazor Maps component | Syncfusion
description: Checkout and learn here all about Shapefile in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Shapefile in Blazor Maps Component

Shapefile is a popular geospatial vector data format for storing location-based information such as shapes, spatial locations, and pertinent properties of geographic landmarks.

## Adding shapefile

Shapefile can be used to render vector shape maps in the Maps component by specifying the remotely hosted file path of the shapefile in the [MapsLayer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html)'s [ShapeData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapeData) property.

> Only when the shapefile is hosted on a remote server it will be displayed in the Maps component.

```cshtml
@using Syncfusion.Blazor.Maps

<div class="control-section">
    <SfMaps>
        <MapsAreaSettings Background="transparent" />
        <MapsLayers>
            <MapsLayer ShapeData='new {dataOptions = "https://cdn.syncfusion.com/maps/map-data/usa-states.shp"}' TValue="string">
                <MapsMarkerClusterSettings AllowClustering="true" AllowClusterExpand="true" Shape="MarkerType.Circle" Height="40" Width="40">
                    <MapsLayerMarkerClusterLabelStyle Color="#FFFFFF" />
                    <MapsLayerMarkerClusterConnectorLineSettings Color="@ConnectorLineColor" />
                </MapsMarkerClusterSettings>
                <MapsMarkerSettings>
                    <MapsMarker Visible="true" TValue="TopUniversitiesDetails" Height=15 Width=15 DataSource="@TopUniversities" Shape="MarkerType.Circle" Fill="red" AnimationDuration="0">
                        <MapsMarkerTooltipSettings Visible="true" ValuePath="Name">
                            <MapsMarkerTooltipTextStyle FontFamily="inherit"></MapsMarkerTooltipTextStyle>
                        </MapsMarkerTooltipSettings>
                    </MapsMarker>
                </MapsMarkerSettings>
                <MapsShapeSettings Fill="#A6A6A6"></MapsShapeSettings>
            </MapsLayer>
        </MapsLayers>
        <MapsZoomSettings Enable="false" />
        <MapsLegendSettings Visible="false" />
        <MapsTitleSettings Text="Top 10 Affordable Universities in the United States">
            <MapsTitleTextStyle Size="16px" FontFamily="inherit" />
        </MapsTitleSettings>
    </SfMaps>
</div>
@code {
    public string ConnectorLineColor = "#000000";
    public class TopUniversitiesDetails
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    };
    public List<TopUniversitiesDetails> TopUniversities = new List<TopUniversitiesDetails> {
        new TopUniversitiesDetails { Name="University of Washington", Latitude=47.655548, Longitude=-122.303200 , Color = "#623e8c" },
        new TopUniversitiesDetails { Name="CUNY Brooklyn College", Latitude=40.631920, Longitude= -73.952904, Color="#45738a" },
        new TopUniversitiesDetails { Name="Purdue University", Latitude=40.425869, Longitude=-86.908066, Color="#5fb8ad" },
        new TopUniversitiesDetails { Name="University of Florida", Latitude=29.643946, Longitude=-82.355659, Color="#5fb87b" },
        new TopUniversitiesDetails { Name="Oklahoma State University", Latitude=35.471901, Longitude=-97.581794, Color="#99b85f" },
        new TopUniversitiesDetails { Name="University of North Carolina at Chapel Hill", Latitude=35.904613, Longitude=-79.046761, Color="#a1931a" },
        new TopUniversitiesDetails { Name="California State University-Long Beach", Latitude=33.783823, Longitude=-118.114090, Color="#a1501a" },
        new TopUniversitiesDetails { Name="California State University-Los Angeles", Latitude=34.022415, Longitude=-118.285530, Color="#db4040" },
        new TopUniversitiesDetails { Name="Indiana University-Bloomington", Latitude=39.168804, Longitude=-86.536659, Color="#e227e8" },
        new TopUniversitiesDetails { Name="University of Illinois at Chicago", Latitude=41.789722, Longitude=-87.599724, Color="#0dff00" }
    };
 
}
```

![Shapefile rendered in Blazor Maps](./images/Shapefile/blazor-shapefile.png)

## Multilayer

The shapefile can also be rendered in multilayer structure as explained in [this section](https://blazor.syncfusion.com/documentation/maps/layers#multilayer) for GeoJSON map. Shapefiles can be added as multilayers in the ways listed below.

1. On top of the online map providers, the shapefile can be shown as a sublayer.
2. The shapefile can be shown as a sublayer above the GeoJSON map.
3. The GeoJSON map can be displayed as a sublayer over the shapefile map.
4. Shapefiles can be provided as both main and sublayer layers.

The following example demonstrates how to display the shapefile as a sublayer.

```cshtml
@using Syncfusion.Blazor.Maps;

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
        <MapsLayer ShapeData='new {dataOptions = "https://cdn.syncfusion.com/maps/map-data/usa-states.shp"}'
                   Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
            <MapsShapeSettings Fill="blue"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```
![Multilayer in Blazor Maps](./images/Shapefile/blazor-multilayer.png)

## Customizations

The characteristics of the shapes, such as fill color, border, projection type, and so on, in the shapefile map can be changed. You can know more about customizing shapes in Maps component from [this link](https://blazor.syncfusion.com/documentation/maps/customization).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## Color mapping

The color mapping functionality is used for changing the shape colors based on data bound with the shapes. You can know more about the color mapping from [this link](https://blazor.syncfusion.com/documentation/maps/color-mapping).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## Data labels

Data labels provide information about the shapes rendered with shapefile. You can know more about the data labels from [this link](https://blazor.syncfusion.com/documentation/maps/data-labels).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## Polygons

Polygon shapes can be rendered over the shapefile maps. You can know more about the polygon shapes from [this link](https://blazor.syncfusion.com/documentation/maps/polygon)

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## Markers

Markers are used to indicate locations with desired symbols on the map. You can know more about the markers from [this link](https://blazor.syncfusion.com/documentation/maps/markers).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## Bubbles

Bubbles are used to represent underlying data values that are bound to the shapes in the map. You can know more about the bubbles from [this link](https://blazor.syncfusion.com/documentation/maps/bubble).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## Legend

A legend is a graphical representation of the data that is associated with the map. To know more about the legends, you can follow [this link](https://blazor.syncfusion.com/documentation/maps/legend).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## Navigation lines

In a shapefile map, navigation lines are used to indicate the path between two points. To know more about the navigation lines, you can follow [this link](https://blazor.syncfusion.com/documentation/maps/navigation-line).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## Annotations

Annotations are used to highlight a particular area of interest on a shapefile map. To know more about the annotations, you can follow [this link](https://blazor.syncfusion.com/documentation/maps/annotations).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## User interactions

The shapefile map supports user interactions such as zooming, panning, selecting, highlight, and tooltip. To know more about the user interactions in the Maps, you can follow [this link](https://blazor.syncfusion.com/documentation/maps/user-interactions).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.

## Print and export

The map displayed via shapefile can be exported or printed. To know more about the print and export functionalities in the Maps, you can see [this link](https://blazor.syncfusion.com/documentation/maps/print-and-export).

> The JSON file will be used to describe each functionality in the URL above. If you want those functions, replace the JSON file path with the shapefile's file path.