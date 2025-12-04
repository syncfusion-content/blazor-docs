---
layout: post
title: Lazy load grouping in Blazor DataGrid | Syncfusion
description: Learn how to enable lazy load grouping in Syncfusion Blazor DataGrid with on-demand data loading, infinite scrolling, and virtual scrolling for large datasets.
platform: Blazor
control: DataGrid
documentation: ug
---

# Lazy Load Grouping in Blazor DataGrid

In Blazor, lazy loading refers to loading data dynamically only when needed, rather than loading everything upfront. This approach reduces initial load time and improves application performance.

Lazy load grouping in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid efficiently loads grouped data by fetching only the required records on demand. This feature is especially useful for large datasets where loading all rows at once can affect performance. When grouping is applied, the DataGrid initially renders only top-level group caption rows in a collapsed state. The child rows for each group are fetched on demand and rendered when the corresponding caption row is expanded.

To enable this feature, set [EnableLazyLoading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_EnableLazyLoading) to **true** in [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings). Ensure grouping is enabled by setting AllowGrouping to true.

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

Lazy load grouping with infinite scrolling is useful when presenting grouped data at scale while maintaining responsiveness. Data is loaded on-demand as users interact with the interface, improving performance and user experience.

**How lazy load grouping with infinite scrolling works**

1. When enabled, the DataGrid initially renders only the top-level group caption rows in a collapsed state.

2. Child rows for a group are fetched and rendered only when the corresponding caption row is expanded.

3. Infinite scrolling loads additional data as the user reaches the end of the scrollbar.

To enable this feature, set [EnableInfiniteScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableInfiniteScrolling) to **true** and set [EnableLazyLoading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_EnableLazyLoading) in [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html) to **true**.

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

> * The [EnableInfiniteScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableInfiniteScrolling) property is optional and can be set based on the requirement.
> * When `EnableLazyLoading` is enabled with `EnableInfiniteScrolling`, the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) and [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) properties must be defined.
> * `Paging` should not be used together with infinite scrolling.

## Lazy load grouping with virtual scrolling

The lazy load grouping with virtual scrolling feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid efficiently presents large grouped datasets by reducing initial load time and providing smooth scrolling.

**How lazy load grouping with virtual scrolling works**

1. When enabled, the DataGrid renders only the initial top-level group caption rows in a collapsed state.

2. Child rows for each group are fetched and rendered only when the respective caption row is expanded.

3. Virtual scrolling loads and displays a buffered set of records while scrolling vertically.

To enable this feature, set [EnableLazyLoading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_EnableLazyLoading) in [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html) to true and set [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) to true.

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

> * When `EnableLazyLoading` is enabled with `EnableVirtualization`, the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) property of [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html) and the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property must be defined.
> * When enabling lazy load grouping with virtual scrolling, the [EnableVirtualMaskRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualMaskRow) property is enabled by default; there is no need to set it explicitly.
> * `Paging` should not be used together with virtual scrolling.

## Lazy load grouping with custom adaptor

Use a Custom Adaptor of DataManager when binding remote data. Along with the default server request, this feature sends additional details to handle lazy load grouping. On the server, these details are bound to the **LazyLoad** and **LazyExpandAllGroup** parameters in the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataManagerRequest.html) model. For implementing server logic, extend the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataAdaptor.html) class.

| Property Name | Description |
|-------|---------|
| LazyLoad | Differentiates between default grouping and lazy load grouping. |
| LazyExpandAllGroup | Handles Expand All support for lazy load grouping. |


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

* Due to browser element height limitations, the maximum number of records that can be rendered is constrained by browser capabilities.
* Lazy load grouping is not compatible with the following features:
    * Batch editing
    * Row template
    * Row drag and drop
    * Hierarchical Grid
    * Detail Template
* Programmatic selection is not supported when groups are collapsed.
* Drag selection, cell selection (box and flow), and row selection do not work when groups are collapsed.
* Clipboard is not supported when groups are collapsed.