---
layout: post
title: AllowFiltering in MultiSelect Dropdown
description: Learn how to enable and configure filtering in Syncfusion Blazor MultiSelect component for search-based item selection.
platform: Blazor
control: MultiSelect
documentation: ug
---

# AllowFiltering in MultiSelect Dropdown

The [**AllowFiltering**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_AllowFiltering) feature in the Syncfusion Blazor MultiSelect component enables real-time search capability within the dropdown popup. Users can filter the list of items dynamically based on their input, supporting both simple text searches and complex filtered queries.

## Getting Started with AllowFiltering

The [**AllowFiltering**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_AllowFiltering) property enables or disables the search functionality in the MultiSelect component. When enabled, users can type in the dropdown to filter items that match the search criteria.

### Basic Usage

To enable filtering, set the `AllowFiltering` property to `true`. By default, this property is set to `false`.

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" DataSource="@countries" Placeholder="Select a country">
    <MultiSelectFieldSettings Text="Name" Value="Code"></MultiSelectFieldSettings>
</SfMultiSelect>

@code {
    private string[] countries = new string[] { "Apple", "Banana", "Cherry", "Date", "Grape", "Orange" };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLntoDxfhqAYVys?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

In this example, the MultiSelect component displays a list of countries with filtering enabled. When the user types in the search box, the list filters in real-time to show only matching items.

> **Note:** The filtering feature works with both primitive data types (strings, integers) and complex object types when configured with [FilterType](#configuring-filter-types).

## Filtering in Different Visual Modes

The behavior of the filtering feature varies depending on the [VisualMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.VisualMode.html) property setting.

### CheckBox Mode

In **CheckBox** mode, the filter input appears as a dedicated search bar at the top of the popup dropdown. This provides a clear separation between the search functionality and the selection interface.

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" Mode="VisualMode.CheckBox" DataSource="@fruits" Placeholder="Search fruits">
</SfMultiSelect>

@code {
    private string[] fruits = new string[] { "Apple", "Banana", "Cherry", "Mango", "Orange", "Papaya", "Peach" };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBnZyNxJUCQLNrs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The filter bar includes the following features when used in CheckBox mode:

* **Placeholder Text**: Customizable using the [FilterBarPlaceholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_FilterBarPlaceholder) property
* **Clear Button**: Automatically appears when text is entered in the filter input
* **Mobile Back Button**: Displayed on mobile devices when [`PopupDisplayMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_PopupDisplayMode) is set to `FullScreen`

### Box, Default, and Delimiter Modes

In **Box**, **Default**, and **Delimiter** modes, the filter functionality integrates directly into the main search input where the selected items are displayed as chips or delimiter-separated values.

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" Mode="VisualMode.Box" DataSource="@colors" Placeholder="Select colors">
</SfMultiSelect>

@code {
    private string[] colors = new string[] { "Red", "Green", "Blue", "Yellow", "Orange", "Purple" };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVxjyDnfAJHWEyb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> **Note:** In these modes, the user must manually clear the input to see the unfiltered list again, as there is no dedicated filter UI element.

## Configuring Filter Types

The [FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_FilterType) property controls how the filtering algorithm matches text. The available filter types are:

| FilterType | Description | Example Match |
|-----------|-------------|---------------|
| [**StartsWith**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_StartsWith) | Matches items that begin with the search text | "App" matches "Apple" |
| [**Contains**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_EndsWith) | Matches items that contain the search text anywhere | "pp" matches "Apple" |
| [**EndsWith**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_Contains) | Matches items that end with the search text | "ple" matches "Apple" |

### Filter Type Example

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" FilterType="FilterType.Contains" DataSource="@vegetables" Placeholder="Contains...">
</SfMultiSelect>

@code {
    private string[] vegetables = new string[] { "Carrot", "Cabbage", "Broccoli", "Spinach", "Potato" };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLxDIDnTqlYHKSk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The default filter type is **StartsWith**, which provides an autocomplete-style filtering experience. The **Contains** filter type is most commonly used for flexible search scenarios.

## Case Sensitivity and Accent Handling

The MultiSelect filtering feature supports case-insensitive and accent-insensitive filtering through dedicated properties.

### Case-Insensitive Filtering

The [IgnoreCase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_IgnoreCase) property controls whether the filter operation is case-sensitive.

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" IgnoreCase="true" DataSource="@countries" Placeholder="Search (case-insensitive)">
</SfMultiSelect>

@code {
    private string[] countries = new string[] { "Apple", "Banana", "Cherry", "America", "Australia" };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBnXSZdJzWeXYri?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

With `IgnoreCase="true"`, typing "apple" matches "Apple", "APPLE", and "apple". When set to `false`, only exact case matches are returned.

### Accent-Insensitive Filtering

The [IgnoreAccent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_IgnoreAccent) property enables filtering that ignores diacritical marks (accents).

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" IgnoreAccent="true" DataSource="@names" Placeholder="Search names">
</SfMultiSelect>

@code {
    private string[] names = new string[] { "Jose", "José", "Mänge", "Mange", "Zoë", "Zoe" };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVdDyZHJTptxWPD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

With `IgnoreAccent="true"`, typing "Jose" matches both "Jose" and "José". This is particularly useful when working with international data or names with special characters.

## Debounce Delay Configuration

The [DebounceDelay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_DebounceDelay) property specifies the delay in milliseconds before the filter executes after the user stops typing. This prevents excessive filtering operations during rapid typing.

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" DebounceDelay="500" DataSource="@cities" Placeholder="Search cities (500ms delay)">
</SfMultiSelect>

@code {
    private string[] cities = new string[] { "New York", "New Delhi", "Newcastle", "Newton", "New Orleans" };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtLHjoXdzpmqdWon?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The default debounce delay is **300 milliseconds**. Setting this value to **0** causes filtering to occur on every keystroke, which may impact performance with large datasets or remote data sources.

> **Note:** The `DebounceDelay` property only takes effect when the `AllowFiltering` property is set to `true`.

## Filtering with Complex Data

When working with complex object types, you must configure which fields to use for filtering and display using the [MultiSelectFieldSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#properties) component.

### Complex Data Example

```cshtml
<SfMultiSelect TItem="Employee" TValue="string[]" AllowFiltering="true" DataSource="@employees" Placeholder="Select employee">
    <MultiSelectFieldSettings Text="Name" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

@code {
    private List<Employee> employees = new List<Employee>
    {
        new Employee { ID = "1", Name = "John Smith", Department = "Engineering" },
        new Employee { ID = "2", Name = "James Wilson", Department = "Marketing" },
        new Employee { ID = "3", Name = "Mary Johnson", Department = "Engineering" },
        new Employee { ID = "4", Name = "Michael Brown", Department = "Sales" },
        new Employee { ID = "5", Name = "Jennifer Davis", Department = "HR" }
    };

    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjrxtSXdfpYSzibJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

In this example, filtering occurs based on the `Name` property as configured in [`MultiSelectFieldSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#properties). When the user types "John", the list filters to show only employees with "John" in their name.

## Virtualization with Filtering

The filtering feature works seamlessly with [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_EnableVirtualization) for large datasets. When both features are enabled, only the visible items are rendered to the DOM, ensuring optimal performance.

### Virtualized Filtering Setup

```cshtml
<SfMultiSelect TItem="Product" TValue="string[]" AllowFiltering="true" EnableVirtualization="true" DataSource="@products" Placeholder="Search products">
    <MultiSelectFieldSettings Text="ProductName" Value="ProductID"></MultiSelectFieldSettings>
</SfMultiSelect>

@code {
    private List<Product> products;

    protected override void OnInitialized()
    {
        products = GenerateProducts(10000);
    }

    private List<Product> GenerateProducts(int count)
    {
        var productList = new List<Product>();
        for (int i = 1; i <= count; i++)
        {
            productList.Add(new Product 
            { 
                ProductID = i.ToString(), 
                ProductName = $"Product {i}" 
            });
        }
        return productList;
    }

public class Product
{
    public string ProductID { get; set; }
    public string ProductName { get; set; }
}
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVRXoZHzyVvCEeT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

When virtualization is enabled with filtering:

1. The component clones the existing query and adds filter conditions
2. Virtual indices are maintained to track visible items
3. Skeleton loaders appear while filtered data loads
4. The `GeneratedData` dictionary caches results to avoid re-querying

> **Note:** The `TotalCount` value adjusts during filtering to reflect only the filtered result count rather than the total dataset size.

## Filtering with HideSelectedItem

The [HideSelectedItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_HideSelectedItem) property removes already-selected items from the filtered list. This behavior differs between modes.

### HideSelectedItem in Action

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" HideSelectedItem="true" DataSource="@languages" Placeholder="Select language">
</SfMultiSelect>

@code {
    private string[] languages = new string[] { "CSharp", "JavaScript", "Python", "Java", "TypeScript", "Go" };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhHXeXdfyorhvoq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

In **Box**, **Default**, and **Delimiter** modes, selected items are hidden from the dropdown list when filtering. In **CheckBox** mode, selected items remain visible with checkmarks.

> **Note:** The [`HideSelectedItem`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_HideSelectedItem) property is ignored in CheckBox mode, where selected items are always displayed with their selection state.

## Custom Query Filtering

You can provide a custom base query that filtering will be applied on top of. The component merges the user's query with filter conditions while preserving the original query settings.

### Query with Filtering

```cshtml
<SfMultiSelect TItem="Order" TValue="string[]" AllowFiltering="true" Query="@customQuery" DataSource="@orders" Placeholder="Search orders">
    <MultiSelectFieldSettings Text="OrderName" Value="OrderID"></MultiSelectFieldSettings>
</SfMultiSelect>

@code {
    private Query customQuery = new Query().Where("Status", "equal", "Active").Take(100);
    
    private List<Order> orders = new List<Order>
    {
        new Order { OrderID = "1", OrderName = "Order A", Status = "Active" },
        new Order { OrderID = "2", OrderName = "Order B", Status = "Inactive" },
        new Order { OrderID = "3", OrderName = "Order C", Status = "Active" }
    };

    public class Order
    {
        public string OrderID { get; set; }
        public string OrderName { get; set; }
        public string Status { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBxNyNdTeGhgMSc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

When filtering is applied with a custom query:

1. The base query is cloned to preserve original settings
2. Filter conditions are added without modifying the original query
3. The `Take()` method from the user's query is preserved
4. Both conditions are applied together in the final query

## Filtering Events

The MultiSelect component provides several events for handling filtering operations at different stages.

### Filtering Event

The [Filtering](https://blazor.syncfusion.com/documentation/multiselect-dropdown/events#filtering-event) event fires before the filtering action executes, allowing you to modify or cancel the default filtering behavior.

```cshtml
<SfMultiSelect @ref="MultiSelectRef" TItem="string" TValue="string[]" AllowFiltering="true" DataSource="@items" Filtering="@OnFiltering" Placeholder="Search with custom logic">
</SfMultiSelect>

@code {
    private string[] items = new string[] { "Apple", "Apricot", "Banana", "Cherry", "Avocado" };
    private SfMultiSelect<string[], string> MultiSelectRef;
    private async void OnFiltering(Syncfusion.Blazor.DropDowns.FilteringEventArgs args)
    {
        // Prevent default filtering and apply custom logic
        args.PreventDefaultAction = true;
        // Custom filter: match items that contain the typed text OR start with "A"
        var filtered = items.Where(x => x.Contains(args.Text) || x.StartsWith("A")).ToList();
        await MultiSelectRef.FilterAsync(filtered);
    }
}
```
{% previewsample "{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVRXoZHzyVvCEeT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}" %}

## Custom Value Creation with Filtering

When [AllowCustomValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_AllowCustomValue) is enabled, users can add custom values that do not match any existing items. This is particularly useful when no filter matches are found.

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" AllowCustomValue="true" DataSource="@colors" Placeholder="Select or add color">
</SfMultiSelect>

@code {
    private string[] colors = new string[] { "Red", "Green", "Blue", "Yellow", "Orange" };
}
```

With both properties enabled, users can type a custom value (such as "Purple") that does not exist in the list and add it as a new selection.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVHjejdJHmrOLoY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## No Records Found Behavior

When filtering produces no matching items, the MultiSelect component displays a "No Records" message by default. You can customize this using the `NoRecordsTemplate`.

### Custom No Records Template

```cshtml
<SfMultiSelect TItem="string" TValue="string[]" AllowFiltering="true" DataSource="@countries" Placeholder="Search countries">
    <NoRecordsTemplate>
        <div class="no-records">
            <span>No matching records found</span>
            <button @onclick="ClearFilter">Clear Filter</button>
        </div>
    </NoRecordsTemplate>
</SfMultiSelect>

@code {
    private string[] countries = new string[] { "USA", "UK", "India", "Canada", "Australia" };
    
    private async Task ClearFilter()
    {
        // Clear the filter and show all items
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVHtSXxznverDnx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Keyboard Navigation During Filtering

The filtering feature supports comprehensive keyboard navigation for accessibility.

| Key | Behavior During Filtering |
|-----|--------------------------|
| **Typing (a-z, 0-9)** | Adds character to filter input and triggers search |
| **Backspace** | Removes character from filter and updates results |
| **ArrowDown** | Moves focus to next visible item in filtered list |
| **ArrowUp** | Moves focus to previous visible item in filtered list |
| **Enter/Space** | Selects the focused filtered item |
| **Tab** | Moves focus out of filter input and closes popup |
| **Escape** | Clears filter input and closes popup |