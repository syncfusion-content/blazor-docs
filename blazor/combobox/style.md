---
layout: post
title: Style and appearance in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor ComboBox component and more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Style and appearance in Blazor ComboBox Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Read-only mode

Specify the boolean value to the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Readonly) whether the ComboBox allows the user to change the value or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/readonly-mode.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVAiBLQUvNGLyuy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with Readonly mode](./images/style/blazor_combobox_readonly-mode.png)" %}

## Disabled state

Specify the boolean value to the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Enabled) property that indicates whether the component is enabled or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/disabled-state.razor %}

{% endhighlight %}

![Blazor ComboBox with Disabled ](./images/style/blazor_ComboBox_disabled-state.png)

## CssClass  

Specifies the CSS class name that can be appended to the root element of the ComboBox. One or more custom CSS classes can be added to a ComboBox.

Some of the possible values are:

* `e-success`: Denotes the component in a success state, adding a green color to the ComboBox input field.
* `e-warning`: Denotes the component in a warning state, adding an orange color to the ComboBox input field.
* `e-error`: Denotes the component in an error state, adding a red color to the ComboBox input field.
* `e-outline`: Supports only the material theme.
* `e-multi-column`: Provides two or more columns in the popup, aligning the columns like a grid.

{% highlight Razor %}

{% include_relative code-snippet/style/cssclass-properties.razor %}

{% endhighlight %} 

![Blazor ComboBox with CssClass property](./images/style/blazor_combobox_cssclass-property.png)

## Customizing the disabled component’s text color

You can customize the text color of a disabled component by targeting its CSS class `.e-input[disabled]`, which indicates the input element in a disabled state, and set the desired color to the `-webkit-text-fill-color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/disable-text-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhqMVBwUFMudrwO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with Disabled component text color](./images/style/blazor_combobox_disabled-text-color.png)" %}

## Customizing the appearance of container element

You can customize the appearance of the container element within the ComboBox component by targeting its CSS class `.e-input`, which indicates the parent element of the input, and allows you to apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/customizing-appearance.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXhqirLQUlXaeBFy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox container element customization](./images/style/blazor_combobox_appearance-of-container.png)" %}

## Customizing the dropdown icon’s color

You can customize the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons#material) by targeting its CSS class `.e-ddl-icon.e-icons`, which indicates the icon element displayed within the combobox component, and setting the desired color to the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrqMBVQKbirhlfh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox icon color](./images/style/blazor_combobox_icon-color.png)" %}

## Customizing the focus color

You can customize the component color when it is focused by targeting its CSS class `.e-input-focus::after`, which indicates the input element when it is focused, and set the desired color to the `background` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/focus-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLUsVhGUFizesmJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox focus color](./images/style/blazor_combobox_focus-color.png)" %}

## Customizing the outline theme's focus color

You can customize the color of the combobox component when it is in a focused state and rendered with an outline theme,  by targeting its CSS class `e-outline` which indicates the input element when it is focused, and allows you to set the desired color to the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/outline-focus-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhqsVBQKFiQpUgc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox focusing color outline theme](./images/style/blazor_combobox_outline-focus-color.png)" %}

## Customizing the background color of focus, hover, and active items

You can customize the background color and text color of list items within the combobox component when they are in a focused, active, or hovered state by targeting the CSS classes `.e-list-item.e-item-focus`, `.e-list-item.e-active`, and `.e-list-item.e-hover`, and set the desired color to the background-color and color properties.

{% highlight cshtml %}

{% include_relative code-snippet/style/background-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhKWhLwgPKXzzDZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with customizing the focus, hover and active item color](./images/style/blazor_combobox_background-color.png)" %}

## Customizing the appearance of pop-up element

You can customize the appearance of the popup element within the combobox component by targeting the CSS class `.e-list-item.e-item-focus`, which indicates the list item element when it is focused, and and allows you to apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/appearance-popup.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjhqiBVmUPKLSlDK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with customizing popup color](./images/style/blazor_combobox_appearance-of-popup.png)" %}

## Change the HTML attributes

Add the additional html attributes such as styles, class, and more to the root element using the [HTMLAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HtmlAttributes) property and accepts n number of attributes in a key-value pair format.

{% highlight cshtml %}

{% include_relative code-snippet/style/html-attributes.razor %}

{% endhighlight %}

![Blazor ComboBox with different font family](./images/style/blazor_ComboBox_html-attributes.png)

## Show tooltip on list item

You can achieve this behavior by integrating the tooltip component. When the mouse hovers over the ComboBox option, a tooltip appears with information about the hovered list item.

The following code demonstrates how to display a tooltip when hovering over the ComboBox option.

{% highlight cshtml %}

{% include_relative code-snippet/style/combobox-with-tooltip.razor %}

{% endhighlight %}

![Blazor ComboBox with tooltip](./images/style/blazor-combobox-tooltip.png)

## Customize selected item opacity

In the following code , the CSS style that targets the `.e-list-item` class within the `.e-dropdownbase` class when it is in an active or active and hovered state. It sets the opacity property , which will make the elements appear transparent. This can be used to change the appearance of the dropdown list items when they are in a certain state.

![Blazor ComboBox with opacity style](./images/style/blazor_combobox_opacity-style.png)

## Disable specific items in DropDownList

Prevent some items in the popup list from selecting. This can be achieved by disabling the item for a specific combobox component by adding the custom class for the popup element using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property.

In the following code, a single list Item is hidden using js interop.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/style/disable-listitem.razor %}

{% endhighlight %}
{% highlight cshtml tabtitle="~/_Layout.cshtml" %}

<script>
    window.disable = function (id) { 
    setTimeout(function (e) { 
        var liCollections = document.querySelectorAll('.e-popup.e-custom-class .e-list-item') 
        if (liCollections && liCollections.length > 0) 
        liCollections[1].classList.add('e-disabled'); 
        liCollections[1].classList.add('e-overlay'); 
    }, 30); 
 } 
</script>

{% endhighlight %}
{% endtabs %}

## Customizing the float label element's focusing color

You can change the text color of the floating label when it is focused by targeting its CSS classes `.e-input-focus` and `.e-float-text.e-label-top`. These classes indicate the floating label text while it is focused and set the desired color using the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/floatlabel-focusing-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhUsLhGgPhWFokH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with float label focusing color](./images/style/blazor_combobox_floatlabel-focus-color.png)" %}

## Customizing the color of the placeholder text

You can change the color of the placeholder by targeting its CSS class `input.e-input::placeholder`, which indicates the placeholder text, and set the desired color using the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/placeholder-with-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVKMrVQqbhTKwJQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with color placeholder](./images/style/blazor_combobox_placeholder-color.png)" %}

## Customizing the placeholder to add mandatory indicator(*)

The mandatory indicator `*` can be applied to the placeholder by targeting its CSS class `.e-float-text::after` using the `content` style.

{% highlight cshtml %}

{% include_relative code-snippet/style/placeholder-with-mandatory.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVAsVhmKPrHruAI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with mandatory indicator placeholder](./images/style/blazor_combobox_placeholder-with-mandatory.png)" %}

## Customizing the text selection color

The appearance of a selected item within a combobox component can be customized by targeting the CSS class `input.e-input::selection` and set the desired background color and text color. This customization will only be applied when the item is selected manually. To achieve this, use the `background-color` and `color` properties of the CSS class `input.e-input::selection`.

{% highlight cshtml %}

{% include_relative code-snippet/style/text-selection-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLKCVBGgPVvrliw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with customizing the focus, hover and active item color](./images/style/blazor_combobox_text-selection-color.png)" %}