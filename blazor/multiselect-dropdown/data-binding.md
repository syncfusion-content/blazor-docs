---
layout: post
title: Data Binding in Blazor MultiSelect Dropdown Component | Syncfusion 
description: Learn about Data Binding in Blazor MultiSelect Dropdown component of Syncfusion, and more details.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Data Binding

Data binding can be achieved by using the `bind-Value` attribute and its supports string, int, Enum, DateTime, bool types. If component value has been changed, it will affect the all places where we bind the variable for the **bind-value** attribute.

```csharp
@using Syncfusion.Blazor.DropDowns

@foreach (var SelectedValue in MultiVal)
{
    <p>MultiSelect value is:<strong>@SelectedValue</strong></p>
}

<SfMultiSelect Placeholder="e.g. Australia" @bind-Value="@MultiVal" DataSource="@Country">
    <MultiSelectFieldSettings Value="Name"></MultiSelectFieldSettings>
</SfMultiSelect>

@code {

   public string[] MultiVal { get; set; } = new string[] { };

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
