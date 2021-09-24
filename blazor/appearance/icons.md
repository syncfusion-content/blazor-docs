---
layout: post
title: Icons Library in Blazor - Syncfusion
description: Learn here all about that how to using Icons in the Syncfusion Blazor Component and its type of icons.
platform: Blazor
component: Common
documentation: ug
---

# Blazor Icons Library

The Syncfusion Blazor library provides the set of `base64` formatted font icons which are being used in the Syncfusion Blazor components. These can be utilized in the web application also as needed.

## Standalone Icon Component

Syncfusion provides support to render icons as a standalone component. You can refer [Getting Started with Syncfusion Blazor for Server-side in Visual Studio 2019 page](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/) for the introduction and configuring the common specifications.

The following code snippet represents the complete example of standalone icon component usage by defining the icons using the `SfIcon` tag.

```csharp
@using Syncfusion.Blazor.Buttons

<SfIcon Name="IconName.Cut"></SfIcon>
<SfIcon Name="IconName.Copy"></SfIcon>
<SfIcon Name="IconName.Paste"></SfIcon>
<SfIcon Name="IconName.Bold"></SfIcon>
<SfIcon Name="IconName.Underline"></SfIcon>
<SfIcon Name="IconName.Italic"></SfIcon>
```

![Icons](./images/icons/icon.png)

## Initialize icons with IconCss

