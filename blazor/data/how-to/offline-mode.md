---
layout: post
title: Working in Offline Mode in Blazor DataManager | Syncfusion
description: Learn how to enable offline mode in Syncfusion® Blazor DataManager to process queries locally without additional server requests.
platform: Blazor
control: DataManager
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Working in Offline Mode in Blazor DataManager 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataManager provides **offline mode** to execute query operations on the client without additional server requests. When data is sourced from a remote service, enabling offline mode retrieves the complete collection during initialization and processes all subsequent operations locally. The cached data is maintained in the **Json** property.

To enable offline mode, set the [Offline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Offline) property to **true** on the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html).

## Key benefits of offline mode

Enabling the `Offline` property modifies the behavior of the `SfDataManager` in the following ways:

- **One-time data retrieval** – Retrieves the complete collection during initialization without additional server requests.
- **Client-side processing** – Handles **filtering**, **sorting**, **paging**, and **grouping** operations in the browser.
- **Improved performance** – Minimizes **network usage** and enhances responsiveness.
- **Offline functionality** – Continues to process queries even when the application is disconnected from the network.
- **Adaptor compatibility** – Supports **OData**, **Web API**, and **URL adaptors** without requiring extra configuration.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="EmployeeData" ID="Grid" AllowPaging="true">
    <SfDataManager Url="https://services.odata.org/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataAdaptor" Offline="true"></SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(EmployeeData.OrderID)" HeaderText="Order ID" Width="120" TextAlign="TextAlign.Center" />
        <GridColumn Field="@nameof(EmployeeData.CustomerID)" HeaderText="Customer Name" Width="130" TextAlign="TextAlign.Center" />
        <GridColumn Field="@nameof(EmployeeData.EmployeeID)" HeaderText="Employee ID" Width="120" TextAlign="TextAlign.Center" />
    </GridColumns>
</SfGrid>

@code {

  public class EmployeeData
  {
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
  }
}
```
N> Ensure that the remote endpoint returns the full data collection when the `Offline` property is enabled.

## When to use Offline mode

Offline mode is most effective when:

- The dataset is moderately sized and can be loaded during initialization.
- Data does not change frequently, reducing the risk of stale results.
- Client-side query processing provides a performance advantage.

## When to avoid Offline mode

Offline mode should be avoided in scenarios such as:

- Large datasets: Loading all records at once may cause performance issues in the browser.
- Frequently changing data: Cached data may become outdated quickly.
- Real-time requirements: Applications that depend on live or streaming data need server-side queries.
- Sensitive data: Storing all records on the client side may expose information unnecessarily.