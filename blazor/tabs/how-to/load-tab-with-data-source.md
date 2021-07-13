---
layout: post
title: How to Load Tab With Data Source in Blazor Tabs Component | Syncfusion
description: Checkout and learn about Load Tab With Data Source in Blazor Tabs component of Syncfusion, and more details.
platform: Blazor
control: Tabs
documentation: ug
---

# Load tab with DataSource

You can bind any data object to Tab items, by mapping it to a [header](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.Navigations.TabHeader.html ) and [content](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Navigations.TabTabItem.html#Syncfusion_EJ2_Navigations_TabTabItem_Content)&nbsp; property.

In the below demo, Data is fetched from an `OData` service using `DataManager`. The result data is formatted as a JSON object with `header` and `content` fields, which is set to items property of Tab.

```csharp
```
