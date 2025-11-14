---
layout: post
title: Cascading in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Cascading in the Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Cascading in ComboBox

A cascading ComboBox allows you to select an item from a list of options, and the options in the second ComboBox are filtered based on the selection made in the first ComboBox. This allows you to create a hierarchy of comboBox options, where the options in the child ComboBox are dependent on the selection made in the parent ComboBox.

In the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxEvents-2.html#Syncfusion_Blazor_DropDowns_ComboBoxEvents_2_ValueChange) event handler of the first ComboBox, you can load the data for the second ComboBox based on the selected value of the first ComboBox. This process can be repeated between the second and third ComboBoxes to create a cascading effect.

To quickly get started with Cascading in the Blazor ComboBox component, you can watch the video below.

{% youtube "https://www.youtube.com/watch?v=zGGntfBPQNI" %}

In the following example, when a country is selected in the first ComboBox, the list of states for that country is loaded in the second ComboBox. Similarly, when a state is selected in the second ComboBox, the list of cities for that state is loaded in the third ComboBox.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLUsVBmKweKQSWe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Cascading in Blazor ComboBox](./images/cascading/blazor_combobox_cascading.gif)" %}

## Cascading with other form field 

To populate other form fields (such as textboxes) based on the value selected in the ComboBox, you can use the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxEvents-2.html#Syncfusion_Blazor_DropDowns_ComboBoxEvents_2_ValueChange) event of the ComboBox. In the `ValueChange` event handler, you can retrieve the relevant data from your data source and use it to populate the other form fields.

In the following example, the ComboBox displays a list of countries, and the textboxes display the state ID, country ID, and capital of the selected country. When the user selects a different country in the ComboBox, the `ValueChange` event handler is triggered, and the data for the selected country is retrieved from the data source

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading-with-other-form-fields.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BthKWhhGKcenJwTt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Cascading with other form field in Blazor ComboBox](./images/cascading/blazor_combobox_cascading-with-other-form-field.png)" %}

N> [View Sample in Demo](https://blazor.syncfusion.com/demos/combobox/cascading?theme=bootstrap5).