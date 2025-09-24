---
layout: post
title: Use Custom Helper with Templates in Blazor DataGrid | Syncfusion
description: Learn how to use a custom helper method inside a column template loop to render a star rating in the Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# Use custom helper inside the loop with templates

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports using custom helpers inside the loop within a column [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template). This enables building flexible templates that incorporate additional logic and helper functions.

The following example renders a customer rating column with a custom template. Inside the template, the code iterates over a fixed range and generates star elements. The `IsRatingGreater` helper method determines which stars to highlight.

```css
.e-grid .rating .star:before {
    content: '★';
}

.e-grid .rating .star {
    font-size: 132%;
    color: lightgrey;
}
```

The highlighted state is applied based on the result of the `IsRatingGreater` method:

```css
.e-grid .rating .star.checked {
    color: #ffa600;
}
```

This is demonstrated in the following example.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.Linq

<SfGrid DataSource="@Orders" Height="300px">
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn HeaderText="Customer Rating" Width="120">
            <Template>
                @{
                    var rating = (context as Order)?.Rating ?? 0;
                }
                <div class="rate" aria-label="@($"{rating} out of 5 stars")">
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