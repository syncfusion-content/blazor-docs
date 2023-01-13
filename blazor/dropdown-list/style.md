---
layout: post
title: Style and appearance in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Style and Appearance in Dropdown List

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Read-only mode

Specify the boolean value to the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Readonly) whether the DropDownList allows the user to change the value or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/readonly-mode.razor %}

{% endhighlight %}

![Blazor DropDownList with Readonly mode](./images/style/blazor_dropdown_readonly-mode.png)

## Disabled state

Specify the boolean value to the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Enabled) property that indicates whether the component is enabled or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/disabled-state.razor %}

{% endhighlight %}

![Blazor DropDownList with Disabled ](./images/style/blazor_dropdown_disabled-state.png)

## CssClass  

Specifies the CSS class name that can be appended with the root element of the DropDownList. One or more custom CSS classes can be added to a DropDownList.

Some of the possible values are

* `e-success`, which denotes the component in success state that is added green color to the dropdownlist's input field.
* `e-warning`, which denotes the component in warning state that is added orange color to the dropdownlist's input field.
* `e-error`, which denotes the component in error state that is added red color to the dropdownlist's input field.
* `e-outline`, which supports only in material theme.
* `e-multi-column`, which provides two or more columns in the popup and the column will be aligned like grid.

{% highlight Razor %}

{% include_relative code-snippet/style/cssclass-properties.razor %}

{% endhighlight %} 

![Blazor DropDownList with CssClass property](./images/style/blazor_dropdown_cssclass-property.png)

## Customizing the disabled component’s text color

