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

Retrieve the selected value from the MultiColumn ComboBox component during the [ValueChange]() event by utilizing the [ChangeEventArgs.Value]() property.

{% highlight cshtml %}

{% include_relative code-snippet/selection/get-selected-value.razor %}

{% endhighlight %}

Retrieve the full object list corresponding to the selected value in the [ValueChange]() event by utilizing the [ChangeEventArgs.ItemData]() property.

{% highlight cshtml %}

{% include_relative code-snippet/selection/item-data.razor %}

{% endhighlight %}

## Preselected value on OnInitializedAsync

To associate a pre-selected value with the MultiColumn ComboBox component, use the [@bind-Value]() attribute. You can set the value property in the [OnInitializedAsync]() lifecycle method. The following example illustrates how to bind the value when the component is initially rendered.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value.razor %}

{% endhighlight %}

![Blazor ComboBox with pre-select value](./images/selection/blazor_combobox_preselect-value.png)

## Programmatically change the selected value

You can change the component's value either programmatically or externally via the component instance using the [@ref](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#ref) attribute. The following example illustrates how to update the component's value when a button is clicked.

{% highlight cshtml %}

{% include_relative code-snippet/selection/change-the-selected-value.razor %}

{% endhighlight %}

![Blazor ComboBox with pre-select value before](./images/selection/blazor_combobox_changing-selected-value.gif)

### ValueChange event

The [ValueChange]() event is triggered when the value of the MultiColumn ComboBox component get changed or modified. Also, it will return the necessary arguments including the current and previously selected or changed value.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valuechange-event.razor %}

{% endhighlight %}

### OnValueSelect event 

The [OnValueSelect]() event is activated whenever a value is chosen in the DropDownList component. You can access the relevant arguments, including the [ChangeEventArgs.ItemData](). Additionally, you can prevent item selection by setting the [ChangeEventArgs.Cancel]() property to `true` within the event arguments.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valueselect-event.razor %}

{% endhighlight %}

## Preselect value with index

Bind the pre-selected value to the component using the [@bind-Index]() attribute. It binds the respective value present in the specified index position of the datasource.

N> It will be dependent on the [SortOrder]() type. It will bind the value to the component with the sorted data if the corresponding property is defined.

The following sample shows how to bind the index on the initial rendering.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value-index.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox with bind-index](./images/selection/blazor_combobox_preselect-value-index.png)

<!-- ## Autofill the selected value

The [Autofill]() property determines if the component's input field will automatically suggest and complete the first matching item as the user types, drawing from the component's data source. If there are no matches, the input field will remain unchanged, and no further action will take place. By default, the `Autofill` setting is set to `false`.

{% highlight Razor %}

{% include_relative code-snippet/selection/auto-fill.razor %}

{% endhighlight %} 

![Blazor ComboBox with Autofill property](./images/selection/blazor_combobox_with-autofill-property.gif) -->

<!-- ## Get selected item by value

Get the entire object belonging to the value selected in the component using the [GetDataByValue]() method.

{% highlight cshtml %}

{% include_relative code-snippet/selection/get-selected-item-by-value.razor %}

{% endhighlight %} -->

## Focus the next component on selection

Focus the component programmatically using the [FocusAsync]() public method. It will set focus instantly to the MultiColumn ComboBox component when invoking it. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-next-component.razor %}

{% endhighlight %}

<!-- ## Programmatically clear the selected value

To programmatically reset the value of the MultiColumn ComboBox, you can utilize the [ClearAsync]() method. This method removes any selected values from the SfComboBox<TValue, TItem> component and sets both the [Value]() and [Index]() properties to null.

{% highlight cshtml %}

{% include_relative code-snippet/selection/programmatically-clear-value.razor %}

{% endhighlight %}

![Blazor ComboBox with programatically clear value](./images/selection/blazor_combobox_with-programmatically-clear-value.gif) -->

## Prevent reload on form submit

To prevent the page from reloading when using the MultiColumn ComboBox component inside a form, you can specify the type of the button as "button" by utilizing the `HTMLAttributes` property. This will prevent the page from reloading when the button is clicked.

{% highlight cshtml %}

{% include_relative code-snippet/selection/prevent-reload.razor %}

{% endhighlight %}

<!-- ## Programmatically trigger onChange event

Trigger the [ValueChange]() event manually by using the instance (taken from @ref attribute) of the [ComboBoxEvents](). In the following example, the `ValueChange` event is invoked inside the `Created` event handler. As per the following code, it will trigger once the component is created or rendered on the page.

{% highlight cshtml %}

{% include_relative code-snippet/selection/trigger-change-event.razor %}

{% endhighlight %} -->

<!-- ## Programmatically focus in and focus out the component

In order to trigger the `FocusAsync()` and `FocusOutAsync()` methods using the instance of the MultiColumn ComboBox, you can use buttons. You can bind the click event of the button to the `FocusAsync()` and `FocusOutAsync()` methods. When the button is clicked, it triggers the corresponding method on the MultiColumn ComboBox.

{% highlight Razor %}

{% include_relative code-snippet/selection/focus-method.razor %}

{% endhighlight %}

While focusing and focus out the following event get triggered. -->

### Focus event

The [Focus]() event will trigger when the component gets focused. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-event.razor %}

{% endhighlight %}

### Blur event

The [Blur]() event will trigger when focus moves out from the component. 

{% highlight cshtml %}

{% include_relative code-snippet/selection/blur-event.razor %}

{% endhighlight %}