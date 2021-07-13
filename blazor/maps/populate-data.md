# Populate Data

This section explains how to populate data inputs and provide it to the Maps component.

## Shape data

The shape data collection describes geographical shape information that can be obtained from [GeoJSON format shapes](http://files2.syncfusion.com/dtsupport/uploads/user/uploads/Maps_GeoJSON.zip). The maps shapes are rendered with this data. You can also add custom shapes such as seat selection in bus, seat selection in cricket stadium, and more useful information besides geographical data.

## Data source

The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_DataSource) property is used to represent statistical data in the Maps component, and it accepts a collection of values as input. For example, you can provide a list of objects as input. This data source will be further used to color the map, display data labels, display tooltips, and more.

```csharp
@code{
    public class PopulationDetail
    {
        public string Code { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }
        public double Density { get; set; }
    };
    private List<PopulationDetail> PopulationDetails = new List<PopulationDetail> {
        new PopulationDetail {
            Code = "AF",
            Value= 53,
            Name= "Afghanistan",
            Population= 29863010,
            Density= 119
        },
        new PopulationDetail {
            Code= "AL",
            Value= 117,
            Name= "Albania",
            Population= 3195000,
            Density= 111
        },
        new PopulationDetail {
            Code= "DZ",
            Value= 15,
            Name= "Algeria",
            Population= 34895000,
            Density= 15
        }
    };
}
```

## Data binding

The following properties in the [`MapsLayer`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Maps.MapsLayer.html) are used for binding data in the Maps component. Both the properties are related to each other.

* ShapePropertyPath
* ShapeDataPath

<b>Shape property path</b>

