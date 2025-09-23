---
layout: post
title: Styles and Appearances in Blazor AppBar Component | Syncfusion
description: Check out and learn about Styles and Appearances in Syncfusion Blazor AppBar component and more here.
platform: Blazor
control: AppBar
documentation: ug
---

# Styles and Appearances in Blazor AppBar Component

The AppBar component is highly customizable, allowing you to tailor its visual presentation to perfectly fit your application's design language. This document outlines various methods to modify the AppBar's appearance, focusing on overriding default CSS, utilizing custom classes, and applying HTML attributes.

For comprehensive custom theming across Syncfusion controls, you can utilize our [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material), which provides a guided interface to create and manage custom themes.

## Customizing AppBar Elements with CSS Classes

The AppBar component is structured with a set of default CSS classes that you can target to override its default styles. Here's a list of common classes and their purpose:

|CSS Class | Purpose of Class |
|-----|----- |
|.e-appbar|To customize the appbar.|
|.e-appbar.e-prominent|To customize the prominent appbar.|
|.e-appbar.e-dense|To customize the dense appbar.|
|.e-appbar.e-light|To customize the light appbar.|
|.e-appbar.e-dark|To customize the dark appbar.|
|.e-appbar.e-primary|To customize the dark appbar.|
|.e-appbar.e-inherit|To customize the inherit appbar.|

N> You can change the prominent AppBar height if larger titles, images, or texts are used.

## CssClass

The `CssClass` property of the `SfAppBar` component allows you to apply a custom CSS class directly to the root HTML element of the AppBar. This provides a clean way to introduce your own styles or completely override existing ones.

In the example below, the AppBar background and color are customized using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_CssClass) property.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary" CssClass="custom-appbar">
       <SfButton CssClass="e-inherit" IconCss="e-icons e-home"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container .e-appbar.custom-appbar {
        background: #ff0000;
        color: #fff;
    }
</style>
```

![Blazor AppBar with CssClass customization](./images/cssclass_appbar.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/rthgCVMTrrGSfJrV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## HtmlAttributes

The `SfAppBar` component provides the `HtmlAttributes` property (via the `@attributes` directive) to allow you to add any standard HTML attribute directly to the root element (`<div>`) of the AppBar. This is particularly useful for adding ARIA attributes for accessibility, custom `data-` attributes, or IDs.

In the example below, an `aria-label` attribute is added to the AppBar to provide an accessible name for screen reader users.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary" aria-label="appbar">
       <SfButton CssClass="e-inherit" IconCss="e-icons e-home"></SfButton>
    </SfAppBar>
</div>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVgWBizBhGaNVBq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
