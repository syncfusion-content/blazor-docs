---
layout: post
title: Styles in Blazor Floating Action Button Component | Syncfusion®
description: Checkout and learn here all about Styles in Blazor Floating Action Button component and much more details.
platform: Blazor
control: Floating Action Button
documentation: ug
---

# Styles in Blazor Floating Action Button Component

This section explains the style options for the Blazor Floating Action Button (FAB), including predefined style classes, custom CSS, showing text on hover, and outline customization.

## FAB styles

The Blazor Floating Action Button supports the following predefined styles. Apply these classes via the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property.

| Class | Description |
| -------- | -------- |
| e-success | Represents a positive action. |
| e-outline | Represents an outlined button appearance. |
| e-info | Represents an informative action. |
| e-warning | Represents an action with caution. |
| e-danger | Represents a negative action. |

```cshtml

@using Syncfusion.Blazor.Buttons

<SfFab CssClass="e-warning" IconCss="e-icons e-edit"></SfFab>

```

![Blazor FAB Component with Styles](./images/Style.webp)

N> Predefined Floating Action Button styles provide only a visual indication. Therefore, the [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_Content) property should describe the action for users of assistive technologies such as screen readers.

## Styles customization

To modify the FAB appearance beyond predefined styles, override the component’s default CSS. The following CSS classes map to common styling scenarios. You can also create a custom theme using the [Theme Studio](https://blazor.syncfusion.com/themestudio).

| CSS Class | Purpose of Class |
|-----|----- |
| .e-fab.e-btn | Customize the FAB. |
| .e-fab.e-btn:hover | Customize the FAB on hover. |
| .e-fab.e-btn:focus | Customize the FAB on focus. |
| .e-fab.e-btn:active | Customize the FAB on active state. |
| .e-fab .e-btn-icon | Customize the style of the FAB icon. |

## Show text on hover

Use the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to customize the Floating Action Button to show text on hover with a transition effect.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfFab IconCss="e-icons e-edit" CssClass="fab-hover"><span class="text-container"><span class="textEle">Edit</span></span></SfFab>

<style>

    .e-fab.e-btn.fab-hover {
        padding: 6px 2px 8px 10px;
    }

    .fab-hover .text-container {
        overflow: hidden;
        width: 0;
        margin: 0;
        transition: width .5s linear 0s, margin .2s linear .5s;
    }

    .fab-hover:hover .text-container {
        width: 25px;
        margin-right:10px;
        transition: width .5s linear .2s, margin .2s linear 0s;
    }

</style>

```

![Blazor FAB Component with Hover](./images/onhover.webp)

## Outline customization

Use the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to customize the outline color of the Floating Action Button.

```cshtml

@using Syncfusion.Blazor.Buttons

<div id="target" style="min-height:200px; position:relative; width:300px; border:1px solid;">
    <SfFab Target="#target" Content="Contact" IconCss="e-icons e-people" CssClass="custom-css"></SfFab>
</div>

<style>
.custom-css.e-fab.e-btn {
  border-color: darkgrey;
  border-width: 4px;
}
</style>

```

![Blazor FAB Component with Outline](./images/FabOutline.webp)