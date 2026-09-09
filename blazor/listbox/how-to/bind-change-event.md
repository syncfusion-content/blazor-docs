---
layout: post
title: How to bind change events in Blazor ListBox | Syncfusion
description: Handle Blazor ListBox value changes by binding the ValueChange event to respond to selection updates.
platform: Blazor
control: List Box
documentation: ug
---

# How to bind change events in Blazor ListBox

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ListBoxEvents-2.html#Syncfusion_Blazor_DropDowns_ListBoxEvents_2_ValueChange) event in [ListBoxEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ListBoxEvents-2.html) binds a change handler. This event is triggered whenever the selected value in the ListBox changes because of a user interaction, such as selecting or deselecting an item.

The handler receives a [ListBoxChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ListBoxChangeEventArgs-2.html) payload that exposes the following key properties:

* `Value` – The currently selected values.
* `Items` – The data items currently bound to the ListBox.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfListBox TValue="string[]" TItem="VehicleData" DataSource="@Vehicles">
    <ListBoxEvents TValue="string[]" ValueChange="OnValueChange" TItem="VehicleData"></ListBoxEvents>
    <ListBoxFieldSettings Text="Text" Value="Id" />
</SfListBox>

@code {
    public List<VehicleData> Vehicles = new List<VehicleData>
        {
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

    private void OnValueChange(ListBoxChangeEventArgs<string[], VehicleData> args)
    {
        //Triggers when value changed
    }
}

```

![Blazor ListBox with change event binding example](./../images/blazor-listbox.webp)

## See also

* [Select Items in Blazor ListBox](./select-items.md)
* [Get Items in Blazor ListBox](./get-items.md)
* [Data Binding in Blazor ListBox](./../data-binding.md)
* [Selection in Blazor ListBox](./../selection.md)