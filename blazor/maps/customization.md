---
layout: post
title: Customization in Blazor Maps Component | Syncfusion
description: Check out and learn here all about customization in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Customization in Blazor Maps Component

## Setting the size for Maps

Set the Maps width and height by using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Height) properties. Specify values in percentage or pixels.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps Height="600px" Width="300px">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            @* To customize map shape *@
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```

![Blazor Maps with Custom Size](./images/Customization/blazor-maps-custom-size.PNG)

## Maps title

Configure a title by using the [MapsTitleSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleSettings.html). The following properties and classes customize the title:

* [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleSettings.html#Syncfusion_Blazor_Maps_MapsTitleSettings_Alignment) – Controls title text alignment: [**Center**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.Alignment.html#Syncfusion_Blazor_Maps_Alignment_Center), [**Near**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.Alignment.html#Syncfusion_Blazor_Maps_Alignment_Near), or [**Far**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.Alignment.html#Syncfusion_Blazor_Maps_Alignment_Far).
* [Description](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleSettings.html#Syncfusion_Blazor_Maps_MapsTitleSettings_Description) – Sets an accessible description for the title.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleSettings.html#Syncfusion_Blazor_Maps_MapsTitleSettings_Text) – Defines the title text.
* [MapsTitleTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleTextStyle.html) – Customizes title text appearance.
* [MapsSubtitleSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsSubtitleSettings.html) – Adds and customizes a subtitle.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps Height="300px">
    <MapsTitleSettings Text="Maps Component" Description="Maps" Alignment="Syncfusion.Blazor.Maps.Alignment.Center">
        <MapsTitleTextStyle Color="Green" FontFamily="Times New Roman" FontStyle="italic" FontWeight="bold">
        </MapsTitleTextStyle>
        <MapsSubtitleSettings Text="Default sample"></MapsSubtitleSettings>
    </MapsTitleSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```

![Customizing Blazor Maps Title](./images/Customization/blazor-maps-title-customization.PNG)

## Setting theme

The Maps control supports the following themes.

* Material
* Fabric
* Bootstrap
* HighContrast
* MaterialDark
* FabricDark
* BootstrapDark
* Bootstrap4
* HighContrastLight
* Tailwind

By default, Maps renders with the **Material** theme. Change the theme by using the [Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Theme) property.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps Theme="Syncfusion.Blazor.Theme.HighContrastLight">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            @* To customize map shape *@
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```

![Applying Theme in Blazor Maps](./images/Customization/blazor-maps-theme.PNG)

## Customizing Maps container

Use the following to customize the Maps container:

* [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Background) – Applies a background color to the container.
* [MapsBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsBorder.html) – Customizes border color and width.
* [MapsMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMargin.html) – Adjusts container margins.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps Height="300px" Width="400px" Background="#CCD1D1">
    <MapsBorder Color="green" Width="2"></MapsBorder>
    <MapsMargin Bottom="10" Left="10" Right="10" Top="10"></MapsMargin>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsShapeSettings Autofill="true"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```

![Customizing Blazor Maps Container](./images/Customization/blazor-maps-container-customization.PNG)

## Customizing Maps area

