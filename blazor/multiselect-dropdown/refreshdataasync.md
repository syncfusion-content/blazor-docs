---
layout: post
title: RefreshDataAsync in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about RefreshDataAsync method in Syncfusion Blazor MultiSelect Dropdown component and much more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# RefreshDataAsync in Blazor MultiSelect Dropdown Component

Use the [RefreshDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_RefreshDataAsync) method to refresh the remote data source dynamically without changing the configured [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query). This method re-requests data from the configured endpoint (URL) and updates the popup list.

In the following example, the initial render loads five items without using Query. The data source is then refreshed to load eight items from the endpoint by calling RefreshDataAsync.

{% highlight Razor %}

{% include_relative code-snippet/ODataAdaptor.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with RefreshDataAsync](./images/blazor-multiselect-refreshdata.gif)

N> When using `RefreshDataAsync` with filtering enabled, prevent the component’s default filtering action in the `Filtering` event (set the cancel flag) before invoking the endpoint and calling `RefreshDataAsync`. This ensures that custom refresh logic runs without conflicting with the built-in behavior.

### Web API adaptor

When using `WebApiAdaptor`, implement a custom controller that handles OData-style query parameters for both initial loads and refresh requests. In this scenario, the endpoint URL is used for both rendering and refreshing the data source.

The following example shows `WebApiAdaptor` usage with a controller and the `RefreshDataAsync` method.

{% tabs %}
{% highlight cshtml tabtitle="Index.razor" %}

{% include_relative code-snippet/WebApiAdaptor.razor %}

{% endhighlight %}

{% highlight c# tabtitle="Controller.cs" %}

{% include_relative code-snippet/OrderController.cs %}

{% endhighlight %}
​​​​​​​{% endtabs %}

### URL adaptor

When using `UrlAdaptor`, the initial load requires `Query.RequiresCount()` to render data from the endpoint. For subsequent refreshes with `RefreshDataAsync`, the query is not required; only the endpoint URL is needed.

The following example shows `UrlAdaptor` usage with a controller and the `RefreshDataAsync` method.

{% tabs %}
{% highlight cshtml tabtitle="Index.razor" %}

{% include_relative code-snippet/UrlAdaptor.razor %}

{% endhighlight %}

{% highlight c# tabtitle="Controller.cs" %}

{% include_relative code-snippet/EmployeeDataController.cs %}

{% endhighlight %}
​​​​​​​{% endtabs %}