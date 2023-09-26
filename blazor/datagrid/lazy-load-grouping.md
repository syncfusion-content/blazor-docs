---
layout: post
title: Lazy Load Grouping in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Lazy Load Grouping in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Lazy Load Grouping in Blazor DataGrid Component

In Blazor , lazy loading refers to the technique of loading data dynamically when they are needed, instead of loading everything upfront. Lazy loading can significantly improve the performance of your application by reducing the initial load time.

Lazy load grouping in Syncfusion Grid allows you to load and display grouped data efficiently by fetching only the required data on demand. This feature is useful when dealing with large datasets where loading all the data at once might affect performance. The Grid will render only the initial level caption rows in the collapsed state at grouping. The child rows of each caption will be fetched in on demand and render in the Grid when you expand the caption row.


To enable this feature, need to set the [EnableLazyLoading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_EnableLazyLoading) as **true** in [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings) component.

The following example demonstrates how to enable the lazy load grouping feature by setting the `EnableLazyLoading` as **true** in `GridGroupSettings` component.

```cshtml
@using Syncfusion.Blazor.Grids
<SfGrid TValue="Order" AllowPaging="true" DataSource="@Orders" AllowGrouping="true" >
    <GridGroupSettings EnableLazyLoading="true" Columns="@Initial"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ProductName) HeaderText="Product Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ProductID) HeaderText="Product ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerName) HeaderText="Customer Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<Order> Orders { get; set; }


    public string[] Initial = (new string[] { "ProductName", "CustomerName" });
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 5000).Select(x => new Order()
            {
                OrderID = 1000 + x,
                ProductName = (new string[] { "Côte de Blaye", "Wimmers gute Semmelknödel", "Mascarpone Fabioli", "Queso Manchego La Pastora", "Sasquatch Ale" })[new Random().Next(5)],
                ProductID = x,
                CustomerName = (new string[] { "Thomas Hardy", "Pascale Cartrain", "Patricia McKenna", "Karl Jablonski", "Paula Wilson" })[new Random().Next(5)],
            }).ToList();

    }


    public class Order
    {
        public int? OrderID { get; set; }
        public string ProductName { get; set; }
        public int? ProductID { get; set; }
        public string? CustomerName { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrUZkjwhTNadxnJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Lazy load grouping with virtual scrolling

The lazy load grouping with virtual scrolling feature in the Syncfusion blazor Grid allows you to efficiently present and analyze large grouped datasets. This feature optimizes performance, reduces initial load time, and provides smooth scrolling through the dataset.

**How lazy load grouping with virtual scrolling works**

1. When you enable lazy load grouping with virtual scrolling, the Grid renders only the initial level caption rows in a collapsed state.

2. The child rows associated with each group caption are loaded and rendered in the Grid only when you expand the respective caption row.

3. Virtual scrolling allows the Grid to load and display a buffered set of records while scrolling vertically.


To enable this feature, you need to set the [EnableLazyLoading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_EnableLazyLoading) property of the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html) component and [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) properties to true.


> When `EnableLazyLoading` is enabled with `EnableVirtualization`, the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) property of the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html) class and the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property must be defined.

> When enabling lazy load grouping with virtual scrolling, the [EnableVirtualMaskRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualMaskRow) property is enabled by default. There is no need to use this property explicitly. 

The following example demonstrates how to enable the lazy load grouping with virtual scrolling feature using the `EnableLazyLoading` property of the `GridGroupSettings` component and `EnableVirtualization` property.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid TValue="Customer" DataSource="customers" ID="Grid" RowHeight="36" AllowGrouping="true" EnableVirtualization="true" Height="400">
    <GridGroupSettings EnableLazyLoading="true" Columns="@GroupedColumns">  
    </GridGroupSettings>
    <GridPageSettings PageSize=40></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Customer.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Customer.ProductName) HeaderText="Product Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Customer.ProductID) HeaderText="Product ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Customer.CustomerName) HeaderText="Customer Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public string[] GroupedColumns = new string[] { "ProductName", "CustomerName" };
    public List<Customer> customers { get; set; } = Customer.GetAllRecords();
    public class Customer
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public static List<Customer> GetAllRecords()
        {
            List<Customer> customers = new List<Customer>();
            string[] Customername ={"Maria", "Ana Trujillo", "Antonio Moreno", "Thomas Hardy", "Christina Berglund", "Hanna Moos", "Frédérique Citeaux", "Martín Sommer", "Laurence Lebihan", "Elizabeth Lincoln",

    "Victoria Ashworth", "Patricio Simpson", "Francisco Chang", "Yang Wang", "Pedro Afonso", "Elizabeth Brown", "Sven Ottlieb", "Janine Labrune", "Ann Devon", "Roland Mendel", "Aria Cruz", "Diego Roel",

    "Martine Rancé", "Maria Larsson", "Peter Franken", "Carine Schmitt", "Paolo Accorti", "Lino Rodriguez", "Eduardo Saavedra", "José Pedro Freyre", "André Fonseca", "Howard Snyder", "Manuel Pereira",

    "Mario Pontes", "Carlos Hernández", "Yoshi Latimer", "Patricia McKenna", "Helen Bennett", "Philip Cramer", "Daniel Tonini", "Annette Roulet", "Yoshi Tannamuri", "John Steel", "Renate Messner", "Jaime Yorres",

    "Carlos González", "Felipe Izquierdo", "Fran Wilson", "Giovanni Rovelli", "Catherine Dewey", "Jean Fresnière", "Alexander Feuer", "Simon Crowther", "Yvonne Moncada", "Rene Phillips", "Henriette Pfalzheim",

    "Marie Bertrand", "Guillermo Fernández", "Georg Pipps", "Isabel de Castro", "Bernardo Batista", "Lúcia Carvalho", "Horst Kloss", "Sergio Gutiérrez", "Paula Wilson", "Maurizio Moroni", "Janete Limeira", "Michael Holz",

    "Alejandra Camino", "Jonas Bergulfsen", "Jose Pavarotti", "Hari Kumar", "Jytte Petersen", "Dominique Perrier", "Art Braunschweiger", "Pascale Cartrain", "Liz Nixon", "Liu Wong", "Karin Josephs", "Miguel Angel Paolino",

    "Anabela Domingues", "Helvetius Nagy", "Palle Ibsen", "Mary Saveley", "Paul Henriot", "Rita Müller", "Pirkko Koskitalo", "Paula Parente", "Karl Jablonski", "Matti Karttunen", "Zbyszek Piestrzeniewicz" };

            string[] Product = { "Chai", "Chang", "Syrup", "Corn Snacks", "Gumbo Mix", "Seeds",
                "Dried Pears", "Sauce", "Mishi Kobe Niku", "Ikura", "Queso Cabrales", "Queso Manchego Pastora", "Konbu",
                "Tofu", "Genen Shouyu", "Pavlova", "Alice Mutton", "Biscuits", "Teatime Chocolate Biscuits", "Sir Rodney\"s Marmalade", "Sir Rodney\"s Scones",
                "Gustaf\"s Knäckebröd", "Tunnbröd", "Guaraná Fantástica", "Nougat-Creme", "Gumbär Gummibärchen", "Schoggi Schokolade", "Rössle Sauerkraut",
                "Thüringer Rostbratwurst", "Nord-Ost Matjeshering", "Gorgonzola Telino", "Mascarpone Fabioli", "Geitost", "Sasquatch Ale", "Steeleye Stout", "Inlagd Sill",
                "Gravad lax", "Nuts", "Chips", "Crab Meat", "Jack\"s Clam Chowder", "Singaporean Fried Mee", "Ipoh Coffee",
                "Gula Malacca", "Rogede sild", "Spegesild", "Zaanse koeken", "Chocolade", "Maxilaku", "Valkoinen suklaa", "Manjimup Dried Apples", "Filo Mix", "Perth Pasties",
                "Tourtičre", "Pâté chinois", "Ipoh Coffee", "Ravioli Angelo", "Escargots Bourgogne", "Raclette Courdavault", "Cake", "Sirop d\"érable",
                "Tarte au sucre", "Vegie-spread", "Lakkalikri", "Louisiana Pepper Sauce", "Louisiana Hot Spiced Okra", "Lumberjack Lager", "Scottish Longbreads",
                "Gudbrandsdalsost", "Outback Lager", "Flotemysost", "Mozzarella di Giovanni", "Röd Kaviar", "Longlife Tofu", "Rhönbräu Klosterbier", "Lakkalikööri", "Original Frankfurter" };
            int OrderID = 1001;
            int i = 0; int l = 0; 
            for (int x = 0; x < 500000; x++)
            {
                i = i >= Customername.Length ? 0 : i;
                l = l >= Product.Length ? 0 : l;
                customers.Add(new Customer()
                    {
                        OrderID = OrderID + x,
                        ProductName = Product[l],
                        ProductID = x,
                        CustomerName = Customername[i],
                       
                    });
                i++;  l++; 
            }
            return customers;
        }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVqjaNmAVEUbngw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Lazy load grouping with custom adaptor

You can use the Custom Adaptor of DataManager when binding the remote data. Along with the default server request, this feature will additionally send the below details to handle the lazy load grouping. In the server end, these details are bound with the **LazyLoad** and **LazyExpandAllGroup** parameters in the DataManagerRequest model.

| Property Name | Description |
|-------|---------|
| LazyLoad | To differentiate between default grouping and lazy load grouping.|
| LazyExpandAllGroup | To handle ExpandAll support for lazy load grouping.|

The following code example describes the lazy load grouping handled at the server-side with other grid actions.

```csharp
 // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        public List<Customer> customers { get; set; } = Customer.GetAllRecords();
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Customer> DataSource = customers;
            if (dm.Search != null && dm.Search.Count > 0)
            {
                // Searching
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                // Sorting
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)
            {
                // Filtering
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Customer>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            DataResult DataObject = new DataResult();
            if (dm.Group != null)
            {
                // Grouping (Perform lazy load grouping need to send LazyLoad property in Group method)
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

* Due to the element height limitation in browsers, the maximum number of records loaded by the grid is limited due to the browser capability.
* Lazy load grouping is not compatible with the following features
    * Batch editing
    * Row template
    * Row drag and drop
    * Hierarchical Grid
    * Detail Template
* Programmatic selection is not supported in lazy load grouping when groups are in a collapsed state.
* Drag selection, Cell selection (box and flow), Row Selection is not working in collapsed state.
* Clipboard is not support when the groups are in collapsed state.