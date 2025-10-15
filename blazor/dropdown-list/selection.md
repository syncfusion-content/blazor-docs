---
layout: post
title: Selection in Blazor DropDownList component | Syncfusion
description: Checkout and learn here all about the Selection feature in Syncfusion Blazor DropDownList component and more.
platform: Blazor
control: DropDownList
documentation: ug
---

# Selection in Dropdown List

## Get selected value

Get the selected value of the `DropDownList` component in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event using the [ChangeEventArgs.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_Value) property.

{% highlight cshtml %}

{% include_relative code-snippet/getting-started/get-selected-value.razor %}

{% endhighlight %}

Get the complete object list of the selected value in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event using the [ChangeEventArgs.ItemData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_ItemData) property.

{% highlight cshtml %}

{% include_relative code-snippet/getting-started/item-data.razor %}

{% endhighlight %}

## Preselected value on OnInitializedAsync

Bind a preselected value to the `DropDownList` using the [`@bind-Value`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute. Assign the value in the [`OnInitializedAsync`](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-6.0#component-initialization-oninitializedasync) lifecycle method. The following sample binds the value during initial rendering.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value.razor %}

{% endhighlight %}

![Blazor DropDownList with preselected value](./images/selection/blazor_dropdown_preselect-value.png)

## Programmatically change the selected value

Change the component value programmatically by referencing the component instance via the [`@ref`](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#ref) attribute. The following sample changes the value from a button click handler.

{% highlight cshtml %}

{% include_relative code-snippet/selection/change-the-selected-value.razor %}

{% endhighlight %}

![Blazor DropDownList with programmatic value change](./images/selection/blazor_dropdown_changing-selected-value.gif)

When the value changes through user action or programmatically, the following events are raised.

### ValueChange event

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event occurs whenever the value is modified and provides details including the current and previous values.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valuechange-event.razor %}

{% endhighlight %}

### OnValueSelect event

The [OnValueSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnValueSelect) event occurs when an item is selected in the popup. Access the selected item via [ChangeEventArgs.ItemData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_ItemData). To prevent selection, set [ChangeEventArgs.Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_Cancel) to `true` in the handler.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valueselect-event.razor %}

{% endhighlight %}

## Preselect value with index

Bind a preselected value by index using the [`@bind-Index`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Index) attribute. This selects the item at the specified position in the data source.

N> Selection by index is affected by the [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html). If sorting is applied, the index corresponds to the sorted data.

The following sample binds the index during initial rendering.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value-index.razor %}

{% endhighlight %}

![Blazor DropDownList with index-based preselection](./images/selection/blazor_dropdown_preselect-value-index.png)

## Get selected item by value

Retrieve the entire data object for a selected value using the [GetDataByValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_GetDataByValue__0_) method.

{% highlight cshtml %}

{% include_relative code-snippet/selection/get-selected-item-by-value.razor %}

{% endhighlight %}

## Focus the next component on selection

Programmatically move focus using the [FocusAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FocusAsync) method on a `DropDownList` instance, for example after selection, to maintain a logical tab order.

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-next-component.razor %}

{% endhighlight %}

## Programmatically trigger onChange event

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event can be invoked manually using the `DropDownListEvents` instance (obtained via `@ref`). In the following example, `ValueChange` is invoked inside the `Created` event handler to demonstrate manual triggering.

{% highlight cshtml %}

{% include_relative code-snippet/selection/trigger-change-event.razor %}

{% endhighlight %}

## Programmatically focus in and focus out the component

In order to trigger the `FocusAsync()` and `FocusOutAsync()` methods using the instance of the dropdownlist, you can use buttons. You can bind the click event of the button to the `FocusAsync()` and `FocusOutAsync()` methods. When the button is clicked, it triggers the corresponding method on the dropdownlist.

{% highlight Razor %}

{% include_relative code-snippet/selection/focus-method.razor %}

{% endhighlight %}

![Blazor DropDownList with dynamic focus in and out](./images/selection/blazor_dropdown_focus-in-out.gif)

When focusing and blurring, the following events are raised.

### Focus event

The [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_Focus) event triggers when the component receives focus.

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-event.razor %}

{% endhighlight %}

### Blur event

The [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_Blur) event triggers when focus moves away from the component.

{% highlight cshtml %}

{% include_relative code-snippet/selection/blur-event.razor %}

{% endhighlight %}

## Get Data by value

Retrieve the selected data by invoking the `GetDataByValue(TValue)` method on the `DropDownList` instance (accessed via `@ref`). For example, bind a button click to call `GetDataByValue(TValue)` and process the returned item.

{% highlight Razor %}

{% include_relative code-snippet/selection/getDataByValue-method.razor %}

{% endhighlight %} 

## Get List Item

Retrieve the list items by calling the `GetItemsAsync()` method on the `DropDownList` instance. For example, bind a button click to invoke `GetItemsAsync()` and use the returned items for further processing.

{% highlight Razor %}

{% include_relative code-snippet/selection/getItemsAsync-method.razor %}

{% endhighlight %}