---
layout: post
title: Value Binding in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about Value Binding in Syncfusion Blazor MultiSelect component and more.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Value Binding in MultiSelect

Value binding is the process of passing values between a component and its parent. There are two methods for binding values. These are:

- @bind-Value binding

## Bind value binding

Value binding is achieved by using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Value) attribute, and it supports `string`, `int`, `enum`, `bool`, and complex types. When the component value changes, the bound variable used with `@bind-Value` is updated everywhere it is referenced. For binding to work correctly, the value assigned to `@bind-Value` must correspond to the field mapped to [MultiSelectFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_Value).

- TItem - Specifies the type of the data items in the MultiSelect component.
- TValue - Specifies the type of the value field (the selection type). The component’s Value is an array of this type.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/bind-value.razor %}

{% endhighlight %}

![Blazor MultiSelect with Bind Value](./images/value-binding/blazor_multiselect_bind-value.png)

## Text and value

The [MultiSelectFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_Value) and [MultiSelectFieldSettings.Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_Text) properties map to the corresponding fields of the data model. The Value field maintains the unique value for each item in the data source, and the Text field provides the displayed text for list items in the popup.

The following example demonstrates Text and Value field mapping. For instance, the selected item displays `Badminton` (Text), while the Value field holds `Game2` (ID).

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/text-and-value.razor %}

{% endhighlight %}

![Blazor MultiSelect with Text and Value](./images/value-binding/blazor_MultiSelect_text-and-value.png)

## Primitive type binding

The MultiSelect supports arrays of primitive data such as strings and numbers. Bind the value of primitive data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Value) attribute of the MultiSelect.

The following example demonstrates an array of strings as the data source.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-string.razor %}

{% endhighlight %}

![Blazor MultiSelect with Primitive Type as string](./images/value-binding/blazor_MultiSelect_primitive-type-string.png)

The following example demonstrates an array of integers as the data source.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-int.razor %}

{% endhighlight %}

![Blazor MultiSelect with Primitive Type as int](./images/value-binding/blazor_MultiSelect_primitive-type-int.png)

## Object binding

Bind object data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Value) attribute and map the value field via [MultiSelectFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_Value). Set `TItem` to the data item type and `TValue` to the value field type.

In the following example, the `Name` column is mapped to the Value field.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/object-binding.razor %}

{% endhighlight %}

![Blazor MultiSelect with object values](./images/value-binding/blazor_MultiSelect_object-binding.png)

## Enum binding

Bind enum values to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Value) attribute of the MultiSelect component. The following example shows how to use enum data and obtain the selected value(s).

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/enum-binding.razor %}

{% endhighlight %}

![Blazor MultiSelect with Enum Data](./images/value-binding/blazor_MultiSelect_enum-binding.png)

## Show or hide clear button

Use the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_ShowClearButton) property to show or hide the clear button. When clicked, the selection is cleared and the bound Value is reset.

N> If `TValue` is a non-nullable type, the clear button sets the default value of that type (for example, `0` for `int`). If `TValue` is a nullable type (for example, `int?`), the clear button sets the Value to `null`.

The following example uses `string` as `TValue`, so clearing sets the value to `null`.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/show-hide-clear-button.razor %}

{% endhighlight %}

![Blazor MultiSelect with clear button](./images/value-binding/blazor_MultiSelect_show-hide-clear-button.png)

## Dynamically change TItem

The `TItem` type can be changed dynamically by creating a generic wrapper component using the `@typeparam` directive. The following example shows how to change `TItem` dynamically for different data sources.

### Creating generic MultiSelect component

Create a `MultiSelect.razor` file as a parent component. Add parameters for the List of `<TItem>` and the bound `TValue[]`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.DropDowns;
@typeparam TValue;
@typeparam TItem;

<SfMultiSelect TValue="TValue[]" Width="300px" TItem="TItem" @bind-Value="@DDLValue" Placeholder="Please select a value" DataSource="@customData">
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

@code {
[Parameter]
public List<TItem> customData { get; set; }
[Parameter]
public TValue[] DDLValue { get; set; }
[Parameter]
public EventCallback<TValue> DDLValueChanged { get; set; }
}

{% endhighlight %}
{% endtabs %}

### Usage of generic component with different type

Render the generic MultiSelect with the required `TValue` and `TItem` in the respective Razor components.

In this example, the MultiSelect is rendered with `TValue` as `string` in `Index.razor` and with `TValue` as `int?` in `Counter.razor`.

**[Index.razor]**

{% tabs %}
{% highlight razor %}

<MultiSelect TValue="string[]" TItem="Games" @bind-DDLValue="@value" customData="@LocalData">
</MultiSelect>

@code{
    public string[] value { get; set; } = new string[] { "Game1" };

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

<MultiSelect TValue="int?[]" TItem="Games" @bind-DDLValue="@value" customData="@LocalData">
</MultiSelect>

@code{

public int?[] value { get; set; } = new int?[] { 3 };
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