The Icon component provides support to render [available icons](#available-icons) and third-party icons using the `IconCss` property.

To use syncfusion icons, add `e-icons` class to the IconCss property that contains the font-family and common property of the font icons. Add the icon class with the corresponding icon name from the available icons with `e-` prefix. The following code explains how to render syncfusion icons using icon class

```csharp
@using Syncfusion.Blazor.Buttons

<SfIcon IconCss="e-icons e-arrow-down"></SfIcon>
<SfIcon IconCss="e-icons e-chevron-down-double"></SfIcon>
<SfIcon IconCss="e-icons e-arrow-up"></SfIcon>
<SfIcon IconCss="e-icons e-chevron-up-double"></SfIcon>
<SfIcon IconCss="e-icons e-arrow-left"></SfIcon>
<SfIcon IconCss="e-icons e-chevron-left-double"></SfIcon>
<SfIcon IconCss="e-icons e-arrow-right"></SfIcon>
<SfIcon IconCss="e-icons e-chevron-right-double">
```

![Icons Css](./images/icons/icon-css.png)

To render third-party icons define the CSS class that provides the required font name, font size, and content for the icon.
The following code explains how to render `open-iconic`(third-party) icons using `IconCss` property.

```cSharp
@using Syncfusion.Blazor.Buttons

<SfIcon IconCss="oi oi-list-rich"></SfIcon>
<SfIcon IconCss="oi oi-account-login"></SfIcon>
<SfIcon IconCss="oi oi-account-logout"></SfIcon>
<SfIcon IconCss="oi oi-action-redo"></SfIcon>
<SfIcon IconCss="oi oi-action-undo"></SfIcon>
<SfIcon IconCss="oi oi-clock"></SfIcon>
<SfIcon IconCss="oi oi-audio"></SfIcon>
<SfIcon IconCss="oi oi-bluetooth"></SfIcon>
```

![Third party icons](./images/icons/third-party-icons.png)

## Set Icon size

The font size of the icon can be changed using the `Size` property. The icon displays `Medium` size by default. To change the default size, define the applicable `IconSize` to Size property. The applicable IconSize are,

* Small
* Medium
* Large

The following code example represents the smaller size of the icon using `Size` property by setting Icon `IconSize.Small` to the size property.

```csharp
@using Syncfusion.Blazor.Buttons

<div style="padding: 5px;">
    <p>Smaller icons</p>
    <SfIcon Name="IconName.Cut" Size="IconSize.Small"></SfIcon>
    <SfIcon Name="IconName.Copy" Size="IconSize.Small"></SfIcon>
    <SfIcon Name="IconName.Paste" Size="IconSize.Small"></SfIcon>
    <SfIcon Name="IconName.Bold" Size="IconSize.Small"></SfIcon>
    <SfIcon Name="IconName.Underline" Size="IconSize.Small"></SfIcon>
    <SfIcon Name="IconName.Italic" Size="IconSize.Small"></SfIcon>
</div>
<div style="padding: 5px;">
    <p>Medium icons</p>
    <SfIcon Name="IconName.Cut" Size="IconSize.Medium"></SfIcon>
    <SfIcon Name="IconName.Copy" Size="IconSize.Medium"></SfIcon>
    <SfIcon Name="IconName.Paste" Size="IconSize.Medium"></SfIcon>
    <SfIcon Name="IconName.Bold" Size="IconSize.Medium"></SfIcon>
    <SfIcon Name="IconName.Underline" Size="IconSize.Medium"></SfIcon>
    <SfIcon Name="IconName.Italic" Size="IconSize.Medium"></SfIcon>
</div>
<div style="padding: 5px;">
    <p>Larger icons</p>
    <SfIcon Name="IconName.Cut" Size="IconSize.Large"></SfIcon>
    <SfIcon Name="IconName.Copy" Size="IconSize.Large"></SfIcon>
    <SfIcon Name="IconName.Paste" Size="IconSize.Large"></SfIcon>
    <SfIcon Name="IconName.Bold" Size="IconSize.Large"></SfIcon>
    <SfIcon Name="IconName.Underline" Size="IconSize.Large"></SfIcon>
    <SfIcon Name="IconName.Italic" Size="IconSize.Large"></SfIcon>
</div>
```

![Icon size](./images/icons/icon-size.png)

> The `Size` property will be applicable only when defining the icon using `Name` property. Other customizations were made using `IconCss` property.

## Display tooltip for icons

`Title` property used to set title attribute for the icon to improve accessibility with screen readers and shows a tooltip on mouseover. The following example code displays tooltip text for appropriate icons.

```csharp
@using Syncfusion.Blazor.Buttons

<SfIcon Name="IconName.Upload" Title="Upload"></SfIcon>
<SfIcon Name="IconName.Download" Title="Download"></SfIcon>
<SfIcon Name="IconName.Undo" Title="Undo"></SfIcon>
<SfIcon Name="IconName.Redo" Title="Redo"></SfIcon>
<SfIcon Name="IconName.AlignTop" Title="AlignTop"></SfIcon>
<SfIcon Name="IconName.AlignBottom" Title="AlignBottom"></SfIcon>
<SfIcon Name="IconName.AlignMiddle" Title="AlignMiddle"></SfIcon>
```

![Icon size](./images/icons/icon-title.png)

## Customize Icon

The Syncfusion Blazor icon library can customize its color and size by overriding the `e-icons` class. The following example code demonstrates the custom font-size and color for icons.

```csharp
@using Syncfusion.Blazor.Buttons

<SfIcon Name="IconName.AlignLeft"></SfIcon>
<SfIcon Name="IconName.AlignRight"></SfIcon>
<SfIcon Name="IconName.AlignCenter"></SfIcon>
<SfIcon Name="IconName.Justify"></SfIcon>
<SfIcon Name="IconName.DecreaseIndent"></SfIcon>
<SfIcon Name="IconName.IncreaseIndent"></SfIcon>

<style>
    .e-icons{
        color: #ff0000;
        font-size: 26px !important;
    }
</style>
```

![Customize Icon](./images/icons/custom-icon.png)

## Icon integration in Button component

The syncfusion icons will integrate on blazor components without defining the `<SfIcon>`. The following example explains how to integrate the icons in syncfusion button component by defining the icon class in the `IconCss` property. Refer icons usage from this [link](#initialize-icons-with-iconcss).

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton IconCss="e-icons e-chevron-down-fill" Content="Show dropdown" IconPosition="IconPosition.Right"></SfButton>
```

![Button Integration](./images/icons/button-integration.png)


## Direct usage of icons

The Syncfusion icons can render directly in the HTML tag. This can be achieved by defining the [available icon's](#available-icons) class with `e-` prefix. The following code example explains the direct rendering of syncfusion `search` icon in the span element.

```cshtml
<span class="e-icons e-search"></span>
```

## Available Icons

The complete pack of Syncfusion Blazor icons is listed in the following table. The corresponding icon content can be referred to the content section.

<!-- markdownlint-disable MD033 -->

### Bootstrap 5

<iframe class="doc-sample-frame" src="https://ej2.syncfusion.com/products/icons/bootstrap5/demo.html" style="height:1000px;width:100%;"></iframe>

### Bootstrap 4

<iframe class="doc-sample-frame" src="https://ej2.syncfusion.com/products/icons/bootstrap4/demo.html" style="height:1000px;width:100%;"></iframe>

### Bootstrap

<iframe class="doc-sample-frame" src="https://ej2.syncfusion.com/products/icons/bootstrap/demo.html" style="height:1000px;width:100%;"></iframe>

### Material

<iframe class="doc-sample-frame" src="https://ej2.syncfusion.com/products/icons/material/demo.html" style="height:1000px;width:100%;"></iframe>

### Office Fabric

<iframe class="doc-sample-frame" src="https://ej2.syncfusion.com/products/icons/fabric/demo.html" style="height:1000px;width:100%;"></iframe>

### High Contrast

<iframe class="doc-sample-frame" src="https://ej2.syncfusion.com/products/icons/highcontrast/demo.html" style="height:1000px;width:100%;"></iframe>

### Tailwind CSS

<iframe class="doc-sample-frame" src="https://ej2.syncfusion.com/products/icons/tailwind/demo.html" style="height:1000px;width:100%;"></iframe>
