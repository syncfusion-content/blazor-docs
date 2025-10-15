---
layout: post
title: Selection in Blazor MultiColumn ComboBox Component | Syncfusion
description: Checkout and learn here all about the Selection feature in Syncfusion Blazor MultiColumn ComboBox component and more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Selection in MultiColumn ComboBox

## Get selected value

Retrieve the selected value from the Blazor MultiColumn ComboBox during the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ValueChange) event by using the [ValueChangeEventArgs.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.ValueChangeEventArgs-2.html#Syncfusion_Blazor_MultiColumnComboBox_ValueChangeEventArgs_2_Value) property. This event also provides both the current and previous values.

{% highlight cshtml %}

{% include_relative code-snippet/selection/get-selected-value.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBfXYhUKacoERWz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

Retrieve the full data object corresponding to the selected value in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ValueChange) event by using the [ValueChangeEventArgs.ItemData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.ValueChangeEventArgs-2.html#Syncfusion_Blazor_MultiColumnComboBox_ValueChangeEventArgs_2_ItemData) property.

{% highlight cshtml %}

{% include_relative code-snippet/selection/item-data.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrTtErggklqvxPe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Preselected value on OnInitializedAsync

Preselect a value by binding the component using [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Value). Set the bound value in [OnInitializedAsync](https://learn.microsoft.com/aspnet/core/blazor/components/lifecycle?view=aspnetcore-8.0#component-initialization-oninitializedasync). Ensure `TValue` aligns with the type of the bound model property.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrTDYVKgaYDmQmK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor MultiColumn ComboBox with preselect value](./images/selection/blazor_combobox_preselect-value.png)

## Programmatically change the selected value

Change the component's value either programmatically or externally via the component instance using the [@ref](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#ref) attribute. The following example illustrates how to update the component's value when a button is clicked.

{% highlight cshtml %}

{% include_relative code-snippet/selection/change-the-selected-value.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVfDkhKgOkmNULd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor MultiColumn ComboBox changing the selected value](./images/selection/blazor_combobox_changing-selected-value.gif)

### ValueChange event

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ValueChange) event triggers when the value of the Blazor MultiColumn ComboBox changes and returns the necessary arguments, including the current and previously selected values and the selected item data.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valuechange-event.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLzXELAzNjrImKu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### OnValueSelect event 

The [OnValueSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_OnValueSelect) event is raised when a value is chosen in the Blazor MultiColumn ComboBox. Access the selected data via [ValueSelectEventArgs.ItemData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.ValueSelectEventArgs-2.html#Syncfusion_Blazor_MultiColumnComboBox_ValueSelectEventArgs_2_ItemData). To prevent selection, set [ValueSelectEventArgs.Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.ValueSelectEventArgs-2.html#Syncfusion_Blazor_MultiColumnComboBox_ValueSelectEventArgs_2_Cancel) to `true`.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valueselect-event.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBfNEBAJNtnOoRY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Preselect value with index

Bind the pre-selected value to the component using the [@bind-Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Value) attribute. It binds the respective value present in the specified index position of the datasource.

The following sample shows how to bind the index on initial rendering.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value-index.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZhpZkBApjCrhVtv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor MultiColumn ComboBox with bind-index](./images/selection/blazor_combobox_preselect-value-index.png)

<!-- ## Autofill the selected value

The [Autofill]() property determines if the component's input field will automatically suggest and complete the first matching item as the user types, drawing from the component's data source. If there are no matches, the input field will remain unchanged, and no further action will take place. By default, the `Autofill` setting is set to `false`.

{% highlight Razor %}

{% include_relative code-snippet/selection/auto-fill.razor %}

{% endhighlight %}  -->

<!-- ## Get selected item by value

Get the entire object belonging to the value selected in the component using the [GetDataByValue]() method.

{% highlight cshtml %}

{% include_relative code-snippet/selection/get-selected-item-by-value.razor %}

{% endhighlight %} -->

## Focus the next component on selection

Programmatically move focus using the [FocusAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_FocusAsync) method. This sets focus to the Blazor MultiColumn ComboBox when invoked.

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-next-component.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox focusing the next component on selection](./images/selection/blazor_combobox_focus-next-component.gif)

<!-- ## Programmatically clear the selected value

To programmatically reset the value of the MultiColumn ComboBox, you can utilize the [ClearAsync]() method. This method removes any selected values from the SfComboBox<TValue, TItem> component and sets both the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Value) and [Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Index) properties to null.

{% highlight cshtml %}

{% include_relative code-snippet/selection/programmatically-clear-value.razor %}

{% endhighlight %} -->

## Prevent reload on form submit

When using the Blazor MultiColumn ComboBox inside a form, prevent a full page reload by setting the button’s type to `"button"` through the `HTMLAttributes` configuration for that button. This ensures clicks do not submit the form unless explicitly intended.

{% highlight cshtml %}

{% include_relative code-snippet/selection/prevent-reload.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBfNkrqfZMEHYfF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

<!-- ## Programmatically trigger onChange event

Trigger the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ValueChange) event manually by using the instance (taken from @ref attribute) of the component. In the following example, the `ValueChange` event is invoked inside the `Created` event handler. As per the following code, it will trigger once the component is created or rendered on the page.

{% highlight cshtml %}

{% include_relative code-snippet/selection/trigger-change-event.razor %}

{% endhighlight %} -->

<!-- ## Programmatically focus in and focus out the component

In order to trigger the `FocusAsync(https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_FocusAsync)` and `FocusOutAsync()` methods using the instance of the MultiColumn ComboBox, you can use buttons. You can bind the click event of the button to the `FocusAsync(https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_FocusAsync)` and `FocusOutAsync()` methods. When the button is clicked, it triggers the corresponding method on the MultiColumn ComboBox.

{% highlight Razor %}

{% include_relative code-snippet/selection/focus-method.razor %}

{% endhighlight %}

While focusing and focus out the following event get triggered. -->

### Focus event

The [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Focus) event triggers when the component receives focus. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-event.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLptkBgfXVfbjJH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Blur event

The [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Blur) event triggers when focus moves out of the component.

{% highlight cshtml %}

{% include_relative code-snippet/selection/blur-event.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBTNYBKfNhYoGKt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}