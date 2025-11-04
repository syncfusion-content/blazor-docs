---
layout: post
title: Selection in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about the Selection feature in Syncfusion Blazor DropDownList component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Selection in Dropdown List

## Get selected value

Get the selected value of the DropDownList component in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event using the [ChangeEventArgs.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_Value) property.

{% highlight cshtml %}

{% include_relative code-snippet/getting-started/get-selected-value.razor %}

{% endhighlight %}

Get the complete object list of the selected value in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event using the [ChangeEventArgs.ItemData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_ItemData) property.

{% highlight cshtml %}

{% include_relative code-snippet/getting-started/item-data.razor %}

{% endhighlight %}

## Preselected value on OnInitializedAsync

Bind the pre-selected value to the DropDownList component using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute. Assign the value property inside the [OnInitializedAsync](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-6.0#component-initialization-oninitializedasync) lifecycle. The following sample shows how to bind the value on the initial rendering of the component.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value.razor %}

{% endhighlight %}

![Blazor DropDownList with pre-select value](./images/selection/blazor_dropdown_preselect-value.png)

## Programmatically change the selected value

Change the component value programmatically or externally by the component instance using the [@ref](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#ref) attribute of the component. The following sample shows how to change the value of the component using click event of the button component.

{% highlight cshtml %}

{% include_relative code-snippet/selection/change-the-selected-value.razor %}

{% endhighlight %}

![Blazor DropDownList with pre-select value before](./images/selection/blazor_dropdown_changing-selected-value.gif)

While changing  and selecting the value the following event get triggered.

### ValueChange event

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event is triggered when the value of the DropDownList component get changed or modified. Also, it will return the necessary arguments including the current and previously selected or changed value.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valuechange-event.razor %}

{% endhighlight %}

### OnValueSelect event

The [OnValueSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnValueSelect) event is triggered when you select any value in the DropDownList component. Get the necessary arguments including the [ChangeEventArgs.ItemData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_ItemData). Also,  prevent the selection of items by setting the [ChangeEventArgs.Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_Cancel) property as `true` provided by the event arguments. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/valueselect-event.razor %}

{% endhighlight %}

## Preselect value with index

Bind the pre-selected value to the component using the [@bind-Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Index) attribute. It binds the respective value present in the specified index position of the datasource.

N> It will be dependent on the [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html) type. It will bind the value to the component with the sorted data if the corresponding property is defined.

The following sample shows how to bind the index on the initial rendering.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value-index.razor %}

{% endhighlight %}

![Blazor DropDownList with bind-index](./images/selection/blazor_dropdown_preselect-value-index.png)

## Get selected item by value

Get the entire object belonging to the value selected in the component using the [GetDataByValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_GetDataByValue__0_) method.

{% highlight cshtml %}

{% include_relative code-snippet/selection/get-selected-item-by-value.razor %}

{% endhighlight %}

## Focus the next component on selection

Focus the component programmatically using the [FocusAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FocusAsync) public method. It will set focus instantly to the DropDownList component when invoking it. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-next-component.razor %}

{% endhighlight %}

## Programmatically trigger onChange event

Trigger the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event manually by using the instance (taken from @ref attribute) of the [DropDownListEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html). In the following example, the `ValueChange` event is invoked inside the `Created` event handler. As per the following code, it will trigger once the component is created or rendered on the page.

{% highlight cshtml %}

{% include_relative code-snippet/selection/trigger-change-event.razor %}

{% endhighlight %}

## Programmatically focus in and focus out the component

In order to trigger the `FocusAsync()` and `FocusOutAsync()` methods using the instance of the dropdownlist, you can use buttons. You can bind the click event of the button to the `FocusAsync()` and `FocusOutAsync()` methods. When the button is clicked, it triggers the corresponding method on the dropdownlist.

{% highlight Razor %}

{% include_relative code-snippet/selection/focus-method.razor %}

{% endhighlight %}

![Blazor DropDownList with dynamic focus in and out](./images/selection/blazor_dropdown_focus-in-out.gif)

While focusing and focus out the following event get triggered.

### Focus event

The [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_Focus) event will trigger when the component gets focused. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-event.razor %}

{% endhighlight %}

### Blur event

The [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_Blur) event will trigger when focus moves out from the component. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/blur-event.razor %}

{% endhighlight %}

## Get Data by value

You can retrieve the selected value from the dropdown list by using the `GetDataByValue(TValue)` method through an instance of the dropdown list. You can bind the click event of a button to the `GetDataByValue(TValue)` method of the dropdown list instance. When the button is clicked, it will trigger the `GetDataByValue(TValue)` method on the dropdown list and return the selected value.

{% highlight Razor %}

{% include_relative code-snippet/selection/getDataByValue-method.razor %}

{% endhighlight %} 

## Get List Item

You can retrieve the list items from the dropdown list by using the `GetItemsAsync()` method through an instance of the dropdown list. You can bind the click event of a button to the `GetItemsAsync()` method of the dropdown list instance. When the button is clicked, it will trigger the `GetItemsAsync()` method on the dropdown list and return the list items

{% highlight Razor %}

{% include_relative code-snippet/selection/getItemsAsync-method.razor %}

{% endhighlight %} 
