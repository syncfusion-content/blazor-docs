---
layout: post
title: Cascading in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Cascading in the Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Cascading in ComboBox

A cascading ComboBox filters the options of a child ComboBox based on the selection made in the parent ComboBox. This enables a hierarchy of ComboBox options, where child options depend on the parent’s selected value.

Use the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxEvents-2.html#Syncfusion_Blazor_DropDowns_ComboBoxEvents_2_ValueChange) event of the parent ComboBox to load and bind data for the child ComboBox based on the selected value. This pattern can be repeated (parent → child → grandchild) to create multi-level cascading.

To quickly get started with cascading in the Blazor ComboBox component, watch the following video.

{% youtube "https://www.youtube.com/watch?v=zGGntfBPQNI" %}

In the following example, selecting a country in the first ComboBox loads its states in the second ComboBox. Selecting a state then loads the corresponding cities in the third ComboBox.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLUsVBmKweKQSWe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Cascading in Blazor ComboBox](./images/cascading/blazor_combobox_cascading.gif)" %}

## Cascading with other form field 

To populate other form fields (such as textboxes) based on the selected value in a ComboBox, handle the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxEvents-2.html#Syncfusion_Blazor_DropDowns_ComboBoxEvents_2_ValueChange) event. In the handler, retrieve the related data from the source and assign it to the target fields.

In the following example, the ComboBox lists countries, and textboxes display the state ID, country ID, and capital for the selected country. When a different country is chosen, the `ValueChange` event triggers and updates the related fields.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading-with-other-form-fields.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BthKWhhGKcenJwTt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Cascading with other form field in Blazor ComboBox](./images/cascading/blazor_combobox_cascading-with-other-form-field.png)" %}

N> [View the cascading ComboBox demo](https://blazor.syncfusion.com/demos/combobox/cascading?theme=bootstrap5).