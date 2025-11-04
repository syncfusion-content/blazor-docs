---
layout: post
title: Bind Change Events in Blazor ListBox Component | Syncfusion
description: Checkout and learn here all about bind change events in Syncfusion Blazor ListBox component and more.
platform: Blazor
control: List Box
documentation: ug
---

# Bind Change Events in Blazor ListBox Component

To bind the change event in the listbox [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfListBox-2.html) event is used and the event is triggered when the value in the listbox changes.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfListBox TValue="string[]" TItem="VehicleData" DataSource="@Vehicles">
    <ListBoxEvents TValue="string[]" ValueChange="change" TItem="VehicleData"></ListBoxEvents>
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
        new VehicleData { Text = "Aston Martin One- 77", Id = "Vehicle-07" },
        new VehicleData { Text = "Jaguar XJ220", Id = "Vehicle-08" }
        };

    public class VehicleData {
        public string Text  { get; set; }
        public string Id  { get; set; }
    }

    private void change(ListBoxChangeEventArgs<string[], VehicleData> args)
    {
        //Triggers when value changed
    }
}

```

![Binding Events in Blazor ListBox](./../images/blazor-listbox.png)