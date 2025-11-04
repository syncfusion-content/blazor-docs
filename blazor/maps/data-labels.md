---
layout: post
title: Data Labels in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about data labels in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Data labels in Blazor Maps Component

Data labels provide information to users about the shapes of the Maps component. It can be enabled by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_Visible) property of the [MapsDataLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html) to **true**.

## Adding data labels

To display data labels in the Maps, the [LabelPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_LabelPath) property of [MapsDataLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html) must be used. The value of the [LabelPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_LabelPath) property can be taken from the field name in the shape data or data source. In the following example, the value of the [LabelPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_LabelPath) property is the field name in the shape data of the Maps layer.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            @* To add data labels *@
            <MapsDataLabelSettings Visible="true" LabelPath="name"></MapsDataLabelSettings>
            <MapsShapeSettings Autofill="true"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Blazor Maps with Data Label](./images/DataLabel/blazor-maps-data-label.png)

In the following example, the value of [LabelPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_LabelPath) property is set from the field name in the data source of the layer settings.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps ID="Maps">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="PopulationDetail"
                   DataSource="PopulationDetails" ShapeDataPath="@ShapeDataPath" ShapePropertyPath="@ShapePropertyPath">
            @* To add data labels *@
            <MapsDataLabelSettings Visible="true" LabelPath="Continent"></MapsDataLabelSettings>
            <MapsShapeSettings Autofill="true"></MapsShapeSettings>
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
        public string Color { get; set; }
        public string Continent { get; set; }
    };
    public List<PopulationDetail> PopulationDetails = new List<PopulationDetail> {
        new PopulationDetail {
            Code = "AF", Value= 53, Name= "Afghanistan", Population= 29863010, Density= 119, Color = "Red", Continent = "Asia"
        },
        new PopulationDetail {
            Code= "AL", Value= 117, Name= "Albania", Population= 3195000, Density= 111, Color = "Blue", Continent = "Europe"
        },
        new PopulationDetail {
            Code= "DZ", Value= 15, Name= "Algeria", Population= 34895000, Density= 15, Color = "Green", Continent = "Africa"
        }
    };
    public string[] ShapePropertyPath = { "name" };
    public string ShapeDataPath = "Name";
}
```

![Getting Blazor Maps Label Path Value from Datasource](./images/DataLabel/blazor-maps-label-path-datasource.PNG)

## Customization

The following properties and classes are available in the [MapsDataLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html) to customize the data label of the Maps component.

* [MapsLayerDataLabelBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayerDataLabelBorder.html) - To customize the color and width for the border of the data labels in Maps.
* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_Fill) - To apply the color of the data labels in Maps.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_Opacity) - To customize the transparency of the data labels in Maps.
* [MapsLayerDataLabelTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayerDataLabelTextStyle.html) - To customize the text style of the data labels in Maps.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            @* To add data labels *@
            <MapsDataLabelSettings Visible="true" LabelPath="name" Fill="red" Opacity="0.9">
                <MapsLayerDataLabelBorder Color="green" Width="2"></MapsLayerDataLabelBorder>
                <MapsLayerDataLabelTextStyle Color="blue" Size="12px" FontStyle="Sans-serif" FontWeight="normal">
                </MapsLayerDataLabelTextStyle>
            </MapsDataLabelSettings>
            <MapsShapeSettings Autofill="true"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Blazor Maps with Custom Data Label](./images/DataLabel/blazor-maps-custom-data-label.PNG)

## Label animation

The data labels can be animated during the initial rendering of the Maps. This can be enabled by setting the [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_AnimationDuration) property in the `MapsDataLabelSettings` of the Maps. The duration of the animation is specified in milliseconds.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            @* To add data labels *@
            <MapsDataLabelSettings Visible="true" LabelPath="name" AnimationDuration="5000"></MapsDataLabelSettings>
            <MapsShapeSettings Autofill="true"></MapsShapeSettings>
            <MapsLayerTooltipSettings Visible="true" ValuePath="name"></MapsLayerTooltipSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Blazor Maps with data label animation](./images/DataLabel/blazor-maps-data-label-animation.gif)

## Smart labels

The Maps component provides an option to handle the labels when they intersect with the corresponding shape borders using the [SmartLabelMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_SmartLabelMode) property. The following options are available in the [SmartLabelMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_SmartLabelMode) property.

* None
* Hide
* Trim

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            @* To hide intersect labels with shape border *@
            <MapsDataLabelSettings Visible="true" LabelPath="name" SmartLabelMode="SmartLabelMode.Hide">
            </MapsDataLabelSettings>
            <MapsShapeSettings Autofill="true"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Blazor Maps with Smart Data Label](./images/DataLabel/blazor-maps-smart-data-label.png)

## Intersect action

The Maps component provides an option to handle the labels when a label intersects with another label using the [IntersectionAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_IntersectionAction) property. The following options are available in the [IntersectionAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_IntersectionAction) property.

* None
* Hide
* Trim

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            @* To trim intersect labels *@
            <MapsDataLabelSettings Visible="true" LabelPath="name" IntersectionAction="IntersectAction.Trim">
            </MapsDataLabelSettings>
            <MapsShapeSettings Autofill="true"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Blazor Maps Label with Intersect Action](./images/DataLabel/blazor-maps-data-label-trim.png)

## Adding data label as a template

The data label can be added as a template in the Maps component. The [LabelTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_LabelTemplate) property of [MapsDataLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html) is used to set the data label as a template. Any text or HTML element can be added as the template in data labels.

N>The customization properties of data label, [SmartLabelMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_SmartLabelMode), [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_AnimationDuration) and [IntersectionAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_IntersectionAction) properties are not applicable to [LabelTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsDataLabelSettings.html#Syncfusion_Blazor_Maps_MapsDataLabelSettings_LabelTemplate) property. The styles can be applied to the label template using the CSS styles of the template element.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="PopulationDetail"
                   DataSource="PopulationDetails" ShapeDataPath="@ShapeDataPath" ShapePropertyPath="@ShapePropertyPath">
            <MapsDataLabelSettings Visible="true">
                <LabelTemplate>
                    @{
                        var Data = context as PopulationDetail;
                        <div style="width:50px; height:20px;border: 2px solid black; text-align:center;">
                            <p style="color:red; font-size:12px;">@Data.Continent</p>
                        </div>
                    }
                </LabelTemplate>
            </MapsDataLabelSettings>
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
        public string Color { get; set; }
        public string Continent { get; set; }
    };
    public List<PopulationDetail> PopulationDetails = new List<PopulationDetail> {
        new PopulationDetail {
            Code = "AF", Value= 53, Name= "Afghanistan", Population= 29863010, Density= 119, Color = "Red", Continent = "Asia"
        },
        new PopulationDetail {
            Code= "AL", Value= 117, Name= "Albania", Population= 3195000, Density= 111, Color = "Blue", Continent = "Europe"
        },
        new PopulationDetail {
            Code= "DZ", Value= 15, Name= "Algeria", Population= 34895000, Density= 15, Color = "Green", Continent = "Africa"
        }
    };
    public string[] ShapePropertyPath = { "name" };
    public string ShapeDataPath = "Name";
}
```

![Blazor Maps with Data Label Template](./images/DataLabel/blazor-maps-data-label-template.PNG)