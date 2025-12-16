---
layout: post
title: Styles and Appearances in Blazor AppBar Component | Syncfusion
description: Check out and learn about Styles and Appearances in Syncfusion Blazor AppBar component and more here.
platform: Blazor
control: AppBar
documentation: ug
---

# Styles and Appearances in Blazor AppBar Component

To modify the AppBar appearance, you need to override the default CSS of the AppBar component. Find the list of CSS classes and their corresponding sections in the AppBar component. Also, you have an option to create your own custom theme for the controls using our [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

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

CssClass is used for AppBar customization based on the custom class. In the example below, the AppBar background and color are customized using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_CssClass) property.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthgCVMTrrGSfJrV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AppBar with CssClass customization](./images/cssclass_appbar.png)" %}

## HtmlAttributes

It can be used for additional inline attributes by specifying as inline attributes or by specifying `@attributes` directive. In the code example below, the aria-label of the AppBar is customized by specifying as inline attributes.

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