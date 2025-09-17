---
layout: post
title: Lazy Load Grouping in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Lazy Load Grouping in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Lazy Load Grouping in Blazor DataGrid

In Blazor , lazy loading refers to the technique of loading data dynamically when they are needed, instead of loading everything upfront. Lazy loading can significantly improve the performance of your application by reducing the initial load time.

Lazy load grouping in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to load and display grouped data efficiently by fetching only the required data on demand. This feature is useful when dealing with large datasets where loading all the data at once might affect performance. The Grid will render only the initial level caption rows in the collapsed state at grouping. The child rows of each caption will be fetched in on demand and render in the Grid when you expand the caption row.

To enable this feature, need to set the [EnableLazyLoading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_EnableLazyLoading) as **true** in [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings).

The following example demonstrates how to enable the lazy load grouping feature by setting the `EnableLazyLoading` as **true** in `GridGroupSettings`:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowPaging="true" AllowGrouping="true">
    <GridGroupSettings EnableLazyLoading="true" Columns="@Initial"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductName) HeaderText="Product Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductID) HeaderText="Product ID" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerName) HeaderText="Customer Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public string[] Initial = (new string[] { "ProductName", "CustomerName" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();  
    public OrderData(){}
    public OrderData(int? OrderID,string ProductName, int? ProductID, string CustomerName)
    {
        this.OrderID = OrderID;    
        this.ProductName = ProductName;
        this.ProductID = ProductID;
        this.CustomerName = CustomerName;           
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {

            string[] Customer ={"Maria", "Ana Trujillo", "Antonio Moreno", "Thomas Hardy", "Christina Berglund", "Hanna Moos", "Frédérique Citeaux", "Martín Sommer", "Laurence Lebihan", "Elizabeth Lincoln",
    "Victoria Ashworth", "Patricio Simpson", "Francisco Chang", "Yang Wang", "Pedro Afonso", "Elizabeth Brown", "Sven Ottlieb", "Janine Labrune", "Ann Devon", "Roland Mendel", "Aria Cruz", "Diego Roel",
    "Martine Rancé", "Maria Larsson", "Peter Franken", "Carine Schmitt", "Paolo Accorti", "Lino Rodriguez", "Eduardo Saavedra", "José Pedro Freyre", "André Fonseca", "Howard Snyder", "Manuel Pereira",
    "Mario Pontes", "Carlos Hernández", "Yoshi Latimer", "Patricia McKenna", "Helen Bennett", "Philip Cramer", "Daniel Tonini", "Annette Roulet", "Yoshi Tannamuri", "John Steel", "Renate Messner", "Jaime Yorres",
    "Carlos González", "Felipe Izquierdo", "Fran Wilson", "Giovanni Rovelli", "Catherine Dewey", "Jean Fresnière", "Alexander Feuer", "Simon Crowther", "Yvonne Moncada", "Rene Phillips", "Henriette Pfalzheim",
    "Marie Bertrand", "Guillermo Fernández", "Georg Pipps", "Isabel de Castro", "Bernardo Batista", "Lúcia Carvalho", "Horst Kloss", "Sergio Gutiérrez", "Paula Wilson", "Maurizio Moroni", "Janete Limeira", "Michael Holz",
    "Alejandra Camino", "Jonas Bergulfsen", "Jose Pavarotti", "Hari Kumar", "Jytte Petersen", "Dominique Perrier", "Art Braunschweiger", "Pascale Cartrain", "Liz Nixon", "Liu Wong", "Karin Josephs", "Miguel Angel Paolino",
    "Anabela Domingues", "Helvetius Nagy", "Palle Ibsen", "Mary Saveley", "Paul Henriot", "Rita Müller", "Pirkko Koskitalo", "Paula Parente", "Karl Jablonski", "Matti Karttunen", "Zbyszek Piestrzeniewicz"};
        string[] Product = {"Chai", "Chang", "Aniseed Syrup", "Chef Anton\"s Cajun Seasoning", "Chef Anton\"s Gumbo Mix", "Grandma\"s Boysenberry Spread",
        "Uncle Bob\"s Organic Dried Pears", "Northwoods Cranberry Sauce", "Mishi Kobe Niku", "Ikura", "Queso Cabrales", "Queso Manchego La Pastora", "Konbu",
        "Tofu", "Genen Shouyu", "Pavlova", "Alice Mutton", "Carnarvon Tigers", "Teatime Chocolate Biscuits", "Sir Rodney\"s Marmalade", "Sir Rodney\"s Scones",
        "Gustaf\"s Knäckebröd", "Tunnbröd", "Guaraná Fantástica", "NuNuCa Nuß-Nougat-Creme", "Gumbär Gummibärchen", "Schoggi Schokolade", "Rössle Sauerkraut",
        "Thüringer Rostbratwurst", "Nord-Ost Matjeshering", "Gorgonzola Telino", "Mascarpone Fabioli", "Geitost", "Sasquatch Ale", "Steeleye Stout", "Inlagd Sill",
        "Gravad lax", "Côte de Blaye", "Chartreuse verte", "Boston Crab Meat", "Jack\"s New England Clam Chowder", "Singaporean Hokkien Fried Mee", "Ipoh Coffee",
        "Gula Malacca", "Rogede sild", "Spegesild", "Zaanse koeken", "Chocolade", "Maxilaku", "Valkoinen suklaa", "Manjimup Dried Apples", "Filo Mix", "Perth Pasties",
        "Tourtière", "Pâté chinois", "Gnocchi di nonna Alice", "Ravioli Angelo", "Escargots de Bourgogne", "Raclette Courdavault", "Camembert Pierrot", "Sirop d\"érable",
        "Tarte au sucre", "Vegie-spread", "Wimmers gute Semmelknödel", "Louisiana Fiery Hot Pepper Sauce", "Louisiana Hot Spiced Okra", "Laughing Lumberjack Lager", "Scottish Longbreads",
        "Gudbrandsdalsost", "Outback Lager", "Flotemysost", "Mozzarella di Giovanni", "Röd Kaviar", "Longlife Tofu", "Rhönbräu Klosterbier", "Lakkalikööri", "Original Frankfurter grüne Soße"};
                int OrderID = 10248;
                int i = 0; int j = 0; int k = 0; int l = 0; int m = 0;
                for (int x = 0; x < 20000; x++)
                {
                    i = i >= Customer.Length ? 0 : i;
                    l = l >= Product.Length ? 0 : l;
                    Orders.Add(new OrderData()
                    {
                        OrderID = OrderID + x,
                        ProductID = x + 10,
                        CustomerName = Customer[i],
                        ProductName = Product[l],

                    });
                    i++; j++; k++; l++; m++;
                }
            }
            return Orders;
        }

    public int? OrderID { get; set; }
    public string ProductName { get; set; }
    public int? ProductID { get; set; }
    public string CustomerName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBfXWNvAIVdashy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Lazy load grouping with infinite scrolling

Lazy loading grouping with infinite scrolling is a valuable feature in scenarios where there is a need to present grouped data, efficiently handle large datasets, and ensure a seamless experience. This feature enables loading data on demand as the interface is interacted with, ensuring optimal performance and responsiveness while effectively managing and presenting large grouped datasets

**How lazy load grouping with infinite scrolling works**

1. When you enable lazy load grouping with infinite scrolling, the Grid initially renders only the top-level caption rows in a collapsed state.

2. The child rows associated with each group caption are loaded and rendered in the Grid only when you expand the corresponding caption row.

3. Infinite scrolling enables the Grid to load additional data as the user scrolls to the end of the scrollbar.

To enable this feature, you need to set the [EnableInfiniteScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableInfiniteScrolling) property as **true** and the [EnableLazyLoading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_EnableLazyLoading) property of the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html) class as **true**.

The following example demonstrates how to enable the lazy load grouping with infinite scrolling feature using the `EnableLazyLoading` property of the `GridGroupSettings` and `EnableInfiniteScrolling` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" ID="Grid" EnableInfiniteScrolling="true" RowHeight="36" AllowGrouping="true" Height="315px">
    <GridGroupSettings EnableLazyLoading="true" Columns="@Initial"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductName) HeaderText="Product Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductID) HeaderText="Product ID" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerName) HeaderText="Customer Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public string[] Initial = (new string[] { "ProductName", "CustomerName" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData() {}

    public OrderData(int? OrderID, string ProductName, int? ProductID, string CustomerName)
    {
        this.OrderID = OrderID;
        this.ProductName = ProductName;
        this.ProductID = ProductID;
        this.CustomerName = CustomerName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {

            string[] Customer ={"Maria", "Ana Trujillo", "Antonio Moreno", "Thomas Hardy", "Christina Berglund", "Hanna Moos", "Frédérique Citeaux", "Martín Sommer", "Laurence Lebihan", "Elizabeth Lincoln",
    "Victoria Ashworth", "Patricio Simpson", "Francisco Chang", "Yang Wang", "Pedro Afonso", "Elizabeth Brown", "Sven Ottlieb", "Janine Labrune", "Ann Devon", "Roland Mendel", "Aria Cruz", "Diego Roel",
    "Martine Rancé", "Maria Larsson", "Peter Franken", "Carine Schmitt", "Paolo Accorti", "Lino Rodriguez", "Eduardo Saavedra", "José Pedro Freyre", "André Fonseca", "Howard Snyder", "Manuel Pereira",
    "Mario Pontes", "Carlos Hernández", "Yoshi Latimer", "Patricia McKenna", "Helen Bennett", "Philip Cramer", "Daniel Tonini", "Annette Roulet", "Yoshi Tannamuri", "John Steel", "Renate Messner", "Jaime Yorres",
    "Carlos González", "Felipe Izquierdo", "Fran Wilson", "Giovanni Rovelli", "Catherine Dewey", "Jean Fresnière", "Alexander Feuer", "Simon Crowther", "Yvonne Moncada", "Rene Phillips", "Henriette Pfalzheim",
    "Marie Bertrand", "Guillermo Fernández", "Georg Pipps", "Isabel de Castro", "Bernardo Batista", "Lúcia Carvalho", "Horst Kloss", "Sergio Gutiérrez", "Paula Wilson", "Maurizio Moroni", "Janete Limeira", "Michael Holz",
    "Alejandra Camino", "Jonas Bergulfsen", "Jose Pavarotti", "Hari Kumar", "Jytte Petersen", "Dominique Perrier", "Art Braunschweiger", "Pascale Cartrain", "Liz Nixon", "Liu Wong", "Karin Josephs", "Miguel Angel Paolino",
    "Anabela Domingues", "Helvetius Nagy", "Palle Ibsen", "Mary Saveley", "Paul Henriot", "Rita Müller", "Pirkko Koskitalo", "Paula Parente", "Karl Jablonski", "Matti Karttunen", "Zbyszek Piestrzeniewicz"};
            string[] Product = {"Chai", "Chang", "Aniseed Syrup", "Chef Anton\"s Cajun Seasoning", "Chef Anton\"s Gumbo Mix", "Grandma\"s Boysenberry Spread",
        "Uncle Bob\"s Organic Dried Pears", "Northwoods Cranberry Sauce", "Mishi Kobe Niku", "Ikura", "Queso Cabrales", "Queso Manchego La Pastora", "Konbu",
        "Tofu", "Genen Shouyu", "Pavlova", "Alice Mutton", "Carnarvon Tigers", "Teatime Chocolate Biscuits", "Sir Rodney\"s Marmalade", "Sir Rodney\"s Scones",
        "Gustaf\"s Knäckebröd", "Tunnbröd", "Guaraná Fantástica", "NuNuCa Nuß-Nougat-Creme", "Gumbär Gummibärchen", "Schoggi Schokolade", "Rössle Sauerkraut",
        "Thüringer Rostbratwurst", "Nord-Ost Matjeshering", "Gorgonzola Telino", "Mascarpone Fabioli", "Geitost", "Sasquatch Ale", "Steeleye Stout", "Inlagd Sill",
        "Gravad lax", "Côte de Blaye", "Chartreuse verte", "Boston Crab Meat", "Jack\"s New England Clam Chowder", "Singaporean Hokkien Fried Mee", "Ipoh Coffee",
        "Gula Malacca", "Rogede sild", "Spegesild", "Zaanse koeken", "Chocolade", "Maxilaku", "Valkoinen suklaa", "Manjimup Dried Apples", "Filo Mix", "Perth Pasties",
        "Tourtière", "Pâté chinois", "Gnocchi di nonna Alice", "Ravioli Angelo", "Escargots de Bourgogne", "Raclette Courdavault", "Camembert Pierrot", "Sirop d\"érable",
        "Tarte au sucre", "Vegie-spread", "Wimmers gute Semmelknödel", "Louisiana Fiery Hot Pepper Sauce", "Louisiana Hot Spiced Okra", "Laughing Lumberjack Lager", "Scottish Longbreads",
        "Gudbrandsdalsost", "Outback Lager", "Flotemysost", "Mozzarella di Giovanni", "Röd Kaviar", "Longlife Tofu", "Rhönbräu Klosterbier", "Lakkalikööri", "Original Frankfurter grüne Soße"};
            int OrderID = 10248;
            int i = 0; int j = 0; int k = 0; int l = 0; int m = 0;
            for (int x = 0; x < 20000; x++)
            {
                i = i >= Customer.Length ? 0 : i;
                l = l >= Product.Length ? 0 : l;
                Orders.Add(new OrderData()
                {
                    OrderID = OrderID + x,
                    ProductID = x + 10,
                    CustomerName = Customer[i],
                    ProductName = Product[l],
                });
                i++; j++; k++; l++; m++;
            }       
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string ProductName { get; set; }
    public int? ProductID { get; set; }
    public string CustomerName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBfjiNqTFAghOTK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The [EnableInfiniteScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableInfiniteScrolling) property is optional and can be set to **true** or **false** based on the requirement.
> * When `EnableLazyLoading` is enabled with `EnableInfiniteScrolling`, the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) and the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property must be defined.

## Lazy load grouping with virtual scrolling

The lazy load grouping with virtual scrolling feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to efficiently present and analyze large grouped datasets. This feature optimizes performance, reduces initial load time, and provides smooth scrolling through the dataset.

**How lazy load grouping with virtual scrolling works**

1. When you enable lazy load grouping with virtual scrolling, the Grid renders only the initial level caption rows in a collapsed state.

2. The child rows associated with each group caption are loaded and rendered in the Grid only when you expand the respective caption row.

3. Virtual scrolling allows the Grid to load and display a buffered set of records while scrolling vertically.

To enable this feature, you need to set the [EnableLazyLoading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_EnableLazyLoading) property of the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html) and [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) properties to true.

The following example demonstrates how to enable the lazy load grouping with virtual scrolling feature using the `EnableLazyLoading` property of the `GridGroupSettings` and `EnableVirtualization` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" ID="Grid" RowHeight="36" AllowGrouping="true" EnableVirtualization="true" Height="315px">
    <GridGroupSettings EnableLazyLoading="true" Columns="@Initial"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductName) HeaderText="Product Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductID) HeaderText="Product ID" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerName) HeaderText="Customer Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public string[] Initial = (new string[] { "ProductName", "CustomerName" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}
    
    public OrderData(int? OrderID,string ProductName, int? ProductID, string CustomerName)
    {
        this.OrderID = OrderID;    
        this.ProductName = ProductName;
        this.ProductID = ProductID;
        this.CustomerName = CustomerName;           
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int? code = 10247;
            for (int i = 1; i < 19999; i++)
            {
                Orders.Add(new OrderData(code + 1, "Gumbär Gummib", i, "Marie Bertrand"));
                Orders.Add(new OrderData(code + 2, "Valkoinen suklaa", i+1, "Paula Wilson"));
                Orders.Add(new OrderData(code + 3, "Chai", i+2, "Giovanni Rovelli"));
                Orders.Add(new OrderData(code + 4, "Guaraná Fantástica", i+3, "Yang Wang"));
                Orders.Add(new OrderData(code + 5, "Chef Anton's Cajun Seasoning", i + 4, "Martín Sommer"));
                Orders.Add(new OrderData(code + 6, "Gudbrandsdalsost", i + 5, "Laurence Lebihan"));
                Orders.Add(new OrderData(code + 7, "Jack's New England Clam Chowder", i + 6, "Frédérique Citeaux"));
                Orders.Add(new OrderData(code + 8, "Queso Cabrales", i + 7, "Philip Cramer"));
                Orders.Add(new OrderData(code + 9, "Tarte au sucre", i + 8, "Francisco Chang"));
                code += 9;
                i += 8;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string ProductName { get; set; }
    public int? ProductID { get; set; }
    public string CustomerName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVUsCMzgHLDLmbm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * When `EnableLazyLoading` is enabled with `EnableVirtualization`, the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) property of the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html) class and the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property must be defined.
> * When enabling lazy load grouping with virtual scrolling, the [EnableVirtualMaskRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualMaskRow) property is enabled by default. There is no need to use this property explicitly. 

## Lazy load grouping with custom adaptor

You can use the Custom Adaptor of DataManager when binding the remote data. Along with the default server request, this feature will additionally send the below details to handle the lazy load grouping. In the server end, these details are bound with the **LazyLoad** and **LazyExpandAllGroup** parameters in the DataManagerRequest model.

| Property Name | Description |
|-------|---------|
| LazyLoad | To differentiate between default grouping and lazy load grouping.|
| LazyExpandAllGroup | To handle ExpandAll support for lazy load grouping.|

The following code example describes the lazy load grouping handled at the server-side with other Grid actions.

```csharp
// Implementing custom adaptor by extending the DataAdaptor class.
public class CustomAdaptor : DataAdaptor
{
    public List<Customer> customers { get; set; } = Customer.GetAllRecords();
    // Performs data Read operation.
    public override object Read(DataManagerRequest dm, string key = null)
    {
        IEnumerable<Customer> DataSource = customers;
        if (dm.Search != null && dm.Search.Count > 0)
        {
            DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
        }
        if (dm.Sorted != null && dm.Sorted.Count > 0)
        {
            DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
        }
        if (dm.Where != null && dm.Where.Count > 0)
        {
            DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
        }
        int count = DataSource.Cast<Customer>().Count();
        if (dm.Skip != 0)
        {
            DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
        }
        if (dm.Take != 0)
        {
            DataSource = DataOperations.PerformTake(DataSource, dm.Take);
        }
        DataResult DataObject = new DataResult();
        if (dm.Group != null)
        {
            // Grouping (Perform lazy load grouping need to send LazyLoad property in Group method).
            IEnumerable ResultData = DataSource.ToList();
            ResultData = DataUtil.Group<Customer>(DataSource, dm.Group[0], dm.Aggregates, 0, dm.GroupByFormatter, dm.LazyLoad, dm.LazyExpandAllGroup);
            DataObject.Result = ResultData;
            DataObject.Count = ResultData.Cast<object>().Count();
            return dm.RequiresCounts ? DataObject : (object)ResultData;
        }
        return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
    }
}
```

## Limitations for lazy load grouping

* Due to the element height limitation in browsers, the maximum number of records loaded by the Grid is limited due to the browser capability.
* Lazy load grouping is not compatible with the following features
    * Batch editing
    * Row template
    * Row drag and drop
    * Hierarchical Grid
    * Detail Template
* Programmatic selection is not supported in lazy load grouping when groups are in a collapsed state.
* Drag selection, Cell selection (box and flow), Row Selection is not working in collapsed state.
* Clipboard is not support when the groups are in collapsed state.