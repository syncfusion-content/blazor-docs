---
layout: post
title: RefreshDataAsync in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about virtualization in Syncfusion Blazor MultiSelect Dropdown component and much more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# RefreshDataAsync in Blazor MultiSelect Dropdown Component

The Remote data source is dynamically updated using the **RefreshDataAsync** function. With the aid of this method, update the data source without the need for a [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query). This approach is not a necessary query to render a specific data source count. The **URL** link is required to accomplish that. 

The following  is used for the initial render by taking 5 data without using the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query) in the ODataV4 Adaptor.

{% highlight Razor %}

{% include_relative code-snippet/Counter.razor %}

{% endhighlight %}

![Blazor MultiSelect with virtualization](./images/blazor-multiselect-refreshdata.gif)

>When using the Refresh method with the filter enabled, the Filter Event must be used independently since the dynamically updated URL does not impact the data manager globally. Because of this, you must also call the Refresh data method at filter time.

The [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query) property handled the dynamic URL change when using the Web API Adaptor. Use a `WebAPIAdaptor` and a local data source with the Controller to update that URL. This allows you to modify the URL of the Web API Adaptor without affecting the query property. This applies to the Filter case also.

This `RefreshDataAsync` method allows you to render the remote data source component without the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query) property and refresh the remote data source without using the query property.

### OData adaptor:
The [OData](https://www.odata.org/documentation/odata-version-3-0/) adaptor allows you to render the component without the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query) property. Also, the adaptor is refreshed dynamically with the `RefreshDataAsync` method without using the query property.
The query property was directly mentioned in the Adaptor URL link.

### Web API adaptor:
The `WebApiAdaptor` remote data source is not directly affected by the URL link [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query) property because the WebApiAdaptor returns the value by the result and count format.
So, the local WebApiAdaptor is suggested to be used with the controller.

### Url adaptor:
The controller also uses the UrlAdaptor and the return value is in result format.
The RefreshDataAsync method is now used to refresh the URL Adaptor by updating the URL link without the query property.


