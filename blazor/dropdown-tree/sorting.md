---
layout: post
title: Sorting in Blazor Dropdown Tree Component | Syncfusion
description: Checkout and learn here all about Sorting in Syncfusion Blazor Dropdown Tree component and much more.
platform: Blazor
control: Dropdown Tree
documentation: ug
---

# Sorting in Blazor Dropdown Tree Component

The [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_SortOrder) property is used to sort the Dropdown Tree nodes in `Ascending` or `Descending` order in the Blazor Dropdown Tree component. The default value of [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_SortOrder) property is `None`.

* **Ascending** - specifies the Dropdown Tree nodes are sorted in the ascending order.
* **Descending** - specifies the Dropdown Tree nodes are sorted in the descending order.
* **None** - specifies the Dropdown Tree nodes are not sorted.

In the following example, the [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_SortOrder) property is dynamically updated on the button click.

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

![Blazor Dropdown Tree with sortOrder descending.](./images/blazor-dropdowntree-component-sort-order.png)