The shape map background color is **white** by default. Modify the background color by using the [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsAreaSettings.html#Syncfusion_Blazor_Maps_MapsAreaSettings_Background) property in [MapsAreaSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsAreaSettings.html). Customize the area border by using [MapsAreaBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsAreaBorder.html).

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
   <MapsAreaSettings Background="#e6e2d3">
       <MapsBorder Color="green" Width="2"></MapsBorder>
   </MapsAreaSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            @* To set shape color automatically *@
            <MapsShapeSettings Autofill="true"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```

![Customizing Blazor Maps Area](./images/Customization/blazor-maps-area-customization.PNG)

## Customizing the shapes

The following properties and class in [MapsShapeSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html) customize map shapes:

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_Fill) – Applies a fill color to shapes.
* [Autofill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_Autofill) – Applies palette colors to shapes when set to true.
* [Palette](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_Palette) – Sets a custom palette for shapes.
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_DashArray) – Defines dash and gap patterns for shape outlines.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_Opacity) – Controls shape transparency.
* [MapsShapeBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeBorder.html) – Customizes border color and width for shapes.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            @* To customize map shape *@
            <MapsShapeSettings Autofill="true" Palette='new string[] {"#d6cbd3", "#eca1a6", "#bdcebe", "#ada397", "#d5e1df"}' DashArray="1" Opacity=0.9>
                <MapsShapeBorder Color="#FFFFFF" Width="2"></MapsShapeBorder>
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```

![Blazor Maps with Custom Shape](./images/Customization/blazor-maps-custom-shape.png)

## Setting color to the shapes from the data source

Set a shape color from data by using the [ColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_ColorValuePath) property of [MapsShapeSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html). Provide a field name from the layer data source that contains color values.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' ShapeDataPath="Continent" ShapePropertyPath='new string[] {"continent"}' DataSource="ShapeColor" TValue="Data">
            <MapsShapeSettings ColorValuePath="Color"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class Data
    {
        public string Continent { get; set; }
        public string Color { get; set; }
    };

    public List<Data> ShapeColor = new List<Data> {
        new Data { Continent = "North America", Color = "#71B081" },
        new Data { Continent = "South America", Color = "#5A9A77" },
        new Data { Continent = "Africa", Color = "#498770" },
        new Data { Continent = "Europe", Color = "#39776C" },
        new Data { Continent = "Asia", Color = "#266665" },
        new Data { Continent = "Australia", Color = "#124F5E" }
    };
}
```

![Blazor Maps with Custom Shape Color](./images/Customization/blazor-maps-custom-shape-color.PNG)

## Applying border to individual shapes

Customize the border of each shape by using [BorderColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_BorderColorValuePath) and [BorderWidthValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_BorderWidthValuePath) properties to define color and width from the layer data source. If these path values do not match a data field, the shape border configuration in shape settings is applied.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' ShapeDataPath="Continent" ShapePropertyPath='new string[] {"continent"}' DataSource="ShapeColor" TValue="Data">
            <MapsShapeSettings ColorValuePath="Color" BorderColorValuePath="BorderColor" BorderWidthValuePath="Width"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class Data
    {
        public string Continent { get; set; }
        public string Color { get; set; }
        public double Width { get; set; }
        public string BorderColor { get; set; }
    };

    public List<Data> ShapeColor = new List<Data> {
        new Data { Continent  "North America", Color = "#71B081", Width = 2 , BorderColor = "#CCFFE5" },
        new Data { Continent = "South America", Color = "#5A9A77", Width = 2 , BorderColor = "red" },
        new Data { Continent = "Africa", Color = "#498770", Width = 2 , BorderColor = "#FFCC99" },
        new Data { Continent = "Europe", Color = "#39776C" , Width = 2 , BorderColor = "#66B2FF" },
        new Data { Continent = "Asia", Color = "#266665", Width = 2 , BorderColor = "#999900" },
        new Data { Continent = "Australia", Color = "#124F5E", Width = 2 , BorderColor = "blue" }
    };
}

```

![Blazor Maps with Custom Border Color and Width](./images/Customization/blazor-maps-custom-border-color-and-width.PNG)

## Projection type

The Maps control supports the following projection types:

* Mercator
* Equirectangular
* Miller
* Eckert3
* Eckert5
* Eckert6
* Winkel3
* AitOff

By default, Maps renders with the **Mercator** projection, which draws shapes based on geographic coordinates. Change the projection by using the [ProjectionType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ProjectionType) property.

```cshtml

@using Syncfusion.Blazor.Maps

@* To change Maps projection *@
<SfMaps ProjectionType="ProjectionType.Miller">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```

![Blazor Maps with Miller Projection](./images/Customization/blazor-maps-miller-projection.png)
