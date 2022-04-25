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

## KeyBoard Navigation

All the Maps actions can be controlled via keyboard keys. The applicable key combinations and their relative functionalities are listed below for the appropriate UI features available in the component.

Interaction Keys |Description
-----|-----
<kbd>Tab</kbd> |Moves to the next focusable element on the map, such as the legend or shape.
<kbd>Shift</kbd> + <kbd>Tab</kbd> |Moves to the previous focusable element on the map, such as the legend or shape.
<kbd> + </kbd> |When zooming is enabled, zoom in operation can be performed.
<kbd> - </kbd> |When zooming is enabled, zoom out operation can be performed.
<kbd>Left arrow</kbd> |When zoomed in, the map can be scrolled to the left.
<kbd>Right arrow</kbd> |When zoomed in, the map can be scrolled to the right.
<kbd>Up arrow</kbd> |When zoomed in, the map can be scrolled upward.
<kbd>Down arrow</kbd> |When zoomed in, the map can be scrolled downward.
<kbd> R </kbd> |When zooming is enabled, reset operation can be performed.
<kbd>Enter</kbd> |The page can be navigated to the next and previous states in legend. Similarly, the selection can be made while navigating over the shape.