---
layout: post
title: Localization in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about Localization in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Localization in Blazor Maps Component

The Blazor Maps component supports localization, allowing it to display content in any language by integrating localized text resources. Static text elements, such as zoom toolbar tooltips and placeholder text for tile images that fail to load, can be translated into various languages (e.g., Arabic, German, French) by defining the appropriate locale value and providing a corresponding translation object. To efficiently manage language-specific content, the localization process can utilize .resx files, enabling developers to maintain translations with ease. This feature enhances user experience and accessibility by allowing users to interact with the map component in their preferred language while ensuring seamless integration into applications tailored for diverse global audiences.

The table below shows the locale keywords and their corresponding text that can be displayed in the Blazor Maps component. These keywords represent various UI elements in the Maps component, such as zoom controls and pan/reset actions. By defining these locale keys in a translation object, developers can customize the text displayed to users in different languages. For example:

<table>
<tr>
<td><b>Locale key words</b></td>
<td><b>Text to display</b></td>
</tr>
<tr>
<td>Maps_Zoom</td>
<td>Zoom</td>
</tr>
<tr>
<td>Maps_ZoomIn</td>
<td>Zoom in</td>
</tr>
<tr>
<td>Maps_ZoomOut</td>
<td>Zoom out</td>
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

These translations allow the Maps component to adapt to the user's preferred language, enhancing accessibility and usability.

Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

The image below illustrates how the zoom toolbar tooltip displays values for different cultures.

![Blazor Maps with Localization](./images/Localization/blazor-maps-zoom-toolbar-tooltip-with-localization.gif)



