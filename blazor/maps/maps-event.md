---
layout: post
title: Events in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about the events in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Events in Blazor Maps Component
 
This section explains the list of events that will be triggered for appropriate actions in Maps. The events should be provided to the Maps using the [MapsEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html).

## AnimationCompleted

When the animation in the component is completed, the [AnimationCompleted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_AnimationCompleted) event will be triggered. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.AnimationCompleteEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents AnimationCompleted="@AnimationEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
           TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void AnimationEvent(Syncfusion.Blazor.Maps.AnimationCompleteEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## AnnotationRendering

Before the annotation is rendered in the Maps, the [AnnotationRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_AnnotationRendering) event will be triggered. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.AnnotationRenderingEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents AnnotationRendering="@AnnotationRenderingEvent"></MapsEvents>
    <MapsAnnotations>
        <MapsAnnotation X="20%" Y="10%" ZIndex="-1" VerticalAlignment="AnnotationAlignment.Center" HorizontalAlignment="AnnotationAlignment.Center">
            <ContentTemplate>
                <div>
                    <div id="first"><h1>Maps</h1></div>
                </div>
            </ContentTemplate>
        </MapsAnnotation>
    </MapsAnnotations>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
           TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void AnnotationRenderingEvent(Syncfusion.Blazor.Maps.AnnotationRenderingEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## BubbleRendering

The [BubbleRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_BubbleRendering) event is triggered before rendering each bubble. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.BubbleRenderingEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents BubbleRendering="@BubbleRenderingEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' DataSource="PopulationDetails"
                   ShapeDataPath="Name" ShapePropertyPath='new string[] {"name"}' TValue="Country">
            @* To add bubbles based on population count *@
            <MapsBubbleSettings>
                <MapsBubble Visible="true" ValuePath="Population" ColorValuePath="Color" DataSource="PopulationDetails" TValue="Country">
                </MapsBubble>
            </MapsBubbleSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code{
    public class Country
    {
        public string Name { get; set; }
        public double Population { get; set; }
        public string Color { get; set; }
    };
    private List<Country> PopulationDetails = new List<Country> {
       new Country
       {
           Name ="United States", Population = 325020000, Color = "#b5e485"
       },
       new Country
       {
           Name = "Russia", Population = 142905208, Color = "#7bc1e8"
       },
       new Country
        {
           Name="India", Population=1198003000, Color = "#df819c"
        }
    };

    void BubbleRenderingEvent(Syncfusion.Blazor.Maps.BubbleRenderingEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## DataLabelRendering

The [DataLabelRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_DataLabelRendering) event is triggered before rendering each label. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.LabelRenderingEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsEvents DataLabelRendering="@DataLabelRenderingEvent"></MapsEvents>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            @* To add data labels *@
            <MapsDataLabelSettings Visible="true" LabelPath="name"></MapsDataLabelSettings>
            <MapsShapeSettings Autofill="true"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void DataLabelRenderingEvent(Syncfusion.Blazor.Maps.LabelRenderingEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## LayerRendering

The [LayerRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_LayerRendering) event is triggered before rendering each layer. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.LayerRenderingEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents LayerRendering="@LayerRenderingEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void LayerRenderingEvent(Syncfusion.Blazor.Maps.LayerRenderingEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## LegendRendering

The [LegendRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_LegendRendering) event is triggered before rendering the legend in the component. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.LegendRenderingEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents LegendRendering="@LegendRenderingEvent"></MapsEvents>
    @*  To set legend mode as interactive  *@
    <MapsLegendSettings Visible="true" Mode="LegendMode.Interactive">
    </MapsLegendSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' ShapeDataPath="Name"
                   DataSource="SecurityCouncilDetails" ShapePropertyPath='new string[] {"name"}' TValue="UNCouncilCountry">
            <MapsShapeSettings ColorValuePath="Membership">
                <MapsShapeColorMappings>
                    <MapsShapeColorMapping Value="Permanent" Color='new string[] {"#D84444"}' />
                    <MapsShapeColorMapping Value="Non-Permanent" Color='new string[] {"#316DB5"}' />
                </MapsShapeColorMappings>
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    private List<UNCouncilCountry> SecurityCouncilDetails = new List<UNCouncilCountry>{
         new UNCouncilCountry { Name= "China", Membership= "Permanent"},
         new UNCouncilCountry { Name= "France", Membership= "Permanent" },
         new UNCouncilCountry { Name= "Russia", Membership= "Permanent"},
         new UNCouncilCountry { Name= "Kazakhstan", Membership= "Non-Permanent"},
         new UNCouncilCountry { Name= "Poland", Membership= "Non-Permanent"},
         new UNCouncilCountry { Name= "Sweden", Membership= "Non-Permanent"},
         new UNCouncilCountry { Name= "United Kingdom", Membership= "Permanent"},
         new UNCouncilCountry { Name= "United States", Membership= "Permanent"}
    };

    public class UNCouncilCountry
    {
        public string Name { get; set; }
        public string Membership { get; set; }
    };
    public void LegendRenderingEvent(Syncfusion.Blazor.Maps.LegendRenderingEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Loaded

The [Loaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_Loaded) event is triggered after the Maps component has been loaded. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.LoadedEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps
<SfMaps>

    <MapsEvents Loaded="@LoadedEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void LoadedEvent(Syncfusion.Blazor.Maps.LoadedEventArgs args)
    {
       // Here you can customize your code
    }
}
```

## MarkerRendering

The [MarkerRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_MarkerRendering) event is triggered before rendering each marker. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MarkerRenderingEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents MarkerRendering="@MarkerRenderingEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="California" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="NewYork" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="Iowa" Height="25" Width="15" TValue="City"></MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    };
    public List<City> California = new List<City> {
        new City {Latitude=35.145083,Longitude=-117.960260}
    };
    public List<City> NewYork = new List<City> {
        new City { Latitude=40.724546, Longitude=-73.850344 }
    };
    public List<City> Iowa = new List<City> {
        new City {Latitude= 41.657782, Longitude=-91.533857}
    };
    public void MarkerRenderingEvent(Syncfusion.Blazor.Maps.MarkerRenderingEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## MarkerClusterClick

The [MarkerClusterClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_MarkerClusterClick) event is triggered after clicking the marker cluster. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MarkerClusterClickEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents MarkerClusterClick="@MarkerClusterClickEvent"></MapsEvents>
    <MapsZoomSettings Enable="true"></MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="LargestCities" Height="25" Width="15" TValue="City">
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsMarkerClusterSettings AllowClustering="true" Shape="MarkerType.Circle" Fill="#008CFF" Height="25" Width="25">
                <MapsLayerMarkerClusterLabelStyle Color="white"></MapsLayerMarkerClusterLabelStyle>
            </MapsMarkerClusterSettings>
            <MapsShapeSettings Fill="lightgray">
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
    };
    private List<City> LargestCities = new List<City> {
        new City { Latitude=40.6971494, Longitude= -74.2598747, Name="New York", Area=8683 },
        new City { Latitude=40.0024137, Longitude= -75.2581194, Name="Philadelphia", Area=4661 },
        new City { Latitude=42.3142647, Longitude= -71.11037, Name="Boston", Area=4497 },
        new City { Latitude=42.3526257, Longitude= -83.239291, Name="Detroit", Area=3267 },
        new City { Latitude=47.2510905, Longitude= -123.1255834, Name="Washington", Area=2996 },
        new City { Latitude=25.7823907, Longitude= -80.2994995, Name="Miami", Area=2891 },
        new City { Latitude=19.3892246, Longitude= -70.1305136, Name="San Juan", Area=2309 }
    };
    public void MarkerClusterClickEvent(Syncfusion.Blazor.Maps.MarkerClusterClickEventArgs args)
    {
       // Here you can customize your code
    }
}
```

## MarkerClusterMouseMove

The [MarkerClusterMouseMove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_MarkerClusterMouseMove) event will be triggered when the cursor moves over the marker cluster. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MarkerClusterMoveEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents MarkerClusterMouseMove="@MarkerClusterMouseMoveEvent"></MapsEvents>
    <MapsZoomSettings Enable="true"></MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="LargestCities" Height="25" Width="15" TValue="City">
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsMarkerClusterSettings AllowClustering="true" Shape="MarkerType.Circle" Fill="#008CFF" Height="25" Width="25">
                <MapsLayerMarkerClusterLabelStyle Color="white"></MapsLayerMarkerClusterLabelStyle>
            </MapsMarkerClusterSettings>
            <MapsShapeSettings Fill="lightgray">
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
    };
    private List<City> LargestCities = new List<City> {
        new City { Latitude=40.6971494, Longitude= -74.2598747, Name="New York", Area=8683 },
        new City { Latitude=40.0024137, Longitude= -75.2581194, Name="Philadelphia", Area=4661 },
        new City { Latitude=42.3142647, Longitude= -71.11037, Name="Boston", Area=4497 },
        new City { Latitude=42.3526257, Longitude= -83.239291, Name="Detroit", Area=3267 },
        new City { Latitude=47.2510905, Longitude= -123.1255834, Name="Washington", Area=2996 },
        new City { Latitude=25.7823907, Longitude= -80.2994995, Name="Miami", Area=2891 },
        new City { Latitude=19.3892246, Longitude= -70.1305136, Name="San Juan", Area=2309 }
    };
    public void MarkerClusterMouseMoveEvent(Syncfusion.Blazor.Maps.MarkerClusterMoveEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## MouseMove

The [MouseMove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_MouseMove) event is triggered when the mouse pointer moves over the map. To learn more about the arguments for this event, refer to the documentation [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MouseMoveEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents MouseMove="@MouseMoveEvent"></MapsEvents>
    <MapsZoomSettings Enable="true"></MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="LargestCities" Height="25" Width="15" TValue="City">
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsMarkerClusterSettings AllowClustering="true" Shape="MarkerType.Circle" Fill="#008CFF" Height="25" Width="25">
                <MapsLayerMarkerClusterLabelStyle Color="white"></MapsLayerMarkerClusterLabelStyle>
            </MapsMarkerClusterSettings>
            <MapsShapeSettings Fill="lightgray">
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
    };
    private List<City> LargestCities = new List<City> {
        new City { Latitude=40.6971494, Longitude= -74.2598747, Name="New York", Area=8683 },
        new City { Latitude=40.0024137, Longitude= -75.2581194, Name="Philadelphia", Area=4661 },
        new City { Latitude=42.3142647, Longitude= -71.11037, Name="Boston", Area=4497 },
        new City { Latitude=42.3526257, Longitude= -83.239291, Name="Detroit", Area=3267 },
        new City { Latitude=47.2510905, Longitude= -123.1255834, Name="Washington", Area=2996 },
        new City { Latitude=25.7823907, Longitude= -80.2994995, Name="Miami", Area=2891 },
        new City { Latitude=19.3892246, Longitude= -70.1305136, Name="San Juan", Area=2309 }
    };
    public void MouseMoveEvent(Syncfusion.Blazor.Maps.MouseMoveEventArgs  args)
    {
        // Here you can customize your code
    }
}
```

## OnBubbleClick

The [OnBubbleClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_MarkerClusterMouseMove) event will be triggered when clicking on the bubbles. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.BubbleClickEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents OnBubbleClick="@OnBubbleClickEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' DataSource="PopulationDetails"
                   ShapeDataPath="Name" ShapePropertyPath='new string[] {"name"}' TValue="Country">
            @* To add bubbles based on population count *@
            <MapsBubbleSettings>
                <MapsBubble Visible="true" ValuePath="Population" ColorValuePath="Color" DataSource="PopulationDetails" TValue="Country">
                </MapsBubble>
            </MapsBubbleSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code{
    public class Country
    {
        public string Name { get; set; }
        public double Population { get; set; }
        public string Color { get; set; }
    };
    private List<Country> PopulationDetails = new List<Country> {
       new Country
       {
           Name ="United States", Population = 325020000, Color = "#b5e485"
       },
       new Country
       {
           Name = "Russia", Population = 142905208, Color = "#7bc1e8"
       },
       new Country
       {
           Name="India", Population=1198003000, Color = "#df819c"
       }
    };

    public void OnBubbleClickEvent(Syncfusion.Blazor.Maps.BubbleClickEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnBubbleMouseMove

The [OnBubbleMouseMove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnBubbleMouseMove) event will be triggered when the cursor moves over the bubbles. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.BubbleMoveEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents OnBubbleMouseMove="@OnBubbleMouseMoveEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' DataSource="PopulationDetails"
                   ShapeDataPath="Name" ShapePropertyPath='new string[] {"name"}' TValue="Country">
            @* To add bubbles based on population count *@
            <MapsBubbleSettings>
                <MapsBubble Visible="true" ValuePath="Population" ColorValuePath="Color" DataSource="PopulationDetails" TValue="Country">
                </MapsBubble>
            </MapsBubbleSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code{
    public class Country
    {
        public string Name { get; set; }
        public double Population { get; set; }
        public string Color { get; set; }
    };
    private List<Country> PopulationDetails = new List<Country> {
       new Country
       {
           Name ="United States", Population = 325020000, Color = "#b5e485"
       },
       new Country
       {
           Name = "Russia", Population = 142905208, Color = "#7bc1e8"
       },
       new Country
       {
           Name="India", Population=1198003000, Color = "#df819c"
       }
    };
    public void OnBubbleMouseMoveEvent(Syncfusion.Blazor.Maps.BubbleMoveEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnClick

The [OnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnClick) event will be triggered after the Maps is clicked. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MouseEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents OnClick="@OnClickEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {

    public void OnClickEvent(Syncfusion.Blazor.Maps.MouseEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnDoubleClick

When performing the double click operation on an element in Maps, the [OnDoubleClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnDoubleClick) will be triggered. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MouseEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents OnDoubleClick="@OnDoubleClickEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void OnDoubleClickEvent(Syncfusion.Blazor.Maps.MouseEventArgs args)
    {
      // Here you can customize your code
    }
}
```

## OnItemHighlight

The [OnItemHighlight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnItemHighlight) event occurs when the cursor moves over the shapes. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SelectionEventArgs.html).

@using Syncfusion.Blazor.Maps

```cshtml
<SfMaps>
    <MapsEvents OnItemHighlight="@OnItemHighlightEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsLayerHighlightSettings Enable="true" Fill="green">
                <MapsLayerHighlightBorder Color="white" Width="2"></MapsLayerHighlightBorder>
            </MapsLayerHighlightSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void OnItemHighlightEvent(Syncfusion.Blazor.Maps.SelectionEventArgs args)
    {
       // Here you can customize your code
    }
}
```

## OnItemSelect

The [OnItemSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnItemSelect) event occurs when selecting the shapes in the Maps. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SelectionEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents OnItemSelect="@OnItemSelectEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsLayerSelectionSettings Enable="true" Fill="green">
                <MapsLayerSelectionBorder Color="White" Width="2"></MapsLayerSelectionBorder>
            </MapsLayerSelectionSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void OnItemSelectEvent(Syncfusion.Blazor.Maps.SelectionEventArgs args)
    {
         // Here you can customize your code
    }
}
```

## OnLoad

[OnLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnLoad) event will be triggered before rendering the Maps. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.LoadEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps
<SfMaps>
    <MapsEvents OnLoad="@OnLoadEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void OnLoadEvent(Syncfusion.Blazor.Maps.LoadEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnMarkerClick

[OnMarkerClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnMarkerClick) event will be triggered by clicking the markers in the Maps. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MarkerClickEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents OnMarkerClick="@OnMarkerClickEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="California" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="NewYork" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="Iowa" Height="25" Width="15" TValue="City"></MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    };
    public List<City> California = new List<City> {
        new City {Latitude=35.145083,Longitude=-117.960260}
    };
    public List<City> NewYork = new List<City> {
        new City { Latitude=40.724546, Longitude=-73.850344 }
    };
    public List<City> Iowa = new List<City> {
        new City {Latitude= 41.657782, Longitude=-91.533857}
    };
    public void OnMarkerClickEvent(Syncfusion.Blazor.Maps.MarkerClickEventArgs args)
    {
       // Here you can customize your code
    }
}
```

## OnMarkerMouseLeave

The [OnMarkerMouseLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnMarkerMouseMove) event is triggered when the cursor moves away from the marker. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MarkerMoveEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents OnMarkerMouseLeave="@OnMarkerMouseLeaveEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="California" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="NewYork" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="Iowa" Height="25" Width="15" TValue="City"></MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    };
    public List<City> California = new List<City> {
        new City {Latitude=35.145083,Longitude=-117.960260}
    };
    public List<City> NewYork = new List<City> {
        new City { Latitude=40.724546, Longitude=-73.850344 }
    };
    public List<City> Iowa = new List<City> {
        new City {Latitude= 41.657782, Longitude=-91.533857}
    };
    public void OnMarkerMouseLeaveEvent(Syncfusion.Blazor.Maps.MarkerMoveEventArgs args)
    {
       // Here you can customize your code
    }
}
```

## OnMarkerMouseMove

The [OnMarkerMouseMove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnMarkerMouseMove) event is triggered when the cursor moves over the marker. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MarkerMoveEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents OnMarkerMouseMove="@OnMarkerMouseMoveEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="California" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="NewYork" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="Iowa" Height="25" Width="15" TValue="City"></MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    };
    public List<City> California = new List<City> {
        new City {Latitude=35.145083,Longitude=-117.960260}
    };
    public List<City> NewYork = new List<City> {
        new City { Latitude=40.724546, Longitude=-73.850344 }
    };
    public List<City> Iowa = new List<City> {
        new City {Latitude= 41.657782, Longitude=-91.533857}
    };
    public void OnMarkerMouseMoveEvent(Syncfusion.Blazor.Maps.MarkerMoveEventArgs args)
    {
       // Here you can customize your code
    }
}
```

## OnPan

When panning the Maps, the [OnPan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnPan) event will be triggered. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnPan).

