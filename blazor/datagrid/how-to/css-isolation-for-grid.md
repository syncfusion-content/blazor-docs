---
layout: post
title: CSS isolation for Blazor DataGrid Component | Syncfusion
description: Check out how to apply styles using CSS isolation in the Syncfusion Blazor DataGrid component with ::deep selectors and scoped wrapper patterns.
platform: Blazor
control: DataGrid
documentation: ug
---

# CSS isolation for Blazor DataGrid

CSS isolation in Blazor allows developers to define component-scoped styles that apply only to a specific Razor component. This approach helps prevent style conflicts and ensures that UI customizations do not unintentionally affect other parts of the application. When working with complex components like the Syncfusion Blazor DataGrid, CSS isolation is especially useful for maintaining clean, modular, and maintainable styling.

To enable CSS isolation, create a **razor.css** file with the same name as the corresponding **.razor** file. For example, to apply isolated styles to an **Index** component, create a file named **Index.razor.css** in the same directory as **Index.razor**. These styles are compiled and scoped automatically by the Blazor framework.

## Why use CSS isolation with DataGrid

The Syncfusion Blazor DataGrid renders a rich set of nested HTML elements to support features such as paging, sorting, filtering, and editing. In global CSS files, targeting these nested elements can lead to conflicts or unintended style overrides. CSS isolation ensures that:

* Styles are scoped only to the intended component  
* Grid customization does not impact other UI elements  
* Maintenance becomes easier in large-scale applications  
* Styling logic remains clean and modular  

## How CSS isolation works

Blazor applies a unique attribute to elements in the component at runtime, and corresponding styles are generated to match only those elements. However, since the DataGrid internally renders child elements, direct selectors may not work inside isolated CSS. To address this, the **::deep** combinator is used to target nested elements rendered by child components.

## Important requirement: wrapping the Grid

When using CSS isolation with the Syncfusion DataGrid, it is recommended to wrap the **SfGrid** component inside a standard HTML container (such as a `div`). This wrapper helps define a clear styling boundary and ensures proper application of scoped styles when using the **::deep** selector.

## Example: Applying CSS isolation to DataGrid

Below is an example demonstrating how to implement a simple DataGrid in **Index.razor** and apply isolated styles using **Index.razor.css**.

{% tabs %}
{% highlight C# tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<div class="grid-host">
    <SfGrid DataSource="@Orders" AllowPaging="true">
        <GridColumns>
            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
            <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code{
    private static readonly Random random = new Random();
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[random.Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[random.Next(5)]
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

```css
Index.razor.css
.grid-host ::deep .e-altrow {
    background-color: violet;
}
```

## Explanation of the styling

In this example, the **.e-altrow** class targets alternate rows in the DataGrid. Since the DataGrid generates its internal DOM structure, the **::deep** combinator is used to penetrate the CSS isolation boundary and apply styles to child elements.

The **.grid-host** wrapper ensures that the scope remains limited to this specific instance of the Grid, preventing unintended styling of other component


## When to use CSS isolation

CSS isolation is recommended in the following scenarios:

* Customizing DataGrid appearance within a specific page or component  
* Avoiding global CSS conflicts in large applications  
* Building reusable components with independent styling  
* Applying theme overrides without modifying global styles


## Best practices

* Always use a wrapper element (e.g., `div`) when styling third-party components  
* Use **::deep** only when targeting child component elements  
* Keep styles minimal and focused to maintain performance  
* Combine CSS isolation with component-level design for better scalability  


## Troubleshooting tips

* If styles are not applied, verify that the **.razor.css** file name matches the component name  
* Ensure the **::deep** selector is used for nested elements  
* Check browser developer tools to inspect generated attributes and applied styles  
* Avoid overly generic selectors that may conflict with framework style

> Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/How-to-Getting-Started-Blazor-DataGrid-Samples/tree/master/CSS_Isolation).

N> More information on CSS Isolation is available [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/css-isolation?view=aspnetcore-8.0#child-component-support).