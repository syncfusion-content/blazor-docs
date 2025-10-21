---
layout: post
title: Adding Custom value to the Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about adding custom value in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Add a custom value to Blazor ComboBox component

Enable users to enter values that are not present in the data by using the [AllowCustom property on SfComboBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html#Syncfusion_Blazor_DropDowns_SfComboBox_2_AllowCustom). When the typed text does not match any items, an “Add” option appears in the popup. Selecting this option commits the custom value. The default value of AllowCustom is `true`.

To persist the new entry to the underlying data source, handle application logic (for example, in value change handling) to add the custom value to the collection. Users can also commit a custom value with the keyboard (such as pressing Enter) when appropriate.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBACVLQKFyiyoKz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ComboBox with add custom value option](./images/blazor-combobox-custom-value.png)