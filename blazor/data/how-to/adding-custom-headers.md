---
layout: post
title: Adding custom headers in Blazor DataManager Component | Syncfusion
description: Checkout and learn here all about adding custom headers in Syncfusion Blazor DataManager component and more.
platform: Blazor
control: DataManager
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Adding Custom Headers in Blazor DataManager

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [DataManager](https://blazor.syncfusion.com/documentation/data/getting-started-with-web-app) component supports adding **custom HTTP headers** to all outbound requests. This feature is essential when requests require additional metadata, such as **authentication tokens**, **tenant identifiers**, or **localization details**.

The [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Headers) property is used to configure these headers by assigning **key–value** pairs through an **IDictionary<string, string>** collection. Each request automatically includes the specified headers, enabling secure and context-aware communication without repetitive code.

**Key Capabilities**

Use the `Headers` property to add custom HTTP headers to requests made by [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). This includes sending authentication details such as a **Bearer token**.

* **Adaptor Support**

  Works with all built-in adaptors, including **Web API**, **OData**, and **URL adaptors**.

* **Automatic Integration**

  Headers are included when `DataManager` connects to components such as [SfGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html), [SfChart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html), or [SfListView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html).

* **Dynamic Updates**

  Modify headers at runtime for scenarios like **token refresh** or **context changes**.

* **Secure Transmission**

  Sensitive data such as **tokens** and **identifiers** remain in headers, reducing payload size and improving security.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
    <GridPageSettings PageSize="10"></GridPageSettings>
    <SfDataManager Headers="@HeaderData"
                   Url="https://blazor.syncfusion.com/services/production/api/Orders/"
                   Adaptor="Adaptors.WebApiAdaptor">
    </SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true"
                    TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Order.OrderDate)" HeaderText="Order Date" Format="d"
                    Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2"
                    TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
   
    private IDictionary<string, string> HeaderData = new Dictionary<string, string>
    {
        { "Authorization", "Bearer <token>" },
        { "X-Tenant-ID", "Tenant123" }
    };

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```