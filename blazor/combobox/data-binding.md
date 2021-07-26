---
layout: post
title: Data Binding in Blazor ComboBox Component | Syncfusion 
description: Learn about Data Binding in Blazor ComboBox component of Syncfusion, and more details.
platform: Blazor
control: ComboBox
documentation: ug
---

# Data Binding

Data binding can be achieved by using the `bind-Value` attribute and its supports string, int, Enum, and bool types. If component value has been changed, it will affect the all places where we bind the variable for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.DropDowns

<p>ComboBox value is:<strong>@ComboVal</strong></p>

<SfComboBox Placeholder="e.g. Australia" @bind-Value="@ComboVal" DataSource="@Country">
    <ComboBoxFieldSettings Value="Name"></ComboBoxFieldSettings>
</SfComboBox>

@code {

    public string ComboVal = "Austarila";

    public class Countries
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    List<Countries> Country = new List<Countries>
    {
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" },
    };
}
```

## Index Value Binding

Index value binding can be achieved by using `bind-Index` attribute and it supports int and int nullable types. By using this attribute you can bind the values respective to its index.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" Placeholder="e.g. Australia" TItem="Countries" @bind-Index="@ddlIndex" DataSource="@Country">
    <ComboBoxFieldSettings Value="Name"></ComboBoxFieldSettings>
</SfComboBox>

@code {

    private int? ddlIndex { get; set; } = 1;

    public class Countries
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    List<Countries> Country = new List<Countries>
{
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" },
    };
}
```
