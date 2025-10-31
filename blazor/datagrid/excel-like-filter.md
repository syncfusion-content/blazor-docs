---
layout: post
title: Excel Like Filter in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Excel like filter in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Excel like filter in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers an Excel-like filter feature, providing a familiar and user-friendly interface for filtering data within the Grid. This feature simplifies complex filtering operations on specific columns, allowing for quick data location and manipulation, similar to Microsoft Excel. Excel like filtering is especially useful when dealing with large datasets and complex filtering requirements.

Here is an example that showcasing how to render the Excel like filter within the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" TValue="OrderData" AllowFiltering="true" AllowSorting="true" AllowPaging="true" DataSource="@GridData">
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="120"> </GridColumn>
      
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }

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

    public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10248;
                
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", new DateTime(1996, 07, 04), 32.38));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", new DateTime(1996, 07, 05), 11.61));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", new DateTime(1996, 07, 07), 45.78));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", new DateTime(1996, 07, 08), 98.6));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", new DateTime(1996, 07, 09), 103.45));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", new DateTime(1996, 07, 10), 103.45));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", new DateTime(1996, 07, 11), 112.48));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", new DateTime(1996, 07, 12), 33.45));
                OrderID += 9; 
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVfZVDQLqvKxcHI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The Excel-like filter feature supports various filter conditions, including text-based, number-based, date-based, and boolean-based filters.
> * The filter dialog provides additional options, such as searching for specific values, and clearing applied filters.

## Checkbox filtering

The checkbox filtering feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables you to filter data based on checkbox selections within a column. This powerful filtering option simplifies the process of narrowing down data, providing a more efficient and user-friendly experience. The check box filter feature is particularly useful when dealing with columns containing categorical data.

Here is an example that showcasing how to render the check box filter within the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" TValue="OrderData" AllowFiltering="true" AllowSorting="true" AllowPaging="true" DataSource="@GridData">
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.CheckBox"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="120"> </GridColumn>
      
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }

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

    public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10248;
                
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", new DateTime(1996, 07, 04), 32.38));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", new DateTime(1996, 07, 05), 11.61));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", new DateTime(1996, 07, 07), 45.78));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", new DateTime(1996, 07, 08), 98.6));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", new DateTime(1996, 07, 09), 103.45));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", new DateTime(1996, 07, 10), 103.45));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", new DateTime(1996, 07, 11), 112.48));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", new DateTime(1996, 07, 12), 33.45));
                OrderID += 9; 
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBTZBNcrfDcFCUo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize the filter choice count

By default, the filter choice count is set to 1000, which means that the filter dialog will display a maximum of 1000 distinct values for each column as a checkbox list data. This default value ensures that the filter operation remains efficient, even with large datasets. Additionally, the filter dialog retrieves and displays distinct data from the first 1000 records bind to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to optimize performance, while the remaining records are returned as a result of the search option within the filter dialog.

The Grid allows you to customize the number of distinct data displayed in the checkbox list of the Excel/Checkbox type filter dialog. This can be useful when you want to customize the default filter choice count values while using large datasets.

