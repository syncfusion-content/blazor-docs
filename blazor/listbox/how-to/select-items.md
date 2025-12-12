---
layout: post
title: Select Items in Blazor ListBox Component | Syncfusion
description: Checkout and learn here all about select items in Syncfusion Blazor ListBox component and much more.
platform: Blazor
control: List Box
documentation: ug
---

# Select Items in Blazor ListBox Component

This example shows how to programmatically select items using the [SelectItemsAsync method](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfListBox-2.html#Syncfusion_Blazor_DropDowns_SfListBox_2_SelectItemsAsync__1___0_System_Boolean_). The first parameter accepts the value or values to select, and the second parameter specifies the selection mode: set it to true to select by the mapped Value field (Text in this example), or false to select by index. Selection is triggered in the Created event to ensure the component is initialized. The `TValue` is `string[]`, which enables multiple selection. Values that do not match any items are ignored.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfListBox TValue="string[]" TItem="VehicleData" DataSource="@Vehicles" @ref="ListBoxObj">
    <ListBoxEvents TValue="string[]" Created="created" TItem="VehicleData"></ListBoxEvents>
    <ListBoxFieldSettings Text="Text" Value="Text" />
</SfListBox>

@code {
    SfListBox<string[],VehicleData> ListBoxObj;
    public List<VehicleData> Vehicles = new List<VehicleData> {
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
    public string[] Value = new string[] { "Bugatti Chiron" };
    private async Task created(object args)
    {
        await ListBoxObj.SelectItemsAsync(this.Value, true);
    }
}

```

![Selecting items in the Blazor ListBox](./../images/blazor-listbox-item-selection.png)