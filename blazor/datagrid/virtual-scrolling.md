---
layout: post
title: Virtualization in Blazor DataGrid | Syncfusion
description: Learn all about virtualization in the Syncfusion Blazor DataGrid component, including virtual scrolling and paging.
platform: Blazor
control: DataGrid
documentation: ug
---

# Virtual scrolling in Blazor DataGrid

The virtual scrolling feature in the Syncfusion Blazor DataGrid allows you to efficiently handle and display large amounts of data without experiencing any [performance](https://www.syncfusion.com/blazor-components/blazor-datagrid/performance) degradation. It optimizes the rendering process by loading only the visible rows in the Grid viewport, rather than rendering the entire dataset at once. This is particularly useful when dealing with datasets containing thousands of records.

To learn about **Virtualization** in the Grid, you can check out this video.

{% youtube "youtube:https://www.youtube.com/watch?v=GrxmYYQPJPE"%}

## Row virtualization

Row virtualization is a feature in the Syncfusion Blazor DataGrid that allows you to load and render rows only within the content viewport. It provides an alternative to traditional paging, where data is dynamically loaded while scrolling vertically, rather than loading all the data at once. This is particularly useful when working with large datasets, as it improves performance and reduces the initial load time.

To set up row virtualization, define the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) property as **true** and specify the content height using the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) property in the Grid configuration.

The number of records displayed in the Grid is implicitly determined by the height of the content area. Additionally, you have the option to explicitly define the number of visible records using the [GridPageSettings.PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) property. The loaded data will be cached and reused when needed in the future.

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

The [OverscanCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_OverscanCount) property in the Syncfusion Blazor DataGrid is used to optimize scrolling performance by pre-rendering additional rows beyond the current viewport. It renders extra items in the DOM before and after the visible items (based on the page size) during virtual scrolling and initial rendering, which reduces the frequency of both data fetch requests and DOM rendering operations, resulting in a smoother scrolling experience.

By rendering extra rows before and after the visible area, `OverscanCount` helps buffer data, minimizing loading delays.

The following example demonstrates how to set the `OverscanCount` property to **5**, allowing five additional records to be preloaded before and after the current viewport.

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

### Limitation

* Row virtual scrolling is not compatible with the following feature
	1. Batch editing
	2. Detail template
	3. Row template
	4. Autofill
	5. Hierarchy Grid
* When row virtual scrolling is activated, compatibility for copy-paste and drag-and-drop operations is limited to the data items visible in the current viewport of the Grid.
* The cell-based selection is not supported for row virtual scrolling. 
* Using different row heights with a template column, when the template height differs for each row, is not supported.
* Group expand and collapse state will not be persisted.
* Due to the element height limitation in browsers, the maximum number of records loaded by the Grid is limited by the browser capability.
* The height of the Grid content is calculated using the row height and total number of records in the data source and hence features which changes row height such as text wrapping are not supported.
* If you want to increase the row height to accommodate the content then you can specify the row height as below to ensure all the table rows are in same height.

    ```css
    .e-grid .e-row {
        height: 2em;
    }
    ```
* Since data is virtualized in Grid, the aggregated information and total group items are displayed based on the current view items. 
* The page size provided must be two times larger than the number of visible rows in the Grid. If the page size is failed to meet this condition then the size will be determined by Grid.
* It is necessary to set a static height for the component or its parent container when using row virtualization. The 100% height will work only if the component height is set to 100%, and its parent container has a static height.

## Column virtualization

Column virtualization is a feature in the Syncfusion Blazor DataGrid that optimizes the rendering of columns by displaying only the columns currently within the viewport. It allows horizontal scrolling to view additional columns. This feature is particularly useful when dealing with Grids that have a large number of columns, as it helps improve performance and reduces the initial loading time.

To enable column virtualization, set the [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) property of the Grid to **true**. This configuration instructs the Grid to render only the columns visible in the viewport.

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

Column virtualization in Syncfusion Blazor DataGrid improves performance by rendering only the visible columns and enabling horizontal scrolling for large datasets. Similarly, row virtualization renders only the visible rows within the viewport, enabling smooth vertical scrolling when handling large datasets.

[EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization): Only the rows visible in the viewport are rendered. As the user scrolls vertically, more rows are dynamically loaded into the Grid.

[EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization): Only the columns visible in the viewport are rendered. As the user scrolls horizontally, more columns are dynamically loaded.

By enabling both features together, you can significantly enhance the responsiveness and usability of the Grid, even with thousands of rows and hundreds of columns.

The following example demonstrates how to enable both column and row virtualization in the Grid:

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

Column virtualization in the Syncfusion Blazor DataGrid improves performance by rendering only the columns that are currently visible in the viewport. As the user scrolls horizontally, additional columns are dynamically loaded.

When combined with paging, the Grid only loads a limited number of rows per page (based on the configured page size), while still rendering only the visible columns. This setup significantly reduces both memory usage and initial rendering time, especially when working with a large number of columns and rows.

