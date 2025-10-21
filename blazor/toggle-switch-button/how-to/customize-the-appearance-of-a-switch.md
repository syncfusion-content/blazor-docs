---
layout: post
title: Customize the appearance of Blazor Toggle Switch Button | Syncfusion
description: Learn here all about customizing the appearance of a Syncfusion Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Customize the appearance of a Blazor Toggle Switch Button Component

The appearance of the Toggle Switch Button can be customized using CSS. Define the required CSS rules and assign the class name to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) property to apply them to the component.

## Customize Toggle Switch Button bar and handle

Toggle Switch Button bar and handle can be customized using CSS rules by applying a custom class through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) property. In the following example, the border-radius of the `e-switch-inner` and `e-switch-handle` elements is changed from circular to square.

N> For this customization, reference the theme stylesheet used by the application. The example below assumes the Fabric theme and references `fabric.css` from the CDN. If using a different theme (for example, Material, Bootstrap 5, or Fluent), reference the corresponding theme stylesheet instead. This file can be found at the following [CDN](https://cdn.syncfusion.com/ej2/fabric.css) link.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch CssClass="square" @bind-Checked="isSquareChecked"></SfSwitch><br />
<SfSwitch CssClass="custom-switch" @bind-Checked="isCustomChecked"></SfSwitch><br />
<SfSwitch CssClass="handle-text" @bind-Checked="isHandleChecked"></SfSwitch>

@code {
    private bool isSquareChecked = true;
    private bool isCustomChecked = false;
    private bool isHandleChecked = false;
}

<style>
/* Square Switch */
.e-switch-wrapper.square .e-switch-inner,
.e-switch-wrapper.square .e-switch-handle {
  border-radius: 0;
}

/* Customize Handle and Bar Switch */
.e-switch-wrapper.custom-switch {
  width: 50px;
  height: 24px;
}

.e-switch-wrapper.custom-switch .e-switch-handle {
  width: 20px;
  height: 16px;
}

.e-switch-wrapper.custom-switch .e-switch-inner,
.e-switch-wrapper.custom-switch .e-switch-handle {
  border-radius: 0;
}

.e-switch-wrapper.custom-switch .e-switch-handle.e-switch-active {
  left: 42px;
}

/* Customize Handle and Bar Switch */
.e-switch-wrapper.handle-text {
  width: 58px;
  height: 24px;
}

.e-switch-wrapper.handle-text .e-switch-handle {
  width: 26px;
  height: 20px;
  left: 2px;
  background-color: #fff;
}

.e-switch-wrapper.handle-text .e-switch-inner,
.e-switch-wrapper.handle-text .e-switch-handle {
  border-radius: 0;
}

.e-switch-wrapper.handle-text .e-switch-handle.e-switch-active {
  left: 46px;
}

.e-switch-wrapper.handle-text .e-switch-inner.e-switch-active,
.e-switch-wrapper.handle-text:hover .e-switch-inner.e-switch-active .e-switch-on {
  background-color: #4d841d;
  border-color: #4d841d;
}

.e-switch-wrapper.handle-text .e-switch-inner,
.e-switch-wrapper.handle-text .e-switch-off {
  background-color: #e3165b;
  border-color: #e3165b;
}

.e-switch-wrapper.handle-text .e-switch-inner:after,
.e-switch-wrapper.handle-text .e-switch-inner:before {
  font-size: 10px;
  position: absolute;
  line-height: 21px;
  font-family: "Helvetica", sans-serif;
  z-index: 1;
  height: 100%;
  transition: all 200ms cubic-bezier(0.445, 0.05, 0.55, 0.95);
}

.e-switch-wrapper.handle-text .e-switch-inner:before {
  content: "OFF";
  color: #e3165b;
  left: 3px;
}

.e-switch-wrapper.handle-text .e-switch-inner:after {
  content: "ON";
  right: 5px;
  color: #fff;
}

.e-switch-wrapper.handle-text .e-switch-inner.e-switch-active:before {
  color: #fff;
}

.e-switch-wrapper.handle-text .e-switch-inner.e-switch-active:after {
  color: #4d841d;
}

.e-switch-wrapper.handle-text:not(.e-switch-disabled):hover .e-switch-handle:not(.e-switch-active) {
  background-color: #fff;
}
</style>
  ```

![Blazor Toggle Switch Button with Custom Bar](./../images/blazor-toggle-switch-button-custom-bar.png)

## Color the Toggle Switch Button

Toggle Switch Button colors can be customized using CSS rules by adding a custom class through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) property. In the following example, the background and border colors of the `e-switch-inner` and `e-switch-off` elements are changed from their default values.

N> For this customization, reference the theme stylesheet that matches the application. The example below references `bootstrap.css` from the CDN. If using Bootstrap 5, Material, or Fluent themes, include the appropriate theme stylesheet to ensure selectors and variables match. The file can be found at the following [CDN](https://cdn.syncfusion.com/ej2/bootstrap.css) link. When choosing colors, ensure sufficient contrast for accessibility and verify appearance in dark mode and RTL layouts as needed.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch CssClass="bar-color"  @bind-Checked="isBarCheked"></SfSwitch><br />
<SfSwitch CssClass="handle-color"  @bind-Checked="isHandleChecked"></SfSwitch><br />
<SfSwitch CssClass="custom-iOS"  @bind-Checked="isCustomChecked"></SfSwitch>

@code {
  private bool isBarCheked = false;
  private bool isHandleChecked = true;
  private bool isCustomChecked = true;

}
<style>
/* Custom color Switch */
.e-switch-wrapper.bar-color .e-switch-inner.e-switch-active,
.e-switch-wrapper.bar-color:hover .e-switch-inner.e-switch-active .e-switch-on {
  background-color: #4d841d;
  border-color: #4d841d;
}

.e-switch-wrapper.bar-color .e-switch-inner,
.e-switch-wrapper.bar-color .e-switch-off {
  background-color: #e3165b;
  border-color: #e3165b;
}

.e-switch-wrapper.bar-color .e-switch-handle {
  background-color: #fff;
}

/* handle color Switch */
.e-switch-wrapper.handle-color .e-switch-handle {
  background-color: #e3165b;
}

.e-switch-wrapper.handle-color .e-switch-handle.e-switch-active {
  background-color: #4d841d
}

.e-switch-wrapper.handle-color .e-switch-inner.e-switch-active,
.e-switch-wrapper.handle-color:hover .e-switch-inner.e-switch-active .e-switch-on {
  background-color: #fff;
  border-color: #ccc;
}

.e-switch-wrapper.handle-color .e-switch-inner,
.e-switch-wrapper.handle-color .e-switch-off {
  background-color: #fff;
  border-color: #ccc;
}

/* iOS Switch */
.e-switch-wrapper.custom-iOS .e-switch-inner.e-switch-active,
.e-switch-wrapper.custom-iOS:hover .e-switch-inner.e-switch-active .e-switch-on {
  background-color: #3df865;
  border-color: #3df665;
}

.e-switch-wrapper.custom-iOS {
  width: 42px;
  height: 24px;
}

.e-switch-wrapper.custom-iOS .e-switch-handle {
  width: 20px;
  height: 20px;
}

.e-switch-wrapper.custom-iOS .e-switch-handle.e-switch-active {
  margin-left: -22px;
}
</style>

```

![Blazor Toggle Switch Button with Custom Color](./../images/blazor-toggle-switch-button-custom-color.png)