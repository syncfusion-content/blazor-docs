---
layout: post
title: Virtualization in Blazor DataGrid | Syncfusion
description: Learn how to implement virtualization in the Syncfusion Blazor DataGrid, including virtual scrolling, paging, and performance optimization techniques.
platform: Blazor
control: DataGrid
documentation: ug
---

# Virtual scrolling in Blazor DataGrid

The virtual scrolling feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid efficiently handles large datasets by rendering only the rows currently visible in the viewport instead of the entire data source. This reduces DOM size, improves responsiveness, and lowers initial load time for datasets with thousands of records.

To learn about `virtualization` in the Grid, watch the following video:

{% youtube "youtube:https://www.youtube.com/watch?v=GrxmYYQPJPE"%}

## Row virtualization

Row virtualization is a technique that optimizes rendering performance for large datasets in data grids. Instead of loading all rows at once, it dynamically loads and renders only the rows visible within the viewport during vertical scrolling. This approach reduces the initial load time and memory usage, making it a more efficient alternative to traditional paging.

To configure row virtualization, set [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) to `true` and define a fixed content height using the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) property. The number of rendered records is implicitly determined by the content height. Optionally, you can influence the visible count using [GridPageSettings.PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize). Data is cached and reused while scrolling.

The following example enables row virtualization using the `EnableVirtualization` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@TaskData" Height="300" EnableVirtualization="true">
    <GridPageSettings PageSize="50"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(TaskDetails.TaskID) HeaderText="TaskID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Engineer) HeaderText="Engineer" Width="150"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Designation) HeaderText="Designation" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Estimation) HeaderText="Estimation" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Status) HeaderText="Status" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<TaskDetails> TaskData { get; set; }
    protected override void OnInitialized()
    {
        TaskData = TaskDetails.GenerateData(1000);
    }  
}

{% endhighlight %}

{% highlight cs tabtitle="TaskDetails.cs" %}

