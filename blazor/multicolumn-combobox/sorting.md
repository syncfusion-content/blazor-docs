---
layout: post
title: Sorting in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Sorting functionality in Syncfusion Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Sorting in Blazor MultiColumn ComboBox Component

The Blazor MultiColumn ComboBox provides built-in support for sorting data-bound columns in ascending or descending order. To enable sorting, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_AllowSorting) property to `true`.

To sort a column, click its header. Each click toggles the sort direction between ascending and descending. Sort indicators on the headers reflect the current sort direction. In remote binding scenarios, sorting can be applied on the server via DataManager queries.

{% tabs %}
{% highlight razor %}

<SfMultiColumnComboBox @bind-Value="@Value" Width="500px" DataSource="@Products" ValueField="Name" TextField="Name" AllowSorting="true">
    <MultiColumnComboboxColumns>
        <MultiColumnComboboxColumn Field="Name"></MultiColumnComboboxColumn>
        <MultiColumnComboboxColumn Field="Price"></MultiColumnComboboxColumn>
        <MultiColumnComboboxColumn Field="Availability"></MultiColumnComboboxColumn>
    </MultiColumnComboboxColumns>
</SfMultiColumnComboBox>

@code {
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Availability { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
    }
    private List<Product> Products = new List<Product>();
    private string Value { get; set; } = "Smartphone";
    protected override Task OnInitializedAsync()
    {
        Products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 999.99m, Availability = "In Stock", Category = "Electronics", Rating = 4.5 },
            new Product { Name = "Smartphone", Price = 599.99m, Availability = "Out of Stock", Category = "Electronics", Rating = 4.3 },
            new Product { Name = "Tablet", Price = 299.99m, Availability = "In Stock", Category = "Electronics", Rating = 4.2 },
            new Product { Name = "Headphones", Price = 49.99m, Availability = "In Stock", Category = "Accessories", Rating = 4.0 },
            new Product { Name = "Smartwatch", Price = 199.99m, Availability = "Limited Stock", Category = "Wearables", Rating = 4.4 },
            new Product { Name = "Monitor", Price = 129.99m, Availability = "In Stock", Category = "Electronics", Rating = 4.6 }
        };
        return base.OnInitializedAsync();
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhpNYhTivWzEcZA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Multi-column sorting

The Blazor MultiColumn ComboBox allows sorting more than one column at a time. Enable multi-column sorting by setting both [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_AllowSorting) and [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_AllowMultiSorting) to `true`. Then hold Ctrl and click additional column headers to add or modify sort levels.

> - `AllowSorting` must be `true` to enable multi-column sorting.
> - Set `AllowMultiSorting` to `false` to disable multi-column sorting.

{% tabs %}
{% highlight razor %}

<SfMultiColumnComboBox @bind-Value="@Value" Width="500px" DataSource="@Products" ValueField="Name" TextField="Name" AllowSorting="true" AllowMultiSorting="true">
    <MultiColumnComboboxColumns>
        <MultiColumnComboboxColumn Field="Name"></MultiColumnComboboxColumn>
        <MultiColumnComboboxColumn Field="Price"></MultiColumnComboboxColumn>
        <MultiColumnComboboxColumn Field="Availability"></MultiColumnComboboxColumn>
    </MultiColumnComboboxColumns>
</SfMultiColumnComboBox>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrJZEBzBCeCcPgD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}