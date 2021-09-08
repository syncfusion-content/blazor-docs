---
layout: post
title: Accessibility in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Accessibility in Blazor Maps Component

Maps provides built-in compliance with the [WAI-ARIA](https://www.w3.org/TR/wai-aria-practices/) specifications. The WAI-ARIA accessibility support is achieved through the attribute like `aria-label` in the SVG element. It helps to provide information about elements in a document for assistive technology. This attribute sets the text label with some default description for the following elements in Maps.

<!-- markdownlint-disable MD033 -->

<table>
    <tr>
        <td><b>Element</b></td>
        <td><b>Default description</b></td>
    </tr>
    <tr>
        <td>Maps container</td>
        <td>Specifies the Maps component.</td>
    </tr>
    <tr>
        <td>Maps title</td>
        <td>Specifies the title of the Maps.</td>
    </tr>
    <tr>
        <td>Maps subtitle</td>
        <td>Specifies the sub-title of the Maps.</td>
    </tr>
    <tr>
        <td>Legend title</td>
        <td>Specifies the title of legend in the Maps.</td>
    </tr>
</table>

To change this default description, use the [`Description`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Description) property available in [`MapsLegendTitle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLegendTitle.html#Syncfusion_Blazor_Maps_MapsLegendTitle_Description), [`MapsTitleSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTitleSettings.html#Syncfusion_Blazor_Maps_MapsTitleSettings_Description), [`MapsSubtitleSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsSubtitleSettings.html#Syncfusion_Blazor_Maps_MapsSubtitleSettings_Description) and [`SfMaps`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Description). It helps the screen reader to read for an assistive purpose.