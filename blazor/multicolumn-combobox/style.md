---
layout: post
title: Style and appearance in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor MultiColumn ComboBox component and more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Style and appearance in Blazor MultiColumn ComboBox Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Read-only mode

Specify the boolean value to the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ReadOnly) whether the MultiColumn ComboBox allows the user to change the value or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/readonly-mode.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVAiBLQUvNGLyuy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disabled state

Specify the boolean value to the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Disabled) property that indicates whether the component is disabled or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/disabled-state.razor %}

{% endhighlight %}

## Applying custom CSS classes

Specifies the CSS class name that can be appended to the root element of the MultiColumn ComboBox. One or more custom CSS classes can be added to a MultiColumn ComboBox.

Some of the possible values are:

* `e-success`: Denotes the component in a success state, adding a green color to the ComboBox input field.
* `e-warning`: Denotes the component in a warning state, adding an orange color to the ComboBox input field.
* `e-error`: Denotes the component in an error state, adding a red color to the ComboBox input field.
* `e-outline`: Supports only the material theme.

{% highlight Razor %}

{% include_relative code-snippet/style/cssclass-properties.razor %}

{% endhighlight %} 

## Customizing the disabled component’s text color

You can customize the text color of a disabled component by targeting its CSS class `.e-input[disabled]`, which indicates the input element in a disabled state, and set the desired color to the `-webkit-text-fill-color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/disable-text-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhqMVBwUFMudrwO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
