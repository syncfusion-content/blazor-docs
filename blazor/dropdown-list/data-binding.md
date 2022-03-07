---
layout: post
title: Data Binding in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Data Binding in Blazor DropDown List Component

Data binding can be achieved by using the `bind-Value` attribute and it supports string, int, Enum and bool types. If component value has been changed, it will affect the all places where you bind the variable for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.DropDowns

<p>DropDownList value is:<strong>@DropVal</strong></p>

<SfDropDownList TValue="string" Placeholder="e.g. Australia" TItem="Country" @bind-Value="@DropVal" DataSource="@Countries">
    <DropDownListFieldSettings Value="Name"></DropDownListFieldSettings>
</SfDropDownList>

@code {

    public string DropVal;

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

## Index Value Binding

Index value binding can be achieved by using `bind-Index` attribute and it supports int and int nullable types. By using this attribute you can bind the values respective to its index.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TValue="string" Placeholder="e.g. Australia" TItem="Country" @bind-Index="@ddlIndex" DataSource="@Countries">
    <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
</SfAutoComplete>

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
