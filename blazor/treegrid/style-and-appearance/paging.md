---
layout: post
title: Pager styling and customization in Blazor TreeGrid | Syncfusion
description: Learn how to style the Syncfusion Blazor TreeGrid pager using CSS—customize container, buttons, numeric items, and page indicator.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Paging customization in Syncfusion Blazor TreeGrid

The appearance of paging elements in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid can be customized using CSS. Styling options are available for different parts of the pager interface:

- **Root container:** The outermost wrapper that holds all pager content.
- **Pager container:** The inner layout that positions the controls.
- **Navigation buttons:** Commands for first, previous, next, and last page navigation.
- **Numeric page indicators:** Indicators that jump directly to specific pages.
- **Current page indicator:** The highlight that marks the active numeric page button.

## Customize the pager root element

The **.e-gridpager** class styles the pager root element in the Blazor TreeGrid. Use CSS to adjust its appearance:

```css
.e-treegrid .e-gridpager {
    font-family: cursive;
    background-color: #deecf9;
}
```

Properties like **font-family**, **background-color**, and spacing-related styles can be changed to fit the TreeGrid layout design.

![Pager root element](../images/style-and-appearance/treegrid-pager-root-element.webp)

## Customize the pager container element

The **.e-pagercontainer** class styles the pager container in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid. Apply CSS to modify its look:

```css
.e-treegrid .e-pagercontainer {
    border: 2px solid #00b5ff;
    font-family: cursive;
}
```

Properties such as **font-family**, **background-color**, and spacing-related styles can be adjusted to align with the TreeGrid design.

![Pager container element](../images/style-and-appearance/treegrid-pager-container-element.webp)

## Customize the pager navigation elements

The **.e-prevpagedisabled**, **.e-prevpage**, **.e-nextpage**, **.e-nextpagedisabled**, **.e-lastpagedisabled**, **.e-lastpage**, **.e-firstpage**, and **.e-firstpagedisabled** classes define the appearance of the pager navigation buttons in the Blazor TreeGrid. Apply CSS to customize their styling:

```css
.e-treegrid .e-gridpager .e-prevpagedisabled,
.e-treegrid .e-gridpager .e-prevpage,
.e-treegrid .e-gridpager .e-nextpage,
.e-treegrid .e-gridpager .e-nextpagedisabled,
.e-treegrid .e-gridpager .e-lastpagedisabled,
.e-treegrid .e-gridpager .e-lastpage,
.e-treegrid .e-gridpager .e-firstpage,
.e-treegrid .e-gridpager .e-firstpagedisabled {
    background-color: #deecf9;
}
```

Adjust properties like **background-color** to match the design, while keeping clear focus styles for accessibility.

![Pager navigation elements](../images/style-and-appearance/treegrid-pager-navigation-element.webp)

## Customize the pager numeric button elements

The **.e-numericitem** class styles the numeric page buttons in the Blazor TreeGrid. Apply CSS to change their appearance:

```css
.e-treegrid .e-gridpager .e-numericitem {
    background-color: #5290cb;
    color: #ffffff;
    cursor: pointer;
}

.e-treegrid .e-gridpager .e-numericitem:hover {
    background-color: white;
    color: #007bff;
}
```

Modify properties such as **background-color**, **color**, and **hover** effects to improve clarity and interaction.

![Pager numeric button elements](../images/style-and-appearance/pager-page-numeric-link-elements.webp)

## Customize the current page numeric element

The **.e-currentitem** class styles the current page indicator in the Blazor TreeGrid pager. Use CSS to adjust it:

```css
.e-treegrid .e-gridpager .e-currentitem {
    background-color: #0078d7;
    color: #fff;
}
```

Change properties like **background-color** and **color** to highlight the active page.

![Current page numeric element](../images/style-and-appearance/grid-pager-current-page-numeric-element.webp)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
<SfTreeGrid DataSource="@TreeGridData" IdMapping="ID" ParentIdMapping="ParentID" Height="440" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridPageSettings PageCount="5" PageSize="2" PageSizeMode="PageSizeMode.Root"></TreeGridPageSettings>
    <TreeGridEditSettings AllowEditing="true"></TreeGridEditSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="ShipID" HeaderText="Ship ID" Width="80" Visible="false" IsPrimaryKey="true" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Name" ClipMode="ClipMode.EllipsisWithTooltip" HeaderText="Orders" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="ShipmentCategory" HeaderText="Category" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Units" HeaderText="Units" Width="80" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="UnitPrice" ClipMode="ClipMode.EllipsisWithTooltip" HeaderText="Unit Price" Format="c2" Width="90" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="OrderDate" HeaderText="Ordered Date" ClipMode="ClipMode.EllipsisWithTooltip" Format="d" Type="ColumnType.Date" Width="120" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="ShippedDate" HeaderText="Shipped Date" ClipMode="ClipMode.EllipsisWithTooltip" Format="d" Type="ColumnType.Date" Width="120" TextAlign="TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

<style>
    .e-treegrid .e-gridpager .e-currentitem {
        background-color: #1114a7;
        color: #fff;
    }