However, you have the flexibility to increase or decrease the filter choice count based on your specific requirements. This can be achieved by adjusting the [FilterChoiceCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterDialogOpeningEventArgs.html#Syncfusion_Blazor_Grids_FilterDialogOpeningEventArgs_FilterChoiceCount) value.

The following example demonstrates how to customize the filter choice count in the checkbox list of the filter dialog. In the [FilterDialogOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_FilterDialogOpening) event, you can set the `FilterChoiceCount` property to the desired value:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" AllowFiltering="true" AllowPaging="true" Height="273px" DataSource="@GridData">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
    <GridEvents FilterDialogOpening="FilterDialogOpeningHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductName) HeaderText="Product Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Quantity) HeaderText="Quantity" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData>? Grid { get; set; }

    public void FilterDialogOpeningHandler(FilterDialogOpeningEventArgs args)
    {
        args.FilterChoiceCount = 3000;
    }

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

    public OrderData(int? OrderID, string CustomerID, string ProductName, string Quantity)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ProductName = ProductName;
        this.Quantity = Quantity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
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


            string[] Quantity = {"10 boxes x 20 bags", "24 - 12 oz bottles", "12 - 550 ml bottles", "48 - 6 oz jars", "36 boxes", "12 - 8 oz jars", "12 - 1 lb pkgs.", "12 - 12 oz jars", "18 - 500 g pkgs.", "12 - 200 ml jars",
            "1 kg pkg.", "10 - 500 g pkgs.", "2 kg box", "40 - 100 g pkgs.", "24 - 250 ml bottles", "32 - 500 g boxes", "20 - 1 kg tins", "16 kg pkg.", "10 boxes x 12 pieces", "30 gift boxes", "24 pkgs. x 4 pieces", "24 - 500 g pkgs.", "12 - 250 g pkgs.",
            "12 - 355 ml cans", "20 - 450 g glasses", "100 - 250 g bags" };

            string[] CustomerID = {"VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC",
        "OTTIK", "QUEDE", "RATTC", "ERNSH", "FOLKO", "BLONP", "WARTH", "FRANK", "GROSR", "WHITC", "WARTH", "SPLIR", "RATTC", "QUICK", "VINET",
        "MAGAA", "TORTU", "MORGK", "BERGS", "LEHMS", "BERGS", "ROMEY", "ROMEY", "LILAS", "LEHMS", "QUICK", "QUICK", "RICAR", "REGGC", "BSBEV",
        "COMMI", "QUEDE", "TRADH", "TORTU", "RATTC", "VINET", "LILAS", "BLONP", "HUNGO", "RICAR", "MAGAA", "WANDK", "SUPRD", "GODOS", "TORTU",
        "OLDWO", "ROMEY", "LONEP", "ANATR", "HUNGO", "THEBI", "DUMON", "WANDK", "QUICK", "RATTC", "ISLAT", "RATTC", "LONEP", "ISLAT", "TORTU",
        "WARTH", "ISLAT", "PERIC", "KOENE", "SAVEA", "KOENE", "BOLID", "FOLKO", "FURIB", "SPLIR", "LILAS", "BONAP", "MEREP", "WARTH", "VICTE",
        "HUNGO", "PRINI", "FRANK", "OLDWO", "MEREP", "BONAP", "SIMOB", "FRANK", "LEHMS", "WHITC", "QUICK", "RATTC", "FAMIA"};


            int OrderID = 10248;
            int i = 0; int j = 0; int k = 0; int l = 0; int m = 0;
            for (int x = 0; x < 25000; x++)
            {
                i = i >= CustomerID.Length ? 0 : i;
                l = l >= Product.Length ? 0 : l;
                k = k >= Quantity.Length ? 0 : k;
                Orders.Add(new OrderData()
                {
                    OrderID = OrderID + x,
                    CustomerID = CustomerID[i],
                    ProductName = Product[l],
                    Quantity = Quantity[k],

                });
                i++; j++; k++; l++;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ProductName { get; set; }
    public string Quantity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVfXVjhBrOeigOb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The specified filter choice count value determines the display of unique items as a checkbox list in the Excel/Checkbox type filter dialog. This can result in a delay in rendering these checkbox items when opening the filter dialog. Therefore, it is advisable to set a restricted filter choice count value.

## Show customized text in checkbox list data

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides you with the flexibility to customize the text displayed in the Excel/Checkbox filtering options. This allows you to modify the default text and provide more meaningful and contextual labels for the filtering.

To customize the text in the Excel/Checkbox filter, you can define a `FilterItemTemplate`  and bind it to the desired column. The `FilterItemTemplate`  property allows you to create custom templates for filter items. You can use any logic and HTML elements within this template to display the desired text or content.

In the example below, you can see how you can customize the text displayed in the filter checkbox list for the **Delivered** column. This is achieved by defining a `FilterItemTemplate`  within the element for that specific column. Inside the template, you can use FilterItemTemplateContext to conditionally display **Delivered** if the data value is true and **Not delivered** if the value is **false**:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" AllowPaging="true">
    <GridFilterSettings Type=" Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.CategoryName) HeaderText="Category Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Delivered) HeaderText="Delivered" Width="120" DisplayAsCheckBox="true" FilterSettings="@(new FilterSettings{Type = Syncfusion.Blazor.Grids.FilterType.CheckBox })">
            <FilterItemTemplate>
                @{
                    var filterContext = (context as FilterItemTemplateContext);
                    var itemTemplateValue = "DefaultText";

                    if (filterContext.Value.ToString() == "False")
                    {
                        itemTemplateValue = "Not delivered";
                    }
                    else
                    {
                        itemTemplateValue = "Delivered";
                    }
                }
                @itemTemplateValue
            </FilterItemTemplate>

        </GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductID) HeaderText="ProductID" Width="120"></GridColumn>
    </GridColumns>

