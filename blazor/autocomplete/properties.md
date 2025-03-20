---
layout: post
title: Properties in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Properties in Syncfusion Blazor AutoComplete component and much more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Properties in Blazor AutoComplete Component

This section explains the list of properties of the AutoComplete component.

## FilterType

Determines on which filter type, the component needs to be considered on search action.

Default value of FilterType is `Contains`,  all the suggestion items which contain typed characters to listed in the suggestion popup. 

Possible values are:

* `StartsWith`, Checks whether a value begins with the specified value.
* `EndsWith`, Checks whether a value ends with specified value.
* `Contains`, Checks whether a value contains with specified value.

[Click to refer the code for FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_FilterType)

## Highlight

When set to 'true', highlight the searched characters on suggested list items.

{% highlight Razor %}

{% include_relative code-snippet/properties/Hightlight.razor %}

{% endhighlight %} 

## MinLength

Allows you to set the minimum search character length, the search action will perform after typed minimum characters.

Default value of MinLength is `1`.

[Click to refer the code for MinLength](https://blazor.syncfusion.com/documentation/autocomplete/filtering#limit-the-minimum-filter-character)

## ShowClearButton

Specifies whether to show or hide the clear button.

When the clear button is clicked, `Value` properties are reset to null.

Default value of ShowClearButton is `true`.

{% highlight Razor %}

{% include_relative code-snippet/properties/ShowClearButton.razor %}

{% endhighlight %}

## ShowPopupButton

Allows you to either show or hide the popup button on the component.

Default value of ShowPopupButton is `false`.

{% highlight Razor %}

{% include_relative code-snippet/properties/ShowPopupButton.razor %}

{% endhighlight %}

## SuggestionCount

Supports the specified number of list items on the suggestion popup.

Default value of SuggestionCount is `20`.

[Click to refer the code for SuggestionCount](https://blazor.syncfusion.com/documentation/autocomplete/filtering#filter-item-count)


