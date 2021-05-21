---
layout: post
title: Blazor Client-side in .NET Core CLI in Blazor DataManager component - Syncfusion
description: Checkout and learn about Blazor Client-side in .NET Core CLI in Blazor DataManager component of Syncfusion, and more details
platform: Blazor
component: DataManager
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Essential JS 2 for Blazor client-side in .NET Core CLI

This article provides a step-by-step introduction to configure Essential JS 2 for Blazor setup, build and run a simple Blazor client-side web application using [.Net Core CLI](https://dotnet.microsoft.com/download/dotnet-core/3.0).

## Prerequisites

* [.NET Core SDK 3.0.100-preview6-012264](https://dotnet.microsoft.com/download/dotnet-core/3.0).

## Create a Blazor client-side project using .NET Core CLI

**Step 1:** Install the Blazor project templates by using below command line in the command prompt:

{% tabs %}

{% highlight C# %}

  dotnet new -i Microsoft.AspNetCore.Blazor.Templates::3.0.0-preview6.19307.2

{% endhighlight %}

{% endtabs  %}

**Step 2:** Once project templates installed, run the following command line to create a new Blazor client-side application.

{% tabs %}

{% highlight C# %}

  dotnet new blazor -o WebApplication1

  cd WebApplication1

{% endhighlight %}

{% endtabs  %}

## Adding Syncfusion Packages

**Step 1:** Now, add Syncfusion.Blazor NuGet package to the new application using below command line.

{% tabs %}

{% highlight C# %}

  dotnet add package Syncfusion.Blazor

  dotnet restore

{% endhighlight %}

{% endtabs  %}  

**Step 2:** The Syncfusion Blazor package will be included in the newly created project after the installation process is completed

**Step 3:** Open **~/_Imports.razor** file and import the `Syncfusion.Blazor`.

{% tabs %}

{% highlight C# %}

  @using Syncfusion.Blazor
  
  @using Syncfusion.Blazor.Grids

{% endhighlight %}

{% endtabs  %}  

## Adding Scripts and CSS reference

Add the client-side resource through CDN or local npm package in the `<head>` element of the **~/Pages/index.html** page.

{% tabs %}

{% highlight HTML %}

<head>
    ....
    ....
    <link href="https://cdn.syncfusion.com/blazor/styles/fabric.css" rel="stylesheet" />
</head>

{% endhighlight %}

{% endtabs  %}

## Add DataGrid Component

To initialize the DataGrid component add the below code to your **Index.razor** view page which is present under **~/Pages** folder. For example, the DataGrid component is added in the **~/Pages/Index.razor** page.

{% tabs %}

{% highlight C# %}

<SfGrid >

</SfGrid>

{% endhighlight %}

{% endtabs  %}

## Defining Row Data

To bind data for the DataGrid component, you can assign a IEnumerable object to the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. The list data source can also be provided as an instance of the `DataManager`. You can assign the data source through the **OnInitialized** lifecycle of the page.

{% tabs %}

{% highlight C# %}

<SfGrid DataSource="@gridData">

</SfGrid>

@code{
    public List<OrdersDetails> gridData { get; set; }
    protected override void OnInitialized()
    {
        gridData = OrdersDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% endtabs  %}

## Defining Columns

The columns are automatically generated when columns declaration is empty or undefined while initializing the datagrid.

The DataGrid has an option to define columns using [`GridColumns`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumns.html) component. In `GridColumn` component we have properties to customize columns.

Let’s check the properties used here:
* We have added [`Field`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) to map with a property name an array of JavaScript objects.
* We have added [`HeaderText`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) to change the title of columns.
* We have used [`TextAlign`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_TextAlign) to change the alignment of columns. By default, columns will be left aligned. To change columns to right align, we need to define `TextAlign` as `Right`.
* Also, we have used another useful property, [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format). Using this, we can format number and date values to standard or custom formats.

{% tabs %}

{% highlight C# %}

<SfGrid DataSource="@gridData">
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<OrdersDetails> gridData { get; set; }
    protected override void OnInitialized()
    {
        gridData = OrdersDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% endtabs  %}

## Enable Paging

The paging feature enables users to view the datagrid record in a paged view. It can be enabled by setting the [`AllowPaging`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) property to true. Pager can be customized using the [`GridPageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) component.

{% tabs %}

{% highlight C# %}

<SfGrid DataSource="@gridData" AllowPaging="true">
 <GridPageSettings PageSize="5"></GridPageSettings>
   <GridColumns>
     <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
   </GridColumns>
</SfGrid>

@code{
    public List<OrdersDetails> gridData { get; set; }
    protected override void OnInitialized()
    {
        gridData = OrdersDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% endtabs  %}

## Enable Sorting

The sorting feature enables you to order the records. It can be enabled by setting the [`AllowSorting`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property as true. Sorting feature can be customized using the [`GridSortSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortSettings) component.

{% tabs %}

{% highlight C# %}

<SfGrid DataSource="@gridData" AllowPaging="true" AllowSorting="true">
 <GridPageSettings PageSize="5"></GridPageSettings>
   <GridColumns>
     <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
   </GridColumns>
</SfGrid>

@code{
    public List<OrdersDetails> gridData { get; set; }
    protected override void OnInitialized()
    {
        gridData = OrdersDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% endtabs  %}

## Enable Filtering

The filtering feature enables you to view reduced amount of records based on filter criteria. It can be enabled by setting the [`AllowFiltering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property as true. Filtering feature can be customized using the [`FilterSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings) property.

{% tabs %}

{% highlight C# %}

<SfGrid DataSource="@gridData" AllowPaging="true" AllowSorting="true" AllowFiltering="true">
 <GridPageSettings PageSize="5"></GridPageSettings>
   <GridColumns>
     <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
   </GridColumns>
</SfGrid>

@code{
    public List<OrdersDetails> gridData { get; set; }
    protected override void OnInitialized()
    {
        gridData = OrdersDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% endtabs  %}

## Enable Grouping

The grouping feature enables you to view the datagrid record in a grouped view. It can be enabled by setting the [`AllowGrouping`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property as true. Grouping feature can be customized using the [`GridGroupSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings) component.

{% tabs %}

{% highlight C# %}

<SfGrid DataSource="@gridData" AllowPaging="true" AllowSorting="true" AllowFiltering="true" AllowGrouping="true">
 <GridPageSettings PageSize="5"></GridPageSettings>
   <GridColumns>
     <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
   </GridColumns>
</SfGrid>

@code{
    public List<OrdersDetails> gridData { get; set; }
    protected override void OnInitialized()
    {
        gridData = OrdersDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% endtabs  %}

Output be like the below.

![final output](../images/final-output.png)

## See Also

* [Getting Started with Syncfusion Blazor for Client-Side in Visual Studio 2019](./client-side-using-visual-studio)

* [Getting Started with Syncfusion Blazor for Server-Side in Visual Studio 2019](./server-side-using-visual-studio)

* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](./server-side-using-cli)