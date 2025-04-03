---
layout: post
title: Value Binding in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about Value Binding in Syncfusion Blazor MultiSelect component and more.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Value Binding in MultiSelect

Value binding is the process of passing values between a component and its parent. There are two methods for binding values.These are.

* bind-Value Binding 

## Bind value binding

The value binding can be achieved by using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Value) attribute and it supports `string`, `int`, `enum`, `bool` and `complex types`. If the component value has been changed, it will affect all places where you bind the variable for the `@bind-value` attribute. In order for the binding to work properly, the value assigned to the `@bind-value` attribute should be based on the field mapped to [MultiSelectFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_Value)

* **TValue** - Specifies the type of each list item of the multiselect component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/bind-value.razor %}

{% endhighlight %}

![Blazor MultiSelect with Bind Value](./images/value-binding/blazor_multiselect_bind-value.png)

## Text and value

The MultiSelect [MultiSelectFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_Value) and [MultiSelectFieldSettings.Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html#Syncfusion_Blazor_DropDowns_FieldSettingsModel_Text) properties point to the corresponding names of the model. The `MultiSelectFieldSettings.Value` mapped to the component maintains the unique value of the item in the data source, and the `MultiSelectFieldSettings.Text` is mapped to display the text in the popup list items for the respective text value.

The following code demonstrates the Value and Text field of the MultiSelect component. For instance, the selected item is `Badminton` (Text Field, this is Game) but the value field holds `Game2` (Value Field, this is ID).

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/text-and-value.razor %}

{% endhighlight %}

![Blazor MultiSelect with Text and Value](./images/value-binding/blazor_MultiSelect_text-and-value.png)

## Primitive type binding

The MultiSelect has support to load array of primitive data such as strings and numbers. Bind the value of primitive data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Value) attribute of the MultiSelect. 

The following code demonstrates array of string as datasource to the MultiSelect component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-string.razor %}

{% endhighlight %}

![Blazor MultiSelect with Primitive Type as string](./images/value-binding/blazor_MultiSelect_primitive-type-string.png)

The following code demonstrates array of int as datasource to the MultiSelect component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-int.razor %}

{% endhighlight %}

![Blazor MultiSelect with Primitive Type as int](./images/value-binding/blazor_MultiSelect_primitive-type-int.png)

## Object binding

Bind the Object data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Value) attribute of the DropdownList component, this is, You can map the class name to `TValue`. 

In the following example, the `Name` column has been mapped to the [DropDownListFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_Value).

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/object-binding.razor %}

{% endhighlight %}

![Blazor MultiSelect with object values](./images/value-binding/blazor_MultiSelect_object-binding.png)

## Enum binding

Bind the enum data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Value) attribute of MultiSelect component. The following code helps you to get a string value from the enumeration data.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/enum-binding.razor %}

{% endhighlight %}

![Blazor MultiSelect with Enum Data](./images/value-binding/blazor_MultiSelect_enum-binding.png)

## Show or hide clear button

Use the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_ShowClearButton) property to specify whether to show or hide the clear button. When the clear button is clicked, the `Value`, `Text`, and `Index` properties are reset to null.

N> If the TValue is a non nullable type, then while using the clear button, it will set the default value of the data type, and if TValue is set as a nullable type, then while using the clear button it will set to a null value(for example If the TValue is int, then while clearing 0 will set to the component and if TValue is int?, then while clearing null will set to the component)

The following sample demonstrates the `string` used as `TValue`. So, if you clear the value using the clear button, it will be set to null as it's the default value of the respective type.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/show-hide-clear-button.razor %}

{% endhighlight %}

![Blazor MultiSelect with clear button](./images/value-binding/blazor_MultiSelect_show-hide-clear-button.png)

## Dynamically change TItem

The `TItem` property can be changed dynamically by defining the datasource type of the MultiSelect component with the help of the `@typeparam` directive. The following sample demonstration explains how to change  the TItem dynamically with different type of datasource.

### Creating generic MultiSelect component

First, create a `MultiSelect.razor` file as a parent component in the `/Pages` folder. Also, add a Parameter property for a List as `<TItem>` and `TValue`.

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

{% endhighlight razor %}
{% endtabs %}

### Usage of generic component with different type

Then, render the Generic MultiSelect component with the required `TValue` and `TItem` in the respective razor components. 

Here, the MultiSelect component is rendered with the TValue as a string type in the `/Index.razor` file and the MultiSelect component with TValue as an int nullable type in the `/Counter.razor` file.

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

{% endhighlight razor %}
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


{% endhighlight razor %}
{% endtabs %}
