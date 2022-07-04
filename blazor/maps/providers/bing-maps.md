---
layout: post
title: Bing Maps in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about Bing Maps in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Bing Maps in Blazor Maps Component

Bing Maps is an online Maps provider, owned by Microsoft, for accessing the external geospatial imagery services for deep-zoom satellite view which is supported in the Blazor Maps component. This provides the ability to visualize satellite, aerial, and street Maps without using any external shape files. As like OSM, it provides Maps tile images based on the requests and combines those images into a single one to display Maps area.

## Adding Bing Maps

The Bing Maps can be rendered by setting the [UrlTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_UrlTemplate) property with the URL generated from the `GetBingUrlTemplate` method in the Maps component. The format of the required URL of Bing Maps varies from other map providers. As a result, a built-in `GetBingUrlTemplate` method has been included that returns the URL in a generic format. In the meantime, a subscription key is required for Bing Maps. Follow the steps in this [link](https://www.microsoft.com/en-us/maps/create-a-bing-maps-key) to generate an API key, then append it to the Bing Maps URL before passing it to the `GetBingUrlTemplate` method. The URL returned by this method must be passed to the `UrlTemplate` property.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer UrlTemplate="@UrlTemplate" TValue="string"></MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public string UrlTemplate;
    protected override async Task OnInitializedAsync()
    {
        UrlTemplate = await SfMaps.GetBingUrlTemplate("https://dev.virtualearth.net/REST/V1/Imagery/Metadata/RoadOnDemand?output=json&uriScheme=https&key=");
    }
}
```

> In the above URL passed to the `GetBingUrlTemplate` method, specify the Bing Maps key.

![Blazor Bing Maps](../images/MapProviders/blazor-bing-maps.png)

## Types of Bing Maps

Bing Maps provides different types of Maps and it can be viewed in the Maps component.

* **Aerial** - Displays satellite images to highlight roads and major landmarks for easy identification.
* **AerialWithLabelsOnDemand** - Displays aerial Maps with labels for the continent, country, ocean, etc.
* **Road** - Displays the default Maps view of roads, buildings, and geography.
* **CanvasDark** - Displays dark version of the road Maps.
* **CanvasLight** - Displays light version of the road Maps.
* **CanvasGray** - Displays grayscale version of the road Maps.

The above types can also be rendered in the Maps component by specifying their URL in the `UrlTemplate` property in the `MapsLayer` class. You can learn more about the available types and the URL for it by visiting the official websites of Bing Maps.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer UrlTemplate="@UrlTemplate" TValue="string"></MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public string UrlTemplate;
    protected override async Task OnInitializedAsync()
    {
        UrlTemplate = await SfMaps.GetBingUrlTemplate("https://dev.virtualearth.net/REST/V1/Imagery/Metadata/CanvasGray?output=json&uriScheme=https&key=");
    }
}
```

> In the above URL passed to the `GetBingUrlTemplate` method, specify the Bing Maps key.

![Blazor Bing Maps with CanvasLight](../images/MapProviders/blazor-bing-maps-with-canvas.png)

## Enable zooming and panning

Bing Maps layer can be zoomed and panned. Zooming helps to get a closer look at a particular area on Maps for in-depth analysis. Panning helps to move Maps around to focus the targeted area.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    @* To zoom and pan *@
    <MapsZoomSettings Enable="true">
        <MapsZoomToolbarSettings>
            <MapsZoomToolbarButton ToolbarItems="new List<ToolbarItem>() { ToolbarItem.Zoom, ToolbarItem.ZoomIn, ToolbarItem.ZoomOut,
            ToolbarItem.Pan, ToolbarItem.Reset }"></MapsZoomToolbarButton>
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer UrlTemplate="@UrlTemplate" TValue="string"></MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public string UrlTemplate;
    protected override async Task OnInitializedAsync()
    {
        UrlTemplate = await SfMaps.GetBingUrlTemplate("https://dev.virtualearth.net/REST/V1/Imagery/Metadata/RoadOnDemand?output=json&uriScheme=https&key=");
    }
}
```

> In the above URL passed to the `GetBingUrlTemplate` method, specify the Bing Maps key.

![Blazor Bing Maps with Zooming](../images/MapProviders/blazor-bing-maps-zooming.png)

## Adding markers and navigation line

Markers can be added to the layers of Bing Maps by setting the corresponding location's coordinates of latitude and longitude using [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html). Navigation lines can be added on top of an Bing Maps layer for highlighting a path among various places by setting the corresponding location's coordinates of latitude and longitude in the [MapsNavigationLine](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsZoomSettings ZoomFactor="4"></MapsZoomSettings>
    <MapsCenterPosition Latitude="29.394708" Longitude="-94.954653"></MapsCenterPosition>
    <MapsLayers>
        <MapsLayer UrlTemplate="@UrlTemplate" TValue="string">
            @* Add marker *@
            <MapsMarkerSettings>
                <MapsMarker Visible="true" Height="25" Width="15" DataSource="Cities" TValue="City">
                </MapsMarker>
            </MapsMarkerSettings>
            @* Add navigation line *@
            <MapsNavigationLines>
                <MapsNavigationLine Visible="true" Color="blue" Angle="0.1" Latitude="new double[]{34.060620, 40.724546}"
                                    Longitude="new double[]{-118.330491,-73.850344}">
                </MapsNavigationLine>
            </MapsNavigationLines>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    }
    private List<City> Cities = new List<City> {
        new City { Latitude = 34.060620, Longitude = -118.330491,  Name="California" },
        new City{ Latitude = 40.724546, Longitude = -73.850344,  Name="New York"}
    };
    public string UrlTemplate;
    protected override async Task OnInitializedAsync()
    {
        UrlTemplate = await SfMaps.GetBingUrlTemplate("https://dev.virtualearth.net/REST/V1/Imagery/Metadata/RoadOnDemand?output=json&uriScheme=https&key=");
    }
}
```

