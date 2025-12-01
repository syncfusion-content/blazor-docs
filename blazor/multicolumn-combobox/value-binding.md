---
layout: post
title:  Value Binding in Blazor MultiColumn ComboBox Component | Syncfusion
description: Checkout and learn here all about value binding in Syncfusion Blazor MultiColumn ComboBox component and more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Value Binding in MultiColumn ComboBox

Value binding synchronizes the selected value between the Blazor MultiColumn ComboBox and the parent component. The control supports two binding approaches:
- `@bind-Value` to bind the selected value
- `@bind-Index` to bind by the zero-based item index

## Value binding

Bind the selected value using the [`@bind-Value`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Value) attribute. Supported value types include primitives (such as `string`, `int`, `bool`, `enum`) and complex types. Ensure the bound value type aligns with the configured [ValueField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ValueField) and [TextField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_TextField) mapping.

- `TValue`: Specifies the selected value type.
- `TItem`: Specifies the data model type of each item.

When the component value changes, all places bound with the same variable are updated.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/bind-value.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBJXYhzMFjWdrGx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Bind Value](./images/value-binding/blazor-combobox-bind-value.png)" %}

## Index value binding

The Index value binding is accomplished through the [@bind-Index]() attribute, which supports both integer and nullable integer types. This attribute allows you to bind values according to their corresponding index.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/index-value.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrJXOrUfZAICmMF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Index Value](./images/value-binding/blazor_combobox_index-value.png)" %}

<!-- ## Object binding

Bind the Object data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Value) attribute of the MultiColumn ComboBox component, allowing you to associate the class name with `TValue`.

In the example provided, the `Name` column is linked to the [ValueField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ValueField) property.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/object-binding.razor %}

{% endhighlight %} -->

## Show or hide clear button

Control the clear button visibility using the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ShowClearButton) property. When the clear button is clicked, the `Value`, `Text`, and `Index` properties reset to `null`.

N> If the TValue is a non-nullable type, pressing the clear button will reset it to the default value for that data type. Conversely, if TValue is a nullable type, pressing the clear button will set it to null. For instance, if TValue is defined as `int`, clearing it will assign a value of 0 to the component, whereas if TValue is defined as `int?`, it will assign a value of null.

The following example uses `string` as the `TValue`, so clearing sets the value to `null`.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/show-hide-clear-button.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBftkrKpNAYFijk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with clear button](./images/value-binding/blazor_combobox_show-hide-clear-button.png)" %}

## Dynamically change TItem

`TItem` can be changed dynamically by wrapping the MultiColumn ComboBox in a generic component that declares `@typeparam` parameters for `TValue` and `TItem`, and exposes parameters for the data source and bound value. The following sample demonstrates using a generic component to switch data types.

### Creating a generic MultiColumn ComboBox component

Create a `MultiColumnComboBox.razor` file that defines `@typeparam` for `TValue` and `TItem`, and exposes parameters for `customData` and `ComboBoxValue`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.MultiColumnComboBox

@typeparam TValue;
@typeparam TItem;

<SfMultiColumnComboBox TValue="TValue" Width="300px" TItem="TItem" @bind-Value="@ComboBoxValue" Placeholder="Please select a value" DataSource="@customData" ValueField="ID" TextField="Text">
</SfMultiColumnComboBox>

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

### Use the generic component with different types

Render the generic component with the required `TValue` and `TItem` in the corresponding Razor page.

Example: Use `int?` for `TValue` and a `Games` model for `TItem` in `Index.razor`.

**[Index.razor]**

{% tabs %}
{% highlight razor %}


<MultiColumnComboBox TValue="int?" TItem="Games" @bind-ComboBoxValue="@value" customData="@LocalData" >
</MultiColumnComboBox>


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