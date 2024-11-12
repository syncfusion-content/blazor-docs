---
layout: post
title: Data Binding in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Data Binding in Blazor MultiSelect Dropdown Component

Data binding can be achieved by using the `bind-Value` attribute and its supports string, int, Enum, DateTime, bool types. If component value has been changed, it will affect all the places where it is bound to the variable for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.DropDowns

@foreach (var SelectedValue in MultiVal)
{
    <p>MultiSelect value is:<strong>@SelectedValue</strong></p>
}

<SfMultiSelect Placeholder="e.g. Australia" @bind-Value="@MultiVal" DataSource="@Countries">
    <MultiSelectFieldSettings Value="Name"></MultiSelectFieldSettings>
</SfMultiSelect>

@code {

   public string[] MultiVal { get; set; } = new string[] { };

    public class Country
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    List<Country> Countries = new List<Country>
{
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
    };
}
```

## Enum binding

Convert the Enum data into a list of strings and bind it to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) property of the SfMultiSelect component to bind Enum types to the MultiSelect Dropdown component.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TValue="List<string>" TItem="string" Placeholder="Select a color" DataSource="@MultiSelectDataSource"
@bind-Value="SelectedValues">
    <MultiSelectFieldSettings Value="Value" Text="Text"></MultiSelectFieldSettings>
</SfMultiSelect>

@if (SelectedValues != null)
{
    <p>Selected Colors: @string.Join(", ", SelectedValues)</p>
}

@code {
    public enum Color
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    public class EnumModel
    {
        public Color Value { get; set; }
        public string Text { get; set; }
    }

    private List<string> MultiSelectDataSource { get; set; } = new List<string>();
    private List<string> SelectedValues { get; set; }

    protected override void OnInitialized()
    {
        MultiSelectDataSource = Enum.GetNames(typeof(Color)).ToList();
        SelectedValues = new List<string> { Enum.GetName(typeof(Color), 2) };
    }
}

```

## Customizing the Change Event

MultiSelect component by default fires the `Change event` when the component loses focus. However, if you want the Change event to be fired every time a value is selected or removed, disable the [EnabledChangeOnBlur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_EnableChangeOnBlur) property. This will make the Change event be fired on every value selection and removal instead of just when the component loses focus. The default value of `EnableChangeOnBlur` is `true.`

{% highlight Razor %}

{% include_relative code-snippet/data-binding/enableChangeOnBlur-property.razor %}

{% endhighlight %} 

## Get Data by value

You can retrieve the selected value from the dropdown list by using the `GetDataByValue(TValue)` method through an instance of the dropdown list. You can bind the click event of a button to the `GetDataByValue(TValue)` method of the dropdown list instance. When the button is clicked, it will trigger the `GetDataByValue(TValue)` method on the dropdown list and return the selected value.

{% highlight Razor %}

{% include_relative code-snippet/data-binding/getDataByValue-method.razor %}

{% endhighlight %}

## Get List Item

You can retrieve the list items from the dropdown list by using the `GetItemsAsync()` method through an instance of the dropdown list. You can bind the click event of a button to the `GetItemsAsync()` method of the dropdown list instance. When the button is clicked, it will trigger the `GetItemsAsync()` method on the dropdown list and return the list items

{% highlight Razor %}

{% include_relative code-snippet/data-binding/getItemsAsync-method.razor %}

{% endhighlight %} 

