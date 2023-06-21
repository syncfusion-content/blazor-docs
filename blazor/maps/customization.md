---
layout: post
title: Customization in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about customization in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Customization in Blazor Maps Component

## Setting the size for Maps

The width and height of the Maps can be set using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Height) properties in the Maps component. Percentage or pixel values can be used for the height and width values.

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

The title for the Maps can be set using the [MapsTitleSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleSettings.html) class. It can be customized using the following properties and classes.

* [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleSettings.html#Syncfusion_Blazor_Maps_MapsTitleSettings_Alignment) - To customize the alignment for the text in the title for the Maps. The possible values are [**Center**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.Alignment.html#Syncfusion_Blazor_Maps_Alignment_Center), [**Near**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.Alignment.html#Syncfusion_Blazor_Maps_Alignment_Near) and [**Far**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.Alignment.html#Syncfusion_Blazor_Maps_Alignment_Far).
* [Description](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleSettings.html#Syncfusion_Blazor_Maps_MapsTitleSettings_Description) - To set the description of the title in Maps.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleSettings.html#Syncfusion_Blazor_Maps_MapsTitleSettings_Text) - To set the text for the title in Maps.
* [MapsTitleTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleTextStyle.html) - To customize the text of the title in Maps.
* [MapsSubtitleSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsSubtitleSettings.html) - To customize the subtitle for the Maps.

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

The Maps control supports following themes.

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

By default, the Maps are rendered by the **Material** theme. The theme of the Maps component is changed using the [Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Theme) property.

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

The following property and classes are available to customize the container in the Maps.

* [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Background) - To apply the background color to the container in the Maps.
* [MapsBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsBorder.html) - To customize the color and width of the border of the Maps.
* [MapsMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMargin.html) - To customize the margins of the Maps.

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

By default, the background color of the shape maps is set as **white**. To modify the background color of the Maps area, the [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsAreaSettings.html#Syncfusion_Blazor_Maps_MapsAreaSettings_Background) property in the [MapsAreaSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsAreaSettings.html) is used. The border of the Maps area can be customized using the [MapsAreaBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsAreaBorder.html).

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

The following properties and class are available in [MapsShapeSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html) to customize the shapes of the Maps component.

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_Fill) - To apply the color to the shapes.
* [Autofill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_Autofill) - To apply the palette colors to the shapes if it is set as true.
* [Palette](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_Palette) - To set the custom palette for the shapes.
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_DashArray) - To define the pattern of dashes and gaps that is applied to the outline of the shapes.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_Opacity) - To customize the transparency for the shapes.
* [MapsShapeBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeBorder.html) - To customize the color and width of the border of the shapes.

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

The color for each shape in the Maps can be set using the [ColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_ColorValuePath) property of [MapsShapeSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html). The value for the [ColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_ColorValuePath) property is the field name from the data source of the [MapsShapeSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html) which contains the color values.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' ShapeDataPath="Continent" ShapePropertyPath='new string[] {"continent"}' DataSource="ShapeColor" TValue="Data">
            <MapsShapeSettings ColorValuePath="Color"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code{
    public class Data
    {
        public string Continent { get; set; }
        public string Color { get; set; }
    };
    public List<Data> ShapeColor = new List<Data>{
        new Data { Continent= "North America", Color= "#71B081" },
        new Data { Continent= "South America", Color= "#5A9A77" },
        new Data { Continent= "Africa", Color= "#498770" },
        new Data { Continent= "Europe", Color= "#39776C" },
        new Data { Continent= "Asia", Color= "#266665" },
        new Data { Continent= "Australia", Color= "#124F5E" }
    };
}
```

![Blazor Maps with Custom Shape Color](./images/Customization/blazor-maps-custom-shape-color.PNG)

## Applying border to individual shapes

The border of each shape in the Maps can be customized using the [BorderColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_BorderColorValuePath) and [BorderWidthValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_BorderWidthValuePath) properties to modify the color and the width of the border respectively. The field name in the data source of the layer which contains the color and the width values must be set in the [BorderColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_BorderColorValuePath) and [BorderWidthValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_BorderWidthValuePath) properties respectively. If the values of [BorderColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_BorderColorValuePath) and [BorderWidthValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_BorderWidthValuePath) do not match with the field name from the data source, then the color and width of the border will be applied to the shapes using the border property in the shapeSettings.

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
    public List<Data> ShapeColor = new List<Data>{
        new Data { Continent= "North America", Color= "#71B081", Width=2 , BorderColor="#CCFFE5"},
        new Data { Continent= "South America", Color= "#5A9A77", Width=2 , BorderColor="red"},
        new Data { Continent= "Africa", Color= "#498770", Width=2 , BorderColor="#FFCC99"},
        new Data { Continent= "Europe", Color= "#39776C" , Width=2 , BorderColor="#66B2FF"},
        new Data { Continent= "Asia", Color= "#266665", Width=2 , BorderColor="#999900"},
        new Data { Continent= "Australia", Color= "#124F5E", Width=2 , BorderColor="blue"}
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

By default, the Maps are rendered by the **Mercator** projection type in which the Maps are rendered based on the coordinates. So, the Maps is not stretched. To change the type of projection in the Maps, the [ProjectionType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ProjectionType) property is used.

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