You can customize the disabled component’s text color by using the following CSS selector. This selector targets the input element when it is in a disabled state and sets the desired color to the `-webkit-text-fill-color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/disable-text-color.razor %}

{% endhighlight %}

![Blazor DropDownList with Disabled component text color](./images/style/blazor_dropdown_disable-text-color.png)

## Show the custom icon in dropdown icon

You can customize the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons/#material) using the following CSS selector. This selector targets the icon element that is displayed within the dropdown list component and set the desired icon to the `content` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon.razor %}

{% endhighlight %}

![Blazor DropDownList with dropdown icon](./images/style/blazor_dropdown_dropdown-icon.png)

You can customize the dropdown icon for the particular component using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property and add style to the custom class which is mapped to `CssClass`.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-using-cssclass.razor %}

{% endhighlight %}

![Blazor DropDownList with dropdown icon using CssClass](./images/style/blazor_dropdown_dropdown-icon.png)

## Customizing the appearance of container element

You can customize the appearance of the container element within the dropdown list component using the following CSS selector. This selector targets the parent element of the input and allows you to apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/customizing-appearance.razor %}

{% endhighlight %}

![Blazor DropDownList container element customization](./images/style/blazor_dropdown_appearance-of-container.png)

## Customizing the dropdown icon’s color

You can customize the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons/#material) using the following CSS selector. This selector targets the icon element that is displayed within the dropdown list component and you can  set the desired color to the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-color.razor %}

{% endhighlight %}

![Blazor DropDownList icon color](./images/style/blazor_dropdown_icon-color.png)

## Customizing the focus color

You can customize the component color while focusing using the following CSS selector. This selector targets the input element when it is focused and you can set the desired color to the `background` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/focus-color.razor %}

{% endhighlight %}

![Blazor DropDownList focus color](./images/style/blazor_dropdown_focus-color.png)

## Customizing the outline theme's focus color

You can customize the color of the dropdown list component when it is in a focused state and rendered with an outline theme, by using the `e-outline` class in the CSS selector. This selector targets the input element when it is focused, and allows you to set the desired color to the color property.

{% highlight cshtml %}

{% include_relative code-snippet/style/outline-focus-color.razor %}

{% endhighlight %}

![Blazor DropDownList focusing color outline theme](./images/style/blazor_dropdown_focusing-color-of-outline-theme.png)

Use the `e-outline` to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property to achieve the outline theme.

{% highlight cshtml %}

{% include_relative code-snippet/style/outline-theme.razor %}

{% endhighlight %}

![Blazor DropDownList with outline theme](./images/style/blazor_dropdown_outline-theme.png)

## Customizing the background color of focus, hover, and active items

You can customize the background color and text color of the list items within the dropdown list component when they are in a focused, active, or hovered state using the following CSS selectors. This selector targets the list item element when it is focused, active, and hovered, and allows you to set the desired background color to the `background-color` property and desired text color to the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/background-color.razor %}

{% endhighlight %}

![Blazor DropDownList with customizing the focus, hover and active item color](./images/style/blazor_dropdown_focus-hover-activeitem-color.png)

## Customizing the appearance of pop-up element

You can customize the appearance of the popup element within the dropdown list component by using the following CSS selector. This selector targets the list item element when it is focused and allows you to apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/appearance-popup.razor %}

{% endhighlight %}

![Blazor DropDownList with customizing popup color](./images/style/blazor_dropdown_popup-color.png)

## Change the HTML attributes

Add the additional html attributes such as styles, class, and more to the root element using the [HTMLAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HtmlAttributes) property and accepts n number of attributes in a key-value pair format..

{% highlight cshtml %}

{% include_relative code-snippet/style/html-attributes.razor %}

{% endhighlight %}

![Blazor DropDownList with different font family](./images/style/blazor_dropdown_html-attributes.png)

## Change the InputAttributes

You can add the additional input attributes such as disabled, value, and more to the root element.

If you configured both the property and equivalent input attribute, then the component considers the property value.

{% highlight Razor %}

{% include_relative code-snippet/style/inputAttributes-property.razor %}

{% endhighlight %} 

![Blazor DropDownList with HtmlAttributes property](./images/style/blazor_dropdown_input-attributes-propety.png)


## Set the various font family for dropdown list elements

The font-family of the dropdown list can be changed by overriding using the following selector. The overridden can be applied to specific component by adding a class name through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property.

In the following sample, the font family of the Dropdownlist, ListItem text in dropdownlist and filterInput text are changed.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-font-family.razor %}

{% endhighlight %}

![Blazor DropDownList with different font family](./images/style/blazor_dropdown_font-family.png)

## Show tooltip on list item

You can achieve this behavior by integrating the tooltip component. When the mouse hovers over the DropDownList option, a tooltip appears with information about the hovered list item.

The following code demonstrates how to display a tooltip when hovering over the DropDownList option.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-with-tooltip.razor %}

{% endhighlight %}

![Blazor DropDownList with tooltip](./images/style/blazor-dropdownlist-tooltip.png)

## Customize selected item opacity

Set the opacity to the selected item using the following selector.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-with-opacity-style.razor %}

{% endhighlight %}

![Blazor DropDownList with opacity style](./images/style/blazor_dropdown_opacity-style.png)

## Customizing the height

### Height of dropdownlist

Use the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupHeight) property to change the height of the popup.

{% highlight cshtml %}

{% include_relative code-snippet/style/popup-height.razor %}

{% endhighlight %}

![Blazor DropDownList with Popup height](./images/style/blazor_dropdown_height.png)

### Width of dropdownlist

To customize the width of the popup alone, use the [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupWidth) property. By default, the popup width is set based on the component's width. Use the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Width) to change the width of the component.You can also set the Width in pixel values. Default value of `Width` is `100%`.

{% highlight cshtml %}

{% include_relative code-snippet/style/popup-width.razor %}

{% endhighlight %}

![Blazor DropDownList with Popup Width](./images/style/blazor_dropdown_width-popup-width.png)

## Disable specfic items in dropdown list

Prevent some items in the popup list from selecting. This can be achieved by disabling the item for a specific dropdownlist component by adding the custom class for the popup element using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property.

In the following code, a single list Item is hidden using jsinterop.

{% highlight cshtml %}

{% include_relative code-snippet/style/disable-listitem.razor %}

{% endhighlight %}

{% tabs %}
{% highlight razor tabtitle="~/_Layout.cshtml" %}

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

![Blazor DropDownList with Popup Width](./images/style/blazor_dropdown_disable-listitem.png)