> In the above URL passed to the `GetBingUrlTemplate` method, specify the Bing Maps key.

![Blazor Bing Maps with Markers and Navigation Line](../images/MapProviders/blazor-bing-maps-marker-and-line.png)

## Adding sublayer

Any GeoJSON shape can be rendered as a sublayer on top of the Bing Maps layer for highlighting a particular continent or country in Bing Maps by adding another layer and specifying the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_Type) of [MapsLayer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html) to **SubLayer**.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer UrlTemplate="@UrlTemplate" TValue="string"></MapsLayer>
        @* To add geometry shape as sublayer *@
        <MapsLayer ShapeData='new {dataOptions = "https://cdn.syncfusion.com/maps/map-data/africa.json"}'
                   Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
            <MapsShapeSettings Fill="blue"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public string UrlTemplate;
    protected override async Task OnInitializedAsync()
    {
        UrlTemplate = await SfMaps.GetBingUrlTemplate("https://dev.virtualearth.net/REST/V1/Imagery/Metadata/CanvasGray?output=json&uriScheme=https&key=");
    }
}
```

> In the above URL passed to the `GetBingUrlTemplate` method, specify the Bing Maps key.

![Blazor Bing Maps with Sublayer](../images/blazor-bing-map-sublayer.PNG)

## Enable legend

The legend can be added to the tile Maps by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLegendSettings.html#Syncfusion_Blazor_Maps_MapsLegendSettings_Visible) property of [MapsLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLegendSettings.html) to **true**.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps Format="N0" UseGroupingSeparator="true">
    <MapsZoomSettings Enable="true">
        <MapsZoomToolbarSettings>
            <MapsZoomToolbarTooltipSettings FontFamily="inherit"></MapsZoomToolbarTooltipSettings>
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
    <MapsLegendSettings Visible="true" Position="LegendPosition.Float" Height="123px" Width="200px" Type="LegendType.Markers" X="10" Y="247" Background="#E6E6E6" ShapePadding="10">
        <MapsLegendTextStyle FontFamily="inherit" Color="#000000" />
    </MapsLegendSettings>
    <MapsTitleSettings Text="Top 10 populated cities in the World">
        <MapsTitleTextStyle Size="16px" FontFamily="inherit" />
    </MapsTitleSettings>
    <MapsLayers>
        <MapsLayer UrlTemplate="@UrlTemplate" TValue="string">
        <MapsMarkerSettings>
                <MapsMarker Visible="true" TValue="PopulationCityDetails" DataSource="@PopulatedCities" Shape="MarkerType.Circle" Fill="#FFFFFF" ColorValuePath="Color" LegendText="Name" Height="15" Width="15">
                    <MapsMarkerTooltipSettings Visible="true" ValuePath="Population" Format="City Name: ${Name}</br>Population: ${Population} million">
                        <MapsMarkerTooltipTextStyle FontFamily="inherit"></MapsMarkerTooltipTextStyle>
                    </MapsMarkerTooltipSettings>
                </MapsMarker>
            </MapsMarkerSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code{
    public class PopulationCityDetails
    {        
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Population { get; set; }
        public string Color { get; set; }
    };
    public List<PopulationCityDetails> PopulatedCities = new List<PopulationCityDetails> {
        new PopulationCityDetails { Name ="Tokyo", Latitude= 35.6805245924747, Longitude= 139.76770396213337, Population= 37435191, Color="#2EB6C8"},
        new PopulationCityDetails { Name ="Delhi", Latitude= 28.644800, Longitude= 77.216721, Population= 29399141, Color="#4A97F4"},
        new PopulationCityDetails { Name ="Shanghai", Latitude= 31.224361, Longitude= 121.469170, Population= 26317104, Color="#498082"},
        new PopulationCityDetails { Name ="Sao Paulo", Latitude= -23.550424484747914, Longitude= -46.646471636488315, Population= 21846507, Color="#FB9E67"},
        new PopulationCityDetails { Name ="Mexico City", Latitude= 19.427402397418774, Longitude= -99.131123716666, Population= 21671908, Color="#8F9DE3"},
        new PopulationCityDetails { Name ="Cairo ", Latitude= 30.033333, Longitude= 31.233334, Population= 20484965, Color="#7B9FB0"},
        new PopulationCityDetails { Name ="Dhaka", Latitude= 23.777176, Longitude= 90.399452, Population= 20283552, Color="#4DB647"},
        new PopulationCityDetails { Name ="Mumbai", Latitude= 19.08492049646163, Longitude= 72.87449446319248, Population= 20185064, Color="#30BEFF"},
        new PopulationCityDetails { Name ="Beijing", Latitude= 39.90395970055848, Longitude= 116.38831272088059, Population= 20035455, Color="#Ac72AD"},
        new PopulationCityDetails { Name ="Osaka", Latitude= 34.69024500601642, Longitude= 135.50746225677142, Population= 19222665, Color="#EFE23E"}
    };
    public string UrlTemplate;
    protected override async Task OnInitializedAsync()
    {
        UrlTemplate = await SfMaps.GetBingUrlTemplate("https://dev.virtualearth.net/REST/V1/Imagery/Metadata/RoadOnDemand?output=json&uriScheme=https&key=AuQazZ3PUo3p2_c2KPhqMku-iKvee5fKcRREIg46MENqVTM9dp2ZyTbrHJpR9esZ");
    }
}

```

![Blazor Bing Maps with Legend](../images/MapProviders/blazor-bing-map-legend.png)