</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

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
    public OrderData(string CategoryName, bool Delivered, int? ProductID)
    {
        this.CategoryName = CategoryName;
        this.Delivered = Delivered;
        this.ProductID = ProductID;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int ProductID = 0;
            for (int i = 1; i < 7; i++)
            {
                Orders.Add(new OrderData("Beverages", true, ProductID + 1));
                Orders.Add(new OrderData("Condiments", false, ProductID + 2));
                Orders.Add(new OrderData("Confections", false, ProductID + 3));
                Orders.Add(new OrderData("DairyProducts", true, ProductID + 4));
                Orders.Add(new OrderData("Grains", true, ProductID + 5));
                Orders.Add(new OrderData("Meat", false, ProductID + 6));
                Orders.Add(new OrderData("Produce", true, ProductID + 7));
                Orders.Add(new OrderData("Seafood", true, ProductID + 8));
                Orders.Add(new OrderData("Confections", false, ProductID + 9));
                ProductID += 9;
            }
        }
        return Orders;
    }

    public string CategoryName { get; set; }
    public bool Delivered { get; set; }
    public int? ProductID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVzDrNsbrIRILzx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Show template in checkbox list data

The `FilterItemTemplate` property in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to customize the appearance of filter items in the Grid’s filter checkbox list for a specific column. This property is useful when you want to provide a custom UI or additional information within the filter checkbox list, such as icons, text, or any HTML elements, alongside the default filter items.

In this example, you can see how to use the `FilterItemTemplate` to render icons along with the category names in the filter checkbox list for the **CategoryName** column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" AllowPaging="true">
    <GridFilterSettings Type=" Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.CategoryName) HeaderText="Category Name" Width="150">
            <FilterItemTemplate>
                @{
                    var filterContext = context as FilterItemTemplateContext;

                    if (filterContext.Value.ToString() == "Beverages")
                    {
                        <i class="fa fa-coffee"></i> <ln/> @filterContext.Value.ToString();
                    }
                    else if (filterContext.Value.ToString() == "Condiments")
                    {
                        <i class="fa fa-leaf"></i> <ln/> @filterContext.Value.ToString();
                    }
                    else if (filterContext.Value.ToString() == "Confections")
                    {
                        <i class="fas fa-birthday-cake"></i> <ln/> @filterContext.Value.ToString();
                    }
                    else if (filterContext.Value.ToString() == "DairyProducts")
                    {
                        <i class="fas fa-ice-cream"></i> <ln/> @filterContext.Value.ToString();
                    }
                    else if (filterContext.Value.ToString() == "Grains")
                    {
                        <i class="fas fa-seedling"></i> <ln/> @filterContext.Value.ToString();
                    }
                    else if (filterContext.Value.ToString() == "Meat")
                    {
                        <i class="fas fa-drumstick-bite"></i> <ln/> @filterContext.Value.ToString();
                    }
                    else if (filterContext.Value.ToString() == "Produce")
                    {
                        <i class="fas fa-carrot"></i> <ln/> @filterContext.Value.ToString();
                    }
                    else if (filterContext.Value.ToString() == "Seafood")
                    {
                        <i class="fas fa-fish"></i> <ln/> @filterContext.Value.ToString();
                    }
                }
            </FilterItemTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.Discontinued) HeaderText="Discontinued" Width="100" DisplayAsCheckBox="true"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductID) HeaderText="ProductID" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

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
    public OrderData(string CategoryName, bool Discontinued, int? ProductID)
    {
        this.CategoryName = CategoryName;
        this.Discontinued = Discontinued;
        this.ProductID = ProductID;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int ProductID = 0;
            for (int i = 1; i < 7; i++)
            {
                Orders.Add(new OrderData("Beverages", true, ProductID + 1));
                Orders.Add(new OrderData("Condiments", false, ProductID + 2));
                Orders.Add(new OrderData("Confections", false, ProductID + 3));
                Orders.Add(new OrderData("DairyProducts", true, ProductID + 4));
                Orders.Add(new OrderData("Grains", true, ProductID + 5));
                Orders.Add(new OrderData("Meat", false, ProductID + 6));
                Orders.Add(new OrderData("Produce", true, ProductID + 7));
                Orders.Add(new OrderData("Seafood", true, ProductID + 8));
                Orders.Add(new OrderData("Confections", false, ProductID + 9));
                ProductID += 9;
            }
        }
        return Orders;
    }

    public string CategoryName { get; set; }
    public bool Discontinued { get; set; }
    public int? ProductID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrJjVtQgjHtuqOK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize checkbox list data using FilterDialogOpening event

