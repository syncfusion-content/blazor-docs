---
layout: post
title: Properties in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about Properties in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Properties in Blazor MultiSelect Dropdown Component

This section explains the list of properties of the MultiSelect DropDown List component. 

## AllowCustomValue

Allows user to add a Custom value the value which is not present in the suggestion list.

Default value of AllowCustomValue is `false`

[Click to refer the code for AllowCustomValue](https://blazor.syncfusion.com/documentation/multiselect-dropdown/custom-value)

## AllowFiltering

To enable the filtering option in this component.

Filter action performs when type in search box and collect the matched item through `Filtering` event.

If searching character does not match, `NoRecordsTemplate` property value will be shown.

[Click to refer the code for AllowFiltering](https://blazor.syncfusion.com/documentation/multiselect-dropdown/filtering)

## CssClass

Specifies the CSS class name that can be appended with the root element of the MultiSelect. One or more custom CSS classes can be added to a MultiSelect.

Possible values are

* `e-success`, which denotes the component in success state that is added green color to the dropdownlist's input field.
* `e-warning`, which denotes the component in warning state that is added orange color to the dropdownlist's input field.
* `e-error`, which denotes the component in error state that is added red color to the dropdownlist's input field.
* `e-outline`, which supports only in material theme.

{% highlight Razor %}

{% include_relative code-snippet/properties/CssClass.razor %}

{% endhighlight %} 

## DelimiterChar

Sets the delimiter character for 'default' and 'delimiter' visibility modes. DelimiterChar is applicable only in default and delimiter mode.

Default value of DelimiterChar is `,`.

{% highlight Razor %}

{% include_relative code-snippet/properties/DelimiterChar.razor %}

{% endhighlight %} 

## EnableChangeOnBlur

By default, the MultiSelect component fires the Change event while focus out the component.

If you want to fires the Change event on every value selection and remove, then disable the EnabledChangeOnBlur property.

Default value of EnableChangeOnBlur is `true`.

{% highlight Razor %}

{% include_relative code-snippet/properties/EnableChangeOnBlur.razor %}

{% endhighlight %} 

## EnableCloseOnSelect

Based on the property, when item get select popup visibility state will changed.

Default value of EnableCloseOnSelect is `true`.

{% highlight Razor %}

{% include_relative code-snippet/properties/EnableCloseOnSelect.razor %}

{% endhighlight %} 

## EnableGroupCheckBox

Specifies a boolean value that indicates the whether the grouped list items are allowed to check by checking the group header in checkbox mode.

By default, there is no checkbox provided for group headers.

This property allows you to render checkbox for group headers and to select all the grouped items at once.

Default value of EnableGroupCheckBox is `false`.

[Click to refer the code for EnableGroupCheckBox](https://blazor.syncfusion.com/documentation/multiselect-dropdown/checkbox-grouping)

## EnableRtl

Enable or disable rendering component in right to left direction.

Default value ofEnableRtl is `false`.

{% highlight Razor %}

{% include_relative code-snippet/properties/EnableRtl.razor %}

{% endhighlight %} 

## EnableSelectionOrder

Reorder the selected items in popup visibility state.

Default value of EnableSelectionOrder is `true`.

[Click to refer the code for EnableSelectionOrder](https://blazor.syncfusion.com/documentation/multiselect-dropdown/checkbox-grouping)

## EnableVirtualization

The Virtual Scrolling feature is used to display a large amount of data that you require without buffering the entire load of a huge database records in the DropDowns, that is, when scrolling, the datamanager request is sent to fetch some amount of data from the server dynamically. To achieve this scenario with DropDowns, set the EnableVirtualization to true.

[Cleck to refer the code for EnableVirtualization](https://blazor.syncfusion.com/documentation/multiselect-dropdown/virtualization)

## FilterBarPlaceholder

Accepts the value to be displayed as a watermark text on the filter bar. FilterBarPlaceholder is applicable when AllowFiltering is used as true in the checkbox mode. FilterBarPlaceholder is depends on [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_AllowFiltering) in checkbox mode.

{% highlight Razor %}

{% include_relative code-snippet/properties/FilterBarPlaceholder.razor %}

{% endhighlight %} 

## FloatLabelType

Specifies the floating label behavior of the MultiSelect that the placeholder text floats above the MultiSelect based on the following values. FloatLabelType is applicable only when Placeholder is used.FloatLabelType is depends on [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Placeholder)

Possible values are:

* `Never` - Never floats the label in the MultiSelect when the placeholder is available.
* `Always` - The floating label always floats above the MultiSelect.
* `Auto` - The floating label floats above the MultiSelect after focusing it or when enters the value in it.

{% highlight Razor %}

{% include_relative code-snippet/properties/FloatLabelType.razor %}

{% endhighlight %}

## FooterTemplate

Accepts the template design and assigns it to the footer container of the popup list.

[Click to refer the code for FooterTemplate](https://blazor.syncfusion.com/documentation/multiselect-dropdown/templates#footer-template)

## HeaderTemplate

Accepts the template design and assigns it to the header container of the popup list.

[Click to refer the code for HeaderTemplate](https://blazor.syncfusion.com/documentation/multiselect-dropdown/templates#header-template)

## HideSelectedItem

Hides the selected item from the list item.

Default value of HideSelectedItem is `true`.

{% highlight Razor %}

{% include_relative code-snippet/properties/HideSelectedItem.razor %}

{% endhighlight %}

## HtmlAttributes

You can add the additional input attributes such as disabled, value, and more to the root element.

If you configured both the property and equivalent input attribute, then the component considers the property value.

{% highlight Razor %}

{% include_relative code-snippet/properties/HtmlAttributes.razor %}

{% endhighlight %}

## ID

Specifies the id of the MultiSelect component.

{% highlight Razor %}

{% include_relative code-snippet/properties/ID.razor %}

{% endhighlight %}

## InputAttributes

You can add the additional input attributes such as disabled, value, and more to the root element.

If you configured both the property and equivalent input attribute, then the component considers the property value.

{% highlight Razor %}

{% include_relative code-snippet/properties/InputAttributes.razor %}

{% endhighlight %}

## ItemsCount

The data can be fetched in popup based on ItemsCount, when enabled the EnableVirtualization. ItemsCount is applicable only when EnableVirtualization is used as true. ItemsCount is depends on [EnableVirtualization](https://blazor.syncfusion.com/documentation/multiselect-dropdown/virtualization)

Default value of ItemsCount is `5`.

{% highlight Razor %}

{% include_relative code-snippet/properties/ItemsCount.razor %}

{% endhighlight %}

## MaximumSelectionLength

Sets limitation to the value selection.

Based on the limitation, list selection will be prevented

Default value of MaximumSelectionLength is `1000`.

{% highlight Razor %}

{% include_relative code-snippet/properties/MaximumSelectionLength.razor %}

{% endhighlight %}

## Mode

configures visibility mode for component interaction.

Default value of Mode is `Default`.

Possible values are:

* `Box` - selected items will be visualized in chip.
* `Delimiter` - selected items will be visualized in text content.
* `Default` - on focus in component will act in box mode. on blur component will act in delimiter mode.
* `CheckBox` - The ‘checkbox’ will be visualized in list item.

[Click to refer the code for Mode](https://blazor.syncfusion.com/documentation/multiselect-dropdown/checkbox)

## OpenOnClick

Whether to automatically open the popup when the control is clicked.

Default value of OpenOnClick is `true`.

{% highlight Razor %}

{% include_relative code-snippet/properties/OpenOnClick.razor %}

{% endhighlight %}

## Placeholder

Specifies the text that is shown as a hint or placeholder until the user focuses or enter a value in MultiSelect. The property is depending on the FloatLabelType property.

{% highlight Razor %}

{% include_relative code-snippet/properties/Placeholder.razor %}

{% endhighlight %}

## PopupHeight

Gets or sets the height of the popup list. By default, it renders based on its list item.

Default value of PopupHeight is `300px`.

{% highlight Razor %}

{% include_relative code-snippet/properties/Size.razor %}

{% endhighlight %}

## PopupWidth

Gets or sets the width of the popup list and percentage values has calculated based on input width.

Default value of PopupWidth is `100%`.

{% highlight Razor %}

{% include_relative code-snippet/properties/Size.razor %}

{% endhighlight %}

## Readonly

Specifies the boolean value whether the MultiSelect allows the user to change the value.

Default value of Readonly is `false`.

{% highlight Razor %}

{% include_relative code-snippet/properties/Readonly.razor %}

{% endhighlight %}

## SelectAllText

Specifies the selectAllText to be displayed on the component.

Default value of SelectAllText is `Select All`

{% highlight Razor %}

{% include_relative code-snippet/properties/SelectAllText.razor %}

{% endhighlight %}

## ShowClearButton

Enables close icon with the each selected item.

Default value of ShowClearButton is `true`.

{% highlight Razor %}

{% include_relative code-snippet/properties/ShowClearButton.razor %}

{% endhighlight %}

## ShowDropDownIcon

Allows you to either show or hide the DropDown button on the component.

Default value of ShowDropDownIcon is `false`.

{% highlight Razor %}

{% include_relative code-snippet/properties/ShowDropDownIcon.razor %}

{% endhighlight %}

## ShowSelectAll

Allows you to either show or hide the selectAll option on the component.

Default value of ShowSelectAll is `false`.

[Click to refer the code ShowSelectAll](https://blazor.syncfusion.com/documentation/multiselect-dropdown/checkbox#select-all)

## TabIndex

Specifies the tab order of the DropDownList component.

{% highlight Razor %}

{% include_relative code-snippet/properties/TabIndex.razor %}

{% endhighlight %}

## Text

Selects the list item which maps the data Text field in the component.

Specifies the tab order of the DropDownList component.

{% highlight Razor %}

{% include_relative code-snippet/properties/Text.razor %}

{% endhighlight %}

## UnSelectAllText

Specifies the UnSelectAllText to be displayed on the component.

Default value for UnSelectAllText is `UnSelect All`

{% highlight Razor %}

{% include_relative code-snippet/properties/SelectAllText.razor %}

{% endhighlight %}

## Value

Selects the list item which maps the data Value field in the component.

{% highlight Razor %}

{% include_relative code-snippet/properties/Value.razor %}

{% endhighlight %}

## ValueExpression

Specifies the expression for defining the value of the bound.

[Click to refer the code for ValueExpression](https://blazor.syncfusion.com/documentation/multiselect-dropdown/how-to/tooltip)

## ValueTemplate

Accepts the template design and assigns it to the selected list item in the input element of the component.

[Click to refer the code for ValueTemplate](https://blazor.syncfusion.com/documentation/multiselect-dropdown/templates#value-template)

## Width

Gets or sets the width of the component. By default, it sizes based on its parent. container dimension.

Default value of Width is `100%`.
 
{% highlight Razor %}

{% include_relative code-snippet/properties/Size.razor %}

{% endhighlight %} 





