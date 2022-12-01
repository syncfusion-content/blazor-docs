---
layout: post
title: Cascading in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Cascading in the Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Cascading in  ComboBox

The Cascading ComboBox is the series of ComboBox, where the value of one ComboBox depends on another ComboBox value. 

In the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxEvents-2.html#Syncfusion_Blazor_DropDowns_ComboBoxEvents_2_ValueChange) event handler of first ComboBox, you should load the data for the second ComboBox based on the selected value of first ComboBox. The same has to be configured between second and third ComboBox.

In this sample, if a country is selected from countries DropDownList, the respective states are loaded in the second DropDownList and in the same way states and cities DropDownList works.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading.razor %}

{% endhighlight %}

![Cascading in Blazor ComboBox](./images/cascading/blazor_combobox_cascading.gif)

## Cascading with filtering 

In this sample, if a country is selected from countries ComboBox then the respective StateID, CountryID and Capital are loaded in the below textbox.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading-with-filtering.razor %}

{% endhighlight %}

![Cascading with Filtering in Blazor ComboBox](./images/cascading/blazor_combobox_cascading-with-filtering.png)