---
layout: post
title: Styles and Appearances in Blazor CheckBox Component | Syncfusion
description: Learn how to customize the Syncfusion Blazor CheckBox appearance using CSS classes, including wrapper, label, hover, and checked states, and explore Theme Studio for custom themes.
platform: Blazor
control: CheckBox
documentation: ug
---

# Styles and Appearances in Blazor CheckBox Component

To modify the [Blazor CheckBox](https://www.syncfusion.com/blazor-components/blazor-checkbox) appearance, override the component’s default CSS classes. The table below lists common CSS hooks and the UI elements they target. Styles can be scoped to specific instances by applying a custom class via the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html) property on the component. You can also create and apply a custom theme using the [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

|CSS Class | Purpose of Class|
|-----|-----|
|.e-checkbox-wrapper .e-frame|Customize the CheckBox frame (the box). |
|.e-checkbox-wrapper:hover .e-frame|Customize the CheckBox frame on hover. |
|.e-checkbox-wrapper .e-label|Customize the CheckBox label text. |
|.e-checkbox-wrapper:hover .e-label|Customize the CheckBox label on hover. |
|.e-checkbox-wrapper .e-frame.e-check|Customize the CheckBox when it is in the checked state. |
|.e-checkbox-wrapper:hover .e-frame.e-check|Customize the checked CheckBox on hover. |