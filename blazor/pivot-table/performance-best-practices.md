---
layout: post
title: Performance tips for Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about best practices to improve the performance of the Syncfusion Blazor Pivot Table component and much more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Best practices to improve the performance of the Blazor Pivot Table

Performance optimization is crucial when working with large datasets in the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table](https://www.syncfusion.com/blazor-components). This documentation provides some best practices to empower your data analysis and enhance the user experience.

N> In Blazor, the framework takes about 0.06 milliseconds to render one component on the page. You can find more details at the official [documentation link](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-8.0).

## How do I improve the loading performance of the Pivot Table?

### Refer individual NuGet, Script and CSS

To enhance the performance of the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table](https://www.syncfusion.com/blazor-components) component during the initial render and specific UI interactions, it's recommended to utilize the individual NuGet package (Syncfusion.Blazor.PivotTable) along with the respective script and CSS files dedicated to this component.

In the bundled package (Syncfusion.Blazor), all components are included, resulting in a larger package size. With the inclusion of script and CSS files, the overall file size increases as they encompass the necessary resources for all Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components. Larger package, script, and CSS file sizes may lead to delays or performance issues during component rendering in certain scenarios compared to using individual packages, scripts, and CSS files.

Individual NuGet packages contain all required dependencies and resources for each component, including their script and CSS references. Therefore, it's preferable to reference the individual package.

Refer to the below documentation:
* [Individual NuGet package](https://blazor.syncfusion.com/documentation/pivot-table/getting-started-webapp)
* [Adding script and CSS](https://blazor.syncfusion.com/documentation/pivot-table/getting-started-webapp)

### Virtual scrolling

The virtual scrolling in the pivot table significantly improves performance, especially when handling large datasets, because it only renders the rows and columns related to the current viewport. The remaining data is loaded dynamically as you scroll, either vertically or horizontally. For more information on implementing virtual scrolling in the pivot table, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/virtual-scrolling).

### Paging

If your browser's maximum pixel height limits you from using the pivot table with virtual scrolling, we recommend utilizing the paging option instead. Similar to virtual scrolling, the paging option allows you to load a large amount of data, which can be displayed in the pivot table page-by-page. For more information on implementing paging in the pivot table, please refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/paging).

### Server-side engine

In contrast to the Blazor Server application, the Blazor WASM application operates on the client-side and has its own drawbacks. For example:

1. Connecting your WASM application to an external data source and fetching a large dataset (referred to as input data), such as one million records for the pivot table, may take considerable time due to network bandwidth limitations when transmitting data from server-side to client-side.

2. Moreover, while we use the same Pivot Table source code for deploying the component in both Server and WASM applications, the WASM framework exhibits slower performance. 

Therefore, we highly recommend using our server-side engine for rendering the Pivot Table with a large amount of data, hosted in the WASM application instead of the built-in engine.

Typically, in this approach, the pivot table component and its report are defined and often modified on the client-side (browser), while the pivot engine is implied and hosted in a dedicated web service (Web API) known as the server-side engine. Here, the server-side engine can directly connect to your data source, swiftly collect the input data (referred to as input raw data), and, based on the provided report by the pivot table through UI interactions periodically, the server-side engine performs all pivot-oriented calculations internally. It then transmits only aggregated data for pivot table display to the client-side (browser). This approach minimizes network bandwidth usage and enhances pivot table rendering, similar to the Blazor Server application.

In case a large amount of aggregated data is sent to the client-side from the web service (Web API), the server-side engine offers the option to enable virtual scrolling or paging. This feature generates aggregated data exclusively for the current viewport of the Pivot Table, further optimizing network bandwidth and rendering performance.

Additionally, the cache concept is implemented in the server-side engine to hold the pivot engine's instance based on the end-user GUID. This allows for quick retrieval, calculation, and re-sending of modified pivot data to the Pivot Table viewport, based on the UI action performed.

For more information on implementing the server-side engine in the pivot table, please refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/server-side-pivot-engine).

## How can I enhance the performance of the Pivot Table through data operations?

### Data compression

If your input data (referred to as input raw data) contains a large number of repeated records, the data compression option becomes particularly useful.

In this approach, based on the pivot report defined in the data source settings and with the data compression option enabled, all the input data is initially iterated. Repetitive records are then summarized, reducing the overall input data for all further pivot calculations. For example, if there are 1000 records with 400 records being repeated, data compression will clean up and result in 600 unique records for every future pivot calculations. Now, consider the impact with one million records and how useful it will be.

The limitation here is that during the initial rendering of the Pivot Table alone, data compression will work by taking slightly extra time to summarize and reduce overall input data. However, for subsequent uses, it will be very quick, with reduced input data. Nevertheless, it is more advantageous since it's a one-time process.

Additionally, it works with the virtual scrolling or paging option enabled as well.

N> If your input data has very few repeated records, we would not suggest this option.

For more information on implementing the data compression in the pivot table, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/virtual-scrolling#data-compression).

### Defer layout update

The Defer Layout Update feature in the pivot table allows end-users to perform various operations, such as adding, removing, and rearranging fields, filtering, sorting, changing aggregation types, and more, without immediately updating the pivot table. The efficiency of this process lies in allowing end-users to complete their modifications. The final application of these changes occurs when end-users click the **Apply** button in the Field List UI. This action triggers the pivot table to update based on the last modified report. By deferring the layout update until precisely requested, the Blazor Pivot Table remains unchanged initially, ensuring minimal resource utilization and avoiding frequent re-rendering until the end-user explicitly applies the modifications.

For more information on defer layout updates, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/defer-layout-update).