The Syncfusion Blazor DataGrid allows users to customize the checkbox list displayed in the filter dialog during Checkbox or Excel filtering. This can be achieved using the FilterDialogOpening event by reassigning the CheckboxListData property within the event handler. This approach enables developers to tailor the filter options to match specific business requirements or user preferences.

In the example below, custom values are assigned to the CheckboxListData during the FilterDialogOpening event. This ensures that the filter dialog displays only the desired checkbox items, offering full control over the filtering experience.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" AllowPaging="true">
    <GridFilterSettings Type=" Syncfusion.Blazor.Grids.FilterType.CheckBox"></GridFilterSettings>
    <GridEvents TValue="OrderData" FilterDialogOpening="OnFilterDialogOpening"></GridEvents>
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.CategoryName) HeaderText="Category Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Discontinued) HeaderText="Discontinued" Width="100" ></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductID) HeaderText="ProductID" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code 
{
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData> Grid;
    public List<string> CustomCategory { get; set; }

    private void OnFilterDialogOpening(FilterDialogOpeningEventArgs args)
    {
        if (args.ColumnName == "CategoryName")
        {
            List<OrderData> newList = GridData.DistinctBy(x => x.CategoryName).ToList<OrderData>();
            args.CheckboxListData = newList.Take(2);
        }
    }

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
    public OrderData(string CategoryName, bool Discontinued, int? ProductID)
    {
        this.CategoryName = CategoryName;
        this.Discontinued = Discontinued;
        this.ProductID = ProductID;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int ProductID = 0;
            for (int i = 1; i < 7; i++)
            {
                Orders.Add(new OrderData("Beverages", true, ProductID + 1));
                Orders.Add(new OrderData("Condiments", false, ProductID + 2));
                Orders.Add(new OrderData("Confections", false, ProductID + 3));
                Orders.Add(new OrderData("DairyProducts", true, ProductID + 4));
                Orders.Add(new OrderData("Grains", true, ProductID + 5));
                Orders.Add(new OrderData("Meat", false, ProductID + 6));
                Orders.Add(new OrderData("Produce", true, ProductID + 7));
                Orders.Add(new OrderData("Seafood", true, ProductID + 8));
                Orders.Add(new OrderData("Confections", false, ProductID + 9));
                ProductID += 9;
            }
        }
        return Orders;
    }

    public string CategoryName { get; set; }
    public bool Discontinued { get; set; }
    public int? ProductID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htLeMXKWzUUYwoyr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Customize the Excel filter dialog using CSS

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, you have the flexibility to enhance the visual presentation of the Excel filter dialog. This can be achieved by utilizing CSS styles to modify the dialog’s appearance according to the specific needs and aesthetics of your application.

