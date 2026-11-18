---
layout: post
title: How to filter data in Blazor ListBox | Syncfusion
description: Filter Blazor ListBox items from an external HTML input using the FilterAsync method and Query criteria.
platform: Blazor
control: List Box
documentation: ug
---

# How to filter data in Blazor ListBox

This example shows how to filter ListBox data based on input from an HTML `<input>` element. Bind the input element's `oninput` event to a handler that filters the ListBox items based on the entered text. Within the event handler, use the [FilterAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfListBox-2.html#Syncfusion_Blazor_DropDowns_SfListBox_2_FilterAsync_System_Collections_Generic_IEnumerable__1__Syncfusion_Blazor_Data_Query_Syncfusion_Blazor_DropDowns_FieldSettingsModel_) method to update the ListBox items, ensuring that only those matching the input text are included. The [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) class is used to define the filtering criteria.

This approach is useful when you want full control over the filter UI (for example, to place the search input outside the ListBox or apply custom styling). For the built-in filter bar, refer to [Filtering in Blazor ListBox](./../filtering.md).

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

<label for="filter">Enter Text: </label>
<input type="text" id="filter" @oninput="FilterList" placeholder="Enter text to filter"/>
<SfListBox @ref="ListBoxRef" TValue="string[]" DataSource="@Vehicles" TItem="VehicleData">
    <ListBoxFieldSettings Text="Text" Value="Id" />
</SfListBox>

@code {
    private SfListBox<string[], VehicleData> ListBoxRef;

    public List<VehicleData> Vehicles = new List<VehicleData> {
        new VehicleData { Text = "Hennessey Venom", Id = "Vehicle-01" },
        new VehicleData { Text = "Bugatti Chiron", Id = "Vehicle-02" },
        new VehicleData { Text = "Bugatti Veyron Super Sport", Id = "Vehicle-03" },
        new VehicleData { Text = "SSC Ultimate Aero", Id = "Vehicle-04" },
        new VehicleData { Text = "Koenigsegg CCR", Id = "Vehicle-05" },
        new VehicleData { Text = "McLaren F1", Id = "Vehicle-06" },
        new VehicleData { Text = "Aston Martin One-77", Id = "Vehicle-07" },
        new VehicleData { Text = "Jaguar XJ220", Id = "Vehicle-08" }
    };

    public class VehicleData {
        public string Text { get; set; }
        public string Id { get; set; }
    }

    private async Task FilterList(Microsoft.AspNetCore.Components.ChangeEventArgs e)
    {
        var inputValue = e.Value?.ToString() ?? string.Empty;
        var query = new Query().Where("Text", "contains", inputValue, true);
        await ListBoxRef.FilterAsync(Vehicles, query);
    }
    
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthJMjgtfQYiRtee?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Adding Items in Blazor ListBox](./../images/blazor-listbox-filter.webp)" %}

## See also

* [Filtering in Blazor ListBox](./../filtering.md)
* [Get Items in Blazor ListBox](./get-items.md)
* [Data Binding in Blazor ListBox](./../data-binding.md)