The [`ShapePropertyPath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_ShapePropertyPath) property is used to refer the field name in the [`ShapeData`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_ShapeData) property of shape layers to identify the shape.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
            ShapePropertyPath='new string[] {"name"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

> `world-map.json` file contains following data and its field 'name' value is used to map the corresponding shape with our statistical data.

```json
[
    {
        "type": "Feature",
        "properties": {
            "admin": "Afghanistan",
            "name": "Afghanistan",
            "continent": "Asia"
        },
        "geometry": { "type": "Polygon", "coordinates": [[[61.21081709172573, ...
    },
...
]
```

<b>Shape data path</b>

The [`ShapeDataPath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_ShapeDataPath) property is similar to the [`ShapePropertyPath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_ShapePropertyPath) property, but it refers the field name in `DataSource` property value.
For example, following population data contains field 'Name', 'Population' and 'Density'. Here the 'Name' field is set to the `ShapeDataPath` to map the corresponding name field value of shape data.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
            DataSource="PopulationDetails" ShapePropertyPath='new string[] {"name"}'
            ShapeDataPath="Name" TValue="PopulationDetail">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code{
    public class PopulationDetail
    {
        public string Name { get; set; }
        public double Population { get; set; }
        public double Density { get; set; }
    };
    private List<PopulationDetail> PopulationDetails = new List<PopulationDetail> {
        new PopulationDetail {
            Name= "Afghanistan",
            Population= 29863010,
            Density= 119
        },
        ...
    };
}
```

In the above example, both 'name' fields contain the same value as 'Afghanistan', this value is matched in both shape data and statistical data, so that the details associated with 'Afghanistan' will be mapped to the corresponding shape and used to color the corresponding shape, display data labels, display tooltips, and more.

When values of the [`ShapeDataPath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_ShapeDataPath) property in the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_DataSource) and [`ShapePropertyPath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_ShapePropertyPath) in the [`ShapeData`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_ShapeData) match, then the associated object from the DataSource is bound to the corresponding shape.

Refer both shape data and data source as demonstrated in the following code example.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
            DataSource="PopulationDetails"
            ShapeDataPath="Name"
            ShapePropertyPath='new string[] {"name"}' TValue="PopulationDetail">
            @*  It display data label for bounded items  *@
            <MapsDataLabelSettings Visible="true" LabelPath="Name"></MapsDataLabelSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code{
    public class PopulationDetail
    {
        public string Code { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }
        public double Density { get; set; }
    };
    private List<PopulationDetail> PopulationDetails = new List<PopulationDetail> {
        new PopulationDetail {
            Code = "AF",
            Value= 53,
            Name= "Afghanistan",
            Population= 29863010,
            Density= 119
        },
        new PopulationDetail {
            Code= "AL",
            Value= 117,
            Name= "Albania",
            Population= 3195000,
            Density= 111
        },
        new PopulationDetail {
            Code= "DZ",
            Value= 15,
            Name= "Algeria",
            Population= 34895000,
            Density= 15
        }
    };
}
```

> You can also set the [`MapsDataLabelSettings`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html) property to display the bound items.

![Maps with data source](./images/populatedata/Populatedata.png)

## Fetching data from JSON file

You can also read the JSON file data, convert it to the C# object, and assign it to the Maps component's [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_DataSource) property.

Refer to the following code sample for fetching  data from JSON file.

The `Http.GetJsonAsync` is used in the 'OnInitAsync' lifecycle method to load JSON file data. As this will be executed asynchronously, check whether 'populationDensity' is available, render the Maps component, or display the loading statement.

```csharp
@inject HttpClient Http;
@using Syncfusion.Blazor.Maps

@if (PopulationDensity == null)
{
    <p><em>Loading Maps component...</em></p>
}
else
{
    <SfMaps>
        <MapsLayers>
            <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
                       DataSource="PopulationDensity"
                       ShapeDataPath="Name"
                       ShapePropertyPath='new string[] {"name"}' TValue="PopulationData">
                <MapsDataLabelSettings Visible="true" LabelPath="Name"></MapsDataLabelSettings>
            </MapsLayer>
        </MapsLayers>
    </SfMaps>
}
@code{
    PopulationData[] PopulationDensity;
    protected override async Task OnInitAsync()
    {
        PopulationDensity = await Http.GetJsonAsync<PopulationDensity[]>("sample-data/PopulationDensity.json");
    }

    public class PopulationData
    {
        public string Code { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }
        public float Density { get; set; }
    }
}
```

Here, the `PopulationDensity.json` file contains following data.

```json
[
        {
            "code": "AF",
            "value": 53,
            "name": "Afghanistan",
            "population": 29863010,
            "density": 119
        },
        {
            "code"= "AL",
            "value"= 117,
            "name"= "Albania",
            "population"= 3195000,
            "density"= 111
        },
        {
            "code"= "DZ",
            "value"= 15,
            "name"= "Algeria",
            "population"= 34895000,
            "density"= 15
        }
]
```

![Maps with JSON data source](./images/populatedata/Populatedata.png)

<!-- markdownlint-disable MD010 -->

## Binding complex data source

You can bind the data field from data source to the maps in two different ways.

1. Bind the field name directly to the properties as [`ShapeDataPath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_ShapeDataPath), [`ColorValuePath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_ColorValuePath),
[`ValuePath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_ValuePath) and [`ShapeValuePath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker.html#Syncfusion_Blazor_Maps_MapsMarker_ShapeValuePath).

2. Bind the field name as `data.field` to the properties as [`ShapeDataPath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_ShapeDataPath), [`ColorValuePath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_ColorValuePath),
[`ValuePath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsShapeSettings.html#Syncfusion_Blazor_Maps_MapsShapeSettings_ValuePath) and [`ShapeValuePath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker.html#Syncfusion_Blazor_Maps_MapsMarker_ShapeValuePath).

The complex data source binding can be done as illustrated in the following code example.

```csharp
@inject HttpClient Http;
@using Syncfusion.Blazor.Maps

@if (populationDensity == null)
{
    <p><em>Loading Maps component...</em></p>
}
else
{
    <SfMaps>
        <MapsLayers>
            <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
                       DataSource="PopulationDensity"
                       ShapeDataPath="data.continent"
                       ShapePropertyPath='new string[] {"continent"}' TValue="PopulationDensity">
				<MapsShapeSettings ColorValuePath="data.color"></MapsShapeSettings>
                <MapsDataLabelSettings Visible="true" LabelPath="Name"></MapsDataLabelSettings>
            </MapsLayer>
        </MapsLayers>
    </SfMaps>
}
@code{
    PopulationDensity[] populationDensity;
    protected override async Task OnInitAsync()
    {
        PopulationDensity = await Http.GetJsonAsync<PopulationDensity[]>("sample-data/PopulationDensity.json");
    }

    public class PopulationDensity
    {
        public string Code { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }
        public float Density { get; set; }
    }
}
```

Here, the `PopulationDensity.json` file contains following data.

```json
[
        { "Continent": "North America", 'color': '#71B081',
            data: { "continent": "North America", 'color': '#71B081' }
            },
            { "Continent": "South America", 'color': '#5A9A77',
            data: { "continent": "South America", 'color': '#5A9A77' }
            },
            { "Continent": "Africa", 'color': '#498770',
            data: { "continent": "Africa", 'color': '#498770' }
            },
            { "Continent": "Europe", 'color': '#39776C',
            data: { "continent": "Europe", 'color': '#39776C' }
            },
            { "Continent": "Asia", 'color': '#266665',
            data: { "continent": "Asia", 'color': '#266665' }
            },
            { "Continent": "Australia", 'color': '#124F5E',
            data: { "continent": "Australia", 'color': '#124F5E' }
            }
]
```