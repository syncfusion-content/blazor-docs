---
layout: post
title: Properties in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about properties in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Properties in Blazor DropDown List Component

This section explains the list of properties of the DropDown List component 

## AllowFiltering

When AllowFiltering is set to true, show the filter bar (search box) of the component.

The filter action retrieves matched items through the `Filtering` event based on the characters typed in the search TextBox.

Default value of AllowFiltering is `false`.

[Click to refer the code for AllowFiltering](https://blazor.syncfusion.com/documentation/dropdown-list/filtering)

## CssClass

Specifies the CSS class name that can be appended with the root element of the DropDownList. One or more custom CSS classes can be added to a DropDownList.

Possible values are

* `e-success`, which denotes the component in success state that is added green color to the dropdownlist's input field.
* `e-warning`, which denotes the component in warning state that is added orange color to the dropdownlist's input field.
* `e-error`, which denotes the component in error state that is added red color to the dropdownlist's input field.
* `e-outline`, which supports only in material theme.

{% highlight Razor %}

{% include_relative code-snippet/properties/CssClass.razor %}

{% endhighlight %} 

## EnableRtl

Enable or disable rendering component in right to left direction.

Default value of EnableRtl is `false`.

{% highlight Razor %}

{% include_relative code-snippet/properties/EnableRtl.razor %}

{% endhighlight %} 

## EnableVirtualization

The Virtual Scrolling feature is used to display a large amount of data that you require without buffering the entire load of a huge database records in the DropDowns, that is, when scrolling, the datamanager request is sent to fetch some amount of data from the server dynamically. To achieve this scenario with DropDowns, set the EnableVirtualization to true.

[Click to refer the code for EnableVirtualization](https://blazor.syncfusion.com/documentation/dropdown-list/virtualization)

## FilterBarPlaceholder

Accepts the value to be displayed as a watermark text on the filter bar. FilterBarPlaceholder is applicable when AllowFiltering is used as true. FilterBarPlaceholder is depends on [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_AllowFiltering).

{% highlight Razor %}

{% include_relative code-snippet/properties/FilterBarPlaceholder.razor %}

{% endhighlight %} 

## FloatLabelType

Specifies the floating label behavior of the DropDownList that the Placeholder text floats above the DropDownList based on the following values. FloatLabelType is applicable only when Placeholder is used.FloatLabelType is depends on [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Placeholder)

Default value of FloatLabelType is `Never`.

Possible values are:

* `Never` - The label will never float in the input when the placeholder is available.
* `Always` - The floating label always floats above the DropDownList.
* `Auto` - The floating label floats above the DropDownList after focusing it or when enters the value in it.

{% highlight Razor %}

{% include_relative code-snippet/properties/FloatLabelType.razor %}

{% endhighlight %} 

## FooterTemplate

The DropDownList has options to show a footer element at the bottom of the list items in the popup list. Here, you can place any custom element as a footer element using the FooterTemplate property.

[Click to refer the code for footer templates](https://blazor.syncfusion.com/documentation/dropdown-list/templates#footer-template)

## HeaderTemplate

The header element is shown statically at the top of the popup list items within DropDownList, and any custom element can be placed as a header element using the HeaderTemplate property.

[Click to refer the code for header templates](https://blazor.syncfusion.com/documentation/dropdown-list/templates#header-template)

## HtmlAttributes

You can add the additional html attributes such as styles, class, and more to the root element. If you configured both property and equivalent html attributes, then the component considers the property value.

{% highlight Razor %}

{% include_relative code-snippet/properties/HtmlAttributes.razor %}

{% endhighlight %} 

## ID

Specifies the id of the DropDownList component. we can access the other properties of the component through this ID

{% highlight Razor %}

{% include_relative code-snippet/properties/ID.razor %}

{% endhighlight %} 

## Index

Gets or sets the index of the selected item in the component. List Item in the mentioned index will bind to the component.

{% highlight Razor %}

{% include_relative code-snippet/properties/Index.razor %}

{% endhighlight %}

## InputAttributes

You can add the additional input attributes such as disabled, value, and more to the root element.

If you configured both the property and equivalent input attribute, then the component considers the property value.

{% highlight Razor %}

{% include_relative code-snippet/properties/InputAttributes.razor %}

{% endhighlight %} 

## ItemsCount

The data can be fetched in popup based on ItemsCount, when enabled the EnableVirtualization. ItemsCount is applicable only when EnableVirtualization is used as true. ItemsCount is depends on [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_EnableVirtualization)

Default value of ItemsCount is `5`.

{% highlight Razor %}

{% include_relative code-snippet/properties/ItemsCount.razor %}

{% endhighlight %}

## Placeholder

Specifies the text that is shown as a hint or placeholder until the user focuses or enter a value in DropDownList. The property is depending on the FloatLabelType property.

{% highlight Razor %}

{% include_relative code-snippet/properties/Placeholder.razor %}

{% endhighlight %}

## PopupHeight

Specifies the height of the popup list.

Default value of PopupHeight is `300px`.

{% highlight Razor %}

{% include_relative code-snippet/properties/Size.razor %}

{% endhighlight %}

## PopupWidth

Specifies the Width of the popup list. By default, the popup Width sets based on the Width of the component.

Default value of PopupWidth is `100%`

{% highlight Razor %}

{% include_relative code-snippet/properties/Size.razor %}

{% endhighlight %}

## Readonly

Specifies the boolean value whether the DropDownList allows the user to change the value.

Default value of Readonly is `false`.

{% highlight Razor %}

{% include_relative code-snippet/properties/Readonly.razor %}

{% endhighlight %}

## ShowClearButton

Specifies whether to show or hide the clear button.

Default value of ShowClearButton is `false`.

When the clear button is clicked, `Value`, `Text`, and `Index` properties are reset to null.

{% highlight Razor %}

{% include_relative code-snippet/properties/ShowClearButton.razor %}

{% endhighlight %}

## TabIndex

Specifies the tab order of the DropDownList component.

{% highlight Razor %}

{% include_relative code-snippet/properties/TabIndex.razor %}

{% endhighlight %}

## Value

Gets or sets the Value of the selected item in the component.

{% highlight Razor %}

{% include_relative code-snippet/properties/Value.razor %}

{% endhighlight %}

## ValueExpression

Specifies the expression for defining the value of the bound.

[Click to refer the code for ValueExpression](https://blazor.syncfusion.com/documentation/dropdown-list/how-to/tooltip)

## ValueTemplate

The currently selected value that is displayed by default on the DropDownList input element can be customized using the ValueTemplate property.

[Click to refer the code for value templates](https://blazor.syncfusion.com/documentation/dropdown-list/templates#value-template)

## Width

Specifies the Width of the component. By default, the component Width sets based on the Width of its parent container.

You can also set the Width in pixel values.

Default value of Width is `100%`

{% highlight Razor %}

{% include_relative code-snippet/properties/Size.razor %}

{% endhighlight %}