To use column virtualization with paging, you must enable both the [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) and [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) properties of the Grid.

* `EnableColumnVirtualization` enables the rendering of only visible columns.

* `AllowPaging` allows the Grid to display data in pages, limiting the number of rows visible at once.

By combining these two properties, you can achieve optimized rendering for both columns and rows, ensuring a smooth user experience even with large datasets.

The following example demonstrates how to enable both column virtualization and paging in the Grid:

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

> * Column's [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Width) is required for column virtualization. If column's `Width` is not defined then Grid will consider its value as **200px**.
> * The collapsed/expanded state of grouped data will persist only for the local dataSource while scrolling.

### Limitations 

* While using column virtualization, column width should be in pixel. Percentage values are not accepted.
* Selected column details are retained only within the viewport. When the next set of columns is loaded, the selection for previously visible columns is lost.
* The cell selection is not supported for column virtualization.
* The **Ctrl + Home** and **Ctrl + End** keys are not supported when using column virtualization.
* The following features are compatible with column virtualization and work within the viewport:
   1. Column resizing
   2. Column chooser
   3. Auto-fit
   4. Clipboard
   5. Column menu - Column chooser, AutofitAll
* Column virtual scrolling is not compatible with the following feature:
    1. Grouping
    2. Batch editing
    3. Column with infinite scrolling
    4. Stacked header
    5. Row template
    6. Detail template
    7. Hierarchy Grid
    8. Autofill

## Enable cell placeholder during Virtualization

The Syncfusion Blazor DataGrid provides an option to render cell placeholders while new data is being loaded during row or column virtualization. This feature enhances the user experience by displaying a visual cue (a loading placeholder) in the Grid cells while new data is being fetched. It is particularly useful in scenarios where there is a large dataset or when virtualization is used to load data dynamically as the user scrolls through the Grid.

When the [EnableVirtualMaskRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualMaskRow) property is set to **true**, the Grid reuses the same DOM elements while scrolling and displays placeholder indicators in the cells until new data is fetched and rendered. This enhances perceived performance and provides a smoother, more responsive scrolling experience. To use this feature, you must also enable either:

* [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) for row virtualization, or
* [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) for column virtualization.

Here’s an example demonstrating how to enable cell placeholders during row and column virtualization:

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

> For a better experience, the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) property of the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html) class and the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property should be defined.

## Frozen columns virtualization

Frozen columns virtualization in Syncfusion Blazor DataGrid allows for the efficient rendering of both frozen and movable columns, along with row virtualization. This feature optimizes the Grid's performance by virtualizing both the rows and the movable columns while ensuring smooth scrolling and a seamless user experience.

**Column Virtualization:** This optimizes the horizontal scrolling experience by rendering only the visible columns and virtualizing the others. The frozen columns remain fixed in place while the movable columns are rendered dynamically as you scroll horizontally.

**Row Virtualization:** This ensures that only the rows within the current viewport are rendered, with placeholders shown for rows that are being dynamically loaded during scrolling.

When row virtualization and column virtualization are both enabled, cell placeholders are displayed in both rows and columns until the data has been loaded into the Grid.

To enable frozen columns with virtualization, follow these steps:

**Define Frozen Columns:** Set the [GridColumn.Freeze](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Freeze) property to **Right** or **Left** for the desired columns, and enable the [IsFrozen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsFrozen) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

**Enable Virtualization:** Enable both [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) for row virtualization and [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) for column virtualization to ensure a smooth experience when scrolling through large datasets.

Here's an example demonstrating how to enable frozen columns along with row and column virtualization in Grid:

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

In certain scenarios, you may want to programmatically scroll the Grid content into view instead of relying on manual scrolling. The Syncfusion Grid provides the [ScrollIntoViewAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ScrollIntoViewAsync_System_Int32_System_Int32_System_Int32_) method, which allows you to scroll to a specific row or column by passing their respective indices as parameters.

To enable smooth scrolling behavior, ensure that virtualization is enabled in the Grid:

* **Horizontal scrolling:** Set both [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) and [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) properties to **true**.
* **Vertical scrolling:** Set the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) property to **true** to enable row virtualization.

The following example demonstrates how to use the `ScrollIntoViewAsync` method with an external button to navigate to a specific row or column programmatically:

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

The [UpdatePageSizeAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UpdatePageSizeAsync_System_Int32_System_Int32_) method refreshes the virtualized Grid's [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) externally by using the specified Grid height or Grid container height and row height. This method calculates the Grid `PageSize` programmatically and refreshes the virtualized Grid with the newly calculated `PageSize`.

To refresh the virtualized Grid externally, set [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) to **true**.

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

> If [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) is specified, the page size is calculated based on the given row height. Otherwise, RowHeight will be determined from the offset height of the Grid row element.

> You can refer to our [Blazor Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Grid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.

## See also

* [Row virtualization with Lazy load grouping in Grid](https://blazor.syncfusion.com/documentation/datagrid/lazy-load-grouping#lazy-load-grouping-with-virtual-scrolling)