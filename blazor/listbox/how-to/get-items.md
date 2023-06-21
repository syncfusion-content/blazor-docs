---
layout: post
title: Get Items in Blazor ListBox Component | Syncfusion
description: Checkout and learn here all about select items in Syncfusion Blazor ListBox component and much more.
platform: Blazor
control: List Box
documentation: ug
---

# Get Items in Blazor ListBox Component

The [GetDataByValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfListBox-2.html#Syncfusion_Blazor_DropDowns_SfListBox_2_GetDataByValue__0_) method is used to get the selected item/items from the list box component based on the value/values passed to this method.

The below example showcases the `GetDataByValue` method.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<SfListBox @ref="ListBoxObj" DataSource="@Vehicles" TValue="string[]" TItem="VehicleData" @bind-Value="@Value">
    <ListBoxFieldSettings Text="Text" Value="Text" />
</SfListBox>

<button @onclick="click">Click</button>

@code {
    SfListBox<string[], VehicleData> ListBoxObj;
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

    public class VehicleData
    {
        public string Text { get; set; }
        public string Id { get; set; }
    }
    public string[] Value = new string[] { "Bugatti Chiron" };
    private void click()
    {
        var Values = ListBoxObj.GetDataByValue(Value);
    }

}

```

![Selecting Items in Blazor ListBox](./../images/blazor-listbox-item-selection.png)