```cshtml
@using Syncfusion.Blazor.Maps
<SfMaps>
    <MapsZoomSettings Enable="true" EnablePanning="true">
        <MapsZoomToolbarSettings Orientation="Orientation.Vertical">
            <MapsZoomToolbarButton ToolbarItems="new List<ToolbarItem>() { ToolbarItem.Zoom, ToolbarItem.ZoomIn, ToolbarItem.ZoomOut, ToolbarItem.Pan, ToolbarItem.Reset }"></MapsZoomToolbarButton>
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
    <MapsEvents OnPan="@OnPanEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void OnPanEvent(Syncfusion.Blazor.Maps.MapPanEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnPanComplete

The [OnPanComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnPanComplete) event will be triggered after panning the Maps. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnPanComplete).

```cshtml
@using Syncfusion.Blazor.Maps
<SfMaps>
    <MapsZoomSettings Enable="true" EnablePanning="true">
        <MapsZoomToolbarSettings Orientation="Orientation.Vertical">
            <MapsZoomToolbarButton ToolbarItems="new List<ToolbarItem>() { ToolbarItem.Zoom, ToolbarItem.ZoomIn, ToolbarItem.ZoomOut, ToolbarItem.Pan, ToolbarItem.Reset }"></MapsZoomToolbarButton>
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
    <MapsEvents OnPanComplete="@OnPanCompleteEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void OnPanCompleteEvent(Syncfusion.Blazor.Maps.MapPanEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnPrint

