---
layout: post
title: Styles and Appearances in Blazor RadioButton Component | Syncfusion
description: Checkout and learn here all about Styles and Appearances in Syncfusion Blazor RadioButton component and more.
platform: Blazor
control: Radio Button
documentation: ug
---

# Styles and Appearances in Blazor RadioButton Component

To modify the RadioButton appearance, override the component’s default CSS. The following table lists common CSS selectors and their purposes within the RadioButton. Ensure custom CSS is loaded after the Syncfusion theme so overrides take effect. A custom theme for all controls can also be created using the [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
| ----- | ----- |
| .e-radio-wrapper | To customize the radio button wrapper. |
| .e-radio + label:hover::before | To customize the radiobutton on hover. |
| .e-radio:checked + label::after, e-radio:checked + label::before | To customize the checked radiobutton. |
| .e-radio:checked:focus + label::before, .e-radio:checked + label:hover::before | To customize the checked radiobutton on hover. |

![Blazor RadioButton with Style and Appearance](./images/blazor-radiobutton-style-and-appearance.png)