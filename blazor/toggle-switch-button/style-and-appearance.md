---
layout: post
title: Style and Appearance in Blazor Toggle Switch Button | Syncfusion
description: Override default CSS classes to customize Blazor Toggle Switch Button bar, handle, and active states.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Style and Appearance in Blazor Toggle Switch Button

To modify the Switch appearance, the default CSS of Switch component has to be overridden. Find the list of CSS classes and their corresponding sections in the Switch. Also, you have an option to create your own custom theme for the controls using our [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
| ----- | ----- |
| .e-switch-wrapper | To customize the Toggle Switch Button wrapper element. |
| .e-switch-wrapper .e-switch-inner | To customize the bar of the Toggle Switch Button in the off state. |
| .e-switch-wrapper .e-switch-inner.e-switch-active | To customize the bar of the Toggle Switch Button in the on state. |
| .e-switch-wrapper .e-switch-handle | To customize the handle of the Toggle Switch Button in the off state. |
| .e-switch-wrapper .e-switch-handle.e-switch-active | To customize the handle of the Toggle Switch Button in the on state. |
| .e-switch-wrapper .e-switch-on | To customize the **ON** label of the Toggle Switch Button. |
| .e-switch-wrapper .e-switch-off | To customize the **OFF** label of the Toggle Switch Button. |
| .e-switch-wrapper:not(.e-switch-disabled):hover .e-switch-handle:not(.e-switch-active) | To customize the handle of the Toggle Switch Button in the off state on hover. |
| .e-switch-wrapper:not(.e-switch-disabled):hover .e-switch-inner:not(.e-switch-active) | To customize the bar of the Toggle Switch Button in the off state on hover. |
| .e-switch-wrapper:hover .e-switch-handle.e-switch-active | To customize the handle of the Toggle Switch Button in the on state on hover. |
| .e-switch-wrapper:hover .e-switch-inner.e-switch-active .e-switch-on | To customize the bar of the Toggle Switch Button in the on state on hover. |

## See also

* [Customize the appearance of a Blazor Toggle Switch Button](./how-to/customize-the-appearance-of-a-switch.md)