### Sorting

During the initial rendering phase, applying sorting to fields other than the string data type, particularly those with a large number of members, may lead to increased processing time for the pivot engine due to internal calculations. To enhance performance without compromising the final outcome, it is advisable to refrain from using sorting options at this stage. Alternatively, load the input raw data into the data source settings in the desired order for display in the pivot table.

Once the input raw data is arranged as needed and the pivot table is rendered, it is recommended to restrict the use of sorting operations for runtime performance optimization. This approach ensures efficient processing and responsive performance while still achieving the desired presentation in the pivot table.

### Member filtering

When working with large datasets, it's beneficial to set a display limit for members in the filter dialog UI. This allows the filter dialog to quickly show members up to the specified limit without facing performance issues. If there are more members beyond this limit, a message displaying the count of remaining members will appear at the bottom of the filter dialog UI. End users can then access the remaining members using the search option provided in the filter dialog during runtime. For detailed instructions on implementing the node limit in the filter dialog UI, refer to the documentation linked [here](https://blazor.syncfusion.com/documentation/pivot-table/filtering#performance-tips).

### Grouping

Using the pivot table's built-in grouping feature to group date, number, and string data type fields is not often recommended.

Here is an example below of how the [PivotViewGroupSetting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGroupSetting.html) tag has been used to configure grouping for the available fields using code-behind. The date and number grouping have been set to the fields "TimeLine" and "Id", respectively.

