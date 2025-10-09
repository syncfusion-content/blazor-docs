---
layout: post
title: Selection in Blazor AutoComplete Component | Syncfusion
description: Check out and learn about the selection features in the Syncfusion Blazor AutoComplete component, including getting selected values, events, programmatic control, and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Selection in AutoComplete

## Get selected value

Get the selected value of the AutoComplete component in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_ValueChange) event using the [ChangeEventArgs.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_Value) property.

{% highlight cshtml %}

{% include_relative code-snippet/selection/get-selected-value.razor %}

{% endhighlight %}

Get the complete data object for the selected item in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_ValueChange) event using the [ChangeEventArgs.ItemData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_ItemData) property.

{% highlight cshtml %}

{% include_relative code-snippet/selection/item-data.razor %}

{% endhighlight %}

## Preselected value on OnInitializedAsync

Bind a preselected value to the AutoComplete component using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute. Assign the value in the [OnInitializedAsync](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-6.0#component-initialization-oninitializedasync) lifecycle method. The following sample shows how to bind the value during initial rendering.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value.razor %}

{% endhighlight %}

![Blazor AutoComplete showing a preselected value on initial render](./images/selection/blazor_autocomplete_preselect_value.png)

## Programmatically change the selected value

Change the component value programmatically using the component instance obtained via the [@ref](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#ref) attribute. The following sample demonstrates changing the value using the button click event.

{% highlight cshtml %}

{% include_relative code-snippet/selection/change-the-selected-value.razor %}

{% endhighlight %}

![Blazor AutoComplete value changed programmatically using a button](./images/selection/blazor_autocomplete_changing-selected-value.gif)

### ValueChange event

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_ValueChange) event is triggered when the value of the AutoComplete component is changed. It provides event arguments that include the current and previously selected values.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valuechange-event.razor %}

{% endhighlight %}

### OnValueSelect event

The [OnValueSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_OnValueSelect) event is triggered when a value is selected in the AutoComplete component. It provides event arguments including [ChangeEventArgs.ItemData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_ItemData). Prevent selection by setting [ChangeEventArgs.Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_Cancel) to `true` in the event arguments.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valueselect-event.razor %}

{% endhighlight %}

## Preselect value with index

Bind a preselected item by index using the [@bind-Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Index) attribute. This binds the value corresponding to the specified index position in the data source.

N> The behavior depends on the [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html) type. If sorting is applied, the index binds against the sorted data.

The following sample shows how to bind the index during initial rendering.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value-index.razor %}

{% endhighlight %}

![Blazor AutoComplete with bind-index selecting an item by position](./images/selection/blazor_autocomplete_preselect-value-index.png)

## Autofill the selected value

The [Autofill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteModel.html#Syncfusion_Blazor_DropDowns_AutoCompleteModel_Autofill) property specifies whether the input automatically suggests and fills the first matched item as the user types, based on the component’s data source. If no match is found, the input is not filled. The default value of `Autofill` is `false`.

{% highlight Razor %}

{% include_relative code-snippet/selection/auto-fill.razor %}

{% endhighlight %} 

![Blazor AutoComplete demonstrating the Autofill feature](./images/selection/blazor_autocomplete_with-autofill-property.gif)

## Get selected item by value

Get the entire data object for the selected value using the [GetDataByValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_GetDataByValue__0_) method.

{% highlight cshtml %}

{% include_relative code-snippet/selection/get-selected-item-by-value.razor %}

{% endhighlight %}

## Focus the next component on selection

Set focus programmatically using the [FocusAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FocusAsync) method. This immediately moves focus to the AutoComplete component when invoked, enabling workflows that shift focus to the next interactive element after selection.

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-next-component.razor %}

{% endhighlight %}

## Prevent reload on form submit

To prevent the page from reloading when the AutoComplete component is used inside a form, set the button type to "button" using the `HTMLAttributes` property. This prevents the default form submit behavior when the button is clicked.

{% highlight cshtml %}

{% include_relative code-snippet/selection/prevent-reload.razor %}

{% endhighlight %}

## Programmatically clear the selected value

To clear the AutoComplete value programmatically, use the [ClearAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ClearAsync) method. This method clears the selected value from the `SfAutocomplete<TValue, TItem>` component and sets the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) and [Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDownList_2_Index) properties to null.

{% highlight cshtml %}

{% include_relative code-snippet/selection/programmatically-clear-value.razor %}

{% endhighlight %}

![Blazor AutoComplete clearing the selected value programmatically](./images/selection/blazor_autocomplete_with-programmatically-clear-value.gif)

## Programmatically trigger onChange event

Trigger the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_ValueChange) event manually by using the instance (taken from @ref) of the [AutoCompleteEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html). In the following example, the `ValueChange` event is invoked inside the `Created` event handler, so it triggers once the component is created or rendered.

{% highlight cshtml %}

{% include_relative code-snippet/selection/trigger-change-event.razor %}

{% endhighlight %}

## Programmatically focus in and focus out the component

To trigger the `FocusAsync()` and `FocusOutAsync()` methods using the AutoComplete instance, use buttons and bind their click events to these methods. Clicking the corresponding button invokes the focus or blur behavior on the component.

{% highlight Razor %}

{% include_relative code-snippet/selection/focus-method.razor %}

{% endhighlight %}

The following events are triggered on focus and blur.

### Focus event

The [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_Focus) event is triggered when the component receives focus. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-event.razor %}

{% endhighlight %}

### Blur event

The [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_Blur) event is triggered when focus moves out of the component. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/blur-event.razor %}

{% endhighlight %}