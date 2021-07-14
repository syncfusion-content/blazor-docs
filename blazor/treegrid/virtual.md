---
layout: post
title: Virtual in Blazor Tree Grid Component | Syncfusion 
description: Learn about Virtual in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Virtualization

Tree Grid allows you to load large amount of data without performance degradation.

## Row Virtualization

Row virtualization allows you to load and render rows only in the content viewport. It is an alternative way of paging in which the rows will be appended while scrolling vertically. To setup the row virtualization, you need to define
[`EnableVirtualization`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid%601~EnableVirtualization.html) as true and content height by [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid%601~Height.html) property.

The number of records displayed in the Tree Grid is determined implicitly by height of the content area and a buffer records will be maintained in the Tree Grid content in addition to the original set of rows.

Expand and Collapse state of any child record will be persisted.

```csharp

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Grids;

<SfTreeGrid TValue="VirtualData" DataSource="@TreeGridData" ChildMapping="Children" EnableVirtualization="true" Height="350" TreeColumnIndex="1">
        <TreeGridColumns>
            <TreeGridColumn Field="TaskID" HeaderText="Player Jersey" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="FIELD1" HeaderText="Player Name" Width="100"></TreeGridColumn>
            <TreeGridColumn Field="FIELD2" HeaderText="Year" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="FIELD3" HeaderText="Stint" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="FIELD4" HeaderText="TMID" Width="80"></TreeGridColumn>
        </TreeGridColumns>
    </SfTreeGrid>

@code{
    public VirtualData[] TreeGridData { get; set; }   

    protected override void OnInitialized()
    {
        this.TreeGridData = VirtualData.GetVirtualData().ToArray();
    } 
}

```

The following output is displayed as a result of the above code example.

![Virtualization](images/virtualization.gif)

## Limitations for Virtualization

* Due to the element height limitation in browsers, the maximum number of records loaded by the tree grid is limited by the browser capability.
* Cell selection will not be persisted in row.
* Virtual scrolling is not compatible with detail template.
* Row count of the page does not depend on the **PageSize** property of the **TreeGridPageSettings**. Row count for the page is determined by the [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid%601~Height.html) given to the Tree Grid.
* The virtual height of the tree grid content is calculated using the row height and total number of records in the data source and hence features which changes row height such as text wrapping are not supported. If you want to increase the row height to accommodate the content then you can specify the row height as below to ensure all the table rows are in same height.
* Programmatic selection using the **SelectRows** method is not supported in virtual scrolling.
* Frozen column feature is not supported with Virtual Scrolling.