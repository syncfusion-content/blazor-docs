---
layout: post
title: Style and appearance in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Style and Appearance in Blazor AutoComplete Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Read-only mode

Specify the boolean value to the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Readonly) whether the AutoComplete allows the user to change the value or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/readonly-mode.razor %}

{% endhighlight %}

![Blazor AutoComplete with Readonly mode](./images/style/blazor_autocomplete_readonly-mode.png)

## Disabled state

Specify the boolean value to the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Enabled) property that indicates whether the component is enabled or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/disabled-state.razor %}

{% endhighlight %}

![Blazor AutoComplete with Disabled ](./images/style/blazor_autocomplete_disabled-state.png)

### Customizing the disabled component’s text color

You can customize the text color of a disabled component by targeting its CSS class `.e-input[disabled]`, which indicates the input element in a disabled state, and set the desired color to the `-webkit-text-fill-color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/disable-text-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLUMBspqpbhLCdp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with Disabled component text color](./images/style/blazor_autocomplete_disabled-text-color.png)

## Show the custom icon in dropdown icon

You can customize the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons#material) by targeting its CSS class `.e-ddl-icon::before`, which indicates the icon element displayed within the autocomplete component, and set the desired icon to the `content` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon.razor %}

{% endhighlight %}

![Blazor AutoComplete with dropdown icon](./images/style/blazor_autocomplete_dropdown-icon.png)

You can customize the dropdown icon for the particular component using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property and add style to the custom class which is mapped to `CssClass`.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-using-cssclass.razor %}

{% endhighlight %}

![Blazor AutoComplete with dropdown icon using CssClass](./images/style/blazor_autocomplete_dropdown-icon.png)

## Customizing the appearance of container element

You can customize the appearance of the container element within the autocomplete component by targeting its CSS class `.e-input`, which indicates the parent element of the input, and allows you to apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/customizing-appearance.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLKMhMJAzRFhNRi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete container element customization](./images/style/blazor_autocomplete_appearance-of-container.png)

## Customizing the dropdown icon’s color

You can customize the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons/#material) by targeting its CSS class `.e-ddl-icon.e-icons`, which indicates the icon element displayed within the autocomplete component, and setting the desired color to the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVqCVCfqzcCFPUr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete icon color](./images/style/blazor_autocomplete_icon-color.png)

## Customizing the focus color

You can customize the component color when it is focused by targeting its CSS class `.e-input-focus::after`, which indicates the input element when it is focused, and set the desired color to the `background` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/focus-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNBAMVipgpQeUpvV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete focus color](./images/style/blazor_autocomplete_focus-color.png)

## Customizing the outline theme's focus color

You can customize the color of the autocomplete component when it is in a focused state and rendered with an outline theme,  by targeting its CSS class `e-outline` which indicates the input element when it is focused, and allows you to set the desired color to the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/outline-focus-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhgiBMzAzcPvKba?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete focusing color outline theme](./images/style/blazor_autocomplete_outline-focus-color.png)

## Customizing the background color of focus, hover, and active items

You can customize the background color and text color of list items within the autocomplete component when they are in a focused, active, or hovered state by targeting the CSS classes `.e-list-item.e-item-focus`, `.e-list-item.e-active`, and `.e-list-item.e-hover`, and set the desired color to the background-color and color properties.

{% highlight cshtml %}

{% include_relative code-snippet/style/background-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhUirWJAIjRQrXM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with customizing the focus, hover and active item color](./images/style/blazor_autocomplete_background-color.png)

## Customizing the appearance of popup element

You can customize the appearance of the popup element within the autocomplete component by targeting the CSS class `.e-list-item.e-item-focus`, which indicates the list item element when it is focused, and and allows you to apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/appearance-popup.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVAMBMTKeChemce?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with customizing popup color](./images/style/blazor_autocomplete_appearance-of-popup.png)

## Change the HTML attributes

Add the additional html attributes such as styles, class, and more to the root element using the [HTMLAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HtmlAttributes) property and accepts n number of attributes in a key-value pair format.

{% highlight cshtml %}

{% include_relative code-snippet/style/html-attributes.razor %}

{% endhighlight %}

![Blazor AutoComplete with different font family](./images/style/blazor_autocomplete_html-attributes.png)

## Set the various font family for autocomplete elements

The font-family of the autocomplete can be changed by overriding using the following selector. The overridden can be applied to specific component by adding a class name through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property.

In the following sample, the font family of the AutoComplete, ListItem text in AutoComplete and filterInput text are changed.

{% highlight cshtml %}

{% include_relative code-snippet/style/autocomplete-font-family.razor %}

{% endhighlight %}

![Blazor AutoComplete with different font family](./images/style/blazor_autocomplete_font-family.png)

## Show tooltip on list item

You can achieve this behavior by integrating the tooltip component. When the mouse hovers over the AutoComplete option, a tooltip appears with information about the hovered list item.

The following code demonstrates how to display a tooltip when hovering over the AutoComplete option.

{% highlight cshtml %}

{% include_relative code-snippet/style/autocomplete-with-tooltip.razor %}

{% endhighlight %}

![Blazor AutoComplete with tooltip](./images/style/blazor-autocomplete-tooltip.png)

## Customize selected item opacity

In the following code , the CSS style that targets the `.e-list-item` class within the `.e-dropdownbase` class when it is in an active or active and hovered state. It sets the opacity property , which will make the elements appear transparent. This can be used to change the appearance of the autocomplete list items when they are in a certain state.

{% highlight cshtml %}

{% include_relative code-snippet/style/autocomplete-with-opacity-style.razor %}

{% endhighlight %}

![Blazor AutoComplete with opacity style](./images/style/blazor_autocomplete_opacity-style.png)

## Customizing the height

### Height of AutoComplete

Use the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupHeight) property to change the height of the popup.

{% highlight cshtml %}

{% include_relative code-snippet/style/popup-height.razor %}

{% endhighlight %}

![Blazor AutoComplete with Popup height](./images/style/blazor_autocomplete_height.png)

### Width of AutoComplete

To customize the width of the popup alone, use the [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupWidth) property. By default, the popup width is set based on the component's width. Use the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Width) to change the width of the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/popup-width.razor %}

{% endhighlight %}

![Blazor AutoComplete with Popup Width](./images/style/blazor_autocomplete_width-popup-width.png)

## Disable specific items in AutoComplete

Prevent some items in the popup list from selecting. This can be achieved by disabling the item for a specific dropdown list component by adding the custom class for the popup element using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property.

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

![Blazor AutoComplete with Popup Width](./images/style/blazor_autocomplete_disable-listitem.png)

## Adding search icon in the Blazor AutoComplete component.

You can add the search icon to the AutoComplete component by overriding the content of the existing icon. The following code demonstrates how to add a search icon to the AutoComplete component.

{% highlight cshtml %}

{% include_relative code-snippet/style/adding-search-icon.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrAChsTqeiSPGka?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete Search Icon](./images/blazor_searchicon_autocomplete.png)

## Customizing the float label element's focusing color

You can change the text color of the floating label when it is focused by targeting its CSS classes `.e-input-focus` and `.e-float-text.e-label-top`. These classes indicate the floating label text while it is focused and set the desired color using the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/floatlabel-focusing-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrgMrMfUfPwJAuJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with float label focusing color](./images/style/blazor_autocomplete_floatlabel-focus-color.png)

## Customizing the color of the placeholder text

You can change the color of the placeholder by targeting its CSS class `input.e-input::placeholder`, which indicates the placeholder text, and set the desired color using the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/placeholder-with-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrKiLszgzkMoAhv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with color placeholder](./images/style/blazor_autocomplete_placeholder-color.png)

## Customizing the placeholder to add mandatory indicator(*)

The mandatory indicator `*` can be applied to the placeholder by targeting its CSS class `.e-float-text::after` using the `content` style.

{% highlight cshtml %}

{% include_relative code-snippet/style/placeholder-with-mandatory.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrgCBCfqpEyZQOn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with mandatory indicator placeholder](./images/style/blazor_autocomplete_placeholder-with-mandatory.png)

## Customizing the text selection color

The appearance of a selected item within a AutoComplete component can be customized by targeting the CSS class `input.e-input::selection` and set the desired background color and text color. This customization will only be applied when the item is selected manually. To achieve this, use the `background-color` and `color` properties of the CSS class `input.e-input::selection`.

{% highlight cshtml %}

{% include_relative code-snippet/style/text-selection-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVgMBsJUzucuFKB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ComboBox with customizing the focus, hover and active item color](./images/style/blazor_autocomplete_text-selection-color.png)
