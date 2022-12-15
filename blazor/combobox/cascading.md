---
layout: post
title: Cascading in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Cascading in the Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Cascading in  ComboBox

The Cascading ComboBox is a series of ComboBoxes, where the value of one ComboBox depends on the value selected in another ComboBox value. 

In the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxEvents-2.html#Syncfusion_Blazor_DropDowns_ComboBoxEvents_2_ValueChange) event handler of first ComboBox, load the data for the second ComboBox based on the selected value of the first ComboBox. The same process can be  configured between the second and third ComboBoxes.

In this sample, when a country is selected from the countries ComboBox, the respective states are loaded in the second ComboBox. Similarly, the states and cities ComboBox works.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading.razor %}

{% endhighlight %}

![Cascading in Blazor ComboBox](./images/cascading/blazor_combobox_cascading.gif)

## Cascading with filtering 

In this sample, when a country is selected from the countries ComboBox, the respective StateID, CountryID and Capital are loaded in the below textbox.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading-with-filtering.razor %}

{% endhighlight %}

![Cascading with Filtering in Blazor ComboBox](./images/cascading/blazor_combobox_cascading-with-filtering.png)