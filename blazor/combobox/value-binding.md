---
layout: post
title:  Data Binding in Blazor ComboBox Component | Syncfusion
description: Checkout and learn about value binding in Syncfusion Blazor ComboBox component and more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Value Binding in ComboBox

Value binding is the process of passing values between a component and its parent. There are two methods for binding values:
- bind-Value binding
- bind-Index binding

## Bind value binding

The value binding can be achieved by using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute and it supports `string`, `int`, `enum`, `bool` and `complex types`. If the component value has been changed, it will affect all places where you bind the variable for the `@bind-value` attribute. In order for the binding to work properly, the value assigned to the `@bind-value` attribute should be based on the field mapped to [ComboBoxFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ComboBoxFieldSettings_Value)

- TValue: Specifies the value type of the component.
- TItem: Specifies the type of each item in the data source.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/bind-value.razor %}

{% endhighlight %}

![Blazor ComboBox with Bind Value](./images/value-binding/blazor-combobox-bind-value.png)

## Index value binding

The Index value binding is achieved by using the [@bind-Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Index) attribute and it supports int and int nullable types. By using this attribute, bind the values respective to its index.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/index-value.razor %}

{% endhighlight %}

![Blazor ComboBox with Index Value](./images/value-binding/blazor_combobox_index-value.png)

## Primitive type binding

The ComboBox has support to load array of primitive data such as strings and numbers. Bind the value of primitive data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute of the ComboBox.

The following code demonstrates array of string as datasource to the ComboBox component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-string.razor %}

{% endhighlight %}

![Blazor ComboBox with Primitive Type as string](./images/value-binding/blazor_combobox_primitive-type-string.png)

The following code demonstrates an array of int as the data source for the ComboBox component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-int.razor %}

{% endhighlight %}

![Blazor ComboBox with Primitive Type as int](./images/value-binding/blazor_combobox_primitive-type-int.png)

## Object binding

Bind object data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html#Syncfusion_Blazor_DropDowns_SfComboBox_2_Value) attribute by setting TValue to the appropriate type. Ensure the field mapped to [ComboBoxFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ComboBoxFieldSettings_Value) corresponds to the bound value.

In the following example, the Name column is mapped to the Value field.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/object-binding.razor %}

{% endhighlight %}

![Blazor ComboBox with object values](./images/value-binding/blazor_combobox_object-binding.png)

## Enum binding

Bind the enum data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute of ComboBox component. The following code helps you to get a string value from the enumeration data.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/enum-binding.razor %}

{% endhighlight %}

![Blazor ComboBox with Enum Data](./images/value-binding/blazor_combobox_enum-binding.png)

## Show or hide clear button

Use the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ShowClearButton) property to specify whether to show or hide the clear button. When the clear button is clicked, the `Value`, `Text`, and `Index` properties are reset to null.

N> If TValue is non-nullable, clearing sets the default value for the type. If TValue is nullable, clearing sets null. For example, if TValue is int, clearing sets 0; if TValue is int?, clearing sets null.

The following sample demonstrates using string as TValue. Clearing the value sets it to null, which is the default for that type.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/show-hide-clear-button.razor %}

{% endhighlight %}

![Blazor ComboBox with clear button](./images/value-binding/blazor_combobox_show-hide-clear-button.png)

## Dynamically change TItem

The TItem type can be changed dynamically by defining the ComboBox data source type with the `@typeparam` directive. The following example demonstrates changing TItem dynamically with different data sources.

### Creating generic combobox component

First, create a ComboBox.razor file as a parent component in the /Pages folder. Add parameter properties for a List<TItem> and TValue.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.DropDowns

@typeparam TValue;
@typeparam TItem;

<SfComboBox TValue="TValue" Width="300px" TItem="TItem" @bind-Value="@ComboBoxValue" Placeholder="Please select a value" DataSource="@customData">
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    [Parameter]
    public List<TItem> customData { get; set; }
    [Parameter]
    public TValue ComboBoxValue { get; set; }
    [Parameter]
    public EventCallback<TValue> ComboBoxValueChanged { get; set; }
}

{% endhighlight %}
{% endtabs %}

### Usage of generic component with different type

Render the generic ComboBox component with the required TValue and TItem in the respective Razor components.

Here, the ComboBox component is rendered with TValue as string in /Index.razor and with TValue as nullable int in /Counter.razor.

**[Index.razor]**

{% tabs %}
{% highlight razor %}

<ComboBox TValue="string" TItem="Games" @bind-ComboBoxValue="@value" customData="@LocalData">
</ComboBox>

@code{
    public string value { get; set; } = "Game1";
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

{% endhighlight %}
{% endtabs %}

**[Counter.razor]**

{% tabs %}
{% highlight razor %}
<ComboBox TValue="int?" TItem="Games" @bind-ComboBoxValue="@value" customData="@LocalData">
</ComboBox>

@code{
    public int? value { get; set; } = 3;
    public class Games
    {
        public int? ID { get; set; }
        public string Text { get; set; }
    }
    List<Games> LocalData = new List<Games> {
        new Games() { ID= 1, Text= "American Football" },
        new Games() { ID= 2, Text= "Badminton" },
        new Games() { ID= 3, Text= "Basketball" },
        new Games() { ID= 4, Text= "Cricket" },
        new Games() { ID= 5, Text= "Football" },
        new Games() { ID= 6, Text= "Golf" },
        new Games() { ID= 7, Text= "Hockey" },
        new Games() { ID= 8, Text= "Rugby"},
        new Games() { ID= 9, Text= "Snooker" },
        new Games() { ID= 10, Text= "Tennis"},
    };
}

{% endhighlight %}
{% endtabs %}