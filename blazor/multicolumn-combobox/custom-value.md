---
layout: post
title: Adding Custom value to the Blazor MultiColumn ComboBox | Syncfusion
description: Checkout and learn here all about adding custom value in Syncfusion Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Adding Custom Value to Blazor MultiColumn ComboBox Component

You can include custom values in the MultiColumn ComboBox component. If the entered character(s) are not found in the list, a button will appear in the popup menu. Clicking this button will add the custom character(s) to the existing list as a new item. By default, the [AllowCustom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_AllowCustom) property is set to `true`.

**[Index.razor]**

{% tabs %}
{% highlight razor %}


@using Syncfusion.Blazor.MultiColumnComboBox

<SfMultiColumnComboBox @bind-Value="@Value" DataSource="@Products" AllowCustom=true PopupWidth="600px" ValueField="Name" TextField="Name" Placeholder="Select any product"></SfMultiColumnComboBox>

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
        };
        return base.OnInitializedAsync();
    }
}
{% endhighlight razor %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrzNaLUIDqNTtMS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with custom value](./images/blazor-multicolumn-custom-value.gif)" %}