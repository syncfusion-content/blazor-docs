---
layout: post
title: Value Binding in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Value Binding in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Value Binding in Dropdown List

Value binding is the process of passing values between a component and its parent. There are two methods for binding values.These are.

* bind-Value Binding 
* bind-Index Binding

## Bind value binding

The value binding can be achieved by using the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute and it supports `string`, `int`, `enum`, `bool` and `complex types`. If the component value has been changed, it will affect all places where you bind the variable for the `@bind-value` attribute. In order for the binding to work properly, the value assigned to the `@bind-value` attribute should be based on the field mapped to [DropDownListFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html#Syncfusion_Blazor_DropDowns_FieldSettingsModel_Value)

* **TValue** - Specifies the type of each list item of the dropdown component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/bind-value.razor %}

{% endhighlight %}

![Blazor DropDownList with Bind Value](./images/value-binding/blazor_dropdown_bind-value.png)

## Index value binding

The Index value binding is achieved by using the [@bind-Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Index) attribute and it supports int and int nullable types. By using this attribute, bind the values respective to its index.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/index-value.razor %}

{% endhighlight %}

![Blazor DropDownList with Index Value](./images/value-binding/blazor_dropdown_index-value.png)

## Text and value

The DropdownList [DropDownListFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html#Syncfusion_Blazor_DropDowns_FieldSettingsModel_Value) and [DropDownListFieldSettings.Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html#Syncfusion_Blazor_DropDowns_FieldSettingsModel_Text) properties point to the corresponding names of the model. The `DropDownListFieldSettings.Value` mapped to the component maintains the unique value of the item in the data source, and the `DropDownListFieldSettings.Text` is mapped to display the text in the popup list items for the respective text value.

The following code demonstrates the Value and Text field of the DropDownList component. For instance, the selected item is `Badminton` (Text Field, this is Game) but the value field holds `Game2` (Value Field, this is ID).

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/text-and-value.razor %}

{% endhighlight %}

![Blazor DropDownList with Text and Value](./images/value-binding/blazor_dropdown_text-and-value.png)

## Primitive type binding

The DropDownList has support to load array of primitive data such as strings and numbers. Bind the value of primitive data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute of the DropDownList 

The following code demonstrates array of string as datasource to the DropDownList component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-string.razor %}

{% endhighlight %}

![Blazor DropDownList with Primitive Type as string](./images/value-binding/blazor_dropdown_primitive-type-string.png)

The following code demonstrates array of int as datasource to the DropDownList component.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/primitive-type-int.razor %}

{% endhighlight %}

![Blazor DropDownList with Primitive Type as int](./images/value-binding/blazor_dropdown_primitive-type-int.png)

## Object binding

Bind the Object data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute of the DropdownList component, this is, You can map the class name to `TValue`. 

In the following example, the `Name` column has been mapped to the [DropDownListFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html#Syncfusion_Blazor_DropDowns_FieldSettingsModel_Value).

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/object-binding.razor %}

{% endhighlight %}

![Blazor DropDownList with object values](./images/value-binding/blazor_dropdown_object-binding.png)

## Enum binding

Bind the enum data to the [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) attribute of DropDownList component. The following code helps you to get a string value from the enumeration data.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/enum-binding.razor %}

{% endhighlight %}

![Blazor DropDownList with Enum Data](./images/value-binding/blazor_dropdown_enum-binding.png)

## Show or hide clear button

Use the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ShowClearButton) property to specify whether to show or hide the clear button. When the clear button is clicked, the `Value`, `Text`, and `Index` properties are reset to null.

N> If the TValue is a non nullable type, then while using the clear button, it will set the default value of the data type, and if TValue is set as a nullable type, then while using the clear button it will set to a null value(for example If the TValue is int, then while clearing 0 will set to the component and if TValue is int?, then while clearing null will set to the component)

The following sample demonstrates the `string` used as `TValue`. So, if you clear the value using the clear button, it will be set to null as it's the default value of the respective type.

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/show-hide-clear-button.razor %}

{% endhighlight %}

![Blazor DropDownList with clear button](./images/value-binding/blazor_dropdown_show-hide-clear-button.png)

## Dynamically change TItem

The `TItem` property can be changed dynamically by defining the datasource type of the DropDownList component with the help of the `@typeparam` directive. The following sample demonstration explains how to change  the TItem dynamically with different type of datasource.

### Creating generic dropdownList component

First, create a `DropDownList.razor` file as a parent component in the `/Pages` folder. Also, add a Parameter property for a List as `<TItem>` and `TValue`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.DropDowns;
@typeparam TValue;
@typeparam TItem;

<SfDropDownList TValue="TValue" Width="300px" TItem="TItem" @bind-Value="@DDLValue" Placeholder="Please select a value" DataSource="@customData">
    <DropDownListFieldSettings Text="Text" Value="ID"></DropDownListFieldSettings>
</SfDropDownList>

@code {
    [Parameter]
    public List<TItem> customData { get; set; }
    [Parameter]
    public TValue DDLValue { get; set; }
    [Parameter]
    public EventCallback<TValue> DDLValueChanged { get; set; }
}

{% endhighlight razor %}
{% endtabs %}

### Usage of generic component with different type

Then, render the Generic DropDownList component with the required `TValue` and `TItem` in the respective razor components. 

Here, the DropDownList component is rendered with the TValue as a string type in the `/Index.razor` file and the DropDownList component with TValue as an int nullable type in the `/Counter.razor` file.

**[Index.razor]**

{% tabs %}
{% highlight razor %}

<DropDownList TValue="string" TItem="Games" @bind-DDLValue="@value" customData="@LocalData">
</DropDownList>

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

{% endhighlight razor %}
{% endtabs %}

**[Counter.razor]**

{% tabs %}
{% highlight razor %}
<DropDownList TValue="int?" TItem="Games" @bind-DDLValue="@value" customData="@LocalData">
</DropDownList>

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

{% endhighlight razor %}
{% endtabs %}

## Two way binding

Two-way is having a bi-directional data flow, i.e., passing the value from the property to the UI and then from the view (UI) to the property as well. The synchronization of data flow between model and view is achieved using the bind attribute in Blazor. To enable two-way binding for the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DropDownList component, you can use the @bind-Value directive to bind the value of the DropDownList

{% highlight cshtml %}

{% include_relative code-snippet/value-binding/two-way-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Two way binding](./images/value-binding/blazor_dropdown_two-way-binding.png)

## Programmatically clearing value

You can clear the value programmatically by accessing the `ClearAsync()` method through an instance of the dropdown list. You can bind the click event of a button to the `ClearAsync()` method. When the button is clicked, it will trigger the `ClearAsync()` method on the dropdown list, clearing its value.

{% highlight Razor %}

{% include_relative code-snippet/value-binding/clearAsync-method.razor %}

{% endhighlight %} 

![Blazor DropDownList with clear button](./images/value-binding/blazor_dropdown_with-clearAsync-method.gif)
