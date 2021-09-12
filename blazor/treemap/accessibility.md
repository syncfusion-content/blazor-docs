---
layout: post
title: Accessibility in Blazor TreeMap Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor TreeMap component and much more.
platform: Blazor
control: TreeMap
documentation: ug
---

# Accessibility in Blazor TreeMap Component

The TreeMap component provides built-in compliance with the [WAI-ARIA](https://www.w3.org/TR/wai-aria-practices/) specifications. The WAI-ARIA accessibility supports are achieved using attributes such as `aria-label`. It helps to provide information about the elements in a document for assistive technology.

This attribute provides text label with some default description for the following elements in the TreeMap.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Element</b></td>
<td><b>Default description</b></td>
</tr>
<tr>
<td>TreeMap container</td>
<td>Reads the TreeMap description</td>
</tr>
<tr>
<td>TreeMap Title</td>
<td>Reads the TreeMap title</td>
</tr>
<tr>
<td>TreeMap Subtitle</td>
<td>Reads the TreeMap subtitle</td>
</tr>
<tr>
<td>Legend Title</td>
<td>Reads the legend title</td>
</tr>
</table>

Change this default description using the [`Description`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_Description) property available in the [TreeMapLegendSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.TreeMap.TreeMapLegendSettings.html), [TreeMapTitleSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapTitleSettings.html), [TreeMapSubTitleSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapSubtitleSettings.html), and [SfTreeMap](https://help.syncfusion.com/cr/blazor). It helps screen readers to read for assistive purpose.