**1.Removing context menu option**

The Excel filter dialog includes several features such as **context menu**, **search box**, and **checkbox list** that may not be required in some scenarios. You can remove these options using the className attribute in the Grid.

```cshtml
<style>
    .e-excelfilter .e-contextmenu-container.e-sfcontextmenu.e-grid-filter-menu {
        display: none;
    }
</style>
```

The following example demonstrates how to remove the context menu option in the Excel filter dialog using above mentioned CSS:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" AllowFiltering="true" AllowPaging="true" DataSource="@GridData">
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="120"> </GridColumn>

    </GridColumns>
</SfGrid>

<style>
    .e-excelfilter .e-contextmenu-container.e-sfcontextmenu.e-grid-filter-menu {
        display: none;
    }
</style>

@code {

    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }

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
    public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10248;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", new DateTime(1996, 07, 06), 32.38));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", new DateTime(1996, 07, 06), 45.78));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", new DateTime(1996, 07, 06), 112.48));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", new DateTime(1996, 07, 06), 33.45));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVJZhtsFqnfgvJa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**2.Customize the height and width of filter popup**

You can customize the height and width of each column’s filter dialog using the CSS style in the [FilterDialogOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_FilterDialogOpening) event of the Grid.

Before opening a filter dialog for each column, the `FilterDialogOpening` event will be triggered. At that point, based on the boolean value, we have set the height and width of the **CustomerID** and **OrderDate** columns using the CSS style in the following sample.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" AllowFiltering="true" AllowPaging="true" DataSource="@GridData">
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
    <GridEvents FilterDialogOpening="FilterDialogOpeningHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="120"> </GridColumn>

    </GridColumns>
</SfGrid>

@if (IsLarge)
{
    <style>
        #Grid .e-excelfilter.e-popup.e-popup-open {
            height: 400px;
            width: 350px !important;
        }
    </style>
}
@if (IsSmall)
{
    <style>
        #Grid .e-excelfilter.e-popup.e-popup-open {
            height: 450px;
            width: 280px !important;
        }
    </style>
}

@code {

    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }
    public bool IsLarge { get; set; } = false;
    public bool IsSmall { get; set; } = false;

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public void FilterDialogOpeningHandler(FilterDialogOpeningEventArgs args)
    {
        if (args.ColumnName == "CustomerID")
        {
            IsLarge = true;
            IsSmall = false;
        }
        else if (args.ColumnName == "OrderDate")
        {
            IsSmall = true;
            IsLarge = false;
        }
        else
        {
            IsLarge = false;
            IsSmall = false;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}

    public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10248;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", new DateTime(1996, 07, 06), 32.38));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", new DateTime(1996, 07, 06), 45.78));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", new DateTime(1996, 07, 06), 112.48));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", new DateTime(1996, 07, 06), 33.45));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBpZBDBCFDseVPP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**3.Customize filter icon for filtered columns**

After filtering the column, the Grid will display the in-built filtered icon with predefined styles by default. The filtered icon can also be customized using <b>.e-grid .e-filtered::before</b> class.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" AllowFiltering="true" AllowPaging="true" DataSource="@GridData">
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="120"> </GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-filtered::before {
        color: red;               // set the color to filtered icon.
        font-size: medium;        // set the font-size to filtered icon.
    }
</style>

@code {

    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }

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

    public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10248;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", new DateTime(1996, 07, 06), 32.38));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", new DateTime(1996, 07, 06), 45.78));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", new DateTime(1996, 07, 06), 112.48));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", new DateTime(1996, 07, 06), 33.45));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

## Add current selection to filter

By default, the CheckBox/Excel filter can only filter the selected items. If filtering is done multiple times on the same column, the previously filtered values in the column will be cleared. Now, it is possible to retain those previous values by using the "Add current selection to filter" option. This checkbox is displayed when data is searched in the search bar of the CheckBox or Excel filter type.


The following image describes the above mentioned behavior.

![Add current selection to filter in Blazor DataGrid.](./images/blazor-datagrid-add-current-selection-to-filter.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBfNLDBsuTLPqvx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.