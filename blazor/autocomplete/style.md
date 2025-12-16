---
layout: post
title: Style and appearance in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Style and Appearance in Blazor AutoComplete Component

The following content explains the CSS structure and options that can be used to modify the component’s appearance based on user preferences and theming requirements.

## Read-only mode

Specify a boolean value for the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Readonly) property to control whether the AutoComplete allows the user to change the value.

{% highlight cshtml %}

{% include_relative code-snippet/style/readonly-mode.razor %}

{% endhighlight %}

![Blazor AutoComplete showing read-only mode](./images/style/blazor_autocomplete_readonly-mode.png)

## Disabled state

Specify a boolean value for the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Enabled) property to indicate whether the component is enabled.

{% highlight cshtml %}

{% include_relative code-snippet/style/disabled-state.razor %}

{% endhighlight %}

![Blazor AutoComplete in a disabled state](./images/style/blazor_autocomplete_disabled-state.png)

### Customizing the disabled component’s text color

Customize the text color of a disabled component by targeting the `.e-input[disabled]` selector (the input element in a disabled state) and setting the desired color using the `-webkit-text-fill-color` property. For broader browser coverage, consider also setting the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/disable-text-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLUMBspqpbhLCdp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete with Disabled component text color](./images/style/blazor_autocomplete_disabled-text-color.png)" %}

## Show the custom icon in dropdown icon

Customize the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons#material) by targeting the `.e-ddl-icon::before` selector (the icon element in the AutoComplete) and setting the desired glyph via the `content` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon.razor %}

{% endhighlight %}

![Blazor AutoComplete with a custom dropdown icon](./images/style/blazor_autocomplete_dropdown-icon.png)

Customize the dropdown icon for a specific component instance using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property and apply styles to that custom class.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-using-cssclass.razor %}

{% endhighlight %}

![Blazor AutoComplete with a custom dropdown icon using CssClass](./images/style/blazor_autocomplete_dropdown-icon.png)

## Customizing the appearance of container element

Customize the container element within the AutoComplete by targeting the `.e-input` selector (the parent element of the input), and apply the desired styles to change the component’s appearance.

{% highlight cshtml %}

{% include_relative code-snippet/style/customizing-appearance.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLKMhMJAzRFhNRi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete container element customization](./images/style/blazor_autocomplete_appearance-of-container.png)" %}

## Customizing the dropdown icon’s color

Customize the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons) color by targeting the `.e-ddl-icon.e-icons` selector and setting the desired value for the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVqCVCfqzcCFPUr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete icon color](./images/style/blazor_autocomplete_icon-color.png)" %}

## Customizing the focus color

Customize the component’s color when focused by targeting the `.e-input-focus::after` selector (the input element when focused) and setting the desired `background` value.

{% highlight cshtml %}

{% include_relative code-snippet/style/focus-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNBAMVipgpQeUpvV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete focus color](./images/style/blazor_autocomplete_focus-color.png)" %}

## Customizing the outline theme's focus color

Customize the focus appearance when using an outline theme by targeting the `e-outline` variant selectors for the input. Adjust the relevant focus styles (such as border or outline color) to achieve the desired effect.

{% highlight cshtml %}

{% include_relative code-snippet/style/outline-focus-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhgiBMzAzcPvKba?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete focusing color outline theme](./images/style/blazor_autocomplete_outline-focus-color.png)" %}

## Customizing the background color of focus, hover, and active items

Customize the background and text colors of list items when focused, active, or hovered by targeting `.e-list-item.e-item-focus`, `.e-list-item.e-active`, and `.e-list-item.e-hover`, and set the `background-color` and `color` properties as needed.

{% highlight cshtml %}

{% include_relative code-snippet/style/background-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhUirWJAIjRQrXM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete with customizing the focus, hover and active item color](./images/style/blazor_autocomplete_background-color.png)" %}

## Customizing the appearance of popup element

Customize the popup element within the AutoComplete by targeting the `.e-list-item.e-item-focus` selector (the list item when focused) and applying the desired styles to adjust the popup’s appearance.

{% highlight cshtml %}

{% include_relative code-snippet/style/appearance-popup.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVAMBMTKeChemce?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete with customizing popup color](./images/style/blazor_autocomplete_appearance-of-popup.png)" %}

## Change the HTML attributes

Add additional HTML attributes, such as styles and classes, to the root element using the [HTMLAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HtmlAttributes) property, which accepts any number of attributes in key–value pair format.

{% highlight cshtml %}

{% include_relative code-snippet/style/html-attributes.razor %}

{% endhighlight %}

