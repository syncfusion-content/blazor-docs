---
layout: post
title: Localization in Blazor Maps Component | Syncfusion 
description: Learn about Localization in Blazor Maps component of Syncfusion, and more details.
platform: Blazor
control: Maps
documentation: ug
---

# Localization

The localization library allows to localize the default text content of the Maps component. It has static text on some features such as zooming toolbars, and this can be changed to any other culture such as Arabic, Deutsch, and French by defining the locale value and translation object.

<!-- markdownlint-disable MD033 -->

<table>
<tr>
<td><b>Locale key words</b></td>
<td><b>Text to display</b></td>
</tr>
<tr>
<td>Zoom</td>
<td>Zoom</td>
</tr>
<tr>
<td>ZoomIn</td>
<td>ZoomIn</td>
</tr>
<tr>
<td>ZoomOut</td>
<td>ZoomOut</td>
</tr>
<tr>
<td>Reset</td>
<td>Reset</td>
</tr>
<tr>
<td>Pan</td>
<td>Pan</td>
</tr>
<tr>
<td>ResetZoom</td>
<td>Reset Zoom</td>
</tr>
</table>

To load data related to toolbar items, use the `LoadLocaleData` method, and set culture using the `SetCulture` method. To customize other properties such as data label and tooltip text, provide value in corresponding culture format as demonstrated in the following example.

```csharp
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsZoomSettings Enable="true"></MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
                   ShapePropertyPath='new string[] {"name"}'
                   DataSource="SecurityCouncilDetails"
                   ShapeDataPath="Name" TValue="UNCouncilCountry">
            <MapsDataLabelSettings Visible="true" LabelPath="CountryName"></MapsDataLabelSettings>
            <MapsLayerTooltipSettings Visible="true" Format="${CountryName} - ${Membership}"></MapsLayerTooltipSettings>
            <MapsShapeSettings Fill="#E5E5E5" ColorValuePath="Membership">
                <MapsShapeColorMappings>
                    <MapsShapeColorMapping Value="Permanent" Color='new string[] {"#EDB46F"}'></MapsShapeColorMapping>
                    <MapsShapeColorMapping Value="Nicht-Permanent" Color='new string[] {"#F1931B"}'></MapsShapeColorMapping>
                </MapsShapeColorMappings>
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }
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

    protected override void OnAfterRender()
    {
        this.JsRuntime.Sf().LoadLocaleData("wwwroot/cldr-data/locale.json").SetCulture("de");
    }

    public class UNCouncilCountry
    {
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string Membership { get; set; }
    };
}
```

The `locale.json` file contains following data.

```json
{
  "de": {
    "maps": {
      "ZoomIn": "hineinzoomen",
      "ZoomOut": "Rauszoomen",
      "Zoom": "Zoomen",
      "Pan": "Schwenken",
      "Reset": "Zurücksetzen"
    }
  }
}
```

![Maps with localization](./images/Localization/Localization.png)
