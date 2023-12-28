---
layout: post
title: Size and Color with Blazor AppBar Component | Syncfusion
description: Check out and learn about Size and Color with the Blazor AppBar component in the Blazor Server App and the Blazor WebAssembly App.
platform: Blazor
control: AppBar
documentation: ug
---

# Size and Color with Blazor AppBar Component

## Size

The size of the AppBar can be set using the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_Mode) property. The available types of the Blazor AppBar are as follows:

* Regular AppBar
* Prominent AppBar
* Dense AppBar

### Regular AppBar

This mode is the default one in which the AppBar is displayed with the default height.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary">
        <SfButton CssClass="e-inherit" IconCss="e-icons e-menu"></SfButton>
        <span class="regular">Regular AppBar</span>
        <AppBarSpacer></AppBarSpacer>
        <SfButton CssClass="e-inherit" Content="FREE TRIAL"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container .e-btn.e-inherit {
        margin: 0 3px;
    }
</style>
```

![Blazor AppBar with Regular Size](./images/regular_appbar.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBAiVWfLtaWPHyq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Prominent AppBar

This height mode can be set to the AppBar by setting `AppBarMode.Prominent` to the property [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_Mode). The prominent AppBar is displayed with a longer height and can be used for larger titles, images, or texts. It is also longer than the regular AppBar. In the following example, we have customized the prominent text using align-self and white-space CSS properties. You can change the prominent AppBar height if larger titles, images, or texts are used.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary" Mode="AppBarMode.Prominent" CssClass="prominent-appbar" >
        <SfButton CssClass="e-inherit" IconCss="e-icons e-menu"></SfButton>
        <span class="prominent">AppBar Component with Prominent mode</span>
        <AppBarSpacer></AppBarSpacer>
        <SfButton CssClass="e-inherit" Content="FREE TRIAL"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container .e-appbar .prominent {
        align-self: center;
        white-space: break-spaces;
        text-align: inherit;
        font-size: 35px;
        line-height: 50px;
    }
    .control-container .e-appbar.prominent-appbar {
        background-image: url("https://blazor.syncfusion.com/demos/_content/blazor_server_common_net8/images/appbar/prominent.png");
        background-size: 100% 400px;
        color: #ffffff;
        background-repeat: no-repeat;
        height: 400px;
    }
    .control-container .prominent-appbar .e-inherit.e-btn {
        background: transparent;
    }
    .control-container .prominent-appbar .e-inherit.e-btn:hover,
    .control-container .prominent-appbar .e-inherit.e-btn:focus,
    .control-container .prominent-appbar .e-inherit.e-btn:active,
    .control-container .prominent-appbar .e-inherit.e-btn.e-active,
    .control-container .prominent-appbar .e-inherit.e-css.e-btn:hover,
    .control-container .prominent-appbar .e-inherit.e-css.e-btn:focus
    .control-container .prominent-appbar .e-inherit.e-css.e-btn:active
    .control-container .prominent-appbar .e-inherit.e-css.e-btn.e-active {
        background: rgba(255, 255, 255, .08);
    }
</style>
```

![Blazor AppBar with Prominent Size](./images/prominent_appbar.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLUChipVCDBzbVE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Dense AppBar

This height mode can be set to the AppBar by setting `AppBarMode.Dense` to the property [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_Mode). Dense AppBar is displayed with shorter height which is denser to accommodate all the AppBar content.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary" Mode="AppBarMode.Dense">
        <SfButton CssClass="e-inherit" IconCss="e-icons e-menu"></SfButton>
        <span class="dense">Dense AppBar</span>
        <AppBarSpacer></AppBarSpacer>
        <SfButton CssClass="e-inherit" Content="FREE TRIAL"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container .e-btn.e-inherit {
        margin: 0 3px;
    }
</style>
```

![Blazor AppBar with Dense Size](./images/dense_appbar.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/VthKirWTrCLzRlMA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Color

The background and font colors can be set using the [ColorMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_ColorMode) property. The available types of background color for the Blazor AppBar are as follows:

* Light AppBar
* Dark AppBar
* Primary AppBar
* Inherit AppBar

### Light AppBar

This color mode is the default one in which the AppBar can be displayed with a light background and its corresponding font color.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar>
        <a href="https://www.syncfusion.com/blazor-components" target="_blank" rel="noopener" role="link" aria-label="Syncfusion blazor components">
            <div class="syncfusion-logo"></div>
         </a>
        <AppBarSpacer></AppBarSpacer>
        <SfButton IsPrimary=true Content="FREE TRIAL"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container .syncfusion-logo {
        background: url(https://cdn.syncfusion.com/blazor/images/demos/syncfusion-logo.svg);
        background-size: contain;
        background-repeat: no-repeat;
        height: 30px;
        width: 150px;
    }
</style>
```

![Blazor AppBar with Light Color](./images/light_appbar.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrqsrMpVMqGpFYy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Dark AppBar

This color mode can be set to the AppBar by setting `AppBarColor.Dark` to the property [ColorMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_ColorMode). A dark AppBar can be displayed with a dark background and its corresponding font color.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Dark">
        <SfButton CssClass="e-inherit" IconCss="e-icons e-menu"></SfButton>
        <AppBarSpacer></AppBarSpacer>
        <SfButton CssClass="e-inherit" Content="FREE TRIAL"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container {
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }
    .control-container .e-btn.e-inherit {
        margin: 0 3px;
    }
</style>
```

![Blazor AppBar with Dark Color](./images/dark_appbar.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBgMBCpBMfsnjes?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Primary AppBar

This color mode can be set to the AppBar by setting `AppBarColor.Primary` to the property [ColorMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_ColorMode). The primary AppBar can be displayed with primary colors.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary">
        <SfButton CssClass="e-inherit" IconCss="e-icons e-menu"></SfButton>
        <AppBarSpacer></AppBarSpacer>
        <SfButton CssClass="e-inherit" Content="FREE TRIAL"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container {
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }
    .control-container .e-btn.e-inherit {
        margin: 0 3px;
    }
</style>
```

![Blazor AppBar with Primary Color](./images/primary_appbar.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBAChsTrifpmere?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Inherit AppBar

This color mode can be set to the AppBar by setting `AppBarColor.Inherit` to the property [ColorMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_ColorMode). The AppBar inherits the background and font color from its parent element.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Inherit">
         <a href="https://www.syncfusion.com/blazor-components" target="_blank" rel="noopener" role="link" aria-label="Syncfusion blazor components">
            <div class="syncfusion-logo"></div>
         </a>
        <AppBarSpacer></AppBarSpacer>
        <SfButton IsPrimary=true Content="FREE TRIAL"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container .syncfusion-logo {
        background: url(https://cdn.syncfusion.com/blazor/images/demos/syncfusion-logo.svg);
        background-size: contain;
        background-repeat: no-repeat;
        height: 30px;
        width: 150px;
    }
</style>
```

![Blazor AppBar with Inherit Color](./images/inherit_appbar.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLgWrWJrsJagjCw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}