public class TaskDetails
{
    public static List<TaskDetails> GenerateData(int count)
    {
        var names = new List<string> { "TOM", "Hawk", "Jon", "Chandler", "Monica", "Rachel", "Phoebe", "Gunther", "Ross", "Geller", "Joey", "Bing", "Tribbiani", "Janice", "Bong", "Perk", "Green", "Ken", "Adams" };
        var hours = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var designations = new List<string> { "Manager", "Engineer 1", "Engineer 2", "Developer", "Tester" };
        var statusValues = new List<string> { "Completed", "Open", "In Progress", "Review", "Testing" };
        var random = new Random();
        var result = new List<TaskDetails>();
        // Generate random data.
        for (int i = 0; i < count; i++)
        {
            result.Add(new TaskDetails
            {
                TaskID = i + 1,
                Engineer = names[random.Next(names.Count)],
                Designation = designations[random.Next(designations.Count)],
                Estimation = hours[random.Next(hours.Count)],
                Status = statusValues[random.Next(statusValues.Count)]
            });
        }
        return result;
    }
    public int TaskID { get; set; }
    public string Engineer { get; set; }
    public string Designation { get; set; }
    public int Estimation { get; set; }
    public string Status { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXreXrDghESsUlpk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Render buffered data using Overscan count

The [OverscanCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_OverscanCount) property in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid improves perceived scrolling performance by pre-rendering a buffer of rows before and after the visible viewport. This reduces the frequency of data fetches and DOM updates for smoother scrolling, and applies during both initial rendering and virtual scrolling.

The following example set `OverscanCount` to `5`, which preloaded five additional rows before and after the viewport.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="315" OverscanCount="5" EnableVirtualization="true" EnableColumnVirtualization="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Verified) HeaderText="Verified" Type="ColumnType.Boolean" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }   
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, int EmployeeID, DateTime OrderDate, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime ShippedDate, bool Verified)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.EmployeeID = EmployeeID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.ShippedDate = ShippedDate;
        this.Verified = Verified;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            int Code = 10247;
            for (int i = 1; i < 500; i++)
            {
                order.Add(new OrderDetails(Code + 1, "VINET", i + 0, new DateTime(1991, 05, 15), 32.38, "Denmark", "Berlin", "Kirchgasse 6", new DateTime(1996, 7, 16), false));
                order.Add(new OrderDetails(Code + 2, "HANAR", i + 2, new DateTime(1990, 04, 04), 58.17, "Brazil", "Madrid", "Avda. Azteca 123", new DateTime(1996, 9, 11), true));
                order.Add(new OrderDetails(Code + 3, "TOMSP", i + 1, new DateTime(1957, 11, 30), 41.34, "Germany", "Cholchester", "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", new DateTime(1996, 10, 7), true));
                order.Add(new OrderDetails(Code + 4, "VICTE", i + 3, new DateTime(1930, 10, 22), 55.09, "Austria", "Marseille", "Magazinweg 7", new DateTime(1996, 12, 30), false));
                order.Add(new OrderDetails(Code + 5, "SUPRD", i + 4, new DateTime(1953, 02, 18), 22.98, "Switzerland", "Tsawassen", "1029 - 12th Ave. S.", new DateTime(1997, 12, 3), true));
                Code += 5;
            }
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime ShippedDate { get; set; }
    public bool Verified { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBeDLNqVYqUifpB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The `OverscanCount` property supports both local and remote data.

### Limitations

* Row virtual scrolling is not compatible with:
	1. Batch editing
	2. Detail template
	3. Row template
	4. Autofill
	5. Hierarchy Grid
* With row virtual scrolling, copy-paste and drag-and-drop apply only to items within the current viewport.
* Cell-based selection is not supported for row virtual scrolling.
* Variable row heights in template columns—where each row has a different height—are not supported.
* Group expand/collapse state is not persisted.
* Due to browser element height limits, the maximum number of records is bounded by browser capabilities.
* Grid content height is calculated from row height and total record count; features that change row height (such as text wrapping) are not supported.
* To increase row height while keeping all rows uniform, specify a fixed height:

    ```css
    .e-grid .e-row {
        height: 2em;
    }
    ```

* Because data is virtualized, aggregate and group totals reflect the current view items.
* For smooth scrolling, the page size should be at least two times the number of visible rows; otherwise, the Grid determines an appropriate size.
* A static height is required for the component or its parent container when using row virtualization. Using 100% height requires both the component and its parent to have defined heights.

## Column virtualization

Column virtualization in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid improves performance when many columns are present by rendering only the columns visible in the viewport. As the user scrolls horizontally, additional columns are loaded dynamically. This reduces initial render time and memory usage.

Enable it by setting [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) to `true`. For predictable behavior, assign explicit widths to columns (see [GridColumn.Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width)).

The following example enables column virtualization using the `EnableColumnVirtualization` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="GridData" Height="300px" EnableColumnVirtualization="true">
    <GridColumns>
        <GridColumn Field=@nameof(VirtualData.SNo) HeaderText="S.No" Width="140"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD1) HeaderText="Player Name" Width="140"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD2) HeaderText="Year" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD3) HeaderText="Stint" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD4) HeaderText="TMID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD5) HeaderText="LGID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD6) HeaderText="GP" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD7) HeaderText="GS" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD8) HeaderText="Minutes" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD9) HeaderText="Points" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD10) HeaderText="oRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD11) HeaderText="dRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD12) HeaderText="Rebounds" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD13) HeaderText="Assists" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD14) HeaderText="Steals" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD15) HeaderText="Blocks" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD16) HeaderText="Turnovers" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD17) HeaderText="PF" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD18) HeaderText="fgAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD19) HeaderText="fgMade" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD20) HeaderText="ftAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD21) HeaderText="ftMade" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD22) HeaderText="ThreeAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD23) HeaderText="ThreeMade" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD24) HeaderText="PostGP" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD25) HeaderText="PostGS" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD26) HeaderText="PostMinutes" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD27) HeaderText="PostPoints" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD28) HeaderText="PostoRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD29) HeaderText="PostdRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD30) HeaderText="PostRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<VirtualData> GridData { get; set; }
    protected override void OnInitialized()
    {
        GridData = VirtualData.GenerateData();
    }   
}

