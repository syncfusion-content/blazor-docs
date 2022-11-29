---
layout: post
title: Filtering in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Filtering in the Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Filtering in Blazor ComboBox Component

The ComboBox has built-in support to filter data items when [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) is enabled. The filter operation starts as soon as you start typing characters in the component.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="EmployeeData" Placeholder="Select a customer" Query="@Query" AllowFiltering=true>
    <SfDataManager Url="https://ej2services.syncfusion.com/production/web-services/api/Employees" Adaptor="Adaptors.WebApiAdaptor" CrossDomain=true></SfDataManager>
    <ComboBoxFieldSettings Text="FirstName" Value="EmployeeID"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public Query Query = new Query();

    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
    }
}
```


![Filtering in Blazor ComboBox](./images/blazor-combobox-filtering.png)

## Custom Filtering

The ComboBox component filter queries can be customized. You can also use your own filter libraries to filter data like Fuzzy search.

```cshtml
@using Syncfusion.Blazor.Data

<SfComboBox TValue="string" @ref="comboObj" TItem="Country" Placeholder="e.g. Australia" DataSource="@Countries" AllowFiltering="true">
    <ComboBoxFieldSettings Text="Name" Value="Code"></ComboBoxFieldSettings>
    <ComboBoxEvents TValue="string" TItem="Country" Filtering="OnFilter"></ComboBoxEvents>
</SfComboBox>

@code {

    SfComboBox<string, Country> comboObj { get; set; }

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

        await comboObj.FilterAsync(CountriesFiltered, query);
    }
}
```

## Custom Filtering with Custom Adaptor

The following sample code demonstrates implementing custom filtering with custom data adaptor, which allows to perform manual operations on the data. This can be utilized for implementing custom data binding and editing operations in the ComboBox component

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

{% include_relative code-snippet/combobox-filter-using-custom-adaptor.razor %}

{% endhighlight %}

​​​​​​​{% endtabs %}