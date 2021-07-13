---
layout: post
title: How to Enable Scroll in Blazor List Box Component | Syncfusion
description: Checkout and learn about Enable Scroll in Blazor List Box component of Syncfusion, and more details.
platform: Blazor
control: List Box
documentation: ug
---

# Enable scroller

The ListBox supports scrolling and it can be achieved by restricting the height of the listbox using [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfListBox-2.html#Syncfusion_Blazor_DropDowns_SfListBox_2_Height) property.

In the following sample, `Height` of the listbox is restricted to `290px`.

```csharp
@using Syncfusion.Blazor.DropDowns

<SfListBox TValue="string[]" DataSource="@Vehicles" Height="290px" TItem="VehicleData">
   <ListBoxFieldSettings Text="Text" Value="Id" />
</SfListBox>

@code {
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
}

```

Output will be shown as

![ListBox](./../images/scroller.png)