{% endhighlight %}

{% highlight cs tabtitle="VirtualData.cs" %}

public class VirtualData
{
    public VirtualData(int sNo, string field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9, int field10, int field11, int field12, int field13, int field14, int field15, int field16, int field17, int field18, int field19, int field20, int field21, int field22, int field23, int field24, int field25, int field26, int field27, int field28, int field29, int field30)
    {
        SNo = sNo;
        FIELD1 = field1;
        FIELD2 = field2;
        FIELD3 = field3;
        FIELD4 = field4;
        FIELD5 = field5;
        FIELD6 = field6;
        FIELD7 = field7;
        FIELD8 = field8;
        FIELD9 = field9;
        FIELD10 = field10;
        FIELD11 = field11;
        FIELD12 = field12;
        FIELD13 = field13;
        FIELD14 = field14;
        FIELD15 = field15;
        FIELD16 = field16;
        FIELD17 = field17;
        FIELD18 = field18;
        FIELD19 = field19;
        FIELD20 = field20;
        FIELD21 = field21;
        FIELD22 = field22;
        FIELD23 = field23;
        FIELD24 = field24;
        FIELD25 = field25;
        FIELD26 = field26;
        FIELD27 = field27;
        FIELD28 = field28;
        FIELD29 = field29;
        FIELD30 = field30;
    }    
    public static List<VirtualData> GenerateData()
    {
        var virtualData = new List<VirtualData>();
        var random = new Random();
        var names = new[] {
            "hardire", "abramjo01", "aubucch01", "Hook", "Rumpelstiltskin", "Belle", "Emma", "Regina", "Aurora", "Elsa", 
            "Anna", "Snow White", "Prince Charming", "Cora", "Zelena", "August", "Mulan", "Graham", "Discord", "Will", 
            "Robin Hood", "Jiminy Cricket", "Henry", "Neal", "Red", "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", 
            "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan", "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", 
            "Abdisalam", "Abdul", "Abdul-Aziz", "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", 
            "Abdul-Majeed", "Abdulmalik", "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", 
            "Abhinav", "Abhisumant", "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", 
            "Addison", "Addisson", "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", 
            "Adrien", "Aedan", "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", 
            "Aiadan", "Aidan", "Aiden", "Aiden-Jack", "Aiden-Vee"
        };
        for (var i = 0; i < 1000; i++)
        {
            virtualData.Add(new VirtualData(
                i + 1,
                names[random.Next(names.Length)],
                1967 + (i % 10),
                random.Next(200),
                random.Next(100),
                random.Next(2000),
                random.Next(1000),
                random.Next(100),
                random.Next(10),
                random.Next(10),
                random.Next(100),
                random.Next(100),
                random.Next(1000),
                random.Next(10),
                random.Next(10),
                random.Next(1000),
                random.Next(200),
                random.Next(300),
                random.Next(400),
                random.Next(500),
                random.Next(700),
                random.Next(800),
                random.Next(1000),
                random.Next(2000),
                random.Next(150),
                random.Next(1000),
                random.Next(100),
                random.Next(400),
                random.Next(600),
                random.Next(500),
                random.Next(300)
            ));
        }
        return virtualData;
    }
    public int SNo { get; set; }
    public string FIELD1 { get; set; }
    public int FIELD2 { get; set; }
    public int FIELD3 { get; set; }
    public int FIELD4 { get; set; }
    public int FIELD5 { get; set; }
    public int FIELD6 { get; set; }
    public int FIELD7 { get; set; }
    public int FIELD8 { get; set; }
    public int FIELD9 { get; set; }
    public int FIELD10 { get; set; }
    public int FIELD11 { get; set; }
    public int FIELD12 { get; set; }
    public int FIELD13 { get; set; }
    public int FIELD14 { get; set; }
    public int FIELD15 { get; set; }
    public int FIELD16 { get; set; }
    public int FIELD17 { get; set; }
    public int FIELD18 { get; set; }
    public int FIELD19 { get; set; }
    public int FIELD20 { get; set; }
    public int FIELD21 { get; set; }
    public int FIELD22 { get; set; }
    public int FIELD23 { get; set; }
    public int FIELD24 { get; set; }
    public int FIELD25 { get; set; }
    public int FIELD26 { get; set; }
    public int FIELD27 { get; set; }
    public int FIELD28 { get; set; }
    public int FIELD29 { get; set; }
    public int FIELD30 { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLoZWBlzonBSEEX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Column virtualization with row virtualization

Column virtualization in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid renders only the columns currently visible in the viewport and loads additional columns as the user scrolls horizontally. This technique improves performance and reduces initial render time, especially when working with a large number of columns.

[EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization): Renders only the visible rows. Additional rows are loaded dynamically during vertical scrolling.

[EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization): Renders only the visible columns. Additional columns are loaded dynamically during horizontal scrolling.

Enabling both features together significantly improves the responsiveness and scalability of the Grid, even when working with thousands of rows and hundreds of columns.

The following example demonstrates both features enabled:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="400" EnableVirtualization="true" EnableColumnVirtualization="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Verified) HeaderText="Verified" Type="ColumnType.Boolean" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }   
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, int EmployeeID, DateTime OrderDate, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime ShippedDate, bool Verified)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.EmployeeID = EmployeeID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.ShippedDate = ShippedDate;
        this.Verified = Verified;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            int Code = 10247;
            for (int i = 1; i < 500; i++)
            {
                order.Add(new OrderDetails(Code + 1, "VINET", i + 0, new DateTime(1991, 05, 15), 32.38, "Denmark", "Berlin", "Kirchgasse 6", new DateTime(1996, 7, 16), false));
                order.Add(new OrderDetails(Code + 2, "HANAR", i + 2, new DateTime(1990, 04, 04), 58.17, "Brazil", "Madrid", "Avda. Azteca 123", new DateTime(1996, 9, 11), true));
                order.Add(new OrderDetails(Code + 3, "TOMSP", i + 1, new DateTime(1957, 11, 30), 41.34, "Germany", "Cholchester", "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", new DateTime(1996, 10, 7), true));
                order.Add(new OrderDetails(Code + 4, "VICTE", i + 3, new DateTime(1930, 10, 22), 55.09, "Austria", "Marseille", "Magazinweg 7", new DateTime(1996, 12, 30), false));
                order.Add(new OrderDetails(Code + 5, "SUPRD", i + 4, new DateTime(1953, 02, 18), 22.98, "Switzerland", "Tsawassen", "1029 - 12th Ave. S.", new DateTime(1997, 12, 3), true));
                Code += 5;
            }
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime ShippedDate { get; set; }
    public bool Verified { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjLIZrZgBlddsUQU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Column virtualization with paging

Column virtualization renders only the columns visible in the viewport, while `paging` limits the number of rows displayed per page.

Enabling both features reduces memory usage and improves initial render time when working with large grids containing many columns and rows.

To configure this setup, set the following properties to true:

* [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) – Enables rendering of only visible columns.
* [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) – Enables paging to limit the number of rows per page.

The following example demonstrates enabling both column virtualization and paging:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="400" AllowPaging="true" EnableColumnVirtualization="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Verified) HeaderText="Verified" Type="ColumnType.Boolean" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }   
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, int EmployeeID, DateTime OrderDate, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime ShippedDate, bool Verified)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.EmployeeID = EmployeeID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.ShippedDate = ShippedDate;
        this.Verified = Verified;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            int Code = 10247;
            for (int i = 1; i < 500; i++)
            {
                order.Add(new OrderDetails(Code + 1, "VINET", i + 0, new DateTime(1991, 05, 15), 32.38, "Denmark", "Berlin", "Kirchgasse 6", new DateTime(1996, 7, 16), false));
                order.Add(new OrderDetails(Code + 2, "HANAR", i + 2, new DateTime(1990, 04, 04), 58.17, "Brazil", "Madrid", "Avda. Azteca 123", new DateTime(1996, 9, 11), true));
                order.Add(new OrderDetails(Code + 3, "TOMSP", i + 1, new DateTime(1957, 11, 30), 41.34, "Germany", "Cholchester", "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", new DateTime(1996, 10, 7), true));
                order.Add(new OrderDetails(Code + 4, "VICTE", i + 3, new DateTime(1930, 10, 22), 55.09, "Austria", "Marseille", "Magazinweg 7", new DateTime(1996, 12, 30), false));
                order.Add(new OrderDetails(Code + 5, "SUPRD", i + 4, new DateTime(1953, 02, 18), 22.98, "Switzerland", "Tsawassen", "1029 - 12th Ave. S.", new DateTime(1997, 12, 3), true));
                Code += 5;
            }
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime ShippedDate { get; set; }
    public bool Verified { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVejhtAVPeiBUyd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Column [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) is required for column virtualization. If a column’s width is not defined, the Grid considers it as `200px`.
> * The collapsed/expanded state of grouped data persists only for local data while scrolling.

### Limitations 

* With column virtualization, column width must be in pixels; percentage values are not supported.
* Selected column details are retained only within the current viewport; selection for off-screen columns is not preserved.
* Cell selection is not supported with column virtualization.
* Ctrl + Home and Ctrl + End keyboard shortcuts are not supported with column virtualization.
* The following features work within the viewport with column virtualization:
   1. Column resizing
   2. Column chooser
   3. Auto-fit
   4. Clipboard
   5. Column menu – Column chooser, AutofitAll
* Column virtual scrolling is not compatible with:
    1. Grouping
    2. Batch editing
    3. Column with infinite scrolling
    4. Stacked header
    5. Row template
    6. Detail template
    7. Hierarchy Grid
    8. Autofill

## Enable cell placeholder during Virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers an option to display cell placeholders while new data is being loaded during row or column virtualization. This feature improves user experience by showing a visual indicator (loading placeholder) in grid cells while data is being fetched. It is especially beneficial when working with large datasets or when virtualization is used to load data dynamically as scrolling occurs.

Set [EnableVirtualMaskRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualMaskRow) to `true` to reuse DOM elements and show placeholders until the incoming data is rendered.

This requires enabling either row virtualization ([EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization)) or column virtualization ([EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization)).

Here’s an example demonstrating placeholders with both row and column virtualization enabled:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="400" RowHeight="38" EnableVirtualMaskRow="true" EnableVirtualization="true" EnableColumnVirtualization="true">
    <GridPageSettings PageSize="32"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Verified) HeaderText="Verified" Type="ColumnType.Boolean" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }   
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, int EmployeeID, DateTime OrderDate, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime ShippedDate, bool Verified)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.EmployeeID = EmployeeID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.ShippedDate = ShippedDate;
        this.Verified = Verified;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            int Code = 10247;
            for (int i = 1; i < 10000; i++)
            {
                order.Add(new OrderDetails(Code + 1, "VINET", i + 0, new DateTime(1991, 05, 15), 32.38, "Denmark", "Berlin", "Kirchgasse 6", new DateTime(1996, 7, 16), false));
                order.Add(new OrderDetails(Code + 2, "HANAR", i + 2, new DateTime(1990, 04, 04), 58.17, "Brazil", "Madrid", "Avda. Azteca 123", new DateTime(1996, 9, 11), true));
                order.Add(new OrderDetails(Code + 3, "TOMSP", i + 1, new DateTime(1957, 11, 30), 41.34, "Germany", "Cholchester", "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", new DateTime(1996, 10, 7), true));
                order.Add(new OrderDetails(Code + 4, "VICTE", i + 3, new DateTime(1930, 10, 22), 55.09, "Austria", "Marseille", "Magazinweg 7", new DateTime(1996, 12, 30), false));
                order.Add(new OrderDetails(Code + 5, "SUPRD", i + 4, new DateTime(1953, 02, 18), 22.98, "Switzerland", "Tsawassen", "1029 - 12th Ave. S.", new DateTime(1997, 12, 3), true));
                Code += 5;
            }
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime ShippedDate { get; set; }
    public bool Verified { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXroDWBkCQohrFJy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> For a better experience, define both [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) and [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight).

## Frozen columns virtualization

Frozen columns virtualization in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables efficient rendering of frozen and movable columns alongside row virtualization. Frozen columns remain fixed while movable columns and rows are virtualized to ensure smooth horizontal and vertical scrolling.

**Column Virtualization:** Renders only visible columns while keeping frozen columns fixed in place.

**Row Virtualization:** Renders only visible rows and shows placeholders during data load when enabled.

When both are enabled, cell placeholders appear for rows and columns until data is loaded.

To enable frozen columns with virtualization:

**Define Frozen Columns:** Set [GridColumn.Freeze](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Freeze) to Left or Right for desired columns and enable [IsFrozen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsFrozen).

**Enable Virtualization:** Turn on both [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) and [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization).

Here's an example demonstrating frozen columns with row and column virtualization:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="GridData" Height="300px" EnableHover="false" RowHeight="38" EnableVirtualization="true" EnableColumnVirtualization="true" EnableVirtualMaskRow="true">
    <GridPageSettings PageSize="40"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(VirtualData.FIELD1) HeaderText="Player Name" IsFrozen="true" Freeze="FreezeDirection.Left" Width="140"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD2) HeaderText="Year" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD3) HeaderText="Stint" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD4) HeaderText="TMID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD5) HeaderText="LGID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD6) HeaderText="GP" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD7) HeaderText="GS" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD8) HeaderText="Minutes" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD9) HeaderText="Points" IsFrozen="true" Freeze="FreezeDirection.Right" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD10) HeaderText="oRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD11) HeaderText="dRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD12) HeaderText="Rebounds" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD13) HeaderText="Assists" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD14) HeaderText="Steals" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD15) HeaderText="Blocks" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD16) HeaderText="Turnovers" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD17) HeaderText="PF" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD18) HeaderText="fgAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD19) HeaderText="fgMade" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD20) HeaderText="ftAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD21) HeaderText="ftMade" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD22) HeaderText="ThreeAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD23) HeaderText="ThreeMade" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD24) HeaderText="PostGP" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD25) HeaderText="PostGS" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD26) HeaderText="PostMinutes" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD27) HeaderText="PostPoints" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD28) HeaderText="PostoRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD29) HeaderText="PostdRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD30) HeaderText="PostRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<VirtualData> GridData { get; set; }
    protected override void OnInitialized()
    {
        GridData = VirtualData.GenerateData();
    }   
}

