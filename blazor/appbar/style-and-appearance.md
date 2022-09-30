---
layout: post
title: Style and Appearance in Blazor AppBar Component | Syncfusion
description: Checkout and learn here all about Style and Appearance in Syncfusion Blazor AppBar component and more.
platform: Blazor
control: AppBar
documentation: ug
---

# Styles and Appearances in Blazor AppBar Component

To modify the AppBar appearance, you need to override the default CSS of AppBar component. Please find the list of CSS classes and its corresponding section in AppBar component. Also, you have an option to create your own custom theme for the controls using our [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

|CSS Class | Purpose of Class |
|-----|----- |
|.e-appbar|To customize the appbar.|
|.e-appbar.e-prominent|To customize the prominent appbar.|
|.e-appbar.e-dense|To customize the dense appbar.|
|.e-appbar.e-light|To customize the light appbar.|
|.e-appbar.e-dark|To customize the dark appbar.|
|.e-appbar.e-primary|To customize the dark appbar.|
|.e-appbar.e-inherit|To customize the inherit appbar.|

>Note: You can change the prominent AppBar height if larger titles, images or texts are used.

## CssClass

CssClass is used for AppBar customization based on the custom class. In the below example AppBar background and color is customized using [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_CssClass) property.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary" CssClass="custom-appbar">
       <SfButton CssClass="e-inherit" IconCss="e-icons e-menu"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container {
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }
    .control-container .e-appbar.custom-appbar {
        background: #adadb1;
        color: #fff;
    }
</style>
```

![Blazor AppBar with CssClass customization](./images/cssclass_appbar.png)

## HtmlAttributes

It can be used to additional inline attributes through `@attributes` directive. In the below code example, aria-label of the AppBar customized using `@attributes` directive.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary" @attributes="customAttribute">
       <SfButton CssClass="e-inherit" IconCss="e-icons e-home"></SfButton>
    </SfAppBar>
</div>

@code { 
     Dictionary<string, object> customAttribute = new Dictionary<string, object>() 
     { 
         { "aria-label", "appbar" } 
     }; 
}

<style>
    .control-container {
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }
</style>
```
