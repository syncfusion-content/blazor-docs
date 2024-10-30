---
layout: post
title: Filter Data in Blazor ListBox Component | Syncfusion
description: Checkout and learn here all Filter ListBox Data Using TextBox Component in Syncfusion Blazor ListBox component and much more.
platform: Blazor
control: List Box
documentation: ug
---

# How to Filter Blazor ListBox Data Using TextBox Component

This example demonstrates how to filter data in the Syncfusion ListBox using a TextBox component. It shows the implementation of a TextBox filter for data filtering in ListBox items.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

<label for="filter">Enter Text: </label>
<input id="filter" @oninput="FilterList" />
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
        await ListBoxRef.FilterAsync(Vehicles, query);  // Use ListBoxRef here
    }
    
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhTMZUjLEnVZImZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Adding Items in Blazor ListBox](./../images/blazor-listbox-filter.png)