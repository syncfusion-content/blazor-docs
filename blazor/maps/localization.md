---
layout: post
title: Localization in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about Localization in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Localization in Blazor Maps Component

The localization library allows localizing the default text content of the Maps component. The Maps component has the static text of some features such as tooltip of zoom toolbar, and that can be changed to other cultures (Arabic, Deutsch, French, etc..) by referring to the Resource file. Refer to more details about localization [here](https://blazor.syncfusion.com/documentation/common/localization/).

<!-- markdownlint-disable MD033 -->

The following is the list of properties that is available in the **.resx** file under the **Resource** folder and its values used in the Maps component.

<table>
<tr>
<td><b>Name</b></td>
<td><b>Text to display</b></td>
</tr>
<tr>
<td>Maps_Zoom</td>
<td>Zoom</td>
</tr>
<tr>
<td>Maps_ZoomIn</td>
<td>Zoom In</td>
</tr>
<tr>
<td>Maps_ZoomOut</td>
<td>Zoom Out</td>
</tr>
<tr>
<td>Maps_Reset</td>
<td>Reset</td>
</tr>
<tr>
<td>Maps_Pan</td>
<td>Pan</td>
</tr>
</table>

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsZoomSettings Enable="true"></MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
                   ShapePropertyPath='new string[] {"name"}' DataSource="SecurityCouncilDetails"
                   ShapeDataPath="Name" TValue="UNCouncilCountry">
            <MapsDataLabelSettings Visible="true" LabelPath="CountryName">
            </MapsDataLabelSettings>
            <MapsLayerTooltipSettings Visible="true" Format="${CountryName} - ${Membership}">
            </MapsLayerTooltipSettings>
            <MapsShapeSettings Fill="#E5E5E5" ColorValuePath="Membership">
                <MapsShapeColorMappings>
                    <MapsShapeColorMapping Value="Permanent" Color='new string[] {"#EDB46F"}'>
                    </MapsShapeColorMapping>
                    <MapsShapeColorMapping Value="Nicht-Permanent" Color='new string[] {"#F1931B"}'>
                    </MapsShapeColorMapping>
                </MapsShapeColorMappings>
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class UNCouncilCountry
    {
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string Membership { get; set; }
    };
    // Set data source value in 'de' culture
    private List<UNCouncilCountry> SecurityCouncilDetails = new List<UNCouncilCountry>{
        new UNCouncilCountry { Name= "China", CountryName= "China", Membership= "Permanent"},
        new UNCouncilCountry { Name= "France", CountryName= "Frankreich", Membership= "Permanent" },
        new UNCouncilCountry { Name= "Russia", CountryName= "Russland", Membership= "Permanent"},
        new UNCouncilCountry { Name= "Kazakhstan", CountryName= "Kasachstan", Membership= "Nicht-Permanent"},
        new UNCouncilCountry { Name= "Poland", CountryName= "Polen", Membership= "Nicht-Permanent"},
        new UNCouncilCountry { Name= "Sweden", CountryName= "Schweden", Membership= "Nicht-Permanent"},
        new UNCouncilCountry { Name= "United Kingdom", CountryName= "Großbritannien", Membership= "Permanent"},
        new UNCouncilCountry { Name= "United States", CountryName= "Vereinigte Staaten", Membership= "Permanent"},
        new UNCouncilCountry { Name= "Bolivia", CountryName= "Bolivien", Membership= "Nicht-Permanent"},
        new UNCouncilCountry { Name= "Eq. Guinea", CountryName= "Gl. Guinea", Membership= "Nicht-Permanent"},
        new UNCouncilCountry { Name= "Ethiopia", CountryName= "Äthiopien", Membership= "Nicht-Permanent"},
        new UNCouncilCountry { Name= "Côte d Ivoire", CountryName= "Elfenbeinküste", Membership= "Permanent"},
        new UNCouncilCountry { Name= "Kuwait", CountryName= "Kuwait", Membership= "Nicht-Permanent"},
        new UNCouncilCountry { Name= "Netherlands", CountryName= "Niederlande", Membership= "Nicht-Permanent"},
        new UNCouncilCountry { Name= "Peru", CountryName= "Peru", Membership= "Nicht-Permanent"}
    };
}
```

![Maps with localization](./images/Localization/Localization.png)

## See also

* [Globalization in Blazor Maps component](https://blazor.syncfusion.com/documentation/maps/internationalization/)