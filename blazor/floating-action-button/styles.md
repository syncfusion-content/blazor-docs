---
layout: post
title: Styles in Blazor Floating Action Button Component | Syncfusion
description: Checkout and learn here all about Styles in Syncfusion Blazor Floating Action Button component and much more.
platform: Blazor
control: Floating Action Button
documentation: ug
---

# Styles in Blazor Floating Action Button Component

This section explains the different styles of Floating Action Button.

## FAB styles

The Blazor Floating Action Button supports the following predefined styles that can be defined using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property. You can customize by replacing the `CssClass` property with the below defined class.

| Class | Description |
| -------- | -------- |
| e-success | Used to represent a positive action. |
| e-outline |  Used to represent an appearance of button with outline. |
| e-info |  Used to represent an informative action. |
| e-warning | Used to represent an action with caution. |
| e-danger | Used to represent a negative action. |

```csharp

@using Syncfusion.Blazor.Buttons

<SfFab CssClass="e-warning" IconCss="e-icons e-edit"></SfFab>

```

![Blazor FAB Component with Styles](./images/Style.png)

N> Predefined Floating Action Button styles provide only the visual indication. So, Floating Action Button [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_Content) property should define the Floating Action Button style for the users of assistive technologies such as screen readers.

## Styles customization

To modify the Floating Action Button appearance, you need to override the default CSS of Floating Action Button component. Please find the list of CSS classes and its corresponding section in Floating Action Button component. Also, you have an option to create your own custom theme for the controls using our [Theme Studio](https://blazor.syncfusion.com/themestudio/).

| CSS Class | Purpose of Class |
|-----|----- |
|.e-fab.e-btn|To customize the FAB.|
|.e-fab.e-btn:hover|To customize the FAB on hover.|
|.e-fab.e-btn:focus|To customize the FAB on focus.|
|.e-fab.e-btn:active|To customize the FAB on active.|
|.e-fab .e-btn-icon|To customize the style of FAB icon.|

## Show text on hover

By using [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass), you can customize the Floating Action Button to show text on hover with applied transition effect.

```csharp

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

![Blazor FAB Component with Hover](./images/onhover.png)

## Outline customization

By using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property, you can customize the outline color of the Floating Action Button.

```csharp

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

![Blazor FAB Component with Outline](./images/FabOutline.png)