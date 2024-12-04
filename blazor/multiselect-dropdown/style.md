---
layout: post
title: Style and appearance in Blazor MultiSelect Dropdown | Syncfusion
description: Learn here all about style and appearance in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Style and appearance in Blazor MultiSelect Dropdown Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Read-only mode

Specify the boolean value to the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Readonly) whether the MultiSelect allows the user to change the value or not.

{% highlight Razor %}

{% include_relative code-snippet/style/readonly-property.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with Readonly property](./images/style/blazor_multiselect_readonly-property.png)

## Disable State 

The SfMultiSelect component has an [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Enabled) property that controls whether the MultiSelect is interactive. Setting `Enabled` to `false` disables the component, making it unclickable and inactive. In contrast, the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Readonly) property, when set to `true`, allows users to view existing selections without modifying them.

{% highlight Razor %}

{% include_relative code-snippet/style/Disable-property.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with Disable property](./images/style/blazor_multiselect_disable-property.png)

### Customizing the disabled component’s text color

You can customize the text color of a disabled component by targeting its CSS class `.e-multiselect.e-disabled`, which indicates the input element in a disabled state, and set the desired color to the `-webkit-text-fill-color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/disable-text-color.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown with Disabled component text color](./images/style/blazor_multiselect_disabled-text-color.png)

## Change remove icon color in chip

To change the remove icon color in a chip within the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiSelect component, you can use the following CSS style to customize it.

{% highlight cshtml %}

{% include_relative code-snippet/style/remove-icon-chip-color.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown with remove icon color in chip](./images/style/blazor_multiselect_remove-icon-chip-color.png)

## Show the custom icon in dropdown icon

You can customize the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons#material) by targeting its CSS class `.e-ddl-icon::before`, which indicates the icon element displayed within the dropdown list component, and set the desired icon to the `content` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon.razor %}

{% endhighlight %}

![Blazor Multiselect with dropdown icon](./images/style/blazor_Multiselect_dropdown-icon.png)

You can customize the dropdown icon for the particular component using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_CssClass) property and add style to the custom class which is mapped to `CssClass`.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-using-cssclass.razor %}

{% endhighlight %}

## Adding Icon in Popup Items

You can customize the MultiSelect dropdown to display icons by mapping a field from the data object to the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_IconCss) property.

{% highlight cshtml %}

{% include_relative code-snippet/style/adding-icon-popup-items.razor %}

{% endhighlight %}

![Blazor Multiselect with adding icon in popup items](./images/style/blazor_Multiselect_adding-icon-popup-items.png)

## Customizing the background color of container element

You can customize the appearance of the container element within the multiselect component by targeting its CSS class `.e-multi-select-wrapper`, which indicates the parent element of the input, and allows you to apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/container-background-color.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown container background color](./images/style/blazor_multiselect_background-color-of-container.png)

## Customizing the dropdown icon’s color

You can customize the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons/#material) by targeting its CSS class `.e-ddl-icon.e-icons`, which indicates the icon element displayed within the multiselect component, and setting the desired color to the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-color.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown icon color](./images/style/blazor_multiselect_icon-color.png)

## CssClass

Specifies the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_CssClass) name that can be appended with the root element of the MultiSelect. One or more custom CSS classes can be added to a MultiSelect.

Some of the possible values are

* `e-success`, which denotes the component in success state that is added green color to the multiselect's input field.
* `e-warning`, which denotes the component in warning state that is added orange color to the multiselect's input field.
* `e-error`, which denotes the component in error state that is added red color to the multiselect's input field.
* `e-outline`, which supports only in material theme.

{% highlight Razor %}

{% include_relative code-snippet/style/cssClass-property.razor %}

{% endhighlight %} 

![Blazor MultiSelect DropDown with CssClass property](./images/style/blazor_multiselect_cssClass-property.png)


## Customizing the appearance of the delimiter container element

You can customize the appearance of the delimiter container element within the multiselect component by targeting its CSS class `.e-delim-values`, which indicates the selected values separated by the delimiter character of the multiselect component, and allows you to apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/appearance-of-delimiter-container.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown appearance of the delimiter container](./images/style/blazor_multiselect__appearance-of-delimiter-container.png)

## Customizing the appearance of chips

You can customize the appearance of the chips within the multiselect component by targeting its CSS classes `.e-chips` and `.e-chipcontent`, which represent the chips of the multiselect component, and apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/appearance-of-chips.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown appearance of chips](./images/style/blazor_multiselect_appearance-of-chips.png)

## Customizing the outline theme's focus color

You can customize the color of the multiselect component when it is in a focused state and rendered with an outline theme, by targeting its CSS class `e-outline` which indicates the input element when it is focused, and allows you to set the desired color to the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/outline-focus-color.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown focusing color outline theme](./images/style/blazor_multiselect_outline-theme-color.png)


## Customizing the background color of focus, hover, and active items

You can customize the background color and text color of list items within the multiselect component when they are in a focused, active, or hovered state by targeting the CSS classes `.e-list-item.e-item-focus`, `.e-list-item.e-active`, and `.e-list-item.e-hover`, and set the desired color to the `background-color` and `color` properties.

{% highlight cshtml %}

{% include_relative code-snippet/style/background-color.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown with customizing the focus, hover and active item color](./images/style/blazor_multiselect_backgroung-color.png)

## Customizing the appearance of pop-up element

Use the following CSS to customize the appearance of popup element.

You can customize the appearance of the popup element within the multiselect component by targeting the CSS class `.e-list-item.e-item-focus`, which indicates the list item element when it is focused, and and allows you to apply any desired styles to the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/appearance-popup.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown with customizing popup color](./images/style/blazor_multiselect_appearance-of-popup.png)

## Change the HTML Attributes

You can add the additional input attributes such as disabled, value, and more to the root element.

If you configured both the property and equivalent input attribute, then the component considers the property value.

{% highlight Razor %}

{% include_relative code-snippet/style/htmlAttributes-property.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with HtmlAttributes property](./images/style/blazor_multiselect_htmlAttributes-property.png)


## Set the various font family for dropdown list elements

The font-family of the multiselect dropdown list can be changed by overriding using the following selector. The overridden can be applied to specific component by adding a class name through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_CssClass) property.

In the following sample, the font family of the MultiSelect, ListItem text in DropDownList and filterInput text are changed.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-font-family.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with different font family](./images/style/blazor_MultiSelect_font-family.png)

## Show tooltip on list item

You can achieve this behavior by integrating the tooltip component. When the mouse hovers over the DropDownList option, a tooltip appears with information about the hovered list item.

The following code demonstrates how to display a tooltip when hovering over the DropDownList option.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-with-tooltip.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown displays Tooltip](./images/blazor-multiselect-dropdown-tooltip.png)

## Change the Width

Gets or sets the width of the component. By default, it sizes based on its parent container dimension.

Default value of [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Width) is `100%`.
 
{% highlight Razor %}

{% include_relative code-snippet/style/width-property.razor %}

{% endhighlight %} 

![Blazor MultiSelect DropDown with Width property](./images/style/blazor_multiselect_width-property.png)

## Disable Specific Items in Dropdown List

The [MultiSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html) provides options for individual items to be either in an enabled or disabled state for specific scenarios. The category of each list item can be mapped through the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_Disabled) field in the data table. Once an item is disabled, it cannot be selected as a value for the component. To configure the disabled item columns, use the `MultiSelectFieldSettings.Disabled` property.

In the following sample, State are grouped according on its category using `Disabled` field.

{% highlight cshtml %}

{% include_relative code-snippet/disabled-items/disabled-items.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLptHMLzPvxxvrZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable Item Method

The disableItem method can be used to handle dynamic changing in disable state of a specific item. Only one item can be disabled in this method. To disable multiple items, this method can be iterated with the items list or array. The disabled field state will to be updated in the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource), when the item is disabled using this method. If the selected item is disabled dynamically, then the selection will be cleared.

| Parameter | Type | Description |
|------|------|------|
| itemValue | <code>string</code> \| <code>number</code> \| <code>boolean</code> \| <code>object</code> | It accepts the string, number, boolean and object type value of the item to be removed. |
| itemIndex | <code>number</code> | It accepts the index of the item to be removed. |

## Customizing the color of the checkbox

You can change the color of the checkbox by targeting the CSS classes `.e-checkbox-wrapper` and `.e-frame.e-check` which indicates the checkbox of the list item element. Set the desired color using the `background-color` and `color` properties.

{% highlight cshtml %}

{% include_relative code-snippet/style/customizing-checkbox.razor %}

{% endhighlight %}

![Blazor Multiselect DropDown with customizing checkbox](./images/style/blazor_multiselect_cutomizing-checkbox.png)

## InputAttributes

You can add the additional input attributes such as disabled, value, and more to the root element.

If you configured both the property and equivalent input attribute, then the component considers the property value.

{% highlight Razor %}

{% include_relative code-snippet/style/inputAttributes-property.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with InputAttributes property](./images/style/blazor_multiselect_inputAttributes-property.png)

## Customization of hiding selected item

By default, the selected items are hidden from the list in the MultiSelect component. You can change this behavior by setting the [HideSelectedItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_HideSelectedItem) property to false. The default value of HideSelectedItem is true.

In the following code, `HideSelectedItem` is set as `false`.

{% highlight Razor %}

{% include_relative code-snippet/style/hideSelectedItem-property.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with HideSelectedItem property](./images/style/blazor_multiselect_hideSelectedItem-property.png)

## Show or Hide Popup after selection

The [EnableCloseOnSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_EnableCloseOnSelect) property is a boolean attribute that determines whether the multi-select component's popup should close or remain open after a user makes a selection. When set to true, the popup will automatically close after a selection is made. When set to false, the popup will remain open after a selection is made. Default value of `EnableCloseOnSelect` is `true`.

{% highlight Razor %}

{% include_relative code-snippet/style/enableCloseOnSelect-property.razor %}

{% endhighlight %} 

![Blazor MultiSelect DropDown with EnableCloseOnSelect property](./images/style/blazor_multiselect_enableCloseOnSelect-property.png)


## Programmatically clearing value

You can clear the value programmatically by accessing the `ClearAsync()` method through an instance of the multiselect. You can bind the click event of a button to the `ClearAsync()` method. When the button is clicked, it will trigger the `ClearAsync()` method on the multiselect, clearing its value.

{% highlight Razor %}

{% include_relative code-snippet/style/clearAsync-method.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with ClearAsync method](./images/style/blazor_multiselect_clearAsync-method.gif)

## Programmatically show and hide spinner

In order to trigger the `HideSpinnerAsync()` and `ShowSpinnerAsync()` methods of the multiselect, you can use buttons. The code provided binds the click event of the button to the corresponding method on the multiselect instance. When the button is clicked, it will trigger the `HideSpinnerAsync()` and `ShowSpinnerAsync()` methods on the multiselect, respectively.

{% highlight Razor %}

{% include_relative code-snippet/style/show-hide-spinnerAsync-method.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with show hide spinner method](./images/style/blazor_multiselect_show-hide-spinnerAsync-method.gif)

## Programmatically focus in and focus out the component

In order to trigger the `FocusAsync()` and `FocusOutAsync()` methods using the instance of the multiselect, you can use buttons. You can bind the click event of the button to the `FocusAsync()` and `FocusOutAsync()` methods. When the button is clicked, it triggers the corresponding method on the multiselect.

{% highlight Razor %}

{% include_relative code-snippet/style/focus-in-out-method.razor %}

{% endhighlight %}

## Popup opening on click

`OpenOnClick` is property of a multi-select component that controls the behavior of the popup. It determines whether the popup should open automatically when the user clicks on the multi-select component or if it should only open when the user clicks on a specific button or icon. Default value of `OpenOnClick` is `true`.

{% highlight Razor %}

{% include_relative code-snippet/style/openOnClick-property.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with OpenOnClick property](./images/style/blazor_multiselect_openOnClick-property.png)