The [OnPrint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnPrint) event will be triggered before the print operation is started. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.PrintEventArgs.html).

```cshtml
<button @onclick="PrintMap">Print</button>

@using Syncfusion.Blazor.Maps
<SfMaps @ref="maps" AllowPrint="true">
    <MapsEvents OnPrint="@GetGEOLocation"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;
    public async Task PrintMap()
    {
        // using Maps component reference call 'Print' method
        await this.maps.PrintAsync();
    }
    public void GetGEOLocation(Syncfusion.Blazor.Maps.PrintEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnRightClick

The [OnRightClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnRightClick) event will be triggered when performing the right click operation on an element in Maps. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MouseEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents OnRightClick="@OnRightClickEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {

    public void OnRightClickEvent(Syncfusion.Blazor.Maps.MouseEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnZoom

The [OnZoom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnZoom) event will be triggered before zooming-in or zooming-out the Maps. This event is also triggered when the [ZoomByPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomByPosition_Syncfusion_Blazor_Maps_MapsCenterPosition_System_Double_) and [ZoomToCoordinates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomToCoordinates_System_Double_System_Double_System_Double_System_Double_) methods are called.To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapZoomEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps
<SfMaps>
    <MapsZoomSettings Enable="true">
        <MapsZoomToolbarSettings Orientation="Orientation.Vertical">
            <MapsZoomToolbarButton ToolbarItems="new List<ToolbarItem>() { ToolbarItem.Zoom, ToolbarItem.ZoomIn, ToolbarItem.ZoomOut, ToolbarItem.Pan, ToolbarItem.Reset }"></MapsZoomToolbarButton>
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
    <MapsEvents OnZoom="@OnZoomEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void OnZoomEvent(Syncfusion.Blazor.Maps.MapZoomEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnZoomComplete

The [OnZoomComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnZoomComplete) event will be triggered after performing zooming operation. This event is also triggered when the [ZoomByPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomByPosition_Syncfusion_Blazor_Maps_MapsCenterPosition_System_Double_) and [ZoomToCoordinates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomToCoordinates_System_Double_System_Double_System_Double_System_Double_) methods are called. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapZoomEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps
<SfMaps>
    <MapsZoomSettings Enable="true">
        <MapsZoomToolbarSettings Orientation="Orientation.Vertical">
            <MapsZoomToolbarButton ToolbarItems="new List<ToolbarItem>() { ToolbarItem.Zoom, ToolbarItem.ZoomIn, ToolbarItem.ZoomOut, ToolbarItem.Pan, ToolbarItem.Reset }"></MapsZoomToolbarButton>
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
    <MapsEvents OnZoomComplete="@OnZoomCompleteEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void OnZoomCompleteEvent(Syncfusion.Blazor.Maps.MapZoomEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Resizing

The [Resizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_Resizing) event will be triggered when resizing the Maps. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.ResizeEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps
<SfMaps>
    <MapsEvents Resizing="@ResizingEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void ResizingEvent(Syncfusion.Blazor.Maps.ResizeEventArgs args)
    {
       // Here you can customize your code
    }
}
```

