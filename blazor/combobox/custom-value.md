---
layout: post
title: Adding Custom Value to the Blazor ComboBox Popup | Syncfusion
description: Learn how to add custom values to the Syncfusion Blazor ComboBox component using the AllowCustom property and AddItemsAsync method.
platform: Blazor
control: ComboBox
documentation: ug
---

# Add a Custom Value to Blazor ComboBox Popup

## What is a Custom Value?

A custom value is a user-entered entry that is not present in the ComboBox's predefined data source. This capability is useful when the available options do not cover all possible user inputs. For example, in a product category dropdown, a new category that is not yet listed can be added.

## Understanding the AllowCustom Property

The [AllowCustom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html#Syncfusion_Blazor_DropDowns_SfComboBox_2_AllowCustom) property in the Blazor ComboBox component determines whether users can enter values that are not present in the data source.

| Property Value | Behavior |
|----------------|----------|
| `true` (default) | Users can type and submit values not present in the ComboBox popup. When the typed text does not match any existing items, the `CustomValueSpecifier` event is triggered, allowing the custom value to be processed. |
| `false` | Users can only select from the available options in the data source. |

When `AllowFiltering` is enabled, user input continues to filter existing items; a custom value is processed when the entered text does not match any filtered results.
## Adding Custom Values Using the AddItemsAsync Method

The [AddItemsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_AddItemsAsync_System_Collections_Generic_IEnumerable__0__System_Nullable_System_Int32__) method, which is available on dropdown components such as `SfDropDownList` and `SfComboBox`, allows dynamically adding new items to the ComboBox data source at runtime. This method is particularly useful when handling the `CustomValueSpecifier` event to persist user-entered custom values.

### Method Signature

```csharp
public async Task AddItemsAsync(IEnumerable<TItem> items, int? index = null)
```

### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `items` | `IEnumerable<TItem>` | The collection of items to add to the data source. |
| `index` | `int?` (optional) | The position at which to insert the new items. If not specified, items are added at the end of the list. |

## Product Category Selection with Custom Entry

The following example demonstrates a scenario where users can select an existing product category or add a new one.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox @ref="@ComboObj" TValue="string" TItem="ProductCategory" DataSource="@Categories" Placeholder="Select or add a category" Width="300px" AllowCustom="true" AllowFiltering="true">
    <ComboBoxFieldSettings Text="CategoryName" Value="CategoryId"></ComboBoxFieldSettings>
    <ComboBoxEvents TValue="string" TItem="ProductCategory" CustomValueSpecifier="@OnCustomValueSpecifier"></ComboBoxEvents>
</SfComboBox>

@code {
    private SfComboBox<string, ProductCategory> ComboObj;

    public class ProductCategory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    private List<ProductCategory> Categories = new List<ProductCategory>
    {
        new ProductCategory { CategoryId = "CAT001", CategoryName = "Electronics" },
        new ProductCategory { CategoryId = "CAT002", CategoryName = "Clothing" },
        new ProductCategory { CategoryId = "CAT003", CategoryName = "Home & Garden" },
        new ProductCategory { CategoryId = "CAT004", CategoryName = "Sports & Outdoors" },
        new ProductCategory { CategoryId = "CAT005", CategoryName = "Books & Stationery" }
    };

    private async Task OnCustomValueSpecifier(CustomValueSpecifierEventArgs<ProductCategory> args)
    {
        // Create a new category with a unique ID based on the entered text
        var newCategory = new ProductCategory
        {
            CategoryId = $"CAT{DateTime.Now.Ticks}",
            CategoryName = args.Text
        };

        // Add the new category to the ComboBox using AddItemsAsync
        await ComboObj.AddItemsAsync(new List<ProductCategory> { newCategory });
    }
}
```

### How It Works

1. **User types a value**: When a user types text that does not match any existing category, the `CustomValueSpecifier` event is triggered.
2. **Event handler creates new item**: The `OnCustomValueSpecifier` method creates a new `ProductCategory` object with the entered text.
3. **AddItemsAsync adds the item**: The new category is added to the ComboBox data source dynamically.
    By default, `AddItemsAsync` inserts new items at the end of the data source (unless an `index` is specified). It does not automatically select the newly added item.
4. **Item becomes selectable**: The newly added item appears in the dropdown and can be selected in future interactions. To programmatically select the new item, set the ComboBox's value to the new item's value after calling `AddItemsAsync`.

N> Custom values can also be committed using the keyboard by pressing **Enter** when the desired text is typed in the input field.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBnjMBqrTWEjiBq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with custom value](./images/blazor-combobox-custom-value.gif)" %}