![Blazor AutoComplete with a custom font family via HTMLAttributes](./images/style/blazor_autocomplete_html-attributes.png)

## Set the various font family for autocomplete elements

Change the font family by overriding the relevant selectors. To scope the override to a specific component instance, add a class via the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property and target that class.

In the following sample, the font family of the AutoComplete input, list item text, and filter input text is changed.

{% highlight cshtml %}

{% include_relative code-snippet/style/autocomplete-font-family.razor %}

{% endhighlight %}

![Blazor AutoComplete with a different font family](./images/style/blazor_autocomplete_font-family.png)

## Show tooltip on list item

This behavior can be achieved by integrating the Tooltip component so that when the mouse hovers over an AutoComplete option, a tooltip displays information about the hovered list item. For details, see the Tooltip component documentation.

The following code demonstrates how to display a tooltip when hovering over an AutoComplete option.

{% highlight cshtml %}

{% include_relative code-snippet/style/autocomplete-with-tooltip.razor %}

{% endhighlight %}

![Blazor AutoComplete showing a tooltip on list items](./images/style/blazor-autocomplete-tooltip.png)

## Customize selected item opacity

In the following code, CSS targets the `.e-list-item` elements within `.e-dropdownbase` when in an active or active-and-hovered state, setting the `opacity` property to adjust visual prominence. This changes the appearance of AutoComplete list items in those states.

{% highlight cshtml %}

{% include_relative code-snippet/style/autocomplete-with-opacity-style.razor %}

{% endhighlight %}

![Blazor AutoComplete with customized selected item opacity](./images/style/blazor_autocomplete_opacity-style.png)

## Customizing the height

### Height of AutoComplete

Use the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupHeight) property to change the height of the popup.

{% highlight cshtml %}

{% include_relative code-snippet/style/popup-height.razor %}

{% endhighlight %}

![Blazor AutoComplete with a custom popup height](./images/style/blazor_autocomplete_height.png)

### Width of AutoComplete

To customize the width of the popup alone, use the [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupWidth) property. By default, the popup width is set based on the component’s width. Use the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDownList_2_Width) property to change the width of the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/popup-width.razor %}

{% endhighlight %}

![Blazor AutoComplete with a custom popup width](./images/style/blazor_autocomplete_width-popup-width.png)

## Disable specific items in AutoComplete

Prevent some items in the popup list from being selected by disabling specific items for a particular component instance. This can be achieved by adding a custom class to the popup element using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDownList_2_CssClass) property and applying styles for that class.

In the following code, a single list item is disabled using JavaScript interop.

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

![Blazor AutoComplete with a disabled list item](./images/style/blazor_autocomplete_disable-listitem.png)

## Adding search icon in the Blazor AutoComplete component.

Add a search icon to the AutoComplete by overriding the content of the existing icon. The following code demonstrates how to add a search icon.

{% highlight cshtml %}

{% include_relative code-snippet/style/adding-search-icon.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrAChsTqeiSPGka?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete Search Icon](./images/blazor_searchicon_autocomplete.png)" %}

## Customizing the float label element's focusing color

Change the text color of the floating label on focus by targeting `.e-input-focus` and `.e-float-text.e-label-top` (the focused floating label text) and setting the desired `color`.

{% highlight cshtml %}

{% include_relative code-snippet/style/floatlabel-focusing-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrgMrMfUfPwJAuJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete with float label focusing color](./images/style/blazor_autocomplete_floatlabel-focus-color.png)" %}

## Customizing the color of the placeholder text

Change the color of the placeholder by targeting `input.e-input::placeholder` (the placeholder text) and setting the desired `color`.

{% highlight cshtml %}

{% include_relative code-snippet/style/placeholder-with-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrKiLszgzkMoAhv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete with color placeholder](./images/style/blazor_autocomplete_placeholder-color.png)" %}

## Customizing the placeholder to add mandatory indicator(*)

Apply a mandatory indicator `*` to the placeholder by targeting `.e-float-text::after` and using the `content` style.

{% highlight cshtml %}

{% include_relative code-snippet/style/placeholder-with-mandatory.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrgCBCfqpEyZQOn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete with mandatory indicator placeholder](./images/style/blazor_autocomplete_placeholder-with-mandatory.png)" %}

## Customizing the text selection color

Customize the text selection appearance within the AutoComplete input by targeting `input.e-input::selection` and setting the desired `background-color` and `color`. This customization applies when text is selected manually.

{% highlight cshtml %}

{% include_relative code-snippet/style/text-selection-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVgMBsJUzucuFKB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with customizing the focus, hover and active item color](./images/style/blazor_autocomplete_text-selection-color.png)" %}