## ShapeHighlighted

The [ShapeHighlighted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_ShapeHighlighted) event is triggered when mouse move on the shape in Maps and before the shape gets highlighted. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.ShapeSelectedEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents ShapeHighlighted="@ShapeHighlightedEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsLayerHighlightSettings Enable="true" Fill="green">
                <MapsLayerHighlightBorder Color="white" Width="2"></MapsLayerHighlightBorder>
            </MapsLayerHighlightSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void ShapeHighlightedEvent(Syncfusion.Blazor.Maps.ShapeSelectedEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## ShapeRendering

The [ShapeRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_ShapeRendering) event will be triggered before rendering a shape of the Maps. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.ShapeRenderingEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents ShapeRendering="@ShapeRenderingEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void ShapeRenderingEvent(Syncfusion.Blazor.Maps.ShapeRenderingEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## ShapeSelected

The [ShapeSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_ShapeSelected) event is triggered when a shape is selected in Maps. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.ShapeSelectedEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents ShapeSelected="@ShapeSelectedEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsLayerSelectionSettings Enable="true" Fill="green">
                <MapsLayerSelectionBorder Color="White" Width="2"></MapsLayerSelectionBorder>
            </MapsLayerSelectionSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void ShapeSelectedEvent(Syncfusion.Blazor.Maps.ShapeSelectedEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## TooltipRendering

The [TooltipRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_TooltipRendering) event is triggered before the tooltip gets rendered. To know more about the arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.TooltipRenderEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsEvents TooltipRendering="@TooltipRenderingEvent"></MapsEvents>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsLayerTooltipSettings Visible="true" ValuePath="name"></MapsLayerTooltipSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public void TooltipRenderingEvent(Syncfusion.Blazor.Maps.TooltipRenderEventArgs args)
    {
       // Here you can customize your code
    }
}
```