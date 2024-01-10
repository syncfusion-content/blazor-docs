---
layout: post
title: Sorting and Grouping in Blazor ListBox Component | Syncfusion
description: Checkout and learn here all about sorting and grouping in Syncfusion Blazor ListBox component and more.
platform: Blazor
control: List Box
documentation: ug
---

# Sorting and Grouping in Blazor ListBox Component

## Sorting

The ListBox supports sorting of available items in the alphabetical order that can be either ascending or descending. This can be achieved using [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html) property. Sort order can be `None`, `Ascending` or `Descending`.

In the following example, the `SortOrder` is set as `Descending`.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfListBox TValue="string[]" DataSource="@CountryData" SortOrder="Syncfusion.Blazor.DropDowns.SortOrder.Descending" TItem="CountryCode">
  <ListBoxFieldSettings Text="Name" Value="Code" />
</SfListBox>

@code {
    public List<CountryCode> CountryData = new List<CountryCode> {
        new CountryCode{ Name = "Australia", Code = "AU" },
        new CountryCode{ Name = "Bermuda", Code = "BM" },
        new CountryCode{ Name = "Canada", Code = "CA" },
        new CountryCode{ Name = "Cameroon", Code = "CM" },
        new CountryCode{ Name = "Denmark", Code = "DK" },
        new CountryCode{ Name = "France", Code = "FR" },
        new CountryCode{ Name = "Finland", Code = "FI" },
        new CountryCode{ Name = "Germany", Code = "DE" },
        new CountryCode{ Name = "Hong Kong", Code = "HK" }
    };
    public class CountryCode {
      public string Name { get; set; }
      public string Code { get; set; }
    }
}

```

![Sorting in Blazor ListBox](images/blazor-listbox-sorting.png)

## Grouping

The ListBox supports to wrap the nested element into a group based on its category. The category of each list item can be mapped with [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ListBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ListBoxFieldSettings_GroupBy) field in the data table.

To get started quickly with grouping in the Blazor ListBox component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=Ja_UJva-cHA" %}

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfListBox TValue="string[]" DataSource="@VegetableData" TItem="VegetableDetail">
  <ListBoxFieldSettings GroupBy = "Category" Text="Vegetable" Value="Id" />
</SfListBox>

@code {
    public List<VegetableDetail> VegetableData = new List<VegetableDetail> {
       new VegetableDetail{ Vegetable = "Cabbage", Category = "Leafy and Salad", Id = "item1" },
       new VegetableDetail{ Vegetable = "Spinach", Category = "Leafy and Salad", Id = "item2" },
       new VegetableDetail{ Vegetable = "Wheat grass", Category = "Leafy and Salad", Id = "item3" },
       new VegetableDetail{ Vegetable = "Yarrow", Category = "Leafy and Salad", Id = "item4" },
       new VegetableDetail{ Vegetable = "Pumpkins", Category = "Leafy and Salad", Id = "item5" },
       new VegetableDetail{ Vegetable = "Chickpea", Category = "Beans", Id = "item6" },
       new VegetableDetail{ Vegetable = "Green bean", Category = "Beans", Id = "item7" },
       new VegetableDetail{ Vegetable = "Horse gram", Category = "Beans", Id = "item8" },
       new VegetableDetail{ Vegetable = "Garlic", Category = "Bulb and Stem", Id = "item9" },
       new VegetableDetail{ Vegetable = "Nopal", Category = "Bulb and Stem", Id = "item10" },
       new VegetableDetail{ Vegetable = "Onion", Category = "Bulb and Stem", Id = "item11" }
    };

    public class VegetableDetail {
      public string Vegetable { get; set; }
      public string Category { get; set; }
      public string Id { get; set; }
    }
}
```

![Grouping in Blazor ListBox](images/blazor-listbox-grouping.png)