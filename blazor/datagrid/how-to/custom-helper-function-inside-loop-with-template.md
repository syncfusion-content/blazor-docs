---
layout: post
title: Use custom helper inside the loop with templates in Blazor DataGrid | Syncfusion
description: Learn here all about place cancel icon in search bar in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# Use custom helper inside the loop with templates

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to use custom helpers inside the loop with [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?#Syncfusion_Blazor_Grids_GridColumn_Template) property of a column. This feature enables you to create complex templates that can incorporate additional helper functions.

The **customer rating** column includes a custom template defined using `Template`. Inside this template, iterates through the item array and generates `<span>` tag, displayed as stars using the CSS below:

```css
.e-grid .rating .star:before {
    content: '★';
}

.e-grid .rating .star {
    font-size: 132%;
    color: lightgrey;
}
```

The class is dynamically assigned  based on the result of the `isRatingGreater` method, highlighting the star using the CSS below:

```css
.e-grid .rating .star.checked {
    color: #ffa600;
}
```

This is demonstrated in the following example.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="300px">
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn HeaderText="Customer Rating" Width="120">
            <Template>
                @{
                    var rating = (context as Order)?.Rating ?? 0;
                }
                <div class="rate">
                    <div class="rating">
                        @foreach (var i in Enumerable.Range(1, 5))
                        {
                            <span class="star @(IsRatingGreater(rating, i) ? "checked" : "")"></span>
                        }
                    </div>
                </div>
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .rating .star:before {
        content: '★';
    }

    .e-grid .rating .star {
        font-size: 132%;
        color: lightgrey;
    }

    .e-grid .rating .star.checked {
        color: #ffa600;
    }
</style>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
         Orders = Order.GetAllRecords();
    }

    private bool IsRatingGreater(int dataRating, int comparisonValue)
    {
        return dataRating >= comparisonValue;
    }
}

{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

public class Order
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int Rating { get; set; }

    public static List<Order> GetAllRecords()
    {
        return new List<Order>
        {
            new Order { OrderID = 1001, CustomerID = "ALFKI", Rating = 3 },
            new Order { OrderID = 1002, CustomerID = "ANATR", Rating = 5 },
            new Order { OrderID = 1003, CustomerID = "ANTON", Rating = 2 },
            new Order { OrderID = 1004, CustomerID = "AROUT", Rating = 4 },
            new Order { OrderID = 1005, CustomerID = "BERGS", Rating = 1 },
            new Order { OrderID = 1006, CustomerID = "BLAUS", Rating = 5 },
            new Order { OrderID = 1007, CustomerID = "BLONP", Rating = 3 },
            new Order { OrderID = 1008, CustomerID = "BOLID", Rating = 2 },
            new Order { OrderID = 1009, CustomerID = "BONAP", Rating = 4 },
            new Order { OrderID = 1010, CustomerID = "BOTTM", Rating = 3 },
            new Order { OrderID = 1011, CustomerID = "BSBEV", Rating = 5 },
            new Order { OrderID = 1012, CustomerID = "CACTU", Rating = 1 },
            new Order { OrderID = 1013, CustomerID = "CENTC", Rating = 4 }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLeXzrApyBafWHl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}