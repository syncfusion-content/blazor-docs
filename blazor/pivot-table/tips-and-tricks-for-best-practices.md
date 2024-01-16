---
layout: post
title: Performance tips for Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about best practices to improve the performance of the Syncfusion Blazor Pivot Table component and much more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Best practices to improve the performance of the Pivot Table

Performance optimization is crucial when working with large datasets in the [Syncfusion Blazor Pivot Table](https://www.syncfusion.com/blazor-components). This documentation provides practical tips and best practices to empower your data analysis and enhance the user experience.

N> In Blazor, the framework takes about 0.06 milliseconds to render one component on the page. You can find more details at the official [documentation link](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-8.0).

## Improve loading performance by referring individual nuget, script and CSS

To improve the performance of the [Syncfusion Blazor Pivot Table](https://www.syncfusion.com/blazor-components) component during the initial render as well as during certain UI actions, it is suggested that you refer to the individual NuGet package (Syncfusion.Blazor.PivotTable) along with the individual script and CSS files specific to the component. In the consolidated package (Syncfusion.Blazor), all the components will be defined, and hence the size of the package will be larger. Along with the script and CSS files, the file size will increase since the script and CSS necessary for all the Syncfusion Blazor components will be defined inside them.

When package, script, and CSS file sizes are larger, there might be a delay or performance lag in rendering the component in certain scenarios compared to the pivot table rendered using individual packages, scripts, and CSS. Individual NuGet packages will contain all the necessary and required dependent component sources, along with their script references. So, it is not necessary to refer to the dependent component externally while referring to the individual package.

Refer to the below documentation:
* [Individual NuGet package](https://blazor.syncfusion.com/documentation/pivot-table/getting-started-webapp)
* [Adding script and CSS](https://blazor.syncfusion.com/documentation/pivot-table/getting-started-webapp)

## Avoid incorporating column-related features

When dealing with large datasets, certain column-related features, such as resizing, autofit, text wrapping, and the dynamic hiding of specific columns, can significantly impact the pivot table's row height and column width at runtime. So, it's better to avoid them while virtual scrolling is enabled.

## Defer layout update

The Defer Layout Update feature allows users to perform operations in the Field List, such as rearranging fields, filtering, sorting, changing aggregation type, and more, without immediately updating the pivot table. The efficiency of this process is that when users complete their modifications and finally apply them by clicking the "Apply" button in the Field List, the pivot table is then updated based on the last modified report. By deferring the layout update until precisely requested, the Blazor Pivot Table remains the same, thereby providing minimal resource utilization and avoiding frequent re-rendering.

For more information on defer layout updates, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/defer-layout-update).

## Virtual scrolling

The virtual scrolling in the pivot table improves performance significantly, especially when handling large datasets, because it only renders the rows and columns within the current view. The remaining data is loaded dynamically as you scroll, either vertically or horizontally. For more information on implementing the virtual scrolling in the pivot table, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/virtual-scrolling).

### Best practices to use virtual scrolling in a pivot table

#### Single page mode

By default, the pivot table with virtual scrolling renders not only the current view page but also the previous and next pages. By using single-page mode along with virtual scrolling, only the rows and columns relevant to the current view page are rendered. This optimization enhances the performance of the pivot table significantly. For more information on implementing this feature, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/virtual-scrolling#single-page-mode).

#### Limiting the component size

Each row and cell in the pivot table is treated as an individual Razor component. However, loading an extensive number of rows and columns into the current view can strain memory consumption and CPU processing. To avoid such performance impacts, load a smaller set of rows and columns in the pivot table by defining and limiting the pivot table using [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGridSettings.html#Syncfusion_Blazor_PivotView_PivotViewGridSettings_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGridSettings.html#Syncfusion_Blazor_PivotView_PivotViewGridSettings_Width) properties. For example, 600px * 1000px, respectively, with just the pivot table alone (that is, without the grouping bar, toolbar, and other additional UI's).

N> The pixel units are preferred, and this ensures more accurate page calculations compared to using percentage units, which involve additional computations for determining page as well as row and column sizes.

## Paging

If your browser's maximum pixel height restricts you from utilizing Pivot Table with virtual scrolling, we advise you to utilize the paging feature instead of virtual scrolling. The paging feature, similar to virtual scrolling, enables you to load a large amount of data that may be split up and shown in the pivot table page by page. For more information on implementing the paging in the pivot table, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/paging).

## Data handling

Here is a list of best practices with respect to data handling via sorting, filtering, and grouping.

### Sorting

During initial rendering, applying sorting to fields other than the string data type, which holds a large number of members, takes time for the pivot engine to be framed (that is, internal pivot calculation). To overcome this performance constraint without affecting the outcome, the sorting option should be avoided. Instead, load the origin data into the data source in the order you want it to appear in the pivot table.

N> Once you pass the input data in the desired order and the pivot table is rendered, you can limit the sorting usage for runtime performance.

### Member Filtering

When dealing with large datasets, an effective strategy is to set a limit on the display of members in the filter dialog UI. By specifying a limit, the filter dialog UI will quickly display members up to that limit without encountering any performance constraints. To identify remaining members beyond the limit, a message indicating the count of remaining members will be displayed at the bottom of the filter dialog UI. To access the remaining members, use the search option included in the filter dialog at runtime. For more information on implementing the node limit in the filter dialog UI, see the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/filtering#performance-tips).

### Grouping

Using the pivot table's built-in grouping feature to group date, number, and string data type fields is not recommended. It obviously impacts the overall performance during pivot table rendering because it always consumes the input data to split and reframe based on the fields contained in the report that will be used for further pivot calculation.

To avoid this performance constraints, we recommend passing the input data source along with pre-processed group field sets based on your grouping needs. For example, if your input data has a date field "StartDate" with the value "15/AUG/2019 03:41 PM" and you want to display it as the year and month alone, split out the date field as "StartDate_Year" = "15/AUG/2019" for the year and "StartDate_Month" = "15/AUG/2019". And use the [FormatSettings](https://blazor.syncfusion.com/documentation/pivot-table/how-to/customize-number-and-date-format) property to show these date fields with the chosen date format. Similarly, to group a number field, just alter its value based on your group interval (e.g., 1-5, 6-10).

### Value Filtering

The [value filtering](https://blazor.syncfusion.com/documentation/pivot-table/filtering#value-filtering) primarily operates on grand totals, meaning the filtering process considers entire rows and columns to match applied value conditions. To achieve similar results with more flexibility, explore our label filtering or member filtering options. These alternates can yield similar results with better performance, especially when dealing with large datasets. More information on utilizing the [label filtering](https://blazor.syncfusion.com/documentation/pivot-table/filtering#label-filtering) or [member filtering](https://blazor.syncfusion.com/documentation/pivot-table/filtering#member-filtering) options can be found in the documentation section dedicated to these features.

## Data compression

When loading a large amount of input data (aka, raw data) into the pivot table, this data compression feature allows the input data to be compressed based on the uniqueness of the input data, and unique records will be provided as input for the pivot table's data source property. The compressed data will always be used for further operations, reducing looping complexity during internal pivot calculation and improving the pivot table performance. For more information on implementing the data compression in the pivot table, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/virtual-scrolling#data-compression).

### Best practices for utilizing data compression in pivot table

#### Unique Records vs. Data Compression

When dealing with a large amount of input data, specifically with fewer unique records available in the input data, data compression performs exceptionally well.

The effectiveness of data compression fails when your input data is entirely made up of more unique records. In such circumstances, using data compression in pivot tables is not suggested because the primary goal of data compression may not be met.

#### Unsupported aggregation types

Avoid setting complex aggregation types like Average, Populationsdev, Samplestdev, Populationvar, and Samplevar to the fields available in the pivot report that may hinder the data compression process.

## Server-side engine

Rather than using the Blazor Pivot Table's built-in engine to process large amounts of data, the server-side engine allows performing all pivot-oriented calculations in a separate hosted web service (Web API), and only the data to be displayed in the pivot table’s viewport is passed to the client-side (browser). It reduces network traffic and improves the pivot table's rendering performance, especially when virtual scrolling or paging is enabled. It also supports all of the pivot table’s existing features, such as data compression, filtering, sorting, aggregation, and more.

For more information on implementing the server-side engine in the pivot table, you can refer to the documentation [here](https://blazor.syncfusion.com/documentation/pivot-table/server-side-pivot-engine).

## Enhancing performance of Pivot Table in WASM application

Improving the performance of a Blazor Pivot Table in WebAssembly (WASM) requires more than just built-in features. This section provides performance guidelines for using the Syncfusion Pivot Table component efficiently in Blazor WebAssembly application. The best practice or guidelines for general framework Blazor WebAssembly performance can be found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-8.0).

### Avoid unnecessary component renders

During Blazor diffing algorithm, every cell of the Pivot Table component and its child component will be checked for re-rendering. For instance, having **EventCallBack** on the application or Pivot Table will check every child component once event callback is completed.

You can have fine-grained control over Pivot Table component rendering. The **PreventRender** method helps you to avoid unnecessary re-rendering of the Pivot Table component. This method internally overrides the **ShouldRender** method of the Pivot Table to prevent rendering.

In the following example:

* The **PreventRender** method is called in the **IncrementCount** method, which is a click event callback.

* Now, Pivot Table component will not be a part of the rendering which happens because of the click event and **currentCount** alone will get updated.

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
N> * This method can only be used after the Pivot Table component has completed its initial rendering. Calling this method during the initial rendering will have no effect.

### Avoid unnecessary component renders after Pivot Table events

When a callback method is assigned to the Pivot Table event, the parent component of the Pivot Table will automatically invoke its **StateHasChanged** when the event is completed.

You can prevent this re-rendering of the Pivot Table component by calling the **PreventRender** method.

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
N> * For better performance, it is recommended to use the **PreventRender** method for user interactive [events](https://blazor.syncfusion.com/documentation/pivot-table/events) like Drill, BeforeColumnsRender, BeforeExport, DrillThrough, CellClick, ChartSeriesCreated, etc.
N> * For events without any argument such as [DataBound](https://blazor.syncfusion.com/documentation/pivot-table/events#databound), you can use **PreventRender** method of the Pivot Table to disable rendering.

## Strategic approaches to addressing latency challenges

Understanding the concerns you are facing regarding the lagging responsiveness of the [Syncfusion Blazor Pivot Table](https://www.syncfusion.com/blazor-components) component, your situation has been reviewed, and several factors contributing to this issue have been identified. It’s important to note that when using dialog-oriented features like filtering and drill-through, a call is made from the client to the server, resulting in some delay if the servers are located in a distant location.

**Network Latency**: When the server is in a different region, the increased distance between the client and server leads to higher latency, impacting the responsiveness of client-server communication.

**Solution**: Host the server in a region closer to the majority of your users to reduce network latency. Choosing a server location nearer to your target audience can significantly improve response times.

For more information and further guidance, refer to the [documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server?view=aspnetcore-8.0) on hosting and deploying Blazor applications.