---
layout: post
title: Selection styling with CSS in Blazor TreeGrid | Syncfusion
description: Learn how to style row and cell selection in Syncfusion Blazor TreeGrid using CSS, with tips on isolation and selector specificity.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Selection customization in Syncfusion Blazor TreeGrid

The appearance of selection elements in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid can be customized using CSS. Styling options are available for:

- **Row selection background:** Highlights the entire row when selected.
- **Cell selection background:** Highlights individual cells when selected.

## Customize row selection background

The **.e-selectionbackground** class styles the background of selected rows in the TreeGrid. Use CSS to modify its appearance:

```css
.e-treegrid td.e-selectionbackground {
    background-color: #00b7ea;
}
```

Properties such as **background-color**, **color**, and **font-weight** can be adjusted to match the TreeGrid's design.

![Row selection](../images/style-and-appearance/row-selection.webp)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
<SfTreeGrid DataSource="@TreeGridData" IdMapping="ID" ParentIdMapping="ParentID" AllowSelection=true Height="440" TreeColumnIndex="1" AllowPaging="true">
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
    .e-treegrid td.e-selectionbackground {
        background-color: #00b7ea;
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

{% highlight c# tabtitle="ShipmentData.cs" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrxDphrTkisQobX?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Customize cell selection background

The **.e-cellselectionbackground** class styles the background of selected cells in the TreeGrid. Apply CSS to customize its appearance:

```css
.e-treegrid td.e-cellselectionbackground {
    background-color: #00b7ea;
}
```

Modify visual properties to align with the overall layout and improve clarity.

![Cell selection](../images/style-and-appearance/cell-selection.webp)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
<SfTreeGrid DataSource="@TreeGridData" IdMapping="ID" ParentIdMapping="ParentID" AllowSelection=true Height="440" TreeColumnIndex="1" AllowPaging="true">
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
    .e-treegrid td.e-cellselectionbackground {
    background-color: #00b7ea;
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

{% highlight c# tabtitle="ShipmentData.cs" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLxXzVVTuylwmnU?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}