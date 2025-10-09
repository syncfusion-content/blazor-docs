---
layout: post
title: Value Binding in Blazor AutoComplete Component | Syncfusion
description: Check out and learn about value binding in the Syncfusion Blazor AutoComplete component, including @bind-Value, @bind-Index, primitive, object, and enum binding, two-way binding, and clearing values.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Value Binding in AutoComplete

Value binding is the process of synchronizing values between a component and its parent. There are two primary approaches:
- @bind-Value binding
- @bind-Index binding

## Bind value binding

Value binding can be achieved using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute, which supports `string`, `int`, `enum`, `bool`, and complex types. When the component value changes, the bound variable is updated everywhere it is used via the `@bind-Value` attribute. For binding to work correctly with complex types, the bound value should correspond to the field mapped to [AutoCompleteFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Value).

- TValue – Specifies the type of the bound value for the component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/bind-value.razor %}

{% endhighlight %}

![Blazor AutoComplete using @bind-Value to bind the selected value](./images/value-binding/blazor-autocomplete-bind-value.png)

## Index value binding

Index-based binding is achieved using the [@bind-Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Index) attribute, which supports `int` and nullable `int` types. This binds the selected item based on its index within the data source.

N> The bound index is resolved against the current data order. If sorting is applied using [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html), the index maps to the sorted data.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/index-value.razor %}

{% endhighlight %}

![Blazor AutoComplete bound by index to select an item by position](./images/value-binding/blazor-autocomplete-index-value.png)

## Value field

The [AutoCompleteFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Value) property points to the field name in the model that represents the value for the item. The mapped value is used for selection and binding, while the corresponding display text is shown in the popup. To control the displayed text, map [AutoCompleteFieldSettings.Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Text).

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/text-and-value.razor %}

{% endhighlight %}

![Blazor AutoComplete with mapped value and display text fields](./images/value-binding/blazor-autocomplete-value.png)

## Primitive type binding

The AutoComplete supports binding to arrays of primitive data such as strings and numbers. Bind primitive values using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute.

The following example demonstrates an array of strings as a data source for the AutoComplete component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-string.razor %}

{% endhighlight %}

![Blazor AutoComplete bound to an array of strings](./images/value-binding/blazor-autocomplete-primitive-type-string.png)

The following example demonstrates an array of int as a data source for the AutoComplete component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-int.razor %}

{% endhighlight %}

![Blazor AutoComplete bound to an array of integers](./images/value-binding/blazor-autocomplete-primitive-type-int.png)

## Object binding

Bind object data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDownList_2_Value) attribute of the AutoComplete component by mapping the class to `TItem` and the value field to `TValue`. For complex types, ensure that the [AutoCompleteFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Value) is mapped to a unique identifier to maintain correct selection and equality comparison.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/object-binding.razor %}

{% endhighlight %}

![Blazor AutoComplete bound to objects with a mapped value field](./images/value-binding/blazor-autocomplete-object-binding.png)

## Enum binding

Bind enum values to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute of the AutoComplete component. The component binds to the enum’s underlying value while displaying the configured text.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/enum-binding.razor %}

{% endhighlight %}

![Blazor AutoComplete bound to enumeration values](./images/value-binding/blazor-autocomplete-enum-binding.png)

## Show or hide clear button

Use the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_ShowClearButton) property to show or hide the clear button. When the clear button is clicked, the `Value`, `Text`, and `Index` properties are reset to null.

N> If `TValue` is non-nullable, the clear action sets the default value of the type. If `TValue` is nullable, the clear action sets the value to `null` (for example, if `TValue` is `int`, clearing sets `0`; if `TValue` is `int?`, clearing sets `null`).

The following sample demonstrates `string` used as `TValue`. Clearing the value sets it to `null`, which is the default for that type.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/show-hide-clear-button.razor %}

{% endhighlight %}

![Blazor AutoComplete showing a clear button that resets the value](./images/value-binding/blazor-autocomplete-show-hide-clear-button.png)

## Dynamically change TItem

The `TItem` type can be changed dynamically by defining the AutoComplete’s data source type with the `@typeparam` directive. The following sample shows how to change `TItem` dynamically with different data source types.

### Creating generic AutoComplete component

First, create an `AutoComplete.razor` file as a parent component in the `/Pages` folder. Add parameter properties for `List<TItem>` and `TValue`.

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

Render the generic AutoComplete with the required `TValue` and `TItem` in the respective Razor components.

Here, the AutoComplete component is rendered with `TValue` as `string` in `/Index.razor` and with `TValue` as nullable `int` in `/Counter.razor`.

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

Two-way binding provides bi-directional data flow between the component and the bound property. In Blazor, this is achieved using the `@bind-Value` directive, which synchronizes changes from the model to the UI and from the UI back to the model. As an alternative, one-way binding can be implemented using `Value` with a corresponding `ValueChanged` callback.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/two-way-binding.razor %}

{% endhighlight %}

![Blazor AutoComplete demonstrating two-way value binding](./images/value-binding/blazor-autocomplete-two-way-binding.png)

## Programmatically clearing value

Clear the value programmatically by calling the [ClearAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDownList_2_ClearAsync) method from an AutoComplete instance. You can bind a button click to invoke `ClearAsync()`, which resets the current value. This behavior is similar to using the clear button when [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_ShowClearButton) is enabled.

{% highlight Razor %}

{% include_relative code-snippet/value-binding/clearAsync-method.razor %}

{% endhighlight %} 

![Blazor AutoComplete clearing the value programmatically via ClearAsync](./images/value-binding/blazor-autocomplete-clearAsync-method.gif)