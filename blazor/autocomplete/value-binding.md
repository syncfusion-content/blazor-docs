---
layout: post
title:  Data Binding in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Value Binding in AutoComplete

Value binding is the process of synchronizing a component’s value with its parent. There are two ways to bind values:
- bind-Value binding
- bind-Index binding

## Bind value binding

Value binding is achieved using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Value) attribute, and it supports `string`, `int`, `enum`, `bool`, and complex types. When the component value changes, the bound variable (used with `@bind-Value`) is updated everywhere it is referenced. For correct binding, the bound value should correspond to the field mapped to [AutoCompleteFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Value).

* **TValue** - specifies the type of each list item on the suggestion list.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/bind-value.razor %}

{% endhighlight %}

![Blazor AutoComplete with Bind Value](./images/value-binding/blazor-autocomplete-bind-value.png)

## Index value binding

Index value binding is achieved using the [@bind-Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Index) attribute, which supports `int` and nullable `int` types. Use this to bind and select items by their zero-based index.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/index-value.razor %}

{% endhighlight %}

![Blazor AutoComplete with Index Value](./images/value-binding/blazor-autocomplete-index-value.png)

## Value field

The AutoComplete [AutoCompleteFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Value) property points to the corresponding field in the data model. The mapped value represents the unique value of each item in the data source and determines which item is selected; the display text appears in the popup list.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/text-and-value.razor %}

{% endhighlight %}

![Blazor AutoComplete with Value](./images/value-binding/blazor-autocomplete-value.png)

## Primitive type binding

The AutoComplete supports arrays of primitive data such as strings and numbers. Bind the primitive value to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Value) attribute. For primitive lists, field settings can be inferred or set explicitly if needed.

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

Bind object data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Value) attribute of the AutoComplete component, and map the class to `TValue`.

In the following example, the `Name` field is mapped to [AutoCompleteFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Value).

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/object-binding.razor %}

{% endhighlight %}

![Blazor AutoComplete with object values](./images/value-binding/blazor-autocomplete-object-binding.png)

## Enum binding

Bind enum data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Value) attribute of the AutoComplete component. The following example shows how to obtain a string value from enumeration data.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/enum-binding.razor %}

{% endhighlight %}

![Blazor AutoComplete with Enum Data](./images/value-binding/blazor-autocomplete-enum-binding.png)

## Show or hide clear button

Use the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_ShowClearButton) property to show or hide the clear button. When clicked, the `Value`, `Text`, and `Index` properties are reset.

N> If `TValue` is non-nullable, clearing sets the default value of the type (for example, 0 for `int`). If `TValue` is nullable (for example, `int?`), clearing sets the value to `null`.

The following sample uses `string` as `TValue`. Clearing sets the value to `null`, which is the default for that type.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/show-hide-clear-button.razor %}

{% endhighlight %}

![Blazor AutoComplete with clear button](./images/value-binding/blazor-autocomplete-show-hide-clear-button.png)

## Dynamically change TItem

The `TItem` type can be changed dynamically by declaring the AutoComplete as a generic component with the `@typeparam` directive. The following sample demonstrates changing `TItem` dynamically for different data sources.

### Creating generic AutoComplete component

First, create an `AutoComplete.razor` file as a parent component in the `/Pages` folder. Add a parameter for a list as `<TItem>` and a `TValue` parameter.

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

Two-way binding synchronizes the component value with the model and UI. Use the `@bind-Value` directive to enable two-way binding for the Syncfusion Blazor AutoComplete component.

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