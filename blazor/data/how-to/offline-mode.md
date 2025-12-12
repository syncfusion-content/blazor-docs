---
layout: post
title: Working in Offline Mode in Blazor DataManager | Syncfusion
description: Learn how to enable offline mode in Syncfusion® Blazor DataManager to process queries locally without additional server requests.
platform: Blazor
control: DataManager
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Working in Offline Mode in Blazor DataManager Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataManager component provides **offline mode** to execute query operations on the client without additional server requests. When data is sourced from a remote service, enabling offline mode retrieves the complete collection during initialization and processes all subsequent operations locally. The cached data is maintained in the **Json** property.

To enable offline mode, set the [Offline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Offline) property to **true** on the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component.

## Key benefits of offline mode

Enabling the `Offline` property modifies the behavior of the `DataManager` component in the following ways:

- **Single data load** – Retrieves the complete collection during initialization without additional server requests.
- **Client-side processing** – Executes **filtering**, **sorting**, **paging**, and **grouping** operations in the browser.
- **Improved performance** – Minimizes **network traffic** and enhances responsiveness.
- **Offline functionality** – Maintains query operations even when network connectivity is unavailable.
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