---
layout: post
title: Properties in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Properties in the Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Properties in Blazor ComboBox Component

This section explains the list of properties of the DropDown List component 

## AllowCustom

Specifies whether the component allows user defined value which does not exist in data source.

Default value of AllowCustom is `true`.

[Click to refer the code for AllowCustom](https://blazor.syncfusion.com/documentation/combobox/custom-value)

## Autofill

Specifies whether suggest a first matched item in input when searching. No action happens when no matches found.

Default value of Autofill is `false`.

{% highlight Razor %}

{% include_relative code-snippet/properties/Autofill.razor %}

{% endhighlight %} 

## ShowClearButton

Specifies whether to show or hide the clear button.

When the clear button is clicked, `Value`, `Text`, and `Index` properties are reset to null.

Default value of ShowClearButton is `true`.

{% highlight Razor %}

{% include_relative code-snippet/properties/ShowClearButton.razor %}

{% endhighlight %} 


