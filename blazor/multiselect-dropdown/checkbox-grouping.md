---
layout: post
title: Checkbox grouping in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about checkbox grouping in Syncfusion Blazor MultiSelect component and much more.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Checkbox Grouping in Blazor MultiSelect Component

You can arrange the datasource items by grouping them with checkbox mode in MultiSelect. Clicking the checkbox in group will select all the items grouped under it. Click the MultiSelect element and then type the character in the search box. It will display the filtered list items based on the typed characters and then select the multiple values through the checkbox.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TValue="string[]" AllowFiltering="true" TItem="Vegetables" Mode="@VisualMode.CheckBox" Width="250px" Placeholder="Select a vegetable" DataSource="@VegetablesList" ShowSelectAll="@ShowSelectAllCheckBox"
               EnableSelectionOrder="@EnableSelectionOrders" FilterBarPlaceholder="Search Vegetables" EnableGroupCheckBox="@EnableCheckBox" PopupHeight="350px">
    <MultiSelectFieldSettings GroupBy="Category" Value="Vegetable"></MultiSelectFieldSettings>
</SfMultiSelect>

@code{
    public bool ShowSelectAllCheckBox { get; set; } = true;
    public bool EnableSelectionOrders { get; set; } = false;
    public bool EnableCheckBox { get; set; } = true;
    public class Vegetables
    {
        public string Vegetable { get; set; }
        public string Category { get; set; }
        public string ID { get; set; }
    }
    List<Vegetables> VegetablesList = new List<Vegetables>()
    {
        new Vegetables() { Vegetable = "Cabbage", Category = "Leafy and Salad", ID = "item1" },
        new Vegetables() { Vegetable = "Chickpea", Category = "Beans", ID = "item2" },
        new Vegetables() { Vegetable = "Garlic", Category = "Bulb and Stem", ID = "item3" },
        new Vegetables() { Vegetable = "Green bean", Category = "Beans", ID = "item4" },
        new Vegetables() { Vegetable = "Horse gram", Category = "Beans", ID = "item5" },
        new Vegetables() { Vegetable = "Nopal", Category = "Bulb and Stem", ID = "item6" },
        new Vegetables() { Vegetable = "Onion", Category = "Bulb and Stem", ID = "item7" },
        new Vegetables() { Vegetable = "Pumpkins", Category = "Leafy and Salad", ID = "item8" },
        new Vegetables() { Vegetable = "Spinach", Category = "Leafy and Salad", ID = "item9" },
        new Vegetables() { Vegetable = "Wheat grass", Category = "Leafy and Salad", ID = "item10" },
        new Vegetables() { Vegetable = "Yarrow", Category = "Leafy and Salad", ID = "item11" },
    };
}

```

![Blazor MultiSelect DropDown with Checkbox Grouping](./images/blazor-multiselect-dropdown-checkbox-grouping.png)

## Properties

### EnableGroupCheckBox 

Specifies a Boolean value that enables checkbox in the group header in checkbox mode. This property allows you to render checkbox for group headers and to select all the grouped items at once.

Default value of [EnableGroupCheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_EnableGroupCheckBox) is `false`.

[Click to refer the code for EnableGroupCheckBox](https://blazor.syncfusion.com/documentation/multiselect-dropdown/checkbox-grouping)

### EnableSelectionOrder

Reorder the selected items in popup visibility state.

Default value of [EnableSelectionOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_EnableSelectionOrder) is `true`.

[Click to refer the code for EnableSelectionOrder](https://blazor.syncfusion.com/documentation/multiselect-dropdown/checkbox-grouping)