---
layout: post
title: Sorting in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Sorting functionality in Syncfusion Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Sorting in Blazor MultiColumn ComboBox Component

The MultiColumn ComboBox component provides built-in support for sorting data-bound columns in ascending or descending order. To enable sorting in the MultiColumn ComboBox, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**.

To sort a particular column in the MultiColumn ComboBox, click on its column header. Each time you click the header, the order of the column will switch between **Ascending** and **Descending**.

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

The MultiColumn ComboBox component allows to sort more than one column at a time using multi-column sorting. To enable multi-column sorting in the MultiColumn ComboBox, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**, and set the [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) property to **true** which enable the user to sort multiple columns by holding the **CTRL** key and click on the column headers. This feature is useful when you want to sort your data based on multiple criteria to analyze it in various ways.

> * The `AllowSorting` must be **true** while enabling multi-column sort.
> * Set `AllowMultiSorting` property as **false** to disable multi-column sorting.

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