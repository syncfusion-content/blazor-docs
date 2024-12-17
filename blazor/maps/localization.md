---
layout: post
title: Localization in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about Localization in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Localization in Blazor Maps Component

The Blazor Maps component supports localization, allowing it to display content in any language by integrating localized text resources. Static text elements, such as zoom toolbar tooltips and placeholder text for tile images that fail to load, can be translated into various languages (e.g., Arabic, German, French) by defining the appropriate locale value. To efficiently manage language-specific content, the localization process can utilize **.resx** files, enabling developers to maintain translations with ease. This feature enhances user experience and accessibility by allowing users to interact with the Maps component in their preferred language while ensuring seamless integration into applications tailored for diverse global audiences.

You can add culture-specific resource files using **.resx** files in your application. Please refer to the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic for details on localizing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

The table below shows the locale keywords and their corresponding text that can be displayed in the Blazor Maps component. These keywords represent various UI elements, such as tooltips for zoom toolbar including zoom, zoom in/out, pan and reset actions. By defining these locale keys, developers can customize the text displayed to users in different languages. 

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
<tr>
<td>Maps_ImageNotFound</td>
<td>Image Not Found</td>
</tr>
</table>

These translations allow the Maps component to adapt to the user's preferred language, enhancing accessibility and usability.

The image below illustrates how the tooltip displays for the zoom toolbar values in different cultures.

![Blazor Maps with Localization](./images/Localization/blazor-maps-zoom-toolbar-tooltip-with-localization.gif)



