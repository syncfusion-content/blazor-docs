---
layout: post
title: Selection in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Selection feature in Syncfusion Blazor DropDownList component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Selection in Blazor DropDown List Component

## Get Selected Value


* You can get the selected value of the DropDownList component from the **Value** property in the [ValueChange event argument](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_Value). 

{% highlight cshtml %}

{% include_relative code-snippet/getting-started/get-selected-value.razor %}

{% endhighlight %}

* You can get the complete object list of the selected value from the **ItemData** property in the [ValueChange event argument](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChangeEventArgs-2.html#Syncfusion_Blazor_DropDowns_ChangeEventArgs_2_ItemData).

{% highlight cshtml %}

{% include_relative code-snippet/getting-started/item-data.razor %}

{% endhighlight %}

## Preselected Value on OnInitializedAsync

You can bind pre-selected value to the DropDownList component using `@bind-Value` property. We can assign the value property inside `OnInitializedAsync` lifecycle. The below sample demonstrates how to bind the value on initial rendering of the component.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselected-value.razor %}

{% endhighlight %}

The output will be as follows,

![Blazor DropDownList with pre-select value](./images/blazor_dropdown_pre_select_value.png)

## Programmatically Change the Selected Value

You can change the component value programmatically or externally by the component instance using `@ref` property of the component. The below sample demonstrates how to change the value of the component using click event of the button component.

{% highlight cshtml %}

{% include_relative code-snippet/selection/change-the-selected-value.razor %}

{% endhighlight %}

*Before changing the value:*

![Blazor DropDownList with pre-select value before](./images/blazor_dropdown_pre_select_before.png)

*After changing the value:*

![Blazor DropDownList with pre-select value after](./images/blazor_dropdown_pre_select_after.png)

## Preselect Value with Index

You can bind pre-selected value to the component also using [@bind-Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Index) property. It binds the respective value present in the binded index.

> It will dependent on [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html) type. It will bind the value to the component with sorted data if the corresponding property is defined.

The below sample demonstrates how to bind the index on initial rendering.

{% highlight cshtml %}

{% include_relative code-snippet/selection/preselect-value-index.razor %}

{% endhighlight %}

The output will be as follows,

![Blazor DropDownList with bind-index](./images/blazor_dropdown_bind_index.png)

## Get Selected Item by Value

We can get all the datasource items belongs to the value selected in the component by using [GetDataByValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_GetDataByValue__0_) method. It will returns the items with the return type of TValue mapped to the component. 

The below sample demonstrates usage `GetDataByValue` method,

{% highlight cshtml %}

{% include_relative code-snippet/selection/get-selected-item-by-value.razor %}

{% endhighlight %}

## Focus the Next Component on Selection

We can focus the component programmatically using [FocusAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FocusAsync) public method. It will set focus instantly to the DropDownList component when invoking it. 

You can also switch focus from one component to another using action based events. In the below sample demonstration, the focus will move from dropdown A to dropdown B if the value is selected in the dropdown A. Hence we have invoked the respective focusing method of B component inside A component's Closed event.

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-next-component.razor %}

{% endhighlight %}

## Programmatically Trigger onChange Event

You can trigger the ValueChange event manually by using the instance (taken from @ref property) of the **DropDownListEvents** tag helper. In the below example, we have invoked the ValueChange event inside **Created** event handle. As per the below code it will trigger once the component is created/rendered in the page.

{% highlight cshtml %}

{% include_relative code-snippet/selection/trigger-change-event.razor %}

{% endhighlight %}

## ValueChange Event

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event is triggered when the value of the DropDownList component get changed or modified. Also it will return the necessary arguments including the current and previously selected/changed value.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valuechange-event.razor %}

{% endhighlight %}

## OnValueSelect Event

The [OnValueSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnValueSelect) event is triggered when the user selects any value in the DropDownList component. You can get the necessary arguments including `ItemData` (datasource items related to the selected value). Also you can prevent the selection of items by setting the `Cancel` property as `true` provided by the event arguments. 

The below example demonstrates the usage of OnValueSelect event.

{% highlight cshtml %}

{% include_relative code-snippet/selection/valueselect-event.razor %}

{% endhighlight %}

## Focus Event

The [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_Focus) event will trigger when the component gets focused. By using the respective event we can perform required things when the component get focused. The below code example demonstrates the usage of Focus event.

{% highlight cshtml %}

{% include_relative code-snippet/selection/focus-event.razor %}

{% endhighlight %}

## Blur Event

The [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_Blur) event will trigger when focus moves out from the component. By using the respective event we can perform required things when the component get focused out.The below code example demonstrates the usage of Blur event.

{% highlight cshtml %}

{% include_relative code-snippet/selection/blur-event.razor %}

{% endhighlight %}