It obviously impacts the overall performance during pivot table rendering because it always consumes the input raw data, splits, reframes, and provides modified input raw data based on the fields in the report that will be used for further pivot calculations.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="GroupData" Width="1000" Height="600">
     <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Id"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="TimeLine"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="PowUnits"></PivotViewValue>
            <PivotViewValue Name="ProCost"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="ProCost" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        <PivotViewGroupSettings>
            <PivotViewGroupSetting Name="TimeLine" Type=GroupType.Date GroupInterval="new List<DateGroup> { DateGroup.Years, DateGroup.Months }"></PivotViewGroupSetting>
            <PivotViewGroupSetting Name="Id" Type=GroupType.Number RangeInterval=3></PivotViewGroupSetting>
        </PivotViewGroupSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    private List<GroupData> data { get; set; }

    protected override void OnInitialized()
    {
        data = GroupData.GetGroupData();
        // Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }

    public class GroupData
    {
        public int Id { get; set; }
        public DateTime TimeLine { get; set; }
        public string Sector { get; set; }
        public string EnerType { get; set; }
        public string EneSource { get; set; }
        public int PowUnits { get; set; }
        public int ProCost { get; set; }

        public static List<GroupData> GetGroupData()
        {
            List<GroupData> groupData = new List<GroupData>();
            groupData.Add(new GroupData
            {
                Id = 1001,
                TimeLine = new DateTime(2015,1,1),
                Sector = "Public Sector",
                EnerType = "Free Energy",
                EneSource = "Hydro-electric",
                PowUnits = 46,
                ProCost = 43
            });
            groupData.Add(new GroupData
            {
                Id = 1002,
                TimeLine = new DateTime(2015,1,2),
                Sector = "Private Sector",
                EnerType = "Free Energy",
                EneSource = "Geo-thermal",
                PowUnits = 30,
                ProCost = 29
            });
            groupData.Add(new GroupData
            {
                Id = 1003,
                TimeLine = new DateTime(2015,2,3),
                Sector = "Public Sector",
                EnerType = "Free Energy",
                EneSource = "Solar",
                PowUnits = 125,
                ProCost = 96
            });
            groupData.Add(new GroupData
            {
                Id = 1004,
                TimeLine = new DateTime(2015,2,4),
                Sector = "Private Sector",
                EnerType = "Free Energy",
                EneSource = "Wind",
                PowUnits = 215,
                ProCost = 123
            });
            groupData.Add(new GroupData
            {
                Id = 1005,
                TimeLine = new DateTime(2016,3,5),
                Sector = "Public Sector",
                EnerType = "Free Energy",
                EneSource = "Wind",
                PowUnits = 263,
                ProCost = 125
            });
            return groupData;
        }
    }
}
```

To avoid this performance constraint, we recommend passing the input raw data along with pre-processed group field sets based on your grouping needs. For example, if your input raw data has a date field "TimeLine" with the value "15/AUG/2019 03:41 PM" and you want to display it as the year and month alone, split out the date field as "TimeLine_Year" = "15/AUG/2019" for the year and "TimeLine_Month" = "15/AUG/2019" for the month. Further use the [PivotViewFormatSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFilterSettings.html) property to show these date fields with the chosen date format. Similarly, to group a number field, just alter its value based on your requirements (e.g., 1–5, 6–10).

Here's an example below of configuring grouping in your input raw data and assigning it to the pivot table's data source. In the code below, the fields "TimeLine_Year," "TimeLine_Month," and "Id" are created and updated in the provided input raw data and have been specified for the date and number grouping. Additionally, the date formatting has been applied to these specified date group fields using the [PivotViewFormatSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFilterSettings.html).

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="GroupData" Width="1000" Height="600">
     <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Id"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="TimeLine"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="PowUnits"></PivotViewValue>
            <PivotViewValue Name="ProCost"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFieldMapping>
            <PivotViewField Name="Id" DataType="number"></PivotViewField>
        </PivotViewFieldMapping>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="ProCost" Format="C"></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="TimeLine_Year" Type="FormatType.DateTime" Format="yyyy"></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="TimeLine_Month" Type="FormatType.DateTime" Format="MMM"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    private List<GroupData> data { get; set; } 
    
    protected override void OnInitialized()
    {
        data = GroupData.GetGroupData();
        // Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }

    public class GroupData
    {
        public string Id { get; set; }
        public DateTime TimeLine_Year { get; set; }
        public DateTime TimeLine_Month { get; set; }
        public string Sector { get; set; }
        public string EnerType { get; set; }
        public string EneSource { get; set; }
        public int PowUnits { get; set; }
        public int ProCost { get; set; }

        public static List<GroupData> GetGroupData()
        {
            List<GroupData> groupData = new List<GroupData>();
            groupData.Add(new GroupData
            {
                Id = "1001-1003",
                TimeLine_Year = new DateTime(2015,1,1),
                TimeLine_Month = new DateTime(2015,1,1),
                Sector = "Public Sector",
                EnerType = "Free Energy",
                EneSource = "Hydro-electric",
                PowUnits = 46,
                ProCost = 43
            });
            groupData.Add(new GroupData
            {
                Id = "1001-1003",
                TimeLine_Year = new DateTime(2015,1,2),
                TimeLine_Month = new DateTime(2015,1,1),
                Sector = "Private Sector",
                EnerType = "Free Energy",
                EneSource = "Geo-thermal",
                PowUnits = 30,
                ProCost = 29
            });
            groupData.Add(new GroupData
            {
                Id = "1001-1003",
                TimeLine_Year = new DateTime(2015,2,3),
                TimeLine_Month = new DateTime(2015,1,1),
                Sector = "Public Sector",
                EnerType = "Free Energy",
                EneSource = "Solar",
                PowUnits = 125,
                ProCost = 96
            });
            groupData.Add(new GroupData
            {
                Id = "1004-1006",
                TimeLine_Year = new DateTime(2015,2,4),
                TimeLine_Month = new DateTime(2015,1,1),
                Sector = "Private Sector",
                EnerType = "Free Energy",
                EneSource = "Wind",
                PowUnits = 215,
                ProCost = 123
            });
            groupData.Add(new GroupData
            {
                Id = "1004-1006",
                TimeLine_Year = new DateTime(2016,3,5),
                TimeLine_Month = new DateTime(2015,1,1),
                Sector = "Public Sector",
                EnerType = "Free Energy",
                EneSource = "Wind",
                PowUnits = 263,
                ProCost = 125
            });
            return groupData;
        }
    }
}
```

### Value filtering

