---
layout: post
title: Sorting in Blazor Dropdown Tree Component | Syncfusion
description: Checkout and learn here all about Sorting in Syncfusion Blazor Dropdown Tree component and much more.
platform: Blazor
control: Dropdown Tree
documentation: ug
---

# Sorting in Blazor Dropdown Tree Component

The [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_SortOrder) property controls the sorting behavior of the Dropdown Tree nodes in the Blazor Dropdown Tree component. This property allows rendering nodes in `Ascending` or `Descending` order. The default value for the `SortOrder` property is `None`, indicating no specific sorting is applied.

The available `SortOrder` options are:

*   **Ascending**: Specifies that the Dropdown Tree nodes are rendered in ascending alphabetical order.
*   **Descending**: Specifies that the Dropdown Tree nodes are rendered in descending alphabetical order.
*   **None**: Specifies that no specific sorting is applied, and the Dropdown Tree nodes maintain their original order from the data source.

The following example demonstrates how to dynamically update the [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_SortOrder) property through button clicks.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="Ascending"> Ascending Order</SfButton>
<SfButton OnClick="Descending">Descending Order</SfButton>
<div>
    <SfDropDownTree TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px" SortOrder="sortOrder">
        <DropDownTreeField TItem="EmployeeData" DataSource="Data" ID="Id" Text="Name" HasChildren="HasChild" ParentID="PId"></DropDownTreeField>
    </SfDropDownTree>
</div>
@code {
    public SortOrder sortOrder;
    List<EmployeeData> Data = new List<EmployeeData>
    {
        new EmployeeData() { Id = "1", Name = "Steven Buchanan", Job = "General Manager", HasChild = true, Expanded = true },
        new EmployeeData() { Id = "2", PId = "1", Name = "Laura Callahan", Job = "Product Manager", HasChild = true },
        new EmployeeData() { Id = "3", PId = "2", Name = "Andrew Fuller", Job = "Team Lead", HasChild = true },
        new EmployeeData() { Id = "4", PId = "3", Name = "Anne Dodsworth", Job = "Developer" },
        new EmployeeData() { Id = "10", PId = "3", Name = "Lilly", Job = "Developer" },
        new EmployeeData() { Id = "5", PId = "1", Name = "Nancy Davolio", Job = "Product Manager", HasChild = true },
        new EmployeeData() { Id = "6", PId = "5", Name = "Michael Suyama", Job = "Team Lead", HasChild = true },
        new EmployeeData() { Id = "7", PId = "6", Name = "Robert King", Job = "Developer" },
        new EmployeeData() { Id = "11", PId = "6", Name = "Mary", Job = "Developer" },
        new EmployeeData() { Id = "9", PId = "1", Name = "Janet Leverling", Job = "HR"}
    };
    public void Ascending()
    {
        sortOrder = SortOrder.Ascending;
    }
    public void Descending()
    {
        sortOrder = SortOrder.Descending;
    }
    class EmployeeData
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Job { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public string? PId { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVyXOVRJCfrEqly?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Blazor Dropdown Tree with sortOrder descending.](./images/blazor-dropdowntree-component-sort-order.png)