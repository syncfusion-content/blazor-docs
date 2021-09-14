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

Syncfusion provides support to render icons as a standalone icon component. Add the client-side resources through CDN or from NuGet package in the `<head>` element of the `~/wwwroot/index.html` in Blazor WebAssembly app or `~/Pages/_Host.cshtml` in Blazor server app.

```html
<head>
    <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    @*<link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/bootstrap4.css" rel="stylesheet" />*@
</head>
```

The following code snippet represents the complete example of standalone icon component usage by defining the icons using `SfIcon` tag in `~/Pages/Index.razor`.

```csharp
@using Syncfusion.Blazor.Buttons

<SfIcon Name="IconName.Cut"></SfIcon>
<SfIcon Name="IconName.Copy"></SfIcon>
<SfIcon Name="IconName.Paste"></SfIcon>
```

![Icons](./images/icons/icon.png)

## Initialize icons with IconCss

The Icon component provides support to render [available icons](#available-icons) and third-party icons using `IconCss` property. Add a class `e-icons` to the IconCss property that contains the font-family and common property of the font icons. Add the icon class with corresponding icon name from the available icons with `e-` prefix.

The following code explains how to render icons using `IconCss`. here search icon rendered with `e-icons e-search` class name.

```csharp
@using Syncfusion.Blazor.Buttons

<SfIcon IconCss="e-icons e-search"></SfIcon> //render search icon from available icons
<SfIcon IconCss="oi oi-home"></SfIcon> //home icon from open-iconic
<SfIcon IconCss="oi oi-plus"></SfIcon> //plus icon from open-iconic
```

![Third party icons](./images/icons/icon-css.png)

## Set Icon size

The font size of the icon can be changed using the `Size` property. The icon displays `Medium` size by default. To change the default size, define the applicable `IconSize` to Size property. The applicable IconSize are,

* Small
* Medium
* Large

```csharp
@using Syncfusion.Blazor.Buttons

<SfIcon Name="IconName.Bold" Size="IconSize.Small"></SfIcon>
<SfIcon Name="IconName.Underline" Size="IconSize.Medium"></SfIcon>
<SfIcon Name="IconName.Italic" Size="IconSize.Large"></SfIcon>
```

![Icon size](./images/icons/icon-size.png)

> The `Size` property will be applicable only when defining the icon using `Name` property. Other customizations were made using `IconCss` property.

## Display tooltip for icons

Tooltip can be shown on icon hover and it can be achieved by setting tooltip text for `Title` property.

```csharp
@using Syncfusion.Blazor.Buttons

<SfIcon Name="IconName.Upload" Title="Upload"></SfIcon>
<SfIcon Name="IconName.Download" Title="Download"></SfIcon>
<SfIcon Name="IconName.Undo" Title="Undo"></SfIcon>
<SfIcon Name="IconName.Redo" Title="Redo"></SfIcon>
```

![Icon size](./images/icons/icon-title.png)

## Customize Icon

The Syncfusion Blazor icon library can customize its color and size by overriding the `e-icons` class.

```csharp
@using Syncfusion.Blazor.Buttons

<SfIcon Name="IconName.AlignLeft"></SfIcon>
<SfIcon Name="IconName.AlignRight"></SfIcon>
<SfIcon Name="IconName.AlignCenter"></SfIcon>
<SfIcon Name="IconName.Justify"></SfIcon>

<style>
    .e-icons{
        color: #ff0000;
        font-size: 26px !important;
    }
</style>
```

![Customize Icon](./images/icons/custom-icon.png)

## Available Icons

The complete pack of Syncfusion Blazor icons is listed in the following table. The corresponding icon content can be referred to the content section.

<!-- markdownlint-disable MD033 -->

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