{% endhighlight %}

{% highlight cs tabtitle="VirtualData.cs" %}

public class VirtualData
{
    public VirtualData(int sNo, string field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9, int field10, int field11, int field12, int field13, int field14, int field15, int field16, int field17, int field18, int field19, int field20, int field21, int field22, int field23, int field24, int field25, int field26, int field27, int field28, int field29, int field30)
    {
        SNo = sNo;
        FIELD1 = field1;
        FIELD2 = field2;
        FIELD3 = field3;
        FIELD4 = field4;
        FIELD5 = field5;
        FIELD6 = field6;
        FIELD7 = field7;
        FIELD8 = field8;
        FIELD9 = field9;
        FIELD10 = field10;
        FIELD11 = field11;
        FIELD12 = field12;
        FIELD13 = field13;
        FIELD14 = field14;
        FIELD15 = field15;
        FIELD16 = field16;
        FIELD17 = field17;
        FIELD18 = field18;
        FIELD19 = field19;
        FIELD20 = field20;
        FIELD21 = field21;
        FIELD22 = field22;
        FIELD23 = field23;
        FIELD24 = field24;
        FIELD25 = field25;
        FIELD26 = field26;
        FIELD27 = field27;
        FIELD28 = field28;
        FIELD29 = field29;
        FIELD30 = field30;
    }    
    public static List<VirtualData> GenerateData()
    {
        var virtualData = new List<VirtualData>();
        var random = new Random();
        var names = new[] {
            "hardire", "abramjo01", "aubucch01", "Hook", "Rumpelstiltskin", "Belle", "Emma", "Regina", "Aurora", "Elsa", 
            "Anna", "Snow White", "Prince Charming", "Cora", "Zelena", "August", "Mulan", "Graham", "Discord", "Will", 
            "Robin Hood", "Jiminy Cricket", "Henry", "Neal", "Red", "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", 
            "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan", "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", 
            "Abdisalam", "Abdul", "Abdul-Aziz", "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", 
            "Abdul-Majeed", "Abdulmalik", "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", 
            "Abhinav", "Abhisumant", "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", 
            "Addison", "Addisson", "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", 
            "Adrien", "Aedan", "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", 
            "Aiadan", "Aidan", "Aiden", "Aiden-Jack", "Aiden-Vee"
        };
        for (var i = 0; i < 1000; i++)
        {
            virtualData.Add(new VirtualData(
                i + 1,
                names[random.Next(names.Length)],
                1967 + (i % 10),
                random.Next(200),
                random.Next(100),
                random.Next(2000),
                random.Next(1000),
                random.Next(100),
                random.Next(10),
                random.Next(10),
                random.Next(100),
                random.Next(100),
                random.Next(1000),
                random.Next(10),
                random.Next(10),
                random.Next(1000),
                random.Next(200),
                random.Next(300),
                random.Next(400),
                random.Next(500),
                random.Next(700),
                random.Next(800),
                random.Next(1000),
                random.Next(2000),
                random.Next(150),
                random.Next(1000),
                random.Next(100),
                random.Next(400),
                random.Next(600),
                random.Next(500),
                random.Next(300)
            ));
        }
        return virtualData;
    }
    public int SNo { get; set; }
    public string FIELD1 { get; set; }
    public int FIELD2 { get; set; }
    public int FIELD3 { get; set; }
    public int FIELD4 { get; set; }
    public int FIELD5 { get; set; }
    public int FIELD6 { get; set; }
    public int FIELD7 { get; set; }
    public int FIELD8 { get; set; }
    public int FIELD9 { get; set; }
    public int FIELD10 { get; set; }
    public int FIELD11 { get; set; }
    public int FIELD12 { get; set; }
    public int FIELD13 { get; set; }
    public int FIELD14 { get; set; }
    public int FIELD15 { get; set; }
    public int FIELD16 { get; set; }
    public int FIELD17 { get; set; }
    public int FIELD18 { get; set; }
    public int FIELD19 { get; set; }
    public int FIELD20 { get; set; }
    public int FIELD21 { get; set; }
    public int FIELD22 { get; set; }
    public int FIELD23 { get; set; }
    public int FIELD24 { get; set; }
    public int FIELD25 { get; set; }
    public int FIELD26 { get; set; }
    public int FIELD27 { get; set; }
    public int FIELD28 { get; set; }
    public int FIELD29 { get; set; }
    public int FIELD30 { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhIDshOhHwVXCEM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Scroll the content by external button

In certain scenarios, it may be necessary to programmatically scroll the Grid content into view rather than relying on manual scrolling. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the [ScrollIntoViewAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ScrollIntoViewAsync_System_Int32_System_Int32_System_Int32_) method, which enables scrolling to a specific row or column by passing their respective indices as parameters.
To ensure smooth scrolling behavior, virtualization must be enabled in the Grid.

* **Horizontal scrolling:** enable both [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) and [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization).
* **Vertical scrolling:** enable [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization).

The following example shows how to call `ScrollIntoViewAsync` from external buttons to navigate to a specific row or column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs

<div style="margin-bottom:5px">
    <label style="margin: 5px 5px 0 0"> Enter Column Index:</label>
    <SfNumericTextBox CssClass="e-outline" @bind-Value="@ColumnIndexValue" Max="10" Width="150px"></SfNumericTextBox>
    <SfButton @onclick="Scroll" Content="Scroll Horizontally"></SfButton>
    <label style="margin: 5px 5px 0 0"> Enter Row Index:</label>
    <SfNumericTextBox CssClass="e-outline" @bind-Value="@RowIndexValue" Max="1000" Width="150px"></SfNumericTextBox>
    <SfButton @onclick="Scroll" Content="Scroll Vertically"></SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" Height="315" EnableVirtualization="true" EnableColumnVirtualization="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Verified) HeaderText="Verified" Type="ColumnType.Boolean" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public int ColumnIndexValue { get; set; } = 1;
    public int RowIndexValue { get; set; } = 1;
    public void Scroll()
    {
        Grid.ScrollIntoViewAsync(ColumnIndexValue, RowIndexValue);
    } 
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, int EmployeeID, DateTime OrderDate, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime ShippedDate, bool Verified)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.EmployeeID = EmployeeID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.ShippedDate = ShippedDate;
        this.Verified = Verified;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            int Code = 10247;
            for (int i = 1; i < 1000; i++)
            {
                order.Add(new OrderDetails(Code + 1, "VINET", i + 0, new DateTime(1991, 05, 15), 32.38, "Denmark", "Berlin", "Kirchgasse 6", new DateTime(1996, 7, 16), false));
                order.Add(new OrderDetails(Code + 2, "HANAR", i + 2, new DateTime(1990, 04, 04), 58.17, "Brazil", "Madrid", "Avda. Azteca 123", new DateTime(1996, 9, 11), true));
                order.Add(new OrderDetails(Code + 3, "TOMSP", i + 1, new DateTime(1957, 11, 30), 41.34, "Germany", "Cholchester", "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", new DateTime(1996, 10, 7), true));
                order.Add(new OrderDetails(Code + 4, "VICTE", i + 3, new DateTime(1930, 10, 22), 55.09, "Austria", "Marseille", "Magazinweg 7", new DateTime(1996, 12, 30), false));
                order.Add(new OrderDetails(Code + 5, "SUPRD", i + 4, new DateTime(1953, 02, 18), 22.98, "Switzerland", "Tsawassen", "1029 - 12th Ave. S.", new DateTime(1997, 12, 3), true));
                Code += 5;
            }
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime ShippedDate { get; set; }
    public bool Verified { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrotMgNKGXhbHbT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Refresh virtualized Grid externally

The [UpdatePageSizeAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UpdatePageSizeAsync_System_Int32_System_Int32_) method in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid refreshes the virtualized Grid’s PageSize externally by using the specified Grid height or container height along with the row height. This method calculates the `PageSize` programmatically and updates the Grid with the new value.

To enable external refresh of the virtualized Grid, set [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization)  to `true`.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
<SfButton Content="Refresh" OnClick="UpdatePageSize"></SfButton>
<SfGrid DataSource="@GridData" Height="500" @ref="Grid" EnableVirtualization="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShippedDate) HeaderText="Shipped Date" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code{
    public List<Order> GridData { get; set; }
    public SfGrid<Order> Grid { get; set; }
    protected override void OnInitialized()
    {
        List<Order> Order = new List<Order>();
        int Code = 10000;
        for (int i = 1; i < 10000; i++)
        {
            Order.Add(new Order(Code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
            Order.Add(new Order(Code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
            Order.Add(new Order(Code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolívar #65-98 Llano Largo"));
            Order.Add(new Order(Code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
            Order.Add(new Order(Code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
            Code += 5;
        }
        GridData = Order;
    }
    public class Order
    {
        public Order(int OrderID, string CustomerID, int EmployeeID, double Freight, bool Verified, DateTime OrderDate, string ShipCity, string ShipCountry, DateTime ShippedDate, string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            this.Freight = Freight;
            this.Verified = Verified;
            this.OrderDate = OrderDate;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
            this.ShippedDate = ShippedDate;
            this.ShipAddress = ShipAddress;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool Verified { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public string ShipAddress { get; set; }
    }
     public async Task UpdatePageSize()
    {
        await Grid.UpdatePageSizeAsync(800, 32);
    }
}
```

> If [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) is specified, the page size is calculated using the given row height; otherwise, it is determined from the Grid row’s offset height.

> Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour for a broad overview. Explore the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand data presentation and manipulation.

## See also

* [Row virtualization with Lazy load grouping in Grid](https://blazor.syncfusion.com/documentation/datagrid/lazy-load-grouping#lazy-load-grouping-with-virtual-scrolling)