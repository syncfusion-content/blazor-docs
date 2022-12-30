---
layout: post
title: Filtering in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about filtering in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Filtering in Blazor MultiSelect Dropdown Component

The MultiSelect has built-in support to filter data items when [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_AllowFiltering) is enabled. The filter operation starts as soon as you start typing characters in the MultiSelect input.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TValue="string[]" TItem="Country" Placeholder="Select a country" AllowFiltering="true" DataSource="@Countries">
    <MultiSelectFieldSettings Text="Name" Value="Code"></MultiSelectFieldSettings>
</SfMultiSelect>

@code{
    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    private List<Country> Countries = new List<Country>
{
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
        new Country() { Name = "Denmark", Code = "DK" },
        new Country() { Name = "France", Code = "FR" },
        new Country() { Name = "Finland", Code = "FI" },
        new Country() { Name = "Germany", Code = "DE" },
        new Country() { Name = "Greenland", Code = "GL" },
        new Country() { Name = "Hong Kong", Code = "HK" },
        new Country() { Name = "India", Code = "IN" },
        new Country() { Name = "Italy", Code = "IT" },
        new Country() { Name = "Japan", Code = "JP" },
        new Country() { Name = "Mexico", Code = "MX" },
        new Country() { Name = "Norway", Code = "NO" },
        new Country() { Name = "Poland", Code = "PL" },
        new Country() { Name = "Switzerland", Code = "CH" },
        new Country() { Name = "United Kingdom", Code = "GB" },
        new Country() { Name = "United States", Code = "US" },
    };
}

```

![Filtering in Blazor MultiSelect DropDown](./images/blazor-multiselect-dropdown-filtering.png)

## Custom Filtering

The MultiSelect component filter queries can be customized. You can also use your own filter libraries to filter data like Fuzzy search.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TValue="string[]" @ref="mulObj" TItem="Country" Placeholder="e.g. Australia" DataSource="@Countries" AllowFiltering="true">
    <MultiSelectFieldSettings Text="Name" Value="Code"></MultiSelectFieldSettings>
    <MultiSelectEvents TValue="string[]" TItem="Country" Filtering="OnFilter"></MultiSelectEvents>
</SfMultiSelect>


@code {

    SfMultiSelect<string[], Country> mulObj { get; set; }

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
        new Country() { Name = "Denmark", Code = "DK" }
    };

    List<Country> CountriesFiltered = new List<Country>
    {
        new Country() { Name = "France", Code = "FR" },
        new Country() { Name = "Finland", Code = "FI" },
        new Country() { Name = "Germany", Code = "DE" },
        new Country() { Name = "Greenland", Code = "GL" }
    };

    private async Task OnFilter(FilteringEventArgs args)
    {
        args.PreventDefaultAction = true;
        var query = new Query().Where(new WhereFilter() { Field = "Name", Operator = "contains", value = args.Text, IgnoreCase = true });

        query = !string.IsNullOrEmpty(args.Text) ? query : new Query();

        await mulObj.FilterAsync(CountriesFiltered, query);
    }
}
```

## Properties

### AllowFiltering

When [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_AllowFiltering) property is set as `true`, filtering option is enabled in the component.

Filter action performs when type in search box and collect the matched item through `Filtering` event.

If searching character does not match, `NoRecordsTemplate` property value will be shown.

[Click to refer the code for AllowFiltering](https://blazor.syncfusion.com/documentation/multiselect-dropdown/filtering)

### FilterBarPlaceholder

Accepts the value to be displayed as a watermark text on the filter bar. [FilterBarPlaceholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_FilterBarPlaceholder) is applicable when [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_AllowFiltering) is set as `true` in the checkbox mode. `FilterBarPlaceholder` is depends on `AllowFiltering` in checkbox mode.

{% highlight Razor %}

{% include_relative code-snippet/filtering/filterBarPlaceholder-property.razor %}

{% endhighlight %} 

![Blazor MultiSelect DropDown with FilterBarPlaceholder property](./images/filtering/blazor_multiselect_filterBarPlaceholder-property.png)

## Methods

### FilterAsync(IEnumerable<TItem>, Query, FieldSettingsModel)

To filter the data from given data source by using query.

#### Declaration

N> public Task FilterAsync(IEnumerable<TItem> dataSource, Query query = null, FieldSettingsModel fields = null)

#### Parameters

* dataSource -Specifies the data source.
* query - Specifies the query.
* fields - Specifies the fields.

[Click to refer the code for FilterAsync](https://blazor.syncfusion.com/documentation/multiselect-dropdown/filtering)
