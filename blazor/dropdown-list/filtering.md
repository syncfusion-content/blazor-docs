---
layout: post
title: Filtering in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Filtering in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Filtering in Blazor DropDown List Component

The DropDownList has built-in support to filter data items when [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_AllowFiltering) is enabled. The filter
operation starts as soon as you start typing characters in the search box.

```cshtml
@using Syncfusion.Blazor.DropDowns

    <SfDropDownList TValue="string" TItem="Countries" Placeholder="Select a country" AllowFiltering="true" DataSource="@Country">
        <DropDownListFieldSettings Text="Name" Value="Code"></DropDownListFieldSettings>
    </SfDropDownList>

@code{
    public class Countries
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    private List<Countries> Country = new List<Countries>
{
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" },
        new Countries() { Name = "Denmark", Code = "DK" },
        new Countries() { Name = "France", Code = "FR" },
        new Countries() { Name = "Finland", Code = "FI" },
        new Countries() { Name = "Germany", Code = "DE" },
        new Countries() { Name = "Greenland", Code = "GL" },
        new Countries() { Name = "Hong Kong", Code = "HK" },
        new Countries() { Name = "India", Code = "IN" },
        new Countries() { Name = "Italy", Code = "IT" },
        new Countries() { Name = "Japan", Code = "JP" },
        new Countries() { Name = "Mexico", Code = "MX" },
        new Countries() { Name = "Norway", Code = "NO" },
        new Countries() { Name = "Poland", Code = "PL" },
        new Countries() { Name = "Switzerland", Code = "CH" },
        new Countries() { Name = "United Kingdom", Code = "GB" },
        new Countries() { Name = "United States", Code = "US" },
    };
}
```

The output will be as follows.

![DropDownList](./images/filter.png)

## Custom Filtering

The DropDownList component filter queries can be customized. You can also use your own filter libraries to filter data like Fuzzy search.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfDropDownList TValue="string" @ref="ddlObj" TItem="Countries" Placeholder="e.g. Australia" DataSource="@Country" AllowFiltering="true">
    <DropDownListFieldSettings Text="Name" Value="Code"></DropDownListFieldSettings>
    <DropDownListEvents TValue="string" TItem="Countries" Filtering="OnFilter"></DropDownListEvents>
</SfDropDownList>


@code {

    SfDropDownList<string, Countries> ddlObj { get; set; }

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
        new Countries() { Name = "Denmark", Code = "DK" }
    };

    List<Countries> Country1 = new List<Countries>
    {
        new Countries() { Name = "France", Code = "FR" },
        new Countries() { Name = "Finland", Code = "FI" },
        new Countries() { Name = "Germany", Code = "DE" },
        new Countries() { Name = "Greenland", Code = "GL" }
    };

    private async Task OnFilter(FilteringEventArgs args)
    {
        args.PreventDefaultAction = true;
        var query = new Query().Where(new WhereFilter() { Field = "Name", Operator = "contains", value = args.Text, IgnoreCase = true });

        query = !string.IsNullOrEmpty(args.Text) ? query : new Query();

        await ddlObj.FilterAsync(Country1, query);
    }


}
```