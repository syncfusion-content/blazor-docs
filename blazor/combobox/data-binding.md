---
layout: post
title: Data Binding in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Data Binding in Blazor ComboBox Component

Data binding can be achieved by using the `bind-Value` attribute and it supports string, int, Enum, and bool types. If the component value is changed, it will affect all places where the variable is bound for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.DropDowns

<p>ComboBox value is:<strong>@ComboVal</strong></p>

<SfComboBox Placeholder="e.g. Australia" @bind-Value="@ComboVal" DataSource="@Countries">
    <ComboBoxFieldSettings Value="Name"></ComboBoxFieldSettings>
</SfComboBox>

@code {

    public string ComboVal = "Austarila";

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/htVgshVcqRXvAAyY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Index value binding

Index value binding can be achieved by using `bind-Index` attribute and it supports int and int nullable types. By using this attribute you can bind the values respective to its index.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" Placeholder="e.g. Australia" TItem="Country" @bind-Index="@ddlIndex" DataSource="@Countries">
    <ComboBoxFieldSettings Value="Name"></ComboBoxFieldSettings>
</SfComboBox>

@code {

    private int? ddlIndex { get; set; } = 1;

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZhqshBGgdWoItJf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
