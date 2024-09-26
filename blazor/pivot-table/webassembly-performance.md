---
layout: post
title: WebAssembly Performance in Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about WebAssembly Performance in Syncfusion Blazor Pivot Table component and more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# WebAssembly Performance in Blazor Pivot Table Component

This section provides performance guidelines for using the Syncfusion Pivot Table component efficiently in Blazor WebAssembly application. The best practice or guidelines for general framework Blazor WebAssembly performance can be found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-7.0).

N> You can refer to our Getting Started with [Blazor Server-Side Pivot Table](https://blazor.syncfusion.com/documentation/pivot-table/getting-started#blazor-server-app) and [Blazor WebAssembly Pivot Table](https://blazor.syncfusion.com/documentation/pivot-table/getting-started#blazor-webassembly-app) documentation pages for configuration specifications.

## Avoid unnecessary component renders

During Blazor diffing algorithm, every cell of the Pivot Table component and its child component will be checked for re-rendering. For instance, having **EventCallBack** on the application or Pivot Table will check every child component once event callback is completed.

You can have fine-grained control over Pivot Table component rendering. The **PreventRender** method helps you to avoid unnecessary re-rendering of the Pivot Table component. This method internally overrides the **ShouldRender** method of the Pivot Table to prevent rendering.

In the following example:

* The **PreventRender** method is called in the **IncrementCount** method which is a click callback.

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
}
```

N> The **PreventRender** method takes a boolean argument that accepts **true** or **false** to disable or enable rendering respectively.<br /> This method can only be used after the Pivot Table component has completed its initial rendering. Calling this method during the initial rendering will have no effect.

## Avoid unnecessary component renders after Pivot Table events

When a callback method is assigned to the Pivot Table event, the parent component of the Pivot Table will automatically invoke its **StateHasChanged** when the event is completed.

You can prevent this re-rendering of the Pivot Table component by calling the **PreventRender** method.

In the following example, the **Drill** event is bound with a callback method. So, after the drill event is completed, the parent component's **StateHasChanged** method will be invoked.

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

N> * The Pivot Table's **PreventRender** method internally overrides the component **ShouldRender** method to prevent rendering.
<br/> * For better performance, it is recommended to use the **PreventRender** method for user interactive events like Drill, BeforeColumnsRender, BeforeExport, DrillThrough, CellClick, ChartSeriesCreated, etc.
<br/> * For events without any argument such as **DataBound**, you can use **PreventRender** method of the Pivot Table to disable rendering.