---
layout: post
title:  Data Binding in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Value Binding in AutoComplete

Value binding is the process of passing values between a component and its parent. There are two methods for binding values.These are.

* bind-Value Binding 
* bind-Index Binding

## Bind value binding

The value binding can be achieved by using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute and it supports `string`, `int`, `enum`, `bool` and `complex types`. If the component value has been changed, it will affect all places where you bind the variable for the `@bind-value` attribute. In order for the binding to work properly, the value assigned to the `@bind-value` attribute should be based on the field mapped to [AutoCompleteFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Value)

* **TValue** - Specifies the type of each list item on the suggestion list.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/bind-value.razor %}

{% endhighlight %}

![Blazor AutoComplete with Bind Value](./images/value-binding/blazor-autocomplete-bind-value.png)

## Index value binding

Bind the selected item by index using the [@bind-Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Index) attribute, which supports `int` and nullable `int`. This binds to the zero-based index of the selected item.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/index-value.razor %}

{% endhighlight %}

![Blazor AutoComplete with Index Value](./images/value-binding/blazor-autocomplete-index-value.png)

## Value field

The [AutoCompleteFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Value) property points to the field in the data model that represents the value of each item. The mapped value identifies the item to select; the display text appears in the popup list.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/text-and-value.razor %}

{% endhighlight %}

![Blazor AutoComplete with Value](./images/value-binding/blazor-autocomplete-value.png)

## Primitive type binding

Bind arrays of primitive data (strings or numbers) to the AutoComplete and use [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Value) for selection. For primitive lists, field settings can be inferred or set explicitly.

The following code demonstrates an array of strings as the data source.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-string.razor %}

{% endhighlight %}

![Blazor AutoComplete with Primitive Type as string](./images/value-binding/blazor-autocomplete-primitive-type-string.png)

The following code demonstrates an array of integers as the data source.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-int.razor %}

{% endhighlight %}

![Blazor AutoComplete with Primitive Type as int](./images/value-binding/blazor-autocomplete-primitive-type-int.png)

## Object binding

Bind object data to the AutoComplete’s [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Value) and map the class appropriately to `TValue`.

In the following example, the `Name` field is mapped to [AutoCompleteFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Value).

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/object-binding.razor %}

{% endhighlight %}

![Blazor AutoComplete with object values](./images/value-binding/blazor-autocomplete-object-binding.png)

## Enum binding

Bind enum data to the AutoComplete with [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Value). The following example shows how to obtain a string value from enumeration data.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/enum-binding.razor %}

{% endhighlight %}

![Blazor AutoComplete with Enum Data](./images/value-binding/blazor-autocomplete-enum-binding.png)

## Show or hide clear button

Use the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_ShowClearButton) property to specify whether to show or hide the clear button. When the clear button is clicked, the `Value`, `Text`, and `Index` properties are reset to null.

N> If the TValue is a non nullable type, then while using the clear button, it will set the default value of the data type, and if TValue is set as a nullable type, then while using the clear button it will set to a null value(for example If the TValue is int, then while clearing 0 will set to the component and if TValue is int?, then while clearing null will set to the component)

The following sample demonstrates the `string` used as `TValue`. So, if you clear the value using the clear button, it will be set to null as it's the default value of the respective type.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/show-hide-clear-button.razor %}

{% endhighlight %}

![Blazor AutoComplete with clear button](./images/value-binding/blazor-autocomplete-show-hide-clear-button.png)

## Dynamically change TItem

The `TItem` property can be changed dynamically by defining the datasource type of the AutoComplete component with the help of the `@typeparam` directive. The following sample demonstration explains how to change  the TItem dynamically with different type of datasource.

### Creating generic AutoComplete component

First, create a `AutoComplete.razor` file as a parent component in the `/Pages` folder. Also, add a Parameter property for a List as `<TItem>` and `TValue`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.DropDowns;
@typeparam TValue;
@typeparam TItem;

<SfAutoComplete TValue="TValue" Width="300px" TItem="TItem" @bind-Value="@SelectedValue" Placeholder="Please select a value" DataSource="@DataList">
    <AutoCompleteFieldSettings Value="Text" />
</SfAutoComplete>

@code {
    [Parameter]
    public List<TItem> DataList { get; set; }

    [Parameter]
    public TValue SelectedValue { get; set; }

    [Parameter]
    public EventCallback<TValue> SelectedValueChanged { get; set; }
}

{% endhighlight razor %}
{% endtabs %}

### Usage of generic component with different type

Render the generic AutoComplete component with the required `TValue` and `TItem` in the corresponding Razor components.

Here, the AutoComplete component uses `TValue` as `string` in `/Index.razor` and `TValue` as nullable `int` in `/Counter.razor`.

**[Index.razor]**

{% tabs %}
{% highlight razor %}

<AutoComplete TValue="string" TItem="Games" @bind-SelectedValue="@value" DataList="@LocalData">
</AutoComplete>

@code{
    public string value { get; set; } = "Football";
    public class Games
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    List<Games> LocalData = new List<Games> {
        new Games() { ID= "Game1", Text= "American Football" },
        new Games() { ID= "Game2", Text= "Badminton" },
        new Games() { ID= "Game3", Text= "Basketball" },
        new Games() { ID= "Game4", Text= "Cricket" },
        new Games() { ID= "Game5", Text= "Football" },
        new Games() { ID= "Game6", Text= "Golf" },
        new Games() { ID= "Game7", Text= "Hockey" },
        new Games() { ID= "Game8", Text= "Rugby"},
        new Games() { ID= "Game9", Text= "Snooker" },
        new Games() { ID= "Game10", Text= "Tennis"},
    };
}

{% endhighlight razor %}
{% endtabs %}

**[Counter.razor]**

{% tabs %}
{% highlight razor %}
    

<AutoComplete TValue="int?" TItem="ZipCode" @bind-SelectedValue="@value" DataList="@LocalData">
</AutoComplete>

@code {
    public int? value { get; set; } = 102767;
    public class ZipCode
    {
        public int? ID { get; set; }
        public int? Text { get; set; }
    }
    List<ZipCode> LocalData = new List<ZipCode> {
            new ZipCode() { ID= 1, Text= 102789 },
            new ZipCode() { ID= 2, Text= 102776 },
            new ZipCode() { ID= 3, Text= 102767 },
            new ZipCode() { ID= 4, Text= 102745 }
        };
    }

{% endhighlight razor %}
{% endtabs %}

## Two way binding

Two-way is having a bi-directional data flow, i.e., passing the value from the property to the UI and then from the view (UI) to the property as well. The synchronization of data flow between model and view is achieved using the bind attribute in Blazor. To enable two-way binding for the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor AutoComplete component, you can use the @bind-Value directive to bind the value of the AutoComplete

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/two-way-binding.razor %}

{% endhighlight %}

![Blazor AutoComplete with Two way binding](./images/value-binding/blazor-autocomplete-two-way-binding.png)

## Programmatically clearing value

Clear the value programmatically by calling [ClearAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_ClearAsync) on a component instance reference. For example, bind a button click to invoke `ClearAsync()` and reset the control’s value.

{% highlight Razor %}

{% include_relative code-snippet/value-binding/clearAsync-method.razor %}

{% endhighlight %} 

![Blazor AutoComplete with clear button](./images/value-binding/blazor-autocomplete-clearAsync-method.gif)