The [value filtering](https://blazor.syncfusion.com/documentation/pivot-table/filtering#value-filtering) primarily operates on grand totals, meaning the filtering process considers entire rows and columns to match applied value conditions. For similar results with more flexibility and better performance, consider exploring our label filtering or member filtering options. These alternatives can yield comparable outcomes, particularly when dealing with large datasets. You can find more information on utilizing the [label filtering](https://blazor.syncfusion.com/documentation/pivot-table/filtering#label-filtering) or [member filtering](https://blazor.syncfusion.com/documentation/pivot-table/filtering#member-filtering) options in the documentation section dedicated to these features.

## How do I improve the scrolling performance of the Pivot Table?

### Virtual scrolling with single page mode

By default, the pivot table with virtual scrolling renders not only the current view page but also the previous and next pages. However, by using single-page mode along with virtual scrolling, only the rows and columns relevant to the current view page are rendered. This optimization significantly enhances the scrolling performance of the pivot table. For more information on implementing this feature, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/virtual-scrolling#single-page-mode).

### Limiting the component size

Each row and cell in the pivot table is treated as an individual Razor component. However, loading an extensive number of rows and columns into the current view can strain memory consumption and CPU processing. To avoid such performance impacts, load a smaller set of rows and columns in the pivot table by defining and limiting the pivot table using the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGridSettings.html#Syncfusion_Blazor_PivotView_PivotViewGridSettings_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGridSettings.html#Syncfusion_Blazor_PivotView_PivotViewGridSettings_Width) properties. For example, 600px * 1000px, respectively, with just the pivot table alone (that is, without the grouping bar, toolbar, and other additional UI elements).
       
N> Normally, pixel units are preferred, ensuring more accurate page calculations compared to using percentage units, which involve additional computations for determining page as well as row and column sizes.

## What other framework-based options exist for improving performance, particularly in the WASM?

This section provides performance guidelines for efficiently using the Syncfusion<sup style="font-size:70%">&reg;</sup> Pivot Table component in Blazor WebAssembly, besides built-in features. The best practices or guidelines for general framework Blazor WebAssembly performance can be found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-8.0).

### Avoid unnecessary component renders

During Blazor diffing algorithm, every cell of the pivot table component and its child component will be checked for re-rendering. For instance, having **EventCallBack** on the application or pivot table will check every child component once event callback is completed.

You can have fine-grained control over pivot table component rendering. The **PreventRender** method helps you to avoid unnecessary re-rendering of the pivot table component. This method internally overrides the **ShouldRender** method of the pivot table to prevent rendering.

In the following example:

* The **PreventRender** method is called in the **IncrementCount** method, which is a click event callback.

* Now, pivot table component will not be a part of the rendering which happens because of the click event and **currentCount** alone will get updated.

```cshtml
@using Syncfusion.Blazor.PivotView

<h1>Counter</h1>

<p>Current Count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<SfPivotView @ref="pivot" TValue="ProductDetails">
     <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    private List<ProductDetails> data { get; set; } 
    private SfPivotView<ProductDetails> pivot;   
    private int currentCount = 0;
    
    protected override void OnInitialized()
    {
        data = ProductDetails.GetProductData().ToList();
        // Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }

    private void IncrementCount()
    {
        pivot.PreventRender();
        currentCount++;
    }

    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}
```

N> * The **PreventRender** method takes a boolean argument that accepts **true** or **false** to disable or enable rendering respectively.
N> * This method can only be used after the pivot table component has completed its initial rendering. Calling this method during the initial rendering will have no effect.

### Avoid unnecessary component renders after pivot table events

When a callback method is assigned to the pivot table event, the parent component of the pivot table will automatically invoke its **StateHasChanged** when the event is completed.

You can prevent this re-rendering of the pivot table component by calling the **PreventRender** method.

In the following example, the [Drill](https://blazor.syncfusion.com/documentation/pivot-table/events#drill) event is bound with a callback method. So, after the drill event is completed, the parent component's **StateHasChanged** method will be invoked.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" AllowConditionalFormatting="true">
    <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewEvents TValue="ProductDetails" Drill="drill"></PivotViewEvents>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    private SfPivotView<ProductDetails> pivot;
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        // Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void drill(DrillArgs<ProductDetails> args)
    {
        pivot.PreventRender(true);
    }
}
```

N> * The **PreventRender** method internally overrides the component's **ShouldRender** method to prevent rendering.
N> * For better performance, it is recommended to use the **PreventRender** method for user interactive [events](https://blazor.syncfusion.com/documentation/pivot-table/events) like BeforeColumnsRender, BeforeExport, CellClick, ChartSeriesCreated, Drill, DrillThrough, etc.
N> * For events without any argument such as [DataBound](https://blazor.syncfusion.com/documentation/pivot-table/events#databound), you can use **PreventRender** method of the pivot table to disable rendering.

## What are the strategic approaches to addressing latency challenges?

Understanding the concerns you are facing regarding the lagging responsiveness of the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table](https://www.syncfusion.com/blazor-components) component, your situation has been reviewed, and several factors contributing to this issue have been identified. It’s important to note that when using dialog-oriented features like filtering and drill-through, a call is made from the client to the server, resulting in some delay if the servers are located in a distant location.

**Network Latency**: When the server is in a different region, the increased distance between the client and server leads to higher latency, impacting the responsiveness of client-server communication.

**Solution**: Host the server in a region closer to the majority of your users to reduce network latency. Choosing a server location nearer to your target audience can significantly improve response times.

For more information and further guidance, refer to the [documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server?view=aspnetcore-8.0) on hosting and deploying Blazor applications.