</style>

@code {
    private List<ShipmentData> TreeGridData { get; set; } = new List<ShipmentData>();
    private List<string> PageSizes { get; set; } = new List<string>();
    protected override void OnInitialized()
    {
        TreeGridData = ShipmentData.GetData();
        PageSizes = new List<string>() { "2", "4", "5", "10", "15", "20", "All" };
    }
}

{% endhighlight %}

{% highlight c# tabtitle="TaskData.cs" %}

public class ShipmentData
{
    public int? ID { get; set; }
    public int? ShipID { get; set; }
    public string? Name { get; set; }
    public int? Units { get; set; }
    public string? Category { get; set; }
    public int? UnitPrice { get; set; }
    public int? Price { get; set; }
    public int? TotalPrice { get; set; } // Added for total price calculation (sum for parents, individual for items)
    public string? ShipmentCategory { get; set; }
    public DateTime? ShippedDate { get; set; } = null;
    public DateTime? OrderDate { get; set; } = null;
    public string? OrderReached { get; set; } = null;
    public int? ParentID { get; set; }
    private static void CalculateTotalPrices(List<ShipmentData> data)
    {
        // For items (non-parents), TotalPrice = Price
        // For parents, TotalPrice = sum of children's TotalPrice
        var parents = data.Where(d => d.ParentID == null).ToList();
        foreach (var parent in parents)
        {
            var children = data.Where(d => d.ParentID == parent.ID).ToList();
            parent.TotalPrice = children.Sum(c => c.Price ?? 0);
            // Recursively set for children if nested, but here it's flat tree
        }
        // Set for items
        foreach (var item in data.Where(d => d.ParentID != null))
        {
            item.TotalPrice = item.Price;
        }
    }
    public static List<ShipmentData> GetData()
    {
        var data = new List<ShipmentData>(capacity: 150);
        var rnd = new Random(42); // deterministic
        var baseOrderDate = new DateTime(2025, 1, 1);
        // pools for categories/items - standardized to Title Case
        var categories = new[]
        {
            ("Seafood", new[] { "Mackerel", "Herrings", "Tilapias", "White Shrimp", "Yellowfin Tuna" }),
            ("Dairy", new[] { "Fresh Cheese", "Blue Veined Cheese", "Butter", "Milk", "Yogurt" }),
            ("Edible", new[] { "Preserved Olives", "Sweet corn", "Pickles", "Tomato Puree", "Olive Oil" }),
            ("Crystals", new[] { "Lead glassware", "Pharmaceutical glass", "Glass beads", "Crystal vials", "Borosilicate glass" }),
            ("Fresh Vegetables", new[] { "Broccoli", "Spinach", "Carrots", "Lettuce", "Cabbage" }),
            ("Leafy Greens", new[] { "Kale", "Arugula", "Chard", "Collards", "Mustard Greens" }),
            ("Root Vegetables", new[] { "Beets", "Radish", "Parsnip", "Turnip", "Rutabaga" }),
            ("Paper", new[] { "Printer Paper", "Photo Paper", "Sticky Notes", "Card Stock", "Plotter Rolls" }),
            ("Consumables", new[] { "Ink Cartridges", "Toner", "Markers", "Glue Sticks", "Tape Rolls" }),
            ("Tools", new[] { "Staplers", "Hole Punch", "Cutters", "Rulers", "Scissors" }),
            ("Stationery", new[] { "Notebooks", "Pens", "Pencils", "Folders", "Envelopes" })
        };
        int id = 0;
        int shipSeed = 4500;
        for (int p = 1; p <= 10; p++)
        {
            int parentId = id++;
            data.Add(new ShipmentData
            {
                ID = parentId,
                Name = $"Order {p}",
                ParentID = null
            });
            for (int c = 0; c < 4; c++)
            {
                // pick a category and item name
                var (cat, items) = categories[(p + c) % categories.Length];
                var itemName = items[(p * 3 + c) % items.Length];
                // numbers
                int units = 20 + rnd.Next(11); // 20..30
                int unitPrice = 5 + rnd.Next(20); // 5..24
                int price = units * unitPrice;
                // dates
                var orderDate = baseOrderDate.AddDays(p * 7 + c * 3);
                var shipLag = 3 + rnd.Next(10); // 3..12 days
                var shippedDate = orderDate.AddDays(shipLag);
                // reached?
                var reached = shippedDate >= orderDate.AddDays(7) && rnd.Next(100) > 30 ? "Yes" : "No";
                data.Add(new ShipmentData
                {
                    ID = id,
                    ShipID = shipSeed + id,
                    Name = itemName,
                    Category = cat,
                    Units = units,
                    UnitPrice = unitPrice,
                    Price = price,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
                    ShipmentCategory = cat,
                    OrderReached = reached,
                    ParentID = parentId
                });
                id++;
            }
        }
        CalculateTotalPrices(data);
        return data;
    }
}

{% endhighlight %}
{% endtabs %}
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtrdjpBVzbiapgnK?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}